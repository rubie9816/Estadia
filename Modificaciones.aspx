﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modificaciones.aspx.cs" Inherits="EstadiaMWE.Modificaciones" %>

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
        background-color:beige;
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
        background: linear-gradient(to bottom, #63b8ee 5%, #468ccf 100%);
        background-color: #63b8ee;
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
            background-color: #468ccf;
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

    .left, .right {
        height: 100%;
        width: 50%;
        position: fixed;
        z-index: 1;
        top: 0;
        overflow-x: hidden;
        padding-top: 20px;
    }

    .left {
        left: 0;
        background-color: beige;
    }

    .right {
        right: 0;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="left">
            <br />
            <br />
            <asp:Button ID="btnModificar" CssClass="myButton" runat="server" Text="Modificar" Height="37px" Width="158px" BackColor="#FF9966" OnClick="btnModificar_Click" />
            <br />
            <br />
            <asp:Label ID="Label11" runat="server" Text="Fecha entrada"></asp:Label>
            &nbsp;<asp:TextBox ID="txtFechaEntrada" CssClass="css-input" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
        &nbsp;<asp:Label ID="Label10" runat="server" Text="Status actual:" Font-Size="Large"></asp:Label>
            &nbsp;
             <asp:DropDownList ID="ddlStatus" CssClass="css-input" runat="server" AutoPostBack="True" Font-Size="Large">
             </asp:DropDownList>
            &nbsp;&nbsp;<br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Part Number"></asp:Label>
            &nbsp;
        <asp:DropDownList ID="ddlPartNumber" CssClass="css-input" runat="server">
        </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
        <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Work order"></asp:Label>
            &nbsp;
        <asp:TextBox ID="txtWorkOrder" CssClass="css-input" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Falla"></asp:Label>
            &nbsp;
        <asp:TextBox ID="txtFalla" CssClass="css-input" runat="server" AutoCompleteType="Disabled" Height="35px" TextMode="MultiLine" Width="197px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Serial Number"></asp:Label>
            &nbsp;
        <asp:TextBox ID="txtSerialNumber" CssClass="css-input" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
        &nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Area"></asp:Label>
            &nbsp;
        <asp:DropDownList ID="ddlArea" CssClass="css-input" runat="server">
        </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Defecto"></asp:Label>
            &nbsp;
             <asp:DropDownList ID="ddlDefecto" CssClass="css-input" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDefecto_SelectedIndexChanged">
             </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="Referencia"></asp:Label>
            <asp:TextBox ID="txtReferencia" CssClass="css-input" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAgregarDefecto" CssClass="myButton" runat="server" Text="Agregar" Height="37px" Width="109px" OnClick="btnAgregarDefecto_Click" />
            <br />
            <br />
            Defectos seleccionados:<br />
            <br />
            <asp:GridView ID="gvDefectos" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvDefectos_SelectedIndexChanged" OnRowCreated="gvDefectos_RowCreated">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnAlta" CssClass="myButton" runat="server" Text="Guardar cambios" Height="72px" Width="186px" BackColor="#00CC66" OnClick="btnAlta_Click" />
            <asp:Button ID="btnCancelar" CssClass="CancelButton" runat="server" Text="Cancelar" Height="72px" Width="186px" BackColor="#FF6666" OnClick="btnCancelar_Click" />
            <br />
            <br />
        </div>
        <div class="right">
            <div class="div1">
                <br />
                &nbsp;
        <asp:Label ID="Label12" runat="server" Text="Work order"></asp:Label>
                &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtBuscarWO" AutoCompleteType="Disabled" CssClass="css-input" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label13" runat="server" Text="Serial Number"></asp:Label>
                &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtBuscarSN" CssClass="css-input" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
                <br />
                <br />
            </div>
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBuscar" CssClass="myButton" runat="server" BackColor="#33CC33" Height="42px" Text="Buscar" Width="112px" OnClick="btnBuscar_Click" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLimpiar" CssClass="auto-style1" runat="server" BackColor="#33CCFF" Height="42px" Text="Limpiar" Width="112px" OnClick="btnLimpiar_Click" />
            &nbsp;<br />
            <asp:GridView   ID="gvUnidades" runat="server" AutoGenerateSelectButton="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="gvAnalisis_SelectedIndexChanged" Width="312px" OnRowCreated="gvAnalisis_RowCreated">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
