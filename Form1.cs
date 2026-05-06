namespace UserForm
{
    public partial class Form1 : Form
    {
        UserService service = new UserService();
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = service.GetUsers();
        }

        //Add User Button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User
                {
                    Name = txtName.Text,
                    Email = txtEmail.Text,
                    Age = int.Parse(txtAge.Text)
                };

                bool result = service.AddUser(user);

                if (result)
                {
                    MessageBox.Show("✅ Data saved successfully!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("❌ Failed to save data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error: " + ex.Message);
            }
        }

        //Update User Button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User
                {
                    Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value),
                    Name = txtName.Text,
                    Email = txtEmail.Text,
                    Age = int.Parse(txtAge.Text)
                };

                bool result = service.UpdateUser(user);

                if (result)
                {
                    MessageBox.Show("✅ Data updated successfully!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("❌ Update failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error: " + ex.Message);
            }
        }
        //Delete User Button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                bool result = service.DeleteUser(id);

                if (result)
                {
                    MessageBox.Show("✅ Deleted successfully!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("❌ Delete failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error: " + ex.Message);
            }
        }
        //Load Data Button
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // When a cell is clicked, populate the text boxes with the selected user's data
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            txtAge.Text = dataGridView1.CurrentRow.Cells["Age"].Value.ToString();
        }

        //update button click event handler
       

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                bool result = service.DeleteUser(id);

                if (result)
                {
                    MessageBox.Show("✅ Deleted successfully!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("❌ Delete failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

