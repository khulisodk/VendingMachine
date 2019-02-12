<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VendingMachine.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VendindMachine</title>
    <style type="text/css">
        .auto-style2 {
            height: 900px;
        }
        .auto-style5 {
            height: 10px;
        }
        .auto-style6 {
            margin-top: 0px;
        }
        .auto-style7 {
            width: 265px;
        }
        .auto-style8 {
            height: 31px;
        }
        </style>
</head>
<body style="height: 86px; margin-bottom: 60px;">

    <h1 style="text-align:center;">
             Welcome To Inside Office Vending Machine
    </h1>

    <form id="form1" runat="server" class="auto-style2" style="background-color: #C0C0C0">
        <div style="background-color: #C0C0C0">
            
        </div>

        <br/>
         

         
        <p style="text-align:center; font-family: 'Arial Black'; font-size: medium;">Available Items To Purchase:</p>

        <br />
        <br />

        <table>
            <tr> <td class="auto-style7"><asp:Label ID="lblProCode" runat="server" Text=" Enter Product Code"></asp:Label></td>
                 <td><asp:TextBox ID="txtProdCode" runat="server" Width="64px" ></asp:TextBox> </td>   
            </tr>

            <tr>
                <td class="auto-style7"><asp:Label ID="lblInsertCode" runat="server" Text="Insert Coin below e.g (50c; R1; R2; R5)"></asp:Label> </td>
                <td><asp:TextBox ID="txtCoin" runat="server" Width="64px" CssClass="auto-style6"></asp:TextBox></td>
            </tr>
             <tr>
                <td class="auto-style7"><asp:Button ID="btnCoin" runat="server" OnClick="btnCoin_Click" Text="Insert Coin" OnClientClick="return true" Autopostback ="true" />

                 <asp:Label ID="lblAmount" runat="server"></asp:Label>
                 </td>

                <td><asp:Button ID="btnPurchase" runat="server" OnClick="btnPurchase_Click" Text="Purchase Item(s)" /></td>
            </tr>
            <tr><td class="auto-style8"><asp:Button ID="btnRefund" runat="server" OnClick="btnRefund_Click" Text="Refund" />

         <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh" style="text-align:center;" /> 

                </td></tr>

        </table>

        <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300" Text=" "></asp:Label>
        
        <br />

        <div>
        <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" RepeatDirection="Horizontal" Height="97px" HorizontalAlign="Center">

            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <ItemStyle BackColor="#DEDFDE" ForeColor="Black" />

            <ItemTemplate>
                <table>

                   <%-- <tr>
                        <td><img src = "<%#Eval("product_imageURL") %>" height="200" width="200"/></td>
                    </tr>--%>

                    
                 <%--   <tr><td class="auto-style5"><p>R <%#Eval("product_Price")%></p></td></tr>
                    <tr><td><p>Quantity  <%#Eval("product_quantity")%></p></td></tr>
                    <tr><td><p>Product Code  <%#Eval("product_code")%></p></td></tr>--%>
                   
                        

                    <tr>
                        <td><img src = "<%#Eval("product_imageURL") %>" height="200" width="200"/></td>
                    </tr>

                    
                    <tr><td class="auto-style5"><p>R <%#Eval("product_Price")%></p></td></tr>
                    <tr><td><p>Quantity  <%#Eval("product_quantity")%></p></td></tr>
                    <tr><td><p>Product Code  <%#Eval("product_code")%></p></td></tr>

                </table>
                

               
            </ItemTemplate>

            <SelectedItemStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />

        </asp:DataList>

        </div>



    </form>
</body>
</html>
