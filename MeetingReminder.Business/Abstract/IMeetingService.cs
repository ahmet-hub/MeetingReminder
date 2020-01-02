using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingReminder.Entities;

namespace MeetingReminder.Business.Abstract
{
    public interface IMeetingService
    {
        List<Meeting> GetAll();
        void Add(Meeting meeting);
        void Delete(Meeting meeting);
        void Update(Meeting meeting);
    }
}
