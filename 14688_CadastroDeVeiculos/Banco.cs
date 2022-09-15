using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _14688_CadastroDeVeiculos
{
    public class Banco
    {

        public static MySqlConnection Connection;

        public static MySqlCommand Command;

        public static MySqlDataAdapter Adapter;

        public static DataTable datTable;

        public static void openConnection()
        {

            try
            {
                Connection = new MySqlConnection("server=localhost;" +
                    "port=3307;" +
                    "uid=root;" +
                    "pwd=etecjau;");

                Connection.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void createDataBase()
        {
            try
            {

              
                openConnection();

                Command = new MySqlCommand("create database if not exists carshop; " +
                    "use carshop;", Connection);
                Command.ExecuteNonQuery();

                Command = new MySqlCommand("create table if not exists veiculos" +
                    "(ID integer auto_increment primary key, " +
                    "Modelo varchar(40), " +
                    "idFabricante integer, " +
                    "idTipo integer, " +
                    "Ano integer(4), " +
                    "idCombustivel integer, " +
                    "Cor varchar(30), " +
                    "Chassi varchar(17), " +
                    "KM decimal(10,3), " +
                    "Revisao boolean, " +
                    "Sinistro boolean, " +
                    "Roubo_furto boolean, " +
                    "Aluguel boolean, " +
                    "Venda boolean, " +
                    "Particular boolean, " +
                    "OBS varchar(200));", Connection);
                Command.ExecuteNonQuery();

                Command = new MySqlCommand("create table if not exists fabricantes " +
                    "(id integer auto_increment primary key, " +
                    "Descricao varchar(30));", Connection);
                Command.ExecuteNonQuery();

                Command = new MySqlCommand("create table if not exists tiposVeiculos " +
                    "(id integer auto_increment primary key, " +
                    "Descricao varchar(30));", Connection);
                Command.ExecuteNonQuery();

                Command = new MySqlCommand("create table if not exists combustiveis " +
                    "(id integer auto_increment primary key, " +
                    "Descricao varchar(20));", Connection);
                Command.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        
    }
}
