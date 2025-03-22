using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using ScreenRecorderLib;
using NAudio.Wave;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{




    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        private Recorder _recorder;
        private string _videoPath;

        
        private WaveInEvent _micCapture;
        private List<byte> _micAudioBuffer = new List<byte>();

        private const int WM_HOTKEY = 0x0312;
        private const uint MOD_NONE = 0x0000;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue200,    
                Primary.Blue600,    
                Primary.Blue200,    
                Accent.LightBlue200,
                TextShade.WHITE
            );
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            try
            {
                var test = Recorder.CreateRecorder();
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show("Some system components (like DirectX or Media Foundation) are missing.\n\n" +
                    "Please install DirectX Runtime or Media Feature Pack.", "Missing Dependencies",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1); 
            }

            //  F1, F2 и F3
            RegisterHotKey(this.Handle, 1, MOD_NONE, (uint)Keys.F1); // Start
            RegisterHotKey(this.Handle, 2, MOD_NONE, (uint)Keys.F2); // Pause
            RegisterHotKey(this.Handle, 3, MOD_NONE, (uint)Keys.F3); // Stop
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();
                switch (id)
                {
                    case 1: // F1 – Start
                        BtnStart_Click(this, EventArgs.Empty);
                        break;
                    case 2: // F2 – Pause
                        btnPause_Click(this, EventArgs.Empty);
                        break;
                    case 3: // F3 – Stop
                        BtnStop_Click(this, EventArgs.Empty);
                        break;
                }
            }
            base.WndProc(ref m);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
            UnregisterHotKey(this.Handle, 3);
            base.OnFormClosing(e);
        }





        private void ClearDailyLogFile()
        {
            try
            {
                string commonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string logFolder = Path.Combine(commonData, "MyScreenRecorderApp", "Logs");
                Directory.CreateDirectory(logFolder);
                string logFile = Path.Combine(logFolder, "ScreenRecorderLog.txt");

                if (File.Exists(logFile))
                {
                    
                    DateTime lastWrite = File.GetLastWriteTime(logFile);
                    if (lastWrite.Date < DateTime.Today)
                    {
                        
                        File.WriteAllText(logFile, string.Empty);
                    }
                }
            }
            catch
            {
                
            }
        }


        // ------------------ ЛОГИРОВАНИЕ ------------------
        private void Log(string message)
        {
            try
            {
                string commonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string logFolder = Path.Combine(commonData, "MyScreenRecorderApp", "Logs");
                Directory.CreateDirectory(logFolder); // создаем папку, если ее нет
                string logFile = Path.Combine(logFolder, "ScreenRecorderLog.txt");
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                File.AppendAllText(logFile, $"{time}  {message}{Environment.NewLine}");
            }
            catch
            {
                
            }
        }

        // ------------------ КНОПКА START ------------------
        private async void BtnStart_Click(object sender, EventArgs e)
        {

            ClearDailyLogFile();
            BtnStart.Enabled = false;
            BtnStart.BackColor = System.Drawing.Color.LightGray;
            await Task.Delay(1000);

            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string videoFileName = $"CaptureScreenAudio_{timestamp}.mp4";
                _videoPath = Path.Combine(desktopPath, videoFileName);

                
                bool audioEnabled = (chkSystemAudio.Checked || chkMicrophone.Checked);

                var recOptions = new RecorderOptions
                {
                    AudioOptions = new AudioOptions
                    {
                        IsAudioEnabled = audioEnabled
                    },
                    VideoEncoderOptions = new VideoEncoderOptions
                    {
                        Framerate = 30,
                        Bitrate = 8000000
                    }
                };

                _recorder = Recorder.CreateRecorder(recOptions);
                _recorder.OnRecordingComplete += Recorder_OnRecordingComplete;
                _recorder.OnRecordingFailed += Recorder_OnRecordingFailed;

                Log("Attempting to start recording. Saving video to: " + _videoPath);
                _recorder.Record(_videoPath);
                lblStatus.Text = "Recording...";
                Log("Recording started successfully.");

                
                chkSystemAudio.Enabled = false;
                chkMicrophone.Enabled = false;

                
                if (chkMicrophone.Checked)
                {
                    _micAudioBuffer.Clear();
                    Log("Attempting to start microphone recording.");
                    _micCapture = new WaveInEvent
                    {
                        WaveFormat = new WaveFormat(44100, 16, 1)
                    };
                    _micCapture.DataAvailable += (s, argsData) =>
                    {
                        _micAudioBuffer.AddRange(argsData.Buffer.Take(argsData.BytesRecorded));
                    };
                    _micCapture.StartRecording();
                    Log("Microphone recording started.");
                }

               
            }
            catch (Exception ex)
            {
                
                BtnStart.Enabled = true;

                Log("Exception in Record(): " + ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show("Error starting recording:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------ КНОПКА STOP ------------------
        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (_recorder != null)
                {
                    Log("Attempting to stop screen recording.");
                    _recorder.Stop();
                    _recorder.Dispose();
                    _recorder = null;
                    lblStatus.Text = "Stopped";
                    Log("Screen recording stopped successfully.");
                }
                else
                {
                    Log("Stop called but _recorder is null.");
                    MessageBox.Show("Recorder not active.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                
                bool micRecorded = false;
                string micFilePath = "";
                if (chkMicrophone.Checked && _micCapture != null)
                {
                    Log("Attempting to stop microphone recording.");
                    _micCapture.StopRecording();
                    WaveFormat micFormat = _micCapture.WaveFormat;
                    _micCapture.Dispose();
                    _micCapture = null;
                    Log("Microphone recording stopped.");

                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    micFilePath = Path.Combine(desktop, $"CaptureMicrophone_{timestamp}.wav");
                    SaveWavFile(micFilePath, _micAudioBuffer, micFormat);
                    Log("Microphone audio saved to: " + micFilePath);
                    micRecorded = true;
                }


                lblStatus.Text = "Saving...";
                Cursor = Cursors.WaitCursor;

                
                if (chkMicrophone.Checked && micRecorded)
                {
                    MergeFiles(_videoPath, micFilePath);
                }
                else
                {
                    
                    MessageBox.Show($"Recording stopped.\nFinal file saved to: {_videoPath}",
                                    "Info",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping recording:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log("Exception in BtnStop_Click: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                
                Cursor = Cursors.Default;
                chkSystemAudio.Enabled = true;
                chkMicrophone.Enabled = true;
                BtnStart.Enabled = true;
                lblStatus.Text = "Status";
                BtnStart.BackColor = System.Drawing.Color.LightSkyBlue;
            }
        }


        // ------------------ Метод MergeFiles (FFmpeg) ------------------
        private void MergeFiles(string videoFile, string micWavFile)
        {
            try
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string finalFile = Path.Combine(desktop, $"FinalCapture_{timestamp}.mp4");

                
                string ffmpegPath = Path.Combine(Application.StartupPath, "ffmpeg", "ffmpeg.exe");

                
                string arguments = $"-y -i \"{videoFile}\" -i \"{micWavFile}\" -filter_complex \"[0:a][1:a]amix=inputs=2:duration=longest\" -c:v copy -c:a aac \"{finalFile}\"";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = ffmpegPath, 
                    Arguments = arguments,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }

                
                if (File.Exists(videoFile)) File.Delete(videoFile);
                if (File.Exists(micWavFile)) File.Delete(micWavFile);

                MessageBox.Show($"Recording stopped.\nFinal file saved to: {finalFile}",
                                "Info",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Log("Merge completed successfully. Final file: " + finalFile);
            }
            catch (Exception ex)
            {
                Log("Exception during merge: " + ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show("Error merging audio and video:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ------------------ События ScreenRecorderLib ------------------
        private void Recorder_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            try
            {
                Log("OnRecordingComplete event fired. File: " + e.FilePath);
            }
            catch (Exception ex)
            {
                Log("Exception in OnRecordingComplete: " + ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show("Error in OnRecordingComplete:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Recorder_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {
            try
            {
                Log("OnRecordingFailed event fired. Error: " + e.Error);
                MessageBox.Show("Recording failed:\n" + e.Error,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log("Exception in OnRecordingFailed: " + ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show("Error in OnRecordingFailed:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------ Сохранение WAV ------------------
        private void SaveWavFile(string filePath, List<byte> audioData, WaveFormat waveFormat)
        {
            try
            {
                using (var writer = new WaveFileWriter(filePath, waveFormat))
                {
                    writer.Write(audioData.ToArray(), 0, audioData.Count);
                }
            }
            catch (Exception ex)
            {
                Log("Exception in SaveWavFile: " + ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show("Error saving WAV:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; 
            }
        }




        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string commonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string logFolder = Path.Combine(commonData, "MyScreenRecorderApp", "Logs");
                if (Directory.Exists(logFolder))
                {
                    Process.Start("explorer.exe", logFolder);
                }
                else
                {
                    MessageBox.Show("Log folder not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening log folder:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }












        private void chkSystemAudio_CheckedChanged_1(object sender, EventArgs e)
        {
            Log("chkSystemAudio changed. Checked = " + chkSystemAudio.Checked);
            
            if (!chkSystemAudio.Checked && chkMicrophone.Checked)
            {
                chkMicrophone.Checked = false;
                Log("Auto-disabled Microphone because System Audio was disabled.");
            }
        }

        private void chkMicrophone_CheckedChanged_1(object sender, EventArgs e)
        {
            Log("chkMicrophone changed. Checked = " + chkMicrophone.Checked);
            
            if (chkMicrophone.Checked)
            {
                chkSystemAudio.Checked = true;
                Log("Auto-enabled System Audio because Microphone was enabled.");
            }
        }

        private bool _isPaused = false;

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isPaused)
                {
                    
                    _recorder.Pause(); 
                    if (_micCapture != null)
                        _micCapture.StopRecording(); 
                    lblStatus.Text = "Paused";
                    btnPause.Text = "Resume";
                    _isPaused = true;
                    Log("Recording paused.");
                }
                else
                {
                    
                    _recorder.Resume(); 
                    if (_micCapture != null)
                        _micCapture.StartRecording(); 
                    lblStatus.Text = "Recording...";
                    btnPause.Text = "Pause";
                    _isPaused = false;
                    Log("Recording resumed.");
                }
            }
            catch (Exception ex)
            {
                Log("Exception in btnPause_Click: " + ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show("Error pausing/resuming recording:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
