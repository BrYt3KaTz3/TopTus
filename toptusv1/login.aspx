<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="toptusv1.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Login/login.css" rel="stylesheet" />
    <script src="Login/login.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <div class="panel panel-default">
                <div class="panel-body">
                    <h5 class="text-center">
                        SIGN UP</h5>
                    
               
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-envelope"></span>
                            </span>

                            <asp:TextBox ID="log_usuario" CssClass="form-control" runat="server" placeholder="Email Address"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                            <asp:TextBox ID="log_password" CssClass="form-control" runat="server" placeholder="Password"></asp:TextBox>
                            
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="input-group col-xs-6 col-xs-offset-5" >
                        <asp:RadioButtonList ID="radiovendedor" runat="server">
                        
                            <asp:ListItem  Selected="True" Value="1" >Seller</asp:ListItem>
                            <asp:ListItem  Value="2">Buy</asp:ListItem>


                            
                           
                            </asp:RadioButtonList>
                            </div>
                       
                    </div>
                </div>
                <asp:Button ID="Button1" runat="server" CssClass="button-link btn btn-sm btn-primary btn-block" Text="SUBMIT" OnClick="Button1_Click" />
              <a href="Index.aspx" class="btn-link pull-right">Back to TopTus.com</a>
            </div>
        </div>
    </div>
</div>

    
</asp:Content>
