using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQTT
{
    public partial class NewTopic : Form
    {
        public NewTopic()
        {
            InitializeComponent();
            this.cb_qos.SelectedIndex = 0;
        }

        public string TopicPath { get { return tb_path.Text; } }
        public int Qos { get { return int.Parse(cb_qos.Text); } }
        public bool subscribed{ get { return chb_subscribe.Checked; } }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
