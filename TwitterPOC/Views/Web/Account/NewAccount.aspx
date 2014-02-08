<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Shared/Site.Master" AutoEventWireup="true"
    CodeBehind="NewAccount.aspx.cs" Inherits="Views.Web.Account.NewAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Create New Account" CssClass="titleblack" />
    <p>
        <asp:Label ID="lblName" runat="server" Text="Name" />
        <asp:TextBox ID="txtName" runat="server" />
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName"
            ValidationGroup="Account" />
    </p>
    <p>
        <asp:Label ID="lblUsr" runat="server" Text="Username" />
        <asp:TextBox ID="txtUsr" runat="server" />
        <asp:RequiredFieldValidator ID="rfvUser" runat="server" ErrorMessage="*" ControlToValidate="txtUsr"
            ValidationGroup="Account" />
    </p>
    <p>
        <asp:Label ID="lblPass" runat="server" Text="Password" />
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator ID="rfvPass" runat="server" ErrorMessage="*" ControlToValidate="txtPass"
            ValidationGroup="Account" />
    </p>
    <p>
        <asp:Label ID="lblCPass" runat="server" Text="Confirm Password" />
        <asp:TextBox ID="txtCPass" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator ID="rfvPass2" runat="server" ErrorMessage="*" ControlToValidate="txtCPass"
            ValidationGroup="Account" />
        <asp:CompareValidator ID="cfvPass" runat="server" 
            ErrorMessage="Password Diferents" ControlToCompare="txtPass" 
            ControlToValidate="txtCPass"/>
    </p>
    
    <p>
        <asp:Label ID="lblGender" runat="server" Text="Gender" />
        <asp:DropDownList ID="ddlGender" runat="server">
            <asp:ListItem Value="0">Female</asp:ListItem>
            <asp:ListItem Value="1">Male</asp:ListItem>
        </asp:DropDownList>
    </p>
    <asp:Button ID="btnNewAccount" runat="server" Text="Create Account" OnClick="btnNewAccount_Click" ValidationGroup="Account" />
</asp:Content>
