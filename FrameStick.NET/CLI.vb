Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace CommandLineInterface

			''' <summary>
			''' 
			''' </summary>
			''' <remarks></remarks>
			Public Class CLI

				''' <summary>
				''' 
				''' </summary>
				''' <remarks></remarks>
				Private mCmdHandler As String

				''' <summary>
				''' 
				''' </summary>
				''' <remarks></remarks>
				Private mMessages As Boolean

				''' <summary>
				''' 
				''' </summary>
				''' <remarks></remarks>
				Private mScript As String

				''' <summary>
				''' 
				''' </summary>
				''' <remarks></remarks>
				Private mStdIn As Object

				''' <summary>
				''' 
				''' </summary>
				''' <remarks></remarks>
				Private mStdOut As Object

				''' <summary>
				''' cmdhandler
				''' </summary>
				Public Property CmdHandler() As String
					Get
						Return Me.mCmdHandler
					End Get

					Set(ByVal value As String)
						Me.mCmdHandler = value
					End Set
				End Property

				''' <summary>
				''' messages
				''' </summary>
				Public Property Messages() As Boolean
					Get
						Return Me.mMessages
					End Get

					Set(ByVal value As Boolean)
						Me.mMessages = value
					End Set
				End Property

				''' <summary>
				''' script
				''' </summary>
				Public Property Script() As String
					Get
						Return Me.mScript
					End Get

					Set(ByVal value As String)
						Me.mScript = value
					End Set
				End Property

				''' <summary>
				''' standard input file
				''' </summary>
				Public Property StdIn() As Object
					Get
						Return Me.mStdIn
					End Get

					Set(ByVal value As Object)
						Me.mStdIn = value
					End Set
				End Property

				''' <summary>
				''' standard output file
				''' </summary>
				Public Property StdOut() As Object
					Get
						Return Me.mStdOut
					End Get

					Set(ByVal value As Object)
						Me.mStdOut = value
					End Set
				End Property

				''' <summary>
				''' add macro
				''' </summary>
				Public Sub AddMacro(ByVal Name As String, ByVal NumArgs As Integer, ByVal definition As String, ByVal helptext As String)
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' execute
				''' </summary>
				Public Sub Execute(ByVal Command As String)
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' list macros
				''' </summary>
				Public Sub ListMacros()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' print
				''' </summary>
				Public Sub Print(ByVal Text As String)
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' quit
				''' </summary>
				Public Sub Quit()
					' BUG: Implementieren
				End Sub
			End Class

		End Namespace

	End Namespace

End Namespace
