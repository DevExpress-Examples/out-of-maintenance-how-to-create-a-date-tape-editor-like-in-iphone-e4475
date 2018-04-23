using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using DevExpress.XtraEditors.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Drawing;

namespace WindowsApplication3
{
    public class DateTapePainter : BaseEditPainter
    {
        public DateTapePainter() { }

        // Fields...
        private SkinElementInfo _HighlightedItemInfo;

        SkinElementInfo HighlightedItemInfo
        {
            get {
                if (_HighlightedItemInfo == null)
                {
                    Skin skin = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
                    SkinElement elem = skin[CommonSkins.SkinHighlightedItem];
                    _HighlightedItemInfo = new SkinElementInfo(elem);
                }
                return _HighlightedItemInfo; }
        }

        protected override void DrawContent(ControlGraphicsInfoArgs info)
        {
            base.DrawContent(info);
            FillRectangle(info);
            DrawSelection(info);
            DrawDay(info);
            DrawHour(info);
            DrawMinute(info);
        }

        protected virtual void FillRectangle(ControlGraphicsInfoArgs info)
        {
            using (Brush brush = GetBackBrush())
                info.Graphics.FillRectangle(brush, info.Bounds);
        }

        protected virtual void DrawDay(ControlGraphicsInfoArgs info)
        {
            DateTapeViewInfo dateViewInfo = info.ViewInfo as DateTapeViewInfo;
            DrawDigit(info.Graphics, dateViewInfo, dateViewInfo.DayBounds, DateInfoType.Day);
            info.Graphics.DrawRectangle(Pens.Black, dateViewInfo.DayBounds);
        }

        protected virtual void DrawDigit(System.Drawing.Graphics graphics, DateTapeViewInfo dateViewInfo, Rectangle rect, DateInfoType datePart)
        {
            Array positions = Enum.GetValues(typeof(PositionType));
            foreach (PositionType positionType in positions)
            {
                Rectangle dateRect = dateViewInfo.GetRect(rect, positionType);
                DateTapeEdit edit = dateViewInfo.OwnerEdit as DateTapeEdit;
                bool isSelectedPart = edit != null && edit.SelectedDatePart == datePart;
                if (isSelectedPart && positionType != PositionType.Middle)
                    using (Brush br = GetSelectedBackBrush())
                        graphics.FillRectangle(br, dateRect);

                RepositoryItemDateTapeEdit item = dateViewInfo.Item as RepositoryItemDateTapeEdit;
                DateTime dt = Convert.ToDateTime(dateViewInfo.EditValue);
                string dayValue = item.GetDayValueByPosition(datePart, positionType, dt).ToString();
                using (Brush br = GetForeBrush(positionType, isSelectedPart))
                    graphics.DrawString(dayValue, dateViewInfo.PaintAppearance.Font, br, dateRect);
            }
        }

        protected virtual void DrawHour(ControlGraphicsInfoArgs info)
        {
            DateTapeViewInfo dateViewInfo = info.ViewInfo as DateTapeViewInfo;
            DrawDigit(info.Graphics, dateViewInfo, dateViewInfo.HourBounds, DateInfoType.Hour);
            info.Graphics.DrawRectangle(Pens.Black, dateViewInfo.HourBounds);
        }

        protected virtual void DrawMinute(ControlGraphicsInfoArgs info)
        {
            DateTapeViewInfo dateViewInfo = info.ViewInfo as DateTapeViewInfo;
            DrawDigit(info.Graphics, dateViewInfo, dateViewInfo.MinuteBounds, DateInfoType.Minute);
            info.Graphics.DrawRectangle(Pens.Black, dateViewInfo.MinuteBounds);
        }

        protected virtual void DrawSelection(ControlGraphicsInfoArgs info)
        {
            DateTapeViewInfo dateViewInfo = info.ViewInfo as DateTapeViewInfo;
            HighlightedItemInfo.Bounds = dateViewInfo.SelectionBounds;
            HighlightedItemInfo.Graphics = info.Graphics;
            ObjectPainter.DrawObject(info.Cache, SkinElementPainter.Default, HighlightedItemInfo);
        }

        protected virtual Brush GetBackBrush()
        {
            return new SolidBrush(LookAndFeelHelper.GetSystemColor(UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.Control));
        }

        protected virtual Brush GetSelectedBackBrush()
        {
            return new SolidBrush(LookAndFeelHelper.GetSystemColor(UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.Highlight));
        }

        protected virtual Brush GetForeBrush(PositionType positionType, bool isSelectedPart)
        {
            if (isSelectedPart && positionType != PositionType.Middle)
                return new SolidBrush(LookAndFeelHelper.GetSystemColor(UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.HighlightText));
            if (positionType == PositionType.Middle)
                return new SolidBrush(LookAndFeelHelper.GetSystemColor(UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.ControlText));
            return new SolidBrush(LookAndFeelHelper.GetSystemColor(UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.GrayText));
        }
    }
}
