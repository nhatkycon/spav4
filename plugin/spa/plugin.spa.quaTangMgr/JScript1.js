var quaTangFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.spa.quaTangMgr.Class1, plugin.spa.quaTangMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#quaTangMdl-List').jqGrid({
            url: quaTangFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Ảnh', 'Spa', 'Tên', 'Số phiếu'],
            colModel: [
            { name: 'QT_ID', key: true, sortable: true, hidden: true },
            { name: 'QT_Anh', width: 10, sortable: false, editable: true },
            { name: 'QT_Ten', width: 20, resizable: true, sortable: false, editable: true },
            { name: 'QT_Thu', width: 60, resizable: true, sortable: false, editable: true },
            { name: 'QT_TongPhieu', width: 10, resizable: true, sortable: false }
            ],
            caption: 'Quà tặng',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'QT_NgayTao',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#quaTangMdl-Pager'),
            onSelectRow: function (rowid) {
                var SPA_ID = $('.mdl-head-spaAnhFilterBySpa');
                adm.regType(typeof (quanLySpaFn), 'plugin.spa.quanLySpa.Class1, plugin.spa.quanLySpa', function () {
                    quanLySpaFn.autoComplete(SPA_ID, function (event, ui) {
                        $(SPA_ID).attr('_value', ui.item.id);
                        quaTangFn.search();
                    });
                });
            },
            loadComplete: function () {
                adm.loading(null);
                quaTangFn.headFn();
            }
        });
        $.getScript('../js/ajaxupload.js', function () { });
    },
    headFn: function () {
        var searchTxt = $('.mdl-head-search-quaTangMdl');
        $(searchTxt).unbind('keyup').keyup(function () {
            quaTangFn.search();
        });
        
    },
    search: function () {
        var timerSearch;
        var SPA_ID = $('.mdl-head-spaAnhFilterBySpa');
        var _SPA_ID = SPA_ID.attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#quaTangMdl-List').jqGrid('setGridParam', { url: quaTangFn.urlDefault
             + '&SPA_ID=' + _SPA_ID
             + '&subAct=get'
            }).trigger("reloadGrid");
        }, 1000);
    },
    edit: function () {
        var s = '';
        if (jQuery('#quaTangMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#quaTangMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                quaTangFn.loadHtml(function () {
                    var newDlg = $('#quaTangMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 800,
                        buttons: {
                            'Lưu': function () {
                                quaTangFn.save(false, function () { quaTangFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                quaTangFn.save(false, function () { quaTangFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            quaTangFn.clearform();
                            quaTangFn.popfn();
                            $.ajax({
                                url: quaTangFn.urlDefault + '&subAct=edit',
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
                                    var DV_ID = $('.DV_ID', newDlg);
                                    var Anh = $('.Anh', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var Hot = $('.Hot', newDlg);
                                    var TrangChu = $('.TrangChu', newDlg);
                                    var HetHan = $('.HetHan', newDlg);
                                    
                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    var spbMsg = $('.admMsg', newDlg);

                                    $(ID).val(dt.ID);
                                    $(SPA_ID).val(dt.SPA_Ten); $(SPA_ID).attr('_value', dt.SPA_ID);
                                    $(DV_ID).val(dt.DV_Ten); $(SPA_ID).attr('_value', dt.DV_ID);
                                    
                                    $(Ten).val(dt.Ten);
                                    $(NoiDung).val(dt.NoiDung);
                                    $(MoTa).val(dt.MoTa);

                                    if (dt.Active) { $(Active).attr('checked', 'checked'); } else { $(Active).removeAttr('checked', 'checked'); }
                                    if (dt.Hot) { $(Hot).attr('checked', 'checked'); } else { $(Hot).removeAttr('checked', 'checked'); }
                                    if (dt.TrangChu) { $(TrangChu).attr('checked', 'checked'); } else { $(TrangChu).removeAttr('checked', 'checked'); }
                                    if (dt.HetHan) { $(HetHan).attr('checked', 'checked'); } else { $(HetHan).removeAttr('checked', 'checked'); }
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
        if (jQuery('#quaTangMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#quaTangMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: quaTangFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery('#quaTangMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#quaTangMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var DV_ID = $('.DV_ID', newDlg);
        var Anh = $('.Anh', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Active = $('.Active', newDlg);
        var Hot = $('.Hot', newDlg);
        var TrangChu = $('.TrangChu', newDlg);
        var HetHan = $('.HetHan', newDlg);
        
        
        var lblAnh = $('.Anh', newDlg);
        var lblAnhPrv = $('.adm-upload-preview', newDlg);
        var lblAnhPrvImg = $(lblAnhPrv).find('img');
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _Ten = $(Ten).val();
        var _SPA_ID = $(SPA_ID).attr('_value');
        var _DV_ID = $(DV_ID).attr('_value');
        var _MoTa = $(MoTa).val();
        var _NoiDung = $(NoiDung).val();
        var _Active = $(Active).is(':checked');
        var _Hot = $(Hot).is(':checked');
        var _TrangChu = $(TrangChu).is(':checked');
        var _HetHan = $(HetHan).is(':checked');
        
        var _anh = $(lblAnh).attr('ref');

        var err = '';
        if (_Ten == '') { err += 'Nhập Tên<br/>'; }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');

        var datas = {
            ID: _ID,
            SPA_ID: _SPA_ID,
            DV_ID : _DV_ID,
            Ten: _Ten,
            MoTa: _MoTa,
            NoiDung: _NoiDung,
            Anh: _anh,
            Hot: _Hot,
            TrangChu: _TrangChu,
            HetHan: _HetHan,
            Active: _Active
        };

        $.ajax({
            url: quaTangFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: datas,
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#quaTangMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        quaTangFn.loadHtml(function () {
            var newDlg = $('#quaTangMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 800,
                buttons: {
                    'Lưu': function () {
                        quaTangFn.save(false, function () {
                            quaTangFn.clearform();
                        }, '#quaTangMdl-List');
                    },
                    'Lưu và đóng': function () {
                        quaTangFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#quaTangMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    quaTangFn.clearform();
                    quaTangFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#quaTangMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var DV_ID = $('.DV_ID', newDlg);
        var Anh = $('.Anh', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Active = $('.Active', newDlg);
        var Hot = $('.Hot', newDlg);
        var TrangChu = $('.TrangChu', newDlg);
        var HetHan = $('.HetHan', newDlg);
        

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
        adm.createFckFull(NoiDung);
    },
    clearform: function () {
        var newDlg = $('#quaTangMdl-dlgNew');
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
        
        newDlg.find('input, textarea').val('');
        newDlg.find('input').attr('_value', '');

        Anh.attr('ref', '');
        lblAnhPrv.attr('src', '');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#quaTangMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.spa.quaTangMgr.htm.htm")%>',
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
