using LashaShraieri.Final.Models;
using LashaShraieri.Final.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LashaShraieri.Final
{
    public partial class Form1 : Form
    {
        private SqlHelper _sqlHelper;

        public Form1()
        {
            InitializeComponent();
            _sqlHelper = new SqlHelper();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLaptops();
        }

        private void LoadLaptops()
        {
            LaptopsListBox.Items.Clear();
            List<Laptop> laptops = _sqlHelper.GetLaptops();
            foreach (Laptop laptop in laptops)
            {
                LaptopsListBox.Items.Add(laptop);
            }
        }

        private void AddLaptopButton_Click(object sender, EventArgs e)
        {
            using (LaptopDialog dialog = new LaptopDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Laptop newLaptop = new Laptop(
                        dialog.Model,
                        dialog.ReleaseYear,
                        dialog.MemorySize,
                        dialog.Cores
                    );
                    _sqlHelper.AddLaptop(newLaptop);
                    LoadLaptops(); // Refresh the list after adding
                }
            }
        }

        private void DeleteLaptopButton_Click(object sender, EventArgs e)
        {
            if (LaptopsListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a laptop to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the selected laptop
            Laptop selectedLaptop = LaptopsListBox.SelectedItem as Laptop;

            if (selectedLaptop != null)
            {
                DialogResult confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete '{selectedLaptop.Model}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    _sqlHelper.DeleteLaptop(selectedLaptop.Id);
                    LoadLaptops(); // Refresh the list after deleting
                }
            }
        }
    }
}
