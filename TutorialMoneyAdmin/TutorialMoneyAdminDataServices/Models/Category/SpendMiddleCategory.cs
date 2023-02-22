using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialMoneyAdminDataServices.Models.Category
{
    /// <summary>
    /// 支出中カテゴリーのフィールド
    /// </summary>
    public class SpendMiddleCategory
    {
        /// <summary>
        /// 支出中カテゴリーID
        /// </summary>
        public int SpendMiddleCategoryId { get; set; }

        /// <summary>
        /// 支出大カテゴリーID
        /// </summary>
        public int SpendLargeCategoryId { get; set; }

        /// <summary>
        /// 支出中カテゴリー名
        /// </summary>
        public string SpendMiddleCategoryName { get; set; }
    }
}
