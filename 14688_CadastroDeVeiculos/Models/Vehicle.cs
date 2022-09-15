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
    public class Vehicle
    {
        public int id { get; set; }
        public string modelo { get; set; }
        public int idfabricante { get; set; }
        public int idtipo { get; set; }
        public string cor { get; set; }
        public int ano { get; set; }
        public int idcombustivel { get; set; }
        public string chassi { get; set; }
        public double km { get; set; }
        public bool revisao { get; set; }
        public bool sinistro { get; set; }
        public bool roubo_furto { get; set; }
        public bool aluguel { get; set; }
        public bool venda { get; set; }
        public bool particular { get; set; }
        public string obs { get; set; }

        public DataTable read()
        {
            try
            {
                Banco.openConnection();
                Banco.Command = new MySqlCommand("Use carshop; " +
                    "select " +
                    "v.*, " +
                    "f.descricao fabricante, " +
                    "t.descricao categoria, " +
                    "c.descricao combustivel " +
                    "" +
                    "from veiculos v " +
                    "inner join fabricantes f on f.id = v.idfabricante " +
                    "inner join tiposveiculos t on t.id = v.idtipo " +
                    "inner join combustiveis c on c.id = v.idcombustivel " +
                    "where v.modelo like @modelo " +
                    "order by v.modelo;", Banco.Connection);
                Banco.Command.Parameters.AddWithValue("@modelo", modelo + "%");
                Banco.Adapter= new MySqlDataAdapter(Banco.Command);
                Banco.datTable = new DataTable();
                Banco.Adapter.Fill(Banco.datTable);
                return Banco.datTable;
            }
            catch(Exception e)
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
                    "insert into veiculos " +
                    "(modelo, " +
                    "idfabricante, " +
                    "idtipo, " +
                    "ano, " +
                    "idcombustivel, " +
                    "cor, " +
                    "chassi, " +
                    "km, " +
                    "revisao, " +
                    "sinistro, " +
                    "roubo_furto, " +
                    "aluguel, " +
                    "venda, " +
                    "particular, " +
                    "obs) " +
                    " " +
                    "values " +
                    "(@modelo, " +
                    "@idfabricante, " +
                    "@idtipo, " +
                    "@ano, " +
                    "@idcombustivel, " +
                    "@cor, " +
                    "@chassi, " +
                    "@km, " +
                    "@revisao, " +
                    "@sinistro, " +
                    "@roubo_furto, " +
                    "@aluguel, " +
                    "@venda, " +
                    "@particular, " +
                    "@obs); ", Banco.Connection);
                Banco.Command.Parameters.AddWithValue("@modelo", modelo);
                Banco.Command.Parameters.AddWithValue("@idfabricante", idfabricante);
                Banco.Command.Parameters.AddWithValue("@idtipo", idtipo);
                Banco.Command.Parameters.AddWithValue("@ano", ano);
                Banco.Command.Parameters.AddWithValue("@idcombustivel", idcombustivel);
                Banco.Command.Parameters.AddWithValue("@cor", cor);
                Banco.Command.Parameters.AddWithValue("@chassi", chassi);
                Banco.Command.Parameters.AddWithValue("@km", km);
                Banco.Command.Parameters.AddWithValue("@revisao", revisao);
                Banco.Command.Parameters.AddWithValue("@sinistro", sinistro);
                Banco.Command.Parameters.AddWithValue("roubo_furto", roubo_furto);
                Banco.Command.Parameters.AddWithValue("@aluguel", aluguel);
                Banco.Command.Parameters.AddWithValue("@venda", venda);
                Banco.Command.Parameters.AddWithValue("@particular", particular);
                Banco.Command.Parameters.AddWithValue("@obs", obs);
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
                    "update veiculos " +
                    "set " +
                    "modelo = @modelo, " +
                    "idfabricante = @idfabricante, " +
                    "idtipo = @idtipo, " +
                    "ano = @ano, " +
                    "cor = @cor, " +
                    "idcombustivel = @idcombustivel, " +
                    "chassi = @chassi, " +
                    "km = @km, " +
                    "revisao = @revisao, " +
                    "sinistro = @sinistro, " +
                    "roubo_furto = @roubo_furto, " +
                    "aluguel = @aluguel, " +
                    "venda = @venda, " +
                    "particular = @particular, " +
                    "obs = @obs " +
                    "where id=@id;", Banco.Connection);
                Banco.Command.Parameters.AddWithValue("@modelo", modelo);
                Banco.Command.Parameters.AddWithValue("@idfabricante", idfabricante);
                Banco.Command.Parameters.AddWithValue("@idtipo", idtipo);
                Banco.Command.Parameters.AddWithValue("@ano", ano);
                Banco.Command.Parameters.AddWithValue("@cor", cor);
                Banco.Command.Parameters.AddWithValue("@idcombustivel", idcombustivel);
                Banco.Command.Parameters.AddWithValue("@chassi", chassi);
                Banco.Command.Parameters.AddWithValue("@km", km);
                Banco.Command.Parameters.AddWithValue("@revisao", revisao);
                Banco.Command.Parameters.AddWithValue("@sinistro", sinistro);
                Banco.Command.Parameters.AddWithValue("roubo_furto", roubo_furto);
                Banco.Command.Parameters.AddWithValue("@aluguel", aluguel);
                Banco.Command.Parameters.AddWithValue("@venda", venda);
                Banco.Command.Parameters.AddWithValue("@particular", particular);
                Banco.Command.Parameters.AddWithValue("@obs", obs);
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
                    "delete from veiculos " +
                    "where id=@id;", Banco.Connection);
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
