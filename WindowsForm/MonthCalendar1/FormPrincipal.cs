using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonthCalendar1
{
    public partial class FormPrincipal : Form
    {

        Recurso recurso = new Recurso();

        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime inicio = monthCalendar2.SelectionStart;
            DateTime fin = monthCalendar2.SelectionEnd;

            int dias= (fin - inicio).Days+1;
            try
            {
                recurso.AgregarOcupacion(inicio, dias);

                listBox1.Items.Clear();
                listBox1.Items.AddRange(recurso.ListarReservas().ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("noo! busque otro día");
            }

            monthCalendar2.BoldedDates = recurso.GetFechasOcupadas().ToArray();

        }

        
    }
}
