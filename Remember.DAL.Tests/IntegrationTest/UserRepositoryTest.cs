using NUnit.Framework;
using Remember.DAL.Repository;
using Remember.DAL.Tests.Tests.IntegrationTest.Base;
using Remember.Domain.Entity;
using System;

namespace Remember.DAL.Tests.IntegrationTest
{
    [TestFixture]
    public class UserRepositoryTest : Base
    {
        #region .: Entity :.
        private UserRepository _userRepository;

        private User _randomUser
        {
            get {
                return _userRepository.GetRandom();
            }
        }
        #endregion

        #region .: Methods :.
        private User CreateEntity()
        {
            return CreateEntity("male");
        }

        private User CreateEntity(string gender)
        {
            User user = new User(Guid.NewGuid(), GetRandomString(60), GetRandomString(60));

            user.BirthDate = DateTime.Now.AddYears(-20);
            user.Gender = gender;
            user.Name = GetRandomString(30, "NUNIT_");
        }
        #endregion

        [SetUp]
        public void SetUp()
        {
            _userRepository = new UserRepository();
        }

        [Test]
        public void User_GetRandomUser_ReturnsUser()
        {
            User result = _randomUser;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.Null);
        }

        [Test]
        public void Insert_ValidUser_Valid()
        {
            User user = CreateEntity();

            var result = _userRepository.Insert(user);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.Null);
        }

        [Test]
        public void Update_UpdateRandomUserName_UpdateName()
        {
            User user = _userRepository.GetRandom();
            var oldName = user.Name;

            user.Name = GetRandomString(50, "NUNIT_UPDATE_");

            _userRepository.Update(user);

            User result = _userRepository.Get(user.Id);

            Assert.That(result.Name, Is.Not.EqualTo(user.Name));
        }

        [Test]
        public void Get_GetInvalidUser_ReturnNull()
        {
            var result = _userRepository.Get(new Guid());

            Assert.That(result, Is.Null);
        }

        [Test]
        [Ignore("Not Implemented Yet")]
        public void Update_UpdateInvalidUser_ReturnsException()
        {
            User user = new User(new Guid(), "anyEmail", "anyPassword");
            
            //TODO: Exception Configure
            //Assert.That(_userRepository.Update(user));
        }

        [Test]
        [Ignore("Not Implemented Yet")]
        public void Insert_ExistentUser_ReturnsException()
        {
            User user = _randomUser;

            //TODO: Exception Configure
            //Assert.That(_userRepository.Insert(user));
        }
    }
}
