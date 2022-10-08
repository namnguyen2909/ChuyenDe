<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="CPanel.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    <title>MultiSelect DropDownList with CheckBoxes in ASP.Net</title>  
</head>  
<body>  
    <form id="form1" runat="server">  
    
        <link href="/Templates/css/bootstrap.css" rel="stylesheet" />
    <link href="/Templates/css/bootstrap-theme.css" rel="stylesheet" />
    <script src="/Templates/js/jquery-1.10.2.min.js"></script>

    <!-- BEGIN: Jquery for All of Format (Interger, Date, Email, Card Number, ... -->
    <script src="/Templates/js/jquery.formance.min.js"></script>
    <script src="/Templates/js/awesome_form.js"></script>
    <!-- END: Jquery for All of Format (Interger, Date, Email, Card Number, ... -->
    
    <!-- BEGIN: Jquery for Accounting Format (Currency Format) -->
    <script type="text/javascript" src="/Templates/js/accounting.min.js"></script>
    <!-- END: Jquery for Accounting Format (Currency Format) -->

        

<!--<script type="text/javascript" src="/Templates/js/jd.gallery.js"></script>-->
<!--<script type="text/javascript" src="/Templates/js/jd.gallery.transitions.js"></script>-->
<script type="text/javascript" src="/Templates/js/sweetalert-dev.js"></script>
<script type="text/javascript" src="/Templates/js/lib_waiting_load_page.js"></script>
    



  
<!--<script type="text/javascript" src="/Templates/js/jv.moomenu.js"></script>-->


    <link rel="stylesheet" type="text/css" href="/Templates/style.css" />
    <link rel="stylesheet" type="text/css" href="/Templates/Site.css" />
    <link href="/Templates/css/atcl_style.css" rel="stylesheet" />



    <link rel="stylesheet" href="/Templates/css/system.css" type="text/css"/>
    <link rel="stylesheet" href="/Templates/css/general.css" type="text/css"/>
	
    <link type="text/css" rel="stylesheet" media="screen" href="/Templates/css/home.css"/>
    <link type="text/css" rel="stylesheet" media="screen" href="/Templates/css/layout.css"/>
    <link type="text/css" rel="stylesheet" media="screen" href="/Templates/css/style.css"/>

    <link rel="stylesheet" href="/Templates/css/default.css" type="text/css"/>
    <link rel="stylesheet" href="/Templates/css/template.css" type="text/css"/>
    <link rel="stylesheet" href="/Templates/css/typo.css" type="text/css"/>
    <link rel="stylesheet" href="/Templates/css/blue.css" type="text/css"/>


    <link rel="stylesheet" href="/Templates/css/styles.css" type="text/css"/>
    <link rel="stylesheet" href="/Templates/css/calendar-jos.css" type="text/css" title="green" media="all"/>
    <link rel="stylesheet" href="/Templates/css/jv.moomenu.css" type="text/css"/>
    <link rel="stylesheet" href="/Templates/css/sweetalert.css" type="text/css"/>
    <link rel="stylesheet" href="/Templates/css/jvslideshow.php" type="text/css"/>
    <script type="text/javascript" src="/Templates/js/lib_js.js"></script>

    
    <link href="/Templates/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/Templates/js/bootstrap.min.js"></script>
    <link href="/Templates/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="/Templates/js/bootstrap-multiselect.js"></script>
    
    
   Employee : <asp:ListBox ID="lstEmployee" runat="server" SelectionMode="Multiple">  
        <asp:ListItem Text="Nikunj Satasiya" Value="1" />  
        <asp:ListItem Text="Dev Karathiya" Value="2" />  
        <asp:ListItem Text="Hiren Dobariya" Value="3" />  
        <asp:ListItem Text="Vivek Ghadiya" Value="4" />  
        <asp:ListItem Text="Pratik Pansuriya" Value="5" />  
    </asp:ListBox>  
    <asp:Button Text="Submit" runat="server" />  
    </form>  

    <script type="text/javascript">
        $(function () {
            $('[id*=lstEmployee]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>  
</body>  
</html>  