using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlitchText
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSubmit_Click(Object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg" ||
                        FileUploadControl.PostedFile.ContentType == "image/pjpeg" ||
                        FileUploadControl.PostedFile.ContentType == "image/gif" ||
                        FileUploadControl.PostedFile.ContentType == "image/png")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 204800) // 102400)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);

                            string extension = "";
                            if (FileUploadControl.PostedFile.ContentType == "image/jpeg" ||
                                FileUploadControl.PostedFile.ContentType == "image/pjpeg")
                            {
                                extension = "jpeg";
                            }
                            else if (FileUploadControl.PostedFile.ContentType == "image/gif")
                            {
                                extension = "gif";
                            }
                            if (FileUploadControl.PostedFile.ContentType == "image/png")
                            {
                                extension = "png";
                            }

                            string path = Server.MapPath("~/SessionImages/" + Session.SessionID + "." + extension);
                            FileUploadControl.SaveAs(path);
                            Session["imagePath"] = path;
                            Response.Redirect("TextEditor.aspx?ex=" + extension);
                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 200k !";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only GIF, JPEG, or PNG files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
    }
}