Namespace GlobalContext

	''' <summary>
	''' 
	''' </summary>
	''' <remarks></remarks>
	Public Class stats

		''' <summary>
		''' last changed property #
		''' </summary>
		Private mChangedProperty As Integer

		''' <summary>
		''' last changed property id
		''' </summary>
		Private mChangedPropertyId As String

		''' <summary>
		''' Number of genetic operations so far
		''' </summary>
		Private mGen_count As Integer

		''' <summary>
		''' Mutations failed
		''' </summary>
		Private mGen_mfaiiled As Integer

		''' <summary>
		''' Mutations invalid
		''' </summary>
		Private mGen_minvalid As Integer

		''' <summary>
		''' Mutations total effect
		''' </summary>
		Private mGen_mutimpr As Double

		''' <summary>
		''' Mutations valid
		''' </summary>
		Private mGen_mvalid As Integer

		''' <summary>
		''' Mutations valitaded
		''' </summary>
		Private mGen_mvalidated As Integer

		''' <summary>
		''' Crossover failed
		''' </summary>
		Private mGen_xofailed As Integer

		''' <summary>
		''' Crossover total effect
		''' </summary>
		Private mGen_xoimpr As Double

		''' <summary>
		''' Crossover invalid
		''' </summary>
		Private mGen_xoinvalid As Integer

		''' <summary>
		''' Crossover valid
		''' </summary>
		Private mGen_xovalid As Integer

		''' <summary>
		''' Crossovers validated
		''' </summary>
		Private mGen_xovalidated As Integer

		''' <summary>
		''' last changed property #
		''' </summary>
		Public Property changedProperty() As Integer
			Get
				Return Me.mChangedProperty
			End Get

			Set(ByVal value As Integer)
				Me.mChangedProperty = value
			End Set
		End Property

		''' <summary>
		''' last changed property id
		''' </summary>
		Public Property changedPropertyId() As String
			Get
				Return Me.mChangedPropertyId
			End Get

			Set(ByVal value As String)
				Me.mChangedPropertyId = value
			End Set
		End Property

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
				Return Me.mGen_mfaiiled
			End Get

			Set(ByVal value As Integer)
				Me.mGen_mfaiiled = value
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
		''' Crossover invalid
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
		''' Crossover validated
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
		''' Average Velocity
		''' </summary>
		Private mSt_avg_c_velocity As Double

		''' <summary>
		''' Average Vertical position
		''' </summary>
		Private mSt_avg_c_vertpos As Double

		''' <summary>
		''' Average Vertical velocity
		''' </summary>
		Private mSt_avg_c_vertvelocity As Double

		''' <summary>
		''' Average Velocity
		''' </summary>
		Public Property st_avg_c_velocity() As Double
			Get
				Return Me.mSt_avg_c_velocity
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_c_velocity = value
			End Set
		End Property

		''' <summary>
		''' Average Vertical position
		''' </summary>
		Public Property st_avg_c_vertpos() As Double
			Get
				Return Me.mSt_avg_c_vertpos
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_c_vertpos = value
			End Set
		End Property

		''' <summary>
		''' Average Vertical velocity
		''' </summary>
		Public Property st_avg_c_vertvelocity() As Double
			Get
				Return Me.mSt_avg_c_vertvelocity
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_c_vertvelocity = value
			End Set
		End Property

		''' <summary>
		''' Average Distance
		''' </summary>
		Private mSt_avg_distance As Double

		''' <summary>
		''' Average Starting energy
		''' </summary>
		Private mSt_avg_energ0 As Double

		''' <summary>
		''' Average Energy
		''' </summary>
		Private mSt_avg_energy As Double

		''' <summary>
		''' Average Energy balance
		''' </summary>
		Private mSt_avg_energy_b As Double

		''' <summary>
		''' Average Energy costs
		''' </summary>
		Private mSt_avg_energy_m As Double

		''' <summary>
		''' Average Energy income
		''' </summary>
		Private mSt_avg_energy_p As Double

		''' <summary>
		''' Average Fitness
		''' </summary>
		Private mSt_avg_fit As Double

		''' <summary>
		''' Average Final fitness
		''' </summary>
		Private mSt_avg_fit2 As Double

		''' <summary>
		''' Average Generation
		''' </summary>
		Private mSt_avg_gnum As Double

		''' <summary>
		''' Average Idle power consumption
		''' </summary>
		Private mSt_avg_idleen As Double

		''' <summary>
		''' Average Life span
		''' </summary>
		Private mSt_avg_lifespan As Double

		''' <summary>
		''' Average Brain connections
		''' </summary>
		Private mSt_avg_nncon As Double

		''' <summary>
		''' Average Brain size
		''' </summary>
		Private mSt_avg_nnsiz As Double

		''' <summary>
		''' Average Distance
		''' </summary>
		Public Property st_avg_distance() As Double
			Get
				Return Me.mSt_avg_distance
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_distance = value
			End Set
		End Property

		''' <summary>
		''' Average Starting energy
		''' </summary>
		Public Property st_avg_energ0() As Double
			Get
				Return Me.mSt_avg_energ0
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_energ0 = value
			End Set
		End Property

		''' <summary>
		''' Average Energy
		''' </summary>
		Public Property st_avg_energy() As Double
			Get
				Return Me.mSt_avg_energy
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_energy = value
			End Set
		End Property

		''' <summary>
		''' Average Energy balance
		''' </summary>
		Public Property st_avg_energy_b() As Double
			Get
				Return Me.mSt_avg_energy_b
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_energy_b = value
			End Set
		End Property

		''' <summary>
		''' Average Energy costs
		''' </summary>
		Public Property st_avg_energy_m() As Double
			Get
				Return Me.mSt_avg_energy_m
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_energy_m = value
			End Set
		End Property

		''' <summary>
		''' Average Energy income
		''' </summary>
		Public Property st_avg_energy_p() As Double
			Get
				Return Me.mSt_avg_energy_p
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_energy_p = value
			End Set
		End Property

		''' <summary>
		''' Average Fitness
		''' </summary>
		Public Property st_avg_fit() As Double
			Get
				Return Me.mSt_avg_fit
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_fit = value
			End Set
		End Property

		''' <summary>
		''' Average Final fitness
		''' </summary>
		Public Property st_avg_fit2() As Double
			Get
				Return Me.mSt_avg_fit2
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_fit2 = value
			End Set
		End Property

		''' <summary>
		''' Average Generation
		''' </summary>
		Public Property st_avg_gnum() As Double
			Get
				Return Me.mSt_avg_gnum
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_gnum = value
			End Set
		End Property

		''' <summary>
		''' Average Idle power consumption
		''' </summary>
		Public Property st_avg_idleen() As Double
			Get
				Return Me.mSt_avg_idleen
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_idleen = value
			End Set
		End Property

		''' <summary>
		''' Average Life span
		''' </summary>
		Public Property st_avg_lifespan() As Double
			Get
				Return Me.mSt_avg_lifespan
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_lifespan = value
			End Set
		End Property

		''' <summary>
		''' Average Brain connections
		''' </summary>
		Public Property st_avg_nncon() As Double
			Get
				Return Me.mSt_avg_nncon
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_nncon = value
			End Set
		End Property

		''' <summary>
		''' Average Brain size
		''' </summary>
		Public Property st_avg_nnsiz() As Double
			Get
				Return Me.mSt_avg_nnsiz
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_nnsiz = value
			End Set
		End Property

		''' <summary>
		''' Average Ordinal number
		''' </summary>
		Private mSt_avg_num As Double

		''' <summary>
		''' Average number of joints
		''' </summary>
		Private mSt_avg_numjoints As Double

		''' <summary>
		''' Average number of neurons
		''' </summary>
		Private mSt_avg_numneurons As Double

		''' <summary>
		''' Average number of parts
		''' </summary>
		Private mSt_avg_numparts As Double

		''' <summary>
		''' Average Instances
		''' </summary>
		Private mSt_avg_popsiz As Double

		''' <summary>
		''' Average Body joints
		''' </summary>
		Private mSt_avg_strjoints As Double

		''' <summary>
		''' Average Ordinal number
		''' </summary>
		Public Property st_avg_num() As Double
			Get
				Return Me.mSt_avg_num
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_num = value
			End Set
		End Property

		''' <summary>
		''' Average number of joints
		''' </summary>
		Public Property st_avg_numjoints() As Double
			Get
				Return Me.mSt_avg_numjoints
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_numjoints = value
			End Set
		End Property

		''' <summary>
		''' Average number of neurons
		''' </summary>
		Public Property st_avg_numneurons() As Double
			Get
				Return Me.mSt_avg_numneurons
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_numneurons = value
			End Set
		End Property

		''' <summary>
		''' Average number of parts
		''' </summary>
		Public Property st_avg_numparts() As Double
			Get
				Return Me.mSt_avg_numparts
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_numparts = value
			End Set
		End Property

		''' <summary>
		''' Average Instances
		''' </summary>
		Public Property st_avg_popsiz() As Double
			Get
				Return Me.mSt_avg_popsiz
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_popsiz = value
			End Set
		End Property

		''' <summary>
		''' Average Body joints
		''' </summary>
		Public Property st_avg_strjoints() As Double
			Get
				Return Me.mSt_avg_strjoints
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_strjoints = value
			End Set
		End Property

		''' <summary>
		''' Average Body parts
		''' </summary>
		Private mSt_avg_strsiz As Double

		''' <summary>
		''' Average Velocity
		''' </summary>
		Private mSt_avg_velocity As Double

		''' <summary>
		''' Average Vertical position
		''' </summary>
		Private mSt_avg_vertpos As Double

		''' <summary>
		''' Avergae Vertical velocity
		''' </summary>
		Private mSt_avg_vertvel As Double

		''' <summary>
		''' Average Body parts
		''' </summary>
		Public Property st_avg_strsiz() As Double
			Get
				Return Me.mSt_avg_strsiz
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_strsiz = value
			End Set
		End Property

		''' <summary>
		''' Average Velocity
		''' </summary>
		Public Property st_avg_velocity() As Double
			Get
				Return Me.mSt_avg_velocity
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_velocity = value
			End Set
		End Property

		''' <summary>
		''' Averge Vertical position
		''' </summary>
		Public Property st_avg_vertpos() As Double
			Get
				Return Me.mSt_avg_vertpos
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_vertpos = value
			End Set
		End Property

		''' <summary>
		''' Aberage Vertical velocity
		''' </summary>
		Public Property st_avg_vertvel() As Double
			Get
				Return Me.mSt_avg_vertvel
			End Get

			Set(ByVal value As Double)
				Me.mSt_avg_vertvel = value
			End Set
		End Property

		''' <summary>
		''' Count
		''' </summary>
		Private mSt_count As Integer

		''' <summary>
		''' Maximal Velocity
		''' </summary>
		Private mSt_max_c_velocity As Double

		''' <summary>
		''' Maximal Vertical position
		''' </summary>
		Private mSt_max_c_vertpos As Double

		''' <summary>
		''' Maximal Vertical velocity
		''' </summary>
		Private mSt_max_c_vertvelocity As Double

		''' <summary>
		''' Maximal Distance
		''' </summary>
		Private mSt_max_distance As Double

		''' <summary>
		''' Maximal Starting Energy
		''' </summary>
		Private mSt_max_energ0 As Double

		''' <summary>
		''' Maximal Energy
		''' </summary>
		Private mSt_max_energy As Double

		''' <summary>
		''' Maximal Energy balance
		''' </summary>
		Private mSt_max_energy_b As Double

		''' <summary>
		''' Maximal Energy costs
		''' </summary>
		Private mSt_max_energy_m As Double

		''' <summary>
		''' Maximal Energy income
		''' </summary>
		Private mSt_max_energy_p As Double

		''' <summary>
		''' Maximal Fitness
		''' </summary>
		Private mSt_max_fit As Double

		''' <summary>
		''' Maximal Final fitness
		''' </summary>
		Private mSt_max_fit2 As Double

		''' <summary>
		''' Maximal Generation
		''' </summary>
		Private mSt_max_gnum As Double

		''' <summary>
		''' Count
		''' </summary>
		Public Property st_count() As Integer
			Get
				Return Me.mSt_count
			End Get

			Set(ByVal value As Integer)
				Me.mSt_count = value
			End Set
		End Property

		''' <summary>
		''' Maximal Velocity
		''' </summary>
		Public Property st_max_c_velocity() As Double
			Get
				Return Me.mSt_max_c_velocity
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_c_velocity = value
			End Set
		End Property

		''' <summary>
		''' Maximal Vertical position
		''' </summary>
		Public Property st_max_c_vertpos() As Double
			Get
				Return Me.mSt_max_c_vertpos
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_c_vertpos = value
			End Set
		End Property

		''' <summary>
		''' Maximal Vertical velocity
		''' </summary>
		Public Property st_max_c_vertvelocity() As Double
			Get
				Return Me.mSt_max_c_vertvelocity
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_c_vertvelocity = value
			End Set
		End Property

		''' <summary>
		''' Maximal Distance
		''' </summary>
		Public Property st_max_distance() As Double
			Get
				Return Me.mSt_max_distance
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_distance = value
			End Set
		End Property

		''' <summary>
		''' Maximal Starting Energy
		''' </summary>
		Public Property st_max_energ0() As Double
			Get
				Return Me.mSt_max_energ0
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_energ0 = value
			End Set
		End Property

		''' <summary>
		''' Maximal Energy
		''' </summary>
		Public Property st_max_energy() As Double
			Get
				Return Me.mSt_max_energy
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_energy = value
			End Set
		End Property

		''' <summary>
		''' Maximal Energy balance
		''' </summary>
		Public Property st_max_energy_b() As Double
			Get
				Return Me.mSt_max_energy_b
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_energy_b = value
			End Set
		End Property

		''' <summary>
		''' Maximal Energy costs
		''' </summary>
		Public Property st_max_energy_m() As Double
			Get
				Return Me.mSt_max_energy_m
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_energy_m = value
			End Set
		End Property

		''' <summary>
		''' Maximal Energy income
		''' </summary>
		Public Property st_max_energy_p() As Double
			Get
				Return Me.mSt_max_energy_p
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_energy_p = value
			End Set
		End Property

		''' <summary>
		''' Maximal Fitness
		''' </summary>
		Public Property st_max_fit() As Double
			Get
				Return Me.mSt_max_fit
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_fit = value
			End Set
		End Property

		''' <summary>
		''' Maximal Final fitness
		''' </summary>
		Public Property st_max_fit2() As Double
			Get
				Return Me.mSt_max_fit2
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_fit2 = value
			End Set
		End Property

		''' <summary>
		''' Maximal Generation
		''' </summary>
		Public Property st_max_gnum() As Double
			Get
				Return Me.mSt_max_gnum
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_gnum = value
			End Set
		End Property

		''' <summary>
		''' Maximal Idle power consumption
		''' </summary>
		Private mSt_max_idleen As Double

		''' <summary>
		''' Maimal Life span
		''' </summary>
		Private mSt_max_lifespan As Double

		''' <summary>
		''' Maximal Idle power consumption
		''' </summary>
		Public Property st_max_idleen() As Double
			Get
				Return Me.mSt_max_idleen
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_idleen = value
			End Set
		End Property

		''' <summary>
		''' Maximal Life span
		''' </summary>
		Public Property st_max_lifespan() As Double
			Get
				Return Me.mSt_max_lifespan
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_lifespan = value
			End Set
		End Property

		''' <summary>
		''' Maximal Brain connection
		''' </summary>
		Private mSt_max_nncon As Double

		''' <summary>
		''' Maximal Brain size
		''' </summary>
		Private mSt_max_nnsiz As Double

		''' <summary>
		''' Maximal Ordinal number
		''' </summary>
		Private mSt_max_num As Double

		''' <summary>
		''' Maximal number of joints
		''' </summary>
		Private mSt_max_numjoints As Double

		''' <summary>
		''' Maximal number of neurons
		''' </summary>
		Private mSt_max_numneurons As Double

		''' <summary>
		''' Maximal number of parts
		''' </summary>
		Private mSt_max_numparts As Double

		''' <summary>
		''' Maximal Instance
		''' </summary>
		Private mSt_max_popsiz As Double

		''' <summary>
		''' Maximal Body joints
		''' </summary>
		Private mSt_max_strjoints As Double

		''' <summary>
		''' Maximal Body parts
		''' </summary>
		Private mSt_max_strsiz As Double

		''' <summary>
		''' Maximal Velocity
		''' </summary>
		Private mSt_max_velocity As Double

		''' <summary>
		''' Maximal Brain connections
		''' </summary>
		Public Property st_max_nncon() As Double
			Get
				Return Me.mSt_max_nncon
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_nncon = value
			End Set
		End Property

		''' <summary>
		''' Maximal Brain size
		''' </summary>
		Public Property st_max_nnsiz() As Double
			Get
				Return Me.mSt_max_nnsiz
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_nnsiz = value
			End Set
		End Property

		''' <summary>
		''' Maximal Ordinal number
		''' </summary>
		Public Property st_max_num() As Double
			Get
				Return Me.mSt_max_num
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_num = value
			End Set
		End Property

		''' <summary>
		''' Maximal number of joints
		''' </summary>
		Public Property st_max_numjoints() As Double
			Get
				Return Me.mSt_max_numjoints
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_numjoints = value
			End Set
		End Property

		''' <summary>
		''' Maximal number of neurons
		''' </summary>
		Public Property st_max_numneurons() As Double
			Get
				Return Me.mSt_max_numneurons
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_numneurons = value
			End Set
		End Property

		''' <summary>
		''' Maximal number of parts
		''' </summary>
		Public Property st_max_numparts() As Double
			Get
				Return Me.mSt_max_numparts
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_numparts = value
			End Set
		End Property

		''' <summary>
		''' Maximal Instances
		''' </summary>
		Public Property st_max_popsiz() As Double
			Get
				Return Me.mSt_max_popsiz
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_popsiz = value
			End Set
		End Property

		''' <summary>
		''' Maximal Body joints
		''' </summary>
		Public Property st_max_strjoints() As Double
			Get
				Return Me.mSt_max_strjoints
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_strjoints = value
			End Set
		End Property

		''' <summary>
		''' Maximal Body parts
		''' </summary>
		Public Property st_max_strsiz() As Double
			Get
				Return Me.mSt_max_strsiz
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_strsiz = value
			End Set
		End Property

		''' <summary>
		''' Maximal Velocity
		''' </summary>
		Public Property st_max_velocity() As Double
			Get
				Return Me.mSt_max_velocity
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_velocity = value
			End Set
		End Property

		''' <summary>
		''' Maximal Vertical position
		''' </summary>
		Private mSt_max_vertpos As Double

		''' <summary>
		''' Maximal Vertical Velocity
		''' </summary>
		Private mSt_max_vertvel As Double

		''' <summary>
		''' Minimal Velocity
		''' </summary>
		Private mSt_min_c_velocity As Double

		''' <summary>
		''' Minimal Vertical position
		''' </summary>
		Private mSt_min_c_vertpos As Double

		''' <summary>
		''' Minimal Vertical Velocity
		''' </summary>
		Private mSt_min_c_vertvelocity As Double

		''' <summary>
		''' Minimal Distance
		''' </summary>
		Private mSt_min_distance As Double

		''' <summary>
		''' Minimal Starting Energy
		''' </summary>
		Private mSt_min_energ0 As Double

		''' <summary>
		''' Minimal Energy
		''' </summary>
		Private mSt_min_energy As Double

		''' <summary>
		''' Minimal Energy balance
		''' </summary>
		Private mSt_min_energy_b As Double

		''' <summary>
		''' Maximal Vertical position
		''' </summary>
		Public Property st_max_vertpos() As Double
			Get
				Return Me.mSt_max_vertpos
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_vertpos = value
			End Set
		End Property

		''' <summary>
		''' Maximal Vertical velocity
		''' </summary>
		Public Property st_max_vertvel() As Double
			Get
				Return Me.mSt_max_vertvel
			End Get

			Set(ByVal value As Double)
				Me.mSt_max_vertvel = value
			End Set
		End Property

		''' <summary>
		''' Minimal Velocity
		''' </summary>
		Public Property st_min_c_velocity() As Double
			Get
				Return Me.mSt_min_c_velocity
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_c_velocity = value
			End Set
		End Property

		''' <summary>
		''' Minimal Vertical Position
		''' </summary>
		Public Property st_min_c_vertpos() As Double
			Get
				Return Me.mSt_min_c_vertpos
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_c_vertpos = value
			End Set
		End Property

		''' <summary>
		''' Minimal Vertical velocity
		''' </summary>
		Public Property st_min_c_vertvelocity() As Double
			Get
				Return Me.mSt_min_c_vertvelocity
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_c_vertvelocity = value
			End Set
		End Property

		''' <summary>
		''' Minimal Distance
		''' </summary>
		Public Property st_min_distance() As Double
			Get
				Return Me.mSt_min_distance
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_distance = value
			End Set
		End Property

		''' <summary>
		''' Minimal Starting Energy
		''' </summary>
		Public Property st_min_energ0() As Double
			Get
				Return Me.mSt_min_energ0
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_energ0 = value
			End Set
		End Property

		''' <summary>
		''' Minimal Energy
		''' </summary>
		Public Property st_min_energy() As Double
			Get
				Return Me.mSt_min_energy
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_energy = value
			End Set
		End Property

		''' <summary>
		''' Minimal Energy balance
		''' </summary>
		Public Property st_min_energy_b() As Double
			Get
				Return Me.mSt_min_energy_b
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_energy_b = value
			End Set
		End Property

		''' <summary>
		''' Minimal Energy costs
		''' </summary>
		Private mSt_min_energy_m As Double

		''' <summary>
		''' Minimal Energy income
		''' </summary>
		Private mSt_min_energy_p As Double

		''' <summary>
		''' Minimal Fitness
		''' </summary>
		Private mSt_min_fit As Double

		''' <summary>
		''' Minimal Final fitness
		''' </summary>
		Private mSt_min_fit2 As Double

		''' <summary>
		''' Minimal Generation
		''' </summary>
		Private mSt_min_gnum As Double

		''' <summary>
		''' Minimal Idle power consumption
		''' </summary>
		Private mSt_min_idleen As Double

		''' <summary>
		''' Minimal Life span
		''' </summary>
		Private mSt_min_lifespan As Double

		''' <summary>
		''' Minimal Brain connections
		''' </summary>
		Private mSt_min_nncon As Double

		''' <summary>
		''' Minimal Energy costs
		''' </summary>
		Public Property st_min_energy_m() As Double
			Get
				Return Me.mSt_min_energy_m
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_energy_m = value
			End Set
		End Property

		''' <summary>
		''' Minimal Energy income
		''' </summary>
		Public Property st_min_energy_p() As Double
			Get
				Return Me.mSt_min_energy_p
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_energy_p = value
			End Set
		End Property

		''' <summary>
		''' Minimal Fitness
		''' </summary>
		Public Property st_min_fit() As Double
			Get
				Return Me.mSt_min_fit
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_fit = value
			End Set
		End Property

		''' <summary>
		''' Minimal Final fitness
		''' </summary>
		Public Property st_min_fit2() As Double
			Get
				Return Me.mSt_min_fit2
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_fit2 = value
			End Set
		End Property

		''' <summary>
		''' Minimal Generation
		''' </summary>
		Public Property st_min_gnum() As Double
			Get
				Return Me.mSt_min_gnum
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_gnum = value
			End Set
		End Property

		''' <summary>
		''' Minimal Idle power consumption
		''' </summary>
		Public Property st_min_idleen() As Double
			Get
				Return Me.mSt_min_idleen
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_idleen = value
			End Set
		End Property

		''' <summary>
		''' Minimal Life span
		''' </summary>
		Public Property st_min_lifespan() As Double
			Get
				Return Me.mSt_min_lifespan
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_lifespan = value
			End Set
		End Property

		''' <summary>
		''' Minimal Brain connections
		''' </summary>
		Public Property st_min_nncon() As Double
			Get
				Return Me.mSt_min_nncon
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_nncon = value
			End Set
		End Property

		''' <summary>
		''' Minimal Brain size
		''' </summary>
		Private mSt_min_nnsiz As Double

		''' <summary>
		''' Minimal Ordinal number
		''' </summary>
		Private mSt_min_num As Double

		''' <summary>
		''' Minimal number of joints
		''' </summary>
		Private mSt_min_numjoints As Double

		''' <summary>
		''' Minimal number of neurons
		''' </summary>
		Private mSt_min_numneurons As Double

		''' <summary>
		''' Minimal number of parts
		''' </summary>
		Private mSt_min_numparts As Double

		''' <summary>
		''' Minimal Instances
		''' </summary>
		Private mSt_min_popsiz As Double

		''' <summary>
		''' Minimal Body joints
		''' </summary>
		Private mSt_min_strjoints As Double

		''' <summary>
		''' Minimal Body parts
		''' </summary>
		Private mSt_min_strsiz As Double

		''' <summary>
		''' Minimal Velocity
		''' </summary>
		Private mSt_min_velocity As Double

		''' <summary>
		''' Minimal Vertical position
		''' </summary>
		Private mSt_min_vertpos As Double

		''' <summary>
		''' Minimal Brain size
		''' </summary>
		Public Property st_min_nnsiz() As Double
			Get
				Return Me.mSt_min_nnsiz
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_nnsiz = value
			End Set
		End Property

		''' <summary>
		''' Minimal Ordinal number
		''' </summary>
		Public Property st_min_num() As Double
			Get
				Return Me.mSt_min_num
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_num = value
			End Set
		End Property

		''' <summary>
		''' Minimal number of joints
		''' </summary>
		Public Property st_min_numjoints() As Double
			Get
				Return Me.mSt_min_numjoints
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_numjoints = value
			End Set
		End Property

		''' <summary>
		''' Minimal number of neurons
		''' </summary>
		Public Property st_min_numneurons() As Double
			Get
				Return Me.mSt_min_numneurons
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_numneurons = value
			End Set
		End Property

		''' <summary>
		''' Minimal number of parts
		''' </summary>
		Public Property st_min_numparts() As Double
			Get
				Return Me.mSt_min_numparts
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_numparts = value
			End Set
		End Property

		''' <summary>
		''' Minimal Instances
		''' </summary>
		Public Property st_min_popsiz() As Double
			Get
				Return Me.mSt_min_popsiz
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_popsiz = value
			End Set
		End Property

		''' <summary>
		''' Minimal Body joints
		''' </summary>
		Public Property st_min_strjoints() As Double
			Get
				Return Me.mSt_min_strjoints
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_strjoints = value
			End Set
		End Property

		''' <summary>
		''' Minimal Body parts
		''' </summary>
		Public Property st_min_strsiz() As Double
			Get
				Return Me.mSt_min_strsiz
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_strsiz = value
			End Set
		End Property

		''' <summary>
		''' Minimal Velocity
		''' </summary>
		Public Property st_min_velocity() As Double
			Get
				Return Me.mSt_min_velocity
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_velocity = value
			End Set
		End Property

		''' <summary>
		''' Minimal Vertical position
		''' </summary>
		Public Property st_min_vertpos() As Double
			Get
				Return Me.mSt_min_vertpos
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_vertpos = value
			End Set
		End Property

		''' <summary>
		''' Minimal Vertical velocity
		''' </summary>
		Private mSt_min_vertvel As Double

		''' <summary>
		''' Minimal Vertical velocity
		''' </summary>
		Public Property st_min_vertvel() As Double
			Get
				Return Me.mSt_min_vertvel
			End Get

			Set(ByVal value As Double)
				Me.mSt_min_vertvel = value
			End Set
		End Property

		''' <summary>
		''' add Property
		''' </summary>
		Public Sub add(ByVal id As String, ByVal type As String, ByVal name As String, ByVal help As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' add group
		''' </summary>
		Public Sub addGroup(ByVal name As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' remove all properties
		''' </summary>
		Public Sub clear()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' Clear stats and history
		''' </summary>
		Public Sub clrstats()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' remove property
		''' </summary>
		Public Sub remove(ByVal index As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' remove group
		''' </summary>
		Public Sub removeGroup(ByVal index As Integer)
			' BUG: Implementieren
		End Sub
	End Class

End Namespace
