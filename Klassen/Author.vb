
''' <summary>
''' Ein Autor in "Evolution des Lebens"
''' </summary>
''' <remarks>Diese Klasse ist in der Funktion ToXML bereits darauf vorbereitet, dass ein Autor mehrere :
''' 
''' Adresse, Mail-Adresse, URL's, ICQ-Accounts, MSN-Accounts oder ICQ-Accounts
''' 
''' haben könnte. Allerdings wird bisher intern nur eine benutzt. Aber es sollte durchaus möglich sein, das System darauf umzustellen, mit Listen zu arbeiten.</remarks>
Public Class Author

	''' <summary>
	''' Jeder Autor muss eindeutig indentifizierbar sein
	''' </summary>
	Private mGUID As System.Guid

	''' <summary>
	''' Jeder Autor muss eindeutig indentifizierbar sein
	''' </summary>
	Public ReadOnly Property GUID() As System.Guid
		Get
			Return Me.mGUID
		End Get
	End Property

	''' <summary>
	''' Was möchte der Autor als Namen bei seinen Objekten sehen=
	''' </summary>
	Private mScreenName As String

	''' <summary>
	''' Was möchte der Autor als Namen bei seinen Objekten sehen=
	''' </summary>
	Public Property ScreenName() As String
		Get
			Return Me.mScreenName
		End Get

		Set(ByVal Name As String)
			Me.mScreenName = Name
		End Set
	End Property

	Private mVorname As String

	Public Property Vorname() As String
		Get
			Return Me.mVorname
		End Get

		Set(ByVal Name As String)
			Me.mVorname = Name
		End Set
	End Property

	Private mNachname As String

	Public Property Nachname() As String
		Get
			Return Me.mNachname
		End Get

		Set(ByVal Name As String)
			Me.mNachname = Name
		End Set
	End Property

	Private mGeburtstag As Date

	Public Property Geburtstag() As Date
		Get
			Return Me.mGeburtstag
		End Get

		Set(ByVal Datum As Date)
			If Datum < System.DateTime.Now Then
				Me.mGeburtstag = Datum
			End If
		End Set
	End Property

	Private mMail As Uri

	Public Property Mail() As Uri
		Get
			Return Me.mMail
		End Get

		Set(ByVal MailAdresse As Uri)
			Me.mMail = MailAdresse
		End Set
	End Property

	Private mURL As Uri

	Public Property URL() As Uri
		Get
			Return Me.mURL
		End Get

		Set(ByVal WwwAdresse As Uri)
			Me.mURL = WwwAdresse
		End Set
	End Property

	Private mICQ As String

	Public Property ICQ() As String
		Get
			Return Me.mICQ
		End Get

		Set(ByVal IcqKennung As String)
			' BUG: lässt sich abfragen !!
			Me.mICQ = IcqKennung
		End Set
	End Property

	Private mMSN As String

	Public Property MSN() As String
		Get
			Return Me.mMSN
		End Get

		Set(ByVal MsnKennung As String)
			' BUG: lässt sich sicher testen !!
			Me.mMSN = MsnKennung
		End Set
	End Property

	''' <summary>
	''' Yahoo Kennung
	''' </summary>
	''' <remarks></remarks>
	Private mYID As String

	''' <summary>
	''' Yahoo Kennung
	''' </summary>
	''' <remarks></remarks>
	Public Property YID() As String
		Get
			Return Me.mYID
		End Get

		Set(ByVal YahooKennung As String)
			' BUG: lässt sich bestimmt testen
			Me.mYID = YahooKennung
		End Set
	End Property

	''' <summary>
	''' wird verschlüsselt gespeichert, und soll wenn möglich dazu dienen, dass nur er seine Objekte bearbeiten kann.
	''' </summary>
	''' <remarks></remarks>
	Private mPasswort As String

	''' <summary>
	''' wird verschlüsselt gespeichert, und soll wenn möglich dazu dienen, dass nur er seine Objekte bearbeiten kann.
	''' </summary>
	''' <remarks>Es wird das verschlüsselte Passwort zurück gegeben bzw.
	''' das im Klartext angegebene Passwort verschlüsselt gespeichert.</remarks>
	Public Property Passwort() As String
		Get
			Return Me.mPasswort
		End Get
		Set(ByVal Text As String)
			' BUG: Verschlüsselung einbauen und dokumentieren
			Me.mPasswort = Text
		End Set
	End Property

	Private mLand As String

	Public Property Land() As String
		Get
			Return Me.mLand
		End Get

		Set(ByVal value As String)
			Me.mLand = value
		End Set
	End Property

	Private mPLZ As String

	Public Property PLZ() As String
		Get
			Return Me.mPLZ
		End Get

		Set(ByVal PostleitZahl As String)
			Me.mPLZ = PostleitZahl
		End Set
	End Property

	Private mOrt As String

	Public Property Ort() As String
		Get
			Return Me.mOrt
		End Get

		Set(ByVal Value As String)
			Me.mOrt = Value
		End Set
	End Property

	Private mHausnummer As String

	Public Property Hausnummer() As String
		Get
			Return Me.mHausnummer
		End Get

		Set(ByVal Value As String)
			Me.mHausnummer = Value
		End Set
	End Property

	Private mStrasse As String

	Public Property Strasse() As String
		Get
			Return Me.mStrasse
		End Get

		Set(ByVal value As String)
			Me.mStrasse = value
		End Set
	End Property

	''' <summary>
	''' Das aus dem Geburtstag errechnete Alter des Authos
	''' </summary>
	Public ReadOnly Property Alter() As Integer
		Get
			' BUG: Monate, Tage etc. vergleichen, da sonst Fhelerhaft
			' Aber wenn wir davon ausgehen, das ein Jahr 364,25 Tage hat, dann
			' sollte es fast stimmen
			Return CType(System.DateTime.Now.Subtract(Me.mGeburtstag).Days / 365.25, Integer)
		End Get
	End Property

	''' <summary>
	''' Dieser Konstruktor legt ein Objekt für ein bereits bekannten Author an um diesen im Speicher halten zu können
	''' </summary>
	''' <param name="GUID"></param>
	Public Sub New(ByVal GUID As System.Guid, ByVal ScreenName As String, _
	 ByVal Vorname As String, ByVal Nachname As String, ByVal MailAddresse As Uri, _
	 ByVal Passwort As String, ByVal WwwAdresse As Uri, ByVal IcqKennung As String, _
	 ByVal MsnKennung As String, ByVal YahooKennung As String, ByVal Land As String, _
	 ByVal Postleitzahl As String, ByVal Ort As String, ByVal Strasse As String, _
	 ByVal Hausnummer As String)

		Me.mGUID = GUID
		Me.ScreenName = ScreenName
		Me.Vorname = Vorname
		Me.Nachname = Nachname
		Me.Mail = MailAddresse
		Me.Passwort = Passwort
		Me.URL = WwwAdresse
		Me.ICQ = IcqKennung
		Me.MSN = MsnKennung
		Me.YID = YahooKennung
		Me.Land = Land
		Me.PLZ = Postleitzahl
		Me.Ort = Ort
		Me.Strasse = Strasse
		Me.Hausnummer = Hausnummer
	End Sub

	''' <summary>
	''' Der Standardkostruktor, der ein "NEUES" Objekt anlegen soll
	''' </summary>
	''' <param name="Passwort">im Klartext !!</param>
	Public Sub New(ByVal ScreenName As String, ByVal Vorname As String, ByVal Nachname As String, ByVal Mail As System.Uri, ByVal Passwort As String)
		Me.mGUID = System.Guid.NewGuid
		Me.ScreenName = ScreenName
		Me.Vorname = Nachname
		Me.Nachname = Nachname
		Me.Mail = Mail
		Me.Passwort = Passwort
	End Sub

	Public Function ToXML() As String
		Dim Text As String

		Text = "<author>"

		Text += "<guid>"
		Text += Me.GUID.ToString
		Text += "</guid>"

		Text += "<ScreenName>"
		Text += Me.ScreenName
		Text += "</ScreenName>"

		Text += "<VorName>"
		Text += Me.Vorname
		Text += "</VorName>"

		Text += "<NachName>"
		Text += Me.Nachname
		Text += "</NachName>"

		Text += "<GeburtsTag>"
		Text += Me.Geburtstag.ToString
		Text += "</GeburtsTag>"

		Text += "<Passwort>"
		Text += Me.Passwort
		Text += "</Passwort>"

		Text += "<Mails>"
		' Mails können mehrfach vorkommen, also später anpassen
		' BUG: Mehre Mail Adressen einbauen
		Text += "<Mail>"
		Text += Me.Mail.ToString
		Text += "</Mail>"
		Text += "</Mails>"

		Text += "<ICQs>"
		' es gibt Leute die haben mehrere
		' BUG: mehre ICQ einbaun
		Text += "<ICQ>"
		Text += Me.ICQ
		Text += "</ICQ>"
		Text += "</ICQs>"

		Text += "<MSNs>"
		' es gibt Leute die haben mehrere
		' BUG: mehre MSN einbaun
		Text += "<MSN>"
		Text += Me.MSN
		Text += "</MSN>"
		Text += "</MSNs>"

		Text += "<YIDs>"
		' es gibt Leute die haben mehrere
		' BUG: mehre YID einbaun
		Text += "<YID>"
		Text += Me.YID
		Text += "</>"
		Text += "</YIDs>"

		Text += "<URLs>"
		' es gibt Leute die haben mehrere
		' BUG: mehre URL einbaun
		Text += "<URL>"
		Text += Me.URL.ToString
		Text += "</URL>"
		Text += "</URLs>"

		Text += "<Adressen>"
		' es gibt Leute die haben mehrere
		' BUG: mehre Adressen einbaun
		Text += "<Adresse>"

		Text += "<Land>"
		Text += Me.Land
		Text += "</Land>"

		Text += "<PostleitZahl>"
		Text += Me.PLZ
		Text += "</PostleitZahl>"

		Text += "<Ort>"
		Text += Me.Ort
		Text += "</Ort>"

		Text += "<Strasse>"
		Text += Me.Strasse
		Text += "</Strasse>"

		Text += "<HausNummer>"
		Text += Me.Hausnummer
		Text += "</HausNummer>"

		Text += "</Adresse>"
		Text += "</Adressen>"

		Text += "</author>"

		Return Text
	End Function
End Class
