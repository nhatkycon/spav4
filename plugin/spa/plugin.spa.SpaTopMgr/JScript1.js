var topSpaMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.spa.SpaTopMgr.Class1, plugin.spa.SpaTopMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#topSpaMgrMdl-List').jqGrid({
            url: topSpaMgrFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Tên', 'Thứ tự', 'Nhóm','Loại', 'Active', 'Readed'],
            colModel: [
            { name: 'TP_ID', key: true, sortable: true, hidden: true },
            { name: 'TP_Ten', width: 50, sortable: false, editable: true },
            { name: 'TP_ThuTu', width: 10, resizable: true, sortable: false, editable: true },
            { name: 'TP_DM_ID', width: 10, resizable: true, sortable: false, editable: true },
            { name: 'TP_LOAI_ID', width: 10, resizable: true, sortable: false, editable: true },
            { name: 'TP_Active', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'TP_Readed', width: 5, resizable: true, sortable: false }
            ],
            caption: 'Top Spa',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'TP_ID',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#topSpaMgrMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#topSpaMgrMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
                topSpaMgrFn.headFn();
            }
        });
    },
    headFn: function () {
        var searchTxt = $('.mdl-head-search-topSpaMgrMdl');
        $(searchTxt).unbind('keyup').keyup(function () {
            topSpaMgrFn.search();
        });
        var DM_ID = $('.mdl-head-topSpaFilterByDm');
        var LOAI_ID = $('.mdl-head-topSpaFilterByLoai');
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteByLoai('SPA-TOP', DM_ID, function (event, ui) {
                $(DM_ID).attr('_value', ui.item.id);
                topSpaMgrFn.search();
            });
            danhmuc.autoCompleteByLoai('SPA-DM-LOAI', LOAI_ID, function (event, ui) {
                $(LOAI_ID).attr('_value', ui.item.id);
                topSpaMgrFn.search();
            });
        });
    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-search-topSpaMgrMdl');
        var __q = $(searchTxt).val();
        var DM_ID = $('.mdl-head-topSpaFilterByDm');
        var LOAI_ID = $('.mdl-head-topSpaFilterByLoai');
        var _dm_id = '';
        var _loai_id = '';
        _dm_id = DM_ID.attr('_value');
        _loai_id = LOAI_ID.attr('_value');

        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#topSpaMgrMdl-List').jqGrid('setGridParam', { url: topSpaMgrFn.urlDefault
             + '&q=' + __q
             + '&subAct=get'
             + '&_DM_ID=' + _dm_id
             + '&_LOAI_ID=' + _loai_id             
            }).trigger("reloadGrid");
        }, 1000);
    },
    saveTopic: function (_obj, _id) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: topSpaMgrFn.urlDefault + '&subAct=saveTopic&ID=' + _id,
            data: { 'TpId': _objId, 'Active': _ck },
            success: function (_dt) { }
        });
    },
    saveTinAttr: function (_obj, _id, _params) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: topSpaMgrFn.urlDefault + '&subAct=saveTinAttr&' + _params + '=' + _ck + '&ID=' + _id,
            success: function (_dt) { }
        });
    },
    saveNhom: function (_obj, _id) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: topSpaMgrFn.urlDefault + '&subAct=saveNhom&ID=' + _id,
            data: { 'Nid': _objId, 'Active': _ck },
            success: function (_dt) { }
        });
    },
    saveBinhLuan: function (_obj, _id) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: topSpaMgrFn.urlDefault + '&subAct=saveBinhLuan&ID=' + _id,
            data: { 'BlId': _objId, 'Active': _ck },
            success: function (_dt) { }
        });
    },
    xoaBinhLuan: function (_obj, _id) {
        var con = confirm('Bạn có muốn xóa bình luận');
        if (con) {
            var obj = $(_obj);
            $.ajax({
                url: topSpaMgrFn.urlDefault + '&subAct=xoaBinhLuan&ID=' + _id,
                data: { 'BlId': _id },
                success: function (_dt) {
                    $(obj).parent().parent().remove();
                }
            });
        }
    },
    edit: function () {
        var s = '';
        if (jQuery('#topSpaMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#topSpaMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                topSpaMgrFn.loadHtml(function () {
                    var newDlg = $('#topSpaMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 600,
                        buttons: {
                            'Lưu': function () {
                                topSpaMgrFn.save(function () { topSpaMgrFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                topSpaMgrFn.save(function () { topSpaMgrFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            topSpaMgrFn.clearform();
                            topSpaMgrFn.popfn();
                            $.ajax({
                                url: topSpaMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                type: 'POST',
                                data: {
                                    '_ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var SPA_ID = $('.SPA_ID', newDlg);
                                    var LOAI_ID = $('.LOAI_ID', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);

                                    var Readed = $('.Readed', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    DM_ID.val(dt.DM_Ten); (DM_ID).attr('_value', dt.DM_ID);
                                    SPA_ID.val(dt.SPA_Ten); (SPA_ID).attr('_value', dt.SPA_ID);
                                    LOAI_ID.val(dt.LOAI_Ten); (LOAI_ID).attr('_value', dt.LOAI_ID);
                                    MoTa.val(dt.MoTa);
                                    NoiDung.val(dt.NoiDung);
                                    ThuTu.val(dt.ThuTu);
                                    if (dt.Active) { Active.attr('checked', 'checked'); } else { Active.removeAttr('checked', 'checked'); }
                                    if (dt.Readed) { Readed.attr('checked', 'checked'); } else { Readed.removeAttr('checked', 'checked'); }
                                    spbMsg.html('');
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function () {
        var s = '';
        if (jQuery('#topSpaMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#topSpaMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa danh mục này?')) {
                    $.ajax({
                        url: topSpaMgrFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            '_ID': s
                        },
                        success: function (dt) {
                            jQuery('#topSpaMgrMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (fn) {
        var newDlg = $('#topSpaMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var LOAI_ID = $('.LOAI_ID', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Active = $('.Active', newDlg);
        var Readed = $('.Readed', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        
        var _ID = $(ID).val();
        var _DM_ID = DM_ID.attr('_value');
        var _SPA_ID = SPA_ID.attr('_value');
        var _LOAI_ID = LOAI_ID.attr('_value');
        var _ThuTu = ThuTu.val();
        var _MoTa = MoTa.val();
        var _NoiDung = NoiDung.val();
        var _Active = Active.is(':checked');
        var _Readed = Readed.is(':checked');

        var err = '';
        if (_ThuTu == '') { err += 'Nhập thứ tự<br/>'; }
        if (_DM_ID == '') { err += 'Chọn loại<br/>'; }
        if (_SPA_ID == '') { err += 'Chọn Spa<br/>'; }
        if (err != '') { spbMsg.html(err); return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: topSpaMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                '_ID': _ID,
                '_DM_ID': _DM_ID,
                '_SPA_ID': _SPA_ID,
                '_LOAI_ID' : _LOAI_ID,
                '_ThuTu': _ThuTu,
                '_Active': _Active,
                '_Readed': _Readed,
                '_NoiDung': _NoiDung,
                '_MoTa': _MoTa
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#topSpaMgrMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        topSpaMgrFn.loadHtml(function () {
            var newDlg = $('#topSpaMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 600,
                buttons: {
                    'Lưu': function () {
                        topSpaMgrFn.save(function () {
                            topSpaMgrFn.clearform();
                        }, '#topSpaMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        topSpaMgrFn.save(function () {
                            $(newDlg).dialog('close');
                        }, '#topSpaMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    topSpaMgrFn.clearform();
                    topSpaMgrFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#topSpaMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var LOAI_ID = $('.LOAI_ID', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Active = $('.Active', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Readed = $('.Readed', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteByLoai('SPA-TOP', DM_ID, function (event, ui) {
                $(DM_ID).attr('_value', ui.item.id);
            });
            danhmuc.autoCompleteByLoai('SPA-DM-LOAI', LOAI_ID, function (event, ui) {
                $(LOAI_ID).attr('_value', ui.item.id);
            });
        });
        adm.regType(typeof (quanLySpaFn), 'plugin.spa.quanLySpa.Class1, plugin.spa.quanLySpa', function () {
            quanLySpaFn.autoComplete(SPA_ID, function (event, ui) {
                $(SPA_ID).attr('_value', ui.item.id);
            });
        });
        adm.createFck(NoiDung);
    },
    clearform: function () {
        var newDlg = $('#topSpaMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var LOAI_ID = $('.LOAI_ID', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Active = $('.Active', newDlg);
        var Readed = $('.Readed', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(ID).val('');
        $(DM_ID).val('');
        $(DM_ID).attr('_value', '');
        $(SPA_ID).val('');
        $(SPA_ID).attr('_value', '');
        $(LOAI_ID).val('');
        $(LOAI_ID).attr('_value', '');
        $(ThuTu).val('1');
        NoiDung.val('');
        MoTa.val('');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#topSpaMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.spa.SpaTopMgr.htm.htm")%>',
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
    }
}
