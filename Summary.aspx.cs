using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Summary : System.Web.UI.Page
{

    Hashtable delivery;
    List<string> payment;
    Hashtable basket;
    int cost = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        FillList();
        if (!IsPostBack)
        {
            payment_list.DataSource = payment;
            payment_list.DataBind();
            payment_list.SelectedIndex = 1;

            SetDeliveryList(delivery, delivery_list);
            delivery_list.SelectedIndex = 1;

            basket = ((Hashtable)Session["basket"]);
            if (basket != null && basket.Count != 0)
            {
                foreach (string keyName in basket.Keys)
                {
                    selected.Items.Add(keyName + " " + (int)basket[keyName]);

                }
            }
            else
            {
                isempty.Text = "Koszyk pusty!";
                selected.Visible = false;
            }

        }

        basket = ((Hashtable)Session["basket"]);
        cost = CountPrice(basket);
        summary.Text = "Całkowita kwota do zapłaty: " + cost.ToString();

        SetVisibility(basket.Count);//jak koszyk pusty to nie widać dostawy, płatności, ceny itp...
    }

    private void SetVisibility(int amount)
    {
        if (amount != 0)
        {
            order_button.Visible = true;
            delivery_list.Visible = true;
            payment_list.Visible = true;
            price.Visible = true;
            summary.Visible = true;
            payment_label.Visible = true;
            delivery_label.Visible = true;

        }
        else
        {
            order_button.Visible = false;
            delivery_list.Visible = false;
            payment_list.Visible = false;
            price.Visible = false;
            summary.Visible = false;
            payment_label.Visible = false;
            delivery_label.Visible = false;
        }
    }

    private void FillList()
    {
        delivery = new Hashtable { { "Dostawca", 15 }, {"Poczta", 10 }, {"Odbiór osobisty", 0} };
        payment = new List<string> { "Karta płatnicza", "Przelew", "Przy odbiorze"};
    }

    private void SetDeliveryList(Hashtable hashtable, RadioButtonList rb_list)
    {
        foreach (DictionaryEntry pair in hashtable)
        {
            rb_list.Items.Add(pair.Key.ToString());
        }

        foreach (ListItem item in rb_list.Items)
        {
            String name = item.Value;
            item.Text = name + " " + hashtable[name];
            item.Value = name;
        }
    }

    private int CountPrice(Hashtable basket)
    {
        int products_price = 0;
        int sum = 0;
        int cur_price = 0;

        foreach (string keyName in basket.Keys)
        {
            cur_price = (int)basket[keyName];
            products_price += cur_price;
        }
        price.Text = "Wartość produktów w koszyku: " + products_price.ToString();

        sum = products_price;
        sum += (int)delivery[delivery_list.SelectedValue];

        return sum;
                                 
    }

    private string Get_Selected(RadioButtonList rbl)
    {
        return rbl.SelectedValue;
    }



    protected void Order_button_Click(object sender, EventArgs e)
    {
        Hashtable order_details = new Hashtable();
        order_details.Add("cost", cost);
        order_details.Add("delivery", Get_Selected(delivery_list));
        order_details.Add("payment", Get_Selected(payment_list));

        Session["order_details"] = order_details; //Zapisuje cene  do sesji
        Response.Redirect("Order.aspx");    
    }
}