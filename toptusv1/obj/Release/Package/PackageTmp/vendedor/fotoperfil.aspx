<%@ Page Title="" Language="C#" MasterPageFile="~/vendedor/base_vendedor.Master" AutoEventWireup="true" CodeBehind="fotoperfil.aspx.cs" Inherits="toptusv1.vendedor.fotoperfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Vendedor" runat="server">
    <div class="row">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
       <div class="col-md-8 col-lg-8 col-xs-8 col-md-offset-4"><h3>Tu foto de perfil</h3></div>
       
   </div>
    
       
       
                      
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                        <ContentTemplate>
                            <div class=" row">
                            <div class="col-md-4 col-md-offset-4">
                            <asp:Panel ID="pnlfoto" runat="server">

                            </asp:Panel>
                            
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <br />
                             
                            <asp:Image ID="imgViewFile" runat="server" CssClass="img-responsive" />
                            </div> 
                                </div>
                            <br />
                            <div class="row col-md-offset-4">
                            Si la imagen no carga correctamente presione "F5"<br />
                            <asp:Button ID="btnUpload" ClientIDMode="Static" runat="server" CssClass="btn-danger btn" Text="Subir Foto" OnClick="btnfoto_Click" /><br />
                                </div>
                        </ContentTemplate>
                        <Triggers> <asp:PostBackTrigger ControlID="btnUpload" /> </Triggers>  
                    </asp:UpdatePanel>
                      
                      
   
    
    
</asp:Content>
