Namespace GlobalContext

	Public Class Model

		''' <summary>
		''' geno
		''' </summary>
		Private mGeno As FrameStick.GlobalContext.Geno

		''' <summary>
		''' number of joint
		''' </summary>
		Private mNumjoints As Integer

		''' <summary>
		''' number of neurons
		''' </summary>
		Private mNumneurons As Integer

		''' <summary>
		''' number of parts
		''' </summary>
		Private mNumparts As Integer

		''' <summary>
		''' startenergy
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mSe As Double

		''' <summary>
		''' bounding box x size
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mSize_x As Double

		''' <summary>
		''' bounding box y size
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mSize_y As Double

		''' <summary>
		''' bounding box z
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mSize_z As Double

		''' <summary>
		''' vis_style
		''' </summary>
		Private mVstyle As String

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
		''' startenergy
		''' </summary>
		''' <value>floating point</value>
		Public Property se() As Double
			Get
				Return Me.mSe
			End Get

			Set(ByVal value As Double)
				Me.mSe = value
			End Set
		End Property

		''' <summary>
		''' bounding box x size
		''' </summary>
		''' <value>floating point</value>
		Public Property size_x() As Double
			Get
				Return Me.mSize_x
			End Get

			Set(ByVal value As Double)
				Me.mSize_x = value
			End Set
		End Property

		''' <summary>
		''' bounding box y size
		''' </summary>
		''' <value>floating point</value>
		Public Property size_y() As Double
			Get
				Return Me.mSize_y
			End Get

			Set(ByVal value As Double)
				Me.mSize_y = value
			End Set
		End Property

		''' <summary>
		''' bounding box z size
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
		''' vis_style
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
		''' getJoint (stytic model information)
		''' </summary>
		Public Function getJoint(ByVal index As Integer) As FrameStick.GlobalContext.Joint
			' BUG Rückgabewert fehlt
			Return New FrameStick.GlobalContext.Joint
		End Function

		''' <summary>
		''' getNeuroDef
		''' </summary>
		Public Function getNeuroDef(ByVal index As Integer) As FrameStick.GlobalContext.NeuroDef
			' BUG Rückgabewert fehlt
			Return Nothing
		End Function

		''' <summary>
		''' getPart (stytic model information)
		''' </summary>
		Public Function getPart(ByVal index As Integer) As FrameStick.GlobalContext.Part
			' BUG Rückgabewert fehlt
			Return Nothing
		End Function

		''' <summary>
		''' create new object
		''' </summary>
		Public Function newFromGeno(ByVal geno As FrameStick.GlobalContext.Geno) As FrameStick.GlobalContext.Model
			' BUG Rückgabewert fehlt
			Return Nothing
		End Function

		''' <summary>
		''' create new object
		''' </summary>
		Public Function newFromString(ByVal genotype As String) As FrameStick.GlobalContext.Model
			' BUG Rückgabewert fehlt
			Return Nothing
		End Function

	End Class

End Namespace