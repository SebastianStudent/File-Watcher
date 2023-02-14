using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Nasłuchiwanie_Plików
{
    public partial class LoginANDPassword : Form
    {
        public LoginANDPassword()
        {
            InitializeComponent();
        }

        private void Security()
        {
            string login = Login_textBox.Text;
            string password = Password_textBox.Text;
            //login = "admin123";
            //password = "zaq1 @WSX";
            
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();      //Class return an array of 16 bytes
            UTF8Encoding utf8 = new UTF8Encoding();                             //To encode a string of Unicode characters and store them in a byte array
            byte[] data = md5.ComputeHash(utf8.GetBytes(login));
            login = Convert.ToBase64String(data);
            data = md5.ComputeHash(utf8.GetBytes(password));
            password = Convert.ToBase64String(data);

            //MessageBox.Show(login + " " + password);                          //To get hash code login and password to access
            StringBuilder strSecurityFilePath = new StringBuilder(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string fileName = Path.GetFileName(strSecurityFilePath.ToString());
            //MessageBox.Show(strExeFilePath + "\n\n" + fileName);              //Path to exe file this program and name of this file
            strSecurityFilePath.Remove(strSecurityFilePath.Length - fileName.Length, fileName.Length);
            //MessageBox.Show(strExeFilePath.ToString());                       //Path to exe file this program without name of this file
            strSecurityFilePath.Append("Security.txt");

            if (!File.Exists(@strSecurityFilePath.ToString()))
            {
                MessageBox.Show("There is no file with login and password!");
            }
            else
            {
                FileStream readSourceStream = new FileStream(@strSecurityFilePath.ToString(), FileMode.Open, FileAccess.Read, FileShare.None);     //Open File stream with only read and share with no one
                StreamReader sr = new StreamReader(readSourceStream);
                bool correct = false;
                while (!sr.EndOfStream)
                {
                    string srLine = sr.ReadLine();
                    /* Login and password
                     * 
                     * Login : admin123
                     * Password : zaq1 @WSX
                     * 
                     */
                    if (srLine.Contains(login + " " + password))
                    {
                        correct = true;
                        break;
                    }
                }
                sr.Close();
                readSourceStream.Close();
                if (correct)
                {
                    this.Hide();
                    watcher watcher = new watcher();
                    watcher.ShowDialog();
                    this.Close();
                }
                else
                {
                    Login_textBox.Text = "";
                    Password_textBox.Text = "";
                    MessageBox.Show("Incorrect Login or Password!");
                }
            }
        }

        private void Login_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Security();
            }
        }

        private void Password_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Security();
            }
        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            Security();
        }
    }
}