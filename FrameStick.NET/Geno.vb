Namespace GlobalContext

	''' <summary>
	''' All information about a single genotype
	''' </summary>
	''' <remarks>This is a genetics-only object does not contain any performance data. See also Genotype Class</remarks>
	Public Class Geno

		''' <summary>
		''' Autogenerated name
		''' </summary>
		''' <remarks></remarks>
		Private mAutoName As String

		''' <summary>
		''' Autogenerated name
		''' </summary>
		Public Property AutoName() As String
			Get
				Return Me.mAutoName
			End Get

			Set(ByVal Name As String)
				Me.mAutoName = Name
			End Set
		End Property

		''' <summary>
		''' f0 genotype
		''' </summary>
		''' <remarks></remarks>
		Private mf0GenoType As String

		''' <summary>
		''' f0 genotype
		''' </summary>
		Public Property f0GenoType() As String
			Get
				Return Me.mf0GenoType
			End Get

			Set(ByVal value As String)
				Me.mf0GenoType = value
			End Set
		End Property

		''' <summary>
		''' Format
		''' </summary>
		''' <remarks></remarks>
		Private mFormat As Integer

		''' <summary>
		''' Format
		''' </summary>
		Public Property Format() As Integer
			Get
				Return Me.mFormat
			End Get

			Set(ByVal value As Integer)
				Me.mFormat = value
			End Set
		End Property

		''' <summary>
		''' Genotype
		''' </summary>
		''' <remarks></remarks>
		Private mGenoType As String

		''' <summary>
		''' Genotype
		''' </summary>
		Public Property GenoType() As String
			Get
				Return Me.mGenoType
			End Get

			Set(ByVal value As String)
				Me.mGenoType = value
			End Set
		End Property

		''' <summary>
		''' Info
		''' </summary>
		''' <remarks></remarks>
		Private mInfo As String

		''' <summary>
		''' Info
		''' </summary>
		Public Property Info() As String
			Get
				Return Me.mInfo
			End Get

			Set(ByVal value As String)
				Me.mInfo = value
			End Set
		End Property

		''' <summary>
		''' Valid ?
		''' </summary>
		''' <remarks></remarks>
		Private mIsValid As Boolean

		''' <summary>
		''' Valid
		''' </summary>
		Public Property isValit() As Boolean
			Get
				Return Me.mIsValid
			End Get

			Set(ByVal Valid As Boolean)
				Me.mIsValid = Valid
			End Set
		End Property

		''' <summary>
		''' Name
		''' </summary>
		''' <remarks></remarks>
		Private mName As String

		''' <summary>
		''' Name
		''' </summary>
		Public Property Name() As String
			Get
				Return Me.mName
			End Get

			Set(ByVal value As String)
				Me.mName = value
			End Set
		End Property

		''' <summary>
		''' String's
		''' </summary>
		''' <remarks></remarks>
		Private mStrings As String

		''' <summary>
		''' String's
		''' </summary>
		Public Property Strings() As String
			Get
				Return Me.mStrings
			End Get

			Set(ByVal value As String)
				Me.mStrings = value
			End Set
		End Property

		''' <summary>
		''' get converted genotype
		''' </summary>
		Public Function getConverted(ByVal format As Integer) As Geno
			' BUG: R�ckgabewert zusammenbauen und zur�ckgeben
			Return Nothing
		End Function

		''' <summary>
		''' create new empty object
		''' </summary>
		Public Sub New()
			' BUG: Object initialisieren
		End Sub

		''' <summary>
		''' create new object
		''' </summary>
		Public Function newFrom(ByVal genotype As String, ByVal format As Integer, ByVal name As String, ByVal description As String) As Geno
			' BUG: R�ckgabewert zusammenbauen und zur�ckgeben
			Return Nothing
		End Function

		''' <summary>
		''' create new object from supplied string argument
		''' </summary>
		Public Function newFromString(ByVal genotype As String) As Geno
			' BUG: R�ckgabewert zusammenbauen und zur�ckgeben
			Return Nothing
		End Function

	End Class

End Namespace
