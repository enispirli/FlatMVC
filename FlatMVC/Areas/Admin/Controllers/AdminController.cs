﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlatMVC.Areas.Admin.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        // admin controler constructer calıştığında session ve diğer şeyler oluşmadığı için Begin Execute methodunu ezdik
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.Session["Giris"] == null)
            {
                requestContext.HttpContext.Response.Redirect("/Admin/Home/Login");
            }
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}