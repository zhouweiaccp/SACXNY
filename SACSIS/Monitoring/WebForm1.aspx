<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SACSIS.Monitoring.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Js/jQueryEasyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../Js/jQueryEasyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/update8.css" rel="stylesheet" type="text/css" />
    <script src="../Js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.easyui.min.js" type="text/javascript"></script>
</head>
<body style="background-color: #1c7ab0; text-align: center; font-size: 12px;">
    <table>
        <tr>
            <td>
                <div id="dv_0" onclick="ShowInfo('00001','1#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                1#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                3.88&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_1" onclick="ShowInfo('00002','2#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                2#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.97&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                131.1&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_2" onclick="ShowInfo('00003','3#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                3#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.16&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                96.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_3" onclick="ShowInfo('00004','4#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                4#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                5.53&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                159.3&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_4" onclick="ShowInfo('00005','5#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                5#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                5.08&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                175.4&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_5" onclick="ShowInfo('00006','6#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                6#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                7.09&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                233.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dv_5" onclick="ShowInfo('00006','6#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                6#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                3.88&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_6" onclick="ShowInfo('00007','7#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                7#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.97&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                131.1&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_7" onclick="ShowInfo('00008','8#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                8#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.16&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                96.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_8" onclick="ShowInfo('00009','9#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                9#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                5.53&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                159.3&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_9" onclick="ShowInfo('00010','10#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                10#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                5.08&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                175.4&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_10" onclick="ShowInfo('00011','11#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                11#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                7.09&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                233.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dv_10" onclick="ShowInfo('00011','11#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                11#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                3.88&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_11" onclick="ShowInfo('00012','12#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                12#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.97&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                131.1&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_12" onclick="ShowInfo('00013','13#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                13#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.16&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                96.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_13" onclick="ShowInfo('00014','14#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                14#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                5.53&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                159.3&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_14" onclick="ShowInfo('00015','15#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                15#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                5.08&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                175.4&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_15" onclick="ShowInfo('00016','16#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                16#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                7.09&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                233.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dv_15" onclick="ShowInfo('00016','16#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                16#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                3.88&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_16" onclick="ShowInfo('00017','17#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                17#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.97&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                131.1&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_17" onclick="ShowInfo('00018','18#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                18#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.16&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                96.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_18" onclick="ShowInfo('00019','19#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                19#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                5.53&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                159.3&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_19" onclick="ShowInfo('00020','20#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                20#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                5.08&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                175.4&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_20" onclick="ShowInfo('00021','21#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                21#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                7.09&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                233.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dv_20" onclick="ShowInfo('00021','21#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                21#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                3.88&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_21" onclick="ShowInfo('00022','22#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                22#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.97&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                131.1&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_22" onclick="ShowInfo('00023','23#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                23#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.16&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                96.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_23" onclick="ShowInfo('00024','24#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                24#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                5.53&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                159.3&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_24" onclick="ShowInfo('00025','25#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                25#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                5.08&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                175.4&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dv_25" onclick="ShowInfo('00026','26#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 10px;">
                        <tr>
                            <td height="20px" width="60px">
                                26#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                7.09&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                233.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="1">
                <div id="dv_25" onclick="ShowInfo('00026','26#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 15px;">
                        <tr>
                            <td height="20px" width="60px">
                                26#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                3.88&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td colspan="1">
                <div id="dv_26" onclick="ShowInfo('00027','27#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 15px;">
                        <tr>
                            <td height="20px" width="60px">
                                27#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.97&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                131.1&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td colspan="3">
                <div id="dv_27" onclick="ShowInfo('00028','28#机组')" style="margin-top: 5px; margin-left: 10px;
                    width: 220px; height: 107px; background-image: url(../img/fjjk_bg.jpg);">
                    <table style="float: right; margin-top: 15px; margin-right: 15px;">
                        <tr>
                            <td height="20px" width="60px">
                                28#机组
                            </td>
                            <td height="20px" valign="middle" align="left">
                                风&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;速:
                            </td>
                            <td height="20px" width="60px">
                                4.16&nbsp;m/s
                            </td>
                        </tr>
                        <tr>
                            <td height="20px">
                            </td>
                            <td height="20px" valign="middle" align="left">
                                有功功率:
                            </td>
                            <td height="20px" width="60px">
                                96.6&nbsp;kw
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <img src="../img/fjjk_yx.png" />
                            </td>
                            <td height="20px" valign="middle" align="left">
                                无功功率:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;kvar
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" valign="middle" align="left">
                                转&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数:
                            </td>
                            <td height="20px" width="60px">
                                0&nbsp;rpm
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</body>
</html>
