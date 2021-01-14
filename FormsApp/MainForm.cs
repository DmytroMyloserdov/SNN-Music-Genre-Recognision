using System;
using System.Windows.Forms;

namespace GenreRecognizer
{
    public partial class GenreRecognitionForm : Form
    {
        private readonly CallPythonScriptManager _manager;
        public GenreRecognitionForm()
        {
            InitializeComponent();
            _manager = new CallPythonScriptManager();
        }

        private async void RecognizeButtonClick(object sender, EventArgs e)
        {
            ProgressBar.Visible = true;

            var openFileDialog = new OpenFileDialog {Filter = @"Allowed files (*.csv)|*.csv" };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            
            var fileName = openFileDialog.FileName;
            var result = await _manager.RecognizeGenre(fileName);

            ProgressBar.Visible = false;
            MessageBox.Show($"{openFileDialog.SafeFileName} has genre {result}", "Info", MessageBoxButtons.OK);
        }

        private async void TrainButtonClick(object sender, EventArgs e)
        {
            ProgressBar.Visible = true;

            var openFolderDialog = new FolderBrowserDialog();
            if (openFolderDialog.ShowDialog() != DialogResult.OK && !string.IsNullOrWhiteSpace(openFolderDialog.SelectedPath)) return;

            await _manager.TrainNeuralNetwork(openFolderDialog.SelectedPath);
            ProgressBar.Visible = false;
            MessageBox.Show("Training has finished", "Info", MessageBoxButtons.OK);
        }
    }
}
