
''' <summary>
''' Jeder Datensatz steht für eine Adresse des Autors
''' </summary>
Public Class Adresse

	Private GUID As System.Guid
	Private Author_GUID As Klassen.Author.GUID
	Private Land As Integer
	Private PLZ As Integer
	Private Ort As Integer
	Private Strasse As Integer
	Private Hausnummer As Integer
	Private AdressArt As Klassen.AdressArten
End Class
