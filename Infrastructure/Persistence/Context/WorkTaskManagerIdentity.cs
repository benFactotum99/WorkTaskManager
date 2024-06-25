using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context
{
    public class WorkTaskManagerIdentity : IdentityDbContext
    {
        public WorkTaskManagerIdentity(DbContextOptions<WorkTaskManagerIdentity> options) : base(options) { }
    }
}
