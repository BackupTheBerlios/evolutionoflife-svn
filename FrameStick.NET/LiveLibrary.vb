Namespace GlobalContext

	''' <summary>
	''' Manages all Creature objects in the experiment, organized in one or more groups. See also: Creature,
	''' CreaturesGroup
	''' </summary>
	Public Class LiveLibrary

		''' <summary>
		''' selected creature
		''' </summary>
		Private mCreature As Integer

		''' <summary>
		''' selected creature
		''' </summary>
		Public Property creature() As Integer
			Get
				Return Me.mCreature
			End Get

			Set(ByVal value As Integer)
				Me.mCreature = value
			End Set
		End Property

		''' <summary>
		''' selected group
		''' </summary>
		Private mGroup As Integer

		''' <summary>
		''' selected group
		''' </summary>
		Public Property group() As Integer
			Get
				Return Me.mGroup
			End Get

			Set(ByVal value As Integer)
				Me.mGroup = value
			End Set
		End Property

		''' <summary>
		''' Number of groups
		''' </summary>
		Private mGroupCount As Integer

		''' <summary>
		''' Number of groups
		''' </summary>
		Public Property groupcount() As Integer
			Get
				Return Me.mGroupCount
			End Get

			Set(ByVal value As Integer)
				Me.mGroupCount = value
			End Set
		End Property

		''' <summary>
		''' add live group
		''' </summary>
		Public Sub addGroup(ByVal name As String)
			' BUG: Implementieren
		End Sub

		Public Sub clear()
			' BUG: Implementieren
		End Sub

		Public Sub clearGroup(ByVal index As Integer)
			' BUG: Implementieren
		End Sub

		Public Function creatBBCollisions(ByVal mask As Integer) As Integer
			' BUG: Implementieren
		End Function

		Public Function createFromGenotype() As FrameStick.GlobalContext.Genotype
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Function createFromString() As FrameStick.GlobalContext.Genotype
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Sub delete()
			' BUG: Implementieren
		End Sub

		Public Function getGroup(ByVal index As Integer) As FrameStick.GlobalContext.CreatureGroup
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Sub kill()
			' BUG: Implementieren
		End Sub

		Public Sub remGroup(ByVal index As Integer)
			' BUG: Implementieren
		End Sub
	End Class

End Namespace
