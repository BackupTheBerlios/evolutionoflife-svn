Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace VisualStyleDefinition

			''' <summary>
			''' Environment details for "Blocks" and "Heightfield" world type.
			''' </summary>
			Public Class WorldMap

				''' <summary>
				''' Map x size
				''' </summary>
				Private mXsize As Integer

				''' <summary>
				''' Map y size
				''' </summary>
				Private mYsize As Integer

				''' <summary>
				''' Map x size
				''' </summary>
				Public Property xsize() As Integer
					Get
						Return Me.mXsize
					End Get

					Set(ByVal value As Integer)
						Me.mXsize = value
					End Set
				End Property

				''' <summary>
				''' Map y size
				''' </summary>
				Public Property ysize() As Integer
					Get
						Return Me.mYsize
					End Get

					Set(ByVal value As Integer)
						Me.mYsize = value
					End Set
				End Property

				''' <summary>
				''' Height
				''' </summary>
				Public Function getHeight(ByVal x As Double, ByVal y As Double) As Double
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' getMap
				''' </summary>
				Public Function getMap(ByVal x As Integer, ByVal y As Integer) As Object
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' intersect
				''' </summary>
				Public Function intersect(ByVal point3d As FrameStick.GlobalContext.Vector, ByVal direction3d As FrameStick.GlobalContext.Vector) As FrameStick.GlobalContext.Vector
					' BUG: Implementieren
					Return Nothing
				End Function
			End Class

		End Namespace

	End Namespace

End Namespace
