<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SACSIS.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Js/jquery-1.8.2.min.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        $(function () {
            $.ajax({
                url: "WebForm1.aspx?funCode=init",
                type: "POST",
                beforeSend: function () {
                    //Handle the beforeSend event
                },
                success: function (json) {
                    //json = eval("("+json+")");
                    var json = $.parseJSON(json);

                   // alert(json.data);
                    $("#tabId").append(json.data);
                },
                error: function (x, e) {
                    alert(x.responseText);
                },
                complete: function () {
                    //Handle the complete event
                }
            });

            //            $.post("WebForm1.aspx", { funCode: 'init' }, function (data) {
            //                alert(data);
            //                //var json = $.parseJSON(json);
            //                //$("tabId").apend(data.data);
            //                alert(data);
            //            }, 'json');

        });


    </script>

    <style type="text/css">
    table td
    {
        border-width: 1px;
	    padding: 5px;
	    border-style: solid;
	    border-color: #666666;
	    background-color: #ffffff;
	}

    table
    {
        font-size:13px;
	    color:#333333;
	    border-width: 1px;
	    border-color: #666666;
	    border-collapse: collapse;	}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tabId">
    
    </div>
    </form>
</body>
</html>
