<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="JS/genericJS.js"></script>
</head>
<body>
    
        <div>
            <div class="container">
            <label for="uname"><b>Username</b></label>
            <input type="text" id="txtUserName" placeholder="Enter Username" name="uname">

            <label for="psw"><b>Password</b></label>
            <input type="password" id="txtPassword" placeholder="Enter Password" name="psw">

            <button type="button" onclick="UserLogin()">Login</button>            
          </div>
        </div>
   
</body>
</html>
