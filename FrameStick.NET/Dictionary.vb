Namespace GlobalContext

	''' <summary>
	''' Dictionary associates stored values with string keys
	''' </summary>
	''' <remarks>Dictionary associates stored values with string keys ("key" is the first argument in get/set/remove
	''' functions).
	''' Integer "key" can be used to enumerate all elements.
	''' 
	''' Example:
	''' &lt;code&gt;
	''' var d=Dictionary.new();
	''' d.set("name","John");
	''' d.set("age",44);
	''' var i,element;
	''' for(i=0;i&lt;d.size();i++)
	'''     element=d.get(i);
	''' &lt;/code&gt;</remarks>
	Public Class Dictionary

		''' <summary>
		''' element count
		''' </summary>
		Private mSize As Integer

		''' <summary>
		''' element count
		''' </summary>
		Public Property size() As Integer
			Get
				Return Me.mSize
			End Get

			Set(ByVal value As Integer)
				Me.mSize = value
			End Set
		End Property

		''' <summary>
		''' clear data
		''' </summary>
		Public Sub clear()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' find
		''' </summary>
		''' <param name="value">untyped field</param>
		Public Function find(ByVal value As Object) As String
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get named element
		''' </summary>
		''' <returns>untyped field</returns>
		Public Function getElement(ByVal name As String) As Object
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get indexed element
		''' </summary>
		''' <returns>untyped field</returns>
		Public Function getElement(ByVal index As Integer) As Object
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' create new Dictonary
		''' </summary>
		Public Sub New()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' remove named element
		''' </summary>
		Public Sub remove(ByVal name As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' remove indexed element
		''' </summary>
		Public Sub remove(ByVal index As Integer)
			' BUG: Implementieren
		End Sub

		Public Sub setElement(ByVal name As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' set named element
		''' </summary>
		''' <param name="index">set indexed element</param>
		Public Sub setElement(ByVal index As Integer)
			' BUG: Implementieren
		End Sub
	End Class

End Namespace

