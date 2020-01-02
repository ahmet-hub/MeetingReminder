using MeetingReminder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingReminder.Business.Abstract
{
    public interface IPersonService
    {
        List<Person> GetAll();
        void Add(Person person);
        void Delete(Person person);
        void Update(Person person);


    }
}
