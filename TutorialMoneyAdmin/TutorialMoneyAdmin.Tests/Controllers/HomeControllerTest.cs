using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialMoneyAdmin;
using TutorialMoneyAdmin.Controllers;

namespace TutorialMoneyAdmin.Tests.Controllers
{
    /// <summary>
    /// デフォルトコントローラー.
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// testtest
        /// </summary>
        /// <param name="test1">１つめの引数あれば使う</param>
        /// <param name="test2">２つめの引数あれば使う</param>
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// testtest
        /// </summary>
        /// <param name="test1">１つめの引数あれば使う</param>
        /// <param name="test2">２つめの引数あれば使う</param>
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        /// <summary>
        /// testtest
        /// </summary>
        /// <param name="test1">１つめの引数あれば使う</param>
        /// <param name="test2">２つめの引数あれば使う</param>
        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
