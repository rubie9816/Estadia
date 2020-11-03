<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="EstadiaMWE.Menu" %>

<!DOCTYPE html>

<style type="text/css">
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
        box-shadow: -5px 5px 17px -4px #808080;
        border-radius: 2px;
        border: 1px solid #000000;
        display: inline-block;
        cursor: pointer;
        color: #ffffff;
        font-family: Arial;
        font-size: 17px;
        font-weight: bold;
        padding: 27px 27px;
        text-decoration: none;
        text-shadow: 0px 2px 0px #808080;
    }

        .myButton:hover {
            background-color: #000000;
        }

        .myButton:active {
            position: relative;
            top: 1px;
        }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu</title>
</head>
<body>
    <form id="form2" runat="server">
        <asp:Label ID="lbl" runat="server" Text="Bienvenido:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblUsuario" runat="server" Text="usuario"></asp:Label>
        <br />
        <br />
        &nbsp;<asp:Button ID="btnAnalisis" CssClass="myButton" BackColor="CadetBlue" runat="server" Text="Analisis" Height="93px" Width="123px" OnClick="btnAnalisis_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnRetrabajo" CssClass="myButton" BackColor="Tomato" runat="server" Text="Retrabajo" Height="91px" Width="135px" OnClick="btnRetrabajo_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnReportes" CssClass="myButton" BackColor="OrangeRed" runat="server" Text="Reportes" Height="93px" Width="125px" OnClick="btnReportes_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBitacora" CssClass="myButton" BackColor="BlueViolet" runat="server" Text="Bitacora" Height="93px" Width="120px" OnClick="btnBitacora_Click" />
        <br />
        <br />
        <asp:Button ID="btnMantenimiento" CssClass="myButton" BackColor="SandyBrown" runat="server" Text="Mantenimiento" Height="78px" Width="172px" OnClick="btnMantenimiento_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnModificaciones" CssClass="myButton" BackColor="orange" runat="server" Text="Modificacion de unidades" Height="77px" Width="254px" OnClick="btnModificaciones_Click"/>
        <br />
        <br />
    </form>
</body>
</html>
