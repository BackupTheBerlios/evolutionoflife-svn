Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace VisualStyleDefinition

			''' <summary>
			''' Load 3d objects files.
			''' </summary>
			Public Class Loader

				''' <summary>
				''' load geometry
				''' </summary>
				Private mLoaded As Integer

				''' <summary>
				''' load geometry
				''' </summary>
				Public Property loaded() As Integer
					Get
						Return Me.mLoaded
					End Get

					Set(ByVal value As Integer)
						Me.mLoaded = value
					End Set
				End Property

				''' <summary>
				''' load
				''' </summary>
				Public Sub load()
					' BUG: Implementieren
				End Sub
			End Class

		End Namespace

	End Namespace

End Namespace
