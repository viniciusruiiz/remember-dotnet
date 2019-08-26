using NUnit.Framework;
using Remember.DAL.Repository;
using Remember.Domain.Entity;
using System;

namespace Remember.DAL.Tests.IntegrationTest.UserRepositoryTest
{
    public class UserRepositoryTestBase : Base
    {
        protected readonly Guid _invalidUserId = new Guid();

        protected User CreateEntity()
        {
            var id = Guid.NewGuid();
            var email = GetRandomString(15, string.Empty, "@email.com");
            var password = GetRandomString(20);
            var name = GetRandomString(12, "Unit Test Name ");
            var age = DateTime.Now.AddYears(new Random().Next(14, 60));
            var gender = GetRandomBoolean() ? 'M' : 'F';

            return new User(id, email, password)
            {
                Name = name,
                BirthDate = age,
                Gender = gender
            };
        }

        [SetUp]
        public void SetUp()
        {
            _userRepository = new UserRepository();
        }
    }
}
