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
    /// �܂������L�ڂ��ׂ��ӏ����킩��Ȃ����ߌ���L��
    /// </summary>
    // SA11649�̌x���̗}�������Ă����B
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileNameMustMatchTypeName", Justification = "Reviewed.")]
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// �܂������L�ڂ��ׂ��ӏ����킩��Ȃ����ߌ���L��
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
