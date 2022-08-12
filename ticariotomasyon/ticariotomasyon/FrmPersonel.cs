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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        
        void personelliste()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_PERSONELLER",
                bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            personelliste();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER " +
                "(AD,SOYAD,TELEFON,TC,MAİL,IL,ILCE,ADRES,GOREV) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@P9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", CmbIl.Text);
            komut.Parameters.AddWithValue("@p7", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", RchAdres.Text);
            komut.Parameters.AddWithValue("@p9", TxtGörev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            personelliste();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Verileri Silme
            SqlCommand komut = new SqlCommand("Delete From TBL_PERSONELLER where ID=@P1",
                bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
            personelliste();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_PERSONELLER set " +
                 "(AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAİL=@P5,IL=@P6,ILCE=@P7,ADRES=@P8,GOREV=@P9) values " +
                 bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", CmbIl.Text);
            komut.Parameters.AddWithValue("@p7", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", RchAdres.Text);
            komut.Parameters.AddWithValue("@p9", TxtGörev.Text);
            komut.Parameters.AddWithValue("@p10", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            personelliste();
        }
    }
}
