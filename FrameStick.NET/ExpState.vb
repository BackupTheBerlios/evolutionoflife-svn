Namespace GlobalContext

	Namespace ExperimentDefinition

		''' <summary>
		''' 
		''' </summary>
		''' <remarks></remarks>
		Public Class ExpState

			''' <summary>
			''' last changed property #
			''' </summary>
			Private mChangedProperty As Integer

			''' <summary>
			''' last changed property id
			''' </summary>
			Private mChangedPropertyId As String

			''' <summary>
			''' creaturegrouploaded
			''' </summary>
			Private mCreaturegrouploaded As Integer

			''' <summary>
			''' Notes
			''' </summary>
			Private mNotes As String

			''' <summary>
			''' Evaluated creatures
			''' </summary>
			Private mTotaltestedcr As Integer

			''' <summary>
			''' last changed property #
			''' </summary>
			Public Property changedProperty() As Integer
				Get
					Return Me.mChangedProperty
				End Get

				Set(ByVal value As Integer)
					Me.mChangedProperty = value
				End Set
			End Property

			''' <summary>
			''' lats changed property id
			''' </summary>
			Public Property changedPropertyId() As String
				Get
					Return Me.mChangedPropertyId
				End Get

				Set(ByVal value As String)
					Me.mChangedPropertyId = value
				End Set
			End Property

			''' <summary>
			''' creaturegrouploaded
			''' </summary>
			Public Property creaturegrouploaded() As Integer
				Get
					Return Me.mCreaturegrouploaded
				End Get

				Set(ByVal value As Integer)
					Me.mCreaturegrouploaded = value
				End Set
			End Property

			''' <summary>
			''' Notes
			''' </summary>
			Public Property notes() As String
				Get
					Return Me.mNotes
				End Get

				Set(ByVal value As String)
					Me.mNotes = value
				End Set
			End Property

			''' <summary>
			''' Evaluated creatures
			''' </summary>
			Public Property totaltestedcr() As Integer
				Get
					Return Me.mTotaltestedcr
				End Get

				Set(ByVal value As Integer)
					Me.mTotaltestedcr = value
				End Set
			End Property

			''' <summary>
			''' add property
			''' </summary>
			Public Sub add(ByVal id As String, ByVal type As String, ByVal name As String, ByVal help As String)
				' BUG: Implementieren
			End Sub

			''' <summary>
			''' add group
			''' </summary>
			Public Sub addGroup(ByVal name As String)
				' BUG: Implementieren
			End Sub

			''' <summary>
			''' remove all properties
			''' </summary>
			Public Sub clear()
				' BUG: Implementieren
			End Sub

			''' <param name="index">remove property</param>
			Public Sub remove(ByVal index As Integer)
				' BUG: Implementieren
			End Sub

			''' <summary>
			''' remove group
			''' </summary>
			Public Sub removeGroup(ByVal index As Integer)
				' BUG: Implementieren
			End Sub
		End Class

	End Namespace

End Namespace
