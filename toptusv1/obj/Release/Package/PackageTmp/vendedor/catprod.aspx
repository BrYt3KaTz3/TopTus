<%@ Page Title="" Language="C#" MasterPageFile="~/vendedor/base_vendedor.Master" AutoEventWireup="true" CodeBehind="catprod.aspx.cs" Inherits="toptusv1.vendedor.catprod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Vendedor" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:Label ID="lblEn" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="lblDes" runat="server" Text=""></asp:Label>

   
    
    <div class="row">
        <div class="col-md-6" style="border-right:1px solid gray"><h4>Elige la(s) categoría(s) y subcategoría(s) para este producto:</h4>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                        <label for="catprod_cat" class="col-md-4 control-label">Categoría:</label>
                        <div class="col-md-8">
                          <asp:DropDownList ID="ddlcat"  runat="server" OnSelectedIndexChanged="ddlcat_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                        </div>
                        </div>
                         <br />
                         <br /> 
                        <div class="form-group">
                        <label for="catprod_sub" class="col-md-4 control-label">Sub Categoría:</label>
                        <div class="col-md-8">
                          <asp:DropDownList ID="ddlsub" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        </div>

                    </ContentTemplate>

                </asp:UpdatePanel>
            <asp:Button ID="btnAgregarCategoria" ClientIDMode="Static" runat="server" CssClass="btn-lg" OnClick="btnAgregarCategoria_Click" Text="Agregar Categoría" />
        </div>

        <div class="col-md-6"><h4>Categorías / Subcategorías</h4> 
            <div class="row">
        <div class="col-md-12">
            <h4> <asp:Label runat="server" ID="repeater_status" CssClass="alert-danger"></asp:Label></h4>
           <ol>
               <asp:Repeater ID="rptCategorias_Subcategorias" runat="server">
                   <ItemTemplate>
                   <li><%# Eval("categoria_descr") %>  - <%#Eval ("subcategoria_descr") %></li>
                   </ItemTemplate>
               </asp:Repeater>
           </ol>
        </div>
             </div>
        </div>
    </div>


    <div class="row">
        	
		</div>

   


</asp:Content>
