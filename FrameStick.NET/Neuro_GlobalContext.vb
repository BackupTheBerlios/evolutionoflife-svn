Namespace GlobalContext

	''' <summary>
	''' Live Neuron object.
	''' </summary>
	Public Class Neuro

		''' <summary>
		''' number of output channels
		''' </summary>
		Private mChannelCount As Integer

		''' <summary>
		''' number of output channels
		''' </summary>
		Public Property channelCount() As Integer
			Get
				Return Me.mChannelCount
			End Get

			Set(ByVal value As Integer)
				Me.mChannelCount = value
			End Set
		End Property

		''' <summary>
		''' get owner creature
		''' </summary>
		Private mCreature As FrameStick.GlobalContext.Creature

		''' <summary>
		''' get owner creature
		''' </summary>
		Public Property creature() As FrameStick.GlobalContext.Creature
			Get
				Return Me.mCreature
			End Get

			Set(ByVal value As FrameStick.GlobalContext.Creature)
				Me.mCreature = value
			End Set
		End Property

		''' <summary>
		''' neuron state (channel 0)
		''' </summary>
		''' <remarks>the only difference from the
		''' "state" field is that currState,
		''' when written, changes the
		''' internal neuron state
		''' immediately (which disturbs
		''' the regular synchronous NN
		''' operation). This feature should
		''' only be used while controlling
		''' the neuron 'from outside' (like
		''' a neuro probe) and not in the
		''' neuron definition.</remarks>
		Private mCurrState As Double

		''' <summary>
		''' neuron state (channel 0)
		''' </summary>
		''' <remarks>the only difference from the
		''' "state" field is that currState,
		''' when written, changes the
		''' internal neuron state
		''' immediately (which disturbs
		''' the regular synchronous NN
		''' operation). This feature should
		''' only be used while controlling
		''' the neuron 'from outside' (like
		''' a neuro probe) and not in the
		''' neuron definition.</remarks>
		Public Property currState() As Double
			Get
				Return Me.mCurrState
			End Get

			Set(ByVal value As Double)
				Me.mCurrState = value
			End Set
		End Property

		''' <summary>
		''' get input count
		''' </summary>
		Private mGetInputCount As Integer

		''' <summary>
		''' get input count
		''' </summary>
		Public Property getInputCount() As Integer
			Get
				Return Me.mGetInputCount
			End Get

			Set(ByVal value As Integer)
				Me.mGetInputCount = value
			End Set
		End Property

		''' <summary>
		''' Hold state
		''' </summary>
		Private mHold As Boolean

		''' <summary>
		''' Hold state
		''' </summary>
		Public Property hold() As Boolean
			Get
				Return Me.mHold
			End Get

			Set(ByVal value As Boolean)
				Me.mHold = value
			End Set
		End Property

		''' <summary>
		''' full signal sum
		''' </summary>
		Private mInputSum As Double

		''' <summary>
		''' full signal sum
		''' </summary>
		Public Property inputSum() As Double
			Get
				Return Me.mInputSum
			End Get

			Set(ByVal value As Double)
				Me.mInputSum = value
			End Set
		End Property

		''' <summary>
		''' position x
		''' </summary>
		Private mPosition_x As Double

		''' <summary>
		''' position y
		''' </summary>
		Private mPosition_y As Double

		''' <summary>
		''' position z
		''' </summary>
		Private mPosition_z As Double

		''' <summary>
		''' position x
		''' </summary>
		Public Property position_x() As Double
			Get
				Return Me.mPosition_x
			End Get

			Set(ByVal value As Double)
				Me.mPosition_x = value
			End Set
		End Property

		''' <summary>
		''' position y
		''' </summary>
		Public Property position_y() As Double
			Get
				Return Me.mPosition_y
			End Get

			Set(ByVal value As Double)
				Me.mPosition_y = value
			End Set
		End Property

		''' <summary>
		''' position z
		''' </summary>
		Public Property position_z() As Double
			Get
				Return Me.mPosition_z
			End Get

			Set(ByVal value As Double)
				Me.mPosition_z = value
			End Set
		End Property

		''' <summary>
		''' neuron state (channel 0)
		''' </summary>
		''' <remarks>When read, returns the current neuron state.
		''' When written, sets the next neuron state (for use in the neuron definition)</remarks>
		Private mState As Double

		''' <summary>
		''' neuron state (channel 0)
		''' </summary>
		''' <remarks>When read, returns the current neuron state.
		''' When written, sets the next neuron state (for use in the neuron definition)</remarks>
		Public Property state() As Double
			Get
				Return Me.mState
			End Get

			Set(ByVal value As Double)
				Me.mState = value
			End Set
		End Property

		''' <summary>
		''' full weighted signal sum
		''' </summary>
		Private mWeightedInputSum As Double

		''' <summary>
		''' full weighted signal sum
		''' </summary>
		Public Property weightedInputSum() As Double
			Get
				Return Me.mWeightedInputSum
			End Get

			Set(ByVal value As Double)
				Me.mWeightedInputSum = value
			End Set
		End Property

		''' <summary>
		''' get channel count for input
		''' </summary>
		Public Function getInputChannelCount(ByVal input As Integer) As Integer
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get input signal
		''' </summary>
		Public Function getInputState(ByVal input As Integer) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get input signal from channel
		''' </summary>
		Public Function getInputStateChannel(ByVal input As Integer, ByVal channel As Integer) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get signal sum
		''' </summary>
		Public Function getInputSum(ByVal input As Integer) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get input weight
		''' </summary>
		Public Function getInputWeight(ByVal input As Integer) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get output state for channel
		''' </summary>
		Public Function getStateChannel(ByVal channel As Integer) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get weighted input signal
		''' </summary>
		Public Function getWeightedInputState(ByVal input As Integer) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get weighted input signal from channel
		''' </summary>
		Public Function getWeightedInputStateChannel(ByVal input As Integer, ByVal channel As Integer) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' get weighted signal sum
		''' </summary>
		Public Function getWeightedInputSum(ByVal input As Integer) As Double
			' BUG: Implementieren
			Return Nothing
		End Function

		''' <summary>
		''' set neuron for channel
		''' </summary>
		''' <remarks>like "currState"</remarks>
		Public Sub setCurrStateChannel(ByVal channel As Integer, ByVal value As Double)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' set output state for channel
		''' </summary>
		Public Sub setStateChannel(ByVal channel As Integer, ByVal value As Double)
			' BUG: Implementieren
		End Sub

	End Class

End Namespace
