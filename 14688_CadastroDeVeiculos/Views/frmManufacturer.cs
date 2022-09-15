using _14688_CadastroDeVeiculos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14688_CadastroDeVeiculos.Views
{
    public partial class frmManufacturer : Form
    {

        Fuel fu;
        Manufacturer ma;
        VehicleType vt;
        Vehicle ve;

        public void clearAll()
        {
            txtDescription.Clear();
            txtID.Clear();
            txtSearch.Clear();

            txtDescription.Focus();
        }

        void loadGrid(string pesquisa)
        {
            ma = new Manufacturer()
            {
                descricao = pesquisa
            };
            dgvManufacturer.DataSource = ma.read();
        }
        public frmManufacturer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void btnincludeManufacturer_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "" || txtDescription.Text == null) return;

            ma = new Manufacturer()
            {
                descricao = txtDescription.Text.ToUpper()
            };
            ma.include();

            clearAll();
            loadGrid("");

            txtDescription.Focus();
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "" || txtDescription.Text == null || txtID.Text == "" || txtID.Text == null) return;
            
            else
            {
                btnincludeManufacturer.Enabled = false;

                ma = new Manufacturer()
                {
                    id = int.Parse(txtID.Text),
                    descricao = txtDescription.Text.ToUpper()
                };
                ma.update();

                clearAll();
                loadGrid("");

                btnincludeManufacturer.Enabled = true;
            }

        }
    

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtID.Text == null) return;
            else
            {
                if (MessageBox.Show("Deseja Mesmo Excluir?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ma = new Manufacturer()
                    {
                        id = int.Parse(txtID.Text)
                    };
                    ma.delete();
                }
                
                btnincludeManufacturer.Enabled = true;

                clearAll();
                loadGrid("");

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearAll();
            loadGrid("");
            btnincludeManufacturer.Enabled = true;
        }

        private void dgvManufacturer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvManufacturer.RowCount > 0)
            {

                btnincludeManufacturer.Enabled = false;

                txtID.Text = dgvManufacturer.CurrentRow.Cells["id"].Value.ToString();
                txtDescription.Text = dgvManufacturer.CurrentRow.Cells["descricao"].Value.ToString().ToUpper();
            }
        }

        private void frmManufacturer_Load(object sender, EventArgs e)
        {
            clearAll();
            loadGrid("");
        }

        private void dgvManufacturer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvManufacturer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "" || txtSearch.Text == null)
            {

                MessageBox.Show("Digite algo para Pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSearch.Focus();

            }
            else
            {
                loadGrid("%" + txtSearch.Text + "%");
            }
        }
    }
}
