using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoGallery.WinApp.Data;
using VideoGallery.WinApp.Documents.CustomerManager;
using VideoGallery.WinApp.Documents.ProductManager;
using VideoGallery.WinApp.Documents.ReportManager;
using VideoGallery.WinApp.Documents.SellManager;
using VideoGallery.WinApp.Documents.UserManager;

namespace VideoGallery.WinApp
{
    public partial class FrmMain : Telerik.WinControls.UI.RadForm
    {

        public FrmMain()
        {
            InitializeComponent();
            this.miAddCdDvd.Click += this.miAddCdDvd_Click;
            this.miCdDvdList.Click += miCdDvdList_Click;
            this.miCustomerAdd.Click += miCustomerAdd_Click;
            this.miCustomerList.Click += miCustomerList_Click;
            this.miUserAdd.Click += miUserAdd_Click;
            this.miUserSearch.Click += miUserSearch_Click;
            miMonthlyIncome.Click += MiMonthlyIncome_Click;
            miExit.Click += MiExit_Click;

        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {

            ddlProductSearch.DataSource = _App.VgmsDb.Product.ToList();
            ddlProductSearch.DisplayMember = "Title";
            ddlProductSearch.ValueMember = "Id";
           
            ddlProductSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            ddlProductSearch.SelectedIndex = -1;
            this.ddlProductSearch.SelectedIndexChanged += this.ddlProductSearch_SelectedIndexChanged;

        }
        private void ddlProductSearch_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddlProductSearch.SelectedIndex != -1 && ddlProductSearch.SelectedItem.DataBoundItem != null)
            {
                var product = ddlProductSearch.SelectedItem.DataBoundItem as Product;
                if (product != null)
                {
                    LoadProductSearch(product);
                }
            }
        }

        void LoadProductSearch(Product product)
        {
            //set other property
            lblTitle.Text = product.Title;
            lblActor.Text = product.Actors;
            lblDirector.Text = product.Directors;
            lblProduser.Text = product.Producers;
            lblReleaseDate.Text = product.ReleaseDate.ToString("dd/MM/yyyy");
            lblPrice.Text = product.SellingPrice.ToString();
            lblAvaiable.Text = product.Avaiable.ToString();
            var imagePath= AppDomain.CurrentDomain.BaseDirectory + product.ImagePath;
            if (File.Exists(imagePath))
            {
                pbProductImage.BackgroundImage = null;
                pbProductImage.ImageLocation = imagePath;
            }
            else
            {
                pbProductImage.BackgroundImage = Properties.Resources.BlankImage;
              
                pbProductImage.ImageLocation = "";

            }
           
        }

        private void FrmTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void miCustomerAdd_Click(object sender, EventArgs e)
        {
            new FrmAddEditCustomer().Show(this);

        }

        private void miCustomerList_Click(object sender, EventArgs e)
        {
            FrmCustomerList frm = new FrmCustomerList();
            frm.Show(this);
        }


        private void miAddCdDvd_Click(object sender, EventArgs e)
        {
            FrmAddEditProduct pro = new FrmAddEditProduct();
            pro.Show(this);
        }

        private void miCdDvdList_Click(object sender, EventArgs e)
        {
            FrmProductList list = new FrmProductList();
            list.Show(this);
        }

        private void miUserAdd_Click(object sender, EventArgs e)
        {
            FrmAddEditUser frmUser = new FrmAddEditUser();
            frmUser.Show(this);

        }

        private void miUserSearch_Click(object sender, EventArgs e)
        {
            FrmUserList frmUserList = new FrmUserList();
            frmUserList.Show(this);

        }
        private void btnAddCdDvd_Click(object sender, EventArgs e)
        {
            new FrmAddEditProduct().Show(this);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            new FrmAddEditCustomer().Show(this);
        }

        

        private void btnSale_Click(object sender, EventArgs e)
        {
            new FrmSaleProduct().Show(this);
        }

        private void MiMonthlyIncome_Click(object sender, EventArgs e)
        {
               new Documents.ReportManager.FrmMonthlyIncomeReport().Show(this);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FrmMonthlyIncomeReport report = new FrmMonthlyIncomeReport();
            report.Show(this);
        }
    }
}
