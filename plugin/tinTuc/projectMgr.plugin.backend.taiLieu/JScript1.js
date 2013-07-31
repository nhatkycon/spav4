var tailieufn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=projectMgr.plugin.backend.taiLieu.Class1, projectMgr.plugin.backend.taiLieu',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu tài liệu');
        adm.styleButton();
        $('#tailieumdl-List').jqGrid({
            url: tailieufn.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', '#', 'Ảnh', 'Tài Liệu', 'Loại tài liệu', 'Tên', 'Tác giả', 'Nhà xuất bản', 'Ngôn ngữ', 'Giá bán', 'Mô tả'],
            colModel: [
            { name: 'TL_ID', key: true, sortable: true, hidden: true },
            { name: 'TL_ThuTu', width: 20, resizable: true, sortable: true, align: "center" },
            { name: 'TL_Anh', width: 30, resizable: true, sortable: true, align: "center" },
            { name: 'TL_DM_ID', width: 20, resizable: true, sortable: true, align: "center", hidden: true },
            { name: 'TL_DM_Ten', width: 50, resizable: true, sortable: true },
            { name: 'TL_Ten', width: 100, resizable: true, sortable: true },
            { name: 'TL_TacGia', width: 80, resizable: true, sortable: true },
            { name: 'TL_NhaXuatBan', width: 80, resizable: true, sortable: true },
            { name: 'TL_NgonNgu', width: 70, resizable: true, sortable: true },
            { name: 'TL_GiaBan', width: 40, resizable: true, sortable: true, align: "center" },
            { name: 'TL_Url', width: 150, resizable: true, sortable: true }
        ],
            caption: 'Danh sách tài liệu',
            autowidth: true,
            sortname: 'TL_ThuTu',
            sortorder: 'asc',
            rowNum: 50,
            rowList: [50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#tailieumdl-Pager'),
            onSelectRow: function (rowid) {

            },
            loadComplete: function () {
                adm.loading(null);
                //adm.regQS(searchTxt, 'tinmdl-List');
                var txtfilter = $('.mdl-head-filterdanhmuc');
                adm.watermarks(txtfilter, 'Nhập loại tài liệu để lọc', function () {
                });
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteByLoai('LTL', txtfilter, function (event, ui) {
                        $(txtfilter).val(ui.item.label);
                        $(txtfilter).attr('_value', ui.item.id);
                        tailieufn.search();
                    });
                    $(txtfilter).unbind('click').click(function () {
                        $(txtfilter).autocomplete('search', '');
                    });
                });
            },
            grouping: false,
            groupingView: {
                groupField: ['TL_ViTri_Ten'],
                groupColumnShow: [true],
                groupText: ['<b>{0}</b>  - <span style=\"color:red;\">Tổng số: {1}</span>'],
                groupCollapse: false,
                groupOrder: ['asc'],
                groupSummary: [true],
                groupColumnShow: [false],
                groupDataSorted: true
            }
        });

        var filterLoaiDanhMucID = $('.mdl-head-filterdanhmuc');
        var searchTxt = $('.mdl-head-search-tailieu');

        $('.mdl-head-filterdanhmuc').keyup(function () {
            if ($('.mdl-head-filterdanhmuc').val() == '') {
                $('.mdl-head-filterdanhmuc').attr('_value', '');
                if ($(searchTxt).val() == 'Tìm kiếm tài liệu') {
                    $(searchTxt).val('');
                }
                tailieufn.search();
                if ($(searchTxt).val() == '') {
                    $(searchTxt).val('Tìm kiếm tài liệu');
                }
            }
        });

        $('.mdl-head-search-tailieu').keyup(function () {
            tailieufn.search();
        });

        adm.watermark(searchTxt, 'Tìm kiếm tài liệu', function () {
            $(searchTxt).val('');
            tailieufn.search();
            $(searchTxt).val('Tìm kiếm tài liệu');
        });
        adm.watermark(filterLoaiDanhMucID, 'Nhập loại tài liệu để lọc', function () {
            if ($(searchTxt).val() == 'Tìm kiếm tài liệu') {
                $(searchTxt).val('');
            }
            tailieufn.search();
            if ($(searchTxt).val() == '') {
                $(searchTxt).val('Tìm kiếm tài liệu');
            }
        });
    },
    add: function () {
        tailieufn.loadHtml(function () {
            var newDlg = $('#tailieumdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        tailieufn.save(false, function () {
                            tailieufn.clearform();
                            tailieufn.insertDraff();
                        });
                    },
                    'Lưu và đóng': function () {
                        tailieufn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    tailieufn.clearform();
                    tailieufn.insertDraff(function () {
                        tailieufn.addpopfn();
                    });
                }
            });
        });
    },
    insertDraff: function (fn) {
        var newDlg = $('#tailieumdl-dlgNew');
        $.ajax({
            url: tailieufn.urlDefault + '&subAct=insert',
            success: function (_dt) {
                adm.loading(null);
                var dt = eval(_dt);
                var txtID = $('.ID', newDlg);
                //var txtTT_So = $('.TT_So', newDlg)
                $(txtID).val(dt.ID);
                $(txtID).attr('_value', dt.RowId);
                //$(txtTT_So).val(dt.TT_So);
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    edit: function () {
        var s = '';
        if (jQuery('#tailieumdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#tailieumdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẫu tài liệu để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẫu tài liệu');
            }
            else {
                tailieufn.loadHtml(function () {
                    var newDlg = $('#tailieumdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                tailieufn.save(false, function () {
                                    tailieufn.clearform();
                                    tailieufn.insertDraff();
                                });
                            },
                            'Lưu và đóng': function () {
                                tailieufn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            tailieufn.clearform();
                            $.ajax({
                                url: tailieufn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#tailieumdl-dlgNew');
                                    var lbladm_upload_fileList = $('.adm-upload-fileList', newDlg);
                                    var txtID = $('.ID', newDlg);
                                    $(txtID).val(data.ID);
                                    $(txtID).attr('_value', data.RowId);
                                    tailieufn.addpopfn();
                                    var txtPID = $('.DMID', newDlg);
                                    $(txtPID).val(data.DM_Ten);
                                    $(txtPID).attr('_value', data.DM_ID);
                                    var txtTen = $('.Ten', newDlg);
                                    $(txtTen).val(data.Ten);
                                    var txtSTT = $('.ThuTu', newDlg);
                                    $(txtSTT).val(data.ThuTu);
                                    var txtUrl = $('.Url', newDlg);
                                    $(txtUrl).val(data.Url);

                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    $(lblAnh).attr('ref', data.Anh);
                                    if (data.Anh != '') {
                                        $(lblAnhPrvImg).attr('src', '../up/i/' + data.Anh + '?ref=' + Math.random());
                                    }

                                    $(lbladm_upload_fileList).html(data.FileListStr);
                                    $.each($('.adm-token-item', newDlg), function (i, item) {
                                        $(item).find('a').unbind('click').click(function () {
                                            var _item = $(this).parent();
                                            $(_item).hide();
                                            $.ajax({
                                                url: tailieufn.urlDefault,
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

                                    var txtTacGia = $('.TacGia', newDlg);
                                    var TacGia = $(txtTacGia).val(data.TacGia);

                                    var txtNhaXuatBan = $('.NhaXuatBan', newDlg);
                                    var NhaXuatBan = $(txtNhaXuatBan).val(data.NhaXuatBan);

                                    var txtNgonNgu = $('.NgonNgu', newDlg);
                                    var NgonNgu = $(txtNgonNgu).val(data.NgonNgu);

                                    var txtGiaBan = $('.GiaBan', newDlg);
                                    var GiaBan = $(txtGiaBan).val(data.GiaBan);

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
        s = jQuery("#tailieumdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tài liệu để xóa');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tailieumdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: tailieufn.urlDefault + '&subAct=del',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#tailieumdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    duyet: function () {
        var s = '';
        s = jQuery("#tailieumdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn mẫu tài liệu nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tailieumdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: tailieufn.urlDefault + '&subAct=duyet',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#tailieumdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-tailieu');
        var searchTxt = $('.mdl-head-filterdanhmuc');
        var q = filterDM.val();
        if (q == 'Tìm kiếm tin tức') {
            q = '';
        }
        var dm = $(searchTxt).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#tailieumdl-List').jqGrid('setGridParam', { url: tailieufn.urlDefault + "&subAct=get&q=" + q + "&DMID=" + dm }).trigger("reloadGrid");
        }, 500);
    },
    save: function (validate, fn) {
        var newDlg = $('#tailieumdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();

        var txtPID = $('.DMID', newDlg);
        var pid = $(txtPID).attr('_value');
        var pten = $(txtPID).val();

        var txtTen = $('.Ten', newDlg);
        var ten = $(txtTen).val();

        var txtThuTu = $('.ThuTu', newDlg);
        var ThuTu = $(txtThuTu).val();

        var ckbPublish = $('.Publish', newDlg);
        var Publish = $(ckbPublish).val();

        var txtUrl = $('.Url', newDlg);
        var QUrl = $(txtUrl).val();

        var lblAnh = $('.Anh', newDlg);
        var anh = $(lblAnh).attr('ref');

        var txtTacGia = $('.TacGia', newDlg);
        var TacGia = $(txtTacGia).val();

        var txtNhaXuatBan = $('.NhaXuatBan', newDlg);
        var NhaXuatBan = $(txtNhaXuatBan).val();

        var txtNgonNgu = $('.NgonNgu', newDlg);
        var NgonNgu = $(txtNgonNgu).val();

        var txtGiaBan = $('.GiaBan', newDlg);
        var GiaBan = $(txtGiaBan).val();

        var spbMsg = $('.admMsg', newDlg);
        var err = '';
        if (pid == '') {
            err += 'Nhập mục tài liệu<br/>';
        }

        if (ten == '') {
            err += 'Nhập tên<br/>';
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
            url: tailieufn.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': id,
                'DMID': pid,
                'DMTen': pten,
                'ThuTu': ThuTu,
                'Ten': ten,
                'QUrl': QUrl,
                'Public': Publish,
                'TacGia': TacGia,
                'NhaXuatBan': NhaXuatBan,
                'NgonNgu': NgonNgu,
                'GiaBan': GiaBan,
                'Anh': anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#tailieumdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    clearform: function () {
        var newDlg = $('#tailieumdl-dlgNew');
        var txtID = $('.ID', newDlg);
        $(txtID).val('');
        var txtPID = $('.DMID', newDlg);
        $(txtPID).val('');
        $(txtPID).attr('_value', '');
        var txtTen = $('.Ten', newDlg);
        $(txtTen).val('');
        var txtSTT = $('.ThuTu', newDlg);
        $(txtSTT).val('');
        var ckbPublish = $('.Active', newDlg);
        $(ckbPublish).removeAttr('checked');
        var txtUrl = $('.Url', newDlg);
        $(txtUrl).val('');

        var txtTacGia = $('.TacGia', newDlg);
        $(txtTacGia).val('');

        var txtNhaXuatBan = $('.NhaXuatBan', newDlg);
        $(txtNhaXuatBan).val('');

        var txtNgonNgu = $('.NgonNgu', newDlg);
        $(txtNgonNgu).val('');

        var txtGiaBan = $('.GiaBan', newDlg);
        $(txtGiaBan).val('');

        var lblAnh = $('.Anh', newDlg);
        var lbladm_upload_fileList = $('.adm-upload-fileList', newDlg);
        $(lbladm_upload_fileList).html('');
        $(lblAnh).attr('ref', '');
        $(lblAnh).prev().find('img').attr('src', '');

        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        $(spbMsg).html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#tailieumdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("projectMgr.plugin.backend.taiLieu.htm.htm")%>',
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
        var newDlg = $('#tailieumdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtDMID = $('.DMID', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var ulpFn = function () {
            var uploadBtn = $('.adm-upload-btn', newDlg);
            var uploadView = $('.adm-upload-preview-img', newDlg);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.upload(uploadBtn, 'anh', _params, function (rs) {
                $(uploadBtn).attr('ref', rs)
                $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteByLoai('LTL', txtDMID, function (event, ui) {
                $(txtDMID).attr('_value', ui.item.id);
                // Nếu thứ tự là rỗng thì tìm max thứ tự + 1
            });
        });

        var fileList = $('.adm-upload-fileList', newDlg);

        var fileBtn = $('.File', newDlg);
        var _params = { 'act': 'uploadfileDkLuong' }

        adm.upload(fileBtn, 'doc', _params, function (rs) {

        }, function (_rs) {

        }, function (_r, _f) {
            var l = '';
            l += '<span class=\"adm-token-item\" _value=\"' + _r.replace('.', '') + '\">' + _f + '<a href=\"javascript:;\">x</a></span>';
            $.ajax({
                url: tailieufn.urlDefault,
                data: {
                    'subAct': 'saveDoc',
                    'F_ID': _r,
                    'ID': $(txtID).attr('_value')
                }, success: function (dt) {

                }
            });
            $(l).appendTo(fileList).find('a').click(function () {
                var _item = $(this);
                $(_item).hide();
                $.ajax({
                    url: tailieufn.urlDefault,
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
}