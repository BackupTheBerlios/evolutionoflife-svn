
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

	Private mVorName As String

	Public Property VorName() As String
		Get
			Return Me.mVorName
		End Get

		Set(ByVal Name As String)
			Me.mVorName = Name
		End Set
	End Property

	Private mNachName As String

	Public Property NachName() As String
		Get
			Return Me.mNachName
		End Get

		Set(ByVal Name As String)
			Me.mNachName = Name
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









	''' <summary>
	''' Yahoo Kennung
	''' </summary>
	''' <remarks></remarks>

	''' <summary>
	''' Yahoo Kennung
	''' </summary>
	''' <remarks></remarks>

	''' <summary>
	''' wird verschlüsselt gespeichert, und soll wenn möglich dazu dienen, dass nur er seine Objekte bearbeiten kann.
	''' </summary>
	''' <remarks></remarks>
	Private mPasswort As String

	''' <summary>
	''' Wird verschlüsselt gespeichert, und soll wenn möglich dazu dienen, dass nur er seine Objekte bearbeiten kann.
	''' Als Verschlüssellungs-Algorithmus habe ich "SHA512" gewählt
	''' </summary>
	''' <remarks>Es wird das verschlüsselte Passwort zurück gegeben bzw.
	''' das im Klartext angegebene Passwort verschlüsselt gespeichert.</remarks>
	Public Property Passwort() As String
		Get
			Return Me.mPasswort
		End Get
		Set(ByVal Text As String)
			' BUG: Verschlüsselung einbauen und dokumentieren
			Me.mPasswort = Me.EncryptPassword(Text)
		End Set
	End Property











	''' <summary>
	''' Das aus dem Geburtstag errechnete Alter des Authos
	''' </summary>
	Public ReadOnly Property Alter() As Integer
		Get
			' BUG: Monate, Tage etc. vergleichen, da sonst Fehelerhaft
			Dim AktMonat As Integer = System.DateTime.Now.Month

			Dim Jahre As Integer = System.DateTime.Now.Year - Me.mGeburtstag.Year

			' Wenn der Monat größer als der aktuelle ist, ist könnte er/sie
			' dieses Jahr bereits Geburtstag gehabt haben
			If AktMonat > Me.Geburtstag.Month Then
				' Hatte er/sie bereits
				Jahre += 1
			ElseIf AktMonat = Me.mGeburtstag.Month Then
				' wenn es der aktuelle Monat ist, müssen wir nun noch eaus bekommen,
				' ob der Tag schon vorbei oder heute ist
				If System.DateTime.Now.Day >= Me.mGeburtstag.Day Then
					Jahre += 1
				End If
			End If

			Return Jahre
		End Get
	End Property

	''' <summary>
	''' Dieser Konstruktor legt ein Objekt für ein bereits bekannten Author an um diesen im Speicher halten zu können
	''' </summary>
	''' <param name="GUID"></param>
	Public Sub New(ByVal GUID As System.Guid, ByVal ScreenName As String, _
	 ByVal Vorname As String, ByVal Nachname As String, _
	 ByVal MailAddresse As String, _
	 ByVal Passwort As String, ByVal WwwAdresse As Uri, ByVal IcqKennung As String, _
	 ByVal MsnKennung As String, ByVal YahooKennung As String, ByVal Land As String, _
	 ByVal Postleitzahl As String, ByVal Ort As String, ByVal Strasse As String, _
	 ByVal Hausnummer As String)

		Me.mGUID = GUID
		Me.ScreenName = ScreenName
		Me.VorName = Vorname
		Me.NachName = Nachname
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
	Public Sub New(ByVal ScreenName As String, ByVal Vorname As String, ByVal Nachname As String, ByVal Mail As String, ByVal Passwort As String)
		Me.mGUID = System.Guid.NewGuid
		Me.ScreenName = ScreenName
		Me.VorName = Nachname
		Me.NachName = Nachname
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
		Text += Me.VorName
		Text += "</VorName>"

		Text += "<NachName>"
		Text += Me.NachName
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

	Public Function EncryptPassword(ByVal TextToHash As String) As String
		Dim md5 As System.Security.Cryptography.MD5CryptoServiceProvider
		Dim bytValue() As Byte
		Dim bytHash() As Byte

		' Create New Crypto Service Provider Object
		md5 = New System.Security.Cryptography.MD5CryptoServiceProvider

		' Convert the original string to array of Bytes
		bytValue = System.Text.Encoding. _
		 UTF8.GetBytes(TextToHash)

		' Compute the Hash, returns an array of Bytes
		bytHash = md5.ComputeHash(bytValue)

		md5.Clear()

		' Return a base 64 encoded string of the Hash value
		Return Convert.ToBase64String(bytHash)
	End Function

End Class
