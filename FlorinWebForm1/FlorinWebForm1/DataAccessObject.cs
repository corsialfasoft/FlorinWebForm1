using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace FlorinWebForm1 {
	public class Prodotto{
		public int		ID			{get;set;}
		public string	Descr		{get;set;}
		public int		Quantita	{get;set;}
		public override string ToString() {
			return $"id = {this.ID.ToString()} Descrizione = {this.Descr.ToString()} Quantita = {this.Quantita.ToString()}";
		}
	}
	public class DataAccessObject {
		private string GetStringBuilder() {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(localdb)\MSSQLLocalDB";
            builder.InitialCatalog = "RICHIESTE";
            return builder.ToString();
        }

		internal void SendRequest(List<Prodotto> products) {
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			try{
				connection.Open();
				string sql = $"insert into RichiesteSet (data) values ('{DateTime.Now.ToString("yyyy/MM/dd")}');";
				SqlCommand command1= new SqlCommand(sql,connection);
				command1.ExecuteNonQuery();
				command1.Dispose();
				foreach(Prodotto p in products){
					SqlCommand command = new SqlCommand("SendRequest",connection);
					command.CommandType=System.Data.CommandType.StoredProcedure;
					command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value= p.ID;
					command.Parameters.Add("@qta",System.Data.SqlDbType.Int).Value= p.Quantita;
					command.ExecuteNonQuery();
					command.Dispose();
				}
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}

		public Prodotto CercaId(int id){
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			try{
				Prodotto p = null;
				connection.Open();
				SqlCommand command = new SqlCommand("CercaId",connection);
				command.CommandType=System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@ID" , System.Data.SqlDbType.Int).Value=id;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()){
					p=  new Prodotto();
					p.ID= reader.GetInt32(0);
					p.Descr=reader.GetString(1);
					p.Quantita= reader.GetInt32(2);
				}
				reader.Close();
				command.Dispose();
				return p;
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}
		public List<Prodotto> CercaDescrizione(string descr){
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			try{
				
				List<Prodotto> res = new List<Prodotto>();
				connection.Open();
				SqlCommand command = new SqlCommand("CercaDescr",connection);
				command.CommandType=System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@Descr" , System.Data.SqlDbType.NVarChar).Value=descr;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()){
					Prodotto p = new Prodotto();
					p.ID= reader.GetInt32(0);
					p.Descr=reader.GetString(1);
					p.Quantita= reader.GetInt32(2);
					res.Add(p);
				}
				reader.Close();
				command.Dispose();
				if(res.Count<=0){
					return null;
				}else{
					return res;
				}
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}
	
	}
}