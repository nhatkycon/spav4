var hinhAnhSpaFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.spa.hinhAnhSpaMgr.Class1, plugin.spa.hinhAnhSpaMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#hinhAnhSpaMdl-List').jqGrid({
            url: hinhAnhSpaFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Ảnh', 'Tên', 'Thứ tự', 'Spa'],
            colModel: [
            { name: 'SPAHA_ID', key: true, sortable: true, hidden: true },
            { name: 'SPAHA_Anh', width: 25, sortable: false, editable: true },
            { name: 'SPAHA_Ten', width: 60, resizable: true, sortable: false, editable: true },
            { name: 'SPAHA_Thu', width: 5, resizable: true, sortable: false, editable: true },
            { name: 'SPAHA_SPA_ID', width: 10, resizable: true, sortable: false }
            ],
            caption: 'Ảnh',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'SPAHA_NgayTao',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#hinhAnhSpaMdl-Pager'),
            onSelectRow: function (rowid) {
                var SPA_ID = $('.mdl-head-spaAnhFilterBySpa');
                adm.regType(typeof (quanLySpaFn), 'plugin.spa.quanLySpa.Class1, plugin.spa.quanLySpa', function () {
                    quanLySpaFn.autoComplete(SPA_ID, function (event, ui) {
                        $(SPA_ID).attr('_value', ui.item.id);
                        hinhAnhSpaFn.search();
                    });
                });
            },
            loadComplete: function () {
                adm.loading(null);
                hinhAnhSpaFn.headFn();
            }
        });
        $.getScript('../js/ajaxupload.js', function () { });
    },
    headFn: function () {
        var searchTxt = $('.mdl-head-search-hinhAnhSpaMdl');
        $(searchTxt).unbind('keyup').keyup(function () {
            hinhAnhSpaFn.search();
        });
        
    },
    search: function () {
        var timerSearch;
        var SPA_ID = $('.mdl-head-spaAnhFilterBySpa');
        var _SPA_ID = SPA_ID.attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#hinhAnhSpaMdl-List').jqGrid('setGridParam', { url: hinhAnhSpaFn.urlDefault
             + '&SPA_ID=' + _SPA_ID
             + '&subAct=get'
            }).trigger("reloadGrid");
        }, 1000);
    },
    edit: function () {
        var s = '';
        if (jQuery('#hinhAnhSpaMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#hinhAnhSpaMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                hinhAnhSpaFn.loadHtml(function () {
                    var newDlg = $('#hinhAnhSpaMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 800,
                        buttons: {
                            'Lưu': function () {
                                hinhAnhSpaFn.save(false, function () { hinhAnhSpaFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                hinhAnhSpaFn.save(false, function () { hinhAnhSpaFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            hinhAnhSpaFn.clearform();
                            hinhAnhSpaFn.popfn();
                            $.ajax({
                                url: hinhAnhSpaFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                type:'POST',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var SPA_ID = $('.SPA_ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var Active = $('.Active', newDlg);
                                    
                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    var spbMsg = $('.admMsg', newDlg);

                                    $(ID).val(dt.ID);
                                    $(SPA_ID).val(dt.SPA_Ten); $(SPA_ID).attr('_value', dt.SPA_ID);
                                    $(Ten).val(dt.Ten);
                                    $(ThuTu).val(dt.ThuTu);
                                    $(MoTa).val(dt.MoTa);
                                    if (dt.Active) { $(Active).attr('checked', 'checked'); } else { $(Active).removeAttr('checked', 'checked'); }
                                    if (dt.Anh != '') {
                                        $(lblAnh).attr('ref', dt.Anh);
                                        $(lblAnhPrvImg).attr('src', '../up/' + dt.Anh + '?ref=' + Math.random());
                                    }
                                    $(spbMsg).html('');
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
        if (jQuery('#hinhAnhSpaMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#hinhAnhSpaMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: hinhAnhSpaFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery('#hinhAnhSpaMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#hinhAnhSpaMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Active = $('.Active', newDlg);
        
        var lblAnh = $('.Anh', newDlg);
        var lblAnhPrv = $('.adm-upload-preview', newDlg);
        var lblAnhPrvImg = $(lblAnhPrv).find('img');
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _Ten = $(Ten).val();
        var _SPA_ID = $(SPA_ID).attr('_value');
        var _ThuTu = $(ThuTu).val();
        var _MoTa = $(MoTa).val();
        var _Active = $(Active).is(':checked');
        var _anh = $(lblAnh).attr('ref');

        var err = '';
        if (_Ten == '') { err += 'Nhập Tên<br/>'; }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');

        var datas = {
            ID: _ID,
            SPA_ID: _SPA_ID,
            Ten: _Ten,
            MoTa: _MoTa,
            Anh: _anh,
            ThuTu: _ThuTu,
            Active: _Active
        };

        $.ajax({
            url: hinhAnhSpaFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: datas,
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#hinhAnhSpaMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        hinhAnhSpaFn.loadHtml(function () {
            var newDlg = $('#hinhAnhSpaMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 800,
                buttons: {
                    'Lưu': function () {
                        hinhAnhSpaFn.save(false, function () {
                            hinhAnhSpaFn.clearform();
                        }, '#hinhAnhSpaMdl-List');
                    },
                    'Lưu và đóng': function () {
                        hinhAnhSpaFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#hinhAnhSpaMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    hinhAnhSpaFn.clearform();
                    hinhAnhSpaFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#hinhAnhSpaMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Anh = $('.Anh', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var NgayTao = $('.NgayTao', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var Active = $('.Active', newDlg);
        

        adm.regType(typeof (quanLySpaFn), 'plugin.spa.quanLySpa.Class1, plugin.spa.quanLySpa', function () {
            quanLySpaFn.autoComplete(SPA_ID, function (event, ui) {
                $(SPA_ID).attr('_value', ui.item.id);
            });
        });
        var ulpFn = function() {
            var uploadBtn = $('.adm-upload-btn', newDlg);
            var uploadView = $('.adm-upload-preview-img', newDlg);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.upload(uploadBtn, 'anh', _params, function(rs) {
                $(uploadBtn).attr('ref', rs)
                $(uploadView).attr('src', '/lib/up/i/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function(f) {
            });
        };
        ulpFn();

    },
    clearform: function () {
        var newDlg = $('#hinhAnhSpaMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Anh = $('.Anh', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Active = $('.Active', newDlg);

        var lblAnhPrv = $('.adm-upload-preview-img', newDlg);
        
        var spbMsg = $('.admMsg', newDlg);

        Ten.val('');
        MoTa.val('');
        ThuTu.val('');
        Ten.focus();
        //newDlg.find('input, textarea').val('');
        //newDlg.find('input').attr('_value', '');

        Anh.attr('ref', '');
        lblAnhPrv.attr('src', '');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#hinhAnhSpaMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.spa.hinhAnhSpaMgr.htm.htm")%>',
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
