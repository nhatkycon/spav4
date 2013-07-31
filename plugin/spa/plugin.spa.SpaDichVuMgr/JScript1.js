var spaDichVuMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.spa.SpaDichVuMgr.Class1, plugin.spa.SpaDichVuMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#spaDichVuMgrMdl-List').jqGrid({
            url: spaDichVuMgrFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Tên', 'Nhóm', 'Spa','Giá', 'Km'],
            colModel: [
            { name: 'DV_ID', key: true, sortable: true, hidden: true },
            { name: 'DV_Ten', width: 40, sortable: false, editable: true },
            { name: 'DV_DM_ID', width: 20, resizable: true, sortable: false, editable: true },
            { name: 'DV_SPA_ID', width: 20, resizable: true, sortable: false, editable: true },
            { name: 'DV_Gia', width: 15, resizable: true, sortable: false, editable: true },
            { name: 'DV_KM', width: 5, resizable: true, sortable: false }
            ],
            caption: 'Top Spa',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'DV_ID',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#spaDichVuMgrMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#spaDichVuMgrMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
                spaDichVuMgrFn.headFn();
            }
        });
    },
    headFn: function () {
        var searchTxt = $('.mdl-head-search-spaDichVuMgrMdl');
        $(searchTxt).unbind('keyup').keyup(function () {
            spaDichVuMgrFn.search();
        });
        var DM_ID = $('.mdl-head-SpaDichVuFilterByDm');
        var SPA_ID = $('.mdl-head-SpaDichVuFilterBySpa');
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteByLoai('DVU', DM_ID, function (event, ui) {
                $(DM_ID).attr('_value', ui.item.id);
                spaDichVuMgrFn.search();
            });
        });
        adm.regType(typeof (quanLySpaFn), 'plugin.spa.quanLySpa.Class1, plugin.spa.quanLySpa', function () {
            quanLySpaFn.autoComplete(SPA_ID, function (event, ui) {
                $(SPA_ID).attr('_value', ui.item.id);
                spaDichVuMgrFn.search();
            });
        });
    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-search-spaDichVuMgrMdl');
        var __q = $(searchTxt).val();
        var DM_ID = $('.mdl-head-SpaDichVuFilterByDm');
        var SPA_ID = $('.mdl-head-SpaDichVuFilterBySpa');
        var _dm_id = '';
        var _spa_id = '';
        if (DM_ID.val() != '') {
            _dm_id = DM_ID.attr('_value');
        }
        if (SPA_ID.val() != '') {
            _spa_id = SPA_ID.attr('_value');
        }
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#spaDichVuMgrMdl-List').jqGrid('setGridParam', { url: spaDichVuMgrFn.urlDefault
             + '&q=' + __q
             + '&subAct=get'
             + '&_DM_ID=' + _dm_id
             + '&_SPA_ID=' + _spa_id             
            }).trigger("reloadGrid");
        }, 1000);
    },
    saveTopic: function (_obj, _id) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: spaDichVuMgrFn.urlDefault + '&subAct=saveTopic&ID=' + _id,
            data: { 'TpId': _objId, 'Active': _ck },
            success: function (_dt) { }
        });
    },
    saveTinAttr: function (_obj, _id, _params) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: spaDichVuMgrFn.urlDefault + '&subAct=saveTinAttr&' + _params + '=' + _ck + '&ID=' + _id,
            success: function (_dt) { }
        });
    },
    saveNhom: function (_obj, _id) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: spaDichVuMgrFn.urlDefault + '&subAct=saveNhom&ID=' + _id,
            data: { 'Nid': _objId, 'Active': _ck },
            success: function (_dt) { }
        });
    },
    saveBinhLuan: function (_obj, _id) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: spaDichVuMgrFn.urlDefault + '&subAct=saveBinhLuan&ID=' + _id,
            data: { 'BlId': _objId, 'Active': _ck },
            success: function (_dt) { }
        });
    },
    xoaBinhLuan: function (_obj, _id) {
        var con = confirm('Bạn có muốn xóa bình luận');
        if (con) {
            var obj = $(_obj);
            $.ajax({
                url: spaDichVuMgrFn.urlDefault + '&subAct=xoaBinhLuan&ID=' + _id,
                data: { 'BlId': _id },
                success: function (_dt) {
                    $(obj).parent().parent().remove();
                }
            });
        }
    },
    edit: function () {
        var s = '';
        if (jQuery('#spaDichVuMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#spaDichVuMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                spaDichVuMgrFn.loadHtml(function () {
                    var newDlg = $('#spaDichVuMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                spaDichVuMgrFn.save(function () { spaDichVuMgrFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                spaDichVuMgrFn.save(function () { spaDichVuMgrFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            spaDichVuMgrFn.clearform();
                            spaDichVuMgrFn.popfn();
                            $.ajax({
                                url: spaDichVuMgrFn.urlDefault + '&subAct=edit',
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
                                    var Ten = $('.Ten', newDlg);
                                    var Gia = $('.Gia', newDlg);
                                    var DonVi = $('.DonVi', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var KM = $('.KM', newDlg);
                                    var GiaKhuyenMai = $('.GiaKhuyenMai', newDlg);
                                    var Hot = $('.Hot', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    DM_ID.val(dt._DanhMuc.Ten); (DM_ID).attr('_value', dt.DM_ID);
                                    SPA_ID.val(dt._Spa.Ten); (SPA_ID).attr('_value', dt.SPA_ID);

                                    Ten.val(dt.Ten);
                                    Gia.val(dt.Gia);
                                    DonVi.val(dt.DonVi);
                                    MoTa.val(dt.MoTa);
                                    NoiDung.val(dt.NoiDung);
                                    GiaKhuyenMai.val(dt.GiaKm);
                                    if (dt.KM) { KM.attr('checked', 'checked'); } else { KM.removeAttr('checked', 'checked'); }
                                    if (dt.Hot) { Hot.attr('checked', 'checked'); } else { Hot.removeAttr('checked', 'checked'); }
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
        if (jQuery('#spaDichVuMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#spaDichVuMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: spaDichVuMgrFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            '_ID': s
                        },
                        success: function (dt) {
                            jQuery('#spaDichVuMgrMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (fn) {
        var newDlg = $('#spaDichVuMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Gia = $('.Gia', newDlg);
        var DonVi = $('.DonVi', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var KM = $('.KM', newDlg);
        var GiaKhuyenMai = $('.GiaKhuyenMai', newDlg);
        var Hot = $('.Hot', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _DM_ID = DM_ID.attr('_value');
        var _SPA_ID = SPA_ID.attr('_value');
        var _Ten = Ten.val();
        var _Gia = Gia.val();
        var _DonVi = DonVi.val();
        var _MoTa = MoTa.val();
        var _NoiDung = NoiDung.val();
        
        var _GiaKhuyenMai = GiaKhuyenMai.val();
        var _KM = KM.is(':checked');
        var _Hot = Hot.is(':checked');
        if (_Gia == '') _Gia = '0';
        if (_GiaKhuyenMai == '') _GiaKhuyenMai = '0';

        var err = '';
        if (_Ten == '') { err += 'Nhập tên<br/>'; }
        if (_Gia == '') { err += 'Nhập giá<br/>'; }
        if (_DonVi == '') { err += 'Nhập đơn vị<br/>'; }
        if (_DM_ID == '') { err += 'Chọn loại<br/>'; }
        if (_SPA_ID == '') { err += 'Chọn Spa<br/>'; }
        if (err != '') { spbMsg.html(err); return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: spaDichVuMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                '_ID': _ID,
                '_DM_ID': _DM_ID,
                '_SPA_ID': _SPA_ID,
                '_Ten': _Ten,
                '_Gia': _Gia,
                '_DonVi': _DonVi,
                '_MoTa': _MoTa,
                '_NoiDung': _NoiDung,
                '_GiaKhuyenMai': _GiaKhuyenMai,
                '_Hot': _Hot,
                '_KM': _KM
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#spaDichVuMgrMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        spaDichVuMgrFn.loadHtml(function () {
            var newDlg = $('#spaDichVuMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                buttons: {
                    'Lưu': function () {
                        spaDichVuMgrFn.save(function () {
                            spaDichVuMgrFn.clearform();
                        }, '#spaDichVuMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        spaDichVuMgrFn.save(function () {
                            $(newDlg).dialog('close');
                        }, '#spaDichVuMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    spaDichVuMgrFn.clearform();
                    spaDichVuMgrFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#spaDichVuMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Gia = $('.Gia', newDlg);
        var DonVi = $('.DonVi', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var KM = $('.KM', newDlg);
        var Hot = $('.Hot', newDlg);
        var GiaKhuyenMai = $('.GiaKhuyenMai', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteByLoai('DVU', DM_ID, function (event, ui) {
                $(DM_ID).attr('_value', ui.item.id);
            });
        });
        adm.regType(typeof (quanLySpaFn), 'plugin.spa.quanLySpa.Class1, plugin.spa.quanLySpa', function () {
            quanLySpaFn.autoComplete(SPA_ID, function (event, ui) {
                $(SPA_ID).attr('_value', ui.item.id);
            });
        });
        adm.createFckFull(NoiDung);
        DonVi.focus(function () {
            DonVi.unbind('keypress').keypress(function (e) {
                if (e.which == 13) {
                    spaDichVuMgrFn.save(function () {
                        spaDichVuMgrFn.clearform();
                    }, '#spaDichVuMgrMdl-List');
                }
            });
        });
    },
    clearform: function () {
        var newDlg = $('#spaDichVuMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Gia = $('.Gia', newDlg);
        var DonVi = $('.DonVi', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var KM = $('.KM', newDlg);
        var GiaKhuyenMai = $('.GiaKhuyenMai', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        ID.val('');
        //DM_ID.val('');DM_ID.attr('_value', '');
        //SPA_ID.val('');SPA_ID.attr('_value', '');
        Ten.val('');
        Gia.val('');
        DonVi.val('');
        MoTa.val('');
        NoiDung.val('');
        GiaKhuyenMai.val('');
        spbMsg.html('');
        Ten.focus();
    },
    loadHtml: function (fn) {
        var dlg = $('#spaDichVuMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.spa.SpaDichVuMgr.htm.htm")%>',
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
