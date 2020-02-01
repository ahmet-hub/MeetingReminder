using System;
using System.Globalization;
using System.Windows.Forms;
using MeetingReminder.Business.Abstract;
using MeetingReminder.Business.Concrete;
using MeetingReminder.DataAccess.Concrete.EntityFramework;
using MeetingReminder.Entities;
using Microsoft.Office.Interop.Excel;

namespace MeetingReminder.WebFormsUO
{
    public partial class PersonDetails : Form
    {
        private readonly IMeetingControlService _meetingControlService = new MeetingControlManager(new EfMeetingControlDal());
        private readonly IMeetingService _meetingService = new MeetingManager(new EfMeetingDal());
        public PersonDetails()
        {
            InitializeComponent();
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
           CheckButton();
        }

        public void CheckButton()
        {
            var result = GetMeetingControl();
            if (result.FirstMeeting == "GELDI")
            {
                button1.Text = @"✓";
            }

            if (result.FirstMeeting == "GELMEDI")
            {
                button1.Text = @"X";
            }
            //

            if (result.SecondMeeting == "GELDI")
            {
                button2.Text= "✓";
            }

            if (result.SecondMeeting == "GELMEDI")
            {
                button2.Text = "X";
            }
            //
            if (result.ThirdMeeting == "GELDI")
            {
                button3.Text = "✓";
            }

            if (result.ThirdMeeting == "GELMEDI")
            {
                button3.Text = "X";
            }
            //
            if (result.FourthMeeting == "GELDI")
            {
                button4.Text = "✓";
            }

            if (result.FourthMeeting == "GELMEDI")
            {
                button4.Text = "X";
            }
            //
            if (result.FifthMeeting == "GELDI")
            {
                button5.Text = "✓";
            }

            if (result.FifthMeeting == "GELMEDI")
            {
                button5.Text = "X";
            }
            //
            if (result.LastMeeting == "GELDI")
            {
                button6.Text = "✓";
            }

            if (result.LastMeeting == "GELMEDI")
            {
                button6.Text = "X";
            }

        }

