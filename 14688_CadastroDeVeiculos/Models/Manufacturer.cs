using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace _14688_CadastroDeVeiculos.Models
{
    public class Manufacturer
    {
        public int id { get; set; }

        public string descricao { get; set; }

        public DataTable read()
        {
            try
            {
                Banco.openConnection();
                Banco.Command = new MySqlCommand("Use carshop; " +
                    "select * " +
                    "from fabricantes " +
                    "where descricao like @descricao " +
                    "order by descricao;", Banco.Connection);
                Banco.Command.Parameters.AddWithValue("@descricao", descricao + "%");
                Banco.Adapter = new MySqlDataAdapter(Banco.Command);
                Banco.datTable = new DataTable();
                Banco.Adapter.Fill(Banco.datTable);
                Banco.Connection.Close();
                return Banco.datTable;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void include()
        {
            try
            {
                Banco.openConnection();
                Banco.Command = new MySqlCommand("Use carshop; " +
                    "insert into " +
                    "fabricantes (descricao) " +
                    "values (@descricao);", Banco.Connection);
                Banco.Command.Parameters.AddWithValue("@descricao", descricao);
                Banco.Command.ExecuteNonQuery();
                Banco.Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void update()
        {
            try
            {
                Banco.openConnection();
                Banco.Command = new MySqlCommand("Use carshop; " +
                    "update fabricantes " +
                    "set descricao = @descricao " +
                    "where id=@id;", Banco.Connection);
                Banco.Command.Parameters.AddWithValue("@descricao", descricao);
                Banco.Command.Parameters.AddWithValue("@id", id);
                Banco.Command.ExecuteNonQuery();
                Banco.Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void delete()
        {
            try
            {
                Banco.openConnection();
                Banco.Command = new MySqlCommand("Use carshop; " +
                    "delete f from fabricantes f " +
                    "left join veiculos v on v.idfabricante = f.id " +
                    "where v.idfabricante is null; ", Banco.Connection);
                Banco.Command.Parameters.AddWithValue("@id", id);
                Banco.Command.ExecuteNonQuery();
                Banco.Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}
