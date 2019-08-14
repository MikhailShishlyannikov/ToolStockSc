﻿<% 
    Response.StatusCode = 500;
    Response.TrySkipIisCustomErrors = true;
%>

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Error404</title>
    <link href="http://toolstocksc.sc/Areas/Foundation/ErrorHandling/Content/ErrorPage.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Encode+Sans+Semi+Condensed:100,200,300,400" rel="stylesheet">
</head>
<body id="ErrorPage" class="loading">
<h1>500</h1>
<h2>Oops! Unexpected Error <b>:(</b></h2>
<h2>
    <a href="javascript:history.go(-1)">Go back to the previous page</a>
</h2>

<div class="gears">
    <div class="gear one">
        <div class="bar"></div>
        <div class="bar"></div>
        <div class="bar"></div>
    </div>
    <div class="gear two">
        <div class="bar"></div>
        <div class="bar"></div>
        <div class="bar"></div>
    </div>
    <div class="gear three">
        <div class="bar"></div>
        <div class="bar"></div>
        <div class="bar"></div>
    </div>
</div>
<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
<script type="text/javascript">
    $(function () {
        setTimeout(function () {
            $('body').removeClass('loading');
        }, 1000);
    });
</script>
</body>
</html>