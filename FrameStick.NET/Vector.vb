Namespace GlobalContext

	''' <summary>
	''' Vector is 1-dimensional array, indexed by integer value (starting from 0). Multidimensional arrays can
	''' be simulated by putting other Vector objects into the Vector.
	''' </summary>
	''' <remarks>Vector is 1-dimensional array, indexed by integer value (starting from 0). Multidimensional arrays can
	''' be simulated by putting other Vector objects into the Vector.
	''' 
	''' Example:
	''' <code>
	''' var v=Vector.new();
	''' v.add(123); 
	''' v.add("string");
	''' </code>
	''' </remarks>
	''' 
	Public Class Vector

		''' <summary>
		''' average
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mAvg As Double

		''' <summary>
		''' average
		''' </summary>
		''' <value>floating point</value>
		Public Property avg() As Double
			Get
				Return Me.mAvg
			End Get

			Set(ByVal value As Double)
				Me.mAvg = value
			End Set
		End Property

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
		''' Standard deviation
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mStdev As Double

		''' <summary>
		''' standard deviation
		''' </summary>
		''' <value>floating point</value>
		Public Property stdev() As Double
			Get
				Return Me.mStdev
			End Get

			Set(ByVal value As Double)
				Me.mStdev = value
			End Set
		End Property

		''' <summary>
		''' append at the end
		''' </summary>
		''' <param name="value">undefined field</param>
		Public Sub add(ByVal value As Object)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' clear data
		''' </summary>
		Public Sub clear()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' find
		''' </summary>
		''' <param name="value">undefined field</param>
		Public Function find(ByVal value As Object) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get value at position (ehemals get)
		''' </summary>
		''' <returns>undefined field</returns>
		Public Function getValueAtPosition(ByVal position As Integer) As Object
			' BUG: Implementieren
			Return Nothing
		End Function

		Public Sub New()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' remove at position
		''' </summary>
		Public Sub remove(ByVal position As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' set value at position (ehemals set)
		''' </summary>
		''' <param name="value">undefined field</param>
		Public Sub setValueAtPosition(ByVal position As Integer, ByVal value As Object)
			' BUG: Implementieren
		End Sub
	End Class

End Namespace
