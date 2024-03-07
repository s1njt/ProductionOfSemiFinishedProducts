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
    /// Логика взаимодействия для AddProductInvoiceForm.xaml
    /// </summary>
    public partial class AddProductInvoiceForm : Window
    {
        Invoice invoice = new Invoice();
        public AddProductInvoiceForm()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            invoice.ProductName = ProductNameTB.Text;
            invoice.UnitMeasurement = UnitMeasurementTB.Text;
            invoice.PricePerUnitMeasurement = int.Parse(PricePerUnitMeasurementTB.Text);
            invoice.Cost = int.Parse(CostTB.Text);

            ConnektDB.db.Invoice.Add(invoice);
            ConnektDB.db.SaveChanges();
            MessageBox.Show("Товар успешно дабавлен в чек!");
            InvoiceForm invoiceForm = new InvoiceForm();
            invoiceForm.Show();
            this.Close();
        }
    }
}
