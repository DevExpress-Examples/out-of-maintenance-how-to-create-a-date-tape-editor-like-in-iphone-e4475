using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System.Reflection;
using DevExpress.XtraEditors.ViewInfo;
using System.Net;

namespace WindowsApplication3
{
    [ToolboxItem(true)]
    public class DateTapeEdit : BaseEdit
    {
        static DateTapeEdit() { RepositoryItemDateTapeEdit.RegisterCustomEdit(); }

        public DateTapeEdit() : base() { }

        // Fields...
        private DateInfoType _SelectedDatePart;
        [Browsable(false)]
        public DateTime Date
        {
            get { return Convert.ToDateTime(EditValue); }
        }

        public DateInfoType SelectedDatePart
        {
            get { return _SelectedDatePart; }
            set
            {
                if (_SelectedDatePart != value)
                {
                    _SelectedDatePart = value;
                    Invalidate();
                }
            }
        }

        public override object EditValue
        {
            get
            {
                return base.EditValue;
            }
            set
            {
                if (value == null || value.Equals(base.EditValue)) return;
                DateTime dt;
                if (DateTime.TryParse(value.ToString(), out dt))
                    base.EditValue = dt;
            }
        }

        public override string EditorTypeName
        {
            get
            {
                return
                    RepositoryItemDateTapeEdit.CustomEditName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemDateTapeEdit Properties
        {
            get { return base.Properties as RepositoryItemDateTapeEdit; }
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (IsInputKey(e.KeyData)) e.Handled = true;
            base.OnKeyDown(e);
            if (SelectedDatePart == DateInfoType.None) return;
            int selectedDatePartValue = (int)SelectedDatePart;
            if (e.KeyData == Keys.Up)
                EditValue = Properties.GetPreviousDate(SelectedDatePart, Date);
            if (e.KeyData == Keys.Down)
                EditValue = Properties.GetNextDate(SelectedDatePart, Date);
            if (e.KeyData == Keys.Left)
            {
                if (selectedDatePartValue > 1)
                    SelectedDatePart = (DateInfoType)((int)SelectedDatePart - 1);
            }
            if (e.KeyData == Keys.Right)
            {
                if (selectedDatePartValue < Enum.GetValues(typeof(DateInfoType)).Length - 1)
                    SelectedDatePart = (DateInfoType)((int)SelectedDatePart + 1);
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right) return true; 
            return base.IsInputKey(keyData);
        }

        public DateHitInfo CalcHitInfo(Point point)
        {
            return ViewInfo.CalcHitInfo(point);
        }

        new DateTapeViewInfo ViewInfo
        {
            get { return base.ViewInfo as DateTapeViewInfo; }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            DateHitInfo hitInfo = CalcHitInfo(e.Location);
            SelectedDatePart = hitInfo.HitInfoType;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (SelectedDatePart != DateInfoType.None)
                if (e.Delta < 0)
                    EditValue = Properties.GetNextDate(SelectedDatePart, Date);
                else
                    EditValue = Properties.GetPreviousDate(SelectedDatePart, Date);
        }
    }

}