<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurePay.aspx.cs" Inherits="NihaoPayDemo.SecurePay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <title>NihaoPay SecurePay</title>
</head>
<body>
  <form id="form1" runat="server">
    <div style=" width:800px; margin:0 auto; padding:0">
    <table border="0">
        <tr><td colspan="2"><h3>SecurePay</h3></td></tr>
        <tr><td style="width:120px;">Reference:</td><td style="width:700px"> 
            <asp:TextBox ID="reference"  runat="server" Width="200px" ClientIDMode="Static"></asp:TextBox>
        </td></tr>
        <tr><td>Currency:</td><td><asp:RadioButtonList ID="currency" runat="server" 
            RepeatDirection="Horizontal">            
            <asp:ListItem Selected="True">USD</asp:ListItem>            
            <asp:ListItem >HKD</asp:ListItem>
            <asp:ListItem >EUR</asp:ListItem>
            <asp:ListItem >JPY</asp:ListItem>
			<asp:ListItem >CAD</asp:ListItem>
			<asp:ListItem >GBP</asp:ListItem>
        </asp:RadioButtonList> </td></tr>
        <tr><td>Amount:</td><td><asp:TextBox ID="amount" Text="100.00" runat="server"  Width="200px" ClientIDMode="Static"></asp:TextBox></td></tr>
      
        <tr><td>Vendor:</td><td><asp:RadioButtonList ID="vendor" runat="server" 
            RepeatDirection="Horizontal">            
            <asp:ListItem Selected="True">alipay</asp:ListItem>            
            <asp:ListItem >wechatpay</asp:ListItem>
            <asp:ListItem >unionpay</asp:ListItem>
        </asp:RadioButtonList> </td></tr>
        <tr><td>Description:</td><td> <asp:TextBox ID="description" 
            Text="order description" runat="server" Width="500px" ClientIDMode="Static"></asp:TextBox></td></tr>
        <tr><td>Terminal:</td><td> 
            <asp:TextBox ID="terminal" 
            Text="" runat="server" Width="500px" ClientIDMode="Static"></asp:TextBox></td></tr>
        <tr><td>Note:</td><td><asp:TextBox ID="note" Text="" runat="server" Width="200px"  ClientIDMode="Static"></asp:TextBox></td></tr>
        <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
        <tr><td colspan=2> <asp:Button ID="Button1" runat="server" Text="Confirm" Height="21px" 
            onclick="Button1_Click" /></td></tr>
    </table>
    </div>
    </form>
    <script>
        var terminal=document.getElementById("terminal")
        if (navigator.userAgent.match(/mobile/i)) {
            terminal.value = "WAP";
        }
        else {
            terminal.value = "ONLINE";

        }
    </script>
</body>
</html>
