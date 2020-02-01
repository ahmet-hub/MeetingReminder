using MeetingReminder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingReminder.DataAccess.Concrete.EntityFramework
{
    public class MeetingReminderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MeetingReminder;Trusted_Connection=true");
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingControl> MeetingControls { get; set; }

    }
}
