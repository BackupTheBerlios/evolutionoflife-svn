Namespace GlobalContext

	''' <summary>
	''' Set of Neuron classes. You can access the selected class in the static NeuroClass object.
	''' </summary>
	''' <remarks></remarks>
	Public Class NeuroClassLibrary

		''' <summary>
		''' current class
		''' </summary>
		''' <remarks>0 bis count -1</remarks>
		Private mCurClass As Integer

		''' <summary>
		''' class count
		''' </summary>
		Private mCount As Integer

		''' <summary>
		''' current class
		''' </summary>
		''' <remarks>Eigendlich "class"</remarks>
		''' <value>0 bis count - 1</value>
		Public Property curClass() As Integer
			Get
				Return Me.mCurClass
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value >= (Me.mCount - 1) Then
					Me.mCurClass = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und (Me.count - 1) liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' class count
		''' </summary>
		Public Property count() As Integer
			Get
				Return Me.mCount
			End Get

			Set(ByVal value As Integer)
				Me.mCount = value
			End Set
		End Property

		''' <summary>
		''' select class by name
		''' </summary>
		Public Sub findClass(ByVal classname As String)
			' BUG: Implemntieren
		End Sub
	End Class


End Namespace
