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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void Btnİşlem_Click(object sender, EventArgs e)
        {
            if (Btnİşlem.Text == "Kaydet") {
            SqlCommand komut = new SqlCommand("insert into TBL_ADMIN values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Admin Sisteme Eklendi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
            if (Btnİşlem.Text == "Güncelle")
            {
                SqlCommand komut = new SqlCommand("update tbl_ADMIN set Sifre=@p2 wherekullaniciad=@p2");bgl.baglanti();
                komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Güncellendi", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }

    }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if(dr != null)
            {
                TxtKullaniciAd.Text=dr["KullaniciAd"].ToString();
                TxtSifre.Text = dr["Sifre"].ToString();
            }
        }

        private void TxtKullaniciAd_TextChanged(object sender, EventArgs e)
        {
            if(TxtKullaniciAd.Text != "")
            {
                Btnİşlem.Text="Güncelle";
                Btnİşlem.BackColor = Color.GreenYellow;

            }
            else
            {
                Btnİşlem.Text = "Kaydet";
                Btnİşlem.BackColor = Color.Turquoise;
            }
        }
    }
}
