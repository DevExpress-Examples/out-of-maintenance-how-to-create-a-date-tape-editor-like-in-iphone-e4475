Imports Microsoft.VisualBasic
Imports System
Namespace WindowsApplication3
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
			Me.customerInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.dataSet11 = New WindowsApplication3.DataSet1()
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colCustomerID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
			Me.colFirstName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colLastName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colImage = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colDate = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemDateTapeEdit1 = New WindowsApplication3.RepositoryItemDateTapeEdit()
			Me.colCheck = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.galleryControl1 = New DevExpress.XtraBars.Ribbon.GalleryControl()
			Me.galleryControlClient1 = New DevExpress.XtraBars.Ribbon.GalleryControlClient()
			Me.dateTapeEdit1 = New WindowsApplication3.DateTapeEdit()
			CType(Me.customerInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemDateEdit1.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemDateTapeEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.galleryControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.galleryControl1.SuspendLayout()
			CType(Me.dateTapeEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' customerInfoBindingSource
			' 
			Me.customerInfoBindingSource.DataMember = "CustomerInfo"
			Me.customerInfoBindingSource.DataSource = Me.dataSet11
			' 
			' dataSet11
			' 
			Me.dataSet11.DataSetName = "DataSet1"
			Me.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			' 
			' imageList1
			' 
			Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
			Me.imageList1.Images.SetKeyName(0, "1.jpg")
			Me.imageList1.Images.SetKeyName(1, "2.jpg")
			Me.imageList1.Images.SetKeyName(2, "3.jpg")
			Me.imageList1.Images.SetKeyName(3, "4.jpg")
			Me.imageList1.Images.SetKeyName(4, "5.jpg")
			Me.imageList1.Images.SetKeyName(5, "6.jpg")
			Me.imageList1.Images.SetKeyName(6, "7.jpg")
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Springtime"
			' 
			' gridControl1
			' 
			Me.gridControl1.DataSource = Me.customerInfoBindingSource
			Me.gridControl1.Location = New System.Drawing.Point(12, 2)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemDateTapeEdit1, Me.repositoryItemDateEdit1})
			Me.gridControl1.Size = New System.Drawing.Size(494, 490)
			Me.gridControl1.TabIndex = 1
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colCustomerID, Me.colFirstName, Me.colLastName, Me.colImage, Me.colDate, Me.colCheck})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			Me.gridView1.RowHeight = 70
			' 
			' colCustomerID
			' 
			Me.colCustomerID.ColumnEdit = Me.repositoryItemDateEdit1
			Me.colCustomerID.FieldName = "CustomerID"
			Me.colCustomerID.Name = "colCustomerID"
			Me.colCustomerID.Visible = True
			Me.colCustomerID.VisibleIndex = 0
			' 
			' repositoryItemDateEdit1
			' 
			Me.repositoryItemDateEdit1.AutoHeight = False
			Me.repositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1"
			Me.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			' 
			' colFirstName
			' 
			Me.colFirstName.FieldName = "FirstName"
			Me.colFirstName.Name = "colFirstName"
			Me.colFirstName.Visible = True
			Me.colFirstName.VisibleIndex = 1
			' 
			' colLastName
			' 
			Me.colLastName.FieldName = "LastName"
			Me.colLastName.Name = "colLastName"
			' 
			' colImage
			' 
			Me.colImage.FieldName = "Image"
			Me.colImage.Name = "colImage"
			' 
			' colDate
			' 
			Me.colDate.ColumnEdit = Me.repositoryItemDateTapeEdit1
			Me.colDate.FieldName = "Date"
			Me.colDate.Name = "colDate"
			Me.colDate.Visible = True
			Me.colDate.VisibleIndex = 2
			' 
			' repositoryItemDateTapeEdit1
			' 
			Me.repositoryItemDateTapeEdit1.AutoHeight = False
			Me.repositoryItemDateTapeEdit1.Name = "repositoryItemDateTapeEdit1"
			' 
			' colCheck
			' 
			Me.colCheck.FieldName = "Check"
			Me.colCheck.Name = "colCheck"
			' 
			' galleryControl1
			' 
			Me.galleryControl1.Controls.Add(Me.galleryControlClient1)
			Me.galleryControl1.DesignGalleryGroupIndex = 0
			Me.galleryControl1.DesignGalleryItemIndex = 0
			Me.galleryControl1.Location = New System.Drawing.Point(533, 124)
			Me.galleryControl1.Name = "galleryControl1"
			Me.galleryControl1.Size = New System.Drawing.Size(253, 368)
			Me.galleryControl1.TabIndex = 2
			Me.galleryControl1.Text = "galleryControl1"
			' 
			' galleryControlClient1
			' 
			Me.galleryControlClient1.GalleryControl = Me.galleryControl1
			Me.galleryControlClient1.Location = New System.Drawing.Point(2, 2)
			Me.galleryControlClient1.Size = New System.Drawing.Size(232, 364)
			' 
			' dateTapeEdit1
			' 
			Me.dateTapeEdit1.Location = New System.Drawing.Point(533, 12)
			Me.dateTapeEdit1.Name = "dateTapeEdit1"
			Me.dateTapeEdit1.Properties.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.dateTapeEdit1.Properties.Appearance.Options.UseFont = True
			Me.dateTapeEdit1.SelectedDatePart = WindowsApplication3.DateInfoType.None
			Me.dateTapeEdit1.Size = New System.Drawing.Size(253, 90)
			Me.dateTapeEdit1.TabIndex = 3
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(841, 499)
			Me.Controls.Add(Me.dateTapeEdit1)
			Me.Controls.Add(Me.galleryControl1)
			Me.Controls.Add(Me.gridControl1)
			Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
			Me.Name = "MainForm"
			Me.Text = "How to create DateTapeEdit"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.customerInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataSet11, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemDateEdit1.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemDateTapeEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.galleryControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.galleryControl1.ResumeLayout(False)
			CType(Me.dateTapeEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region


		Private customerInfoBindingSource As System.Windows.Forms.BindingSource
		Private dataSet11 As DataSet1
		Private imageList1 As System.Windows.Forms.ImageList
		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private galleryControl1 As DevExpress.XtraBars.Ribbon.GalleryControl
		Private galleryControlClient1 As DevExpress.XtraBars.Ribbon.GalleryControlClient
		Private colCustomerID As DevExpress.XtraGrid.Columns.GridColumn
		Private colFirstName As DevExpress.XtraGrid.Columns.GridColumn
		Private colLastName As DevExpress.XtraGrid.Columns.GridColumn
		Private colImage As DevExpress.XtraGrid.Columns.GridColumn
		Private colDate As DevExpress.XtraGrid.Columns.GridColumn
		Private colCheck As DevExpress.XtraGrid.Columns.GridColumn
		Private repositoryItemDateTapeEdit1 As RepositoryItemDateTapeEdit
		Private repositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
		Private dateTapeEdit1 As DateTapeEdit
	End Class
End Namespace

