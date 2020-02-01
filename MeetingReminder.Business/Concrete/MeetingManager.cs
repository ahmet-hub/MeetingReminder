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
    public class MeetingManager : IMeetingService
    {
        private IMeetingDal _meetingDal;

        public MeetingManager(IMeetingDal meetingDal)
        {
            _meetingDal = meetingDal;
        }

        public void Add(Meeting meeting)
        {
            _meetingDal.Add(meeting);
        }

        public void Delete(Meeting meeting)
        {
            _meetingDal.Delete(meeting);
        }


        public Meeting Get(int id)
        {
           return _meetingDal.Get(p => p.PersonID == id);
        }

        public List<Meeting> GetAll()
        {
           return _meetingDal.GetAll();
        }

       
        public void Update(Meeting meeting)
        {
           _meetingDal.Update(meeting);
        }
    }
}
