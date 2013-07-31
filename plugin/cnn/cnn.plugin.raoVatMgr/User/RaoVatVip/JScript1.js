UserRaoVatVipFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.raoVatMgr.User.RaoVatVip.Class1, cnn.plugin.raoVatMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $('#UserRaoVatVipFnMdl-List').jqGrid({
                    url: UserRaoVatVipFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'STT','Mã tin', 'Ảnh', 'Tiêu đề', 'Mục', 'Loại tin', 'Ngày đăng', 'ĐK Super', 'ĐK Vip', 'ĐK hot'],
                    colModel: [
                        { name: 'RV_ID', key: true, sortable: true, hidden: true },
                        { name: 'STT', align: "center", width: 10 },
                        { name: 'MaTin', align: "center", width: 20 },
                        { name: 'RV_Anh', width: 40, sortable: true, align: "center" },
                        { name: 'RV_Ten', width: 50, resizable: true, sortable: true },
                        { name: 'RV_DM_ID', width: 40, sortable: true },
                        { name: 'RV_NC_ID', width: 20, sortable: true, align: "center" },
                        { name: 'RV_NgayDang', width: 30, resizable: true, sortable: true, align: "center" },
                        { name: 'RV_VIP_SUPER_NgayHetHan', width: 80, resizable: true, sortable: true, align: "center" },
                        { name: 'RV_VIP_VIP_NgayHetHan', width: 80, resizable: true, sortable: true, align: "center" },
                        { name: 'RV_VIP_NoiBat_NgayHetHan', width: 80, resizable: true, sortable: true, align: "center" },
                    ],
                    caption: 'Danh sách dịch vụ chờ duyệt',
                    autowidth: true,
                    height: 350,
                    sortname: 'RV_NgayDang',
                    sortorder: 'DESC',
                    rowNum: 20,
                    rowList: [20, 50, 100, 200, 300],
                    multiselect: true,
                    multiboxonly: true,
                    pager: $('#UserRaoVatVipFnMdl-Pager'),
                    onSelectRow: function (rowid) {
                    },
                    loadComplete: function () {
                        adm.loading(null);
                        var txtfilter = $('.mdl-head-filterDanhMucUserRaoVatVip', '#UserRaoVatVipFnMdl-head');
                        var txtfilterTINH = $('.mdl-head-filterKhuVucUserRaoVatVip', '#UserRaoVatVipFnMdl-head');
                        var txtfilterLoaiTin = $('.mdl-head-filterLoaiTinUserRaoVatVip', '#UserRaoVatVipFnMdl-head');

                        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                            danhmuc.autoCompleteLangBased("", "RAOVAT", txtfilter, function (event, ui) {
                                $(txtfilter).attr('_value', ui.item.id);
                                UserRaoVatVipFn.search();
                            });
                            $(txtfilter).unbind('click').click(function () {
                                $(txtfilter).autocomplete('search', '');
                            });

                            danhmuc.autoCompleteLangBased("", "KV-TINH", txtfilterTINH, function (event, ui) {
                                $(txtfilterTINH).attr('_value', ui.item.id);
                                UserRaoVatVipFn.search();
                            });
                            $(txtfilterTINH).unbind('click').click(function () {
                                $(txtfilterTINH).autocomplete('search', '');
                            });

                            danhmuc.autoCompleteLangBased("", "TIN-NHOM", txtfilterLoaiTin, function (event, ui) {
                                $(txtfilterLoaiTin).attr('_value', ui.item.id);
                                UserRaoVatVipFn.search();
                            });
                            $(txtfilterLoaiTin).unbind('click').click(function () {
                                $(txtfilterLoaiTin).autocomplete('search', '');
                            });

                        });
                    }
                });
                var filterLoaiDanhMucID = $('.mdl-head-filterDanhMucUserRaoVatVip', '#UserRaoVatVipFnMdl-head');
                var filterTINHID = $('.mdl-head-filterKhuVucUserRaoVatVip', '#UserRaoVatVipFnMdl-head');
                var filterLoaiTin = $('.mdl-head-filterLoaiTinUserRaoVatVip', '#UserRaoVatVipFnMdl-head');
                var searchTxt = $('.mdl-head-search-UserRaoVatVip', '#UserRaoVatVipFnMdl-head');

                $(filterLoaiDanhMucID).keyup(function () {
                    if ($(filterLoaiDanhMucID).val() == '') {
                        $(filterLoaiDanhMucID).attr('_value', '');
                        if ($(searchTxt).val() == 'Tìm kiếm tin') {
                            $(searchTxt).val('');
                        }
                        UserRaoVatVipFn.search();
                        if ($(searchTxt).val() == '') {
                            $(searchTxt).val('Tìm kiếm tin');
                        }
                    }
                });
                $(filterTINHID).keyup(function () {
                    if ($(filterTINHID).val() == '') {
                        $(filterTINHID).attr('_value', '');
                        if ($(searchTxt).val() == 'Tìm kiếm tin') {
                            $(searchTxt).val('');
                        }
                        UserRaoVatVipFn.search();
                        if ($(searchTxt).val() == '') {
                            $(searchTxt).val('Tìm kiếm tin');
                        }
                    }
                });
                $(filterLoaiTin).keyup(function () {
                    if ($(filterLoaiTin).val() == '') {
                        $(filterLoaiTin).attr('_value', '');
                        if ($(searchTxt).val() == 'Tìm kiếm tin') {
                            $(searchTxt).val('');
                        }
                        UserRaoVatVipFn.search();
                        if ($(searchTxt).val() == '') {
                            $(searchTxt).val('Tìm kiếm tin');
                        }
                    }
                });
                $(searchTxt).keyup(function () {
                    UserRaoVatVipFn.search();
                });
                adm.watermark(searchTxt, 'Tìm kiếm tin', function () {
                    $(searchTxt).val('');
                    UserRaoVatVipFn.search();
                    $(searchTxt).val('Tìm kiếm tin');
                });
                adm.watermark(filterLoaiDanhMucID, 'Gõ tên mục tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    UserRaoVatVipFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                adm.watermark(filterTINHID, 'Gõ tên Khu vực để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    UserRaoVatVipFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                adm.watermark(filterLoaiTin, 'Gõ tên loại tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    UserRaoVatVipFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                //                var muaban = $('#UserRaoVatVipFnMdl-muaban');
                //                $(muaban).find('option').remove();
                //                $(muaban).prepend('<option value="True"> Chào mua</option>');
                //                $(muaban).prepend('<option value="False">Chào bán</option>');
                //                $(muaban).prepend('<option value="">--Chọn loại tin--</option>');
                //                $(muaban).val('--Chọn loại tin--');

                //                var TrangThai = $('#UserRaoVatVipFnMdl-TrangThai');
                //                $(TrangThai).find('option').remove();
                //                $(TrangThai).prepend('<option value="2">Đã duyệt</option>');
                //                $(TrangThai).prepend('<option value="3">Chưa Duyệt</option>');
                //                $(TrangThai).prepend('<option value="1">Quá hạn</option>');
                //                $(TrangThai).prepend('<option value="">--Trạng thái--</option>');
                //                $(TrangThai).val('--Trạng thái--');


                var changeLangBtn = $('#UserRaoVatVipFnMdl-changeLangSlt');
                $(changeLangBtn).find('option').remove();
                $.each(LangArr, function (i, item) {
                    if (item.Active) {
                        Lang = item.Ma;
                    }
                    $(changeLangBtn).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                });
                $(changeLangBtn).val('Tiếng Việt');
                if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }
            });
        });
    },
    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-UserRaoVatVip');
        var searchDM = $('.mdl-head-filterDanhMucUserRaoVatVip');
        var searchTINH = $('.mdl-head-filterKhuVucUserRaoVatVip');
        var searchLoaiTin = $('.mdl-head-filterLoaiTinUserRaoVatVip', '#UserRaoVatVipFnMdl-head');
        var _Lang = $('#UserRaoVatVipFnMdl-changeLangSlt').val();
        var filtermuaban = $('#UserRaoVatVipFnMdl-muaban');
        var filterTrangThai = $('#UserRaoVatVipFnMdl-TrangThai');
        var q = filterDM.val();
        if (q == 'Tìm kiếm tin') {
            q = '';
        }
        var dm = $(searchDM).attr('_value');
        var tinh = $(searchTINH).attr('_value');
        var loaitin = $(searchLoaiTin).attr('_value');
        var trangthai = $(filterTrangThai).attr('value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#UserRaoVatVipFnMdl-List').jqGrid('setGridParam', { url: UserRaoVatVipFn.urlDefault().toString() + '&subAct=get&dm=' + dm + '&dmkv=' + tinh + '&Lang=' + _Lang + '&q=' + q + '&muaban=' + loaitin + '&trangthai=' + trangthai }).trigger('reloadGrid');
        }, 500);
    },
    loadHtml: function (fn) {
        var dlg = $('#UserRaoVatVipFnMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.raoVatMgr.User.RaoVatVip.htm.htm")%>',
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
    add: function () {
        UserRaoVatVipFn.loadHtml(function () {
            var newDlg = $('#UserRaoVatVipFnMdl-dlgNew');
            var LangSlt = $('.Lang', newDlg);
            LangSlt.removeAttr('disabled');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 700,
                height: 500,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        UserRaoVatVipFn.save(false, function () {
                            UserRaoVatVipFn.clearform();
                            jQuery('#UserRaoVatVipFnMdl-List').trigger('reloadGrid');
                        });
                    },
                    'Lưu và đóng': function () {
                        UserRaoVatVipFn.save(false, function () {
                            $(newDlg).dialog('close');
                            jQuery('#UserRaoVatVipFnMdl-List').trigger('reloadGrid');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    UserRaoVatVipFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    UserRaoVatVipFn.clearform();
                    UserRaoVatVipFn.popfn();
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#UserRaoVatVipFnMdl-dlgNew');
        var DM_ID = $('.DM_ID', newDlg);
        var DM_KV = $('.DM_KV', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var NhuCau_ID = $('.NhuCau_ID', newDlg);
        var NgayHetHan = $('.NgayHetHan', newDlg);

        danhmuc.autoCompleteLangBased('', 'RAOVAT', DM_ID, function (event, ui) {
            $(DM_ID).attr('_value', ui.item.id);
        });
        $(DM_ID).unbind('click').click(function () { $(DM_ID).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'KV_TINH', DM_KV, function (event, ui) {
            $(DM_KV).attr('_value', ui.item.id);
        });
        $(DM_KV).unbind('click').click(function () { $(DM_KV).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'TIN-NHOM', NhuCau_ID, function (event, ui) {
            $(NhuCau_ID).attr('_value', ui.item.id);
        });
        $(NhuCau_ID).unbind('click').click(function () { $(NhuCau_ID).autocomplete('search', ''); });

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


        var LangSlt = $('.Lang', newDlg);
        if ($(LangSlt).children().length > 0) { return false; }
        $(LangSlt).find('option').remove();
        $.each(LangArr, function (i, item) {
            if (item.Active) {
                Lang = item.Ma;
            }
            $(LangSlt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
        });
        $(LangSlt).val('');
        $('.NgayHetHan', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    clearform: function () {
        var newDlg = $('#UserRaoVatVipFnMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var LangBased = $('.LangBased', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var DM_KV = $('.DM_KV', newDlg);
        var NhuCau_ID = $('.NhuCau_ID', newDlg);
        var LangSlt = $('.Lang', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var Ten = $('.Ten', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Gia = $('.Gia', newDlg);
        var NgayHetHan = $('.NgayHetHan', newDlg);
        var Publish = $('.Publish', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var Mota = $('.Mota', newDlg);
        Mota.val('');
        ID.val('');
        LangBased.removeAttr('checked');
        LangBased_ID.val('');
        DM_ID.val('');
        DM_KV.val('');
        NhuCau_ID.val('');
        LangSlt.val('');
        imgAnh.attr('src', '');
        lblAnh.attr('ref', '');
        Ten.val('');
        Gia.val('');
        NoiDung.val('');
        NgayHetHan.val('');
        Publish.removeAttr('checked');
        spbMsg.html('');
    },
    save: function (validate, fn) {
        var newDlg = $('#UserRaoVatVipFnMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var _ID = ID.val();

        var LangBased = $('.LangBased', newDlg);
        var _LangBased = LangBased.is(':checked');

        var LangBased_ID = $('.LangBased_ID', newDlg);
        var _LangBased_ID = LangBased_ID.val();

        var DM_ID = $('.DM_ID', newDlg);
        var _DM_ID = DM_ID.attr('_value');

        var DM_KV = $('.DM_KV', newDlg);
        var _DM_KV = DM_KV.attr('_value');

        var NhuCau_ID = $('.NhuCau_ID', newDlg);
        var _NhuCau_ID = NhuCau_ID.attr('_value');

        var LangSlt = $('.Lang', newDlg);
        var _Lang = LangSlt.val();

        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var _Anh = lblAnh.attr('ref');

        var Ten = $('.Ten', newDlg);
        var _Ten = Ten.val();

        var Gia = $('.Gia', newDlg);
        var _Gia = Gia.val();
        var Mota = $('.Mota', newDlg);
        var _Mota = Mota.val();
        var NoiDung = $('.NoiDung', newDlg);
        var _NoiDung = NoiDung.val();

        var NgayHetHan = $('.NgayHetHan', newDlg);
        var _NgayHetHan = NgayHetHan.val();

        var Publish = $('.Publish', newDlg);
        var _Publish = Publish.is(':checked');
        var spbMsg = $('.admMsg', newDlg);

        var err = '';
        if (_DM_ID == '') { err += 'Chọn danh mục<br/>'; };
        if (_DM_KV == '') { err += 'Chọn Khu vực<br/>'; };
        if (_Ten == '') { err += 'Nhập tên<br/>'; };
        if (_NgayHetHan == '') { err += 'Nhập Ngày hết hạn<br/>'; };
        if (!_LangBased) { if (_Lang == Lang) { err += 'Chọn ngôn ngữ khác'; }; }
        else { if (_Lang != Lang) { err += 'Bạn cần chọn ngôn ngữ gốc ' + Lang; }; }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: UserRaoVatVipFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                'ID': _ID,
                'LangBased': _LangBased,
                'LangBased_ID': _LangBased_ID,
                'dm': _DM_ID,
                'dmkv': _DM_KV,
                'muaban': _NhuCau_ID,
                'Anh': _Anh,
                'Ten': _Ten,
                'Lang': _Lang,
                'NoiDung': _NoiDung,
                'Gia': _Gia,
                'NgayHetHan': _NgayHetHan,
                'Publish': _Publish,
                'Mota': _Mota
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    edit: function () {
        var s = '';
        if (jQuery('#UserRaoVatVipFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#UserRaoVatVipFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                UserRaoVatVipFn.loadHtml(function () {
                    var newDlg = $('#UserRaoVatVipFnMdl-dlgNew');
                    var LangSlt = $('.Lang', newDlg);
                    LangSlt.removeAttr('disabled');
                    UserRaoVatVipFn.popfn();
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 700,
                        height: 500,
                        buttons: {
                            'Lưu': function () {
                                UserRaoVatVipFn.save(false, function () {
                                    UserRaoVatVipFn.clearform();
                                    jQuery('#UserRaoVatVipFnMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Lưu và đóng': function () {
                                UserRaoVatVipFn.save(false, function () {
                                    UserRaoVatVipFn.clearform();
                                    $(newDlg).dialog('close');
                                    jQuery('#UserRaoVatVipFnMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            UserRaoVatVipFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            $.ajax({
                                url: UserRaoVatVipFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var LangBased = $('.LangBased', newDlg);
                                    var LangBased_ID = $('.LangBased_ID', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var DM_KV = $('.DM_KV', newDlg);
                                    var NhuCau_ID = $('.NhuCau_ID', newDlg);
                                    var LangSlt = $('.Lang', newDlg);
                                    var Mota = $('.Mota', newDlg);
                                    var imgAnh = $('.adm-upload-preview-img', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var NgayHetHan = $('.NgayHetHan', newDlg);
                                    var Gia = $('.Gia', newDlg);
                                    var Publish = $('.Publish', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    DM_ID.val(dt._DM_Ten);
                                    DM_ID.attr('_value', dt.DM_ID);
                                    DM_KV.val(dt._Tinh_Ten)
                                    DM_KV.attr('_value', dt.TINH_ID);
                                    NhuCau_ID.attr('_value', dt.NC_ID);
                                    NhuCau_ID.val(dt._Nhucau_Ten);
                                    LangSlt.val(dt.Lang);
                                    if (dt.LangBased) {
                                        $(LangBased).attr('checked', 'checked');
                                    }
                                    else {
                                        $(LangBased).removeAttr('checked');
                                    }
                                    LangBased_ID.val(dt.LangBased_ID);
                                    Ten.val(dt.Ten);
                                    NoiDung.val(dt.NoiDung);
                                    Mota.val(dt.MoTa);
                                    Gia.val(dt.Gia);
                                    $(lblAnh).attr('ref', dt.Anh1);
                                    if (dt.Anh != '') {
                                        $(imgAnh).attr('src', '../up/i/' + dt.Anh1 + '?ref=' + Math.random());
                                    }

                                    var __NgayHetHan = new Date(dt.NgayHetHan);
                                    var _NgayHetHan = __NgayHetHan.getDate() + '/' + (__NgayHetHan.getMonth() + 1) + '/' + __NgayHetHan.getFullYear();
                                    NgayHetHan.val(_NgayHetHan);
                                    if (dt.Publish) { Publish.attr('checked', 'checked'); } else { Publish.removeAttr('checked'); }
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
        s = jQuery('#UserRaoVatVipFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa?')) {
                $.ajax({
                    url: UserRaoVatVipFn.urlDefault().toString() + '&subAct=del',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery('#UserRaoVatVipFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    },
    PheDuyet: function (active) {
        var s = '';
        s = jQuery('#UserRaoVatVipFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để duyệt');
        }
        else {
            if (confirm('Bạn có chắc chắn duyệt các mẩu tin này?')) {
                $.ajax({
                    url: UserRaoVatVipFn.urlDefault().toString() + '&subAct=PheDuyet' + '&active=' + active,
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery('#UserRaoVatVipFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    },
    popfndkdv: function () {
        var newDlgDKDV = $('#UserRaoVatVipFnMdl-DKDVFnMdl-dlgNew');
        var NgayHetHanSuper = $('.NgayHetHanSuper', newDlgDKDV);
        var NgayHetHanVip = $('.NgayHetHanVip', newDlgDKDV);
        var NgayHetHanHot = $('.NgayHetHanHot', newDlgDKDV);
        $('.NgayHetHanSuper', newDlgDKDV).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanVip', newDlgDKDV).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanHot', newDlgDKDV).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    clearformdkdv: function () {
        var newDlgDKDV = $('#UserRaoVatVipFnMdl-DKDVFnMdl-dlgNew');
        var NgayHetHanSuper = $('.NgayHetHanSuper', newDlgDKDV);
        var NgayHetHanVip = $('.NgayHetHanVip', newDlgDKDV);
        var NgayHetHanHot = $('.NgayHetHanHot', newDlgDKDV);
        var spbMsg = $('.admMsg', newDlgDKDV);
        var ID = $('.ID', newDlgDKDV);
        NgayHetHanSuper.val('');
        NgayHetHanVip.val('');
        NgayHetHanHot.val('');
        ID.val('');
        spbMsg.html('');
    },
    loadHtmlDKDV: function (fn) {
        var dlg = $('#UserRaoVatVipFnMdl-DKDVFnMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.raoVatMgr.User.RaoVatVip.Dkdv.htm")%>',
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
    DKDV: function () {
        var s = '';
        s = jQuery('#UserRaoVatVipFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn các mẩu tin để đăng ký dịch vụ');
        }
        else {
            UserRaoVatVipFn.loadHtmlDKDV(function () {
                UserRaoVatVipFn.popfndkdv();
                var newDlgDKDV = $('#UserRaoVatVipFnMdl-DKDVFnMdl-dlgNew');
                $(newDlgDKDV).dialog({
                    title: 'Sửa',
                    width: 580,
                    height: 265,
                    buttons: {
                        'Đăng ký dịch vụ và đóng': function () {
                            UserRaoVatVipFn.saveDKDV(false, function () {
                                UserRaoVatVipFn.clearformdkdv();
                                $(newDlgDKDV).dialog('close');
                            });
                        },
                        'Đóng': function () {
                            $(newDlgDKDV).dialog('close');
                        }
                    },
                    beforeClose: function () {
                        UserRaoVatVipFn.clearformdkdv();
                    },
                    open: function () {
                        var ID = $('.ID', newDlgDKDV);
                        ID.val(s);
                        adm.styleButton();
                    }
                });
            });
        }
    },
    saveDKDV: function (validate, fn) {
        //UserRaoVatVipFn.popfndkdv();
        var newDlg = $('#UserRaoVatVipFnMdl-DKDVFnMdl-dlgNew');
        var dkhot = 'False';
        var dkvip = 'False';
        var dksuper = 'False';
        var NgayHetHanSuper = $('.NgayHetHanSuper', newDlg);
        var NgayHetHanVip = $('.NgayHetHanVip', newDlg);
        var NgayHetHanHot = $('.NgayHetHanHot', newDlg);
        var ID = $('.ID', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _NgayHetHanHot = NgayHetHanHot.val();
        var _NgayHetHanSuper = NgayHetHanSuper.val();
        var _NgayHetHanVip = NgayHetHanVip.val();
        var err = '';

        if ((_NgayHetHanHot == '') && (_NgayHetHanSuper == '') && (_NgayHetHanVip == '')) {
            err += 'Bạn phải chọn thời gian đăng ký cần thiết';
        }
        if (_NgayHetHanHot != '') {
            dkhot = 'True';
        }
        if (_NgayHetHanVip != '') {
            dkvip = 'True';
        }
        if (_NgayHetHanSuper != '') {
            dksuper = 'True';
        }

        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: UserRaoVatVipFn.urlDefault().toString() + '&subAct=DKDV',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'DKhot': dkhot,
                'DKSuper': dksuper,
                'DKVip': dkvip,
                'NgayHetHanHot': _NgayHetHanHot,
                'NgayHetHanVip': _NgayHetHanVip,
                'NgayHetHanSuper': _NgayHetHanSuper
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#UserRaoVatVipFnMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    HuyDangKy: function (all,_super,vip,hot) {
        var s = '';
        s = jQuery('#UserRaoVatVipFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để duyệt');
        }
        else {
            if (confirm('Bạn có chắc chắn duyệt các mẩu tin này?')) {
                $.ajax({
                    url: UserRaoVatVipFn.urlDefault().toString() + '&subAct=HuyDichVu' + '&_calcelall=' + all + '&_super=' + _super + "&_vip=" + vip + "&_hot=" + hot,
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery('#UserRaoVatVipFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    }
}
