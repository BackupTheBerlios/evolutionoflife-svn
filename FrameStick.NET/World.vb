Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace VisualStyleDefinition

			''' <summary>
			''' Environment properties.
			''' </summary>
			Public Class World

				''' <summary>
				''' Boundaries
				''' </summary>
				''' <remarks>0 bis 2
				''' 
				''' 0 = None
				''' 1 = Fence
				''' 2 = Teleport</remarks>
				Private mWrldbnd As Integer

				''' <summary>
				''' Map
				''' </summary>
				Private mWrldmap As String

				''' <summary>
				''' Size
				''' </summary>
				''' <remarks>floating point
				''' 
				''' 10 bis 200</remarks>
				Private mWrldsiz As Double

				''' <summary>
				''' Type
				''' </summary>
				''' <remarks>0 bis 2
				''' 
				''' 0 = Flat surface
				''' 1 = Blocks
				''' 2 = Height field</remarks>
				Private mWrldtype As Integer

				''' <summary>
				''' Water level
				''' </summary>
				''' <remarks>floating point
				''' 
				''' -20 bis 30</remarks>
				Private mWrldwat As Double

				''' <summary>
				''' Boundaries
				''' </summary>
				''' <value>0 bis 2
				''' 
				''' 0 = None
				''' 1 = Fence
				''' 2 = Teleport</value>
				Public Property wrldbnd() As Integer
					Get
						Return Me.mWrldbnd
					End Get

					Set(ByVal value As Integer)
						If value >= 0 And value <= 2 Then
							Me.mWrldbnd = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' Map
				''' </summary>
				Public Property wrldmap() As String
					Get
						Return Me.mWrldmap
					End Get

					Set(ByVal value As String)
						Me.mWrldmap = value
					End Set
				End Property

				''' <summary>
				''' Size
				''' </summary>
				''' <value>floating point
				''' 
				''' 10 bis 200</value>
				Public Property wrldsiz() As Double
					Get
						Return Me.mWrldsiz
					End Get

					Set(ByVal value As Double)
						If value >= 10 And value <= 200 Then
							Me.mWrldsiz = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 10 und 200 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' Type
				''' </summary>
				''' <value>0 bis 2
				''' 
				''' 0 = Flat surface
				''' 1 = Blocks
				''' 2 = Height field</value>
				Public Property wrldtype() As Integer
					Get
						Return Me.mWrldtype
					End Get

					Set(ByVal value As Integer)
						If value >= 0 And value <= 2 Then
							Me.mWrldtype = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' Watter level
				''' </summary>
				''' <value>floating point
				''' 
				''' -20 bis 30</value>
				Public Property wrldwat() As Double
					Get
						Return Me.mWrldwat
					End Get

					Set(ByVal value As Double)
						If value >= -20 And value <= 30 Then
							Me.mWrldwat = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -20 und 30 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' Trigger world update
				''' </summary>
				Public Sub wrldchg()
					' BUG: Implementieren
				End Sub
			End Class

		End Namespace

	End Namespace

End Namespace
