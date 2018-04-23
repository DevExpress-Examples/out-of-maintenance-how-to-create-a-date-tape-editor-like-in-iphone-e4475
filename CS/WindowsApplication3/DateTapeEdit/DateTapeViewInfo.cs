using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Repository;

namespace WindowsApplication3
{
    public class DateTapeViewInfo: BaseEditViewInfo
    {
        public DateTapeViewInfo(RepositoryItem item): base(item) {
            _HorIndent = 2;
            _VertIndent = 2;
        }

        // Fields...
        private Rectangle _SelectionBounds;
        private int _VertIndent;
        private int _HorIndent;
        private Rectangle _MinuteBounds;
        private Rectangle _HourBounds;
        private Rectangle _DayBounds;

        public Rectangle DayBounds
        {
            get { return _DayBounds; }
            set
            {
                _DayBounds = value;
            }
        }

        public Rectangle HourBounds
        {
            get { return _HourBounds; }
            set
            {
                _HourBounds = value;
            }
        }

        public Rectangle SelectionBounds
        {
            get { return _SelectionBounds; }
            set
            {
                _SelectionBounds = value;
            }
        }
        
     
        public Rectangle MinuteBounds
        {
            get { return _MinuteBounds; }
            set
            {
                _MinuteBounds = value;
            }
        }

        protected virtual int HorIndent
        {
            get { return _HorIndent; }
        }


        protected virtual int VertIndent
        {
            get { return _VertIndent; }
        }

        protected virtual void CalcDayBounds()
        {
            DayBounds = new Rectangle(Bounds.X + HorIndent, Bounds.Y + VertIndent, Bounds.Width / 2 - HorIndent, Bounds.Height - VertIndent - 1);
        }

        protected virtual void CalcHourBounds()
        {
            HourBounds = new Rectangle(DayBounds.Right + HorIndent, Bounds.Y + VertIndent, Bounds.Width / 4 - HorIndent, Bounds.Height - VertIndent - 1);
        }

        protected virtual void CalcMinuteBounds()
        {
            MinuteBounds = new Rectangle(HourBounds.Right + HorIndent, Bounds.Y + VertIndent, Bounds.Width / 4 - HorIndent - 1, Bounds.Height - VertIndent - 1);
        }

        protected virtual void CalcSelectionBounds()
        {
            SelectionBounds = new Rectangle(DayBounds.X + 1, DayBounds.Y + DayBounds.Height / 3, Bounds.Width - HorIndent - 4, Bounds.Height / 3);
        }

        public Rectangle GetRect(Rectangle rect, PositionType positionType)
        {
            if (positionType == PositionType.Top)
                return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height / 3);
            if(positionType == PositionType.Middle)
                return new Rectangle(rect.X, rect.Y + rect.Height / 3, rect.Width, rect.Height / 3);
            return new Rectangle(rect.X, rect.Y + rect.Height * 2 / 3, rect.Width, rect.Height / 3);
        }

        public new DateHitInfo CalcHitInfo(Point point)
        {
            if (DayBounds.Contains(point))
                return new DateHitInfo() { Point = point, HitInfoType = DateInfoType.Day};
            if (HourBounds.Contains(point))
                return new DateHitInfo() { Point = point, HitInfoType = DateInfoType.Hour };
            if (MinuteBounds.Contains(point))
                return new DateHitInfo() { Point = point, HitInfoType = DateInfoType.Minute };
            return new DateHitInfo() { Point = point, HitInfoType = DateInfoType.None };
        }

        protected override int CalcMinHeightCore(Graphics g)
        {
            return base.CalcMinHeightCore(g) * 3;
        }

        protected override void Assign(BaseControlViewInfo info)
        {
            base.Assign(info);
            DateTapeViewInfo viewInfo = info as DateTapeViewInfo;
            DayBounds = viewInfo.DayBounds;
            HourBounds = viewInfo.HourBounds;
            MinuteBounds = viewInfo.MinuteBounds;
            SelectionBounds = viewInfo.SelectionBounds;
        }

        protected override void CalcContentRect(Rectangle bounds)
        {
            base.CalcContentRect(bounds);
            CalcDayBounds();
            CalcHourBounds();
            CalcMinuteBounds();
            CalcSelectionBounds();
        }

        public override void Offset(int x, int y)
        {
            base.Offset(x, y);
            if (!DayBounds.IsEmpty) _DayBounds.Offset(x, y);
            if (!HourBounds.IsEmpty) _HourBounds.Offset(x, y);
            if (!MinuteBounds.IsEmpty) _MinuteBounds.Offset(x, y);
            if (!SelectionBounds.IsEmpty) _SelectionBounds.Offset(x, y);
        }
    }
}
