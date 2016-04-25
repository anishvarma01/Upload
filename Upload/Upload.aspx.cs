using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace Upload
{
    public partial class Upload : System.Web.UI.Page
    {
        public object ConfigurationMangager { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Lbl.Visible = false;
                HyperLink1.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile=FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;

            if(fileExtension.ToLower()==".jpg"|| fileExtension.ToLower()==".mp4"||fileExtension.ToLower()==".gif")
                {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
               byte[] bytes= binaryReader.ReadBytes((int)stream.Length);
                String An = ConfigurationManager.ConnectionStrings["Anish"].ConnectionString;
                using (SqlConnection con = new SqlConnection(An))
                {
                    SqlCommand cmd = new SqlCommand("spUploadImage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paraname = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = filename
                    };
                    cmd.Parameters.Add(paraname);
                    SqlParameter paraSize = new SqlParameter()
                    {
                        ParameterName = "@Size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(paraSize);
                    SqlParameter paraImageData = new SqlParameter()
                    {
                        ParameterName = "@ImageData",
                        Value = bytes
                    };
                    cmd.Parameters.Add(paraImageData);
                    SqlParameter paraNewId = new SqlParameter()
                    {
                        ParameterName = "@NewID",
                        Value = -1,
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paraNewId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Lbl.Visible = true;
                    Lbl.Text = "Successful";
                    Lbl.ForeColor = System.Drawing.Color.Green;
                    HyperLink1.Visible = true;
                    HyperLink1.NavigateUrl = "~/Display.aspx?Id=" + cmd.Parameters["@NewID"].Value.ToString();
                }

            }

            else
            {
                Lbl.Visible = true;
                Lbl.Text = "only";
                Lbl.ForeColor = System.Drawing.Color.Red;
                HyperLink1.Visible = false;

            }
        }

    }
}