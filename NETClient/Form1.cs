using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NETClient
{
    public partial class Form1 : Form
    {
        HubConnection con;
        private IHubProxy chatHub;

        public Form1()
        {
            con = new HubConnection("http://localhost:52257/signalr/hubs");
            chatHub = con.CreateHubProxy("chatHub");
            con.Start();
            InitializeComponent();
            chatHub.On<string,string>("onMessage",(name,message) => listBox.Invoke(new Action(() => listBox.Items.Add(name+" : "+message))));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string message = txt_message.Text;
            chatHub.Invoke("NewMessage",name,message);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string group_name = txt_group.Text;

            chatHub.Invoke("JoinGroup",name,group_name);
        }

        private void btn_send_group_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string group_name = txt_group.Text;
            string message = txt_message.Text;

            chatHub.Invoke("SendToGroup",name,group_name,message);
        }
    }
}
