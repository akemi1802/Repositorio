<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSearchTweet.ascx.cs"
    Inherits="Views.Web.Search.ucSearchTweet" %>
<p>
    <asp:Label ID="LblSearch" runat="server" Text="Search" CssClass="subtitle" />
    <asp:TextBox ID="txtSearch" runat="server" />
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
</p>
<p>
    <asp:Panel ID="pnlSearch" runat="server" ScrollBars="Vertical" Height="300" Width="350">
        <asp:DataList ID="dtlSearch" runat="server">
            <ItemTemplate>
                    <p>
                    <asp:HyperLink runat="server" ID="hplSearch" Text='<%# Bind("ITEM1") %>'
                    NavigateUrl='<%#String.Format("~/Web/Profile/User.aspx?id={0}", Eval("ITEM2"))%>' />
                    </p>
                    
                

            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
</p>
