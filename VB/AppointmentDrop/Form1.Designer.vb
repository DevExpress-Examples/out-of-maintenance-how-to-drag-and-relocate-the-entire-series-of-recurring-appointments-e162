Imports Microsoft.VisualBasic
Imports System
Namespace AppointmentDrop
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
			Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
			Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' schedulerControl1
			' 
			Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
			Me.schedulerControl1.Location = New System.Drawing.Point(0, 0)
			Me.schedulerControl1.LookAndFeel.SkinName = "iMaginary"
			Me.schedulerControl1.LookAndFeel.UseDefaultLookAndFeel = False
			Me.schedulerControl1.Name = "schedulerControl1"
			Me.schedulerControl1.Size = New System.Drawing.Size(696, 360)
			Me.schedulerControl1.Start = New System.DateTime(2008, 2, 13, 0, 0, 0, 0)
			Me.schedulerControl1.Storage = Me.schedulerStorage1
			Me.schedulerControl1.TabIndex = 0
			Me.schedulerControl1.Text = "schedulerControl1"
			Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
			Me.schedulerControl1.Views.TimelineView.Enabled = False
			Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
'			Me.schedulerControl1.AppointmentDrop += New DevExpress.XtraScheduler.AppointmentDragEventHandler(Me.schedulerControl1_AppointmentDrop);
'			Me.schedulerControl1.AppointmentViewInfoCustomizing += New DevExpress.XtraScheduler.AppointmentViewInfoCustomizingEventHandler(Me.scheduler_AppointmentViewInfoCustomizing);
			' 
			' schedulerStorage1
			' 
			Me.schedulerStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("CustomField1", "CustomField1"))
			Me.schedulerStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("OutookEntryID", "OutookEntryID"))
			Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
			Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
			Me.schedulerStorage1.Appointments.Mappings.End = "EndDate"
			Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
			Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
			Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
			Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
			Me.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceID"
			Me.schedulerStorage1.Appointments.Mappings.Start = "StartDate"
			Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
			Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
			Me.schedulerStorage1.Appointments.Mappings.Type = "Type"
			Me.schedulerStorage1.Resources.Mappings.Caption = "ResourceName"
			Me.schedulerStorage1.Resources.Mappings.Color = "Color"
			Me.schedulerStorage1.Resources.Mappings.Id = "ResourceID"
			Me.schedulerStorage1.Resources.Mappings.Image = "Image"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(696, 360)
			Me.Controls.Add(Me.schedulerControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
		Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
	End Class
End Namespace

