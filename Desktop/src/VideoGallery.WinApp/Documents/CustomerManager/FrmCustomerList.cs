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
    public partial class FrmCustomerList : Telerik.WinControls.UI.RadForm
    {

        public FrmCustomerList()
        {
            InitializeComponent();



        }
        public void LoadList()
        {
            try
            {
                gvCustomerList.DataSource = _App.VgmsDb.Customer.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.GetBaseException().ToString(), "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

           
        }
        void Search()
        {
            string searText = txtSearch.Text;
            //List<Customer> customerList= vgmsDbContext.Customer.ToList();
            //foreach (var customer in customerList)
            //{
            //    if(customer.Name.Contains(searText))
            //    {

            //    }
            //}

            gvCustomerList.DataSource = _App.VgmsDb.Customer.Where(customer => customer.Id.ToString() == searText || customer.Name.Contains(searText) || customer.Email.Contains(searText)).ToList();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }


        private void gvCustomerList_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            Customer customer = gvCustomerList.SelectedRows[0].DataBoundItem as Customer;
        }
        FrmAddEditCustomer frmCustomer = null;
        private void gvCustomerList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (gvCustomerList.SelectedRows != null && gvCustomerList.SelectedRows.Count >= 1)
            {
                var customer = gvCustomerList.SelectedRows[0].DataBoundItem as Customer;

                if (frmCustomer == null)
                {
                    frmCustomer = new FrmAddEditCustomer(this);
                    frmCustomer.Show(this);
                }
                frmCustomer.Populate(customer);

            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvCustomerList.SelectedRows != null && gvCustomerList.SelectedRows.Count >= 1)
                {
                    var customer = gvCustomerList.SelectedRows[0].DataBoundItem as Customer;
                    if (customer != null)
                    {
                        DialogResult res = MessageBox.Show(this, "Are you sure, you want to delete Customer?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (res == DialogResult.Yes)
                        {
                            var objectToSave = _App.VgmsDb.Customer.SingleOrDefault(y => y.Id == customer.Id);
                            if (objectToSave != null)
                            {
                                _App.VgmsDb.Customer.Remove(objectToSave);
                                _App.VgmsDb.SaveChanges();
                            }
                            LoadList();
                            MessageBox.Show(this, "Customer Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.GetBaseException().ToString(), "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
    }
}
