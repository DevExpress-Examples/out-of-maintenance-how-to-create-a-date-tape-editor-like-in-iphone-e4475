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

namespace WindowsApplication3
{
    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemDateTapeEdit : RepositoryItem
    {
        static RepositoryItemDateTapeEdit() { RegisterCustomEdit(); }

        public RepositoryItemDateTapeEdit() { }

        public const string CustomEditName = "DateTapeEdit";

        public override string EditorTypeName { get { return CustomEditName; } }

        public static void RegisterCustomEdit()
        {

            Image img = null;
            try
            {
                img = (Bitmap)Bitmap.FromStream(Assembly.GetExecutingAssembly().
                  GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp"));
            }
            catch
            {
            }
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
              typeof(DateTapeEdit), typeof(RepositoryItemDateTapeEdit),
              typeof(DateTapeViewInfo), new DateTapePainter(), true, img));
            
        }

        public string GetCurrentDayValue(DateInfoType datePart, DateTime dt)
        {
            if (datePart == DateInfoType.Day)
                return dt.ToString("M");
            if (datePart == DateInfoType.Hour)
                return dt.Hour.ToString();
            return dt.Minute.ToString();
        }

        public string GetPreviousDayValue(DateInfoType datePart, DateTime dt)
        {
            dt = GetPreviousDate(datePart, dt);
            if (datePart == DateInfoType.Day)
                return dt.ToString("M");
            if (datePart == DateInfoType.Hour)
                return dt.Hour.ToString();
            return dt.Minute.ToString();
        }

        public string GetNextDayValue(DateInfoType datePart, DateTime dt)
        {
            dt = GetNextDate(datePart, dt);
            if (datePart == DateInfoType.Day)
                return dt.ToString("M");
            if (datePart == DateInfoType.Hour)
                return dt.Hour.ToString();
            return dt.Minute.ToString();
        }

        public DateTime GetPreviousDate(DateInfoType datePart, DateTime dt)
        {
            return GetDate(datePart, dt, -1);
        }

        public DateTime GetNextDate(DateInfoType datePart, DateTime dt)
        {
           return GetDate(datePart, dt, 1);
        }

        public DateTime GetDate(DateInfoType datePart, DateTime dt, int val)
        {
            try
            {
                if (datePart == DateInfoType.Day)
                    return dt.AddDays(val);
                if (datePart == DateInfoType.Hour)
                    return dt.AddHours(val);
                return dt.AddMinutes(val);
            }
            catch { }    
            return dt;
        }

        public string GetDayValueByPosition(DateInfoType datePart, PositionType positionType, DateTime dt)
        {
            if (positionType == PositionType.Top)
                return GetPreviousDayValue(datePart, dt);                       
            if (positionType == PositionType.Middle)
                return GetCurrentDayValue(datePart, dt);
            return GetNextDayValue(datePart, dt);
        }

    }
}
