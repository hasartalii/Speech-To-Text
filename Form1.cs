using System;
using System.Windows.Forms;
using Vosk; 
using NAudio.Wave; 

namespace VoskProjesi 
{
    public partial class Form1 : Form
    {
        Vosk.Model model;
        VoskRecognizer rec;
        WaveInEvent waveIn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                model = new Vosk.Model("model-tr");

                rec = new VoskRecognizer(model, 16000.0f);
                rec.SetMaxAlternatives(0); 
                rec.SetWords(true);        

                waveIn = new WaveInEvent();
                waveIn.WaveFormat = new WaveFormat(16000, 1); 

                waveIn.DataAvailable += WaveIn_DataAvailable;

                this.FormClosing += Form1_FormClosing;

                btnDurdur.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Model yüklenirken bir hata oluþtu: {ex.Message}");
                Application.Exit();
            }
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (rec.AcceptWaveform(e.Buffer, e.BytesRecorded))
            {
                string finalResult = GetTextFromJson(rec.Result(), "text");

                this.Invoke((MethodInvoker)delegate
                {
                    txtGunluk.AppendText(finalResult + Environment.NewLine); 
                    lblAnlik.Text = ""; 
                });
            }
            else
            {
                string partialResult = GetTextFromJson(rec.PartialResult(), "partial");

                      this.Invoke((MethodInvoker)delegate
                {
                    lblAnlik.Text = partialResult; 
                });
            }
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                waveIn.StartRecording();
                lblAnlik.Text = "Dinleniyor...";
                btnBaslat.Enabled = false;
                btnDurdur.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mikrofon baþlatýlamadý: {ex.Message}");
            }
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            waveIn.StopRecording();
            lblAnlik.Text = "(Dinleme bekleniyor...)";
            btnBaslat.Enabled = true;
            btnDurdur.Enabled = false;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
                waveIn.Dispose();
                waveIn = null;
            }

            if (rec != null)
            {
                rec.Dispose();
                rec = null;
            }

            if (model != null)
            {
                model.Dispose();
                model = null;
            }
        }

        private string GetTextFromJson(string json, string key)
        {
            string keyPattern = $"\"{key}\" : \"";
            int startIndex = json.IndexOf(keyPattern);

            if (startIndex == -1) return string.Empty; // Anahtar bulunamadý

            startIndex += keyPattern.Length;
            int endIndex = json.IndexOf("\"", startIndex);

            if (endIndex == -1) return string.Empty; // Kapatma týrnaðý bulunamadý

            return json.Substring(startIndex, endIndex - startIndex);
        }

    }
}