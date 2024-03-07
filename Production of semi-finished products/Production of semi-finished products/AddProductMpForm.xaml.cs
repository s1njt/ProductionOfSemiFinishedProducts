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
    /// Логика взаимодействия для AddProductMpForm.xaml
    /// </summary>
    public partial class AddProductMpForm : Window
    {
        OrderSalesManager orderSalesManager = new OrderSalesManager();
        public AddProductMpForm()
        {
            InitializeComponent();
        }

        private void AddProductB_Click(object sender, RoutedEventArgs e)
        {
            orderSalesManager.Category = CategoryTB.Text;
            orderSalesManager.ProductName = ProductNameTB.Text;
            orderSalesManager.Price = int.Parse(PriceTB.Text);
            orderSalesManager.Quantity = int.Parse(QuantityTB.Text);

            ConnektDB.db.OrderSalesManager.Add(orderSalesManager);
            ConnektDB.db.SaveChanges();
            MessageBox.Show("Товар успешно добавлен!");
            MpForm mpForm = new MpForm();
            mpForm.Show();
            this.Close();
        }
    }
}
