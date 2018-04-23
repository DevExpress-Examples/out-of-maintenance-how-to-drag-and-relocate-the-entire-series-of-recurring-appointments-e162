Namespace My


    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")> _
    Friend NotInheritable Partial Class Settings
        Inherits System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As Settings = (CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings()), Settings))

        Public Shared ReadOnly Property [Default]() As Settings
            Get
                Return defaultInstance
            End Get
        End Property

        <Global.System.Configuration.ApplicationScopedSettingAttribute(), Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString), Global.System.Configuration.DefaultSettingValueAttribute("Data Source=ZAYTSEV_XP;Initial Catalog=XtraScheduling;Persist Security Info=True;" & "User ID=sa;Password=123")> _
        Public ReadOnly Property XtraSchedulingConnectionString() As String
            Get
                Return (DirectCast(Me("XtraSchedulingConnectionString"), String))
            End Get
        End Property

        <Global.System.Configuration.ApplicationScopedSettingAttribute(), Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString), Global.System.Configuration.DefaultSettingValueAttribute("Data Source=zaytsev_xp;Initial Catalog=BeautyCenter;Persist Security Info=True;Us" & "er ID=sa;Password=123")> _
        Public ReadOnly Property BeautyCenterConnectionString() As String
            Get
                Return (DirectCast(Me("BeautyCenterConnectionString"), String))
            End Get
        End Property
    End Class
End Namespace
