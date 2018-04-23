Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid
Imports DevExpress.XtraBars.Helpers


Namespace WindowsApplication3
	Partial Public Class MainForm
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub InitData()
			For i As Integer = 0 To 4
				dataSet11.Tables(0).Rows.Add(New Object() { i, String.Format("FirstName {0}", i), i, imageList1.Images(i), DateTime.Today.AddDays(i), True })
				dataSet11.Tables(1).Rows.Add(New Object() { i, String.Format("FirstName {0}", i), i })
			Next i
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			InitData()
			SkinHelper.InitSkinGallery(galleryControl1)
			dateTapeEdit1.EditValue = DateTime.Now
		End Sub

	End Class
End Namespace
