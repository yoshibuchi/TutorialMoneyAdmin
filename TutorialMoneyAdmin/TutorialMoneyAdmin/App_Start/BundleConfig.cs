using System.Web.Optimization;

namespace TutorialMoneyAdmin
{
    /// <summary>
    /// javascript,CSSファイルなどの読み込みを設定します。
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// javascript,CSSファイルなどの読み込みを設定します。
        /// </summary>
        /// <param name="bundles">使いたいファイルを追加していく</param>
        // バンドルの詳細については、https://go.microsoft.com/fwlink/?LinkId=301862 を参照してください
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.slim.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 開発と学習には、Modernizr の開発バージョンを使用します。次に、実稼働の準備が
            // 運用の準備が完了したら、https://modernizr.com のビルド ツールを使用し、必要なテストのみを選択します。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.js",
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // bundles.UseCdn = true;
            // カレンダー画面のJS、CSSファイルの読み込み
            bundles.Add(new ScriptBundle("~/bundles/calenderJs").Include(
                      "~/Scripts/Calender/calender.js",
                      "~/Scripts/Plugins/main.js",
                      "~/Scripts/Plugins/main.min.js",
                      "~/Scripts/Plugins/ja.js"));

            bundles.Add(new StyleBundle("~/bundles/calenderCss").Include(
                      "~/Css/Calender/calender.css",
                      "~/Css/Plugins/main.css",
                      "~/Css/Plugins/main.min.css"));
        }
    }
}
