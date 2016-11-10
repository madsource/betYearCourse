using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameCasino.Tests
{
    [TestClass]
    public class GameInfoTests
    {
        public bool Initialized { get; set; }

        [ClassInitialize] // before all
        private void BeforeAllTests()
        {
            //this.Initialized = true;
        }

        [TestInitialize] // before each
        private void BeforeEachTests()
        {
            this.Initialized = true;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, 2, "One should be equal to one!");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(1, 1);
        }

        [TestCleanup] // after each
        private void AfterEachTests()
        {
            this.Initialized = false;
        }
        [ClassCleanup] // after all
        private void AfterAllTests()
        {
            //this.Initialized = true;
        }
    }
}
