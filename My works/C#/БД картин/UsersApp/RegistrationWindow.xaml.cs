using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        ApplicationContext db;
        public RegistrationWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();

            User regUser = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                regUser = db.Users.Where(b => b.Login == login).FirstOrDefault();
            }

            if (regUser != null)
            {
                MessageBox.Show("Такой логин уже существует");
                textBoxLogin.Background = Brushes.DarkRed;
            }
             else if (login.Length < 2)
            {
                Mark(textBoxLogin);

            } else if (password.Length < 2)
            {
                Mark(passBox);
                textBoxLogin.Background = Brushes.Transparent;
            } else if (password != pass_2)
            {
                textBoxLogin.Background = Brushes.Transparent;
                passBox.Background = Brushes.Transparent;
                Mark(passBox_2);
            } 
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;

                MessageBox.Show("Все хорошо!");
                User user = new User(login, password);
                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();

            }
        }
        public void Mark(Control control)
        {
            control.ToolTip = "Это поле введено некорректно!";
            control.Background = Brushes.DarkRed;
        }
        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }


    }
}
