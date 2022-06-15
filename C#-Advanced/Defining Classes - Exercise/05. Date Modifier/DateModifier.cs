using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class DateModifier
    {
        public DateModifier(string firstData, string lastData)
        {
            FirstData = DateTime.Parse( firstData);
            LastData = DateTime.Parse( lastData);
        }

        public DateTime FirstData { get; set; }

        public DateTime LastData { get; set; }

        public int GetDiff()
        {
            return Math.Abs((int)(FirstData - LastData).TotalDays);
        }

    }
}
