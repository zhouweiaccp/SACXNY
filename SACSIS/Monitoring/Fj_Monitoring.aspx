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
        width: 890px; height: 490px; display: none;">
        <div id="dv_info" style="background-image: url(../img/fjjk_dt_bg.jpg); width: 890px;
            height: 450px; font-size: 12px; color: White;">
            <%--  <img src="../img/fjjk_dt_bg.jpg" height="491" width="798" />--%>
            <table style="margin-left: 150px; background-image: url(../img/fjjk_dt_tb3.png);
                width: 160px; height: 45px;">
                <tr>
                    <td>
                        1#机组
                    </td>
                </tr>
            </table>
            <table style="position: absolute; margin-top: 25px;">
                <tr>
                    <td>
                        <table style="background-image: url(../img/fjjk_dt_tb1.png); height: 372px; width: 240px;">
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    风速：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp;0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    有功功率：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    无功功率：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    功率因数：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    功率因数设定值：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    转子速度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    母线频率：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp;0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    发电机速度(CPU)：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    发电机速度(PLC)：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp;0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    塔筒偏转角度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    机舱位置：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table style="background-image: url(../img/fjjk_dt_tb2.png); margin-top: 220px; height: 132px;
                            width: 400px;">
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    液压预压：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp;0000
                                </td>
                                <td align="right" valign="middle" width="120px">
                                    机舱转动：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    10秒风向差值：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                                <td align="right" valign="middle" width="120px">
                                    转距实际差值：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    1秒风向差值：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                                <td align="right" valign="middle" width="120px">
                                    转距设定值：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table style="background-image: url(../img/fjjk_dt_tb1.png); height: 372px; width: 240px;">
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    环境温度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp;0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    机舱温度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    无功功率：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    齿轮箱温度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    齿轮箱轴承温度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    尾轴轴承温度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    发电机1点温度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp;0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    发电机2点温度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="140px">
                                    发电机冷却空气温度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp;0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    轴承A点温度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="120px">
                                    轴承B点温度：
                                </td>
                                <td align="left" valign="middle">
                                    &nbsp;&nbsp;&nbsp;&nbsp; 0000
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
