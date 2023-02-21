using System;
using System.Web.Mvc;
using TutorialMoneyAdminDataServices.Models.Calender;
using static TutorialMoneyAdminDataServices.Models.Calender.CalenderModalVM;

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
        /// <param name="date">カレンダーのモーダル画面の日付</param>
        /// <param name="mode">収入か支出どちらを選択しているか。</param>
        /// <returns>"mode"</returns>
        public ActionResult ShowCalenderModal(string date, int mode)
        {
            try
            {
                CalenderModalVM model = new CalenderModalVM();
                model.IncomeOrSpendMode = mode;
                switch (model.IncomeOrSpendMode)
                {
                    case (int)PaymentType.Income:
                        model.PlusOrMinusMark = "＋";
                        model.SpendOrIncomeWord = "収入金額";
                        model.IncomeOrSpendWordColor = "text-info";
                        model.IncomeOrSpendBorderColor = "border border-info";
                        model.IncomeOrSpendSeparateBorderColor = "border-right border-info";
                        model.Date = date;
                        break;
                    case (int)PaymentType.Spend:
                        model.PlusOrMinusMark = "ー";
                        model.SpendOrIncomeWord = "支出金額";
                        model.IncomeOrSpendWordColor = "text-danger";
                        model.IncomeOrSpendBorderColor = "border border-danger";
                        model.IncomeOrSpendSeparateBorderColor = "border-right border-danger";
                        model.Date = date;
                        break;
                }

                return PartialView("~/Views/Calender/_UpdateIncomeOrSpend.cshtml", model);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}