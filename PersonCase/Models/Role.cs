using System;
using Microsoft.AspNetCore.Identity;

namespace PersonCase.Models
{
    public class Role : IdentityRole<Guid>
    {
        protected Role()
        {

        }
    }
}