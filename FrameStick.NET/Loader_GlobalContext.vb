Namespace GlobalContext

	''' <summary>
	''' Support for loading files in the Framsticks format. Used in the experiment definition to retrieve
	''' experiment state (see OnExpLoad function in standard.expdef). Registered objects (addClass) are
	''' handled automaticaly. Loader can call user functions defined by setBreakLabel.
	''' </summary>
	Public Class Loader

		''' <summary>
		''' AfterObject break condition
		''' </summary>
		Private mAfterObject As Integer

		''' <summary>
		''' AfterObject break condition
		''' </summary>
		Public Property AfterObject() As Integer
			Get
				Return Me.mAfterObject
			End Get

			Set(ByVal value As Integer)
				Me.mAfterObject = value
			End Set
		End Property

		''' <summary>
		''' BeforeObject break condition
		''' </summary>
		Private mBeforeObject As Integer

		''' <summary>
		''' BeforeObject break condition
		''' </summary>
		Public Property BeforeObject() As Integer
			Get
				Return Me.mBeforeObject
			End Get

			Set(ByVal value As Integer)
				Me.mBeforeObject = value
			End Set
		End Property

		''' <summary>
		''' BeforeUnknown break condition
		''' </summary>
		Private mBeforeUnknown As Integer

		''' <summary>
		''' BeforeUnknown break condition
		''' </summary>
		Public Property BeforeUnknown() As Integer
			Get
				Return Me.mBeforeUnknown
			End Get

			Set(ByVal value As Integer)
				Me.mBeforeUnknown = value
			End Set
		End Property

		''' <summary>
		''' last comment
		''' </summary>
		Private mComment As String

		''' <summary>
		''' current object
		''' </summary>
		Private mCurrentObject As Object

		''' <summary>
		''' last comment
		''' </summary>
		Public Property comment() As String
			Get
				Return Me.mComment
			End Get

			Set(ByVal value As String)
				Me.mComment = value
			End Set
		End Property

		''' <summary>
		''' current object
		''' </summary>
		Public Property currentObject() As Object
			Get
				Return Me.mCurrentObject
			End Get

			Set(ByVal value As Object)
				Me.mCurrentObject = value
			End Set
		End Property

		''' <summary>
		''' first comment
		''' </summary>
		Private mFirstComment As Boolean

		''' <summary>
		''' first comment
		''' </summary>
		Public Property firstComment() As Boolean
			Get
				Return Me.mFirstComment
			End Get

			Set(ByVal value As Boolean)
				Me.mFirstComment = value
			End Set
		End Property

		''' <summary>
		''' current object's class name
		''' </summary>
		Private mObjectName As String

		''' <summary>
		''' current object's class name
		''' </summary>
		Public Property objectName() As String
			Get
				Return Me.mObjectName
			End Get

			Set(ByVal value As String)
				Me.mObjectName = value
			End Set
		End Property

		''' <summary>
		''' OnComment break condition
		''' </summary>
		Private mOnComment As Integer

		''' <summary>
		''' OnComment break condition
		''' </summary>
		Public Property OnComment() As Integer
			Get
				Return Me.mOnComment
			End Get

			Set(ByVal value As Integer)
				Me.mOnComment = value
			End Set
		End Property

		''' <summary>
		''' OnError break condition
		''' </summary>
		Private mOnError As Integer

		''' <summary>
		''' OnError break condition
		''' </summary>
		Public Property OnError() As Integer
			Get
				Return Me.mOnError
			End Get

			Set(ByVal value As Integer)
				Me.mOnError = value
			End Set
		End Property

		''' <summary>
		''' loader status
		''' </summary>
		Private mStatus As Integer

		''' <summary>
		''' loader status
		''' </summary>
		Public Property status() As Integer
			Get
				Return Me.mStatus
			End Get

			Set(ByVal value As Integer)
				Me.mStatus = value
			End Set
		End Property

		''' <summary>
		''' abort loading
		''' </summary>
		Public Sub abort()
			' BUG: Implemetieren
		End Sub

		''' <summary>
		''' add class definition
		''' </summary>
		Public Sub addClass(ByVal objeckt As Object)
			' BUG: Implemetieren
		End Sub

		''' <summary>
		''' remove all definitions
		''' </summary>
		Public Sub clearClasses()
			' BUG: Implemetieren
		End Sub

		''' <summary>
		''' load until next break
		''' </summary>
		Public Sub go()
			' BUG: Implemetieren
		End Sub

		''' <summary>
		''' load current object
		''' </summary>
		Public Sub loadObject()
			' BUG: Implemetieren
		End Sub

		''' <summary>
		''' remove class definition
		''' </summary>
		Public Sub removeObject(ByVal objekt As Object)
			' BUG: Implemetieren
		End Sub

		''' <summary>
		''' continue loading
		''' </summary>
		Public Sub run()
			' BUG: Implemetieren
		End Sub

		''' <summary>
		''' define break condition
		''' </summary>
		Public Sub setBreak(ByVal breakconditions As Integer)
			' BUG: Implemetieren
		End Sub

		''' <summary>
		''' associate code label with the break condition
		''' </summary>
		Public Sub setBreakLabel(ByVal breakcondition As Integer, ByVal label As String)
			' BUG: Implemetieren
		End Sub

		''' <summary>
		''' skip current object
		''' </summary>
		Public Sub skipObject()
			' BUG: Implemetieren
		End Sub
	End Class

End Namespace
