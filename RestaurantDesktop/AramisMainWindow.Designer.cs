namespace TradeHouseDesktop
    {
    partial class AramisMainWindow
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AramisMainWindow));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.smallImagesCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.Catalogs = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem18 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
            this.mainReportButton = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem27 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem22 = new DevExpress.XtraBars.BarButtonItem();
            this.largeImagesCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallImagesCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeImagesCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Images = this.smallImagesCollection;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.Catalogs,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem9,
            this.barButtonItem13,
            this.barButtonItem15,
            this.barButtonItem17,
            this.barButtonItem18,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem10,
            this.barButtonItem12,
            this.barButtonItem14,
            this.barButtonItem16,
            this.barButtonItem19,
            this.mainReportButton,
            this.barSubItem1,
            this.barButtonItem27,
            this.barButtonItem22});
            this.ribbon.LargeImages = this.largeImagesCollection;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 59;
            this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Never;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(970, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            // 
            // smallImagesCollection
            // 
            this.smallImagesCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("smallImagesCollection.ImageStream")));
            // 
            // Catalogs
            // 
            this.Catalogs.Caption = "Справочники";
            this.Catalogs.Id = 1;
            this.Catalogs.LargeImageIndex = 0;
            this.Catalogs.Name = "Catalogs";
            this.Catalogs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Catalogs_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Документы";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.LargeImageIndex = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Тест хранения файлов";
            this.barButtonItem3.Id = 4;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem9.Id = 11;
            this.barButtonItem9.ImageIndex = 2;
            this.barButtonItem9.LargeImageIndex = 1;
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem9.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem13
            // 
            this.barButtonItem13.Caption = "barButtonItem13";
            this.barButtonItem13.Id = 19;
            this.barButtonItem13.Name = "barButtonItem13";
            this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem13_ItemClick);
            // 
            // barButtonItem15
            // 
            this.barButtonItem15.Caption = "Отчеты";
            this.barButtonItem15.Id = 23;
            this.barButtonItem15.LargeImageIndex = 31;
            this.barButtonItem15.Name = "barButtonItem15";
            this.barButtonItem15.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem15_ItemClick);
            // 
            // barButtonItem17
            // 
            this.barButtonItem17.Caption = "Адаптеры";
            this.barButtonItem17.Id = 25;
            this.barButtonItem17.Name = "barButtonItem17";
            this.barButtonItem17.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem17_ItemClick);
            // 
            // barButtonItem18
            // 
            this.barButtonItem18.Caption = "Пользователи";
            this.barButtonItem18.Id = 26;
            this.barButtonItem18.Name = "barButtonItem18";
            this.barButtonItem18.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem18_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Прием товара";
            this.barButtonItem6.Id = 42;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick_1);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Отгрузка товара";
            this.barButtonItem7.Id = 43;
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick_1);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "Инвентаризация";
            this.barButtonItem10.Id = 44;
            this.barButtonItem10.Name = "barButtonItem10";
            this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick_1);
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "Приход денежн. средств";
            this.barButtonItem12.Id = 45;
            this.barButtonItem12.Name = "barButtonItem12";
            this.barButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem12_ItemClick);
            // 
            // barButtonItem14
            // 
            this.barButtonItem14.Caption = "Расход денежн. средств";
            this.barButtonItem14.Id = 46;
            this.barButtonItem14.Name = "barButtonItem14";
            this.barButtonItem14.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem14_ItemClick);
            // 
            // barButtonItem16
            // 
            this.barButtonItem16.Caption = "Затраты";
            this.barButtonItem16.Id = 47;
            this.barButtonItem16.Name = "barButtonItem16";
            this.barButtonItem16.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem16_ItemClick);
            // 
            // barButtonItem19
            // 
            this.barButtonItem19.Caption = "Долги";
            this.barButtonItem19.Id = 48;
            this.barButtonItem19.Name = "barButtonItem19";
            this.barButtonItem19.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem19_ItemClick);
            // 
            // mainReportButton
            // 
            this.mainReportButton.Caption = "Финансовый результат";
            this.mainReportButton.Id = 50;
            this.mainReportButton.Name = "mainReportButton";
            this.mainReportButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.mainReportButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem22_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Учет долгов";
            this.barSubItem1.Id = 52;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem19),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem27)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem27
            // 
            this.barButtonItem27.Caption = "Погашение долгов";
            this.barButtonItem27.Id = 53;
            this.barButtonItem27.Name = "barButtonItem27";
            this.barButtonItem27.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem27_ItemClick);
            // 
            // barButtonItem22
            // 
            this.barButtonItem22.Caption = "Итог за неделю";
            this.barButtonItem22.Id = 54;
            this.barButtonItem22.Name = "barButtonItem22";
            this.barButtonItem22.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem22_ItemClick_1);
            // 
            // largeImagesCollection
            // 
            this.largeImagesCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.largeImagesCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("largeImagesCollection.ImageStream")));
            this.largeImagesCollection.Images.SetKeyName(17, "fenology.png");
            this.largeImagesCollection.Images.SetKeyName(18, "ExternalData.png");
            this.largeImagesCollection.Images.SetKeyName(19, "Priva.png");
            this.largeImagesCollection.Images.SetKeyName(20, "61616175_10bddf4ddcd4.png");
            this.largeImagesCollection.Images.SetKeyName(21, "1306484724_gnome-help.png");
            this.largeImagesCollection.Images.SetKeyName(22, "iWarning.png");
            this.largeImagesCollection.Images.SetKeyName(23, "Tasks for me.png");
            this.largeImagesCollection.Images.SetKeyName(24, "Build_52.png");
            this.largeImagesCollection.Images.SetKeyName(25, "Print.png");
            this.largeImagesCollection.Images.SetKeyName(26, "database_save.png");
            this.largeImagesCollection.Images.SetKeyName(27, "1308134199_page_save.png");
            this.largeImagesCollection.Images.SetKeyName(28, "Tasks to control.png");
            this.largeImagesCollection.Images.SetKeyName(29, "My tasks.png");
            this.largeImagesCollection.Images.SetKeyName(30, "Actions-view-calendar-month-icon.png");
            this.largeImagesCollection.Images.SetKeyName(31, "stock_task.png");
            this.largeImagesCollection.Images.SetKeyName(32, "1311149276_3d bar chart.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Основная панель";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.Catalogs);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem15);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem17);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem18);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Объекты системы";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem10);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem12);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem14);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem16);
            this.ribbonPageGroup2.ItemLinks.Add(this.barSubItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Документы";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.mainReportButton);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem22);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Отчеты";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barButtonItem9);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 418);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(970, 31);
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Blue";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Справочники";
            this.barButtonItem4.Id = 16;
            this.barButtonItem4.ImageIndex = 1;
            this.barButtonItem4.LargeImageIndex = 0;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // AramisMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 449);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "AramisMainWindow";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Торговый дом";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AramisMainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallImagesCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeImagesCollection)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.Utils.ImageCollection largeImagesCollection;
        private DevExpress.Utils.ImageCollection smallImagesCollection;
        private DevExpress.XtraBars.BarButtonItem Catalogs;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private DevExpress.XtraBars.BarButtonItem barButtonItem18;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        private DevExpress.XtraBars.BarButtonItem barButtonItem19;
        private DevExpress.XtraBars.BarButtonItem mainReportButton;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem27;
        private DevExpress.XtraBars.BarButtonItem barButtonItem22;
        }
    }