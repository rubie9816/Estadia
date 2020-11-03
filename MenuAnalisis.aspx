<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAnalisis.aspx.cs" Inherits="EstadiaMWE.MenuAnalisis" %>

<!DOCTYPE html>

<style type="text/css">
    body {
        background-image: url('Images/photo-1.jpg');
        background-repeat: round;
        background-attachment: fixed;
        text-align: center;
    }

    input.button-add {
    background-image: url(/Images/analisis.png); /* 16px x 16px */
    background-color: transparent; /* make the button transparent */
    background-repeat: no-repeat;  /* make the background image appear only once */
    background-position: 0px 0px;  /* equivalent to 'top left' */
    border: none;           /* assuming we don't want any borders */
    cursor: pointer;        /* make the cursor like hovering over an <a> element */
    height: 16px;           /* make this the size of your image */
    padding-left: 16px;     /* make text start to the right of the image */
    vertical-align: middle; /* align the text vertically centered */
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
    <title>Menu Analisis</title>
</head>
<body>
    <form id="form2" runat="server">
        <br />
        <asp:Button ID="btnAlta" CssClass="myButton" runat="server" BackColor="Tomato" Text="Alta de unidad" Height="107px" Width="184px" OnClick="btnAlta_Click" />
        <br />
        <br />
        <asp:Button ID="btnAnalisis" CssClass="myButton" BackColor="Orange" runat="server" Text="Analizar unidades" Height="109px" Width="196px" OnClick="btnAnalisis_Click" />
        &nbsp;<br />
        <br />
    </form>
</body>
</html>
