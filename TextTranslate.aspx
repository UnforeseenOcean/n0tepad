<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextTranslate.aspx.cs" Inherits="GlitchText.TextTranslate" MasterPageFile="~/Site.master" validateRequest=false %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div style="float: left; margin: 10px; vertical-align: top; text-align: center">
        <img src="dot_yawn.jpg" /><br />
    </div>
    <div style="float: left; margin: 10px; vertical-align: top; text-align: center">
        <asp:TextBox ID="databox" runat="server" Width="600" Height="600" TextMode="multiline"></asp:TextBox><br />
        <asp:Button ID="ResetData" runat="server" Text="Reset Data" OnClick="ResetData_Click" /> &nbsp;
        <asp:Button ID="submit" runat="server" Text="Change Picture" OnClick="DrawPicture_Click" />
    </div>
    <div style="float: left; margin: 10px; vertical-align: top; text-align: center">
        <asp:Image ID="resultImage" runat="server" />
    </div>
</asp:Content>
