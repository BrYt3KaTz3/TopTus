<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="a_solicitud.aspx.cs" Inherits="toptusv1.admin.a_solicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Admin" runat="server">
    
    <div class="container panel">

        <div class ="row" style="background-color:#4479BA; color:white">

            <h3 class="col-md-offset-4" ">Solicitudes de Ingreso a TopTus</h3>
        </div>
        

        <div class="row">
           
            <div class="col-md-12" >
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                      <ItemTemplate>
                             <div class="list-group text-center" >
                                 <h4 class="list-group-item"><%# Eval("nombre_completo") %></h4>
                                <p class="list-group-item-text">Email: <%# Eval("email") %> </p><br /> 
                                 <asp:LinkButton ID="lk_detalle" runat="server" CommandName="ver_detalle" CssClass="btn-link"  ClientIDMode="Static">View Details</asp:LinkButton>
                               
                                 <asp:HiddenField  ID="hidden_detalle" runat="server" Value='<%# Eval("vendedor_id") %>' ClientIDMode="Static" />

                             </div>
                         </ItemTemplate>
                </asp:Repeater>

                

            </div>
             <div class="col-md-12" id="div_datos_solicitud" runat="server">

                 
                     <div class="form-group">
                         <asp:Label ID="Label1" runat="server" Text="Nombre Completo" CssClass="col-md-2 col-md-offset-4"></asp:Label>
                         <asp:Label ID="lbl_Nombre_Completo" runat="server" Text="" CssClass="col-md-6"></asp:Label>
                        
                     </div>
                 <br />
                 <div class="form-group">
                         <asp:Label ID="Label3" runat="server" Text="Correo:" CssClass="col-md-2 col-md-offset-4"></asp:Label>
                         <asp:Label ID="lbl_correo" runat="server" Text="" CssClass="col-md-6"></asp:Label>
                        
                     </div>
                 <br />
                 <div class="form-group">
                         <asp:Label ID="Label5" runat="server" Text="Fecha de Solicitud:" CssClass="col-md-2 col-md-offset-4"></asp:Label>
                         <asp:Label ID="lbl_fecha" runat="server" Text="" CssClass="col-md-6"></asp:Label>
                     <asp:HiddenField ID="hd_id" runat="server"  />
                     </div>
                <div class="form-group text-center">
                    <asp:Button ID="btn_aceptar_solicitud" runat="server" Text="Aceptar Solicitud" OnClick="btn_aceptar_solicitud_Click" ClientIDMode="Static" />
                </div>
                

             </div>

        </div>
       

    </div>

    <div id="dialog" title="Confirmación" style="display:none">
  <p> La solicitud ha sido procesada correctamente</p>
</div>
</asp:Content>
