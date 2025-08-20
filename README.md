# Projeto de Transcrição de Áudio (Whisper.net)

Este é um projeto simples em C\# que usa a biblioteca [Whisper.net](https://github.com/sandrohanea/whisper.net) para transcrever arquivos de áudio em formato MP3 para texto. Ele usa o **FFmpeg** para converter o áudio para um formato compatível e, em seguida, aplica o modelo de IA do Whisper para gerar a transcrição.

### Pré-requisitos

Para que o projeto funcione corretamente, você precisa ter o **FFmpeg** instalado na sua máquina.

-----

### Como Instalar o FFmpeg

A instalação varia dependendo do seu sistema operacional.

#### Windows

1.  Vá para a [página de download do FFmpeg](https://ffmpeg.org/download.html).
2.  Clique no ícone do Windows e escolha uma das opções, como o link do **gyan.dev**.
3.  Baixe o arquivo ZIP da versão `essentials`.
4.  Descompacte o conteúdo em uma pasta, por exemplo, `C:\ffmpeg`.
5.  Adicione o caminho para a pasta `bin` do FFmpeg (`C:\ffmpeg\bin`) nas **Variáveis de Ambiente** do seu sistema. Isso permite que você execute o `ffmpeg` a partir de qualquer diretório no terminal.

#### macOS

Se você usa o [Homebrew](https://brew.sh/), a instalação é bem simples:

```bash
brew install ffmpeg
```

#### Linux (Ubuntu/Debian)

Use o gerenciador de pacotes `apt`:

```bash
sudo apt update
sudo apt install ffmpeg
```

-----

### Como Usar o Projeto

1.  **Clone o repositório:**

    ```bash
    git clone https://github.com/catrique/audio-transcription.git
    cd audio-transcription
    ```

2.  **Posicione o arquivo MP3:**
    Você deve colocar o arquivo de áudio que deseja transcrever (`.mp3`) na pasta de saída do projeto, que é **`bin/Debug/net8.0`**.

    A estrutura de pastas deve ficar assim:

    ```
    transcrever/
    ├── bin/
    │   └── Debug/
    │       └── net8.0/
    │           └── seu-audio-aqui.mp3  <-- COLOQUE O ARQUIVO AQUI
    ├── obj/
    ├── Program.cs
    └── transcrever.csproj
    ```

3.  **Execute o projeto:**
    Abra um terminal na pasta raiz do projeto (`transcrever/`) e execute:

    ```bash
    dotnet run
    ```

    Na primeira execução, o programa fará o download de um modelo de IA de aproximadamente 3 GB, o que pode levar alguns minutos dependendo da sua conexão.

### O que o código faz?

O programa executa as seguintes etapas:

1.  Usa o FFmpeg para converter o arquivo `flor.mp3` para o formato `flor.wav`, que é o formato ideal para o modelo Whisper.
2.  Verifica se o modelo de IA (`ggml-model-whisper-large-q5_0.bin`) já foi baixado. Se não, ele faz o download automático.
3.  Processa o arquivo `flor.wav` e transcreve o áudio para o português.
4.  Imprime a transcrição no console e salva o texto em um arquivo chamado `flor.txt`.