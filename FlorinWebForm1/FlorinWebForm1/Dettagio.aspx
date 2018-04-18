<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="Dettagio.aspx.cs" 
    Inherits="FlorinWebForm1.Dettagio" 
    MasterPageFile="~/Site.Master"
%>



<asp:Content runat="server" ContentPlaceHolderID="MainContent">

        <div id="form1" ">
        <div class="alert alert-success" role="alert">
            <div>
                <label>ID</label>
                <%=p.ID%>
            </div>
            <div>
                 <label>Descrizione</label>
                <%=p.Descr%>
            </div>
            <div>
                 <label>Giacenza</label>
                <%=p.Quantita%>
            </div>
        </div>
        <div>
             Inserisci la quantità da ordinare 
        </div>
        <div class="container">

            <label >Quantita</label>
            <asp:TextBox ID="idQuantita" runat="server" Height="45px" Width="224px"></asp:TextBox>
            <asp:Button ID="btnAddQuatita" OnClick="btnAddQuatita_Click" BackColor="PowderBlue"  runat="server"/>
        </div>
    </div>

</asp:Content>
