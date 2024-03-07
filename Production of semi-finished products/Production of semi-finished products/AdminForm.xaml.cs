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
    /// Логика взаимодействия для AdminForm.xaml
    /// </summary>
    public partial class AdminForm : Window
    {
        public AdminForm()
        {
            InitializeComponent();
            ListTikets.ItemsSource = ConnektDB.db.Tickets.ToList();
            OrderSalesManagerTabl.ItemsSource = ConnektDB.db.OrderSalesManager.ToList();
            SalesManagerTabl.ItemsSource = ConnektDB.db.SalesManager.ToList();

        }

        private void BackWards_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
        /// <summary>
        /// Выывод таблиц OrderSalesManager, PurchasingManager, Tickets
        /// </summary>
        /// <param name="sender">Вывод таблиц. Удаление данных. Добавление тикетов</param>
        /// <param name="e"></param>
        private void DellData_Click(object sender, RoutedEventArgs e)
        {
            var Tickets = ListTikets.SelectedItem as Tickets;
            var Tovars = OrderSalesManagerTabl.SelectedItem as OrderSalesManager;
            var OrderingGift = SalesManagerTabl.SelectedItem as SalesManager;
            if (Tickets != null)
            {
                ConnektDB.db.Tickets.Remove(Tickets);
                ConnektDB.db.SaveChanges();
                MessageBox.Show($"Тикет удален");

                ListTikets.ItemsSource = ConnektDB.db.Tickets.ToList();
            }
            if (Tovars != null)
            {
                ConnektDB.db.OrderSalesManager.Remove(Tovars);
                ConnektDB.db.SaveChanges();
                MessageBox.Show($"Товар удален");

                OrderSalesManagerTabl.ItemsSource = ConnektDB.db.OrderSalesManager.ToList();
            }
            if (OrderingGift != null)
            {
                ConnektDB.db.SalesManager.Remove(OrderingGift);
                ConnektDB.db.SaveChanges();
                MessageBox.Show($"Заказ  удален");

                SalesManagerTabl.ItemsSource = ConnektDB.db.PurchasingManager.ToList();
            }
        }
        /// <summary>
        /// Переход
        /// </summary>
        /// <param name="sender">Переход на страницу AddTiketsForm </param>
        /// <param name="e"></param>
        private void AddTikets_Click(object sender, RoutedEventArgs e)
        {
            AddTiketsForm addTiketsForm = new AddTiketsForm();
            addTiketsForm.Show();
            this.Close();
        }
    }
}
