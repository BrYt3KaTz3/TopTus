<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="a_solicitud.aspx.cs" Inherits="toptusv1.admin.a_solicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Admin" runat="server">
    
    <div class="container panel">

        <div class ="row">

            <h3 class="col-md-12">Solicitudes de Ingreso a TopTus</h3>
        </div>
        
        <div class="row">
            <div class="col-lg-push-6">

                <asp:GridView ID="gv_solicitudes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre">
                        <ItemStyle  />
                        </asp:BoundField>
                        <asp:BoundField DataField="apellido_p" HeaderText="Apellido Paterno">
                        <ControlStyle  />
                        </asp:BoundField>
                        <asp:BoundField DataField="apellido_m" HeaderText="Apellido Materno">
                        <ControlStyle  />
                        </asp:BoundField>
                        <asp:BoundField DataField="email" HeaderText="Correo" />
                        <asp:BoundField DataField="fecha_solicitud" DataFormatString="{0:d}" HeaderText="Fecha Solicitud" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>

            </div>

        </div>

    </div>
</asp:Content>
