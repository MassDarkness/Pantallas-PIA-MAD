// --- REEMPLAZA TODO TU ARCHIVO DAO/GeneradorReciboPDF.cs ---

using iTextSharp.text;
using iTextSharp.text.pdf;
using Pantallas_PIA_MAD.entidades;
using System;
using System.IO;

namespace Pantallas_PIA_MAD.DAO
{
    public class GeneradorReciboPDF
    {
        private iTextSharp.text.Font fontTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD);
        private iTextSharp.text.Font fontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);
        private iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        private iTextSharp.text.Font fontPeque = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL);

        public void GenerarPDF(string rutaArchivo, Empleado empleado, Recibo_Nomina recibo, CalculoDesglose desglose, RegistroEmpresa empresa)
        {
            Document doc = new Document(PageSize.LETTER);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                Paragraph pEmpresa = new Paragraph(empresa.razon_social, fontTitulo);
                pEmpresa.Alignment = Element.ALIGN_CENTER;
                doc.Add(pEmpresa);

                Paragraph pRfc = new Paragraph($"RFC: {empresa.RFC} | Reg. Patronal: {empresa.registro_patronal}", fontPeque);
                pRfc.Alignment = Element.ALIGN_CENTER;
                doc.Add(pRfc);

                Paragraph pRecibo = new Paragraph("Recibo de Nómina", fontBold);
                pRecibo.Alignment = Element.ALIGN_CENTER;
                doc.Add(pRecibo);

                Paragraph pPeriodo = new Paragraph($"Periodo de Pago: {recibo.fecha.Value.ToString("MMMM 'de' yyyy")}", fontNormal); 
                pPeriodo.Alignment = Element.ALIGN_CENTER;
                doc.Add(pPeriodo);

                doc.Add(Chunk.NEWLINE);

                PdfPTable tblEmpleado = new PdfPTable(4);
                tblEmpleado.WidthPercentage = 100;

                tblEmpleado.AddCell(CrearCelda("Nombre del Empleado:", fontBold));
                tblEmpleado.AddCell(CrearCelda($"{empleado.nombres} {empleado.apellido_paterno} {empleado.apellido_materno}", fontNormal));
                tblEmpleado.AddCell(CrearCelda("IMSS:", fontBold));
                tblEmpleado.AddCell(CrearCelda(empleado.nss, fontNormal));
                tblEmpleado.AddCell(CrearCelda("Puesto:", fontBold));
                tblEmpleado.AddCell(CrearCelda(empleado.Puesto?.nombre ?? "N/A", fontNormal));
                tblEmpleado.AddCell(CrearCelda("CURP:", fontBold));
                tblEmpleado.AddCell(CrearCelda(empleado.curp, fontNormal));
                tblEmpleado.AddCell(CrearCelda("Departamento:", fontBold));
                tblEmpleado.AddCell(CrearCelda(empleado.Departamento?.nombre ?? "N/A", fontNormal));
                tblEmpleado.AddCell(CrearCelda("RFC:", fontBold));
                tblEmpleado.AddCell(CrearCelda(empleado.rfc, fontNormal));
                tblEmpleado.AddCell(CrearCelda("Banco:", fontBold));
                tblEmpleado.AddCell(CrearCelda(empleado.banco, fontNormal));
                tblEmpleado.AddCell(CrearCelda("Número de Cuenta:", fontBold));
                tblEmpleado.AddCell(CrearCelda(empleado.numero_cuenta, fontNormal));
                doc.Add(tblEmpleado);
                doc.Add(Chunk.NEWLINE);

                PdfPTable tblConceptos = new PdfPTable(4);
                tblConceptos.WidthPercentage = 100;

                tblConceptos.AddCell(CrearCeldaTitulo("PERCEPCIONES", fontBold, 2));
                tblConceptos.AddCell(CrearCeldaTitulo("DEDUCCIONES", fontBold, 2));

                tblConceptos.AddCell(CrearCelda("Sueldo Bruto:", fontNormal));
                tblConceptos.AddCell(CrearCelda(recibo.sueldo_bruto.ToString("C2"), fontNormal));
                tblConceptos.AddCell(CrearCelda("ISR:", fontNormal));
                tblConceptos.AddCell(CrearCelda(desglose.DeduccionISR.ToString("C2"), fontNormal));
                tblConceptos.AddCell(CrearCelda("Aguinaldo:", fontNormal));
                tblConceptos.AddCell(CrearCelda(desglose.Aguinaldo.ToString("C2"), fontNormal));
                tblConceptos.AddCell(CrearCelda("IMSS:", fontNormal));
                tblConceptos.AddCell(CrearCelda(desglose.DeduccionIMSS.ToString("C2"), fontNormal));
                tblConceptos.AddCell(CrearCelda("Bono Puntualidad:", fontNormal));
                tblConceptos.AddCell(CrearCelda(desglose.BonoPuntualidad.ToString("C2"), fontNormal));
                tblConceptos.AddCell(CrearCelda("Cuota Sindical:", fontNormal));
                tblConceptos.AddCell(CrearCelda(desglose.DeduccionSindical.ToString("C2"), fontNormal));
                tblConceptos.AddCell(CrearCelda("Bono Asistencia:", fontNormal));
                tblConceptos.AddCell(CrearCelda(desglose.BonoAsistencia.ToString("C2"), fontNormal));
                tblConceptos.AddCell(CrearCelda("", fontNormal));
                tblConceptos.AddCell(CrearCelda("", fontNormal));

                doc.Add(tblConceptos);
                doc.Add(Chunk.NEWLINE);

                PdfPTable tblTotal = new PdfPTable(2);
                tblTotal.WidthPercentage = 100;

                tblTotal.AddCell(CrearCelda("TOTAL PERCEPCIONES:", fontBold));
                tblTotal.AddCell(CrearCelda(recibo.percepciones.ToString("C2"), fontNormal));

                tblTotal.AddCell(CrearCelda("TOTAL DEDUCCIONES:", fontBold));
                tblTotal.AddCell(CrearCelda(recibo.deducciones.ToString("C2"), fontNormal));

                tblTotal.AddCell(CrearCelda("NETO A PAGAR:", fontBold));
                tblTotal.AddCell(CrearCelda(recibo.sueldo_neto.ToString("C2"), fontBold));

                doc.Add(tblTotal);
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error al crear el PDF: " + ex.Message);
            }
            finally
            {
                if (doc.IsOpen())
                {
                    doc.Close();
                }
            }
        }

        private PdfPCell CrearCelda(string texto, iTextSharp.text.Font fuente)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, fuente));
            celda.Border = PdfPCell.NO_BORDER;
            celda.Padding = 4;
            return celda;
        }
        private PdfPCell CrearCeldaTitulo(string texto, iTextSharp.text.Font fuente, int colspan = 1)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, fuente));
            celda.BackgroundColor = BaseColor.LIGHT_GRAY;
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.Padding = 6;
            celda.Colspan = colspan;
            return celda;
        }
    }
}