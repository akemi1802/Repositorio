<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogin.ascx.cs" Inherits="Views.Web.Shared.UserControls.ucLogin" %>


<div class="bgLogin">
<asp:Label ID="lblUser" runat="server" Text="Username"/>
<asp:TextBox ID="txtUser" runat="server" CssClass="txtboxP"/>
<asp:Label ID="lblPassword" runat="server" Text="Password"/>
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="txtboxP" />
<asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" />
<asp:Button ID="btnJoin" runat="server" Text="Join" onclick="btnJoin_Click" />
</div>