        public int GetMeetingId()
        {
            var meeting = _meetingService.Get(Convert.ToInt32(txtId.Text));
            return meeting.MeetingID;
        }
        public MeetingControl GetMeetingControl()
        {
           var meeting= _meetingService.Get(Convert.ToInt32(txtId.Text));

            return _meetingControlService.Get(meeting.MeetingID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = GetMeetingControl();
            if (result.FirstMeeting == "GELDI")
            {
                button1.Text= "✓";
            }

            if (result.FirstMeeting == "GELMEDI")
            {
                button1.Text = "X";
            }
            
            
            if (button1.Text=="X")
            {
                button1.Text = "✓";

                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = "GELDI",
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.FourthMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingControlService.Update(meetingControl);
            }

            else
            {
                button1.Text = "X";
                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = "GELMEDI",
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.FourthMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingControlService.Update(meetingControl);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = GetMeetingControl();
            if (result.SecondMeeting == "GELDI")
            {
                button2.Text = "✓";
            }

            if (result.SecondMeeting == "GELMEDI")
            {
                button2.Text = "X";
            }


            if (button2.Text == "X")
            {
                button2.Text = "✓";
                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = "GELDI",
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.FourthMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingControlService.Update(meetingControl);
            }
            else
            {
                button2.Text = "X";
                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = "GELMEDI",
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.FourthMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingControlService.Update(meetingControl);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            var result = GetMeetingControl();
            if (result.ThirdMeeting == "GELDI")
            {
                button3.Text= "✓";
            }

            if (result.ThirdMeeting == "GELMEDI")
            {
                button3.Text = "X";
            }

            if (button3.Text == "X")
            {
                button3.Text = "✓";
                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = "GELDI",
                    FourthMeeting = result.FourthMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingControlService.Update(meetingControl);

            }
            else
            {
                button3.Text = "X";
                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = "GELMEDI",
                    FourthMeeting = result.FourthMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingControlService.Update(meetingControl);

            }

        }
        private void button4_Click(object sender, EventArgs e)
        {

            var result = GetMeetingControl();
            if (result.FourthMeeting == "GELDI")
            {
                button4.Text = "✓";
            }

            if (result.FourthMeeting == "GELMEDI")
            {
                button4.Text = "X";
            }


            if (button4.Text == "X")
            {
                button4.Text = "✓";

                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = "GELDI",
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingControlService.Update(meetingControl);
                
            }
            else
            {
                button4.Text = "X";
                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = "GELMEDI",
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingControlService.Update(meetingControl);
            }
            


        }

        private void button5_Click(object sender, EventArgs e)
        {

            var result = GetMeetingControl();
            if (result.FifthMeeting == "GELDI")
            {
                button5.Text = "✓";
            }

            if (result.FifthMeeting == "GELMEDI")
            {
                button5.Text = "X";
            }


            if (button5.Text == "X")
            {
                button5.Text = "✓";

                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.FourthMeeting,
                    FifthMeeting = "GELDI",
                    LastMeeting = result.LastMeeting
                };
                _meetingControlService.Update(meetingControl);
            }
            else
            {
                button5.Text = "X";
                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.FourthMeeting,
                    FifthMeeting = "GELMEDI",
                    LastMeeting = result.LastMeeting
                };
                _meetingControlService.Update(meetingControl);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var result = GetMeetingControl();
            if (result.LastMeeting == "GELDI")
            {
                button6.Text = "✓";
            }

            if (result.LastMeeting == "GELMEDI")
            {
                button6.Text = "X";
            }


            if (button6.Text == "X")
            {
                button6.Text = "✓";

                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.FourthMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = "GELDI"
                };
                _meetingControlService.Update(meetingControl);
            }
            else
            {
                button6.Text = "X";
                MeetingControl meetingControl = new MeetingControl
                {
                    MeetingControlID = GetMeetingId(),
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.FourthMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = "GELMEDI"
                };
                _meetingControlService.Update(meetingControl);
            }

        }

        public void PostExcel()
        {
            var result = _meetingService.Get(Convert.ToInt32(txtId.Text));
            var resultControl = _meetingControlService.Get(result.MeetingID);
            DateTime[] dateTimes =
            {
                result.FirstMeeting, result.SecondMeeting, result.ThirdMeeting, result.FourthMeeting,
                result.FifthMeeting, result.LastMeeting
            };
            string[] controls =
            {
                resultControl.FirstMeeting,resultControl.SecondMeeting,resultControl.ThirdMeeting,resultControl.FourthMeeting,resultControl.FifthMeeting,resultControl.LastMeeting
            };
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            object missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            int startCol = 1;
            int startRow = 1;
            sheet1.Rows.ColumnWidth=15;
            string[] array = { "1.TOPLANTI", "2.TOPLANTI", "3.TOPLANTI", "4.TOPLANTI", "5.TOPLANTI", "6.TOPLANTI" };
            for (int i = 0; i < array.Length; i++)
            {
                Range myRange = (Range)sheet1.Cells[startRow + i, startCol];
                myRange.Value2 = array[i];
            }

            for (int i = 0; i < array.Length; i++)
            {

                Range myRangeRow = (Range)sheet1.Cells[startRow + i, startCol];
                myRangeRow.Value2 = dateTimes[i].Date.ToShortDateString();
                string dayName = CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat.DayNames[(int)dateTimes[i].DayOfWeek];
                Range myRangeColumnDay= (Range)sheet1.Cells[startRow + i, startCol + 1];
                myRangeColumnDay.Value2 = dayName;
                Range myRangeColumn = (Range)sheet1.Cells[startRow+i, startCol + 2];
                myRangeColumn.Value2 = controls[i];
                myRangeRow.Select();
                myRangeColumn.Select();
                myRangeColumnDay.Select();
            }

            sheet1.Name = lblTabPage1Name.Text;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblTabPage1Name_Click(object sender, EventArgs e)
        {

           PostExcel();
        }

        private int sayac1=0;
        private void dtpMeeting1_ValueChanged(object sender, EventArgs e)
        {
            sayac1++;

            if (sayac1 > 1)
            {
                var result = _meetingService.Get(Convert.ToInt32(txtId.Text));

                Meeting meeting = new Meeting
                {
                    MeetingID = result.MeetingID,
                    PersonID = result.PersonID,
                    
                    FirstMeeting = dtpMeeting1.Value,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.ThirdMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingService.Update(meeting);
                MessageBox.Show("Toplantı tarihi Değiştirildi");
            }
            
        }

        private void dtpMeeting1_MouseCaptureChanged(object sender, EventArgs e)
        {
        }

        private int sayac2 = 0;
        private void dtpMeeting2_ValueChanged(object sender, EventArgs e)
        {
            sayac2++;
            if (sayac2 > 1)
            {
                var result = _meetingService.Get(Convert.ToInt32(txtId.Text));

                Meeting meeting = new Meeting
                {
                    MeetingID = result.MeetingID,
                    PersonID = result.PersonID,
                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = dtpMeeting2.Value,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.ThirdMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingService.Update(meeting);
                MessageBox.Show("Toplantı tarihi Değiştirildi");
            }

        }

        private int sayac3 = 0;
        private void dtpMeeting3_ValueChanged(object sender, EventArgs e)
        {
            sayac3++;
            if (sayac3 > 1)
            {
                var result = _meetingService.Get(Convert.ToInt32(txtId.Text));

                Meeting meeting = new Meeting
                {
                    MeetingID = result.MeetingID,
                    PersonID = result.PersonID,

                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = dtpMeeting3.Value,
                    FourthMeeting = result.ThirdMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingService.Update(meeting);
                MessageBox.Show("Toplantı tarihi Değiştirildi");
            }
        }

        private int sayac4 = 0;
        private void dtpMeeting4_ValueChanged(object sender, EventArgs e)
        {
            sayac4 = 0;
            if (sayac4 > 1)
            {
                var result = _meetingService.Get(Convert.ToInt32(txtId.Text));

                Meeting meeting = new Meeting
                {
                    MeetingID = result.MeetingID,
                    PersonID = result.PersonID,

                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = dtpMeeting4.Value,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = result.LastMeeting
                };
                _meetingService.Update(meeting);
                MessageBox.Show("Toplantı tarihi Değiştirildi");
            }

        }

        private int sayac5 = 0;

        private void dtpMeeting5_ValueChanged(object sender, EventArgs e)
        {
            sayac5++;
            if (sayac5 > 1)
            {
                var result = _meetingService.Get(Convert.ToInt32(txtId.Text));

                Meeting meeting = new Meeting
                {
                    MeetingID = result.MeetingID,
                    PersonID = result.PersonID,

                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.ThirdMeeting,
                    FifthMeeting =dtpMeeting5.Value,
                    LastMeeting = result.LastMeeting
                };
                _meetingService.Update(meeting);
                MessageBox.Show("Toplantı tarihi Değiştirildi");
            }

        }

        private int sayac6 = 0;
        private void dtpMeeting6_ValueChanged(object sender, EventArgs e)
        {
            sayac6++;
            if (sayac6 > 1)
            {
                var result = _meetingService.Get(Convert.ToInt32(txtId.Text));

                Meeting meeting = new Meeting
                {
                    MeetingID = result.MeetingID,
                    PersonID = result.PersonID,

                    FirstMeeting = result.FirstMeeting,
                    SecondMeeting = result.SecondMeeting,
                    ThirdMeeting = result.ThirdMeeting,
                    FourthMeeting = result.ThirdMeeting,
                    FifthMeeting = result.FifthMeeting,
                    LastMeeting = dtpMeeting6.Value
                };
                _meetingService.Update(meeting);
                MessageBox.Show("Toplantı tarihi Değiştirildi");

            }

        }
    }
}