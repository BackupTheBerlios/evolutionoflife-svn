Namespace GlobalContext

	Namespace ExperimentDefinition

		Namespace VisualStyleDefinition

			''' <summary>
			''' Manipulate 3d objects surface properties (Material objects can be associated with geometry nodes).
			''' </summary>
			Public Class Material

				Private mAmbient As Integer
				Private mColormat As Integer
				Private mDiffuse As Integer
				Private mEmission As Integer
				Private mObjekt As Object
				Private mShininess As Double
				Private mSpecular As Integer
				Private mTexture As String
				Private mTranslucent As Integer

				Public Property ambient() As Integer
					Get

					End Get
					Set(ByVal value As Integer)

					End Set
				End Property

				Public Property colormar() As Integer
					Get

					End Get
					Set(ByVal value As Integer)

					End Set
				End Property

				Public Property diffuse() As Integer
					Get

					End Get
					Set(ByVal value As Integer)

					End Set
				End Property

				Public Property emission() As Integer
					Get

					End Get
					Set(ByVal value As Integer)

					End Set
				End Property

				Public Property objekt() As Object
					Get

					End Get
					Set(ByVal value As Object)

					End Set
				End Property

				Public Property shininess() As Double
					Get

					End Get
					Set(ByVal value As Double)

					End Set
				End Property

				Public Property specular() As Integer
					Get

					End Get
					Set(ByVal value As Integer)

					End Set
				End Property

				Public Property texture() As String
					Get

					End Get
					Set(ByVal value As String)

					End Set
				End Property

				Public Property translucent() As Integer
					Get

					End Get
					Set(ByVal value As Integer)

					End Set
				End Property

				Public Sub care()

				End Sub

				Public Sub disable()

				End Sub

				Public Sub dontcare()

				End Sub

				Public Sub enable()

				End Sub

				Public Sub New()

				End Sub

				Public Sub setFlat()

				End Sub

				Public Sub setSmooth()

				End Sub
			End Class

		End Namespace

	End Namespace

End Namespace
