using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlyBanHang
{
    public static class SqlCon
    {
        public static string ConnectionString = @"Data Source=DESKTOP-1417HQ2\SQLEXPRESS02;Initial Catalog=QLBanHang;Integrated Security=True";
        public static SqlConnection GetConnection()
        {
           return new SqlConnection(ConnectionString);
        }
    }
}
