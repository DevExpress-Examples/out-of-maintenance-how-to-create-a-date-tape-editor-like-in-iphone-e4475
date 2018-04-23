using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace WindowsApplication3
{
    public class DateHitInfo
    {
        public DateHitInfo() : base() { }

        // Fields...
        private Point _Point;
        private DateInfoType _HitInfoType;

        public DateInfoType HitInfoType
        {
            get { return _HitInfoType; }
            set { _HitInfoType = value; }
        }


        public Point Point
        {
            get { return _Point; }
            set
            {
                _Point = value;
            }
        }
        
    }
}
