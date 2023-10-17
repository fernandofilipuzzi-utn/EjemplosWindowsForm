using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthCalendar1
{
    class Recurso
    {
        List<Reserva> ocupaciones = new List<Reserva>();

        public List<DateTime> GetFechasOcupadas()
        {
            List<DateTime> fechas = new List<DateTime>();
            foreach (Reserva o in ocupaciones)
            {
                for (int n = 0; n < o.Dias; n++)
                    fechas.Add(o.Desde.AddDays(n));
            }
            return fechas;
        }

        public List<Reserva> ListarReservas() 
        {
            return ocupaciones;
        }

        public void AgregarOcupacion(DateTime desde, int dias)
        {
            DateTime hasta = desde.AddDays(dias - 1);

            //      f1i-f1f      f2i-f2f  f3i-f3f f4i-f4f
            //              ^  v

            //verifica?
            bool verifica = true; 
            int n = 0;
            while (n<ocupaciones.Count && verifica == true)
            {
                verifica = desde > ocupaciones[n].Hasta;  //pruebo si!
                verifica |= hasta < ocupaciones[n].Desde;
                n++;
            }

            if (verifica == true)
            {
                Reserva nuevo = new Reserva { Desde = desde, Dias = dias };
                ocupaciones.Add(nuevo);
                ocupaciones.Sort();
            }
            else
                throw new Exception("fecha ocupada");
        }
    }
}
