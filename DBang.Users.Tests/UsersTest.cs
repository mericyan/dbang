using System;
using DBang.Data;
using DBang.Messages;
using DBang.Users.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

namespace DBang.Users.Tests
{
    /// <summary>
    ///This is a test class for UsersTest and is intended
    ///to contain all UsersTest Unit Tests
    ///</summary>
    [TestClass]
    public class UsersTest
    {
        private readonly UserManager _users;

        public UsersTest()
        {
            //var sender = new Mock<ISender>();
            //sender.Setup(foo => foo.Send("0", "123", "333"));
            //IDatabase database = new Database("System.Data.SqlClient", "Data Source=127.0.0.1;Initial Catalog=dbang;Integrated Security=True");

            //_users = new Users(database, sender.Object);
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        /// <summary>
        ///A test for Users Constructor
        ///</summary>
        [TestMethod]
        public void UsersConstructorTest()
        {
            //var sender = new Mock<ISender>();
            //sender.Setup(foo => foo.Send("0", "123", "333"));
            //IDatabase database = new Database("System.Data.SqlClient", "Data Source=127.0.0.1;Initial Catalog=dbang;Integrated Security=True");

            //var target = new Users(database, sender.Object);
            //Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod]
        public void CreateTest()
        {
            var userInfo = new UserInfoEntity();

            userInfo.PromoterId = 5;
            userInfo.RegionId = 3;
            userInfo.Name = "TestUser";
            userInfo.Password = "451122";
            userInfo.VerificationCode = "623026";
            userInfo.VerifiedMobileNumber = "15827555778";

            const bool expected = true;
            bool actual = _users.Create(userInfo);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Exists
        ///</summary>
        [TestMethod]
        public void ExistsTest()
        {
            const string userMobileNumber = "15827555778";

            const bool expected = true;
            bool actual = _users.Exists(userMobileNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SendVerificationCode
        ///</summary>
        [TestMethod]
        public void SendVerificationCodeTest()
        {
            const string mobileNumber = "15827555778";
            
            const long expected = 3;
            long actual = _users.SendVerificationCode(mobileNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UpdateUserInfo
        ///</summary>
        [TestMethod]
        public void UpdateUserInfoTest()
        {
            //IDatabase database = null; // TODO: Initialize to an appropriate value
            //ISender sender = null; // TODO: Initialize to an appropriate value
            //var target = new UserManager(database, sender); // TODO: Initialize to an appropriate value
            //UserInfoEntity userInfo = null; // TODO: Initialize to an appropriate value
            //target.Update(userInfo);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}