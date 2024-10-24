using ShoppingCartApp;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SQLite;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private SQLiteConnection sqliteConnection;
        private Dictionary<string, (decimal price, string category, int stock, int quantity, byte[] image)> cartProducts = new Dictionary<string, (decimal price, string category, int stock, int quantity, byte[] image)>();
        private List<(string name, decimal price, string category, int stock, byte[] image)> RecommendedProducts = new List<(string name, decimal price, string category, int stock, byte[] image)>();
        public Form1()
        {
            InitializeComponent();
            string dbpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "shopping_cart.db");
            sqliteConnection = new SQLiteConnection($"DataSource={dbpath};Version=3;");
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadProductData();
            LoadCartData();
            LoadRecommededProducts();
        }
        private void LoadProductData()
        {
            try
            {
                sqliteConnection.Open();
                string query = "SELECT * FROM PRODUCTS";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, sqliteConnection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                // dataGridView1.DataSource = table;
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in table.Rows)
                {
                    // Create a panel for each product
                    var productPanel = new Panel
                    {
                        Width = 420,
                        Height = 120,
                        Margin = new Padding(10)
                    };

                    byte[] imageBytes = (byte[])row["Image"];
                    MemoryStream ms = new MemoryStream(imageBytes);
                    Image pdImage = Image.FromStream(ms);
                    // PictureBox for the product image
                    var pictureBox = new PictureBox
                    {
                        Image = pdImage,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 130,
                        Height = 110
                    };
                    //Label name for Products
                    var labelName = new Label
                    {
                        Text = row["Name"].ToString(),
                        AutoSize = true,
                        Location = new Point(150, 10),
                        Font = new Font("Candara", 12, FontStyle.Bold)
                    };
                    //Label price for Products
                    var labelPrice = new Label
                    {
                        Text = $"Rs {row["Price"].ToString()} ",
                        AutoSize = true,
                        Location = new Point(150, 40),
                        Font = new Font("Arial", 10)
                    };

                    var labelCategory = new Label
                    {
                        Text = $"Category: {row["Category"].ToString()} ",
                        AutoSize = true,
                        Location = new Point(150, 60),
                        Font = new Font("Arial", 10)
                    };
                    var labelStock = new Label
                    {
                        Text = $"Stock left: {row["Quantity"].ToString()} ",
                        AutoSize = true,
                        Location = new Point(150, 80),
                        Font = new Font("Arial", 10)
                    };

                    var addCartButton = new Button
                    {
                        Text = "Add to Cart",
                        AutoSize = true,
                        Location = new Point(300, 80)
                    };

                    addCartButton.Tag = new Tuple<string, decimal, string, int, byte[]>
                     (
                        row["Name"].ToString(),
                        Convert.ToDecimal(row["Price"]),
                        row["Category"].ToString(),
                        Convert.ToInt32(row["Quantity"]),
                        imageBytes
                     );

                    addCartButton.Click += addToCartButtonClick;

                    productPanel.Controls.Add(pictureBox);
                    productPanel.Controls.Add(labelName);
                    productPanel.Controls.Add(labelPrice);
                    productPanel.Controls.Add(labelCategory);
                    productPanel.Controls.Add(labelStock);

                    productPanel.Controls.Add(addCartButton);


                    // Add the product panel to the FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(productPanel);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                sqliteConnection.Close();
            }
        }

        private void addToCartButtonClick(object sender, EventArgs e)
        {
            Button clicked_button = sender as Button;

            if (clicked_button?.Tag is Tuple<string, decimal, string, int, byte[]> product_details)
            {
                string product_name = product_details.Item1;
                decimal product_price = product_details.Item2;
                string product_category = product_details.Item3;
                int product_quantity = 1;
                int product_stock = product_details.Item4;
                byte[] product_image = product_details.Item5;

                if (cartProducts.ContainsKey(product_name))
                {
                    MessageBox.Show($"{product_name} is already in the cart!");
                }
                else
                {
                    cartProducts[product_name] = (product_price, product_category, product_stock, product_quantity, product_image);

                    addCartProductsToDatabase(product_name, product_price, product_category, product_stock, product_quantity, product_image);
                    RecommendedProducts.Clear();
                    LoadRecommededProducts();


                    MessageBox.Show("Product added to the cart successfully!");
                }
            }
        }

        private void LoadCartData()
        {
            try
            {
                sqliteConnection.Open();
                string query = "SELECT * FROM CART";
                SQLiteDataAdapter cartAdapter = new SQLiteDataAdapter(query, sqliteConnection);
                DataTable cartTable = new DataTable();
                cartAdapter.Fill(cartTable);

                foreach (DataRow row in cartTable.Rows)
                {
                    string pdName = row["productName"].ToString();
                    decimal price = Convert.ToDecimal(row["Price"]);
                    string category = row["Category"].ToString();
                    int stock = Convert.ToInt32(row["Stock"]);
                    int qty = Convert.ToInt32(row["Quantity"]);
                    byte[] img = (byte[])row["Image"];

                    cartProducts[pdName] = (price, category, stock, qty, img);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Loading Cart: {ex.Message}");
            }
            finally
            {
                sqliteConnection.Close();
            }
        }

        private void CartDisplayTab()
        {
            flowLayoutPanel2.Controls.Clear();


            foreach (var item in cartProducts)
            {

                var cartProductPanel = new Panel
                {
                    Width = 420,
                    Height = 120,
                    Padding = new Padding(10)
                };

                byte[] imageBytes = item.Value.image;
                MemoryStream ms = new MemoryStream(imageBytes);
                Image pdImage = Image.FromStream(ms);
                var cartPictureBox = new PictureBox
                {
                    Image = pdImage,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 130,
                    Height = 110
                };
                var cartNameLabel = new Label
                {
                    Text = item.Key,
                    AutoSize = true,
                    Location = new Point(150, 10),
                    Font = new Font("Candara", 12, FontStyle.Bold)
                };
                //Label price for Products
                var cartPriceLabel = new Label
                {
                    Text = $"Rs {item.Value.price} ",
                    AutoSize = true,
                    Location = new Point(150, 40),
                    Font = new Font("Arial", 10)
                };

                var cartCategoryLabel = new Label
                {
                    Text = $"Category: {item.Value.category} ",
                    AutoSize = true,
                    Location = new Point(150, 60),
                    Font = new Font("Arial", 10)
                };

                var cartQuantityLabel = new Label
                {
                    Text = "Quantity",
                    AutoSize = true,
                    Location = new Point(300, 70),
                    Font = new Font("Arial", 10)
                };

                var quantityCounter = new NumericUpDown
                {
                    AutoSize = false,
                    Size = new Size(32, 23),
                    Minimum = 1,
                    Maximum = item.Value.stock - 20,
                    ReadOnly = true,
                    Cursor = null,
                    Value = item.Value.quantity,
                    Location = new Point(370, 70)
                };
                //updating value in dictionary to persist changes
                quantityCounter.ValueChanged += (sender, e) =>
                {
                    cartProducts[item.Key] = (item.Value.price, item.Value.category, item.Value.stock, (int)quantityCounter.Value, item.Value.image);
                    UpdateCartQuantity(item.Key, (int)quantityCounter.Value);
                    CalculateSubTotal();
                };

                var removeProductButton = new Button
                {
                    Text = "Remove",
                    Location = new Point(315, 40),

                };

                cartProductPanel.Controls.Add(cartPictureBox);
                cartProductPanel.Controls.Add(cartNameLabel);
                cartProductPanel.Controls.Add(cartPriceLabel);
                cartProductPanel.Controls.Add(cartCategoryLabel);
                cartProductPanel.Controls.Add(cartQuantityLabel);
                cartProductPanel.Controls.Add(quantityCounter);
                cartProductPanel.Controls.Add(removeProductButton);

                flowLayoutPanel2.Controls.Add(cartProductPanel);

            }
            CalculateSubTotal();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                CartDisplayTab();
            }

        }

        private void addCartProductsToDatabase(string name, decimal price, string category, int stock, int quantity, byte[] image)
        {
            try
            {
                sqliteConnection.Open();
                string query = "INSERT INTO CART VALUES(@productName, @Price, @Category, @Stock, @Quantity, @Image)";
                using (SQLiteCommand command = new SQLiteCommand(query, sqliteConnection))
                {
                    command.Parameters.AddWithValue("@productName", name);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@Stock", stock);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Image", image);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Saving Cart Data: {ex.Message}");
            }
            finally
            {
                sqliteConnection.Close();
            }

        }

        private void UpdateCartQuantity(string productName, int quantity)
        {
            try
            {
                sqliteConnection.Open();

                string query = "UPDATE CART SET Quantity = @NewQuantity WHERE productName= @ProductName";
                using (SQLiteCommand command = new SQLiteCommand(query, sqliteConnection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@NewQuantity", quantity);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
            finally
            {
                sqliteConnection.Close();
            }
        }

        private List<string> GetRecommededCategories()
        {
            var LastTwoCartCategories = cartProducts.Reverse().Take(2).Select(p => p.Value.category).ToList();

            return LastTwoCartCategories;
        }

        private void SetRecommededProducts(List<string> recommendedCategories)
        {
            try
            {
                sqliteConnection.Open();

                foreach (string category in recommendedCategories)
                {
                    var cartProductNames = string.Join(",", cartProducts.Keys.Select(n => $"'{n}'"));
                    string query = $"SELECT * FROM PRODUCTS WHERE Category= @Category AND Name NOT IN ({cartProductNames}) LIMIT 2";

                    using (SQLiteCommand command = new SQLiteCommand(query, sqliteConnection))
                    {
                        command.Parameters.AddWithValue("@Category", category);

                        //adjusting cart products names according to sql query syntax

                        //command.Parameters.AddWithValue("@CartProductsNames", cartProductNames);

                        using (SQLiteDataReader productReader = command.ExecuteReader())
                        {
                            while (productReader.Read())
                            {
                                string name = productReader["Name"].ToString();
                                decimal price = Convert.ToDecimal(productReader["Price"]);
                                string pd_category = productReader["Category"].ToString();
                                int stock = Convert.ToInt32(productReader["Quantity"]);
                                byte[] img = (byte[])productReader["image"];

                                RecommendedProducts.Add((name, price, pd_category, stock, img));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Showing Recommeded Products : {ex.Message}");
            }
            finally
            {
                sqliteConnection.Close();
            }

        }

        private void LoadRecommededProducts()
        {
            List<string> recommededCategories = GetRecommededCategories();

            SetRecommededProducts(recommededCategories);

            flowLayoutPanelRecommendations.Controls.Clear();

            foreach (var pd in RecommendedProducts)
            {
                var productPanel = new Panel
                {
                    Width = 400,
                    Height = 88,
                    Margin = new Padding(10)
                };

                byte[] imageBytes = pd.image;
                MemoryStream ms = new MemoryStream(imageBytes);
                Image pdImage = Image.FromStream(ms);
                // PictureBox for the product image
                var pictureBox = new PictureBox
                {
                    Image = pdImage,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 130,
                    Height = 90
                };
                //Label name for Products
                var recommendedName = new Label
                {
                    Text = pd.name.ToString(),
                    AutoSize = true,
                    Location = new Point(150, 10),
                    Font = new Font("Candara", 12, FontStyle.Bold)
                };
                //Label price for Products
                var recommendedPrice = new Label
                {
                    Text = $"Rs {pd.price.ToString()} ",
                    AutoSize = true,
                    Location = new Point(150, 30),
                    Font = new Font("Arial", 10)
                };

                var recommendedCategory = new Label
                {
                    Text = $"Category: {pd.category.ToString()} ",
                    AutoSize = true,
                    Location = new Point(150, 50),
                    Font = new Font("Arial", 10)
                };
                var recommendedStock = new Label
                {
                    Text = $"Stock left: {pd.stock.ToString()} ",
                    AutoSize = true,
                    Location = new Point(150, 70),
                    Font = new Font("Arial", 10)
                };

                var addCartButton = new Button
                {
                    Text = "Add to Cart",
                    AutoSize = true,
                    Location = new Point(300, 60)
                };

                addCartButton.Tag = new Tuple<string, decimal, string, int, byte[]>
                 (
                    pd.name.ToString(),
                    Convert.ToDecimal(pd.price),
                    pd.category.ToString(),
                    Convert.ToInt32(pd.stock),
                    imageBytes
                 );

                addCartButton.Click += addToCartButtonClick;

                productPanel.Controls.Add(pictureBox);
                productPanel.Controls.Add(recommendedName);
                productPanel.Controls.Add(recommendedPrice);
                productPanel.Controls.Add(recommendedCategory);
                productPanel.Controls.Add(recommendedStock);

                productPanel.Controls.Add(addCartButton);


                // Add the product panel to the FlowLayoutPanel
                flowLayoutPanelRecommendations.Controls.Add(productPanel);
            }


        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //Amna Code starts here.
        private void label12_Click(object sender, EventArgs e)
        {
   
        }
        private void label13_Click(object sender, EventArgs e)
        {
            
        }
        private void UpdateSubTotalLabel(decimal total)
        {
            label13.Text = $"Rs {total}";
            label13.Font = new Font("Arial", 12);
            label13.AutoSize = true;
        }
        private decimal CalculateSubTotal()
        {
            decimal subTotal = 0;
            foreach(var item in cartProducts)
            {
                subTotal += item.Value.price * item.Value.quantity;
            }

            UpdateSubTotalLabel(subTotal);
            return subTotal;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            using(Form2 checkoutForm=new Form2())
            {
                if(checkoutForm.ShowDialog() == DialogResult.OK)
                {
                    Invoice();
                }
            }
        }
        private void Invoice()
        {
            decimal subTotal = CalculateSubTotal();
            decimal discount_rate = 0.05m;
            decimal tax_rate = 0.02m;
            decimal discount = 0, discount_amount = 0, tax = 0, total_amount = 0;
            if (subTotal >= 5000)
            {
                discount = subTotal * discount_rate;
                discount_amount = subTotal - discount;
            }
            else
            {
                discount = subTotal * 0;
                discount_amount = subTotal - discount;
            }
            tax = discount_amount * tax_rate;
            total_amount = tax + discount_amount;

            int int_sub = Convert.ToInt32(subTotal);
            int int_discount = Convert.ToInt32(discount);
            int int_tax = Convert.ToInt32(tax);
            int int_total = Convert.ToInt32(total_amount);

            //Format for invoice string.
            string invoice = $@"
                       INVOICE 



                Subtotal: Rs {int_sub}

                Discount: Rs {int_discount}

                Tax     : Rs {int_tax}


                Total Amount: Rs {int_total}";

            MessageBox.Show(invoice, "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
       