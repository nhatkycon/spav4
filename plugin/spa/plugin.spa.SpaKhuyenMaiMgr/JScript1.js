var spaKhuyenMaiMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.spa.SpaKhuyenMaiMgr.Class1, plugin.spa.SpaKhuyenMaiMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#spaKhuyenMaiMgrMdl-List').jqGrid({
            url: spaKhuyenMaiMgrFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Tên', 'Spa', 'Giá', 'Tỷ lệ', 'Từ ngày', 'Đến ngày'],
            colModel: [
            { name: 'KM_ID', key: true, sortable: true, hidden: true },
            { name: 'KM_Ten', width: 40, sortable: true, editable: true },
            { name: 'KM_SPA_ID', width: 20, resizable: true, sortable: true, editable: true },
            { name: 'KM_GiaKhuyenMai', width: 15, resizable: true, sortable: true, editable: true },
            { name: 'KM_TyLeKhuyenMai', width: 5, resizable: true, sortable: true },
            { name: 'KM_NgayBatDau', width: 5, resizable: true, sortable: true },
            { name: 'KM_NgayKetThuc', width: 5, resizable: true, sortable: true }
            ],
            caption: 'Danh sách khuyến mãi',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'KM_ID',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#spaKhuyenMaiMgrMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#spaKhuyenMaiMgrMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
                spaKhuyenMaiMgrFn.headFn();
            }
        });
    },
    headFn: function () {
        var searchTxt = $('.mdl-head-search-spaKhuyenMaiMgrMdl');
        $(searchTxt).unbind('keyup').keyup(function () {
            spaKhuyenMaiMgrFn.search();
        });
        var SPA_ID = $('.mdl-head-SpaKhuyenMaiFilterBySpa');
        adm.regType(typeof (quanLySpaFn), 'plugin.spa.quanLySpa.Class1, plugin.spa.quanLySpa', function () {
            quanLySpaFn.autoComplete(SPA_ID, function (event, ui) {
                $(SPA_ID).attr('_value', ui.item.id);
                spaKhuyenMaiMgrFn.search();
            });
        });
    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-search-spaKhuyenMaiMgrMdl');
        var __q = $(searchTxt).val();
        var SPA_ID = $('.mdl-head-SpaKhuyenMaiFilterBySpa');
        var _spa_id = '';
        _spa_id = SPA_ID.attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#spaKhuyenMaiMgrMdl-List').jqGrid('setGridParam', { url: spaKhuyenMaiMgrFn.urlDefault
             + '&q=' + __q
             + '&subAct=get'
             + '&_SPA_ID=' + _spa_id
            }).trigger("reloadGrid");
        }, 1000);
    },
    edit: function () {
        var s = '';
        if (jQuery('#spaKhuyenMaiMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#spaKhuyenMaiMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                spaKhuyenMaiMgrFn.loadHtml(function () {
                    var newDlg = $('#spaKhuyenMaiMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                spaKhuyenMaiMgrFn.save(function () { spaKhuyenMaiMgrFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                spaKhuyenMaiMgrFn.save(function () { spaKhuyenMaiMgrFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            spaKhuyenMaiMgrFn.clearform();
                            spaKhuyenMaiMgrFn.popfn();
                            $.ajax({
                                url: spaKhuyenMaiMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                type: 'POST',
                                data: {
                                    '_ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var SPA_ID = $('.SPA_ID', newDlg);
                                    var NgayBatDau = $('.NgayBatDau', newDlg);
                                    var NgayKetThuc = $('.NgayKetThuc', newDlg);
                                    var GiaKhuyenMai = $('.GiaKhuyenMai', newDlg);
                                    var TyLeKhuyenMai = $('.TyLeKhuyenMai', newDlg);
                                    var GiaThiTruong = $('.GiaThiTruong', newDlg);
                                    var GiaThuVe = $('.GiaThuVe', newDlg);
                                    var SoLuongMua = $('.SoLuongMua', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var Hot = $('.Hot', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    SPA_ID.val(dt._Spa.Ten); (SPA_ID).attr('_value', dt.SPA_ID);

                                    var _NgayBatDau = new Date(dt.NgayBatDau);
                                    var __NgayBatDau = _NgayBatDau.getDate() + '/' + (_NgayBatDau.getMonth() + 1) + '/' + (_NgayBatDau.getFullYear());

                                    var _NgayKetThuc = new Date(dt.NgayKetThuc);
                                    var __NgayKetThuc = _NgayKetThuc.getDate() + '/' + (_NgayKetThuc.getMonth() + 1) + '/' + (_NgayKetThuc.getFullYear());
                                    NgayBatDau.val(__NgayBatDau);
                                    NgayKetThuc.val(__NgayKetThuc);
                                    Ten.val(dt.Ten);
                                    GiaThiTruong.val(dt.GiaThiTruong);
                                    GiaThuVe.val(dt.GiaThuVe);
                                    SoLuongMua.val(dt.SoLuongMua);
                                    GiaKhuyenMai.val(dt.GiaKhuyenMai);
                                    TyLeKhuyenMai.val(dt.TyLeKhuyenMai);
                                    MoTa.val(dt.MoTa);
                                    if (dt.Active) { Active.attr('checked', 'checked'); } else { Active.removeAttr('checked', 'checked'); }
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
        if (jQuery('#spaKhuyenMaiMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#spaKhuyenMaiMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: spaKhuyenMaiMgrFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            '_ID': s
                        },
                        success: function (dt) {
                            jQuery('#spaKhuyenMaiMgrMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (fn) {
        var newDlg = $('#spaKhuyenMaiMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var NgayBatDau = $('.NgayBatDau', newDlg);
        var NgayKetThuc = $('.NgayKetThuc', newDlg);
        var GiaKhuyenMai = $('.GiaKhuyenMai', newDlg);
        var TyLeKhuyenMai = $('.TyLeKhuyenMai', newDlg);
        var GiaThiTruong = $('.GiaThiTruong', newDlg);
        var GiaThuVe = $('.GiaThuVe', newDlg);
        var SoLuongMua = $('.SoLuongMua', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Active = $('.Active', newDlg);
        var Hot = $('.Hot', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _SPA_ID = SPA_ID.attr('_value');
        var _Ten = Ten.val();
        var _NgayBatDau = NgayBatDau.val();
        var _NgayKetThuc = NgayKetThuc.val();
        var _GiaKhuyenMai = GiaKhuyenMai.val();
        var _TyLeKhuyenMai = TyLeKhuyenMai.val();
        var _GiaThiTruong = GiaThiTruong.val();
        var _GiaThuVe = GiaThuVe.val();
        var _SoLuongMua = SoLuongMua.val();
        var _MoTa = MoTa.val();
        var _Active = Active.is(':checked');
        var _Hot = Hot.is(':checked');

        var err = '';
        if (_Ten == '') { err += 'Nhập tên<br/>'; }
        if (_GiaKhuyenMai == '') { err += 'Nhập giá<br/>'; }
        if (_TyLeKhuyenMai == '') { err += 'Nhập tỷ lệ<br/>'; }
        if (_SPA_ID == '') { err += 'Chọn Spa<br/>'; }
        if (err != '') { spbMsg.html(err); return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: spaKhuyenMaiMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                '_ID': _ID,
                '_SPA_ID': _SPA_ID,
                '_NgayBatDau': _NgayBatDau,
                '_NgayKetThuc': _NgayKetThuc,
                '_Ten': _Ten,
                '_GiaKhuyenMai': _GiaKhuyenMai,
                '_TyLeKhuyenMai': _TyLeKhuyenMai,
                '_GiaThiTruong': _GiaThiTruong,
                '_GiaThuVe': _GiaThuVe,
                '_SoLuongMua': _SoLuongMua,
                '_MoTa': _MoTa,
                '_Active': _Active,
                '_Hot': _Hot
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#spaKhuyenMaiMgrMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        spaKhuyenMaiMgrFn.loadHtml(function () {
            var newDlg = $('#spaKhuyenMaiMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                buttons: {
                    'Lưu': function () {
                        spaKhuyenMaiMgrFn.save(function () {
                            spaKhuyenMaiMgrFn.clearform();
                        }, '#spaKhuyenMaiMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        spaKhuyenMaiMgrFn.save(function () {
                            $(newDlg).dialog('close');
                        }, '#spaKhuyenMaiMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    spaKhuyenMaiMgrFn.clearform();
                    spaKhuyenMaiMgrFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#spaKhuyenMaiMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var NgayBatDau = $('.NgayBatDau', newDlg);
        var NgayKetThuc = $('.NgayKetThuc', newDlg);
        var GiaKhuyenMai = $('.GiaKhuyenMai', newDlg);
        var TyLeKhuyenMai = $('.TyLeKhuyenMai', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Active = $('.Active', newDlg);
        var Hot = $('.Hot', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        adm.regType(typeof (quanLySpaFn), 'plugin.spa.quanLySpa.Class1, plugin.spa.quanLySpa', function () {
            quanLySpaFn.autoComplete(SPA_ID, function (event, ui) {
                $(SPA_ID).attr('_value', ui.item.id);
            });
        });
        var _d = new Date();
        var _dStr = _d.getDate() + '/' + (_d.getMonth() + 1) + '/' + (_d.getFullYear());
        NgayBatDau.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayKetThuc.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayBatDau.val(_dStr);
        NgayKetThuc.val(_dStr);
        adm.createFckFull(MoTa);
    },
    clearform: function () {
        var newDlg = $('#spaKhuyenMaiMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var NgayBatDau = $('.NgayBatDau', newDlg);
        var NgayKetThuc = $('.NgayKetThuc', newDlg);
        var GiaKhuyenMai = $('.GiaKhuyenMai', newDlg);
        var TyLeKhuyenMai = $('.TyLeKhuyenMai', newDlg);
        var GiaThiTruong = $('.GiaThiTruong', newDlg);
        var GiaThuVe = $('.GiaThuVe', newDlg);
        var SoLuongMua = $('.SoLuongMua', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Active = $('.Active', newDlg);
        var Hot = $('.Hot', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        ID.val('');
        Ten.val('');
        SPA_ID.val(''); SPA_ID.attr('_value', '');
        NgayBatDau.val('');
        NgayKetThuc.val('');
        GiaKhuyenMai.val('');
        TyLeKhuyenMai.val('');
        MoTa.val('');
        GiaThiTruong.val('');
        GiaThuVe.val('');
        SoLuongMua.val('');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#spaKhuyenMaiMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.spa.SpaKhuyenMaiMgr.htm.htm")%>',
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
