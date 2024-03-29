﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace TutorialMoneyAdmin.Controllers
{
    /// <summary>
    /// デフォルトのホームコントローラー
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// testtest
        /// </summary>
        /// <param name="test1">１つめの引数あれば使う</param>
        /// <param name="test2">２つめの引数あれば使う</param>
        /// <returns>戻り値記載します</returns>
        public ActionResult Index()
        {
            // ログ取得
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // ログ一覧　Info,Errorを主に使う
            // logger.Info($"{this.RouteData.Values["controller"].ToString()}コントローラーの{MethodBase.GetCurrentMethod().Name}アクションを実行しました！");
            // logger.Error($"{this.RouteData.Values["controller"].ToString()}コントローラーの{MethodBase.GetCurrentMethod().Name}アクションでエラー発生！");

            // logger.Fatal($"{ this.RouteData.Values["controller"].ToString()}コントローラーの{ MethodBase.GetCurrentMethod().Name}アクションで致命的なエラー発生！至急対応してください！");
            // logger.Error("システムが停止するまではいかない障害が発生");
            // logger.Fatal("システムが停止する致命的な障害が発生");
            // logger.Debug("開発中のデバッグ／トレースに使用する");
            // logger.Info("情報（操作履歴等）");
            // logger.Warn("注意／警告（障害の一歩手前）");
            return View();
        }

        /// <summary>
        /// testtest
        /// </summary>
        /// <param name="test1">１つめの引数あれば使う</param>
        /// <param name="test2">２つめの引数あれば使う</param>
        /// <returns>戻り値記載します</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// testtest
        /// </summary>
        /// <param name="test1">１つめの引数あれば使う</param>
        /// <param name="test2">２つめの引数あれば使う</param>
        /// <returns>戻り値記載します</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}