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
    public partial class frmFuel : Form
    {

        Banco b;
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
            fu = new Fuel()
            {
                descricao = pesquisa
            };
            dgvFuel.DataSource = fu.read();
        }

        public frmFuel()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void btnincludeFuel_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "" || txtDescription.Text == null) return;

            fu = new Fuel()
            {
                descricao = txtDescription.Text.ToUpper()
            };
            fu.include();

            clearAll();
            loadGrid("");

            txtDescription.Focus();
        }

        private void frmFuel_Load(object sender, EventArgs e)
        {
            clearAll();
            loadGrid("");

        }

        private void dgvFuel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFuel.RowCount > 0)
            {

                btnincludeFuel.Enabled = false;

                txtID.Text = dgvFuel.CurrentRow.Cells["id"].Value.ToString();
                txtDescription.Text = dgvFuel.CurrentRow.Cells["descricao"].Value.ToString().ToUpper();
            }
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "" || txtDescription.Text == null ||txtID.Text=="" || txtID.Text==null) return;
            else
            {
                btnincludeFuel.Enabled = false;

                fu = new Fuel()
                {
                    id = int.Parse(txtID.Text),
                    descricao = txtDescription.Text.ToUpper()
                };

                fu.update();

                clearAll();
                loadGrid("");

                btnincludeFuel.Enabled = true;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtID.Text == null) return;
            else{
                if (MessageBox.Show("Deseja Mesmo Excluir?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    fu = new Fuel()
                    {
                        id = int.Parse(txtID.Text)
                    };
                    fu.delete();

                }

                btnincludeFuel.Enabled = true;

                clearAll();
                loadGrid("");

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearAll();
            loadGrid("");
            btnincludeFuel.Enabled = true;
        }

        private void dgvFuel_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvFuel_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
