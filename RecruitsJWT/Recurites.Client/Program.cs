using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // HttpClient 인스턴스 생성
            using var httpClient = new HttpClient();

            // Bearer Token 설정
            string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluIiwibmJmIjoxNzAwOTAwMTU0LCJleHAiOjE3MDA5MDA3NTQsImlhdCI6MTcwMDkwMDE1NH0.qkN064IhbJ4pg3JW6x-1T8RVv8BZlYKiv_wIyeNk0XY";
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

            // 요청할 URL
            string url = "https://localhost:7000/api/Recruites/hello";

            try
            {
                // GET 요청 수행
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // 응답 상태 코드 확인
                response.EnsureSuccessStatusCode();

                // 응답 본문을 문자열로 읽기
                string responseBody = await response.Content.ReadAsStringAsync();

                // 결과 출력
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                // 오류 처리
                Console.WriteLine($"Request exception: {e.Message}");
            }
        }
    }
}
