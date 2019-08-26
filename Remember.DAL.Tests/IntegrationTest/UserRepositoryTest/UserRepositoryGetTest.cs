using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.DAL.Tests.IntegrationTest.UserRepositoryTest
{
    [TestFixture]
    public class UserRepositoryGetTest : UserRepositoryTestBase
    {
        [Test]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void Get_GetRandomUser_ReturnsUser()
        {
            var result = GetRandomUser();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Get_GetInvalidUser_ReturnNull()
        {
            var result = _userRepository.Get(new Guid());

            Assert.That(result, Is.Null);
        }

    }
}
