Namespace GlobalContext

	Namespace ExperimentDefinition

		Public Class ExpParams

			''' <summary>
			''' Aging time, 0..100000
			''' </summary>
			Private mAging As Integer

			''' <summary>
			''' Gene pool capacity, 0...2000
			''' </summary>
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
			''' Constant floating point, -10000..10000
			''' </summary>
			Private mCr_c As Double

			''' <summary>
			''' Distance, floating point, -10000..10000
			''' </summary>
			Private mCr_di As Double

			''' <summary>
			''' Body parts, floating point, -10000..10000
			''' </summary>
			Private mCr_gl As Double

			''' <summary>
			''' Body joints, floating point, -10000..10000
			''' </summary>
			Private mCr_joints As Double

			''' <summary>
			''' Life span, floating point, -10000..10000
			''' </summary>
			Private mCr_life As Double

			''' <summary>
			''' Brain connections, floating point, -10000..10000
			''' </summary>
			Private mCr_nncon As Double

			''' <summary>
			''' Brain neurons, floating Points, -10000..10000
			''' </summary>
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
			''' Velocity, floating Point, -10000..10000
			''' </summary>
			Private mCr_v As Double

			''' <summary>
			''' Vertical position, floating point, -10000..10000
			''' </summary>
			Private mCr_vpos As Double

			''' <summary>
			''' Vertical velocity, floating point, -10000..10000
			''' </summary>
			Private mCr_vvel As Double

			''' <summary>
			''' Creation height, floating point, -1..50
			''' </summary>
			Private mCreath As Double

			''' <summary>
			''' Delete genotypes, 0..2, 0= Randomly, 1=Inverse-proportionally to fitness, 2=Only the worst
			''' </summary>
			Private mDelrule As Integer

			''' <summary>
			''' Idle metabolism, floating point, 0..1
			''' </summary>
			Private mE_meta As Double

			''' <summary>
			''' Starting energy, floating Point, 0..10000
			''' </summary>
			Private mEnergy0 As Double

			''' <summary>
			''' Automatic feeding, 0..100
			''' </summary>
			Private mFeed As Integer

			''' <summary>
			''' Food's energy, floating point, 0..1000
			''' </summary>
			Private mFeede0 As Double

			''' <summary>
			''' Ingestion multiplier, floating point, 0..100
			''' </summary>
			Private mFeedtrans As Double

			''' <summary>
			''' Food's genotype
			''' </summary>
			Private mFoodgen As String

			''' <summary>
			''' Initial genotype
			''' </summary>
			Private mInitialgen As String

			''' <summary>
			''' Simulated creatures, 0..50
			''' </summary>
			Private mMaxCreated As Integer

			''' <summary>
			''' Mutated, floating point, 0..100
			''' </summary>
			Private mP_mut As Double

			''' <summary>
			''' Unchanged, floating Point, 0..100
			''' </summary>
			Private mP_nop As Double

			''' <summary>
			''' Crossed over, floating point, 0..100
			''' </summary>
			Private mP_xov As Double

			''' <summary>
			''' Creation placement, 0..1, 0=Random, 1=Central
			''' </summary>
			Private mPlacement As Integer

			''' <summary>
			''' Selection rule, 0..5
			''' 0=Random
			''' 1=Fitness-proportional (roulette)
			''' 2=Tournament (2 genotypes)
			''' 3=Tournament (3 genotypes)
			''' 4=Tournament (4 genotypes)
			''' 5=Tournament (5 genotypes)
			''' </summary>
			Private mSelrule As Integer

			''' <summary>
			''' Minimal similarity, floating point, 0..9999
			''' </summary>
			Private mXov_mins As Double

			''' <summary>
			''' add property (id,type,name,help)
			''' </summary>
			Public Sub Add(ByVal id As String, ByVal type As String, ByVal name As String, ByVal help As String)
				' BUG: Implementieren
			End Sub

			''' <summary>
			''' add group (name)
			''' </summary>
			Public Sub AddGroup(ByVal Name As String)
				' BUG: Implementieren
			End Sub

			''' <summary>
			''' remove all properties
			''' </summary>
			Public Sub Clear()
				' BUG: Implementieren
			End Sub

			''' <summary>
			''' Reset performence data
			''' </summary>
			Public Sub ClearData()
				' BUG: Implementieren
			End Sub

			''' <summary>
			''' remove property (index)
			''' </summary>
			Public Sub Remove(ByVal Index As String)
				'BUG: Implementieren
			End Sub

			''' <summary>
			''' remove group (index)
			''' </summary>
			Public Sub RemoveGroup(ByVal Index As String)
				' BUG: Implementieren
			End Sub

			''' <summary>
			''' Aging time
			''' </summary>
			''' <value>0 bis 10.000</value>
			Public Property Aging() As Integer
				Get
					Return Me.mAging
				End Get

				Set(ByVal value As Integer)
					If value >= 0 And value <= 10000 Then
						Me.mAging = value
					Else
						Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 10000 liegen.")
					End If
				End Set
			End Property

			''' <summary>
			''' Gene pool capacity
			''' </summary>
			''' <value>0 bis 2.000</value>
			Public Property Capacity() As Integer
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
			Public Property ChangedProperty() As Integer
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
			Public Property ChangedPropertyId() As String
				Get
					Return Me.mChangedPropertyId
				End Get

				Set(ByVal PropertyId As String)
					Me.mChangedPropertyId = PropertyId
				End Set
			End Property

			''' <summary>
			''' Constant
			''' </summary>
			''' <value>floating point
			''' -10.000 bis 10.000</value>
			Public Property Cr_c() As Double
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
			''' <value>floating point
			'''  -10000 bis 10000</value>
			Public Property Cr_di() As Double
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
			''' <value>floating point
			''' -10000 bis 10000</value>
			Public Property Cr_gl() As Double
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
			''' <value>floating point
			''' -10000 bis 10000</value>
			Public Property Cr_joints() As Double
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
			''' <value>floating point
			''' -10000 bis 10000</value>
			Public Property Cr_life() As Double
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
			''' <value>floating point
			''' -10000 bis 10000</value>
			Public Property Cr_nncon() As Double
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
			''' <value>floating point
			''' -10000 bis 10000</value>
			Public Property Cr_nnsiz() As Double
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
			Public Property Cr_norm() As Boolean
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
			Public Property Cr_simi() As Boolean
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
			''' <value>floating point
			''' -10000 bis 10000</value>
			Public Property Cr_v() As Double
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
			''' <value>floating point
			''' -10000 bis 10000</value>
			Public Property Cr_vpos() As Double
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
			''' <value>floating point
			''' -10000 bis 10000</value>
			Public Property Cr_vvel() As Double
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
			''' Creation height
			''' </summary>
			''' <value>floating point
			''' -1 bis 50</value>
			Public Property Creath() As Double
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
			''' Delete genotypes
			''' </summary>
			''' <remarks>0=Randomly
			''' 1=Inverse-proportionally to fitness
			''' 2=Only the worst</remarks>
			''' <value>0 bis 2</value>
			Public Property Delrule() As Integer
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
			''' <value>floating point
			''' 0 bis 1</value>
			Public Property E_meta() As Double
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
			''' <value>floating point
			''' 0 bis 10000</value>
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
			''' Automatic feeding
			''' </summary>
			''' <value>0 bis 100</value>
			Public Property Feed() As Integer
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
			''' <value>floating point
			''' 0 bis 1000</value>
			Public Property Feede0() As Double
				Get
					Return Me.mFeede0
				End Get

				Set(ByVal value As Double)
					If value >= 0 And value <= 1000 Then
						Me.mFeede0 = value
					Else
						Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1000 liegen.")
					End If
				End Set
			End Property

			''' <summary>
			''' Ingestion multiplier
			''' </summary>
			''' <value>flaoting point
			''' 0 bis 100</value>
			Public Property Feedtrans() As Double
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
			''' Food's genotype
			''' </summary>
			Public Property Foodgen() As String
				Get
					Return Me.mFoodgen
				End Get

				Set(ByVal value As String)
					Me.mFoodgen = value
				End Set
			End Property

			''' <summary>
			''' Initial genotype
			''' </summary>
			Public Property Initialgen() As String
				Get
					Return Me.mInitialgen
				End Get

				Set(ByVal value As String)
					Me.mInitialgen = value
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
			''' Mutated
			''' </summary>
			''' <value>floating point
			''' 0 bis 100</value>
			Public Property P_mut() As Double
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
			''' <value>floating point
			''' 0 bis 100</value>
			Public Property P_nop() As Double
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
			''' <value>floating point
			''' 0 bis 100</value>
			Public Property P_xov() As Double
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
			''' <remarks>0= Random
			''' 1= Central</remarks>
			''' <value>0 bis 1</value>
			Public Property Placement() As Integer
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
			''' Selection rule
			''' </summary>
			''' <remarks>0=Random
			''' 1=Fitness-proportional (roulette)
			''' 2=Tournament (2 genotype)
			''' 3=Tournament (3 genotype)
			''' 4=Tournament (4 genotype)
			''' 5=Tournament (5 genotype)</remarks>
			''' <value>0 bis 5</value>
			Public Property Selrule() As Integer
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
			''' Minimal similarity
			''' </summary>
			''' <value>floating point 0..9999</value>
			Public Property Xov_mins() As Double
				Get
					Return Me.mXov_mins
				End Get

				Set(ByVal value As Double)
					Me.mXov_mins = value
				End Set
			End Property
		End Class

	End Namespace

End Namespace
