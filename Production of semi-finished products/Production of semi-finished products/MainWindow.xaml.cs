using System;
using System.Collections.Generic;
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

namespace Production_of_semi_finished_products
{
    /// <summary>
    /// Логика взаимодействия для MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserNameCB.SelectedIndex = 0;
        }

        private void EnterBT_Click(object sender, RoutedEventArgs e)
        {
            var sotrudnik = ConnektDB.db.Users.FirstOrDefault(x => x.Password == PasswordB.Password);

            if (sotrudnik != null)
            {
                if (UserNameCB.Text == "Администратор" && sotrudnik.Password == "1")
                {
                    MessageBox.Show("Успешный вход админа!");

                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                    this.Hide();
                }
                else if (UserNameCB.Text == "Менеджер продаж" && sotrudnik.Password == "2")
                {
                    MessageBox.Show("Успешный вход менеджер продаж!");

                    MpForm mpForm = new MpForm();
                    mpForm.Show();
                    this.Hide();
                }
                else if(UserNameCB.Text == "Менеджер закупок" && sotrudnik.Password == "3")
                {
                    MessageBox.Show("Успешный вход менеджер закупок!");

                    MzForm mzForm = new MzForm();
                    mzForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неправильная роль пользователя.");
                }
            }
            else
            {
                MessageBox.Show("Неправильные данные.");
            }
        }

        private void ExitPO_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
