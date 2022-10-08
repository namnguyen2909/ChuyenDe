<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="CPanel.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error</title>
     <link href="/Templates/css/bootstrap.css" rel="stylesheet" />
    <link href="/Templates/css/bootstrap-theme.css" rel="stylesheet" />
</head>
<body>
    <div style="margin:auto;align-content:center; text-align:center">
        <h1>Something Went Wrong
        </h1>
        <hr />
        <div style="height: 300px;">
            <img src="Templates/images/error.jpg"/>
        </div>
        <div>
           
            <a class="btn btn-primary" href="javascript:history.back()">
                Quay lại 
            </a>
                

        </div>
    </div>
</body>
</html>
