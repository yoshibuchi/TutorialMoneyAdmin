using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TutorialMoneyAdminDataServices.DataServices.Common;
using TutorialMoneyAdminDataServices.Models.Category;

namespace TutorialMoneyAdminDataServices.DataServices.Category
{
    /// <summary>
    /// 収支のカテゴリーデータ取得を取得する
    /// </summary>
    public class IncomeOrSpendCategoryDataService
    {
        /// <summary>
        /// 収入大カテゴリーのデータ取得する
        /// </summary>
        public static List<IncomeLargeCategory> CreateIncomeLargeCategory(MySqlConnection conn)
        {
            var query = "SELECT income_large_category_id, income_large_category_name FROM income_large_category ORDER BY income_large_category_id DESC";
            CommonDataService.ModelMappingService();
            var result = conn.Query<IncomeLargeCategory>(query).ToList();
           
            return result;
        }

        /// <summary>
        /// 収入中カテゴリーのデータ取得する
        /// </summary>
        public static List<IncomeMiddleCategory> CreateIncomeMiddleCategory(int? largeCategory, MySqlConnection conn)
        {
            var query = "SELECT income_middle_category_id, income_middle_category_name FROM income_middle_category WHERE income_large_category_id = " + largeCategory + " ORDER BY income_middle_category_id DESC";
            CommonDataService.ModelMappingService();
            var result = conn.Query<IncomeMiddleCategory>(query).ToList();

            return result;
        }

        /// <summary>
        /// 支出大カテゴリーのデータ取得する
        /// </summary>
        public static List<SpendLargeCategory> CreateSpendLargeCategory(MySqlConnection conn)
        {
            var query = "SELECT spend_large_category_id, spend_large_category_name FROM spend_large_category ORDER BY spend_large_category_id DESC";
            CommonDataService.ModelMappingService();
            var result = conn.Query<SpendLargeCategory>(query).ToList();

            return result;
        }

        /// <summary>
        /// 支出中カテゴリーのデータ取得する
        /// </summary>
        public static List<SpendMiddleCategory> CreateSpendMiddleCategory(int? middleCategory, MySqlConnection conn)
        {
            var query = "SELECT spend_middle_category_id, spend_middle_category_name FROM spend_middle_category WHERE spend_large_category_id = " + middleCategory + " ORDER BY spend_middle_category_id DESC";
            CommonDataService.ModelMappingService();
            var result = conn.Query<SpendMiddleCategory>(query).ToList();

            return result;
        }

        /// <summary>
        /// 収入中カテゴリーIdに紐づく収入大カテゴリーのデータを取得する
        /// </summary>
        public static List<IncomeLargeCategory> CreateIncomeLargeCategoryFromMiddleCategory(int middleCategoryId, MySqlConnection conn)
        {
            var query = "SELECT ilc.income_large_category_id, ilc.income_large_category_name, imc.income_middle_category_name  ";
            query += "FROM ";
            query += "  income_middle_category as imc ";
            query += "INNER JOIN ";
            query += "  income_large_category as ilc on imc.income_large_category_id = ilc.income_large_category_id ";
            query += "WHERE ";
            query += "  imc.income_middle_category_id = " + middleCategoryId;
            CommonDataService.ModelMappingService();
            var result = conn.Query<IncomeLargeCategory>(query).ToList();

            return result;
        }
    }
}
