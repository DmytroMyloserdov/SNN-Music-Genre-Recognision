using System.Diagnostics;
using System.Threading.Tasks;

namespace GenreRecognizer
{
    public class CallPythonScriptManager
    {
        public Task<string> RecognizeGenre(string filePath) => Task.Run(() =>
        {
            var process = CreatePowerShellProcess(
                $@"-windowstyle hidden cd '.\Scripts'; C:\Users\Dmytro\AppData\Local\Programs\Python\Python37\python.exe snn.py --recognise {filePath}");

            process.Start();
            var result = string.Empty;
            using var reader = process.StandardOutput;
            while (!process.HasExited)
                result = reader.ReadToEnd();

            return result;
        });

        public Task TrainNeuralNetwork(string folderPath) => Task.Run(() =>
        {
            var process = CreatePowerShellProcess(
                $@"-windowstyle hidden cd '.\Scripts'; C:\Users\Dmytro\AppData\Local\Programs\Python\Python37\python.exe snn.py --train {folderPath}");

            process.Start();
            using var reader = process.StandardOutput;
            while (!process.HasExited)
                reader.ReadToEnd();
        });

        private Process CreatePowerShellProcess(string args)
        {
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "powershell.exe",
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            var process = new Process {StartInfo = startInfo};

            return process;
        }
    }
}
