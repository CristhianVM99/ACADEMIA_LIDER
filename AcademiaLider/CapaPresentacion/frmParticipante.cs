using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AcademiaLider.CapaLogicaNegocio;
using AcademiaLider.Entidades;

namespace AcademiaLider.CapaPresentacion
{
    public partial class frmParticipante : Form
    {
        private ClnParticipante objLogicaNegocio = new ClnParticipante();
        private Participante objParticipante = new Participante();

        public frmParticipante()
        {
            InitializeComponent();
        }

        private void frmParticipante_Load(object sender, EventArgs e)
        {
            Limpiar();
            DeshabilitarBtnModificar();
            DeshabilitarBtnEliminar();
            CargarGradosAcademicos();
            CargarProfesioness();
            CargarCiudades();
            Listar();
        }

        private void Limpiar()
        {
            txtNombres.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtCi.Text = "";
            dtpFechaNac.Text = "";
            cboCiudad.Text = "";
            cboProfesion.Text = "";
            cboGradoAcademico.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }

        private void Inicializar()
        {
            objParticipante = new Participante();
        }

        private void HabilitarBtnNuevo()
        {
            btnNuevo.Enabled = true;
        }

        private void DeshabilitarBtnNuevo()
        {
            btnNuevo.Enabled = false;
        }

        private void HabilitarBtnModificar()
        {
            btnModificar.Enabled = true;
        }

        private void DeshabilitarBtnModificar()
        {
            btnModificar.Enabled = false;
        }

        private void HabilitarBtnEliminar()
        {
            btnEliminar.Enabled = true;
        }

        private void DeshabilitarBtnEliminar()
        {
            btnEliminar.Enabled = false;
        }

        private void CargarGradosAcademicos()
        {
            cboGradoAcademico.ValueMember = "codigo";
            cboGradoAcademico.DisplayMember = "nombre";
            cboGradoAcademico.DataSource = objLogicaNegocio.ListarGradosAcademicos();
        }

        private void CargarProfesioness()
        {
            cboProfesion.ValueMember = "codigo";
            cboProfesion.DisplayMember = "nombre";
            cboProfesion.DataSource = objLogicaNegocio.ListarProfesiones();
        }

        private void CargarCiudades()
        {
            cboCiudad.ValueMember = "codigo";
            cboCiudad.DisplayMember = "nombre";
            cboCiudad.DataSource = objLogicaNegocio.ListarCiudades();
        }

        private void Listar()
        {
            dgvListado.DataSource = objLogicaNegocio.ListarRegistros();
        }

        private void CargarDatos()
        {
            objParticipante.Nombres = txtNombres.Text;
            objParticipante.ApPaterno = txtApPaterno.Text;
            objParticipante.ApMaterno = txtApMaterno.Text;
            objParticipante.Ci = txtCi.Text;
            objParticipante.FechaNac = dtpFechaNac.Value.Year + "-" + dtpFechaNac.Value.Month + "-" + dtpFechaNac.Value.Day;
            objParticipante.CodProfesion = Convert.ToInt32(cboProfesion.SelectedValue);
            objParticipante.CodGrado = Convert.ToInt32(cboGradoAcademico.SelectedValue);
            objParticipante.CodCiudad = Convert.ToInt32(cboCiudad.SelectedValue);
            objParticipante.Correo = txtCorreo.Text;
            objParticipante.Telefono = txtTelefono.Text.Equals("") ? 0 : Convert.ToInt32(txtTelefono.Text);
        }

        private void MostrarDatos()
        {
            txtNombres.Text = objParticipante.Nombres;
            txtApPaterno.Text = objParticipante.ApPaterno;
            txtApMaterno.Text = objParticipante.ApMaterno;
            txtCi.Text = objParticipante.Ci;
            dtpFechaNac.Text = objParticipante.FechaNac;
            cboCiudad.SelectedValue = objParticipante.CodCiudad;
            cboProfesion.SelectedValue = objParticipante.CodProfesion;
            cboGradoAcademico.SelectedValue = objParticipante.CodGrado;
            txtCorreo.Text = objParticipante.Correo;
            txtTelefono.Text = objParticipante.Telefono.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DeshabilitarBtnNuevo();
            Inicializar();
            CargarDatos();
            objLogicaNegocio.CrearRegistro(objParticipante);
            if (objLogicaNegocio.Estado)
            {
                Limpiar();
                Listar();
                MessageBox.Show(objLogicaNegocio.Mensaje);
            }
            else
            {
                MessageBox.Show(objLogicaNegocio.Mensaje);
            }
            HabilitarBtnNuevo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DeshabilitarBtnModificar();
            DeshabilitarBtnEliminar();
            CargarDatos();
            objLogicaNegocio.ModificarRegistro(objParticipante);
            if (objLogicaNegocio.Estado)
            {
                Limpiar();
                HabilitarBtnNuevo();
                Listar();
                MessageBox.Show(objLogicaNegocio.Mensaje);
            }
            else
            {
                HabilitarBtnModificar();
                HabilitarBtnEliminar();
                MessageBox.Show(objLogicaNegocio.Mensaje);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DeshabilitarBtnModificar();
            DeshabilitarBtnEliminar();
            objLogicaNegocio.EliminarRegistro(objParticipante.Codigo);
            if (objLogicaNegocio.Estado)
            {
                Limpiar();
                HabilitarBtnNuevo();
                Listar();
                MessageBox.Show(objLogicaNegocio.Mensaje);
            }
            else
            {
                HabilitarBtnModificar();
                HabilitarBtnEliminar();
                MessageBox.Show(objLogicaNegocio.Mensaje);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Inicializar();
            HabilitarBtnNuevo();
            DeshabilitarBtnModificar();
            DeshabilitarBtnEliminar();
        }

        private void dgvListado_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvListado.Rows.Count - 1)
            {
                String codigo = dgvListado.Rows[e.RowIndex].Cells[0].Value.ToString();
                objParticipante = objLogicaNegocio.ObtenerRegistro(codigo);
                DeshabilitarBtnNuevo();
                HabilitarBtnModificar();
                HabilitarBtnEliminar();
                MostrarDatos();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String criterio = txtCriterioBusqueda.Text;
            dgvListado.DataSource = objLogicaNegocio.BuscarRegistros(criterio);
        }
    }
}
