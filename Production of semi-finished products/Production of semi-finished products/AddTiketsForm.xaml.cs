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
using System.Windows.Shapes;


namespace Production_of_semi_finished_products
{
    /// <summary>
    /// Логика взаимодействия для AddTiketsForm.xaml
    /// </summary>
    public partial class AddTiketsForm : Window
    {
        Tickets tickets = new Tickets();
        
        public AddTiketsForm()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Добавление данных в таблицу Tickets.
        /// </summary>
        /// <param name="sender">Добавление данных и переход на страницу AdminForm</param>
        /// <param name="e"></param>
        private void ButtonAddTiket_Click(object sender, RoutedEventArgs e)
        {
            tickets.Data = DataTB.Text;
            tickets.Condition = ConditionTB.Text;
            tickets.Proprietor = ProprietorTB.Text;
            tickets.Comment = CommentTB.Text;

            ConnektDB.db.Tickets.Add(tickets);
            ConnektDB.db.SaveChanges();
            MessageBox.Show("Тикет добавлен!");
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Close();
        }
    }
}
