using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _14688_CadastroDeVeiculos.Models;
using _14688_CadastroDeVeiculos.Views;

namespace _14688_CadastroDeVeiculos
{
    public partial class frmMenu : Form
    {

        Fuel fu;
        Manufacturer ma;
        VehicleType vt;
        Vehicle ve;
        

       
        public frmMenu()
        {
            InitializeComponent();
        }

        public void frmMenu_Load(object sender, EventArgs e)
        {
            Banco.openConnection();

            Banco.createDataBase(); 
        }

        private void btnincludeVechicle_Click(object sender, EventArgs e)
        {
            frmIncludeVehicle form = new frmIncludeVehicle();
            form.Show();
        }

        private void btnIncludeManufacturer_Click(object sender, EventArgs e)
        {
            frmManufacturer form = new frmManufacturer();
            form.Show();
        }

        private void btnVehicleType_Click(object sender, EventArgs e)
        {
            frmVehicleType form = new frmVehicleType();
            form.Show();
        }

        private void btnFuel_Click(object sender, EventArgs e)
        {
            frmFuel form = new frmFuel();
            form.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
                Environment.Exit(0);
        }

        private void dgvVeiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvVeiculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
    }
}
