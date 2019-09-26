using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.DAL.Tests.IntegrationTest.MemoryLineRepositoryTest
{
    [TestFixture]
    public class MemoryLineRepositoryGetTest : MemoryLineRepositoryTestBase
    {
        [Test]
        public void GetByUser_WithValidUserId_ReturnsMemoryLineOfUser()
        {
            var user = GetRandomUser();

            var result = _memoryLineRepository.GetByUser(user.Id);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GetByUser_WithValidUserIdWithAnyMemoryLine_ReturnsMemoryLineOfUser()
        {
            var randomMemoryLine = _memoryLineRepository.GetRandom();

            var result = _memoryLineRepository.GetByUser(randomMemoryLine.Host.Id);

            Assert.That(result, Is.Not.Empty);
        }
    }
}
