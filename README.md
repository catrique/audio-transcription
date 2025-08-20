# 🎙️ Transcrição de Áudio com Whisper.net

Este projeto realiza a transcrição automática de arquivos de áudio usando [Whisper.net](https://github.com/Const-me/Whisper) e [FFmpeg](https://ffmpeg.org/). Basta colocar o arquivo de áudio no mesmo diretório do programa e executar — o texto transcrito será salvo em um arquivo `.txt`.

## 🚀 Como funciona

1. Converte o áudio para o formato `.wav` com 16kHz e canal mono usando FFmpeg.
2. Baixa o modelo Whisper (LargeV3) se ainda não estiver presente.
3. Processa o áudio e gera a transcrição.
4. Salva o resultado em `nome_do_arquivo_da_transcricao.txt`.

## 📁 Estrutura esperada

Coloque o arquivo de áudio no mesmo diretório do executável ou do código-fonte. Exemplo:

```
transcrever/
├── Program.cs
├── ggml-large-v3.bin (gerado automaticamente)
├── arquivo_de_audio.mp3
├── arquivo_de_audio.wav (gerado automaticamente)
├── nome_do_arquivo_da_transcricao.txt (gerado automaticamente)
```

## 🛠️ Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [FFmpeg](https://ffmpeg.org/download.html) instalado e disponível no PATH
- Conexão com a internet (para baixar o modelo na primeira execução)

## 📦 Instalação

Clone o repositório e compile com o .NET CLI:

```bash
git clone https://github.com/catrique/audio-transcription.git
cd audio-transcription
dotnet build
```

## ▶️ Execução

```bash
dotnet build
dotnet run
```

O programa irá:

1. Converter o áudio para `.wav` com FFmpeg
2. Baixar o modelo Whisper (se necessário)
3. Transcrever o áudio
4. Salvar o texto em `nome_do_arquivo_da_transcricao.txt`

## 📝 Resultado

A transcrição será exibida no console e salva em `nome_do_arquivo_da_transcricao.txt`.

