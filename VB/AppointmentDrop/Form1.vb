Imports DevExpress.XtraScheduler
Imports System
Imports System.Windows.Forms

Namespace AppointmentDrop
   Partial Public Class Form1
       Inherits Form

        Public Sub New()
            InitializeComponent()
            AddHandler schedulerControl1.AppointmentDrop, AddressOf schedulerControl1_AppointmentDrop
            schedulerControl1.ActiveViewType = SchedulerViewType.WorkWeek
            schedulerControl1.Start = Date.Now.Date
            FillData()
        End Sub
        Private Sub FillData()
            Dim start As Date = schedulerControl1.Start.Date
            Dim apt As New Appointment(start.AddHours(2), TimeSpan.FromHours(1), "normal")
            Me.schedulerStorage1.Appointments.Add(apt)

            Dim pattern As New Appointment(AppointmentType.Pattern, start.AddHours(5), TimeSpan.FromHours(1), "recurring")
            pattern.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount
            pattern.RecurrenceInfo.Type = RecurrenceType.Daily
            pattern.RecurrenceInfo.Periodicity = 2
            pattern.RecurrenceInfo.OccurrenceCount = 5
            Me.schedulerStorage1.Appointments.Add(pattern)
        End Sub

        #Region "#appointmentdrop"
        Private Sub schedulerControl1_AppointmentDrop(ByVal sender As Object, ByVal e As AppointmentDragEventArgs)
            If e.EditedAppointment.IsRecurring Then
                e.Allow = DropRecurringAppointment(e.SourceAppointment.RecurrencePattern, e.EditedAppointment.Start)
            Else
                e.Allow = DropNormalAppointment(e.EditedAppointment, e.EditedAppointment.Start,e.SourceAppointment.Start)
            End If
        End Sub
        Private Function DropNormalAppointment(ByVal appointment As Appointment, ByVal newStart As Date, ByVal srcStart As Date) As Boolean
            Dim createEventMsg As String = "Creating an event on {0:D} at {1:t}."
            Dim moveEventMsg As String = "Moving the event " & ControlChars.CrLf & "scheduled on {0:D} at {1:T}" & ControlChars.CrLf & "to {2:dddd, dd MMM yyyy HH:mm:ss }."
            Dim msg As String = If(srcStart = Date.MinValue, String.Format(createEventMsg, newStart.Date,newStart.TimeOfDay), String.Format(moveEventMsg, srcStart.Date, srcStart.TimeOfDay, newStart))
           If MessageBox.Show(msg & " Proceed?", "Confirm the action", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                appointment.Start = newStart
                appointment.Subject += ControlChars.CrLf & "datetime modified"
                Return True
           End If
            Return False
        End Function
        Private Function DropRecurringAppointment(ByVal pattern As Appointment, ByVal newStart As Date) As Boolean
            Dim result As DialogResult = MessageBox.Show("Should the entire series follow the appointment?", "Confirm the action", MessageBoxButtons.YesNoCancel)
            If result = System.Windows.Forms.DialogResult.Yes Then
                pattern.DeleteExceptions()
                pattern.RecurrenceInfo.Start = newStart
            Else
                If result = System.Windows.Forms.DialogResult.No Then
                    Return True
                End If
            End If

            Return False
        End Function
        #End Region ' #appointmentdrop
   End Class
End Namespace
