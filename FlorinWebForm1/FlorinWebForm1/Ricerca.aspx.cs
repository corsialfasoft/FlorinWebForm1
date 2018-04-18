using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlorinWebForm1 {
	public partial class Ricerca : Page {
		public string Message {get;set;}
		public TextBox test {get;set;}
		public Prodotto p {get;set;}
		public List<Prodotto> Prodotti {get;set;}
		public TableRow row {get;set;}
		protected void Page_Load(object sender,EventArgs e) {
			test = new TextBox();
			p= new Prodotto();
			Message=Request["Messagge"];
			row= new TableRow();
		}
		public void Cerca(object sender,EventArgs e){
			DataAccessObject data = new DataAccessObject();
			int id;
			if(int.TryParse(idText.Text , out id)){
				Page.Session["id"]=id.ToString();
				Response.Redirect( string.Format($"~/Dettagio.aspx?id= {id}"));
			}else if(DescrText.Text!=null && DescrText.Text!=""){
				Prodotti = data.CercaDescrizione(DescrText.Text);
				if(Prodotti!=null){
					foreach(Prodotto p in Prodotti){
						TableRow tr = new TableRow();
						TableCell tcCodice = new TableCell();
						tcCodice.Controls.Add(new Label() {Text=p.ID.ToString() , CssClass ="col-xs-2"} );
						tr.Cells.Add(tcCodice);
						TableCell tcDescr = new TableCell();
						tcDescr.Controls.Add(new Label() {Text= p.Descr , CssClass="col-xs-6"});
						tr.Cells.Add(tcDescr);
						TableCell tcQuantita = new TableCell();
						tcQuantita.Controls.Add(new Label() {Text=p.Quantita.ToString() , CssClass="col-xs-2"});
						tr.Cells.Add(tcQuantita);
						TableCell tcDettagli = new TableCell();
						tcDettagli.Controls.Add( new Button {Text="Dettagli" , PostBackUrl=$"~/Dettagio.aspx?id={p.ID.ToString()}"});
						tr.Cells.Add(tcDettagli);
						Table1.Rows.Add(tr);
					}
					Message="Ecco I Prodotti cercati!";
				}else{
					Prodotti=new List<Prodotto>();
					Message=" Non ho trovato nessun prodotto :(";
				}
			}else{
				Message= " Parametri errati";
			}
			
		
			
		}

		protected void Unnamed_Click(object sender,EventArgs e) {
				string c = Page.Session["id"] as string;
				int id ;
				
			if(int.TryParse(c , out id)){
				
				Response.Redirect( string.Format($"~/Dettagio.aspx?id= {id}"));
			}
		}
	}
}