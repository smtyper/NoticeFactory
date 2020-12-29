using System;
using Microsoft.AspNetCore.Identity;

namespace PersonCase.Models
{
    public class User : IdentityUser<Guid>
    {
        public DateTime BirthDate { get; set; }

        public User()
        {

        }
    }
}
