using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace TiendaComicsMVC.Models
{
    //Clase que servira para hacer todo el acceso a datos junto con los metodos que realizara la pagina, estos metodos se enviaran al controlador principal
    public class TiendaComicsMVCDAL
    {
        //Inicio de la conexion de la base de datos para presentar la informacion
        private string conexion;
        public TiendaComicsMVCDAL()
        {
            conexion = System.Configuration.ConfigurationManager.ConnectionStrings["BDComics"].ConnectionString;
        }

        //Lineas de codigo para recuperar la informacion(Contenido)de la Bd
        public List<Comic> getAll()/*Metodo de consultar a todos los campos*/
        {
            List<Comic> Lista = new List<Comic>();/*Recupera una lista de la clase Comic*/
            using (SqlConnection Conexion = new SqlConnection(conexion))
            {
                Conexion.Open();
                using (SqlCommand Comando = new SqlCommand())
                {
                    Comando.Connection = Conexion;/*Realiza la consulta de la base de datos*/
                    Comando.CommandText = "Select id, numepisodio, nombre, tipocomic, costo, editorial, foto from Comic";
                    SqlDataReader Lector = Comando.ExecuteReader();
                    while (Lector.Read())/*cuando el lector tenga algo que leer entra a un ciclo*/
                    {
                        Comic C = new Comic()
                        {/*Una ves que  se hcae la consulta se genera a un juguete que es rescatado de la base de datos*/
                            id = Convert.ToInt32(Lector["id"]),
                            numepisodio = Convert.ToInt32(Lector["numepisodio"]),
                            nombre = Lector["nombre"].ToString(),
                            tipocomic = Lector["tipocomic"].ToString(),
                            costo = Convert.ToDouble(Lector["costo"]),
                            editorial = Lector["editorial"].ToString(),
                            foto = Lector["foto"].ToString()
                        };
                        Lista.Add(C);
                    }
                };
                Conexion.Close();
            };
            return Lista; /*Se retorna la lista con la informacion*/
        }
        //Fin de la conexion de la base de datos para presentar la informacion

        public void Eliminar(int id)/*Metodo para eliminar a un elemento*/
        {
            using (SqlConnection Conexion = new SqlConnection(conexion))
            {
                Conexion.Open();
                using (SqlCommand Comando = new SqlCommand())
                {
                    Comando.Connection = Conexion;
                    SqlParameter Parametro = new SqlParameter("@id", id);/*Se pretende que al seleccionar el boton eliminar se seleccione el identificador (id) para quelo compare con la base de datos y si son iguales procede a hacer la eliminacion*/
                    Comando.Parameters.Add(Parametro);
                    Comando.CommandText = "delete Comic where id = @id";
                    Comando.ExecuteNonQuery();
                };
                Conexion.Close();
            };
        }

        public void Registrar(Comic Nuevo)
        {
            using (SqlConnection Conexion = new SqlConnection(conexion))
            {
                Conexion.Open();
                using (SqlCommand Comando = new SqlCommand())
                {
                    //Se habilitan los parametros para ser llenados y cada uno sea relacionado con el campo que le corresponde
                    Comando.Connection = Conexion;
                    SqlParameter Parametro1 = new SqlParameter("@id", Nuevo.id);
                    SqlParameter Parametro2 = new SqlParameter("@numepisodio", Nuevo.numepisodio);
                    SqlParameter Parametro3 = new SqlParameter("@nombre", Nuevo.nombre);
                    SqlParameter Parametro4 = new SqlParameter("@tipocomic", Nuevo.tipocomic);
                    SqlParameter Parametro5 = new SqlParameter("@costo", Nuevo.costo);
                    SqlParameter Parametro6 = new SqlParameter("@editorial", Nuevo.editorial);
                    SqlParameter Parametro7 = new SqlParameter("@foto", Nuevo.foto);

                    Comando.Parameters.Add(Parametro1);
                    Comando.Parameters.Add(Parametro2);
                    Comando.Parameters.Add(Parametro3);
                    Comando.Parameters.Add(Parametro4);
                    Comando.Parameters.Add(Parametro5);
                    Comando.Parameters.Add(Parametro6);
                    Comando.Parameters.Add(Parametro7);
                    //Se realiza la accion de insertar en la base de datos
                    Comando.CommandText = "insert into Comic values (@id, @numepisodio, @nombre, @tipocomic, @costo, @editorial, @foto)";
                    Comando.ExecuteNonQuery();
                };
                Conexion.Close();
            };
        }


        public Comic getComic(int id)
        {
            Comic Respuesta = null;
            using (SqlConnection Conexion = new SqlConnection(conexion))
            {
                Conexion.Open();
                using (SqlCommand Comando = new SqlCommand())
                {
                    //Se realiza este metodo para que al seleccionar el link editar se busque el identificador de ese comic en especifico y se recupere la informacion
                    Comando.Connection = Conexion;
                    Comando.Parameters.AddWithValue("@id", id);
                    Comando.CommandText = "Select id, numepisodio, nombre, tipocomic, costo, editorial, foto from Comic where id=@id";
                    SqlDataReader Lector = Comando.ExecuteReader();
                    while (Lector.Read())
                    {
                        Respuesta = new Comic()
                        {
                            id = Convert.ToInt32(Lector["id"]),
                            numepisodio = Convert.ToInt32(Lector["numepisodio"]),
                            nombre = Lector["nombre"].ToString(),
                            tipocomic = Lector["tipocomic"].ToString(),
                            costo = Convert.ToDouble(Lector["costo"]),
                            editorial = Lector["editorial"].ToString(),
                            foto = Lector["foto"].ToString()
                        };
                    }
                };
                Conexion.Close();
            };
            return Respuesta;
        }

        public void Modificar(Comic Com)
        {
            using (SqlConnection Conexion = new SqlConnection(conexion))
            {
                Conexion.Open();
                using (SqlCommand Comando = new SqlCommand())
                {
                    //Una veez echo lo anterior (recureparar la informacion) se presentara dicha informacion el los textbox y al hacer una modificacion a la informacion se actualice
                    Comando.Connection = Conexion;
                    SqlParameter Parametro1 = new SqlParameter("@id", Com.id);
                    SqlParameter Parametro2 = new SqlParameter("@numepisodio", Com.numepisodio);
                    SqlParameter Parametro3 = new SqlParameter("@nombre", Com.nombre);
                    SqlParameter Parametro4 = new SqlParameter("@tipocomic", Com.tipocomic);
                    SqlParameter Parametro5 = new SqlParameter("@costo", Com.costo);
                    SqlParameter Parametro6 = new SqlParameter("@editorial", Com.editorial);
                    SqlParameter Parametro7 = new SqlParameter("@foto", Com.foto);

                    Comando.Parameters.Add(Parametro1);
                    Comando.Parameters.Add(Parametro2);
                    Comando.Parameters.Add(Parametro3);
                    Comando.Parameters.Add(Parametro4);
                    Comando.Parameters.Add(Parametro5);
                    Comando.Parameters.Add(Parametro6);
                    Comando.Parameters.Add(Parametro7);

                    Comando.CommandText = "update Comic set id=@id, numepisodio=@numepisodio, nombre=@nombre, tipocomic=@tipocomic, costo=@costo, editorial=@editorial, foto=@foto where id=@id";
                    Comando.ExecuteNonQuery();
                };
                Conexion.Close();
            };
        }
    }
}