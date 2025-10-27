using System;
using System.Drawing;
using System.Windows.Forms;

namespace _6._1
{
    public partial class TransactionForm : Form
    {
        private Transaction _transaction;
        private bool _isEditMode;

        private TextBox txtDescription;
        private NumericUpDown numAmount;
        private ComboBox cmbType;
        private DateTimePicker dtpDate;
        private ComboBox cmbCategory;
        private Button btnSave;
        private Button btnCancel;

        public TransactionForm()
        {
            InitializeComponent();
            _isEditMode = false;
        }

        public TransactionForm(Transaction transaction) : this()
        {
            _transaction = transaction;
            _isEditMode = true;
            LoadTransactionData();
        }

        private void LoadTransactionData()
        {
            txtDescription.Text = _transaction.Description;
            numAmount.Value = _transaction.Amount;
            cmbType.Text = _transaction.Type;
            dtpDate.Value = _transaction.Date;
            cmbCategory.Text = _transaction.Category;
            Text = "Редактировать запись";
            btnSave.Text = "Обновить";
        }

        private void InitializeComponent()
        {
            this.Text = "Добавить запись";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Элементы управления
            var lblDescription = new Label { Text = "Описание:", Location = new Point(20, 20), Width = 100 };
            txtDescription = new TextBox { Location = new Point(120, 20), Width = 240 };

            var lblAmount = new Label { Text = "Сумма:", Location = new Point(20, 60), Width = 100 };
            numAmount = new NumericUpDown { Location = new Point(120, 60), Width = 120, DecimalPlaces = 2, Maximum = 1000000 };

            var lblType = new Label { Text = "Тип:", Location = new Point(20, 100), Width = 100 };
            cmbType = new ComboBox { Location = new Point(120, 100), Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbType.Items.AddRange(new[] { "Income", "Expense" });

            var lblDate = new Label { Text = "Дата:", Location = new Point(20, 140), Width = 100 };
            dtpDate = new DateTimePicker { Location = new Point(120, 140), Width = 120 };

            var lblCategory = new Label { Text = "Категория:", Location = new Point(20, 180), Width = 100 };
            cmbCategory = new ComboBox { Location = new Point(120, 180), Width = 120 };
            cmbCategory.Items.AddRange(new[] { "Зарплата", "Инвестиции", "Подарки", "Еда", "Транспорт", "Жилье", "Развлечения", "Здоровье", "Другое" });

            btnSave = new Button { Text = "Сохранить", Location = new Point(120, 220), Width = 80 };
            btnCancel = new Button { Text = "Отмена", Location = new Point(220, 220), Width = 80 };

            // Добавление элементов на форму
            this.Controls.AddRange(new Control[] {
                lblDescription, txtDescription,
                lblAmount, numAmount,
                lblType, cmbType,
                lblDate, dtpDate,
                lblCategory, cmbCategory,
                btnSave, btnCancel
            });

            // События
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            cmbType.SelectedIndexChanged += CmbType_SelectedIndexChanged;

            // Установка значений по умолчанию
            cmbType.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCategories();
        }

        private void UpdateCategories()
        {
            cmbCategory.Items.Clear();
            if (cmbType.Text == "Income")
            {
                cmbCategory.Items.AddRange(new[] { "Зарплата", "Инвестиции", "Подарки", "Другое" });
            }
            else
            {
                cmbCategory.Items.AddRange(new[] { "Еда", "Транспорт", "Жилье", "Развлечения", "Здоровье", "Другое" });
            }
            cmbCategory.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Введите описание", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Сумма должна быть больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var transaction = new Transaction
            {
                Description = txtDescription.Text.Trim(),
                Amount = numAmount.Value,
                Type = cmbType.Text,
                Date = dtpDate.Value,
                Category = cmbCategory.Text
            };

            if (_isEditMode)
            {
                transaction.Id = _transaction.Id;
                DatabaseHelper.UpdateTransaction(transaction);
            }
            else
            {
                DatabaseHelper.AddTransaction(transaction);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
