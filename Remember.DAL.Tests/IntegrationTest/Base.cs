using Remember.DAL.Repository;
using Remember.Domain.Entity;
using System;
using System.Text;

namespace Remember.DAL.Tests.IntegrationTest
{
    public class Base
    {
        protected UserRepository _userRepository;
        private Random _random = new Random();
        private readonly string _dictionaryString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789 ";

        protected User GetRandomUser()
        {
            return _userRepository.GetRandom();
        }

        protected string GetRandomString(int length, string prefix = "", string sulfix = "")
        {
            var retVal = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                retVal.Append(_dictionaryString[_random.Next(_dictionaryString.Length)]);
            }

            return string.Concat(prefix, retVal, sulfix);
        }

        protected bool GetRandomBoolean()
        {
            return _random.Next(11) > 5;
        }
    }
}
