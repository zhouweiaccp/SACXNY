<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainConnect.aspx.cs" Inherits="WebApplication2.WebForm4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>总公司情况</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script src="../Js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Js/highcharts.js" type="text/javascript"></script>
    <script src="../Js/highcharts-more.js" type="text/javascript"></script>
    <script src="../Js/exporting.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        $(function () {
            ssfh(); //实时负荷
            zzjl(d2_1); //总装机量
            zzjl(d2_2);
            zzjl(d2_3);
            fdjh(d4_1); //发电计划
            fdjh(d4_2);
            zjxm(d6_1); //在建项目
            zjxm(d6_2)

        });


        function ssfh() {
            $('#d1').highcharts({
                chart: {
                    type: 'area'
                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    labels: {
                        formatter: function () {
                            return this.value; // clean, unformatted number for year
                        }
                    }
                },
                yAxis: {
                    title: {
                        text: ''
                    },
                    labels: {
                        formatter: function () {
                            return this.value / 1000 + 'k';
                        }
                    }
                },
                tooltip: {
                    pointFormat: '{series.name} produced <b>{point.y:,.0f}</b><br/>warheads in {point.x}'
                },
                plotOptions: {
                    area: {
                        pointStart: 1940,
                        marker: {
                            enabled: false,
                            symbol: 'circle',
                            radius: 2,
                            states: {
                                hover: {
                                    enabled: true
                                }
                            }
                        }
                    }
                },
                series: [{
                    name: '总电量',
                    data: [null, null, null, null, null, 6, 11, 32, 110, 235, 369, 640,
                    1005, 1436, 2063, 3057, 4618, 6444, 9822, 15468, 20434, 24126,
                    27387, 29459, 31056, 31982, 32040, 31233, 29224, 27342, 26662,
                    26956, 27912, 28999, 28965, 27826, 25579, 25722, 24826, 24605,
                    24304, 23464, 23708, 24099, 24357, 24237, 24401, 24344, 23586,
                    22380, 21004, 17287, 14747, 13076, 12555, 12144, 11009, 10950,
                    10871, 10824, 10577, 10527, 10475, 10421, 10358, 10295, 10104]
                }, {
                    name: '火电',
                    data: [null, null, null, null, null, null, null, null, null, null,
                5, 25, 50, 120, 150, 200, 426, 660, 869, 1060, 1605, 2471, 3322,
                4238, 5221, 6129, 7089, 8339, 9399, 10538, 11643, 13092, 14478,
                15915, 17385, 19055, 21205, 23044, 25393, 27935, 30062, 32049,
                33952, 35804, 37431, 39197, 45000, 43000, 41000, 39000, 37000,
                35000, 33000, 31000, 29000, 27000, 25000, 24000, 23000, 22000,
                21000, 20000, 19000, 18000, 18000, 17000, 16000]
                }],
                exporting: {
                    enabled: false //用来设置是否显示‘打印’,'导出'等功能按钮，不设置时默认为显示 
                }
            });

        }

        function zzjl(a) {
            $.ajax({
                url: "MainConnect.aspx?fncode=zzjl",
                type: "POST",
                beforeSend: function () {
                    //Handle the beforeSend event
                },
                success: function (json) {
                   // json = eval("("+json+")");
                    var json = $.parseJSON(json);
                    var chart = new Highcharts.Chart({
                        chart: {
                            type: 'gauge',
                            renderTo: a,
                            backgroundColor: 'rgba(255, 255, 255, 0)',
                            plotBackgroundColor: null,
                            plotBackgroundImage: null,
                            plotBorderWidth: 0,
                            plotShadow: false
                        },

                        title: {
                            text: ''
                        },

                        pane: {
                            startAngle: -150,
                            endAngle: 150,
                            background: [{
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
	                    [0, '#FFF'],
	                    [1, '#333']
	                ]
                                },
                                borderWidth: 0,
                                outerRadius: '109%'
                            }, {
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
	                    [0, '#333'],
	                    [1, '#FFF']
	                ]
                                },
                                borderWidth: 1,
                                outerRadius: '107%'
                            }, {
                            // default background
                        }, {
                            backgroundColor: '#DDD',
                            borderWidth: 0,
                            outerRadius: '105%',
                            innerRadius: '103%'
                        }]
                    },

                    // the value axis
                    yAxis: {
                        min: 0,
                        max: 400,

                        minorTickInterval: 'auto',
                        minorTickWidth: 1,
                        minorTickLength: 10,
                        minorTickPosition: 'inside',
                        minorTickColor: '#666',

                        tickPixelInterval: 30,
                        tickWidth: 2,
                        tickPosition: 'inside',
                        tickLength: 10,
                        tickColor: '#666',
                        labels: {
                            step: 2,
                            rotation: 'auto'
                        },
                        title: {
                            text: ''
                        },
                        plotBands: [{
                            from: 0,
                            to: 400,
                            color: '#55BF3B' // green
                        }]
                    },

                    series: [{
                        name: 'Speed',
                        data: json.data,
                        tooltip: {
                            valueSuffix: ' km/h'
                        }
                    }],
                    exporting: {
                        enabled: false //用来设置是否显示‘打印’,'导出'等功能按钮，不设置时默认为显示 
                    }
                });
            },
            error: function (x, e) {
                alert(x.responseText);
            },
            complete: function () {
                //Handle the complete event
            }
        });
            
    }

        function fdjh(a) {
            var chart = new Highcharts.Chart({
                chart: {
                    renderTo: a,
                    type: 'column'
                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    categories: [
                    'Jan',
                    'Feb',
                    'Mar',
                    'Apr',
                    'May',
                    'Jun',
                    'Jul',
                    'Aug',
                    'Sep',
                    'Oct',
                    'Nov',
                    'Dec'
                ]
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: ''
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                    '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: [{
                    name: '总电量',
                    data: [49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4]

                }, {
                    name: '火电',
                    data: [83.6, 78.8, 98.5, 93.4, 106.0, 84.5, 105.0, 104.3, 91.2, 83.5, 106.6, 92.3]

                }, {
                    name: '水电',
                    data: [48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0, 59.6, 52.4, 65.2, 59.3, 51.2]

                }, {
                    name: '风电',
                    data: [42.4, 33.2, 34.5, 39.7, 52.6, 75.5, 57.4, 60.4, 47.6, 39.1, 46.8, 51.1]

                }],
                exporting: {
                    enabled: false //用来设置是否显示‘打印’,'导出'等功能按钮，不设置时默认为显示 
                }
            });
        }

        function zjxm(a) {
            var chart = new Highcharts.Chart({
                chart: {
                    renderTo: a,
                    backgroundColor: '#e7ebef',
                    plotBackgroundColor: '#f3f6f8',
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    spacingTop: 0,            //图表上方的空白(好用)
                    spacingRight: 0,
                    spacingBottom: 0,
                    spacingLeft: 0
                },
                width: 400, //图框（最外层）宽(默认800)
                height: 250,
                title: {
                    text: ''
                },
                tooltip: {
                    formatter: function () {
                        return '<b>' + this.point.name + '</b>: ' + this.percentage + ' %';
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false,
                            color: '#000000',
                            connectorColor: '#000000',
                            formatter: function () {
                                return '';
                            }
                        },
                        showInLegend: true
                    }
                },
                legend: {
                    layout: 'vertical',
                    backgroundColor: '#FFFFFF',
                    align: 'left',
                    verticalAlign: 'top',
                    x: 10,
                    y: 0,
                    floating: true,
                    shadow: true
                },
                series: [{
                    type: 'pie',
                    name: '月进度',
                    data: [
                                ['在建容量', 55.0],
                                ['月计划投产', 20.0],
                                ['月实际投产', 25.0]
                            ]
                }],
                exporting: {
                    enabled: false //用来设置是否显示‘打印’,'导出'等功能按钮，不设置时默认为显示 
                }
            });

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="div" style="margin:auto; text-align:center;width:950px">
        <div id="div1" style="width: 250px; height: 200px; border: solid 1px #8C9EB5; float: left;
            margin: 2px">
            <div id="div1_title" style="background-image: url(../img/20131115110424.jpg);
                width: 250px; height: 19px; background-repeat: repeat-x; border-bottom: solid 1px #8C9EB5; font-family:SimHei; font-size:14px; line-height:20px">实时负荷对比
            </div>
            <div id="d1" style="width:250px; height:180px">
            </div>
        </div>
        <div id="div2" style="width: 450px; height: 200px; border: solid 1px #8C9EB5; float: left;
            margin: 2px">
            <div id="div7" style="background-image: url(../img/20131115110424.jpg);
                width: 450px; height: 19px; background-repeat: repeat-x; border-bottom: solid 1px #8C9EB5 ;font-family:SimHei; font-size:14px; line-height:20px">总装机量
            </div>
            <div id="d2" style="width: 450px; height: 180px">
                <table>
                    <tr>
                        <td align="center" valign="top" style="font-size: 13px">
                            发电量
                        </td>
                        <td align="center" valign="top" style="font-size: 13px">
                            运行容量
                        </td>
                        <td align="center" valign="top" style="font-size: 13px">
                            供热量
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <div style="width: 150px; height: 130px; margin: 0 auto" id="d2_1">
                            </div>
                        </td>
                        <td align="right" valign="top">
                            <div style="width: 150px; height: 130px; margin: 0 auto" id="d2_2">
                            </div>
                        </td>
                        <td align="right" valign="top">
                            <div style="width: 150px; height: 130px; margin: 0 auto" id="d2_3">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" style="font-size: 13px">
                            累计发电量
                        </td>
                        <td align="center" valign="top" style="font-size: 13px">
                            总装机容量
                        </td>
                        <td align="center" valign="top" style="font-size: 13px">
                            累计供热量
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" style="font-size: 13px">
                            <div id="divlj1" runat="server">
                            </div>
                        </td>
                        <td align="center" valign="top" style="font-size: 13px">
                            <div id="divlj2" runat="server">
                            </div>
                        </td>
                        <td align="center" valign="top" style="font-size: 13px">
                            <div id="divlj3" runat="server">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="div3" style="width: 200px; height: 200px; border: solid 1px #8C9EB5; float: left;
            margin: 2px">
            <div id="div8" style=" background-image: url(../img/20131115110424.jpg);
                width: 200px; height: 19px; background-repeat: repeat-x; border-bottom: solid 1px #8C9EB5;font-family:SimHei; font-size:14px; line-height:20px">成本效益指标展示
            </div>
            <div id="d3" style="width:200px; height:180px">
            </div>
        </div>
        <div id="div4" style="width: 250px; height: 300px; border: solid 1px #8C9EB5; float: left;
            margin: 2px">
            <div id="div9" style="background-image: url(../img/20131115110424.jpg);
                width: 250px; height: 19px; background-repeat: repeat-x; border-bottom: solid 1px #8C9EB5;font-family:SimHei; font-size:14px; line-height:20px">发电量计划完成情况
            </div>
            <div id="d4" style="width: 250px; height: 280px">
                <div id="d4_1" style="width: 250px; height: 140px">
                </div>
                <div id="d4_2" style="width: 250px; height: 140px">
                </div>
            </div>
        </div>
        <div id="div5" style="width: 450px; height: 300px; border: solid 1px #8C9EB5; float: left;
            margin: 2px">
            <div id="div10" style="background-image: url(../img/20131115110424.jpg);
                width: 450px; height: 19px; background-repeat: repeat-x; border-bottom: solid 1px #8C9EB5;font-family:SimHei; font-size:14px; line-height:20px">项目分布图
            </div>
            <div id="d5" style="width: 450px; height: 280px">
            </div>
        </div>
        <div id="div6" style="width: 200px; height: 300px; border: solid 1px #8C9EB5; float: left;
            margin: 2px">
            <div id="div11" style=" background-image: url(../img/20131115110424.jpg);
                width: 200px; height: 19px; background-repeat: repeat-x; border-bottom: solid 1px #8C9EB5;font-family:SimHei; font-size:14px; line-height:20px">在建项目进度情况
            </div>
            <div id="d6" style="width: 200px; height: 280px">
                <div id="d6_1" style="width: 200px; height: 140px">
                </div>
                <div id="d6_2" style="width: 200px; height: 140px">
                </div>
            </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
