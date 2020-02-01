using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingReminder.Entities;

namespace MeetingReminder.Business.Abstract
{
     public  interface IMeetingControlService
     {
        MeetingControl Get(int id);
        void Add(MeetingControl meetingControl);
         void Update(MeetingControl meetingControl);
     }
}
