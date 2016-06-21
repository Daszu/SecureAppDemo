using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Secure_Library;

namespace Secure_Application_Demo
{
    public partial class Form1 : Form
    {
        private string blokada = "nie posiadasz uprawnień do wykonania tej akcji!";

        public Form1()
        {
            InitializeComponent();


            if (Context.myCtx == null)
            {
                button6.Enabled = false;
            }
            else
            {
                button1.Enabled = false;

                button7.Enabled = Context.myCtx.HasPermission(Roles.CREATE_USER);
                button8.Enabled = Context.myCtx.HasPermission(Roles.CREATE_GROUP);
                button9.Enabled = Context.myCtx.HasPermission(Roles.DELETE_USER);
                button11.Enabled = Context.myCtx.HasPermission(Roles.USER_PERMISSION);
                button12.Enabled = Context.myCtx.HasPermission(Roles.GROUP_PERMISSION);
                button13.Enabled = Context.myCtx.HasPermission(Roles.USER_GROUP);
                button10.Enabled = Context.myCtx.HasPermission(Roles.DELETE_GROUP);
                button3.Enabled = Context.myCtx.HasPermission(Roles.CREATE_POST);
                button5.Enabled = Context.myCtx.HasPermission(Roles.DELETE_POST);
                button4.Enabled = Context.myCtx.HasPermission(Roles.MODIFY_POST);

                if (Context.myCtx.UName != "root")
                {
                    button2.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new Form2();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Context.myCtx = null;
            this.Hide();
            Form1 newForm = new Form1();
            newForm.Closed += (s, args) => this.Close();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.allAccess();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.createPost();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.modifyPost();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.deletePost();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.createUser();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.deleteUser();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.userPermission();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.userGroup();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.createGroup();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.deleteGroup();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                BizzLay.groupPermission();
            }
            catch (Exception exc)
            {
                MessageBox.Show(blokada);
            }
        }
    }
}
