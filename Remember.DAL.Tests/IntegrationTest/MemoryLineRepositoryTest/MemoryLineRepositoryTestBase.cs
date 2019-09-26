using NUnit.Framework;
using Remember.DAL.Repository;
using Remember.Domain.Entity;
using System;

namespace Remember.DAL.Tests.IntegrationTest.MemoryLineRepositoryTest
{
    public class MemoryLineRepositoryTestBase : Base
    {
        protected MemoryLineRepository _memoryLineRepository;

        protected MemoryLine CreateEntity()
        {
            return new MemoryLine(Guid.NewGuid())
            {
                Name = GetRandomString(12, "Memory line "),
                Host = _userRepository.GetRandom(),
                IsPublic = GetRandomBoolean(),
            };
        }

        [SetUp]
        public void SetUp()
        {
            _memoryLineRepository = new MemoryLineRepository();
            _userRepository = new UserRepository();
        }
    }
}
