using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialMoneyAdminDataServices.Models.Category
{
    /// <summary>
    /// 収入大カテゴリーのフィールド
    /// </summary>
    public class IncomeLargeCategory
    {
        /// <summary>
        /// 収入大カテゴリーID
        /// </summary>
        public int IncomeLargeCategoryId { get; set; }
        /// <summary>
        /// 収入大カテゴリー名
        /// </summary>
        public string IncomeLargeCategoryName { get; set; }
        /// <summary>
        /// ドロップダウンの並び順
        /// </summary>
        public int Sort { get; set; } = 1;
    }
}
