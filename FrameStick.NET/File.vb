Namespace GlobalContext

	''' <summary>
	''' Provides read/write access to the filesystem. Used in the experiment definition to save the experiment
	''' state (onExpSave). Other (general purpose) use of this class is currently very limited.
	''' </summary>
	''' <remarks>Provides read/write access to the filesystem. Used in the experiment definition to save the experiment
	''' state (onExpSave). Other (general purpose) use of this class is currently very limited.</remarks>
	Public Class File

		''' <summary>
		''' EndOfFile
		''' </summary>
		Private mEOF As Boolean = True

		''' <summary>
		''' information
		''' </summary>
		Private mInfo As String

		''' <summary>
		''' name
		''' </summary>
		Private mName As String

		''' <summary>
		''' fill path
		''' </summary>
		Private mPath As String

		''' <summary>
		''' / or \
		''' </summary>
		Private mPathseparator As String = "\"

		''' <summary>
		''' EndOfFile
		''' </summary>
		Public Property EOF() As Boolean
			Get
				Return Me.mEOF
			End Get

			Set(ByVal value As Boolean)
				Me.mEOF = value
			End Set
		End Property

		''' <summary>
		''' information
		''' </summary>
		Public Property info() As String
			Get
				Return Me.mInfo
			End Get

			Set(ByVal value As String)
				Me.mInfo = value
			End Set
		End Property

		''' <summary>
		''' name
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
		''' full path
		''' </summary>
		Public Property path() As String
			Get
				Return Me.mPath
			End Get

			Set(ByVal value As String)
				Me.mPath = value
			End Set
		End Property

		''' <summary>
		''' / or \
		''' </summary>
		Public Property pathseparator() As String
			Get
				Return Me.mPathseparator
			End Get

			Set(ByVal value As String)
				Me.mPathseparator = value
			End Set
		End Property

		''' <summary>
		''' append buffered to the file
		''' </summary>
		Public Function append(ByVal filename As String, ByVal description As String) As FrameStick.GlobalContext.File
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' append unbuffered to the disk file
		''' </summary>
		Public Function appendDirect(ByVal filename As String, ByVal description As String) As FrameStick.GlobalContext.File
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' close a file
		''' </summary>
		Public Sub close()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' create a new buffered file
		''' </summary>
		Public Function create(ByVal filename As String, ByVal description As String) As FrameStick.GlobalContext.File
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' create a new unbuffered disk file
		''' </summary>
		Public Function createDirect(ByVal filename As String, ByVal description As String) As FrameStick.GlobalContext.File
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' test if a file exists
		''' </summary>
		Public Function exists() As Boolean
			' BUG: Implementieren
			Return False
		End Function

		''' <summary>
		''' flush
		''' </summary>
		Public Sub flush()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' create a new memory file
		''' </summary>
		Public Sub New()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' create a new memory file with string contents
		''' </summary>
		Public Function newFromString(ByVal text As String) As FrameStick.GlobalContext.File
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' open existing file for reading
		''' </summary>
		Public Function open(ByVal filename As String) As FrameStick.GlobalContext.File
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' read line
		''' </summary>
		Public Function readLine() As String
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' read object
		''' </summary>
		Public Sub readObject(ByVal objekt As Object)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' read everything
		''' </summary>
		Public Function readUntilEOF() As String
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' write comment string
		''' </summary>
		Public Sub writeComment(ByVal anything As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' write object with alternate name
		''' </summary>
		Public Sub writeNameObject(ByVal name As String, ByVal objekt As Object)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' write object
		''' </summary>
		Public Sub writeObject(ByVal objekt As Object)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' write object header
		''' </summary>
		Public Sub writeObjectBegin(ByVal objekt As Object)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' finish object
		''' </summary>
		Public Sub writeObjectEnd()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' write single field
		''' </summary>
		Public Sub writeObjectField(ByVal objekt As Object, ByVal index As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' write single field
		''' </summary>
		Public Sub writeObjectField(ByVal objekt As Object, ByVal name As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' write all fields
		''' </summary>
		Public Sub writeObjectFields(ByVal objekt As Object)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' write anything
		''' </summary>
		''' <param name="anything">untyped field</param>
		Public Sub writeString(ByVal anything As Object)
			' BUG: Implementieren
		End Sub
	End Class


End Namespace
