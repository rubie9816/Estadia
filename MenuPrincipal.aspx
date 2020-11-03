<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="EstadiaMWE.MenuPrincipal" %>

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
        box-shadow: inset 0px 1px 0px 0px #bee2f9;
        background: linear-gradient(to bottom, #63b8ee 5%, #468ccf 100%);
        background-color: #63b8ee;
        border-radius: 6px;
        border: 1px solid #3866a3;
        display: inline-block;
        cursor: pointer;
        color: #14396a;
        font-family: Arial;
        font-size: 15px;
        font-weight: bold;
        padding: 6px 24px;
        text-decoration: none;
        text-shadow: 0px 1px 0px #7cacde;
    }

        .myButton:hover {
            background: linear-gradient(to bottom, #468ccf 5%, #63b8ee 100%);
            background-color: #468ccf;
        }

        .myButton:active {
            position: relative;
            top: 1px;
        }

    .myButton2 {
        box-shadow: inset 0px 0px 14px -3px #f2fadc;
        background: linear-gradient(to bottom, #dbe6c4 5%, #9ba892 100%);
        background-color: #dbe6c4;
        border-radius: 6px;
        border: 1px solid #b2b8ad;
        display: inline-block;
        cursor: pointer;
        color: #757d6f;
        font-family: Arial;
        font-size: 15px;
        font-weight: bold;
        padding: 6px 24px;
        text-decoration: none;
        text-shadow: 0px 1px 0px #ced9bf;
    }

        .myButton2:hover {
            background: linear-gradient(to bottom, #9ba892 5%, #dbe6c4 100%);
            background-color: #9ba892;
        }

        .myButton2:active {
            position: relative;
            top: 1px;
        }
</style>
<html>
<head>
    <title>Análisis y retrabajo</title>
    <meta charset="utf-8">
</head>
<body>
    <form id="form2" runat="server">
        <br />
        <asp:Button ID="btnAnalisis" CssClass="myButton2" runat="server" Text="Alta para Analisis"  Height="55px" Width="186px" OnClick="btnAnalisis_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAlta" CssClass="myButton" runat="server" Text="Alta para RWK" OnClick="btnAlta_Click" Height="55px" Width="186px" />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLogIn" CssClass="myButton2" runat="server" Text="Iniciar sesión" OnClick="btnLogIn_Click" Height="56px" Width="180px" />
        <br />
        <br />
    </form>
</body>
</html>



