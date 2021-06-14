using System;
using Xunit;
using IIG.PasswordHashingUtils;
using IIG.CoSFE.DatabaseUtils;

namespace Lab4
{
    public class PasswordHashingAndAuthDBTest
    {
        private const string Server = @"DESKTOP-RQEAFUO\Server";
        private const string Database = @"IIG.CoSWE.AuthDB";
        private const bool IsTrusted = false;
        private const string Login = @"sa";
        private const string Password = @"admin1";
        private const int ConnectionTimeout = 75;
        private AuthDatabaseUtils dbManager = new(Server, Database,
            IsTrusted, Login, Password, ConnectionTimeout);


        [Fact]
        public void AddCredential()
        {
            var login = "user1";
            var password = "fl3lkj3";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(login, passwordHash);
            var isChecked = dbManager.CheckCredentials(login, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(login, passwordHash);

            Assert.True(isAdded);
            Assert.True(isChecked);
            Assert.True(isDeleted);
        }

        [Fact]
        public void AddCredentialWithEmptyLogin()
        {
            var login = "";
            var password = "fl3lkj3";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(login, passwordHash);
            var isChecked = dbManager.CheckCredentials(login, passwordHash);

            Assert.False(isAdded);
            Assert.False(isChecked);
        }

        [Fact]
        public void AddCredentialWithEmptyPassword()
        {
            var login = "user2";
            var password = "";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(login, passwordHash);
            var isChecked = dbManager.CheckCredentials(login, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(login, passwordHash);

            Assert.True(isAdded);
            Assert.True(isChecked);
            Assert.True(isDeleted);
        }

        [Fact]
        public void AddCredentialWithWhitepaceLogin()
        {
            var login = " ";
            var password = "fl3lkj3";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(login, passwordHash);
            var isChecked = dbManager.CheckCredentials(login, passwordHash);

            Assert.False(isAdded);
            Assert.False(isChecked);
        }

        [Fact]
        public void AddCredentialWithUTFLogin()
        {
            var login = "\u041a\u043e\u0440\u0438\u0441\u0442\u0443\u0432\u0430\u0447";
            var password = "thfgdbw12";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(login, passwordHash);
            var isChecked = dbManager.CheckCredentials(login, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(login, passwordHash);

            Assert.True(isAdded);
            Assert.True(isChecked);
            Assert.True(isDeleted);
        }

        [Fact]
        public void AddCredentialWithUTFPassword()
        {
            var login = "Petro";
            var password = "\u0446\u0443\u043a\u0443\u0446\u043a";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(login, passwordHash);
            var isChecked = dbManager.CheckCredentials(login, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(login, passwordHash);

            Assert.True(isAdded);
            Assert.True(isChecked);
            Assert.True(isDeleted);
        }

        [Fact]
        public void AddCredentialWithUTFLoginAndPassword()
        {
            var login = "\u041f\u0435\u0442\u0440\u043e";
            var password = "\u0466\u0466\u0413\u043a\u0443";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(login, passwordHash);
            var isChecked = dbManager.CheckCredentials(login, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(login, passwordHash);

            Assert.True(isAdded);
            Assert.True(isChecked);
            Assert.True(isDeleted);
        }

        [Fact]
        public void AddAlreadyExistsCredential()
        {
            var login = "Paul";
            var password = "foiwjsefm2";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded1 = dbManager.AddCredentials(login, passwordHash);
            var isAdded2 = dbManager.AddCredentials(login, passwordHash);
            var isChecked1 = dbManager.CheckCredentials(login, passwordHash);
            var isChecked2 = dbManager.CheckCredentials(login, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(login, passwordHash);

            Assert.True(isAdded1);
            Assert.False(isAdded2);
            Assert.True(isChecked1);
            Assert.True(isChecked2);
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateCredential()
        {
            var oldLogin = "Jack";
            var newLogin = "Jackson";
            var oldPassword = "111111";
            var newPassword = "3498fhhDORI#H!@ER83h";
            var oldPasswordHash = PasswordHasher.GetHash(oldPassword);
            var newPasswordHash = PasswordHasher.GetHash(newPassword);

            var isAdded = dbManager.AddCredentials(oldLogin, oldPasswordHash);
            var isUpdated = dbManager.UpdateCredentials(oldLogin, oldPasswordHash, newLogin, newPasswordHash);
            var isChecked = dbManager.CheckCredentials(newLogin, newPasswordHash);
            var isDeleted = dbManager.DeleteCredentials(newLogin, newPasswordHash);

            Assert.True(isAdded);
            Assert.True(isUpdated);
            Assert.True(isChecked);
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateCredentialOnlyLogin()
        {
            var oldLogin = "Monica";
            var newLogin = "Ella";
            var password = "111111";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(oldLogin, passwordHash);
            var isUpdated = dbManager.UpdateCredentials(oldLogin, passwordHash, newLogin, passwordHash);
            var isChecked = dbManager.CheckCredentials(newLogin, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(newLogin, passwordHash);

            Assert.True(isAdded);
            Assert.True(isUpdated);
            Assert.True(isChecked);
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateCredentialOnlyPassword()
        {
            var login = "Jack";
            var oldPassword = "222111";
            var newPassword = "DORI#H!@ER83h";
            var oldPasswordHash = PasswordHasher.GetHash(oldPassword);
            var newPasswordHash = PasswordHasher.GetHash(newPassword);

            var isAdded = dbManager.AddCredentials(login, oldPasswordHash);
            var isUpdated = dbManager.UpdateCredentials(login, oldPasswordHash, login, newPasswordHash);
            var isChecked = dbManager.CheckCredentials(login, newPasswordHash);
            var isDeleted = dbManager.DeleteCredentials(login, newPasswordHash);

            Assert.True(isAdded);
            Assert.True(isUpdated);
            Assert.True(isChecked);
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateCredentialWithEmptyLogin()
        {
            var oldLogin = "Mike";
            var newLogin = "";
            var password = "f23f23gsdf";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(oldLogin, passwordHash);
            var isUpdated = dbManager.UpdateCredentials(oldLogin, passwordHash, newLogin, passwordHash);
            var isChecked1 = dbManager.CheckCredentials(oldLogin, passwordHash);
            var isChecked2 = dbManager.CheckCredentials(newLogin, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(oldLogin, passwordHash);

            Assert.True(isAdded);
            Assert.False(isUpdated);
            Assert.True(isChecked1);
            Assert.False(isChecked2);
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateCredentialWithEmptyPassword()
        {
            var login = "Jimmy";
            var oldPassword = "3222111";
            var newPassword = "";
            var oldPasswordHash = PasswordHasher.GetHash(oldPassword);
            var newPasswordHash = PasswordHasher.GetHash(newPassword);

            var isAdded = dbManager.AddCredentials(login, oldPasswordHash);
            var isUpdated = dbManager.UpdateCredentials(login, oldPasswordHash, login, newPasswordHash);
            var isChecked1 = dbManager.CheckCredentials(login, oldPasswordHash);
            var isChecked2 = dbManager.CheckCredentials(login, newPasswordHash);
            var isDeleted = dbManager.DeleteCredentials(login, oldPassword);

            Assert.True(isAdded);
            Assert.False(isUpdated);
            Assert.True(isChecked1);
            Assert.False(isChecked2);
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateCredentialWithWhitepaceLogin()
        {
            var oldLogin = "Neron";
            var newLogin = " ";
            var password = "f23fsdf";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(oldLogin, passwordHash);
            var isUpdated = dbManager.UpdateCredentials(oldLogin, passwordHash, newLogin, passwordHash);
            var isChecked1 = dbManager.CheckCredentials(oldLogin, passwordHash);
            var isChecked2 = dbManager.CheckCredentials(newLogin, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(oldLogin, passwordHash);

            Assert.True(isAdded);
            Assert.False(isUpdated);
            Assert.True(isChecked1);
            Assert.False(isChecked2);
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateCredentialWithUTFLogin()
        {
            var oldLogin = "Cassii";
            var newLogin = "\u041a\u043e\u0440\u0438\u0441";
            var password = "sdsdsf23fsdf";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(oldLogin, passwordHash);
            var isUpdated = dbManager.UpdateCredentials(oldLogin, passwordHash, newLogin, passwordHash);
            var isChecked1 = dbManager.CheckCredentials(oldLogin, passwordHash);
            var isChecked2 = dbManager.CheckCredentials(newLogin, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(newLogin, passwordHash);

            Assert.True(isAdded);
            Assert.True(isUpdated);
            Assert.False(isChecked1);
            Assert.True(isChecked2);
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateCredentialWithUTFPassword()
        {
            var login = "Nabrahaputa";
            var oldPassword = "3a1";
            var newPassword = "\u0438\u0441\u4402\u041a\u043e\u0440\u0438\u0441\u4402";
            var oldPasswordHash = PasswordHasher.GetHash(oldPassword);
            var newPasswordHash = PasswordHasher.GetHash(newPassword);

            var isAdded = dbManager.AddCredentials(login, oldPasswordHash);
            var isUpdated = dbManager.UpdateCredentials(login, oldPasswordHash, login, newPasswordHash);
            var isChecked1 = dbManager.CheckCredentials(login, oldPasswordHash);
            var isChecked2 = dbManager.CheckCredentials(login, newPasswordHash);
            var isDeleted = dbManager.DeleteCredentials(login, newPasswordHash);

            Assert.True(isAdded);
            Assert.True(isUpdated);
            Assert.False(isChecked1);
            Assert.True(isChecked2);
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateCredentialWithUTFLoginAndPassword()
        {
            var oldLogin = "Jared";
            var newLogin = "\u0412\u0430\u0441\u0438\u043b\u044c";
            var oldPassword = "111111";
            var newPassword = "\u0444\u0456\u0432\u0444\u0452\u0430#H!@ER83h";
            var oldPasswordHash = PasswordHasher.GetHash(oldPassword);
            var newPasswordHash = PasswordHasher.GetHash(newPassword);

            var isAdded = dbManager.AddCredentials(oldLogin, oldPasswordHash);
            var isUpdated = dbManager.UpdateCredentials(oldLogin, oldPasswordHash, newLogin, newPasswordHash);
            var isChecked1 = dbManager.CheckCredentials(oldLogin, oldPasswordHash);
            var isChecked2 = dbManager.CheckCredentials(newLogin, newPasswordHash);
            var isDeleted = dbManager.DeleteCredentials(newLogin, newPasswordHash);

            Assert.True(isAdded);
            Assert.True(isUpdated);
            Assert.False(isChecked1);
            Assert.True(isChecked2);
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateUnexistCredential()
        {
            var oldLogin = "Atlant";
            var newLogin = "Name";
            var oldPassword = "foisdsdsdsm2";
            var newPassword = "foisdh";
            var oldPasswordHash = PasswordHasher.GetHash(oldPassword);
            var newPasswordHash = PasswordHasher.GetHash(newPassword);

            var isChecked1 = dbManager.CheckCredentials(oldLogin, oldPasswordHash);
            var isUpdated = dbManager.UpdateCredentials(oldLogin, oldPasswordHash, newLogin, newPasswordHash);
            var isChecked2 = dbManager.CheckCredentials(newLogin, newPasswordHash);

            Assert.False(isChecked1);
            Assert.False(isUpdated);
            Assert.False(isChecked2);
        }

        [Fact]
        public void DeleteCredential()
        {
            var login = "Semen";
            var password = "jsefsddasm2";
            var passwordHash = PasswordHasher.GetHash(password);

            var isAdded = dbManager.AddCredentials(login, passwordHash);
            var isChecked = dbManager.CheckCredentials(login, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(login, passwordHash);

            Assert.True(isAdded);
            Assert.True(isChecked);
            Assert.True(isDeleted);
        }

        [Fact]
        public void DeleteUnexistCredential()
        {
            var login = "Moisha";
            var password = "1212121dasm2";
            var passwordHash = PasswordHasher.GetHash(password);

            var isChecked1 = dbManager.CheckCredentials(login, passwordHash);
            var isDeleted = dbManager.DeleteCredentials(login, passwordHash);
            var isChecked2 = dbManager.CheckCredentials(login, passwordHash);


            Assert.False(isChecked1);
            Assert.True(isDeleted);
            Assert.False(isChecked2);
        }
    }
}
