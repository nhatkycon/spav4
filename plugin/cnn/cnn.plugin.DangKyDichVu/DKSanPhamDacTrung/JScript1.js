var HangHoaDKSanPhamDacTrungFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.DangKyDichVu.DKSanPhamDacTrung.Class1, cnn.plugin.DangKyDichVu'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu danh mục');
        var DMID = $('.mdl-head-search-HangHoaDKSanPhamDacTrungFn');
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                var initialized = [false, false];
                $('#HangHoaDKSanPhamDacTrungFnMdl-List').jqGrid({
                    url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'LangBased', 'Lang', 'Ảnh', 'Mã', 'Tên', 'Danh mục','Ngày tạo'],
                    colModel: [
                        { name: 'ID', key: true, sortable: true, hidden: true },
                        { name: 'LangBased', key: true, sortable: true, hidden: true },
                        { name: 'Lang', key: true, sortable: true, hidden: true },
                        { name: 'Anh', width: 10, sortable: true, align: "center" },
                        { name: 'Ma', width: 10, resizable: true, sortable: true },
                        { name: 'Ten', width: 50, resizable: true, sortable: true },
                        { name: 'DM_ID', width: 10, sortable: true, align: "center" },
                        { name: 'NgayTao', width: 10, resizable: true, sortable: true }
                    ],
                    caption: 'Danh sách',
                    autowidth: true,
                    sortname: 'ID',
                    sortorder: 'asc',
                    rowNum: 10000,
                    multiselect: true,
                    multiboxonly: true,
                    onSelectRow: function (rowid) {
                        HangHoaDKSanPhamDacTrungFn.loadSubGrid(rowid);
                    },
                    loadComplete: function () {
                        adm.loading(null);
                    },
                    pager: $('#HangHoaDKSanPhamDacTrungFnMdl-Pager')
                });
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () { });
                adm.watermark(DMID, 'Gõ tên loại danh mục để lọc', function () {
                });
                if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }
            });
        });
    },
    loadSubGrid: function (_id) {
        if (_id != null) {

        }
        else {
        }
    },
    edit: function () {
        var s = '';
        if (jQuery('#HangHoaDKSanPhamDacTrungFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#HangHoaDKSanPhamDacTrungFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                HangHoaDKSanPhamDacTrungFn.loadHtml(function () {
                    var newDlg = $('#HangHoaDKSanPhamDacTrungFnMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                HangHoaDKSanPhamDacTrungFn.save(false, function () {
                                    HangHoaDKSanPhamDacTrungFn.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                HangHoaDKSanPhamDacTrungFn.save(false, function () {
                                    HangHoaDKSanPhamDacTrungFn.clearform();
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            HangHoaDKSanPhamDacTrungFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            $.ajax({
                                url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=edit',
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
                                    var Ten = $('.Ten', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var Alias = $('.Alias', newDlg);
                                    var LangSlt = $('.Lang', newDlg);
                                    var XuatXu_ID = $('.XuatXu_ID', newDlg);
                                    var DonVi_ID = $('.DonVi_ID', newDlg);
                                    var SoLuong = $('.SoLuong', newDlg);
                                    var GNY = $('.GNY', newDlg);
                                    var GiaNhap = $('.GiaNhap', newDlg);
                                    var KeyWords = $('.KeyWords', newDlg);
                                    var Description = $('.Description', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var imgAnh = $('.adm-upload-preview-img', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);

                                    var Active = $('.Active', newDlg);
                                    var Publish = $('.Publish', newDlg);
                                    var Hot = $('.Hot', newDlg);
                                    var Hot1 = $('.Hot1', newDlg);
                                    var Hot2 = $('.Hot2', newDlg);
                                    var Hot3 = $('.Hot3', newDlg);
                                    var Hot4 = $('.Hot4', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    LangBased_ID.val(dt.LangBased_ID);
                                    if (dt.LangBased) {
                                        $(LangBased).attr('checked', 'checked');
                                    }
                                    else {
                                        $(LangBased).removeAttr('checked');
                                    }
                                    DM_ID.val(dt._DM_Ten);
                                    DM_ID.attr('_value', dt.DM_ID);
                                    Ten.val(dt.Ten);
                                    Ma.val(dt.Ma);
                                    Alias.val(dt.Alias);
                                    LangSlt.val(dt.Lang);
                                    XuatXu_ID.val(dt._XuatXu_Ten);
                                    XuatXu_ID.attr('_value', dt.XuatXu_ID);
                                    DonVi_ID.val(dt._DonVi_Ten);
                                    DonVi_ID.attr('_value', dt.DonVi_ID);
                                    SoLuong.val(dt.SoLuong);
                                    GNY.val(dt.GNY);
                                    GiaNhap.val(dt.GiaNhap);
                                    KeyWords.val(dt.KeyWords);
                                    Description.val(dt.Description);
                                    MoTa.val(dt.MoTa);
                                    $(lblAnh).attr('ref', dt.Anh);
                                    if (dt.Anh != '') {
                                        $(imgAnh).attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());
                                    }
                                    NoiDung.val(dt.NoiDung);
                                    if (dt.Active) { Active.attr('checked', 'checked'); } else { Active.removeAttr('checked'); }
                                    if (dt.Publish) { Publish.attr('checked', 'checked'); } else { Publish.removeAttr('checked'); }
                                    if (dt.Hot) { Hot.attr('checked', 'checked'); } else { Hot.removeAttr('checked'); }
                                    if (dt.Hot1) { Hot1.attr('checked', 'checked'); } else { Hot1.removeAttr('checked'); }
                                    if (dt.Hot2) { Hot2.attr('checked', 'checked'); } else { Hot2.removeAttr('checked'); }
                                    if (dt.Hot3) { Hot3.attr('checked', 'checked'); } else { Hot3.removeAttr('checked'); }
                                    if (dt.Hot4) { Hot4.attr('checked', 'checked'); } else { Hot4.removeAttr('checked'); }
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function () {
        HangHoaDKSanPhamDacTrungFn.loadHtml(function () {
            var newDlg = $('#HangHoaDKSanPhamDacTrungFnMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        HangHoaDKSanPhamDacTrungFn.save(false, function () {
                            HangHoaDKSanPhamDacTrungFn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        HangHoaDKSanPhamDacTrungFn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    HangHoaDKSanPhamDacTrungFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    HangHoaDKSanPhamDacTrungFn.clearform();
                    HangHoaDKSanPhamDacTrungFn.popfn();
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');
                }
            });
        });
    },
    del: function () {
        var s = '';
        if (jQuery('#HangHoaDKSanPhamDacTrungFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#HangHoaDKSanPhamDacTrungFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=del',
                        dataType: 'script',
                        data: { 'ID': s },
                        success: function (dt) {
                            jQuery('#HangHoaDKSanPhamDacTrungFnMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#HangHoaDKSanPhamDacTrungFnMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var LangBased = $('.LangBased', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var Alias = $('.Alias', newDlg);
        var LangSlt = $('.Lang', newDlg);
        var XuatXu_ID = $('.XuatXu_ID', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var GNY = $('.GNY', newDlg);
        var GiaNhap = $('.GiaNhap', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Description = $('.Description', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Active = $('.Active', newDlg);
        var Publish = $('.Publish', newDlg);
        var Hot = $('.Hot', newDlg);
        var Hot1 = $('.Hot1', newDlg);
        var Hot2 = $('.Hot2', newDlg);
        var Hot3 = $('.Hot3', newDlg);
        var Hot4 = $('.Hot4', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _LangBased = $(LangBased).is(':checked');
        var _LangBased_ID = $(LangBased_ID).val();
        var _DM_ID = DM_ID.attr('_value');
        var _Ten = Ten.val();
        var _Ma = Ma.val();
        var _Alias = Alias.val();
        var _Lang = LangSlt.val();
        var _XuatXu_ID = XuatXu_ID.attr('_value');
        var _DonVi_ID = DonVi_ID.attr('_value');
        var _SoLuong = SoLuong.val();
        var _GNY = GNY.val();
        var _GiaNhap = GiaNhap.val();
        var _KeyWords = KeyWords.val();
        var _Description = Description.val();
        var _MoTa = MoTa.val();
        var _Anh = lblAnh.attr('ref');
        var _NoiDung = NoiDung.val();
        var _Active = Active.is(':checked');
        var _Publish = Publish.is(':checked');
        var _Hot = Hot.is(':checked');
        var _Hot1 = Hot1.is(':checked');
        var _Hot2 = Hot2.is(':checked');
        var _Hot3 = Hot3.is(':checked');
        var _Hot4 = Hot4.is(':checked');

        var err = '';
        if (_DM_ID == '') { err += 'Chọn danh mục<br/>'; };
        if (_Ten == '') { err += 'Nhập tên<br/>'; };
        if (!_LangBased) { if (_Lang == Lang) { err += 'Chọn ngôn ngữ khác'; }; }
        else { if (_Lang != Lang) { err += 'Bạn cần chọn ngôn ngữ gốc ' + Lang; }; }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                'ID': _ID,
                'LangBased': _LangBased,
                'LangBased_ID': _LangBased_ID,
                'DM_ID': _DM_ID,
                'Ten': _Ten,
                'Ma': _Ma,
                'Alias': _Alias,
                'Lang': _Lang,
                'XuatXu_ID': _XuatXu_ID,
                'DonVi_ID': _DonVi_ID,
                'SoLuong': _SoLuong,
                'GNY': _GNY,
                'GiaNhap': _GiaNhap,
                'KeyWords': _KeyWords,
                'Description': _Description,
                'MoTa': _MoTa,
                'Anh': _Anh,
                'NoiDung': _NoiDung,
                'Active': _Active,
                'Publish': _Publish,
                'Hot': _Hot,
                'Hot1': _Hot1,
                'Hot2': _Hot2,
                'Hot3': _Hot3,
                'Hot4': _Hot4
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#HangHoaDKSanPhamDacTrungFnMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    search: function () {
        var timerSearch;
        var LDMID = $('.mdl-head-filterloaiHangHoaDKSanPhamDacTrungFn');
        var _Lang = $('#HangHoaDKSanPhamDacTrungFnMdl-changeLangSlt').val();
        var _LDMID = $(LDMID).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#HangHoaDKSanPhamDacTrungFnMdl-List').jqGrid('setGridParam', { url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=get&LDMID=' + _LDMID + '&Lang=' + _Lang }).trigger('reloadGrid');
        }, 500);
    },
    popfn: function () {
        var newDlg = $('#HangHoaDKSanPhamDacTrungFnMdl-dlgNew');
        var DM_ID = $('.DM_ID', newDlg);
        var XuatXu_ID = $('.XuatXu_ID', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        // Lấy danh mục thuộc Loại nhóm có mã là HH-DM: Hàng hóa Danh mục
        danhmuc.autoCompleteLangBased('', 'SP_NHOM', DM_ID, function (event, ui) {
            $(DM_ID).attr('_value', ui.item.id);
        });
        $(DM_ID).unbind('click').click(function () { $(DM_ID).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'KV-XX', XuatXu_ID, function (event, ui) {
            $(XuatXu_ID).attr('_value', ui.item.id);
        });
        $(XuatXu_ID).unbind('click').click(function () { $(XuatXu_ID).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'HH-DV', DonVi_ID, function (event, ui) {
            $(DonVi_ID).attr('_value', ui.item.id);
        });
        $(DonVi_ID).unbind('click').click(function () { $(DonVi_ID).autocomplete('search', ''); });

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
        adm.createFck(NoiDung);

        var LangSlt = $('.Lang', newDlg);
        if ($(LangSlt).children().length > 0) { return false; }
        $(LangSlt).find('option').remove();
        $.each(LangArr, function (i, item) {
            if (item.Active) {
                Lang = item.Ma;
            }
            $(LangSlt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
        });


    },
    clearform: function () {
        var newDlg = $('#HangHoaDKSanPhamDacTrungFnMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var LangBased = $('.LangBased', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var Alias = $('.Alias', newDlg);
        var LangSlt = $('.Lang', newDlg);
        var XuatXu_ID = $('.XuatXu_ID', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var GNY = $('.GNY', newDlg);
        var GiaNhap = $('.GiaNhap', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Description = $('.Description', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Active = $('.Active', newDlg);
        var Publish = $('.Publish', newDlg);
        var Hot = $('.Hot', newDlg);
        var Hot1 = $('.Hot1', newDlg);
        var Hot2 = $('.Hot2', newDlg);
        var Hot3 = $('.Hot3', newDlg);
        var Hot4 = $('.Hot4', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        ID.val('');
        LangBased.removeAttr('checked');
        LangBased_ID.val('');
        Ten.val('');
        Ma.val('');
        Alias.val('');
        SoLuong.val('');
        GNY.val('');
        GiaNhap.val('');
        KeyWords.val('');
        Description.val('');
        MoTa.val('');
        imgAnh.attr('src', '');
        lblAnh.attr('ref', '');
        NoiDung.val('');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#HangHoaDKSanPhamDacTrungFnMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.DangKyDichVu.DKSanPhamDacTrung.htm.htm")%>',
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
    loadfromDKSPDT: function (fn) {
        var dlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.DangKyDichVu.DKSanPhamDacTrung.DangKySanPhamDacTrung.htm")%>',
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
    DangKySanPhamDacTrung: function () {
        var s = '';
        if (jQuery('#HangHoaDKSanPhamDacTrungFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#HangHoaDKSanPhamDacTrungFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                HangHoaDKSanPhamDacTrungFn.loadfromDKSPDT(function () {
                    var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
                    HangHoaDKSanPhamDacTrungFn.Activeform();
                    $(newDlg).dialog({
                        title: 'Đăng ký sản phẩm đặc trưng',
                        width: 830,
                        height: 625,
                        buttons: {
                            'Lưu': function () {
                                HangHoaDKSanPhamDacTrungFn.saveDKSPDT(false, function () {
                                    HangHoaDKSanPhamDacTrungFn.clearformdkdv();
                                });
                            },
                            'Lưu và đóng': function () {
                                HangHoaDKSanPhamDacTrungFn.saveDKSPDT(false, function () {
                                    HangHoaDKSanPhamDacTrungFn.clearformdkdv();
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            HangHoaDKSanPhamDacTrungFn.clearformdkdv();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            HangHoaDKSanPhamDacTrungFn.popfndksp();
                            HangHoaDKSanPhamDacTrungFn.LoadThongTinSanPham(s);
                            HangHoaDKSanPhamDacTrungFn.LoadHotro();
                            HangHoaDKSanPhamDacTrungFn.LoadThanhToanGioiThieu(function () {
                                HangHoaDKSanPhamDacTrungFn.Mathtimefn();
                            });
                        }
                    });
                });
            }
        }
    },
    clearformdkdv: function () {
        var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
        var ID = $('.ID', newDlg);
        var TenSP = $('.TenSP', newDlg);
        var DanhMucSP = $('.DanhMucSP', newDlg);
        var NgayDangSP = $('.NgayDangSP', newDlg);
        var MaTinSP = $('.MaTinSP', newDlg);
        var ImgSP = $('.adm-upload-preview-img-60', newDlg);
        var LienHeDM = $('.LienHe-DanhMuc', newDlg);
        var HoTroDanhMuc = $('.HoTro-DanhMuc', newDlg);
        var ChuyenKhoanDM = $('.ChuyenKhoan-DanhMuc', newDlg);
        var ThanhToanDanhMuc = $('.ThanhToan-DanhMuc', newDlg);

        var SPDacTrungDanhMuc = $('.SPDacTrung-DanhMuc', newDlg);
        var GiaSPDacTrungDanhMuc = $('.GiaSPDacTrung-DanhMuc', newDlg);
        var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
        var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);
        var SoNgayDKSPDacTrung = $('.SoNgayDKSPDacTrung', newDlg);
        var TongTienDKSPDacTrung = $('.TongTien-DKSPDacTrung', newDlg);
        var GioiThieuDKSPDanhMuc = $('.GioiThieuDKSP-DanhMuc', newDlg);

        var ThongTinDangKySPDT = $('.ThongTinDangKySPDT', newDlg);
        var btnDKSPDT = $('.mdl-head-DKSPDT', newDlg);

        btnDKSPDT.show();
        ThongTinDangKySPDT.html('');
        SPDacTrungDanhMuc.html('');
        GiaSPDacTrungDanhMuc.html('');
        SoNgayDKSPDacTrung.html('');
        TongTienDKSPDacTrung.html('');
        GioiThieuDKSPDanhMuc.html('');
        NgayDKSPDacTrung.val('');
        NgayKTDKSPDacTrung.val('');

        ID.val('');
        ImgSP.attr('src', '');
        MaTinSP.html('');
        NgayDangSP.html('');
        TenSP.html('');
        DanhMucSP.html('');
        LienHeDM.html('');
        HoTroDanhMuc.html('');
        ChuyenKhoanDM.html('');
        ThanhToanDanhMuc.html('');

    },
    Activeform: function () {
        adm.styleButton();
        var tbBox = $('.thanhToan-box', '#DangKySanPhamDacTrung-DKDV-dlgNew');
        $('.thanhToan-menu-item', tbBox).eq(0).addClass('thanhToan-menu-item-active');
        $('.thanhToan-content-box', tbBox).eq(0).addClass('thanhToan-content-box-active');
        $('.thanhToan-menu-item', tbBox).click(function () {
            var item = $(this);
            var _ref = item.attr('_ref');
            $('.thanhToan-menu-item-active', tbBox).removeClass('thanhToan-menu-item-active');
            item.addClass('thanhToan-menu-item-active');
            $('.thanhToan-content-box-active', tbBox).removeClass('thanhToan-content-box-active');
            $('.thanhToan-content-box[_ref=""' + _ref + '""]', tbBox).addClass('thanhToan-content-box-active');
        });
    },
    LoadThongTinSanPham: function (ID) {
        var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
        adm.loading('Lấy dữ liệu gian hàng');
        $.ajax({
            url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=edit',
            dataType: 'script',
            data: {
                'ID': ID
            },
            success: function (dt) {
                adm.loading(null);
                data = eval(dt);
                var ID = $('.ID', newDlg);
                var TenSP = $('.TenSP', newDlg);
                var DanhMucSP = $('.DanhMucSP', newDlg);
                var NgayDangSP = $('.NgayDangSP', newDlg);
                var MaTinSP = $('.MaTinSP', newDlg);
                var ImgSP = $('.adm-upload-preview-img-60', newDlg);
                var ID = $('.ID', newDlg);

                var ThongTinDangKySPDT = $('.ThongTinDangKySPDT', newDlg);

                var btnDKSPDT = $('.mdl-head-DKSPDT', newDlg);

                ID.val(data.ID);
                TenSP.append(data.Ten);
                DanhMucSP.append(data._DM_Ten);
                var __NgayDangSP = new Date(data.NgayTao);
                var _NgayDangSP = __NgayDangSP.getDate() + '/' + (__NgayDangSP.getMonth() + 1) + '/' + __NgayDangSP.getFullYear();
                NgayDangSP.append(_NgayDangSP);
                MaTinSP.append('SP' + data.ID);
                if (data.Anh != '') {
                    $(ImgSP).attr('src', '../up/i/' + data.Anh + '?ref=' + Math.random());
                }

                if (eval(data.Hot1) == true) {
                    btnDKSPDT.hide();
                    var _TuNgay = new Date(data.NgayBD_DK_SPDT);
                    var TuNgay = _TuNgay.getDate() + '/' + (_TuNgay.getMonth() + 1) + '/' + _TuNgay.getFullYear();
                    var _DenNgay = new Date(data.NgayKT_DK_SPDT);
                    var DenNgay = _DenNgay.getDate() + '/' + (_DenNgay.getMonth() + 1) + '/' + _DenNgay.getFullYear();
                    var btnHuyBo = '<a style="margin-left:200px;color:red;" class="mdl-head-HUYDKSP" href="javascript:" onclick="HangHoaDKSanPhamDacTrungFn.HuyDangKyDichVu();"">Hủy</a>';
                    ThongTinDangKySPDT.append('Bạn đã đăng ký sản phẩm đặc trưng từ <span style="color:red;"> ' + TuNgay + '</span> đến <span style="color:red;"> ' + DenNgay +'</span>' +btnHuyBo);
                    adm.styleButton();

                }
            }
        });
    },
    LoadHotro: function () {
        $.ajax({
            url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'LIENHE'
            },
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);
                var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
                var LienHeDM = $('.LienHe-DanhMuc', newDlg);
                var HoTroDanhMuc = $('.HoTro-DanhMuc', newDlg);
                HoTroDanhMuc.append('<b>HỖ TRỢ</b><br/>');
                $.each(data, function (i, item) {
                    if (item.Ma == 'LH_CHUNG') {
                        LienHeDM.append(item.Description);
                    };
                    if (item.Ma == 'LH_HOTRO') {
                        var src = 'http://opi.yahoo.com/online?u=' + item.GiaTri + '&amp;m=g&amp;t=1';
                        HoTroDanhMuc.append('<br/><b>' + item.Ten + '</b>' + '<br/>' + '<a href="ymsgr:sendIM?' + item.GiaTri + '"><img border="0" src="' + src + '" alt="Hỗ trợ trực tuyến"></a><br />' + 'Mobile:<span style="color:red;"> ' + item.KyHieu + '</span><br/>');
                    };
                });
            }
        });
    },
    sendLienHe: function (validate, fn) {
        var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
        var spbMsg = $('.admMsg', newDlg);
        var txtNoiDung = $('.txtNoiDungLienHe', newDlg);
        var txtID = $('.ID', newDlg);
        var txtTieuDeLienHe = $('.txtTieuDeLienHe', newDlg)
        var tieude = $(txtTieuDeLienHe).val();
        var noidung = $(txtNoiDung).val();
        var ID = txtID.val();

        if (noidung == '') { alert('bạn phải điền nội dung'); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang gửi liên hệ');
        $.ajax({
            url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=lienHe',
            dataType: 'script',
            data: {
                'ID': ID,
                'NoiDungLienHe': noidung,
                'msgtitle': tieude
            },
            success: function (dt) {
                adm.loading(null);
                txtNoiDung.val('');
                txtTieuDeLienHe.val('');
                alert('Bạn đã gửi liên hệ thành công');
            }
        });
    },
    LoadThanhToanGioiThieu: function (fn) {
        $.ajax({
            url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'THANHTOAN'
            },
            success: function (dt) {
                var data = eval(dt);
                var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
                var ChuyenKhoanDM = $('.ChuyenKhoan-DanhMuc', newDlg);
                var ThanhToanDanhMuc = $('.ThanhToan-DanhMuc', newDlg);

                $.each(data, function (i, item) {
                    if (item.Ma == 'TT_TAIKHOAN') {
                        ChuyenKhoanDM.append(item.Description);
                    };
                    if (item.Ma == 'TT_HINHTHUC') {
                        ThanhToanDanhMuc.append(item.Description);
                    }
                });
            }
        });
        $.ajax({
            url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'SP_DICHVU'
            },
            success: function (dt) {
                var data = eval(dt);
                var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
                var SPDacTrungDanhMuc = $('.SPDacTrung-DanhMuc', newDlg);
                var GiaSPDacTrungDanhMuc = $('.GiaSPDacTrung-DanhMuc', newDlg);
                var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
                var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);
                var SoNgayDKSPDacTrung = $('.SoNgayDKSPDacTrung', newDlg);
                var TongTienDKSPDacTrung = $('.TongTien-DKSPDacTrung', newDlg);
                var GioiThieuDKSPDanhMuc = $('.GioiThieuDKSP-DanhMuc', newDlg);

                $.each(data, function (i, item) {
                    if (item.Ma == 'SP_DV_GIOITHIEU') {
                        GioiThieuDKSPDanhMuc.append(item.Description);
                    }
                    if (item.Ma == 'SP_DV_DACTRUNG') {
                        GiaSPDacTrungDanhMuc.append(item.GiaTri);
                        GiaSPDacTrungDanhMuc.attr('_gia', item.GiaTri);
                        SPDacTrungDanhMuc.append(item.Description);
                    }
                });
                if (typeof (fn) == 'function') { fn(); }
            }
        });
    },
    popfndksp: function () {
        var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
        var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
        var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);
        NgayDKSPDacTrung.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayKTDKSPDacTrung.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    Mathtimefn: function () {
        var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');

        var GiaSPDacTrungDanhMuc = $('.GiaSPDacTrung-DanhMuc', newDlg);
        var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
        var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);
        var SoNgayDKSPDacTrung = $('.SoNgayDKSPDacTrung', newDlg);
        var TongTienDKSPDacTrung = $('.TongTien-DKSPDacTrung', newDlg);

        var _DateNow = new Date();
        var _Dateweek = new Date();
        _Dateweek.setDate(_Dateweek.getDate() + 7);

        var Dateweek = _Dateweek.getDate() + '/' + (_Dateweek.getMonth() + 1) + '/' + _Dateweek.getFullYear();
        var DateNow = _DateNow.getDate() + '/' + (_DateNow.getMonth() + 1) + '/' + _DateNow.getFullYear();

        NgayDKSPDacTrung.val(DateNow);
        NgayKTDKSPDacTrung.val(Dateweek);

        SoNgayDKSPDacTrung.append('( 1 tuần )');
        var GiaDkSPDacTrungTuan = $(GiaSPDacTrungDanhMuc).attr('_gia');
        ////console.log(GiaDkSPDacTrungTuan);
        TongTienDKSPDacTrung.append(GiaDkSPDacTrungTuan);

        NgayDKSPDacTrung.change(function () {
            HangHoaDKSanPhamDacTrungFn.InputChange(NgayDKSPDacTrung, NgayKTDKSPDacTrung, SoNgayDKSPDacTrung, TongTienDKSPDacTrung, GiaSPDacTrungDanhMuc);
        });
        NgayKTDKSPDacTrung.change(function () {
            HangHoaDKSanPhamDacTrungFn.InputChange(NgayDKSPDacTrung, NgayKTDKSPDacTrung, SoNgayDKSPDacTrung, TongTienDKSPDacTrung, GiaSPDacTrungDanhMuc);
        });
    },
    InputChange: function (_NgayBD, _NgayKT, _SoNgay, _TongTien, _GiaThanhVien) {
        var NgayBD = $(_NgayBD);
        var NgayKT = $(_NgayKT);
        var SoNgay = $(_SoNgay);
        var TongTien = $(_TongTien);
        var GiaThanhVien = $(_GiaThanhVien);

        SoNgay.html('');
        TongTien.html('');

        var convertNgayBD = HangHoaDKSanPhamDacTrungFn.convertDate(NgayBD.val(), '/');
        var convertNgayKT = HangHoaDKSanPhamDacTrungFn.convertDate(NgayKT.val(), '/');
        var Datecount = HangHoaDKSanPhamDacTrungFn.dateDiff('d', convertNgayBD, convertNgayKT);
        var convertweek;

        if (parseInt(Datecount) % 7 == 0) {
            convertweek = parseInt(parseInt(Datecount) / 7);
            SoNgay.append('(' + convertweek + 'tuần )');
        }
        else {
            convertweek = parseInt(parseInt(Datecount) / 7) + 1;
            var countDateDu = parseInt(Datecount) % 7;

            convertNgayKT = new Date(convertNgayKT);
            convertNgayKT.setDate(convertNgayKT.getDate() + (7 - countDateDu));
            SoNgay.append('(' + convertweek + 'tuần )');
            var convertNgayKTNew = convertNgayKT.getDate() + '/' + (convertNgayKT.getMonth() + 1) + '/' + convertNgayKT.getFullYear();
            _NgayKT.val(convertNgayKTNew);
        }
        var giatt = parseInt(GiaThanhVien.attr('_gia'));
        var tongtientt = parseInt(convertweek) * giatt;
        TongTien.append(tongtientt);
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
                    i_Number = Math.round((i_Year * 12 + i_Month) / 3);
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
    SaveDKSPDT: function (validate, fn) {
        var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
        var dkspdt = 'False';

        var ID = $('.ID', newDlg);
        var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
        var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);

        var btnDKSPDT = $('.mdl-head-DKSPDT', newDlg);

        var _ID = ID.val();
        var _NgayKTDKSPDacTrung = NgayKTDKSPDacTrung.val();
        var _NgayDKSPDacTrung = NgayDKSPDacTrung.val();
        var err = '';

        var convertDateNgayKTDKSPDacTrung = HangHoaDKSanPhamDacTrungFn.convertDate(NgayKTDKSPDacTrung.val(), '/');
        var convertDateNgayDKSPDacTrung = HangHoaDKSanPhamDacTrungFn.convertDate(NgayDKSPDacTrung.val(), '/');
        if (Date.parse(convertDateNgayKTDKSPDacTrung) < Date.parse(convertDateNgayDKSPDacTrung)) {
            err += 'ngày kết thúc phải lớn hơn ngày đăng ký';
        }
        if (_NgayDKSPDacTrung == '') {
            err += 'Bạn phải điền ngày bắt đầu';
        }
        if (_NgayKTDKSPDacTrung == '') {
            err += 'Bạn phải điền ngày hết hạn';
        }
        if (_NgayDKSPDacTrung != '' && _NgayKTDKSPDacTrung != '' && (Date.parse(convertDateNgayKTDKSPDacTrung) > Date.parse(convertDateNgayDKSPDacTrung))) {
            dkspdt = 'True';
        }
        if (err != '') { alert(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=DKSPDT',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'Hot1': dkspdt,
                'NgayDKSPDT': _NgayDKSPDacTrung,
                'NgayKTDKSPDT': _NgayKTDKSPDacTrung
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    btnDKSPDT.hide();
                    HangHoaDKSanPhamDacTrungFn.loadFormThongtinDk();
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    HuyDangKyDichVu: function () {
        var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
        var dkspdt = 'False';
        var _ID = $('.ID', newDlg);
        var ID = _ID.val();
        var btnHuyBo = $('.mdl-head-HUYDKSP', newDlg);
        var btnDKSPDT = $('.mdl-head-DKSPDT', newDlg);
        var ThongTinDangKySPDT = $('.ThongTinDangKySPDT', newDlg);
        if (confirm('Bạn có chắc chắn muốn hủy?')) {
            $.ajax({
                url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=DKSPDT',
                dataType: 'script',
                type: 'POST',
                data: {
                    'ID': ID,
                    'Hot1': dkspdt,
                    'NgayDKSPDT': '',
                    'NgayKTDKSPDT': ''
                },
                success: function (dt) {
                    adm.loading(null);
                    if (dt == '1') {
                        ThongTinDangKySPDT.html('');
                        btnDKSPDT.show();
                        
                    }
                    else {
                        spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                    }
                }
            });
        }
    },
    loadFormThongtinDk: function () {
        var newDlg = $('#DangKySanPhamDacTrung-DKDV-dlgNew');
        var ThongTinDangKySPDT = $('.ThongTinDangKySPDT', newDlg);
        var _ID = $('.ID', newDlg);
        //console.log('3');
        var ID = _ID.val();
        if (confirm('Bạn có chắc chắn muốn hủy?')) {
            $.ajax({
                url: HangHoaDKSanPhamDacTrungFn.urlDefault().toString() + '&subAct=edit',
                dataType: 'script',
                type: 'POST',
                data: {
                    'ID': ID
                },
                success: function (dt) {
                    var _TuNgay = new Date(data.NgayBD_DK_SPDT);
                    var TuNgay = _TuNgay.getDate() + '/' + (_TuNgay.getMonth() + 1) + '/' + _TuNgay.getFullYear();
                    var _DenNgay = new Date(data.NgayKT_DK_SPDT);
                    var DenNgay = _DenNgay.getDate() + '/' + (_DenNgay.getMonth() + 1) + '/' + _DenNgay.getFullYear();
                    var btnHuyBo = '<a style="margin-left:200px;color:red;" class="mdl-head-HUYDKSP" href="javascript:" onclick="HangHoaDKSanPhamDacTrungFn.HuyDangKyDichVu();"">Hủy</a>';
                    ThongTinDangKySPDT.append('Bạn đã đăng ký sản phẩm đặc trưng từ <span style="color:red;"> ' + TuNgay + '</span> đến <span style="color:red;">' + DenNgay + '</span>' + btnHuyBo);
                    adm.styleButton();
                }
            });
        }
    }
}
