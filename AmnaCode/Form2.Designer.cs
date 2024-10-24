namespace ShoppingCartApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NameText = new TextBox();
            AddressText = new TextBox();
            PhoText = new TextBox();
            EmailText = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            CardText = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // NameText
            // 
            NameText.Location = new Point(177, 43);
            NameText.Name = "NameText";
            NameText.Size = new Size(231, 27);
            NameText.TabIndex = 0;
            NameText.Text = "\r\n";
            // 
            // AddressText
            // 
            AddressText.Location = new Point(177, 85);
            AddressText.Name = "AddressText";
            AddressText.Size = new Size(231, 27);
            AddressText.TabIndex = 1;
            // 
            // PhoText
            // 
            PhoText.Location = new Point(177, 131);
            PhoText.Name = "PhoText";
            PhoText.Size = new Size(231, 27);
            PhoText.TabIndex = 2;
            // 
            // EmailText
            // 
            EmailText.Location = new Point(177, 178);
            EmailText.Name = "EmailText";
            EmailText.Size = new Size(231, 27);
            EmailText.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 46);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 4;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 92);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 5;
            label2.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 134);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 6;
            label3.Text = "Phone Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 181);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 7;
            label4.Text = "E-mail";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 229);
            label5.Name = "label5";
            label5.Size = new Size(142, 20);
            label5.TabIndex = 8;
            label5.Text = "Credit Card Number";
            // 
            // CardText
            // 
            CardText.Location = new Point(177, 222);
            CardText.Name = "CardText";
            CardText.Size = new Size(231, 27);
            CardText.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(314, 317);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 10;
            button1.Text = "Place Order";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(496, 682);
            Controls.Add(button1);
            Controls.Add(CardText);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(EmailText);
            Controls.Add(PhoText);
            Controls.Add(AddressText);
            Controls.Add(NameText);
            Name = "Form2";
            Text = "CheckoutForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameText;
        private TextBox AddressText;
        private TextBox PhoText;
        private TextBox EmailText;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox CardText;
        private Button button1;
    }
}