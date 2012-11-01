// #define _DOTRACE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlitchText
{
    public partial class _Default : System.Web.UI.Page
    {
        private string submitPage = "ImageOutput"; // ImageGenerator

        protected void Page_Load(object sender, EventArgs e)
        {
            //Inject onload and unload
            HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("PageBody");
            body.Attributes.Add("onload", "doResize();"); // loadRaw(true);");
            body.Attributes.Add("onresize", "doResize()");

            //radioNormal.Attributes.Add("onload", "doResize();");
            //radioWillie.Attributes.Add("onload", "doResize();");

            if (!Page.IsPostBack)
            {
#if _DOTRACE
                System.Diagnostics.Trace.Write(DateTime.Now.ToString() + ": ");
                System.Diagnostics.Trace.WriteLine("TextEditor.aspx page_load event");
                System.Diagnostics.Trace.Flush();
#endif

                if (Session["imagePath"] == null)
                {
                    Response.Redirect("./");
                }
                ResetText();

                databox.Text = Session["rawData"].ToString();
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "DoResize", "doResize();", true);
        }

        //protected void ResetImage_Click(Object sender, EventArgs e)
        //{
        //    ResetText();
        //}

        protected void DrawPicture_Click(Object sender, EventArgs e)
        {
#if _DOTRACE
            System.Diagnostics.Trace.Write(DateTime.Now.ToString() + ": ");
            System.Diagnostics.Trace.WriteLine("Button clicked");
            System.Diagnostics.Trace.Flush();
#endif
            DrawImage();
        }

        private void DrawImage()
        {
#if _DOTRACE
            System.Diagnostics.Trace.Write(DateTime.Now.ToString() + ": ");
            System.Diagnostics.Trace.WriteLine("beginning translating / putting image into session");
            System.Diagnostics.Trace.Flush();
#endif
            if (radioNormal.Checked)
            {
                Session["currPicture"] = databox.Text;
            }
            else
            {
                Session["currPicture"] = TranslateBack(databox.Text, (int[])Session["pad"]);
            }
#if _DOTRACE
            System.Diagnostics.Trace.Write(DateTime.Now.ToString() + ": ");
            System.Diagnostics.Trace.WriteLine("completed translating / putting image into session");
            System.Diagnostics.Trace.Flush();
#endif
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ImageOutput", "window.open('" + submitPage + ".aspx?ex=" + Request.QueryString["ex"] + "');", true);
        }

        private void ResetText()
        {
            Converter converter = new Converter();
            string toSave = converter.EncodeWithStringUnicode(Session["imagePath"].ToString());
            Session["rawData"] = toSave;
            string willieData = BuildStringMatch(toSave);
            Session["willieData"] = willieData;
            Session["pad"] = BuildPad(willieData, toSave);
//            string pictureText = converter.EncodeWithStringUnicode(Session["imagePath"].ToString());
//            hfRawData.Value = pictureText;
//            hfWillie.Value = BuildStringMatch(hfRawData.Value);
//            ViewState.Add("pad",BuildPad(hfWillie.Value, hfRawData.Value)); // keep this one in viewstate just b/c it's easier, being ints rather than a string
        }

        private string BuildStringMatch(string dataText)
        {
            StringBuilder retString = new StringBuilder();

            while (retString.Length < dataText.Length)
            {
                retString.Append(Application["Eula"].ToString());
            }
            return retString.ToString().Substring(0, dataText.Length);
        }

        private int[] BuildPad(string translationText, string dataText)
        {
            if (translationText.Length != dataText.Length)
            {
                throw new ApplicationException("string lengths are not equal");
            }

            List<int> retList = new List<int>();

            for (int i = 0; i < translationText.Length; i++)
            {
                retList.Add((int)translationText[i] - (int)dataText[i]);
            }

            return retList.ToArray();
        }

        private string TranslateBack(string translationText, int[] pad)
        {
#if _DOTRACE
            System.Diagnostics.Trace.Write(DateTime.Now.ToString() + ": ");
            System.Diagnostics.Trace.WriteLine("in TraslateBack()");
            System.Diagnostics.Trace.Flush();
#endif
            StringBuilder retString = new StringBuilder();

            // get the smaller number of the two
            string rawData = Session["rawData"].ToString();
            int smallerNum = (translationText.Length < rawData.Length) ?
                translationText.Length :
                rawData.Length; 

            for (int i = 0, j = 0; i < rawData.Length; i++, j++)
            {
                if (j > translationText.Length) j = 0;

                retString.Append((char)((int)translationText[j] - (int)pad[i]));
            }

            //StringTest(retString, pad);

#if _DOTRACE
            System.Diagnostics.Trace.Write(DateTime.Now.ToString() + ": ");
            System.Diagnostics.Trace.WriteLine("completed TraslateBack()");
            System.Diagnostics.Trace.Flush();
#endif
            return retString.ToString();
        }

        /// <summary>
        /// Should be used in EULA mode with no changes to text, to make sure the translation still works
        /// </summary>
        /// <param name="retString"></param>
        /// <param name="pad"></param>
        private void StringTest(StringBuilder retString, int[] pad)
        {
            string rawData = Session["rawData"].ToString();

            for (int count = 0; count < retString.Length; count++)
            {
                if (rawData[count] != retString[count])
                {
                    throw new ApplicationException("invalid string: " + count.ToString() + ", " + rawData[count] + ", " + retString[count] + ", " + pad[count].ToString());
                }
            }
        }

        protected void ViewType_Click(Object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                if (((RadioButton)sender).ID == "radioWillie")
                {
                    databox.Text = Session["willieData"].ToString();
                }
                else
                {
                    databox.Text = Session["rawData"].ToString();
                }
            }
        }
    }
}




