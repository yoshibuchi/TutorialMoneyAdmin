using System;
using System.Web.Mvc;
using MySqlConnector;
using TutorialMoneyAdminDataServices.DataServices.Category;
using TutorialMoneyAdminDataServices.DataServices.Common;
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
                var connectionString = CommonDataService.GetConnectionString();
                using (var conn = new MySqlConnection(connectionString))
                {
                    model.IncomeOrSpendMode = mode;
                    model.SelectLargeCategory = mode == (int)PaymentType.Income ? (int)UncategorizedType.IncomeLargeCategoryId : (int)UncategorizedType.SpendLargeCategoryId;
                    model.SelectMiddleCategory = mode == (int)PaymentType.Income ? (int)UncategorizedType.IncomeMiddleCategoryId : (int)UncategorizedType.SpendMiddleCategoryId;
                    var incomeLargeCategoryList = IncomeOrSpendCategoryDataService.CreateIncomeLargeCategory(conn);
                    var incomeMiddleCategoryList = IncomeOrSpendCategoryDataService.CreateIncomeMiddleCategory(model.SelectLargeCategory, conn);
                    var spendLargeCategoryList = IncomeOrSpendCategoryDataService.CreateSpendLargeCategory(conn);
                    var spendMiddleCategoryList = IncomeOrSpendCategoryDataService.CreateSpendMiddleCategory(model.SelectLargeCategory, conn);
                    switch (model.IncomeOrSpendMode)
                    {
                        case (int)PaymentType.Income:
                            model.PlusOrMinusMark = "＋";
                            model.SpendOrIncomeWord = "収入金額";
                            model.IncomeOrSpendWordColor = "text-info";
                            model.IncomeOrSpendBorderColor = "border border-info";
                            model.IncomeOrSpendSeparateBorderColor = "border-right border-info";
                            model.LargeCategory = new SelectList(incomeLargeCategoryList, "IncomeLargeCategoryId", "IncomeLargeCategoryName", model.SelectLargeCategory);
                            model.MiddleCategory = new SelectList(incomeMiddleCategoryList, "IncomeMiddleCategoryId", "IncomeMiddleCategoryName", model.SelectMiddleCategory);
                            model.IncomeOrSpendDate = date;
                            break;
                        case (int)PaymentType.Spend:
                            model.PlusOrMinusMark = "ー";
                            model.SpendOrIncomeWord = "支出金額";
                            model.IncomeOrSpendWordColor = "text-danger";
                            model.IncomeOrSpendBorderColor = "border border-danger";
                            model.IncomeOrSpendSeparateBorderColor = "border-right border-danger";
                            model.LargeCategory = new SelectList(spendLargeCategoryList, "SpendLargeCategoryId", "SpendLargeCategoryName", model.SelectLargeCategory);
                            model.MiddleCategory = new SelectList(spendMiddleCategoryList, "SpendMiddleCategoryId", "SpendMiddleCategoryName", model.SelectMiddleCategory);
                            model.IncomeOrSpendDate = date;
                            break;
                    }

                    return PartialView("~/Views/Calender/_UpdateIncomeOrSpend.cshtml", model);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        /// <summary>
        /// カレンダー日付クリック時に生成されるモーダルを作成
        /// </summary>
        /// <param name="selectCategory">ドロップダウンでどの大カテゴリーを選択しているか。</param>
        /// <param name="mode">収入か支出どちらを選択しているか。</param>
        /// <returns>"mode"</returns>
        [HttpPost]
        public JsonResult ReloadMiddleCategory(int selectCategory, int mode)
        {
            var connectionString = CommonDataService.GetConnectionString();
            using (var conn = new MySqlConnection(connectionString))
            {
                if (mode == (int)PaymentType.Income)
                {
                    var incomeMiddleCategoryList = IncomeOrSpendCategoryDataService.CreateIncomeMiddleCategory(selectCategory, conn);
                    return Json(incomeMiddleCategoryList);
                }
                else
                {
                    var spendMiddleCategoryList = IncomeOrSpendCategoryDataService.CreateSpendMiddleCategory(selectCategory, conn);
                    return Json(spendMiddleCategoryList);
                }
            }
        }
    }
}