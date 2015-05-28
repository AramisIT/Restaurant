using System;
using Aramis.Attributes;

namespace Catalogs
    {
    public class Consts : SystemConsts
        {
        public static IContractor UtkContractor
            {
            get
                {
                lock (locker)
                    {
                    return (IContractor)GetValueForObjectProperty("UtkContractor");
                    }
                }
            set
                {
                lock (locker)
                    {
                    SetValueForObjectProperty("UtkContractor", value);
                    }
                }
            }

        public static IExpensesArticles LoanBodyRepayment
            {
            get
                {
                lock (locker)
                    {
                    return (IExpensesArticles)GetValueForObjectProperty("LoanBodyRepayment");
                    }
                }
            set
                {
                lock (locker)
                    {
                    SetValueForObjectProperty("LoanBodyRepayment", value);
                    }
                }
            }

        public static IExpensesArticles LoanPercentsRepayment
            {
            get
                {
                lock (locker)
                    {
                    return (IExpensesArticles)GetValueForObjectProperty("LoanPercentsRepayment");
                    }
                }
            set
                {
                lock (locker)
                    {
                    SetValueForObjectProperty("LoanPercentsRepayment", value);
                    }
                }
            }

        public static IContractor OneTimeContractor
            {
            get
                {
                lock (locker)
                    {
                    return (IContractor)GetValueForObjectProperty("OneTimeContractor");
                    }
                }
            set
                {
                lock (locker)
                    {
                    SetValueForObjectProperty("OneTimeContractor", value);
                    }
                }
            }

        public static IExpensesArticles BankCommission
            {
            get
                {
                lock (locker)
                    {
                    return (IExpensesArticles)GetValueForObjectProperty("BankCommission");
                    }
                }
            set
                {
                lock (locker)
                    {
                    SetValueForObjectProperty("BankCommission", value);
                    }
                }
            }

        public static IExpensesArticles BonusesReturning
            {
            get
                {
                lock (locker)
                    {
                    return (IExpensesArticles)GetValueForObjectProperty("BonusesReturning");
                    }
                }
            set
                {
                lock (locker)
                    {
                    SetValueForObjectProperty("BonusesReturning", value);
                    }
                }
            }

        public static IExpensesArticles ArticleB
            {
            get
                {
                lock (locker)
                    {
                    return (IExpensesArticles)GetValueForObjectProperty("ArticleB");
                    }
                }
            set
                {
                lock (locker)
                    {
                    SetValueForObjectProperty("ArticleB", value);
                    }
                }
            }


        public static IExpensesArticles ArticleP
            {
            get
                {
                lock (locker)
                    {
                    return (IExpensesArticles)GetValueForObjectProperty("ArticleP");
                    }
                }
            set
                {
                lock (locker)
                    {
                    SetValueForObjectProperty("ArticleP", value);
                    }
                }
            }


        //[DataField(ReadOnly = true)]
        //public static string VisitorsPhotosFolderPath
        //    {
        //    get
        //        {
        //        lock (locker)
        //            {
        //            return z_VisitorsPhotosFolderPath;
        //            }
        //        }
        //    set
        //        {
        //        lock (locker)
        //            {
        //            if (z_VisitorsPhotosFolderPath != value)
        //                {
        //                z_VisitorsPhotosFolderPath = value;
        //                NotifyPropertyChanged("VisitorsPhotosFolderPath");
        //                }
        //            }
        //        }
        //    }
        //private static string z_VisitorsPhotosFolderPath;

        //[DataField(ReadOnly = true)]
        //public static string CameraName
        //    {
        //    get
        //        {
        //        lock (locker)
        //            {
        //            return z_CameraName;
        //            }
        //        }
        //    set
        //        {
        //        lock (locker)
        //            {
        //            if (z_CameraName != value)
        //                {
        //                z_CameraName = value;
        //                NotifyPropertyChanged("CameraName");
        //                }
        //            }
        //        }
        //    }
        //private static string z_CameraName;
        }
    }
