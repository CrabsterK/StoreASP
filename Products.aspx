<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
        <meta name="keywords" content="pizza, salad, food, jedzenia, restauracja, nocna">    <!--TODO: keywords-->
        <meta name="description" content="Restauracja wysyłkowa z napojami, sałatkami, pizzą.">    <!--TODO: description-->
        <meta name="author" content="Arkadiusz Marcinowski, CrabsterK">
        <title>Menu</title>    <!--TODO: title-->
        <link href="css/general.css" rel="stylesheet" type="text/css">
</head>
<body>
      <a href ="Products.aspx">
            <img id="logo" alt="logo" src="img/pizza.png">
        </a>
        <a href ="Summary.aspx">
            <img id="track" alt="logo" src="img/track.png">
        </a>
        <a href ="user.html">
            <img id="user" alt="logo" src="img/user.png">
        </a>
        <a href ="search.html">
            <img id="search" alt="logo" src="img/search.png">
        </a>

            
        <header id="menu">
            <script src="js/menu.js"></script>
        </header>

        <section>
            <h2>Menu</h2>
            <article style="height: 900px; ">
           	  <br>


        <form id="form1" runat="server" class="nowyStyl1" >
            <asp:Label ID="testlabel" runat="server" Font-Size="Large" ForeColor="Crimson"></asp:Label>
            <asp:RadioButtonList ID="category_list" runat="server"  AutoPostBack="True"> </asp:RadioButtonList>
            <hr />          
                <asp:CheckBoxList ID="ziemniaki_list" runat="server" ></asp:CheckBoxList>    
                <asp:CheckBoxList ID="gwozdzie_list" runat="server" ></asp:CheckBoxList>
                <asp:CheckBoxList ID="choragiewki_list" runat="server" ></asp:CheckBoxList>
           
           Liczba produktów w koszyku:<asp:Label ID="number_of_products" runat="server"></asp:Label>
           
            <br />
           <asp:Button ID="buy_button" Text="Dodaj do koszyka" runat="server" OnClick="Buy_button_Click" />
             <br />
           <asp:CheckBoxList ID="lista" runat="server" ></asp:CheckBoxList>
             <br />
           <asp:Button ID="clear" Text="Wyczyść koszyk" runat="server" OnClick="delete" AutoPostBack = "true" />
            <br />
           <asp:HyperLink ID="link" runat="server" Text="Przejdź do koszyka" NavigateUrl="Summary.aspx"></asp:HyperLink>

    </form>
</body>
</html>
