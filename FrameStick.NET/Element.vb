Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace VisualStyleDefinition

			''' <summary>
			''' Information about current visual element: Part, Joint or Neuro. To be used in _build() or _update()
			''' functions.
			''' </summary>
			Public Class Element

				''' <summary>
				''' geometry node associated with the visual element
				''' </summary>
				Private mNode As Integer

				''' <summary>
				''' gemetry node associated with the visual style
				''' </summary>
				Public Property node() As Integer
					Get
						Return Me.mNode
					End Get

					Set(ByVal value As Integer)
						Me.mNode = value
					End Set
				End Property

				''' <summary>
				''' prepare Creature object
				''' </summary>
				Public Sub useCreature()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare Joint object
				''' </summary>
				Public Sub useJoint()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare first Part from current Joint
				''' </summary>
				Public Sub useJointPart1()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare second Part from current Joint
				''' </summary>
				Public Sub useJointPart2()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare MechJoint object
				''' </summary>
				Public Sub useMechJoint()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare first MechPart from current object
				''' </summary>
				Public Sub useMechJointPart1()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare second MechPart from current object
				''' </summary>
				Public Sub useMechJointPart2()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare MechPart object
				''' </summary>
				Public Sub useMechPart()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare Model object
				''' </summary>
				Public Sub useModel()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare Neuro object
				''' </summary>
				Public Sub useNeuro()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare Joint from current Neuro
				''' </summary>
				Public Sub useNeuroJoint()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare Part from current Neuro
				''' </summary>
				Public Sub useNeuroPart()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' prepare Part object
				''' </summary>
				Public Sub usePart()
					' BUG: Implementieren
				End Sub
			End Class

		End Namespace

	End Namespace

End Namespace
