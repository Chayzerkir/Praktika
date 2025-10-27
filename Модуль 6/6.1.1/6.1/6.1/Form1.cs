using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _6._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadTransactions();
            UpdateFinancialSummary();
        }

        private void LoadTransactions()
        {
            var transactions = DatabaseHelper.GetAllTransactions();

            dataGridView.DataSource = transactions.Select(t => new
            {
                t.Id,
                t.Description,
                Сумма = t.Type == "Income" ? $"+{t.Amount} руб." : $"-{t.Amount} руб.",
                Тип = t.Type == "Income" ? "Доход" : "Расход",
                t.Category,
                Дата = t.Date.ToString("dd.MM.yyyy")
            }).ToList();

            // Настройка внешнего вида
            dataGridView.Columns["Id"].Visible = false;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Тип"].Value?.ToString() == "Доход")
                {
                    row.Cells["Сумма"].Style.ForeColor = Color.Green;
                }
                else
                {
                    row.Cells["Сумма"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void UpdateFinancialSummary()
        {
            decimal income = DatabaseHelper.GetTotalIncome();
            decimal expenses = DatabaseHelper.GetTotalExpenses();
            decimal balance = income - expenses;

            lblBalance.Text = $"Баланс: {balance} руб.";
            lblIncome.Text = $"Доходы: {income} руб.";
            lblExpenses.Text = $"Расходы: {expenses} руб.";

            // Цвет баланса в зависимости от значения
            lblBalance.ForeColor = balance >= 0 ? Color.Green : Color.Red;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new TransactionForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTransactions();
                    UpdateFinancialSummary();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedId = (int)dataGridView.SelectedRows[0].Cells["Id"].Value;
            var transactions = DatabaseHelper.GetAllTransactions();
            var transaction = transactions.FirstOrDefault(t => t.Id == selectedId);

            if (transaction != null)
            {
                using (var form = new TransactionForm(transaction))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadTransactions();
                        UpdateFinancialSummary();
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var selectedId = (int)dataGridView.SelectedRows[0].Cells["Id"].Value;
                DatabaseHelper.DeleteTransaction(selectedId);
                LoadTransactions();
                UpdateFinancialSummary();
            }
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEdit_Click(sender, e);
            }
        }
    }
}
