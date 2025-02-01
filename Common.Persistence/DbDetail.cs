using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence
{
    public class DbDetail
    {
        public DbDetail()
        {
            //Server = Environment.GetEnvironmentVariable("sqlServer") ?? string.Empty;
            //UserPassword = Environment.GetEnvironmentVariable("password") ?? string.Empty;
            //DatabaseName = Environment.GetEnvironmentVariable("database") ?? string.Empty;
            //UserName = Environment.GetEnvironmentVariable("sqlUser") ?? string.Empty;
            int.TryParse(Environment.GetEnvironmentVariable("maxPoolsize"), out int maxPoolsize);
            ConnectionPoolSize = maxPoolsize > 0 ? maxPoolsize : 100;
        }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int? ConnectionPoolSize { get; set; }

        public string ConnectionString
        {
            get
            {
                //Server = "database-1.cbs4s6s0a6jq.us-east-1.rds.amazonaws.com"; DatabaseName = "POS"; UserName = "admin"; UserPassword = "0YogAhn73lDVbFUozhSJ";
                //return $"Data Source=database-1.cbs4s6s0a6jq.us-east-1.rds.amazonaws.com;Initial Catalog=POS;User ID=admin;Password=0YogAhn73lDVbFUozhSJ; Integrated Security=true";
               return $"Data Source=DESKTOP-GBTCR3D\\SQLEXPRESS;Initial Catalog=InventoryERP; Integrated Security=true";
             // return $"Server={Server};Initial Catalog={DatabaseName};User ID={UserName};Password={UserPassword};Max Pool Size={ConnectionPoolSize}";
            }
        }
    }
}
