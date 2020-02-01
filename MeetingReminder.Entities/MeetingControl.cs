using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingReminder.Entities
{
    public class MeetingControl :IEntity
    {
      
        public int MeetingControlID { get; set; }
        public string FirstMeeting { get; set; }
        public string SecondMeeting { get; set; }
        public string ThirdMeeting { get; set; }
        public string FourthMeeting { get; set; }
        public string FifthMeeting { get; set; }
        public string LastMeeting { get; set; }
    }
}
