using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialMoneyAdminDataServices.Models.Category
{
    /// <summary>
    /// 収入中カテゴリーのフィールド
    /// </summary>
    public class IncomeMiddleCategory
    {
        /// <summary>
        /// 収入中カテゴリーID
        /// </summary>
        public int IncomeMiddleCategoryId { get; set; }
        /// <summary>
        /// 収入大カテゴリーID
        /// </summary>
        public int IncomeLargeCategoryId { get; set; }
        /// <summary>
        /// 収入中カテゴリー名
        /// </summary>
        public string IncomeMiddleCategoryName { get; set; }
    }
}
