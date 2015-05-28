namespace Aramis.UI.WinFormsDevXpress.Forms
    {
    partial class ConstsForm
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if ( disposing && ( components != null ) )
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.OKButton = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.warehouseParametersTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.OneTimeContractor = new Aramis.AramisSearchLookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.UtkContractor = new Aramis.AramisSearchLookUpEdit();
            this.DepartmentLabel = new DevExpress.XtraEditors.LabelControl();
            this.SystemEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.ArticleP = new Aramis.AramisSearchLookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.ArticleB = new Aramis.AramisSearchLookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.LoanBodyRepayment = new Aramis.AramisSearchLookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.LoanPercentsRepayment = new Aramis.AramisSearchLookUpEdit();
            this.BonusesReturning = new Aramis.AramisSearchLookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.BankCommission = new Aramis.AramisSearchLookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.warehouseParametersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OneTimeContractor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UtkContractor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoanBodyRepayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoanPercentsRepayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonusesReturning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankCommission.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.OKButton);
            this.ribbonStatusBar.ItemLinks.Add(this.barButtonItem1);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 490);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(584, 31);
            // 
            // OKButton
            // 
            this.OKButton.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.OKButton.Caption = "OK";
            this.OKButton.Id = 6;
            this.OKButton.ImageIndex = 0;
            this.OKButton.Name = "OKButton";
            this.OKButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OKButton_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Сменить камеру";
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonGroup1,
            this.OKButton,
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(584, 27);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 4;
            this.barButtonGroup1.ItemLinks.Add(this.OKButton);
            this.barButtonGroup1.MenuAppearance.AppearanceMenu.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.barButtonGroup1.MenuAppearance.AppearanceMenu.Normal.Options.UseFont = true;
            this.barButtonGroup1.MenuAppearance.MenuBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.barButtonGroup1.MenuAppearance.MenuBar.Options.UseFont = true;
            this.barButtonGroup1.MenuAppearance.MenuCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.barButtonGroup1.MenuAppearance.MenuCaption.Options.UseFont = true;
            this.barButtonGroup1.MenuAppearance.SideStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.barButtonGroup1.MenuAppearance.SideStrip.Options.UseFont = true;
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // warehouseParametersTabPage
            // 
            this.warehouseParametersTabPage.Controls.Add(this.OneTimeContractor);
            this.warehouseParametersTabPage.Controls.Add(this.labelControl7);
            this.warehouseParametersTabPage.Controls.Add(this.UtkContractor);
            this.warehouseParametersTabPage.Controls.Add(this.DepartmentLabel);
            this.warehouseParametersTabPage.Controls.Add(this.SystemEmail);
            this.warehouseParametersTabPage.Controls.Add(this.labelControl1);
            this.warehouseParametersTabPage.Name = "warehouseParametersTabPage";
            this.warehouseParametersTabPage.Size = new System.Drawing.Size(578, 435);
            this.warehouseParametersTabPage.Text = "Основні параметри системи";
            // 
            // OneTimeContractor
            // 
            this.OneTimeContractor.BaseFilter = null;
            this.OneTimeContractor.Location = new System.Drawing.Point(222, 77);
            this.OneTimeContractor.Name = "OneTimeContractor";
            this.OneTimeContractor.Properties.BaseFilter = null;
            this.OneTimeContractor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.OneTimeContractor.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.OneTimeContractor.Properties.FirstPopUp = null;
            this.OneTimeContractor.Properties.NullText = "";
            this.OneTimeContractor.Size = new System.Drawing.Size(312, 20);
            this.OneTimeContractor.TabIndex = 31;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl7.Location = new System.Drawing.Point(20, 79);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(190, 14);
            this.labelControl7.TabIndex = 32;
            this.labelControl7.Text = "Контрагент для разовой отгрузки";
            // 
            // UtkContractor
            // 
            this.UtkContractor.BaseFilter = null;
            this.UtkContractor.Location = new System.Drawing.Point(222, 22);
            this.UtkContractor.Name = "UtkContractor";
            this.UtkContractor.Properties.BaseFilter = null;
            this.UtkContractor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.UtkContractor.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.UtkContractor.Properties.FirstPopUp = null;
            this.UtkContractor.Properties.NullText = "";
            this.UtkContractor.Size = new System.Drawing.Size(312, 20);
            this.UtkContractor.TabIndex = 29;
            // 
            // DepartmentLabel
            // 
            this.DepartmentLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DepartmentLabel.Location = new System.Drawing.Point(20, 24);
            this.DepartmentLabel.Name = "DepartmentLabel";
            this.DepartmentLabel.Size = new System.Drawing.Size(22, 14);
            this.DepartmentLabel.TabIndex = 30;
            this.DepartmentLabel.Text = "УТК";
            // 
            // SystemEmail
            // 
            this.SystemEmail.Location = new System.Drawing.Point(222, 134);
            this.SystemEmail.MenuManager = this.ribbon;
            this.SystemEmail.Name = "SystemEmail";
            this.SystemEmail.Size = new System.Drawing.Size(312, 20);
            this.SystemEmail.TabIndex = 24;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 137);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "Email";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 27);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.warehouseParametersTabPage;
            this.xtraTabControl1.Size = new System.Drawing.Size(584, 463);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.warehouseParametersTabPage,
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.BankCommission);
            this.xtraTabPage1.Controls.Add(this.labelControl8);
            this.xtraTabPage1.Controls.Add(this.ArticleP);
            this.xtraTabPage1.Controls.Add(this.labelControl6);
            this.xtraTabPage1.Controls.Add(this.ArticleB);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Controls.Add(this.BonusesReturning);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(578, 435);
            this.xtraTabPage1.Text = "Специальные статьи расхода";
            // 
            // ArticleP
            // 
            this.ArticleP.BaseFilter = null;
            this.ArticleP.Location = new System.Drawing.Point(220, 195);
            this.ArticleP.Name = "ArticleP";
            this.ArticleP.Properties.BaseFilter = null;
            this.ArticleP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.ArticleP.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.ArticleP.Properties.FirstPopUp = null;
            this.ArticleP.Properties.NullText = "";
            this.ArticleP.Size = new System.Drawing.Size(321, 20);
            this.ArticleP.TabIndex = 40;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl6.Location = new System.Drawing.Point(21, 198);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 41;
            this.labelControl6.Text = "Статья Р";
            // 
            // ArticleB
            // 
            this.ArticleB.BaseFilter = null;
            this.ArticleB.Location = new System.Drawing.Point(220, 169);
            this.ArticleB.Name = "ArticleB";
            this.ArticleB.Properties.BaseFilter = null;
            this.ArticleB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.ArticleB.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.ArticleB.Properties.FirstPopUp = null;
            this.ArticleB.Properties.NullText = "";
            this.ArticleB.Size = new System.Drawing.Size(321, 20);
            this.ArticleB.TabIndex = 38;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl5.Location = new System.Drawing.Point(21, 172);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 39;
            this.labelControl5.Text = "Статья В";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.LoanBodyRepayment);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.LoanPercentsRepayment);
            this.groupControl1.Location = new System.Drawing.Point(11, 17);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(550, 103);
            this.groupControl1.TabIndex = 37;
            this.groupControl1.Text = "Займы";
            // 
            // LoanBodyRepayment
            // 
            this.LoanBodyRepayment.BaseFilter = null;
            this.LoanBodyRepayment.Location = new System.Drawing.Point(209, 33);
            this.LoanBodyRepayment.Name = "LoanBodyRepayment";
            this.LoanBodyRepayment.Properties.BaseFilter = null;
            this.LoanBodyRepayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.LoanBodyRepayment.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.LoanBodyRepayment.Properties.FirstPopUp = null;
            this.LoanBodyRepayment.Properties.NullText = "";
            this.LoanBodyRepayment.Size = new System.Drawing.Size(321, 20);
            this.LoanBodyRepayment.TabIndex = 31;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl2.Location = new System.Drawing.Point(15, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(178, 14);
            this.labelControl2.TabIndex = 32;
            this.labelControl2.Text = "Статья возвращение тела займа";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl3.Location = new System.Drawing.Point(15, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(183, 14);
            this.labelControl3.TabIndex = 34;
            this.labelControl3.Text = "Статья возвращение % по займу";
            // 
            // LoanPercentsRepayment
            // 
            this.LoanPercentsRepayment.BaseFilter = null;
            this.LoanPercentsRepayment.Location = new System.Drawing.Point(209, 68);
            this.LoanPercentsRepayment.Name = "LoanPercentsRepayment";
            this.LoanPercentsRepayment.Properties.BaseFilter = null;
            this.LoanPercentsRepayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.LoanPercentsRepayment.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.LoanPercentsRepayment.Properties.FirstPopUp = null;
            this.LoanPercentsRepayment.Properties.NullText = "";
            this.LoanPercentsRepayment.Size = new System.Drawing.Size(321, 20);
            this.LoanPercentsRepayment.TabIndex = 33;
            // 
            // BonusesReturning
            // 
            this.BonusesReturning.BaseFilter = null;
            this.BonusesReturning.Location = new System.Drawing.Point(220, 143);
            this.BonusesReturning.Name = "BonusesReturning";
            this.BonusesReturning.Properties.BaseFilter = null;
            this.BonusesReturning.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.BonusesReturning.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.BonusesReturning.Properties.FirstPopUp = null;
            this.BonusesReturning.Properties.NullText = "";
            this.BonusesReturning.Size = new System.Drawing.Size(321, 20);
            this.BonusesReturning.TabIndex = 35;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl4.Location = new System.Drawing.Point(21, 146);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(97, 14);
            this.labelControl4.TabIndex = 36;
            this.labelControl4.Text = "Выплата бонусов";
            // 
            // BankCommission
            // 
            this.BankCommission.BaseFilter = null;
            this.BankCommission.Location = new System.Drawing.Point(220, 221);
            this.BankCommission.Name = "BankCommission";
            this.BankCommission.Properties.BaseFilter = null;
            this.BankCommission.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.BankCommission.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.BankCommission.Properties.FirstPopUp = null;
            this.BankCommission.Properties.NullText = "";
            this.BankCommission.Size = new System.Drawing.Size(321, 20);
            this.BankCommission.TabIndex = 42;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl8.Location = new System.Drawing.Point(21, 224);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(90, 14);
            this.labelControl8.TabIndex = 43;
            this.labelControl8.Text = "Комиссия банка";
            // 
            // ConstsForm
            // 
            this.AllowDisplayRibbon = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 521);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(297, 434);
            this.Name = "ConstsForm";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Константы системы";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConstsForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Itemform_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.warehouseParametersTabPage.ResumeLayout(false);
            this.warehouseParametersTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OneTimeContractor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UtkContractor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoanBodyRepayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoanPercentsRepayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonusesReturning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankCommission.Properties)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.BarButtonItem OKButton;
        private DevExpress.XtraTab.XtraTabPage warehouseParametersTabPage;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraEditors.TextEdit SystemEmail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private AramisSearchLookUpEdit UtkContractor;
        private DevExpress.XtraEditors.LabelControl DepartmentLabel;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private AramisSearchLookUpEdit LoanPercentsRepayment;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private AramisSearchLookUpEdit LoanBodyRepayment;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private AramisSearchLookUpEdit BonusesReturning;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private AramisSearchLookUpEdit ArticleP;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private AramisSearchLookUpEdit ArticleB;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private AramisSearchLookUpEdit OneTimeContractor;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private AramisSearchLookUpEdit BankCommission;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        }
    }