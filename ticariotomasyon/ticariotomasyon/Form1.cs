using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticariotomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FrmUrunler fr;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr==null)
            fr = new FrmUrunler();
            fr.MdiParent = this;
            fr.Show();

        }
        FrmMusterıler fr2;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null)
            fr2 = new FrmMusterıler();
            fr2.MdiParent = this;
            fr2.Show();


        }
        FrmFirmalar fr3;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr3 == null)
            fr3 = new FrmFirmalar();
            fr3.MdiParent = this;
            fr3.Show();


        }
        FrmPersonel fr4;
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr4 == null)
                fr4 = new FrmPersonel();
            fr4.MdiParent = this;
            fr4.Show();
        }
        FrmRehber fr5;
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr5 == null)
                fr5 = new FrmRehber();
            fr5.MdiParent = this;
            fr5.Show();
        }
        FrmGiderler fr6;
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null)
                fr6 = new FrmGiderler();
            fr6.MdiParent = this;
            fr6.Show();
        }
        FrmStoklar fr7;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null)
                fr7 = new FrmStoklar();
            fr7.MdiParent = this;
            fr7.Show();
        }
        FrmAyarlar fr8;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr8 == null)
                fr8 = new FrmAyarlar();
            fr8.Show();
        }
        FrmAnaSayfa fr9;
        private void BtnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null)
                fr9 = new FrmAnaSayfa();
            fr9.MdiParent = this;
            fr9.Show();
        }
    }
}
