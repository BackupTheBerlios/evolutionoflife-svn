Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace NeuronDefinitions

			Public Class n

				''' <summary>
				''' item details
				''' </summary>
				Private mD As String

				''' <summary>
				''' info
				''' </summary>
				Private mI As String

				''' <summary>
				''' joint ref#
				''' </summary>
				''' <remarks>-1 bis 999999</remarks>
				Private mJ As Integer

				''' <summary>
				''' part ref#
				''' </summary>
				''' <remarks>-1 bis 999999</remarks>
				Private mP As Integer

				''' <summary>
				''' vis_style
				''' </summary>
				Private mVstyle As String

				''' <summary>
				''' item details
				''' </summary>
				Public Property d() As String
					Get
						Return Me.mD
					End Get

					Set(ByVal value As String)
						Me.mD = value
					End Set
				End Property

				''' <summary>
				''' info
				''' </summary>
				Public Property i() As String
					Get
						Return Me.mI
					End Get

					Set(ByVal value As String)
						Me.mI = value
					End Set
				End Property

				''' <summary>
				''' joint ref#
				''' </summary>
				''' <value>-1 bis 999.999</value>
				Public Property j() As Integer
					Get
						Return Me.mJ
					End Get

					Set(ByVal value As Integer)
						If value >= -1 And value <= 999999 Then
							Me.mJ = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -1 und 999999 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' part ref#
				''' </summary>
				''' <value>-1 bis 999.999</value>
				Public Property p() As Integer
					Get
						Return Me.mP
					End Get

					Set(ByVal value As Integer)
						If value >= -1 And value <= 999999 Then
							Me.mP = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -1 und 999999 liegen.")
						End If
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
