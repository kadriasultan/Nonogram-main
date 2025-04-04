using System.Diagnostics;
using Nonogram.Database;
using Nonogram.Models;

namespace NonogramTest
{
    [TestClass]
    public sealed class TestUser
    {
        private string _filePath = "../../../users.json";

        public void TestUserStore()
        {
            DPassword password = User.HashPassword("Hello", "Hello");
            User user = new User("Test3", password);

            JsonUserDatabase db = new JsonUserDatabase();
            db.Save(user, _filePath);
        }

        [TestMethod]
        public void TestUserGet()
        {
            TestUserStore();

            JsonUserDatabase db = new JsonUserDatabase();
            List<User> users = db.GetUsers(_filePath);
            Assert.IsNotNull(users);

            TestDeleteUserFile();
        }

        public void TestDeleteUserFile()
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            //Assert.IsFalse(File.Exists(_filePath));
        }
    }
}
