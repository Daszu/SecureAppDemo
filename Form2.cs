using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] encodedPassword = new UTF8Encoding().GetBytes(textBox2.Text);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            bool status;

            SecureLib initSecure = new SecureLib();

            try
            {
                if (status = initSecure.login(textBox1.Text, encoded, out Context.myCtx))
                {
                    Thread.CurrentPrincipal = Secure_Library.SecureLib.gp;
                    this.Hide();
                    var mainForm = new Form1();
                    mainForm.Closed += (s, args) => this.Close();
                    mainForm.Show();
                }
                else
                    MessageBox.Show("Błędne dane logowania!");

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
