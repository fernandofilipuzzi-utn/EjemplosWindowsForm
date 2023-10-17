using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthCalendar1
{
    class Reserva : IComparable
    {
        public DateTime Desde { set; get; }
        public DateTime Hasta { get { return Desde.AddDays(Dias - 1); } }
        public int Dias { get; set; }

        public int CompareTo(object obj)
        {
            Reserva reserva = obj as Reserva;
            if (reserva != null)
                return Desde.CompareTo(reserva.Desde);
            return -1;
        }

        public override string ToString()
        {
            return $"{Desde:dd/MM/yyyy} a {Hasta:dd/MM/yyyy}";
        }
    }
}
