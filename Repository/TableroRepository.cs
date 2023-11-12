using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using tl2_tp09_2023_0ignacio.Models;


namespace tl2_tp09_2023_0ignacio.Repositories
{
    public class TableroRepository : ITableroRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void Create(Tablero tablero)
        {
            var query = $"INSERT INTO Tablero (id_usuario_propietario, nombre_tablero, descripcion_tablero) VALUES (@idUsuarioPropietario, @nombreTablero, @descTablero)";
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuarioPropietario", tablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombreTablero", tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descTablero", tablero.Desc));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Update(int idTablero, Tablero tablero)
        {
            var query = $"UPDATE Tablero SET id_usuario_propietario = @idUsuarioPropietario, nombre_tablero = @nombreTablero, descripcion_tablero = @descTablero";
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuarioPropietario", tablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombreTablero", tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descTablero", tablero.Desc));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<Tablero> GetAll()
        {
            var query = @"SELECT * FROM Tablero";
            List<Tablero> tableros = new List<Tablero>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();

                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(reader["id_tablero"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre_tablero"].ToString();
                        tablero.Desc = reader["descripcion_tablero"].ToString();
                        tableros.Add(tablero);
                    }
                }
                connection.Close();
            }
            return tableros;
        }
        public Tablero GetById(int idTablero)
        {
            var query = @"SELECT * FROM Tablero WHERE id_tablero = @idTablero";
            var tablero = new Tablero();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        tablero.Id = Convert.ToInt32(reader["id_tablero"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre_tablero"].ToString();
                        tablero.Desc = reader["descripcion_tablero"].ToString();
                    }
                }
                connection.Close();
            }
            return (tablero.Id == 0) ? null : tablero;
        }
        public List<Tablero> GetByUsuario(int idUsuario)
        {
            var query = @"SELECT * FROM Tablero WHERE id_usuario_propietario = @idUsuario";
            List<Tablero> tableros = new List<Tablero>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
                connection.Open();

                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(reader["id_tablero"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre_tablero"].ToString();
                        tablero.Desc = reader["descripcion_tablero"].ToString();
                        tableros.Add(tablero);
                    }
                }
                connection.Close();
            }
            return tableros;
        }
        public void Delete(int idTablero)
        {
            var query = @"DELETE FROM Tarea WHERE id_tablero = @idTablero";
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}