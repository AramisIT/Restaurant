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
                // ���� �� ���� ������, ������ ���������� �� �������� ���� �� �� ������
                SystemConsts.�onstsAutoUpdating = false;
                }
            }

        private void ConstsForm_FormClosed(object sender, FormClosedEventArgs e)
            {
            SystemConsts.�onstsAutoUpdating = true;
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