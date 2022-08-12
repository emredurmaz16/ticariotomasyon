using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ticariotomasyon
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Dbo TicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
