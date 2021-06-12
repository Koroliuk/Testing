using IIG.PasswordHashingUtils;
using Xunit;

namespace Lab3
{
    public class PasswordHashingUtilsTest
    {
        [Fact]
        public void Init()
        {
            const string salt = "this is salt";

            const string expected = "8C78B9B3EBC78196D2459546B9C49AE12C77C906735E6D0179E6D2947A12AF88";
            var actual = PasswordHasher.GetHash("password", salt, 10);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InitWithNullSalt()
        {
            const string salt = null;

            var actual = PasswordHasher.GetHash("password", salt, 10);

            Assert.NotNull(actual);
        }

        [Fact]
        public void InitWithEmptySalt()
        {
            const string salt = "";

            var actual = PasswordHasher.GetHash("password", salt, 10);

            Assert.NotNull(actual);
        }


        [Fact]
        public void InitWithUnicodeCharacterSalt()
        {
            const string salt = "\u041f\u0440\u043b\u044c asdaf21";

            const string  expected = "07782B378AF3CFD3B553E71D881D4409906B400E5BA45FE69923B638CF987657";
            var actual = PasswordHasher.GetHash("password", salt, 10);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InitWithPositiveAdlerMod()
        {
            const uint adlerMod32 = 12;

            const string expected = "A522B2CE5459DE688CC56E96AE020E8BC22B54207E3508AE82001FD3E1A0F2DA";
            var actual = PasswordHasher.GetHash("password", "some salt", adlerMod32);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InitWithZeroAdlerMod()
        {
            const uint adlerMod32 = 0;

            var actual = PasswordHasher.GetHash("password", "some salt", adlerMod32);

            Assert.NotNull(actual);
        }
        
        
        [Fact]
        public void InitWithNoAdlerMod()
        {
            var actual = PasswordHasher.GetHash("password", "some salt");

            Assert.NotNull(actual);
        }
        
        [Fact]
        public void GetHash()
        {
            const string password = "Some password1";

            const string expected = "44A9D058A796B549B2ED67CEBCC1603CA5062B3C1B02B3AF532D7F6E4C45FFF1";
            var actual = PasswordHasher.GetHash(password, "some salt", 10);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetHashWithNullPassword()
        {
            const string password = null;

            var actual = PasswordHasher.GetHash(password, "some salt", 10);

            Assert.Null(actual);
        }

        [Fact]
        public void GetHashWithEmptyPassword()
        {
            const string password = "";

            var actual = PasswordHasher.GetHash(password, "some salt", 10);

            Assert.NotNull(actual);
        }


        [Fact]
        public void GetHashWithUnicodeCharacterPassword()
        {
            const string password = "\u041f\u0440\u043b\u044c asdaf21";

            const string  expected = "CBD0B1F9FA8216E3ED2D844D1954AE36E81E0B7A3CDF9EC4D150DBC12E57CF0B";
            var actual = PasswordHasher.GetHash(password, "some salt", 10);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void TestDefault()
        {
            const string salt = "saltttsdfsd";
            const uint adlerMod32 = 21;
            const string password = "fffasdaf21";
            
            PasswordHasher.Init(salt, adlerMod32);
            var result1 = PasswordHasher.GetHash(password);
            var result2 = PasswordHasher.GetHash(password, salt, adlerMod32);

            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.Equal(result1, result2);
        }
        
        [Fact]
        public void TestInitWithGetHash()
        {
            const string salt = "sasd";
            const uint adlerMod32 = 1;
            const string password = "ff21";
            
            PasswordHasher.Init(salt, adlerMod32);
            var result1 = PasswordHasher.GetHash(password);
            var result2 = PasswordHasher.GetHash(password, salt, adlerMod32);

            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.Equal(result1, result2);
        }

    }
}