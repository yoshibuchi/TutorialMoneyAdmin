using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorialMoneyAdminDataServices.Models.Calender
{
    /// <summary>
    /// カレンダーのモーダル画面に関するモデル
    /// <summary>
    public class CalenderModal
    {
        /// <summary>
        /// 支出金額
        /// <summary>
        public int? SpendMoney { get; set; }

        /// <summary>
        /// 収入金額
        /// <summary>
        public int? IncomeMoney { get; set; }

        /// <summary>
        /// カレンダーの日付
        /// <summary>
        public string Date { get; set; }
    }
}