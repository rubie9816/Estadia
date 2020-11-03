<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Analisis.aspx.cs" Inherits="EstadiaMWE.Analisis" %>

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
        background-color: beige;
    }

    form {
        background-color: white;
        background-repeat: round;
        background-attachment: fixed;
        text-align: left;
        /*width: 80%;*/
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

    .divCenter {
        text-align: center;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div class="left">
            <asp:Label ID="lbl1" runat="server" Text="Analisis" Font-Size="Larger" Style="font-weight: 700; font-size: x-large"></asp:Label>
            &nbsp;<br />
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
        <asp:TextBox ID="txtWorkOrder" AutoCompleteType="Disabled" CssClass="css-input" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Falla"></asp:Label>
            &nbsp;
        <asp:TextBox ID="txtFalla" AutoCompleteType="Disabled" CssClass="css-input" runat="server" Height="35px" TextMode="MultiLine" Width="197px"></asp:TextBox>
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
            <asp:Label ID="Label5" runat="server" Text="*Area"></asp:Label>
            &nbsp;
        <asp:DropDownList ID="ddlArea" CssClass="css-input" runat="server">
        </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="*Defecto"></asp:Label>
            &nbsp;
             <asp:DropDownList ID="ddlDefecto" CssClass="css-input" runat="server" AutoPostBack="True">
             </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="*Referencia"></asp:Label>
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
            <asp:Button ID="btnRWK" CssClass="myButton" runat="server" Text="Enviar a RWK" Height="72px" Width="186px" OnClick="btnRWK_Click" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCalidad" CssClass="CancelButton" runat="server" Text="Enviar a CALIDAD" Height="72px" Width="186px" OnClick="btnCalidad_Click" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnScrap" CssClass="CancelButton" runat="server" Text="Enviar a SCRAP" Height="72px" Width="186px" BackColor="#FF6666" OnClick="btnScrap_Click" />
            <br />
            <br />
        </div>
        <div class="right">
            <div class="div1">
                <asp:Label ID="lbl2" runat="server" Text="Unidades NO analizadas" Font-Size="Larger" Style="font-weight: 700; font-size: x-large"></asp:Label>
                <br />
                &nbsp;
        <asp:Label ID="Label12" runat="server" Text="Work order"></asp:Label>
                &nbsp;&nbsp;&nbsp;


                <%--<asp:Panel runat="server" DefaultButton="Button1">--%>
                <asp:TextBox ID="txtBuscarWO" CssClass="css-input" AutoCompleteType="Disabled" runat="server" AutoPostBack="True" onkeyup="cambiarTexto()" ></asp:TextBox>
                <%--        <asp:Button ID="Button1" runat="server" Style="display: none" Text="Button" OnClick="Button1_Click" />



                <%--<input type="text" id="txtBuscarWO" runat="server" autocomplete="off" class="css-input" onkeypress="txtBuscarWO_TextChanged" />--%>

                &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label13" runat="server" Text="Serial Number"></asp:Label>
                &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtBuscarSN" onkeypress="return false;" onpaste="return false" CssClass="css-input" AutoCompleteType="Disabled" runat="server" AutoPostBack="True" OnTextChanged="txtBuscarSN_TextChanged"></asp:TextBox>
                <%--<input type="text" id="txtBuscarSN" runat="server" autocomplete="off" class="css-input" onkeypress="txtBuscarSN_TextChanged" />--%>
                <br />
                <br />
            </div>
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBuscar" CssClass="myButton" runat="server" BackColor="#33CC33" Height="42px" Text="Buscar" Width="112px" OnClick="btnBuscar_Click" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLimpiar" CssClass="auto-style1" runat="server" BackColor="#33CCFF" Height="42px" Text="Limpiar" Width="112px" OnClick="btnLimpiar_Click" />
            &nbsp;&nbsp;&nbsp;
             <asp:Button ID="btnSeleccionar" CssClass="myButton" runat="server" BackColor="#33CCFF" Height="42px" Text="Seleccionar varios" Width="184px" OnClick="btnSeleccionar_Click" />
            &nbsp;<br />
            <br />
            <div style="width: 100%; height: 400px; overflow: scroll">
                <asp:GridView ID="gvAnalisis" CssClass="grid" runat="server" AutoGenerateSelectButton="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="gvAnalisis_SelectedIndexChanged" Width="312px" OnRowCreated="gvAnalisis_RowCreated">
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#9999FF" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="Gray" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <%--                <Columns>
                    <asp:BoundField HeaderText="Falla" DataField="Falla"
                        ItemStyle-Width="300px" />
                </Columns>--%>
                </asp:GridView>
            </div>
            <br />
            <br />
        </div>
    </form>

</body>
</html>

<script type="text/javascript">            
    function cambiarTexto() {
       <%#EstadiaMWE.Globales.cambiarTexto()%> ;
    }
</script>
