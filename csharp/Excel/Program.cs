// See https://aka.ms/new-console-template for more information

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Office.Interop.Excel;

string key = "AIMSKOREA+!@#$%^";
string iv = "AIMSKOREA+!@#$%^";


Application excelApp = new Application();


// 엑셀 파일 열기
Workbook workbook = excelApp.Workbooks.Open(@"D:\Projects\aims\최종작업중.xlsx");

// 첫 번째 시트 선택
Worksheet worksheet = (Worksheet)workbook.Sheets[1];

try
{
    //for (int i = 30000; i < worksheet.Rows.Count-1; i++)
    for (int i = 10; i < worksheet.Rows.Count - 1; i++)
    {
        var range = worksheet.Cells[i, 6];
        range.Value = DecryptString(range.Value);

        var range2 = worksheet.Cells[i, 7];
        range2.Value = DecryptString(range2.Value);

        Marshal.ReleaseComObject(range);
        Marshal.ReleaseComObject(range2);
    }

    workbook.Save();
}
finally
{
    workbook.Close();
    excelApp.Quit();
    Marshal.ReleaseComObject(worksheet);
    Marshal.ReleaseComObject(workbook);
    Marshal.ReleaseComObject(excelApp);

    GC.Collect();
}



string DecryptString(string encryptedText)
{
    byte[] keyBytes = Encoding.UTF8.GetBytes(key);
    byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

    using (Aes aes = Aes.Create())
    {
        aes.Mode = CipherMode.CBC;
        aes.Key = keyBytes;
        aes.IV = ivBytes;

        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using (MemoryStream ms = new MemoryStream(encryptedBytes))
        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
        using (StreamReader reader = new StreamReader(cs))
        {
            return reader.ReadToEnd();
        }
    }
}