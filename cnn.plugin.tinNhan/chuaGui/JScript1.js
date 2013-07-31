var tinnhanchuaguiObj = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.tinNhan.chuaGui.Class1, cnn.plugin.tinNhan',
    //chung	
    setup: function () {
        //alert(1111111);

        tinnhanchuaguiObj.loadHtml1();
        tinnhanchuaguiObj.loadHtml2();

        tinnhanchuaguiObj.loadgrid();

        $('#tinnhanchuaguimdl-troveBtn').hide();

        //cau hinh tim kiem
        var searchTxt = $('.mdl-head-search-tinnhanchuagui');
        $(searchTxt).keyup(function () {
            tinnhanchuaguiObj.search();
        });
        adm.watermark(searchTxt, 'Tìm kiếm tin', function () {
            $(searchTxt).val('');
            tinnhanchuaguiObj.search();
            $(searchTxt).val('Tìm kiếm tin');
        });
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu tin nhắn');
        adm.styleButton();
        $('#tinnhanchuaguimdl-List').jqGrid({
            url: tinnhanchuaguiObj.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['STT', 'TinID', 'Đặt cờ', 'Người nhận', 'Tiêu đề', 'Ngày tạo', 'File'],
            colModel: [
            { name: 'TN_Thutu', width: 10, resizable: true, sortable: true, align: "center" },
            { name: 'TN_TinID', key: true, sortable: true, hidden: true },
            { name: 'TNM_Co', width: 15, resizable: true, align: "center" },
            { name: 'TNM_Nguoinhan', width: 50, resizable: true, sortable: true, align: "left" },
            { name: 'TN_Tieude', width: 160, resizable: true, sortable: true, align: "left" },
            { name: 'TN_Ngaygui', width: 80, resizable: true, sortable: true, align: "left" },
            { name: 'TN_File', width: 20, resizable: true, sortable: true, align: "center" },

        ],
            caption: 'Hòm thư nháp',
            autowidth: true,
            sortname: 'TN_TinID',
            sortorder: 'desc',
            rowNum: 50,
            rowList: [50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#tinnhanchuaguimdl-Pager'),
            onSelectRow: function (rowid) {
                //tinnhanchuaguiObj.soanthu(rowid); ;

            },
            loadComplete: function () {
                adm.loading(null);

            },
            grouping: false,
            groupingView: {
                groupField: ['TN_Tieude'],
                groupColumnShow: [true],
                groupText: ['<b>{0}</b>  - <span style=\"color:red;\">Tổng số: {1}</span>'],
                groupCollapse: false,
                groupOrder: ['asc'],
                groupSummary: [true],
                groupColumnShow: [false],
                groupDataSorted: true
            }
        });

    },
    setupfocus: function (newDlg) {
        var Nguoinhan = $('.Nguoinhan', newDlg);
        tinnhanchuaguiObj.initkeypress(Nguoinhan);

        var Cc = $('.Cc', newDlg);
        tinnhanchuaguiObj.initkeypress(Cc);

        var Bc = $('.Bc', newDlg);
        tinnhanchuaguiObj.initkeypress(Bc);
    },
    initkeypress: function (input) {
        var inputTo = $(input).parent();
        $(inputTo).click(function () {
            $(input).focus();
        });

        $(input).keyup(function (e) {
            //alert(e.which);
            if (e.which == 188) {
                var s = $(input).val();
                if ((s.length > 0) & (s != ',')) {
                    $(input).val('');
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + s + '\">' + s + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(input);
                    var CurrentItem = $(inputTo).find('span[_value=' + s + ']');
                    var removeBtn = $(CurrentItem).find('a');
                    $(removeBtn).click(function () {
                        $(CurrentItem).remove();
                    });
                }
            }
            if (e.which == 8) {
                var s = $(input).val();

                if (s.length > 0) {
                    $(input).val('');

                }
                else {
                    //alert('aaa');
                    var spanar = $(inputTo).find('span');
                    var spancur = spanar[spanar.length - 1];
                    if (spanar.length > 0)
                        $(spancur).remove();

                }
            }
        });

    },
    selectRow: function (rowid) {
        tinnhanchuaguiObj.getinfo(rowid);

        $('#tinnhanchuaguimdl-TinID').val(rowid);
        $('#tinnhanchuagui-List').hide();
        tinnhanchuaguiObj.hideBtn();
        $('#tinnhanchuaguimdl-dlgChitiet').show();
        $('#tinnhanchuaguimdl-troveBtn').show();
    },
    hideDiv: function () {
        $('#tinnhanchuaguimdl-dlgChitiet').hide();
        $('#tinnhanchuaguimdl-dlgsoanthu').hide();

    },
    hideBtn: function () {
        $('#tinnhanchuaguimdl-chuyentoiBtn').hide();
        $('#tinnhanchuaguimdl-delBtn').hide();
        $('#tinnhanchuaguimdl-datcoBtn').hide();
        $('#tinnhanchuaguimdl-bocoBtn').hide();
        $('#tinnhanchuaguimdl-chuyentoiDop').hide();
    },
    showBtn: function () {
        $('#tinnhanchuaguimdl-chuyentoiBtn').show();
        $('#tinnhanchuaguimdl-delBtn').show();
        $('#tinnhanchuaguimdl-datcoBtn').show();
        $('#tinnhanchuaguimdl-bocoBtn').show();
        $('#tinnhanchuaguimdl-chuyentoiDop').show();
    },
    quaylai: function () {
        $('#tinnhanchuagui-List').show();
        $('#tinnhanchuaguimdl-troveBtn').hide();
        tinnhanchuaguiObj.hideDiv();
        tinnhanchuaguiObj.showBtn();
        //tinnhanchuaguiObj.loadgrid();
        //$('#tinnhanchuaguimdl-List').jqGrid('setGridParam', { url: tinnhanchuaguiObj.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        jQuery('#tinnhanchuaguimdl-List').trigger('reloadGrid');
    },
    chuyentoi: function (droplist) {
        var s = '';
        s = jQuery("#tinnhanchuaguimdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tin nhắn');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tinnhanchuaguimdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            adm.loading('Đang chuyển dữ liệu');
            $.ajax({
                url: tinnhanchuaguiObj.urlDefault + '&subAct=chuyentoi',
                dataType: 'script',
                data: {
                    'ID': ll,
                    'chuyentoi': droplist.value
                },
                success: function (dt) {
                    jQuery("#tinnhanchuaguimdl-List").trigger('reloadGrid');
                    adm.loading(null);
                    //                    alert(droplist.selectedIndex);
                    //                    alert(droplist.value);
                }
            });
        }
    },
    getinfo: function (tinID) {

        adm.loading('Đang nạp dữ liệu');
        $.ajax({
            url: tinnhanchuaguiObj.urlDefault + '&subAct=getInfo',
            dataType: 'script',
            data: {
                'ID': tinID
            },
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);
                var newDlg = $('#tinnhanchuaguimdl-dlgChitiet');

                var lbnguoigui = $('#lbnguoigui', newDlg);
                $(lbnguoigui).html(data.Nguoigui);

                var lbnguoinhan = $('#lbnguoinhan', newDlg);
                $(lbnguoinhan).html(data.Nguoinhan);

                var lbCc = $('#lbCc', newDlg);
                $(lbCc).html(data.Listcc);

                var lbBc = $('#lbBc', newDlg);
                $(lbBc).html(data.Listbc);

                var lbnguoigui = $('#lbnguoigui', newDlg);
                $(lbnguoigui).html(data.Nguoigui);

                var lbngaygui = $('#lbngaygui', newDlg);
                $(lbngaygui).html(data.sNgaygui);
                //alert(data.Ngaygui);

                var lbtieude = $('#lbtieude', newDlg);
                $(lbtieude).html(data.Tieude);


                var lbnoidung = $('#lbnoidung', newDlg);
                $(lbnoidung).html(data.Noidung);

                var lbfilelist = $('#lbfilelist', newDlg);
                $(lbfilelist).html(data.FileListStr);
            }
        });


    },
    search: function () {
        var timerSearch;
        var filterTN = $('.mdl-head-search-tinnhanchuagui');
        var s = filterTN.val();
        if (s == 'Tìm kiếm tin') {
            s = '';
        }

        timerSearch = setTimeout(function () {
            $('#tinnhanchuaguimdl-List').jqGrid('setGridParam', { url: tinnhanchuaguiObj.urlDefault + '&subAct=get&s=' + s }).trigger('reloadGrid');
        }, 500);
    },

    loadHtml1: function (fn) {
        var dlg = $('#tinnhanchuaguimdl-dlgChitiet');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.chuaGui.htm1.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('#tinnhanchuaguimdl-ListConten').append(dt);
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
            });
        }
        else {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
    },
    loadHtml2: function (fn) {

        var dlg = $('#tinnhanchuaguimdl-dlgsoanthu');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');

            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.chuaGui.htm2.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('#tinnhanchuaguimdl-ListConten').append(dt);
                    var newDlg = $('#tinnhanchuaguimdl-dlgTraloi');
                    tinnhanchuaguiObj.setupfocus(newDlg);
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
            });
        }
        else {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
    },

    del: function (fn) {
        var s = '';
        s = jQuery("#tinnhanchuaguimdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tin nhắn để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa tin nhắn này không?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    var treedata = $("#tinnhanchuaguimdl-List").jqGrid('getRowData', ss[j]);
                    ll += ss[j] + ',';
                }
                adm.loading('Đang xóa tin nhắn');
                $.ajax({
                    url: tinnhanchuaguiObj.urlDefault + '&subAct=del',
                    dataType: 'script',
                    data: {
                        'ID': ll
                    },
                    success: function (dt) {
                        adm.loading(null);
                        jQuery("#tinnhanchuaguimdl-List").trigger('reloadGrid');
                    }
                });
            }
        }

    },

    datco: function (fn) {
        var s = '';
        s = jQuery("#tinnhanchuaguimdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tin nhắn');
        }
        else {

            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tinnhanchuaguimdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            adm.loading('Đang sử lý tin nhắn');
            $.ajax({
                url: tinnhanchuaguiObj.urlDefault + '&subAct=datco',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    adm.loading(null);
                    jQuery("#tinnhanchuaguimdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },

    boco: function (fn) {
        var s = '';
        s = jQuery("#tinnhanchuaguimdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tin nhắn');
        }
        else {

            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tinnhanchuaguimdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            adm.loading('Đang sử lý tin nhắn');
            $.ajax({
                url: tinnhanchuaguiObj.urlDefault + '&subAct=boco',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    adm.loading(null);
                    jQuery("#tinnhanchuaguimdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    adduser: function (item, parent) {
        adm.regType(typeof (danhbaObj), 'cnn.plugin.tinNhan.danhBa.Class1, cnn.plugin.tinNhan', function () {
            danhbaObj.chondanhba2(function (data) {

                $(data).insertBefore(item);
                var span = $(parent).find('span');

                $.each(span, function (i, Currentspan) {
                    var removeBtn = $(Currentspan).find('a');
                    $(removeBtn).click(function () {
                        $(Currentspan).remove();
                    });

                });

            });

        });
    },
    //chung//

    //soanthu
    soanthu: function (tinid) {

        //alert(s);
        adm.styleButton();
        $('#tinnhanchuagui-List').hide();
        tinnhanchuaguiObj.hideDiv();
        tinnhanchuaguiObj.hideBtn();


        $('#tinnhanchuaguimdl-dlgsoanthu').show();
        $('#tinnhanchuaguimdl-troveBtn').show();


        adm.loading('Ðang nạp dữ liệu');
        //tinnhanchuaguiObj.clearform();
        tinnhanchuaguiObj.addpopsoanthupfn();

        $.ajax({
            url: tinnhanchuaguiObj.urlDefault + '&subAct=getInfoct',
            dataType: 'script',
            data: {
                'ID': tinid
            },
            success: function (dt) {
                //alert(1);
                adm.loading(null);
                var data = eval(dt);
                var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');

                var txtID = $('.ID', newDlg);
                $(txtID).val(data.TinID);
                //alert(data.TinID);

                var txtTieuDe = $('.Tieude', newDlg);
                $(txtTieuDe).val(data.Tieude);


                var txtNoidung = $('.Noidung', newDlg);
                $(txtNoidung).val(data.Noidung);

                //cau hinh file
                var lbladm_upload_fileList = $('.adm-upload-fileList', newDlg);
                $(lbladm_upload_fileList).html(data.FileListStr);
                $(lbladm_upload_fileList).find('a').click(function () {
                    var _item = $(this).parent();
                    $(_item).hide();
                    $.ajax({
                        url: tinnhanchuaguiObj.urlDefault,
                        data: {
                            'subAct': 'DeleteDoc',
                            'F_ID': $(_item).attr('_value')
                        },
                        success: function (dt) {
                            $(_item).remove();
                        }
                    });
                    $(this).parent().remove();
                });
                //alert(data.FileListStr);
                //cau hinh nguoi nhan
                var NguoinhanTo = $('.NguoinhanTo', newDlg);
                var input = $(NguoinhanTo).find('input');
                $(data.Nguoinhan).insertBefore(input);
                //alert(data.Nguoinhan);
                $(NguoinhanTo).find('a').click(function () {
                    var _item = $(this).parent();
                    $(this).parent().remove();
                });

                //cau hinh cc
                var CcTo = $('.CcTo', newDlg);
                var input1 = $(CcTo).find('input');
                $(data.Listcc).insertBefore(input1);
                $(CcTo).find('a').click(function () {
                    var _item = $(this).parent();
                    $(this).parent().remove();
                });
                //alert(data.Listcc);
                //cau hinh bc
                var rowbc = $('#rowbc', newDlg);
                if (data.Listbc != '') {

                    $(rowbc).show();
                    var BcTo = $('.BcTo', newDlg);
                    var input2 = $(BcTo).find('input');
                    $(data.Listbc).insertBefore(input2);
                    $(BcTo).find('a').click(function () {
                        var _item = $(this).parent();
                        $(this).parent().remove();
                    });
                }
                else {
                    $(rowbc).hide();
                }
                //alert(data.Listbc);
                ////console.log(data);
                //chu y  cho nay khong can phai insert draff
                //tinnhanchuaguiObj.insertDraffCT(data.TinID);

                var sendBtn = $('#tinnhanchuaguimdl-dlgsoanthu-sendBtn', newDlg);
                $(sendBtn).attr('disabled', 'disabled');
                //$('#Tinnhanmdl-saveBtn').attr('disabled', 'disabled');
                $(sendBtn).show();

                var saveBtn = $('#tinnhanchuaguimdl-dlgsoanthu-saveBtn', newDlg);
                $(saveBtn).show();

                var delBtn = $('#tinnhanchuaguimdl-dlgsoanthu-delBtn', newDlg);
                $(delBtn).show();
            }
        });




    },
    insertDraffCT: function (tinid) {

        $.ajax({
            url: tinnhanchuaguiObj.urlDefault + '&subAct=insertTinct',
            dataType: 'script',
            data: {
                'ID': tinid
            },
            success: function (_dt) {
                adm.loading(null);
                var dt = eval(_dt);
                var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');
                var txtID = $('.ID', newDlg);
                $(txtID).val(dt.TinID);
                //alert(dt.TinID);
                $(txtID).attr('_value', dt.RowID);
                //alert(dt.RowID);

            }
        });
    },
    savect: function (validate, fn) {
        var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');
        var spbMsg = $('.admMsg', newDlg);

        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();


        var txtCc = $('.Cc', newDlg);
        var Cc = $(txtCc).val();

        var txtBc = $('.Bc', newDlg);
        var Bc = $(txtBc).val();

        var txtTieuDe = $('.Tieude', newDlg);
        var TieuDe = $(txtTieuDe).val();

        var txtNoidung = $('.Noidung', newDlg);
        var Noidung = $(txtNoidung).val();

        var checkQuantrong = $('.Quantrong', newDlg);
        var Quantrong = $(checkQuantrong).is(':checked');
        //alert(2);

        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        var l = '';
        $.each($(NguoinhanToDiv).find('span'), function (i, item) {
            l += $(item).attr('_value') + ',';
        });
        //alert(l);

        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        var l1 = '';
        $.each($(tinnhanCCToDiv).find('span'), function (i, item) {
            l1 += $(item).attr('_value') + ',';
        });
        //alert(l1);

        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        var l2 = '';
        $.each($(tinnhanBCToDiv).find('span'), function (i, item) {
            l2 += $(item).attr('_value') + ',';
        });
        //alert(l2);


        var fileList = $('.adm-upload-fileList', newDlg);
        var fileListToDiv = $(fileList).parent();
        var l3 = '';
        $.each($(fileListToDiv).find('span'), function (i, item) {
            l3 += $(item).attr('_value') + ',';
        });
        //alert(l3);


        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: tinnhanchuaguiObj.urlDefault + '&subAct=savect',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'Tieude': TieuDe,
                'Noidung': Noidung,
                'Nguoinhan': l,
                'UserCC': l1,
                'UserBC': l2,
                'File': l3,
                'Quantrong': Quantrong

            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    spbMsg.html('Lưu dữ liệu thành công');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    sendct: function (fn) {

        var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');
        var spbMsg = $('.admMsg', newDlg);

        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        //alert(id);

        var txtTieuDe = $('.Tieude', newDlg);
        var TieuDe = $(txtTieuDe).val();


        var txtNoidung = $('.Noidung', newDlg);
        var Noidung = $(txtNoidung).val();

        var checkQuantrong = $('.Quantrong', newDlg);
        var Quantrong = $(checkQuantrong).is(':checked');

        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        var l = '';
        $.each($(NguoinhanToDiv).find('span'), function (i, item) {
            l += $(item).attr('_value') + ',';
        });
        Nguoinhan = l;
        //alert(l);

        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        var l1 = '';
        $.each($(tinnhanCCToDiv).find('span'), function (i, item) {
            l1 += $(item).attr('_value') + ',';
        });
        //alert(l1);

        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        var l2 = '';
        $.each($(tinnhanBCToDiv).find('span'), function (i, item) {
            l2 += $(item).attr('_value') + ',';
        });
        //alert(l2);

        var fileList = $('.adm-upload-fileList', newDlg);
        var fileListToDiv = $(fileList).parent();
        var l3 = '';
        $.each($(fileListToDiv).find('span'), function (i, item) {
            l3 += $(item).attr('_value') + ',';
        });
        //alert(l3);

        var err = '';
        if (id == '') {
            err += 'Lỗi lưu dữ liệu<br/>';

        }
        if (Nguoinhan == '') {
            err += 'Nhập người nhận<br/>';
        }
        if (TieuDe == '') {
            err += 'Chưa nhập tiêu đề<br/>';
        }

        if (Noidung == '') {
            err += 'Nhập nội dung<br/>';
        }

        if (err != '') {
            spbMsg.html(err);
            return;
        }
        adm.loading('Đang gửi tin nhắn');
        $.ajax({
            url: tinnhanchuaguiObj.urlDefault + '&subAct=sendct',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'Tieude': TieuDe,
                'Noidung': Noidung,
                'Nguoinhan': l,
                'UserCC': l1,
                'UserBC': l2,
                'File': l3,
                'Quantrong': Quantrong
            },
            success: function (dt) {

                adm.loading(null);
                if (dt == '1') {
                    tinnhanchuaguiObj.clearformct();
                    spbMsg.html('Thư của bạn đã được gửi');

//                    var sendBtn = $('#tinnhanchuaguimdl-dlgsoanthu-sendBtn', newDlg);
//                    $(sendBtn).attr('disabled', 'disabled');
//                    $(sendBtn).hide();

//                    var saveBtn = $('#tinnhanchuaguimdl-dlgsoanthu-saveBtn', newDlg);
//                    $(saveBtn).hide();

//                    var delBtn = $('#tinnhanchuaguimdl-dlgsoanthu-delBtn', newDlg);
//                    $(delBtn).hide();

//                    var newBtn = $('#tinnhanchuaguimdl-dlgsoanthu-newBtn', newDlg);
                    //                    $(newBtn).show();
                    danhbaObj.loadHtmladddanhba(newDlg, function () {

                        var dlg = $('#danhbamdl-dlgadddanhba', newDlg);
                        dlg.show();
                        var listUser = l + l1 + l2;

                        $.ajax({
                            url: danhbaObj.urlDefault + '&subAct=addexist',
                            dataType: 'script',
                            type: 'POST',
                            data: {
                                'listUser': listUser
                            },
                            success: function (dt) {
                                adm.loading(null);
                                if (dt == '1') {
                                    adm.loading('Lưu dữ liệu thành công');

                                    listUser = l + l1 + l2;
                                    listUser = listUser.replace(/,/g, ", ");
                                    $('.inline-items', dlg).html(listUser);
                                }
                                else {
                                    adm.loading('Lỗi máy chủ, chưa thể lưu được vào danh bạ');
                                }
                            }
                        });

                    });  
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }


            }

        });

    },
    clearformct: function () {
        var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');

        var txtTieuDe = $('.Tieude', newDlg);
        $(txtTieuDe).val('');

        var txtNoidung = $('.Noidung', newDlg);
        $(txtNoidung).val('');

        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        $(NguoinhanToDiv).find('span').remove();
        //$(Nguoinhan).val('');

        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        $(tinnhanCCToDiv).find('span').remove();
        //$(tinnhanCC).val('');

        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        $(tinnhanBCToDiv).find('span').remove();
        //$(tinnhanBC).val('');

        var fileList = $('.adm-upload-fileList', newDlg);
        var fileListToDiv = $(fileList).parent();
        $(fileListToDiv).find('span').remove();
        //$(fileListToDiv).val('');


        //alert('ok!');
    },
    initMailsoanthu: function (fn) {

        var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');
        //cai dat nguoi nhan
        var Nguoinhan = $('.Nguoinhan', newDlg);
        $(Nguoinhan).focus();
        var NguoinhanToDiv = $(Nguoinhan).parent();
        $(NguoinhanToDiv).find('span').remove();
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(Nguoinhan, function (e, ui) {

                var CurrentItem = $(NguoinhanToDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    $(Nguoinhan).val('');
                }, 100);
                if ($(CurrentItem).length < 1) {
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(Nguoinhan);
                    CurrentItem = $(NguoinhanToDiv).find('span[_value=' + ui.item.value + ']');
                    var removeBtn = $(CurrentItem).find('a');
                    $(removeBtn).click(function () {
                        $(CurrentItem).remove();
                    });
                }
                else {
                    $(CurrentItem).animate({ backgroundColor: 'orange' }, 500, function () {
                        $(CurrentItem).animate({ backgroundColor: 'white' }, 500);
                    });
                }
            });
        });
        //cai dat CC
        var tinnhanCC = $('.Cc', newDlg);
        // $(tinnhanCC).focus();
        var tinnhanCCDiv = $(tinnhanCC).parent();
        $(tinnhanCCDiv).find('span').remove();
        //alert($(tinnhanCC));
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(tinnhanCC, function (e, ui) {

                var CurrentItem = $(tinnhanCCDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    $(tinnhanCC).val('');
                }, 100);
                if ($(CurrentItem).length < 1) {
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(tinnhanCC);
                    CurrentItem = $(tinnhanCCDiv).find('span[_value=' + ui.item.value + ']');
                    var removeBtn = $(CurrentItem).find('a');
                    $(removeBtn).click(function () {
                        $(CurrentItem).remove();
                    });
                }
                else {
                    $(CurrentItem).animate({ backgroundColor: 'orange' }, 500, function () {
                        $(CurrentItem).animate({ backgroundColor: 'white' }, 500);
                    });
                }
            });
        });
        //cai dat Bc
        var tinnhanBC = $('.Bc', newDlg);
        //$(tinnhanBC).focus();
        var tinnhanBCDiv = $(tinnhanBC).parent();
        $(tinnhanBCDiv).find('span').remove();
        //alert($(tinnhanBC));
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(tinnhanBC, function (e, ui) {

                var CurrentItem = $(tinnhanBCDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    $(tinnhanBC).val('');
                }, 100);
                if ($(CurrentItem).length < 1) {
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(tinnhanBC);
                    CurrentItem = $(tinnhanBCDiv).find('span[_value=' + ui.item.value + ']');
                    var removeBtn = $(CurrentItem).find('a');
                    $(removeBtn).click(function () {
                        $(CurrentItem).remove();
                    });
                }
                else {
                    $(CurrentItem).animate({ backgroundColor: 'orange' }, 500, function () {
                        $(CurrentItem).animate({ backgroundColor: 'white' }, 500);
                    });
                }
            });
        });
    },
    delEmptyct: function () {
        var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();

        adm.loading('Đang xóa tin nhắn');
        $.ajax({
            url: tinnhanchuaguiObj.urlDefault + '&subAct=delEmpty',
            dataType: 'script',
            data: {
                'ID': id
            },
            success: function (dt) {
                tinnhanchuaguiObj.clearformct();
                adm.loading(null);

//                var sendBtn = $('#tinnhanchuaguimdl-dlgsoanthu-sendBtn', newDlg);
//                $(sendBtn).attr('disabled', 'disabled');
//                //$('#Tinnhanmdl-saveBtn').attr('disabled', 'disabled');
//                $(sendBtn).hide();

//                var saveBtn = $('#tinnhanchuaguimdl-dlgsoanthu-saveBtn', newDlg);
//                $(saveBtn).hide();

//                var delBtn = $('#tinnhanchuaguimdl-dlgsoanthu-delBtn', newDlg);
//                $(delBtn).hide();

//                var newBtn = $('#tinnhanchuaguimdl-dlgsoanthu-newBtn', newDlg);
                //                $(newBtn).show();
                adm.regType(typeof (danhbaObj), 'cnn.plugin.tinNhan.danhBa.Class1, cnn.plugin.tinNhan', function () {
                    danhbaObj.loadHtmladddanhba(newDlg, function () {

                        var dlg = $('#danhbamdl-dlgadddanhba', newDlg);
                        dlg.show();

                        $('.success', dlg).html('Thư của bạn đã được hủy');
                        $('.label', dlg).find('b').html('');
                        $('.inline-items', dlg).html('');
                    });

                });
            }
        });

    },
    addpopsoanthupfn: function () {
        var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');

        var txtNoiDung = $('.Noidung', newDlg);
        adm.createFck_TN(txtNoiDung);
        tinnhanchuaguiObj.initMailsoanthu();

        var txtID = $('.ID', newDlg);
        var fileList = $('.adm-upload-fileList', newDlg);
        var fileBtn = $('.File', newDlg);
        var _params = { 'act': 'uploadfileDkLuong' }

        adm.upload(fileBtn, 'data', _params, function (rs) {
        }, function (_rs) {

        }, function (_r, _f) {
            var l = '';
            // alert(_r.replace('.', ''));
            l += '<span class=\"adm-token-item-radi\"><span onclick=\"javascript:document.location.href=\'Default.aspx?act=download&ID=' + _r.replace('.', '') + '\'\">' + _f + '</span><a _value=\"' + _r.replace('.', '') + '\"  href=\"javascript:;\">x</a></span>';
            $.ajax({
                url: tinnhanchuaguiObj.urlDefault,
                data: {
                    'subAct': 'saveDoc',
                    'F_ID': _r,
                    'ID': $(txtID).attr('_value')
                },
                success: function (dt) {

                }
            });
            //alert(txtID.val());
            $(l).appendTo(fileList).find('a').click(function () {
                var _item = $(this);
                $(_item).hide();
                $.ajax({
                    url: tinnhanchuaguiObj.urlDefault,
                    data: {
                        'subAct': 'DeleteDoc',
                        'F_ID': $(_item).attr('_value')
                    },
                    success: function (dt) {
                        $(_item).remove();
                    }
                });
                $(this).parent().remove();
            });
        });

    },
    addnguoinhanct: function () {
        var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');
        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        tinnhanchuaguiObj.adduser(Nguoinhan, NguoinhanToDiv);
    },
    addccct: function () {
        var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');
        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        tinnhanchuaguiObj.adduser(tinnhanCC, tinnhanCCToDiv);
    },
    addbcct: function () {
        var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');
        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        tinnhanchuaguiObj.adduser(tinnhanBC, tinnhanBCToDiv);
    },
    thembcct: function () {
        var newDlg = $('#tinnhanchuaguimdl-dlgsoanthu');
        $('#rowbc', newDlg).show();

    }
    //soanthu//

}