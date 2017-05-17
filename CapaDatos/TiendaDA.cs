using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class TiendaDA
    {
        public List<Tienda> Listar()
        {
            string sqlquery = "USP_GETTDA_PER_ACT";
            List<Tienda> list = null;            
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.conexion_data))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            list = new List<Tienda>();
                            while(dr.Read())
                            {
                                Tienda row = new Tienda();
                                row.COD_ENT= dr["cod_entid"].ToString();
                                row.DES_ENT = dr["des_entid"].ToString();
                                list.Add(row);
                            }
                        }
                    }
                }
            }
            catch
            {
                list = null;
            }
            return list;
        }
        public Tienda_Config Get(string codtda)
        {
            string sqlquery = "USP_GetConfig_TDA";
            Tienda_Config item = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.conexion_data))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cod_tda", codtda);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {                            
                            while(dr.Read())
                            {
                                item = new Tienda_Config();
                                string _codigo_interno = dr["codigo_interno"].ToString();
                                string _boleta = dr["boleta"].ToString();
                                string _factura = dr["factura"].ToString();
                                string _nc_boleta = dr["nc_boleta"].ToString();
                                string _nc_factura = dr["nc_factura"].ToString();                                
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
            catch
            {
                item = null;
            }
            return item;
        }
    }
}
