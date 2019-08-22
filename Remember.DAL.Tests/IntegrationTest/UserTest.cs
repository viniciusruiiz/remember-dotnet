using NUnit.Framework;
using Remember.DAL.Repository;
using Remember.DAL.Tests.Tests.IntegrationTest.Base;
using Remember.Domain.Entity;
using System;

namespace Remember.DAL.Tests.IntegrationTest
{
    [TestFixture]
    public class UserTest : Base
    {
        private User _user;
        private UserRepository _userRepository;

        [SetUp]
        public void SetUp()
        {
            _user = new User(Guid.NewGuid(), GetRandomString(60), GetRandomString(60));
            _userRepository = new UserRepository();
        }

        [Test]
        [Ignore("not implemented yet")]
        public void User_GetByValidId_ReturnsUser()
        {
            
        }

        [Test]
        public void Insert_ValidUser_Valid()
        {
            _user.BirthDate = DateTime.Now.AddYears(-20);
            _user.Gender = "male";
            _user.Name = GetRandomString(30, "NUNIT_");

            var retUser = _userRepository.Insert(_user);

            Assert.That(retUser, Is.Not.Null);
        }
    }
}
