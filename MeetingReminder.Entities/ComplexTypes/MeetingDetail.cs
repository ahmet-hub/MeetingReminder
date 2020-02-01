using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingReminder.Entities.ComplexTypes
{
    public class MeetingDetail
    {
        public string Name { get; set; }
        public string  LastName { get; set; }
        public DateTime FirstMeeting { get; set; }
        public DateTime SecondMeeting { get; set; }
        public DateTime ThirdMeeting { get; set; }
        public DateTime FourthMeeting { get; set; }
        public DateTime FifthMeeting { get; set; }
        public DateTime LastMeeting { get; set; }


    }
}
