using Pantallas_PIA_MAD.DAO;
using Pantallas_PIA_MAD.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pantallas_PIA_MAD
{
    public partial class Form12 : Form
    {
        private CalculoNomina nominaService = new CalculoNomina();
        public Form12()
        {
            InitializeComponent();
        }
        //Metodo para cerrar completamente el programa
        private void Form12_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Form12_Load(object sender, EventArgs e)
        {
            this.FormClosed += Form12_FormClosed;
            ComboBoxEmpresaPuestoAUX.DataSource = EmpresaDAP.ObtenerEmpresas();
            ComboBoxEmpresaPuestoAUX.DisplayMember = "nombre";
            ComboBoxEmpresaPuestoAUX.ValueMember = "id_empresa";
            ComboBoxDepartamentoPuestoAUX.SelectedIndex = -1;
        }
        //Boton para enviarte al apartado de la gestion de empresas
        private void Empresa_MEAU_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de los reportes
        private void Reportes__MEAU_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
        //Boton para enviarte a iniciar sesion si se desea
        private void Salir__MEAU_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void BTN_CalcularNominaAUX_Click(object sender, EventArgs e)
        {
            {
                // --- 1. VALIDAR INPUTS ---
                if (comboBox2AUX.SelectedValue == null) // ¡Tu ComboBox de empleado es comboBox2!
                {
                    MessageBox.Show("Por favor, seleccione un empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(TB_DiasTrabajadosAUX.Text, out int diasTrabajados))
                {
                    MessageBox.Show("Días trabajados debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- 2. OBTENER DATOS DE LA UI ---
                try
                {
                    // ¡¡CORRECCIÓN 3a: Arreglado el 'InvalidCastException'!!
                    // NO podemos usar (int)comboBox2.SelectedValue
                    var empleadoSel = (Empleado)comboBox2AUX.SelectedItem;
                    int idEmpleado = empleadoSel.id_empleado;

                    Empleado empleado = EmpleadoDAO.ObtenerEmpleadoPorId(idEmpleado);
                    if (empleado == null)
                    {
                        MessageBox.Show("No se pudo encontrar al empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Leemos los TextBoxes
                    decimal.TryParse(TB_AguinaldoAUX.Text, out decimal aguinaldo);
                    decimal.TryParse(TB_BNPuntualidadAUX.Text, out decimal bonoPuntualidad);
                    decimal.TryParse(TB_BNAsistenciaAUX.Text, out decimal bonoAsistencia);
                    decimal.TryParse(TB_CuotaIMSSAUX.Text, out decimal cuotaImss);
                    decimal.TryParse(TB_CuotaSindicalAUX.Text, out decimal cuotaSindical);

                    // --- 3. LLAMAR AL CEREBRO (CALCULAR) ---
                    Recibo_Nomina reciboCalculado = nominaService.CalcularNomina(
                        empleado, diasTrabajados, aguinaldo, bonoPuntualidad,
                        bonoAsistencia, cuotaImss, cuotaSindical
                    );

                    // --- 4. GUARDAR EN LA BASE DE DATOS ---

                    // a. Crear la nómina (objeto)
                    DateTime fechaSeleccionada = FechaAUXNomina.Value;
                    DateTime fechaDeNomina = new DateTime(fechaSeleccionada.Year, fechaSeleccionada.Month, 1);
                    Nomina nomina = new Nomina
                    {
                        fecha = fechaDeNomina,
                        estatus = "Calculada",
                        id_empleado = idEmpleado
                    };

                    // ¡¡CORRECCIÓN 3b: Usando el 'out'!!
                    int idNominaNueva; // Variable para recibir el ID
                    int resultadoNomina = NominaDAO.InsertarNomina(nomina, out idNominaNueva);

                    if (resultadoNomina <= 0 || idNominaNueva <= 0)
                    {
                        MessageBox.Show("Error: No se pudo registrar la nómina principal.");
                        return;
                    }

                    // c. Asignar ese ID al recibo
                    reciboCalculado.id_nomina = idNominaNueva;
                    reciboCalculado.fecha = fechaDeNomina; // Súper importante que el recibo tenga la misma fecha

                    // d. Guardar el Recibo (¡Paso 2!)
                    int resultadoRecibo = ReciboNominaDAO.InsertarReciboNomina(reciboCalculado);
                    if (resultadoRecibo <= 0)
                    {
                        MessageBox.Show("Error: Se guardó la nómina, pero no el recibo detallado.");
                        return;
                    }

                    List<Recibo_Nomina> listaParaMostrar = new List<Recibo_Nomina>();
                    listaParaMostrar.Add(reciboCalculado);
                    Vista_Nomina.DataSource = listaParaMostrar;

                    try
                    {
                        Vista_Nomina.Columns["sueldo_bruto"].HeaderText = "Sueldo Bruto";
                        Vista_Nomina.Columns["sueldo_neto"].HeaderText = "Sueldo Neto";
                        Vista_Nomina.Columns["percepciones"].HeaderText = "Total Percepciones";
                        Vista_Nomina.Columns["deducciones"].HeaderText = "Total Deducciones";
                        Vista_Nomina.Columns["id_nomina"].HeaderText = "ID Nómina";

                        if (Vista_Nomina.Columns.Contains("id_recibo"))
                        {
                            Vista_Nomina.Columns["id_recibo"].Visible = false;
                        }

                        if (Vista_Nomina.Columns.Contains("Nomina"))
                        {
                            Vista_Nomina.Columns["Nomina"].Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error al renombrar columnas: " + ex.Message);
                    }

                    MessageBox.Show("Nómina calculada y guardada en la Base de Datos con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error crítico al calcular: " + ex.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void comboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxEmpresaPuestoAUX.SelectedValue is int idEmpresa)
            {
                ComboBoxDepartamentoPuestoAUX.DataSource = DepartamentoDAO.ObtenerDepartamentosPorEmpresa(idEmpresa);
                ComboBoxDepartamentoPuestoAUX.DisplayMember = "nombre";
                ComboBoxDepartamentoPuestoAUX.ValueMember = "id_departamento";
                comboBox1AUX.SelectedIndex = -1;
            }
        }
        private void comboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxDepartamentoPuestoAUX.SelectedValue is int idDepartamento)
            {
                comboBox1AUX.DataSource = PuestoDAO.ObtenerPuestosPorDepartamento(idDepartamento);
                comboBox1AUX.DisplayMember = "nombre";
                comboBox1AUX.ValueMember = "id_puesto";
                comboBox1AUX.SelectedIndex = -1;
            }
        }
        private void comboPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1AUX.SelectedValue is int idPuesto)
            {
                comboBox2AUX.DataSource = EmpleadoDAO.ObtenerEmpleadosPorPuesto(idPuesto);
                comboBox2AUX.DisplayMember = "nombres";
                comboBox2AUX.ValueMember = "id_empleado";
                comboBox2AUX.SelectedIndex = -1;
            }
        }

    }
}
