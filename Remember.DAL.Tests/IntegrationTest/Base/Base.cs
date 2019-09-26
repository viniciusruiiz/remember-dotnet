using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Remember.DAL.Tests.Tests.IntegrationTest.Base
{
    public class Base
    {
        protected string GetRandomString(int length, string prefix = "", string sulfix = "")
        {
            var random = new Random();
            var retVal = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                retVal.Append(_dictionaryString[random.Next(_dictionaryString.Length)]);
            }

            return string.Concat(prefix, retVal, sulfix);
        }

        private readonly string _dictionaryString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}
