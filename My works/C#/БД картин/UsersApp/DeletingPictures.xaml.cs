using System;
using System.Linq;
using System.Windows;


namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для DeletingPictures.xaml
    /// </summary>
    public partial class DeletingPictures : Window
    {
        ApplicationContext db;
        public DeletingPictures()
        {
            InitializeComponent();

            db = new ApplicationContext();

        }

        private void Udalit(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(textBoxidred.Text.Trim());
            Picture picture = db.Pictures.Where(o => o.id_pic == a).FirstOrDefault();
            db.Pictures.Remove(picture);
            db.SaveChanges();
            


            UserPageWindow userPageWindow = new UserPageWindow();
            userPageWindow.Show();
            Hide();
        }
    }
}
