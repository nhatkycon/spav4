RaoVatAdminMoiFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.raoVatMgr.Admin.Moi.Class1, cnn.plugin.raoVatMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $('#RaoVatAdminMoiFnMdl-List').jqGrid({
                    url: RaoVatAdminMoiFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID','TT','Mã tin' ,'Ảnh', 'Tiêu đề', 'Chi tiết tin rao vặt', 'Sản phẩm', 'Loại tin', 'Ngày đăng','Người rao'],
                    colModel: [
                        { name: 'RV_ID', key: true, sortable: true, hidden: true },
                        { name: 'STT', align: "center", width: 10 },
                        { name: 'MaTin', align: "center", width: 10 },
                        { name: 'RV_Anh', width: 50, sortable: true, align: "center" },
                        { name: 'RV_Ten', width: 80, resizable: true, sortable: true },
                        { name: 'RV_NoiDung', width: 100, resizable: true, sortable: true },
                        { name: 'RV_DM_ID', width: 35, sortable: true },
                        { name: 'RV_NC_ID', width: 20, sortable: true, align: "center" },
                        { name: 'RV_NgayDang', width: 30, resizable: true, sortable: true, align: "center" },
                        { name: 'RV_TenNguoiDang', width: 30, resizable: true, sortable: true, align: "center" }
                        
                    ],
                    caption: 'Danh sách tin Rao vặt',
                    autowidth: true,
                    height: 350,
                    sortname: 'RV_NgayDang',
                    sortorder: 'DESC',
                    rowNum: 20,
                    rowList: [20,50, 100, 200, 300],
                    multiselect: true,
                    multiboxonly: true,
                    pager: $('#RaoVatAdminMoiFnMdl-Pager'),
                    onSelectRow: function (rowid) {
                    },
                    loadComplete: function () {
                        adm.loading(null);
                        var txtfilter = $('.mdl-head-filterDanhMucRaoVatAdminMoi', '#RaoVatAdminMoiFnMdl-head');
                        var txtfilterTINH = $('.mdl-head-filterKhuVucRaoVatAdminMoi', '#RaoVatAdminMoiFnMdl-head');
                        var txtfilterLoaiTin = $('.mdl-head-filterLoaiTinRaoVatAdminMoi', '#RaoVatAdminMoiFnMdl-head');

                        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                            danhmuc.autoCompleteLangBased("", "RAOVAT", txtfilter, function (event, ui) {
                                $(txtfilter).attr('_value', ui.item.id);
                                RaoVatAdminMoiFn.search();
                            });
                            $(txtfilter).unbind('click').click(function () {
                                $(txtfilter).autocomplete('search', '');
                            });

                            danhmuc.autoCompleteLangBased("", "KV_TINH", txtfilterTINH, function (event, ui) {
                                $(txtfilterTINH).attr('_value', ui.item.id);
                                RaoVatAdminMoiFn.search();
                            });
                            $(txtfilterTINH).unbind('click').click(function () {
                                $(txtfilterTINH).autocomplete('search', '');
                            });

                            danhmuc.autoCompleteLangBased("", "TIN-NHOM", txtfilterLoaiTin, function (event, ui) {
                                $(txtfilterLoaiTin).attr('_value', ui.item.id);
                                RaoVatAdminMoiFn.search();
                            });
                            $(txtfilterLoaiTin).unbind('click').click(function () {
                                $(txtfilterLoaiTin).autocomplete('search', '');
                            });

                        });
                    }
                });
                var filterLoaiDanhMucID = $('.mdl-head-filterDanhMucRaoVatAdminMoi', '#RaoVatAdminMoiFnMdl-head');
                var filterTINHID = $('.mdl-head-filterKhuVucRaoVatAdminMoi', '#RaoVatAdminMoiFnMdl-head');
                var filterLoaiTin = $('.mdl-head-filterLoaiTinRaoVatAdminMoi', '#RaoVatAdminMoiFnMdl-head');
                var searchTxt = $('.mdl-head-search-RaoVatAdminMoi', '#RaoVatAdminMoiFnMdl-head');

                $(filterLoaiDanhMucID).keyup(function () {
                    if ($(filterLoaiDanhMucID).val() == '') {
                        $(filterLoaiDanhMucID).attr('_value', '');
                        if ($(searchTxt).val() == 'Tìm kiếm tin') {
                            $(searchTxt).val('');
                        }
                        RaoVatAdminMoiFn.search();
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
                        RaoVatAdminMoiFn.search();
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
                        RaoVatAdminMoiFn.search();
                        if ($(searchTxt).val() == '') {
                            $(searchTxt).val('Tìm kiếm tin');
                        }
                    }
                });
                $(searchTxt).keyup(function () {
                    RaoVatAdminMoiFn.search();
                });
                adm.watermark(searchTxt, 'Tìm kiếm tin', function () {
                    $(searchTxt).val('');
                    RaoVatAdminMoiFn.search();
                    $(searchTxt).val('Tìm kiếm tin');
                });
                adm.watermark(filterLoaiDanhMucID, 'Gõ tên mục tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    RaoVatAdminMoiFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                adm.watermark(filterTINHID, 'Gõ tên Khu vực để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    RaoVatAdminMoiFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                adm.watermark(filterLoaiTin, 'Gõ tên loại tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    RaoVatAdminMoiFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                //                var muaban = $('#RaoVatAdminMoiFnMdl-muaban');
                //                $(muaban).find('option').remove();
                //                $(muaban).prepend('<option value="True"> Chào mua</option>');
                //                $(muaban).prepend('<option value="False">Chào bán</option>');
                //                $(muaban).prepend('<option value="">--Chọn loại tin--</option>');
                //                $(muaban).val('--Chọn loại tin--');

                //                var TrangThai = $('#RaoVatAdminMoiFnMdl-TrangThai');
                //                $(TrangThai).find('option').remove();
                //                $(TrangThai).prepend('<option value="2">Đã duyệt</option>');
                //                $(TrangThai).prepend('<option value="3">Chưa Duyệt</option>');
                //                $(TrangThai).prepend('<option value="1">Quá hạn</option>');
                //                $(TrangThai).prepend('<option value="">--Trạng thái--</option>');
                //                $(TrangThai).val('--Trạng thái--');


                var changeLangBtn = $('#RaoVatAdminMoiFnMdl-changeLangSlt');
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
        var filterDM = $('.mdl-head-search-RaoVatAdminMoi');
        var searchDM = $('.mdl-head-filterDanhMucRaoVatAdminMoi');
        var searchTINH = $('.mdl-head-filterKhuVucRaoVatAdminMoi');
        var searchLoaiTin = $('.mdl-head-filterLoaiTinRaoVatAdminMoi', '#RaoVatAdminMoiFnMdl-head');
        var _Lang = $('#RaoVatAdminMoiFnMdl-changeLangSlt').val();
        var filtermuaban = $('#RaoVatAdminMoiFnMdl-muaban');
        var filterTrangThai = $('#RaoVatAdminMoiFnMdl-TrangThai');
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
            $('#RaoVatAdminMoiFnMdl-List').jqGrid('setGridParam', { url: RaoVatAdminMoiFn.urlDefault().toString() + '&subAct=get&dm=' + dm + '&dmkv=' + tinh + '&Lang=' + _Lang + '&q=' + q + '&muaban=' + loaitin + '&trangthai=' + trangthai }).trigger('reloadGrid');
        }, 500);
    },
    loadHtml: function (fn) {
        var dlg = $('#RaoVatAdminMoiFnMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.raoVatMgr.Admin.Moi.htm.htm")%>',
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
        RaoVatAdminMoiFn.loadHtml(function () {
            var newDlg = $('#RaoVatAdminMoiFnMdl-dlgNew');
            var LangSlt = $('.Lang', newDlg);
            LangSlt.removeAttr('disabled');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 700,
                height: 380,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        RaoVatAdminMoiFn.save(false, function () {
                            RaoVatAdminMoiFn.clearform();
                            jQuery('#RaoVatAdminMoiFnMdl-List').trigger('reloadGrid');
                        });
                    },
                    'Lưu và đóng': function () {
                        RaoVatAdminMoiFn.save(false, function () {
                            $(newDlg).dialog('close');
                            jQuery('#RaoVatAdminMoiFnMdl-List').trigger('reloadGrid');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    RaoVatAdminMoiFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    RaoVatAdminMoiFn.clearform();
                    RaoVatAdminMoiFn.popfn();
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#RaoVatAdminMoiFnMdl-dlgNew');
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
        var newDlg = $('#RaoVatAdminMoiFnMdl-dlgNew');
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
        ID.val('');
        Mota.val('');
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
        var newDlg = $('#RaoVatAdminMoiFnMdl-dlgNew');
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
        var Mota = $('.Mota', newDlg);
        var _Mota = Mota.val();
        var LangSlt = $('.Lang', newDlg);
        var _Lang = LangSlt.val();

        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var _Anh = lblAnh.attr('ref');

        var Ten = $('.Ten', newDlg);
        var _Ten = Ten.val();

        var Gia = $('.Gia', newDlg);
        var _Gia = Gia.val();

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
            url: RaoVatAdminMoiFn.urlDefault().toString(),
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
                'Mota':_Mota
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
        if (jQuery('#RaoVatAdminMoiFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#RaoVatAdminMoiFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                RaoVatAdminMoiFn.loadHtml(function () {
                    var newDlg = $('#RaoVatAdminMoiFnMdl-dlgNew');
                    var LangSlt = $('.Lang', newDlg);
                    LangSlt.removeAttr('disabled');
                    RaoVatAdminMoiFn.popfn();
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 700,
                        height: 380,
                        buttons: {
                            'Lưu': function () {
                                RaoVatAdminMoiFn.save(false, function () {
                                    RaoVatAdminMoiFn.clearform();
                                    jQuery('#RaoVatAdminMoiFnMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Lưu và đóng': function () {
                                RaoVatAdminMoiFn.save(false, function () {
                                    RaoVatAdminMoiFn.clearform();
                                    $(newDlg).dialog('close');
                                    jQuery('#RaoVatAdminMoiFnMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            RaoVatAdminMoiFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            $.ajax({
                                url: RaoVatAdminMoiFn.urlDefault().toString() + '&subAct=edit',
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
        s = jQuery('#RaoVatAdminMoiFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa?')) {
                $.ajax({
                    url: RaoVatAdminMoiFn.urlDefault().toString() + '&subAct=del',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery('#RaoVatAdminMoiFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    },
    PheDuyet: function (active) {
        var s = '';
        s = jQuery('#RaoVatAdminMoiFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để duyệt');
        }
        else {
            if (confirm('Bạn có chắc chắn duyệt các mẩu tin này?')) {
                $.ajax({
                    url: RaoVatAdminMoiFn.urlDefault().toString() + '&subAct=PheDuyet' + '&active=' + active,
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery('#RaoVatAdminMoiFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    },
    DangTinDungTin: function (Publish) {
        var s = '';
        s = jQuery('#RaoVatAdminMoiFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để duyệt');
        }
        else {
            if (confirm('Bạn có chắc muốn đăng các mẩu tin này?')) {
                $.ajax({
                    url: RaoVatAdminMoiFn.urlDefault().toString() + '&subAct=DangTinDungTin' + '&Publish='+ Publish,
                    dataType: 'script',
                    data: {
                        'ID': s,
                    },
                    success: function (dt) {
                        jQuery('#RaoVatAdminMoiFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    },
    popfndkdv: function () {
        var newDlgDKDV = $('#RaoVatAdminMoiFnMdl-DKDVFnMdl-dlgNew');
        var NgayHetHanSuper = $('.NgayHetHanSuper', newDlgDKDV);
        var NgayHetHanHot = $('.NgayHetHanHot', newDlgDKDV);
        var NgayHetHanVip = $('.NgayHetHanVip', newDlgDKDV);

        var NgayBatDauHot = $('.NgayBatDauHot', newDlgDKDV);
        var NgayBatDauSuper = $('.NgayBatDauSuper', newDlgDKDV);
        var NgayBatDauVip = $('.NgayBatDauVip', newDlgDKDV);

        $('.NgayHetHanSuper', newDlgDKDV).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayBatDauSuper', newDlgDKDV).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayBatDauVip', newDlgDKDV).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanVip', newDlgDKDV).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanHot', newDlgDKDV).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayBatDauHot', newDlgDKDV).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    clearformdkdv: function () {
        var newDlgDKDV = $('#RaoVatAdminMoiFnMdl-DKDVFnMdl-dlgNew');
        
        var ID = $('.ID', newDlgDKDV);
        var spbMsg = $('.admMsg', newDlgDKDV);
        var imgmuaban = $('.img-muaban',newDlgDKDV);
        var imgAnh = $('.adm-upload-preview-img-60', newDlgDKDV);
        var TieuDe = $('.TieuDe',newDlgDKDV);
        var MaTinRV = $('.MaTinRV',newDlgDKDV);
        var DanhMuc = $('.DanhMuc',newDlgDKDV);
        var NgayDang = $('.NgayDang',newDlgDKDV);

        var NgayHetHanSuper = $('.NgayHetHanSuper', newDlgDKDV);
        var HotroSuper = $('.Super-DanhMuc',newDlgDKDV);
        var NgayBatDauSuper = $('.NgayBatDauSuper', newDlgDKDV);
        var GiaSuper = $('.GiaSuper-DanhMuc',newDlgDKDV);
        var TongTienSuper = $('.TongTien-Super',newDlgDKDV);

        var NgayBatDauHot = $('.NgayBatDauHot', newDlgDKDV);
        var NgayHetHanHot = $('.NgayHetHanHot', newDlgDKDV);
        var HotroHot = $('.Hot-DanhMuc',newDlgDKDV);
        var GiaHot = $('.GiaHot-DanhMuc',newDlgDKDV);
        var TongTienHot = $('.TongTien-Hot',newDlgDKDV);

        var HotroVip = $('.Vip-DanhMuc',newDlgDKDV);
        var NgayHetHanVip = $('.NgayHetHanVip', newDlgDKDV);
        var NgayBatDauVip = $('.NgayBatDauVip', newDlgDKDV);
        var GiaVip = $('.GiaVip-DanhMuc',newDlgDKDV);
        var TongTienVip = $('.TongTien-Vip',newDlgDKDV);

        var ChuyenKhoanDM = $('.ChuyenKhoan-DanhMuc',newDlgDKDV);
        var GioiThieuDanhMuc = $('.GioiThieu-DanhMuc',newDlgDKDV);
        var ThanhToanDanhMuc = $('.ThanhToan-DanhMuc',newDlgDKDV);
        var LienHeDanhMuc= $('.LienHe-DanhMuc',newDlgDKDV);
        var GhiChuDKDVTT = $('.GhiChuDKDVTT',newDlgDKDV);
        
        GioiThieuDanhMuc.html('');
        ThanhToanDanhMuc.html('');
        LienHeDanhMuc.html('');
        GiaVip.html('');
        ChuyenKhoanDM.html('');
        TongTienVip.html('');
        TongTienHot.html('');
        GiaHot.html('');
        TongTienSuper.html('');
        GiaSuper.html('');


        TieuDe.html('');
        DanhMuc.html('');
        NgayDang.html('');
        HotroSuper.html('');
        HotroVip.html('');
        HotroHot.html('');
        MaTinRV.html('');
//        GhiChuDKDVTT.html('');
        imgmuaban.html('');
        NgayBatDauHot.val('');
        NgayBatDauSuper.val('');
        NgayBatDauVip.val();
        NgayHetHanSuper.val('');
        NgayHetHanVip.val('');
        NgayHetHanHot.val('');
        imgAnh.attr('src', '');
        ID.val('');
        spbMsg.html('');
    },
    loadHtmlDKDV: function (fn,nvar) {
        var dlg = $('#RaoVatAdminMoiFnMdl-DKDVFnMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.raoVatMgr.Admin.Moi.Dkdv.htm")%>',
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
        if (jQuery('#RaoVatAdminMoiFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#RaoVatAdminMoiFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                RaoVatAdminMoiFn.loadHtmlDKDV(function () {
                    RaoVatAdminMoiFn.popfndkdv();
                    var newDlgDKDV = $('#RaoVatAdminMoiFnMdl-DKDVFnMdl-dlgNew');

                    $(newDlgDKDV).dialog({
                    title: 'Đăng ký dịch vụ Tin rao vặt',
                    width: 820,
                    height: 610,
                    buttons: {
                        'Đăng ký dịch vụ và đóng': function () {
                            RaoVatAdminMoiFn.saveDKDV(false, function () {
                                RaoVatAdminMoiFn.clearformdkdv();
                                $(newDlgDKDV).dialog('close');
                            });
                        },
                        'Đóng': function () {
                            $(newDlgDKDV).dialog('close');
                        }
                    },
                    beforeClose: function () {
                        RaoVatAdminMoiFn.clearformdkdv();
                    },
                        open: function () {
                            var inputDKDVSuper = $('.input-DKDV-Super',newDlgDKDV);
                            var inputDKDVVip = $('.input-DKDV-Vip',newDlgDKDV);
                            var inputDKDVHot = $('.input-DKDV-Hot',newDlgDKDV);
                            inputDKDVSuper.hide();
                            inputDKDVVip.hide();
                            inputDKDVHot.hide();
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            //console.log('1');
                            $.ajax({
                                url: RaoVatAdminMoiFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlgDKDV);
                                    var imgAnh = $('.adm-upload-preview-img-60', newDlgDKDV);
                                    var TieuDe = $('.TieuDe',newDlgDKDV);
                                    var imgmuaban = $('.img-muaban',newDlgDKDV);
                                    var DanhMuc = $('.DanhMuc',newDlgDKDV);
                                    var NgayDang = $('.NgayDang',newDlgDKDV);
                                    var MaTinRV = $('.MaTinRV',newDlgDKDV);
                                    var ckbSuper = $('.ckbSuper',newDlgDKDV);
                                    var ckbVip = $('.ckbVip',newDlgDKDV);
                                    var ckbHot = $('.ckbHot',newDlgDKDV);
                                    var inputDKDVSuper = $('.input-DKDV-Super',newDlgDKDV);
                                    var inputDKDVVip = $('.input-DKDV-Vip',newDlgDKDV);
                                    var inputDKDVHot = $('.input-DKDV-Hot',newDlgDKDV);
                                    
                                    ckbVip.click(function(){
                                        //var _Publish = Publish.is(':checked');
                                        if(ckbVip.is(':checked') == true){
                                            inputDKDVVip.slideToggle("slow");
                                        }
                                        else{
                                            inputDKDVVip.slideToggle("slow");
                                        }
                                    });
                                    ckbHot.click(function(){
                                        //var _Publish = Publish.is(':checked');
                                        if(ckbHot.is(':checked') == true){
                                            inputDKDVHot.slideToggle("slow");
                                        }
                                        else{
                                            inputDKDVHot.slideToggle("slow");
                                        }
                                    });
                                    ckbSuper.click(function(){
                                        //var _Publish = Publish.is(':checked');
                                        if(ckbSuper.is(':checked') == true){
                                            inputDKDVSuper.slideToggle("slow");
                                        }
                                        else{
                                            inputDKDVSuper.slideToggle("slow");
                                        }
                                    });

                                    if(dt._DM_Ma == 'BAN'){
                                        imgmuaban.append('<img alt="" src="../css/admin/redmond/i/sell.gif" height="12px" width="30px"/>');            
                                    }
                                    if(dt._DM_Ma == 'MUA'){
                                        imgmuaban.append('<img alt="" src="../css/admin/redmond/i/buy.gif" height="12px" width="30px"/>');               
                                    }
                                    var NgayBatDauHot = $('.NgayBatDauHot', newDlgDKDV);
                                    var NgayBatDauSuper = $('.NgayBatDauSuper', newDlgDKDV);
                                    var NgayBatDauVip = $('.NgayBatDauVip', newDlgDKDV);

                                    var _DateNow = new Date();
                                    var DateNow = _DateNow.getDate() + '/' + (_DateNow.getMonth() + 1) + '/' + _DateNow.getFullYear();
                                    NgayBatDauHot.val(DateNow);
                                    NgayBatDauSuper.val(DateNow);
                                    NgayBatDauVip.val(DateNow);
                                    ID.val(dt.ID);
                                    if (dt.Anh != '') {
                                        $(imgAnh).attr('src', '../up/i/' + dt.Anh1 + '?ref=' + Math.random());
                                    }
                                    MaTinRV.append('RV-'+dt.ID);
                                    TieuDe.append(dt.Ten);
                                    DanhMuc.append(dt._DM_Ten);
                                    var __NgayDang = new Date(dt.NgayDang);
                                    var _NgayDang = __NgayDang.getDate() + '/' + (__NgayDang.getMonth() + 1) + '/' + __NgayDang.getFullYear();

                                    NgayDang.append(_NgayDang);
                                }
                            });
                            //console.log('2');
                            $.ajax({
                                url: RaoVatAdminMoiFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
                                dataType: 'script',
                                data: {
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var HotroSuper = $('.Super-DanhMuc',newDlgDKDV);
                                    var HotroVip = $('.Vip-DanhMuc',newDlgDKDV);
                                    var HotroHot = $('.Hot-DanhMuc',newDlgDKDV);
                                    var GhiChu = $('.GhiChu',newDlgDKDV);

                                    var ChuyenKhoanDM = $('.ChuyenKhoan-DanhMuc',newDlgDKDV);
                                    var GioiThieuDanhMuc = $('.GioiThieu-DanhMuc',newDlgDKDV);
                                    var ThanhToanDanhMuc = $('.ThanhToan-DanhMuc',newDlgDKDV);
                                    var LienHeDanhMuc= $('.LienHe-DanhMuc',newDlgDKDV);

                                    var GiaSuper = $('.GiaSuper-DanhMuc',newDlgDKDV);
                                    var TongTienSuper = $('.TongTien-Super',newDlgDKDV);
                                    var GiaHot = $('.GiaHot-DanhMuc',newDlgDKDV);
                                    var TongTienHot = $('.TongTien-Hot',newDlgDKDV);
                                    var GiaVip = $('.GiaVip-DanhMuc',newDlgDKDV);
                                    var TongTienVip = $('.TongTien-Vip',newDlgDKDV);

                                    $.each(data, function(i, item){
                                        if(item.Ma == 'RV_DV_VIP'){
                                            HotroVip.append(item.Description);
                                            GiaVip.append(item.GiaTri);
                                            //console.log(item.Description);
                                        }
                                        if(item.Ma == 'RV_DV_SUPER'){
                                            HotroSuper.append(item.Description);
                                            //console.log(item.Description);
                                            GiaSuper.append(item.GiaTri);
                                        }
                                        if(item.Ma == 'RV_DV_HOT'){
                                            HotroHot.append(item.Description);
                                            //console.log(item.Description);
                                            GiaHot.append(item.GiaTri);
                                        }
                                        if(item.Ma == 'RV_DV_LIENHE'){
                                        
                                            GhiChu.append(item.Description);
                                        }
                                        if(item.Ma == 'RV_DV_LIENHE'){
                                            LienHeDanhMuc.append(item.Description);
                                            //console.log(item.Description);
                                        }
                                        if(item.Ma == 'RV_DV_GIOITHIEU'){
                                            GioiThieuDanhMuc.append(item.Description);
                                            //console.log(item.Description);
                                        }
                                        if(item.Ma == 'RV_DV_TTOAN'){
                                            ThanhToanDanhMuc.append(item.Description);
                                            //console.log(item.Description);
                                        }
                                        if(item.Ma == 'RV_DV_CHKHOAN'){
                                            ChuyenKhoanDM.append(item.Description);
                                            //console.log(item.Description);
                                        }
                                    });
                                    //HotroSuper.append(dt.);
                    //                $.each(data, function(item,i));
                                }
                            });
                            //console.log('2');
                        }
                    });
                });
            }
        }
    },
    saveDKDV: function (validate, fn) {
        //RaoVatAdminMoiFn.popfndkdv();
        var newDlg = $('#RaoVatAdminMoiFnMdl-DKDVFnMdl-dlgNew');
        var dkhot = 'False';
        var dkvip = 'False';
        var dksuper = 'False';
        var NgayHetHanSuper = $('.NgayHetHanSuper', newDlg);
        var NgayHetHanVip = $('.NgayHetHanVip', newDlg);
        var NgayHetHanHot = $('.NgayHetHanHot', newDlg);
        var NgayBatDauHot = $('.NgayBatDauHot', newDlg);
        var NgayBatDauSuper = $('.NgayBatDauSuper', newDlg);
        var NgayBatDauVip = $('.NgayBatDauVip', newDlg);
        var ID = $('.ID', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _NgayHetHanHot = NgayHetHanHot.val();
        var _NgayHetHanSuper = NgayHetHanSuper.val();
        var _NgayHetHanVip = NgayHetHanVip.val();
        var _NgayBatDauHot = NgayBatDauHot.val();
        var _NgayBatDauSuper= NgayBatDauSuper.val();
        var _NgayBatDauVip = NgayBatDauVip.val();
        var err = '';
        //Date.parse
        if(Date.parse(_NgayHetHanHot) <= Date.parse(_NgayBatDauHot)){
            err += 'ngày kết thúc tin HOT phải lớn hơn ngày bắt đầu tin HOT';
        }
       
        if(Date.parse(_NgayHetHanSuper) <= Date.parse(_NgayBatDauSuper)){
            err += 'ngày kết thúc tin SUPER phải lớn hơn ngày bắt đầu tin SUPER';
        }
        if(Date.parse(_NgayHetHanVip) <= Date.parse(_NgayBatDauVip)){
            err += 'ngày kết thúc tin VIP phải lớn hơn ngày bắt đầu tin VIP';
        }
        if ((_NgayHetHanHot == '') && (_NgayHetHanSuper == '') && (_NgayHetHanVip == '')) {
            err += 'Bạn phải chọn thời gian đăng ký cần thiết';
        }

        if(_NgayHetHanHot != ''){
            if(_NgayBatDauHot ==''){
                err += 'Bạn phải chọn Ngày bắt đầu sử dụng dịch vụ tin HOT';
            }
        }

        if(_NgayHetHanSuper != ''){
            if(_NgayBatDauSuper ==''){
                err += 'Bạn phải chọn Ngày bắt đầu sử dụng dịch vụ tin SUPER';
            }
        }

        if(_NgayHetHanVip != ''){
            if(_NgayBatDauVip ==''){
                err += 'Bạn phải chọn Ngày bắt đầu sử dụng dịch vụ tin VIP';
            }
        }

        if(_NgayHetHanHot ==''){
            _NgayBatDauHot = '';
        }
        if(_NgayHetHanSuper ==''){
            _NgayBatDauSuper = '';
        }
        if(_NgayHetHanVip == ''){
            _NgayBatDauVip= '';
        }

        if (_NgayHetHanHot != '' && _NgayBatDauHot!= '') {
            dkhot = 'True';
        }
        if (_NgayHetHanVip != '' && _NgayBatDauVip!='') {
            dkvip = 'True';
        }
        if (_NgayHetHanSuper != '' && _NgayBatDauSuper!='') {
            dksuper = 'True';
        }

        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: RaoVatAdminMoiFn.urlDefault().toString() + '&subAct=DKDV',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'DKhot': dkhot,
                'DKSuper': dksuper,
                'DKVip': dkvip,
                'NgayHetHanHot': _NgayHetHanHot,
                'NgayHetHanVip': _NgayHetHanVip,
                'NgayHetHanSuper': _NgayHetHanSuper,
                'NgayDKSuper': _NgayBatDauSuper,
                'NgayDKVip':_NgayBatDauVip,
                'NgayDKHot':_NgayBatDauHot
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#RaoVatAdminMoiFnMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    }
}
