using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;
using BizDeducter.View.Expenses;
using Syncfusion.XlsIO;
using System.IO;
using BizDeducter.Helpers;
using Plugin.Media.Abstractions;

namespace BizDeducter.View
{
    public partial class HomePage : ContentPage
    {

        HomeViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new HomeViewModel(this);

            ButtonDeduction.Clicked += async (sender, e) =>
                await Navigation.PushAsync(new OtherExpensePage());

            ButtonReports.Clicked += (sender, e) =>
            {
                var stream = CreateExcel();
                DependencyService.Get<IEmailHelper>().SendMail(stream);
            };

            ButtonMileage.Clicked += async (sender, e) =>
                await Navigation.PushAsync(new MileageExpensePage());

            ButtonTaxServices.Clicked += async (sender, e) =>
                await Navigation.PushAsync(new TaxServicesPage());

        }

        MemoryStream CreateExcel()
        {
            ExcelEngine excel = new ExcelEngine();
            IApplication application = excel.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;
            IWorkbook workbook = application.Workbooks.Create(1);

            IWorksheet workSheet = workbook.Worksheets[0];
            workSheet.Name = "Expense Report";

            workSheet.Range["A1"].Text = "Name";
            workSheet.Range["A1:C1"].ColumnWidth = 20;
			workSheet.Range["D1"].ColumnWidth = 50;
            workSheet.Range["B1"].Text = "Purpose";
            workSheet.Range["C1"].Text = "Amount";
            workSheet.Range["D1"].Text = "Photo";

            int currRowCount = 2;

            foreach (var expense in viewModel.Expenses)
            {

                workSheet.Range["A" + currRowCount].Text = expense.Name;
                workSheet.Range["B" + currRowCount].Text = expense.Purpose;
                workSheet.Range["C" + currRowCount].Text = expense.Amount.ToString();

                if (expense.Receipt != string.Empty)
                {
                    Stream imageStream = DependencyService.Get<IStreamHelper>().GetStream(expense.Receipt);
                    
                    if (imageStream != null)
                    {
                        imageStream.Position = 0;
						workSheet.Range[currRowCount,1].RowHeight = 100;
						workSheet.Pictures.AddPicture(currRowCount, 4,currRowCount+1, 5,imageStream);
                        imageStream.Close();
                    }
                }
                currRowCount++;
            }

            workbook.Version = ExcelVersion.Excel2013;
            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excel.Dispose();

            return stream;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Expenses.Count == 0 || viewModel.IsDirty)
                viewModel.LoadExpensesCommand.Execute(null);
        }
    }
}