using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorialMoneyAdminDataServices.Models.Calender
{
    /// <summary>
    /// カレンダーのモーダル画面に関するビューモデル
    /// <summary>
    public class CalenderModalVM
    {
        /// <summary>
        /// 収入金額か支出金額のプラスマイナスマークを設定
        /// <summary>
        public string PlusOrMinusMark { get; set; }

        /// <summary>
        /// 支出金額か収入金額のタイトルワード
        /// <summary>
        public string SpendOrIncomeWord { get; set; }

        /// <summary>
        /// 収入か支出選択時のテキスト色
        /// <summary>
        public string IncomeOrSpendWordColor { get; set; }

        /// <summary>
        /// 収入か支出選択時のボーダーの色
        /// <summary>
        public string IncomeOrSpendBorderColor { get; set; }

        /// <summary>
        /// 収入か支出選択時のカラム別けの色
        /// <summary>
        public string IncomeOrSpendSeparateBorderColor { get; set; }

        /// <summary>
        /// 収入、支出どちらを選択しているか。
        /// <summary>
        public int? IncomeOrSpendMode { get; set; }

        /// <summary>
        /// カレンダーのモーダル画面のデータを格納する
        /// <summary>
        public IEnumerable<CalenderModal> CalenderModal { get; set; }

        /// <summary>
        /// 大カテゴリーリスト
        /// <summary>
        public SelectList LargeCategory { get; set; }

        /// <summary>
        /// 中カテゴリーリスト
        /// <summary>
        public SelectList MiddleCategory { get; set; }

        /// <summary>
        /// 選択している大カテゴリー項目
        /// <summary>
        public int? SelectLargeCategory { get; set; }

        /// <summary>
        /// 選択している中カテゴリー項目
        /// <summary>
        public int? SelectMiddleCategory { get; set; }

        /// <summary>
        /// 日付
        /// <summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string IncomeOrSpendDate { get; set; }

        /// <summary>
        /// 支出金額
        /// <summary>
        public int SpendMoney { get; set; } = 0;

        /// <summary>
        /// 収入金額
        /// <summary>
        public int IncomeMoney { get; set; } = 0;

        /// <summary>
        /// 収入金額
        /// <summary>
        public string CategoryRemarks { get; set; }

        /// <summary>
        /// 収入か支出か。
        /// <summary>
        public enum PaymentType
        {
            /// <summary>
            /// 収入
            /// <summary>
            Income = 1,
            /// <summary>
            /// 支出
            /// <summary>
            Spend = 2
        }

        /// <summary>
        /// 未分類ID
        /// <summary>
        public enum UncategorizedType
        {
            /// <summary>
            /// 収入大カテゴリー未分類ID
            /// <summary>
            IncomeLargeCategoryId = 2,
            /// <summary>
            /// 支出大カテゴリー未分類ID
            /// <summary>
            SpendLargeCategoryId = 18,
            /// <summary>
            /// 収入中カテゴリー未分類ID
            /// <summary>
            IncomeMiddleCategoryId = 9,
            /// <summary>
            /// 支出中カテゴリー未分類ID
            /// <summary>
            SpendMiddleCategoryId = 98
        }
    }
}