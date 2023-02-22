using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialMoneyAdminDataServices.Models.Category
{
    /// <summary>
    /// 支出大カテゴリーのフィールド
    /// </summary>
    public class SpendLargeCategory
    {
        /// <summary>
        /// 支出大カテゴリーID
        /// </summary>
        public int SpendLargeCategoryId { get; set; }

        /// <summary>
        /// 支出大カテゴリー名
        /// </summary>
        public string SpendLargeCategoryName { get; set; }
    }
}
