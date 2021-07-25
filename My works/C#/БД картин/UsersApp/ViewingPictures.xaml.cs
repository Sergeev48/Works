using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для ViewingPictures.xaml
    /// </summary>
    public partial class ViewingPictures : Window
    {
        ApplicationContext db;

        public ViewingPictures()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Button_show(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(textBoxidred.Text.Trim());
            Picture picture = db.Pictures.Where(o => o.id_pic == a).FirstOrDefault();
            string q = picture.kartinka;
            kartinka.Source = ByteImageConverter.ByteToImage(Convert.FromBase64String(q));

        }
        public class ByteImageConverter
        {
            public static ImageSource ByteToImage(byte[] imageData)
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(imageData);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();

                ImageSource imgSrc = biImg as ImageSource;

                return imgSrc;
            }
        }
    }
}
