using _14688_CadastroDeVeiculos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14688_CadastroDeVeiculos.Views
{
    public partial class frmIncludeVehicle : Form
    {
        Banco ba;
        Fuel fu;
        Manufacturer ma;
        VehicleType vt;
        Vehicle ve;

        public void clearAll()
        {
            txtID.Clear();
            txtModelo.Clear();
            cboFabricante.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
            cboCombustivel.SelectedIndex = -1;
            txtAno.Clear();
            txtCor.Clear();
            txtChassi.Clear();
            txtKm.Clear();
            chkRevisao.Checked = false;
            chkSinistro.Checked = false;
            chkRouboFurto.Checked = false;
            chkAluguel.Checked = false;
            chkVenda.Checked = false;
            chkParticular.Checked = false;
            txtObs.Clear();
            txtSearch.Clear();

            txtModelo.Focus();
        }

        public void loadGrid(string pesquisa)
        {
            ve = new Vehicle()
            {
                modelo = pesquisa
            };
            dgvVeiculos.DataSource = ve.read();

        }



        public frmIncludeVehicle()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void frmIncludeVehicle_Load(object sender, EventArgs e)
        {
            fu = new Fuel();
            cboCombustivel.DataSource = fu.read();
            cboCombustivel.DisplayMember = "descricao";
            cboCombustivel.ValueMember = "id";

            ma = new Manufacturer();
            cboFabricante.DataSource = ma.read();
            cboFabricante.DisplayMember = "descricao";
            cboFabricante.ValueMember = "id";

            vt = new VehicleType();
            cboTipo.DataSource = vt.read();
            cboTipo.DisplayMember = "descricao";
            cboTipo.ValueMember = "id";

            clearAll(); 
            loadGrid("");

            dgvVeiculos.Columns["idcombustivel"].Visible = false;
            dgvVeiculos.Columns["idfabricante"].Visible = false;
            dgvVeiculos.Columns["idtipo"].Visible = false;
            dgvVeiculos.Columns["chassi"].Visible = false;
            dgvVeiculos.Columns["km"].Visible = false;
            dgvVeiculos.Columns["revisao"].Visible = false;
            dgvVeiculos.Columns["sinistro"].Visible = false;
            dgvVeiculos.Columns["roubo_furto"].Visible = false;
            dgvVeiculos.Columns["aluguel"].Visible = false;
            dgvVeiculos.Columns["venda"].Visible = false;
            dgvVeiculos.Columns["particular"].Visible = false;           
            
            

        }

        public void cboFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFabricante.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboFabricante.SelectedItem;
                cboFabricante.SelectedItem = reg["descricao"].ToString();
            }
        }

        public void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboTipo.SelectedItem;
                cboTipo.SelectedItem = reg["descricao"].ToString();
            }
        }

        public void cboCombustivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCombustivel.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCombustivel.SelectedItem;
                cboCombustivel.SelectedItem = reg["descricao"].ToString();
            }
        }

        private void btnincludeVechicle_Click(object sender, EventArgs e)
        {
            if (txtModelo.Text == "" || txtModelo.Text == null ||
                txtChassi.Text == "" || txtChassi.Text == null ||
                cboCombustivel.SelectedIndex == -1 ||
                cboFabricante.SelectedIndex == -1 ||
                cboTipo.SelectedIndex == -1 ||
                txtAno.Text == null || txtAno.Text == "" ||
                txtChassi.Text == null || txtChassi.Text == "" ||
                txtKm.Text == null || txtKm.Text == ""
                )
            {
                txtError.Visible = true;
                txtError.Text = "Preencha os Campos em Negrito!";
                txtError.ForeColor = Color.Red;
                return;
            }

            ve = new Vehicle()
            {
                modelo = txtModelo.Text.ToUpper(),
                idfabricante = (int)cboFabricante.SelectedValue,
                idtipo = (int)cboTipo.SelectedValue,
                idcombustivel = (int)cboCombustivel.SelectedValue,
                ano = int.Parse(txtAno.Text),
                cor = txtCor.Text.ToUpper(),
                chassi = txtChassi.Text.ToUpper(),
                km = double.Parse(txtKm.Text),
                revisao = chkRevisao.Checked,
                sinistro = chkSinistro.Checked,
                roubo_furto = chkRouboFurto.Checked,
                aluguel = chkAluguel.Checked,
                venda = chkVenda.Checked,
                particular = chkParticular.Checked,
                obs = txtObs.Text.ToUpper()

            };
            ve.include();

            clearAll();
            loadGrid("");
            txtModelo.Focus();

            
            txtError.Text = "Campos em Negrito São Obrigatórios";
            txtError.ForeColor = Color.Black;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearAll();
            txtModelo.Focus();
            btnincludeVechicle.Enabled = true;
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtID.Text == null ||
                txtModelo.Text == "" || txtModelo.Text == null ||
                txtChassi.Text == "" || txtChassi.Text == null ||
                cboCombustivel.SelectedIndex == -1 ||
                cboFabricante.SelectedIndex == -1 ||
                cboTipo.SelectedIndex == -1 ||
                txtAno.Text == null || txtAno.Text == "" ||
                txtChassi.Text == null || txtChassi.Text == "" ||
                txtKm.Text == null || txtKm.Text == ""
                )
            {
                txtError.Visible = true;
                txtError.Text = "Preencha os Campos em Negrito!";
                txtError.ForeColor = Color.Red;
                return;
            }           
            else
            {
                try
                {

                    btnincludeVechicle.Enabled = false;

                    ve = new Vehicle()
                    {
                        id = int.Parse(txtID.Text),
                        modelo = txtModelo.Text.ToUpper(),
                        idfabricante = (int)cboFabricante.SelectedValue,
                        idtipo = (int)cboTipo.SelectedValue,
                        idcombustivel = (int)cboCombustivel.SelectedValue,
                        ano = int.Parse(txtAno.Text),
                        cor = txtCor.Text.ToUpper(),
                        chassi = txtChassi.Text.ToUpper(),
                        km = double.Parse(txtKm.Text),
                        revisao = chkRevisao.Checked,
                        sinistro = chkSinistro.Checked,
                        roubo_furto = chkRouboFurto.Checked,
                        aluguel = chkAluguel.Checked,
                        venda = chkVenda.Checked,
                        particular = chkParticular.Checked,
                        obs = txtObs.Text.ToUpper()
                    };

                    ve.update();

                    clearAll();
                    loadGrid("");
                    txtModelo.Focus();

                    btnincludeVechicle.Enabled = true;
                    
                    txtError.Text = "Campos em Negrito São Obrigatórios";
                    txtError.ForeColor = Color.Black;

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Nenhum item selecionado para exclusão", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Deseja mesmo exluir o item selecionado?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ve = new Vehicle()
                    {
                        id = int.Parse(txtID.Text)
                    };
                    ve.delete();
                }
            }

            btnincludeVechicle.Enabled = true;

            clearAll();
            loadGrid("");

            txtModelo.Focus();
        }

        private void dgvVeiculos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvVeiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
        }

        private void btnIncludeManufacturer_Click(object sender, EventArgs e)
        {
            frmManufacturer form = new frmManufacturer();
            form.Show();

            

        }

        private void btnIncludeCategory_Click(object sender, EventArgs e)
        {
            frmVehicleType form = new frmVehicleType();
            form.Show();
        }

        private void btnIncludeFuel_Click(object sender, EventArgs e)
        {
            frmFuel form = new frmFuel();
            form.Show();
        }

        private void dgvVeiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVeiculos.RowCount > 0)
            {

                btnincludeVechicle.Enabled = false;

                txtID.Text = dgvVeiculos.CurrentRow.Cells["id"].Value.ToString();
                txtModelo.Text = dgvVeiculos.CurrentRow.Cells["modelo"].Value.ToString();
                cboFabricante.Text = dgvVeiculos.CurrentRow.Cells["fabricante"].Value.ToString();
                cboTipo.Text = dgvVeiculos.CurrentRow.Cells["categoria"].Value.ToString();
                cboCombustivel.Text = dgvVeiculos.CurrentRow.Cells["combustivel"].Value.ToString();
                txtAno.Text = dgvVeiculos.CurrentRow.Cells["ano"].Value.ToString();
                txtCor.Text = dgvVeiculos.CurrentRow.Cells["cor"].Value.ToString();
                txtChassi.Text = dgvVeiculos.CurrentRow.Cells["chassi"].Value.ToString();
                txtKm.Text = dgvVeiculos.CurrentRow.Cells["km"].Value.ToString();
                txtObs.Text = dgvVeiculos.CurrentRow.Cells["obs"].Value.ToString();
                chkRevisao.Checked = (bool)dgvVeiculos.CurrentRow.Cells["revisao"].Value;
                chkSinistro.Checked = (bool)dgvVeiculos.CurrentRow.Cells["sinistro"].Value;
                chkRouboFurto.Checked = (bool)dgvVeiculos.CurrentRow.Cells["roubo_furto"].Value;
                chkAluguel.Checked = (bool)dgvVeiculos.CurrentRow.Cells["aluguel"].Value;
                chkVenda.Checked = (bool)dgvVeiculos.CurrentRow.Cells["venda"].Value;
                chkParticular.Checked = (bool)dgvVeiculos.CurrentRow.Cells["particular"].Value;
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

