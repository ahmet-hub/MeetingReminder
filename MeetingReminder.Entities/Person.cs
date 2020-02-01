using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace MeetingReminder.Entities
{
    public class Person:IEntity
    {
        
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int Period { get; set; }
        public string Explanation { get; set; }

    }
}
