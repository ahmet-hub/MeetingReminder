using MeetingReminder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingReminder.Entities.ComplexTypes;


namespace MeetingReminder.DataAccess.Abstract
{
    public interface IPersonDal:IEntityRepository<Person>
    {
        List<PersonDetail> GetPersonDetails();
    }
}
