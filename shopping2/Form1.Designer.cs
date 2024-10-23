namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            flowLayoutPanelRecommendations = new FlowLayoutPanel();
            pictureBox3 = new PictureBox();
            label9 = new Label();
            button3 = new Button();
            label10 = new Label();
            label11 = new Label();
            label8 = new Label();
            tabPage2 = new TabPage();
            flowLayoutPanel2 = new FlowLayoutPanel();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            numericUpDown1 = new NumericUpDown();
            remove_button = new Button();
            cart_expiration = new Button();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            flowLayoutPanelRecommendations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            tabPage2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.SeaShell;
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Location = new Point(6, 6);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(471, 458);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 110);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Candara", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(139, 0);
            label1.Name = "label1";
            label1.Size = new Size(303, 50);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(3, 119);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "add_to_cart_button";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 116);
            label2.Name = "label2";
            label2.Size = new Size(33, 16);
            label2.TabIndex = 2;
            label2.Text = "price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(123, 116);
            label3.Name = "label3";
            label3.Size = new Size(38, 16);
            label3.TabIndex = 3;
            label3.Text = "label3";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(5, 3);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(491, 656);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 2;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.MistyRose;
            tabPage1.Controls.Add(flowLayoutPanelRecommendations);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(flowLayoutPanel1);
            tabPage1.Location = new Point(4, 25);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(483, 627);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Home";
            tabPage1.Click += tabPage1_Click;
            // 
            // flowLayoutPanelRecommendations
            // 
            flowLayoutPanelRecommendations.AutoScroll = true;
            flowLayoutPanelRecommendations.BackColor = Color.SeaShell;
            flowLayoutPanelRecommendations.Controls.Add(pictureBox3);
            flowLayoutPanelRecommendations.Controls.Add(label9);
            flowLayoutPanelRecommendations.Controls.Add(button3);
            flowLayoutPanelRecommendations.Controls.Add(label10);
            flowLayoutPanelRecommendations.Controls.Add(label11);
            flowLayoutPanelRecommendations.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelRecommendations.Location = new Point(10, 485);
            flowLayoutPanelRecommendations.Name = "flowLayoutPanelRecommendations";
            flowLayoutPanelRecommendations.Size = new Size(467, 125);
            flowLayoutPanelRecommendations.TabIndex = 4;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(3, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(126, 93);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // label9
            // 
            label9.Font = new Font("Candara", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(135, 0);
            label9.Name = "label9";
            label9.Size = new Size(303, 35);
            label9.TabIndex = 2;
            label9.Text = "label9";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.Location = new Point(135, 38);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "add_to_cart_button";
            button3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(135, 64);
            label10.Name = "label10";
            label10.Size = new Size(33, 16);
            label10.TabIndex = 6;
            label10.Text = "price";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(135, 80);
            label11.Name = "label11";
            label11.Size = new Size(44, 16);
            label11.TabIndex = 7;
            label11.Text = "label11";
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(9, 465);
            label8.Name = "label8";
            label8.Size = new Size(282, 17);
            label8.TabIndex = 3;
            label8.Text = "Recommended Products:";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.MistyRose;
            tabPage2.Controls.Add(cart_expiration);
            tabPage2.Controls.Add(flowLayoutPanel2);
            tabPage2.Location = new Point(4, 25);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(483, 627);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Cart";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.BackColor = Color.Snow;
            flowLayoutPanel2.Controls.Add(pictureBox2);
            flowLayoutPanel2.Controls.Add(label4);
            flowLayoutPanel2.Controls.Add(label5);
            flowLayoutPanel2.Controls.Add(label6);
            flowLayoutPanel2.Controls.Add(label7);
            flowLayoutPanel2.Controls.Add(numericUpDown1);
            flowLayoutPanel2.Controls.Add(remove_button);
            flowLayoutPanel2.Location = new Point(16, 16);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(452, 443);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(130, 110);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.Font = new Font("Candara", 14.25F, FontStyle.Bold);
            label4.Location = new Point(139, 0);
            label4.Name = "label4";
            label4.Size = new Size(300, 47);
            label4.TabIndex = 1;
            label4.Text = "label4";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImageAlign = ContentAlignment.BottomRight;
            label5.Location = new Point(3, 116);
            label5.Name = "label5";
            label5.Size = new Size(33, 16);
            label5.TabIndex = 3;
            label5.Text = "price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 116);
            label6.Name = "label6";
            label6.Size = new Size(53, 16);
            label6.TabIndex = 4;
            label6.Text = "category";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(101, 116);
            label7.Name = "label7";
            label7.Size = new Size(51, 16);
            label7.TabIndex = 6;
            label7.Text = "quantity";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Cursor = Cursors.No;
            numericUpDown1.Location = new Point(158, 119);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.ReadOnly = true;
            numericUpDown1.Size = new Size(32, 23);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // remove_button
            // 
            remove_button.Location = new Point(196, 119);
            remove_button.Name = "remove_button";
            remove_button.Size = new Size(75, 23);
            remove_button.TabIndex = 7;
            remove_button.Text = "remove";
            remove_button.UseVisualStyleBackColor = true;
            // 
            // cart_expiration
            // 
            cart_expiration.Location = new Point(16, 474);
            cart_expiration.Name = "cart_expiration";
            cart_expiration.Size = new Size(144, 23);
            cart_expiration.TabIndex = 1;
            cart_expiration.Text = "Check Cart Expiration";
            cart_expiration.UseVisualStyleBackColor = true;
            cart_expiration.Click += cart_expiration_Click;
            // 
            // Form1
            // 
            AccessibleName = "";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.LightCoral;
            ClientSize = new Size(508, 674);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            flowLayoutPanelRecommendations.ResumeLayout(false);
            flowLayoutPanelRecommendations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private FlowLayoutPanel flowLayoutPanel2;
        private PictureBox pictureBox2;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown numericUpDown1;
        private Label label7;
        private Button remove_button;
        private Label label8;
        private FlowLayoutPanel flowLayoutPanelRecommendations;
        private PictureBox pictureBox3;
        private Label label9;
        private Button button3;
        private Label label10;
        private Label label11;
        private Button cart_expiration;
    }
}
