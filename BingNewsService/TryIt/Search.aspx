﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="NewsSearchPortal.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>News Search Service</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <link href="Style/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <%--<link href='http://fonts.googleapis.com/css?family=Lato' rel='stylesheet' type='text/css'>--%>
    <link href='http://fonts.googleapis.com/css?family=Lato:300' rel='stylesheet' type='text/css'>
    <link href="Style/custom.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
        });
        var GetJson = function () {
            $.ajax({
                type: "GET",
                url: "http://localhost:28823/NewsService.svc/json/" + document.getElementById("txtQuery").value,
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var result = data.JSONDataResult;
                    var collectionLength = result.length;
                    for (var i = 0; i < collectionLength; i++) {
                        var myDiv = document.createElement('div');
                        var myLink = document.createElement('a');
                        myDiv.id = 'myDiv' + i;
                        myLink.id = 'myLink' + i;
                        document.body.appendChild(myDiv);
                        if (result[i].ID != "00000000-0000-0000-0000-000000000000") {
                            document.getElementById('myDiv' + i).innerHTML =
                                result[i].Description +
                                result[i].Source +
                                result[i].Title +
                                result[i].Url;
                            document.getElementById('myDiv' + i).style.border = ("1px solid black");
                        }

                    }
                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="container">
            <div class="navbar navbar-default navbar-fixed-top" style="background-color: rgb(56, 196, 119);"> 
                <div class="container">
                    <div class="navbar-header">
                        <a class="navbar-brand active" href="#" style="color: white; font-size: 30px;">News Search</a>
                       <br /> <asp:Label ID="Label1" runat="server" Text="Finding news about specific topics, for example, find all  news articles about ASU (Arizona State University)."></asp:Label>
                    </div>


                    <div class="navbar-collapse collapse">
                        <%--<div class="form-group">--%>
                        
                            <div class="row">

                                <div class="col-md-5" style="margin-top: 8px;">
                                    <input id="txtQuery" class="form-control noRadius" type="text" placeholder="Search">
                                    <br />

                                    <asp:Label ID="Label2" runat="server" Text="URL: http://localhost:28823/NewsService.svc"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text="Endpoints are kerword as a parameter and  function returning a list "></asp:Label>
                                &nbsp;&nbsp;&nbsp;

                                </div>
                                <div class="col-md-5" style="margin-top: 8px;">
                                    <input type="button" id="jsonButton" onclick="GetJson()" value="Search" class="btn-primary noRadius" />
                                </div>
                            </div>


                        <%--</div>--%>
                    </div>

                </div>
            </div>
            <br />
            <br />
            <div id="myDiv">
            </div>

            <div class="row">
                
                <div class="col-md-8" ></div>
              
                <div class="col-md-9" style="border:1px solid rgb(232,232,232);margin-top: 45px;min-height:25px;" id="mydivmain">
                 <%--   <div class="col-md-1">Title</div>
                    <div class="col-md-1">Source</div>
                    <div class="col-md-1">Url</div>
                    <div class="col-md-5">Description</div>--%>
                </div>
            </div>

        </div>
    </form>
</body>

</html>
