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
    public class CuponesDA
    {
        public List<Cupones> Listar(int pageIndex, int pageSize, ref int pageCount, string _Buscar)
        {
            string sqlquery = "[USP_ListaCuponesBA_Pag]";
            List<Cupones> List = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.conexion_data))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {
                        
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StartIndex", pageIndex);
                        cmd.Parameters.AddWithValue("@PageSize", pageSize);
                        cmd.Parameters.AddWithValue("@buscar", _Buscar);                        

                        SqlParameter parTotalCount= new SqlParameter("@TotalCount", SqlDbType.Int);
                        parTotalCount.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(parTotalCount);
                      
                         SqlDataReader dr = cmd.ExecuteReader();

                     
                        if (dr.HasRows)
                        {
                            List = new List<Cupones>();
                            while (dr.Read())
                            {
                                Cupones row = new Cupones();
                                row.CODE = dr["CODE-128"].ToString();
                                row.CORRELATIVO = dr["CORRELATIVO"].ToString();
                                row.BARRA = dr["BARRA"].ToString();
                                row.NOMAPE = dr["NOMAPE"].ToString();
                                row.EMAIL = dr["EMAIL"].ToString();
                                row.DNI = dr["DNI"].ToString();
                                row.ESTADO = dr["EST_DESCRIPCION"].ToString();
                                row.PORC_DESC =(decimal)dr["PORC_DESCUENTO"];
                                row.FEC_EMI =Convert.ToDateTime(dr["FECHA_EMISION"]);
                                row.FEC_FIN =Convert.ToDateTime(dr["FECHA_CADUCADO"]);
                                row.PARES_MAX =(int) dr["PARES_MAX"];
                                row.CAMPA = dr["GRUPO"].ToString();
                                row.MONTO_VALE =(decimal)dr["MONTOVALE"];
                                row.EST_ID= dr["EST_ID"].ToString();
                                List.Add(row);
                            }
                            
                        }
                        dr.Close();
                        pageCount = Convert.ToInt32(parTotalCount.Value);
                    }
                }
            }
            catch(Exception exc)
            {
                List = null;
            }
            return List;
        }
    }
}
