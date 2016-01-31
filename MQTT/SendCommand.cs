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
    public partial class SendCommand : Form
    {
        public SendCommand()
        {
            InitializeComponent();
        }

        public int CommandId { get { return int.Parse(textBox1.Text); } }
        public int V1 { get { return int.Parse(textBox2.Text); } }
        public int V2{ get { return int.Parse(textBox3.Text); } }

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
