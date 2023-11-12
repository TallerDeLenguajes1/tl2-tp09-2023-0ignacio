using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using tl2_tp09_2023_0ignacio.Models;

namespace tl2_tp09_2023_0ignacio.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void Create(int idTablero, Tarea tarea)
        {
            var query = $"INSERT INTO Tarea (id_tablero, nombre_tarea, estado_tarea, descripcion_tarea, color_tarea, id_usuario_asignado) VALUES (@idTablero, @nombreTarea, @estadoTarea, @descTarea, @colorTarea, @idUsuarioAsignado)";

            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                command.Parameters.Add(new SQLiteParameter("@nombreTarea", tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estadoTarea", tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@descTarea", tarea.Desc));
                command.Parameters.Add(new SQLiteParameter("@colorTarea", tarea.Color));
                command.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", tarea.IdUsuarioAsignado));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Update(int idTarea, Tarea tarea)
        {
            var query = $"UPDATE Tarea SET id_tablero = @idTablero, nombre_tarea = @nombreTarea, estado_tarea = @estadoTarea, descripcion_tarea = @descTarea, color_tarea = @colorTarea, id_usuario_asignado = @idUsuarioAsignado WHERE id_tarea = @idTarea";
            
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                command.Parameters.Add(new SQLiteParameter("@idTablero", tarea.IdTablero));
                command.Parameters.Add(new SQLiteParameter("@nombreTarea", tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estadoTarea", tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@descTarea", tarea.Desc));
                command.Parameters.Add(new SQLiteParameter("@colorTarea", tarea.Color));
                command.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", tarea.IdUsuarioAsignado));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Assign(int idUsuario, int idTarea)
        {
            var query = $"UPDATE Tarea SET id_usuario_asignado = @idUsuarioAsignado WHERE id_tarea = @idTarea";
            
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                command.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", idUsuario));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public Tarea GetById(int idTarea)
        {
            var query = @"SELECT * FROM Tarea WHERE id_tarea = @idTarea";
            var tarea = new Tarea();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        tarea.Id = Convert.ToInt32(reader["id_tarea"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        if (reader["id_usuario_asignado"] != DBNull.Value)
                        {
                            tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);;
                        }else{
                            tarea.IdUsuarioAsignado = 0;
                        }
                        tarea.Nombre = reader["nombre_tarea"].ToString();
                        tarea.Desc = reader["descripcion_tarea"].ToString();
                        tarea.Color = reader["color_tarea"].ToString();
                        tarea.Estado = (EstadoTarea)Convert.ToInt32(reader["estado_tarea"]);
                    }
                }
                connection.Close();
            }
            return (tarea.Id == 0) ? null : tarea;
        }
        public List<Tarea> GetAllByUsuario(int idUsuario)
        {
            var query = @"SELECT * FROM Tarea WHERE id_usuario_asignado = @idUsuario";
            List<Tarea> tareas = new List<Tarea>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
                connection.Open();

                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id_tarea"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        if (reader["id_usuario_asignado"] != DBNull.Value)
                        {
                            tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);;
                        }else{
                            tarea.IdUsuarioAsignado = 0;
                        }
                        tarea.Nombre = reader["nombre_tarea"].ToString();
                        tarea.Desc = reader["descripcion_tarea"].ToString();
                        tarea.Color = reader["color_tarea"].ToString();
                        tarea.Estado = (EstadoTarea)Convert.ToInt32(reader["estado_tarea"]);
                        tareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return tareas;
        }
        public List<Tarea> GetAllByTablero(int idTablero)
        {
            var query = @"SELECT * FROM Tarea WHERE id_tablero = @idTablero";
            List<Tarea> tareas = new List<Tarea>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                connection.Open();

                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id_tarea"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        if (reader["id_usuario_asignado"] != DBNull.Value)
                        {
                            tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);;
                        }else{
                            tarea.IdUsuarioAsignado = 0;
                        }
                        tarea.Nombre = reader["nombre_tarea"].ToString();
                        tarea.Desc = reader["descripcion_tarea"].ToString();
                        tarea.Color = reader["color_tarea"].ToString();
                        tarea.Estado = (EstadoTarea)Convert.ToInt32(reader["estado_tarea"]);
                        tareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return tareas;
        }
        public void Delete(int idTarea)
        {
            var query = @"DELETE FROM Tarea WHERE id_tarea = @idTarea";
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public int GetCantEstado(int estado)
        {
            var query = @"SELECT * FROM Tarea WHERE estado_tarea = @estado";
            List<Tarea> tareas = new List<Tarea>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@estado", estado));
                connection.Open();

                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id_tarea"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        if (reader["id_usuario_asignado"] != DBNull.Value)
                        {
                            tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);;
                        }else{
                            tarea.IdUsuarioAsignado = 0;
                        }
                        tarea.Nombre = reader["nombre_tarea"].ToString();
                        tarea.Desc = reader["descripcion_tarea"].ToString();
                        tarea.Color = reader["color_tarea"].ToString();
                        tarea.Estado = (EstadoTarea)Convert.ToInt32(reader["estado_tarea"]);
                        tareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return tareas.Count();
        }
    }
}