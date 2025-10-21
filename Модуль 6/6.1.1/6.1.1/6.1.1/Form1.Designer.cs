namespace _6._1._1
{
    partial class Form1
    {
        private DataGridView dataGridView1;
        private TextBox textBoxName;
        private TextBox textBoxPosition;
        private Button buttonAdd;
        private Button buttonDelete;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            textBoxName = new TextBox();
            textBoxPosition = new TextBox();
            buttonAdd = new Button();
            buttonDelete = new Button();
            SuspendLayout();
            //
            // textBoxName
            //
            textBoxName.PlaceholderText = "Имя сотрудника";
            textBoxName.Location = new Point(12, 12);
            textBoxName.Size = new Size(150, 23);
            //
            // textBoxPosition
            //
            textBoxPosition.PlaceholderText = "Должность";
            textBoxPosition.Location = new Point(168, 12);
            textBoxPosition.Size = new Size(150, 23);
            //
            // buttonAdd
            //
            buttonAdd.Text = "Добавить";
            buttonAdd.Location = new Point(324, 12);
            buttonAdd.Click += buttonAdd_Click;
            //
            // buttonDelete
            //
            buttonDelete.Text = "Удалить";
            buttonDelete.Location = new Point(400, 12);
            buttonDelete.Click += buttonDelete_Click;
            //
            // dataGridView1
            //
            dataGridView1.Location = new Point(12, 50);
            dataGridView1.Size = new Size(460, 250);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            //
            // Form1
            //
            ClientSize = new Size(484, 321);
            Controls.Add(dataGridView1);
            Controls.Add(textBoxName);
            Controls.Add(textBoxPosition);
            Controls.Add(buttonAdd);
            Controls.Add(buttonDelete);
            Text = "Учёт сотрудников";
            ResumeLayout(false);
        }
    }
}
