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
                    model.IncomeLargeCategories = IncomeOrSpendCategoryDataService.CreateIncomeLargeCategory(conn);
                    model.IncomeMiddleCategories = IncomeOrSpendCategoryDataService.CreateIncomeMiddleCategory(model.SelectLargeCategory, conn);
                    model.SpendLargeCategories = IncomeOrSpendCategoryDataService.CreateSpendLargeCategory(conn);
                    model.SpendMiddleCategories = IncomeOrSpendCategoryDataService.CreateSpendMiddleCategory(model.SelectLargeCategory, conn);
                    switch (model.IncomeOrSpendMode)
                    {
                        case (int)PaymentType.Income:
                            model.PlusOrMinusMark = "＋";
                            model.SpendOrIncomeWord = "収入金額";
                            model.IncomeOrSpendWordColor = "text-info";
                            model.IncomeOrSpendBorderColor = "border border-info";
                            model.IncomeOrSpendSeparateBorderColor = "border-right border-info";

                            // 多階層でないプルダウンリスト
                            // model.LargeCategory = new SelectList(model.IncomeLargeCategories, "IncomeLargeCategoryId", "IncomeLargeCategoryName", model.SelectLargeCategory);
                            // model.MiddleCategory = new SelectList(model.IncomeMiddleCategories, "IncomeMiddleCategoryId", "IncomeMiddleCategoryName", model.SelectMiddleCategory);
                            model.IncomeOrSpendDate = date;
                            break;
                        case (int)PaymentType.Spend:
                            model.PlusOrMinusMark = "ー";
                            model.SpendOrIncomeWord = "支出金額";
                            model.IncomeOrSpendWordColor = "text-danger";
                            model.IncomeOrSpendBorderColor = "border border-danger";
                            model.IncomeOrSpendSeparateBorderColor = "border-right border-danger";
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

        /// <summary>
        /// カレンダー日付クリック時に生成されるモーダルを作成
        /// </summary>
        /// <param name="selectMiddleCategoryId">ドロップダウンでどの中カテゴリーを選択したか。</param>
        /// <param name="mode">収入か支出どちらを選択しているか。</param>
        /// <returns>"mode"</returns>
        [HttpPost]
        public JsonResult SelectMiddleCategory(int selectMiddleCategoryId, int mode)
        {
            var connectionString = CommonDataService.GetConnectionString();
            using (var conn = new MySqlConnection(connectionString))
            {
                if (mode == (int)PaymentType.Income)
                {
                    var incomeSelectLargeCategoryList = IncomeOrSpendCategoryDataService.CreateIncomeLargeCategoryFromMiddleCategory(selectMiddleCategoryId, conn);
                    return Json(incomeSelectLargeCategoryList);
                }
                else
                {
                    var spendMiddleCategoryList = IncomeOrSpendCategoryDataService.CreateSpendLargeCategory(conn);
                    return Json(spendMiddleCategoryList);
                }
            }
        }
    }
}