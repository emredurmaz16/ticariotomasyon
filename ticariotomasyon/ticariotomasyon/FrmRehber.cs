﻿using System;
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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmRehber_Load(object sender, EventArgs e)
        {
            //MÜŞTERİ BİLGİLERİ
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAİL From TBL_MUSTERILER",
                bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //FİRMA BİLGİLERİ
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select AD,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAİL,FAX from TBL_FIRMALAR",
                bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }
        
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if( dr != null)
            {
                frm.mail = dr["MAİL"].ToString();
            }
            frm.Show();
        }

       
    }
}
