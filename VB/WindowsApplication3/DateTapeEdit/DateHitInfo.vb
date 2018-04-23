Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing

Namespace WindowsApplication3
	Public Class DateHitInfo
		Public Sub New()
			MyBase.New()
		End Sub

		' Fields...
		Private _Point As Point
		Private _HitInfoType As DateInfoType

		Public Property HitInfoType() As DateInfoType
			Get
				Return _HitInfoType
			End Get
			Set(ByVal value As DateInfoType)
				_HitInfoType = value
			End Set
		End Property


		Public Property Point() As Point
			Get
				Return _Point
			End Get
			Set(ByVal value As Point)
				_Point = value
			End Set
		End Property

	End Class
End Namespace
