Namespace GlobalContext

	''' <summary>
	''' The static NeuroClass object refers to class selected in the NeuroClassLibrary.
	''' </summary>
	''' <remarks></remarks>
	Public Class NeuroClass

		''' <summary>
		''' Long Description
		''' </summary>
		Private mDescription As String

		''' <summary>
		''' Glyph vector data
		''' </summary>
		Private mGlyph As String

		''' <summary>
		''' Long, human readable name
		''' </summary>
		Private mLongname As String

		''' <summary>
		''' Class name
		''' </summary>
		Private mName As String

		''' <summary>
		''' Preferred number of inputs
		''' </summary>
		Private mPrefinputs As Integer

		''' <summary>
		''' Preferred body location
		''' </summary>
		''' <remarks>0 bis 2
		''' 
		''' 0 = None
		''' 1 = Part
		''' 2 = Joint</remarks>
		Private mPreflocation As Integer

		''' <summary>
		''' Provides output
		''' </summary>
		Private mPrefoutput As Boolean

		''' <summary>
		''' Interface object connected with neuron class properties
		''' </summary>
		Private mProperties As FrameStick.GlobalContext.Interfaces

		''' <summary>
		''' Visual hints
		''' </summary>
		Private mVisualhints As Integer

		''' <summary>
		''' Long Description
		''' </summary>
		Public Property description() As String
			Get
				Return Me.mDescription
			End Get

			Set(ByVal value As String)
				Me.mDescription = value
			End Set
		End Property

		''' <summary>
		''' Glyph vector data
		''' </summary>
		Public Property glyph() As String
			Get
				Return Me.mGlyph
			End Get

			Set(ByVal value As String)
				Me.mGlyph = value
			End Set
		End Property

		''' <summary>
		''' Long, human readable name
		''' </summary>
		Public Property longname() As String
			Get
				Return Me.mLongname
			End Get

			Set(ByVal value As String)
				Me.mLongname = value
			End Set
		End Property

		''' <summary>
		''' Classname
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
		''' Prefferred number of inputs
		''' </summary>
		Public Property prefinputs() As Integer
			Get
				Return Me.mPrefinputs
			End Get

			Set(ByVal value As Integer)
				Me.mPrefinputs = value
			End Set
		End Property

		''' <summary>
		''' Preferred body location
		''' </summary>
		''' <value>0 bis 2
		''' 
		''' 0 = None
		''' 1 = Part
		''' 2 = Joint
		''' </value>
		Public Property preflocation() As Integer
			Get
				Return Me.mPreflocation
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 2 Then
					Me.mPreflocation = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Provides output
		''' </summary>
		Public Property prefoutput() As Boolean
			Get
				Return Me.mPrefoutput
			End Get

			Set(ByVal value As Boolean)
				Me.mPrefoutput = value
			End Set
		End Property

		''' <summary>
		''' Interface object connected with neuron class properties
		''' </summary>
		Public Property properties() As FrameStick.GlobalContext.Interfaces
			Get
				Return Me.mProperties
			End Get

			Set(ByVal value As FrameStick.GlobalContext.Interfaces)
				Me.mProperties = value
			End Set
		End Property

		''' <summary>
		''' Visual hints
		''' </summary>
		Public Property visualhints() As Integer
			Get
				Return Me.mVisualhints
			End Get

			Set(ByVal value As Integer)
				Me.mVisualhints = value
			End Set
		End Property

	End Class

End Namespace
