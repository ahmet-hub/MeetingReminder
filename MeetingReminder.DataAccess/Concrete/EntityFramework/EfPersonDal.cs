using MeetingReminder.DataAccess.Abstract;
using MeetingReminder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingReminder.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal: EntityRepositoryBase<Person, MeetingReminderContext>,IPersonDal
    {

    }
}
