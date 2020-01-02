using System;
using System.Security.AccessControl;

namespace MeetingReminder.Entities
{
    public class Meeting:IEntity
    {
        public int MeetingID { get; set; }
        public DateTime FirstMeeting { get; set; }
        public DateTime SecondMeeting { get; set; }
        public DateTime ThirdMeeting { get; set; }
        public DateTime FourthMeeting { get; set; }
        public DateTime FifthMeeting { get; set; }
        public DateTime LastMeeting { get; set; }
        public int PersonID { get; set; }
        

    }
}
