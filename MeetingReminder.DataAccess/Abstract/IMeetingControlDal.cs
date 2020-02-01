using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingReminder.DataAccess.Concrete.EntityFramework;
using MeetingReminder.Entities;

namespace MeetingReminder.DataAccess.Abstract
{
    public interface IMeetingControlDal:IEntityRepository<MeetingControl>
    {
    }
}
