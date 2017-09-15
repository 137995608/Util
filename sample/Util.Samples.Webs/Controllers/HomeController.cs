﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Util.Logs;
using Util.Logs.Abstractions;
using Util.Logs.Extensions;
using Util.Samples.Webs.Models;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller
    {
        public HomeController( ILogManager manager ) {
            Log = manager.GetLog(this);
        }

        public ILog Log { get; set; }

        public void Index() {
            Log.BusinessId( Guid.NewGuid().ToString() ).Trace();
        }

        public IActionResult Error()
        {
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}