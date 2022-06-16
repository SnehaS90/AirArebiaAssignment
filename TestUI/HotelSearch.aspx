<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelSearch.aspx.cs" Inherits="TestUI.HotelSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotels</title>
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="JS/genericJS.js"></script>
</head>
<body>
    <div>
    <div style="width:30%; float:left; border: 1px; height: 100%; border-color:black;">
        <label for="search"><b>Search By City</b></label><br>
            <input type="text" id="txtSearch" placeholder="Enter City to Search" name="search">
            <button type="button" onclick="SearchHotelByCity()">Search</button> 
     </div>
       <div><span>Total Hotels Count : </span> <span id="divCount"></span> </div>
    <div id="mainSearch" style="width:80%; float:right;border: 1px; height: 100%; border-color:black;">
    
     </div>
    </div>
</body>
</html>

<script type="text/javascript">
    $(document).ready(function () {
        GetHotels();
    });

</script>