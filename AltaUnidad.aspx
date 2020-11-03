<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaUnidad.aspx.cs" Inherits="EstadiaMWE.AltaUnidad" %>

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
        background-color:#f7c5c0;
    }

    form {
        background-color: white;
        background-repeat: round;
        background-attachment: fixed;
        text-align: left;
        width: 70%;
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
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alta de unidad</title>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;&nbsp;&nbsp;
      <asp:Label ID="Label11" runat="server" Text="Bienvenido" Style="font-weight: 700"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblusuario" runat="server" Text="usuario" Style="font-weight: 700"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Part Number"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="ddlPartNumber" CssClass="css-input" runat="server"></asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp; Area&nbsp;&nbsp;
        <asp:DropDownList ID="ddlArea" CssClass="css-input" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Work order"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtNumOrden" runat="server" CssClass="css-input" AutoCompleteType="Disabled"></asp:TextBox>
        <br />
        <br />
        <div class="div1">
            <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Serial Number"></asp:Label>
            &nbsp;
        <br />
            <br />
            &nbsp;&nbsp;&nbsp; Individual:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNumSerie" runat="server" CssClass="css-input" AutoCompleteType="Disabled"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAgregarNumSerie" runat="server" Text="+ Serial num" class="myButton" Width="138px" OnClick="btnAgregarNumSerie_Click" />
            <br />
            <br />
            &nbsp;
        <br />
            &nbsp;&nbsp;&nbsp;
        A partir de: <asp:TextBox ID="txtserieinicial" runat="server" CssClass="css-input" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Cantidad:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtQTY" runat="server" CssClass="css-input" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
            &nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="btnQTY" runat="server" Text="Agregar" class="myButton" Width="138px" OnClick="btnQTY_Click" />
            <br />
            <br />
            &nbsp;<asp:GridView ID="gvNumSerie" CssClass="grid" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvNumSerie_SelectedIndexChanged">
            </asp:GridView>
            <br />
            <br />
        </div>
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Text="Defecto"></asp:Label>
        &nbsp;
             <asp:DropDownList ID="ddlDefecto" CssClass="css-input" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDefecto_SelectedIndexChanged">
             </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label10" runat="server" Text="Referencia"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtReferencia" runat="server" CssClass="css-input" AutoCompleteType="Disabled"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnAgregarDefecto" runat="server" Text="Agregar" class="myButton" Width="138px" OnClick="btnAgregarDefecto_Click" />
            <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        Defectos seleccionados:
        <br />
        &nbsp;&nbsp;&nbsp;
                <asp:GridView ID="gvDefectos" CssClass="grid" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvDefectos_SelectedIndexChanged" OnRowCreated="gvDefectos_RowCreated">
                </asp:GridView>
                <br />
                <br />
                <asp:Button ID="btnAlta" runat="server" Text="Dar de alta" class="myButton" OnClick="btnAlta_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="CancelButton" OnClick="btnCancelar_Click" />
            
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />

    </form>
</body>
</html>

