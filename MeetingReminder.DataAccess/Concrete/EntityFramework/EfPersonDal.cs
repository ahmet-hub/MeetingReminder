using MeetingReminder.DataAccess.Abstract;
using MeetingReminder.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeetingReminder.Entities.ComplexTypes;

namespace MeetingReminder.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal: EntityRepositoryBase<Person, MeetingReminderContext>,IPersonDal
    {
        public List<PersonDetail> GetPersonDetails()
        {
            using (MeetingReminderContext context = new MeetingReminderContext())
            {
                var result = from p in context.Persons
                    join m in context.Meetings on p.PersonID equals m.PersonID
                    where m.FirstMeeting.Day == DateTime.Today.Day ||
                          m.SecondMeeting.Day == DateTime.Today.Day ||
                          m.ThirdMeeting.Day == DateTime.Today.Day ||
                          m.FourthMeeting.Day == DateTime.Today.Day ||
                          m.FifthMeeting.Day == DateTime.Today.Day ||
                          m.LastMeeting.Day == DateTime.Today.Day
                    select new PersonDetail
                    {
                       // PersonId = p.PersonID,
                        Name = p.Name,
                        LastName = p.LastName
                        
                    };
                //return result.ToList();
                
                return result.OrderBy(p => p.Name).ToList();


            }
        }
    }
}
