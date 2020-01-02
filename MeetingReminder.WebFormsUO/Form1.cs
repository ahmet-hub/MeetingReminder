using MeetingReminder.Business.Abstract;
using System;
using System.Windows.Forms;
using MeetingReminder.Business.Concrete;
using MeetingReminder.DataAccess.Concrete.EntityFramework;
using MeetingReminder.Entities;

namespace MeetingReminder.WebFormsUO
{
    public partial class Form1 : Form
    {
        private IPersonService _personService=new PersonManager(new EfPersonDal());
        private IMeetingService _meetingService=new MeetingManager(new EfMeetingDal());
        private Person _person;
        private Meeting _meeting;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           LoadPerson();
           LoadMeeting();
        }

        public void LoadPerson()
        {
            dgwPersons.DataSource = _personService.GetAll();
            this.dgwPersons.Columns["PersonID"].Visible = false;
        }

        public void LoadMeeting()
        {
            dataGridView1.DataSource = _meetingService.GetAll();
        }
        
        public Person AddPerson()
        {
            Person addPerson=new Person
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                StartTime = Convert.ToDateTime(dtpStartTime.Text),
                FinishTime = Convert.ToDateTime(dtFinishTime.Text),
                Explanation = txtExplanation.Text,
                Period =Convert.ToInt32( cbxPeriod.Text)
            };
            _personService.Add(addPerson);
            LoadPerson();
            return addPerson;
        }
        private Person UpdatePerson ()
        {
            Person updatePerson = new Person
            {
                PersonID = Convert.ToInt32( dgwPersons.CurrentRow.Cells[0].Value),
                Name = txtName.Text,
                LastName = txtLastName.Text,
                StartTime = Convert.ToDateTime(dtpStartTime.Text),
                FinishTime = Convert.ToDateTime(dtFinishTime.Text),
                Explanation = txtExplanation.Text,
                Period = Convert.ToInt32(cbxPeriod.Text)
            };

            _personService.Update(updatePerson);
            LoadPerson();
            return updatePerson;
        }
        public Meeting AddMeeting()
        {

            Meeting addmeeting=new Meeting
            {
                FirstMeeting = _person.StartTime,
                SecondMeeting = _person.StartTime.AddDays(_person.Period),
                ThirdMeeting = _person.StartTime.AddDays(_person.Period*2),
                FourthMeeting = _person.StartTime.AddDays(_person.Period*3),
                FifthMeeting = _person.StartTime.AddDays(_person.Period*4),
                LastMeeting = _person.FinishTime,
                PersonID = _person.PersonID
            };
            _meetingService.Add(addmeeting);
            return addmeeting;
        }
        
        public void UpdateMeeting()
        {
            if (_meeting.SecondMeeting > _meeting.LastMeeting)
            {
                _meeting.SecondMeeting = Convert.ToDateTime(null);
                _meeting.ThirdMeeting = Convert.ToDateTime(null);
                _meeting.FourthMeeting = Convert.ToDateTime(null);
                _meeting.FifthMeeting = Convert.ToDateTime(null);

            }
            if (_meeting.ThirdMeeting > _meeting.LastMeeting)
            {
               
                _meeting.ThirdMeeting = Convert.ToDateTime(null);
                _meeting.FourthMeeting = Convert.ToDateTime(null);
                _meeting.FifthMeeting = Convert.ToDateTime(null);

            }
            if (_meeting.FourthMeeting > _meeting.LastMeeting)
            {

               
                _meeting.FourthMeeting = Convert.ToDateTime(null);
                _meeting.FifthMeeting = Convert.ToDateTime(null);

            }
            if (_meeting.FifthMeeting > _meeting.LastMeeting)
            {

                _meeting.FifthMeeting = Convert.ToDateTime(null);

            }

            _meetingService.Update(_meeting);

            LoadMeeting();
        }

        private void btnAdded_Click(object sender, EventArgs e)
        {
            _person = AddPerson();
            _meeting = AddMeeting();
            UpdateMeeting();

        }
        private void GetUser()
        {
            if (dgwPersons.CurrentRow != null)
            {
                
                txtName.Text = dgwPersons.CurrentRow.Cells[1].Value.ToString();
                txtLastName.Text = dgwPersons.CurrentRow.Cells[2].Value.ToString();
                cbxPeriod.Text = dgwPersons.CurrentRow.Cells[5].Value.ToString();
                txtExplanation.Text = dgwPersons.CurrentRow.Cells[6].Value.ToString();
            }
        }
        private void btnUpdated_Click(object sender, EventArgs e)
        {
            _person = UpdatePerson();
            _meeting = AddMeeting();
            UpdateMeeting();

        }

        private void dgwPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetUser();
        }
    }
}
