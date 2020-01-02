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
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public void Add(Person person)
        {
            _personDal.Add(person);
        }

        public void Delete(Person person)
        {
            _personDal.Delete(person);
        }

        public List<Person> GetAll()
        {
           return _personDal.GetAll();
        }

        public void Update(Person person)
        {
            _personDal.Update(person);
        }
    }
}
