using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using VideoGallery.WinApp.Data;

namespace VideoGallery.WinApp
{
    public partial class FrmLogin : Telerik.WinControls.UI.RadForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show(this,"Type User Name!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var pass = txtPass.Text;
            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show(this, "Type Password!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var dbContext = new VgmsDbContext();
            var user = dbContext.UserInfo.SingleOrDefault(x => x.UserName == userName);
            if(user!=null)
            {
                if (user.Password== pass)
                {
                    //success login
                    _App.UserFullName = user.FullName;
                    _App.UserName = user.UserName;
                    FrmMain main = new FrmMain();
                    main.Show(this);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(this,"Invalid Password!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this,"Invalid  User Name!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
