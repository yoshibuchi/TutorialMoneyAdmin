using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        /// カレンダーの日付
        /// <summary>
        public string Date { get; set; }

        /// <summary>
        /// 収入か支出か。
        /// Income：収入、Spend：支出
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
    }
}