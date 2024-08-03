using TaskManager.Data.Module.User.Entity;
using TaskManager.Domain.Module.User.Model;

namespace TaskManager.Data.Test.User
{
    public class UserMock
    {

        static public UserEntity UserEntity1 { get; set; } = new UserEntity("User1", "user1@gmail.com", "12345678");
        static public UserEntity UserEntity2 { get; set; } = new UserEntity("User2", "user2@gmail.com", "12345678");
        static public UserEntity UserEntity3 { get; set; } = new UserEntity("User3", "user3@gmail.com", "12345678");
        static public UserEntity UserEntity4 { get; set; } = new UserEntity("User4", "user4@gmail.com", "12345678");

        static public UserModel User1 { get; set; } = new UserModel("User1", "user1@gmail.com", "12345678");
        static public UserModel User2 { get; set; } = new UserModel("User2", "user2@gmail.com", "12345678");
        static public UserModel User3 { get; set; } = new UserModel("User3", "user3@gmail.com", "12345678");
        static public UserModel User4 { get; set; } = new UserModel("User4", "user4@gmail.com", "12345678");
    }
}
