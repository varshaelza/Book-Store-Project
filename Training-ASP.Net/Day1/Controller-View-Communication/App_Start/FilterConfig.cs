﻿using System.Web;
using System.Web.Mvc;

namespace Controller_View_Communication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
