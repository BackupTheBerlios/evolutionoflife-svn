Namespace GlobalContext

	''' <summary>
	''' Manages various genetic operations, using appropriate operators for the argument genotype format.
	''' </summary>
	Public Class GenMan

		''' <summary>
		''' last changed property #
		''' </summary>
		Private mChangedProperty As Integer

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
		''' last changed property id
		''' </summary>
		Private mChangedPropertyId As String

		''' <summary>
		''' last changed property id
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
		''' Delete
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_c_del As Double

		''' <summary>
		''' Delete
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_c_del() As Double
			Get
				Return Me.mF0_c_del
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_c_del = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' New connection
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_c_new As Double

		''' <summary>
		''' New connection
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_c_new() As Double
			Get
				Return Me.mF0_c_new
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_c_new = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Change weight
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_c_wei As Double

		''' <summary>
		''' Change weight
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_c_wei() As Double
			Get
				Return Me.mF0_c_wei
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_c_wei = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Delete
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_j_del As Double

		''' <summary>
		''' New joint
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_j_new As Double

		''' <summary>
		''' Rotstif
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_j_rsf As Double

		''' <summary>
		''' Stif
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_j_stf As Double

		''' <summary>
		''' Stamina
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_j_stm As Double

		''' <summary>
		''' Delete
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_j_del() As Double
			Get
				Return Me.mF0_j_del
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_j_del = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' New joint
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_j_new() As Double
			Get
				Return Me.mF0_j_new
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_j_new = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Rotstif
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_j_rsf() As Double
			Get
				Return Me.mF0_j_rsf
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_j_rsf = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Stif
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_j_stf() As Double
			Get
				Return Me.mF0_j_stf
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_j_stf = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Stamina
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_j_stm() As Double
			Get
				Return Me.mF0_j_stm
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_j_stm = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Delete
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_n_del As Double

		''' <summary>
		''' New neuron
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_n_new As Double

		''' <summary>
		''' Change properties
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_n_prp As Double

		''' <summary>
		''' Delete
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_n_del() As Double
			Get
				Return Me.mF0_n_del
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_n_del = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' New neuron
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_n_new() As Double
			Get
				Return Me.mF0_n_new
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_n_new = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Change properties
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_n_prp() As Double
			Get
				Return Me.mF0_n_prp
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_n_prp = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Assimilation
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_p_asm As Double

		''' <summary>
		''' Delete
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_p_del As Double

		''' <summary>
		''' Friction
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_p_frc As Double

		''' <summary>
		''' Ingest
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_p_ing As Double

		''' <summary>
		''' Mass
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_p_mas As Double

		''' <summary>
		''' New part
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_p_new As Double

		''' <summary>
		''' Position
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_p_pos As Double

		''' <summary>
		''' Swap part
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF0_p_swp As Double

		''' <summary>
		''' Assimilation
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_p_asm() As Double
			Get
				Return Me.mF0_p_asm
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_asm = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Delete
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_p_del() As Double
			Get
				Return Me.mF0_p_del
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_del = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Friction
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_p_frc() As Double
			Get
				Return Me.mF0_p_frc
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_frc = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Ingest
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_p_ing() As Double
			Get
				Return Me.mF0_p_ing
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_ing = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Mass
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_p_mas() As Double
			Get
				Return Me.mF0_p_mas
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_mas = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' New Part
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_p_new() As Double
			Get
				Return Me.mF0_p_new
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_new = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Position
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_p_pos() As Double
			Get
				Return Me.mF0_p_pos
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_pos = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Swap part
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f0_p_swp() As Double
			Get
				Return Me.mF0_p_swp
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF0_p_swp = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Excluded modifiers
		''' </summary>
		Private mF1_mut_exmod As String

		''' <summary>
		''' Add/remove neural connection
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF1_nmConn As Double

		''' <summary>
		''' Add/remove a neuron
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF1_nmNeu As Double

		''' <summary>
		''' Add/remove neuron property setting
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF1_nmProp As Double

		''' <summary>
		''' Change property value
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF1_nmVal As Double

		''' <summary>
		''' Change connection weight
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF1_nmWei As Double

		''' <summary>
		''' Excluded modifiers
		''' </summary>
		Public Property f1_mut_exmod() As String
			Get
				Return Me.mF1_mut_exmod
			End Get

			Set(ByVal value As String)
				Me.mF1_mut_exmod = value
			End Set
		End Property

		''' <summary>
		''' Add/remove neural connection
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f1_nmConn() As Double
			Get
				Return Me.mF1_nmConn
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_nmConn = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove a neuron
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f1_nmNeu() As Double
			Get
				Return Me.mF1_nmNeu
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_nmNeu = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove neuron property setting
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f1_nmProp() As Double
			Get
				Return Me.mF1_nmProp
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_nmProp = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Change property value
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f1_nmVal() As Double
			Get
				Return Me.mF1_nmVal
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_nmVal = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Change connection weight
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f1_nmWei() As Double
			Get
				Return Me.mF1_nmWei
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_nmWei = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove a comma ,
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF1_smComma As Double

		''' <summary>
		''' Add/remove a junction ( )
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF1_smJunct As Double

		''' <summary>
		''' Add/remove a modifier
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF1_smModif As Double

		''' <summary>
		''' Add/remove a stick X
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF1_smX As Double

		''' <summary>
		''' Add/remove a comma ,
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f1_smComma() As Double
			Get
				Return Me.mF1_smComma
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_smComma = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove a junction ( )
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f1_smJunct() As Double
			Get
				Return Me.mF1_smJunct
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_smJunct = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove a modifier
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f1_smModif() As Double
			Get
				Return Me.mF1_smModif
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_smModif = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Add/remove a stick X
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f1_smX() As Double
			Get
				Return Me.mF1_smX
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF1_smX = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Proportional crossover
		''' </summary>
		Private mF1_xo_propor As Boolean

		''' <summary>
		''' Proportional crossover
		''' </summary>
		Public Property f1_xo_propor() As Boolean
			Get
				Return Me.mF1_xo_propor
			End Get

			Set(ByVal value As Boolean)
				Me.mF1_xo_propor = value
			End Set
		End Property

		''' <summary>
		''' Add node
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF4_mut_add As Double

		''' <summary>
		''' - add connection
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF4_mut_add_conn As Double

		''' <summary>
		''' - add division
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF4_mut_add_div As Double

		''' <summary>
		''' - add neural parameter
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF4_mut_add_neupar As Double

		''' <summary>
		''' - add repetion
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF4_mut_add_rep As Double

		''' <summary>
		''' - add simple node
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF4_mut_add_simp As Double

		''' <summary>
		''' Delete node
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF4_mut_del As Double

		''' <summary>
		''' Modify node
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mF4_mut_mod As Double

		''' <summary>
		''' Add node
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f4_mut_add() As Double
			Get
				Return Me.mF4_mut_add
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' - add connection
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f4_mut_add_conn() As Double
			Get
				Return Me.mF4_mut_add_conn
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add_conn = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' - add division
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f4_mut_add_div() As Double
			Get
				Return Me.mF4_mut_add_div
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add_div = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' - add neural parameter
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f4_mut_add_neupar() As Double
			Get
				Return Me.mF4_mut_add_neupar
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add_neupar = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' - add repetion
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f4_mut_add_rep() As Double
			Get
				Return Me.mF4_mut_add_rep
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add_rep = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' - add simple node
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f4_mut_add_simp() As Double
			Get
				Return Me.mF4_mut_add_simp
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_add_simp = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Delete
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f4_mut_del() As Double
			Get
				Return Me.mF4_mut_del
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_del = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Modifiy node
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property f4_mut_mod() As Double
			Get
				Return Me.mF4_mut_mod
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mF4_mut_mod = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Use syntax highlighting
		''' </summary>
		Private mGen_hilite As Boolean

		''' <summary>
		''' Remember history of genetic operations
		''' </summary>
		Private mGen_hist As Boolean

		''' <summary>
		''' Operators for f0
		''' </summary>
		''' <remarks>0 bis 0
		''' 
		''' 0 = Default</remarks>
		Private mGenoper_f0 As Integer

		''' <summary>
		''' Operators for f1
		''' </summary>
		''' <remarks>0 bis 0
		''' 
		''' 0 = Default</remarks>
		Private mGenoper_f1 As Integer

		''' <summary>
		''' Operators for f4
		''' </summary>
		''' <remarks>0 bis 0
		''' 
		''' 0 = Default</remarks>
		Private mGenoper_f4 As Integer

		''' <summary>
		''' Use syntax highlighting
		''' </summary>
		Public Property gen_hilite() As Boolean
			Get
				Return Me.mGen_hilite
			End Get

			Set(ByVal value As Boolean)
				Me.mGen_hilite = value
			End Set
		End Property

		''' <summary>
		''' Remember history of genetic operations
		''' </summary>
		Public Property gen_hist() As Boolean
			Get
				Return Me.mGen_hist
			End Get

			Set(ByVal value As Boolean)
				Me.mGen_hist = value
			End Set
		End Property

		''' <summary>
		''' Operators for f0
		''' </summary>
		''' <value>0 bis 0
		''' 
		''' 0 = Default</value>
		Public Property genoper_f0() As Integer
			Get
				Return Me.mGenoper_f0
			End Get

			Set(ByVal value As Integer)
				Me.mGenoper_f0 = value
			End Set
		End Property

		''' <summary>
		''' Operators for f1
		''' </summary>
		''' <value>0 bis 0
		''' 
		''' 0 = Default</value>
		Public Property genoper_f1() As Integer
			Get
				Return Me.mGenoper_f1
			End Get

			Set(ByVal value As Integer)
				Me.mGenoper_f1 = value
			End Set
		End Property

		''' <summary>
		''' Operators for f4
		''' </summary>
		''' <value>0 bis 0
		''' 
		''' 0 = Default</value>
		Public Property genoper_f4() As Integer
			Get
				Return Me.mGenoper_f4
			End Get

			Set(ByVal value As Integer)
				If value = 0 Then
					Me.mGenoper_f4 = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert kann nur 0 sein.")
				End If
			End Set
		End Property

		''' <summary>
		''' Neuron (N)
		''' </summary>
		Private mNeuadd_N As Boolean

		''' <summary>
		''' Unipolar neuron [EXPERIMENTAL!] (Nu)
		''' </summary>
		Private mNeuadd_Nu As Boolean

		''' <summary>
		''' Gyroscope (G)
		''' </summary>
		Private mNeuadd_G As Boolean

		''' <summary>
		''' Touch (T)
		''' </summary>
		Private mNeuadd_T As Boolean

		''' <summary>
		''' Neuron (N)
		''' </summary>
		Public Property neuadd_N() As Boolean
			Get
				Return Me.mNeuadd_N
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_N = value
			End Set
		End Property

		''' <summary>
		''' Unipolar neuron [EXPERIMENTAL!] (Nu)
		''' </summary>
		Public Property neuadd_Nu() As Boolean
			Get
				Return Me.mNeuadd_Nu
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Nu = value
			End Set
		End Property

		''' <summary>
		''' Gyroscope (G)
		''' </summary>
		Public Property neuadd_G() As Boolean
			Get
				Return Me.mNeuadd_G
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_G = value
			End Set
		End Property

		''' <summary>
		''' Touch (T)
		''' </summary>
		Public Property neuadd_T() As Boolean
			Get
				Return Me.mNeuadd_T
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_T = value
			End Set
		End Property

		''' <summary>
		''' Smell (S)
		''' </summary>
		Private mNeuadd_s As Boolean

		''' <summary>
		''' Constant (*)
		''' </summary>
		Private mNeuadd_asteric As Boolean

		''' <summary>
		''' Bend muscle (I)
		''' </summary>
		Private mNeuadd_I As Boolean

		''' <summary>
		''' Rotation muscle (@)
		''' </summary>
		Private mNeuadd_at As Boolean

		''' <summary>
		''' Differentiate (D)
		''' </summary>
		Private mNeuAdd_D As Boolean

		''' <summary>
		''' Smell (S)
		''' </summary>
		Public Property neuadd_S() As Boolean
			Get
				Return Me.mNeuadd_s
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_s = value
			End Set
		End Property

		''' <summary>
		''' Constant (*)
		''' </summary>
		Public Property neuadd_asteric() As Boolean
			Get
				Return Me.mNeuadd_asteric
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_asteric = value
			End Set
		End Property

		''' <summary>
		''' Bend muscle (I)
		''' </summary>
		Public Property neuadd_I() As Boolean
			Get
				Return Me.mNeuadd_I
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_I = value
			End Set
		End Property

		''' <summary>
		''' Rotation muscle (@)
		''' </summary>
		Public Property neuadd_at() As Boolean
			Get
				Return Me.mNeuadd_at
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_at = value
			End Set
		End Property

		''' <summary>
		''' Differentiate (D)
		''' </summary>
		Public Property neuadd_D() As Boolean
			Get
				Return Me.mNeuAdd_D
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuAdd_D = value
			End Set
		End Property

		''' <summary>
		''' Fuzzy system [EXPERIMENTAL!] (Fuzzy)
		''' </summary>
		Private mNeuadd_Fuzzy As Boolean

		''' <summary>
		''' Vector Eye [EXPERIMENTAL!] (VE)
		''' </summary>
		Private mNeuadd_VE As Boolean

		''' <summary>
		''' Sticky [EXPERIMENTAL!] (Sti)
		''' </summary>
		Private mNeuadd_Sti As Boolean

		''' <summary>
		''' Length muscle [EXPERIMENTAL!] (LMu)
		''' </summary>
		Private mNeuadd_LMu As Boolean

		''' <summary>
		''' Water detector (Water)
		''' </summary>
		Private mNeuadd_Water As Boolean

		''' <summary>
		''' Fuzzy system [EXPERIMENTAL!] (Fuzzy)
		''' </summary>
		Public Property neuadd_Fuzzy() As Boolean
			Get
				Return Me.mNeuadd_Fuzzy
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Fuzzy = value
			End Set
		End Property

		''' <summary>
		''' Vector Exe [EXPERIMENTAL!] (VE)
		''' </summary>
		Public Property neuadd_VE() As Boolean
			Get
				Return Me.mNeuadd_VE
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_VE = value
			End Set
		End Property

		''' <summary>
		''' Sticky [EXPERIMENTAL!] (Sti)
		''' </summary>
		Public Property neuadd_Sti() As Boolean
			Get
				Return Me.mNeuadd_Sti
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Sti = value
			End Set
		End Property

		''' <summary>
		''' Lenght muscle [EXPERIMENTAL!] (LMu)
		''' </summary>
		Public Property neuadd_LMu() As Boolean
			Get
				Return Me.mNeuadd_LMu
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_LMu = value
			End Set
		End Property

		''' <summary>
		''' Water detector (Water)
		''' </summary>
		Public Property neuadd_Water() As Boolean
			Get
				Return Me.mNeuadd_Water
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Water = value
			End Set
		End Property

		''' <summary>
		''' Energy level (Energy)
		''' </summary>
		Private mNeuadd_Energy As Boolean

		''' <summary>
		''' Channelize (Ch)
		''' </summary>
		Private mNeuadd_Ch As Boolean

		''' <summary>
		''' Channel multiplexer (ChMux)
		''' </summary>
		Private mNeuadd_ChMux As Boolean

		''' <summary>
		''' Channel selector (ChSel)
		''' </summary>
		Private mNeuadd_ChSel As Boolean

		''' <summary>
		''' Energy level (Energy)
		''' </summary>
		Public Property neuadd_Energy() As Boolean
			Get
				Return Me.mNeuadd_Energy
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Energy = value
			End Set
		End Property

		''' <summary>
		''' Channelize (Ch)
		''' </summary>
		Public Property neuadd_Ch() As Boolean
			Get
				Return Me.mNeuadd_Ch
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Ch = value
			End Set
		End Property

		''' <summary>
		''' Channel multiplexer (ChMux)
		''' </summary>
		Public Property neuadd_ChMux() As Boolean
			Get
				Return Me.mNeuadd_ChMux
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_ChMux = value
			End Set
		End Property

		''' <summary>
		''' Channel selector (ChSel)
		''' </summary>
		Public Property neuadd_ChSel() As Boolean
			Get
				Return Me.mNeuadd_ChSel
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_ChSel = value
			End Set
		End Property

		''' <summary>
		''' Random noise (Rnd)
		''' </summary>
		Private mNeuadd_Rnd As Boolean

		''' <summary>
		''' Sinnus generator (Sin)
		''' </summary>
		Private mNeuadd_Sin As Boolean

		''' <summary>
		''' Matching method
		''' </summary>
		''' <remarks>0 bis 1
		''' 
		''' 0 = New
		''' 1 = Old</remarks>
		Private mSimil_method As Integer

		''' <summary>
		''' Weight of neurons count
		''' </summary>
		''' <remarks>floating point 0 bis 100</remarks>
		Private mSimil_neuro As Double

		''' <summary>
		''' Weight of part's degree
		''' </summary>
		''' <remarks>floating point
		''' 
		''' 0 bis 100</remarks>
		Private mSimil_partdeg As Double

		''' <summary>
		''' Weight of parts count
		''' </summary>
		Private mSimil_parts As Double

		''' <summary>
		''' Random noise (Rnd)
		''' </summary>
		Public Property neuadd_Rnd() As Boolean
			Get
				Return Me.mNeuadd_Rnd
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Rnd = value
			End Set
		End Property

		''' <summary>
		''' Sinus generator (Sin)
		''' </summary>
		Public Property neuadd_Sin() As Boolean
			Get
				Return Me.mNeuadd_Sin
			End Get

			Set(ByVal value As Boolean)
				Me.mNeuadd_Sin = value
			End Set
		End Property

		''' <summary>
		''' Matching method
		''' </summary>
		''' <value>0 bis 1
		''' 
		''' 0 = New
		''' 1 = Old</value>
		Public Property simil_method() As Integer
			Get
				Return Me.mSimil_method
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 1 Then
					Me.mSimil_method = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 1 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Weight of neurons count
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property simil_neuro() As Double
			Get
				Return Me.mSimil_neuro
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mSimil_neuro = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Weight of part's degree
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property simil_partdeg() As Double
			Get
				Return Me.mSimil_partdeg
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mSimil_partdeg = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Weight of parts count
		''' </summary>
		''' <value>floating point
		''' 
		''' 0 bis 100</value>
		Public Property simil_parts() As Double
			Get
				Return Me.mSimil_parts
			End Get

			Set(ByVal value As Double)
				If value >= 0 And value <= 100 Then
					Me.mSimil_parts = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' add property (id, type, name, help)
		''' </summary>
		Public Sub add(ByVal id As String, ByVal type As String, ByVal name As String, ByVal help As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' add group (name)
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

		''' <summary>
		''' Crossover
		''' </summary>
		Public Sub crossOver()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' evaluate model dissimilarity
		''' </summary>
		Public Sub evaluateDistance()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' Mutate
		''' </summary>
		Public Sub mutate()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' Operators report
		''' </summary>
		Public Sub operReport()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' remove property (index)
		''' </summary>
		Public Sub remove(ByVal index As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' remove group (index)
		''' </summary>
		Public Sub removeGroup(ByVal index As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' HTMLize a genotype
		''' </summary>
		Public Sub toHTML()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' HTMLize a genotype, shorten if needed
		''' </summary>
		Public Sub toHTMLshort()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' Validate
		''' </summary>
		Public Sub validate()
			' BUG: Implementieren
		End Sub
	End Class

End Namespace
