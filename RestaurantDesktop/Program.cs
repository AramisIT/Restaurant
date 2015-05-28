using Aramis;
using Aramis.Platform;
using AramisDesktopUserInterface;
using Catalogs;
using System;

namespace TradeHouseDesktop
    {
    public static class Program
        {
        [STAThread, AramisSystem(DefaultLanguage = Language.Russian)]
        public static void Main(string[] args)
            {
            SystemAramis.SystemStart(args, new DesktopUserInterfaceEngine(typeof(AramisMainWindow), typeof(Users)));
            }
        }
    }


