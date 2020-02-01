using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingReminder.Business.Abstract;
using MeetingReminder.Business.Utilities;
using MeetingReminder.Business.ValidationRules.FluentValidation;
using MeetingReminder.DataAccess.Abstract;
using MeetingReminder.Entities;
using MeetingReminder.Entities.ComplexTypes;

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
            ValidationTool.Validate(new PersonValidator(), person);
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

        public List<PersonDetail> GetPersonDetails()
        {
            return _personDal.GetPersonDetails();
        }

        public void Update(Person person)
        {
            ValidationTool.Validate(new PersonValidator(), person);
            _personDal.Update(person);
        }
    }
}
