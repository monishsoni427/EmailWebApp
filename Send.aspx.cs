﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class Send : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection con;
    SqlDataAdapter ad;
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
        string email = Session["emailValue"].ToString();

       
            string s = "select *from Compose where sfrom='" + email + "' order by Time desc ";
            ad = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            r1.DataSource = ds;
            r1.DataBind();
        
    }
    protected void DeleleMail_Btn(object sender, CommandEventArgs e)
    {
        string id = e.CommandName;
        string query = "delete from Compose where id = '" + id + "'";
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        Response.Redirect("Send.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}