using System.Web;
using System.Web.Mvc;

namespace TutorialMoneyAdmin
{
    /// <summary>
    /// 無
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// 理解でき次第記載
        /// </summary>
        /// <param name="filters">無</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
