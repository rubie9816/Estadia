<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="EstadiaMWE.InicioSesion" %>

<!DOCTYPE html>

<style type="text/css">
input {
    max-width: 100%;
}

body {
    background-image: url('Images/photo-1.jpg');
    background-repeat: round;
    background-attachment: fixed;
    text-align: center;
}

form {
    background-color: white;
    background-repeat: round;
    background-attachment: fixed;
    text-align: center;
    width: 50%;
    display: inline-block;
}

.myButton {
    box-shadow: inset 0px 1px 0px 0px #a4e271;
    background: linear-gradient(to bottom, #89c403 5%, #77a809 100%);
    border-radius: 6px;
    border: 1px solid #74b807;
    display: inline-block;
    cursor: pointer;
    color: #ffffff;
    font-family: Arial;
    font-size: 15px;
    font-weight: bold;
    padding: 6px 24px;
    text-decoration: none;
    text-shadow: 0px 1px 0px #528009;
}

    .myButton:hover {
        background: linear-gradient(to bottom, #77a809 5%, #89c403 100%);
    }

    .myButton:active {
        position: relative;
        top: 1px;
    }

.CancelButton {
    box-shadow: inset 0px 1px 0px 0px #f7c5c0;
    background: linear-gradient(to bottom, #fc8d83 5%, #e4685d 100%);
    background-color: #fc8d83;
    border-radius: 6px;
    border: 1px solid #d83526;
    display: inline-block;
    cursor: pointer;
    color: #ffffff;
    font-family: Arial;
    font-size: 15px;
    font-weight: bold;
    padding: 6px 24px;
    text-decoration: none;
    text-shadow: 0px 1px 0px #b23e35;
}

    .CancelButton:hover {
        background: linear-gradient(to bottom, #e4685d 5%, #fc8d83 100%);
        background-color: #e4685d;
    }

    .CancelButton:active {
        position: relative;
        top: 1px;
    }

.css-input {
    padding: 5px;
    font-size: 12px;
    border-width: 1px;
    border-color: #CCCCCC;
    background-color: #FFFFFF;
    color: #000000;
    border-style: solid;
    border-radius: 12px;
    box-shadow: 0px 0px 5px rgba(66,66,66,.75);
}

    .css-input:focus {
        outline: none;
    }

</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio de sesion</title>
<%--    <link rel="styles" runat="server" media="screen" href="~/css/styles.css" />--%>
</head>
<body>
    <form id="form1" runat="server">

        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo2.png" />
        <br />
        <br />
        <strong>SISTEMA DE ANALISIS Y RE TRABAJO DE UNIDADES</strong><br />
        <br />
        INICIAR SESION<br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtUsuario" CssClass="css-input" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtPassword" CssClass="css-input" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnEntrar" class="myButton" runat="server" Text="Entrar"  BackColor="#00CC66" OnClick="btnEntrar_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" class="CancelButton" runat="server" Text="Cancelar"  BackColor="#FF6666" />
        <br />
        <br />
    </form>
</body>
</html>
