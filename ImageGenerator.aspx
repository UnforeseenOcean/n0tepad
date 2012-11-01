<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ImageGenerator.aspx.cs" Inherits="GlitchText.ImageGenerator" Title="Image Output" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        #divLoading, #imagePane
        {
            color: #AA0000;
            font-size: 250%;
            position: absolute;
            left: 20px;
            top: 20px;
        }
        #divLoading H3
        {
            color: #AA0000;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function ClearLoading() {
            var ldiv = document.getElementById("divLoading");
            ldiv.style.visibility = "hidden";
        }
    </script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="divLoading"><h3>Loading...</h3></div>
    <div class="genImage" id="imagePane">
        <img src="ImageOutput.aspx?ex=<%= Request.QueryString["ex"] %>" onload="ClearLoading();" />
    </div>
</asp:Content>
