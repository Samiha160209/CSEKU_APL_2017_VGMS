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

namespace VideoGallery.WinApp.Documents.UserManager
{
    public partial class FrmUserList : Telerik.WinControls.UI.RadForm 
    {
       
        public FrmUserList()
        {
            InitializeComponent();
            
        }

        public void Search()
        {
            string text = txtSearch.Text;
            gvUserList.DataSource = _App.VgmsDb.UserInfo.Where(usr => usr.FullName.Contains(text) || 
            usr.UserName.Contains(text) || usr.Email.Contains(text)).ToList();
        }

        public void LoadList()
        {
          try
            {
                gvUserList.DataSource = _App.VgmsDb.UserInfo.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.GetBaseException().ToString(), "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

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

        private void FrmUserList_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void gvUserList_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            UserInfo user = gvUserList.SelectedRows[0].DataBoundItem as UserInfo;
        }

        FrmAddEditUser frmUser = null;
        private void gvUserList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (gvUserList.SelectedRows != null && gvUserList.SelectedRows.Count >= 1)
            {
                var user = gvUserList.SelectedRows[0].DataBoundItem as UserInfo;

                if (frmUser == null)
                {
                    frmUser = new FrmAddEditUser(this);

                    frmUser.Show(this);
                }
                frmUser.Populate(user);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserList.SelectedRows != null && gvUserList.SelectedRows.Count >= 1)
                {
                    var user = gvUserList.SelectedRows[0].DataBoundItem as UserInfo;
                    if (user != null)
                    {
                        DialogResult res = MessageBox.Show(this, "Are you sure, you want to delete User?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (res == DialogResult.Yes)
                        {
                            var userToSave = _App.VgmsDb.UserInfo.SingleOrDefault(y => y.Id == user.Id);
                            if (userToSave != null)
                            {
                                _App.VgmsDb.UserInfo.Remove(userToSave);
                                _App.VgmsDb.SaveChanges();
                            }
                            LoadList();
                            MessageBox.Show(this, "User Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
