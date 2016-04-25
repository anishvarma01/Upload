using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Upload
{
    public partial class Display : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String An = ConfigurationManager.ConnectionStrings["Anish"].ConnectionString;
            using (SqlConnection con = new SqlConnection(An))
            {
                SqlCommand cmd = new SqlCommand("spGetImageId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paraId = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = Request.QueryString["Id"]
                };
                cmd.Parameters.Add(paraId);
                con.Open();
                byte[] bytes =(byte[])cmd.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                IMG1.ImageUrl = "data:Image/png," + strBase64;
                
            }

            }
    }
}