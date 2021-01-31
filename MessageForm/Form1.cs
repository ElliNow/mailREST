using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models.Message message = new Models.Message
            {
                Title = textBox2.Text,
                Text = richTextBox1.Text,
                Email = textBox1.Text
            };
            string protocol = (checkBox1.Checked) ? "https://" : "http://";
            var client = new RestClient($"{protocol}{textBox3.Text}:{textBox4.Text}/api/");
            var request = new RestRequest("Send/", Method.POST, DataFormat.Json);
            request.AddJsonBody(message);
            var responce = client.Execute(request);
            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
                MessageBox.Show("Отправлено");
            else MessageBox.Show("Bad");

        }
    }
}
