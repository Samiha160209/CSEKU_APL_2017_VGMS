using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using VideoGallery.WinApp.Data;
using System.IO;

namespace VideoGallery.WinApp.Documents.ProductManager
{
    public partial class FrmAddEditProduct : Telerik.WinControls.UI.RadForm
    {
        public enum VideoTypeEnum
        {
            Movie=0,
            Audio=1,
            Software=2,
            DigitalBook=3
        }

        public enum VideoStatusEnum
        {
            Available=0,
            NotAvailable=1
        }

        private Product product=null;
        private FrmProductList frmproductList;
        public FrmAddEditProduct()
        {
            InitializeComponent();
        }

        public FrmAddEditProduct(FrmProductList productList)
        {
            InitializeComponent();
            this.frmproductList = productList;
        }

        public void Populate(Product product)
        {
            this.product = product;
            if (product != null)
            {
                txtTitle.Text = product.Title;
                numDuration.Value = (decimal)product.DurationInMin;
                txtActor.Text = product.Actors;
                txtDirector.Text = product.Directors;
                txtProducer.Text = product.Producers;
                dtpReleaseDate.Value = product.ReleaseDate;
                numTotalItem.Value = product.TotalSold;
                numTotalSold.Value = product.TotalSold;
                ddlVideoType.SelectedText = ((VideoTypeEnum)product.VideoTypeId).ToString();
                pbImage.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + product.ImagePath;
                numPrice.Value = (decimal)product.SellingPrice;
                numBuyPrice.Value = (decimal)product.BuyPrice;


            }
        }
        bool IsValidToSaveProduct()
        {


            if (txtTitle.Text == "")
            {
                MessageBox.Show("Enter Title");
                return false;
            }

            if (numDuration.Text == "")
            {
                MessageBox.Show("Enter Duration Time");
                return false;
            }

            if (txtActor.Text == "")
            {
                MessageBox.Show("Enter Actor Name");
                return false;
            }

            if (txtDirector.Text == "")
            {
                MessageBox.Show("Enter Director Name");
                return false;
            }

            if (txtProducer.Text == "")
            {
                MessageBox.Show("Enter producer Name");
                return false;
            }

            if (dtpReleaseDate.Value > DateTime.Now)
            {
                MessageBox.Show("Invalied Date");
                return false;

            }


            return true;
        }

        void SaveProduct()
        {
            if (IsValidToSaveProduct())
            {
                Product productToSave = null;
                if(product != null)
                {
                    productToSave = _App.VgmsDb.Product.SingleOrDefault( x => x.Id == product.Id);
                }
                if (productToSave == null)
                {
                    productToSave = new Product();
                    _App.VgmsDb.Product.Add(productToSave);
                    product = productToSave;

                }
                productToSave.Title = txtTitle.Text;
                productToSave.DurationInMin = (double)numDuration.Value;
                productToSave.Actors = txtActor.Text;
                productToSave.Directors = txtDirector.Text;
                productToSave.Producers = txtProducer.Text;
                productToSave.ReleaseDate = dtpReleaseDate.Value;

                var type = ddlVideoType.SelectedItem.DataBoundItem;
                productToSave.VideoTypeId = (int)((VideoTypeEnum)type);

                productToSave.TotalItem = (int)numTotalItem.Value;
                productToSave.TotalSold = (int)numTotalSold.Value;
                productToSave.SellingPrice = (float)numPrice.Value;
                productToSave.BuyPrice = (float)numBuyPrice.Value;



                _App.VgmsDb.SaveChanges();
                string newFilePath = "";
                if (UploadImage(productToSave.Id.ToString(),out newFilePath))
                {

                    productToSave.ImagePath = newFilePath;
                    _App.VgmsDb.SaveChanges();
                }

                if (frmproductList!=null)
                {
                    frmproductList.LoadList();
                }
               
                MessageBox.Show("Product Saved!!");

            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            SaveProduct();

        }
        bool UploadImage(string newFileName, out string newFilePath)
        {
            newFilePath = "";
            var sourceFilePath = ofdSelectImage.FileName;
            try
            {
                if (File.Exists(sourceFilePath))
                {
                    var fileExtention = Path.GetExtension(sourceFilePath);
                    newFileName = newFileName +  fileExtention;
                    // 'AppDomain.CurrentDomain.BaseDirectory +'-projects exe file location
                    var destinationFolder = AppDomain.CurrentDomain.BaseDirectory + "\\ProductImage\\";
                    Directory.CreateDirectory(destinationFolder);
                    newFilePath = destinationFolder + newFileName;
                   
                    if (newFilePath.Equals(sourceFilePath, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return false;
                    }


                    File.Copy(sourceFilePath, newFilePath, true);
                    newFilePath = "\\ProductImage\\" + newFileName;
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image Upload Failed."+ex.GetBaseException().ToString());
                return false;
            }
           
            return false;
        }
        private void FrmAddEditProduct_Load(object sender, EventArgs e)
        {
            ddlVideoType.DataSource = Enum.GetValues(typeof(VideoTypeEnum));
            
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
           var res= ofdSelectImage.ShowDialog();
            if (res == DialogResult.OK && ofdSelectImage.CheckFileExists)
            {
                var filePath = ofdSelectImage.FileName;
                pbImage.ImageLocation = filePath;                                    
            }
        }

        private void FrmAddEditProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmproductList != null)
            {
                frmproductList.frmProduct = null;
            }
        }
    }
}
