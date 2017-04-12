
using System;
using System.Linq;
using System.Windows.Forms;
using VideoGallery.WinApp.Data;


namespace VideoGallery.WinApp.Documents.UserManager
{
    public partial class FrmAddEditUser : Telerik.WinControls.UI.RadForm
    {
        private UserInfo user;
        private FrmUserList frmUserList;

        public enum GenderEnum
        {
            Male = 0,
            Female = 1,
            Other = 2
        }
        public FrmAddEditUser()
        {
            InitializeComponent();
        }

        public FrmAddEditUser(FrmUserList frmUserList)
        {
            InitializeComponent();

            this.frmUserList = frmUserList;
        }

        public void Populate(UserInfo user)
        {
            this.user = user;
            if (user != null)
            {

                txtName.Text = user.FullName;
                txtUserName.Text = user.UserName;
                txtPass.Text = user.Password;
                txtEmail.Text = user.Email;
                txtMobile.Text = user.Mobile.ToString();
                dtpDob.Value = user.Dob;
                ddlGender.SelectedText = ((GenderEnum)user.GenderEnumId).ToString();
            }
        }

        bool IsValidToSaveUser()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Type Name!");
                return false;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Type Email!");
                return false;
            }
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Invalid Email!");
                return false;
            }

            if (txtPass.Text == "")
            {
                MessageBox.Show("Type Password!");
                return false;
            }

            if (txtPass.Text != txtRePass.Text)
            {
                MessageBox.Show("Password not matched!!");
                return false;
            }

            if (txtMobile.Text == "")
            {
                MessageBox.Show("Type Mobile number!");
                return false;
            }

            if (dtpDob.Value >= DateTime.Now)
            {
                MessageBox.Show("Invalid DOB!");
                return false;
            }
            return true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidToSaveUser())
            {
                UserInfo userToSave = null;
                if (user != null)
                {
                    userToSave = _App.VgmsDb.UserInfo.SingleOrDefault(y => y.Id == user.Id);
                }
                if (userToSave == null)
                {
                    userToSave = new UserInfo();
                    _App.VgmsDb.UserInfo.Add(userToSave);
                    
                    user = userToSave;

                }

                userToSave.FullName = txtName.Text;
                userToSave.UserName = txtUserName.Text;
                userToSave.Password = txtPass.Text;
                userToSave.Email = txtEmail.Text;
                userToSave.Mobile = txtMobile.Text;
                userToSave.Dob = dtpDob.Value;

                var gender = ddlGender.SelectedItem.DataBoundItem;
                userToSave.GenderEnumId = (int)((GenderEnum)gender);

                //data save to database
                _App.VgmsDb.SaveChanges();

                if (frmUserList != null)
                {
                    frmUserList.LoadList();
                }

                MessageBox.Show(" User Saved!!.. ");
            }
        }

        private void FrmAddEditUser_Load(object sender, EventArgs e)
        {
            ddlGender.DataSource = Enum.GetValues(typeof(GenderEnum));
        }
    }
}
