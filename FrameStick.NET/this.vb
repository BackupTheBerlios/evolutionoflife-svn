Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace FitnessFormula

			''' <summary>
			''' A Genotype with the associated performance information. See also: Genotype, GenotypeGroup as
			''' described in GenotypeLibrary.
			''' </summary>
			Public Class this

				''' <summary>
				''' Conversion backtrace [1]
				''' </summary>
				Private mConvtrace1 As String

				''' <summary>
				''' Conversion backtrace [1]
				''' </summary>
				Public Property convtrace1() As String
					Get
						Return Me.mConvtrace1
					End Get

					Set(ByVal value As String)
						Me.mConvtrace1 = value
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
				''' f0 genotype
				''' </summary>
				''' <remarks>converted to f0 genotype</remarks>
				Private mF0genotype As String

				''' <summary>
				''' f0 genotype
				''' </summary>
				''' <remarks>converted to f0 genotype</remarks>
				Public Property f0genotype() As String
					Get
						Return Me.mF0genotype
					End Get

					Set(ByVal value As String)
						Me.mF0genotype = value
					End Set
				End Property

				''' <summary>
				''' Fitness
				''' </summary>
				Private mFit As Double

				''' <summary>
				''' Fitness
				''' </summary>
				Public Property fit() As Double
					Get
						Return Me.mFit
					End Get

					Set(ByVal value As Double)
						Me.mFit = value
					End Set
				End Property

				''' <summary>
				''' Final fitness
				''' </summary>
				''' <remarks>Fitnes shifted by (avg-n*stddev)</remarks>
				Private mFit2 As Double

				''' <summary>
				''' Final fitness
				''' </summary>
				''' <remarks>Fitnes shifted by (avg-n*stddev)</remarks>
				Public Property fit2() As Double
					Get
						Return Me.mFit2
					End Get

					Set(ByVal value As Double)
						Me.mFit2 = value
					End Set
				End Property

				''' <summary>
				''' Geno
				''' </summary>
				''' <remarks>Geno object for this Genotype</remarks>
				Private mGeno As FrameStick.GlobalContext.Geno

				''' <summary>
				''' Geno
				''' </summary>
				''' <remarks>Geno object for this Genotype</remarks>
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
				''' Info
				''' </summary>
				''' <remarks>Additional information or
				''' comments</remarks>
				Private mInfo As String

				''' <summary>
				''' Info
				''' </summary>
				''' <remarks>Additional information or
				''' comments</remarks>
				Public Property info() As String
					Get
						Return Me.mInfo
					End Get

					Set(ByVal value As String)
						Me.mInfo = value
					End Set
				End Property

				''' <summary>
				''' Valid
				''' </summary>
				Private mIsValid As Boolean

				''' <summary>
				''' Valid
				''' </summary>
				Public Property isValid() As Boolean
					Get
						Return Me.mIsValid
					End Get

					Set(ByVal value As Boolean)
						Me.mIsValid = value
					End Set
				End Property

				''' <summary>
				''' Life span
				''' </summary>
				''' <remarks>Average life span</remarks>
				Private mLifespan As Double

				''' <summary>
				''' Life span
				''' </summary>
				''' <remarks>Average life span</remarks>
				Public Property lifespan() As Double
					Get
						Return Me.mLifespan
					End Get

					Set(ByVal value As Double)
						Me.mLifespan = value
					End Set
				End Property

				''' <summary>
				''' Name
				''' </summary>
				Private mName As String

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
				''' Brain connections
				''' </summary>
				Private mNncon As Double

				''' <summary>
				''' Brain size
				''' </summary>
				Private mNnsiz As Double

				''' <summary>
				''' Ordinal number
				''' </summary>
				Private mNum As Integer

				''' <summary>
				''' Instances
				''' </summary>
				Private mPopsiz As Integer

				''' <summary>
				''' Similarity
				''' </summary>
				Private mSimi As Double

				''' <summary>
				''' Body joints
				''' </summary>
				Private mStrjoints As Double

				''' <summary>
				''' Body parts
				''' </summary>
				Private mStrsiz As Double

				''' <summary>
				''' Brain connections
				''' </summary>
				Public Property nncon() As Double
					Get
						Return Me.mNncon
					End Get

					Set(ByVal value As Double)
						Me.mNncon = value
					End Set
				End Property

				''' <summary>
				''' Brain size
				''' </summary>
				Public Property nnsiz() As Double
					Get
						Return Me.mNnsiz
					End Get

					Set(ByVal value As Double)
						Me.mNnsiz = value
					End Set
				End Property

				''' <summary>
				''' Ordinal number
				''' </summary>
				Public Property num() As Integer
					Get
						Return Me.mNum
					End Get

					Set(ByVal value As Integer)
						Me.mNum = value
					End Set
				End Property

				''' <summary>
				''' Instances
				''' </summary>
				Public Property popsiz() As Integer
					Get
						Return Me.mPopsiz
					End Get

					Set(ByVal value As Integer)
						Me.mPopsiz = value
					End Set
				End Property

				''' <summary>
				''' Similarity
				''' </summary>
				Public Property simi() As Double
					Get
						Return Me.mSimi
					End Get

					Set(ByVal value As Double)
						Me.mSimi = value
					End Set
				End Property

				''' <summary>
				''' Body joints
				''' </summary>
				Public Property strjoints() As Double
					Get
						Return Me.mStrjoints
					End Get

					Set(ByVal value As Double)
						Me.mStrjoints = value
					End Set
				End Property

				''' <summary>
				''' Body parts
				''' </summary>
				Public Property strsiz() As Double
					Get
						Return Me.mStrsiz
					End Get

					Set(ByVal value As Double)
						Me.mStrsiz = value
					End Set
				End Property

				''' <summary>
				''' #
				''' </summary>
				''' <remarks>Unique identifier</remarks>
				Private mUid As String

				''' <summary>
				''' User field 1
				''' </summary>
				''' <remarks>untyped field</remarks>
				Private mUser1 As Object

				''' <summary>
				''' User filed 2
				''' </summary>
				''' <remarks>untyped field</remarks>
				Private mUser2 As Object

				''' <summary>
				''' User field 3
				''' </summary>
				''' <remarks>untyped field</remarks>
				Private mUser3 As Object

				''' <summary>
				''' Velocity
				''' </summary>
				''' <remarks>Average velocity</remarks>
				Private mVelocity As Double

				''' <summary>
				''' Vertical position
				''' </summary>
				Private mVertpos As Double

				''' <summary>
				''' Vertical velocity
				''' </summary>
				Private mVertvel As Double

				''' <summary>
				''' #
				''' </summary>
				''' <remarks>Unique identifier</remarks>
				Public Property uid() As String
					Get
						Return Me.mUid
					End Get

					Set(ByVal value As String)
						Me.mUid = value
					End Set
				End Property

				''' <summary>
				''' User filed 1
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
				''' User filed 2
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
				''' Velocity
				''' </summary>
				''' <remarks>Average velocity</remarks>
				Public Property velocity() As Double
					Get
						Return Me.mVelocity
					End Get

					Set(ByVal value As Double)
						Me.mVelocity = value
					End Set
				End Property

				''' <summary>
				''' Vertical position
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
				''' Vertical velocity
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
				''' get normalized property
				''' </summary>
				Public Function getNormalized(ByVal name As String) As Double
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' get normalized property
				''' </summary>
				Public Function getNormalized(ByVal index As Integer) As Double
					' BUG: Implementieren
					Return Nothing
				End Function

				''' <summary>
				''' Mutate
				''' </summary>
				Public Sub mutate()
					' BUG: Implementieren
				End Sub
			End Class

		End Namespace

	End Namespace

End Namespace
