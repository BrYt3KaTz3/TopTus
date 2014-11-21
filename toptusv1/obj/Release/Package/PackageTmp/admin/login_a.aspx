<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_a.aspx.cs" Inherits="toptusv1.admin.login_a" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
      <script src="../Scripts/jquery-2.1.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <link href="../css/cssgeneral.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="admin_generales.js"></script>
    <script src="a_login.js"></script>
    <script src="../Scripts/generales.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form_admin_login" runat="server">
    <div>
    
        
    

    <div class="container">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <div class="panel panel-default">
                <div class="panel-body">
                    <h5 class="text-center">
                        Admin Login</h5>
                    
               
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-envelope"></span>
                            </span>

                            <asp:TextBox ID="a_usuario" CssClass="form-control" runat="server" placeholder="Usuario"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                            <asp:TextBox ID="a_password" CssClass="form-control" runat="server" placeholder="Password"></asp:TextBox>
                            
                        </div>
                    </div>

                   
                </div>
                <asp:Button ID="Button1" runat="server" CssClass="button-link btn btn-sm btn-primary btn-block" Text="Entrar" OnClick="Button1_Click" />
              <a href="../Index.aspx" target="_blank" class="btn-link pull-right">Back to TopTus.com</a>
            </div>
        </div>
    </div>
</div>



    </div>
    </form>
     <div id="loader">
        <label>Procesando solicitud</label>
    <img src="../imagenes/ajax-loader.gif" alt="loading"/><br/>
        </div>
</body>
</html>
