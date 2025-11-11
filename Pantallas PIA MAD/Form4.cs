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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        //Metodo para cerrar completamente el programa
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //Carga la pantalla y todos los datos en el combobox
        private void Form4_Load(object sender, EventArgs e)
        {
            this.FormClosed += Form4_FormClosed;

            CB_TipoReporteAUX.DisplayMember = "Nombre";
            CB_TipoReporteAUX.ValueMember = "Valor";
            CB_TipoReporteAUX.DataSource = new[] {
                new { Nombre = "Reporte General de Nómina", Valor = 1 },
                new { Nombre = "Reporte Headcounter", Valor = 2 },
                new { Nombre = "Reporte Resumen de Nómina", Valor = 3 }
            };
            CB_TipoReporteAUX.SelectedIndex = -1;

            int anioActual = DateTime.Now.Year;
            CB_AñoReportesAUX.DisplayMember = "Nombre";
            CB_AñoReportesAUX.ValueMember = "Valor";
            CB_AñoReportesAUX.DataSource = new[] {
                new { Nombre = (anioActual - 2).ToString(), Valor = anioActual - 2 },
                new { Nombre = (anioActual - 1).ToString(), Valor = anioActual - 1 },
                new { Nombre = anioActual.ToString(), Valor = anioActual }
            };
            CB_AñoReportesAUX.SelectedValue = anioActual;

            CB_MesReportesAUX.DisplayMember = "Nombre";
            CB_MesReportesAUX.ValueMember = "Valor";
            CB_MesReportesAUX.DataSource = new[] {
                new { Nombre = "Enero", Valor = 1 }, new { Nombre = "Febrero", Valor = 2 },
                new { Nombre = "Marzo", Valor = 3 }, new { Nombre = "Abril", Valor = 4 },
                new { Nombre = "Mayo", Valor = 5 }, new { Nombre = "Junio", Valor = 6 },
                new { Nombre = "Julio", Valor = 7 }, new { Nombre = "Agosto", Valor = 8 },
                new { Nombre = "Septiembre", Valor = 9 }, new { Nombre = "Octubre", Valor = 10 },
                new { Nombre = "Noviembre", Valor = 11 }, new { Nombre = "Diciembre", Valor = 12 }
            };
            CB_MesReportesAUX.SelectedValue = DateTime.Now.Month;

            try
            {
                var listaDeptos = DepartamentoDAO.ObtenerDepartamentos();
                listaDeptos.Insert(0, new Departamento { id_departamento = 0, nombre = "[TODOS]" });

                CB_DepartamentoReporteAUX.DataSource = listaDeptos;
                CB_DepartamentoReporteAUX.DisplayMember = "nombre";
                CB_DepartamentoReporteAUX.ValueMember = "id_departamento";
                CB_DepartamentoReporteAUX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message);
            }
            ActualizarVisibilidadFiltros();
        }
        //Boton para enviarte al apartado de la gestion de empresas
        private void Empresa_MEAU_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
        //Boton para enviarte al apartado de la gestion de nomina 
        private void Nomina__MEAU_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.Show();
            this.Hide();
        }
        //Boton para enviarte a iniciar sesion si se desea
        private void Salir_MEAU_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        private void CB_TipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadFiltros();
        }
        private void ActualizarVisibilidadFiltros()
        {

            if (CB_TipoReporteAUX.SelectedValue == null)
            {
                CB_MesReportesAUX.Visible = false;
                CB_AñoReportesAUX.Visible = false;
                CB_DepartamentoReporteAUX.Visible = false;
                return;
            }

            int tipoReporte = (int)CB_TipoReporteAUX.SelectedValue;

            switch (tipoReporte)
            {
                case 1: // General de Nómina
                    CB_MesReportesAUX.Visible = true;
                    CB_AñoReportesAUX.Visible = true;
                    CB_DepartamentoReporteAUX.Visible = false;
                    break;
                case 2: // Headcounter
                    CB_MesReportesAUX.Visible = true;
                    CB_AñoReportesAUX.Visible = true;
                    CB_DepartamentoReporteAUX.Visible = true;
                    break;
                case 3: // Resumen de Nómina
                    CB_MesReportesAUX.Visible = false;
                    CB_AñoReportesAUX.Visible = true;
                    CB_DepartamentoReporteAUX.Visible = false;
                    break;
            }
        }
        //Boton para calcular el reporte segun el seleccionado
        private void BTN_CalcularReporteAUX_Click(object sender, EventArgs e)
        {
            if (CB_TipoReporteAUX.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un tipo de reporte.");
                return;
            }

            int tipoReporte = (int)CB_TipoReporteAUX.SelectedValue;
            int anio = (int)CB_AñoReportesAUX.SelectedValue;
            int mes = (int)CB_MesReportesAUX.SelectedValue;
            int idDeptoSeleccionado = (int)CB_DepartamentoReporteAUX.SelectedValue;

            int? idDepto = (idDeptoSeleccionado == 0) ? (int?)null : idDeptoSeleccionado;

            try
            {
                switch (tipoReporte)
                {
                    case 1: // General de Nómina
                        Vista_ReporteAUX.DataSource = ReportesDAO.ObtenerReporteGeneral(anio, mes);
                        break;
                    case 2: // Headcounter
                        Vista_ReporteAUX.DataSource = ReportesDAO.ObtenerReporteHeadcounter(idDepto, anio, mes);
                        break;
                    case 3: // Resumen de Nómina
                        var resumen = ReportesDAO.ObtenerReporteResumen(anio);
                        Vista_ReporteAUX.DataSource = resumen;
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
                if (Vista_ReporteAUX.Columns["SalarioDiario"] != null)
                {
                    Vista_ReporteAUX.Columns["SalarioDiario"].DefaultCellStyle.Format = "C2";
                }
            }
            catch {}
            // Para Resumen de Nomina
            try
            {
                if (Vista_ReporteAUX.Columns["TotalSueldoBruto"] != null)
                {
                    Vista_ReporteAUX.Columns["TotalSueldoBruto"].DefaultCellStyle.Format = "C2";
                }
                if (Vista_ReporteAUX.Columns["TotalSueldoNeto"] != null)
                {
                    Vista_ReporteAUX.Columns["TotalSueldoNeto"].DefaultCellStyle.Format = "C2";
                }
            }
            catch { }
        }
        //Boton exportar en PDF segun el reporte seleccionado
        private void BTN_ExportarPDFAUX_Click(object sender, EventArgs e)
        {
            if (Vista_ReporteAUX.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
            sfd.Title = "Guardar Reporte en PDF";
            sfd.FileName = $"Reporte_{CB_TipoReporteAUX.Text.Replace(" ", "")}_{DateTime.Now.ToString("yyyyMMdd")}.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document doc = new Document(PageSize.LETTER.Rotate());
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    iTextSharp.text.Font tituloFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
                    Paragraph titulo = new Paragraph(CB_TipoReporteAUX.Text, tituloFont);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);
                    doc.Add(new Paragraph(" "));

                    int numColumnas = Vista_ReporteAUX.Columns.GetColumnCount(DataGridViewElementStates.Visible);
                    PdfPTable tablaPdf = new PdfPTable(numColumnas);
                    tablaPdf.WidthPercentage = 100;

                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                    foreach (DataGridViewColumn column in Vista_ReporteAUX.Columns)
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
                    foreach (DataGridViewRow row in Vista_ReporteAUX.Rows)
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
                    if ((int)CB_TipoReporteAUX.SelectedValue == 3 && Vista_ReporteAUX.DataSource is List<ReporteResumenNominaDTO>)
                    {
                        var lista = (List<ReporteResumenNominaDTO>)Vista_ReporteAUX.DataSource;
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
