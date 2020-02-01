using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingReminder.DataAccess.Abstract;
using MeetingReminder.Entities;

namespace MeetingReminder.DataAccess.Concrete.EntityFramework
{
    public class EfMeetingControlDal:EntityRepositoryBase<MeetingControl,MeetingReminderContext>,IMeetingControlDal
    {

    }
}
