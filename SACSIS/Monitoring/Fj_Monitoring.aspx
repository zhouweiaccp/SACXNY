<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fj_Monitoring.aspx.cs"
    Inherits="SACSIS.Monitoring.Fj_Monitoring" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>风机监控</title>
    <link href="../Js/jQueryEasyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../Js/jQueryEasyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/update8.css" rel="stylesheet" type="text/css" />
    <script src="../Js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
    	<!--

        var num = 0;
        $(function () {
            /*设置风机高度*/
            //            $("#dv_bg").css("height", pageHeight() - 30);
            //            $("#dv_lien").css("width", pageWidth() - 380);

            /*初始化数据*/
            Init();

            //            $("#showPointInfo").hide();

            //            for (var i = 0; i < num; i++) {
            //                $("#dv_" + i).click(function () {
            //                    $("#showPointInfo").show();
            //                    $('#showPointInfo').dialog({});
            //                });
            //            }
        });

        function ShowInfo(id) {
            //            $.post("Fj_Monitoring.aspx", { param: 'point', id: id }, function (data) {
            $("#showPointInfo").show();
            $('#showPointInfo').dialog({});
            //            }, 'json');
        }


        /*初始化页面数据   开始*/
        function Init() {
            $.post("Fj_Monitoring.aspx", { param: 'Init' }, function (data) {
                $("#dv_show").html(data.tb);
                num = data.num;
            }, 'json');
        }
        /*初始化页面数据   结束*/


        function pageHeight() {
            if ($.browser.msie) {
                return document.compatMode == "CSS1Compat" ? document.documentElement.clientHeight :
            document.body.clientHeight;
            } else {
                return self.innerHeight;
            }
        };

        function pageWidth() {
            if ($.browser.msie) {
                return document.compatMode == "CSS1Compat" ? document.documentElement.clientWidth :
            document.body.clientWidth;
            } else {
                return self.innerWidth;
            }
        }; 
            //-->
    </script>
</head>
<body style="background-color: #1c7ab0; text-align: center;">
    <div id="dv_show" style="text-align: center; float: inherit;">
    </div>
    <div id="showPointInfo" title="风机详细信息" data-options="iconCls:'icon-save'" style="padding: 5px;
        width: 700px; height: 450px; display: none;">
        <div id="dv_info" style="background-image: url(../img/fjjk_dt_bg.jpg); width: 680px;
            height: 420px;">
            <%--  <img src="../img/fjjk_dt_bg.jpg" height="491" width="798" />--%>
            <table>
                <tr>
                    <td>
                        <table style="background-image: url(../img/fjjk_dt_tb1.png); height: 372px; width: 240px;">
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table style="background-image: url(../img/fjjk_dt_tb2.png); height: 132px; width: 400px;">
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table style="background-image: url(../img/fjjk_dt_tb1.png); height: 372px; width: 240px;">
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</body>
</html>
