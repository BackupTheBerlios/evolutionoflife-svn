Namespace GlobalContext

	Public Class sim_params

		''' <summary>
		''' Aging time
		''' </summary>
		''' <remarks> 0 bis 100000</remarks>
		Private mAging As Integer

		''' <summary>
		''' Save backup
		''' </summary>
		''' <remarks>0 bis 100000</remarks>
		Private mAutosaveperiod As Integer

		''' <summary>
		''' Gene pool capacity
		''' </summary>
		''' <remarks>0 bis 2000</remarks>
		Private mCapacity As Integer

		''' <summary>
		''' last changed property #
		''' </summary>
		Private mChangedProperty As Integer

		''' <summary>
		''' last changed property id
		''' </summary>
		Private mChangedPropertyId As String

		''' <summary>
		''' Constant
		''' </summary>
		''' <remarks>-10000 bis 100000</remarks>
		Private mCr_c As Double

		''' <summary>
		''' Distance
		''' </summary>
		''' <remarks>-10000 bis 10000</remarks>
		Private mCr_di As Double

		''' <summary>
		''' Body parts
		''' </summary>
		''' <remarks>-10000 bis 10000</remarks>
		Private mCr_gl As Double

		''' <summary>
		''' Aging time
		''' </summary>
		''' <value>0 bis 100000</value>
		Public Property aging() As Integer
			Get
				Return Me.mAging
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 100000 Then
					Me.mAging = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Save backup
		''' </summary>
		''' <value>0 bis 100000</value>
		Public Property autosaveperiod() As Integer
			Get
				Return Me.mAutosaveperiod
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 100000 Then
					Me.mAutosaveperiod = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Gene pool capacity
		''' </summary>
		''' <remarks>Wraum nur 2000 ??</remarks>
		''' <value>0 bis 2000</value>
		Public Property capacity() As Integer
			Get
				Return Me.mCapacity
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 2000 Then
					Me.mCapacity = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2000 liegen.")
				End If
			End Set
		End Property

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
		''' Constant
		''' </summary>
		''' <value>-10000 bis 10000</value>
		Public Property cr_c() As Double
			Get
				Return Me.mCr_c
			End Get

			Set(ByVal value As Double)
				If value >= -10000 And value <= 10000 Then
					Me.mCr_c = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -10000 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Distance
		''' </summary>
		''' <value>-10000 bis 10000</value>
		Public Property cr_di() As Double
			Get
				Return Me.mCr_di
			End Get

			Set(ByVal value As Double)
				If value >= -10000 And value <= 10000 Then
					Me.mCr_di = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -10000 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Body parts
		''' </summary>
		''' <value>-10000 bis 10000</value>
		Public Property cr_gl() As Double
			Get
				Return Me.mCr_gl
			End Get

			Set(ByVal value As Double)
				If value >= -10000 And value <= 10000 Then
					Me.mCr_gl = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -10000 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Body joints
		''' </summary>
		''' <remarks>-10000 bis 10000</remarks>
		Private mCr_joints As Double

		''' <summary>
		''' Life span
		''' </summary>
		''' <remarks>-10000 bis 10000</remarks>
		Private mCr_life As Double

		''' <summary>
		''' Brain connections
		''' </summary>
		''' <remarks>-10000 bis 10000</remarks>
		Private mCr_nncon As Double

		''' <summary>
		''' Brain neurons
		''' </summary>
		''' <remarks>-10000 bis 10000</remarks>
		Private mCr_nnsiz As Double

		''' <summary>
		''' Criteria normalization
		''' </summary>
		Private mCr_norm As Boolean

		''' <summary>
		''' Similarity speciation
		''' </summary>
		Private mCr_simi As Boolean

		''' <summary>
		''' Body joints
		''' </summary>
		''' <value>-10000 bis 10000</value>
		Public Property cr_joints() As Double
			Get
				Return Me.mCr_joints
			End Get

			Set(ByVal value As Double)
				If value >= -10000 And value <= 10000 Then
					Me.mCr_joints = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -10000 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Life span
		''' </summary>
		''' <value>-10000 bis 10000</value>
		Public Property cr_life() As Double
			Get
				Return Me.mCr_life
			End Get

			Set(ByVal value As Double)
				If value >= -10000 And value <= 10000 Then
					Me.mCr_life = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -10000 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Brain connections
		''' </summary>
		''' <value>-10000 bis 10000</value>
		Public Property cr_nncon() As Double
			Get
				Return Me.mCr_nncon
			End Get

			Set(ByVal value As Double)
				If value >= -10000 And value <= 10000 Then
					Me.mCr_nncon = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -10000 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Brain neurons
		''' </summary>
		''' <value>-10000 bis 10000</value>
		Public Property cr_nnsiz() As Double
			Get
				Return Me.mCr_nnsiz
			End Get

			Set(ByVal value As Double)
				If value >= -10000 And value <= 10000 Then
					Me.mCr_nnsiz = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -10000 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Criteria normalization
		''' </summary>
		Public Property cr_norm() As Boolean
			Get
				Return Me.mCr_norm
			End Get

			Set(ByVal value As Boolean)
				Me.mCr_norm = value
			End Set
		End Property

		''' <summary>
		''' Similarity speciation
		''' </summary>
		Public Property cr_simi() As Boolean
			Get
				Return Me.mCr_simi
			End Get

			Set(ByVal value As Boolean)
				Me.mCr_simi = value
			End Set
		End Property

		''' <summary>
		''' Velocity
		''' </summary>
		''' <remarks>-10000 bis 10000</remarks>
		Private mCr_v As Double

		''' <summary>
		''' Vertical position
		''' </summary>
		''' <remarks>-10000 bis 10000</remarks>
		Private mCr_vpos As Double

		''' <summary>
		''' Vertical velocity
		''' </summary>
		''' <remarks>-10000 bis 10000</remarks>
		Private mCr_vvel As Double

		''' <summary>
		''' Object creation errors
		''' </summary>
		''' <remarks>0 bis 2
		''' 
		''' 0 = Ignore
		''' 1 = Show summary
		''' 2 = Show details</remarks>
		Private mCreaterr As Integer

		''' <summary>
		''' Creation height
		''' </summary>
		''' <remarks>-1 bis 50</remarks>
		Private mCreath As Double

		''' <summary>
		''' creaturesgrouploaded
		''' </summary>
		Private mCrearuresgrouploaded As Integer

		''' <summary>
		''' Delete genotypes
		''' </summary>
		''' <remarks>0 bis 2
		''' 
		''' 0 = Randomly
		''' 1 = Inverse-proportionally to fitness
		''' 2 = Only the worst</remarks>
		Private mDelrule As Integer

		''' <summary>
		''' Velovcity
		''' </summary>
		''' <value>-10000 bis 10000</value>
		Public Property cr_v() As Double
			Get
				Return Me.mCr_v
			End Get

			Set(ByVal value As Double)
				If value >= -10000 And value <= 10000 Then
					Me.mCr_v = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -10000 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Vertical position
		''' </summary>
		''' <value>-10000 bis 10000</value>
		Public Property cr_vpos() As Double
			Get
				Return Me.mCr_vpos
			End Get

			Set(ByVal value As Double)
				If value >= -10000 And value <= 10000 Then
					Me.mCr_vpos = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -10000 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Vertical velocity
		''' </summary>
		''' <value>-10000 bis 10000</value>
		Public Property cr_vvel() As Double
			Get
				Return Me.mCr_vvel
			End Get

			Set(ByVal value As Double)
				If value >= -10000 And value <= 10000 Then
					Me.mCr_vvel = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -10000 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Object creation erros
		''' </summary>
		''' <value>0 bis 2
		''' 
		''' 0 = Ignore
		''' 1 = Show summary
		''' 2 = Show details</value>
		Public Property createrr() As Integer
			Get
				Return Me.mCreaterr
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 2 Then
					Me.mCreaterr = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Creation height
		''' </summary>
		''' <value>-1 bis 50</value>
		Public Property creath() As Double
			Get
				Return Me.mCreath
			End Get

			Set(ByVal value As Double)
				If value >= -1 And value <= 50 Then
					Me.mCreath = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -1 und 50 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' creatuesgrouploaded
		''' </summary>
		Public Property creaturesgrouploaded() As Integer
			Get
				Return Me.mCrearuresgrouploaded
			End Get

			Set(ByVal value As Integer)
				Me.mCrearuresgrouploaded = value
			End Set
		End Property

		''' <summary>
		''' Delete genotypes
		''' </summary>
		''' <value>0 bis 2
		''' 
		''' 0 = Randomly
		''' 1 = Inverse-proportionally to fitness
		''' 2 = Only the worst</value>
		Public Property delrule() As Integer
			Get
				Return Me.mDelrule
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 2 Then
					Me.mDelrule = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Idle metabolism
		''' </summary>
		''' <remarks>0 bis 1</remarks>
		Private mE_meta As Double

		''' <summary>
		''' Starting energy
		''' </summary>
		''' <remarks>0 bis 10000</remarks>
		Private mEnergy0 As Double

		''' <summary>
		''' Experiment definition
		''' </summary>
		Private mExpdef As String

		''' <summary>
		''' Description
		''' </summary>
		Private mExpdef_info As String

		''' <summary>
		''' Title
		''' </summary>
		Private mExpdef_title As String

		''' <summary>
		''' Delete
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_c_del As Double

		''' <summary>
		''' New connection
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_c_new As Double

		''' <summary>
		''' Idle metabolism
		''' </summary>
		''' <value>0 bis 1</value>
		Public Property e_meta() As Double
			Get
				Return Me.mE_meta
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 1 Then
					Me.mE_meta = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Starting energy
		''' </summary>
		''' <value>0 bis 10000</value>
		Public Property Energy0() As Double
			Get
				Return Me.mEnergy0
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 10000 Then
					Me.mEnergy0 = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 10000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Experiment definition
		''' </summary>
		Public Property expdef() As String
			Get
				Return Me.mExpdef
			End Get

			Set(ByVal value As String)
				Me.mExpdef = value
			End Set
		End Property

		''' <summary>
		''' Description
		''' </summary>
		Public Property expdef_info() As String
			Get
				Return Me.mExpdef_info
			End Get

			Set(ByVal value As String)
				Me.mExpdef_info = value
			End Set
		End Property

		''' <summary>
		''' Title
		''' </summary>
		Public Property expdef_title() As String
			Get
				Return Me.mExpdef_title
			End Get

			Set(ByVal value As String)
				Me.mExpdef_title = value
			End Set
		End Property

		''' <summary>
		''' Delete
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_c_del() As Double
			Get
				Return Me.mF0_c_del
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_c_del = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' New connection
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_c_new() As Double
			Get
				Return Me.mF0_c_new
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_c_new = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Change weight
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_c_wei As Double

		''' <summary>
		''' Delete
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_j_del As Double

		''' <summary>
		''' New joint
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_j_new As Double

		''' <summary>
		''' Rotstif
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_j_rsf As Double

		''' <summary>
		''' Stif
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_j_stf As Double

		''' <summary>
		''' Stamina
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_j_stm As Double

		''' <summary>
		''' Delete
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_n_del As Double

		''' <summary>
		''' New neuron
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_n_new As Double

		''' <summary>
		''' Change properties
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_n_prp As Double

		''' <summary>
		''' Assimilation
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_p_asm As Double

		''' <summary>
		''' Change weight
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_c_wei() As Double
			Get
				Return Me.mF0_c_wei
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_c_wei = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Delete
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_j_del() As Double
			Get
				Return Me.mF0_j_del
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_j_del = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' New joint
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_j_new() As Double
			Get
				Return Me.mF0_j_new
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_j_new = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Rotstif
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_j_rsf() As Double
			Get
				Return Me.mF0_j_rsf
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_j_rsf = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Stif
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_j_stf() As Double
			Get
				Return Me.mF0_j_stf
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_j_stf = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Stamina
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_j_stm() As Double
			Get
				Return Me.mF0_j_stm
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_j_stm = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Delete
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_n_del() As Double
			Get
				Return Me.mF0_n_del
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_n_del = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' New neuron
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_n_new() As Double
			Get
				Return Me.mF0_n_new
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_n_new = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Change properties
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_n_prp() As Double
			Get
				Return Me.mF0_n_prp
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_n_prp = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Assimilation
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_p_asm() As Double
			Get
				Return Me.mF0_p_asm
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_asm = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Delete
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_p_del As Double

		''' <summary>
		''' Friction
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_p_frc As Double

		''' <summary>
		''' Ingest
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_p_ing As Double

		''' <summary>
		''' Mass
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_p_mas As Double

		''' <summary>
		''' New part
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_p_new As Double

		''' <summary>
		''' Position
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_p_pos As Double

		''' <summary>
		''' Swap parts
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF0_p_swp As Double

		''' <summary>
		''' Excluded modifiers
		''' </summary>
		Private mF1_mut_exmod As String

		''' <summary>
		''' Delete
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_p_del() As Double
			Get
				Return Me.mF0_p_del
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_del = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Friction
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_p_frc() As Double
			Get
				Return Me.mF0_p_frc
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_frc = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Ingest
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_p_ing() As Double
			Get
				Return Me.mF0_p_ing
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_ing = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Mass
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_p_mas() As Double
			Get
				Return Me.mF0_p_mas
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_mas = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' New part
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_p_new() As Double
			Get
				Return Me.mF0_p_new
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_new = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Position
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_p_pos() As Double
			Get
				Return Me.mF0_p_pos
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_pos = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Swap parts
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f0_p_swp() As Double
			Get
				Return Me.mF0_p_swp
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_swp = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Excluded modiefiers
		''' </summary>
		Public Property f1_mut_exmod() As String
			Get
				Return Me.mF1_mut_exmod
			End Get

			Set(ByVal value As String)
				Me.mF1_mut_exmod = value
			End Set
		End Property

		''' <summary>
		''' Add/remove neural connection
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF1_nmConn As Double

		''' <summary>
		''' Add/remove a neuron
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF1_nmNeu As Double

		''' <summary>
		''' Add/remove neuron property setting
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF1_nmProp As Double

		''' <summary>
		''' Change property value
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF1_nmVal As Double

		''' <summary>
		''' Change connection weight
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF1_nmWei As Double

		''' <summary>
		''' Add/remove a comma ,
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF1_smComma As Double

		''' <summary>
		''' Add/remove a junction ( )
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF1_smJunct As Double

		''' <summary>
		''' Add/remove a modifier
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF1_smModif As Double

		''' <summary>
		''' Add/remove a stick X
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF1_smX As Double

		''' <summary>
		''' Add/remove neural connection
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f1_nmConn() As Double
			Get
				Return Me.mF1_nmConn
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_nmConn = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove a neuron
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f1_nmNeu() As Double
			Get
				Return Me.mF1_nmNeu
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_nmNeu = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove neuron property setting
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f1_nmProp() As Double
			Get
				Return Me.mF1_nmProp
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_nmProp = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Change property value
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f1_nmVal() As Double
			Get
				Return Me.mF1_nmVal
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_nmVal = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Change connection weight
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f1_nmWei() As Double
			Get
				Return Me.mF1_nmWei
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_nmWei = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove a comma ,
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f1_smComma() As Double
			Get
				Return Me.mF1_smComma
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_smComma = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove a junction ( )
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f1_smJunct() As Double
			Get
				Return Me.mF1_smJunct
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_smJunct = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove a modifier
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f1_smModif() As Double
			Get
				Return Me.mF1_smModif
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_smModif = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove a stick X
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f1_smX() As Double
			Get
				Return Me.mF1_smX
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_smX = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Proportional crossover
		''' </summary>
		Private mF1_xo_propor As Boolean

		''' <summary>
		''' Add node
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF4_mut_add As Double

		''' <summary>
		''' - add connection
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF4_mut_add_conn As Double

		''' <summary>
		''' - add division
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF4_mut_add_div As Double

		''' <summary>
		''' - add neural parameter
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF4_mut_add_neupar As Double

		''' <summary>
		''' - add repetition
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF4_mut_add_rep As Double

		''' <summary>
		''' Proportional crossover
		''' </summary>
		Public Property f1_xo_propor() As Boolean
			Get
				Return Me.mF1_xo_propor
			End Get

			Set(ByVal value As Boolean)
				Me.mF1_xo_propor = value
			End Set
		End Property

		''' <summary>
		''' Add node
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f4_mut_add() As Double
			Get
				Return Me.mF4_mut_add
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' - add connection
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f4_mut_add_conn() As Double
			Get
				Return Me.mF4_mut_add_conn
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add_conn = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' - add division
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f4_mut_add_div() As Double
			Get
				Return Me.mF4_mut_add_div
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add_div = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' - add neural parameter
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f4_mut_add_neupar() As Double
			Get
				Return Me.mF4_mut_add_neupar
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add_neupar = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' - add repetion
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f4_mut_add_rep() As Double
			Get
				Return Me.mF4_mut_add_rep
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add_rep = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' - add simple node
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF4_mut_add_simp As Double

		''' <summary>
		''' Delete node
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF4_mut_del As Double

		''' <summary>
		''' Modify node
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mF4_mut_mod As Double

		''' <summary>
		''' Automatic feeding
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mFeed As Integer

		''' <summary>
		''' Food's energy
		''' </summary>
		''' <remarks>0 bis 1000</remarks>
		Private mFeede0 As Double

		''' <summary>
		''' Ingestion multiplier
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mFeedtrans As Double

		''' <summary>
		''' Show file comments
		''' </summary>
		Private mFilecomm As Boolean

		''' <summary>
		''' Food's genotype
		''' </summary>
		Private mFoodgen As String

		''' <summary>
		''' - add simple node
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f4_mut_add_simp() As Double
			Get
				Return Me.mF4_mut_add_simp
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add_simp = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Delete node
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f4_mut_del() As Double
			Get
				Return Me.mF4_mut_del
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_del = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Modifiy node
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property f4_mut_mod() As Double
			Get
				Return Me.mF4_mut_mod
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_mod = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Automatic feeding
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property feed() As Integer
			Get
				Return Me.mFeed
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 100 Then
					Me.mFeed = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Food's energy
		''' </summary>
		''' <value>0 bis 1000</value>
		Public Property feede0() As Double
			Get
				Return Me.mFeede0
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mFeede0 = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Ingestion multiplier
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property feedtrans() As Double
			Get
				Return Me.mFeedtrans
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mFeedtrans = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Show file comments
		''' </summary>
		Public Property filecomm() As Boolean
			Get
				Return Me.mFilecomm
			End Get

			Set(ByVal value As Boolean)
				Me.mFilecomm = value
			End Set
		End Property

		''' <summary>
		''' Food's genotype
		''' </summary>
		Public Property foodgen() As String
			Get
				Return Me.mFoodgen
			End Get

			Set(ByVal value As String)
				Me.mFoodgen = value
			End Set
		End Property

		''' <summary>
		''' Use syntax highlighting
		''' </summary>
		Private mGen_hilite As Boolean

		''' <summary>
		''' Remember history of genetic operations
		''' </summary>
		Private mGen_hist As Boolean

		''' <summary>
		''' f1 converter
		''' </summary>
		Private mGenkonw0 As Boolean

		''' <summary>
		''' f4 converter
		''' </summary>
		Private mGenkonw1 As Boolean

		''' <summary>
		''' genotype library object
		''' </summary>
		Private mGenolib As FrameStick.GlobalContext.GenotypeLibrary

		''' <summary>
		''' Operators for f0
		''' </summary>
		''' <remarks>0 bis 0
		''' 
		''' 0 = Default</remarks>
		Private mGenoper_f0 As Integer

		''' <summary>
		''' Operators for f1
		''' </summary>
		''' <remarks>0 bis 0
		''' 
		''' 0 = Default</remarks>
		Private mGenoper_f1 As Integer

		''' <summary>
		''' Use syntax highlighting
		''' </summary>
		Public Property gen_hilite() As Boolean
			Get
				Return Me.mGen_hilite
			End Get

			Set(ByVal value As Boolean)
				Me.mGen_hilite = value
			End Set
		End Property

		''' <summary>
		''' Remermer history of genetic operations
		''' </summary>
		Public Property gen_hist() As Boolean
			Get
				Return Me.mGen_hist
			End Get

			Set(ByVal value As Boolean)
				Me.mGen_hist = value
			End Set
		End Property

		''' <summary>
		''' f1 converter
		''' </summary>
		Public Property genkonw0() As Boolean
			Get
				Return Me.mGenkonw0
			End Get

			Set(ByVal value As Boolean)
				Me.mGenkonw0 = value
			End Set
		End Property

		''' <summary>
		''' f4 converter
		''' </summary>
		Public Property genkonw1() As Boolean
			Get
				Return Me.mGenkonw1
			End Get

			Set(ByVal value As Boolean)
				Me.mGenkonw1 = value
			End Set
		End Property

		''' <summary>
		''' genotype library object
		''' </summary>
		Public Property genolib() As FrameStick.GlobalContext.GenotypeLibrary
			Get
				Return Me.mGenolib
			End Get

			Set(ByVal value As FrameStick.GlobalContext.GenotypeLibrary)
				Me.mGenolib = value
			End Set
		End Property

		''' <summary>
		''' Operators for f0
		''' </summary>
		''' <value>0 bis 0
		''' 
		''' 0 = Default</value>
		Public Property genoper_f0() As Integer
			Get
				Return Me.mGenoper_f0
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 0 Then
					Me.mGenoper_f0 = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 0 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Operators for f1
		''' </summary>
		''' <value>0 bis 0
		''' 
		''' 0 = Default</value>
		Public Property genoper_f1() As Integer
			Get
				Return Me.mGenoper_f1
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 0 Then
					Me.mGenoper_f1 = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss 0 und 0 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Operators for f4
		''' </summary>
		''' <remarks>0 bis 0
		''' 
		''' 0 = Default</remarks>
		Private mGenoper_f4 As Integer

		''' <summary>
		''' Check genotypes added to groups
		''' </summary>
		Private mGroupchk As Boolean

		''' <summary>
		''' Check imported genotypes
		''' </summary>
		Private mImportchk As Boolean

		''' <summary>
		''' Initial genotype
		''' </summary>
		Private mInitialgen As String

		''' <summary>
		''' live library object
		''' </summary>
		Private mLivelib As FrameStick.GlobalContext.LiveLibrary

		''' <summary>
		''' Check genotypes loaded from experiment
		''' </summary>
		Private mLoadchk As Boolean

		''' <summary>
		''' Simulated creatues
		''' </summary>
		''' <remarks>0 bis 50</remarks>
		Private mMaxCreated As Integer

		''' <summary>
		''' Operators for f4
		''' </summary>
		''' <value>0 bis 0
		''' 
		''' 0 = Default</value>
		Public Property genoper_f4() As Integer
			Get
				Return Me.mGenoper_f4
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 0 Then
					Me.mGenoper_f4 = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 0 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Check genotypes added to groups
		''' </summary>
		Public Property groupchk() As Boolean
			Get
				Return Me.mGroupchk
			End Get

			Set(ByVal value As Boolean)
				Me.mGroupchk = value
			End Set
		End Property

		''' <summary>
		''' Check imported genotypes
		''' </summary>
		Public Property importchk() As Boolean
			Get
				Return Me.mImportchk
			End Get

			Set(ByVal value As Boolean)
				Me.mImportchk = value
			End Set
		End Property

		''' <summary>
		''' Initial genotype
		''' </summary>
		Public Property initialgen() As String
			Get
				Return Me.mInitialgen
			End Get

			Set(ByVal value As String)
				Me.mInitialgen = value
			End Set
		End Property

		''' <summary>
		''' live library object
		''' </summary>
		Public Property livelib() As FrameStick.GlobalContext.LiveLibrary
			Get
				Return Me.mLivelib
			End Get

			Set(ByVal value As FrameStick.GlobalContext.LiveLibrary)
				Me.mLivelib = value
			End Set
		End Property

		''' <summary>
		''' Check genotypes loaded from experiment
		''' </summary>
		Public Property loadchk() As Boolean
			Get
				Return Me.mLoadchk
			End Get

			Set(ByVal value As Boolean)
				Me.mLoadchk = value
			End Set
		End Property

		''' <summary>
		''' Simulated creatures
		''' </summary>
		''' <value>0 bis 50</value>
		Public Property MaxCreated() As Integer
			Get
				Return Me.mMaxCreated
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 50 Then
					Me.mMaxCreated = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 50 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Neuron (N)
		''' </summary>
		Private mNeuadd_N As Boolean

		''' <summary>
		''' Unipolar neuron [EXPERIMENTAL!] (Nu)
		''' </summary>
		Private mNeuadd_Nu As Boolean

		''' <summary>
		''' Neuron (N)
		''' </summary>
		Public Property neuadd_N() As Boolean
			Get
				Return Me.mNeuadd_N
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_N = value
			End Set
		End Property

		''' <summary>
		''' Unipolar neuron [EXPERIMENTAL!] (Nu)
		''' </summary>
		Public Property neuadd_Nu() As Boolean
			Get
				Return Me.mNeuadd_Nu
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Nu = value
			End Set
		End Property

		''' <summary>
		''' Gyroscope (G)
		''' </summary>
		Private mNeuadd_G As Boolean

		''' <summary>
		''' Touch (T)
		''' </summary>
		Private mNeuadd_T As Boolean

		''' <summary>
		''' Smell (S)
		''' </summary>
		Private mNeuadd_S As Boolean

		''' <summary>
		''' Gyroscope (G)
		''' </summary>
		Public Property neuadd_G() As Boolean
			Get
				Return Me.mNeuadd_G
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_G = value
			End Set
		End Property

		''' <summary>
		''' Touch (T)
		''' </summary>
		Public Property neuadd_T() As Boolean
			Get
				Return Me.mNeuadd_T
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_T = value
			End Set
		End Property

		''' <summary>
		''' Smell (S)
		''' </summary>
		Public Property neuadd_S() As Boolean
			Get
				Return Me.mNeuadd_S
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_S = value
			End Set
		End Property

		''' <summary>
		''' Constant (*)
		''' </summary>
		Private mNeuadd_asteric As Boolean

		''' <summary>
		''' Bend muscle (I)
		''' </summary>
		Private mNeuadd_I As Boolean

		''' <summary>
		''' Constant (*)
		''' </summary>
		Public Property neuadd_asteric() As Boolean
			Get
				Return Me.mNeuadd_asteric
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_asteric = value
			End Set
		End Property

		''' <summary>
		''' Bend muscle (I)
		''' </summary>
		Public Property neuadd_I() As Boolean
			Get
				Return Me.mNeuadd_I
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_I = value
			End Set
		End Property

		''' <summary>
		''' Rotation muscle (@)
		''' </summary>
		Private mNeuadd_at As Boolean

		''' <summary>
		''' Differentiate (D)
		''' </summary>
		Private mNeuadd_D As Boolean

		''' <summary>
		''' Fuzzy system [EXPERIMENTAL!] (Fuzzy)
		''' </summary>
		Private mNeuadd_Fuzzy As Boolean

		''' <summary>
		''' Rotation muscle (@)
		''' </summary>
		Public Property neuadd_at() As Boolean
			Get
				Return Me.mNeuadd_at
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_at = value
			End Set
		End Property

		''' <summary>
		''' Differentiate (D)
		''' </summary>
		Public Property nauadd_D() As Boolean
			Get
				Return Me.mNeuadd_D
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_D = value
			End Set
		End Property

		''' <summary>
		''' Fuzzy system [EXPERIMENTAL!] (Fuzzy)
		''' </summary>
		Public Property neuadd_Fuzzy() As Boolean
			Get
				Return Me.mNeuadd_Fuzzy
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Fuzzy = value
			End Set
		End Property

		''' <summary>
		''' Vector Eye [EXPERIMENTAL!] (VE)
		''' </summary>
		Private mNeuadd_VE As Boolean

		''' <summary>
		''' Sticky [EXPERIMENTAL!] (Sti)
		''' </summary>
		Private mNeuadd_Sti As Boolean

		''' <summary>
		''' Lenght muscle [EXPERIMENTAL!] (LMu)
		''' </summary>
		Private mNeuadd_LMu As Boolean

		''' <summary>
		''' Vector Eye [EXPERIMENTAL!] (VE)
		''' </summary>
		Public Property neuadd_VE() As Boolean
			Get
				Return Me.mNeuadd_VE
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_VE = value
			End Set
		End Property

		''' <summary>
		''' Sticky [EXPERIMENTAL!] (Sti)
		''' </summary>
		Public Property neuadd_Sti() As Boolean
			Get
				Return Me.mNeuadd_Sti
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Sti = value
			End Set
		End Property

		''' <summary>
		''' Lenght muscle [EXPERIMENTAL!] (LMu)
		''' </summary>
		Public Property neuadd_LMu() As Boolean
			Get
				Return Me.mNeuadd_LMu
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_LMu = value
			End Set
		End Property

		''' <summary>
		''' Water detector (Water)
		''' </summary>
		Private mNeuadd_Water As Boolean

		''' <summary>
		''' Energy level (Energy)
		''' </summary>
		Private mNeuadd_Energy As Boolean

		''' <summary>
		''' Channelize (Ch)
		''' </summary>
		Private mNeuadd_Ch As Boolean

		''' <summary>
		''' Water detector (Water)
		''' </summary>
		Public Property neuadd_Water() As Boolean
			Get
				Return Me.mNeuadd_Water
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Water = value
			End Set
		End Property

		''' <summary>
		''' Energy level (Energy)
		''' </summary>
		Public Property neuadd_Energy() As Boolean
			Get
				Return Me.mNeuadd_Energy
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Energy = value
			End Set
		End Property

		''' <summary>
		''' Channelize (Ch)
		''' </summary>
		Public Property neuadd_Ch() As Boolean
			Get
				Return Me.mNeuadd_Ch
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Ch = value
			End Set
		End Property

		''' <summary>
		''' Channel multiplexer (ChMux)
		''' </summary>
		Private mNeuadd_ChMux As Boolean

		''' <summary>
		''' Channel selector (ChSel)
		''' </summary>
		Private mNeuadd_ChSel As Boolean

		''' <summary>
		''' Random noise (Rnd)
		''' </summary>
		Private mNeuadd_Rnd As Boolean

		''' <summary>
		''' Channel multiplexer (ChMux)
		''' </summary>
		Public Property neuadd_ChMux() As Boolean
			Get
				Return Me.mNeuadd_ChMux
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_ChMux = value
			End Set
		End Property

		''' <summary>
		''' Channel selector (ChSel)
		''' </summary>
		Public Property neuadd_ChSel() As Boolean
			Get
				Return Me.mNeuadd_ChSel
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_ChSel = value
			End Set
		End Property

		''' <summary>
		''' Random noise (Rnd)
		''' </summary>
		Public Property neuadd_Rnd() As Boolean
			Get
				Return Me.mNeuadd_Rnd
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Rnd = value
			End Set
		End Property

		''' <summary>
		''' Sinus generator (Sin)
		''' </summary>
		Private mNeuadd_Sin As Boolean

		''' <summary>
		''' Sinus generator (Sin)
		''' </summary>
		Public Property neuadd_Sin() As Boolean
			Get
				Return Me.mNcl_Sin
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_Sin = value
			End Set
		End Property

		''' <summary>
		''' Neuron (N)
		''' </summary>
		Private mNcl_N As Boolean

		''' <summary>
		''' Unipolar neuron [EXPERIMENTAL!] (Nu)
		''' </summary>
		Private mNcl_Nu As Boolean

		''' <summary>
		''' Neuron (N)
		''' </summary>
		Public Property ncl_N() As Boolean
			Get
				Return Me.mNcl_N
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_N = value
			End Set
		End Property

		''' <summary>
		''' Unipolar neuron [EXPERIMENTAL!] (Nu)
		''' </summary>
		Public Property ncl_Nu() As Boolean
			Get
				Return Me.mNcl_Nu
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_Nu = value
			End Set
		End Property

		''' <summary>
		''' Gyroscope (G)
		''' </summary>
		Private mNcl_G As Boolean

		''' <summary>
		''' Gyroscope (G)
		''' </summary>
		Public Property ncl_G() As Boolean
			Get
				Return Me.mNcl_G
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_G = value
			End Set
		End Property

		''' <summary>
		''' Toch (T)
		''' </summary>
		Private mNcl_T As Boolean

		''' <summary>
		''' Smell (S)
		''' </summary>
		Private mNcl_S As Boolean

		''' <summary>
		''' Constant (*)
		''' </summary>
		Private mNcl_asteric As Boolean

		''' <summary>
		''' Touch (T)
		''' </summary>
		Public Property ncl_T() As Boolean
			Get
				Return Me.mNcl_T
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_T = value
			End Set
		End Property

		''' <summary>
		''' Smell (S)
		''' </summary>
		Public Property ncl_S() As Boolean
			Get
				Return Me.mNcl_S
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_S = value
			End Set
		End Property

		''' <summary>
		''' Constant (*)
		''' </summary>
		Public Property ncl_asteric() As Boolean
			Get
				Return Me.mNcl_asteric
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_asteric = value
			End Set
		End Property

		''' <summary>
		''' Bend muscle (I)
		''' </summary>
		Private mNcl_I As Boolean

		''' <summary>
		''' Rotation muscle (@)
		''' </summary>
		Private mNcl_at As Boolean

		''' <summary>
		''' Bend muscle (I)
		''' </summary>
		Public Property ncl_I() As Boolean
			Get
				Return Me.mNcl_I
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_I = value
			End Set
		End Property

		''' <summary>
		''' Rotation muscle (@)
		''' </summary>
		Public Property ncl_at() As Boolean
			Get
				Return Me.mNcl_at
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_at = value
			End Set
		End Property

		''' <summary>
		''' Differentiate (D)
		''' </summary>
		Private mNcl_D As Boolean

		''' <summary>
		''' Fuzzy system [EXPERIMENTAL!] (Fuzzy)
		''' </summary>
		Private mNcl_Fuzzy As Boolean

		''' <summary>
		''' Vector Eye [EXPERIMENTAL!] (VE)
		''' </summary>
		Private mNcl_VE As Boolean

		''' <summary>
		''' Differentiate (D)
		''' </summary>
		Public Property ncl_D() As Boolean
			Get
				Return Me.mNcl_D
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_D = value
			End Set
		End Property

		''' <summary>
		''' Fuzzy system [EXPERIMENTAL!] (Fuzzy)
		''' </summary>
		Public Property ncl_Fuzzy() As Boolean
			Get
				Return Me.mNcl_Fuzzy
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_Fuzzy = value
			End Set
		End Property

		''' <summary>
		''' Vector Eye [EXPERIMENTAL!] (VE)
		''' </summary>
		Public Property ncl_VE() As Boolean
			Get
				Return Me.mNcl_VE
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_VE = value
			End Set
		End Property

		''' <summary>
		''' Sticky [EXPERIMENTAL!] (Sti)
		''' </summary>
		Private mNcl_Sti As Boolean

		''' <summary>
		''' Lenght muscle [EXPERIMENTAL!] (LMu)
		''' </summary>
		Private mNcl_LMu As Boolean

		''' <summary>
		''' Sticky [EXPERIMENTAL!] (Sti)
		''' </summary>
		Public Property ncl_Sti() As Boolean
			Get
				Return Me.mNcl_Sti
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_Sti = value
			End Set
		End Property

		''' <summary>
		''' Lenght muscle [EXPERIMENTAL!] (LMu)
		''' </summary>
		Public Property ncl_LMu() As Boolean
			Get
				Return Me.mNcl_LMu
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_LMu = value
			End Set
		End Property

		''' <summary>
		''' Water detector (Water)
		''' </summary>
		Private mNcl_Water As Boolean

		''' <summary>
		''' Energy level (Energy)
		''' </summary>
		Private mNcl_Energy As Boolean

		''' <summary>
		''' Channelize (Ch)
		''' </summary>
		Private mNcl_Ch As Boolean

		''' <summary>
		''' Water detector (Water)
		''' </summary>
		Public Property ncl_Water() As Boolean
			Get
				Return Me.mNcl_Water
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_Water = value
			End Set
		End Property

		''' <summary>
		''' Energy level (Energy)
		''' </summary>
		Public Property ncl_Energy() As Boolean
			Get
				Return Me.mNcl_Energy
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_Energy = value
			End Set
		End Property

		''' <summary>
		''' Channelize (Ch)
		''' </summary>
		Public Property ncl_Ch() As Boolean
			Get
				Return Me.mNcl_Ch
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_Ch = value
			End Set
		End Property

		''' <summary>
		''' Channel multiplexer (ChMux)
		''' </summary>
		Private mNcl_ChMux As Boolean

		''' <summary>
		''' Channel selector (ChSel)
		''' </summary>
		Private mNcl_ChSel As Boolean

		''' <summary>
		''' Channel Multiplexer (ChMux)
		''' </summary>
		Public Property ncl_ChMux() As Boolean
			Get
				Return Me.mNcl_ChMux
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_ChMux = value
			End Set
		End Property

		''' <summary>
		''' Channel selector (ChSel)
		''' </summary>
		Public Property ncl_ChSel() As Boolean
			Get
				Return Me.mNcl_ChSel
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_ChSel = value
			End Set
		End Property

		''' <summary>
		''' Random noise (Rnd)
		''' </summary>
		Private mNcl_Rnd As Boolean

		''' <summary>
		''' Sinus generator (Sin)
		''' </summary>
		Private mNcl_Sin As Boolean

		''' <summary>
		''' Notes
		''' </summary>
		Private mNotes As String

		''' <summary>
		''' Overwrite
		''' </summary>
		Private mOverwrite As Boolean

		''' <summary>
		''' Mutated
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mP_mut As Double

		''' <summary>
		''' Random noise (Rnd)
		''' </summary>
		Public Property ncl_Rnd() As Boolean
			Get
				Return Me.mNcl_Rnd
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_Rnd = value
			End Set
		End Property

		''' <summary>
		''' Sinus generator (Sin)
		''' </summary>
		Public Property ncl_Sin() As Boolean
			Get
				Return Me.mNcl_Sin
			End Get

			Set(ByVal value As Boolean)
				Me.mNcl_Sin = value
			End Set
		End Property

		''' <summary>
		''' Notes
		''' </summary>
		Public Property notes() As String
			Get
				Return Me.mNotes
			End Get

			Set(ByVal value As String)
				Me.mNotes = value
			End Set
		End Property

		''' <summary>
		''' Overwrite
		''' </summary>
		Public Property overwrite() As Boolean
			Get
				Return Me.mOverwrite
			End Get

			Set(ByVal value As Boolean)
				Me.mOverwrite = value
			End Set
		End Property

		''' <summary>
		''' Mutated
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property p_mut() As Double
			Get
				Return Me.mP_mut
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mP_mut = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Unchanged
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mP_nop As Double

		''' <summary>
		''' Crossed over
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mP_xov As Double

		''' <summary>
		''' Creation placement
		''' </summary>
		''' <remarks>0 bis 1
		''' 
		''' 0 = Random
		''' 1 = Central</remarks>
		Private mPlacement As Integer

		''' <summary>
		''' Random initialization
		''' </summary>
		Private mRandinit As Double

		''' <summary>
		''' Selection rule
		''' </summary>
		''' <remarks>0 bis 5
		''' 
		''' 0 = Random
		''' 1 = Fitness-proportional (roulette)
		''' 2 = Tournament (2 genotypes)
		''' 3 = Tournament (3 genotypes)
		''' 4 = Tournament (4 genotypes)
		''' 5 = Tournament (5 genotypes)</remarks>
		Private mSelrule As Integer

		''' <summary>
		''' Unchanged
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property p_nop() As Double
			Get
				Return Me.mP_nop
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mP_nop = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Crossed over
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property p_xov() As Double
			Get
				Return Me.mP_xov
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mP_xov = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Creation placement
		''' </summary>
		''' <value>0 bis 1
		''' 
		''' 0 = Random
		''' 1 = Central</value>
		Public Property placement() As Integer
			Get
				Return Me.mPlacement
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 1 Then
					Me.mPlacement = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Random initialisation
		''' </summary>
		Public Property randinit() As Double
			Get
				Return Me.mRandinit
			End Get

			Set(ByVal value As Double)
				Me.mRandinit = value
			End Set
		End Property

		''' <summary>
		''' Selection rule
		''' </summary>
		''' <value>0 bis 5
		''' 
		''' 0 = Random
		''' 1 = Fitness-proportional (roulette)
		''' 2 = Tournament (2 genotypes)
		''' 3 = Tournament (3 genotypes)
		''' 4 = Tournament (4 genotypes)
		''' 5 = Tournament (5 genotypes)</value>
		Public Property selrule() As Integer
			Get
				Return Me.mSelrule
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 5 Then
					Me.mSelrule = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 5 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' the simulation should stop
		''' </summary>
		Private mShouldStop As Boolean

		''' <summary>
		''' Matching method
		''' </summary>
		''' <remarks>0 bis 1
		''' 
		''' 0 = New
		''' 1 = Old</remarks>
		Private mSimil_method As Integer

		''' <summary>
		''' Weight of neurons count
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mSimil_neuron As Double

		''' <summary>
		''' Degree's og parts
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mSimil_partdeg As Double


		''' <summary>
		''' Weight of parts count
		''' </summary>
		''' <remarks>0 bis 100</remarks>
		Private mSimil_parts As Double

		''' <summary>
		''' number of steps
		''' </summary>
		Private mTime As Integer

		''' <summary>
		''' Evaluated creatues
		''' </summary>
		Private mTotaltestedcr As Integer

		''' <summary>
		''' User script
		''' </summary>
		Private mUsercode As String

		''' <summary>
		''' world object
		''' </summary>
		Private mWolrd As FrameStick.GlobalContext.ExperimentDefinition.VisualStyleDefinition.World

		''' <summary>
		''' the simulation should stop
		''' </summary>
		Public Property shouldStop() As Boolean
			Get
				Return Me.mShouldStop
			End Get

			Set(ByVal value As Boolean)
				Me.mShouldStop = value
			End Set
		End Property

		''' <summary>
		''' Matching method
		''' </summary>
		''' <value>0 bis 1
		''' 
		''' 0 = New
		''' 1 = Old</value>
		Public Property simil_method() As Integer
			Get
				Return Me.mSimil_method
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 1 Then
					Me.mSimil_method = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Weight of neurons count
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property simil_neuro() As Double
			Get
				Return Me.mSimil_neuron
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mSimil_neuron = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Weight of parts' degree
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property simil_partdeg() As Double
			Get
				Return Me.mSimil_partdeg
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mSimil_partdeg = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Weight of parts count
		''' </summary>
		''' <value>0 bis 100</value>
		Public Property simil_parts() As Double
			Get
				Return Me.mSimil_parts
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mSimil_parts = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' number of steps
		''' </summary>
		Public Property time() As Integer
			Get
				Return Me.mTime
			End Get

			Set(ByVal value As Integer)
				Me.mTime = value
			End Set
		End Property

		''' <summary>
		''' Evaluated creatures
		''' </summary>
		Public Property totaltestedcr() As Integer
			Get
				Return Me.mTotaltestedcr
			End Get

			Set(ByVal value As Integer)
				Me.mTotaltestedcr = value
			End Set
		End Property

		''' <summary>
		''' User script
		''' </summary>
		Public Property usercode() As String
			Get
				Return Me.mUsercode
			End Get

			Set(ByVal value As String)
				Me.mUsercode = value
			End Set
		End Property

		''' <summary>
		''' world object
		''' </summary>
		Public Property world() As FrameStick.GlobalContext.ExperimentDefinition.VisualStyleDefinition.World
			Get
				Return Me.mWolrd
			End Get

			Set(ByVal value As FrameStick.GlobalContext.ExperimentDefinition.VisualStyleDefinition.World)
				Me.mWolrd = value
			End Set
		End Property

		''' <summary>
		''' Boundaries
		''' </summary>
		''' <remarks>0 bis 2
		''' 
		''' 0 = None
		''' 1 = Fence
		''' 2 = Teleport</remarks>
		Private mWrldbnd As Integer

		''' <summary>
		''' Map
		''' </summary>
		Private mWrldmap As String

		''' <summary>
		''' Size
		''' </summary>
		''' <remarks>10 bis 200</remarks>
		Private mWrldsiz As Double

		''' <summary>
		''' Type
		''' </summary>
		''' <remarks>0 bis 2
		''' 
		''' 0 = Flat surface
		''' 1 = Blocks
		''' 2 = Height field</remarks>
		Private mWrldtyp As Integer

		''' <summary>
		''' Boundaries
		''' </summary>
		''' <value>0 bis 2
		''' 
		''' 0 = None
		''' 1 = Fence
		''' 2 = Teleport</value>
		Public Property wrldbnd() As Integer
			Get
				Return Me.mWrldbnd
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 2 Then
					Me.mWrldbnd = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Map
		''' </summary>
		Public Property wrldmap() As String
			Get
				Return Me.mWrldmap
			End Get

			Set(ByVal value As String)
				Me.mWrldmap = value
			End Set
		End Property

		''' <summary>
		''' Size
		''' </summary>
		''' <value>10 bis 200</value>
		Public Property wrldsiz() As Double
			Get
				Return Me.mWrldsiz
			End Get

			Set(ByVal value As Double)
				If value >= 10 And value <= 200 Then
					Me.mWrldsiz = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 200 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Type
		''' </summary>
		''' <value>0 bis 2
		''' 
		''' 0 = Flat surface
		''' 1= Blocks
		''' 2 = Height field</value>
		Public Property wrldtyp() As Integer
			Get
				Return Me.mWrldtyp
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 2 Then
					Me.mWrldtyp = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Water level
		''' </summary>
		''' <remarks>- 20 bis 30</remarks>
		Private mWrldwat As Double

		''' <summary>
		''' Minimal similarity
		''' </summary>
		''' <remarks>0 bis 9999</remarks>
		Private mXov_mins As Double

		''' <summary>
		''' Water level
		''' </summary>
		''' <value>-20 bis 30</value>
		Public Property wrldwat() As Double
			Get
				Return Me.mWrldwat
			End Get

			Set(ByVal value As Double)
				If value >= -20 And value <= 30 Then
					Me.mWrldwat = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -20 und 30 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Minimal similiarity
		''' </summary>
		''' <value>0 bis 9999</value>
		Public Property xov_mins() As Double
			Get
				Return Me.mXov_mins
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 9999 Then
					Me.mXov_mins = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 9999 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' add property
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
		''' Reset performance dat
		''' </summary>
		Public Sub cleardata()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' Crossover
		''' </summary>
		Public Sub crossOver()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' evalaute model dissimilarity
		''' </summary>
		Public Sub evaluateDistance()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' export
		''' </summary>
		Public Sub export(ByVal filename As String, ByVal options As Integer, ByVal genotypegroup As Integer, ByVal creaturesgroup As Integer)
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' import
		''' </summary>
		Public Sub import(ByVal filename As String, ByVal options As Integer)
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' Initialize experiment
		''' </summary>
		Public Sub init()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' load
		''' </summary>
		Public Sub load(ByVal filename As String)
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' Reload experiment definition
		''' </summary>
		Public Sub loadexpdef()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' (re)load neuron definition
		''' </summary>
		Public Sub loadNeurons(ByVal directorypath As String)
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' print message
		''' </summary>
		Public Sub message(ByVal text As String, ByVal level As Integer)
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' Mutate
		''' </summary>
		Public Sub mutate()
			' BUG: Implementieren 
		End Sub

		Public Sub New()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' eigendlich als "new" gedacht
		''' </summary>
		''' <remarks>, allerdings kann ein Konstruktor nur ein Object von sich selbst zurückgeben und nicht eine andere Klasse</remarks>
		Public Function newSimulator() As FrameStick.GlobalContext.Simulator
			' BUG: Implementieren 
			Return Nothing
		End Function

		''' <summary>
		''' Operators report
		''' </summary>
		Public Sub openReport()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' print information message
		''' </summary>
		Public Sub print(ByVal text As String)
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

		''' <summary>
		''' save
		''' </summary>
		Public Sub save(ByVal filename As String)
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' do single simulation step
		''' </summary>
		''' <remarks>eigendlich "step"</remarks>
		Public Sub doSetep()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' stop simulation
		''' </summary>
		''' <remarks>eigendlcih "stop"</remarks>
		Public Sub doStop()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' HTMLize a genotype
		''' </summary>
		Public Sub toHTML()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' HTMLize a genotype, shorten if needed
		''' </summary>
		Public Sub toHTMLshort()
			' BUG: Implementieren 
		End Sub

		''' <summary>
		''' Trigger world update
		''' </summary>
		Public Event wrldchg As EventHandler

		''' <summary>
		''' Trigger autosave now
		''' </summary>
		Public Event autosave As EventHandler
	End Class

End Namespace
