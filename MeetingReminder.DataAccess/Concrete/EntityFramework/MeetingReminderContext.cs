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
        private string SqlConnection()
        {
           string sqlConnection= System.IO.File.ReadAllText(@"C:\SqlConnection.txt");
           return sqlConnection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlConnection());
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingControl> MeetingControls { get; set; }

    }


}
