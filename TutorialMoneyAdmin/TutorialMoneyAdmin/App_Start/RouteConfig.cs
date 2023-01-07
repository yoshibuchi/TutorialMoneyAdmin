using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TutorialMoneyAdmin
{
    /// <summary>
    /// ルーティングの設定
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// ルーティングの設定をします。
        /// </summary>
        /// <param name="routes">ルート先</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // カレンダー画面をトップ画面とする。
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Calender", action = "Index", id = UrlParameter.Optional });
        }
    }
}
