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
    /// Логика взаимодействия для AddProductForm.xaml
    /// </summary>
    public partial class AddProductForm : Window
    {
        SalesManager salesManager = new SalesManager();
        public AddProductForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Добавление данных в SalesManager 
        /// </summary>
        /// <param name="sender">Добавление данных и переход на страницу OrderFormMp</param>
        /// <param name="e"></param>
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            salesManager.ProductName = ProductNameTB.Text;
            salesManager.Price = int.Parse(PriceTB.Text);
            salesManager.StockАvailability = int.Parse(StockАvailabilityTB.Text);
            salesManager.Reserved = ReservedTB.Text;
            salesManager.Quantity = int.Parse(QuantityTB.Text);

            ConnektDB.db.SalesManager.Add(salesManager);
            ConnektDB.db.SaveChanges();
            MessageBox.Show("Заявка на приобритение успешно отправлена!");
            OrderFormMp orderFormMp = new OrderFormMp();
            orderFormMp.Show();
            this.Close();
        }
    }
}
