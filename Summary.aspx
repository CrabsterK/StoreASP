<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Summary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
        <meta name="keywords" content="pizza, salad, food, jedzenia, restauracja, nocna">    <!--TODO: keywords-->
        <meta name="description" content="Restauracja wysyłkowa z napojami, sałatkami, pizzą.">    <!--TODO: description-->
        <meta name="author" content="Arkadiusz Marcinowski, CrabsterK">
        <title>Finalizacja</title>    <!--TODO: title-->
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
    
            <h2>Finalizacja</h2>
            
            <article style="height: 900px; ">
           	  <br>


        <form id="form1" runat="server" class="nowyStyl1">
                <asp:ListBox ID="selected" runat="server" Width="250px" Height="100px" ></asp:ListBox>
                <asp:Label ID="isempty" runat ="server"></asp:Label>
            <br />
              <asp:Label ID="price" runat ="server"></asp:Label>
            <br />
                <asp:Label ID="summary" runat ="server"></asp:Label>

            <br />
                
            <br /><br /><br />
            <asp:Label ID="delivery_label" runat ="server">Wybierz sposób dostawy</asp:Label>
            <asp:RadioButtonList ID="delivery_list" runat="server"  AutoPostBack="True"> </asp:RadioButtonList>
           
            
             <br /><br /><br />
             <asp:Label ID="payment_label" runat ="server">Wybierz sposób płatności</asp:Label>
             <asp:RadioButtonList ID="payment_list" runat="server"> </asp:RadioButtonList>

            <br /><br />
           
              
            <asp:Button ID="order_button" Text="Złóż zamówienie" runat="server"  OnClick="Order_button_Click"/>
            <br />
            <asp:HyperLink ID="link" runat="server" Text="Kontynuuj zakupy" NavigateUrl="Products.aspx"></asp:HyperLink>

    </form>
</body>
</html>
