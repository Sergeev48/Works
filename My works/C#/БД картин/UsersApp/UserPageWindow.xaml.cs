using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        
        public UserPageWindow()
        {
            InitializeComponent();

            ApplicationContext db = new ApplicationContext();
            List<Picture> pictures = db.Pictures.ToList();
            listOfUsers.ItemsSource = pictures;
            


        }

        private void Button_dobavit(object sender, RoutedEventArgs e)
        {
            AddingPictures addingPictures = new AddingPictures();
            addingPictures.Show();
            Hide();
        }


        private void Button_udalit(object sender, RoutedEventArgs e)
        {
            DeletingPictures deletingPictures = new DeletingPictures();
            deletingPictures.Show();
        }

        private void Button_kart(object sender, RoutedEventArgs e)
        {
            ViewingPictures viewingPictures = new ViewingPictures();
            viewingPictures.Show();
        }
    }
}
