var spaKhachHangMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.spa.SpaKhachHangMgr.Class1, plugin.spa.SpaKhachHangMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#spaKhachHangMgrMdl-List').jqGrid({
            url: spaKhachHangMgrFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Tên', 'Email', 'Mobile', 'Địa chỉ', 'Active','Đọc'],
            colModel: [
            { name: 'KH_ID', key: true, sortable: true, hidden: true },
            { name: 'KH_Ten', width: 40, sortable: false, editable: true },
            { name: 'KH_Email', width: 10, resizable: true, sortable: false, editable: true },
            { name: 'KH_Mobile', width: 10, resizable: true, sortable: false, editable: true },
            { name: 'KH_DiaChi', width: 30, resizable: true, sortable: false, editable: true },
            { name: 'KH_Active', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'KH_Readed', width: 5, resizable: true, sortable: false, formatter: 'checkbox' }
            ],
            caption: 'Khách hàng',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'KH_ID',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#spaKhachHangMgrMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#spaKhachHangMgrMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
                spaKhachHangMgrFn.headFn();
            }
        });
    },
    headFn: function () {
        var searchTxt = $('.mdl-head-search-spaKhachHangMgrMdl');
        $(searchTxt).unbind('keyup').keyup(function () {
            spaKhachHangMgrFn.search();
        });
    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-search-spaKhachHangMgrMdl');
        var __q = $(searchTxt).val();
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#spaKhachHangMgrMdl-List').jqGrid('setGridParam', { url: spaKhachHangMgrFn.urlDefault
             + '&q=' + __q
             + '&subAct=get'
            }).trigger("reloadGrid");
        }, 1000);
    },
    edit: function () {
        var s = '';
        if (jQuery('#spaKhachHangMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#spaKhachHangMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                spaKhachHangMgrFn.loadHtml(function () {
                    var newDlg = $('#spaKhachHangMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                spaKhachHangMgrFn.save(function () { spaKhachHangMgrFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                spaKhachHangMgrFn.save(function () { spaKhachHangMgrFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            spaKhachHangMgrFn.clearform();
                            spaKhachHangMgrFn.popfn();
                            $.ajax({
                                url: spaKhachHangMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                type: 'POST',
                                data: {
                                    '_ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var Ho = $('.Ho', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var Email = $('.Email', newDlg);
                                    var Mobile = $('.Mobile', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var Readed = $('.Readed', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    Ma.val(dt.Ma);
                                    Ho.val(dt.Ho);
                                    Ten.val(dt.Ten);
                                    Email.val(dt.Email);
                                    Mobile.val(dt.Mobile);
                                    MoTa.val(dt.DiaChi);
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
        if (jQuery('#spaKhachHangMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#spaKhachHangMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: spaKhachHangMgrFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            '_ID': s
                        },
                        success: function (dt) {
                            jQuery('#spaKhachHangMgrMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (fn) {
        var newDlg = $('#spaKhachHangMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ho = $('.Ho', newDlg);
        var Ten = $('.Ten', newDlg);
        var Email = $('.Email', newDlg);
        var Mobile = $('.Mobile', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Active = $('.Active', newDlg);
        var Readed = $('.Readed', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _Ma = Ma.val();
        var _Ho = Ho.val();
        var _Ten = Ten.val();
        var _Email = Email.val();
        var _Mobile = Mobile.val();
        var _MoTa = MoTa.val();
        var _Active = Active.is(':checked');
        var _Readed = Readed.is(':checked');

        var err = '';
        if (_Ten == '') { err += 'Nhập tên<br/>'; }
        if (err != '') { spbMsg.html(err); return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: spaKhachHangMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                '_ID': _ID,
                '_Ma': _Ma,
                '_Ho': _Ho,
                '_Ten': _Ten,
                '_Email': _Email,
                '_Mobile': _Mobile,
                '_MoTa': _MoTa,
                '_Active': _Active,
                '_Readed': _Readed
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#spaKhachHangMgrMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        spaKhachHangMgrFn.loadHtml(function () {
            var newDlg = $('#spaKhachHangMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                buttons: {
                    'Lưu': function () {
                        spaKhachHangMgrFn.save(function () {
                            spaKhachHangMgrFn.clearform();
                        }, '#spaKhachHangMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        spaKhachHangMgrFn.save(function () {
                            $(newDlg).dialog('close');
                        }, '#spaKhachHangMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    spaKhachHangMgrFn.clearform();
                    spaKhachHangMgrFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#spaKhachHangMgrMdl-dlgNew');
    },
    clearform: function () {
        var newDlg = $('#spaKhachHangMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ho = $('.Ho', newDlg);
        var Ten = $('.Ten', newDlg);
        var Email = $('.Email', newDlg);
        var Mobile = $('.Mobile', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Active = $('.Active', newDlg);
        var KM = $('.KM', newDlg);
        var Readed = $('.Readed', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $('input, textarea', newDlg).val('');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#spaKhachHangMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.spa.SpaKhachHangMgr.htm.htm")%>',
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

