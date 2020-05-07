using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BuyerDB.Models;
using BuyerDB.Repositories;
using BuyerDB.Entity;
using System.Threading.Tasks;
using Moq;

namespace UserServiceTesting
{
    [TestFixture]
    class UserRepositoryTesting
    {
        IUserRepository userRepository;
        [SetUp]
        public void SetUp()
        {
            userRepository = new UserRepository(new BuyerContext());
        }
        [TearDown]
        public void TearDown()
        {
            userRepository = null;
        }
        /// <summary>
        /// Testing register buyer
        /// </summary>
        [Test]
        [TestCase("B3", "Sarath", "sarath123#", "sarath@gmail.com", "9876543210")]
        [TestCase("B23", "tarath", "trath123#", "tarath@gmail.com", "9879543210")]
        [Description("Add Buyer Testing")]
        public async Task RegisterBuyer_Successfull(string buyerId, string userName, string password, string email, string mobileNo)
        {
            DateTime datetime = System.DateTime.Now;
            var buyer = new Buyer { Buyerid = buyerId, Buyername = userName, Password = password, Email = email, Mobileno = mobileNo, Datetime = datetime };
            await userRepository.BuyerRegister(buyer);
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.BuyerRegister(buyer));
            var login = new Login { userName = userName, userPassword = password };
            var result = await userRepository.BuyerLogin(login);
            Assert.NotNull(result);
        }
        [Test]
        [TestCase("Karthik", "karthik123")]
        [Description("testing buyer login")]
        public async Task BuyerLogin_Successfull(string userName, string password)
        {
                var login = new Login { userName = userName, userPassword = password };
                var result = await userRepository.BuyerLogin(login);
                Assert.NotNull(result);
           
        }
        [Test]
        [TestCase("eswar", "abcdefg@")]
        [Description("Test buyer login failure case")]
        public async Task BuyerLogin_UnSuccessfull(string userName, string password)
        {
           
                var login = new Login { userName = userName, userPassword = password };
                var result = await userRepository.BuyerLogin(login);
                Assert.AreEqual(null, result);
           
        }
    }
}
