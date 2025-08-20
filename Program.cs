using System.Diagnostics;
using Whisper.net;
using Whisper.net.Ggml;

Console.WriteLine("Whisper.net");

string outputFilePath = "nome_do_arquivo_da_transcricao.txt";
using var transcript = File.CreateText(outputFilePath);
Process.Start("ffmpeg", "-i arquivo_de_audio.mp3 -ar 16000 -ac 1 arquivo_de_audio.wav").WaitForExit();

var modelName = "ggml-large-v3.bin";
if (!File.Exists(modelName))
{
    Console.WriteLine("Baixando!");
    using var modelStream = await WhisperGgmlDownloader.GetGgmlModelAsync(GgmlType.LargeV2);

    using var fileWriter = File.OpenWrite(modelName);
    await modelStream.CopyToAsync(fileWriter);
}

Console.WriteLine("Processando audio...");

using var whisperFactory = WhisperFactory.FromPath(modelName);
using var builder = whisperFactory.CreateBuilder()
    .WithLanguage("portuguese")
    .Build();


using var audioStream = File.OpenRead("arquivo_de_audio.wav");

await foreach (var result in builder.ProcessAsync(audioStream))
{
    Console.WriteLine($"{result.Start} -> {result.End}: {result.Text}");
    transcript.WriteLine(result.Text);
}

Console.WriteLine("Feito!");
