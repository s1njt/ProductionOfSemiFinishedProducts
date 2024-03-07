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
    /// Логика взаимодействия для MpForm.xaml
    /// </summary>
    public partial class MpForm : Window
    {

        public MpForm()
        {
            InitializeComponent();
            OrderSalesManagerTabl.ItemsSource = ConnektDB.db.OrderSalesManager.ToList();
            Categori.SelectedIndex = 0;
        }
        private void Categori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Categori.SelectedIndex == 0)
            {
                OrderSalesManagerTabl.ItemsSource = ConnektDB.db.OrderSalesManager.ToList();
            }
            else if (Categori.SelectedIndex == 1)
            {
                OrderSalesManagerTabl.ItemsSource = ConnektDB.db.OrderSalesManager.Where(x => x.Category == "Готовые продукты").ToList();
            }
            else if(Categori.SelectedIndex == 2)
            {
                OrderSalesManagerTabl.ItemsSource = ConnektDB.db.OrderSalesManager.Where(x => x.Category == "Замароженные полуфобрикаты").ToList();
            }
            else if(Categori.SelectedIndex == 3)
            {
                OrderSalesManagerTabl.ItemsSource = ConnektDB.db.OrderSalesManager.Where(x => x.Category == "Глубокая забарозка").ToList();
            }
            else
            {
                OrderSalesManagerTabl.ItemsSource = ConnektDB.db.OrderSalesManager.ToList();
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            OrderFormMp orderFormMp = new OrderFormMp();
            orderFormMp.Show();
            this.Hide();
        }

        private void ReceiptForm_Click(object sender, RoutedEventArgs e)
        {
            ReceiptForm receiptform = new ReceiptForm();
            receiptform.Show();
        }

        private void InvoiseForm_Click(object sender, RoutedEventArgs e)
        {
            InvoiceForm invoiceform = new InvoiceForm();
            invoiceform.Show();
            this.Close();
        }

        private void PriceTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(PriceTB.Text, out int sortValue))
            {
                OrderSalesManagerTabl.ItemsSource = ConnektDB.db.OrderSalesManager.Where(x => x.Price <= sortValue).ToList();
            }
            else
            {
                // Если поле сортировки пустое, выводим все данные
                OrderSalesManagerTabl.ItemsSource = ConnektDB.db.OrderSalesManager.ToList();
            }
        }

        private void BackWards_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void AddProductMP_Click(object sender, RoutedEventArgs e)
        {
            AddProductMpForm addProductMpForm = new AddProductMpForm();
            addProductMpForm.Show();
            this.Close();
        }
    }
}
