using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jarvis
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine engine;
        private SpeechSynthesizer synthesizer;
        public void LoadSpeach()
        {
            try
            {
                engine = new SpeechRecognitionEngine();
                engine.SetInputToDefaultAudioDevice();
                engine.LoadGrammar(new DictationGrammar());
                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);
                engine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

            }
        }
        public Form1() 
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSpeach();
        }
        private void rec(object s, SpeechRecognizedEventArgs e)
        {
            label1.Text = "You : " + e.Result.Text;
            if(e.Result.Text=="what is the time")
            {
                string time = DateTime.Now.ToString("h:mm:ss tt ");
                label2.Text = time;
            }
            else if(e.Result.Text == "what is my name")
            {
                label2.Text = "Efti Sir";
            }
            else
            {
                label2.Text = "There is nothing like it";
            }
            
        }
    }
}
