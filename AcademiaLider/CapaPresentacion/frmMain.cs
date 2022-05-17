using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaLider.CapaPresentacion
{
    public partial class frmMain : Form
    {
        private Form viewParticipante = null;
        private Form viewDocente = null;
        private Form viewEvento  = null;
        private Form viewInscripcion = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(viewParticipante))
            {
                viewParticipante = new frmParticipante();
                viewParticipante.MdiParent = this;
            }
            viewParticipante.Show();
            viewParticipante.BringToFront();
        }

        private void registroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*if (!this.MdiChildren.Contains(formDocente))
            {
                formDocente = new frmDocente();
                formDocente.MdiParent = this;
            }
            formDocente.Show();
            formDocente.BringToFront();*/
        }

        private void registroToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(viewInscripcion))
            {
                viewInscripcion = new frmInscripcion();
                viewInscripcion.MdiParent = this;
            }
            viewInscripcion.Show();
            viewInscripcion.BringToFront();
        }
    }
}
