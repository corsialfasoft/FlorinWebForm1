using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlorinWebForm1 {
	public partial class Dettagio : System.Web.UI.Page {
		public Prodotto p  {get;set;}
		public string Message {get;set;}
		protected void Page_Load(object sender,EventArgs e) {
			DataAccessObject data = new DataAccessObject();
			Message="Ecco I tuoi Prodtti";
			string  c = Page.Request["id"] as string;
			int i = int.Parse(c); 
			p= data.CercaId(i);
			if(p==null){
				Response.Redirect("~/Ricerca.aspx?Messagge=Prodotto non trovato :(");
			}
			
		}

		protected void btnAddQuatita_Click(object sender,EventArgs e) {
			int qta ;
			if(int.TryParse(idQuantita.Text, out qta)){
				p.Quantita=qta;
				List<Prodotto> carrello =Session["products"] as List<Prodotto>;
				if(carrello==null){
					carrello= new List<Prodotto>();
					
				}
				carrello.Add(p);
				Session["products"]= carrello;
				Response.Redirect("~/Ricerca.aspx?Messagge=Prodotto aggiunto al carrello!");
			}else{
				Message="La quantita deve essere un valore numerico";
			}
		}
	}
}