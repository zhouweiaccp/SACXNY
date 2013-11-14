﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BGFJDB.aspx.cs" Inherits="Web.LineAndChart.BGFJDB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>标杆风机对比</title>
    <link href="../js/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <link href="../UI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../UI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/zTreeStyle/FJ.css" rel="stylesheet" type="text/css" />
    <link href="../css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="../js/WPPLine.js" type="text/javascript"></script>
    <script src="../js/Chart.js" type="text/javascript"></script>
    <script src="../UI/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery.ztree.core-3.5.js" type="text/javascript"></script>
    <script src="../js/jquery.ztree.excheck-3.5.js" type="text/javascript"></script>
    <script src="../UI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
    	<!--
        var idbg = '';
        var namebg = '';
        var idpt = '';
        var namept = '';
        var settingLeft = {
            view: {
                selectedMulti: false
            },
            check: {
                enable: true
            },
            data: {
                simpleData: {
                    enable: true
                }
            },
            callback: {
                beforeCheck: beforeCheck,
                onCheck: onCheck
            }
        };
        var settingRight = {
            view: {
                selectedMulti: false
            },
            check: {
                enable: true
            },
            data: {
                simpleData: {
                    enable: true
                }
            },
            callback: {
                beforeCheck: beforeCheck,
                onCheck: onCheckPt
            }
        };

        function beforeCheck(treeId, treeNode) {
            return (treeNode.doCheck !== false);
        }

        function onCheck(e, treeId, treeNode) {
            if (treeNode.checked == true) {
                idbg += "'" + treeNode.id + "',";
                namebg += treeNode.name + ',';
            } else {
                idbg = idbg.replace("'" + treeNode.id + "',", '');
                namebg = namebg.replace("'" + treeNode.name + "',", '');
            }
        }

        function onCheckPt(e, treeId, treeNode) {
            if (treeNode.checked == true) {
                idpt += "'" + treeNode.id + "',";
                namept += treeNode.name + ',';
            } else {
                idpt = idpt.replace("'" + treeNode.id + "',", '');
                namept = namept.replace("'" + treeNode.name + "',", '');
            }
        }

        $(function () {

            $("#dv_lien").css("width", pageWidth() - 380);
            /*设置风机高度*/
            $("#dv_bg").css("height", pageHeight() - 30);
            $("#tree_bg").css("height", pageHeight() - 40);

            $("#dv_pt").css("height", pageHeight() - 30);
            $("#tree_pt").css("height", pageHeight() - 40);
            /*设置风机高度*/


            $("#grid").hide();


            /*初始化数据*/
            Init();

            $("#GValue").change(function () {
                //清空记录
                idbg = '';
                idpt == '';
                namebg = '';
                namept = '';
                $.post("BGFJDB.aspx", { param: 'unit', id: $("#GValue").val() }, function (data) {
                    if (data.infoBg != "" && data.infoBg != null) {
                        var zNodes = eval(data.infoBg);
                        $.fn.zTree.init($("#tree_bg"), settingLeft, zNodes);
                    }

                    if (data.infoPt != "" && data.infoPt != null) {
                        var zNodes = eval(data.infoPt);
                        $.fn.zTree.init($("#tree_pt"), settingRight, zNodes);
                    }
                }, 'json');
            });

            $("#ZType").change(function () {
                //清空记录
                idbg = '';
                idpt == '';
                namebg = '';
                namept = '';
                $.post("BGFJDB.aspx", { param: 'unit', id: $("#GValue").val() }, function (data) {
                    if (data.infoBg != "" && data.infoBg != null) {
                        var zNodes = eval(data.infoBg);
                        $.fn.zTree.init($("#tree_bg"), settingLeft, zNodes);
                    }

                    if (data.infoPt != "" && data.infoPt != null) {
                        var zNodes = eval(data.infoPt);
                        $.fn.zTree.init($("#tree_pt"), settingRight, zNodes);
                    }
                }, 'json');
            });

            $("#btnSearchb").click(function () {
                if (idbg == '' && idpt == '') {
                    $.messager.alert('标杆风机对比', '请先选择风机在进行查询!', 'warning');
                } else {
                    $.post("BGFJDB.aspx", { param: 'line', id_bg: escape(idbg), name_bg: escape(namebg), id_pt: escape(idpt), name_pt: escape(namept), gq: $("#GValue").val(), type: $("#ZType").val(), sTime: $("#txtS").val(), eTime: $("#txtE").val() }, function (data) {
                        if ($("#ZType").val() == "1" || $("#ZType").val() == "2") {
                            Hc();
                            SetLine(data);
                            $("#grid").show();
                            $("#grid").css("width", pageWidth() - 380);
                            $("#grid").css("height", pageHeight() - 500);
                            showGrid(data);
                        } else {
                            HT();
                            CHART(data);
                        }
                    }, 'json');
                }
            });
        });

        function showGrid(data) {
            if (data.rows.length == 0) {
                $.messager.alert("结果", "没有数据!", "info", null);
            }
            var options = {
                //                width: "auto",
                rownumbers: true
                //fitColumns: true,
                //striped: true,
                //align: 'center',
                //loadMsg: "正在努力为您加载数据", //加载数据时向用户展示的语句
                //collapsible: true,
                //remoteSort: false
            };
            options.columns = eval(data.columns); //把返回的数组字符串转为对象，并赋于datagrid的column属性  
            var dataGrid = $("#grid");
            dataGrid.datagrid(options); //根据配置选项，生成datagrid
            dataGrid.datagrid("loadData", data.rows); //载入本地json格式的数据  
        }

        /*初始化页面数据   开始*/
        function Init() {
            $.post("BGFJDB.aspx", { param: 'Init' }, function (data) {
                var lists = data.list;
                $("#FValue").empty();
                if (lists != null) {
                    for (var i = 0; i < lists.length; i++) {
                        $("#FValue").append("<option value='" + lists[i].ID + "'>" + lists[i].NAME + "</option>");
                    }
                } else {
                    $("#FValue").append("<option value='0'>没有分公司数据</option>");
                }

                var lists = data.lt;
                $("#GValue").empty();
                if (lists != null) {
                    for (var i = 0; i < lists.length; i++) {
                        $("#GValue").append("<option value='" + lists[i].T_PERIODID + "'>" + lists[i].T_PERIODDESC + "</option>");
                    }
                } else {
                    $("#GValue").append("<option value='0'>没有工期数据</option>");
                }

                $("#ZType").empty();
                $("#ZType").append("<option value='1'>功率</option>");
                $("#ZType").append("<option value='2'>风速</option>");
                $("#ZType").append("<option value='3'>发电量</option>");
                $("#ZType").append("<option value='4'>停机时间</option>");

                if (data.listB != "" && data.listB != null) {
                    var zNodes = eval(data.listB);
                    $.fn.zTree.init($("#tree_bg"), settingLeft, zNodes);
                }

                if (data.listF != "" && data.listF != null) {
                    var zNodes = eval(data.listF);
                    $.fn.zTree.init($("#tree_pt"), settingRight, zNodes);
                }
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
<body style="font-size: 12px;">
    <script src="../js/highcharts.js" type="text/javascript"></script>
    <script src="../js/data.js" type="text/javascript"></script>
    <script src="../js/exporting.js" type="text/javascript"></script>
    <div id="dv_body">
        <div id="dv_jz" style="width: 340px; float: left;">
            <div id="dv_bg" class="zTreeDemoBackground left" style="float: left;">
                <ul id="tree_bg" class="ztree">
                </ul>
            </div>
            <div id="dv_pt" class="zTreeDemoBackground left" style="float: right; margin-left: -40px;">
                <ul id="tree_pt" class="ztree">
                </ul>
            </div>
        </div>
        <div id="dv_lien" style="float: right;">
            <div id="dv_d">
                &nbsp;&nbsp;&nbsp;公&nbsp;&nbsp;&nbsp;&nbsp;司
                <select id="FValue" style="width: 120px; text-align: center;">
                </select>
                &nbsp;&nbsp;&nbsp;风&nbsp;&nbsp;&nbsp;&nbsp;场&nbsp;
                <select id="GValue" style="width: 120px; text-align: center;">
                </select>&nbsp;&nbsp;&nbsp;指标类型&nbsp;
                <select id="ZType" style="width: 120px; text-align: center;">
                </select><br />
                <br />
                <span>&nbsp; &nbsp;开始时间</span>
                <input type="text" id="txtS" style="text-align: center; width: 180px;" runat="server"
                    readonly="readonly" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" />&nbsp; &nbsp; <span>结束时间</span>
                <input type="text" id="txtE" style="text-align: center; width: 180px;" runat="server"
                    readonly="readonly" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" />
                &nbsp;&nbsp;&nbsp;&nbsp;<a id="btnSearchb" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-ok'">查&nbsp;&nbsp;询</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div id="container" style="margin-top: 10px;">
            </div>
            <table id="grid" style="margin-top: 20px;">
            </table>
        </div>
    </div>
</body>
</html>
