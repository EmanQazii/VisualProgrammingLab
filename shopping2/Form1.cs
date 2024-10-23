using Microsoft.SqlServer.Server;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        private SQLiteConnection sqliteConnection;
        private Dictionary<string, CartItem> cartProducts = new Dictionary<string, CartItem>();
        private List<Product> RecommendedProducts = new List<Product>();
        public DateTime cartLastUpdated=DateTime.MinValue;
        TimeSpan expirationDuration = TimeSpan.FromHours(24);
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
                    var product = new Product(
                    row["Name"].ToString(),
                    Convert.ToDecimal(row["Price"]),
                    row["Category"].ToString(),
                    Convert.ToInt32(row["Quantity"]),
                    (byte[])row["Image"]
);
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
                    addCartButton.Tag = product;
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

            if (clicked_button?.Tag is Product product)
            {
                //string product_name = product_details.Item1;
                //decimal product_price = product_details.Item2;
                //string product_category = product_details.Item3;
                //int product_quantity = 1;
                //int product_stock = product_details.Item4;
                //byte[] product_image = product_details.Item5;

                if (cartProducts.ContainsKey(product.Name))
                {
                    MessageBox.Show($"{product.Name} is already in the cart!");
                }
                else
                {

                    cartProducts[product.Name] = new CartItem(product, 1);
                    addCartProductsToDatabase(product.Name, product.Price, product.Category, product.Stock, 1, product.Image);
                    RecommendedProducts.Clear();
                    LoadRecommededProducts();
                    cartLastUpdated=DateTime.Now;

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
                    var product = new Product(
                        row["productName"].ToString(),
                        Convert.ToDecimal(row["Price"]),
                        row["Category"].ToString(),
                        Convert.ToInt32(row["Stock"]),
                        (byte[])row["Image"]
                    );

                    cartProducts[product.Name] = new CartItem(product, Convert.ToInt32(row["Quantity"]));
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


            foreach (var item in cartProducts.Values)
            {
                if (item.Product.Stock == null || item.Product.Category == null || item.Quantity == null || item.Product.Image == null || item.Product.Price == null || item.Product.Name == null)
                {
                    continue;
                }
                var cartProductPanel = new Panel
                {
                    Width = 420,
                    Height = 120,
                    Padding = new Padding(10)
                };

                byte[] imageBytes = item.Product.Image;
                if (imageBytes == null)
                {
                    continue;
                }
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
                    Text = item.Product.Name,
                    AutoSize = true,
                    Location = new Point(150, 10),
                    Font = new Font("Candara", 12, FontStyle.Bold)
                };
                //Label price for Products
                var cartPriceLabel = new Label
                {
                    Text = $"$ {item.Product.Price} ",
                    AutoSize = true,
                    Location = new Point(150, 40),
                    Font = new Font("Arial", 10)
                };

                var cartCategoryLabel = new Label
                {
                    Text = $"Category: {item.Product.Category} ",
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
                    Maximum = item.Product.Stock - 20,
                    ReadOnly = true,
                    Cursor = null,
                    Value = item.Quantity,
                    Location = new Point(370, 70)
                };
                //updating value in dictionary to persist changes
                quantityCounter.ValueChanged += (sender, e) =>
                {
                    //cartProducts[item.Key] = (item.Value.price, item.Value.category, item.Value.stock, (int)quantityCounter.Value, item.Value.image);
                    item.Quantity = (int)quantityCounter.Value;
                    UpdateCartQuantity(item.Product.Name, item.Quantity);
                };

                var removeProductButton = new Button
                {
                    Text = "Remove",
                    Location = new Point(315, 40),

                };
                removeProductButton.Click += (sender, e) => RemoveCartProduct(item.Product.Name);

                cartProductPanel.Controls.Add(cartPictureBox);
                cartProductPanel.Controls.Add(cartNameLabel);
                cartProductPanel.Controls.Add(cartPriceLabel);
                cartProductPanel.Controls.Add(cartCategoryLabel);
                cartProductPanel.Controls.Add(cartQuantityLabel);
                cartProductPanel.Controls.Add(quantityCounter);
                cartProductPanel.Controls.Add(removeProductButton);

                flowLayoutPanel2.Controls.Add(cartProductPanel);



            }
        }
        private void RemoveCartProduct(string productName)
        {
            try
            {
                sqliteConnection.Open();
                string query = "DELETE FROM CART WHERE productName = @productName";
                using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConnection))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Product removed from the cart successfully.");
                if (cartProducts.ContainsKey(productName))
                {
                    cartProducts.Remove(productName);
                }
                CartDisplayTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing product: " + ex.Message);
            }
            finally
            {
                sqliteConnection.Close();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                //CheckCartExpiration();
                LoadCartData();
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
                    MessageBox.Show("parameters added");

                    command.ExecuteNonQuery();
                    MessageBox.Show("query executed");
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
            var LastTwoCartCategories = cartProducts.Reverse().Take(2).Select(p => p.Value.Product.Category).ToList();

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
                                var product = new Product(
                                productReader["Name"].ToString(),
                                Convert.ToDecimal(productReader["Price"]),
                                productReader["Category"].ToString(),
                                Convert.ToInt32(productReader["Quantity"]),
                                (byte[])productReader["Image"]
                            );

                                RecommendedProducts.Add(product);
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

                byte[] imageBytes = pd.Image;
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
                    Text = pd.Name.ToString(),
                    AutoSize = true,
                    Location = new Point(150, 10),
                    Font = new Font("Candara", 12, FontStyle.Bold)
                };
                //Label price for Products
                var recommendedPrice = new Label
                {
                    Text = $"Rs {pd.Price.ToString()} ",
                    AutoSize = true,
                    Location = new Point(150, 30),
                    Font = new Font("Arial", 10)
                };

                var recommendedCategory = new Label
                {
                    Text = $"Category: {pd.Category.ToString()} ",
                    AutoSize = true,
                    Location = new Point(150, 50),
                    Font = new Font("Arial", 10)
                };
                var recommendedStock = new Label
                {
                    Text = $"Stock left: {pd.Stock.ToString()} ",
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

                addCartButton.Tag = pd;

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
        public bool isCartExpired()
        {
            MessageBox.Show($"lastup  {cartLastUpdated}");
            TimeSpan timeLeft = DateTime.Now - cartLastUpdated;
            MessageBox.Show($"time : {timeLeft}");
            return timeLeft > expirationDuration;

        }

        public void CheckCartExpiration()
        {
            if (isCartExpired())
            {
                cartProducts.Clear();
                MessageBox.Show("Your cart has expired and has been cleared.");
                cartLastUpdated = DateTime.Now;
            }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cart_expiration_Click(object sender, EventArgs e)
        {
            TimeSpan timeleft = expirationDuration - (DateTime.Now - cartLastUpdated);
            string time_left_formatted = string.Format("{0:D2}:{1:D2}:{2:D2}",
            timeleft.Hours,
            timeleft.Minutes,
            timeleft.Seconds);
            MessageBox.Show($"Cart Last Updated : {cartLastUpdated} \nTime left for cart expiration : {time_left_formatted}");

        }
    }
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public byte[] Image { get; set; }


        public Product(string name, decimal price, string category, int stock, byte[] image)
        {
            Name = name;
            Price = price;
            Category = category;
            Stock = stock;
            Image = image;

        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            
        }


        
       
    }
}
       