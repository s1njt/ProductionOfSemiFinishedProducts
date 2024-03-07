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
    /// Логика взаимодействия для MzForm.xaml
    /// </summary>
    public partial class MzForm : Window
    {
        SalesManager salesManager = new SalesManager();
        public MzForm()
        {
            InitializeComponent();
            SalesManagerTabl.ItemsSource = ConnektDB.db.SalesManager.ToList();

        }
        private void SortTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(SortTB.Text, out int sortValue))
            {
                SalesManagerTabl.ItemsSource = ConnektDB.db.SalesManager.Where(x => x.StockАvailability <= sortValue).ToList();
            }
            else
            {
                // Если поле сортировки пустое, выводим все данные
                SalesManagerTabl.ItemsSource = ConnektDB.db.PurchasingManager.ToList();
            }
        }

        private void BackWards_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void ReceiptForm_Click(object sender, RoutedEventArgs e)
        {
            ReceiptForm receiptform = new ReceiptForm();
            receiptform.Show();
        }

        private void PurchaseProduct_Click(object sender, RoutedEventArgs e)
        {
            var obj = SalesManagerTabl.SelectedItem as SalesManager;
            if (obj != null)
            {
                ConnektDB.db.SalesManager.Remove(obj);
                ConnektDB.db.SaveChanges();
                MessageBox.Show($"Товар {obj.ProductName.ToUpper()}\nУспешно заказан у поставщика\nДата привоза заказа: {DateTime.Now.AddDays(3):dd.MM.yyyy}", "Успешный заказ", MessageBoxButton.OK, MessageBoxImage.Information);
                SalesManagerTabl.ItemsSource = ConnektDB.db.SalesManager.ToList();
            }
        }
    }
}
