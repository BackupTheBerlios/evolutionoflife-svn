Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace CommandLineInterface

			''' <summary>
			''' Object reference, can be used to provide online hints.
			''' </summary>
			Public Class ClassBrowser

				''' <summary>
				''' get result label
				''' </summary>
				Private mGetLabel As Integer

				''' <summary>
				''' get result text
				''' </summary>
				Private mGetText As Integer

				''' <summary>
				''' get result type
				''' </summary>
				Private mGetTypeOfResult As Integer

				''' <summary>
				''' result count
				''' </summary>
				Private mResultCount As Integer

				''' <summary>
				''' search
				''' </summary>
				Public Sub Search()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' get result Label
				''' </summary>
				Public Property GetLabel() As Integer
					Get
						Return Me.mGetLabel
					End Get

					Set(ByVal value As Integer)
						Me.mGetLabel = value
					End Set
				End Property

				''' <summary>
				''' get result text
				''' </summary>
				Public Property GetText() As Integer
					Get
						Return Me.mGetText
					End Get

					Set(ByVal value As Integer)
						Me.mGetText = value
					End Set
				End Property

				''' <summary>
				''' get result type
				''' </summary>
				Public Property GetTypeOfResult() As Integer
					Get
						Return Me.mGetTypeOfResult
					End Get

					Set(ByVal value As Integer)
						Me.mGetTypeOfResult = value
					End Set
				End Property

				''' <summary>
				''' result count
				''' </summary>
				Public Property ResultCount() As Integer
					Get
						Return Me.mResultCount
					End Get

					Set(ByVal value As Integer)
						Me.mResultCount = value
					End Set
				End Property
			End Class

		End Namespace

	End Namespace

End Namespace
