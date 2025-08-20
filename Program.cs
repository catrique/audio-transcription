using System.Diagnostics;
using Whisper.net;
using Whisper.net.Ggml;

Console.WriteLine("Whisper.net");

string outputFilePath = "flor.txt";
using var transcript = File.CreateText(outputFilePath);
Process.Start("ffmpeg", "-i flor.mp3 -ar 16000 -ac 1 flor.wav").WaitForExit();


var modelName = "ggml-model-whisper-large-q5_0.bin";
if (!File.Exists(modelName))
{
    using var modelStream = await WhisperGgmlDownloader.GetGgmlModelAsync(GgmlType.LargeV3);
    using var fileWriter = File.OpenWrite(modelName);
    await modelStream.CopyToAsync(fileWriter);
}



Console.WriteLine("Processando audio...");

using var whisperFactory = WhisperFactory.FromPath(modelName);
using var builder = whisperFactory.CreateBuilder()
    .WithLanguage("portuguese")
    .Build();


using var audioStream = File.OpenRead("flor.wav");

await foreach (var result in builder.ProcessAsync(audioStream))
{
    Console.WriteLine($"{result.Start} -> {result.End}: {result.Text}");
    transcript.WriteLine(result.Text);
}

Console.WriteLine("Feito!");
