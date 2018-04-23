Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.Utils.Drawing

Namespace WindowsApplication3
	Public Class DateTapePainter
		Inherits BaseEditPainter
		Public Sub New()
		End Sub

		' Fields...
		Private _HighlightedItemInfo As SkinElementInfo

		Private ReadOnly Property HighlightedItemInfo() As SkinElementInfo
			Get
				If _HighlightedItemInfo Is Nothing Then
					Dim skin As Skin = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel)
					Dim elem As SkinElement = skin(CommonSkins.SkinHighlightedItem)
					_HighlightedItemInfo = New SkinElementInfo(elem)
				End If
				Return _HighlightedItemInfo
			End Get
		End Property

		Protected Overrides Sub DrawContent(ByVal info As ControlGraphicsInfoArgs)
			MyBase.DrawContent(info)
			FillRectangle(info)
			DrawSelection(info)
			DrawDay(info)
			DrawHour(info)
			DrawMinute(info)
		End Sub

		Protected Overridable Sub FillRectangle(ByVal info As ControlGraphicsInfoArgs)
			Using brush As Brush = GetBackBrush()
				info.Graphics.FillRectangle(brush, info.Bounds)
			End Using
		End Sub

		Protected Overridable Sub DrawDay(ByVal info As ControlGraphicsInfoArgs)
			Dim dateViewInfo As DateTapeViewInfo = TryCast(info.ViewInfo, DateTapeViewInfo)
			DrawDigit(info.Graphics, dateViewInfo, dateViewInfo.DayBounds, DateInfoType.Day)
			info.Graphics.DrawRectangle(Pens.Black, dateViewInfo.DayBounds)
		End Sub

		Protected Overridable Sub DrawDigit(ByVal graphics As System.Drawing.Graphics, ByVal dateViewInfo As DateTapeViewInfo, ByVal rect As Rectangle, ByVal datePart As DateInfoType)
			Dim positions As Array = System.Enum.GetValues(GetType(PositionType))
			For Each positionType As PositionType In positions
				Dim dateRect As Rectangle = dateViewInfo.GetRect(rect, positionType)
				Dim edit As DateTapeEdit = TryCast(dateViewInfo.OwnerEdit, DateTapeEdit)
				Dim isSelectedPart As Boolean = edit IsNot Nothing AndAlso edit.SelectedDatePart = datePart
				If isSelectedPart AndAlso positionType <> PositionType.Middle Then
					Using br As Brush = GetSelectedBackBrush()
						graphics.FillRectangle(br, dateRect)
					End Using
				End If

				Dim item As RepositoryItemDateTapeEdit = TryCast(dateViewInfo.Item, RepositoryItemDateTapeEdit)
				Dim dt As DateTime = Convert.ToDateTime(dateViewInfo.EditValue)
				Dim dayValue As String = item.GetDayValueByPosition(datePart, positionType, dt).ToString()
				Using br As Brush = GetForeBrush(positionType, isSelectedPart)
					graphics.DrawString(dayValue, dateViewInfo.PaintAppearance.Font, br, dateRect)
				End Using
			Next positionType
		End Sub

		Protected Overridable Sub DrawHour(ByVal info As ControlGraphicsInfoArgs)
			Dim dateViewInfo As DateTapeViewInfo = TryCast(info.ViewInfo, DateTapeViewInfo)
			DrawDigit(info.Graphics, dateViewInfo, dateViewInfo.HourBounds, DateInfoType.Hour)
			info.Graphics.DrawRectangle(Pens.Black, dateViewInfo.HourBounds)
		End Sub

		Protected Overridable Sub DrawMinute(ByVal info As ControlGraphicsInfoArgs)
			Dim dateViewInfo As DateTapeViewInfo = TryCast(info.ViewInfo, DateTapeViewInfo)
			DrawDigit(info.Graphics, dateViewInfo, dateViewInfo.MinuteBounds, DateInfoType.Minute)
			info.Graphics.DrawRectangle(Pens.Black, dateViewInfo.MinuteBounds)
		End Sub

		Protected Overridable Sub DrawSelection(ByVal info As ControlGraphicsInfoArgs)
			Dim dateViewInfo As DateTapeViewInfo = TryCast(info.ViewInfo, DateTapeViewInfo)
			HighlightedItemInfo.Bounds = dateViewInfo.SelectionBounds
			HighlightedItemInfo.Graphics = info.Graphics
			ObjectPainter.DrawObject(info.Cache, SkinElementPainter.Default, HighlightedItemInfo)
		End Sub

		Protected Overridable Function GetBackBrush() As Brush
			Return New SolidBrush(LookAndFeelHelper.GetSystemColor(UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.Control))
		End Function

		Protected Overridable Function GetSelectedBackBrush() As Brush
			Return New SolidBrush(LookAndFeelHelper.GetSystemColor(UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.Highlight))
		End Function

		Protected Overridable Function GetForeBrush(ByVal positionType As PositionType, ByVal isSelectedPart As Boolean) As Brush
			If isSelectedPart AndAlso positionType <> PositionType.Middle Then
				Return New SolidBrush(LookAndFeelHelper.GetSystemColor(UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.HighlightText))
			End If
			If positionType = PositionType.Middle Then
				Return New SolidBrush(LookAndFeelHelper.GetSystemColor(UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.ControlText))
			End If
			Return New SolidBrush(LookAndFeelHelper.GetSystemColor(UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.GrayText))
		End Function
	End Class
End Namespace
