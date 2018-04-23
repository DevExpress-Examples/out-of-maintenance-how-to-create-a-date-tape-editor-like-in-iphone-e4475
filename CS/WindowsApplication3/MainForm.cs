using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraBars.Helpers;


namespace WindowsApplication3 {
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void InitData()
        {
            for (int i = 0; i < 5; i++)
            {
                dataSet11.Tables[0].Rows.Add(new object[] { i, string.Format("FirstName {0}", i), i, imageList1.Images[i], DateTime.Today.AddDays(i), true });
                dataSet11.Tables[1].Rows.Add(new object[] { i, string.Format("FirstName {0}", i), i });
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitData();
            SkinHelper.InitSkinGallery(galleryControl1);
            dateTapeEdit1.EditValue = DateTime.Now;
        }

    }
}
