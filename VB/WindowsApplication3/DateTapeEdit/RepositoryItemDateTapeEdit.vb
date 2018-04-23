Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports System.Reflection

Namespace WindowsApplication3
	<UserRepositoryItem("RegisterCustomEdit")> _
	Public Class RepositoryItemDateTapeEdit
		Inherits RepositoryItem
		Shared Sub New()
			RegisterCustomEdit()
		End Sub

		Public Sub New()
		End Sub

		Public Const CustomEditName As String = "DateTapeEdit"

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return CustomEditName
			End Get
		End Property

		Public Shared Sub RegisterCustomEdit()

			Dim img As Image = Nothing
			Try
				img = CType(Bitmap.FromStream(System.Reflection.Assembly.GetExecutingAssembly(). GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp")), Bitmap)
			Catch
			End Try
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(DateTapeEdit), GetType(RepositoryItemDateTapeEdit), GetType(DateTapeViewInfo), New DateTapePainter(), True, img))

		End Sub

		Public Function GetCurrentDayValue(ByVal datePart As DateInfoType, ByVal dt As DateTime) As String
			If datePart = DateInfoType.Day Then
				Return dt.ToString("M")
			End If
			If datePart = DateInfoType.Hour Then
				Return dt.Hour.ToString()
			End If
			Return dt.Minute.ToString()
		End Function

		Public Function GetPreviousDayValue(ByVal datePart As DateInfoType, ByVal dt As DateTime) As String
			dt = GetPreviousDate(datePart, dt)
			If datePart = DateInfoType.Day Then
				Return dt.ToString("M")
			End If
			If datePart = DateInfoType.Hour Then
				Return dt.Hour.ToString()
			End If
			Return dt.Minute.ToString()
		End Function

		Public Function GetNextDayValue(ByVal datePart As DateInfoType, ByVal dt As DateTime) As String
			dt = GetNextDate(datePart, dt)
			If datePart = DateInfoType.Day Then
				Return dt.ToString("M")
			End If
			If datePart = DateInfoType.Hour Then
				Return dt.Hour.ToString()
			End If
			Return dt.Minute.ToString()
		End Function

		Public Function GetPreviousDate(ByVal datePart As DateInfoType, ByVal dt As DateTime) As DateTime
			Return GetDate(datePart, dt, -1)
		End Function

		Public Function GetNextDate(ByVal datePart As DateInfoType, ByVal dt As DateTime) As DateTime
		   Return GetDate(datePart, dt, 1)
		End Function

		Public Function GetDate(ByVal datePart As DateInfoType, ByVal dt As DateTime, ByVal val As Integer) As DateTime
			Try
				If datePart = DateInfoType.Day Then
					Return dt.AddDays(val)
				End If
				If datePart = DateInfoType.Hour Then
					Return dt.AddHours(val)
				End If
				Return dt.AddMinutes(val)
			Catch
			End Try
			Return dt
		End Function

		Public Function GetDayValueByPosition(ByVal datePart As DateInfoType, ByVal positionType As PositionType, ByVal dt As DateTime) As String
			If positionType = PositionType.Top Then
				Return GetPreviousDayValue(datePart, dt)
			End If
			If positionType = PositionType.Middle Then
				Return GetCurrentDayValue(datePart, dt)
			End If
			Return GetNextDayValue(datePart, dt)
		End Function

	End Class
End Namespace
