using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace El_Balcon_de_Chalita
{
    class cliente
    {

        public List<string> llenarComboBoxClientes()
        {
            //Instanciamos la clase de Mysql para la lectura de registros en BD
            MySqlDataReader reader = null;
            List<string> clientes = new List<string>();

            //Query para obtener toda la info de los clientes registrados en la BD
            string query = "SELECT* FROM clientes";
            //Instanciamos la clase de MysqlConnection 
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            //Abrimos la conexion a la BD
            conexionBD.Open();
            //Ejecutamos bloque try - catch para ejecutar el query de consulta
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                reader = comando.ExecuteReader();
                //Si la consulta trae resultados, se llenara el combobox de clientes
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clientes.Add(reader.GetString(6) + "-" + reader.GetString(1));

                    }
                }
                reader.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ocurrio un error en la consulta:" + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
            return clientes;

        }
        public List<string> llenarComboBoxCompañiasAfiliadas()
        {
            //Instanciamos la clase de Mysql para la lectura de registros en BD
            MySqlDataReader reader = null;
            List<string> compañias = new List<string>();

            //Query para obtener toda la info de los clientes registrados en la BD
            string queryCompañias = "SELECT * FROM compañiasafiliadas";
            //Instanciamos la clase de MysqlConnection 
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            //Abrimos la conexion a la BD
            conexionBD.Open();
            //Ejecutamos bloque try - catch para ejecutar el query de consulta
            try
            {
                MySqlCommand comando = new MySqlCommand(queryCompañias, conexionBD);
                reader = comando.ExecuteReader();
                //Si la consulta trae resultados, se llenara el combobox de clientes
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        compañias.Add(reader.GetString(0) + "-" + reader.GetString(1));

                    }
                }
                reader.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ocurrio un error en la consulta:" + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
            return compañias;

        }

        public void eliminarCliente(string codigo)
        {
            String query = "DELETE FROM clientes where codigoCliente= '" + codigo + "' ";
            MessageBox.Show(query);

            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand accion = new MySqlCommand(query, conexionBD);
                accion.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar el regustro:" + ex.Message);
            }
        }
    }
}
