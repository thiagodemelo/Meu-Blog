﻿using blog.Filters;
using System.Web;
using System.Web.Mvc;

namespace blog
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new SaveChangesFilter());
        }
    }
}