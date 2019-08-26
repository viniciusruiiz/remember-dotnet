using NUnit.Framework;
using Remember.Domain.Entity;

namespace Remember.DAL.Tests.IntegrationTest.UserRepositoryTest
{
    [TestFixture]
    public class UserRepositoryUpdateTest : UserRepositoryTestBase
    {
        [Test]
        public void Update_UpdateRandomUserName_UpdateName()
        {
            var user = _userRepository.GetRandom();

            var newName = GetRandomString(12, "New Updated Name "); ;

            user.Name = newName;

            _userRepository.Update(user);

            var result = _userRepository.Get(user.Id);

            Assert.That(result.Name, Is.EqualTo(newName));
        }

        [Test]
        public void Update_UpdateInexistentUser_ReturnsStaleStateException()
        {
            var user = new User(_invalidUserId, "anyEmail", "anyPassword");

            Assert.That(() => _userRepository.Update(user), Throws.Exception.TypeOf<NHibernate.StaleStateException>());
        }
    }
}
