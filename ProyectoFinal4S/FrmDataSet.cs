using MailKit.Net.Smtp;
//using iText.IO.Font.Constants;
//using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
//using iText.Layout.Properties;
using MimeKit;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace ProyectoFinal4S
{
    public partial class FrmDataSet : Form
    {
        // Lista para guardar todas las filas leídas del CSV 

        private List<string[]> allRows = new List<string[]>();
        public FrmDataSet()
        {
            InitializeComponent();


            // Evento para cambiar vista
            cmbViewOption.Items.Clear();
            cmbViewOption.Items.AddRange(new string[] { "Tabla", "Texto Plano" });
            cmbViewOption.SelectedIndex = 0; // Por defecto tabla
            cmbViewOption.SelectedIndexChanged += cmbViewOption_SelectedIndexChanged;

            txtPlainText.Visible = false;

            this.Load += Form2_Load;
            btnFilterClass.Click += btnFilterClass_Click;
        }

        // Evento Load: llenar ComboBox con opciones de clase
        private void Form2_Load(object sender, EventArgs e)
        {
            cmbClassFilter.Items.Clear();
            cmbClassFilter.Items.AddRange(new string[] { "TODOS", "STAR", "GALAXY", "QSO" });
            cmbClassFilter.SelectedIndex = 0; // Por defecto "TODOS"

            cmbExportFormat.Items.Clear();
            cmbExportFormat.Items.AddRange(new string[] { "CSV", "TXT", "JSON", "XML", "PDF" });
            cmbExportFormat.SelectedIndex = 0;

            cmbDeleteType.Items.Clear();
            cmbDeleteType.Items.AddRange(new string[] { "Fila", "Columna" });
            cmbDeleteType.SelectedIndex = 0;
        }

        // Método para convertir los datos a texto plano
        private string ConvertToPlainText()
        {
            var sb = new StringBuilder();

            // Encabezados
            var headers = dgvData.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText);
            sb.AppendLine(string.Join("\t", headers));  // Tab para separar columnas

            // Filas
            foreach (var row in allRows)
            {
                sb.AppendLine(string.Join("\t", row));
            }
            return sb.ToString();
        }

        // Evento cambio de vista
        private void cmbViewOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = cmbViewOption.SelectedItem.ToString();

            if (option == "Texto Plano")
            {
                txtPlainText.Text = ConvertToPlainText();
                txtPlainText.Visible = true;
                dgvData.Visible = false;
            }
            else if (option == "Tabla")
            {
                txtPlainText.Visible = false;
                dgvData.Visible = true;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog
            //{
            //    Filter = "CSV and TXT files (*.csv;*.txt)|*.csv;*.txt",
            //    Title = "Open file"
            //};

            //if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            //string filePath = openFileDialog.FileName;

            //try
            //{
            //    var lines = File.ReadAllLines(filePath);

            //    dgvData.Rows.Clear();
            //    dgvData.Columns.Clear();
            //    allRows.Clear();

            //    if (lines.Length > 0)
            //    {
            //        char delimiter = ',';
            //        var headers = lines[0].Split(delimiter);
            //        foreach (var header in headers)
            //        {
            //            dgvData.Columns.Add(header, header);
            //        }

            //        for (int i = 1; i < lines.Length; i++)
            //        {
            //            var row = lines[i].Split(delimiter);
            //            allRows.Add(row);
            //        }

            //        DisplayRows(allRows);
            //        LlenarTreeView(allRows); // Llenar el TreeView con los datos
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error loading data: " + ex.Message);
            //}
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV and TXT files (*.csv;*.txt)|*.csv;*.txt",
                Title = "Abrir archivo"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string filePath = openFileDialog.FileName;

            try
            {
                var lines = File.ReadAllLines(filePath);

                dgvData.Rows.Clear();
                dgvData.Columns.Clear();
                allRows.Clear();

                if (lines.Length > 0)
                {
                    char delimiter = ',';  // O cualquier delimitador que estés utilizando
                    var headers = lines[0].Split(delimiter);

                    // Asegúrate de que las columnas necesarias estén presentes en el archivo CSV
                    if (!headers.Contains("class") || !headers.Contains("objid") || !headers.Contains("ra") || !headers.Contains("dec"))
                    {
                        MessageBox.Show("El archivo CSV no contiene las columnas necesarias (class, objid, ra, dec).");
                        return;
                    }

                    // Mostrar los encabezados para depuración
                    foreach (var header in headers)
                    {
                        Console.WriteLine("Encabezado: " + header); // Esto imprimirá todos los encabezados en la consola
                    }

                    // Agregar las columnas al DataGridView
                    foreach (var header in headers)
                    {
                        dgvData.Columns.Add(header, header);
                    }

                    // Validar las filas y asegurarse de que el número de columnas es correcto
                    for (int i = 1; i < lines.Length; i++)
                    {
                        var row = lines[i].Split(delimiter);

                        // Verificar que la fila tenga el número correcto de columnas
                        if (row.Length == headers.Length)
                        {
                            allRows.Add(row);
                        }
                        else
                        {
                            // Si la fila no tiene el número esperado de columnas, muestra un mensaje
                            MessageBox.Show($"Fila {i + 1} tiene un número incorrecto de columnas.");
                        }
                    }

                    // Mostrar los datos en el DataGridView
                    DisplayRows(allRows);

                    // Llenar el TreeView después de cargar los datos
                    LlenarTreeView(allRows);  // Llamada a la función para llenar el TreeView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }

        }

        // Función para mostrar filas en DataGridView
        private void DisplayRows(List<string[]> rows)
        {
            dgvData.Rows.Clear();
            foreach (var row in rows)
            {
                dgvData.Rows.Add(row);
            }
        }

        private void btnFilterClass_Click(object sender, EventArgs e)
        {
            string filtroSeleccionado = cmbClassFilter.SelectedItem.ToString();

            // Buscar índice de la columna "class"
            int indexClass = dgvData.Columns.Cast<DataGridViewColumn>()
                .FirstOrDefault(col => col.HeaderText.Equals("class", StringComparison.OrdinalIgnoreCase))?.Index ?? -1;

            if (indexClass == -1)
            {
                MessageBox.Show("No se encontró la columna 'class'.");
                return;
            }

            // Mostrar todas las filas si seleccionó "TODOS"
            if (filtroSeleccionado.Equals("TODOS", StringComparison.OrdinalIgnoreCase))
            {
                DisplayRows(allRows);
                return;
            }

            // Filtrar filas que coincidan exactamente con el filtro seleccionado (insensible a mayúsculas)
            var filasFiltradas = allRows.Where(row =>
                row.Length > indexClass &&
                row[indexClass].Equals(filtroSeleccionado, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            DisplayRows(filasFiltradas);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cmbExportFormat.SelectedItem == null)
                return;

            string formato = cmbExportFormat.SelectedItem.ToString();

            // Configuración del cuadro de diálogo para guardar archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = $"Exportar a {formato}",
                Filter = GetExportFilter(formato)  // Dependiendo del formato seleccionado
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string ruta = saveFileDialog.FileName;

            try
            {
                switch (formato)
                {
                    case "CSV":
                        GuardarArchivoCSV(ruta);
                        break;
                    case "TXT":
                        GuardarArchivoTXT(ruta);
                        break;
                    case "JSON":
                        ExportarAJSON(ruta);
                        break;
                    case "XML":
                        ExportarAXML(ruta);
                        break;
                    case "PDF":
                        ExportarAPDF(ruta);
                        break;
                }

                // Confirmación de exportación
                MessageBox.Show($"Archivo exportado correctamente en formato {formato}.");

                // Abrir el archivo automáticamente
                Process.Start(new ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exportando archivo: " + ex.Message);
            }
        }

        private string GetExportFilter(string formato)
        {
            return formato switch
            {
                "CSV" => "CSV files (*.csv)|*.csv",
                "TXT" => "TXT files (*.txt)|*.txt",
                "JSON" => "JSON files (*.json)|*.json",
                "XML" => "XML files (*.xml)|*.xml",
                "PDF" => "PDF files (*.pdf)|*.pdf",
                _ => throw new InvalidOperationException("Unknown format.")
            };

        }

        public void GuardarArchivoCSV(string ruta)
        {
            var lines = new List<string>
            {
                string.Join(",", dgvData.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText))
            };

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>().Select(cell => EscapeForCsv(cell.Value?.ToString() ?? ""));
                    lines.Add(string.Join(",", cells));
                }
            }

            File.WriteAllLines(ruta, lines);
        }

        private string EscapeForCsv(string value)
        {
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }
            return value;
        }

        public void GuardarArchivoTXT(string ruta)
        {
            var lines = new List<string>
            {
                string.Join("\t", dgvData.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText))
            };

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString() ?? "");
                    lines.Add(string.Join("\t", cells));
                }
            }

            File.WriteAllLines(ruta, lines);
        }

        public void ExportarAJSON(string ruta)
        {
            var listaObjetos = new List<Dictionary<string, string>>();

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    var dict = new Dictionary<string, string>();
                    foreach (DataGridViewColumn col in dgvData.Columns)
                    {
                        var valor = row.Cells[col.Index].Value?.ToString() ?? "";
                        dict[col.HeaderText] = valor;
                    }
                    listaObjetos.Add(dict);
                }
            }

            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(listaObjetos, opciones);

            File.WriteAllText(ruta, jsonString);
        }

        public void ExportarAXML(string ruta)
        {
            var root = new XElement("Registros");

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    var registro = new XElement("Registro");
                    foreach (DataGridViewColumn col in dgvData.Columns)
                    {
                        var valor = row.Cells[col.Index].Value?.ToString() ?? "";
                        registro.Add(new XElement(col.HeaderText, valor));
                    }
                    root.Add(registro);
                }
            }

            var doc = new XDocument(root);
            doc.Save(ruta);
        }

        private void ExportarAPDF(string ruta)
        {
            try
            {
                if (string.IsNullOrEmpty(ruta))
                {
                    MessageBox.Show("Ruta de archivo no válida.");
                    return;
                }

                using (var writer = new PdfWriter(ruta))
                using (var pdf = new PdfDocument(writer))
                using (var document = new Document(pdf))
                {
                    Table table = new Table(dgvData.Columns.Count);

                    // Encabezados
                    foreach (DataGridViewColumn col in dgvData.Columns)
                    {
                        table.AddHeaderCell(new Paragraph(col.HeaderText));
                    }

                    // Filas
                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.IsNewRow) continue;

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(new Paragraph(cell.Value?.ToString() ?? ""));
                        }
                    }

                    document.Add(table);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("El archivo está en uso o no se puede acceder. Ciérralo si está abierto.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message);
            }
        }
        // Función para enviar correo con archivo adjunto usando MailKit
        private void EnviarCorreo(string toEmail, string subject, string body, string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("El archivo adjunto no existe.");
                return;
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Rosalinda", "rosalindacedillo2017@gmail.com"));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = subject;

            var builder = new BodyBuilder { TextBody = body };
            builder.Attachments.Add(filePath);
            message.Body = builder.ToMessageBody();

            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("rosalindacedillo2017@gmail.com", "rqcs laqq upjg rypk");

                    client.Send(message);
                    client.Disconnect(true);
                }

                MessageBox.Show("Correo enviado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }

        private void LlenarTreeView(List<string[]> rows)
        {
            //treeView.Nodes.Clear(); // Limpiar los nodos existentes

            //// Agrupar las filas por "class" (o cualquier otro campo que elijas)
            //var agrupadoPorClase = rows.GroupBy(row => row[ObtenerIndiceColumna("class")]).ToList();

            //foreach (var grupoClase in agrupadoPorClase)
            //{
            //    // Crear el nodo raíz basado en la clase
            //    TreeNode nodoClase = new TreeNode(grupoClase.Key); // "class" (por ejemplo, "QSO")
            //    treeView.Nodes.Add(nodoClase);

            //    // Para cada clase, agrupar por ubicación (RA, Dec)
            //    var agrupadoPorUbicacion = grupoClase.GroupBy(row => new { RA = row[ObtenerIndiceColumna("RA")], Dec = row[ObtenerIndiceColumna("Dec")] }).ToList();

            //    foreach (var grupoUbicacion in agrupadoPorUbicacion)
            //    {
            //        // Crear un nodo para la ubicación
            //        TreeNode nodoUbicacion = new TreeNode($"RA: {grupoUbicacion.Key.RA}, Dec: {grupoUbicacion.Key.Dec}");
            //        nodoClase.Nodes.Add(nodoUbicacion);

            //        // Agregar detalles adicionales o IDs de objetos debajo del nodo de ubicación
            //        foreach (var item in grupoUbicacion)
            //        {
            //            string objectID = item[ObtenerIndiceColumna("objectID")]; // Ejemplo de ID de objeto
            //            TreeNode nodoObjeto = new TreeNode($"Object ID: {objectID}");
            //            nodoUbicacion.Nodes.Add(nodoObjeto);
            //        }
            //    }
            //}



            //treeView.Nodes.Clear(); // Limpiar los nodos existentes

            //// Agrupar las filas por "class" (o cualquier otro campo que elijas)
            //var agrupadoPorClase = rows.GroupBy(row => row[ObtenerIndiceColumna("class")]).ToList();

            //foreach (var grupoClase in agrupadoPorClase)
            //{
            //    // Crear el nodo raíz basado en la clase
            //    TreeNode nodoClase = new TreeNode(grupoClase.Key); // "class" (por ejemplo, "QSO")
            //    treeView.Nodes.Add(nodoClase);

            //    // Agrupar por "Redshift" solo si el valor de Redshift es positivo
            //    var agrupadoPorRedshift = grupoClase
            //        .Where(row => double.TryParse(row[ObtenerIndiceColumna("Redshift")], out double redshift) && redshift > 0) // Filtrar por Redshift positivo
            //        .GroupBy(row => row[ObtenerIndiceColumna("Redshift")])
            //        .ToList();

            //    foreach (var grupoRedshift in agrupadoPorRedshift)
            //    {
            //        // Crear un nodo para Redshift
            //        TreeNode nodoRedshift = new TreeNode($"Redshift: {grupoRedshift.Key}");
            //        nodoClase.Nodes.Add(nodoRedshift);

            //        // Agregar el Object ID para cada objeto
            //        foreach (var item in grupoRedshift)
            //        {
            //            string objectID = item[ObtenerIndiceColumna("objectID")]; // Ejemplo de ID de objeto
            //            TreeNode nodoObjeto = new TreeNode($"Object ID: {objectID}");
            //            nodoRedshift.Nodes.Add(nodoObjeto);
            //        }
            //    }
            //}

            treeView.Nodes.Clear(); // Limpiar los nodos existentes

            // Agrupar las filas por "class" (o cualquier otro campo que elijas)
            var agrupadoPorClase = rows.GroupBy(row => row[ObtenerIndiceColumna("class")]).ToList();

            foreach (var grupoClase in agrupadoPorClase)
            {
                // Crear el nodo raíz basado en la clase
                TreeNode nodoClase = new TreeNode(grupoClase.Key); // "class" (por ejemplo, "QSO", "STAR", "GALAXY")
                treeView.Nodes.Add(nodoClase);

                // Agrupar por "objid" (ID del objeto)
                var agrupadoPorObjid = grupoClase
                    .GroupBy(row => row[ObtenerIndiceColumna("objid")])
                    .ToList();

                foreach (var grupoObjid in agrupadoPorObjid)
                {
                    // Crear un nodo para el "objid"
                    TreeNode nodoObjid = new TreeNode($"Objid: {grupoObjid.Key}");
                    nodoClase.Nodes.Add(nodoObjid);

                    // Agregar el RA y DEC bajo el objeto
                    foreach (var item in grupoObjid)
                    {
                        string ra = item[ObtenerIndiceColumna("ra")]; // Right Ascension
                        string dec = item[ObtenerIndiceColumna("dec")]; // Declination
                        TreeNode nodoCoordenadas = new TreeNode($"RA: {ra}, DEC: {dec}");
                        nodoObjid.Nodes.Add(nodoCoordenadas);
                    }
                }
            }

        }

        // Función auxiliar para obtener el índice de una columna por su nombre
        private int ObtenerIndiceColumna(string nombreColumna)
        {
            // Asumiendo que los datos provienen de un CSV y tienen encabezados
            var encabezados = dgvData.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText).ToList();
            return encabezados.IndexOf(nombreColumna);
        }


        private void btnClearData_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Seguro que quieres limpiar toda la tabla?",
                                       "Confirmar limpieza",
                                       MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                dgvData.Rows.Clear();
                dgvData.Columns.Clear();
                allRows.Clear();
            }
        }

        private void btnEnviarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Mostrar todos los tipos de archivos que has permitido para exportar
                Filter = "CSV files (*.csv)|*.csv|TXT files (*.txt)|*.txt|JSON files (*.json)|*.json|XML files (*.xml)|*.xml|PDF files (*.pdf)|*.pdf",
                Title = "Seleccionar archivo para enviar por correo"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string ruta = openFileDialog.FileName;

            if (!File.Exists(ruta))
            {
                MessageBox.Show("El archivo seleccionado no existe.");
                return;
            }

            try
            {
                EnviarCorreo("rosalindacedillo2017@gmail.com", "Archivo Exportado", "Aquí está el archivo exportado.", ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentCell == null)
            {
                MessageBox.Show("Selecciona una celda para eliminar la fila o columna correspondiente.");
                return;
            }

            string opcion = cmbDeleteType.SelectedItem.ToString();

            if (opcion == "Fila")
            {
                int rowIndex = dgvData.CurrentCell.RowIndex;

                var confirm = MessageBox.Show($"¿Eliminar fila {rowIndex + 1}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    dgvData.Rows.RemoveAt(rowIndex);
                    if (rowIndex < allRows.Count)
                        allRows.RemoveAt(rowIndex);
                }
            }
            else if (opcion == "Columna")
            {
                int colIndex = dgvData.CurrentCell.ColumnIndex;
                string colName = dgvData.Columns[colIndex].HeaderText;

                var confirm = MessageBox.Show($"¿Eliminar columna '{colName}'?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    dgvData.Columns.RemoveAt(colIndex);

                    // Actualizar allRows para eliminar esa columna
                    for (int i = 0; i < allRows.Count; i++)
                    {
                        var listRow = allRows[i].ToList();
                        if (colIndex < listRow.Count)
                            listRow.RemoveAt(colIndex);
                        allRows[i] = listRow.ToArray();
                    }
                }
            }
        }
    }
}