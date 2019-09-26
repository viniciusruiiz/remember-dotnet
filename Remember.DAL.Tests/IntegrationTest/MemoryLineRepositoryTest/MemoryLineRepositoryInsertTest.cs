using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.DAL.Tests.IntegrationTest.MemoryLineRepositoryTest
{
    [TestFixture]
    public class MemoryLineRepositoryInsertTest : MemoryLineRepositoryTestBase
    {
        [Test]
        public void Insert_ValidMemoryLineByRandomPerson_InsertsMemoryLine()
        {
            var memoryLine = CreateEntity();

            _memoryLineRepository.Insert(memoryLine);

            var result = _memoryLineRepository.Get(memoryLine.Id);

            Assert.That(result, Is.Not.Null);
        }
    }
}
