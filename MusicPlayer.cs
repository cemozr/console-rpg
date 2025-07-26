using System;
using System.Threading;
using NAudio.Wave;

public class MusicPlayer
{
    private static IWavePlayer waveOut;
    private static AudioFileReader audioFile;

    public static void PlayMusic(string path, bool loop = true)
    {
        try
        {
            waveOut = new WaveOutEvent();
            audioFile = new AudioFileReader(path);
            waveOut.Init(audioFile);
            waveOut.Play();

            if (loop)
            {
                waveOut.PlaybackStopped += (s, e) =>
                {
                    audioFile.Position = 0;
                    waveOut.Play();
                };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Music Error] {ex.Message}");
        }
    }

    public static void StopMusic()
    {
        waveOut?.Stop();
        audioFile?.Dispose();
        waveOut?.Dispose();
    }
}
