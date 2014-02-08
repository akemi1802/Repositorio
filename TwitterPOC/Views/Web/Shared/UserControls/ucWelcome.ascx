<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucWelcome.ascx.cs" Inherits="Views.Web.Shared.UserControls.ucWelcome" %>
<div class="bgLogin">
    <asp:Label ID="lblWelcome" runat="server" Text="Welcome" />
    <asp:HyperLink ID="hplProfile" runat="server" NavigateUrl="~/Web/Profile/Profile.aspx" Text="My Profile" />
    <asp:Button ID="btnLogoff" runat="server" Text="Logoff" OnClick="btnLogoff_Click" />
</div>
