using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlorinWebForm1 {
	public partial class Carrello : System.Web.UI.Page {
		public List<Prodotto> products {get;set;}
		public string Message {get;set;}

		protected void Page_Load(object sender,EventArgs e) {
			products= Session["products"] as List<Prodotto>;
			Message=Page.Request["Messagge"];

			if(products==null){
				products= new List<Prodotto>();
				if(Message==null){
					Message="Il carrello é vuoto!";
				}
			}
		}

		protected void btnSendRequest_Click(object sender,EventArgs e) {
			DataAccessObject data = new DataAccessObject();
			data.SendRequest(products);
			Session.RemoveAll();
			Response.Redirect("~/Ricerca.aspx?Messagge=Ordine Inviato Con Successo!");

		}

		protected void btnPulisci_Click(object sender,EventArgs e) {
			Session.RemoveAll();
			Message="Carrello Svuotato!";
			Response.Redirect("~/Carrello.aspx?Messagge=Carrello Svuotato Con Successo");
		}
	}
}