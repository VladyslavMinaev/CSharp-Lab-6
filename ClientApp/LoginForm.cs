using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientApp.Entities;
using ClientApp.Services;
using Newtonsoft.Json;

namespace ClientApp
{
    public partial class LoginForm : Form
    {
        private Communicator _communicator;
        public LoginForm()
        {
            _communicator = new();
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (emailTb.Text == "" || passwordTb.Text == "")
            {
                return;
            }

            User body = new()
            {
                Email = emailTb.Text,
                Password = passwordTb.Text
            };
            var data = await _communicator.Post<UserResponse>("http://localhost:5000/api/Login", body);

            MainForm mainForm = new(data.User);
            mainForm.FormClosed += MainForm_Closed;

            if (data.Code == 0)
            {
                MessageBox.Show("Ви успішно зареєструвалися");
                mainForm.Show();
                Hide();
                return;
            }

            if (data.Code == 1)
            {
                MessageBox.Show("Ви успішно увійшли в додаток");
                mainForm.Show();
                Hide();
                return;
            }

            if (data.Code == -1)
            {
                MessageBox.Show("Ваш пароль невірний");
            }
        }

        private void MainForm_Closed(object sender, EventArgs e)
        {
            Show();
        }
    }
}
