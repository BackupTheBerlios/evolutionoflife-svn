Namespace GlobalContext

Public Class MechPart

		''' <summary>
		''' friction
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mFr As Double

		''' <summary>
		''' mass
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mM As Double

		''' <summary>
		''' size
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mS As Double

		''' <summary>
		''' volume
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mVol As Double

		''' <summary>
		''' velocity.x
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mVx As Double

		''' <summary>
		''' velocity.y
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mVy As Double

		''' <summary>
		''' velocity.z
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mVz As Double

		''' <summary>
		''' position.x
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mX As Double

		''' <summary>
		''' position.y
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mY As Double

		''' <summary>
		''' position.z
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mZ As Double

		''' <summary>
		''' friction
		''' </summary>
		''' <value>floating point</value>
		Public Property fr() As Double
			Get
				Return Me.mFr
			End Get

			Set(ByVal value As Double)
				Me.mFr = value
			End Set
		End Property

		''' <summary>
		''' mass
		''' </summary>
		''' <value>floating point</value>
		Public Property m() As Double
			Get
				Return Me.mM
			End Get

			Set(ByVal value As Double)
				Me.mM = value
			End Set
		End Property

		''' <summary>
		''' size
		''' </summary>
		''' <value>floating point</value>
		Public Property s() As Double
			Get
				Return Me.mS
			End Get

			Set(ByVal value As Double)
				Me.mS = value
			End Set
		End Property

		''' <summary>
		''' volume
		''' </summary>
		''' <value>floating point</value>
		Public Property vol() As Double
			Get
				Return Me.mVol
			End Get

			Set(ByVal value As Double)
				Me.mVol = value
			End Set
		End Property

		''' <summary>
		''' velocity.x
		''' </summary>
		''' <value>floating point</value>
		Public Property vx() As Double
			Get
				Return Me.mVx
			End Get

			Set(ByVal value As Double)
				Me.mVx = value
			End Set
		End Property

		''' <summary>
		''' velocity.y
		''' </summary>
		''' <value>floating point</value>
		Public Property vy() As Double
			Get
				Return Me.mVy
			End Get

			Set(ByVal value As Double)
				Me.mVy = value
			End Set
		End Property

		''' <summary>
		''' velocity.z
		''' </summary>
		''' <value>floating point</value>
		Public Property vz() As Double
			Get
				Return Me.mVz
			End Get

			Set(ByVal value As Double)
				Me.mVz = value
			End Set
		End Property

		''' <summary>
		''' position.x
		''' </summary>
		''' <value>floating point</value>
		Public Property x() As Double
			Get
				Return Me.mX
			End Get

			Set(ByVal value As Double)
				Me.mX = value
			End Set
		End Property

		''' <summary>
		''' position.y
		''' </summary>
		''' <value>floating point</value>
		Public Property y() As Double
			Get
				Return Me.mY
			End Get

			Set(ByVal value As Double)
				Me.mY = value
			End Set
		End Property

		''' <summary>
		''' position.z
		''' </summary>
		''' <value>floating point</value>
		Public Property z() As Double
			Get
				Return Me.mZ
			End Get

			Set(ByVal value As Double)
				Me.mZ = value
			End Set
		End Property
	End Class

End Namespace
