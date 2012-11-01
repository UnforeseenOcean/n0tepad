<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GlitchText.Default" MasterPageFile="~/Site.master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <title>n0tepad</title>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h1>n0tepad</h1>
        <br />
        <a href="About.aspx">About</a>
        <br /><br />
        <a href="SampleImages.aspx">Sample Images</a>
        <br /><br /><br /><br />
        <div style="border: 1px solid #666666; width: 700px; margin: 10px; text-align: center"><div style="border: 5px solid #EEEEEE; width: 680px; margin: 5px; text-align: center"><div style="margin: 30px;">
        Upload your picture! (up to 200k) 
        <asp:FileUpload id="FileUploadControl" runat="server" />
       <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" /><br />
       <asp:Label ID="StatusLabel" runat="server"></asp:Label>
       </div></div></div>
    </div>
</asp:Content>
