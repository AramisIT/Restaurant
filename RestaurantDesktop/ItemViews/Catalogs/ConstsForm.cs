using Catalogs;
using DevExpress.XtraBars;
using System;
using System.Windows.Forms;

namespace Aramis.UI.WinFormsDevXpress.Forms
    {
    public partial class ConstsForm : DevExpress.XtraBars.Ribbon.RibbonForm
        {
        public ConstsForm()
            {
            InitializeComponent();

            lock (SystemConsts.locker)
                {
                // Если мы сюда попали, значит обновление не начнется пока мы не выйдем
                SystemConsts.СonstsAutoUpdating = false;
                }
            }

        private void ConstsForm_FormClosed(object sender, FormClosedEventArgs e)
            {
            SystemConsts.СonstsAutoUpdating = true;
            }

        private void Itemform_KeyDown(object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Escape:
                    Close();
                    break;
                }
            }

        private void OKButton_ItemClick(object sender, ItemClickEventArgs e)
            {
            Close();
            }
        }
    }