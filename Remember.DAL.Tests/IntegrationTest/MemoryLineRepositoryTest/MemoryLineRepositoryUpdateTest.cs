using NUnit.Framework;
using Remember.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.DAL.Tests.IntegrationTest.MemoryLineRepositoryTest
{
    [TestFixture]
    public class MemoryLineRepositoryUpdateTest : MemoryLineRepositoryTestBase
    {
        [Test]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        public void Update_AddNewGuest_AddGuest()
        {
            var memoryLine = _memoryLineRepository.GetRandom();
            var randomUser = GetRandomUser();

            memoryLine.Guests.Add(randomUser);

            _memoryLineRepository.Update(memoryLine);

            var result = _memoryLineRepository.GetMemoryWithGuestList(memoryLine.Id).Guests;

            var validationResult = ValidateNewGuest(result, randomUser);

            Assert.That(validationResult, Is.True);
        }

        private bool ValidateNewGuest(IList<User> userList, User userAdded)
        {
            var validation = false;

            foreach (User user in userList)
            {
                if(user.Id == userAdded.Id)
                {
                    validation = true;
                    break;
                }
            }

            return validation;
        }
    }
}
