using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerSeri
{
    internal class Player
    {
        public Player() { }

        public void Attack() 
        {
            Log.Information("Attack");
        }
    }
}
