Namespace GlobalContext

	''' <summary>
	''' A set of Creature objects, sharing some high level simulation properties (performance calculation, NN
	''' simulation, collision detection, event handling). The groups usually have different roles in the
	''' experiment (Creatures groups and Food group in standard.expdef)
	''' </summary>
	''' <remarks>A set of Creature objects, sharing some high level simulation properties (performance calculation, NN
	''' simulation, collision detection, event handling). The groups usually have different roles in the
	''' experiment (Creatures groups and Food group in standard.expdef)</remarks>
	Public Class CreatureGroup

		''' <summary>
		''' Collision mask
		''' </summary>
		''' <remarks>0 bis 65535</remarks>
		Private mColmask As Integer

		''' <summary>
		''' Collision mask
		''' </summary>
		''' <value>0 bis 65535</value>
		Public Property colmask() As Integer
			Get
				Return Me.mColmask
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 65535 Then
					Me.mColmask = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 65535 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Number of creatures
		''' </summary>
		Private mCreaturecount As Integer

		''' <summary>
		''' Death
		''' </summary>
		Private mDeath As Boolean

		''' <summary>
		''' Muscle dynamic work
		''' </summary>
		''' <remarks>floatinf point
		''' 0 bis 1</remarks>
		Private mEm_dyn As Double

		''' <summary>
		''' Muscle static work
		''' </summary>
		''' <remarks>floating point
		''' 0 bis 1</remarks>
		Private mEm_stat As Double

		''' <summary>
		''' Assimilation productivity
		''' </summary>
		''' <remarks>floating point
		''' 0 bis 1</remarks>
		Private mEn_assim As Double

		''' <summary>
		''' Performance calculation
		''' </summary>
		''' <remarks>0 bis 2
		''' 
		''' 0 = Off
		''' 1 = Immediate
		''' 2 = After freeze</remarks>
		Private mEnableperf As Integer

		''' <summary>
		''' Energy calculation
		''' </summary>
		Private mEnergy As Boolean

		''' <summary>
		''' group index
		''' </summary>
		Private mIndex As Integer

		''' <summary>
		''' Group name
		''' </summary>
		Private mName As String

		''' <summary>
		''' Numer of creatures
		''' </summary>
		Public Property creaturecount() As Integer
			Get
				Return Me.mCreaturecount
			End Get

			Set(ByVal value As Integer)
				Me.mCreaturecount = value
			End Set
		End Property

		''' <summary>
		''' Death
		''' </summary>
		Public Property death() As Boolean
			Get
				Return Me.mDeath
			End Get

			Set(ByVal value As Boolean)
				Me.mDeath = value
			End Set
		End Property

		''' <summary>
		''' Muscle dynamic work
		''' </summary>
		''' <value>floating point
		''' 0 bis 1</value>
		Public Property em_dyn() As Double
			Get
				Return Me.mEm_dyn
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 1 Then
					Me.mEm_dyn = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Muscle static work
		''' </summary>
		''' <value>floating point
		''' 0 bis 1</value>
		Public Property em_stat() As Double
			Get
				Return Me.mEm_stat
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 1 Then
					Me.mEm_stat = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Assimilation productivity
		''' </summary>
		''' <value>floating point
		''' 0 bis 1</value>
		Public Property en_assim() As Double
			Get
				Return Me.mEn_assim
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 1 Then
					Me.mEn_assim = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Performance calculation
		''' </summary>
		''' <value>0 bis 2
		''' 
		''' 0 = Off
		''' 1 = Immediate
		''' 2 = After freeze</value>
		Public Property enableperf() As Integer
			Get
				Return Me.mEnableperf
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 2 Then
					Me.mEnableperf = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Energy calculation
		''' </summary>
		Public Property energy() As Boolean
			Get
				Return Me.mEnergy
			End Get

			Set(ByVal value As Boolean)
				Me.mEnergy = value
			End Set
		End Property

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
		''' Neural net simulation
		''' </summary>
		''' <remarks>0 bis 2
		''' 
		''' 0 = Off
		''' 1 = Immediate
		''' 2 = Affter freeze</remarks>
		Private mNnsim As Integer

		''' <summary>
		''' Performance sampling period
		''' </summary>
		''' <remarks>0 bis 1000000</remarks>
		Private mPerfperiod As Integer

		''' <summary>
		''' Neural net simulation
		''' </summary>
		''' <value>0 bis 2
		''' 
		''' 0 = Off
		''' 1= Immediate
		''' 2 = After freeze</value>
		Public Property nnsim() As Integer
			Get
				Return Me.mNnsim
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 2 Then
					Me.mNnsim = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Performance sampling period
		''' </summary>
		''' <value>0 bis 1.000.000</value>
		Public Property perfperiod() As Integer
			Get
				Return Me.mPerfperiod
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 1000000 Then
					Me.mPerfperiod = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1000000 liegen.")
				End If
			End Set
		End Property

		Public Function createFromGeno(ByVal Geno As FrameStick.GlobalContext.Geno) As FrameStick.GlobalContext.Genotype
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Sub createFromGenotype()
			' BUG: Implementieren
		End Sub

		Public Function createFromString(ByVal genotype As String) As FrameStick.GlobalContext.Genotype
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' find creature by UID
		''' </summary>
		Public Function findUID(ByVal uid As String) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get creature object
		''' </summary>
		Public Function getCreature(ByVal index As Integer) As FrameStick.GlobalContext.Creature
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' senseCreaturesProperty
		''' </summary>
		''' <param name="x">floating point</param>
		''' <param name="y">floating point</param>
		''' <param name="z">floating point</param>
		''' <returns>floating point</returns>
		Public Function senseCreaturesProperty(ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal propertyname As String, ByVal except As FrameStick.GlobalContext.Creature) As Double
			' BUG: Implementieren
		End Function
	End Class

End Namespace
