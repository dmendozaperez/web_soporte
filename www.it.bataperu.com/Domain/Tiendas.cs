using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace www.it.bataperu.com.Domain
{
    public class Tiendas
    {

        public Config_Correlativo _get_correlativoTDA(string codtda)
        {
            string sqlquery = "USP_GetConfig_TDA";
            Config_Correlativo item = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.conexion_data))
                {
                    if (cn.State == 0) cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cod_tda", codtda);
                        SqlDataReader sqlreader = cmd.ExecuteReader();
                        if(sqlreader.HasRows)
                        {
                            while(sqlreader.Read())
                            {
                                string _codigo_interno = sqlreader["codigo_interno"].ToString();
                                string _boleta = sqlreader["boleta"].ToString();
                                string _factura = sqlreader["factura"].ToString();
                                string _nc_boleta = sqlreader["nc_boleta"].ToString();
                                string _nc_factura = sqlreader["nc_factura"].ToString();
                                item = new Config_Correlativo();
                                item.CODIGO_INTERNO = _codigo_interno;
                                item.BOLETA = _boleta;
                                item.FACTURA = _factura;
                                item.NCBOLETA = _nc_boleta;
                                item.NCFACTURA = _nc_factura;
                            }
                        }
                    }
                }

            }
            catch(Exception exc)
            {
                item = null;
            }
            return item;
        }
        public List<Select_Tiendas> _get_tiendas()
        {
            string sqlquery = "USP_GETTDA_PER_ACT";
            List<Select_Tiendas> data_select = new List<Select_Tiendas>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.conexion_data))
                {
                    if (cn.State == 0) cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader sqlread = cmd.ExecuteReader();

                        if (sqlread.HasRows)
                        {
                            while (sqlread.Read())
                            {
                                Select_Tiendas item = new Select_Tiendas();
                                item.COD_ENT = sqlread["cod_entid"].ToString();
                                item.DES_ENT = sqlread["des_entid"].ToString();
                                data_select.Add(item);
                            }
                        }
                        
                    }

                }

            }
            catch
            {
                data_select = null;
            }
            return data_select;
        }
    }
    public class Select_Tiendas
    {
        public string COD_ENT { get; set; }
        public string DES_ENT { get; set; }
    }
    public class Config_Correlativo
    {       
        public string CODIGO_ERROR { get; set; }
        public string CODIGO_INTERNO { get; set; }
        public string BOLETA { get; set; }
        public string FACTURA { get; set; }
        public string NCBOLETA { get; set; }
        public string NCFACTURA { get; set; }
    }
}