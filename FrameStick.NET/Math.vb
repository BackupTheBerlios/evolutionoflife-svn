Namespace GlobalContext

	''' <summary>
	''' Mathematical functions library
	''' </summary>
	Public Class Math

		''' <summary>
		''' pi ~ 3.14
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mPi As Double

		''' <summary>
		''' pi ~ 3.14
		''' </summary>
		''' <value>floating point</value>
		Public Property pi() As Double
			Get
				Return Me.mPi
			End Get

			Set(ByVal value As Double)
				Me.mPi = value
			End Set
		End Property

		''' <summary>
		''' pi/2 ~ 1.57
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mPi2 As Double

		''' <summary>
		''' pi/2 ~ 1.57
		''' </summary>
		''' <value>floating point</value>
		Public Property pi2() As Double
			Get
				Return Me.mPi2
			End Get

			Set(ByVal value As Double)
				Me.mPi2 = value
			End Set
		End Property

		''' <summary>
		''' pi/4 ~ 0.78
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mPi4 As Double

		''' <summary>
		''' pi/4 ~ 0.78
		''' </summary>
		''' <value>floating point</value>
		Public Property pi4() As Double
			Get
				Return Me.mPi4
			End Get

			Set(ByVal value As Double)
				Me.mPi4 = value
			End Set
		End Property

		''' <summary>
		''' random number
		''' 0 bis 1
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mRnd01 As Double

		''' <summary>
		''' random number
		''' 0 bis 1
		''' </summary>
		''' <value>floating point</value>
		Public Property rnd01() As Double
			Get
				Return Me.mRnd01
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 1 Then
					Me.mRnd01 = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' random number (normal distribution)
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mRndGaussStd As Double

		''' <summary>
		''' random number (normal distribution)
		''' </summary>
		''' <value>floating point</value>
		Public Property rndGaussStd() As Double
			Get
				Return Me.mRndGaussStd
			End Get

			Set(ByVal value As Double)
				Me.mRndGaussStd = value
			End Set
		End Property

		''' <summary>
		''' random seed
		''' </summary>
		Private mSeed As Integer

		''' <summary>
		''' random seed
		''' </summary>
		Public Property seed() As Integer
			Get
				Return Me.mSeed
			End Get

			Set(ByVal value As Integer)
				Me.mSeed = value
			End Set
		End Property

		''' <summary>
		''' current time
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mTime As Double

		''' <summary>
		''' current time
		''' </summary>
		''' <value>floating point</value>
		Public Property time() As Double
			Get
				Return Me.mTime
			End Get

			Set(ByVal value As Double)
				Me.mTime = value
			End Set
		End Property

		''' <summary>
		''' 2*pi ~ 6.28
		''' </summary>
		''' <remarks>floating point</remarks>
		Private mTwopi As Double

		''' <summary>
		''' 2*pi ~ 6.28
		''' </summary>
		''' <value>floating point</value>
		Public Property twopi() As Double
			Get
				Return Me.mTwopi
			End Get

			Set(ByVal value As Double)
				Me.mTwopi = value
			End Set
		End Property

		''' <summary>
		''' arc tangent
		''' </summary>
		Public Function atan(ByVal value As Double) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' cosinus
		''' </summary>
		Public Function cos(ByVal value As Double) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' exponent
		''' </summary>
		Public Function exp(ByVal value As Double) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' logarithm; base = e
		''' </summary>
		Public Function log(ByVal value As Double) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' integer random number
		''' </summary>
		Public Function random(ByVal num As Integer) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' random number
		''' </summary>
		Public Function rndCustom(ByVal vector As FrameStick.GlobalContext.Vector) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' random number (selectable std.dev.)
		''' </summary>
		Public Function rndGaus(ByVal center As Double, ByVal standarddeviation As Double) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' random number (uniform distribution)
		''' </summary>
		Public Function rndUni(ByVal begin As Double, ByVal ende As Double) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' sigmoid function = 2 / ( 1 + exp( -x ) ) - 1
		''' </summary>
		Public Function sigmoid(ByVal value As Double) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' sinus
		''' </summary>
		Public Function sin(ByVal value As Double) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' square root
		''' </summary>
		Public Function sqrt(ByVal value As Double) As Double
			' BUG: Implementieren
		End Function

	End Class

End Namespace
