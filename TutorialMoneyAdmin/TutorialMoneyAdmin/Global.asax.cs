using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TutorialMoneyAdmin
{
    /// <summary>
    /// まだ何を記載すべき箇所かわからないため後日記載
    /// </summary>
    // SA11649の警告の抑制をしておく。
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileNameMustMatchTypeName", Justification = "Reviewed.")]
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// まだ何を記載すべき箇所かわからないため後日記載
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
