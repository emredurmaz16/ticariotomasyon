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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void firmalistesi()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FIRMALAR",
                bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select * From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void carikodacıklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            TxtAd.Text="";
            Txtid.Text = "";
            TxtKod1.Text = "";
            TxtKod2.Text = "";
            TxtKod3.Text = "";
            TxtMaıl.Text = "";
            TxtSektör.Text = "";
            TxtVergı.Text = "";
            TxtYetkili.Text = "";
            TxtYetkiliGorev.Text = "";
            MskFax.Text = "";
            MskTc.Text = "";
            MskTelefon1.Text = "";
            MskTelefon2.Text = "";
            MskTelefon3.Text = "";
            RchAdres.Text = "";
            RchKod1.Text = "";
            RchKod2.Text = "";
            RchKod3.Text = "";
        }
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firmalistesi();
            temizle();
            sehirlistesi();
            carikodacıklamalar();
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)

        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                TxtAd.Text = dr["YETKILIADSOYAD"].ToString();
                TxtYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
                TxtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                MskTc.Text = dr["YETKILITC"].ToString();
                TxtSektör.Text = dr["SEKTOR"].ToString();
                MskTelefon1.Text = dr["TELEFON1"].ToString();
                MskTelefon2.Text = dr["TELEFON2"].ToString();
                MskTelefon3.Text = dr["TELEFON3"].ToString();
                TxtMaıl.Text = dr["MAİL"].ToString();
                MskFax.Text = dr["FAX"].ToString();
                CmbIl.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILÇE"].ToString();
                TxtVergı.Text = dr["VERGIDAIRE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtKod1.Text = dr["OZELKOD1"].ToString();
                TxtKod2.Text = dr["OZELKOD2"].ToString();
                TxtKod3.Text = dr["OZELKOD3"].ToString();


            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR" +
                " AD,SOYAD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAİL,FAX,IL,ILCE,VERIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3 " +
                "VALUES @P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17");
                bgl.baglanti();
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtSektör.Text);
            komut.Parameters.AddWithValue("@p6", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p7", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", MskTelefon3.Text);
            komut.Parameters.AddWithValue("@p9", TxtMaıl.Text);
            komut.Parameters.AddWithValue("@p10", MskFax.Text);
            komut.Parameters.AddWithValue("@p11", CmbIl.Text);
            komut.Parameters.AddWithValue("@p12", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p13", TxtVergı.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", TxtKod1.Text);
            komut.Parameters.AddWithValue("@p16", TxtKod2.Text);
            komut.Parameters.AddWithValue("@p17", TxtKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistesi();
            temizle();
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select * From TBL_ILCELER where Sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_FIRMALAR where ID=@P1",
                bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            firmalistesi();
           
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_MUSTERILER set" +
                " AD=@P1,YETKILISTATU=@P2,YETKILIADSOYAD=@P3,YETKILITC=@P4,SEKTOR=@P5,TELEFON1=@P6,TELEFON2=" +
                "@P7,TELEFON3=@P8,MAİL=@P9,IL=@P11,ILÇE=@P12,FAX=@P10,VERGIDAIRE=@P13,ADRES=@P14,OZELKOD1=" +
                "@P15,OZELKOD2_@P16,OZELKOD3,@P17 where ID= @P18", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtSektör.Text);
            komut.Parameters.AddWithValue("@p6", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p7", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", MskTelefon3.Text);
            komut.Parameters.AddWithValue("@p9", TxtMaıl.Text);
            komut.Parameters.AddWithValue("@p10", MskFax.Text);
            komut.Parameters.AddWithValue("@p11", CmbIl.Text);
            komut.Parameters.AddWithValue("@p12", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p13", TxtVergı.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", TxtKod1.Text);
            komut.Parameters.AddWithValue("@p16", TxtKod2.Text);
            komut.Parameters.AddWithValue("@p17", TxtKod3.Text);
            komut.Parameters.AddWithValue("@p18", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firmalistesi();
            temizle();
        }
    }
}
