Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace VisualStyleDefinition

			Public Class m

				''' <summary>
				''' startenergy
				''' </summary>
				Private mSe As Double

				''' <summary>
				''' vis_style
				''' </summary>
				Private mVstyle As String

				''' <summary>
				''' startenergy
				''' </summary>
				Public Property se() As Double
					Get
						Return Me.mSe
					End Get

					Set(ByVal value As Double)
						Me.mSe = value
					End Set
				End Property

				''' <summary>
				''' vis_style
				''' </summary>
				Public Property Vstyle() As String
					Get
						Return Me.mVstyle
					End Get

					Set(ByVal value As String)
						Me.mVstyle = value
					End Set
				End Property
			End Class

		End Namespace

	End Namespace

End Namespace
