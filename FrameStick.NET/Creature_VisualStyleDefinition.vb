Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace VisualStyleDefinition

			''' <summary>
			''' The object inside the simulated world, including its physical structure, neural network and performance
			''' data. Food pieces, obstacles and other movable objects can be implemented as Creatures even though
			''' the are not "alive". See also: CreaturesGroup.
			''' </summary>
			Public Class Creature

				''' <summary>
				''' Velocity
				''' </summary>
				Private mC_velocity As Double

				''' <summary>
				''' Velocity
				''' </summary>
				Public Property c_velocity() As Double
					Get
						Return Me.mC_velocity
					End Get

					Set(ByVal value As Double)
						Me.mC_velocity = value
					End Set
				End Property
				''' <summary>
				''' Vertical position
				''' </summary>
				Private mC_vertpos As Double

				''' <summary>
				''' Vertical position
				''' </summary>
				Public Property c_vertpos() As Double
					Get
						Return Me.mC_vertpos
					End Get

					Set(ByVal value As Double)
						Me.mC_vertpos = value
					End Set
				End Property

				''' <summary>
				''' Vertical velocity
				''' </summary>
				Private mC_vertvelocity As Double

				''' <summary>
				''' Vertical velocity
				''' </summary>
				Public Property c_vertvelocity() As Double
					Get
						Return Me.mC_vertvelocity
					End Get

					Set(ByVal value As Double)
						Me.mC_vertvelocity = value
					End Set
				End Property

				''' <summary>
				''' center.x
				''' </summary>
				Private mCenter_x As Double

				''' <summary>
				''' center.y
				''' </summary>
				Private mCenter_y As Double

				''' <summary>
				''' center.z
				''' </summary>
				Private mCenter_z As Double

				''' <summary>
				''' center.x
				''' </summary>
				Public Property center_x() As Double
					Get
						Return Me.mCenter_x
					End Get

					Set(ByVal value As Double)
						Me.mCenter_x = value
					End Set
				End Property

				''' <summary>
				''' center.y
				''' </summary>
				Public Property center_y() As Double
					Get
						Return Me.mCenter_y
					End Get

					Set(ByVal value As Double)
						Me.mCenter_y = value
					End Set
				End Property

				''' <summary>
				''' center.z
				''' </summary>
				Public Property center_z() As Double
					Get
						Return Me.mCenter_z
					End Get

					Set(ByVal value As Double)
						Me.mCenter_z = value
					End Set
				End Property

				''' <summary>
				''' Distance
				''' </summary>
				Private mDistance As Double

				''' <summary>
				''' Distance
				''' </summary>
				Public Property distance() As Double
					Get
						Return Me.mDistance
					End Get

					Set(ByVal value As Double)
						Me.mDistance = value
					End Set
				End Property

				''' <summary>
				''' Starting energy
				''' </summary>
				Private mEnerg0 As Double

				''' <summary>
				''' Starting energy
				''' </summary>
				Public Property energ0() As Double
					Get
						Return Me.mEnerg0
					End Get

					Set(ByVal value As Double)
						Me.mEnerg0 = value
					End Set
				End Property

				''' <summary>
				''' Energy
				''' </summary>
				Private mEnergy As Double

				''' <summary>
				''' Energy
				''' </summary>
				Public Property energy() As Double
					Get
						Return Me.mEnergy
					End Get

					Set(ByVal value As Double)
						Me.mEnergy = value
					End Set
				End Property

				''' <summary>
				''' Energy balance
				''' </summary>
				Private mEnergy_b As Double

				''' <summary>
				''' Energy balance
				''' </summary>
				Public Property energy_b() As Double
					Get
						Return Me.mEnergy_b
					End Get

					Set(ByVal value As Double)
						Me.mEnergy_b = value
					End Set
				End Property

				''' <summary>
				''' Energy costs
				''' </summary>
				Private mEnergy_m As Double

				''' <summary>
				''' Energy costs
				''' </summary>
				Public Property energy_m() As Double
					Get
						Return Me.mEnergy_m
					End Get

					Set(ByVal value As Double)
						Me.mEnergy_m = value
					End Set
				End Property

				''' <summary>
				''' Energy income
				''' </summary>
				Private mEnergy_p As Double

				''' <summary>
				''' Energy income
				''' </summary>
				Public Property energy_p() As Double
					Get
						Return Me.mEnergy_p
					End Get

					Set(ByVal value As Double)
						Me.mEnergy_p = value
					End Set
				End Property

				''' <summary>
				''' geno
				''' </summary>
				Private mGeno As FrameStick.GlobalContext.Geno

				''' <summary>
				''' geno
				''' </summary>
				Public Property geno() As FrameStick.GlobalContext.Geno
					Get
						Return Me.mGeno
					End Get

					Set(ByVal value As FrameStick.GlobalContext.Geno)
						Me.mGeno = value
					End Set
				End Property

				''' <summary>
				''' Genotype
				''' </summary>
				Private mGenotype As String

				''' <summary>
				''' Genotype
				''' </summary>
				Public Property genotype() As String
					Get
						Return Me.mGenotype
					End Get

					Set(ByVal value As String)
						Me.mGenotype = value
					End Set
				End Property

				''' <summary>
				''' Generation
				''' </summary>
				Private mGnum As Integer

				''' <summary>
				''' group
				''' </summary>
				Private mGroup As Object

				''' <summary>
				''' Idle power consumption
				''' </summary>
				Private mIdleen As Double

				''' <summary>
				''' Info
				''' </summary>
				''' <remarks>Additional Information or Comments</remarks>
				Private mInfo As String

				''' <summary>
				''' Life span
				''' </summary>
				Private mLifespan As Integer

				''' <summary>
				''' model
				''' </summary>
				Private mModel As FrameStick.GlobalContext.Model

				''' <summary>
				''' Name
				''' </summary>
				Private mName As String

				''' <summary>
				''' NN enabled
				''' </summary>
				Private mNnenabled As Boolean

				''' <summary>
				''' number of joints
				''' </summary>
				Private mNumjoints As Integer

				''' <summary>
				''' Generation
				''' </summary>
				Public Property gnum() As Integer
					Get
						Return Me.mGnum
					End Get

					Set(ByVal value As Integer)
						Me.mGnum = value
					End Set
				End Property

				''' <summary>
				''' group
				''' </summary>
				Public Property group() As Object
					Get
						Return Me.mGroup
					End Get

					Set(ByVal value As Object)
						Me.mGroup = value
					End Set
				End Property

				''' <summary>
				''' Idle power consumption
				''' </summary>
				Public Property idleen() As Double
					Get
						Return Me.mIdleen
					End Get

					Set(ByVal value As Double)
						Me.mIdleen = value
					End Set
				End Property

				''' <summary>
				''' Info
				''' </summary>
				''' <remarks>Additional Information or Comments</remarks>
				Public Property info() As String
					Get
						Return Me.mInfo
					End Get

					Set(ByVal value As String)
						Me.mInfo = value
					End Set
				End Property

				''' <summary>
				''' Life span
				''' </summary>
				Public Property lifespan() As Integer
					Get
						Return Me.mLifespan
					End Get

					Set(ByVal value As Integer)
						Me.mLifespan = value
					End Set
				End Property

				''' <summary>
				''' model
				''' </summary>
				Public Property model() As FrameStick.GlobalContext.Model
					Get
						Return Me.mModel
					End Get

					Set(ByVal value As FrameStick.GlobalContext.Model)
						Me.mModel = value
					End Set
				End Property

				''' <summary>
				''' Name
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
				''' NN enabled
				''' </summary>
				Public Property nnenabled() As Boolean
					Get
						Return Me.mNnenabled
					End Get

					Set(ByVal value As Boolean)
						Me.mNnenabled = value
					End Set
				End Property

				''' <summary>
				''' number of joints
				''' </summary>
				Public Property numjoints() As Integer
					Get
						Return Me.mNumjoints
					End Get

					Set(ByVal value As Integer)
						Me.mNumjoints = value
					End Set
				End Property

				''' <summary>
				''' number of neurons
				''' </summary>
				Private mNumneurons As Integer

				''' <summary>
				''' number of parts
				''' </summary>
				Private mNumparts As Integer

				''' <summary>
				''' Performance calculation
				''' </summary>
				''' <remarks>0 bis 2
				''' 
				''' 0 = Off
				''' 1 = On
				''' 2 = Waiting for freeze</remarks>
				Private mPerf As Integer

				''' <summary>
				''' position.x
				''' </summary>
				Private mPos_x As Double

				''' <summary>
				''' position.y
				''' </summary>
				Private mPos_y As Double

				''' <summary>
				''' position.z
				''' </summary>
				Private mPos_z As Double

				''' <summary>
				''' size.x
				''' </summary>
				Private mSize_x As Double

				''' <summary>
				''' size.y
				''' </summary>
				Private mSize_y As Double

				''' <summary>
				''' size.z
				''' </summary>
				Private mSize_z As Double

				''' <summary>
				''' #
				''' </summary>
				Private mUid As String

				''' <summary>
				''' number of neurons
				''' </summary>
				Public Property numneurons() As Integer
					Get
						Return Me.mNumneurons
					End Get

					Set(ByVal value As Integer)
						Me.mNumneurons = value
					End Set
				End Property

				''' <summary>
				''' number of parts
				''' </summary>
				Public Property numparts() As Integer
					Get
						Return Me.mNumparts
					End Get

					Set(ByVal value As Integer)
						Me.mNumparts = value
					End Set
				End Property

				''' <summary>
				''' Performance Calculation
				''' </summary>
				''' <value>0 bis 2
				''' 
				''' 0 = Off
				''' 1 = On
				''' 2 = Waiting for freeze</value>
				Public Property perf() As Integer
					Get
						Return Me.mPerf
					End Get

					Set(ByVal value As Integer)
						If value >= 0 And value <= 2 Then
							Me.mPerf = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' position.x
				''' </summary>
				Public Property pos_x() As Double
					Get
						Return Me.mPos_x
					End Get

					Set(ByVal value As Double)
						Me.mPos_x = value
					End Set
				End Property

				''' <summary>
				''' position.y
				''' </summary>
				Public Property pos_y() As Double
					Get
						Return Me.mPos_y
					End Get

					Set(ByVal value As Double)
						Me.mPos_y = value
					End Set
				End Property

				''' <summary>
				''' position.z
				''' </summary>
				Public Property pos_z() As Double
					Get
						Return Me.mPos_z
					End Get

					Set(ByVal value As Double)
						Me.mPos_z = value
					End Set
				End Property

				''' <summary>
				''' size.x
				''' </summary>
				Public Property size_x() As Double
					Get
						Return Me.mSize_x
					End Get

					Set(ByVal value As Double)
						Me.mSize_x = value
					End Set
				End Property

				''' <summary>
				''' size.y
				''' </summary>
				Public Property size_y() As Double
					Get
						Return Me.mSize_y
					End Get

					Set(ByVal value As Double)
						Me.mSize_y = value
					End Set
				End Property

				''' <summary>
				''' size.z
				''' </summary>
				Public Property size_z() As Double
					Get
						Return Me.mSize_z
					End Get

					Set(ByVal value As Double)
						Me.mSize_z = value
					End Set
				End Property

				''' <summary>
				''' #
				''' </summary>
				Public Property uid() As String
					Get
						Return Me.mUid
					End Get

					Set(ByVal value As String)
						Me.mUid = value
					End Set
				End Property

				''' <summary>
				''' User field 1
				''' </summary>
				''' <remarks>untyped field</remarks>
				Private mUser1 As Object

				''' <summary>
				''' User field 2
				''' </summary>
				''' <remarks>untyped field</remarks>
				Private mUser2 As Object

				''' <summary>
				''' User filed 3
				''' </summary>
				''' <remarks>untyped field</remarks>
				Private mUser3 As Object

				''' <summary>
				''' Avg.velocity
				''' </summary>
				Private mVelocity As Double

				''' <summary>
				''' Avg.vertical position
				''' </summary>
				Private mVertpos As Double

				''' <summary>
				''' Avg.vertical velocity
				''' </summary>
				Private mVertvel As Double

				''' <summary>
				''' User field 1
				''' </summary>
				''' <value>untyped field</value>
				Public Property user1() As Object
					Get
						Return Me.mUser1
					End Get

					Set(ByVal value As Object)
						Me.mUser1 = value
					End Set
				End Property

				''' <summary>
				''' User field 2
				''' </summary>
				''' <value>untyped field</value>
				Public Property user2() As Object
					Get
						Return Me.mUser2
					End Get

					Set(ByVal value As Object)
						Me.mUser2 = value
					End Set
				End Property

				''' <summary>
				''' User filed 3
				''' </summary>
				''' <value>untyped field</value>
				Public Property user3() As Object
					Get
						Return Me.mUser3
					End Get

					Set(ByVal value As Object)
						Me.mUser3 = value
					End Set
				End Property

				''' <summary>
				''' Avg.velocity
				''' </summary>
				Public Property velocity() As Double
					Get
						Return Me.mVelocity
					End Get

					Set(ByVal value As Double)
						Me.mVelocity = value
					End Set
				End Property

				''' <summary>
				''' Avg.vertical position
				''' </summary>
				Public Property vertpos() As Double
					Get
						Return Me.mVertpos
					End Get

					Set(ByVal value As Double)
						Me.mVertpos = value
					End Set
				End Property

				''' <summary>
				''' Avg.vertical velocity
				''' </summary>
				Public Property vertvel() As Double
					Get
						Return Me.mVertvel
					End Get

					Set(ByVal value As Double)
						Me.mVertvel = value
					End Set
				End Property

				''' <summary>
				''' currentGeometryAsF0
				''' </summary>
				Public Function currentGeometryAsF0() As String
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' getJoint (static model information)
				''' </summary>
				Public Function getJoint(ByVal index As Integer) As FrameStick.GlobalContext.Joint
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' getMechJoint (current properties)
				''' </summary>
				Public Function getMechJoint(ByVal index As Integer) As FrameStick.GlobalContext.MechJoint
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' getMechPart (current properties)
				''' </summary>
				Public Function getMechPart(ByVal index As Integer) As FrameStick.GlobalContext.MechPart
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' getNeuro
				''' </summary>
				Public Function getNeuro(ByVal index As Integer) As FrameStick.GlobalContext.Neuro
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' getNeuroDef
				''' </summary>
				Public Function getNeuroDef(ByVal index As Integer) As FrameStick.GlobalContext.NeuroDef
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' getPart (static model information)
				''' </summary>
				Public Function getPart(ByVal index As Integer) As FrameStick.GlobalContext.Part
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' move
				''' </summary>
				Public Sub move(ByVal x As Double, ByVal y As Double, ByVal z As Double)
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' move to absolute location
				''' </summary>
				Public Sub moveAbs(ByVal x As Double, ByVal y As Double, ByVal z As Double)
					' BUG: Implementieren
				End Sub
			End Class

		End Namespace

	End Namespace

End Namespace
