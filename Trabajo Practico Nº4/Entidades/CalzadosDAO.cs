using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class CalzadosDAO
    {
        private SqlConnection sqlConnection;
        private string connectionString;

        /// <summary>
        /// Constructor sin argumentos que conecta a la BD
        /// </summary>
        public CalzadosDAO()
        {
            this.connectionString = "Server=.\\SQLEXPRESS;Database=TP4DB;Trusted_Connection=True;";
            this.sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Lista botines por ID cargados de la BD y devuelve una empresa con esos botines ingresados.
        /// </summary>
        /// <returns></returns>
        public Empresa ListarBotines()
        {
            Botin.EOrigen origen;
            Botin.EMarca marca;
            Botin.ETipoBotin tipoBotin;
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                string command = "SELECT * FROM Botines where BotinesID=BotinesID";

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Botin> botines = new List<Botin>();
                Empresa empresa = new Empresa("Botines BD", 200);

                while (reader.Read())
                {
                    int id = (int)reader["BotinesID"];
                    origen = CalzadosDAO.EnumOrigen((string)reader["Origen"]);
                    double precioCompra = (float)Convert.ToDouble(reader["PrecioCompra"]);
                    int talle = (int)reader["Talle"];
                    string descripcion = null;
                    if (reader["Descripcion"] != DBNull.Value)
                    {
                        descripcion = (string)reader["Descripcion"];
                    }
                    marca = CalzadosDAO.EnumMarca((string)reader["Marca"]);
                    tipoBotin = CalzadosDAO.EnumTipoBotin((string)reader["Tipo"]);

                    Botin botin = new Botin(id, origen, precioCompra, talle, descripcion, marca, tipoBotin);
                    empresa.SumarCalzado<Botin>(empresa, botin);
                }

                return empresa;
            }
        }

        /// <summary>
        /// Lista zapatillas por ID cargados de la BD y devuelve una empresa con esos botines ingresados.
        /// </summary>
        /// <returns></returns>
        public Empresa ListarZapatillas()
        {
            Zapatilla.EOrigen origen;
            Zapatilla.EMarca marca;
            Zapatilla.ETipoZapatilla tipoZapatilla;
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                string command = "SELECT * FROM Zapatillas where ZapatillasID=ZapatillasID";

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Zapatilla> zapatillas = new List<Zapatilla>();
                Empresa empresa = new Empresa("Zapatillas BD", 200);

                while (reader.Read())
                {
                    int id = (int)reader["ZapatillasID"];
                    origen = CalzadosDAO.EnumOrigen((string)reader["Origen"]);
                    double precioCompra = (float)Convert.ToDouble(reader["PrecioCompra"]);
                    int talle = (int)reader["Talle"];
                    string descripcion = null;
                    if (reader["Descripcion"] != DBNull.Value)
                    {
                        descripcion = (string)reader["Descripcion"];
                    }
                    marca = CalzadosDAO.EnumMarca((string)reader["Marca"]);
                    tipoZapatilla = CalzadosDAO.EnumTipoZapatilla((string)reader["Tipo"]);

                    Zapatilla zapatilla = new Zapatilla(id, origen, precioCompra, talle, descripcion, marca, tipoZapatilla);
                    empresa.SumarCalzado<Zapatilla>(empresa, zapatilla);
                }

                return empresa;
            }
        }

        /// <summary>
        /// Convierte el formato string en enumerado.
        /// </summary>
        /// <param name="origen"></param>
        /// <returns></returns>
        static Calzado.EOrigen EnumOrigen(string origen)
        {
            Calzado.EOrigen auxRetorno = Calzado.EOrigen.Nacional;

            switch (origen)
            {
                case "Nacional":
                    auxRetorno = Calzado.EOrigen.Nacional;
                    break;
                case "Importado":
                    auxRetorno = Calzado.EOrigen.Importado;
                    break;  
            }

            return auxRetorno;
        }

        /// <summary>
        /// Convierte el formato string en enumerado.
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        static Calzado.EMarca EnumMarca(string marca)
        {
            Calzado.EMarca auxRetorno = Calzado.EMarca.Adidas;

            switch(marca)
            {
                case "Adidas":
                    auxRetorno = Calzado.EMarca.Adidas;
                    break;
                case "Nike":
                    auxRetorno = Calzado.EMarca.Nike;
                    break;
                case "Puma":
                    auxRetorno = Calzado.EMarca.Puma;
                    break;
                case "Reebok":
                    auxRetorno = Calzado.EMarca.Reebok;
                    break;
                case "Umbro":
                    auxRetorno = Calzado.EMarca.Umbro;
                    break;
            }

            return auxRetorno;
        }

        /// <summary>
        /// Convierte el formato string en enumerado.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        static Botin.ETipoBotin EnumTipoBotin(string tipo)
        {
            Botin.ETipoBotin auxRetorno = Botin.ETipoBotin.Cesped;

            switch (tipo)
            {
                case "Cesped":
                    auxRetorno = Botin.ETipoBotin.Cesped;
                    break;
                case "Sintetico":
                    auxRetorno = Botin.ETipoBotin.Sintetico;
                    break;
                case "Pista":
                    auxRetorno = Botin.ETipoBotin.Pista;
                    break;

            }

            return auxRetorno;
        }

        /// <summary>
        /// Convierte el formato string en enumerado.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        static Zapatilla.ETipoZapatilla EnumTipoZapatilla(string tipo)
        {
            Zapatilla.ETipoZapatilla auxRetorno = Zapatilla.ETipoZapatilla.Moda;

            switch (tipo)
            {
                case "Moda":
                    auxRetorno = Zapatilla.ETipoZapatilla.Moda;
                    break;
                case "Running":
                    auxRetorno = Zapatilla.ETipoZapatilla.Running;
                    break;
                case "Sport":
                    auxRetorno = Zapatilla.ETipoZapatilla.Sport;
                    break;

            }

            return auxRetorno;
        }

    }
}