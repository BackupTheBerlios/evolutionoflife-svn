Imports Microsoft.VisualStudio.QualityTools.UnitTesting.Framework

'The following code was generated by Microsoft Test Code
' Generation V1.0. The test owner should check each test
' for validity.


''' <summary>
''' This is a test class for Author and is intended
''' to contain all Author Unit Tests
''' </summary>
<TestClass()> Public Class AuthorTest

	Private ScreenName As String = "henryfr"
	Private Vorname As String = "Henry"
	Private Nachname As String = "Fr�drich"
	Private Mail As String = "henryfr@web.de"
	Private Passwort As String = "Passwort"

	''' <summary>
	''' Initialize() is called once during test execution before
	''' test methods in this test class are executed.
	''' </summary>
	<TestInitialize()> Public Sub Initialize()
		' TODO: Add test initialization code
	End Sub

	''' <summary>
	''' Cleanup() is called once during test execution after
	''' test methods in this class have executed unless
	''' this test class' Initialize() method throws an exception.
	''' </summary>
	<TestCleanup()> Public Sub Cleanup()
		' TODO: Add test cleanup code
	End Sub

	Private m_testContext As TestContext

	Public Property TestContext() As TestContext
		Get
			Return m_testContext
		End Get

		Set(ByVal Value As TestContext)
			m_testContext = Value
		End Set
	End Property

	''' <summary>
	''' ScreenNameTest is a test case for Public Property ScreenName()
	''' </summary>
	<TestMethod()> Public Sub ScreenNameTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "ScreenName"

		target.ScreenName = val

		Assert.AreEqual(val, target.ScreenName)
	End Sub

	''' <summary>
	''' ToXMLTest is a test case for Public Function ToXML()
	''' </summary>
	<TestMethod()> Public Sub ToXMLTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		' TODO: �berarbeiten
		Dim expected As String = "Sollte"
		Dim actual As String = "Ist"

		actual = target.ToXML
		Assert.AreEqual(expected, actual)

		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	''' <summary>
	''' AlterTest is a test case for Public Property Alter()
	''' </summary>
	<TestMethod()> Public Sub AlterTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		target.Geburtstag = New Date(CLng("21.12.1958"))

		' TODO: Stimmt das ?
		Dim val As Integer = 45

		Assert.AreEqual(val, target.Alter)

		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	''' <summary>
	''' GeburtstagTest is a test case for Public Property Geburtstag()
	''' </summary>
	<TestMethod()> Public Sub GeburtstagTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As Date = New Date(CLng("21.12.1958"))

		target.Geburtstag = val

		Assert.AreEqual(val, target.Geburtstag)
	End Sub

	''' <summary>
	''' GUIDTest is a test case for Public Property GUID()
	''' </summary>
	<TestMethod()> Public Sub GUIDTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As System.Guid = System.Guid.NewGuid

		Assert.AreEqual(val, target.GUID)

		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	''' <summary>
	''' HausnummerTest is a test case for Public Property Hausnummer()
	''' </summary>
	<TestMethod()> Public Sub HausnummerTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "12a"

		target.Hausnummer = val

		Assert.AreEqual(val, target.Hausnummer)
	End Sub

	''' <summary>
	''' ICQTest is a test case for Public Property ICQ()
	''' </summary>
	<TestMethod()> Public Sub ICQTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "N/A"

		target.ICQ = val

		Assert.AreEqual(val, target.ICQ)
	End Sub

	''' <summary>
	''' LandTest is a test case for Public Property Land()
	''' </summary>
	<TestMethod()> Public Sub LandTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "Deutschland"

		target.Land = val

		Assert.AreEqual(val, target.Land)
	End Sub

	''' <summary>
	''' MailTest is a test case for Public Property Mail()
	''' </summary>
	<TestMethod()> Public Sub MailTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "ich@wir.de"

		target.Mail = val

		Assert.AreEqual(val, target.Mail)

		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	''' <summary>
	''' MSNTest is a test case for Public Property MSN()
	''' </summary>
	<TestMethod()> Public Sub MSNTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "N/A"

		target.MSN = val

		Assert.AreEqual(val, target.MSN)
	End Sub

	''' <summary>
	''' NachnameTest is a test case for Public Property Nachname()
	''' </summary>
	<TestMethod()> Public Sub NachnameTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "Mustermann"

		target.Nachname = val

		Assert.AreEqual(val, target.Nachname)
	End Sub

	''' <summary>
	''' OrtTest is a test case for Public Property Ort()
	''' </summary>
	<TestMethod()> Public Sub OrtTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "Berlin"

		target.Ort = val

		Assert.AreEqual(val, target.Ort)
	End Sub

	''' <summary>
	''' PasswortTest is a test case for Public Property Passwort()
	''' </summary>
	<TestMethod()> Public Sub PasswortTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "xyz0815"

		target.Passwort = val

		' Kommt verschl�sselt zur�ck
		Assert.AreEqual(val, target.Passwort)

		Assert.Inconclusive("Verify the correctness of this test method.")
	End Sub

	''' <summary>
	''' PLZTest is a test case for Public Property PLZ()
	''' </summary>
	<TestMethod()> Public Sub PLZTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "12627"

		target.PLZ = val

		Assert.AreEqual(val, target.PLZ)
	End Sub

	''' <summary>
	''' StrasseTest is a test case for Public Property Strasse()
	''' </summary>
	<TestMethod()> Public Sub StrasseTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "MusterStrasse"

		target.Strasse = val

		Assert.AreEqual(val, target.Strasse)
	End Sub

	''' <summary>
	''' URLTest is a test case for Public Property URL()
	''' </summary>
	<TestMethod()> Public Sub URLTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As System.Uri = New System.Uri("http://www.nicht-mehr-allein.de/")

		target.URL = val

		Assert.AreEqual(val, target.URL)
	End Sub

	''' <summary>
	''' VornameTest is a test case for Public Property Vorname()
	''' </summary>
	<TestMethod()> Public Sub VornameTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "Klaus"

		target.Vorname = val

		Assert.AreEqual(val, target.Vorname)
	End Sub

	''' <summary>
	''' YIDTest is a test case for Public Property YID()
	''' </summary>
	<TestMethod()> Public Sub YIDTest()

		Dim target As Klassen.Author = New Klassen.Author(Me.ScreenName, Me.Vorname, Me.Nachname, Me.Mail, Me.Passwort)

		Dim val As String = "N/A"

		target.YID = val

		Assert.AreEqual(val, target.YID)
	End Sub
End Class
