GiaoThuongMoiFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.giaoThuong.Moi.Class1, cnn.plugin.giaoThuong'; },
    setup: function () { },
    thongbao: function () {
        var thongbao = $('.ThongBaoms');
        thongbao.val('Bạn phải đăng ký gian hàng mới có thể sử dụng chức năng này');
        alert('Bạn phải đăng ký gian hàng mới có thể sử dụng chức năng này');
    },
    loadgrid: function () {

        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        var initialized = [false, false];
        $('#GiaoThuongMoiFnMdl-subMdl').tabs({ show: function (event, ui) {
            if (ui.index == 0 && !initialized[0]) {
                $('#GiaoThuongMoiFnMdl-subLangMdl-List').jqGrid({
                    url: GiaoThuongMoiFn.urlDefault().toString(),
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'LangBased', 'Lang', 'Ảnh', 'Tên', 'Mô tả', 'Danh mục', 'Xuất xứ', 'Ngày ĐK', 'Username', 'Publish', 'Active'],
                    colModel: [
                        { name: 'GT_ID', key: true, sortable: true, hidden: true },
                        { name: 'GT_LangBased', key: true, sortable: true, hidden: true },
                        { name: 'GT_Lang', key: true, width: 20, sortable: true },
                        { name: 'GT_Anh', width: 40, sortable: true, align: "center" },
                        { name: 'GT_Ten', width: 50, resizable: true, sortable: true },
                        { name: 'GT_NoiDung', width: 80, resizable: true, sortable: true },
                        { name: 'GT_DM_ID', width: 40, sortable: true, align: "center" },
                        { name: 'GT_XuatXu', width: 30, resizable: true, sortable: true },
                        { name: 'GT_NgayTao', width: 30, resizable: true, sortable: true },
                        { name: 'GT_NguoiTao', width: 50, resizable: true, sortable: true },
                        { name: 'GT_Publish', width: 10, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                        { name: 'GT_Active', width: 10, resizable: true, sortable: true, align: "center", formatter: 'checkbox' }
                    ],
                    caption: 'Ngôn ngữ',
                    autowidth: true,
                    sortname: 'GT_NgayTao',
                    sortorder: 'DESC',
                    rowNum: 10000,
                    onSelectRow: function (rowid) {
                    },
                    loadComplete: function () {
                        adm.loading(null);
                    }
                });
            }
            initialized[ui.index] = true;
        }
        });
        var DMID = $('.mdl-head-search-GiaoThuongMoi');
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $('#GiaoThuongMoiFnMdl-List').jqGrid({
                    url: GiaoThuongMoiFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'LangBased', 'Lang', 'Ảnh', 'Tên', 'Mô tả', 'Danh mục', 'Xuất xứ', 'Ngày ĐK', 'Username', 'Publish', 'Active'],
                    colModel: [
                        { name: 'GT_ID', key: true, sortable: true, hidden: true },
                        { name: 'GT_LangBased', key: true, sortable: true, hidden: true },
                        { name: 'GT_Lang', key: true, width: 20, sortable: true },
                        { name: 'GT_Anh', width: 40, sortable: true, align: "center" },
                        { name: 'GT_Ten', width: 50, resizable: true, sortable: true },
                        { name: 'GT_NoiDung', width: 80, resizable: true, sortable: true },
                        { name: 'GT_DM_ID', width: 40, sortable: true, align: "center" },
                        { name: 'GT_XuatXu', width: 30, resizable: true, sortable: true },
                        { name: 'GT_NgayTao', width: 30, resizable: true, sortable: true },
                        { name: 'GT_NguoiTao', width: 50, resizable: true, sortable: true },
                        { name: 'GT_Publish', width: 10, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                        { name: 'GT_Active', width: 10, resizable: true, sortable: true, align: "center", formatter: 'checkbox' }
                    ],
                    caption: 'Danh sách',
                    autowidth: true,
                    sortname: 'GT_NgayTao',
                    sortorder: 'DESC',
                    rowNum: 50,
                    rowList: [50, 100, 200, 300],
                    multiselect: true,
                    pager: $('#GiaoThuongMoiFnMdl-Pager'),
                    onSelectRow: function (rowid) {
                        GiaoThuongMoiFn.loadSubGrid(rowid);
                    },
                    loadComplete: function () {
                        adm.loading(null);
                        var txtfilter = $('.mdl-head-filterDanhMucGiaoThuongMoi', '#GiaoThuongMoiFnMdl-head');
                        var txtfilterTINH = $('.mdl-head-filterKhuVucGiaoThuongMoi', '#GiaoThuongMoiFnMdl-head');
                        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                            danhmuc.autoCompleteLangBased("", "SP_NHOM", txtfilter, function (event, ui) {
                                $(txtfilter).attr('_value', ui.item.id);
                                GiaoThuongMoiFn.search();
                            });
                            $(txtfilter).unbind('click').click(function () {
                                $(txtfilter).autocomplete('search', '');
                            });
                            danhmuc.autoCompleteLangBased("", "KV-TINH", txtfilterTINH, function (event, ui) {
                                $(txtfilterTINH).attr('_value', ui.item.id);
                                GiaoThuongMoiFn.search();
                            });
                            $(txtfilterTINH).unbind('click').click(function () {
                                $(txtfilterTINH).autocomplete('search', '');
                            });
                        });

                    }

                });
                var filterLoaiDanhMucID = $('.mdl-head-filterDanhMucGiaoThuongMoi', '#GiaoThuongMoiFnMdl-head');
                var filterTINHID = $('.mdl-head-filterKhuVucGiaoThuongMoi', '#GiaoThuongMoiFnMdl-head');
                var searchTxt = $('.mdl-head-search-GiaoThuongMoi', '#GiaoThuongMoiFnMdl-head');

                $(filterLoaiDanhMucID).keyup(function () {
                    if ($(filterLoaiDanhMucID).val() == '') {
                        $(filterLoaiDanhMucID).attr('_value', '');
                        if ($(searchTxt).val() == 'Tìm kiếm tin') {
                            $(searchTxt).val('');
                        }
                        GiaoThuongMoiFn.search();
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
                        GiaoThuongMoiFn.search();
                        if ($(searchTxt).val() == '') {
                            $(searchTxt).val('Tìm kiếm tin');
                        }
                    }
                });
                $(searchTxt).keyup(function () {
                    GiaoThuongMoiFn.search();
                });
                adm.watermark(searchTxt, 'Tìm kiếm tin', function () {
                    $(searchTxt).val('');
                    GiaoThuongMoiFn.search();
                    $(searchTxt).val('Tìm kiếm tin');
                });
                adm.watermark(filterLoaiDanhMucID, 'Gõ tên mục tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    GiaoThuongMoiFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                adm.watermark(filterTINHID, 'Gõ tên Khu vực để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin') {
                        $(searchTxt).val('');
                    }
                    GiaoThuongMoiFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin');
                    }
                });
                var muaban = $('#GiaoThuongMoiFnMdl-muaban');
                $(muaban).find('option').remove();
                $(muaban).prepend('<option value="True"> Chào mua</option>');
                $(muaban).prepend('<option value="False">Chào bán</option>');
                $(muaban).prepend('<option value="">--Chọn loại tin--</option>');
                $(muaban).val('--Chọn loại tin--');

                var TrangThai = $('#GiaoThuongMoiFnMdl-TrangThai');
                $(TrangThai).find('option').remove();
                $(TrangThai).prepend('<option value="2">Đã duyệt</option>');
                $(TrangThai).prepend('<option value="3">Chưa Duyệt</option>');
                $(TrangThai).prepend('<option value="1">Quá hạn</option>');
                $(TrangThai).prepend('<option value="">--Trạng thái--</option>');
                $(TrangThai).val('--Trạng thái--');


                var changeLangBtn = $('#GiaoThuongMoiFnMdl-changeLangSlt');
                $(changeLangBtn).find('option').remove();
                $.each(LangArr, function (i, item) {
                    if (item.Active) {
                        Lang = item.Ma;
                    }
                    $(changeLangBtn).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                });
                $(changeLangBtn).val('Tiếng Việt');
                if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }
            }
            );
        }
        );
    },
    loadSubGrid: function (_id) {
        if (_id != null) {
            adm.loading('Đang lấy dữ liệu ngôn ngữ phụ');
            $('#GiaoThuongMoiFnMdl-subLangMdl-List').jqGrid('setGridParam', {
                url: GiaoThuongMoiFn.urlDefault().toString() + "&subAct=getByLangBasedId" + "&LangBased_ID=" + _id
                , loadComplete: function () {
                    adm.loading(null);
                }
            }).trigger("reloadGrid");
        }
    },
    loadSubGridByLangBase: function () {

    },
    filterfn: function (_active, _pub) {
        $('#GiaoThuongMoiFnMdl-List').jqGrid('setGridParam', { url: GiaoThuongMoiFn.urlDefault().toString() + "&subAct=get" + "&Active=" + _active + "&Publish=" + _pub }).trigger("reloadGrid");
    },
    EditLang: function () {
        var s = '';
        if (jQuery('#GiaoThuongMoiFnMdl-subLangMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#GiaoThuongMoiFnMdl-subLangMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                GiaoThuongMoiFn.loadHtml(function () {
                    var newDlg = $('#GiaoThuongMoiFnMdl-dlgNew');
                    GiaoThuongMoiFn.popfn();
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 750,
                        height: 550,
                        buttons: {
                            'Lưu': function () {
                                GiaoThuongMoiFn.save(false, function () {
                                    GiaoThuongMoiFn.clearform();
                                    jQuery('#GiaoThuongMoiFnMdl-subLangMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Lưu và đóng': function () {
                                GiaoThuongMoiFn.save(false, function () {
                                    GiaoThuongMoiFn.clearform();
                                    $(newDlg).dialog('close');
                                    jQuery('#GiaoThuongMoiFnMdl-subLangMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            GiaoThuongMoiFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            $.ajax({
                                url: GiaoThuongMoiFn.urlDefault().toString() + '&subAct=edit',
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
                                    var LangSlt = $('.Lang', newDlg);
                                    LangSlt.attr('disabled', 'disabled');

                                    var SltMuaBan = $('.SltMuaBan', newDlg)
                                    //var ckbMua;
                                    var imgAnh = $('.adm-upload-preview-img', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var NgayHetHan = $('.NgayHetHan', newDlg);
                                    var XuatXu = $('.XuatXu', newDlg);
//                                    var Active = $('.Active', newDlg);
                                    var Publish = $('.Publish', newDlg);
//                                    var Hot1 = $('.Hot1', newDlg);
//                                    var Hot2 = $('.Hot2', newDlg);
//                                    var Hot3 = $('.Hot3', newDlg);
//                                    var Hot4 = $('.Hot4', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    DM_ID.val(dt._DM_Ten);
                                    DM_ID.attr('_value', dt.DM_ID);
                                    DM_KV.val(dt._Tinh_Ten)
                                    DM_KV.attr('_value', dt.KV_ID);


                                    $(SltMuaBan).attr('value', dt.Mua);

                                    LangSlt.val(dt.Lang);
                                    if (dt.LangBased) {
                                        $(LangBased).attr('checked', 'checked');
                                    }
                                    else {
                                        $(LangBased).removeAttr('checked');
                                    }
                                    LangBased_ID.val(dt.LangBased_ID);
                                    Ten.val(dt.Ten);
                                    MoTa.val(dt.MoTa);
                                    NoiDung.val(dt.NoiDung);
                                    XuatXu.val(dt.XuatXu);
                                    $(lblAnh).attr('ref', dt.Anh);
                                    if (dt.Anh != '') {
                                        $(imgAnh).attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());
                                    }

                                    var __NgayHetHan = new Date(dt.NgayHetHan);
                                    var _NgayHetHan = __NgayHetHan.getDate() + '/' + (__NgayHetHan.getMonth() + 1) + '/' + __NgayHetHan.getFullYear();
                                    NgayHetHan.val(_NgayHetHan);
//                                    if (dt.Active) { Active.attr('checked', 'checked'); } else { Active.removeAttr('checked'); }
                                    if (dt.Publish) { Publish.attr('checked', 'checked'); } else { Publish.removeAttr('checked'); }
//                                    if (dt.Hot1) { Hot1.attr('checked', 'checked'); } else { Hot1.removeAttr('checked'); }
//                                    if (dt.Hot2) { Hot2.attr('checked', 'checked'); } else { Hot2.removeAttr('checked'); }
//                                    if (dt.Hot3) { Hot3.attr('checked', 'checked'); } else { Hot3.removeAttr('checked'); }
//                                    if (dt.Hot4) { Hot4.attr('checked', 'checked'); } else { Hot4.removeAttr('checked'); }
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    DelLang: function () {
        var s = '';
        if (jQuery('#GiaoThuongMoiFnMdl-subLangMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#GiaoThuongMoiFnMdl-subLangMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: GiaoThuongMoiFn.urlDefault().toString() + '&subAct=del',
                        dataType: 'script',
                        data: { 'ID': s },
                        success: function (dt) {
                            jQuery('#GiaoThuongMoiFnMdl-subLangMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-GiaoThuongMoi');
        var searchDM = $('.mdl-head-filterDanhMucGiaoThuongMoi');
        var searchTINH = $('.mdl-head-filterKhuVucGiaoThuongMoi');
        var _Lang = $('#GiaoThuongMoiFnMdl-changeLangSlt').val();
        var filtermuaban = $('#GiaoThuongMoiFnMdl-muaban');
        var filterTrangThai = $('#GiaoThuongMoiFnMdl-TrangThai');
        var q = filterDM.val();
        if (q == 'Tìm kiếm tin') {
            q = '';
        }
        var dm = $(searchDM).attr('_value');
        var tinh = $(searchTINH).attr('_value');
        var muaban = $(filtermuaban).attr('value');
        var trangthai = $(filterTrangThai).attr('value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#GiaoThuongMoiFnMdl-List').jqGrid('setGridParam', { url: GiaoThuongMoiFn.urlDefault().toString() + '&subAct=get&dm=' + dm + '&dmkv=' + tinh + '&Lang=' + _Lang + '&q=' + q + '&muaban=' + muaban + '&trangthai=' + trangthai }).trigger('reloadGrid');
        }, 500);
    },
    add: function () {
        GiaoThuongMoiFn.loadHtml(function () {
            var newDlg = $('#GiaoThuongMoiFnMdl-dlgNew');
            var LangSlt = $('.Lang', newDlg);
            LangSlt.removeAttr('disabled');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 750,
                height: 550,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        GiaoThuongMoiFn.save(false, function () {
                            GiaoThuongMoiFn.clearform();
                            jQuery('#GiaoThuongMoiFnMdl-List').trigger('reloadGrid');
                        });
                    },
                    'Lưu và đóng': function () {
                        GiaoThuongMoiFn.save(false, function () {
                            $(newDlg).dialog('close');
                            jQuery('#GiaoThuongMoiFnMdl-List').trigger('reloadGrid');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    GiaoThuongMoiFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    GiaoThuongMoiFn.clearform();
                    GiaoThuongMoiFn.popfn();
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#GiaoThuongMoiFnMdl-dlgNew');
        var DM_ID = $('.DM_ID', newDlg);
        var DM_KV = $('.DM_KV', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var NgayHetHan = $('.NgayHetHan', newDlg);
        var sltmuaban = $('.SltMuaBan', newDlg);

        $(sltmuaban).find('option').remove();
        $(sltmuaban).prepend('<option value="true"> Chào mua</option>');
        $(sltmuaban).prepend('<option value="false">Chào bán</option>');
        var XuatXu = $('.XuatXu',newDlg);
        danhmuc.autoCompleteLangBased('', 'KV-XUATXU', XuatXu, function (event, ui) {
            $(XuatXu).attr('_value', ui.item.id);
        });
        $(XuatXu).unbind('click').click(function () { $(XuatXu).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'SP_NHOM', DM_ID, function (event, ui) {
            $(DM_ID).attr('_value', ui.item.id);
        });
        $(DM_ID).unbind('click').click(function () { $(DM_ID).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'KV-TINH', DM_KV, function (event, ui) {
            $(DM_KV).attr('_value', ui.item.id);
        });
        $(DM_KV).unbind('click').click(function () { $(DM_KV).autocomplete('search', ''); });

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
        $(LangSlt).val('');
        $('.NgayHetHan', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    loadHtml: function (fn) {
        var dlg = $('#GiaoThuongMoiFnMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.giaoThuong.Moi.htm.htm")%>',
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
    edit: function () {
        var s = '';
        if (jQuery('#GiaoThuongMoiFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#GiaoThuongMoiFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                GiaoThuongMoiFn.loadHtml(function () {
                    var newDlg = $('#GiaoThuongMoiFnMdl-dlgNew');
                    var LangSlt = $('.Lang', newDlg);
                    LangSlt.removeAttr('disabled');
                    GiaoThuongMoiFn.popfn();
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 750,
                        height: 550,
                        buttons: {
                            'Lưu': function () {
                                GiaoThuongMoiFn.save(false, function () {
                                    GiaoThuongMoiFn.clearform();
                                    jQuery('#GiaoThuongMoiFnMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Lưu và đóng': function () {
                                GiaoThuongMoiFn.save(false, function () {
                                    GiaoThuongMoiFn.clearform();
                                    $(newDlg).dialog('close');
                                    jQuery('#GiaoThuongMoiFnMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            GiaoThuongMoiFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            $.ajax({
                                url: GiaoThuongMoiFn.urlDefault().toString() + '&subAct=edit',
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
                                    var LangSlt = $('.Lang', newDlg);
                                    //var ckbMua = $('.ckbMua', newDlg);
                                    var SltMuaBan = $('.SltMuaBan', newDlg);

                                    var imgAnh = $('.adm-upload-preview-img', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var NgayHetHan = $('.NgayHetHan', newDlg);
                                    var XuatXu = $('.XuatXu', newDlg);
//                                    var Active = $('.Active', newDlg);
                                    var Publish = $('.Publish', newDlg);
//                                    var Hot1 = $('.Hot1', newDlg);
//                                    var Hot2 = $('.Hot2', newDlg);
//                                    var Hot3 = $('.Hot3', newDlg);
//                                    var Hot4 = $('.Hot4', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    DM_ID.val(dt._DM_Ten);
                                    DM_ID.attr('_value', dt.DM_ID);
                                    DM_KV.val(dt._Tinh_Ten)
                                    DM_KV.attr('_value', dt.KV_ID);
                                    $(SltMuaBan).attr('value', dt.Mua);
                                    LangSlt.val(dt.Lang);
                                    if (dt.LangBased) {
                                        $(LangBased).attr('checked', 'checked');
                                    }
                                    else {
                                        $(LangBased).removeAttr('checked');
                                    }
                                    LangBased_ID.val(dt.LangBased_ID);
                                    Ten.val(dt.Ten);
                                    MoTa.val(dt.MoTa);
                                    NoiDung.val(dt.NoiDung);
                                    XuatXu.val(dt.XuatXu);
                                    $(lblAnh).attr('ref', dt.Anh);
                                    if (dt.Anh != '') {
                                        $(imgAnh).attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());
                                    }

                                    var __NgayHetHan = new Date(dt.NgayHetHan);
                                    var _NgayHetHan = __NgayHetHan.getDate() + '/' + (__NgayHetHan.getMonth() + 1) + '/' + __NgayHetHan.getFullYear();
                                    NgayHetHan.val(_NgayHetHan);
//                                    if (dt.Active) { Active.attr('checked', 'checked'); } else { Active.removeAttr('checked'); }
                                    if (dt.Publish) { Publish.attr('checked', 'checked'); } else { Publish.removeAttr('checked'); }
//                                    if (dt.Hot1) { Hot1.attr('checked', 'checked'); } else { Hot1.removeAttr('checked'); }
//                                    if (dt.Hot2) { Hot2.attr('checked', 'checked'); } else { Hot2.removeAttr('checked'); }
//                                    if (dt.Hot3) { Hot3.attr('checked', 'checked'); } else { Hot3.removeAttr('checked'); }
//                                    if (dt.Hot4) { Hot4.attr('checked', 'checked'); } else { Hot4.removeAttr('checked'); }
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#GiaoThuongMoiFnMdl-dlgNew');
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
        var LangSlt = $('.Lang', newDlg);
        var _Lang = LangSlt.val();
        var Langtemp;

        var SltMuaBan = $('.SltMuaBan', newDlg);

        var _ckbMua = SltMuaBan.attr('value');

        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var _Anh = lblAnh.attr('ref');
        var Ten = $('.Ten', newDlg);
        var _Ten = Ten.val();
        var MoTa = $('.MoTa', newDlg);
        var _MoTa = MoTa.val();
        var NoiDung = $('.NoiDung', newDlg);
        var _NoiDung = NoiDung.val();
        var NgayHetHan = $('.NgayHetHan', newDlg);
        var _NgayHetHan = NgayHetHan.val();
        var XuatXu = $('.XuatXu', newDlg);
        var _XuatXu = XuatXu.val();
//        var Active = $('.Active', newDlg);
//        var _Active = Active.is(':checked');
        var Publish = $('.Publish', newDlg);
        var _Publish = Publish.is(':checked');
//        var Hot1 = $('.Hot1', newDlg);
//        var _Hot1 = Hot1.is(':checked');
//        var Hot2 = $('.Hot2', newDlg);
//        var _Hot2 = Hot2.is(':checked');
//        var Hot3 = $('.Hot3', newDlg);
//        var _Hot3 = Hot3.is(':checked');
//        var Hot4 = $('.Hot4', newDlg);
//        var _Hot4 = Hot4.is(':checked');
        var spbMsg = $('.admMsg', newDlg);

        var err = '';
        if (_DM_ID == '') { err += 'Chọn danh mục<br/>'; };
        if (_DM_KV == '') { err += 'Chọn Khu vực<br/>'; };
        if (_Ten == '') { err += 'Nhập tên<br/>'; };
        if (_NgayHetHan == '') { err += 'Nhập Ngày hết hạn<br/>'; };
        if (!_LangBased) { if (_Lang == Lang) { err += 'Chọn ngôn ngữ khác'; }; }
        else { if (_Lang != Lang) { err += 'Bạn cần chọn ngôn ngữ gốc ' + Lang; }; }

        if (_LangBased_ID != '' && eval(_LangBased) == false) {
            $.ajax({
                url: GiaoThuongMoiFn.urlDefault().toString() + '&subAct=CountLang',
                dataType: 'script',
                data: {
                    'ID': _LangBased_ID,
                    'Lang': _Lang
                },
                success: function (_dt) {
                    adm.loading(null);
                    var dt = eval(_dt);
                    Langtemp = dt.COUNTLANG;
                    if (Langtemp != 0) {
                        err += 'Đã tồn tại ngôn ngữ này ' + _Lang + '<br/>';
                    }
                    if (err != '') { spbMsg.html(err); return false; }
                    if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
                    adm.loading('Đang lưu dữ liệu');
                    $.ajax({
                        url: GiaoThuongMoiFn.urlDefault().toString(),
                        dataType: 'script',
                        type: 'POST',
                        data: {
                            'subAct': 'save',
                            'ID': _ID,
                            'LangBased': _LangBased,
                            'LangBased_ID': _LangBased_ID,
                            'dm': _DM_ID,
                            'dmkv': _DM_KV,
                            'ckbMua': _ckbMua,
                            'Anh': _Anh,
                            'Ten': _Ten,
                            'Lang': _Lang,
                            'MoTa': _MoTa,
                            'NoiDung': _NoiDung,
                            'NgayHetHan': _NgayHetHan,
                            'XuatXu': _XuatXu,
//                            'Active': _Active,
                            'Publish': _Publish
//                            'Hot1': _Hot1,
//                            'Hot2': _Hot2,
//                            'Hot3': _Hot3,
//                            'Hot4': _Hot4

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

                }
            });
        }
        else {
            if (err != '') { spbMsg.html(err); return false; }
            if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
            adm.loading('Đang lưu dữ liệu');
            $.ajax({
                url: GiaoThuongMoiFn.urlDefault().toString(),
                dataType: 'script',
                type: 'POST',
                data: {
                    'subAct': 'save',
                    'ID': _ID,
                    'LangBased': _LangBased,
                    'LangBased_ID': _LangBased_ID,
                    'dm': _DM_ID,
                    'dmkv': _DM_KV,
                    'ckbMua': _ckbMua,
                    'Anh': _Anh,
                    'Ten': _Ten,
                    'Lang': _Lang,
                    'MoTa': _MoTa,
                    'NoiDung': _NoiDung,
                    'NgayHetHan': _NgayHetHan,
                    'XuatXu': _XuatXu,
//                    'Active': _Active,
                    'Publish': _Publish
//                    'Hot1': _Hot1,
//                    'Hot2': _Hot2,
//                    'Hot3': _Hot3,
//                    'Hot4': _Hot4

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
        }
    },
    del: function () {
        var s = '';
        s = jQuery('#GiaoThuongMoiFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa?')) {
                $.ajax({
                    url: GiaoThuongMoiFn.urlDefault().toString() + '&subAct=del',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery('#GiaoThuongMoiFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    },
    AddLang: function () {
        var s = '';
        if (jQuery('#GiaoThuongMoiFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#GiaoThuongMoiFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu mẩu tin');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var treedata = $("#GiaoThuongMoiFnMdl-List").jqGrid('getRowData', s);
                var _GT_ID = treedata.GT_ID;
                GiaoThuongMoiFn.loadHtml(function () {
                    var newDlg = $('#GiaoThuongMoiFnMdl-dlgNew');
                    var LangSlt = $('.Lang', newDlg);
                    LangSlt.removeAttr('disabled');
                    //removeAttr
                    $(newDlg).dialog({
                        title: 'Thêm mới',
                        width: 750,
                        height: 550,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                GiaoThuongMoiFn.save(false, function () {
                                    GiaoThuongMoiFn.clearform();
                                    jQuery('#GiaoThuongMoiFnMdl-subLangMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Lưu và đóng': function () {
                                GiaoThuongMoiFn.save(false, function () {
                                    $(newDlg).dialog('close');
                                    jQuery('#GiaoThuongMoiFnMdl-subLangMdl-List').trigger('reloadGrid');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            GiaoThuongMoiFn.clearform();
                        },
                        open: function () {

                            adm.styleButton();
                            GiaoThuongMoiFn.clearform();
                            GiaoThuongMoiFn.popfn();
                            var LangBased_ID = $('.LangBased_ID', newDlg);
                            LangBased_ID.val(s);
                            var LangBased = $('.LangBased', newDlg);
                            $(LangBased).removeAttr('checked');
                            $.ajax({
                                url: GiaoThuongMoiFn.urlDefault().toString(),
                                dataType: 'script',
                                data: {
                                    'subAct': 'edit',
                                    'ID': _GT_ID
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var LangBased_ID = $('.LangBased_ID', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var DM_KV = $('.DM_KV', newDlg);
                                    var LangSlt = $('.Lang', newDlg);

                                    var SltMuaBan = $('.SltMuaBan', newDlg);

                                    var imgAnh = $('.adm-upload-preview-img', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var NgayHetHan = $('.NgayHetHan', newDlg);
                                    var XuatXu = $('.XuatXu', newDlg);
//                                    var Active = $('.Active', newDlg);
                                    var Publish = $('.Publish', newDlg);
//                                    var Hot1 = $('.Hot1', newDlg);
//                                    var Hot2 = $('.Hot2', newDlg);
//                                    var Hot3 = $('.Hot3', newDlg);
//                                    var Hot4 = $('.Hot4', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    DM_ID.val(dt._DM_Ten);
                                    DM_ID.attr('_value', dt.DM_ID);
                                    DM_KV.val(dt._Tinh_Ten)
                                    DM_KV.attr('_value', dt.KV_ID);


                                    $(SltMuaBan).attr('value', dt.Mua);

                                    LangSlt.val(dt.Lang);

                                    LangBased_ID.val(dt.ID);
                                    Ten.val(dt.Ten);
                                    MoTa.val(dt.MoTa);
                                    NoiDung.val(dt.NoiDung);
                                    XuatXu.val(dt.XuatXu);
                                    $(lblAnh).attr('ref', dt.Anh);
                                    if (dt.Anh != '') {
                                        $(imgAnh).attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());
                                    }

                                    var __NgayHetHan = new Date(dt.NgayHetHan);
                                    var _NgayHetHan = __NgayHetHan.getDate() + '/' + (__NgayHetHan.getMonth() + 1) + '/' + __NgayHetHan.getFullYear();
                                    NgayHetHan.val(_NgayHetHan);
//                                    if (dt.Active) { Active.attr('checked', 'checked'); } else { Active.removeAttr('checked'); }
                                    if (dt.Publish) { Publish.attr('checked', 'checked'); } else { Publish.removeAttr('checked'); }
//                                    if (dt.Hot1) { Hot1.attr('checked', 'checked'); } else { Hot1.removeAttr('checked'); }
//                                    if (dt.Hot2) { Hot2.attr('checked', 'checked'); } else { Hot2.removeAttr('checked'); }
//                                    if (dt.Hot3) { Hot3.attr('checked', 'checked'); } else { Hot3.removeAttr('checked'); }
//                                    if (dt.Hot4) { Hot4.attr('checked', 'checked'); } else { Hot4.removeAttr('checked'); }
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    clearform: function () {
        var newDlg = $('#GiaoThuongMoiFnMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var LangBased = $('.LangBased', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var DM_KV = $('.DM_KV', newDlg);
        var LangSlt = $('.Lang', newDlg);
        //var ckbMua = $('.ckbMua', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var NgayHetHan = $('.NgayHetHan', newDlg);
        var XuatXu = $('.XuatXu', newDlg);
//        var Active = $('.Active', newDlg);
        var Publish = $('.Publish', newDlg);
//        var Hot1 = $('.Hot1', newDlg);
//        var Hot2 = $('.Hot2', newDlg);
//        var Hot3 = $('.Hot3', newDlg);
//        var Hot4 = $('.Hot4', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        ID.val('');
        LangBased.removeAttr('checked');
        LangBased_ID.val('');
        DM_ID.val('');
        DM_KV.val('');
        LangSlt.val('');
        //ckbMua.removeAttr('checked');
        imgAnh.attr('src', '');
        lblAnh.attr('ref', '');
        Ten.val('');
        MoTa.val('');
        NoiDung.val('');
        NgayHetHan.val('');
        XuatXu.val('');
//        Active.removeAttr('checked');
        Publish.removeAttr('checked');
//        Hot1.removeAttr('checked');
//        Hot2.removeAttr('checked');
//        Hot3.removeAttr('checked');
//        Hot4.removeAttr('checked');
        spbMsg.html('');
    },
    PheDuyet: function (active) {
        var s = '';
        s = jQuery('#GiaoThuongMoiFnMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để duyệt');
        }
        else {
            if (confirm('Bạn có chắc chắn duyệt các mẩu tin này?')) {
                $.ajax({
                    url: GiaoThuongMoiFn.urlDefault().toString() + '&subAct=PheDuyet' + '&active='+ active,
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery('#GiaoThuongMoiFnMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    }
}