Namespace GlobalContext

Public Class Part

		''' <summary>
		''' assimilation
		''' </summary>
		''' <remarks>floatin point
		''' 0..1</remarks>
		Private mAs As Double

		''' <summary>
		''' density
		''' </summary>
		''' <remarks>floating point
		''' 0,2..5</remarks>
		Private mDn As Double

		''' <summary>
		''' friction
		''' </summary>
		''' <remarks>floating point
		''' 0..4</remarks>
		Private mFr As Double

		''' <summary>
		''' info
		''' </summary>
		Private mI As String

		''' <summary>
		''' ingestion
		''' </summary>
		''' <remarks>floating point
		''' 0..1</remarks>
		Private mIng As Double

		''' <summary>
		''' mass
		''' </summary>
		''' <remarks>floating point
		''' 0,1...999</remarks>
		Private mM As Double

		''' <summary>
		''' rot.x
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mRx As Double

		''' <summary>
		''' rot.y
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mRy As Double

		''' <summary>
		''' rot.z
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mRz As Double

		''' <summary>
		''' size
		''' </summary>
		''' <remarks>ffloating point
		''' 0,1...10</remarks>
		Private mS As Double

		''' <summary>
		''' vis_style
		''' </summary>
		Private mVstyle As String

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
		''' assimilation
		''' </summary>
		''' <remarks>eigendlich 'as', aber ist ja schon belegt</remarks>
		''' <value>floating point
		''' 0 bis 1</value>
		Public Property assimilation() As Double
			Get
				Return Me.mAs
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 1 Then
					Me.mAs = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' density
		''' </summary>
		''' <value>floating point
		''' 0,2 bis 5</value>
		Public Property dn() As Double
			Get
				Return Me.mDn
			End Get

			Set(ByVal value As Double)
				If value >= 0.2 And value <= 5 Then
					Me.mDn = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0,2 und 5 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' friction
		''' </summary>
		''' <value>floating point
		''' 0 bis 4</value>
		Public Property fr() As Double
			Get
				Return Me.mFr
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 4 Then
					Me.mFr = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 4 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Info
		''' </summary>
		Public Property i() As String
			Get
				Return Me.mI
			End Get

			Set(ByVal value As String)
				Me.mI = value
			End Set
		End Property

		''' <summary>
		''' ingestion
		''' </summary>
		''' <value>floating point
		''' 0 bis 1</value>
		Public Property ing() As Double
			Get
				Return Me.mIng
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 1 Then
					Me.mIng = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' mass
		''' </summary>
		''' <value>floating point
		''' 0,1 bis 999</value>
		Public Property m() As Double
			Get
				Return Me.mM
			End Get

			Set(ByVal value As Double)
				If value >= 0.1 And value <= 999 Then
					Me.mM = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0,1 und 999 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' rot.x
		''' </summary>
		''' <value>floating point</value>
		Public Property rx() As Double
			Get
				Return Me.mRx
			End Get

			Set(ByVal value As Double)
				Me.mRx = value
			End Set
		End Property

		''' <summary>
		''' rot.y
		''' </summary>
		''' <value>floating point</value>
		Public Property ry() As Double
			Get
				Return Me.mRy
			End Get

			Set(ByVal value As Double)
				Me.mRy = value
			End Set
		End Property

		''' <summary>
		''' rot.z
		''' </summary>
		''' <value>floating point</value>
		Public Property rz() As Double
			Get
				Return Me.mRz
			End Get

			Set(ByVal value As Double)
				Me.mRz = value
			End Set
		End Property

		''' <summary>
		''' size
		''' </summary>
		''' <value>floating point
		''' 0,1 bis 10</value>
		Public Property s() As Double
			Get
				Return Me.mS
			End Get

			Set(ByVal value As Double)
				If value >= 0.1 And value <= 10 Then
					Me.mS = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0,1 und 10 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' v_style
		''' </summary>
		Public Property Vstyle() As String
			Get
				Return Me.mVstyle
			End Get

			Set(ByVal value As String)
				Me.mVstyle = value
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
