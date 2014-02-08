<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTweeet.ascx.cs" Inherits="Views.Web.Profile.ucTweeet" %>
<p><asp:Label ID="lblTweet" runat="server" Text="Post Tweet"/>
</p>
<p>
<asp:TextBox ID="txtTweet" runat="server" TextMode="MultiLine" CssClass="txtboxG"/>
</p>
<asp:Button ID="btnPostTweet" runat="server" Text="Submit" 
    onclick="btnPostTweet_Click" />