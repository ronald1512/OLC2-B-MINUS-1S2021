using Proyecto1.Administracion;
using Proyecto1.Analisis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //limpiamos el contenido de la singleton
            MasterClass.Instance.clear();
            Evaluator evaluator = new Evaluator();
            evaluator.analizar(this.txtEntrada.Text);
            MasterClass.Instance.ejecutar();
            this.txtSalida.Text = MasterClass.Instance.getOutput();


        }
    }
}
