Namespace GlobalContext

	''' <summary>
	''' Manages all genotypes in the experiment, organized in one or more groups.
	''' </summary>
	''' <remarks>Manages all genotypes in the experiment, organized in one or more groups.
	''' Some functions refer to the "selected genotype" i.e. the genotype number "GenotypeLibrary.genotype" in the group number "GenotypeLibrary.group".
	''' 
	''' For example to access the first genoype in the first group you could do:
	''' 
	''' <code>
	''' GenotypeLibrary.group=0;
	''' GenotypeLibrary.genotype=0;
	''' var name=Genotype.name;
	''' </code>
	''' 
	''' The new preferred way doesn't refer to the static Genotype object:
	''' 
	''' <code>
	''' var name=GenotypeLibrary.getGroup(0).getGenotype(0).name;
	''' </code></remarks>
	Public Class GenotypeLibrary

		''' <summary>
		''' selected genotype
		''' </summary>
		Private mGenotype As Integer

		''' <summary>
		''' selected genotype
		''' </summary>
		Public Property genotype() As Integer
			Get
				Return Me.mGenotype
			End Get

			Set(ByVal value As Integer)
				Me.mGenotype = value
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
		''' number og groups
		''' </summary>
		Private mGroupcount As Integer

		''' <summary>
		''' Number of groups
		''' </summary>
		Public Property groupcount() As Integer
			Get
				Return Me.mGroupcount
			End Get

			Set(ByVal value As Integer)
				Me.mGroupcount = value
			End Set
		End Property

		''' <summary>
		''' add genotype group
		''' </summary>
		Public Sub addGroup(ByVal name As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' add performance figures from creature
		''' </summary>
		Public Sub addPerformanceFromCreature()
			' BUG: Implementieren
		End Sub

		Public Sub clear()
			' BUG: Implementieren
		End Sub

		Public Sub clearGroup(ByVal index As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' copy selected genotype to another group
		''' </summary>
		Public Sub copyGenotype()
			' BUG: Implementieren
		End Sub

		Public Sub crossover(ByVal index As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' remove 1 genotype (with respect to popsiz)
		''' </summary>
		Public Sub del1Genotype()
			' BUG: Implementieren
		End Sub

		Public Sub delGenotype()
			' BUG: Implementieren
		End Sub

		Public Function findGenotype() As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Function findGenotypeForCreature() As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Sub getFromCreature()
			' BUG: Implementieren
		End Sub

		Public Sub getFromCreatureObject(ByVal creature As FrameStick.GlobalContext.Creature)
			' BUG: Implementieren
		End Sub

		Public Function getGroup(ByVal index As Integer) As FrameStick.GlobalContext.GenotypeGroup
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <param name="MinimumSimilarity">floating point</param>
		Public Function likeThisRoulette(ByVal MinimumSimilarity As Double) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Sub mutate()
			' BUG: Implementieren
		End Sub

		Public Sub newGenotype(ByVal genotye As String)
			' BUG: Implementieren
		End Sub

		Public Function random() As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <param name="MinimumSimilarity">floating point</param>
		Public Function randomLikeThis(ByVal MinimumSimilarity As Double) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Sub remGroup(ByVal index As Integer)
			' BUG: Implementieren
		End Sub

		Public Function revroulette() As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Function roulette() As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <param name="genotypes">genotypes in tournament</param>
		Public Function tournament(ByVal genotypes As Integer) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Function worst() As Integer
			' BUG: Implementieren
			Return Nothing
		End Function
	End Class

End Namespace
