Namespace GlobalContext

Public Class Collision

		''' <summary>
		''' Creature 1
		''' </summary>
		Private mCreature1 As Object

		''' <summary>
		''' Creature 2
		''' </summary>
		Private mCreature2 As Object

		''' <summary>
		''' MechPart 1
		''' </summary>
		Private mMechPart1 As Object

		''' <summary>
		''' MechPart 2
		''' </summary>
		Private mMechPart2 As Object

		''' <summary>
		''' Part 1
		''' </summary>
		Private mPart1 As Object

		''' <summary>
		''' Part 2
		''' </summary>
		Private mPart2 As Object

		''' <summary>
		''' 
		''' </summary>
		''' <value></value>
		''' <remarks></remarks>
		Public Property Creature1() As Object
			Get
				Return Me.mCreature1
			End Get

			Set(ByVal value As Object)
				Me.mCreature1 = value
			End Set
		End Property

		''' <summary>
		''' 
		''' </summary>
		''' <value></value>
		''' <remarks></remarks>
		Public Property Creature2() As Object
			Get
				Return Me.mCreature2
			End Get

			Set(ByVal value As Object)
				Me.mCreature2 = value
			End Set
		End Property

		''' <summary>
		''' 
		''' </summary>
		''' <value></value>
		''' <remarks></remarks>
		Public Property MechPart1() As Object
			Get
				Return Me.mMechPart1
			End Get

			Set(ByVal value As Object)
				Me.mMechPart1 = value
			End Set
		End Property

		''' <summary>
		''' 
		''' </summary>
		''' <value></value>
		''' <remarks></remarks>
		Public Property MechPart2() As Object
			Get
				Return Me.mMechPart2
			End Get

			Set(ByVal value As Object)
				Me.mMechPart2 = value
			End Set
		End Property

		''' <summary>
		''' 
		''' </summary>
		''' <value></value>
		''' <remarks></remarks>
		Public Property Part1() As Object
			Get
				Return Me.mPart1
			End Get

			Set(ByVal value As Object)
				Me.mPart1 = value
			End Set
		End Property

		''' <summary>
		''' 
		''' </summary>
		''' <value></value>
		''' <remarks></remarks>
		Public Property Part2() As Object
			Get
				Return Me.mPart2
			End Get

			Set(ByVal value As Object)
				Me.mPart2 = value
			End Set
		End Property
	End Class

End Namespace


