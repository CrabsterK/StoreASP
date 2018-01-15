<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
        <meta name="keywords" content="pizza, salad, food, jedzenia, restauracja, nocna">    <!--TODO: keywords-->
        <meta name="description" content="Restauracja wysyłkowa z napojami, sałatkami, pizzą.">    <!--TODO: description-->
        <meta name="author" content="Arkadiusz Marcinowski, CrabsterK">
        <title>Koszyk</title>    <!--TODO: title-->
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
    
            <h2>Koszyk</h2>
            
            <article style="height: 900px; ">
           	  <br>


        <form id="form1" runat="server" class="nowyStyl1">
           <asp:Label ID ="cena" runat ="server"></asp:Label>
            <br />
            <asp:Label  ID="dostawa" runat="server"></asp:Label>
            <br />
           <asp:Label ID ="platnosc" runat ="server"></asp:Label>
            <br />
                  
            <h1 style="text-align: center;"><br><br>Dziękujemy! <br><br> Realizacja zamówienia zakończona powodzeniem! <br><br><br></h1>
           
    </form>
</body>
</html>
