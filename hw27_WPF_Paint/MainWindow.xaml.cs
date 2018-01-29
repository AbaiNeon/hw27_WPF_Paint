using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hw27_WPF_Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonInsertClick(object sender, RoutedEventArgs e)
        {
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(@"котэ с кентами.jpg", UriKind.RelativeOrAbsolute));

            myRect.Fill = imgBrush;

            string title;
            using (FileStream stream = new FileStream(@"котэ с кентами.jpg", FileMode.OpenOrCreate))
            {
                BitmapDecoder decoder = JpegBitmapDecoder.Create(stream, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                BitmapMetadata metadata = (BitmapMetadata)decoder.Frames[0].Metadata;
                // Получаем заголовок через поле класса
                title = metadata.Title;  
            }

            myLabel.Content = title;
        }
    }
}
