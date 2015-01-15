<%@ Page Title="" Language="C#" MasterPageFile="~/vendedor/base_vendedor.Master" AutoEventWireup="true" CodeBehind="socialmedia.aspx.cs" Inherits="toptusv1.vendedor.socialmedia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Vendedor" runat="server">

    <div class="row">
       
       <div class="col-md-8 col-md-offset-4"><h3>Redes Sociales</h3></div>
       
   </div>
    <div class="row">
        <div class="col-md-offset-3 col-md-4" id="facebook">
           <asp:TextBox ID="redes_facebook" ClientIDMode="Static" type="text" CssClass="form-control input_form"  placeholder="https://www.facebook.com/user" runat="server" ></asp:TextBox>
         </div>     
    </div>

    <div class="row">
        <div class="col-md-offset-3 col-md-4" id="twitter">
           <asp:TextBox ID="redes_twitter" ClientIDMode="Static" type="text" CssClass="form-control input_form"  placeholder="https://twitter.com/user" runat="server" ></asp:TextBox>
         </div>     
    </div>

   <div class="row">
        <div class="col-md-offset-3 col-md-4" id="googleplus">
           <asp:TextBox ID="redes_google" ClientIDMode="Static" type="text" CssClass="form-control input_form"  placeholder="https://plus.google.com/user" runat="server" ></asp:TextBox>
         </div>     
    </div>

    <div class="row">
        <div class="col-md-offset-3 col-md-4" id="instagram">
           <asp:TextBox ID="redes_instagram" ClientIDMode="Static" type="text" CssClass="form-control input_form"  placeholder="http://instagram.com/user" runat="server" ></asp:TextBox>
         </div>     
    </div>

    <div class="row">
        <div class="col-md-offset-3 col-md-4" id="linkedin">
           <asp:TextBox ID="redes_linked" ClientIDMode="Static" type="text" CssClass="form-control input_form"  placeholder="https://www.linkedin.com/in/user" runat="server" ></asp:TextBox>
         </div>     
    </div>
    <div class="row col-md-offset-3 col-md-4">
        <asp:Button ID="btnRedes" runat="server" Text="Guardar" OnClick="btnRedes_Click"  ClientIDMode="Static"/>
    </div>

</asp:Content>
