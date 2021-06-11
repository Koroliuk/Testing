using System;
using IIG.PasswordHashingUtils;
using Xunit;

namespace Lab3
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var hasher = new PasswordHasher();
        }
    }
}