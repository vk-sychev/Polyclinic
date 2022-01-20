using System;
using System.Collections.Generic;
using System.Text;

namespace Polyclinic.Infrastructure.Constants
{
    public class Constants
    {
        public static readonly TimeSpan StartWorkTime = new TimeSpan(08, 00, 00);

        public static readonly TimeSpan EndWorkTime = new TimeSpan(17, 00, 00);

        public const int VisitDurationInMinutes = 15;
    }
}
