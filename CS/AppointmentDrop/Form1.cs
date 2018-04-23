using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace AppointmentDrop
{
   public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();

			schedulerControl1.ActiveViewType = SchedulerViewType.WorkWeek;
            schedulerControl1.Start = DateTime.Now.Date;
			FillData();
		}
		private void FillData() {
			DateTime start = schedulerControl1.Start.Date;
			Appointment apt = new Appointment(start.AddHours(5), TimeSpan.FromHours(2), "normal");
			this.schedulerStorage1.Appointments.Add(apt);

			Appointment pattern = new Appointment(AppointmentType.Pattern, start.AddHours(8), TimeSpan.FromHours(1), "recurring");
			pattern.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount;
			pattern.RecurrenceInfo.Type = RecurrenceType.Daily;
			pattern.RecurrenceInfo.Periodicity = 2;
			pattern.RecurrenceInfo.OccurrenceCount = 5;
			this.schedulerStorage1.Appointments.Add(pattern);
		}
		
       private void schedulerControl1_AppointmentDrop(object sender, AppointmentDragEventArgs e) {
			if (e.EditedAppointment.IsRecurring)
				e.Allow = DropRecurringAppointment (e.SourceAppointment.RecurrencePattern, e.EditedAppointment.Start);
			else
                e.Allow = DropNormalAppointment(e.EditedAppointment, e.EditedAppointment.Start,e.SourceAppointment.Start);

			e.Handled = true;
		}
		private bool DropNormalAppointment(Appointment appointment, DateTime newStart,DateTime srcStart ) {
            string createEventMsg = "Creating an event on {0:D} at {1:t}.";
            string moveEventMsg = "Moving the event \r\nscheduled on {0:D} at {1:T}\r\nto {2:dddd, dd MMM yyyy HH:mm:ss }.";


            string msg = (srcStart == DateTime.MinValue) ? String.Format(createEventMsg, newStart.Date,newStart.TimeOfDay) :
                String.Format(moveEventMsg, srcStart.Date, srcStart.TimeOfDay, newStart);

           if (MessageBox.Show(msg + " Proceed?", "Confirm the action", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				appointment.Start = newStart;
				appointment.Subject += "\r\ndatetime modified";
				return true;
			}
			return false;
		}
		private bool DropRecurringAppointment(Appointment pattern, DateTime newStart) {
			DialogResult result = MessageBox.Show("Should the entire series follow the appointment?", "Confirm the action", MessageBoxButtons.YesNoCancel);
			if (result == DialogResult.Yes) {
				pattern.DeleteExceptions();
				pattern.RecurrenceInfo.Start = newStart;
			} else 
				if (result == DialogResult.No)
					return true;

			return false;
		}

       private void Form1_Load(object sender, EventArgs e)
       {

       }
        void scheduler_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e) {
            Appointment apt = e.ViewInfo.Appointment;
            if (apt.HasReminder && apt.Type == AppointmentType.Occurrence && apt.RecurrencePattern != null)
            {
                Appointment pattern = apt.RecurrencePattern;
                RecurringReminder reminder = (RecurringReminder)pattern.Reminder;
                e.ViewInfo.ShowBell = reminder.AlertOccurrenceIndex <= apt.RecurrenceIndex;
            }
		        }
       
	}
}
