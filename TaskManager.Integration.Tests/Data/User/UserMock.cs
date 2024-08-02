using TaskManager.Data.Module.User.Entity;

namespace TaskManager.Data.Test.User
{
    public class UserMock
    {

        static public UserEntity User1 { get; set; } = new UserEntity("User1", "user1@gmail.com", "12345678");
        static public UserEntity User2 { get; set; } = new UserEntity("User2", "user2@gmail.com", "12345678");
        static public UserEntity User3 { get; set; } = new UserEntity("User3", "user3@gmail.com", "12345678");
        static public UserEntity User4 { get; set; } = new UserEntity("User4", "user4@gmail.com", "12345678");
    }
}
