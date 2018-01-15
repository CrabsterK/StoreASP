using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cena.Text = "Całkowita wartość zamówienia: " + ((Hashtable)Session["order_details"])["cost"].ToString() +" zł";
        dostawa.Text = "Sposób dostawy: " + ((Hashtable)Session["order_details"])["delivery"].ToString();
        platnosc.Text = "Sposób płatności: " + ((Hashtable)Session["order_details"])["payment"].ToString();

        Session["basket"] = null;
        Session["order_details"] = null;
    }
}