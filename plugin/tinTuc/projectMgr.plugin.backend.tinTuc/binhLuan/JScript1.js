var dbBlfn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=projectMgr.plugin.backend.tinTuc.binhLuan.Class1, projectMgr.plugin.backend.tinTuc',
    setup: function () {
    },
    loadgrid: function () {

        adm.loading('Đang lấy dữ liệu tin tức');
        adm.styleButton();
        $('#dbBlMdl-List').jqGrid({
            url: dbBlfn.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Tên', 'Email', 'Mobile', 'NoiDung', 'Tin', 'Active'],
            colModel: [
                        { name: 'TIN_ID', key: true, sortable: true, hidden: true },
                        { name: 'Tên', width: 10, sortable: true },
                        { name: 'Email', width: 10, resizable: true, sortable: true, hidden: true },
                        { name: 'Mobile', width: 10, resizable: true, sortable: true },
                        { name: 'NoiDung', width: 30, resizable: true, sortable: true },
                        { name: 'Active', width: 5, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                        { name: 'Tin', width: 5, resizable: true, sortable: true }
                    ],
            caption: 'Danh sách Bình luận',
            autowidth: true,
            sortname: 'TIN_NgayCapNhat',
            sortorder: 'desc',
            rowNum: 10,
            rowList: [10, 20, 50, 100, 200, 300],
            pager: jQuery('#dbBlMdl-Pagerql'),
            onSelectRow: function (rowid) {

            },
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    del: function (fn) {
        var s = '';
        if (jQuery("#dbBlMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#dbBlMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa?')) {
                    $.ajax({
                        url: dbBlfn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery("#dbBlMdl-List").trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    duyet: function (st) {
        var s = '';
        if (jQuery("#dbBlMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#dbBlMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                $.ajax({
                    url: dbBlfn.urlDefault + '&subAct=duyet',
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery("#dbBlMdl-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    send: function (act,fn) {
        var newDlg = $('#dbBlMdl-dlgNew');
        var NoiDung = $('.NoiDung', newDlg);
        var TIN_ID = $('.TIN_ID', newDlg);
        var ID = $('.ID', newDlg);
        var _NoiDung = NoiDung.val();
        var _PID = TIN_ID.val();
        var _ID = ID.val();

        $.ajax({
            url: dbBlfn.urlDefault + '&subAct=' + act,
            dataType: 'script',
            data: {
                'ID': _ID,
                'NoiDung': _NoiDung,
                'PID': _PID
            },
            success: function (_dt) {
                if (typeof (fn) == 'function') { fn(); };
            }
        });

    },
    rep: function () {

        var s = '';
        if (jQuery('#dbBlMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#dbBlMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một bình luận');
            }
            else {
                dbBlfn.loadHtml(function () {
                    var newDlg = $('#dbBlMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Trả lời',
                        width: 900,

                        position: [200, 0],
                        //     modal: true,
                        buttons: {
                            'Gửi': function () {
                                dbBlfn.send('send',function () {
                                    dbBlfn.clearform();
                                    $(newDlg).dialog('close');
                                    jQuery("#dbBlMdl-List").trigger('reloadGrid');
                                });
                            },
                            'Lưu, không gửi': function () {
                                dbBlfn.send('save', function () {
                                    dbBlfn.clearform();
                                    $(newDlg).dialog('close');
                                    jQuery("#dbBlMdl-List").trigger('reloadGrid');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            dbBlfn.clearform();
                            $.ajax({
                                url: dbBlfn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    var dt = eval(_dt);
                                    var newDlg = $('#dbBlMdl-dlgNew');
                                    var NoiDung = $('.NoiDung', newDlg);
                                    adm.createTinyMce(NoiDung);
                                    var TIN_ID = $('.TIN_ID', newDlg);
                                    var ID = $('.ID', newDlg);

                                    NoiDung.val(dt.NoiDung);
                                    TIN_ID.val(dt.PID);
                                    ID.val(dt.ID);
                                }
                            });
                        },
                        beforeclose: function () {
                            dbBlfn.clearform();
                        }
                    });
                });
            }
        }

    },
    clearform: function () {
        var newDlg = $('#dbBlMdl-dlgNew');
        $('input, textarea', newDlg).val('');
    },
    loadHtml: function (fn) {
        var dlg = $('#dbBlMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("projectMgr.plugin.backend.tinTuc.binhLuan.htm.htm")%>',
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
