﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCartApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CustomerName = NameText.Text;
            string CustomerAddress = AddressText.Text;
            string CustomerPhoneNo=PhoText.Text;
            string CustomerEmail=EmailText.Text;
            string CustomerCard=CardText.Text;
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
