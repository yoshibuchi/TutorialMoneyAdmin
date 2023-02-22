using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialMoneyAdminDataServices.DataServices.Common
{
    public class CommonDataService
    {
        /// <summary>
        /// 接続文字列を取得する
        /// </summary>
        public static string GetConnectionString()
        {
            return "Server=127.0.0.1;port=3306;Database=tutorialmyadmin;Uid=root;Pwd=Naomichi0011;charset=utf8;SslMode=Preferred;Max Pool Size=200;Connection Timeout=120; ConvertZeroDatetime=true;";
        }

        /// <summary>
        /// Dapperの仕様。カラムのアンダーバーを無視する設定。
        /// </summary>
        public static void ModelMappingService()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
