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
using OfficeOpenXml;
using System.IO;

namespace Production_of_semi_finished_products
{
    /// <summary>
    /// Логика взаимодействия для OrderFormMp.xaml
    /// </summary>
    public partial class OrderFormMp : Window
    {
        decimal totalPrice;
        public OrderFormMp()
        {
            InitializeComponent();
            SalesManager.ItemsSource = ConnektDB.db.SalesManager.ToList();
            var data = (SalesManager.ItemsSource as IEnumerable<SalesManager>).ToList();

            // Расчет общей суммы столбца "Price"
            totalPrice = data.Sum(item => item.Price ?? 0);

            // Вывод суммы в Label
            SummPrice.Content = "Общая сумма: " + totalPrice.ToString();
        }

        private void BackWards_Click(object sender, RoutedEventArgs e)
        {
            MpForm mpForm = new MpForm();
            mpForm.Show();
            this.Hide();
        }

        private void SaveRecipeExel_Click(object sender, RoutedEventArgs e)
        {
            // Создание нового Excel пакета
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Создание нового листа Excel
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Квитанция");

                // Получение данных из DataGrid
                var data = (SalesManager.ItemsSource as IEnumerable<SalesManager>).ToList();

                // Запись данных в Excel
                worksheet.Cells[1, 2].Value = "Название";
                worksheet.Cells[1, 3].Value = "Цена";
                worksheet.Cells[1, 4].Value = "Кол-во на складе";
                worksheet.Cells[1, 5].Value = "Зарезервировано";
                worksheet.Cells[1, 6].Value = "Количество";

                // Запись данных в Excel
                for (int currentRow = 1; currentRow <= data.Count; currentRow++)
                {
                    worksheet.Cells[currentRow + 1, 1].Value = data[currentRow - 1].ID;
                    worksheet.Cells[currentRow + 1, 2].Value = data[currentRow - 1].ProductName;
                    worksheet.Cells[currentRow + 1, 3].Value = data[currentRow - 1].Price;
                    worksheet.Cells[currentRow + 1, 4].Value = data[currentRow - 1].StockАvailability;
                    worksheet.Cells[currentRow + 1, 5].Value = data[currentRow - 1].Reserved;
                    worksheet.Cells[currentRow + 1, 6].Value = data[currentRow - 1].Quantity;
                }

                // Запись общей стоимости и подписи для общей стоимости
                worksheet.Cells[data.Count + 2, 7].Value = "Общая стоимость:";
                worksheet.Cells[data.Count + 2, 8].Value = totalPrice;
                worksheet.Cells[data.Count + 2, 8].Style.Font.Bold = true;
                worksheet.Cells[data.Count + 2, 8].Style.Numberformat.Format = "#,##0.00" + "руб";
                // Выравнивание столбцов по ширине содержимого
                worksheet.Cells.AutoFitColumns();
                // Сохранение Excel файла на жестком диске
                string filePath = @"C:\Users\DNS\Desktop\Индигриеты дял продуктов.xlsx";
                FileInfo excelFile = new FileInfo(filePath);
                excelPackage.SaveAs(excelFile);
                MessageBox.Show($"Квитанция сохранена успешно!");
            }
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.Show();
            this.Close();
        }

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            SalesManager.ItemsSource = ConnektDB.db.SalesManager.Where(x => x.ProductName.StartsWith(SerchTB.Text) || x.ProductName.Contains(SerchTB.Text)).ToList();
        }
    }
}
