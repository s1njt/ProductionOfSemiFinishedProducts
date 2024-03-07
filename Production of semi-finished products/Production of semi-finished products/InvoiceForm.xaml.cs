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
    /// Логика взаимодействия для InvoiceForm.xaml
    /// </summary>
    public partial class InvoiceForm : Window
    {
        private int counter;
        private string counterFilePath = "counter.txt";//системная дата 
        decimal totalPrice;
        public InvoiceForm()
        {
            InitializeComponent();
            Invoice.ItemsSource = ConnektDB.db.Invoice.ToList();
            var data = (Invoice.ItemsSource as IEnumerable<Invoice>).ToList();

            dateTextBlock.Text = DateTime.Now.ToString();
            Loaded += InvoiceForm_Loaded;

            // Расчет общей суммы столбца "Price"
            totalPrice = data.Sum(item => item.Cost ?? 0);
            SummPrice.Content = "Общая сумма: " + totalPrice.ToString();
        }
        /// <summary>
        /// Счетчик счета-фактуры
        /// </summary>
        /// <param name="sender">Счетчик перехода на страницу</param>
        /// <param name="e"></param>
        private void InvoiceForm_Loaded(object sender, RoutedEventArgs e)
        {
            // При каждой загрузке формы, проверяем, существует ли файл счетчика
            if (File.Exists(counterFilePath))
            {
                //Считываем значение счетчика из файла
                string counterValue = File.ReadAllText(counterFilePath);
                if (int.TryParse(counterValue, out int savedCounter))
                {
                    counter = savedCounter;
                }
            }
            // Увеличиваем значение счетчика и обновляем Label
            counter++;
            CounterLabel.Content = counter.ToString("0000");
            // Сохраняем значение счетчика в файл
            File.WriteAllText(counterFilePath, counter.ToString());
        }

        private void BackWards_Click(object sender, RoutedEventArgs e)
        {
            MpForm mpForm = new MpForm();
            mpForm.Show();
            this.Hide();
        }
        /// <summary>
        /// Сохранение всех данных на форме в exel документ
        /// </summary>
        /// <param name="sender">Сохранение данных в exel документ </param>
        /// <param name="e"></param>
        private void SaveRecipeExel_Click(object sender, RoutedEventArgs e)
        {
            // Создание нового Excel пакета
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Создание нового листа Excel
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Квитанция");

                // Получение данных из DataGrid
                var data = (Invoice.ItemsSource as IEnumerable<Invoice>).ToList();

                // Запись данных в Excel
                worksheet.Cells[1, 2].Value = "Название";
                worksheet.Cells[1, 3].Value = "Единица измирения";
                worksheet.Cells[1, 4].Value = "Цена за еденицу товара";
                worksheet.Cells[1, 5].Value = "Стоимость";

                // Запись данных в Excel
                for (int currentRow = 1; currentRow <= data.Count; currentRow++)
                {
                    worksheet.Cells[currentRow + 1, 1].Value = data[currentRow - 1].ID;
                    worksheet.Cells[currentRow + 1, 2].Value = data[currentRow - 1].ProductName;
                    worksheet.Cells[currentRow + 1, 3].Value = data[currentRow - 1].UnitMeasurement;
                    worksheet.Cells[currentRow + 1, 4].Value = data[currentRow - 1].PricePerUnitMeasurement;
                    worksheet.Cells[currentRow + 1, 5].Value = data[currentRow - 1].Cost;
                }

                // Запись общей стоимости и подписи для общей стоимости
                worksheet.Cells[data.Count + 2, 5].Value = "Общая стоимость:";
                worksheet.Cells[data.Count + 2, 6].Value = totalPrice;
                worksheet.Cells[data.Count + 2, 6].Style.Font.Bold = true;
                worksheet.Cells[data.Count + 2, 6].Style.Numberformat.Format = "#,##0.00"+"руб";

                // Запись значений текстовых полей
                worksheet.Cells[1, 8].Value = "Информация о заказчике";
                worksheet.Cells[1, 8, 1, 9].Merge = true; // Объединение ячеек с 1-й строки и 8-м столбцом до 1-й строки и 9-го столбца
                worksheet.Cells[2, 8].Value = "ФИО";
                worksheet.Cells[3, 8].Value = "Адрес";
                worksheet.Cells[4, 8].Value = "Покупатель(Организация)";
                worksheet.Cells[5, 8].Value = "Адрес доставки";

                worksheet.Cells[2, 9].Value = FCsTB.Text; // Значение из поля FCsTB
                worksheet.Cells[3, 9].Value = AdressTB.Text; // Значение из поля AdressTB
                worksheet.Cells[4, 9].Value = BuyerTB.Text; // Значение из поля BuyerTB
                worksheet.Cells[5, 9].Value = DeliveryAddressTB.Text; // Значение из поля DeliveryAddressTB
                worksheet.Cells.AutoFitColumns();

                // Сохранение Excel файла на жестком диске
                string counterValue = CounterLabel.Content.ToString();
                string fileName = $"Квитанция_{counterValue}.xlsx";
                string filePath = System.IO.Path.Combine(@"C:\Users\DNS\Desktop", fileName);
                FileInfo excelFile = new FileInfo(filePath);
                excelPackage.SaveAs(excelFile);
                MessageBox.Show($"Квитанция сохранена успешно!");
            }
        }

        private void DellЕntry_Click(object sender, RoutedEventArgs e)
        {
            var fwwef = Invoice.SelectedItem as Invoice;
            if (fwwef != null)
            {
                ConnektDB.db.Invoice.Remove(fwwef);
                ConnektDB.db.SaveChanges();
                MessageBox.Show($"Товар {fwwef.ProductName} удален");

                Invoice.ItemsSource = ConnektDB.db.Invoice.ToList();
            }
        }

        private void AddProductInvoiceB_Click(object sender, RoutedEventArgs e)
        {
            AddProductInvoiceForm addProductInvoiceForm = new AddProductInvoiceForm();
            addProductInvoiceForm.Show();
            this.Close();
        }
    }
}
