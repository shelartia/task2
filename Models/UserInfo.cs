using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Task2.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
    }

    public class UserInfoContext : DbContext
    {
        public DbSet<UserInfo> UserInfoes { get; set; }
    }
}