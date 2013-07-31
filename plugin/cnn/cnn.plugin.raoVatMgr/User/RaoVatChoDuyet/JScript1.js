UserRaoVatChoDuyetFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.raoVatMgr.User.RaoVatChoDuyet.Class1, cnn.plugin.raoVatMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $('#UserRaoVatChoDuyetFnMdl-List').jqGrid({
                    url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,//+'&trangthai=10',
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID','TT','Mã tin' ,'Ảnh', 'Tiêu đề', 'Danh mục RV', 'Loại tin', 'Ngày tạo','Từ ngày','Đến ngày'],
                    colModel: [
                        { name: 'RV_ID', key: true, sortable: true, hidden: true },
                        { name: 'STT', align: "center", width: 10 },
                        { name: 'MaTin', align: "center", width: 20 },
                        { name: 'RV_Anh', width: 30, sortable: true, align: "center" },
                        { name: 'RV_Ten', width: 120, resizable: true, sortable: true },
                        { name: 'RV_DM_ID', width: 35, sortable: true },
                        { name: 'RV_NC_ID', width: 20, sortable: true, align: "center" },
                        { name: 'RV_NgayDang', width: 30, resizable: true, sortable: true, align: "center" },
                        { name: 'RV_NgayDang', width: 30, resizable: true, align: "center" },
                        { name: 'RV_NgayDang', width: 30, resizable: true, align: "center" },
                        
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
                    pager: $('#UserRaoVatChoDuyetFnMdl-Pager'),
                    onSelectRow: function (rowid) {
                    },
                    loadComplete: function () {
                        adm.loading(null);
                        var txtfilter = $('.mdl-head-filterDanhMucUserRaoVatChoDuyet', '#UserRaoVatChoDuyetFnMdl-head');
                        var txtfilterTINH = $('.mdl-head-filterKhuVucUserRaoVatChoDuyet', '#UserRaoVatChoDuyetFnMdl-head');
                        var txtfilterLoaiTin = $('.mdl-head-filterLoaiTinUserRaoVatChoDuyet', '#UserRaoVatChoDuyetFnMdl-head');

                        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                            danhmuc.autoCompleteLangBased("", "RAOVAT", txtfilter, function (event, ui) {
                                $(txtfilter).attr('_value', ui.item.id);
                                UserRaoVatChoDuyetFn.search();
                            });
                            $(txtfilter).unbind('click').click(function () {
                                $(txtfilter).autocomplete('search', '');
                            });

                            danhmuc.autoCompleteLangBased("", "KV_TINH", txtfilterTINH, function (event, ui) {
                                $(txtfilterTINH).attr('_value', ui.item.id);
                                UserRaoVatChoDuyetFn.search();
                            });
                            $(txtfilterTINH).unbind('click').click(function () {
                                $(txtfilterTINH).autocomplete('search', '');
                            });

                            danhmuc.autoCompleteLangBased("", "TIN-NHOM", txtfilterLoaiTin, function (event, ui) {
                                $(txtfilterLoaiTin).attr('_value', ui.item.id);
                                UserRaoVatChoDuyetFn.search();
                            });
                            $(txtfilterLoaiTin).unbind('click').click(function () {
                                $(txtfilterLoaiTin).autocomplete('search', '');
                            });

                        });
                    }
                });
                var filterLoaiDanhMucID = $('.mdl-head-filterDanhMucUserRaoVatChoDuyet', '#UserRaoVatChoDuyetFnMdl-head');
                var filterTINHID = $('.mdl-head-filterKhuVucUserRaoVatChoDuyet', '#UserRaoVatChoDuyetFnMdl-head');
                var filterLoaiTin = $('.mdl-head-filterLoaiTinUserRaoVatChoDuyet', '#UserRaoVatChoDuyetFnMdl-head');
                var searchTxt = $('.mdl-head-search-UserRaoVatChoDuyet', '#UserRaoVatChoDuyetFnMdl-head');

                $(filterLoaiDanhMucID).keyup(function () {
                    if ($(filterLoaiDanhMucID).val() == '') {
                        $(filterLoaiDanhMucID).attr('_value', '');
                        if ($(searchTxt).val() == 'Tìm kiếm tin') {
                            $(searchTxt).val('');
                        }
                        UserRaoVatChoDuyetFn.search();
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
                        UserRaoVatChoDuyetFn.search();
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
                        UserRaoVatChoDuyetFn.search();
                        if ($(searchTxt).val() == '') {
                            $(searchTxt).val('Tìm kiếm tin');
                        }
                    }
                });
                $(searchTxt).keyup(function () {
                    UserRaoVatChoDuyetFn.search();
                });
                adm.watermark(searchTxt, 'Tìm kiếm tin', function () {
                    $(searchTxt).val('');
                    UserRaoVatChoDuyetFn.search();
                    $(searchTxt).val('Tìm kiếm tin');
                });
                adm.watermark(filterLoaiDanhMucID, 'Gõ tên mục tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    UserRaoVatChoDuyetFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                adm.watermark(filterTINHID, 'Gõ tên Khu vực để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    UserRaoVatChoDuyetFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                adm.watermark(filterLoaiTin, 'Gõ tên loại tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    UserRaoVatChoDuyetFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                var TrangThai = $('#UserRaoVatChoDuyetFnMdl-TrangThai');
                $(TrangThai).find('option').remove();
                $(TrangThai).prepend('<option value="1">Quá hạn</option>');
                $(TrangThai).prepend('<option value="2">Ðang đăng</option>');
                $(TrangThai).prepend('<option value="10">--Trạng thái--</option>');
                $(TrangThai).val('--Tr?ng thái--');
                //                var muaban = $('#UserRaoVatChoDuyetFnMdl-muaban');
                //                $(muaban).find('option').remove();
                //                $(muaban).prepend('<option value="True"> Chào mua</option>');
                //                $(muaban).prepend('<option value="False">Chào bán</option>');
                //                $(muaban).prepend('<option value="">--Chọn loại tin--</option>');
                //                $(muaban).val('--Chọn loại tin--');

                //                var TrangThai = $('#UserRaoVatChoDuyetFnMdl-TrangThai');
                //                $(TrangThai).find('option').remove();
                //                $(TrangThai).prepend('<option value="2">Đã duyệt</option>');
                //                $(TrangThai).prepend('<option value="3">Chưa Duyệt</option>');
                //                $(TrangThai).prepend('<option value="1">Quá hạn</option>');
                //                $(TrangThai).prepend('<option value="">--Trạng thái--</option>');
                //                $(TrangThai).val('--Trạng thái--');


                var changeLangBtn = $('#UserRaoVatChoDuyetFnMdl-changeLangSlt');
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
        var filterDM = $('.mdl-head-search-UserRaoVatChoDuyet');
        var searchDM = $('.mdl-head-filterDanhMucUserRaoVatChoDuyet');
        var searchTINH = $('.mdl-head-filterKhuVucUserRaoVatChoDuyet');
        var searchLoaiTin = $('.mdl-head-filterLoaiTinUserRaoVatChoDuyet', '#UserRaoVatChoDuyetFnMdl-head');
        var _Lang = $('#UserRaoVatChoDuyetFnMdl-changeLangSlt').val();
        var filtermuaban = $('#UserRaoVatChoDuyetFnMdl-muaban');
        var filterTrangThai = $('#UserRaoVatChoDuyetFnMdl-TrangThai');
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
            $('#UserRaoVatChoDuyetFnMdl-List').jqGrid('setGridParam', { url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=get&dm=' + dm + '&dmkv=' + tinh + '&Lang=' + _Lang + '&q=' + q + '&muaban=' + loaitin + '&trangthai=' + trangthai }).trigger('reloadGrid');
        }, 500);
    },
    loadHtml: function (fn) {
        var dlg = $('#UserRaoVatChoDuyetFnMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.raoVatMgr.User.RaoVatChoDuyet.htm.htm")%>',
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
        UserRaoVatChoDuyetFn.loadHtml(function () {
            var newDlg = $('#UserRaoVatChoDuyetFnMdl-dlgNew');
            var LangSlt = $('.Lang', newDlg);
            LangSlt.removeAttr('disabled');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 700,
                height: 500,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        UserRaoVatChoDuyetFn.save(false, function () {
                            UserRaoVatChoDuyetFn.clearform();
                            jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                        });
                    },
                    'Lưu và đóng': function () {
                        UserRaoVatChoDuyetFn.save(false, function () {
                            $(newDlg).dialog('close');
                            jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    UserRaoVatChoDuyetFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    UserRaoVatChoDuyetFn.clearform();
                    UserRaoVatChoDuyetFn.popfn();
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-dlgNew');
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
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-dlgNew');
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
        var Mota = $('.Mota', newDlg);
        var Gia = $('.Gia', newDlg);
        var NgayHetHan = $('.NgayHetHan', newDlg);
        var Publish = $('.Publish', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        ID.val('');
        LangBased.removeAttr('checked');
        LangBased_ID.val('');
        DM_ID.val('');
        DM_KV.val('');
        NhuCau_ID.val('');
        Mota.val('');
        LangSlt.val('');
        imgAnh.attr('src', '');
        lblAnh.attr('ref', '');
        Ten.val('');
        Gia.val('');
        NoiDung.val('');
        NgayHetHan.val('');
        spbMsg.html('');
    },
    save: function (validate, fn) {
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-dlgNew');
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

        var NoiDung = $('.NoiDung', newDlg);
        var _NoiDung = NoiDung.val();

        var Mota = $('.Mota', newDlg);
        var _Mota = Mota.val();

        var NgayHetHan = $('.NgayHetHan', newDlg);
        var _NgayHetHan = NgayHetHan.val();

        var Publish = $('.Publish', newDlg);
        var _Publish = Publish.is(':checked');
        var spbMsg = $('.admMsg', newDlg);

        var err = '';
        //console.log(_DM_ID);
        //console.log(_DM_KV);
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
            url: UserRaoVatChoDuyetFn.urlDefault().toString(),
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
        if (jQuery('#UserRaoVatChoDuyetFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#UserRaoVatChoDuyetFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                UserRaoVatChoDuyetFn.loadHtml(function () {
                    var newDlg = $('#UserRaoVatChoDuyetFnMdl-dlgNew');
                    var LangSlt = $('.Lang', newDlg);
                    LangSlt.removeAttr('disabled');
                    UserRaoVatChoDuyetFn.popfn();
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 700,
                        height: 500,
                        buttons: {
                            'Lưu': function () {
                                UserRaoVatChoDuyetFn.save(false, function () {
                                    UserRaoVatChoDuyetFn.clearform();
                                    jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Lưu và đóng': function () {
                                UserRaoVatChoDuyetFn.save(false, function () {
                                    UserRaoVatChoDuyetFn.clearform();
                                    $(newDlg).dialog('close');
                                    jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            UserRaoVatChoDuyetFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            $.ajax({
                                url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=edit',
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

                                    var imgAnh = $('.adm-upload-preview-img', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var Mota = $('.Mota', newDlg);
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
        s = jQuery('#UserRaoVatChoDuyetFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa?')) {
                $.ajax({
                    url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=del',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    },
    PheDuyet: function (active) {
        var s = '';
        s = jQuery('#UserRaoVatChoDuyetFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để duyệt');
        }
        else {
            if (confirm('Bạn có chắc chắn duyệt các mẩu tin này?')) {
                $.ajax({
                    url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=PheDuyet' + '&active=' + active,
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    },
    DangTinDungTin: function (Publish) {
        var s = '';
        s = jQuery('#UserRaoVatChoDuyetFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để duyệt');
        }
        else {
            if (confirm('Bạn có chắc muốn đăng các mẩu tin này?')) {
                $.ajax({
                    url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=DangTinDungTin' + '&Publish='+ Publish,
                    dataType: 'script',
                    data: {
                        'ID': s,
                    },
                    success: function (dt) {
                        jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    },
    popfndkdv: function () {
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-DKDVFnMdl-dlgNew');
        var NgayHetHanSuper = $('.NgayHetHanSuper', newDlg);
        var NgayHetHanHot = $('.NgayHetHanHot', newDlg);
        var NgayHetHanVip = $('.NgayHetHanVip', newDlg);

        var NgayBatDauHot = $('.NgayBatDauHot', newDlg);
        var NgayBatDauSuper = $('.NgayBatDauSuper', newDlg);
        var NgayBatDauVip = $('.NgayBatDauVip', newDlg);

        $('.NgayHetHanSuper', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayBatDauSuper', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayBatDauVip', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanVip', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanHot', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayBatDauHot', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    clearformdkdv: function () {
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-DKDVFnMdl-dlgNew');
        
        var ID = $('.ID', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var imgmuaban = $('.img-muaban',newDlg);
        var imgAnh = $('.adm-upload-preview-img-60', newDlg);
        var TieuDe = $('.TieuDe',newDlg);
        var MaTinRV = $('.MaTinRV',newDlg);
        var DanhMuc = $('.DanhMuc',newDlg);
        var NgayDang = $('.NgayDang',newDlg);

        var NgayHetHanSuper = $('.NgayHetHanSuper', newDlg);
        var HotroSuper = $('.Super-DanhMuc',newDlg);
        var NgayBatDauSuper = $('.NgayBatDauSuper', newDlg);
        var GiaSuper = $('.GiaSuper-DanhMuc',newDlg);
        var TongTienSuper = $('.TongTien-Super',newDlg);

        var NgayBatDauHot = $('.NgayBatDauHot', newDlg);
        var NgayHetHanHot = $('.NgayHetHanHot', newDlg);
        var HotroHot = $('.Hot-DanhMuc',newDlg);
        var GiaHot = $('.GiaHot-DanhMuc',newDlg);
        var TongTienHot = $('.TongTien-Hot',newDlg);

        var HotroVip = $('.Vip-DanhMuc',newDlg);
        var NgayHetHanVip = $('.NgayHetHanVip', newDlg);
        var NgayBatDauVip = $('.NgayBatDauVip', newDlg);
        var GiaVip = $('.GiaVip-DanhMuc',newDlg);
        var TongTienVip = $('.TongTien-Vip',newDlg);

        var ChuyenKhoanDM = $('.ChuyenKhoan-DanhMuc',newDlg);
        var GioiThieuDanhMuc = $('.GioiThieu-DanhMuc',newDlg);
        var ThanhToanDanhMuc = $('.ThanhToan-DanhMuc',newDlg);
        var LienHeDanhMuc= $('.LienHe-DanhMuc',newDlg);
        var GhiChuDKDVTT = $('.GhiChuDKDVTT',newDlg);
        var HoTroDanhMuc = $('.HoTro-DanhMuc',newDlg);

        var SoNgayDangTinSuperhtm = $('.SoNgayDangTinSuper',newDlg);
        var SoNgayDangTinViphtm = $('.SoNgayDangTinVip',newDlg);
        var SoNgayDangTinHothtm = $('.SoNgayDangTinHot',newDlg);

        var btnVip = $('.mdl-head-DKVip',newDlg);
        var btnSuper = $('.mdl-head-DKSuper',newDlg);
        var btnHot = $('.mdl-head-DKHot',newDlg);
        var ThongTinRaoVatTrangThaiDKDV = $('.ThongTin-RaoVat-TrangThaiDKDV',newDlg);
        ThongTinRaoVatTrangThaiDKDV.html('');
        btnVip.show();
        btnHot.show();
        btnSuper.show();
        //btnHot.fadeIn('speed');
        //btnSuper.fadeIn('speed');
        //btnVip.fadeIn('speed');
        //btnHot.attr('href','javascript:');
        //btnSuper.attr('href','javascript:');
        //btnVip.attr('href','javascript:');

        SoNgayDangTinSuperhtm.html('');
        SoNgayDangTinViphtm.html('');
        SoNgayDangTinHothtm.html('');
        HoTroDanhMuc.html('');
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
    loadHtmlDKDV: function (fn) {
        var dlg = $('#UserRaoVatChoDuyetFnMdl-DKDVFnMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.raoVatMgr.User.RaoVatChoDuyet.Dkdv.htm")%>',
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
    TinhGiaCuoc: function(NgayHetHan, NgayBatDau,Gia){
        var GiaCuocTong;
        var EndDate =$(NgayHetHan);
        var StartDate = $(NgayBatDau);
        var GiaCuocNgay = $(Gia);
        if(parent.Date(EndDate) > parent.Date(StartDate)){
            var SoNgay = UserRaoVatChoDuyetFn.dateDiff(d,EndDate,StartDate);
            //////console.log(SoNgay);
            GiaCuocTong=  SoNgay*GiacuocNgay;
        }
        else{
            EndDate.val('');
        }
        return GiaCuocTong;

    },
    convertDate: function (d, s) {
        var cDate = d.split(s);
        return cDate[1] + s + cDate[0] + s + cDate[2];
    },
    dateDiff: function (p_Interval, p_StartDate, p_EndDate) {
        var s_dt = new Date(p_StartDate);
        var e_dt = new Date(p_EndDate);
        var i_Number;
        var i_Year = Math.abs(e_dt.getFullYear() - s_dt.getFullYear());
        var i_Month = e_dt.getMonth() - s_dt.getMonth();

        switch (p_Interval.toLowerCase()) {
            case "yyyy":
                {// year
                    i_Number = i_Year;
                    break;
                }
            case "q":
                { // quarter
                    i_Number = Math.round((i_Year * 12 + i_Month) / 3)
                    if (((i_Year * 12 + i_Month) % 3) > 0) {
                        i_Number += 1;
                    }
                    break;
                }
            case "m":
                { // month
                    i_Number = i_Year * 12 + i_Month;
                    break;
                }
            case "d": // day
                {
                    i_Number = Math.abs(Math.round((e_dt - s_dt) / (24 * 60 * 60 * 1000)));
                    break;
                }
            default:
                {
                    return "invalid interval: '" + p_Interval + "'";
                }
        }
        return i_Number;
    },
    DKDV: function () {
        var s = '';
        if (jQuery('#UserRaoVatChoDuyetFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#UserRaoVatChoDuyetFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                UserRaoVatChoDuyetFn.loadHtmlDKDV(function () {
                    UserRaoVatChoDuyetFn.popfndkdv();
                    var newDlg = $('#UserRaoVatChoDuyetFnMdl-DKDVFnMdl-dlgNew');
                    $(newDlg).dialog({
                    title: 'Đăng ký dịch vụ Tin rao vặt',
                    width: 820,
                    height: 610,
                    buttons: {
                        'Đóng': function () {
                            $(newDlg).dialog('close');
                        }
                    },
                    beforeClose: function () {
                        UserRaoVatChoDuyetFn.clearformdkdv();
                    },
                        open: function () {
                            //UserRaoVatChoDuyetFn.LoadDichVuDaDangKy(ThongTinRaoVatTrangThaiDKDV,_ID);
                            var ThongTinRaoVatTrangThaiDKDV = $('.ThongTin-RaoVat-TrangThaiDKDV',newDlg);
                            UserRaoVatChoDuyetFn.LoadDichVuDaDangKy(ThongTinRaoVatTrangThaiDKDV,s);
                            
                            var inputDKDVSuper = $('.input-DKDV-Super',newDlg);
                            var inputDKDVVip = $('.input-DKDV-Vip',newDlg);
                            var inputDKDVHot = $('.input-DKDV-Hot',newDlg);
                            inputDKDVSuper.hide();
                            inputDKDVVip.hide();
                            inputDKDVHot.hide();
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            //////console.log('1');
                            $.ajax({
                                url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var imgAnh = $('.adm-upload-preview-img-60', newDlg);
                                    var TieuDe = $('.TieuDe',newDlg);
                                    var imgmuaban = $('.img-muaban',newDlg);
                                    var DanhMuc = $('.DanhMuc',newDlg);
                                    var NgayDang = $('.NgayDang',newDlg);
                                    var MaTinRV = $('.MaTinRV',newDlg);
                                    var ckbSuper = $('.ckbSuper',newDlg);
                                    var ckbVip = $('.ckbVip',newDlg);
                                    var ckbHot = $('.ckbHot',newDlg);
                                    var inputDKDVSuper = $('.input-DKDV-Super',newDlg);
                                    var inputDKDVVip = $('.input-DKDV-Vip',newDlg);
                                    var inputDKDVHot = $('.input-DKDV-Hot',newDlg);
                                    if(dt._DM_Ma == 'BAN'){
                                        imgmuaban.append('<img alt="" src="../css/admin/redmond/i/sell.gif" height="12px" width="30px"/>');            
                                    }
                                    if(dt._DM_Ma == 'MUA'){
                                        imgmuaban.append('<img alt="" src="../css/admin/redmond/i/buy.gif" height="12px" width="30px"/>');               
                                    }
                                    var NgayBatDauHot = $('.NgayBatDauHot', newDlg);
                                    var NgayBatDauSuper = $('.NgayBatDauSuper', newDlg);
                                    var NgayBatDauVip = $('.NgayBatDauVip', newDlg);
                                    var NgayHetHanSuper = $('.NgayHetHanSuper', newDlg);
                                    var NgayHetHanVip = $('.NgayHetHanVip', newDlg);
                                    var NgayHetHanHot = $('.NgayHetHanHot', newDlg);
                                    var _DateNow = new Date();
                                    var  _Dateweek = new Date();
                                    _Dateweek.setDate(_Dateweek.getDate() + 7);
                                    var Dateweek = _Dateweek.getDate() + '/' + (_Dateweek.getMonth() + 1) + '/' + _Dateweek.getFullYear();
                                    var DateNow = _DateNow.getDate() + '/' + (_DateNow.getMonth() + 1) + '/' + _DateNow.getFullYear();
                                    NgayBatDauHot.val(DateNow);
                                    NgayBatDauSuper.val(DateNow);
                                    NgayBatDauVip.val(DateNow);
                                    NgayHetHanHot.val(Dateweek);
                                    NgayHetHanSuper.val(Dateweek);
                                    NgayHetHanVip.val(Dateweek);
                                    ID.val(dt.ID);
                                    if (dt.Anh != '') {
                                        $(imgAnh).attr('src', '../up/i/' + dt.Anh1 + '?ref=' + Math.random());
                                    }
                                    MaTinRV.append('RV'+dt.ID);
                                    TieuDe.append(dt.Ten);
                                    DanhMuc.append(dt._DM_Ten);
                                    var __NgayDang = new Date(dt.NgayDang);
                                    var _NgayDang = __NgayDang.getDate() + '/' + (__NgayDang.getMonth() + 1) + '/' + __NgayDang.getFullYear();
                                    NgayDang.append(_NgayDang);
                                    
                                    

                                }
                            });
                            $.ajax({
                                url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
                                dataType: 'script',
                                data: {
                                    'MaDanhMuc':'LIENHE'
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var LienHeDM = $('.LienHe-DanhMuc',newDlg);
                                    var HoTroDanhMuc = $('.HoTro-DanhMuc',newDlg);
                                    HoTroDanhMuc.append('<b>Hỗ trợ</b> <br/>');
                                    $.each(data, function(i,item){
                                        if(item.Ma == 'LH_CHUNG'){
                                            LienHeDM.append(item.Description);
                                        };
                                        if(item.Ma == 'LH_HOTRO'){
                                            var src= 'http://opi.yahoo.com/online?u='+ item.GiaTri+'&amp;m=g&amp;t=1';
                                            HoTroDanhMuc.append('<b>'+item.Ten+'</b>' + ': <br/>'+'<a href="ymsgr:sendIM?'+item.GiaTri+'"><img border="0" src="'+src+'" alt="Hỗ trợ trực tuyến"></a><br />'+'Mobile: '+ item.KyHieu+'<br/>');
                                        };
                                    });
                                }
                            });
                            $.ajax({
                                url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=LoadThanhToanDanhMuc',
                                dataType: 'script',
                                data: {
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var ChuyenKhoanDM = $('.ChuyenKhoan-DanhMuc',newDlg);
                                    var ThanhToanDanhMuc = $('.ThanhToan-DanhMuc',newDlg);
                                    $.each(data, function(i,item){
                                        if(item.Ma == 'TT_TAIKHOAN'){
                                            ChuyenKhoanDM.append(item.Description);
                                        };
                                        if(item.Ma == 'TT_HINHTHUC'){
                                            ThanhToanDanhMuc.append(item.Description);
                                        }
                                    });


                                }
                            });
                            $.ajax({
                                url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
                                dataType: 'script',
                                data: {
                                    'MaDanhMuc':'RV_DICHVU'
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    //console.log(data);
                                    var HotroSuper = $('.Super-DanhMuc',newDlg);
                                    var HotroVip = $('.Vip-DanhMuc',newDlg);
                                    var HotroHot = $('.Hot-DanhMuc',newDlg);
                                    var GhiChu = $('.GhiChu',newDlg);

                                    var ChuyenKhoanDM = $('.ChuyenKhoan-DanhMuc',newDlg);
                                    var GioiThieuDanhMuc = $('.GioiThieu-DanhMuc',newDlg);
                                    var ThanhToanDanhMuc = $('.ThanhToan-DanhMuc',newDlg);
                                    //var LienHeDanhMuc= $('.LienHe-DanhMuc',newDlg);

                                    var GiaSuper = $('.GiaSuper-DanhMuc',newDlg);
                                    var TongTienSuper = $('.TongTien-Super',newDlg);
                                    var GiaHot = $('.GiaHot-DanhMuc',newDlg);
                                    var TongTienHot = $('.TongTien-Hot',newDlg);
                                    var GiaVip = $('.GiaVip-DanhMuc',newDlg);
                                    var TongTienVip = $('.TongTien-Vip',newDlg);

                                    var SoNgayDangTinSuperhtm = $('.SoNgayDangTinSuper',newDlg);
                                    var SoNgayDangTinViphtm = $('.SoNgayDangTinVip',newDlg);
                                    var SoNgayDangTinHothtm = $('.SoNgayDangTinHot',newDlg);

                                    SoNgayDangTinHothtm.append('( Số ngày: 7)');
                                    SoNgayDangTinViphtm.append('( Số ngày: 7)');
                                    SoNgayDangTinSuperhtm.append('( Số ngày: 7)');
                                    $.each(data, function(i, item){
                                        if(item.Ma == 'RV_DV_VIP'){
                                            HotroVip.append(item.Description);
                                            GiaVip.append(item.GiaTri);
                                            GiaVip.attr('_gia',item.GiaTri);
                                            //////console.log(item.Description);
                                        }
                                        if(item.Ma == 'RV_DV_SUPER'){
                                            HotroSuper.append(item.Description);
                                            //////console.log(item.Description);
                                            GiaSuper.append(item.GiaTri);
                                            GiaSuper.attr('_gia',item.GiaTri);
                                        }
                                        if(item.Ma == 'RV_DV_HOT'){
                                            HotroHot.append(item.Description);
                                            //////console.log(item.Description);
                                            GiaHot.append(item.GiaTri);
                                            GiaHot.attr('_gia',item.GiaTri);
                                        }
                                        if(item.Ma == 'RV_DV_LIENHE'){
                                        
                                            GhiChu.append(item.Description);
                                        }
//                                        if(item.Ma == 'RV_DV_LIENHE'){
//                                            LienHeDanhMuc.append(item.Description);
//                                        }
                                        if(item.Ma == 'RV_DV_GIOITHIEU'){
                                            GioiThieuDanhMuc.append(item.Description);
                                        }
//                                        if(item.Ma == 'RV_DV_TTOAN'){
//                                            ThanhToanDanhMuc.append(item.Description);
//                                        }
//                                        if(item.Ma == 'RV_DV_CHKHOAN'){
//                                            ChuyenKhoanDM.append(item.Description);
//                                        }
                                    });

                                    var Sumhot =parent.parseFloat(GiaHot.attr('_gia'))*7;
                                    TongTienHot.append(Sumhot);
                                    TongTienSuper.append(parent.parseFloat(GiaSuper.attr('_gia'))*7);
                                    TongTienVip.append(parent.parseFloat(GiaVip.attr('_gia'))*7);
                                    
                                    var NgayBatDauHot = $('.NgayBatDauHot', newDlg);
                                    var NgayBatDauSuper = $('.NgayBatDauSuper', newDlg);
                                    var NgayBatDauVip = $('.NgayBatDauVip', newDlg);
                                    var NgayHetHanSuper = $('.NgayHetHanSuper', newDlg);
                                    var NgayHetHanVip = $('.NgayHetHanVip', newDlg);
                                    var NgayHetHanHot = $('.NgayHetHanHot', newDlg);

                                    
                                    NgayBatDauSuper.change(function(){
                                        TongTienSuper.html('');
                                        SoNgayDangTinSuperhtm.html('');
                                        var convertDateNgayHetHanSuper = UserRaoVatChoDuyetFn.convertDate(NgayHetHanSuper.val(),'/');
                                        var convertDateNgayBatDauSuper = UserRaoVatChoDuyetFn.convertDate(NgayBatDauSuper.val(),'/'); 
                                        var SoNgayDangKySuper = UserRaoVatChoDuyetFn.dateDiff('d',convertDateNgayBatDauSuper,convertDateNgayHetHanSuper);
                                        SoNgayDangTinSuperhtm.append('( Số ngày: '+ SoNgayDangKySuper +')');
                                        TongTienSuper.append(parent.parseFloat(GiaSuper.attr('_gia'))*parent.parseFloat(SoNgayDangKySuper));
                                    });
                                    NgayHetHanSuper.change(function(){
                                        TongTienSuper.html('');
                                        SoNgayDangTinSuperhtm.html('');
                                        var convertDateNgayHetHanSuper = UserRaoVatChoDuyetFn.convertDate(NgayHetHanSuper.val(),'/');
                                        var convertDateNgayBatDauSuper = UserRaoVatChoDuyetFn.convertDate(NgayBatDauSuper.val(),'/'); 
                                        var SoNgayDangKySuper = UserRaoVatChoDuyetFn.dateDiff('d',convertDateNgayBatDauSuper,convertDateNgayHetHanSuper);
                                        SoNgayDangTinSuperhtm.append('( Số ngày: '+ SoNgayDangKySuper +')');
                                        TongTienSuper.append(parent.parseFloat(GiaSuper.attr('_gia'))*parent.parseFloat(SoNgayDangKySuper));
                                    });
                                    NgayBatDauHot.change(function(){
                                        TongTienHot.html('');
                                        SoNgayDangTinHothtm.html('');
                                        var convertDateNgayHetHanHot = UserRaoVatChoDuyetFn.convertDate(NgayHetHanHot.val(),'/');
                                        var convertDateNgayBatDauHot = UserRaoVatChoDuyetFn.convertDate(NgayBatDauHot.val(),'/'); 
                                        var SoNgayDangKyHot = UserRaoVatChoDuyetFn.dateDiff('d',convertDateNgayBatDauHot,convertDateNgayHetHanHot);
                                        SoNgayDangTinHothtm.append('( Số ngày: '+ SoNgayDangKyHot +')');
                                        TongTienHot.append(parent.parseFloat(GiaHot.attr('_gia'))*parent.parseFloat(SoNgayDangKyHot));
                                    });
                                    NgayHetHanHot.change(function(){
                                        TongTienHot.html('');
                                        SoNgayDangTinHothtm.html('');
                                        var convertDateNgayHetHanHot = UserRaoVatChoDuyetFn.convertDate(NgayHetHanHot.val(),'/');
                                        var convertDateNgayBatDauHot = UserRaoVatChoDuyetFn.convertDate(NgayBatDauHot.val(),'/'); 
                                        var SoNgayDangKyHot = UserRaoVatChoDuyetFn.dateDiff('d',convertDateNgayBatDauHot,convertDateNgayHetHanHot);
                                        SoNgayDangTinHothtm.append('( Số ngày: '+ SoNgayDangKyHot +')');
                                        TongTienHot.append(parent.parseFloat(GiaHot.attr('_gia'))*parent.parseFloat(SoNgayDangKyHot));
                                    });

                                    NgayHetHanVip.change(function(){
                                        TongTienVip.html('');
                                        SoNgayDangTinViphtm.html('');
                                        var convertDateNgayHetHanVip = UserRaoVatChoDuyetFn.convertDate(NgayHetHanVip.val(),'/');
                                        var convertDateNgayBatDauVip = UserRaoVatChoDuyetFn.convertDate(NgayBatDauVip.val(),'/'); 
                                        var SoNgayDangKyVip = UserRaoVatChoDuyetFn.dateDiff('d',convertDateNgayBatDauVip,convertDateNgayHetHanVip);
                                        SoNgayDangTinViphtm.append('( Số ngày: '+ SoNgayDangKyVip +')');
                                        TongTienVip.append(parent.parseFloat(GiaVip.attr('_gia'))*parent.parseFloat(SoNgayDangKyVip));
                                    });
                                    NgayBatDauVip.change(function(){
                                        TongTienVip.html('');
                                        SoNgayDangTinViphtm.html('');
                                        var convertDateNgayHetHanVip = UserRaoVatChoDuyetFn.convertDate(NgayHetHanVip.val(),'/');
                                        var convertDateNgayBatDauVip = UserRaoVatChoDuyetFn.convertDate(NgayBatDauVip.val(),'/'); 
                                        var SoNgayDangKyVip = UserRaoVatChoDuyetFn.dateDiff('d',convertDateNgayBatDauVip,convertDateNgayHetHanVip);
                                        SoNgayDangTinViphtm.append('( Số ngày: '+ SoNgayDangKyVip +')');
                                        TongTienVip.append(parent.parseFloat(GiaVip.attr('_gia'))*parent.parseFloat(SoNgayDangKyVip));
                                    });
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    saveDKDVVIP: function(validate, fn){
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-DKDVFnMdl-dlgNew');
        var dkvip = 'False';
        var NgayHetHanVip = $('.NgayHetHanVip', newDlg);
        var NgayBatDauVip = $('.NgayBatDauVip', newDlg);
        var ID = $('.ID', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var _ID = ID.val();
        var _NgayHetHanVip = NgayHetHanVip.val();
        var _NgayBatDauVip = NgayBatDauVip.val();
        var btnVip = $('.mdl-head-DKVip',newDlg);
        var err = '';
        var convertDateNgayHetHanVip = UserRaoVatChoDuyetFn.convertDate(NgayHetHanVip.val(),'/');
        var convertDateNgayBatDauVip = UserRaoVatChoDuyetFn.convertDate(NgayBatDauVip.val(),'/');
        if(Date.parse(convertDateNgayHetHanVip) < Date.parse(convertDateNgayBatDauVip)){
            err += 'ngày kết thúc phải lớn hơn ngày đăng ký';
        }
        if(_NgayBatDauVip ==''){
            err += 'Bạn phải điền ngày bắt đầu';
        }
        if(_NgayHetHanVip ==''){
            err += 'Bạn phải điền ngày hết hạn';
        }
        if (_NgayBatDauVip != '' && _NgayHetHanVip!= '' && (Date.parse(convertDateNgayHetHanVip) > Date.parse(convertDateNgayBatDauVip))) {
            dkvip = 'True';
        }
        if (err != '') { alert(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=DKDV',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'DKVip': dkvip,
                'NgayHetHanVip': _NgayHetHanVip,
                'NgayDKVip':_NgayBatDauVip
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                    btnVip.hide();
                    var ThongTinRaoVatTrangThaiDKDV = $('.ThongTin-RaoVat-TrangThaiDKDV',newDlg);
                    UserRaoVatChoDuyetFn.LoadDichVuDaDangKy(ThongTinRaoVatTrangThaiDKDV,_ID);
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    saveDKDVSUPER: function(validate, fn){
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-DKDVFnMdl-dlgNew');
        var dksuper = 'False';
        var NgayHetHanSuper = $('.NgayHetHanSuper', newDlg);
        var NgayBatDauSuper = $('.NgayBatDauSuper', newDlg);
        var btnSuper = $('.mdl-head-DKSuper',newDlg);
        
        var ID = $('.ID', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var _ID = ID.val();
        var _NgayBatDauSuper= NgayBatDauSuper.val();
        var _NgayHetHanSuper = NgayHetHanSuper.val();
        var err = '';
        var convertDateNgayHetHanSuper = UserRaoVatChoDuyetFn.convertDate(NgayHetHanSuper.val(),'/');
        var convertDateNgayBatDauSuper = UserRaoVatChoDuyetFn.convertDate(NgayBatDauSuper.val(),'/');
        if(Date.parse(convertDateNgayHetHanSuper) < Date.parse(convertDateNgayBatDauSuper)){
            err += 'ngày kết thúc phải lớn hơn ngày đăng ký';
        }
        if(_NgayBatDauSuper ==''){
            err += 'Bạn phải điền ngày bắt đầu';
        }
        if(_NgayHetHanSuper ==''){
            err += 'Bạn phải điền ngày hết hạn';
        }
        if (_NgayBatDauSuper != '' && _NgayHetHanSuper!= '' && (Date.parse(convertDateNgayHetHanSuper) > Date.parse(convertDateNgayBatDauSuper))) {
            dksuper = 'True';
        }
        if (err != '') { alert(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=DKDV',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'DKSuper': dksuper,
                'NgayHetHanSuper': _NgayHetHanSuper,
                'NgayDKSuper': _NgayBatDauSuper
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                    //btnSuper.fadeTo("slow",0.25);
                    //btnSuper.removeAttr('href');
                    btnSuper.hide();
                    //alert('Bạn đã đăng ký thành công dịch vụ tin rao vặt SUPER.');
                    var ThongTinRaoVatTrangThaiDKDV = $('.ThongTin-RaoVat-TrangThaiDKDV',newDlg);
                    UserRaoVatChoDuyetFn.LoadDichVuDaDangKy(ThongTinRaoVatTrangThaiDKDV,_ID);
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    saveDKDVHOT: function(validate, fn){
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-DKDVFnMdl-dlgNew');
        var dkhot = 'False';
        var NgayHetHanHot = $('.NgayHetHanHot', newDlg);
        var NgayBatDauHot = $('.NgayBatDauHot', newDlg);
        var ID = $('.ID', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var btnHot = $('.mdl-head-DKHot',newDlg);
        var _ID = ID.val();
        var _NgayHetHanHot = NgayHetHanHot.val();
        var _NgayBatDauHot = NgayBatDauHot.val();
        var convertDateNgayHetHanHot = UserRaoVatChoDuyetFn.convertDate(NgayHetHanHot.val(),'/');
        var convertDateNgayBatDauHot = UserRaoVatChoDuyetFn.convertDate(NgayBatDauHot.val(),'/');
        var err = '';
        if(Date.parse(convertDateNgayHetHanHot) < Date.parse(convertDateNgayBatDauHot)){
            err += 'ngày kết thúc phải lớn hơn ngày đăng ký';
        }
        if(_NgayBatDauHot ==''){
            err += 'Bạn phải điền ngày bắt đầu';
        }
        if(_NgayHetHanHot ==''){
            err += 'Bạn phải điền ngày hết hạn';
        }
        if (_NgayBatDauHot != '' && _NgayHetHanHot!= '' && (Date.parse(convertDateNgayHetHanHot) > Date.parse(convertDateNgayBatDauHot))) {
            dkhot = 'True';
        }
        if (err != '') { alert(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=DKDV',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'DKhot': dkhot,
                'NgayHetHanHot': _NgayHetHanHot,
                'NgayDKHot':_NgayBatDauHot
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                    //btnHot.fadeTo("slow",0.25);
                    //btnHot.removeAttr('href');
                    btnHot.hide();
                    //alert('Bạn đã đăng ký thành công dịch vụ tin rao vặt HOT.');
                    var ThongTinRaoVatTrangThaiDKDV = $('.ThongTin-RaoVat-TrangThaiDKDV',newDlg);
                    UserRaoVatChoDuyetFn.LoadDichVuDaDangKy(ThongTinRaoVatTrangThaiDKDV,_ID);
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    saveDKDV: function (validate, fn) {
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-DKDVFnMdl-dlgNew');
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
        var _NgayBatDauHot = NgayBatDauHot.val();
        var _NgayHetHanVip = NgayHetHanVip.val();
        
        var _NgayBatDauSuper= NgayBatDauSuper.val();
        var _NgayHetHanSuper = NgayHetHanSuper.val();
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
            url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=DKDV',
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
                    jQuery('#UserRaoVatChoDuyetFnMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    sendLienHe: function (validate, fn) {
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-DKDVFnMdl-dlgNew');
        var spbMsg = $('.admMsg', newDlg);
        var txtNoiDung = $('.txtNoiDungLienHe', newDlg);
        var txtID = $('.ID',newDlg);
        var txtTieuDeLienHe = $('.txtTieuDeLienHe',newDlg)

        var tieude = $(txtTieuDeLienHe).val();
        var noidung = $(txtNoiDung).val();
        var ID = txtID.val();

        if(noidung ==''){alert('Bạn phải điền nội dung'); return false;}
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang gửi liên hệ');
        $.ajax({
            url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=lienHe',
            dataType: 'script',
            data: {
                'ID': ID,
                'NoiDungLienHe': noidung,
                'msgtitle':tieude

            },
            success: function (dt) {
                adm.loading(null);
                txtNoiDung.val('');
                txtTieuDeLienHe.val('');
                alert('Bạn đã gửi thành liên hệ thành công');
            }

        })
    },
    LoadDichVuDaDangKy: function(_obj,_ID){
        var obj = $(_obj);
        var ID = _ID;
        var newDlg = $('#UserRaoVatChoDuyetFnMdl-DKDVFnMdl-dlgNew');
        ////console.log('LoadDichVuDaDangKy'+ID);
        obj.html('');
        $.ajax({
            url: UserRaoVatChoDuyetFn.urlDefault().toString() + '&subAct=edit',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': ID
            },
            success: function (dt) {
                data = eval(dt);
                var Dkhot = eval(data.DangKy_NoiBat);
                var DKsuper = eval(data.DangKy_SUPER);
                var Dkvip = eval(data.DangKy_VIP);
                var btnVip = $('.mdl-head-DKVip',newDlg);
                var btnSup = $('.mdl-head-DKSuper',newDlg);
                var btnHot = $('.mdl-head-DKHot',newDlg);
                if(Dkhot== true){
                    $(btnHot).hide();
                }
                if(DKsuper== true){
                    $(btnSup).hide();
                }
                if(Dkvip== true){
                    $(btnVip).hide();
                }
                //var __NgayHetHan = new Date(dt.NgayHetHan);
                //var _NgayHetHan = __NgayHetHan.getDate() + '/' + (__NgayHetHan.getMonth() + 1) + '/' + __NgayHetHan.getFullYear();
                //NgayHetHan.val(_NgayHetHan);
                var NgayBDvip = new Date(data.VIP_VIP_NgayBatDau);
                var NgayKTvip = new Date(data.VIP_VIP_NgayHetHan);
                var NgayBDsuper = new Date(data.VIP_SUPER_NgayBatDau);
                var NgayKTsuper = new Date(data.VIP_SUPER_NgayHetHan);
                var NgayBDhot = new Date(data.VIP_NoiBat_NgayBatDau);
                var NgayKThot = new Date(data.VIP_NoiBat_NgayHetHan);
                var _NgayBDvip = NgayBDvip.getDate() + '/' + (NgayBDvip.getMonth() + 1) + '/' + NgayBDvip.getFullYear();
                var _NgayKTvip = NgayKTvip.getDate() + '/' + (NgayKTvip.getMonth() + 1) + '/' + NgayKTvip.getFullYear();
                var _NgayBDsuper = NgayBDsuper.getDate() + '/' + (NgayBDsuper.getMonth() + 1) + '/' + NgayBDsuper.getFullYear();
                var _NgayKTsuper = NgayKTsuper.getDate() + '/' + (NgayKTsuper.getMonth() + 1) + '/' + NgayKTsuper.getFullYear();
                var _NgayBDhot = NgayBDhot.getDate() + '/' + (NgayBDhot.getMonth() + 1) + '/' + NgayBDhot.getFullYear();
                var _NgayKThot = NgayKThot.getDate() + '/' + (NgayKThot.getMonth() + 1) + '/' + NgayKThot.getFullYear();
                
                if(eval(Dkvip) == true){
                    //imgmuaban.append('<img alt="" src="../css/admin/redmond/i/sell.gif" height="12px" width="30px"/>');            
                    $(obj).append('<a style="margin: 10px;"><img alt="" src="../css/admin/redmond/i/vip.jpg" height="12px" width="30px"/>'+':'+_NgayBDvip+'-'+_NgayKTvip+'</a><br/>');
                }
                if(eval(DKsuper) == true){
                    //imgmuaban.append('<img alt="" src="../css/admin/redmond/i/sell.gif" height="12px" width="30px"/>');            
                    $(obj).append('<a style="margin: 10px;"><img alt="" src="../css/admin/redmond/i/super.jpg" height="12px" width="30px"/>'+':'+_NgayBDsuper+'-'+_NgayKTsuper+'</a><br/>');
                }
                if(eval(Dkhot) == true){
                    //imgmuaban.append('<img alt="" src="../css/admin/redmond/i/sell.gif" height="12px" width="30px"/>');            
                    $(obj).append('<a style="margin: 10px;"><img alt="" src="../css/admin/redmond/i/hot.jpg" height="12px" width="30px"/>'+':'+_NgayBDhot+'-'+_NgayKThot+'</a><br/>');
                }
                
            }
        });
    }
}
