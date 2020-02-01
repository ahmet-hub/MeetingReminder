using MeetingReminder.Business.Abstract;
using System;
using System.Drawing;
using System.Windows.Forms;
using MeetingReminder.Business.Concrete;
using MeetingReminder.DataAccess.Concrete.EntityFramework;
using MeetingReminder.Entities;
using Microsoft.Office.Interop.Excel;


namespace MeetingReminder.WebFormsUO
{
    public partial class Form1 : Form
    {
        private readonly PersonDetails _personDetails = new PersonDetails();

        private readonly IPersonService _personService = new PersonManager(new EfPersonDal());

        private readonly IMeetingService _meetingService = new MeetingManager(new EfMeetingDal());
        private readonly IMeetingControlService _meetingControlService = new MeetingControlManager(new EfMeetingControlDal());

        private Person _person;
        private Meeting _meeting;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPerson();

            LoadTodayMeeting();
        }

        public void LoadPerson()
        {
            dgwPerson.DataSource = _personService.GetAll();
            // ReSharper disable once PossibleNullReferenceException
            this.dgwPerson.Columns["PersonID"].Visible = false;
            this.dgwPerson.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public void LoadTodayMeeting()
        {
            dgwTodayMeeting.DataSource = _personService.GetPersonDetails();
            this.dgwTodayMeeting.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public Person AddPerson()
        {
            
                Person addPerson = new Person
                {
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    StartTime = Convert.ToDateTime(dtpStartTime.Text),
                    FinishTime = Convert.ToDateTime(dtpFinishTime.Text),
                    Explanation = txtExplanation.Text,
                    Period = Convert.ToInt32(cbxPeriod.Text)
                };
                _personService.Add(addPerson);
                LoadPerson();
                return addPerson;
            
            
        }

        private Person UpdatePerson()
        {

            if (dgwPerson.CurrentRow != null)
            {
                Person updatePerson = new Person
                {
                    PersonID = Convert.ToInt32(dgwPerson.CurrentRow.Cells[0].Value),
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    StartTime = Convert.ToDateTime(dtpStartTime.Text),
                    FinishTime = Convert.ToDateTime(dtpFinishTime.Text),
                    Explanation = txtExplanation.Text,
                    Period = Convert.ToInt32(cbxPeriod.Text)
                };

                _personService.Update(updatePerson);
                LoadPerson();
                return updatePerson;
            }

            return null;

        }

        private void DeletePerson()
        {

            if (dgwPerson.CurrentRow != null)
            {
                Person deletePerson = new Person
                {
                    PersonID = Convert.ToInt32(dgwPerson.CurrentRow.Cells[0].Value)
                };
                _personService.Delete(deletePerson);
            }

            LoadPerson();




        }

        public int CalculateDay(DateTime startTime, DateTime finishTime,int period)
        {
            int result =  Convert.ToInt32((finishTime - startTime).TotalDays)/period;
            return result;
        }
        public Meeting AddMeeting()
        {
            int nextMeeting = CalculateDay(_person.StartTime, _person.FinishTime, _person.Period);

                Meeting addmeeting = new Meeting
                {
                    FirstMeeting = _person.StartTime,
                    SecondMeeting = _person.StartTime.AddDays(nextMeeting),
                    ThirdMeeting = _person.StartTime.AddDays(nextMeeting * 2),
                    FourthMeeting = _person.StartTime.AddDays(nextMeeting * 3),
                    FifthMeeting = _person.StartTime.AddDays(nextMeeting * 4),
                    LastMeeting = _person.FinishTime,
                    PersonID = _person.PersonID,
                };
                _meetingService.Add(addmeeting);

                // UpdateMeeting();
                return addmeeting;
            
           

        }
        public void AddMeetingControl()
        {
           
                MeetingControl addMeetingControl = new MeetingControl
                {
                    MeetingControlID = _meeting.MeetingID,
                    FirstMeeting = "GELMEDI",
                    SecondMeeting = "GELMEDI",
                    ThirdMeeting = "GELMEDI",
                    FourthMeeting = "GELMEDI",
                    FifthMeeting = "GELMEDI",
                    LastMeeting = "GELMEDI",
                };
                _meetingControlService.Add(addMeetingControl);
            
         

            
        }

        public void UpdateMeeting()
        {
            if (_meeting.SecondMeeting >= _meeting.LastMeeting)
            {
                _meeting.SecondMeeting = Convert.ToDateTime(null);
                _meeting.ThirdMeeting = Convert.ToDateTime(null);
                _meeting.FourthMeeting = Convert.ToDateTime(null);
                _meeting.FifthMeeting = Convert.ToDateTime(null);

            }

            if (_meeting.ThirdMeeting >= _meeting.LastMeeting)
            {

                _meeting.ThirdMeeting = Convert.ToDateTime(null);
                _meeting.FourthMeeting = Convert.ToDateTime(null);
                _meeting.FifthMeeting = Convert.ToDateTime(null);

            }

            if (_meeting.FourthMeeting >= _meeting.LastMeeting)
            {


                _meeting.FourthMeeting = Convert.ToDateTime(null);
                _meeting.FifthMeeting = Convert.ToDateTime(null);

            }

            if (_meeting.FifthMeeting >= _meeting.LastMeeting)
            {

                _meeting.FifthMeeting = Convert.ToDateTime(null);

            }

            _meetingService.Update(_meeting);


        }
        private void GetUser()
        {
            if (dgwPerson.CurrentRow != null)
            {

                txtName.Text = dgwPerson.CurrentRow.Cells[1].Value.ToString();
                txtLastName.Text = dgwPerson.CurrentRow.Cells[2].Value.ToString();
                cbxPeriod.Text = dgwPerson.CurrentRow.Cells[5].Value.ToString();
                txtExplanation.Text = dgwPerson.CurrentRow.Cells[6].Value.ToString();
            }
        }





        private void GetPersonName()
        {
            if (dgwPerson.CurrentRow != null)
            {
                _personDetails.lblTabPage1Name.Text = dgwPerson.CurrentRow.Cells[1].Value + @"  " +
                                                      dgwPerson.CurrentRow.Cells[2].Value;
            }
        }

        private int GetMeetingId()
        {
            var result = _meetingService.Get(GetPersonId());
            _personDetails.txtId.Text = result.PersonID.ToString();
            return result.PersonID;
        }

        private int GetPersonId()
        {
            return (Convert.ToInt32(dgwPerson.CurrentRow?.Cells[0].Value));
        }

        public void GetMeetingDate()
        {
            var result = _meetingService.Get(GetMeetingId());

            if (result.FirstMeeting.Date > DateTime.MinValue)
            {
                _personDetails.dtpMeeting1.Text = result.FirstMeeting.ToString();
            }
            else
            {
                _personDetails.label1.Visible = true;

            }
            if (result.SecondMeeting.Date > DateTime.MinValue)
            {
                _personDetails.dtpMeeting2.Text = result.SecondMeeting.ToString();
            }
            else
            {
                _personDetails.label2.Visible = true;

            }

            if (result.ThirdMeeting.Date > DateTime.MinValue)
            {
                _personDetails.dtpMeeting3.Text = result.ThirdMeeting.ToString();
            }
            else
            {
                _personDetails.label3.Visible = true;


            }

            if (result.FourthMeeting.Date > DateTime.MinValue)
            {
                _personDetails.dtpMeeting4.Text = result.FourthMeeting.ToString();
            }
            else
            {
                _personDetails.label4.Visible = true;

            }

            if (result.FifthMeeting.Date > DateTime.MinValue)
            {
                _personDetails.dtpMeeting5.Text = result.FifthMeeting.ToString();
            }
            else
            {
                _personDetails.label5.Visible = true;

            }

            if (result.LastMeeting.Date > DateTime.MinValue)
            {
                _personDetails.dtpMeeting6.Text = result.LastMeeting.ToString();
            }
            else
            {
                _personDetails.label6.Visible = true;

            }

        }

        private void GetMeetingExplanation()
        {
            if (dgwPerson.CurrentRow != null)
            {
                _personDetails.txt1Explanation.Text = dgwPerson.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void dgwPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GetUser();
                btnDeleted.Visible = true;
                btnUpdated.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void dgwPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GetPersonName();
                GetMeetingDate();
                GetMeetingExplanation();
                GetMeetingId();
                _personDetails.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void dgwTodayMeeting_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PostExcel();
        }

        private void PostExcel()
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            object missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            var startCol = 1;
            var startRow = 1;
            sheet1.Cells.Rows.ColumnWidth = 15;
            string[] header = {"ADI", "SOYADI"};
            for (int j = 0; j < dgwTodayMeeting.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[startRow, startCol + j];
                myRange.Value2 = header[j];
            }

            startRow++;
            for (int i = 0; i < dgwTodayMeeting.Rows.Count; i++)
            {
                for (int j = 0; j < dgwTodayMeeting.Columns.Count; j++)
                {

                    Range myRange = (Range)sheet1.Cells[startRow + i, startCol + j];
                    myRange.Value2 = dgwTodayMeeting[j, i].Value == null ? "" : dgwTodayMeeting[j, i].Value;
                    myRange.Select();
                }
            }

            sheet1.Name = "Günün Görüşmeleri";
        }
        private void btnDeleted_Click(object sender, EventArgs e)
        {
            try
            {
                DeletePerson();
                LoadPerson();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void btnUpdated_Click(object sender, EventArgs e)
        {
            try
            {
                _person = UpdatePerson();
                _meeting = AddMeeting();
                UpdateMeeting();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           

        }
        private void btnAdded_Click(object sender, EventArgs e)
        {
            try
            {
                _person = AddPerson();
                _meeting = AddMeeting();
                AddMeetingControl();
                UpdateMeeting();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void dgwTodayMeeting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwTodayMeeting.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.ForestGreen;
        }


    }
}
