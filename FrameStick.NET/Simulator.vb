Namespace GlobalContext

	''' <summary>
	''' The Framesticks simulator.
	''' </summary>
	Public Class Simulator

		''' <summary>
		''' Save backup
		''' </summary>
		''' <remarks>0 bis 100000</remarks>
		Private mAutosaveperiode As Integer

		''' <summary>
		''' Object creation errors
		''' </summary>
		''' <remarks>0 bis 2
		''' 
		''' 0 = Ignore
		''' 1 = Show summry
		''' 2 = Show details</remarks>
		Private mCreaterr As Integer

		''' <summary>
		''' Experiment definition
		''' </summary>
		Private mExpdef As String

		''' <summary>
		''' Description
		''' </summary>
		Private mExpdef_info As String

		''' <summary>
		''' Title
		''' </summary>
		Private mExpdef_title As String

		''' <summary>
		''' Show file comments
		''' </summary>
		Private mFilecomm As Boolean

		''' <summary>
		''' genotype library object
		''' </summary>
		Private mGenolib As FrameStick.GlobalContext.GenotypeLibrary

		''' <summary>
		''' Check genotypes added to groups
		''' </summary>
		Private mGroupchk As Boolean

		''' <summary>
		''' Check imported genotypes
		''' </summary>
		Private mImportchk As Boolean

		''' <summary>
		''' live library object
		''' </summary>
		Private mLivelib As FrameStick.GlobalContext.LiveLibrary

		''' <summary>
		''' Check genotypes loades from experiment
		''' </summary>
		Private mLoadchk As Boolean

		''' <summary>
		''' Overwrite
		''' </summary>
		Private mOverwrite As Boolean

		''' <summary>
		''' Save backup
		''' </summary>
		''' <value>0 bis 100000</value>
		Public Property autosaveperiod() As Integer
			Get
				Return Me.mAutosaveperiode
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 100000 Then
					Me.mAutosaveperiode = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 100000 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Object creation errors
		''' </summary>
		''' <value>0 bis 2
		''' 
		''' 0 = Ignore
		''' 1 = Show summary
		''' 2 = Show details</value>
		Public Property createrr() As Integer
			Get
				Return Me.mCreaterr
			End Get

			Set(ByVal value As Integer)
				If value >= 0 And value <= 2 Then
					Me.mCreaterr = value
				Else
					Throw New ArgumentOutOfRangeException("value", "Der Wert muss zwischen 0 und 2 liegen.")
				End If
			End Set
		End Property

		''' <summary>
		''' Experiment definition
		''' </summary>
		Public Property expdef() As String
			Get
				Return Me.mExpdef
			End Get

			Set(ByVal value As String)
				Me.mExpdef = value
			End Set
		End Property

		''' <summary>
		''' Description
		''' </summary>
		Public Property expdef_info() As String
			Get
				Return Me.mExpdef_info
			End Get

			Set(ByVal value As String)
				Me.mExpdef_info = value
			End Set
		End Property

		''' <summary>
		''' Title
		''' </summary>
		Public Property expdef_title() As String
			Get
				Return Me.mExpdef_title
			End Get

			Set(ByVal value As String)
				Me.mExpdef_title = value
			End Set
		End Property

		''' <summary>
		''' Show file comments
		''' </summary>
		Public Property filecomm() As Boolean
			Get
				Return Me.mFilecomm
			End Get

			Set(ByVal value As Boolean)
				Me.mFilecomm = value
			End Set
		End Property

		''' <summary>
		''' genotype library object
		''' </summary>
		Public Property genolib() As FrameStick.GlobalContext.GenotypeLibrary
			Get
				Return Me.mGenolib
			End Get

			Set(ByVal value As FrameStick.GlobalContext.GenotypeLibrary)
				Me.mGenolib = value
			End Set
		End Property

		''' <summary>
		''' Check genotypes added to groups
		''' </summary>
		Public Property groupchk() As Boolean
			Get
				Return Me.mGroupchk
			End Get

			Set(ByVal value As Boolean)
				Me.mGroupchk = value
			End Set
		End Property

		''' <summary>
		''' Check imported genotypes
		''' </summary>
		Public Property importchk() As Boolean
			Get
				Return Me.mImportchk
			End Get

			Set(ByVal value As Boolean)
				Me.mImportchk = value
			End Set
		End Property

		''' <summary>
		''' live library object
		''' </summary>
		Public Property livelib() As FrameStick.GlobalContext.LiveLibrary
			Get
				Return Me.mLivelib
			End Get

			Set(ByVal value As FrameStick.GlobalContext.LiveLibrary)
				Me.mLivelib = value
			End Set
		End Property

		''' <summary>
		''' Check genotypes loaded from experiment
		''' </summary>
		Public Property loadchk() As Boolean
			Get
				Return Me.mLoadchk
			End Get

			Set(ByVal value As Boolean)
				Me.mLoadchk = value
			End Set
		End Property

		''' <summary>
		''' Overwrite
		''' </summary>
		Public Property overwrite() As Boolean
			Get
				Return Me.mOverwrite
			End Get

			Set(ByVal value As Boolean)
				Me.mOverwrite = value
			End Set
		End Property

		''' <summary>
		''' the simulation should stop
		''' </summary>
		Private mShouldStop As Boolean

		''' <summary>
		''' number of steps
		''' </summary>
		Private mTime As Integer

		''' <summary>
		''' User script
		''' </summary>
		Private mUsercode As String

		''' <summary>
		''' world object
		''' </summary>
		Private mWorld As FrameStick.GlobalContext.ExperimentDefinition.VisualStyleDefinition.World

		''' <summary>
		''' the simulation should stop
		''' </summary>
		Public Property shouldStop() As Boolean
			Get
				Return Me.mShouldStop
			End Get

			Set(ByVal value As Boolean)
				Me.mShouldStop = value
			End Set
		End Property

		''' <summary>
		''' number of steps
		''' </summary>
		Public Property time() As Integer
			Get
				Return Me.mTime
			End Get

			Set(ByVal value As Integer)
				Me.mTime = value
			End Set
		End Property

		''' <summary>
		''' User Script
		''' </summary>
		Public Property usercode() As String
			Get
				Return Me.mUsercode
			End Get

			Set(ByVal value As String)
				Me.mUsercode = value
			End Set
		End Property

		''' <summary>
		''' world object
		''' </summary>
		Public Property world() As FrameStick.GlobalContext.ExperimentDefinition.VisualStyleDefinition.World
			Get
				Return Me.mWorld
			End Get

			Set(ByVal value As FrameStick.GlobalContext.ExperimentDefinition.VisualStyleDefinition.World)
				Me.mWorld = value
			End Set
		End Property

		''' <summary>
		''' Trigger autosave now
		''' </summary>
		Public Sub autosave()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' export
		''' </summary>
		Public Sub export(ByVal filename As String, ByVal options As Integer, ByVal genotypegroup As Integer, ByVal creaturesgroup As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' import
		''' </summary>
		Public Sub import(ByVal filename As String, ByVal options As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' Initialze experiment
		''' </summary>
		Public Sub init()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' load
		''' </summary>
		Public Sub load(ByVal filename As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' Reload experiment definition
		''' </summary>
		Public Sub loadexpdef()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' (re)load neuron definitions
		''' </summary>
		Public Sub loadNeurons(ByVal directorypath As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' print message
		''' </summary>
		Public Sub message(ByVal text As String, ByVal level As Integer)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' create new Simulator
		''' </summary>
		Public Sub New()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' print information message
		''' </summary>
		Public Sub print(ByVal text As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' save
		''' </summary>
		Public Sub save(ByVal filename As String)
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' do signle simulation step
		''' </summary>
		''' <remarks>eigendlich "step"</remarks>
		Public Sub nextStep()
			' BUG: Implementieren
		End Sub

		''' <summary>
		''' stop simulation
		''' </summary>
		''' <remarks>eigendlich "stop"</remarks>
		Public Sub stopSimulation()
			' BUG: Implementieren
		End Sub
	End Class

End Namespace
