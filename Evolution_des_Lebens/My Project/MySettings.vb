﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version:2.0.40607.85
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On



Partial NotInheritable Class MySettings
    Inherits System.Configuration.ApplicationSettingsBase
    
    Private Shared m_Value As MySettings
    
    Private Shared m_SyncObject As Object = New Object
    
    <System.Diagnostics.DebuggerNonUserCode()>  _
    Public Shared ReadOnly Property Value() As MySettings
        Get
            If (MySettings.m_Value Is Nothing) Then
                System.Threading.Monitor.Enter(MySettings.m_SyncObject)
                If (MySettings.m_Value Is Nothing) Then
                    Try 
                        MySettings.m_Value = New MySettings
                    Finally
                        System.Threading.Monitor.Exit(MySettings.m_SyncObject)
                    End Try
                End If
            End If
            Return MySettings.m_Value
        End Get
    End Property
    
    <System.Diagnostics.DebuggerNonUserCode(),  _
     System.Configuration.UserScopedSettingAttribute(),  _
     System.Configuration.DefaultSettingValueAttribute("Manual")>  _
    Public Property StartPosition() As System.Windows.Forms.FormStartPosition
        Get
            Return CType(Me("StartPosition"),System.Windows.Forms.FormStartPosition)
        End Get
        Set
            Me("StartPosition") = value
        End Set
    End Property
    
    <System.Diagnostics.DebuggerNonUserCode(),  _
     System.Configuration.UserScopedSettingAttribute(),  _
     System.Configuration.DefaultSettingValueAttribute("0")>  _
    Public Property TabIndex() As Integer
        Get
            Return CType(Me("TabIndex"),Integer)
        End Get
        Set
            Me("TabIndex") = value
        End Set
    End Property
    
    <System.Diagnostics.DebuggerNonUserCode(),  _
     System.Configuration.UserScopedSettingAttribute(),  _
     System.Configuration.DefaultSettingValueAttribute("770, 559")>  _
    Public Property MinimumSize() As System.Drawing.Size
        Get
            Return CType(Me("MinimumSize"),System.Drawing.Size)
        End Get
        Set
            Me("MinimumSize") = value
        End Set
    End Property
End Class

Namespace My
    
    <Microsoft.VisualBasic.HideModuleName()>  _
    Public Module MySettingsProperty
        
        <System.Diagnostics.DebuggerNonUserCode()>  _
        Friend ReadOnly Property Settings() As MySettings
            Get
                Return MySettings.Value
            End Get
        End Property
    End Module
End Namespace
