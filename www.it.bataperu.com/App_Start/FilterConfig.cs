﻿using System.Web;
using System.Web.Mvc;

namespace www.it.bataperu.com
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
