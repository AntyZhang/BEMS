using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using BEMS.Common;

namespace BEMS.BAL
{
    public class GlobalBusiness
    {
        public static string GetSiteName()
        {
            return AppConfiguration.Configuration["Appsettings:SiteName"];
        }
    }
}
