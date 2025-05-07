using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
//Librerías especializadas 
using AForge.Video.DirectShow;
using AForge.Video;
using ZXing;
using ZXing.Common;

namespace LectorBarcodes
{
    public partial class AddBarcodes : Form
    {
        private FilterInfoCollection FilterInfoCollection;
        private VideoCaptureDevice VideoCaptureDevice;
        private Bitmap currentFrame = null;
        private bool cameraActive = false;
        private Size cameraResolution = new Size(640, 480); // Resolución optimizada
        private object lockObject = new object(); // Para sincronización de acceso al bitmap

        public AddBarcodes()
        {
            InitializeComponent();
            AddBarcodes_Load(this, null);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(AddBarcodes_KeyDown);
        }
        private void AddBarcodes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                cmd_readcode.PerformClick();
            }
        }

        private void cmd_back_Click(object sender, EventArgs e)
        {
            CloseCamera();
            this.Close();
            // Show the main form
            Main Win1 = new Main();
            Win1.Show();
        }

        private void StartCamera()
        {
            if (FilterInfoCollection == null || FilterInfoCollection.Count == 0)
            {
                MessageBox.Show("No se detectaron cámaras disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Detiene la cámara si ya está en funcionamiento
            CloseCamera();

            try
            {
                VideoCaptureDevice = new VideoCaptureDevice(FilterInfoCollection[cbox_camera.SelectedIndex].MonikerString);
                VideoCaptureDevice.VideoResolution = SelectOptimalResolution(VideoCaptureDevice);
                VideoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                VideoCaptureDevice.Start();
                cameraActive = true;

                // Actualiza la UI para mostrar que la cámara está activa
                lbl_status.Text = "Cámara activa - Esperando comando para escanear";
                lbl_status.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar la cámara: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmd_readcode_Click(object sender, EventArgs e)
        {
            if (!cameraActive)
            {
                // Si la cámara no está activa, la iniciamos
                StartCamera();
                return;
            }

            // Limpia el campo de resultados
            txt_resultado.Clear();

            // Captura y procesa el fotograma actual
            ProcessCurrentFrame();
        }

        private void ProcessCurrentFrame()
        {
            Bitmap frameToProcess;

            lock (lockObject)
            {
                if (currentFrame == null)
                {
                    lbl_status.Text = "No hay imagen disponible para procesar";
                    lbl_status.ForeColor = Color.Red;
                    return;
                }
                frameToProcess = new Bitmap(currentFrame); // Hacemos una copia segura
            }

            lbl_status.Text = "Procesando imagen...";
            lbl_status.ForeColor = Color.Blue;

            Task.Run(() =>
            {
                try
                {
                    BarcodeReader reader = new BarcodeReader
                    {
                        Options = new DecodingOptions
                        {
                            TryHarder = true,
                            PossibleFormats = new List<BarcodeFormat>
                    {
                        BarcodeFormat.EAN_13,
                        BarcodeFormat.EAN_8,
                        BarcodeFormat.CODE_39,
                        BarcodeFormat.CODE_128,
                        BarcodeFormat.UPC_A,
                        BarcodeFormat.UPC_E
                    },
                            PureBarcode = false,
                            AssumeGS1 = true,
                            ReturnCodabarStartEnd = true
                        },
                        AutoRotate = true, // A veces ayuda activarlo
                    };

                    var result = reader.Decode(frameToProcess);

                    if (result != null)
                    {
                        using (Graphics g = Graphics.FromImage(frameToProcess))
                        {
                            var points = result.ResultPoints;
                            if (points != null && points.Length > 0)
                            {
                                float minX = points.Min(p => p.X);
                                float minY = points.Min(p => p.Y);
                                float maxX = points.Max(p => p.X);
                                float maxY = points.Max(p => p.Y);

                                g.DrawRectangle(new Pen(Color.Lime, 5), minX, minY, maxX - minX, maxY - minY);
                                g.DrawString(result.Text, new Font("Arial", 12, FontStyle.Bold),
                                             Brushes.Red, new PointF(minX, minY - 20));
                            }
                        }

                        this.Invoke(new MethodInvoker(() =>
                        {
                            string codigo = result.Text.ToString();

                            // Comprobar si el código tiene longitud válida y agregar 0 al inicio si tiene 12 caracteres
                            if (codigo.Length == 12 || codigo.Length == 13)
                            {
                                // Si tiene 12 caracteres, agregar un 0 al inicio
                                if (codigo.Length == 12)
                                {
                                    codigo = "0" + codigo;
                                }

                                // Actualizar los elementos de la interfaz
                                txt_resultado.Text = codigo;
                                lbl_codehistory.Text = lbl_codehistory.Text + codigo + "\n";
                                lbl_status.Text = "¡Código detectado!";
                                lbl_status.ForeColor = Color.Blue;
                                System.Media.SystemSounds.Beep.Play();
                                UpdatePreviewImage(frameToProcess);

                                // Mostrar tokens léxicos en el DataGridView optimizado
                                MostrarTokensLexicos(codigo);

                            }
                            else
                            {
                                lbl_status.Text = "¡Código dañado o incompleto!";
                                lbl_status.ForeColor = Color.Red;
                                dgv_lexico.Visible = false; // Ocultar el DataGridView si el código es inválido
                            }

                            //Lineas para el test de longitud de los codigos.
                            //MessageBox.Show("Longitud del texto detectado: " + result.Text.Length.ToString(), "Longitud");
                        }));
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            lbl_status.Text = "No se detectó ningún código.";
                            lbl_status.ForeColor = Color.Red;
                            dgv_lexico.Visible = false; // Ocultar el DataGridView cuando no se detecta código
                            lbl_validación.Visible = false;
                            lbl_tabladetokens.Visible = false;
                        }));
                        frameToProcess.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        lbl_status.Text = "Error al invocar el método, intente de nuevo";
                        lbl_status.ForeColor = Color.Red;
                        dgv_lexico.Visible = false; // Ocultar el DataGridView en caso de error
                    }));
                    frameToProcess.Dispose();
                }
            });
        }

        // Método separado para mostrar los tokens léxicos de manera optimizada
        private void MostrarTokensLexicos(string codigo)
        {
            // Limpiar el DataGridView
            dgv_lexico.Columns.Clear();
            dgv_lexico.Rows.Clear();

            // Configurar propiedades para reducir espacio
            dgv_lexico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_lexico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_lexico.RowHeadersVisible = false;  // Ocultar encabezados de filas

            // Añadir columnas con nombres más cortos
            for (int i = 0; i < codigo.Length; i++)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.Name = $"col{i}";
                col.HeaderText = $"T{i + 1}";  // "T1", "T2", etc.
                col.Width = 30;  // Ancho fijo reducido
                dgv_lexico.Columns.Add(col);
            }

            // Añadir los caracteres como fila
            object[] fila = codigo.Select(c => (object)c.ToString()).ToArray();
            dgv_lexico.Rows.Add(fila);

            // Hacer visible el DataGridView
            lbl_tabladetokens.Visible = true;
            dgv_lexico.Visible = true;

            //Validación
            lbl_validación.Text = "Longitud válida: Sí (13 dígitos)\r\nTodos los caracteres son numéricos: ✔️";
            lbl_validación.Visible = true;

            RealizarAnalisisSintactico(codigo);
        }

        private void RealizarAnalisisSintactico(string codigo)
        {
            // Verificar que sea un código EAN-13 válido (13 dígitos)
            if (codigo.Length != 13 || !codigo.All(char.IsDigit))
            {
                lbl_status.Text = "El código no cumple con el formato EAN-13 (13 dígitos numéricos)";
                lbl_status.ForeColor = Color.Red;

                // También mostrar mensaje de error en lbl_estructura
                lbl_estructura.Text = "ERROR: El código no cumple con el formato EAN-13 (13 dígitos numéricos)";
                lbl_estructura.ForeColor = Color.Red;
                return;
            }

            // Extraer los componentes del código EAN-13
            string codigoSistema = codigo.Substring(0, 1);
            string codigoFabricante = codigo.Substring(1, 6);
            string codigoProducto = codigo.Substring(7, 5);
            string digitoControl = codigo.Substring(12, 1);

            // Verificar el dígito de control
            bool digitoControlValido = VerificarDigitoControl(codigo);

            // Crear DataTable para mostrar los componentes
            DataTable dt = new DataTable();
            dt.Columns.Add("Componente", typeof(string));
            dt.Columns.Add("Valor", typeof(string));
            dt.Columns.Add("Descripción", typeof(string));

            // Agregar filas con los componentes
            dt.Rows.Add("Sistema", codigoSistema, "Código del sistema");
            dt.Rows.Add("Fabricante", codigoFabricante, "Código del fabricante");
            dt.Rows.Add("Producto", codigoProducto, "Código del producto");
            dt.Rows.Add("Control", digitoControl, "Dígito de verificación");
            dt.Rows.Add("Validación", digitoControlValido ? "✓ Válido" : "✗ Inválido",
                digitoControlValido ? "El dígito de control es correcto" : "El dígito de control no coincide");

            // Mostrar en el DataGridView
            dgv_sintactico.Visible = true;
            dgv_sintactico.DataSource = dt;

            // Formatear y mostrar el mensaje según sea válido o no
            string estructuraMsg = $"Estructura: [{codigoSistema}] Código del sistema - [{codigoFabricante}] Fabricante " +
                                  $"[{codigoProducto}] Producto - [{digitoControl}] Dígito de control";

            if (digitoControlValido)
            {
                lbl_elementos.Text = estructuraMsg;
                lbl_elementos.ForeColor = Color.Black;
                lbl_estructura.Text = "Formato EAN-13 válido: ✓";
                lbl_estructura.ForeColor = Color.Green; // Color verde para mensaje positivo
            }
            else
            {
                lbl_elementos.ForeColor = Color.Black;
                lbl_elementos.Text = estructuraMsg;
                lbl_estructura.Text = "Formato EAN-13 inválido: ✗ - El dígito de control no coincide";
                lbl_estructura.ForeColor = Color.Red; // Color rojo para mensaje negativo
            }
            //Mostramos los resultados
            lbl_elementos.Visible = true;
            lbl_estructura.Visible = true;
        }

        // Método para verificar el dígito de control de un código EAN-13
        private bool VerificarDigitoControl(string codigo)
        {
            if (codigo.Length != 13 || !codigo.All(char.IsDigit))
                return false;
            // Algoritmo para calcular el dígito de control EAN-13
            int suma = 0;
            for (int i = 0; i < 12; i++)
            {
                int digito = int.Parse(codigo[i].ToString());
                suma += (i % 2 == 0) ? digito : digito * 3;
            }
            int digitoCalculado = (10 - (suma % 10)) % 10;
            int digitoReal = int.Parse(codigo[12].ToString());
            return digitoCalculado == digitoReal;
        }

        private VideoCapabilities SelectOptimalResolution(VideoCaptureDevice device)
        {
            // Obtiene todas las resoluciones disponibles
            VideoCapabilities[] videoCapabilities = device.VideoCapabilities;

            if (videoCapabilities == null || videoCapabilities.Length == 0)
                return null;

            // Busca una resolución de media que ofrezca buen equilibrio entre calidad y rendimiento
            // Prefiere resoluciones cercanas a 640x480 (VGA) que suelen ser óptimas para escáneres
            VideoCapabilities bestMatch = videoCapabilities[0];
            int targetPixels = 640 * 480;
            int minDiff = int.MaxValue;

            foreach (VideoCapabilities capability in videoCapabilities)
            {
                // Calcula la diferencia entre esta resolución y la deseada
                int pixels = capability.FrameSize.Width * capability.FrameSize.Height;
                int diff = Math.Abs(pixels - targetPixels);

                // Prioriza mayores fps para resoluciones similares
                if (diff < minDiff || (diff == minDiff && capability.AverageFrameRate > bestMatch.AverageFrameRate))
                {
                    bestMatch = capability;
                    minDiff = diff;
                }
            }

            return bestMatch;
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap frame = (Bitmap)eventArgs.Frame.Clone(); // Clonamos una sola vez

                lock (lockObject)
                {
                    if (currentFrame != null)
                    {
                        currentFrame.Dispose();
                    }
                    currentFrame = (Bitmap)frame.Clone(); // Guardamos una copia para procesar luego
                }

                UpdatePreviewImage(frame); // Mostramos la copia directa
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en NewFrame: " + ex.Message);
            }
        }


        private void UpdatePreviewImage(Bitmap image)
        {
            if (image == null) return;

            try
            {
                if (pictureBox1.InvokeRequired)
                {
                    pictureBox1.Invoke(new MethodInvoker(() => UpdatePreviewImageInternal(image)));
                }
                else
                {
                    UpdatePreviewImageInternal(image);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error actualizando imagen: " + ex.Message);
                image.Dispose();
            }
        }

        private void UpdatePreviewImageInternal(Bitmap image)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    pictureBox1.Image.Dispose();
                }
                catch { }

                pictureBox1.Image = null;
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = image;
        }

        private void CloseCamera()
        {
            if (VideoCaptureDevice != null)
            {
                if (VideoCaptureDevice.IsRunning)
                {
                    VideoCaptureDevice.SignalToStop();
                    VideoCaptureDevice.WaitForStop();
                }
                VideoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                VideoCaptureDevice = null;
            }

            lock (lockObject)
            {
                if (currentFrame != null)
                {
                    currentFrame.Dispose();
                    currentFrame = null;
                }
            }

            if (pictureBox1.Image != null)
            {
                try
                {
                    pictureBox1.Image.Dispose();
                }
                catch { }
                pictureBox1.Image = null;
            }

            cameraActive = false;
        }

        private void AddBarcodes_Load(object sender, EventArgs e)
        {
            //Elementos de los analisis
            dgv_lexico.Visible = false;
            dgv_sintactico.Visible = false;
            lbl_validación.Visible = false;
            lbl_tabladetokens.Visible = false;
            lbl_estructura.Visible = false;
            lbl_elementos.Visible = false;


            // Crea un label para mostrar el estado si no existe
            if (lbl_status == null)
            {
                lbl_status = new Label();
                lbl_status.AutoSize = true;
                lbl_status.Location = new Point(txt_resultado.Location.X, txt_resultado.Location.Y + txt_resultado.Height + 10);
                lbl_status.Name = "lbl_status";
                lbl_status.Text = "Cámara inactiva";
                lbl_status.ForeColor = Color.Gray;
                this.Controls.Add(lbl_status);
            }

            // Inicializa el filtro de cámaras al cargar el formulario
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Verifica que se haya encontrado al menos una cámara
            if (FilterInfoCollection.Count > 0)
            {
                foreach (FilterInfo device in FilterInfoCollection)
                    cbox_camera.Items.Add(device.Name);

                cbox_camera.SelectedIndex = 0;

                // Opcional: iniciar la cámara automáticamente al cargar el formulario
                // StartCamera();
            }
            else
            {
                MessageBox.Show("No se detectaron cámaras. Conecte una cámara y reinicie la aplicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Añadir un botón para iniciar la cámara si no existe ya
            if (!Controls.OfType<Button>().Any(b => b.Name == "btn_start_camera"))
            {
                Button btnStartCamera = new Button();
                btnStartCamera.Name = "btn_start_camera";
                btnStartCamera.Text = "Iniciar Cámara";
                btnStartCamera.Location = new Point(cbox_camera.Location.X + cbox_camera.Width + 10, cbox_camera.Location.Y);
                btnStartCamera.Click += (s, args) => StartCamera();
                Controls.Add(btnStartCamera);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmd_exit_Click(object sender, EventArgs e)
        {
            CloseCamera();
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbl_codehistory.Text = "";
            txt_resultado.Text = "";
            lbl_elementos.Text = "";
            lbl_estructura.Text = "";
            lbl_status.Text = "Historial de códigos borrado";
            dgv_lexico.Visible = false;
            lbl_tabladetokens.Visible = false;
            lbl_validación.Visible = false;
            
        }
    }
}