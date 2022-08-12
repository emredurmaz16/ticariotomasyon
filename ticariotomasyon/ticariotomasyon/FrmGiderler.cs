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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void giderlistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            giderlistesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER" +
                " (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR)values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);
            komut.Parameters.AddWithValue("@p2", CmbYıl.Text);
            komut.Parameters.AddWithValue("@p3",decimal.Parse(TxtElektrik.Text));
            komut.Parameters.AddWithValue("@p4",decimal.Parse(TxtSu.Text));
            komut.Parameters.AddWithValue("@p5",decimal.Parse(TxtDoğalgaz.Text));
            komut.Parameters.AddWithValue("@p6",decimal.Parse(Txtİnternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtMaaşlar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@p9", decimal.Parse(RchNotlar.Text));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Tabloya Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderlistesi();


        }
    }
}
