using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prueba.Controller;
using System.Diagnostics;
namespace Prueba
{
    public partial class Form1 : Form
    {
        InventaryController ic;
        public Form1()
        {
            InitializeComponent();
            ic = new InventaryController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mydbDataSet.inventario' table. You can move, or remove it, as needed.
            this.inventarioTableAdapter.Fill(this.mydbDataSet.inventario);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValid(this.txtProduct.Text, (int)this.numQuantity.Value))
            {
                ic.addItem(this.txtProduct.Text, (int)this.numQuantity.Value);
                this.inventarioTableAdapter.Fill(this.mydbDataSet.inventario);
            }
            else
            {
                MessageBox.Show("Escriba un nombre y cantidad valida");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectedRows.Count == 1)
            {

                

                int selectedrowindex = this.dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.dataGridView1.Rows[selectedrowindex];
                int id = (int)selectedRow.Cells[0].Value;
                if (isValid(this.txtProduct.Text, (int)this.numQuantity.Value))
                { 
                    ic.updateItem(id, this.txtProduct.Text, (int)this.numQuantity.Value);
                    this.inventarioTableAdapter.Fill(this.mydbDataSet.inventario);
                }
                else
                {
                    MessageBox.Show("Escriba un nombre y cantidad valida");
                }
            }else {
                MessageBox.Show("Seleccione una fila para editar");
            }
            
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            if (this.dataGridView1.SelectedRows.Count == 1)
            {


                DialogResult dr = MessageBox.Show("Esta seguro?", "Eliminar registro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {


                    int selectedrowindex = this.dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = this.dataGridView1.Rows[selectedrowindex];
                    int id = (int)selectedRow.Cells[0].Value;
                    ic.deleteItem(id);
                    this.inventarioTableAdapter.Fill(this.mydbDataSet.inventario);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0) { 
            int selectedrowindex = this.dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = this.dataGridView1.Rows[selectedrowindex];

            this.txtProduct.Text = selectedRow.Cells[1].Value.ToString();
            this.numQuantity.Value= (int) selectedRow.Cells[2].Value;
            }
        }
        private bool isValid(string name,int value)
        {
            return !string.IsNullOrEmpty(name) && value >= 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ic.searchItem(
                (BindingSource)dataGridView1.DataSource,
                this.txtBusqueda.Text,
                (int)this.numQuantitySearch.Value,
                (int)this.numQuantitySearchUp.Value,
                (DateTime) this.dtFrom.Value,
                (DateTime)this.dtUntil.Value
                );
        }

        private void button1_Click(object sender, EventArgs e)
            {
                dataGridView1.DataSource = ic.restore((BindingSource)dataGridView1.DataSource);
            }
    }
}
