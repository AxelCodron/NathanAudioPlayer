using NAudio.Wave;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NathanAudioPlayer
{
    public partial class Form1 : Form
    {
        private string DirectoryPath = "";
        private readonly WaveOutEvent WaveOut = new WaveOutEvent();
        private string currentRecord = "";
        private readonly FileSystemWatcher Watcher = new FileSystemWatcher();
        private bool stop = false;
        private bool skip = false;

        public Form1()
        {
            InitializeComponent();
            if (RemoveButtonWorker.IsBusy != true)
            {
                RemoveButtonWorker.RunWorkerAsync();
            }
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            PauseButton.Enabled = true;
            StopButton.Enabled = true;
            PlayButton.Enabled = false;
            SkipButton.Enabled = true;
            isRandomCheckBox.Enabled = false;
            if (BackgroundPlayer.IsBusy != true)
            {
                BackgroundPlayer.RunWorkerAsync();
            }
            else
            {
                DisplayLabel.Invoke((MethodInvoker)delegate
                {
                    DisplayLabel.Text = $"Listening to record \"{Path.GetFileNameWithoutExtension(currentRecord)}\"...";
                });
                WaveOut.Play();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WaveOut.Stop();
            StopButton.Enabled = false;
            PauseButton.Enabled = false;
            PlayButton.Enabled = false;
            isRandomCheckBox.Enabled = true;

            folderBrowserDialog1.ShowDialog();
            if (Directory.Exists(folderBrowserDialog1.SelectedPath))
            {
                /// Enabling plural applications to read the same folder.
                string directoryName = folderBrowserDialog1.SelectedPath.Split('\\').Last();
                if (Directory.Exists(directoryName))
                {
                    for (int i = 1; i < 100; i++)
                    {
                        if (!Directory.Exists(directoryName + i))
                        {
                            Directory.CreateDirectory(directoryName + i);
                            DirectoryPath = directoryName + i;
                            break;
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(directoryName);
                    DirectoryPath = directoryName;
                }
                Watcher.Path = DirectoryPath;
                foreach (string file in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                {
                    File.Copy(file, DirectoryPath + "\\" + file.Split('\\').Last());
                }

                if (Directory.Exists(DirectoryPath))
                {
                    string[] files = Directory.GetFiles(DirectoryPath);
                    FilesDisplay.Invoke((MethodInvoker)delegate
                    {
                        FilesDisplay.Items.Clear();
                    });
                    foreach (string item in files)
                    {
                        FilesDisplay.Invoke((MethodInvoker)delegate
                        {
                            FilesDisplay.Items.Add(new ListViewItem(item.Split('\\').Last()));
                        });
                    }
                }

                Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                    | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                Watcher.Changed += OnChanged;
                Watcher.Created += OnChanged;
                Watcher.Deleted += OnChanged;
                Watcher.Renamed += OnChanged;

                Watcher.EnableRaisingEvents = true;

                PlayButton.Enabled = true;
                DisplayLabel.Invoke((MethodInvoker)delegate
                {
                    DisplayLabel.Text = "Click on the play button to start the records.";
                });
            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (Directory.Exists(DirectoryPath))
            {
                string[] files = Directory.GetFiles(DirectoryPath);
                FilesDisplay.Invoke((MethodInvoker)delegate
                {
                    FilesDisplay.Items.Clear();
                });
                foreach (string item in files)
                {
                    FilesDisplay.Invoke((MethodInvoker)delegate
                    {
                        FilesDisplay.Items.Add(new ListViewItem(item.Split('\\').Last()));
                    });
                }
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            WaveOut.Pause();
            DisplayLabel.Invoke((MethodInvoker)delegate
            {
                DisplayLabel.Text = "Paused";
            });
            PlayButton.Enabled = true;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            DisplayLabel.Invoke((MethodInvoker)delegate
            {
                DisplayLabel.Text = "Stopped";
            });
            PlayButton.Enabled = true;
            PauseButton.Enabled = false;
            SkipButton.Enabled = false;
            StopButton.Enabled = false;
            isRandomCheckBox.Enabled = true;
            stop = true;
        }

        private void BackgroundPlayer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!stop)
            {
                string[] files = Directory.GetFiles(DirectoryPath);

                /// Randomization
                if (isRandomCheckBox.Checked)
                {
                    Random random = new Random();
                    int n = files.Length;
                    while (n > 1)
                    {
                        int k = random.Next(n--);
                        (files[k], files[n]) = (files[n], files[k]);
                    }
                }

                foreach (string record in files)
                {
                    if (File.Exists(record))
                    {
                        if (Path.GetExtension(record) == ".mp3")
                        {
                            currentRecord = record;
                            DisplayLabel.Invoke((MethodInvoker)delegate
                            {
                                DisplayLabel.Text = $"Listening to record \"{Path.GetFileNameWithoutExtension(record)}\"...";
                            });
                            Mp3FileReader reader = new Mp3FileReader(record);
                            WaveOut.Init(reader);
                            WaveOut.Play();
                            while (WaveOut.PlaybackState == PlaybackState.Playing || WaveOut.PlaybackState == PlaybackState.Paused)
                            {
                                Thread.Sleep(100);
                                if (stop || skip)
                                {
                                    WaveOut.Stop();
                                    skip = false;
                                    break;
                                }
                            }
                            WaveOut.Stop();
                            WaveOut.Dispose();
                            GC.Collect();
                            if (stop)
                            {
                                break;
                            }
                        }
                        else if (Path.GetExtension(record) == ".wav")
                        {
                            currentRecord = record;
                            DisplayLabel.Invoke((MethodInvoker)delegate
                            {
                                DisplayLabel.Text = $"Listening to record \"{Path.GetFileNameWithoutExtension(record)}\"...";
                            });
                            WaveFileReader reader = new WaveFileReader(record);
                            WaveOut.Init(reader);
                            WaveOut.Play();
                            while (WaveOut.PlaybackState == PlaybackState.Playing || WaveOut.PlaybackState == PlaybackState.Paused)
                            {
                                Thread.Sleep(100);
                                if (stop || skip)
                                {
                                    WaveOut.Stop();
                                    skip = false;
                                    break;
                                }
                            }
                            WaveOut.Stop();
                            WaveOut.Dispose();
                            GC.Collect();
                            if (stop)
                            {
                                break;
                            }
                        }
                        else
                        {
                            DisplayLabel.Invoke((MethodInvoker)delegate
                            {
                                DisplayLabel.Text = $"Skipping \"{Path.GetFileNameWithoutExtension(record)}\", the file is not in the mp3 format.";
                            });
                            Thread.Sleep(1000);
                        }
                        DisplayLabel.Invoke((MethodInvoker)delegate
                        {
                            DisplayLabel.Text = $"Waiting {numericUpDown.Value} seconds before next recording...";
                        });
                        Thread.Sleep((int)numericUpDown.Value * 1000);
                    }
                }
            }

            stop = false;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in FilesDisplay.Items)
            {
                string path = DirectoryPath + "\\" + item.Text;
                if (item.Checked)
                {
                    if (currentRecord == path)
                    {
                        DisplayLabel.Invoke((MethodInvoker)delegate
                        {
                            DisplayLabel.Text = $"Cannot remove a file that is currently playing.";
                        });
                    }
                    else
                    {
                        DisplayLabel.Invoke((MethodInvoker)delegate
                        {
                            DisplayLabel.Text = $"Supressed";
                        });
                        try
                        {
                            File.Delete(path);
                            Thread.Sleep(200);
                        }
                        catch
                        {
                            DisplayLabel.Invoke((MethodInvoker)delegate
                            {
                                DisplayLabel.Text = $"Error while supressing the file.";
                            });
                        }
                    }
                }
            }
        }

        private void RemoveButtonWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                FilesDisplay.Invoke((MethodInvoker)delegate
                {
                    if (FilesDisplay.CheckedItems.Count > 0)
                    {
                        RemoveButton.Visible = true;
                    }
                    else
                    {
                        RemoveButton.Visible = false;
                    }
                });
            }
        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            skip = true;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // TODO
            // Directory.Delete(DirectoryPath, true);
        }
    }
}
