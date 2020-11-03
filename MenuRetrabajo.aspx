<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuRetrabajo.aspx.cs" Inherits="EstadiaMWE.MenuRetrabajo" %>

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
    <title>Menu Retrabajo</title>
</head>
<body>
    <form id="form2" runat="server">
        <br />
        <asp:Button ID="btnAlta" CssClass="myButton" BackColor="SlateBlue" runat="server" Text="Alta para RWK" Height="116px" Width="206px" OnClick="btnAlta_Click"/>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnRetrabajo" CssClass="myButton" BackColor="CornflowerBlue" runat="server" Text="Re trabajar unidad" Height="116px" Width="206px" OnClick="btnRetrabajo_Click" />
        &nbsp;<br />
        <br />
    </form>
</body>
</html>
