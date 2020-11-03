<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="EstadiaMWE.Reportes" %>

<!DOCTYPE html>

<style type="text/css">
    body {
        background-image: url('Images/photo-1.jpg');
        background-repeat: round;
        background-attachment: fixed;
        text-align: center;
    }

    .grid {
        display: inline-block;
    }

    .div1 {
        text-align: center;
    }

    form {
        background-color: white;
        background-repeat: round;
        background-attachment: fixed;
        text-align: left;
        width: 80%;
        display: inline-block;
    }

    .myButton {
        box-shadow: inset 0px 1px 0px 0px #bee2f9;
        border-radius: 6px;
        border: 1px solid #3866a3;
        display: inline-block;
        cursor: pointer;
        color: white;
        font-family: Arial;
        font-size: 15px;
        font-weight: bold;
        padding: 6px 24px;
        text-decoration: none;
        text-shadow: 0px 1px 0px #7cacde;
    }

        .myButton:hover {
            background: linear-gradient(to bottom, #468ccf 5%, #63b8ee 100%);
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
        border-width: 0px;
        border-color: #CCCCCC;
        background-color: #FFFFFF;
        color: #000000;
        border-style: solid;
        border-radius: 7px;
        box-shadow: 0px 0px 5px rgba(66,66,66,.75);
        text-shadow: -50px 0px 0px rgba(66,66,66,.0);
    }

        .css-input:focus {
            outline: none;
        }
    .auto-style1 {
        box-shadow: inset 0px 1px 0px 0px #bee2f9;
        border-radius: 6px;
        border: 1px solid #3866a3;
        display: inline-block;
        cursor: pointer;
        color: white;
        font-family: Arial;
        font-size: 15px;
        font-weight: bold;
        padding: 6px 24px;
        text-decoration: none;
        text-shadow: 0px 1px 0px #7cacde;
        margin-bottom: 0px;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Estatus"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlStatus" CssClass="css-input" runat="server"></asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="label" runat="server" Text="Turno"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlTurno"  CssClass="css-input" runat="server">
            <asp:ListItem Value="-1">Select All</asp:ListItem>
            <asp:ListItem Value="1">Primero</asp:ListItem>
            <asp:ListItem Value="2">Segundo</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Empleado"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlNumEmpleado"  CssClass="css-input" runat="server"></asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Part Number"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="ddlPartNumber"  CssClass="css-input" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Work order"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtWo"  CssClass="css-input" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Serial Number"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtSerialNum"  CssClass="css-input" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBuscar" CssClass="myButton" runat="server" BackColor="#33CC33" Height="42px" OnClick="btnBuscar_Click" Text="Buscar" Width="112px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLimpiar" CssClass="auto-style1" runat="server" BackColor="#33CCFF" Height="42px" OnClick="btnLimpiar_Click" Text="Limpiar" Width="112px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnExportar" CssClass="myButton" runat="server" BackColor="Gold" Height="42px" Text="Exportar" Width="112px" OnClick="btnExportar_Click" />
        <br />
        &nbsp;<div style="text-align: center">
            &nbsp;&nbsp;&nbsp;
            <asp:GridView runat="server" ID="gvReportes" OnRowCreated="gvReportes_RowCreated"></asp:GridView>
        </div>
        <br />
    </form>
</body>
</html>
