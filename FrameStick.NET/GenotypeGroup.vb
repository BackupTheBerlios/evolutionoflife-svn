Namespace GlobalContext

	''' <summary> 
	''' The static GenotypeGroup object refers to the "selected group" as described in GenotypeLibrary
	''' </summary>
	Public Class GenotypeGroup

		''' <summary>
		''' Number of unique genotypes
		''' </summary>
		Private mCount As Integer

		''' <summary>
		''' Number og unique genotypes
		''' </summary>
		Public Property count() As Integer
			Get
				Return Me.mCount
			End Get

			Set(ByVal value As Integer)
				Me.mCount = value
			End Set
		End Property

		''' <summary>
		''' Scale fitness?
		''' </summary>
		''' <remarks>Enable fitnes scaling</remarks>
		Private mFitfun As Boolean

		''' <summary>
		''' Scale fitness
		''' </summary>
		''' <remarks>Enable fitness scaling</remarks>
		Public Property fitfun() As Boolean
			Get
				Return Me.mFitfun
			End Get

			Set(ByVal value As Boolean)
				Me.mFitfun = value
			End Set
		End Property

		''' <summary>
		''' Shift coefficient
		''' </summary>
		''' <remarks>floatin point
		''' 
		''' 0 bis 10</remarks>
		Private mFitm As Double

		''' <summary>
		''' Shift coefficient
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 10</value>
		Public Property fitm() As Double
			Get
				Return Me.mFitm
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 10 Then
					Me.mFitm = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 10 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Scaling coefficient
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 1 bis 10</remarks>
		Private mFita As Double

		''' <summary>
		''' Scaling coefficient
		''' </summary>
		''' <value>floating point
		''' 
		''' 1 bis 10</value>
		Public Property fita() As Double
			Get
				Return Me.mFita
			End Get

			Set(ByVal value As Double)
				If value >= 1 And value <= 10 Then
					Me.mFita = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 1 und 10 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Fitness formula
		''' </summary>
		Private mFitness As String

		''' <summary>
		''' Fitness formula
		''' </summary>
		Public Property fitness() As String
			Get
				Return Me.mFitness
			End Get

			Set(ByVal value As String)
				Me.mFitness = value
			End Set
		End Property

		''' <summary>
		''' group index
		''' </summary>
		Private mIndex As Integer

		''' <summary>
		''' group index
		''' </summary>
		Public Property index() As Integer
			Get
				Return Me.mIndex
			End Get

			Set(ByVal value As Integer)
				Me.mIndex = value
			End Set
		End Property

		''' <summary>
		''' Group Name
		''' </summary>
		Private mName As String

		''' <summary>
		''' Group name
		''' </summary>
		Public Property name() As String
			Get
				Return Me.mName
			End Get

			Set(ByVal value As String)
				Me.mName = value
			End Set
		End Property

		''' <summary>
		''' Number of genotype instances
		''' </summary>
		Private mTotalpop As Integer

		''' <summary>
		''' Number of genotype instances
		''' </summary>
		Public Property totalpop() As Integer
			Get
				Return Me.mTotalpop
			End Get

			Set(ByVal value As Integer)
				Me.mTotalpop = value
			End Set
		End Property

		''' <summary>
		''' make Genotype from Geno
		''' </summary>
		Public Function addGeno(ByVal geno As FrameStick.GlobalContext.Geno) As FrameStick.GlobalContext.Genotype
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' find Genotype index
		''' </summary>
		Public Function findGeno(ByVal geno As FrameStick.GlobalContext.Geno) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' find Genotype by UID
		''' </summary>
		Public Function findUID(ByVal uid As String) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get Genotype object
		''' </summary>
		Public Function getGenotype(ByVal index As Integer) As FrameStick.GlobalContext.Genotype
			' BUG: Implementieren
			Return Nothing
		End Function
	End Class

End Namespace
