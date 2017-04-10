using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoGallery.WinApp.Data;

namespace VideoGallery.WinApp.Documents.CustomerManager
{
    public partial class FrmAddEditCustomer : Telerik.WinControls.UI.RadForm 
    {
        private Customer customer;
        private FrmCustomerList frmCustomerList;

        public enum GenderEnum
        {
            Male = 0,
            Female = 1,
            Other = 2
        }
        public FrmAddEditCustomer()
        {
            InitializeComponent();

        }
        public FrmAddEditCustomer(FrmCustomerList frmCustomerList)
        {
            InitializeComponent();
            this.frmCustomerList = frmCustomerList;
        }


        public void Populate(Customer customer)
        {
            this.customer = customer;
            if (customer != null)
            {

                txtName.Text = customer.Name;
                txtAddress.Text = customer.Address;
                txtMobile.Text = customer.MobileNumber.ToString();
                txtEmail.Text = customer.Email;
                numDeposite.Value = (decimal)customer.Diposite;
                ddlGender.SelectedText = ((GenderEnum)customer.GenderEnumId).ToString();
            }
        }

        bool IsValidToSaveCustomer()
        {

            if (txtName.Text == "")
            {
                MessageBox.Show("Type Name!");
                return false;
            }

            if (txtAddress.Text == "")
            {
                MessageBox.Show("Type address!");
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Type email!");
                return false;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Invalid Email!");
                return false;
            }

            if (txtMobile.Text == "")
            {
                MessageBox.Show("Type Mobile number!");
                return false;
            }
            int x = 0;
            if (!Int32.TryParse(txtMobile.Text, out x))
            {
                MessageBox.Show("Invalid Mobile number!");
                return false;
            }

            if (numDeposite.Value <= 200)
            {
                MessageBox.Show("Deposite ammount should be minimum 200 BDT!");
                return false;
            }

            return true;
        }
        void SaveCustomer()
        {

            try
            {


                if (IsValidToSaveCustomer())
                {
                    Customer objectToSave = null;
                    if (customer != null)
                    {
                        objectToSave = _App.VgmsDb.Customer.SingleOrDefault(y => y.Id == customer.Id);
                    }
                    if (objectToSave == null)
                    {
                        objectToSave = new Customer();
                        _App.VgmsDb.Customer.Add(objectToSave);
                        objectToSave.CreateById = 1;
                        objectToSave.CreateDate = DateTime.Now;
                        customer = objectToSave;

                    }
                    objectToSave.Name = txtName.Text;
                    objectToSave.Address = txtAddress.Text;

                    int x = 0;
                    Int32.TryParse(txtMobile.Text, out x);
                    objectToSave.MobileNumber = x;

                    objectToSave.Email = txtEmail.Text;
                    objectToSave.Diposite = (double)numDeposite.Value;


                    var gender = ddlGender.SelectedItem.DataBoundItem ;
                    objectToSave.GenderEnumId = (int)((GenderEnum)gender);



                    objectToSave.UpdateById = 1;
                    objectToSave.UpdateDate = DateTime.Now;
                    


                    //data save to database


                    _App.VgmsDb.SaveChanges();

                    if (frmCustomerList != null)
                    {
                        frmCustomerList.LoadList();
                    }


                    MessageBox.Show("Customer Saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.GetBaseException().ToString(), "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



      

        private void FrmAddEditCustomer_Load(object sender, EventArgs e)
        {

            ddlGender.DataSource = Enum.GetValues(typeof(GenderEnum));

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCustomer();
        }
    }
}
