using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace _6._1._1
{
    public partial class Form1 : Form
    {
        private const string DbName = "employees.db";
        private readonly string connStr = $"Data Source={DbName};Version=3;";

        public Form1()
        {
            InitializeComponent();
            InitDatabase();
            LoadData();
        }

        private void InitDatabase()
        {
            if (!File.Exists(DbName))
            {
                SQLiteConnection.CreateFile(DbName);
                using var con = new SQLiteConnection(connStr);
                con.Open();
                using var cmd = new SQLiteCommand("CREATE TABLE employees (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, position TEXT)", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void LoadData()
        {
            using var con = new SQLiteConnection(connStr);
            con.Open();
            using var da = new SQLiteDataAdapter("SELECT * FROM employees", con);
            DataTable dt = new();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void AddEmployee(string name, string position)
        {
            using var con = new SQLiteConnection(connStr);
            con.Open();
            using var cmd = new SQLiteCommand("INSERT INTO employees (name, position) VALUES (@n, @p)", con);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@p", position);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void DeleteEmployee()
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            using var con = new SQLiteConnection(connStr);
            con.Open();
            using var cmd = new SQLiteCommand("DELETE FROM employees WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxPosition.Text))
            {
                MessageBox.Show("¬ведите им€ и должность!");
                return;
            }
            AddEmployee(textBoxName.Text, textBoxPosition.Text);
        }

        private void buttonDelete_Click(object sender, EventArgs e) => DeleteEmployee();
    }
}
