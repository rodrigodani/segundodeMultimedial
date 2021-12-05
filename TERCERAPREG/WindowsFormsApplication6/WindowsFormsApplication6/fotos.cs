using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication6
{
    class fotos
    {
        static string cadenadebasededatos = @"Data Source=(localdb)\Projects;Initial Catalog=pregtres;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

        public static DataTable LeeDatos()
        {
            DataTable Listafotos = new DataTable();
            SqlConnection conn = new SqlConnection(cadenadebasededatos);
            SqlCommand com = new SqlCommand("select * from fotos;", conn);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(Listafotos);


            }
            catch (Exception e)
            {


            }
            finally
            {
                conn.Close();

            }

            return Listafotos;

        }

        public static DataTable cargarCapa(int codFoto, string color, string nombre)
        {
            bool exito = false;
            DataTable ultimo = new DataTable();
            SqlConnection conn = new SqlConnection(cadenadebasededatos);
            SqlCommand com = new SqlCommand("insert into capa (color,codfoto,nombre) values (@color,@codFoto,@nombre)", conn);
            com.Parameters.AddWithValue("@color", color);
            com.Parameters.AddWithValue("@codFoto", codFoto);
            com.Parameters.AddWithValue("@nombre", nombre);

            try
            {
                conn.Open();
                com.ExecuteNonQuery();
                SqlCommand com2 = new SqlCommand("SELECT @@IDENTITY As Ultimo", conn);
                SqlDataAdapter da = new SqlDataAdapter(com2);
                da.Fill(ultimo);
                exito = true;
            }
            catch (Exception e)
            {


            }
            finally
            {
                conn.Close();

            }

            return ultimo;

        }

        public static bool cargarPuntos(string codCapa, string punts)
        {
            bool exito = false;
            SqlConnection conn = new SqlConnection(cadenadebasededatos);
            SqlCommand com = new SqlCommand("insert into puntos (punts,codCapa) values (@punts,@codCapa)", conn);
            com.Parameters.AddWithValue("@punts", punts);
            com.Parameters.AddWithValue("@codCapa", codCapa);

            try
            {
                conn.Open();
                com.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception e)
            {


            }
            finally
            {
                conn.Close();

            }

            return exito;

        }

        public static DataTable subirfoto(string dir)
        {
            bool exito = false;
            SqlConnection conn = new SqlConnection(cadenadebasededatos);
            SqlCommand com = new SqlCommand("insert into fotos (url) values (@dir)", conn);
            com.Parameters.AddWithValue("@dir", dir);
            DataTable ultimo = new DataTable();

            try
            {
                conn.Open();
                com.ExecuteNonQuery();
                SqlCommand com2 = new SqlCommand("SELECT @@IDENTITY As Ultimo", conn);
                SqlDataAdapter da = new SqlDataAdapter(com2);
                da.Fill(ultimo);
                exito = true;
            }
            catch (Exception e)
            {


            }
            finally
            {
                conn.Close();

            }

            return ultimo;

        }

        public static bool eliminaCapasdeFoto(string codFoto)
        {
            bool exito = false;
            SqlConnection conn = new SqlConnection(cadenadebasededatos);
            SqlCommand com = new SqlCommand("delete from capa where codfoto = " + codFoto, conn);

            try
            {
                conn.Open();
                com.ExecuteNonQuery();
                exito = true;
            }
            catch (Exception e)
            {


            }
            finally
            {
                conn.Close();

            }

            return exito;

        }

        public static DataTable traerCapas(string codFoto)
        {
            DataTable Listafotos = new DataTable();
            SqlConnection conn = new SqlConnection(cadenadebasededatos);
            SqlCommand com = new SqlCommand("select c.cod, c.color, c.nombre,  c.codfoto, p.punts from capa c inner join puntos p on c.cod = p.codCapa where c.codfoto = @codFoto;", conn);
            com.Parameters.AddWithValue("@codFoto", codFoto);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(Listafotos);
            }
            catch (Exception e)
            {


            }
            finally
            {
                conn.Close();

            }

            return Listafotos;
        }

    }
}
