Namespace GlobalContext

	''' <summary>
	''' Statistics for genetic operations.
	''' </summary>
	Public Class GenManStats

		''' <summary>
		''' Number of genetic operations so far
		''' </summary>
		Private mGen_count As Integer

		''' <summary>
		''' Mutations failed
		''' </summary>
		Private mGen_mfailed As Integer

		''' <summary>
		''' Mutations invalid
		''' </summary>
		Private mGen_minvalid As Integer

		''' <summary>
		''' Mutations total effect
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mGen_mutimpr As Double

		''' <summary>
		''' Mutations valid
		''' </summary>
		Private mGen_mvalid As Integer

		''' <summary>
		''' Mutations validated
		''' </summary>
		Private mGen_mvalidated As Integer

		''' <summary>
		''' Crossovers failed
		''' </summary>
		Private mGen_xofailed As Integer

		''' <summary>
		''' Crossovers total effect
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mGen_xoimpr As Double

		''' <summary>
		''' Crossovers invalid
		''' </summary>
		Private mGen_xoinvalid As Integer

		''' <summary>
		''' Crossovers valid
		''' </summary>
		Private mGen_xovalid As Integer

		''' <summary>
		''' Crossovers valitated
		''' </summary>
		Private mGen_xovalidated As Integer

		''' <summary>
		''' Number of genetic operations so far
		''' </summary>
		Public Property gen_count() As Integer
			Get
				Return Me.mGen_count
			End Get

			Set(ByVal value As Integer)
				Me.mGen_count = value
			End Set
		End Property

		''' <summary>
		''' Mutations failed
		''' </summary>
		Public Property gen_mfailed() As Integer
			Get
				Return Me.mGen_mfailed
			End Get

			Set(ByVal value As Integer)
				Me.mGen_mfailed = value
			End Set
		End Property

		''' <summary>
		''' Mutations invalid
		''' </summary>
		Public Property gen_minvalid() As Integer
			Get
				Return Me.mGen_minvalid
			End Get

			Set(ByVal value As Integer)
				Me.mGen_minvalid = value
			End Set
		End Property

		''' <summary>
		''' Mutations total effect
		''' </summary>
		Public Property gen_mutimpr() As Double
			Get
				Return Me.mGen_mutimpr
			End Get

			Set(ByVal value As Double)
				Me.mGen_mutimpr = value
			End Set
		End Property

		''' <summary>
		''' Mutations valid
		''' </summary>
		Public Property gen_mvalid() As Integer
			Get
				Return Me.mGen_mvalid
			End Get

			Set(ByVal value As Integer)
				Me.mGen_mvalid = value
			End Set
		End Property

		''' <summary>
		''' Mutations validated
		''' </summary>
		Public Property gen_mvalidated() As Integer
			Get
				Return Me.mGen_mvalidated
			End Get

			Set(ByVal value As Integer)
				Me.mGen_mvalidated = value
			End Set
		End Property

		''' <summary>
		''' Crossover failed
		''' </summary>
		Public Property gen_xofailed() As Integer
			Get
				Return Me.mGen_xofailed
			End Get

			Set(ByVal value As Integer)
				Me.mGen_xofailed = value
			End Set
		End Property

		''' <summary>
		''' Crossover total effect
		''' </summary>
		Public Property gen_xoimpr() As Double
			Get
				Return Me.mGen_xoimpr
			End Get

			Set(ByVal value As Double)
				Me.mGen_xoimpr = value
			End Set
		End Property

		''' <summary>
		''' Crossovers invalid
		''' </summary>
		Public Property gen_xoinvalid() As Integer
			Get
				Return Me.mGen_xoinvalid
			End Get

			Set(ByVal value As Integer)
				Me.mGen_xoinvalid = value
			End Set
		End Property

		''' <summary>
		''' Crossover valid
		''' </summary>
		Public Property gen_xovalid() As Integer
			Get
				Return Me.mGen_xovalid
			End Get

			Set(ByVal value As Integer)
				Me.mGen_xovalid = value
			End Set
		End Property

		''' <summary>
		''' Crossovers validated
		''' </summary>
		Public Property gen_xovalidated() As Integer
			Get
				Return Me.mGen_xovalidated
			End Get

			Set(ByVal value As Integer)
				Me.mGen_xovalidated = value
			End Set
		End Property

		''' <summary>
		''' Clear stats and history
		''' </summary>
		Public Sub clrstats()
			' BUG: Implementieren
		End Sub
	End Class

End Namespace
