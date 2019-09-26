using NUnit.Framework;

namespace Remember.DAL.Tests.IntegrationTest.UserRepositoryTest
{
    [TestFixture]
    public class UserRepositoryInsertTest : UserRepositoryTestBase
    {
        [Test]
        public void Insert_ValidUser_InsertsUser()
        {
            var user = CreateEntity();

            _userRepository.Insert(user);

            var result = _userRepository.GetByEmail(user.Email);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Insert_ExistentUser_ReturnsGenericADOException()
        {
            var user = GetRandomUser();

            Assert.That(() => _userRepository.Insert(user), Throws.Exception.TypeOf<NHibernate.Exceptions.GenericADOException>());
        }
    }
}
