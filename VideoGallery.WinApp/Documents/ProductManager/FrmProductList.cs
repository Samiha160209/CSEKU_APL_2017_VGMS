using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using VideoGallery.WinApp.Data;
using System.IO;

namespace VideoGallery.WinApp.Documents.ProductManager
{
    public partial class FrmProductList : Telerik.WinControls.UI.RadForm
    {
        private string searchTxt;

        public FrmProductList()
        {
            InitializeComponent();

        }

        //public FrmProductList(string searchTxt)
        //{
        //    InitializeComponent();
        //    vgmsDb = new VgmsDbContext();
        //    this.searchTxt = searchTxt;
        //}

        void Search()
        {
            string search = txtSearch.Text;

            gvProductList.DataSource = _App.VgmsDb.Product.Where(x => x.Title.Contains(search) || x.Id.ToString() == search).ToList();
        }
        public void Search(string searchTxt)
        {
            txtSearch.Text = searchTxt;
            Search();
        }
        public void LoadList()

        {
            gvProductList.DataSource = _App.VgmsDb.Product.ToList();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void gvProductList_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            txtSearch.Text = searchTxt;

            LoadList();
        }
        public FrmAddEditProduct frmProduct = null;
        private void gvProductList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (gvProductList.SelectedRows != null && gvProductList.SelectedRows.Count >= 1)
            {
                var product = gvProductList.SelectedRows[0].DataBoundItem as Product;

                if (frmProduct == null)
                {
                    frmProduct = new FrmAddEditProduct(this);
                    frmProduct.Show(this);
                }
                frmProduct.Populate(product);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvProductList.SelectedRows != null && gvProductList.SelectedRows.Count >= 1)
            {
                var product = gvProductList.SelectedRows[0].DataBoundItem as Product;
                if (product != null)
                {
                    DialogResult res = MessageBox.Show(this, "Are you sure, you want to delete Product?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        var productToDelete = _App.VgmsDb.Product.SingleOrDefault(x => x.Id == product.Id);
                        if (productToDelete != null)
                        {
                            var imageTodel = AppDomain.CurrentDomain.BaseDirectory + productToDelete.ImagePath;

                            _App.VgmsDb.Product.Remove(productToDelete);
                            _App.VgmsDb.SaveChanges();

                            if (File.Exists(imageTodel))
                            {
                                File.Delete(imageTodel);
                            }
                        }
                        LoadList();

                        MessageBox.Show(this, "Product deleted", "success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
