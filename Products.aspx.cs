using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : System.Web.UI.Page
{
    HashSet<string> categories_set;
    Hashtable ziemniaki;
    Hashtable gwozdzie;
    Hashtable choragiewki;
    CheckBoxList curent;
    Hashtable basket;
    Hashtable selected;

    protected void Page_Load(object sender, EventArgs e)
    {

        FillLists();
        if (!IsPostBack)
        {
            if (Session["basket"] == null)
            {
                Session["basket"] = new Hashtable();
            }
            
            SetCategoriesList();
            SetProductsList(ziemniaki, ziemniaki_list);         //przypisywanie do ID CheckBoxList
            SetProductsList(gwozdzie, gwozdzie_list);           //przypisywanie do ID CheckBoxList
            SetProductsList(choragiewki, choragiewki_list);     //przypisywanie do ID CheckBoxList
        }

        basket = (Hashtable) Session["basket"];
        number_of_products.Text = basket.Count.ToString();      //to jest label ilości w koszyku

        if (category_list.SelectedItem != null)                 //jeśli jest wybrana kategoria
        {
            testlabel.Text = "Kategoria: " + category_list.SelectedValue.ToString();    //label wybranej kategorii
            testlabel.Visible = true;
            gwozdzie_list.Visible = choragiewki_list.Visible = ziemniaki_list.Visible = false;

            if (category_list.SelectedValue.ToString() == "Ziemniaki")          //wyświetlam produkty danej kategorii
            {
                ziemniaki_list.Visible = true;
                curent = ziemniaki_list;
            }
            else if (category_list.SelectedValue.ToString() == "Gwozdzie")
            {
                gwozdzie_list.Visible = true;
                curent = gwozdzie_list;
            }
            else if (category_list.SelectedValue.ToString() == "Choragiewki")
            {
                choragiewki_list.Visible = true;
                curent = choragiewki_list;
            }
        }

        if (curent != null)         //jeśli wyświetlone są produkty to można kupować
        {
            buy_button.Visible = true;
        }
        else
        {
            buy_button.Visible = false;
        }
    }




    private void SetCategoriesList()
    {

        category_list.DataSource = categories_set;
        category_list.DataBind();
        category_list.DataTextField = "categoryID";
        category_list.DataValueField = "categoryValue";
    }

    private void SetProductsList(Hashtable hashtable, CheckBoxList chb_list)
    {
        foreach (DictionaryEntry pair in hashtable)
        {
            chb_list.Items.Add(pair.Key.ToString());
        }
        
        chb_list.Visible = false;

        foreach (ListItem item in chb_list.Items)
        {
            String name = item.Value;
            item.Text = name + " " + hashtable[name];
            item.Value = name;
        }
    }

    private void FillLists()
    {
        categories_set = new HashSet<string>();
        categories_set.Add("Ziemniaki");
        categories_set.Add("Gwozdzie");
        categories_set.Add("Choragiewki");

        ziemniaki = new Hashtable();
        ziemniaki.Add("ziemniaki z ziemi", 12);
        ziemniaki.Add("ziemniaki nie z ziemi", 15);
        ziemniaki.Add("ziemniaki czyste", 24);
        ziemniaki.Add("ziemniaki pobrudzone", 65);


        gwozdzie = new Hashtable();
        gwozdzie.Add("gwoździe stalowe", 8);
        gwozdzie.Add("gwoździe miedziane", 9);
        gwozdzie.Add("gwoździe z ziemniaków", 12);


        choragiewki = new Hashtable();
        choragiewki.Add("Chorągiewka francuska biała", 8);
        choragiewki.Add("Chorągiewka bez nadruku", 9);
        choragiewki.Add("Chorągiewka Nowa Huta", 32);


        selected = new Hashtable();
    }

    protected void Buy_button_Click(object sender, EventArgs e)
    {
        foreach (ListItem item in curent.Items)
        {
            if (item.Selected)
            {
                int price = 0;

                if (category_list.SelectedValue.ToString() == "Ziemniaki")
                {
                    price = (int)ziemniaki[item.Value];
                }
                else if (category_list.SelectedValue.ToString() == "Gwozdzie")
                {
                    price = (int)gwozdzie[item.Value];
                }
                else if (category_list.SelectedValue.ToString() == "Choragiewki")
                {
                    price = (int)choragiewki[item.Value];
                }

                basket[item.Value] = price;
                number_of_products.Text = basket.Count.ToString();
            }
        }

        lista.DataSource = selected;
        lista.DataBind();
        lista.Visible = true;
    }

    protected void delete(object sender, EventArgs e)
    {
        Session["basket"] = new Hashtable();
        basket = (Hashtable)Session["basket"];
        number_of_products.Text = basket.Count.ToString();
    }
}
