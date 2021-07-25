using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using Microsoft.Win32;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AddingPictures.xaml
    /// </summary>
    public partial class AddingPictures : Window
    {
        ApplicationContext db;  
        public AddingPictures()
        {
            InitializeComponent();

            db = new ApplicationContext();

        }
        string kart;
        private void Dobavit(object sender, RoutedEventArgs e)
        {
            string nazvanie = textBoxNazv.Text.Trim();
            string avtor = textBoxAvtor.Text.Trim();
            int god = Convert.ToInt32(textBoxGod.Text.Trim());
            string kartinka = kart;
            string dat = da.Text.Trim();
            string vremya = PresetTimePicker.Text.Trim();
            string nalichie;
            if (perekl.IsChecked == false)
                nalichie = "нет в наличии";
            else
                nalichie = "есть в наличии";


            if (nazvanie.Length == 0)
            {
                Mark(textBoxNazv);

            }
            else if (avtor.Length == 0)
            {
                Mark(textBoxAvtor);
                textBoxNazv.Background = Brushes.Transparent;
            }
            else if (god == 0)
            {
                Mark(textBoxGod);
                textBoxAvtor.Background = Brushes.Transparent;

            }
            else
            {
                textBoxNazv.Background = Brushes.Transparent;
                textBoxAvtor.Background = Brushes.Transparent;
                textBoxGod.Background = Brushes.Transparent;

                Picture picture = new Picture(nazvanie, avtor, god,kartinka,dat,vremya,nalichie);
                db.Pictures.Add(picture);
                db.SaveChanges();

                UserPageWindow userPageWindow = new UserPageWindow();
                userPageWindow.Show();
                Hide();

            }

        }
        public void Mark(Control control)
        {
            control.ToolTip = "Это поле введено некорректно!";
            control.Background = Brushes.DarkRed;
        }
        private void Button_kartina(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                kart = Convert.ToBase64String(File.ReadAllBytes(openFileDialog.FileName));
                aff.Text = openFileDialog.FileName;
                            }
            
        }
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

