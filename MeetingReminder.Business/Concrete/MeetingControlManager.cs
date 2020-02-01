using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingReminder.Business.Abstract;
using MeetingReminder.DataAccess.Abstract;
using MeetingReminder.Entities;

namespace MeetingReminder.Business.Concrete
{
    public class MeetingControlManager:IMeetingControlService
    {
        private IMeetingControlDal _meetingControlDal;

        public MeetingControlManager(IMeetingControlDal meetingControlDal)
        {
            _meetingControlDal = meetingControlDal;
        }

        public void Add(MeetingControl meetingControl)
        {
            _meetingControlDal.Add(meetingControl);
        }

        public MeetingControl Get(int id)
        {
           return _meetingControlDal.Get(p => p.MeetingControlID == id);
        }
        public void Update(MeetingControl meetingControl)
        {
            _meetingControlDal.Update(meetingControl);
        }
    }
}
