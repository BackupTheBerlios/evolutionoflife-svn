Namespace GlobalContext

Public Class MechJoint

		''' <summary>
		''' delta.x
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mDx As Double

		''' <summary>
		''' delta.y
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mDy As Double

		''' <summary>
		''' delta.z
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mDz As Double

		''' <summary>
		''' rotation stiffness
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mRotstif As Double

		''' <summary>
		''' rotation.x
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mRx As Double

		''' <summary>
		''' rotation.y
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mRy As Double

		''' <summary>
		''' rotation.z
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mRz As Double

		''' <summary>
		''' stiffness
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mStif As Double

		''' <summary>
		''' delta.x
		''' </summary>
		''' <value>floating point</value>
		Public Property dx() As Double
			Get
				Return Me.mDx
			End Get

			Set(ByVal value As Double)
				Me.mDx = value
			End Set
		End Property

		''' <summary>
		''' delta.y
		''' </summary>
		''' <value>floating point</value>
		Public Property dy() As Double
			Get
				Return Me.mDy
			End Get

			Set(ByVal value As Double)
				Me.mDy = value
			End Set
		End Property

		''' <summary>
		''' delta.z
		''' </summary>
		''' <value>floating point</value>
		Public Property dz() As Double
			Get
				Return Me.mDz
			End Get

			Set(ByVal value As Double)
				Me.mDz = value
			End Set
		End Property

		''' <summary>
		''' rotation stiffness
		''' </summary>
		''' <value>floating point</value>
		Public Property rotstif() As Double
			Get
				Return Me.mRotstif
			End Get

			Set(ByVal value As Double)
				Me.mRotstif = value
			End Set
		End Property

		''' <summary>
		''' rotation.x
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
		''' rotation.y
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
		''' rotation.z
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
		''' stiffness
		''' </summary>
		''' <value>floating point</value>
		Public Property stif() As Double
			Get
				Return Me.mStif
			End Get

			Set(ByVal value As Double)
				Me.mStif = value
			End Set
		End Property
	End Class

End Namespace
