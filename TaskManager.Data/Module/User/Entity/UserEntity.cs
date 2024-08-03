using System.ComponentModel.DataAnnotations;
using TaskManager.Data.Module.Task.Entity;
using TaskManager.Domain.Module.User.Model;

namespace TaskManager.Data.Module.User.Entity
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserRole Role { get; set; } = UserRole.EMPLOYEE;
        public ICollection<TaskEntity> Tasks { get; set; } = [];

        public UserEntity(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public UserEntity(int id, string name, string email, string password, UserRole role)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public UserEntity SetId(int id)
        {
            Id = id;
            return this;
        }
    }
}
