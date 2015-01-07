<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="json.aspx.cs" Inherits="toptusv1.json" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <p id="p" runat="server"></p>

        <asp:Repeater ID="rptItemsInCart" runat="server" OnItemDataBound="rptItemsInCart_ItemDataBound">

  
  <ItemTemplate>
       
    
      <p id="cates" runat="server"><%# Eval("categoria_id") %></p>
      <p><%# Eval("categoria_descr")%></p>
       
      <asp:HiddenField  ID="hidden_categorias" runat="server" Value='<%# Eval("categoria_id") %>' ClientIDMode="Static" />
      
   
      
      <br />
          <asp:Repeater runat="server" ID="repeater_subcategorias">
                <ItemTemplate>
            <p class="subcategoria"><a href="productlist.aspx?cat=<%# Eval("categoria_id") %>&sub=<%# Eval("subcategoria_id") %>"><%# Eval("subcategoria_descr") %></a></p>
                    
                    </ItemTemplate>
            </asp:Repeater>

      
  </ItemTemplate>
  
</asp:Repeater>
    </div>
</asp:Content>
