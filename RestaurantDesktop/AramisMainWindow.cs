using System.Diagnostics;
using Aramis.Core;
using Aramis.DatabaseUpdating;
using Aramis.Platform;
using Aramis.UI;
using Catalogs;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Documents;
using System;
using TradeHouse.AramisModels;
using TradeHouse.DatabaseObjects;

namespace TradeHouseDesktop
    {
    public partial class AramisMainWindow : DevExpress.XtraBars.Ribbon.RibbonForm, IMainForm
        {
        public Action ShowConnectionTroublesForm
            {
            get;
            set;
            }

        public bool AutoStartMode
            {
            get;
            set;
            }

        public void OnAutoStart()
            {
            "It's work!".AlertBox();
            }

        public ImageCollection SmallImagesCollection
            {
            get
                {
                return smallImagesCollection;
                }
            }

        public ImageCollection LargeImagesCollection
            {
            get
                {
                return largeImagesCollection;
                }
            }


        new public UserLookAndFeel LookAndFeel
            {
            get
                {
                return defaultLookAndFeel.LookAndFeel;
                }
            }

        public AramisMainWindow()
            {
            InitializeComponent();
            }

        private void Catalogs_ItemClick(object sender, ItemClickEventArgs e)
            {
            UserInterface.Current.ShowObjectSelectingView(AramisObjectType.Catalog);
            }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
            {
            UserInterface.Current.ShowObjectSelectingView(AramisObjectType.Document);
            }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e) { }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
            {
            //MatrixReports user = (MatrixReports)new Catalogs.MatrixReports().Read(1);
            //ReportTest1 form = new ReportTest1();
            //form.Item = user;
            //UserInterface.Current.ShowSystemObject(user, form);
            UserInterface.Current.ShowReport("іва");
            }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
            {
            Aramis.UI.UserInterface.Current.ShowList(typeof(MatrixReports));
            }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
            {
            Aramis.UI.UserInterface.Current.ShowList(typeof(MatrixAdapters));
            }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
            {
            Aramis.UI.UserInterface.Current.ShowList(typeof(Users));
            }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
            {
            new MotionsCreatorsUpdatingHelper().Update();
            }

        private void barButtonItem6_ItemClick_1(object sender, ItemClickEventArgs e)
            {
            }

        private void barButtonItem7_ItemClick_1(object sender, ItemClickEventArgs e)
            {
            }

        private void barButtonItem10_ItemClick_1(object sender, ItemClickEventArgs e)
            {
            }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
            {
            }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
            {
            }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
            {
            UserInterface.Current.ShowList(typeof(IExpenses), true);
            }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
            {
            }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
            {
            UserInterface.Current.ShowReport("Финансовый результат");
            }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
            {
            }

        private void barButtonItem22_ItemClick_1(object sender, ItemClickEventArgs e)
            {
            UserInterface.Current.ShowReport("Итог за неделю");
            }

        private void AramisMainWindow_Load(object sender, EventArgs e)
            {
            if (SolutionRoles.SuperAdmin || SolutionRoles.TopManager)
                {
                mainReportButton.Visibility = BarItemVisibility.Always;
                }
            }
        }


    }

