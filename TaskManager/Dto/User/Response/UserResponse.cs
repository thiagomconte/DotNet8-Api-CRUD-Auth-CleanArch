﻿using TaskManager.Dto.Task.Response;

namespace TaskManager.Dto.User.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public UserResponse(int id, string name, string email, string role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }
    }
}
