using Flier.Toolbox.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace Demo
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            TextBox_Resoult.Text = String.Join(",", TextBox_Text.Text.IndexOfAll(TextBox_Pattern.Text));
            stopwatch.Stop();
            MessageBox.Show($"IndexOfAll Cost {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Start();
            string text = TextBox_Text.Text;
            List<int> resoult = new List<int>();
            for (int i=0;i<text.Length;i++)
            {
                i=text.IndexOf(TextBox_Pattern.Text,i);
                if (i == -1)
                    break;
                resoult.Add(i);
            }
            TextBox_Resoult.Text = String.Join(",", resoult);
            stopwatch.Stop();
            MessageBox.Show($"IndexOf Cost {stopwatch.ElapsedMilliseconds} ms");

        }
    }
}
