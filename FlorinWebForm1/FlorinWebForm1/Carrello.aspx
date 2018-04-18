<%@ Page Language="C#"
    AutoEventWireup="true" 
    CodeBehind="Carrello.aspx.cs" 
    Inherits="FlorinWebForm1.Carrello" 
     MasterPageFile="~/Site.Master" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %> </h1>
    
    <h2><%=Message %></h2>
         <div>
             <ul class="list-group">
            <%foreach(var p in products ){%>
                <li>
                <label>ID</label>
                <%=p.ID%>
                 <label>Descrizione</label>
                <%=p.Descr%>
                 <label>Giacenza</label>
                <%=p.Quantita%>
                </li>
             <%} %>
            </ul>
         </div>
    <div class="container">
        <asp:Button ID="btnSendRequest" Text="Invia Richiesta" OnClick="btnSendRequest_Click" runat="server" />
        <asp:Button ID="btnPulisci" Text="Pulisci" OnClick="btnPulisci_Click" runat="server" />
    </div>
</asp:Content>
