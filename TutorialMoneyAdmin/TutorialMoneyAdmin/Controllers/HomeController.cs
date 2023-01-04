using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TutorialMoneyAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            logger.Debug("開発中のデバッグ／トレースに使用する");
            logger.Info("情報（操作履歴等）");
            logger.Warn("注意／警告（障害の一歩手前）");
            logger.Error("システムが停止するまではいかない障害が発生");
            logger.Fatal("システムが停止する致命的な障害が発生");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}