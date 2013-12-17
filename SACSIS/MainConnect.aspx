<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainConnect.aspx.cs" Inherits="WebApplication2.WebForm4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>总公司情况</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="../Js/jQueryEasyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../Js/jQueryEasyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../Js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Js/highcharts.js" type="text/javascript"></script>
    <script src="../Js/highcharts-more.js" type="text/javascript"></script>
    <script src="../Js/exporting.js" type="text/javascript"></script>

    <style type="text/css">
    body
    {
       font-family:微软雅黑;
	}
	#tabId td {border: solid thin #6BA5BD;}
	
	
	/*内蒙古*/
 
    div#lmg:hover {background-color:black }
    div#ty:hover { background-color:Yellow}
    </style>

    <script type="text/javascript" language="javascript">
        $(function () {

            $("#hd_progressbar").progressbar({
                value: 59
            })
            $("#sd_progressbar").progressbar({
                value: 59
            })
            $("#fd_progressbar").progressbar({
                value: 59
            })
            $("#tyn_progressbar").progressbar({
                value: 59
            })
            $("#fbs_progressbar").progressbar({
                value: 59
            })
            $("#qt_progressbar").progressbar({
                value: 59
            })


            LOADCHARTS();
        });


        function LOADCHARTS() {

            $('#container1').highcharts({
                chart: {
                    type: 'spline'
                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                colors: [
                '#32E1FC', '#0E91C9', '#023668'
                ],
                xAxis: {
                    type: 'datetime'
                },
                yAxis: {
                    title: {
                        text: ''
                    },
                    min: 0,
                    minorGridLineWidth: 0,
                    gridLineWidth: 0,
                    alternateGridColor: null,
                    plotBands: [{ // Light air
                        from: 0.3,
                        to: 1.5,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Light breeze
                        from: 1.5,
                        to: 3.3,
                        color: 'rgba(0, 0, 0, 0)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Gentle breeze
                        from: 3.3,
                        to: 5.5,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Moderate breeze
                        from: 5.5,
                        to: 8,
                        color: 'rgba(0, 0, 0, 0)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Fresh breeze
                        from: 8,
                        to: 11,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Strong breeze
                        from: 11,
                        to: 14,
                        color: 'rgba(0, 0, 0, 0)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // High wind
                        from: 14,
                        to: 15,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }]
                },
                tooltip: {
                    valueSuffix: ' m/s'
                },
                plotOptions: {
                    spline: {
                        lineWidth: 2,
                        states: {
                            hover: {
                                lineWidth: 3
                            }
                        },
                        marker: {
                            enabled: false
                        },
                        pointInterval: 3600000, // one hour
                        pointStart: Date.UTC(2009, 9, 6, 0, 0, 0)
                    }
                },
                series: [{
                    name: '火电',
                    data: [4.3, 5.1, 4.3, 5.2, 5.4, 4.7, 3.5, 4.1, 5.6, 7.4, 6.9, 7.1,
                    7.1, 7.5, 8.1, 6.8, 3.4, 2.1, 1.9, 2.8, 2.9, 1.3, 4.4, 4.2,
                    3.0, 3.0]

                }, {
                    name: '风电',
                    data: [0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.1, 0.0, 0.3, 0.0,
                    3.0, 3.3, 4.8, 5.0, 4.8, 5.0, 3.2, 2.0, 0.9, 0.4, 0.3, 0.5, 0.4]
                },{
                    name: '水电',
                    data: [2.3, 5.1, 4.3, 5.2, 5.4, 4.7, 3.5, 4.1, 5.6, 7.4, 6.9, 7.1,
                    7.1, 7.5, 3.1, 6.8, 3.4, 2.1, 1.9, 2.8, 2.9, 1.3, 4.4, 4.2,
                    3.0, 3.0]

                }
                ],exporting: {
                                    enabled: false //用来设置是否显示‘打印’,'导出'等功能按钮，不设置时默认为显示 
                                }
            ,
                navigation: {
                    menuItemStyle: {
                        fontSize: '10px'
                    }
                }
            });
            $('#container2').highcharts({
                chart: {
                    type: 'spline'
                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                colors: [
                '#32E1FC', '#0E91C9', '#023668'
                ],
                xAxis: {
                    type: 'datetime'
                },
                yAxis: {
                    title: {
                        text: ''
                    },
                    min: 0,
                    minorGridLineWidth: 0,
                    gridLineWidth: 0,
                    alternateGridColor: null,
                    plotBands: [{ // Light air
                        from: 0.3,
                        to: 1.5,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Light breeze
                        from: 1.5,
                        to: 3.3,
                        color: 'rgba(0, 0, 0, 0)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Gentle breeze
                        from: 3.3,
                        to: 5.5,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Moderate breeze
                        from: 5.5,
                        to: 8,
                        color: 'rgba(0, 0, 0, 0)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Fresh breeze
                        from: 8,
                        to: 11,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Strong breeze
                        from: 11,
                        to: 14,
                        color: 'rgba(0, 0, 0, 0)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // High wind
                        from: 14,
                        to: 15,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }]
                },
                tooltip: {
                    valueSuffix: ' m/s'
                },
                plotOptions: {
                    spline: {
                        lineWidth: 2,
                        states: {
                            hover: {
                                lineWidth: 3
                            }
                        },
                        marker: {
                            enabled: false
                        },
                        pointInterval: 3600000, // one hour
                        pointStart: Date.UTC(2009, 9, 6, 0, 0, 0)
                    }
                },
                series: [{
                    name: '太阳能',
                    data: [4.3, 5.1, 4.3, 5.2, 5.4, 4.7, 3.5, 4.1, 5.6, 7.4, 6.9, 7.1,
                    7.1, 7.5, 8.1, 6.8, 3.4, 2.1, 1.9, 2.8, 2.9, 1.3, 4.4, 4.2,
                    3.0, 3.0]

                }, {
                    name: '分布式',
                    data: [0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.1, 0.0, 0.3, 0.0,
                    3.0, 3.3, 4.8, 5.0, 4.8, 5.0, 3.2, 2.0, 0.9, 0.4, 0.3, 0.5, 0.4]
                }, {
                    name: '其他',
                    data: [2.3, 5.1, 4.3, 5.2, 5.4, 4.7, 3.5, 4.1, 5.6, 7.4, 6.9, 7.1,
                    7.1, 7.5, 3.1, 6.8, 3.4, 2.1, 1.9, 2.8, 2.9, 1.3, 4.4, 4.2,
                    3.0, 3.0]

                }
                ], exporting: {
                    enabled: false //用来设置是否显示‘打印’,'导出'等功能按钮，不设置时默认为显示 
                }
            ,
                navigation: {
                    menuItemStyle: {
                        fontSize: '10px'
                    }
                }
            });
            $('#container3').highcharts({
                chart: {
                    type: 'spline'
                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                colors: [
                '#2F7FD8', '#0E91C9', '#023668'
                ],
                xAxis: {
                    type: 'datetime'
                },
                yAxis: {
                    title: {
                        text: ''
                    },
                    min: 0,
                    minorGridLineWidth: 0,
                    gridLineWidth: 0,
                    alternateGridColor: null,
                    plotBands: [{ // Light air
                        from: 0.3,
                        to: 1.5,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Light breeze
                        from: 1.5,
                        to: 3.3,
                        color: 'rgba(0, 0, 0, 0)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Gentle breeze
                        from: 3.3,
                        to: 5.5,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Moderate breeze
                        from: 5.5,
                        to: 8,
                        color: 'rgba(0, 0, 0, 0)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Fresh breeze
                        from: 8,
                        to: 11,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // Strong breeze
                        from: 11,
                        to: 14,
                        color: 'rgba(0, 0, 0, 0)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }, { // High wind
                        from: 14,
                        to: 15,
                        color: 'rgba(68, 170, 213, 0.1)',
                        label: {
                            text: '',
                            style: {
                                color: '#606060'
                            }
                        }
                    }]
                },
                tooltip: {
                    valueSuffix: ' m/s'
                },
                plotOptions: {
                    spline: {
                        lineWidth: 2,
                        states: {
                            hover: {
                                lineWidth: 3
                            }
                        },
                        marker: {
                            enabled: false
                        },
                        pointInterval: 3600000, // one hour
                        pointStart: Date.UTC(2009, 9, 6, 0, 0, 0)
                    }
                },
                series: [{
                    name: '总负荷',
                    data: [4.3, 5.1, 4.3, 5.2, 5.4, 4.7, 3.5, 4.1, 5.6, 7.4, 6.9, 7.1,
                    7.1, 7.5, 8.1, 6.8, 3.4, 2.1, 1.9, 2.8, 2.9, 1.3, 4.4, 4.2,
                    3.0, 3.0]
                }
                ], exporting: {
                    enabled: false //用来设置是否显示‘打印’,'导出'等功能按钮，不设置时默认为显示 
                }
            ,
                navigation: {
                    menuItemStyle: {
                        fontSize: '10px'
                    }
                }
            });

            $('#container4').highcharts({
                chart: {
                    type: 'column'
                },
                title: {
                    align:'center',
                    text: '装机容量',
                    style:
                    {
                        color: '#3E576F',
	                    fontSize: '14px',
	                    fontFamily: '微软雅黑'
                    }
            },
            subtitle: {
                text: ''
            },
            xAxis: {
                categories: [
                    '火电', '水电', '风电','太阳能','分布式','其他'
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
                    pointPadding: 0.02,
                    borderWidth: 0
                }
            },
            series: [{
            name:'装机容量',
            data: [{
                y: 55.11,
                name:'火电',
                color: '#55BF3B'
            }, {
                y: 41.63,
                name: '水电',
                color: '#77BFBB'
            }, {
                y: 30.94,
                name: '风电',
                color: '#7799BF'
            }, {
                y: 12.15,
                name: '太阳能',
                color: '#0DDFDC'
            }, {
                y: 9.14,
                name: '分布式',
                color: '#DDE00D'
            }, {
                y: 8.14,
                name: '其他',
                color: '#DFAA0C'
            }]

            }],
            exporting: {
                enabled: false //用来设置是否显示‘打印’,'导出'等功能按钮，不设置时默认为显示 
            },
            legend: {
                enabled: false
            }

        });
            $('#container5').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    margin: [5, 80, 5, 5]
                },
                title: {
                    align: 'left',
                    text: '发电量',
                    style:
                        {
                            color: '#3E576F',
                            fontSize: '14px',
                            fontFamily: '微软雅黑'
                        }
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>',
                    percentageDecimals: 1
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Browser share',
                    data: [{
                                y: 55.11,
                                name: '火电',
                                color: '#2F7ED9'
                            }, {
                                y: 41.63,
                                name: '水电',
                                color: '#023668'
                            }, {
                                y: 30.94,
                                name: '风电',
                                color: '#EC561B'
                            }, {
                                y: 12.15,
                                name: '太阳能',
                                color: '#DDDF00'
                            }, {
                                y: 9.14,
                                name: '分布式',
                                color: '#23CBE5'
                            }, {
                                y: 2.14,
                                name: '其他',
                                color: '#FFA200'
                            }
                        ]
                }],
                exporting: {
                    enabled: false //用来设置是否显示‘打印’,'导出'等功能按钮，不设置时默认为显示 
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    itemStyle: {
                        cursor: 'pointer',
                        color: 'black',
                        fontSize: '14px',
                        fontFamily: '微软雅黑'
                    },
                    verticalAlign: 'middle'
                }
            });

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:1000px; height:1550px; background-color:#023668; margin:5px auto;" >

        <div style="width: 990px; height: 60px; float:left; background-image : url(img/20131211142227.png); padding:5px" >
        <div style="width: 190px; height: 60px; float:left; font-size:22px; color:White;">装机容量</br>8,888,888mw</div>
        <div style="width: 190px; height: 60px; float:left; font-size:22px; color:White;">有功功率</br>8,888,888mw</div>
        <div style="width: 190px; height: 60px; float:left; font-size:22px; color:White;">日发电量</br>8,888,888万kwh</div>
        <div style="width: 190px; height: 60px; float:left; font-size:22px; color:White;">月发电量</br>8,888,888万kwh</div>
        <div style="width: 190px; height: 60px; float:left; font-size:22px; color:White;">年发电量</br>8,888,888万kwh</div>
        </div>

        <div style="width: 310px; height: 80px; border: 1px solid #184C78; float:left; margin:0.5px; padding:10px">
            <div style="width: 310px; height: 30px; float: left;font-size:22px; color:White; text-align:center">火&nbsp;&nbsp;电&nbsp;<span style="font-size:11px; color:White;">装机容量&nbsp;</span>67945<span style="font-size:11px; color:White;">&nbsp;日发电量&nbsp;</span>29654
            </div>
            <div style="width: 310px; height: 40px; float: left; border-radius:5px; background-color:White; text-align:center;font-size:12px; color:#002E5C; padding-top:2px">

                    计划完成率
                <div id="hd_progressbar" style="width:280px; margin:auto">
                </div>
            </div>
        </div>
        <div style="width: 310px; height: 80px; border: 1px solid #184C78; float:left; margin:0.5px; padding:10px">
            <div style="width: 310px; height: 30px; float: left;font-size:22px; color:White; text-align:center">水&nbsp;&nbsp;电&nbsp;<span style="font-size:11px; color:White;">装机容量&nbsp;</span>67945<span style="font-size:11px; color:White;">&nbsp;日发电量&nbsp;</span>29654
            </div>
            <div style="width: 310px; height: 40px; float: left; border-radius:5px; background-color:White; text-align:center;font-size:12px; color:#002E5C; padding-top:2px">

                    计划完成率
                <div id="sd_progressbar" style="width:280px; margin:auto">
                </div>
            </div>
        </div>
        <div style="width: 310px; height: 80px; border: 1px solid #184C78; float:left; margin:0.5px; padding:10px">
            <div style="width: 310px; height: 30px; float: left;font-size:22px; color:White; text-align:center">风&nbsp;&nbsp;电&nbsp;<span style="font-size:11px; color:White;">装机容量&nbsp;</span>67945<span style="font-size:11px; color:White;">&nbsp;日发电量&nbsp;</span>29654
            </div>
            <div style="width: 310px; height: 40px; float: left; border-radius:5px; background-color:White; text-align:center;font-size:12px; color:#002E5C; padding-top:2px">

                    计划完成率
                <div id="fd_progressbar" style="width:280px; margin:auto">
                </div>
            </div>
        </div>
        <div style="width: 310px; height: 80px; border: 1px solid #184C78; float:left; margin:0.5px; padding:10px">
            <div style="width: 310px; height: 30px; float: left;font-size:22px; color:White; text-align:center">太阳能&nbsp;<span style="font-size:11px; color:White;">装机容量&nbsp;</span>67945<span style="font-size:11px; color:White;">&nbsp;日发电量&nbsp;</span>29654
            </div>
            <div style="width: 310px; height: 40px; float: left; border-radius:5px; background-color:White; text-align:center;font-size:12px; color:#002E5C; padding-top:2px">

                    计划完成率
                <div id="tyn_progressbar" style="width:280px; margin:auto">
                </div>
            </div>
        </div>
        <div style="width: 310px; height: 80px; border: 1px solid #184C78; float:left; margin:0.5px; padding:10px">
            <div style="width: 310px; height: 30px; float: left;font-size:22px; color:White; text-align:center">分布式&nbsp;<span style="font-size:11px; color:White;">装机容量&nbsp;</span>67945<span style="font-size:11px; color:White;">&nbsp;日发电量&nbsp;</span>29654
            </div>
            <div style="width: 310px; height: 40px; float: left; border-radius:5px; background-color:White; text-align:center;font-size:12px; color:#002E5C; padding-top:2px">

                    计划完成率
                <div id="fbs_progressbar" style="width:280px; margin:auto">
                </div>
            </div>
        </div>
        <div style="width: 310px; height: 80px; border: 1px solid #184C78; float:left; margin:0.5px; padding:10px">
            <div style="width: 310px; height: 30px; float: left;font-size:22px; color:White; text-align:center">其&nbsp;&nbsp;它&nbsp;<span style="font-size:11px; color:White;">装机容量&nbsp;</span>67945<span style="font-size:11px; color:White;">&nbsp;日发电量&nbsp;</span>29654
            </div>
            <div style="width: 310px; height: 40px; float: left; border-radius:5px; background-color:White; text-align:center;font-size:12px; color:#002E5C; padding-top:2px">

                    计划完成率
                <div id="qt_progressbar" style="width:280px; margin:auto">
                </div>
            </div>
        </div>

        <div style="width: 1000px; height: 230px; float: left; margin-top:1px">
            <div style="width: 1000px; height: 35px; float: left;
                background-image: url(img/20131211144004.png); font-size:19px; color:White; line-height:30px">
                &nbsp;时实负荷
            </div>
            <div style="width: 1000px; height: 200px; float: left;">
                <div id="container1" style="width: 320px; height: 180px; float: left; margin:5px">
                </div>
                <div id="container2" style="width: 320px; height: 180px; float: left; margin:5px">
                </div>
                <div id="container3" style="width: 320px; height: 180px; float: left; margin:5px">
                </div>
            </div>
        </div>

        <div style="width: 1000px; height: 230px; float: left;">
            <div style="width: 1000px; height: 35px; float: left;
                background-image: url(img/20131211144004.png); font-size:19px; color:White; line-height:30px">
                &nbsp;项目情况<label style=" margin-left:590px">时实负荷数据</label>
            </div>

            <div style="width: 1000px; height: 200px; float: left;">
                <div id="container4" style="width: 320px; height: 180px; float: left; margin:5px">
                </div>
                <div id="container5" style="width: 320px; height: 180px; float: left; margin:5px">
                </div>
                <div id="Div3" style="width: 320px; height: 180px; float: left; margin:5px;">
                    <table id="tabId" style="BORDER-COLLAPSE: collapse; background-color:White; width:310px; height:176px; text-align:center; margin-top:2px; margin-left:8px" border=1>
                        <tr>
                            <td style="width:100px;">火电
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>水电
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>风电
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>太阳能
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>分布式
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>其他
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

        <div style="width: 1000px; height: 350px; float: left;">
            <div style="width: 1000px; height: 35px; float: left;
                background-image: url(img/20131211144004.png); font-size:19px; color:White; line-height:30px">
                &nbsp;项目分布
            </div>
            <div style="width: 1000px; height: 770px; float: left; background-image: url(img/全国地图.jpg); position:relative">
                <div id="lmg" style="width: 345px; height: 288px; position: absolute; top: 51px;
                    left: 362px;">
                </div>

                <div id="ty" style="width: 56px; height: 108px; position: absolute; top: 289px;
                    left: 530px;">
                </div>

                <div id='logo' 
                    style="width: 42px; height: 32px;background-image: url('img/华电logo.png'); position: absolute; top: 232px; left: 550px;">
                
                </div>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>
