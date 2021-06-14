using IIG.PasswordHashingUtils;
using Xunit;

namespace Lab3
{
    public class PasswordHashingUtilsTest
    {
        private const string someSalt = "dqwdweffsdf3wf";

        [Fact]
        public void Init()
        {
            const string salt = "this is salt";

            var actual = PasswordHasher.GetHash("password", salt, 10);

            Assert.NotNull(actual);
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

            var actual = PasswordHasher.GetHash("password", salt, 10);

            Assert.NotNull(actual);
        }

        [Fact]
        public void InitWithPositiveAdlerMod()
        {
            const uint adlerMod32 = 12;

            var actual = PasswordHasher.GetHash("password", someSalt, adlerMod32);

            Assert.NotNull(actual);
        }

        [Fact]
        public void InitWithZeroAdlerMod()
        {
            const uint adlerMod32 = 0;

            var actual = PasswordHasher.GetHash("password", someSalt, adlerMod32);

            Assert.NotNull(actual);
        }
        
        
        [Fact]
        public void InitWithNoAdlerMod()
        {
            var actual = PasswordHasher.GetHash("password", someSalt);

            Assert.NotNull(actual);
        }
        
        [Fact]
        public void GetHash()
        {
            const string password = "Some password1";

            var actual = PasswordHasher.GetHash(password, someSalt, 10);

            Assert.NotNull(actual);
        }

        [Fact]
        public void GetHashWithNullPassword()
        {
            const string password = null;

            var actual = PasswordHasher.GetHash(password, someSalt, 10);

            Assert.Null(actual);
        }

        [Fact]
        public void GetHashWithEmptyPassword()
        {
            const string password = "";

            var actual = PasswordHasher.GetHash(password, someSalt, 10);

            Assert.NotNull(actual);
        }


        [Fact]
        public void GetHashWithUnicodeCharacterPassword()
        {
            const string password = "\u041f\u0440\u043b\u044c asdaf21";

            var actual = PasswordHasher.GetHash(password, someSalt, 10);

            Assert.NotNull(actual);
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