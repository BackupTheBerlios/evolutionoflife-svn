Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace VisualStyleDefinition

			''' <summary>
			''' Scene graph access (build and manipulate the 3d object tree)
			''' </summary>
			Public Class GeomBuilder

				''' <summary>
				''' Script
				''' </summary>
				Private mCode As String

				''' <summary>
				''' Skript
				''' </summary>
				Public Property code() As String
					Get
						Return Me.mCode
					End Get

					Set(ByVal value As String)
						Me.mCode = value
					End Set
				End Property

				''' <summary>
				''' currently selected node
				''' </summary>
				Private mCurrentNode As Integer

				''' <summary>
				''' currnetly selected node
				''' </summary>
				Public Property currentNode() As Integer
					Get
						Return Me.mCurrentNode
					End Get

					Set(ByVal value As Integer)
						Me.mCurrentNode = value
					End Set
				End Property

				''' <summary>
				''' default style
				''' </summary>
				Private mDefaultStyle As String

				''' <summary>
				''' default style
				''' </summary>
				Public Property defaultStyle() As String
					Get
						Return Me.mDefaultStyle
					End Get

					Set(ByVal value As String)
						Me.mDefaultStyle = value
					End Set
				End Property

				''' <summary>
				''' matrix[0,0]
				''' </summary>
				Private mMatrix00 As Double

				''' <summary>
				''' matrix[0,1]
				''' </summary>
				Private mMatrix01 As Double

				''' <summary>
				''' matrix[0,2]
				''' </summary>
				Private mMatrix02 As Double

				''' <summary>
				''' matrix[0,3]
				''' </summary>
				Private mMatrix03 As Double

				''' <summary>
				''' matrix[1,0]
				''' </summary>
				Private mMatrix10 As Double

				''' <summary>
				''' matrix[1,1]
				''' </summary>
				Private mMatrix11 As Double

				''' <summary>
				''' matrix[1,2]
				''' </summary>
				Private mMatrix12 As Double

				''' <summary>
				''' matrix[1,3]
				''' </summary>
				Private mMatrix13 As Double

				''' <summary>
				''' matrix[2,0]
				''' </summary>
				Private mMatrix20 As Double

				''' <summary>
				''' matrix[2,1]
				''' </summary>
				Private mMatrix21 As Double

				''' <summary>
				''' matrix[2,2]
				''' </summary>
				Private mMatrix22 As Double

				''' <summary>
				''' matrix[2,3]
				''' </summary>
				Private mMatrix23 As Double

				''' <summary>
				''' matrix[3,0]
				''' </summary>
				Private mMatrix30 As Double

				''' <summary>
				''' matrix[3,1]
				''' </summary>
				Private mMatrix31 As Double

				''' <summary>
				''' matrix[3,2]
				''' </summary>
				Private mMatrix32 As Double

				''' <summary>
				''' matrix[3,3]
				''' </summary>
				Private mMatrix33 As Double

				''' <summary>
				''' matrix[0,0]
				''' </summary>
				Public Property matrix00() As Double
					Get
						Return Me.mMatrix00
					End Get

					Set(ByVal value As Double)
						Me.mMatrix00 = value
					End Set
				End Property

				''' <summary>
				''' matrix[0,1]
				''' </summary>
				Public Property matrix01() As Double
					Get
						Return Me.mMatrix01
					End Get

					Set(ByVal value As Double)
						Me.mMatrix01 = value
					End Set
				End Property

				''' <summary>
				''' matrix[0,2]
				''' </summary>
				Public Property matrix02() As Double
					Get
						Return Me.mMatrix02
					End Get

					Set(ByVal value As Double)
						Me.mMatrix02 = value
					End Set
				End Property

				''' <summary>
				''' matrix[0,3]
				''' </summary>
				Public Property matrix03() As Double
					Get
						Return Me.mMatrix03
					End Get

					Set(ByVal value As Double)
						Me.mMatrix03 = value
					End Set
				End Property

				''' <summary>
				''' matrix[1,0]
				''' </summary>
				Public Property matrix10() As Double
					Get
						Return Me.mMatrix10
					End Get

					Set(ByVal value As Double)
						Me.mMatrix10 = value
					End Set
				End Property

				''' <summary>
				''' matrix[1,1]
				''' </summary>
				Public Property matrix11() As Double
					Get
						Return Me.mMatrix11
					End Get

					Set(ByVal value As Double)
						Me.mMatrix11 = value
					End Set
				End Property

				''' <summary>
				''' matrix[1,2]
				''' </summary>
				Public Property matrix12() As Double
					Get
						Return Me.mMatrix12
					End Get

					Set(ByVal value As Double)
						Me.mMatrix12 = value
					End Set
				End Property

				''' <summary>
				''' matrix[1,3]
				''' </summary>
				Public Property matrix13() As Double
					Get
						Return Me.mMatrix13
					End Get

					Set(ByVal value As Double)
						Me.mMatrix13 = value
					End Set
				End Property

				''' <summary>
				''' matrix[2,0]
				''' </summary>
				Public Property matrix20() As Double
					Get
						Return Me.mMatrix20
					End Get

					Set(ByVal value As Double)
						Me.mMatrix20 = value
					End Set
				End Property

				''' <summary>
				''' matrix[2,1]
				''' </summary>
				Public Property matrix21() As Double
					Get
						Return Me.mMatrix21
					End Get

					Set(ByVal value As Double)
						Me.mMatrix21 = value
					End Set
				End Property

				''' <summary>
				''' matrix[2,2]
				''' </summary>
				Public Property matrix22() As Double
					Get
						Return Me.mMatrix22
					End Get

					Set(ByVal value As Double)
						Me.mMatrix22 = value
					End Set
				End Property

				''' <summary>
				''' matrix[2,3]
				''' </summary>
				Public Property matrix23() As Double
					Get
						Return Me.mMatrix23
					End Get

					Set(ByVal value As Double)
						Me.mMatrix23 = value
					End Set
				End Property

				''' <summary>
				''' matrix[3,0]
				''' </summary>
				Public Property matrix30() As Double
					Get
						Return Me.mMatrix30
					End Get

					Set(ByVal value As Double)
						Me.mMatrix30 = value
					End Set
				End Property

				''' <summary>
				''' matrix[3,1]
				''' </summary>
				Public Property matrix31() As Double
					Get
						Return Me.mMatrix31
					End Get

					Set(ByVal value As Double)
						Me.mMatrix31 = value
					End Set
				End Property

				''' <summary>
				''' matrix[3,2]
				''' </summary>
				Public Property matrix32() As Double
					Get
						Return Me.mMatrix32
					End Get

					Set(ByVal value As Double)
						Me.mMatrix32 = value
					End Set
				End Property

				''' <summary>
				''' matrix[3,3]
				''' </summary>
				Public Property matrix33() As Double
					Get
						Return Me.mMatrix33
					End Get

					Set(ByVal value As Double)
						Me.mMatrix33 = value
					End Set
				End Property

				''' <summary>
				''' object's root node
				''' </summary>
				Private mRootNode As Integer

				''' <summary>
				''' object's root node
				''' </summary>
				Public Property rootNode() As Integer
					Get
						Return Me.mRootNode
					End Get

					Set(ByVal value As Integer)
						Me.mRootNode = value
					End Set
				End Property

				''' <summary>
				''' geometry node to be associated with current creature's element
				''' </summary>
				Private mUpdatingNode As Integer

				''' <summary>
				''' geometry node to be associated with current creature's element
				''' </summary>
				Public Property updatingNode() As Integer
					Get
						Return Me.mUpdatingNode
					End Get

					Set(ByVal value As Integer)
						Me.mUpdatingNode = value
					End Set
				End Property

				''' <summary>
				''' add
				''' </summary>
				Public Sub add()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' addBranche
				''' </summary>
				Public Sub addBranch()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' addTransform
				''' </summary>
				Public Sub addTransform()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' dump object hierarchy
				''' </summary>
				Public Sub dump(ByVal objekt As Object, ByVal level As Integer)
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' translate matrix
				''' </summary>
				Public Sub matrixMove()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' set matrix orientation
				''' </summary>
				Public Sub matrixOrient()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' load identity matrix
				''' </summary>
				Public Sub matrixReset()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' rotate matrix
				''' </summary>
				Public Sub matrixRotate()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' scale matrix
				''' </summary>
				Public Sub matrixScale()
					' BUG: Implementieren
				End Sub

				''' <summary>
				''' set Matrix
				''' </summary>
				Public Sub setMatrix()
					' BUG: Implementieren
				End Sub

			End Class

		End Namespace

	End Namespace

End Namespace
