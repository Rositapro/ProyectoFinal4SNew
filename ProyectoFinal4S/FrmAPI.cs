using System.Text.Json;

namespace ProyectoFinal4S
{
    public partial class FrmAPI : Form
    {
        private const string api = "https://api.nasa.gov/planetary/apod";
        private const string key = "dlI71b7WG1efSkePYdr6zw61QSrjIMqqDQDn7GTQ";
        private readonly HttpClient _httpClient = new();

        public FrmAPI()
        {
            InitializeComponent();
            cbMonth.Items.AddRange(new string[]
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            });
            cbMonth.SelectedIndex = 0;

            dgvData.CellContentClick += dgvData_CellContentClick;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbMonth.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona un mes.");
                return;
            }

            int selectedMonth = cbMonth.SelectedIndex + 1;
            int year = DateTime.Now.Year;

            DateTime start = new DateTime(year, selectedMonth, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);

            string startDate = start.ToString("yyyy-MM-dd");
            string endDate = end.ToString("yyyy-MM-dd");

            string url = $"{api}?api_key={key}&start_date={startDate}&end_date={endDate}";

            try
            {
                string json = await _httpClient.GetStringAsync(url);
                var result = JsonSerializer.Deserialize<List<ApodResponse>>(json);

                if (result != null)
                {
                    dgvData.DataSource = result;
                    dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    // Convertir columna "url" a tipo link
                    if (dgvData.Columns["url"] is not DataGridViewLinkColumn)
                    {
                        int colIndex = dgvData.Columns["url"].Index;
                        var linkCol = new DataGridViewLinkColumn
                        {
                            Name = "url",
                            HeaderText = "Imagen",
                            DataPropertyName = "url",
                            UseColumnTextForLinkValue = false,
                            LinkBehavior = LinkBehavior.SystemDefault
                        };

                        dgvData.Columns.Remove("url");
                        dgvData.Columns.Insert(colIndex, linkCol);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para ese mes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos: " + ex.Message);
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvData.Columns[e.ColumnIndex].Name == "url")
            {
                var cellValue = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValue))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = cellValue,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo abrir el enlace: " + ex.Message);
                    }
                }
            }
        }

        public class ApodResponse
        {
            public string title { get; set; }
            public string date { get; set; }
            public string explanation { get; set; }
            public string url { get; set; }
            public string media_type { get; set; }
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
