var hangHoaFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.hangHoa.Class1, cnn.plugin.hangHoa'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu danh mục');
        var DMID = $('.mdl-head-search-hangHoa');
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                var initialized = [false, false];
                $('#hangHoaFnMdl-subMdl').tabs({ show: function (event, ui) {
                    if (ui.index == 0 && !initialized[0]) {
                        //console.log('2');
                        $('#hangHoaFnMdl-subLangMdl-List').jqGrid({
                            url: hangHoaFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
                            datatype: 'json',
                            loadui: 'disable',
                            colNames: ['ID', 'LangBased', 'Lang', 'Ảnh', 'Danh mục', 'Mã', 'Tên', 'Giá', 'Ngày tạo'],
                            colModel: [
                            { name: 'ID', key: true, sortable: true, hidden: true },
                            { name: 'LangBased', key: true, sortable: true, hidden: true },
                            { name: 'Lang', key: true, sortable: true, hidden: true },
                            { name: 'Anh', width: 10, sortable: true, align: "center" },
                            { name: 'DM_ID', width: 10, sortable: true, align: "center" },
                            { name: 'Ma', width: 10, resizable: true, sortable: true },
                            { name: 'Ten', width: 50, resizable: true, sortable: true },
                            { name: 'GNY', width: 10, resizable: true, sortable: true },
                            { name: 'NgayTao', width: 10, resizable: true, sortable: true }
                        ],
                            caption: 'Ngôn ngữ',
                            autowidth: true,
                            sortname: 'ID',
                            sortorder: 'asc',
                            rowNum: 10000,
                            onSelectRow: function (rowid) {
                            },
                            loadComplete: function () {
                                //console.log('2s');
                                adm.loading(null);
                            }
                        });
                    }
                    else if (ui.index == 1 && !initialized[1]) {
                        //console.log('3');

                        $('#hangHoaFnMdl-subNhomMdl-List').jqGrid({
                            url: hangHoaFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
                            datatype: 'json',
                            loadui: 'disable',
                            colNames: ['ID', 'LangBased', 'Lang', 'Ảnh', 'Danh mục', 'Mã', 'Tên', 'Giá', 'Ngày tạo'],
                            colModel: [
                        { name: 'ID', key: true, sortable: true, hidden: true },
                        { name: 'LangBased', key: true, sortable: true, hidden: true },
                        { name: 'Lang', key: true, sortable: true, hidden: true },
                        { name: 'Anh', width: 10, sortable: true, align: "center" },
                        { name: 'DM_ID', width: 10, sortable: true, align: "center" },
                        { name: 'Ma', width: 10, resizable: true, sortable: true },
                        { name: 'Ten', width: 50, resizable: true, sortable: true },
                        { name: 'GNY', width: 10, resizable: true, sortable: true },
                        { name: 'NgayTao', width: 10, resizable: true, sortable: true }
                    ],
                            caption: 'Nhóm',
                            autowidth: true,
                            sortname: 'ID',
                            sortorder: 'asc',
                            rowNum: 10000,
                            onSelectRow: function (rowid) {
                            },
                            loadComplete: function () {
                                adm.loading(null);
                            }
                        });
                    }
                    else if (ui.index == 2 && !initialized[2]) {
                        //console.log('4');
                        $('#hangHoaFnMdl-subAnhMdl-List').jqGrid({
                            url: hangHoaFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
                            datatype: 'json',
                            loadui: 'disable',
                            colNames: ['ID', 'LangBased', 'Lang', 'Ảnh', 'Danh mục', 'Mã', 'Tên', 'Giá', 'Ngày tạo'],
                            colModel: [
                        { name: 'ID', key: true, sortable: true, hidden: true },
                        { name: 'LangBased', key: true, sortable: true, hidden: true },
                        { name: 'Lang', key: true, sortable: true, hidden: true },
                        { name: 'Anh', width: 10, sortable: true, align: "center" },
                        { name: 'DM_ID', width: 10, sortable: true, align: "center" },
                        { name: 'Ma', width: 10, resizable: true, sortable: true },
                        { name: 'Ten', width: 50, resizable: true, sortable: true },
                        { name: 'GNY', width: 10, resizable: true, sortable: true },
                        { name: 'NgayTao', width: 10, resizable: true, sortable: true }
                    ],
                            caption: 'Ảnh',
                            autowidth: true,
                            sortname: 'ID',
                            sortorder: 'asc',
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
            $('#hangHoaFnMdl-List').jqGrid({
                url: hangHoaFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
                datatype: 'json',
                loadui: 'disable',
                colNames: ['ID', 'LangBased', 'Lang', 'Ảnh', 'Danh mục', 'Mã', 'Tên', 'Giá', 'Ngày tạo'],
                colModel: [
                        { name: 'ID', key: true, sortable: true, hidden: true },
                        { name: 'LangBased', key: true, sortable: true, hidden: true },
                        { name: 'Lang', key: true, sortable: true, hidden: true },
                        { name: 'Anh', width: 10, sortable: true, align: "center" },
                        { name: 'DM_ID', width: 10, sortable: true, align: "center" },
                        { name: 'Ma', width: 10, resizable: true, sortable: true },
                        { name: 'Ten', width: 50, resizable: true, sortable: true },
                        { name: 'GNY', width: 10, resizable: true, sortable: true },
                        { name: 'NgayTao', width: 10, resizable: true, sortable: true }
                    ],
                caption: 'Danh sách',
                autowidth: true,
                sortname: 'ID',
                sortorder: 'asc',
                rowNum: 10000,
                onSelectRow: function (rowid) {
                    hangHoaFn.loadSubGrid(rowid);
                },
                loadComplete: function () {
                    adm.loading(null);
                },
                pager: $('#hangHoaFnMdl-Pager')
            });
            //hangHoaFn.loadSubGrid(null);
            adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () { });
            adm.watermark(DMID, 'Gõ tên loại danh mục để lọc', function () {
            });
            //                var changeLangBtn = $('#hangHoaMdl-changeLangSlt');
            //                $(changeLangBtn).find('option').remove();
            //                $.each(LangArr, function (i, item) {
            //                    if (item.Active) {
            //                        Lang = item.Ma;
            //                    }
            //                    $(changeLangBtn).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
            //                });
            //                $(changeLangBtn).val(Lang);
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
        if (jQuery('#hangHoaFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#hangHoaFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                //                var treedata = $("#hangHoaFnMdl-List").jqGrid('getRowData', s);
                //                var __DM_ID = treedata._DM_ID;
                //                var _DM_ID = treedata.DM_ID;
                //                var _Lang = treedata.DM_Lang;
                //                if (__DM_ID == '0') { alert('Danh mục này chưa tồn tại ở ngôn ngữ ' + _Lang); return false; }
                hangHoaFn.loadHtml(function () {
                    var newDlg = $('#hangHoaFnMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                hangHoaFn.save(false, function () {
                                    hangHoaFn.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                hangHoaFn.save(false, function () {
                                    hangHoaFn.clearform();
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            hangHoaFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            $.ajax({
                                url: hangHoaFn.urlDefault().toString() + '&subAct=edit',
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
    addLang: function () {
        var s = '';
        if (jQuery('#hangHoaFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#hangHoaFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu mẩu tin');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var treedata = $("#hangHoaFnMdl-List").jqGrid('getRowData', s);
                var _DM_ID = treedata.DM_ID;
                //                if (treedata.LangBased == 'False') {
                //                    alert('Bạn cần chọn ngôn ngữ gốc');
                //                    return false;
                //                }
                hangHoaFn.loadHtml(function () {
                    var newDlg = $('#hangHoaFnMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Thêm mới',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                hangHoaFn.save(false, function () {
                                    hangHoaFn.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                hangHoaFn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            hangHoaFn.clearform();
                        },
                        open: function () {
                            adm.styleButton();
                            hangHoaFn.clearform();
                            hangHoaFn.popfn();
                            var LangBased_ID = $('.LangBased_ID', newDlg);
                            LangBased_ID.val(s);
                            var LangBased = $('.LangBased', newDlg);
                            $(LangBased).removeAttr('checked');

                            $.ajax({
                                url: hangHoaFn.urlDefault().toString(),
                                dataType: 'script',
                                data: {
                                    'subAct': 'edit',
                                    'ID': _DM_ID
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var LangBased_ID = $('.LangBased_ID');
                                    var LDMID = $('.LDMID');
                                    var PID = $('.PID');
                                    var LangTxt = $('.Lang');
                                    var Ten = $('.Ten');
                                    var Alias = $('.Alias');
                                    var Ma = $('.Ma');
                                    var KyHieu = $('.KyHieu');
                                    var GiaTri = $('.GiaTri');
                                    var KeyWords = $('.KeyWords');
                                    var Description = $('.Description');
                                    var ThuTu = $('.ThuTu');
                                    var NguoiTao = $('.NguoiTao');
                                    var spbMsg = $('.admMsg', newDlg);

                                    LangBased_ID.val(dt.LangBased_ID);
                                    LDMID.val(dt.LDM_Ten);
                                    LDMID.attr('_value', dt.LDM_ID);
                                    PID.val(dt.PID_Ten);
                                    PID.attr('_value', dt.PID);
                                    LangTxt.val(dt.Lang);
                                    Ten.val(dt.Ten);
                                    Alias.val(dt.Alias);
                                    Ma.val(dt.Ma);
                                    KyHieu.val(dt.KyHieu);
                                    GiaTri.val(dt.GiaTri);
                                    KeyWords.val(dt.KeyWords);
                                    Description.val(dt.Description);
                                    ThuTu.val(dt.ThuTu);
                                    NguoiTao.val(dt.NguoiTao);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function () {
        hangHoaFn.loadHtml(function () {
            var newDlg = $('#hangHoaFnMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        hangHoaFn.save(false, function () {
                            hangHoaFn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        hangHoaFn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    hangHoaFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    hangHoaFn.clearform();
                    hangHoaFn.popfn();
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
        if (jQuery('#hangHoaFnMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#hangHoaFnMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa danh mục này?')) {// Xác nhận xem có xóa hay không
                    //                    var treedata = $("#hangHoaFnMdl-List").jqGrid('getRowData', s); // Lấy row hiện tại đang select
                    //                    var __DM_ID = treedata._DM_ID; // Lấy DM_ID thật của danh mục
                    $.ajax({
                        url: hangHoaFn.urlDefault().toString() + '&subAct=del',
                        dataType: 'script',
                        data: { 'ID': s },
                        success: function (dt) {
                            jQuery('#hangHoaFnMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#hangHoaFnMdl-dlgNew');
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
            url: hangHoaFn.urlDefault().toString(),
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
                    jQuery('#hangHoaFnMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    search: function () {
        var timerSearch;
        var LDMID = $('.mdl-head-filterloaihangHoaFn');
        var _Lang = $('#hangHoaFnMdl-changeLangSlt').val();
        var _LDMID = $(LDMID).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#hangHoaFnMdl-List').jqGrid('setGridParam', { url: hangHoaFn.urlDefault().toString() + '&subAct=get&LDMID=' + _LDMID + '&Lang=' + _Lang }).trigger('reloadGrid');
        }, 500);
    },
    popfn: function () {
        var newDlg = $('#hangHoaFnMdl-dlgNew');
        var DM_ID = $('.DM_ID', newDlg);
        var XuatXu_ID = $('.XuatXu_ID', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        // Lấy danh mục thuộc Loại nhóm có mã là HH-DM: Hàng hóa Danh mục
        danhmuc.autoCompleteLangBased('', 'HH-DM', DM_ID, function (event, ui) {
            $(DM_ID).attr('_value', ui.item.id);
        });
        $(DM_ID).unbind('click').click(function () { $(DM_ID).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'HH-XX', XuatXu_ID, function (event, ui) {
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
        var newDlg = $('#hangHoaFnMdl-dlgNew');
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
    autoCompleteLangBased: function (id, el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'hangHoaFn-autoCompleteLangBased';
                //                if (term in _cache) {
                //                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                //                    response($.map(_cache[term], function (item) {
                //                        if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ma.toLowerCase()))) {
                //                            return {
                //                                label: item.Ten,
                //                                value: item.Ten,
                //                                id: item.ID,
                //                                rowid: item.RowId,
                //                                ma: item.Ma,
                //                                kyhieu: item.KyHieu,
                //                                giatri: item.GiaTri,
                //                                level: item.Level
                //                            }
                //                        }
                //                    }))
                //                    return;
                //                }
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: hangHoaFn.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteLangBased', 'ID': id },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri,
                                        level: item.Level
                                    }
                                }
                            }))
                        }
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            },
            change: function (event, ui) {
                if (!ui.item) {
                    if ($(this).val() == '') {
                        $(this).attr('_value', '');
                    }
                }
            },
            delay: 0,
            selectFirst: true
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    loadHtml: function (fn) {
        var dlg = $('#hangHoaFnMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.hangHoa.htm.htm")%>',
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
