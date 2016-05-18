using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog(); 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
            Nullable<bool> result = dlg.ShowDialog();
            
            if (result == true)
            { 
                string filename = dlg.FileName;
                FileBox.Text = filename;
            }
            var picture = new Bitmap(FileBox.Text);
            var pictureHeight = picture.Size.Height;
            var pictureWidht = picture.Size.Width;

            //размер
            SizeBox.Text = picture.Size.ToString();
            FrameBox.Text = (pictureHeight * pictureWidht).ToString();

            //количество байтов
            FileInfo pf = new FileInfo(FileBox.Text);
            long size = pf.Length;
            ButeSize.Text = size.ToString();

            //время создания
            pf = new FileInfo(FileBox.Text);
            string data = pf.LastWriteTime.ToShortDateString() + " " + pf.LastWriteTime.ToLongTimeString();
            OpenData.Text = data;

            //время последнего изменения
            string data1 = pf.CreationTime.ToShortDateString() + " " + pf.CreationTime.ToLongTimeString();
            LastAccess.Text = data1;

            //только для чтения
            bool a = pf.IsReadOnly;
            ReadOnly.Text = a.ToString();
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
