using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModuleRegisterApp
{
    public partial class MessageFrm : Form
    {
        public MessageFrm()
        {
            InitializeComponent();
        }

        private void yes_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void no_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
