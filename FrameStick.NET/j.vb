Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace VisualStyleDefinition

			Public Class j

				''' <summary>
				''' delta.x
				''' </summary>
				''' <remarks>-2 bis 2</remarks>
				Private mDx As Double

				''' <summary>
				''' delta.y
				''' </summary>
				''' <remarks>-2 bis 2</remarks>
				Private mDy As Double

				''' <summary>
				''' delta.z
				''' </summary>
				''' <remarks>-2 bis 2</remarks>
				Private mDz As Double

				''' <summary>
				''' info
				''' </summary>
				Private mI As String

				''' <summary>
				''' part1 ref#
				''' </summary>
				''' <remarks>-1 bis 999.999</remarks>
				Private mP1 As Integer

				''' <summary>
				''' part2 ref#
				''' </summary>
				''' <remarks>-1 bis 999.999</remarks>
				Private mP2 As Integer

				''' <summary>
				''' rotation stiffness
				''' </summary>
				''' <remarks>0 bis 1</remarks>
				Private mRotstif As Double

				''' <summary>
				''' rotation.x
				''' </summary>
				Private mRx As Double

				''' <summary>
				''' rotation.y
				''' </summary>
				Private mRy As Double

				''' <summary>
				''' rotation.z
				''' </summary>
				Private mRz As Double

				''' <summary>
				''' stamina
				''' </summary>
				''' <remarks>0 bis 1</remarks>
				Private mStam As Double

				''' <summary>
				''' delta.x
				''' </summary>
				''' <value>-2 bis 2</value>
				Public Property dx() As Double
					Get
						Return Me.mDx
					End Get

					Set(ByVal value As Double)
						If value >= -2 And value <= 2 Then
							Me.mDx = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -2 und 2 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' delta.y
				''' </summary>
				''' <value>-2 bis 2</value>
				Public Property dy() As Double
					Get
						Return Me.mDy
					End Get

					Set(ByVal value As Double)
						If value >= -2 And value <= 2 Then
							Me.mDy = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -2 und 2 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' delat.z
				''' </summary>
				''' <value>-2 bis 2</value>
				Public Property dz() As Double
					Get
						Return Me.mDz
					End Get

					Set(ByVal value As Double)
						If value >= -2 And value <= 2 Then
							Me.mDz = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -2 und 2 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' info
				''' </summary>
				Public Property i() As String
					Get
						Return Me.mI
					End Get

					Set(ByVal value As String)
						Me.mI = value
					End Set
				End Property

				''' <summary>
				''' part1 ref#
				''' </summary>
				''' <value>-1 bis 999.999</value>
				Public Property p1() As Integer
					Get
						Return Me.mP1
					End Get

					Set(ByVal value As Integer)
						If value >= -1 And value <= 999999 Then
							Me.mP1 = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -1 und 999999 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' part2 ref#
				''' </summary>
				''' <value>-1 bis 999.999</value>
				Public Property p2() As Integer
					Get
						Return Me.mP2
					End Get

					Set(ByVal value As Integer)
						If value >= -1 And value <= 999999 Then
							Me.mP2 = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen -1 und 999999 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' rotation stiffness
				''' </summary>
				''' <value>0 bis 1</value>
				Public Property rotstif() As Double
					Get
						Return Me.mRotstif
					End Get

					Set(ByVal value As Double)
						If value >= 0 And value <= 1 Then
							Me.mRotstif = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' rotation.x
				''' </summary>
				Public Property rx() As Double
					Get
						Return Me.mRx
					End Get

					Set(ByVal value As Double)
						Me.mRx = value
					End Set
				End Property

				''' <summary>
				''' rotation.y
				''' </summary>
				Public Property ry() As Double
					Get
						Return Me.mRy
					End Get

					Set(ByVal value As Double)
						Me.mRy = value
					End Set
				End Property

				''' <summary>
				''' rotation.z
				''' </summary>
				Public Property rz() As Double
					Get
						Return Me.mRz
					End Get

					Set(ByVal value As Double)
						Me.mRz = value
					End Set
				End Property

				''' <summary>
				''' stamina
				''' </summary>
				''' <value>0 bis 1</value>
				Public Property stam() As Double
					Get
						Return Me.mStam
					End Get

					Set(ByVal value As Double)
						If value >= 0 And value <= 1 Then
							Me.mStam = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' stiffness
				''' </summary>
				''' <remarks>0 bis 1</remarks>
				Private mStif As Double

				''' <summary>
				''' vis_style
				''' </summary>
				Private mVstyle As String

				''' <summary>
				''' stiffness
				''' </summary>
				''' <value>0 bis 1</value>
				Public Property stif() As Double
					Get
						Return Me.mStif
					End Get

					Set(ByVal value As Double)
						If value >= 0 And value <= 1 Then
							Me.mStif = value
						Else
							Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
						End If
					End Set
				End Property

				''' <summary>
				''' visd_style
				''' </summary>
				Public Property Vstyle() As String
					Get
						Return Me.mVstyle
					End Get

					Set(ByVal value As String)
						Me.mVstyle = value
					End Set
				End Property
			End Class


		End Namespace

	End Namespace

End Namespace
