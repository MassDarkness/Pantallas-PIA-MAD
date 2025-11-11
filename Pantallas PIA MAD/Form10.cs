using iTextSharp.text;
using iTextSharp.text.pdf;
using Pantallas_PIA_MAD.DAO;
using Pantallas_PIA_MAD.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_PIA_MAD
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        //Metodo para cerrar completamente el programa
        private void Form11_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //Boton para enviarte al apartado de la gestion de empresas
        private void Empresa_MEAD_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de la gestion de usuarios
        private void DepaPues__MEAD_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de la gestion de departamentos y puestos
        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de la gestion de nomina 
        private void Nomina_MEAD_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }
        //Cargar todo el contenido dentro de los combobox
        private void Form11_Load(object sender, EventArgs e)
        {
            this.FormClosed += Form11_FormClosed;

            CB_TipoReporte.DisplayMember = "Nombre";
            CB_TipoReporte.ValueMember = "Valor";
            CB_TipoReporte.DataSource = new[] {
                new { Nombre = "Reporte General de Nómina", Valor = 1 },
                new { Nombre = "Reporte Headcounter", Valor = 2 },
                new { Nombre = "Reporte Resumen de Nómina", Valor = 3 }
            };
            CB_TipoReporte.SelectedIndex = -1;

            int anioActual = DateTime.Now.Year;
            CB_AñoReportes.DisplayMember = "Nombre";
            CB_AñoReportes.ValueMember = "Valor";
            CB_AñoReportes.DataSource = new[] {
                new { Nombre = (anioActual - 2).ToString(), Valor = anioActual - 2 },
                new { Nombre = (anioActual - 1).ToString(), Valor = anioActual - 1 },
                new { Nombre = anioActual.ToString(), Valor = anioActual }
            };
            CB_AñoReportes.SelectedValue = anioActual;

            CB_MesReporte.DisplayMember = "Nombre";
            CB_MesReporte.ValueMember = "Valor";
            CB_MesReporte.DataSource = new[] {
                new { Nombre = "Enero", Valor = 1 }, new { Nombre = "Febrero", Valor = 2 },
                new { Nombre = "Marzo", Valor = 3 }, new { Nombre = "Abril", Valor = 4 },
                new { Nombre = "Mayo", Valor = 5 }, new { Nombre = "Junio", Valor = 6 },
                new { Nombre = "Julio", Valor = 7 }, new { Nombre = "Agosto", Valor = 8 },
                new { Nombre = "Septiembre", Valor = 9 }, new { Nombre = "Octubre", Valor = 10 },
                new { Nombre = "Noviembre", Valor = 11 }, new { Nombre = "Diciembre", Valor = 12 }
            };
            CB_MesReporte.SelectedValue = DateTime.Now.Month;

            try
            {
                var listaDeptos = DepartamentoDAO.ObtenerDepartamentos();
                listaDeptos.Insert(0, new Departamento { id_departamento = 0, nombre = "[TODOS]" });

                CB_DepartamentoReporte.DataSource = listaDeptos;
                CB_DepartamentoReporte.DisplayMember = "nombre";
                CB_DepartamentoReporte.ValueMember = "id_departamento";
                CB_DepartamentoReporte.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message);
            }
            ActualizarVisibilidadFiltros();
        }
        //Boton para enviarte a iniciar sesion si se desea
        private void Salir_MEAD_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de la gestion de empleados 
        private void Empleados_MEAD_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.Show();
            this.Hide();
        }
        //Combobox para sacar el tipo de reporte depende lo seleccionado pediran los demas datos
        private void CB_TipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadFiltros();
        }
        private void ActualizarVisibilidadFiltros()
        {

            if (CB_TipoReporte.SelectedValue == null)
            {
                CB_MesReporte.Visible = false;
                CB_AñoReportes.Visible = false;
                CB_DepartamentoReporte.Visible = false;
                return;
            }

            int tipoReporte = (int)CB_TipoReporte.SelectedValue;

            switch (tipoReporte)
            {
                case 1: // General de Nómina
                    CB_MesReporte.Visible = true;
                    CB_AñoReportes.Visible = true;
                    CB_DepartamentoReporte.Visible = false;
                    break;
                case 2: // Headcounter
                    CB_MesReporte.Visible = true;
                    CB_AñoReportes.Visible = true;
                    CB_DepartamentoReporte.Visible = true;
                    break;
                case 3: // Resumen de Nómina
                    CB_MesReporte.Visible = false;
                    CB_AñoReportes.Visible = true;
                    CB_DepartamentoReporte.Visible = false;
                    break;
            }
        }
        //Boton para calcular el reporte 
        private void BTN_CalcularReporteADMIN_Click(object sender, EventArgs e)
        {
            if (CB_TipoReporte.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un tipo de reporte.");
                return;
            }

            int tipoReporte = (int)CB_TipoReporte.SelectedValue;
            int anio = (int)CB_AñoReportes.SelectedValue;
            int mes = (int)CB_MesReporte.SelectedValue;
            int idDeptoSeleccionado = (int)CB_DepartamentoReporte.SelectedValue;

            int? idDepto = (idDeptoSeleccionado == 0) ? (int?)null : idDeptoSeleccionado;

            try
            {
                switch (tipoReporte)
                {
                    case 1: // General de Nómina
                        VistaReporteADMIN.DataSource = ReportesDAO.ObtenerReporteGeneral(anio, mes);
                        break;
                    case 2: // Headcounter
                        VistaReporteADMIN.DataSource = ReportesDAO.ObtenerReporteHeadcounter(idDepto, anio, mes);
                        break;
                    case 3: // Resumen de Nómina
                        var resumen = ReportesDAO.ObtenerReporteResumen(anio);
                        VistaReporteADMIN.DataSource = resumen;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message);
            }
            FormatearColumnasMoneda(); 
        }
        private void FormatearColumnasMoneda()
        {
            // Para Reporte General
            try
            {
                if (VistaReporteADMIN.Columns["SalarioDiario"] != null)
                {
                    VistaReporteADMIN.Columns["SalarioDiario"].DefaultCellStyle.Format = "C2";
                }
            }
            catch {}
            // Para Resumen de Nomina
            try
            {
                if (VistaReporteADMIN.Columns["TotalSueldoBruto"] != null)
                {
                    VistaReporteADMIN.Columns["TotalSueldoBruto"].DefaultCellStyle.Format = "C2";
                }
                if (VistaReporteADMIN.Columns["TotalSueldoNeto"] != null)
                {
                    VistaReporteADMIN.Columns["TotalSueldoNeto"].DefaultCellStyle.Format = "C2";
                }
            }
            catch {}
        }
        //Crear PDF dependiendo el tipo de reporte a sacar.
        private void BTN_ExportarPDF_Click(object sender, EventArgs e)
        {
            if (VistaReporteADMIN.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
            sfd.Title = "Guardar Reporte en PDF";
            sfd.FileName = $"Reporte_{CB_TipoReporte.Text.Replace(" ", "")}_{DateTime.Now.ToString("yyyyMMdd")}.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document doc = new Document(PageSize.LETTER.Rotate());
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    iTextSharp.text.Font tituloFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
                    Paragraph titulo = new Paragraph(CB_TipoReporte.Text, tituloFont);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);
                    doc.Add(new Paragraph(" "));

                    int numColumnas = VistaReporteADMIN.Columns.GetColumnCount(DataGridViewElementStates.Visible);
                    PdfPTable tablaPdf = new PdfPTable(numColumnas);
                    tablaPdf.WidthPercentage = 100;

                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                    foreach (DataGridViewColumn column in VistaReporteADMIN.Columns)
                    {
                        if (column.Visible)
                        {
                            PdfPCell celda = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                            celda.BackgroundColor = new BaseColor(79, 129, 189);
                            celda.HorizontalAlignment = Element.ALIGN_CENTER;
                            tablaPdf.AddCell(celda);
                        }
                    }
                    tablaPdf.HeaderRows = 1;
                    iTextSharp.text.Font celdaFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL);
                    foreach (DataGridViewRow row in VistaReporteADMIN.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Visible)
                                {
                                    string valor = cell.FormattedValue.ToString();
                                    PdfPCell celdaPdf = new PdfPCell(new Phrase(valor, celdaFont));
                                    tablaPdf.AddCell(celdaPdf);
                                }
                            }
                        }
                    }
                    if ((int)CB_TipoReporte.SelectedValue == 3 && VistaReporteADMIN.DataSource is List<ReporteResumenNominaDTO>)
                    {
                        var lista = (List<ReporteResumenNominaDTO>)VistaReporteADMIN.DataSource;
                        decimal totalBruto = lista.Sum(r => r.TotalSueldoBruto);
                        decimal totalNeto = lista.Sum(r => r.TotalSueldoNeto);

                        iTextSharp.text.Font totalFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);

                        PdfPCell celdaTotalTitulo = new PdfPCell(new Phrase("--- TOTAL ---", totalFont));
                        celdaTotalTitulo.Colspan = 3;
                        celdaTotalTitulo.HorizontalAlignment = Element.ALIGN_RIGHT;
                        tablaPdf.AddCell(celdaTotalTitulo);

                        PdfPCell celdaTotalBruto = new PdfPCell(new Phrase(totalBruto.ToString("C2"), totalFont));
                        tablaPdf.AddCell(celdaTotalBruto);

                        PdfPCell celdaTotalNeto = new PdfPCell(new Phrase(totalNeto.ToString("C2"), totalFont));
                        tablaPdf.AddCell(celdaTotalNeto);
                    }
                    doc.Add(tablaPdf);
                    doc.Close();

                    MessageBox.Show("Reporte PDF exportado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el PDF: " + ex.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
