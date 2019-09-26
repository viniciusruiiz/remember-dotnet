//using Moq;
//using NUnit.Framework;
//using Remember.Domain.Entity;
//using Remember.Domain.Interface.Repository;
//using Remember.Domain.Interface.Service;
//using Remember.Services.Services;
//using System;

//namespace Remember.Services.Tests.UnitTest
//{
//    [TestFixture]
//    public class UserServiceTest
//    {
//        private Mock<IUserRepository> _userRepository;
//        private IUserService _service;
//        private User _user;

//        [SetUp]
//        public void SetUp()
//        {
//            _userRepository = new Mock<IUserRepository>();
//            _service = new UserService(_userRepository.Object, null);
//            _user = new User(Guid.Empty);
//        }

//        [Test]
//        public void InsertUser_WithValidCrendentials_ReturnsEmptyErrors()
//        {
//            _user.Name = "abcde";
//            _user.Gender = 'm';

//            var result = _service.Insert(_user);

//            Assert.That(result.Errors, Is.Null);
//        }

//        [Test]
//        [TestCase("abc", 'm')]
//        [TestCase("abcde", 'a')]
//        [TestCase("abc", 'b')]
//        public void InsertUser_WithInvalidCrendentials_ReturnsFluentErrors(string name, char gender)
//        {
//            _user.Name = name;
//            _user.Gender = gender;

//            var result = _service.Insert(_user);

//            Assert.That(result.Errors, Is.Not.Empty);
//        }
//    }
//}
