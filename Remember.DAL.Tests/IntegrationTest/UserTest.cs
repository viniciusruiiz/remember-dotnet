using NUnit.Framework;
using Remember.DAL.Repository;
using Remember.DAL.Tests.Tests.IntegrationTest.Base;
using Remember.Domain.Entity;
using System;
using System.Security.Cryptography;

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
            _user = new User();
            _userRepository = new UserRepository();
        }

        [Test]
        public void Insert_ValidUser_Valid()
        {
            _user.Id = Guid.NewGuid();
            _user.Email = GetRandomString(20, null, "@email.com");
            _user.BirthDate = DateTime.Now.AddYears(-20);
            _user.Gender = 'm';
            _user.Name = GetRandomString(5, "NUNIT ");

            var retUser = _userRepository.Insert(_user);

            Assert.That(retUser, Is.Not.Null);
        }

        [Test]
        public void GetUserPKByEmail_InvalidEmail_ReturnNull()
        {
            var retUser = _userRepository.GetUserPkByEmail(base.GetRandomString(20));

            Assert.That(retUser, Is.EqualTo(Guid.Empty));
        }

        [Test]
        public void GetUserPKByEmail_ValidEmail_ReturnGUID()
        {
            _user = _userRepository.GetRandomUser();

            var retUser = _userRepository.GetUserPkByEmail(_user.Email);

            Assert.That(retUser, Is.EqualTo(_user.Id));
        }
    }
}
