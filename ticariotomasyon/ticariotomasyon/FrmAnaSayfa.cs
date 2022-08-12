using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ticariotomasyon
 
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Urunad,Sum(Adet) as 'Adet' From TBL_URUNLER " +
                "group by Urunad having Sum(adet) <= 20 order by Sum(adet)", bgl.baglanti());
            da.Fill(dt);
            GridControlStoklar.DataSource = dt;
        }
        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 8 nottarıh,notsaat,notbaslık from tbl_Notlar order by notID desc", bgl.baglanti());
            da.Fill(dt);
            GridControlAjanda.DataSource = dt;
        }
        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,Telefon1 from Tbl_Fırmalar", bgl.baglanti());
            da.Fill(dt);
            GridControlFiHRİST.DataSource = dt;
        }
        
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            fihrist();
            webBrowser1.Navigate("https://www.tcmb.gov.tr/wps/wcm/connect/tr/tcmb+tr/main+page+site+area/bugun");
            
        }
    }
}
