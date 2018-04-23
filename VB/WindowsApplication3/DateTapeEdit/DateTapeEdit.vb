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
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Net

Namespace WindowsApplication3
	<ToolboxItem(True)> _
	Public Class DateTapeEdit
		Inherits BaseEdit
		Shared Sub New()
			RepositoryItemDateTapeEdit.RegisterCustomEdit()
		End Sub

		Public Sub New()
			MyBase.New()
		End Sub

		' Fields...
		Private _SelectedDatePart As DateInfoType
		<Browsable(False)> _
		Public ReadOnly Property [Date]() As DateTime
			Get
				Return Convert.ToDateTime(EditValue)
			End Get
		End Property

		Public Property SelectedDatePart() As DateInfoType
			Get
				Return _SelectedDatePart
			End Get
			Set(ByVal value As DateInfoType)
				If _SelectedDatePart <> value Then
					_SelectedDatePart = value
					Invalidate()
				End If
			End Set
		End Property

		Public Overrides Property EditValue() As Object
			Get
				Return MyBase.EditValue
			End Get
			Set(ByVal value As Object)
				If value Is Nothing OrElse value.Equals(MyBase.EditValue) Then
					Return
				End If
				Dim dt As DateTime
				If DateTime.TryParse(value.ToString(), dt) Then
					MyBase.EditValue = dt
				End If
			End Set
		End Property

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemDateTapeEdit.CustomEditName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemDateTapeEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemDateTapeEdit)
			End Get
		End Property


		Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
			If IsInputKey(e.KeyData) Then
				e.Handled = True
			End If
			MyBase.OnKeyDown(e)
			If SelectedDatePart = DateInfoType.None Then
				Return
			End If
			Dim selectedDatePartValue As Integer = CInt(Fix(SelectedDatePart))
			If e.KeyData = Keys.Up Then
				EditValue = Properties.GetPreviousDate(SelectedDatePart, [Date])
			End If
			If e.KeyData = Keys.Down Then
				EditValue = Properties.GetNextDate(SelectedDatePart, [Date])
			End If
			If e.KeyData = Keys.Left Then
				If selectedDatePartValue > 1 Then
					SelectedDatePart = CType(CInt(Fix(SelectedDatePart)) - 1, DateInfoType)
				End If
			End If
			If e.KeyData = Keys.Right Then
				If selectedDatePartValue < System.Enum.GetValues(GetType(DateInfoType)).Length - 1 Then
					SelectedDatePart = CType(CInt(Fix(SelectedDatePart)) + 1, DateInfoType)
				End If
			End If
		End Sub

		Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
			If keyData = Keys.Up OrElse keyData = Keys.Down OrElse keyData = Keys.Left OrElse keyData = Keys.Right Then
				Return True
			End If
			Return MyBase.IsInputKey(keyData)
		End Function

		Public Function CalcHitInfo(ByVal point As Point) As DateHitInfo
			Return ViewInfo.CalcHitInfo(point)
		End Function

		Private Shadows ReadOnly Property ViewInfo() As DateTapeViewInfo
			Get
				Return TryCast(MyBase.ViewInfo, DateTapeViewInfo)
			End Get
		End Property

		Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
			MyBase.OnMouseDown(e)
			Dim hitInfo As DateHitInfo = CalcHitInfo(e.Location)
			SelectedDatePart = hitInfo.HitInfoType
		End Sub

		Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
			MyBase.OnMouseWheel(e)
			If SelectedDatePart <> DateInfoType.None Then
				If e.Delta < 0 Then
					EditValue = Properties.GetNextDate(SelectedDatePart, [Date])
				Else
					EditValue = Properties.GetPreviousDate(SelectedDatePart, [Date])
				End If
			End If
		End Sub
	End Class

End Namespace