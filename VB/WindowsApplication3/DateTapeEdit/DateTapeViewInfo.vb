Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Repository

Namespace WindowsApplication3
	Public Class DateTapeViewInfo
		Inherits BaseEditViewInfo
		Public Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)
			_HorIndent = 2
			_VertIndent = 2
		End Sub

		' Fields...
		Private _SelectionBounds As Rectangle
		Private _VertIndent As Integer
		Private _HorIndent As Integer
		Private _MinuteBounds As Rectangle
		Private _HourBounds As Rectangle
		Private _DayBounds As Rectangle

		Public Property DayBounds() As Rectangle
			Get
				Return _DayBounds
			End Get
			Set(ByVal value As Rectangle)
				_DayBounds = value
			End Set
		End Property

		Public Property HourBounds() As Rectangle
			Get
				Return _HourBounds
			End Get
			Set(ByVal value As Rectangle)
				_HourBounds = value
			End Set
		End Property

		Public Property SelectionBounds() As Rectangle
			Get
				Return _SelectionBounds
			End Get
			Set(ByVal value As Rectangle)
				_SelectionBounds = value
			End Set
		End Property


		Public Property MinuteBounds() As Rectangle
			Get
				Return _MinuteBounds
			End Get
			Set(ByVal value As Rectangle)
				_MinuteBounds = value
			End Set
		End Property

		Protected Overridable ReadOnly Property HorIndent() As Integer
			Get
				Return _HorIndent
			End Get
		End Property


		Protected Overridable ReadOnly Property VertIndent() As Integer
			Get
				Return _VertIndent
			End Get
		End Property

		Protected Overridable Sub CalcDayBounds()
			DayBounds = New Rectangle(Bounds.X + HorIndent, Bounds.Y + VertIndent, Bounds.Width \ 2 - HorIndent, Bounds.Height - VertIndent - 1)
		End Sub

		Protected Overridable Sub CalcHourBounds()
			HourBounds = New Rectangle(DayBounds.Right + HorIndent, Bounds.Y + VertIndent, Bounds.Width \ 4 - HorIndent, Bounds.Height - VertIndent - 1)
		End Sub

		Protected Overridable Sub CalcMinuteBounds()
			MinuteBounds = New Rectangle(HourBounds.Right + HorIndent, Bounds.Y + VertIndent, Bounds.Width \ 4 - HorIndent - 1, Bounds.Height - VertIndent - 1)
		End Sub

		Protected Overridable Sub CalcSelectionBounds()
			SelectionBounds = New Rectangle(DayBounds.X + 1, DayBounds.Y + DayBounds.Height \ 3, Bounds.Width - HorIndent - 4, Bounds.Height \ 3)
		End Sub

		Public Function GetRect(ByVal rect As Rectangle, ByVal positionType As PositionType) As Rectangle
			If positionType = PositionType.Top Then
				Return New Rectangle(rect.X, rect.Y, rect.Width, rect.Height \ 3)
			End If
			If positionType = PositionType.Middle Then
				Return New Rectangle(rect.X, rect.Y + rect.Height \ 3, rect.Width, rect.Height \ 3)
			End If
			Return New Rectangle(rect.X, rect.Y + rect.Height * 2 \ 3, rect.Width, rect.Height \ 3)
		End Function

		Public Shadows Function CalcHitInfo(ByVal point As Point) As DateHitInfo
			If DayBounds.Contains(point) Then
				Return New DateHitInfo() With {.Point = point, .HitInfoType = DateInfoType.Day}
			End If
			If HourBounds.Contains(point) Then
				Return New DateHitInfo() With {.Point = point, .HitInfoType = DateInfoType.Hour}
			End If
			If MinuteBounds.Contains(point) Then
				Return New DateHitInfo() With {.Point = point, .HitInfoType = DateInfoType.Minute}
			End If
			Return New DateHitInfo() With {.Point = point, .HitInfoType = DateInfoType.None}
		End Function

		Protected Overrides Function CalcMinHeightCore(ByVal g As Graphics) As Integer
			Return MyBase.CalcMinHeightCore(g) * 3
		End Function

		Protected Overrides Sub Assign(ByVal info As BaseControlViewInfo)
			MyBase.Assign(info)
			Dim viewInfo As DateTapeViewInfo = TryCast(info, DateTapeViewInfo)
			DayBounds = viewInfo.DayBounds
			HourBounds = viewInfo.HourBounds
			MinuteBounds = viewInfo.MinuteBounds
			SelectionBounds = viewInfo.SelectionBounds
		End Sub

		Protected Overrides Sub CalcContentRect(ByVal bounds As Rectangle)
			MyBase.CalcContentRect(bounds)
			CalcDayBounds()
			CalcHourBounds()
			CalcMinuteBounds()
			CalcSelectionBounds()
		End Sub

		Public Overrides Overloads Sub Offset(ByVal x As Integer, ByVal y As Integer)
			MyBase.Offset(x, y)
			If (Not DayBounds.IsEmpty) Then
				_DayBounds.Offset(x, y)
			End If
			If (Not HourBounds.IsEmpty) Then
				_HourBounds.Offset(x, y)
			End If
			If (Not MinuteBounds.IsEmpty) Then
				_MinuteBounds.Offset(x, y)
			End If
			If (Not SelectionBounds.IsEmpty) Then
				_SelectionBounds.Offset(x, y)
			End If
		End Sub
	End Class
End Namespace
