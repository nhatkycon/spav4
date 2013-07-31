var thongketin = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=agrobiotech.plugin.backend.thongketin.Class1, agrobiotech.plugin.backend.thongketin',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu tin tức');
        adm.styleButton();
        $('#thongketinmdl-List').jqGrid({
            url: thongketin.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Ngày cập nhật', 'Ảnh', 'Tiêu đề', 'Tóm tắt', 'Mã', 'Mục tin', 'Lần đọc', 'Người viết', '#', 'Kích hoạt', 'Hot', 'Hết hạn'],
            colModel: [
            { name: 'TIN_ID', key: true, sortable: true, hidden: true },
            { name: 'TIN_NgayCapNhat', width: 50, resizable: true, sortable: true, align: "center" },
            { name: 'TIN_Anh', width: 130, resizable: true, sortable: true, align: "center", hidden: true },
            { name: 'TIN_Ten', width: 100, resizable: true, sortable: true },
            { name: 'TIN_MoTa', width: 200, resizable: true, sortable: true },
            { name: 'TIN_DM_ID', width: 1, sortable: true, align: "center", hidden: true },
            { name: 'TIN_DM_Ten', width: 50, sortable: true },
            { name: 'TIN_Views', width: 30, resizable: true, sortable: true, hidden: true },
            { name: 'TIN_NguoiTao', width: 50, resizable: true, sortable: true, align: "center" },
            { name: 'TIN_ThuTu', width: 20, resizable: true, sortable: true, align: "center", hidden: true },
            { name: 'TIN_Active', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true },
            { name: 'TIN_Hot', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true },
           { name: 'TIN_HetHan', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true }
        ],
            caption: 'Danh sách tin',
            autowidth: true,
            sortname: 'TIN_NgayCapNhat',
            sortorder: 'desc',
            rowNum: 50,
            rowList: [50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#tinmdl-Pager'),
            onSelectRow: function (rowid) {

            },
            loadComplete: function () {
                adm.loading(null);

                //adm.regQS(searchTxt, 'thongketinmdl-List');



            },

            grouping: false,
            groupingView: {
                groupField: ['TIN_DM_Ten'],
                groupColumnShow: [true],
                groupText: ['<b>{0}</b>  - <span style=\"color:red;\">Tổng số: {1}</span>'],
                groupCollapse: false,
                groupOrder: ['asc'],
                groupSummary: [true],
                groupColumnShow: [false],
                groupDataSorted: true
            }
        });

        var filterLoaiDanhMucID = $('.mdl-head-filterthongketinByCQID');
        var searchTxt = $('.mdl-head-search-thongketin');

        $('.mdl-head-filterthongketinByCQID').keyup(function () {
            if ($('.mdl-head-filterthongketinByCQID').val() == '') {
                $('.mdl-head-filterthongketinByCQID').attr('_value', '');
                if ($(searchTxt).val() == 'Tìm kiếm tin tức') {
                    $(searchTxt).val('');
                }
                thongketin.search();
                if ($(searchTxt).val() == '') {
                    $(searchTxt).val('Tìm kiếm tin tức');
                }
            }
        });

        $('.mdl-head-search-thongketin').keyup(function () {
            thongketin.search();
        });

        adm.watermark(searchTxt, 'Tìm kiếm tin tức', function () {
            $(searchTxt).val('');
            thongketin.search();
            $(searchTxt).val('Tìm kiếm tin tức');
        });
        adm.watermark(filterLoaiDanhMucID, 'Gõ tên mục tin để lọc', function () {
            if ($(searchTxt).val() == 'Tìm kiếm tin tức') {
                $(searchTxt).val('');
            }
            thongketin.search();
            if ($(searchTxt).val() == '') {
                $(searchTxt).val('Tìm kiếm tin tức');
            }
        });
        var _today = new Date();
        var _todayDate = _today.getDate() + '/' + (_today.getMonth() + 1) + '/' + _today.getFullYear();
        var _todayDates = _today.getDate() + '/' + (_today.getMonth() + 1) + '/' + (_today.getFullYear() - 1);

        $('.mdl-head-tungay').datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true, onSelect: function (d, s) { thongketin.search(); } });
        $('.mdl-head-denngay').datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true, onSelect: function (d, s) { thongketin.search(); } });
        $('.mdl-head-tungay').val(_todayDates);
        $('.mdl-head-denngay').val(_todayDate);

        var txtfilter = $('.mdl-head-filterthongketinByCQID');
        var txtthanhvien = $('.mdl-head-filterthanhvien');
        adm.watermarks(txtfilter, 'Lọc theo mục tin', function () {
        });
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteByLoai('TIN', txtfilter, function (event, ui) {
                $(txtfilter).val(ui.item.label);
                $(txtfilter).attr('_value', ui.item.id);
                thongketin.search();
            });
            $(txtfilter).unbind('click').click(function () {
                $(txtfilter).autocomplete('search', '');
            });
        });


        adm.watermarks(txtthanhvien, 'Lọc theo thành viên', function () {
        });
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocompleteCungDonVi(txtthanhvien, function (event, ui) {
                $(txtthanhvien).val(ui.item.label);
                $(txtthanhvien).attr('_value', ui.item.username);
                thongketin.search();
            });
            $(txtthanhvien).unbind('click').click(function () {
                $(txtthanhvien).autocomplete('search', '');
            });
        });

    },
    add: function () {

        thongketin.loadHtml(function () {
            var newDlg = $('#thongketinmdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 813,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        thongketin.save(false, function () {
                            thongketin.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        thongketin.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {

                    adm.styleButton();
                    thongketin.clearform();
                    thongketin.addpopfn();
                }
                ,
                beforeclose: function () {
                    $('.mceEditor', newDlg).remove();
                    $('textarea', newDlg).removeAttr('id');
                    $('textarea', newDlg).show();
                }
            });
        });
    },
    edit: function () {

        var s = '';
        if (jQuery('#thongketinmdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#thongketinmdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {

                thongketin.loadHtml(function () {
                    var newDlg = $('#thongketinmdl-dlgNew');

                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 813,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                thongketin.save(false, function () {
                                    thongketin.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                thongketin.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeclose: function () {
                            $('.mceEditor', newDlg).remove();
                            $('textarea', newDlg).removeAttr('id');
                            $('textarea', newDlg).show();
                        },
                        open: function () {

                            //alert("aaaaaaaaa");
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            thongketin.clearform();
                            $.ajax({
                                url: thongketin.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#thongketinmdl-dlgNew');

                                    var txtID = $('.ID', newDlg);
                                    $(txtID).val(data.ID);
                                    var txtPID = $('.DMID', newDlg);
                                    $(txtPID).val(data.DM_Ten);
                                    $(txtPID).attr('_value', data.DM_ID);
                                    var txtTen = $('.Ten', newDlg);
                                    $(txtTen).val(data.Ten);
                                    var txtMoTa = $('.MoTa', newDlg);
                                    $(txtMoTa).val(data.MoTa);

                                    var txtNoiDung = $('.NoiDung', newDlg);

                                    $(txtNoiDung).val(data.NoiDung);

                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    $(lblAnh).attr('ref', data.Anh);
                                    if (data.Anh != '') {
                                        $(lblAnhPrvImg).attr('src', '../up/i/' + data.Anh + '?ref=' + Math.random());
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
                                    thongketin.addpopfn();
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
        s = jQuery("#thongketinmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#thongketinmdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: thongketin.urlDefault + '&subAct=del',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#thongketinmdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    duyet: function (st) {
        var s = '';
        s = jQuery("#thongketinmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#thongketinmdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: thongketin.urlDefault + '&subAct=duyet&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#thongketinmdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    tinhot: function (st) {
        var s = '';
        s = jQuery("#thongketinmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#thongketinmdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: thongketin.urlDefault + '&subAct=hot&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#thongketinmdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    hethan: function (st) {
        var s = '';
        s = jQuery("#thongketinmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#thongketinmdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: thongketin.urlDefault + '&subAct=hethan&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#thongketinmdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },

    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-thongketin');
        var searchTxt = $('.mdl-head-filterthanhvien');
        var q = filterDM.val();
        if (q == 'Tìm kiếm tin tức') {
            q = '';
        }
        var txtTuNgay = $('.mdl-head-tungay');
        var txtDenNgay = $('.mdl-head-denngay');
        var tungay = txtTuNgay.val();
        var denngay = txtDenNgay.val();
        var dm = $(searchTxt).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#thongketinmdl-List').jqGrid('setGridParam', { url: thongketin.urlDefault + "&subAct=get&q=" + q + "&Username=" + dm + "&TuNgay=" + tungay + "&DenNgay=" + denngay }).trigger("reloadGrid");
        }, 500);
    },
    save: function (validate, fn) {
        var newDlg = $('#thongketinmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();

        var txtPID = $('.DMID', newDlg);
        var pid = $(txtPID).attr('_value');
        var pten = $(txtPID).val();

        var txtTen = $('.Ten', newDlg);
        var ten = $(txtTen).val();

        var txtMa = $('.Ma', newDlg);
        var ma = $(txtMa).val();

        var txtThuTu = $('.ThuTu', newDlg);
        var ThuTu = $(txtThuTu).val();

        var txtMoTa = $('.MoTa', newDlg);
        var MoTa = $(txtMoTa).val();

        var txtNoiDung = $('.NoiDung', newDlg);
        var NoiDung = $(txtNoiDung).val();

        var txtNgayHetHan = $('.NgayHetHan', newDlg);
        var NgayHetHan = $(txtNgayHetHan).val();

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
        if (pid == '') {
            err += 'Nhập mục tin<br/>';
        }

        if (ten == '') {
            err += 'Nhập tên<br/>';
        }

        if (MoTa == '') {
            err += 'Nhập mô tả<br/>';
        }

        if (NoiDung == '') {
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
            url: thongketin.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': id,
                'DMID': pid,
                'DMTen': pten,
                'ThuTu': ThuTu,
                'Ten': ten,
                'Mota': MoTa,
                'NoiDung': NoiDung,
                'Public': Publish,
                'Hot': Hot,
                'Anh': anh,
                'HetHan': HetHan,
                'NgayHetHan': NgayHetHan
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#thongketinmdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    clearform: function () {
        var newDlg = $('#thongketinmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        $(txtID).val('');
        var txtPID = $('.DMID', newDlg);
        $(txtPID).val('');
        $(txtPID).attr('_value', '');
        var txtTen = $('.Ten', newDlg);
        $(txtTen).val('');
        var txtNguoiTao = $('.NguoiTao', newDlg);
        $(txtNguoiTao).val('');
        var txtSTT = $('.ThuTu', newDlg);
        $(txtSTT).val('');
        var txtMoTa = $('.MoTa', newDlg);
        $(txtMoTa).val('');
        var txtNoiDung = $('.NoiDung', newDlg);
        $(txtNoiDung).val('');
        var ckbHot = $('.Hot', newDlg);
        $(ckbHot).removeAttr('checked');
        var ckbPublish = $('.Publish', newDlg);
        $(ckbPublish).removeAttr('checked');
        var ckbHetHan = $('.HetHan', newDlg);
        $(ckbHetHan).removeAttr('checked');
        var lblAnh = $('.Anh', newDlg);
        $(lblAnh).attr('ref', '');
        $(lblAnh).prev().find('img').attr('src', '');
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        $(spbMsg).html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#thongketinmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("agrobiotech.plugin.backend.thongketin.htm.htm")%>',
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

        var newDlg = $('#thongketinmdl-dlgNew');
        var txtNoiDung = $('.NoiDung', newDlg);
        var txtID = $('.ID', newDlg);
        var txttextarea = $('.adm-textarea-bh', newDlg);
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
            danhmuc.autoCompleteByLoai('TIN', txtDMID, function (event, ui) {
                $(txtDMID).attr('_value', ui.item.id);
            });
        });

        $('.NgayHetHan', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });

        adm.createTinyMce($(txttextarea));
        setTimeout(function () {
            $(txtNoiDung).next().find('iframe').css({ 'height': '200px' });
        }, 10000);

    },
    createReport: function (v) {
        var request = $('#thongketinmdl-List').jqGrid('getGridParam', 'url');
        request = request.replace('loadPlug', 'loadPlugDirect');
        request = request.replace('get', 'reports');
        adm.loadIfr(request + '&Loai=' + v + '&rows=' + $('#thongketinmdl-List').jqGrid('getGridParam', 'rowNum')
        , function () {
            adm.loading('Đang tạo báo cáo');
        }
        , function () {
            adm.loading(null);
        });
    }
}
