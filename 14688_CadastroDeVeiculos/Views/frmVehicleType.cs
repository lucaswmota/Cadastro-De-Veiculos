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
    public partial class frmVehicleType : Form
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
            vt= new VehicleType()
            {
                descricao = pesquisa
            };
            dgvCategory.DataSource = vt.read();
        }
        public frmVehicleType()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void btnIncludeCategory_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "" || txtDescription.Text == null) return;

            vt = new VehicleType()
            {
                descricao = txtDescription.Text.ToUpper()
            };
            vt.include();

            clearAll();
            loadGrid("");

            txtDescription.Focus();
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "" || txtDescription.Text == null || txtID.Text == "" || txtID.Text == null) return;
            
            else
            {
                btnIncludeCategory.Enabled = false;

                vt = new VehicleType()
                {
                    id = int.Parse(txtID.Text),
                    descricao = txtDescription.Text.ToUpper()
                };
                vt.update();

                clearAll();
                loadGrid("");

                btnIncludeCategory.Enabled = true;
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
                    vt = new VehicleType()
                    {
                        id = int.Parse(txtID.Text)
                    };
                    vt.delete();
                }

                btnIncludeCategory.Enabled = true;

                clearAll();
                loadGrid("");

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearAll();
            loadGrid("");
            btnIncludeCategory.Enabled = true;
        }

        private void dgvCategory_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frmVehicleType_Load(object sender, EventArgs e)
        {
            clearAll();
            loadGrid("");
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategory.RowCount > 0)
            {

                btnIncludeCategory.Enabled = false;

                txtID.Text = dgvCategory.CurrentRow.Cells["id"].Value.ToString();
                txtDescription.Text = dgvCategory.CurrentRow.Cells["descricao"].Value.ToString().ToUpper();
            }
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
