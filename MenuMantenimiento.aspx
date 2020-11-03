<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuMantenimiento.aspx.cs" Inherits="EstadiaMWE.MenuMantenimiento" %>

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
    .auto-style1 {
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
        margin-left: 0px;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenimiento</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Button ID="btnNumParte" CssClass="myButton" runat="server" Text="Numeros de parte" Height="72px" Width="197px" OnClick="btnNumParte_Click" BackColor="#FF9900" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDefecto" CssClass="myButton" runat="server" Text="Defectos" Height="72px" Width="186px" OnClick="btnDefecto_Click" BackColor="#FF9F11"/>
        <br />
        <br />
        <asp:Button ID="btnUsuario" CssClass="myButton" runat="server" Text="Usuarios" Height="72px" Width="186px" OnClick="btnUsuario_Click" BackColor="#FF9F0F"/>
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnArea" CssClass="myButton" runat="server" Text="Areas" Height="72px" Width="186px" OnClick="btnArea_Click" BackColor="#FFA41C" />
        <br />
&nbsp;
        <br />
&nbsp;
        <asp:Button ID="btnStatus" CssClass="myButton" runat="server" Text="Status" Height="72px" Width="186px" OnClick="btnStatus_Click" BackColor="#FFAB2D"/>
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnCliente" CssClass="myButton" runat="server" Text="Clientes" Height="72px" Width="186px" OnClick="btnCliente_Click" BackColor="#FFAB2D"/>
        &nbsp;&nbsp;&nbsp;<br />
        <br />
        <asp:Button ID="btnTipoUsuario" CssClass="auto-style1" runat="server" Text="Usuarios" Height="72px" Width="186px" OnClick="btnTipoUsuario_Click" BackColor="#FFAC2F"  />
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnAreaInt" CssClass="myButton" runat="server" Text="Areas internas" Height="72px" Width="186px" OnClick="btnAreaInt_Click" BackColor="#FFB442"/>
        <br />
    </form>
</body>
</html>
