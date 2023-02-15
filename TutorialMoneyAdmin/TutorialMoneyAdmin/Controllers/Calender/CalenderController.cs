﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorialMoneyAdmin.Controllers.Calender
{
    /// <summary>
    /// トップページにカレンダーに関する機能を実装する
    /// <summary>
    public class CalenderController : Controller
    {
        /// <summary>
        /// トップページを表示
        /// </summary>
        /// <returns>戻り値記載します</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// カレンダー日付クリック時に生成されるモーダルを作成
        /// </summary>
        /// <returns>戻り値記載します</returns>
        public ActionResult ShowCalenderModal()
        {
            return PartialView("~/Views/Calender/_UpdateIncomeOrSpend.cshtml");
        }
    }
}