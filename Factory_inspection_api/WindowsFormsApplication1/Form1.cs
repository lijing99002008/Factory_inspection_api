using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Factory_inspection_api;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory_inspection_api.Factory_inspection_api_class Factory_inspection_api_dll = new Factory_inspection_api_class();

            textBox1.Text = Factory_inspection_api_dll.erification("0", "1");

            
        }
    }
}
