using System;

namespace BirthdayReminder
{
    public class Employee
    {
        public Employee(int id, string name, DateTime birthday, string email)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Email = email;
        }

        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime Birthday { get; set; }
        
        public string Email { get; set; }
    }
}