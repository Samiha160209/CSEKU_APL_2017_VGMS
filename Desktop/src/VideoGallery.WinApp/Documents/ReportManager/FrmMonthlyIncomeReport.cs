using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGallery.WinApp.Documents.ReportManager
{
    public partial class FrmMonthlyIncomeReport : Telerik.WinControls.UI.RadForm
    {
        public FrmMonthlyIncomeReport()
        {
            InitializeComponent();
        }


        private void FrmMonthlyIncomeReport_Load(object sender, EventArgs e)
        {
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            EndtDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,23,59,59);
            LoadReport();
        }
        DateTime StartDate
        {
            get
            {
                return new DateTime(dTPickerStart.Value.Year, dTPickerStart.Value.Month, dTPickerStart.Value.Day, 0, 0, 1);
            }
            set
            {
                dTPickerStart.Value = value;
            }
        }
        DateTime EndtDate
        {
            get
            {
                return new DateTime(dTPickerEnd.Value.Year, dTPickerEnd.Value.Month, dTPickerEnd.Value.Day, 23, 59, 59);
            }
            set
            {
                dTPickerEnd.Value = value;
            }
        }
        void LoadReport()
        {
            //var invoiceList = _App.VgmsDb.Invoice.Where(x => x.CreateDate >= dTPickerStart.Value && x.CreateDate <= dTPickerEnd.Value).ToList();

            var productSoldList=_App.VgmsDb.Sold.Include("Product")
                              .Where(x => x.SaleDate >= StartDate && x.SaleDate <= EndtDate).OrderByDescending(x=>x.InvoiceId).ToList();

            int totalItem = 0;
            var totalCost = 0.00;
            var totalPrice = 0.00;
            var totalProfit = 0.00;

            foreach (var item in productSoldList)
            {
                totalItem += item.Quantity;
                if (item.Product!=null)
                {
                    totalCost += item.Quantity * item.Product.BuyPrice;
                }
               
                totalPrice += item.TotalPrice ;
            }
            totalProfit =  totalPrice - totalCost;

            lblItemSold.Text = totalItem.ToString();
            lblTotalCost.Text = totalCost.ToString();
            lblTotalPrice.Text = totalPrice.ToString();
            lblProfit.Text = totalProfit.ToString();

            gvReportList.DataSource = null;
            gvReportList.DataSource = productSoldList;
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

    
    }
}
