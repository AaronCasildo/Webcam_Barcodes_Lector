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
                            if (result.Text.ToString().Length==13)
                            {
                                txt_resultado.Text = result.Text;
                                lbl_codehistory.Text = lbl_codehistory.Text + result.Text + "\n";
                                lbl_status.Text = "¡Código detectado!";
                                lbl_status.ForeColor = Color.Blue;
                                System.Media.SystemSounds.Beep.Play();
                                UpdatePreviewImage(frameToProcess);
                            }
                            else if (result.Text.ToString().Length == 12)
                            {
                                txt_resultado.Text = "0" + result.Text;
                                lbl_codehistory.Text = lbl_codehistory.Text + "0" + result.Text + "\n";
                                lbl_status.Text = "¡Código detectado!";
                                lbl_status.ForeColor = Color.Blue;
                                System.Media.SystemSounds.Beep.Play();
                                UpdatePreviewImage(frameToProcess);
                            }
                            else
                            {
                                lbl_status.Text = "¡Código dañado o incompleto!";
                                lbl_status.ForeColor = Color.Red;
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
                        }));
                        frameToProcess.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        lbl_status.Text = "Error al procesar: " + ex.Message;
                        lbl_status.ForeColor = Color.Red;
                    }));
                    frameToProcess.Dispose();
                }
            });
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
            lbl_status.Text = "Historial de códigos borrado";
        }
    }
}