Namespace GlobalContext

	''' <summary>
	''' Used to query for object member descriptions.
	''' 
	''' Eigendlich heißt die Klasse Interface, aber das ist wie so oft ein Schlüsselwort.
	''' </summary>
	''' <remarks>Used to query for object member descriptions.
	''' Example:
	''' <code>
	''' var iface=Interface.makeFrom(someobject); 
	''' var description = "this object has " + iface.properties + "properties, first property is " + iface.getId(0);
	''' </code>
	''' </remarks>
	Public Class Interfaces

		''' <summary>
		''' group count
		''' </summary>
		Private mGroups As Integer

		''' <summary>
		''' group count
		''' </summary>
		Public Property groups() As Integer
			Get
				Return Me.mGroups
			End Get

			Set(ByVal value As Integer)
				Me.mGroups = value
			End Set
		End Property

		''' <summary>
		''' object name
		''' </summary>
		Private mName As String

		''' <summary>
		''' object name
		''' </summary>
		Public Property name() As String
			Get
				Return Me.mName
			End Get

			Set(ByVal value As String)
				Me.mName = value
			End Set
		End Property

		''' <summary>
		''' property count
		''' </summary>
		Private mProperties As Integer

		''' <summary>
		''' property count
		''' </summary>
		Public Property properties() As Integer
			Get
				Return Me.mProperties
			End Get

			Set(ByVal value As Integer)
				Me.mProperties = value
			End Set
		End Property

		''' <summary>
		''' group # for group name
		''' </summary>
		Public Function findGroupId(ByVal name As String) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' item # for id
		''' </summary>
		Public Function findId(ByVal name As String) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' item # for id in group
		''' </summary>
		Public Function findIdInGroup(ByVal name As String, ByVal groupname As String) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' item # for id in group
		''' </summary>
		Public Function findIdInGroup(ByVal name As String, ByVal index As Integer) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' value of item #
		''' </summary>
		''' <remarks>eigendlich "get"</remarks>
		''' <returns>undefined field</returns>
		Public Function getItemNumber(ByVal index As Integer) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' flags for item #
		''' </summary>
		Public Function getFlags(ByVal index As Integer) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' group # for item #
		''' </summary>
		Public Function getGroup(ByVal index As Integer) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' group name for group #
		''' </summary>
		Public Function getGroupName(ByVal index As Integer) As String
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' help for item #
		''' </summary>
		Public Function getHelp(ByVal index As Integer) As String
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' id for item #
		''' </summary>
		Public Function getId(ByVal index As Integer) As String
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' name for item #
		''' </summary>
		Public Function getName(ByVal index As Integer) As String
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' type for item #
		''' </summary>
		''' <remarks>eigendlich getType, aber wieder ein schon benutztes Schlüsselwort.</remarks>
		''' <returns>string</returns>
		Public Function getItemType(ByVal index As Integer) As String
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' invoke action
		''' </summary>
		Public Sub invoke(ByVal functionname As String, ByVal arguments As FrameStick.GlobalContext.Vector)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' invike action
		''' </summary>
		Public Sub invoke(ByVal functionname As String, ByVal index As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' get interface object
		''' </summary>
		Public Function makeFrom(ByVal objeckt As Object) As FrameStick.GlobalContext.Interfaces
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' set value of item #
		''' </summary>
		''' <remarks>eigendlich "set"</remarks>
		''' <param name="value">undefined field</param>
		Public Sub setValue(ByVal index As Integer, ByVal value As Object)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' set default values for all items
		''' </summary>
		Public Sub setAllDefault()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' set default value for item #
		''' </summary>
		Public Sub setDefault(ByVal index As Integer)
			' BUG: Implementieren
		End Sub
	End Class

End Namespace
