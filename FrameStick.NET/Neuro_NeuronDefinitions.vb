Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace NeuronDefinitions

			''' <summary>
			''' Live Neuron Object
			''' </summary>
			Public Class Neuro

				''' <summary>
				''' number of output channels
				''' </summary>
				Private mChannelCount As Integer

				''' <summary>
				''' get owner creature
				''' </summary>
				Private mCreature As FrameStick.GlobalContext.Creature

				''' <summary>
				''' neuron state (channel 0)
				''' </summary>
				''' <remarks>floating point</remarks>
				Private mCurrState As Double

				''' <summary>
				''' get input count
				''' </summary>
				Private mGetInputCount As Integer

				''' <summary>
				''' Hold state
				''' </summary>
				Private mHold As Boolean

				''' <summary>
				''' full signal sum
				''' </summary>
				''' <remarks>floating point</remarks>
				Private mInputSum As Double

				''' <summary>
				''' position x
				''' </summary>
				''' <remarks>floating point</remarks>
				Private mPosition_x As Double

				''' <summary>
				''' position y
				''' </summary>
				''' <remarks>floating point</remarks>
				Private mPosition_y As Double

				''' <summary>
				''' position z
				''' </summary>
				''' <remarks>floating point</remarks>
				Private mPosition_z As Double

				''' <summary>
				''' number of output channels
				''' </summary>
				Public Property channelcount() As Integer
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
				''' <value>floatin point</value>
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
				Public Property getInputCount() As Integer
					Get
						Return Me.mGetInputCount
					End Get

					Set(ByVal value As Integer)
						Me.mGetInputCount = value
					End Set
				End Property

				''' <summary>
				''' Hold State
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
				''' <value>floating point</value>
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
				''' <value>floating point</value>
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
				''' <value>floating point</value>
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
				''' <value>floating point</value>
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
				''' <remarks>floating point</remarks>
				Private mState As Double

				''' <summary>
				''' full weighted signal sum
				''' </summary>
				''' <remarks>floating point</remarks>
				Private mWeightedInputSun As Double

				''' <summary>
				''' neuron state (channel 0)
				''' </summary>
				''' <value>floating point</value>
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
				''' <value>floating point</value>
				Public Property weightedInputSum() As Double
					Get
						Return Me.mWeightedInputSun
					End Get

					Set(ByVal value As Double)
						Me.mWeightedInputSun = value
					End Set
				End Property

				''' <summary>
				''' get channel count for input
				''' </summary>
				Public Function getInputChannelCount(ByVal input As Integer) As Integer
					' BUG: implementieren
					Return 0
				End Function

				''' <summary>
				''' get input signal
				''' </summary>
				''' <returns>floating point</returns>
				Public Function getInputState(ByVal input As Integer) As Double
					' BUG: implementieren
					Return 0
				End Function

				''' <summary>
				''' get input signal from channel
				''' </summary>
				''' <returns>floating point</returns>
				Public Function getInputStateChannel(ByVal input As Integer, ByVal channel As Integer) As Double
					' BUG: implementieren
					Return 0
				End Function

				''' <summary>
				''' get signal sum
				''' </summary>
				''' <returns>floating point</returns>
				Public Function getInputSum(ByVal input As Integer) As Double
					' BUG: implementieren
					Return 0
				End Function

				''' <summary>
				''' get input weight
				''' </summary>
				''' <returns>floating point</returns>
				Public Function getInputWeight(ByVal input As Integer) As Double
					' BUG: implementieren
					Return 0
				End Function

				''' <summary>
				''' get output state for channel
				''' </summary>
				''' <returns>floating point</returns>
				Public Function getStateChannel(ByVal channel As Integer) As Double
					' BUG: implementieren
					Return 0
				End Function

				''' <summary>
				''' get weighted input signal
				''' </summary>
				''' <returns>floating point</returns>
				Public Function getWeightedInputState(ByVal input As Integer) As Double
					' BUG: implementieren
					Return 0
				End Function

				''' <summary>
				''' get weighted input signal from channel
				''' </summary>
				''' <returns>floating point</returns>
				Public Function getWeightedInputStateChannel(ByVal input As Integer, ByVal channel As Integer) As Double
					' BUG: implementieren
					Return 0
				End Function

				''' <summary>
				''' get weighted signal sum
				''' </summary>
				''' <returns>floating point</returns>
				Public Function getWeightedInputSum(ByVal input As Integer) As Double
					' BUG: implementieren
					Return 0
				End Function

				''' <summary>
				''' set neuron for channel
				''' </summary>
				''' <param name="value">floating point</param>
				Public Sub setCurrStateChannel(ByVal channel As Integer, ByVal value As Double)
					' BUG: implementieren
				End Sub

				''' <summary>
				''' set output state for channel
				''' </summary>
				''' <param name="value">floating point</param>
				Public Sub setStateChannel(ByVal channel As Integer, ByVal value As Double)
					' BUG: implementieren
				End Sub

			End Class

		End Namespace

	End Namespace

End Namespace
