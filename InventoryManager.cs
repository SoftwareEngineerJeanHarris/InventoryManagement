using InventoryManagement;

public partial class InventoryManager : Form
{
    private Login loginForm;
    TextBox txtProductID;
    TextBox txtProductName;
    ComboBox cmbProductType;
    TextBox txtProductQuantity;
    DataGridView dgvProducts;

    public InventoryManager(string username)
    {
        loginForm = new Login(); // Store a reference to the login form
        CreateAddProductSection();
        CreateViewProductsSection();

        // Additional form setup, such as setting the form size
        Text = "Inventory Manager";
        ClientSize = new System.Drawing.Size(480, 460);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
    }

    private void CreateAddProductSection()
    {
        Label lblProductID = new Label { Text = "Product ID:", Location = new System.Drawing.Point(10, 10) };
        txtProductID = new TextBox { Location = new System.Drawing.Point(10, 30) };

        Label lblProductName = new Label { Text = "Product Name:", Location = new System.Drawing.Point(10, 60) };
        txtProductName = new TextBox { Location = new System.Drawing.Point(10, 80) };

        Label lblProductType = new Label { Text = "Product Type:", Location = new System.Drawing.Point(10, 110) };
        cmbProductType = new ComboBox { Location = new System.Drawing.Point(10, 130), DropDownStyle = ComboBoxStyle.DropDownList };
        cmbProductType.Items.AddRange(new string[] { "Monitor", "RAM", "Motherboard", "CPU", "Graphics Card", "CPU Cooler" });

        Label lblProductQuantity = new Label { Text = "Quantity:", Location = new System.Drawing.Point(10, 160) };
        txtProductQuantity = new TextBox { Location = new System.Drawing.Point(10, 180) };

        Button btnAddProduct = new Button { Text = "Add Product", Location = new System.Drawing.Point(10, 210) };
        btnAddProduct.Click += BtnAddProduct_Click;

        Controls.AddRange(new Control[] { lblProductID, txtProductID, lblProductName, txtProductName, lblProductType, cmbProductType, lblProductQuantity, txtProductQuantity, btnAddProduct });
    }

    private void CreateViewProductsSection()
    {
        dgvProducts = new DataGridView { Location = new System.Drawing.Point(10, 250), Size = new System.Drawing.Size(460, 200), AllowUserToAddRows = false, ReadOnly = true };
        dgvProducts.Columns.Add("ProductID", "Product ID");
        dgvProducts.Columns.Add("ProductName", "Product Name");
        dgvProducts.Columns.Add("ProductType", "Product Type");
        dgvProducts.Columns.Add("ProductQuantity", "Quantity");

        Controls.Add(dgvProducts);
    }

    private void BtnAddProduct_Click(object sender, EventArgs e)
    {
        // Logic to add a new product goes here
    }

    private void BtnLogout_Click(object sender, EventArgs e)
    {
        // Close the main form
        this.Close();

        // Show the login form
        loginForm.Show();
    }
}