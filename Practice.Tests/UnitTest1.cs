using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper; // MvcContrib TestHelperの名前空間を追加
using System.Web.Routing;
using Moq;
using System.Web;
using Practice.Controllers;

namespace Practice.Tests
{
    [TestClass]
    public class UnitTest1
    {
        // 各テストケースの前に実行する処理
        [TestInitialize]
        public void SetUp()
        {
            // （A）ルーティング情報を設定
            RouteTable.Routes.Clear();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        [TestMethod]
        public void View()
        {
            "~/".Route().ShouldMapTo<GuildViewController>(action => action.Index());
        }
        [TestMethod]
        public void View2()
        {
            "~/GuildView/Result/select * from Guilds".Route().ShouldMapTo<GuildViewController>(action => action.Result("select * from Guilds"));
        }
        [TestMethod]
        public void View3()
        {
            "~/Guild/".Route().ShouldMapTo<GuildController>(action => action.Index());
        }
    }
}
