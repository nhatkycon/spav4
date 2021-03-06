﻿var dbtinfn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.ktnn.DuyetTin.Class1, cnn.plugin.ktnn',
    setup: function () {
    },
    loadgrid: function () {

        adm.loading('Đang lấy dữ liệu tin tức');
        adm.styleButton();
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $('#dbtinmdlktnn-List').jqGrid({
                    url: dbtinfn.urlDefault + '&subAct=get&Lang=' + Lang,
                    height: 'auto',
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'LangBased', '_ID', 'Lang', '#', 'Ảnh', 'Tiêu đề', 'Tóm tắt', 'Mục tin', 'Nguồn', 'Lần đọc', 'Người viết', 'Ngày tạo', 'Kích hoạt', 'Hot', 'Hết hạn'],
                    colModel: [
            { name: 'KTNN_ID', key: true, sortable: true, hidden: true },
             { name: 'LangBased', key: true, sortable: true, hidden: true },
            { name: '_KTNN_ID', key: true, sortable: true, hidden: true },
            { name: 'KTNN_Lang', width: 30, sortable: true, align: "center" },
            { name: 'KTNN_ThuTu', width: 20, resizable: true, sortable: true, align: "center", hidden: true },
            { name: 'KTNN_Anh', width: 50, resizable: true, sortable: true, align: "center" },
            { name: 'KTNN_Ten', width: 100, resizable: true, sortable: true },
            { name: 'KTNN_MoTa', width: 180, resizable: true, sortable: true },
            { name: 'KTNN_DM_Ten', width: 50, sortable: true },
            { name: 'KTNN_Nguon', width: 50, sortable: true },
            { name: 'KTNN_Views', width: 30, resizable: true, sortable: true, hidden: true },
            { name: 'KTNN_NguoiTao', width: 50, resizable: true, sortable: true, align: "center" },
            { name: 'KTNN_NgayCapNhat', width: 50, resizable: true, sortable: true, align: "center" },
            { name: 'KTNN_Active', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true },
            { name: 'KTNN_Hot', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true },
            { name: 'KTNN_HetHan', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true }
        ],
                    caption: 'Danh sách tin',
                    autowidth: true,
                    sortname: 'KTNN_NgayCapNhat',
                    sortorder: 'desc',
                    rowNum: 20,
                    rowList: [20, 50, 100, 200, 300],
                    multiselect: true,
                    multiboxonly: true,
                    pager: jQuery('#dbtinmdlktnn-Pagerql'),
                    onSelectRow: function (rowid) {

                    },
                    loadComplete: function () {
                        adm.loading(null);
                        $.getScript('../js/ajaxupload.js', function () { });
                        //adm.regQS(searchTxt, 'dbtinmdlktnn-List');
                        var txtfilter = $('.mdl-head-dbfilterdanhmuc');
                        adm.watermarks(txtfilter, 'Gõ tên mục tin để lọc', function () {
                        });
                        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                            danhmuc.autoCompleteByLoai("KT_NN", txtfilter, function (event, ui) {
                                //    $(txtfilter).val(ui.item.label);
                                $(txtfilter).attr('_value', ui.item.id);
                                dbtinfn.search();
                            });
                            //                        });
                            //                        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                            //                            danhmuc.autoCompleteByLoaiLang('TIN-DM', txtfilter, function (event, ui) {
                            //                                $(txtfilter).val(ui.item.label);
                            //                                $(txtfilter).attr('_value', ui.item.id);
                            //                                dbtinfn.search();
                            //                            });
                            $(txtfilter).unbind('click').click(function () {
                                $(txtfilter).autocomplete('search', '');
                            });
                        });
                        adm.regQS($('.mdl-head-search-danhmuc'), 'dbtinmdlktnn-List');

                    },

                    grouping: false,
                    groupingView: {
                        groupField: ['KTNN_DM_Ten'],
                        groupColumnShow: [true],
                        groupText: ['<b>{0}</b>  - <span style=\"color:red;\">Tổng số: {1}</span>'],
                        groupCollapse: false,
                        groupOrder: ['asc'],
                        groupSummary: [true],
                        groupColumnShow: [false],
                        groupDataSorted: true
                    }
                });

                var filterLoaiDanhMucID = $('.mdl-head-dbfilterdanhmuc');
                var searchTxt = $('.mdl-head-search-ktnn-db');

                $('.mdl-head-dbfilterdanhmuc').keyup(function () {
                    if ($('.mdl-head-dbfilterdanhmuc').val() == '') {
                        $('.mdl-head-dbfilterdanhmuc').attr('_value', '');
                        if ($(searchTxt).val() == 'Tìm kiếm tin tức') {
                            $(searchTxt).val('');
                        }
                        dbtinfn.search();
                        if ($(searchTxt).val() == '') {
                            $(searchTxt).val('Tìm kiếm tin tức');
                        }
                    }
                });

                $('.mdl-head-search-ktnn-db').keyup(function () {
                    dbtinfn.search();
                });

                adm.watermark(searchTxt, 'Tìm kiếm tin tức', function () {
                    $(searchTxt).val('');
                    dbtinfn.search();
                    $(searchTxt).val('Tìm kiếm tin tức');
                });
                adm.watermark(filterLoaiDanhMucID, 'Gõ tên mục tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin tức') {
                        $(searchTxt).val('');
                    }
                    dbtinfn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin tức');
                    }
                });
                var changeLangBtn = $('#dbtintucdl-changeLangSlt');
                $(changeLangBtn).find('option').remove();
                $.each(LangArr, function (i, item) {
                    if (item.Active) {
                        Lang = item.Ma;
                    }
                    $(changeLangBtn).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                });
                $(changeLangBtn).val(Lang);
            });
        });
    },
    add: function () {

        dbtinfn.loadHtml(function () {
            var newDlg = $('#dbtinmdlktnn-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,

                position: [200, 0],
                //     modal: true,
                buttons: {
                    'Lưu': function () {
                        dbtinfn.save(false, function () {
                            dbtinfn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        dbtinfn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {

                    adm.styleButton();
                    dbtinfn.clearform();
                    dbtinfn.addpopfn();
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');
                }
                ,
                beforeclose: function () {

                }
            });
        });
    },
    addLang: function () {

        var s = '';
        if (jQuery('#dbtinmdlktnn-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#dbtinmdlktnn-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var treedata = $("#dbtinmdlktnn-List").jqGrid('getRowData', s);

                var _KTNN_ID = treedata.KTNN_ID;

                dbtinfn.loadHtml(function () {
                    var newDlg = $('#dbtinmdlktnn-dlgNew');

                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        height: 500,
                        position: [200, 0],
                        //  modal: true,
                        buttons: {
                            'Lưu': function () {
                                dbtinfn.save(false, function () {
                                    dbtinfn.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                dbtinfn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeclose: function () {
                            dbtinfn.clearform();
                        },
                        open: function () {

                            //alert("aaaaaaaaa");
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            dbtinfn.clearform();
                            dbtinfn.addpopfn();
                            var LangBased_ID = $('.LangBased_ID', newDlg);
                            LangBased_ID.val(s);
                            var LangBased = $('.LangBased', newDlg);
                            $(LangBased).removeAttr('checked');
                            $.ajax({
                                url: dbtinfn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': _KTNN_ID
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#dbtinmdlktnn-dlgNew');
                                    //file uploadKTNN
                                    var lbladm_uploadKTNN_fileLists = $('.adm-uploadKTNN-fileLists', newDlg);
                                    //                                    var txtID = $('.ID', newDlg);
                                    //                                    $(txtID).val(data.ID);
                                    //                                    $(txtID).attr('_value', data.RowId);
                                    // var LangBased = $('.LangBased', newDlg);
                                    //var LangBased_ID = $('.LangBased_ID', newDlg);
                                    var Alias = $('.Alias', newDlg);
                                    var LangTxt = $('.Lang', newDlg);
                                    //  var LangSlt = $('.Lang', newDlg);

                                    var KeyWords = $('.KeyWords', newDlg);
                                    var Description = $('.Description', newDlg);
                                    var txtPID = $('.DMIDdb_ktnn', newDlg);
                                    $(txtPID).val(data.DM_Ten);
                                    $(txtPID).attr('_value', data.DM_ID);
                                    var txtTen = $('.Ten', newDlg);
                                    $(txtTen).val(data.Ten);

                                    LangBased_ID.val(data.LangBased_ID);
                                    //                                    if (data.LangBased) {
                                    //                                        $(LangBased).attr('checked', 'checked');
                                    //                                    }
                                    //                                    else {
                                    //                                        $(LangBased).removeAttr('checked');
                                    //                                    }

                                    Alias.val(data.Alias);
                                    KeyWords.val(data.KeyWords);
                                    Description.val(data.Description);
                                    var txtNguon = $('.Nguon', newDlg);
                                    $(txtNguon).val(data.Nguon);

                                    var txtMoTa = $('.MoTa', newDlg);
                                    $(txtMoTa).val(data.MoTa);

                                    var txtNoiDungdb_ktnn = $('.NoiDungdb_ktnn', newDlg);

                                    $(txtNoiDungdb_ktnn).val(data.NoiDung);

                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-uploadKTNN-vbpreview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    $(lblAnh).attr('ref', data.Anh);
                                    if (data.Anh != '') {
                                        $(lblAnhPrvImg).attr('src', '../up/KTNN/' + data.Anh + '?ref=' + Math.random());
                                    }
                                    var txtNguoiTao = $('.NguoiTao', newDlg);
                                    $(txtNguoiTao).val(data.NguoiTao);
                                    var txtSTT = $('.ThuTu', newDlg);
                                    $(txtSTT).val(data.ThuTu);
                                    var ckbHot = $('.Hot', newDlg);
                                    if (data.Hot.toString() == 'true') {
                                        $(ckbHot).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbHot).removeAttr('checked');
                                    }
                                    var ckbPublish = $('.Publish', newDlg);
                                    if (data.Active.toString() == 'true') {
                                        $(ckbPublish).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbPublish).removeAttr('checked');
                                    }

                                    var ckbHetHan = $('.HetHan', newDlg);
                                    if (data.HetHan.toString() == 'true') {
                                        $(ckbHetHan).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbHetHan).removeAttr('checked');
                                    }
                                    var txtNgayHetHan = $('.NgayHetHan', newDlg)
                                    var _ngayHetHan = new Date(data.NgayHetHan);

                                    checkdate = '';
                                    checkdate = _ngayHetHan.getDate() + '/' + (_ngayHetHan.getMonth() + 1) + '/' + (_ngayHetHan.getFullYear());
                                    if ('1/1/1980' == checkdate) {
                                        $(txtNgayHetHan).val('');
                                    }
                                    else {
                                        $(txtNgayHetHan).val(checkdate);
                                    }
                                    var txtNgayCapNhat = $('.NgayCapNhat', newDlg)
                                    var _ngayCapNhat = new Date(data.NgayCapNhat);

                                    checkdates = '';
                                    checkdates = _ngayCapNhat.getDate() + '/' + (_ngayCapNhat.getMonth() + 1) + '/' + (_ngayCapNhat.getFullYear());
                                    if ('1/1/1980' == checkdates) {
                                        $(txtNgayCapNhat).val('');
                                    }
                                    else {
                                        $(txtNgayCapNhat).val(checkdates);
                                    }
                                    // file uploadKTNN
                                    $(lbladm_uploadKTNN_fileLists).html(data.FileListStr);
                                    $(lbladm_uploadKTNN_fileLists).find('a').click(function () {
                                        var _item = $(this).parent();
                                        $(_item).hide();
                                        //  alert($(_item).attr('_value'));
                                        $.ajax({
                                            url: dbtinfn.urlDefault,
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


                                    LangTxt.val(data.Lang);

                                }
                            });
                        }
                    });
                });
            }
        }
    },
    edit: function () {

        var s = '';
        if (jQuery('#dbtinmdlktnn-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#dbtinmdlktnn-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var treedata = $("#dbtinmdlktnn-List").jqGrid('getRowData', s);
                var __KTNN_ID = treedata._KTNN_ID;
                var _KTNN_ID = treedata.KTNN_ID;
                var _Lang = treedata.KTNN_Lang;
                if (__KTNN_ID == '0') { alert('Tin này chưa tồn tại ở ngôn ngữ ' + _Lang); return false; }
                dbtinfn.loadHtml(function () {
                    var newDlg = $('#dbtinmdlktnn-dlgNew');

                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,

                        position: [200, 0],
                        //  modal: true,
                        buttons: {
                            'Lưu': function () {
                                dbtinfn.save(false, function () {
                                    dbtinfn.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                dbtinfn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeclose: function () {

                        },
                        open: function () {

                            //alert("aaaaaaaaa");
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            dbtinfn.clearform();
                            $.ajax({
                                url: dbtinfn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': __KTNN_ID
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#dbtinmdlktnn-dlgNew');
                                    //file uploadKTNN
                                    var lbladm_uploadKTNN_fileLists = $('.adm-uploadKTNN-fileLists', newDlg);
                                    var txtID = $('.ID', newDlg);
                                    $(txtID).val(data.ID);
                                    $(txtID).attr('_value', data.RowId);
                                    var LangBased = $('.LangBased', newDlg);
                                    var LangBased_ID = $('.LangBased_ID', newDlg);
                                    var Alias = $('.Alias', newDlg);
                                    var LangTxt = $('.Lang', newDlg);
                                    //  var LangSlt = $('.Lang', newDlg);

                                    var KeyWords = $('.KeyWords', newDlg);
                                    var Description = $('.Description', newDlg);
                                    var txtPID = $('.DMIDdb_ktnn', newDlg);
                                    $(txtPID).val(data.DM_Ten);
                                    $(txtPID).attr('_value', data.DM_ID);
                                    var txtTen = $('.Ten', newDlg);
                                    $(txtTen).val(data.Ten);

                                    LangBased_ID.val(data.LangBased_ID);
                                    if (data.LangBased) {
                                        $(LangBased).attr('checked', 'checked');
                                    }
                                    else {
                                        $(LangBased).removeAttr('checked');
                                    }

                                    Alias.val(data.Alias);
                                    KeyWords.val(data.KeyWords);
                                    Description.val(data.Description);
                                    var txtNguon = $('.Nguon', newDlg);
                                    $(txtNguon).val(data.Nguon);

                                    var txtMoTa = $('.MoTa', newDlg);
                                    $(txtMoTa).val(data.MoTa);

                                    var txtNoiDungdb_ktnn = $('.NoiDungdb_ktnn', newDlg);

                                    $(txtNoiDungdb_ktnn).val(data.NoiDung);

                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-uploadKTNN-vbpreview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    $(lblAnh).attr('ref', data.Anh);
                                    if (data.Anh != '') {
                                        var st = 'KTNN/' + data.Anh;
                                       st= st.replace('KTNN/rss', 'tintuc/rss');
                                        $(lblAnhPrvImg).attr('src', '../up/' + st+'?ref=' + Math.random());
                                    }
                                    var txtNguoiTao = $('.NguoiTao', newDlg);
                                    $(txtNguoiTao).val(data.NguoiTao);
                                    var txtSTT = $('.ThuTu', newDlg);
                                    $(txtSTT).val(data.ThuTu);
                                    var ckbHot = $('.Hot', newDlg);
                                    if (data.Hot.toString() == 'true') {
                                        $(ckbHot).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbHot).removeAttr('checked');
                                    }
                                    var ckbPublish = $('.Publish', newDlg);
                                    if (data.Active.toString() == 'true') {
                                        $(ckbPublish).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbPublish).removeAttr('checked');
                                    }

                                    var ckbHetHan = $('.HetHan', newDlg);
                                    if (data.HetHan.toString() == 'true') {
                                        $(ckbHetHan).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbHetHan).removeAttr('checked');
                                    }
                                    var txtNgayHetHan = $('.NgayHetHan', newDlg)
                                    var _ngayHetHan = new Date(data.NgayHetHan);

                                    checkdate = '';
                                    checkdate = _ngayHetHan.getDate() + '/' + (_ngayHetHan.getMonth() + 1) + '/' + (_ngayHetHan.getFullYear());
                                    if ('1/1/1980' == checkdate) {
                                        $(txtNgayHetHan).val('');
                                    }
                                    else {
                                        $(txtNgayHetHan).val(checkdate);
                                    }
                                    var txtNgayCapNhat = $('.NgayCapNhat', newDlg)
                                    var _ngayCapNhat = new Date(data.NgayCapNhat);

                                    checkdates = '';
                                    checkdates = _ngayCapNhat.getDate() + '/' + (_ngayCapNhat.getMonth() + 1) + '/' + (_ngayCapNhat.getFullYear());
                                    if ('1/1/1980' == checkdates) {
                                        $(txtNgayCapNhat).val('');
                                    }
                                    else {
                                        $(txtNgayCapNhat).val(checkdates);
                                    }
                                    // file uploadKTNN
                                    $(lbladm_uploadKTNN_fileLists).html(data.FileListStr);
                                    $(lbladm_uploadKTNN_fileLists).find('a').click(function () {
                                        var _item = $(this).parent();
                                        $(_item).hide();
                                        //  alert($(_item).attr('_value'));
                                        $.ajax({
                                            url: dbtinfn.urlDefault,
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

                                    dbtinfn.addpopfn();
                                    LangTxt.val(data.Lang);
                                    //                                    if ($(LangTxt).children().length > 0) { return false; }
                                    //                                    $(LangTxt).find('option').remove();
                                    //                                    $.each(LangArr, function (i, item) {
                                    //                                        if (item.Active) {
                                    //                                            Lang = item.Ma;
                                    //                                        }
                                    //                                        $(LangTxt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                                    //                                    });
                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    $(spbMsg).html('');
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function (fn) {
        var s = '';
        s = jQuery("#dbtinmdlktnn-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa tin này?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    var treedata = $("#dbtinmdlktnn-List").jqGrid('getRowData', ss[j]);
                    ll += treedata._KTNN_ID + ',';
                }
            }
            $.ajax({
                url: dbtinfn.urlDefault + '&subAct=del',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#dbtinmdlktnn-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    duyet: function (st) {
        var s = '';
        s = jQuery("#dbtinmdlktnn-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#dbtinmdlktnn-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: dbtinfn.urlDefault + '&subAct=duyet&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#dbtinmdlktnn-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    tinhot: function (st) {
        var s = '';
        s = jQuery("#dbtinmdlktnn-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#dbtinmdlktnn-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: dbtinfn.urlDefault + '&subAct=hot&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#dbtinmdlktnn-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    hethan: function (st) {
        var s = '';
        s = jQuery("#dbtinmdlktnn-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#dbtinmdlktnn-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: dbtinfn.urlDefault + '&subAct=hethan&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#dbtinmdlktnn-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },

    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-ktnn-db');
        var searchTxt = $('.mdl-head-dbfilterdanhmuc');
        var q = filterDM.val();
        if (q == 'Tìm kiếm tin tức') {
            q = '';
        }
        var _Lang = $('#dbtintucdl-changeLangSlt').val();
        var dm = $(searchTxt).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#dbtinmdlktnn-List').jqGrid('setGridParam', { url: dbtinfn.urlDefault + "&subAct=get&q=" + q + "&DMID=" + dm + '&Lang=' + _Lang }).trigger("reloadGrid");
        }, 500);
    },
    save: function (validate, fn) {
        var newDlg = $('#dbtinmdlktnn-dlgNew');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        var LangBased = $('.LangBased', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var LangTxt = $('.Lang', newDlg);
        var Alias = $('.Alias', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Description = $('.Description', newDlg);
        var _LangBased_ID = LangBased_ID.val();
        var _LangBased = $(LangBased).is(':checked');
        var _Lang = LangTxt.val();
        var _Alias = Alias.val();
        var _Keywords = $(KeyWords).val();
        var _Description = Description.val();

        var txtPID = $('.DMIDdb_ktnn', newDlg);
        var pid = $(txtPID).attr('_value');
        var pten = $(txtPID).val();

        var txtTen = $('.Ten', newDlg);
        var ten = $(txtTen).val();

        var txtNguon = $('.Nguon', newDlg);
        var Nguon = $(txtNguon).val();

        var txtMa = $('.Ma', newDlg);
        var ma = $(txtMa).val();

        var txtThuTu = $('.ThuTu', newDlg);
        var ThuTu = $(txtThuTu).val();

        var txtMoTa = $('.MoTa', newDlg);
        var MoTa = $(txtMoTa).val();

        var txtNoiDungdb_ktnn = $('.NoiDungdb_ktnn', newDlg);
        var NoiDungdb_ktnn = $(txtNoiDungdb_ktnn).val();

        var txtNgayHetHan = $('.NgayHetHan', newDlg);
        var NgayHetHan = $(txtNgayHetHan).val();

        var txtNgayCapNhat = $('.NgayCapNhat', newDlg);
        var NgayCapNhat = $(txtNgayCapNhat).val();

        var ckbPublish = $('.Publish', newDlg);
        var Publish = $(ckbPublish).val();

        var lblAnh = $('.Anh', newDlg);
        var anh = $(lblAnh).attr('ref');

        var ckbHot = $('.Hot', newDlg);
        var Hot = $(ckbHot).is(':checked');

        var ckbHetHan = $('.HetHan', newDlg);
        var HetHan = $(ckbHetHan).is(':checked');

        var txtNguoiTao = $('.NguoiTao', newDlg);

        var spbMsg = $('.admMsg', newDlg);
        var err = '';
        if (ThuTu == '') { ThuTu = '0'; } else { if (!adm.isInt(ThuTu)) { err += 'Nhập thứ tự kiểu số<br/>'; } }
        if (!_LangBased) { if (_Lang == Lang) { err += 'Chọn ngôn ngữ khác'; }; }
        else { if (_Lang != Lang) { err += 'Bạn cần chọn ngôn ngữ gốc ' + Lang; }; }
        if (pid == '') {
            err += 'Nhập mục tin<br/>';
        }

        if (ten == '') {
            err += 'Nhập tên<br/>';
        }

        //        if (MoTa == '') {
        //            err += 'Nhập mô tả<br/>';
        //        }

        if (NoiDungdb_ktnn == '') {
            err += 'Nhập nội dung<br/>';
        }

        if (err != '') {
            spbMsg.html(err);
            return false;
        }
        if (validate) {
            if (typeof (fn) == 'function') {
                fn();
            }
            return false;
        }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: dbtinfn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'LangBased': _LangBased,
                'LangBased_ID': _LangBased_ID,
                'Alias': _Alias,
                'Lang': _Lang,
                'DMID': pid,
                'DMTen': pten,
                'ThuTu': ThuTu,
                'Ten': ten,
                'Mota': MoTa,
                'NoiDungdb_ktnn': NoiDungdb_ktnn,
                'Public': Publish,
                'Hot': Hot,
                'Anh': anh,
                'HetHan': HetHan,
                'NgayHetHan': NgayHetHan,
                'NgayCapNhat': NgayCapNhat,
                'Nguon': Nguon,
                'KeyWords': _Keywords,
                'Description': _Description
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#dbtinmdlktnn-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    clearform: function () {
        var newDlg = $('#dbtinmdlktnn-dlgNew');
        var txtID = $('.ID', newDlg);
        $(txtID).val('');
        var txtPID = $('.DMIDdb_ktnn', newDlg);
        $(txtPID).val('');
        $(txtPID).attr('_value', '');
        var txtTen = $('.Ten', newDlg);
        $(txtTen).val('');
        var txtNguon = $('.Nguon', newDlg);
        $(txtNguon).val('');
        var txtNguoiTao = $('.NguoiTao', newDlg);
        $(txtNguoiTao).val('');
        var txtSTT = $('.ThuTu', newDlg);
        $(txtSTT).val('');
        var txtMoTa = $('.MoTa', newDlg);
        $(txtMoTa).val('');
        var txtNoiDungdb_ktnn = $('.NoiDungdb_ktnn', newDlg);
        $(txtNoiDungdb_ktnn).val('');
        var ckbHot = $('.Hot', newDlg);
        $(ckbHot).removeAttr('checked');
        var ckbPublish = $('.Publish', newDlg);
        $(ckbPublish).removeAttr('checked');
        var ckbHetHan = $('.HetHan', newDlg);
        $(ckbHetHan).removeAttr('checked');
        var lblAnh = $('.Anh', newDlg);
        $(lblAnh).attr('ref', '');
        $(lblAnh).prev().find('img').attr('src', '');
        var fileList = $('.adm-uploadKTNN-fileLists', newDlg);
        $(fileList).val('');
        var LangTxt = $('.Lang', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Description = $('.Description', newDlg);
        LangBased_ID.val('');
        KeyWords.val('');
        var Alias = $('.Alias', newDlg);
        Alias.val('');
        Description.val('');
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        $(spbMsg).html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#dbtinmdlktnn-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.ktnn.DuyetTin.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('body').append(dt);
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
    addpopfn: function () {

        var newDlg = $('#dbtinmdlktnn-dlgNew');
        var txtNoiDungdb_ktnn = $('.NoiDungdb_ktnn', newDlg);
        var txtID = $('.ID', newDlg);
        var txtDMIDdb_ktnn = $('.DMIDdb_ktnn', newDlg);

        var lblAnh = $('.Anh', newDlg);
        var fileList = $('.adm-uploadKTNN-fileLists', newDlg);
        var ulpFn = function () {
            var uploadKTNNBtn = $('.adm-uploadKTNN-btn', newDlg);
            var uploadKTNNView = $('.adm-uploadKTNN-vbpreview-img', newDlg);
            var _params = { 'oldFile': $(uploadKTNNBtn).attr('ref') };
            adm.uploadKTNN(uploadKTNNBtn, 'anh', _params, function (rs) {
                $(uploadKTNNBtn).attr('ref', rs)
                $(uploadKTNNView).attr('src', '../up/KTNN/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });

            // uploadKTNN file
            var fileBtn = $('.File', newDlg);
            var _params = { 'act': 'uploadfileDkLuong' }

            adm.uploadKTNN(fileBtn, 'doc', _params, function (rs) {

            }, function (_rs) {

            }, function (_r, _f) {
                var l = '';
                l += '<span class=\"adm-token-item\"><span onclick=\"javascript:document.location.href=\' ../Default.aspx?act=download&ID=' + _r.replace('.', '') + '\'\">' + _f + '</span><a _value=\"' + _r.replace('.', '') + '\"  href=\"javascript:;\">x</a></span>';
                $.ajax({
                    url: dbtinfn.urlDefault,
                    data: {
                        'subAct': 'saveDoc',
                        'F_ID': _r,
                        'ID': $(txtID).attr('_value')
                    }, success: function (dt) {

                    }
                });
                $(l).appendTo(fileList).find('a').click(function () {
                    var _item = $(this).parent();
                    $(_item).hide();
                    $.ajax({
                        url: dbtinfn.urlDefault,
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
        }
        ulpFn();
        var ID = $('.ID', newDlg);
        var _ID = ID.val();
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased(_ID, "KT_NN", txtDMIDdb_ktnn, function (event, ui) {
                $(txtDMIDdb_ktnn).attr('_value', ui.item.id);
            });
        });
        $(txtDMIDdb_ktnn).unbind('click').click(function () { $(txtDMIDdb_ktnn).autocomplete('search', ''); });

        var LangSlt = $('.Lang', newDlg);
        if ($(LangSlt).children().length > 0) { return false; }
        $(LangSlt).find('option').remove();
        $.each(LangArr, function (i, item) {
            if (item.Active) {
                Lang = item.Ma;
            }
            $(LangSlt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
        });
        //        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
        //            danhmuc.autoCompleteByLoaiLang('TIN', txtDMIDdb_ktnn, function (event, ui) {
        //                $(txtDMIDdb_ktnn).attr('_value', ui.item.id);
        //            });
        //        });

        $('.NgayHetHan', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayCapNhat', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });

        var txttextarea = $('.NoiDungdb_ktnn', newDlg);
        adm.createTinyMce(txttextarea);
        //        setTimeout(function () {
        //            $(txtNoiDungdb_ktnn).next().find('iframe').css({ 'height': '200px' });
        //        }, 10000);

    }
}
