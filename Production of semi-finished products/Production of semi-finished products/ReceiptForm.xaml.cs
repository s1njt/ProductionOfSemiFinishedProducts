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
    /// Логика взаимодействия для ReceiptForm.xaml
    /// </summary>
    public partial class ReceiptForm : Window
    {
        public ReceiptForm()
        {
            InitializeComponent();
            ListTikets.ItemsSource = ConnektDB.db.Tickets.ToList();

        }

        private void BackWards_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }


        private void AddTikets_Click(object sender, RoutedEventArgs e)
        {
            AddTiketsForm addTiketsForm = new AddTiketsForm();
            addTiketsForm.Show();
            this.Close();
        }
    }
}