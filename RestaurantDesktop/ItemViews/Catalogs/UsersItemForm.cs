using Aramis.Core;
using Aramis.Enums;
using Aramis.Platform;
using Aramis.UI;
using Aramis.UI.WinFormsDevXpress;
using Catalogs;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Aramis.CommonForms
    {

    [Aramis.Attributes.View(DBObjectGuid = "A705F057-D476-46D6-BA96-0D6B111D1F85", ViewType = ViewFormType.CatalogItem, IsMDI = true)]
    public partial class UsersItemForm : DevExpress.XtraBars.Ribbon.RibbonForm, IItemForm
        {
        #region Поля и свойства

        private Users item;

        public IDatabaseObject Item
            {
            get
                {
                return item;
                }
            set
                {
                item = (Users)value;
                }
            }

        public Users User
            {
            get
                {
                return (Users)item;
                }
            }

        #endregion

        #region Event handling

        private void Itemform_Load(object sender, EventArgs e)
            {
            if (!User.IsNew && User.MobilePhone > 0)
                {
                string mobileNum = User.MobilePhone.ToString();
                stringMobilePhone.Text = string.Format("+{0} ({1}) {2}-{3}-{4}", mobileNum.Substring(0, 2), mobileNum.Substring(2, 3), mobileNum.Substring(5, 3), mobileNum.Substring(8, 2), mobileNum.Substring(10, 2));
                }
            }

        public UsersItemForm()
            {
            InitializeComponent();
            }

        private void TryCancel()
            {
            Close();
            }

        private void Itemform_KeyDown(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Escape)
                {
                TryCancel();
                }
            else if (e.KeyCode == Keys.Enter && e.Control)
                {
                OK_ItemClick(null, null);
                }
            else if (e.KeyCode == Keys.S && e.Control)
                {
                Write_ItemClick(null, null);
                }

            }

        #endregion

        private bool Write()
            {
            if (!SetMobileNumber())
                {
                return false;
                }

            return Item.Write() == WritingResult.Success;
            }

        private bool SetMobileNumber()
            {
            string mobileNum = stringMobilePhone.Text.Replace(" ", "").Replace("_", "").Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "");

            if (mobileNum.Length != 12)
                {
                User.MobilePhone = 0;
                }
            else
                {
                long longMobile = Convert.ToInt64(mobileNum);
                if (item.PhoneIsNotUnique(longMobile))
                    {
                    return false;
                    }
                User.MobilePhone = longMobile;
                }
            return true;
            }

        private void OK_ItemClick(object sender, ItemClickEventArgs e)
            {
            if (Write())
                {
                Close();
                }
            }

        private void Write_ItemClick(object sender, ItemClickEventArgs e)
            {
            Write();
            }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
            {
            TryCancel();
            }

        private void UsersItemForm_FormClosed(object sender, FormClosedEventArgs e)
            {
            if (!User.IsNew && SystemAramis.CurrentUser.Ref == User.Ref)
                {
                UIConsts.NotifyUserSkinWasReviewed(SystemAramis.CurrentUser.Skin);
                }
            }

        private void Password_Enter(object sender, EventArgs e)
            {
            ClearControl(EnteredPassword);
            ClearControl(RepeatedPassword);
            }

        private void ClearControl(TextEdit textEdit)
            {
            if (textEdit.Text == CatalogUsers.EMPTY_PASSWORD && !textEdit.Properties.ReadOnly)
                {
                textEdit.Text = "";
                }
            }

        private void Skin_Modified(object sender, EventArgs e)
            {
            if (!User.IsNew && SystemAramis.CurrentUser.Ref == User.Ref)
                {
                UIConsts.NotifyUserSkinWasReviewed((Skins)(Skin.SelectedIndex));

                UserInterface.WindowsManager.GetFormsList(AramisObjectType.Catalog, true).ForEach(ItemFormTuner.ComplateFormSkinUpdating);
                UserInterface.WindowsManager.GetFormsList(AramisObjectType.Document, true).ForEach(ItemFormTuner.ComplateFormSkinUpdating);
                }
            }

        private void detach_ItemClick(object sender, ItemClickEventArgs e)
            {
            MdiParent = null;
            }

        }
    }