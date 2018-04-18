<%@ Page Title="Contact" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Ricerca.aspx.cs"
    Inherits="FlorinWebForm1.Ricerca" 
    %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2> Pagina di Ricerca</h2>
    <h3 class="alert alert-info"><%=Message%></h3>
    <div class="Container">
        <div>
            <label >ID</label>
            <asp:TextBox ID="idText" runat="server"></asp:TextBox>
             <label >Descrizione</label>
            <asp:TextBox ID="DescrText" runat="server"></asp:TextBox>
            <asp:Button OnClick="Cerca" Text="Cerca" runat="server" />
        </div>
    </div>
    <div class="Table">
        <asp:Table ID="Table1" CellPadding="10" Width="100%" GridLines="Both" runat="server" HorizontalAlign="Center">

        </asp:Table>
    </div>

      
</asp:Content>
