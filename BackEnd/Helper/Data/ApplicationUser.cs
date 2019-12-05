using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.Models;

namespace WebApi2.Data
{
    public class ApplicationUser : IdentityUser<long>
    {
        public virtual ICollection<Clientorders> Clientorders { get; set; }
    }
}