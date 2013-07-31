PublishFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    loadHtml: function (_objmain, _objId, _subObjClass, fn) {
        var ObjMain = $(_objmain);
        var Obj = $(_objId);
        var SubObj = $(_subObjClass);
        $(Obj).html('');
        adm.loading('Dựng from');
        $.ajax({
            url: '<%=WebResource("cnn.plugin.QuanLySanPham.htm.htm")%>',
            success: function (dt) {
                adm.loading(null);
                $(Obj).append(dt);
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    popfn: function (_obj) {
        var obj = $(_obj);
        var danhMucSelectionList = $('.danhMucSelection-List', obj);
        var DanhMucBox_show = $('.DanhMucBox_show', obj);
        $('.danhMucSelection-Btn').click(function () {
            danhmuc.getSelectTionTest('SP_NHOM', danhMucSelectionList, DanhMucBox_show, obj);
            $('.DanhMucBox_show').show();
        });
        $('.danhMucSelection-List').click(function () {
            danhmuc.getSelectTionTest('SP_NHOM', danhMucSelectionList, DanhMucBox_show, obj);
            $('.DanhMucBox_show').show();
        });

        var XuatXu_ID = $('.XuatXu_ID', obj);
        var DonVi_ID = $('.DonVi_ID', obj);
        var NoiDung = $('.NoiDung', obj);
        var SoLuong = $('.SoLuong', obj);
        var GNY = $('.GNY', obj);

        danhmuc.autoCompleteLangBased('', 'KV-XUATXU', XuatXu_ID, function (event, ui) {
            $(XuatXu_ID).attr('_value', ui.item.id);
        });
        $(XuatXu_ID).unbind('click').click(function () { $(XuatXu_ID).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'HH_DV', DonVi_ID, function (event, ui) {
            $(DonVi_ID).attr('_value', ui.item.id);
        });
        $(DonVi_ID).unbind('click').click(function () { $(DonVi_ID).autocomplete('search', ''); });
        adm.createFck(NoiDung);

        var LangSlt = $('.Lang', obj);
        if ($(LangSlt).children().length > 0) { return false; }
        $(LangSlt).find('option').remove();
        $.each(LangArr, function (i, item) {
            if (item.Active) {
                Lang = item.Ma;
            }
            $(LangSlt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
        });

        $(SoLuong).unbind('keyup').keyup(function () {
            var strValue = $(this).val();
            $(this).val(adm.numberFormatfn(adm.stripNonNumericfn(strValue)));
        });
        $(GNY).unbind('keyup').keyup(function () {
            var strValue = $(this).val();
            $(this).val(adm.numberFormatfn(adm.stripNonNumericfn(strValue)));
        });

        var lightboxImg = $('.lightboxImg', obj);

        $(LangSlt).attr('value', 'Vi-vn');
        var ulpFn = function () {
            var uploadBtn = $('.adm-upload-btn', obj);
            var uploadView = $('.previewImg', obj);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.uploadSanPham(uploadBtn, 'anh', _params, function (rs) {
                $(uploadBtn).attr('ref', rs)
                $(uploadView).attr('src', '../up/sanpham/' + rs + '?ref=' + Math.random());
                $(lightboxImg).attr('href', '../up/sanpham/' + '400x400' + rs);
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();
        $(lightboxImg).fancybox();


    },
    clearform: function (_obj) {
        var newDlg = $(_obj);
        var ID = $('.ID', newDlg);
        var LangBased = $('.LangBased', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var LangSlt = $('.Lang', newDlg);
        var Ten = $('.Ten', newDlg);
        var TuKhoa = $('.TuKhoa', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var imgAnh = $('.previewImg', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var GNY = $('.GNY', newDlg);
        var XuatXu_ID = $('.XuatXu_ID', newDlg);

        var RowIdSP = $('.P_RowIdSP', newDlg);
        var listImg = $('.listImg', newDlg);
        var spbMsg = $('.admMsg', newDlg);



        ID.val('');
        LangBased.removeAttr('checked');
        LangBased_ID.val('');
        RowIdSP.val('');
        RowIdSP.attr('_value', '');
        RowIdSP.attr('value', '');
        RowIdSP.attr('_rowid');
        listImg.html('');
        Ten.val('');
        TuKhoa.val('');
        DM_ID.html('');
        imgAnh.attr('src', '');
        lblAnh.attr('ref', '');
        MoTa.val('');
        NoiDung.val('');
        SoLuong.val('');
        DonVi_ID.val('');
        GNY.val('');
        XuatXu_ID.val('');
        spbMsg.html('');
    },
    add: function (_objmain, _obj, _Subobj, _grid) {
        var ObjMain = $(_objmain);
        var obj = $(_obj);
        var Subobj = $(_Subobj);
        var grid = $(_grid);
        PublishFn.loadHtml(ObjMain, obj, Subobj, function () {
            var newDlg = $(obj);
            $(newDlg).dialog({
                title: 'Thêm Sảm phẩm',
                width: 785,
                height: 660,
                buttons: {
                    'Lưu': function () {
                        PublishFn.save(newDlg, grid, false, function () {
                            PublishFn.clearform(obj);
                        });
                    },
                    'Lưu và đóng': function () {
                        PublishFn.save(newDlg, grid, false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Ðóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    PublishFn.clearform(obj);
                },
                open: function () {
                    adm.styleButton();
                    PublishFn.popfn(obj);
                    PublishFn.clearform(obj);
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');

                    var LangSlt = $('.Lang', newDlg);
                    var _Lang = LangSlt.val();

                    var RowIdSP = $('.P_RowIdSP', newDlg);
                    var UploadImg = $('.UploadImg', newDlg);
                    var listImg = $('.listImg', newDlg);
                    var ID = $('.ID', newDlg);
                    var _LangBased = $(LangBased).is(':checked');
                    var _LangBased_ID = $(LangBased_ID).val();
                    $.ajax({
                        url: PublishFn.urlDefault().toString(),
                        dataType: 'script',
                        type: 'POST',
                        data: {
                            'subAct': 'InsertDraff'
                        },
                        success: function (dt) {
                            data = eval(dt);
                            RowIdSP.val(data.RowId);
                            RowIdSP.attr('_value', data.ID);
                            RowIdSP.attr('_RowID', data.RowId);
                            PublishFn.addEventUpload(UploadImg, listImg, RowIdSP);
                        }
                    });
                }
            });
        });
    },
    save: function (_obj, _grid, validate, fn) {
        var grid = $(_grid);
        var newDlg = $(_obj);
        var ID = $('.ID', newDlg);
        var LangBased = $('.LangBased', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var LangSlt = $('.Lang', newDlg);
        var _Lang = LangSlt.val();
        var Ten = $('.Ten', newDlg);
        var TuKhoa = $('.TuKhoa', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var imgAnh = $('.previewImg', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var GNY = $('.GNY', newDlg);
        var XuatXu_ID = $('.XuatXu_ID', newDlg);
        var RowIdSP = $('.P_RowIdSP', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var _ID = ID.val();
        var _LangBased = $(LangBased).is(':checked');
        var _LangBased_ID = $(LangBased_ID).val();
        var _Ten = Ten.val();
        var _TuKhoa = TuKhoa.val();
        var _DM_ID = DM_ID.attr('value');
        ////console.log(_DM_ID);

        var _Anh = lblAnh.attr('ref');
        var _NoiDung = NoiDung.val();
        var _MoTa = MoTa.val();
        var _SoLuong = SoLuong.val();
        var _DonVi_ID = DonVi_ID.attr('_value');
        var _GNY = GNY.val();
        var _XuatXu_ID = XuatXu_ID.attr('_value');
        var _RowIdSP = RowIdSP.attr('_rowid');
        var err = '';
        if (_DM_ID == '' || typeof (_DM_ID) == 'undefined') { err += 'Bạn Chọn danh mục<br/>'; };
        if (_Ten == '') { err += 'Nhập tên <br/>'; };
        if (!_LangBased) { if (_Lang == Lang) { err += 'Chọn ngôn ngữ khác'; }; }
        else { if (_Lang != Lang) { err += 'Bạn cần chọn ngôn ngữ gốc ' + Lang; }; }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: PublishFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                'ID': _ID,
                'LangBased': _LangBased,
                'LangBased_ID': _LangBased_ID,
                'Ten': _Ten,
                'KeyWords': _TuKhoa,
                'DM_ID': _DM_ID,
                'Lang': _Lang,
                'Anh': _Anh,
                'MoTa': _MoTa,
                'NoiDung': _NoiDung,
                'SoLuong': _SoLuong,
                'DonVi_ID': _DonVi_ID,
                'XuatXu_ID': _XuatXu_ID,
                'GNY': _GNY,
                'PRowIdSP': _RowIdSP
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery(grid).trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa lưu được dữ liệu');
                }
            }
        })
    },
    LamMoiGrid: function (_grid) {
        var grid = $(_grid);
        jQuery(grid).trigger('reloadGrid');
    },
    loadgridAdmCase: function (_obj, _grid, _pagergrid, _case, _caption, _FilterDMSP, _txtSearch, _FilterGHID) {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu danh mục');
        var newDlg = $(_obj);
        var grid = $(_grid);
        var pagergrid = $(_pagergrid);
        var FilterDMSP = $(_FilterDMSP);
        var FilterGHID = $(_FilterGHID);
        var txtSearch = $(_txtSearch);
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $(grid).jqGrid({
                    url: PublishFn.urlDefault().toString() + '&subAct=' + _case + '&Lang=' + Lang,
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'LangBased', 'Lang', 'STT', 'Ảnh SP', 'Tên sản phẩm', 'Danh mục SP', 'Thông tin tóm tắt', 'Ngày cập nhật', 'Doanh nghiệp'],
                    colModel: [
                            { name: 'ID', key: true, sortable: true, hidden: true },
                            { name: 'LangBased', key: true, sortable: true, hidden: true },
                            { name: 'Lang', key: true, sortable: true, hidden: true },
                            { name: 'STT', width: 10, key: true, sortable: true, align: "center" },
                            { name: 'Anh', width: 20, align: "center" },
                            { name: 'Ten', width: 70, resizable: true, sortable: true },
                            { name: 'DM_ID', width: 30, sortable: true, align: "center" },
                            { name: 'MoTa', width: 100, resizable: true, sortable: true },
                            { name: 'NgayTao', width: 30, resizable: true, sortable: true },
                            { name: 'GH_ID', width: 20, resizable: true, sortable: true }
                    ],
                    caption: _caption,
                    autowidth: true,
                    sortname: 'NgayTao',
                    sortorder: 'DESC',
                    height: 400,
                    rowNum: 50,
                    rowList: [50, 100, 200, 300],
                    multiselect: true,
                    multiboxonly: true,
                    onSelectRow: function (rowid) {
                    },
                    loadComplete: function () {
                        adm.loading(null);
                        PublishFn.LoadAutocompletefn(FilterDMSP, txtSearch, FilterGHID, grid, _case);
                    },
                    pager: $(pagergrid)
                });

                PublishFn.keyUpFn(FilterDMSP, txtSearch, FilterGHID, grid, _case);

                if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }

                adm.regJPlugin(jQuery().fancybox, '../js/fancybox/jquery.fancybox-1.3.4.pack.js', function () {
                    $.getScript('../js/fancybox/jquery.mousewheel-3.0.4.pack.js', function () { });
                });
            });
        });
    },
    loadgridCase: function (_obj, _grid, _pagergrid, _case, _caption) {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu danh mục');
        var newDlg = $(_obj);
        var grid = $(_grid);
        var pagergrid = $(_pagergrid);
        var DMID = $('.mdl-head-search-hangHoa', newDlg);
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $(grid).jqGrid({
                    url: PublishFn.urlDefault().toString() + '&subAct=' + _case + '&Lang=' + Lang,
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'LangBased', 'Lang', 'STT', 'Ảnh SP', 'Tên sản phẩm', 'Danh mục SP', 'Thông tin tóm tắt', 'Ngày cập nhật'],
                    colModel: [
                            { name: 'ID', key: true, sortable: true, hidden: true },
                            { name: 'LangBased', key: true, sortable: true, hidden: true },
                            { name: 'Lang', key: true, sortable: true, hidden: true },
                            { name: 'STT', width: 10, key: true, sortable: true, align: "center" },
                            { name: 'Anh', width: 20, align: "center" },
                            { name: 'Ten', width: 70, resizable: true, sortable: true },
                            { name: 'DM_ID', width: 30, sortable: true, align: "center" },
                            { name: 'MoTa', width: 100, resizable: true, sortable: true },
                            { name: 'NgayTao', width: 30, resizable: true, sortable: true }
                    ],
                    caption: _caption,
                    autowidth: true,
                    sortname: 'NgayTao',
                    sortorder: 'DESC',
                    height: 400,
                    rowNum: 50,
                    rowList: [50, 100, 200, 300],
                    multiselect: true,
                    multiboxonly: true,
                    onSelectRow: function (rowid) {
                    },
                    loadComplete: function () {
                        adm.loading(null);
                    },
                    pager: $(pagergrid)
                });
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () { });
                adm.watermark(DMID, 'Gõ tên loại danh mục để lọc', function () {
                });
                if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }

                adm.regJPlugin(jQuery().fancybox, '../js/fancybox/jquery.fancybox-1.3.4.pack.js', function () {
                    $.getScript('../js/fancybox/jquery.mousewheel-3.0.4.pack.js', function () { });
                });
            });
        });
    },
    loadgridSPTraPhiUserCase: function (_obj, _grid, _pagergrid, _case, _caption) {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu danh mục');
        var newDlg = $(_obj);
        var grid = $(_grid);
        var pagergrid = $(_pagergrid);
        var DMID = $('.mdl-head-search-hangHoa', newDlg);
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $(grid).jqGrid({
                    url: PublishFn.urlDefault().toString() + '&subAct=' + _case + '&Lang=' + Lang,
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'LangBased', 'Lang', 'STT', 'Ảnh SP', 'Tên sản phẩm', 'Danh mục SP', 'Ngày Cập nhật', 'Thời gian đăng ký'],
                    colModel: [
                            { name: 'ID', key: true, sortable: true, hidden: true },
                            { name: 'LangBased', key: true, sortable: true, hidden: true },
                            { name: 'Lang', key: true, sortable: true, hidden: true },
                            { name: 'STT', width: 10, key: true, sortable: true, align: "center" },
                            { name: 'Anh', width: 20, align: "center" },
                            { name: 'Ten', width: 100, resizable: true, sortable: true },
                            { name: 'DM_ID', width: 30, sortable: true, align: "center" },
                            { name: 'NgayTao', width: 30, resizable: true, sortable: true },
                            { name: 'ThoiGianDangKy', width: 30, resizable: true }
                    ],
                    caption: _caption,
                    autowidth: true,
                    sortname: 'NgayTao',
                    sortorder: 'DESC',
                    height: 400,
                    rowNum: 50,
                    rowList: [50, 100, 200, 300],
                    multiselect: true,
                    multiboxonly: true,
                    onSelectRow: function (rowid) {
                    },
                    loadComplete: function () {
                        adm.loading(null);
                    },
                    pager: $(pagergrid)
                });
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () { });
                adm.watermark(DMID, 'Gõ tên loại danh mục để lọc', function () {
                });
                if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }

                adm.regJPlugin(jQuery().fancybox, '../js/fancybox/jquery.fancybox-1.3.4.pack.js', function () {
                    $.getScript('../js/fancybox/jquery.mousewheel-3.0.4.pack.js', function () { });
                });
            });
        });
    },
    loadgridSPTraPhiAdmCase: function (_obj, _grid, _pagergrid, _case, _caption, _FilterDMSP, _txtSearch, _FilterGHID) {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu danh mục');
        var newDlg = $(_obj);
        var grid = $(_grid);
        var pagergrid = $(_pagergrid);
        var FilterDMSP = $(_FilterDMSP);
        var FilterGHID = $(_FilterGHID);
        var txtSearch = $(_txtSearch);
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $(grid).jqGrid({
                    url: PublishFn.urlDefault().toString() + '&subAct=' + _case + '&Lang=' + Lang,
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'LangBased', 'Lang', 'STT', 'Ảnh SP', 'Tên sản phẩm', 'Danh mục SP', 'Ngày cập nhật', 'Thời gian đăng ký', 'Doanh Nghiệp'],
                    colModel: [
                            { name: 'ID', key: true, sortable: true, hidden: true },
                            { name: 'LangBased', key: true, sortable: true, hidden: true },
                            { name: 'Lang', key: true, sortable: true, hidden: true },
                            { name: 'STT', width: 10, key: true, sortable: true, align: "center" },
                            { name: 'Anh', width: 20, align: "center" },
                            { name: 'Ten', width: 100, resizable: true, sortable: true },
                            { name: 'DM_ID', width: 30, sortable: true, align: "center" },
                            { name: 'NgayTao', width: 30, resizable: true, sortable: true },
                            { name: 'ThoiGianDangKy', width: 30, resizable: true },
                            { name: 'GH_ID', width: 30, resizable: true }
                    ],
                    caption: _caption,
                    autowidth: true,
                    sortname: 'NgayTao',
                    sortorder: 'DESC',
                    height: 400,
                    rowNum: 50,
                    rowList: [50, 100, 200, 300],
                    multiselect: true,
                    multiboxonly: true,
                    onSelectRow: function (rowid) {
                    },
                    loadComplete: function () {
                        adm.loading(null);
                        PublishFn.LoadAutocompletefn(FilterDMSP, txtSearch, FilterGHID, grid, _case);
                    },
                    pager: $(pagergrid)
                });

                PublishFn.keyUpFn(FilterDMSP, txtSearch, FilterGHID, grid, _case);
                if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }

                adm.regJPlugin(jQuery().fancybox, '../js/fancybox/jquery.fancybox-1.3.4.pack.js', function () {
                    $.getScript('../js/fancybox/jquery.mousewheel-3.0.4.pack.js', function () { });
                });
            });
        });
    },
    edit: function (_objmain, _obj, _Subobj, _grid) {
        var ObjMain = $(_objmain);
        var obj = $(_obj);
        var Subobj = $(_Subobj);
        var grid = $(_grid);
        var s = '';
        if (jQuery(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn mẩu tin để sửa');
            }
            else {
                PublishFn.loadHtml(ObjMain, obj, Subobj, function () {
                    var newDlg = $(obj);
                    $(newDlg).dialog({
                        title: 'Edit',
                        width: 785,
                        height: 660,
                        buttons: {
                            'Lưu': function () {
                                PublishFn.save(newDlg, grid, false, function () {
                                    PublishFn.clearform(obj);
                                });
                            },
                            'Lưu và đóng': function () {
                                PublishFn.save(newDlg, grid, false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Ðóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            PublishFn.clearform(obj);
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            PublishFn.popfn(obj);
                            adm.styleButton();
                            $.ajax({
                                url: PublishFn.urlDefault().toString() + '&subAct=editDetail',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ListFiles = eval(dt.ListFiles);

                                    var ID = $('.ID', newDlg);
                                    var LangBased = $('.LangBased', newDlg);
                                    var LangBased_ID = $('.LangBased_ID', newDlg);
                                    var LangSlt = $('.Lang', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var TuKhoa = $('.TuKhoa', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var imgAnh = $('.previewImg', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var SoLuong = $('.SoLuong', newDlg);
                                    var DonVi_ID = $('.DonVi_ID', newDlg);
                                    var GNY = $('.GNY', newDlg);
                                    var XuatXu_ID = $('.XuatXu_ID', newDlg);
                                    var RowIdSP = $('.P_RowIdSP', newDlg);
                                    var UploadImg = $('.UploadImg', newDlg);
                                    var listImg = $('.listImg', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    ID.val(dt.ID);
                                    LangBased_ID.val(dt.LangBased_ID);
                                    if (dt.LangBased) {
                                        $(LangBased).attr('checked', 'checked');
                                    }
                                    else {
                                        $(LangBased).removeAttr('checked');
                                    }
                                    LangSlt.val(dt.Lang);

                                    Ten.val(dt.Ten);
                                    TuKhoa.val(dt.Keywords);
                                    $(lblAnh).attr('ref', dt.Anh);
                                    if (dt.Anh != '') {
                                        $(imgAnh).attr('src', '../up/sanpham/' + dt.Anh + '?ref=' + Math.random());
                                    }
                                    MoTa.val(dt.Description);
                                    NoiDung.val(dt.NoiDung);
                                    SoLuong.val(dt.SoLuong);
                                    DonVi_ID.val(dt._DonVi_Ten);
                                    DonVi_ID.attr('_value', dt.DonVi_ID);
                                    XuatXu_ID.val(dt._XuatXu_Ten);
                                    XuatXu_ID.attr('_value', dt.XuatXu_ID);
                                    GNY.val(dt.GNY);
                                    RowIdSP.val(dt.RowId);
                                    $.each(ListFiles, function (i, item) {
                                        $('<span class=\"adm-token-item\"><div class=\"adm-div-preview-img-size-75\"><img class=\"adm-preview-img-size-75\" src=\"../up/sanpham/' + item.ThuMuc + '/' + item.Ten + item.MimeType + '?ref=' + Math.random() + '\" /></div><a _value=\"' + item.ID + '\" href="javascript:;" class="adm-upload-btn">Xóa</a></span>').appendTo(listImg).find('a').click(function () {
                                            if (confirm('Bạn có chắc chắn xóa ảnh này?')) {
                                                var _item = $(this);
                                                $(_item).hide();
                                                $.ajax({
                                                    url: PublishFn.urlDefault().toString(),
                                                    dataType: 'script',
                                                    type: 'POST',
                                                    data: {
                                                        'subAct': 'DeleteDoc',
                                                        'F_ID': $(_item).attr('_value')
                                                    },
                                                    success: function (dt) {
                                                        $(_item).remove();
                                                    }
                                                });
                                                $(this).parent().remove();
                                            }
                                        });
                                    });
                                    RowIdSP.attr('_value', dt.ID);
                                    RowIdSP.attr('_RowID', dt.RowId);
                                    PublishFn.addEventUpload(UploadImg, listImg, RowIdSP);
                                    $(DM_ID).attr('value', dt.DM_ID);
                                    $.ajax({
                                        url: PublishFn.urlDefault().toString() + '&subAct=SelectTreeParentByDmId',
                                        dataType: 'script',
                                        data: {
                                            'DM_ID': dt.DM_ID
                                        },
                                        success: function (dt) {
                                            var data = eval(dt);
                                            var count = 0;
                                            var tempappend = '';
                                            $.each(data, function (i, item) {
                                                count++;
                                                tempappend += '<span class="spanlv' + count + '" level="' + count + '" _id="' + item.DM_ID + '" >' + item._DM_Ten + '</span><span>&nbsp;>>&nbsp;</span>';
                                                //$(DM_ID).append('<span class="spanlv' + count + '" level="' + count + '" _id="' + item.DM_ID + '" >' + item._DM_Ten + '</span><span>&nbsp;>>&nbsp;</span>');
                                            });
                                            tempappend = tempappend.substring(0, tempappend.length - 27);
                                            $(DM_ID).append(tempappend);
                                        }
                                    });
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function (_grid) {
        var grid = $(_grid);
        var s = '';
        if (jQuery(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn mẩu tin để xóa');
            }
            else {
                if (confirm('Bạn có muốn xóa mẩu tin này')) {// Xác nh?n xem có xóa hay không
                    //                    var treedata = $("#QuanLySanPhamFnMdl-List").jqGrid('getRowData', s); // L?y row hi?n t?i dang select
                    //                    var __DM_ID = treedata._DM_ID; // L?y DM_ID th?t c?a danh m?c
                    $.ajax({
                        url: PublishFn.urlDefault().toString() + '&subAct=del',
                        dataType: 'script',
                        data: { 'ID': s },
                        success: function (dt) {
                            jQuery(grid).trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    addEventUpload: function (oBrowseButton, oFileList, oInputData) {

        var browseButton = $(oBrowseButton);
        var fileList = $(oFileList);
        var inputData = $(oInputData);

        var PRowIdSP = inputData.attr('_RowID');
        var _params = { 'act': 'MultiuploadImg', 'PRowIdSP': PRowIdSP }
        adm.uploadSanPham(browseButton, 'anh', _params, function (rs) {
        }, function (_rs) {
        }, function (_r, _f) {

            var datars = eval(_r);
            var Imgname = datars.Ten + datars.MimeType;
            var foldername = datars.ThuMuc;
            var l = '';
            //l += '<span class=\"adm-token-item\"><span onclick=\"javascript:document.location.href=\' ../Default.aspx?act=download&ID=' + _r.replace('.', '') + '\'\">' + _f + '</span><a _value=\"' + _r.replace('.', '') + '\"  href=\"javascript:;\">x</a></span>';
            l += '<span class=\"adm-token-item\"><div class=\"adm-div-preview-img-size-75\"><img class=\"adm-preview-img-size-75\" src=\"../up/sanpham/' + foldername + '/' + Imgname + '?ref=' + Math.random() + '\" /></div><a _value=\"' + datars.ID + '\" href="javascript:;" class="adm-upload-btn">Xóa</a></span>';
            $(l).appendTo(fileList).find('a').click(function () {
                if (confirm('Bạn có chắc chắn xóa ảnh này?')) {
                    var _item = $(this);
                    $(_item).hide();
                    $.ajax({
                        url: PublishFn.urlDefault().toString(),
                        dataType: 'script',
                        type: 'POST',
                        data: {
                            'subAct': 'DeleteDoc',
                            'F_ID': $(_item).attr('_value')
                        },
                        success: function (dt) {
                            $(_item).remove();
                        }
                    });
                    $(this).parent().remove();
                }
            });
        });
    },
    loadfromDKSPDT: function (_objmain, _objId, _subObjClass, fn) {
        var ObjMain = $(_objmain);
        var Obj = $(_objId);
        var SubObj = $(_subObjClass);
        $(Obj).html('');
        adm.loading('Dựng from');
        $.ajax({
            url: '<%=WebResource("cnn.plugin.QuanLySanPham.DangKySanPhamDacTrung.htm")%>',
            success: function (dt) {
                adm.loading(null);
                $(Obj).append(dt);
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    DangKySanPhamDacTrung: function (_objmain, _obj, _Subobj, _grid) {
        var ObjMain = $(_objmain);
        var obj = $(_obj);
        var Subobj = $(_Subobj);
        var grid = $(_grid);
        var s = '';
        if (jQuery(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                PublishFn.loadfromDKSPDT(ObjMain, obj, Subobj, function () {
                    var newDlg = $(obj);
                    PublishFn.Activeform(newDlg);
                    $(newDlg).dialog({
                        title: 'Đăng ký sản phẩm đặc trưng',
                        width: 830,
                        height: 625,
                        buttons: {
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            PublishFn.clearformdkdv(newDlg);
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();

                            PublishFn.popfndksp(newDlg);
                            PublishFn.LoadThongTinSanPham(s, newDlg);
                            PublishFn.LoadHotro(newDlg);
                            PublishFn.LoadThanhToanGioiThieu(newDlg, function () {
                                PublishFn.Mathtimefn(newDlg);
                            });
                            var btnLienhe = $('.mdl-head-lienHe', newDlg); //sendLienHe
                            btnLienhe.click(function () {
                                PublishFn.sendLienHe(newDlg);
                            });
                            var btnDangKy = $('.mdl-head-DKSPDT', newDlg);
                            btnDangKy.click(function () {
                                PublishFn.SaveDKSPDT(newDlg, false, function () {
                                });
                            });
                        }
                    });
                });
            }
        }
    },
    clearformdkdv: function (_obj) {
        var newDlg = $(_obj);
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
    Activeform: function (_obj) {
        var obj = $(_obj);
        adm.styleButton();
        var tbBox = $('.thanhToan-box', obj);
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
    LoadThongTinSanPham: function (ID, _obj) {
        var newDlg = $(_obj);
        adm.loading('Lấy dữ liệu gian hàng');
        $.ajax({
            url: PublishFn.urlDefault().toString() + '&subAct=edit',
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
                    $(ImgSP).attr('src', '../up/sanpham/' + data.Anh + '?ref=' + Math.random());
                }

                if (eval(data.Hot1) == true) {
                    btnDKSPDT.hide();
                    var _TuNgay = new Date(data.NgayBD_DK_SPDT);
                    var TuNgay = _TuNgay.getDate() + '/' + (_TuNgay.getMonth() + 1) + '/' + _TuNgay.getFullYear();
                    var _DenNgay = new Date(data.NgayKT_DK_SPDT);
                    var DenNgay = _DenNgay.getDate() + '/' + (_DenNgay.getMonth() + 1) + '/' + _DenNgay.getFullYear();
                    var btnHuyBo = '<a style="margin-left:200px;color:red;" class="mdl-head-HUYDKSP" href="javascript:">Hủy</a>';
                    ThongTinDangKySPDT.append('Bạn đã đăng ký sản phẩm đặc trưng từ <span style="color:red;"> ' + TuNgay + '</span> đến <span style="color:red;"> ' + DenNgay + '</span>' + btnHuyBo);
                    adm.styleButton();
                    var btnHuyDK = $('.mdl-head-HUYDKSP', newDlg);
                    btnHuyDK.click(function () {
                        PublishFn.HuyDangKyDichVu(newDlg);
                    });

                }
            }
        });
    },
    LoadHotro: function (_obj) {
        $.ajax({
            url: PublishFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'LIENHE'
            },
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);
                var newDlg = $(_obj);
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
    sendLienHe: function (_obj, validate, fn) {
        var newDlg = $(_obj);
        //var btnLienhe = $('.mdl-head-lienHe', newDlg);sendLienHe
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
            url: PublishFn.urlDefault().toString() + '&subAct=lienHe',
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
    LoadThanhToanGioiThieu: function (_obj, fn) {
        //console.log('test2');
        $.ajax({
            url: PublishFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'THANHTOAN'
            },
            success: function (dt) {
                var data = eval(dt);
                var newDlg = $(_obj);
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
            url: PublishFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'SP_DICHVU'
            },
            success: function (dt) {
                var data = eval(dt);
                var newDlg = $(_obj);
                var SPDacTrungDanhMuc = $('.SPDacTrung-DanhMuc', newDlg);
                var SPMenuDanhMuc = $('.SPMenu-DanhMuc', newDlg);
                var GiaSPDacTrungDanhMuc = $('.GiaSPDacTrung-DanhMuc', newDlg);
                var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
                var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);
                var SoNgayDKSPDacTrung = $('.SoNgayDKSPDacTrung', newDlg);
                var TongTienDKSPDacTrung = $('.TongTien-DKSPDacTrung', newDlg);
                var GioiThieuDKSPDanhMuc = $('.GioiThieuDKSP-DanhMuc', newDlg);
                var GioiThieuDKSPMenuDanhMuc = $('.GioiThieuDKSPMenu-DanhMuc', newDlg);
                $.each(data, function (i, item) {


                    if ($(newDlg).find('.GioiThieuDKSP-DanhMuc') >= 1) {
                        if (item.Ma == 'SP_DV_GIOITHIEU') {
                            GioiThieuDKSPDanhMuc.append(item.Description);
                        }
                    }

                    if ($(newDlg).find('.GioiThieuDKSP-DanhMuc') >= 1) {
                        if (item.Ma == 'SP_DV_MENU_GIOITHIEU') {
                            GioiThieuDKSPMenuDanhMuc.append(item.Description);
                        }
                    }


                    if ($(newDlg).find('.SPDacTrung-DanhMuc').length >= 1) {
                        if (item.Ma == 'SP_DV_DACTRUNG') {
                            GiaSPDacTrungDanhMuc.append(item.GiaTri);
                            GiaSPDacTrungDanhMuc.attr('_gia', item.GiaTri);
                            SPDacTrungDanhMuc.append(item.Description);
                        }
                    }
                    if ($(newDlg).find('.SPMenu-DanhMuc').length >= 1) {
                        if (item.Ma == 'SP_DV_MENU') {
                            GiaSPDacTrungDanhMuc.append(item.GiaTri);
                            GiaSPDacTrungDanhMuc.attr('_gia', item.GiaTri);
                            SPMenuDanhMuc.append(item.Description);
                        }
                    }
                });
                if (typeof (fn) == 'function') { fn(); }
            }
        });
    },
    popfndksp: function (_obj) {
        var newDlg = $(_obj);
        var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
        var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);
        NgayDKSPDacTrung.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayKTDKSPDacTrung.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    Mathtimefn: function (_obj) {
        var newDlg = $(_obj);
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
        TongTienDKSPDacTrung.append(GiaDkSPDacTrungTuan);

        NgayDKSPDacTrung.change(function () {
            PublishFn.InputChange(NgayDKSPDacTrung, NgayKTDKSPDacTrung, SoNgayDKSPDacTrung, TongTienDKSPDacTrung, GiaSPDacTrungDanhMuc);
        });
        NgayKTDKSPDacTrung.change(function () {
            PublishFn.InputChange(NgayDKSPDacTrung, NgayKTDKSPDacTrung, SoNgayDKSPDacTrung, TongTienDKSPDacTrung, GiaSPDacTrungDanhMuc);
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

        var convertNgayBD = PublishFn.convertDate(NgayBD.val(), '/');
        var convertNgayKT = PublishFn.convertDate(NgayKT.val(), '/');
        var Datecount = PublishFn.dateDiff('d', convertNgayBD, convertNgayKT);
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
    SaveDKSPDT: function (_obj, validate, fn) {
        var newDlg = $(_obj);
        var dkspdt = 'False';

        var ID = $('.ID', newDlg);
        var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
        var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);

        var btnDKSPDT = $('.mdl-head-DKSPDT', newDlg);

        var _ID = ID.val();
        var _NgayKTDKSPDacTrung = NgayKTDKSPDacTrung.val();
        var _NgayDKSPDacTrung = NgayDKSPDacTrung.val();
        var err = '';

        var convertDateNgayKTDKSPDacTrung = PublishFn.convertDate(NgayKTDKSPDacTrung.val(), '/');
        var convertDateNgayDKSPDacTrung = PublishFn.convertDate(NgayDKSPDacTrung.val(), '/');
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
            url: PublishFn.urlDefault().toString() + '&subAct=DKSPDT',
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
                    PublishFn.loadFormThongtinDk(newDlg);
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    HuyDangKyDichVu: function (_obj) {
        var newDlg = $(_obj);
        var dkspdt = 'False';
        var _ID = $('.ID', newDlg);
        var ID = _ID.val();
        var btnHuyBo = $('.mdl-head-HUYDKSP', newDlg);
        var btnDKSPDT = $('.mdl-head-DKSPDT', newDlg);
        var ThongTinDangKySPDT = $('.ThongTinDangKySPDT', newDlg);
        if (confirm('Bạn có chắc muốn hủy đăng ký dịch vụ sản phẩm đặc trưng?')) {
            $.ajax({
                url: PublishFn.urlDefault().toString() + '&subAct=DKSPDT',
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
    loadFormThongtinDk: function (_obj) {
        var newDlg = $(_obj);
        var ThongTinDangKySPDT = $('.ThongTinDangKySPDT', newDlg);
        var ThongTinDangKySPMENU = $('.ThongTinDangKySPMENU', newDlg);
        var _ID = $('.ID', newDlg);
        var ID = _ID.val();
        if (confirm('Bạn có chắc chắn muốn đăng ký dịch vụ sản phẩm?')) {
            $.ajax({
                url: PublishFn.urlDefault().toString() + '&subAct=edit',
                dataType: 'script',
                type: 'POST',
                data: {
                    'ID': ID
                },
                success: function (dt) {

                    if ($(newDlg).find('.ThongTinDangKySPDT').length >= 1) {
                        var _TuNgay = new Date(data.NgayBD_DK_SPDT);
                        var TuNgay = _TuNgay.getDate() + '/' + (_TuNgay.getMonth() + 1) + '/' + _TuNgay.getFullYear();
                        var _DenNgay = new Date(data.NgayKT_DK_SPDT);
                        var DenNgay = _DenNgay.getDate() + '/' + (_DenNgay.getMonth() + 1) + '/' + _DenNgay.getFullYear();
                        var btnHuyBo = '<a style="margin-left:200px;color:red;" class="mdl-head-HUYDKSP" href="javascript:">Hủy</a>';
                        ThongTinDangKySPDT.append('Bạn đã đăng ký sản phẩm đặc trưng từ <span style="color:red;"> ' + TuNgay + '</span> đến <span style="color:red;">' + DenNgay + '</span>' + btnHuyBo);
                        adm.styleButton();
                        var btnHuyDK = $('.mdl-head-HUYDKSP', newDlg);
                        btnHuyDK.click(function () {
                            PublishFn.HuyDangKyDichVu(newDlg);
                        });
                    }

                    if ($(newDlg).find('.ThongTinDangKySPMENU').length >= 1) {
                        var _TuNgay = new Date(data.NgayBD_DK_SPMenu);
                        var TuNgay = _TuNgay.getDate() + '/' + (_TuNgay.getMonth() + 1) + '/' + _TuNgay.getFullYear();
                        var _DenNgay = new Date(data.NgayKT_DK_SPMenu);
                        var DenNgay = _DenNgay.getDate() + '/' + (_DenNgay.getMonth() + 1) + '/' + _DenNgay.getFullYear();
                        var btnHuyBoDKMenu = '<a style="margin-left:200px;color:red;" class="mdl-head-HUYDKSPMenu" href="javascript:">Hủy</a>';
                        ThongTinDangKySPMENU.append('Bạn đã đăng ký sản phẩm Menu từ <span style="color:red;"> ' + TuNgay + '</span> đến <span style="color:red;">' + DenNgay + '</span>' + btnHuyBoDKMenu);
                        adm.styleButton();
                        var btnHuyDKSPMenu = $('.mdl-head-HUYDKSPMenu', newDlg);
                        btnHuyDKSPMenu.click(function () {
                            PublishFn.HuyDangKyDichVuSPMenu(newDlg);
                        });
                    }


                }
            });
        }
    },
    loadfromDKSPMENU: function (_objmain, _objId, _subObjClass, fn) {
        var ObjMain = $(_objmain);
        var Obj = $(_objId);
        var SubObj = $(_subObjClass);
        $(Obj).html('');
        adm.loading('Dựng from');
        $.ajax({
            url: '<%=WebResource("cnn.plugin.QuanLySanPham.DangKySanPhamMenu.htm")%>',
            success: function (dt) {
                adm.loading(null);
                $(Obj).append(dt);
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    DangKySanPhamMenu: function (_objmain, _obj, _Subobj, _grid) {
        var ObjMain = $(_objmain);
        var obj = $(_obj);
        var Subobj = $(_Subobj);
        var grid = $(_grid);
        var s = '';
        if (jQuery(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                PublishFn.loadfromDKSPMENU(ObjMain, obj, Subobj, function () {
                    var newDlg = $(obj);
                    PublishFn.Activeform(newDlg);
                    $(newDlg).dialog({
                        title: 'Đăng ký sản phẩm Menu',
                        width: 830,
                        height: 625,
                        buttons: {
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            PublishFn.clearformdkdv(newDlg);
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            var btnLienhe = $('.mdl-head-lienHe', newDlg); //sendLienHe
                            btnLienhe.click(function () {
                                PublishFn.sendLienHe(newDlg);
                            });
                            PublishFn.LoadHotro(newDlg);
                            PublishFn.popfndksp(newDlg);
                            PublishFn.LoadThongTinSanPhamDKMenu(s, newDlg);
                            PublishFn.LoadThanhToanGioiThieu(newDlg, function () {
                                PublishFn.Mathtimefn(newDlg);
                            });


                            var btnDangKy = $('.mdl-head-DKSPMENU', newDlg);
                            btnDangKy.click(function () {
                                PublishFn.SaveDKSPMenu(newDlg, false, function () {
                                });
                            });

                        }
                    });
                });
            }
        }
    },
    LoadThongTinSanPhamDKMenu: function (ID, _obj) {
        var newDlg = $(_obj);
        adm.loading('Lấy dữ liệu gian hàng');
        $.ajax({
            url: PublishFn.urlDefault().toString() + '&subAct=edit',
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

                var ThongTinDangKySPDT = $('.ThongTinDangKySPMENU', newDlg);

                var btnDKSPDT = $('.mdl-head-DKSPMENU', newDlg);

                ID.val(data.ID);
                TenSP.append(data.Ten);
                DanhMucSP.append(data._DM_Ten);
                var __NgayDangSP = new Date(data.NgayTao);
                var _NgayDangSP = __NgayDangSP.getDate() + '/' + (__NgayDangSP.getMonth() + 1) + '/' + __NgayDangSP.getFullYear();
                NgayDangSP.append(_NgayDangSP);
                MaTinSP.append('SPMenu' + data.ID);
                if (data.Anh != '') {
                    $(ImgSP).attr('src', '../up/sanpham/' + data.Anh + '?ref=' + Math.random());
                }

                if (eval(data.Hot2) == true) {
                    btnDKSPDT.hide();
                    var _TuNgay = new Date(data.NgayBD_DK_SPMenu);
                    var TuNgay = _TuNgay.getDate() + '/' + (_TuNgay.getMonth() + 1) + '/' + _TuNgay.getFullYear();
                    var _DenNgay = new Date(data.NgayKT_DK_SPMenu);
                    var DenNgay = _DenNgay.getDate() + '/' + (_DenNgay.getMonth() + 1) + '/' + _DenNgay.getFullYear();
                    var btnHuyBo = '<a style="margin-left:200px;color:red;" class="mdl-head-HUYDKSPMenu" href="javascript:">Hủy</a>';
                    ThongTinDangKySPDT.append('Bạn đã đăng ký sản phẩm Menu từ <span style="color:red;"> ' + TuNgay + '</span> đến <span style="color:red;"> ' + DenNgay + '</span>' + btnHuyBo);
                    adm.styleButton();
                    var btnHuyDK = $('.mdl-head-HUYDKSPMenu', newDlg);
                    btnHuyDK.click(function () {
                        PublishFn.HuyDangKyDichVuSPMenu(newDlg);
                    });

                }
            }
        });
    },
    SaveDKSPMenu: function (_obj, validate, fn) {
        var newDlg = $(_obj);
        var dkspdt = 'False';

        var ID = $('.ID', newDlg);
        var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
        var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);

        var btnDKSPDT = $('.mdl-head-DKSPMENU', newDlg);

        var _ID = ID.val();
        var _NgayKTDKSPDacTrung = NgayKTDKSPDacTrung.val();
        var _NgayDKSPDacTrung = NgayDKSPDacTrung.val();
        var err = '';

        var convertDateNgayKTDKSPDacTrung = PublishFn.convertDate(NgayKTDKSPDacTrung.val(), '/');
        var convertDateNgayDKSPDacTrung = PublishFn.convertDate(NgayDKSPDacTrung.val(), '/');
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
            url: PublishFn.urlDefault().toString() + '&subAct=DKSPMenu',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'Hot2': dkspdt,
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
                    PublishFn.loadFormThongtinDk(newDlg);
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    HuyDangKyDichVuSPMenu: function (_obj) {
        var newDlg = $(_obj);
        var dkspdt = 'False';
        var _ID = $('.ID', newDlg);
        var ID = _ID.val();
        var btnHuyBo = $('.mdl-head-HUYDKSPMenu', newDlg);

        var btnDKSPDT = $('.mdl-head-DKSPMENU', newDlg);
        var ThongTinDangKySPMenu = $('.ThongTinDangKySPMENU', newDlg);

        //console.log(btnHuyBo);
        //console.log(btnDKSPDT);
        //console.log(ThongTinDangKySPMenu);
        if (confirm('Bạn có muốn hủy đăng ký dịch vụ sản phẩm menu?')) {
            $.ajax({
                url: PublishFn.urlDefault().toString() + '&subAct=DKSPMenu',
                dataType: 'script',
                type: 'POST',
                data: {
                    'ID': ID,
                    'Hot2': dkspdt,
                    'NgayDKSPDT': '',
                    'NgayKTDKSPDT': ''
                },
                success: function (dt) {
                    adm.loading(null);
                    if (dt == '1') {
                        ThongTinDangKySPMenu.html('');
                        btnDKSPDT.show();

                    }
                    else {
                        spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                    }
                }
            });
        }
    },
    DangTinDungTinCase: function (_grid, _case) {
        var grid = $(_grid);
        var s = '';
        s = jQuery(grid).jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin');
        }
        else {
            if (confirm('Bạn có chắc chắn?')) {
                $.ajax({
                    url: PublishFn.urlDefault().toString() + '&subAct=' + _case,
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(grid).trigger('reloadGrid');
                    }
                });

            }
        }
    },
    loadfromDuyetDKDV: function (_objmain, _objId, _subObjClass, fn) {
        var ObjMain = $(_objmain);
        var Obj = $(_objId);
        var SubObj = $(_subObjClass);
        $(Obj).html('');
        adm.loading('Dựng from');
        $.ajax({
            url: '<%=WebResource("cnn.plugin.QuanLySanPham.DuyetSPDT.htm")%>',
            success: function (dt) {
                adm.loading(null);
                $(Obj).append(dt);
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    FormDuyetDKSP: function (_objmain, _obj, _Subobj, _grid, _title, fn1, fn2) {
        var ObjMain = $(_objmain);
        var obj = $(_obj);
        var Subobj = $(_Subobj);
        var grid = $(_grid);
        var s = '';
        if (jQuery(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn mẩu tin để sửa');
            }
            else {
                PublishFn.loadfromDuyetDKDV(ObjMain, obj, Subobj, function () {
                    var newDlg = $(obj);
                    $(newDlg).dialog({
                        title: _title,
                        width: 637,
                        height: 415,
                        modal: true,
                        buttons: {
                            //                            'Hủy ĐKDV': function () {
                            //                                //                                if (typeof (fn1) == 'function') {
                            //                                //                                    fn1();
                            //                                //                                }
                            //                                PublishFn.SaveDKDVSource(grid, s, '', '', '', '', 'False', '', '', '');
                            //                                $(newDlg).dialog('close');
                            //                            },
                            'Duyệt và đóng': function () {
                                PublishFn.DetailsSaveDKDVGrid(obj, grid, false, function () {
                                    $(obj).dialog('close');
                                });
                                //                                if (typeof (fn2) == 'function') {
                                //                                    fn2();
                                //                                }

                            },
                            'Ðóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            //                            PublishFn.clearform(obj);
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            PublishFn.PopFormDuyetDKSPFn(obj);
                            adm.styleButton();
                            $.ajax({
                                url: PublishFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: { 'ID': s },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var ID = $('.ID', obj);
                                    var Anh = $('.img-preview-sp', obj);
                                    var TenSp = $('.Ten', obj);
                                    //var TaiKhoan = $('.TaiKhoan', obj);
                                    var DanhMucSP = $('.DanhMucSP', obj);
                                    var DonVi = $('.DonVi', obj);
                                    var NguoiDaiDien = $('.NguoiDaiDien', obj);
                                    var DienThoai = $('.DienThoai', obj);
                                    var Email = $('.Email', obj);
                                    var NgayDangKy = $('.NgayDangKy', obj);
                                    var cbkDKDT = $('.cbkDKDT', obj);
                                    var cbkDKMenu = $('.cbkDKMenu', obj);
                                    var cbkTT = $('.cbkTT', obj);
                                    var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', obj);
                                    var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', obj);
                                    var NgayDKSPMenu = $('.NgayDKSPMenu', obj);
                                    var NgayKTDKSPMenu = $('.NgayKTDKSPMenu', obj);

                                    cbkTT.unbind('click').click(function () {
                                        var _checkedTT = cbkTT.is(':checked');
                                        if (eval(_checkedTT) == true) {
                                            NgayDKSPDacTrung.attr('disabled', 'disabled');
                                            NgayKTDKSPDacTrung.attr('disabled', 'disabled');
                                            NgayDKSPMenu.attr('disabled', 'disabled');
                                            NgayKTDKSPMenu.attr('disabled', 'disabled');
                                            NgayDKSPDacTrung.val('');
                                            NgayKTDKSPDacTrung.val('');
                                            NgayDKSPMenu.val('');
                                            NgayKTDKSPMenu.val('');
                                            cbkDKDT.attr('disabled', 'disabled');
                                            cbkDKMenu.attr('disabled', 'disabled');
                                            cbkDKDT.removeAttr('checked');
                                            cbkDKMenu.removeAttr('checked');
                                        }
                                        if (eval(_checkedTT) == false) {
                                            NgayDKSPDacTrung.removeAttr('disabled');
                                            NgayKTDKSPDacTrung.removeAttr('disabled');
                                            NgayDKSPMenu.removeAttr('disabled');
                                            NgayKTDKSPMenu.removeAttr('disabled');
                                            cbkDKDT.removeAttr('disabled');
                                            cbkDKMenu.removeAttr('disabled');
                                        }
                                    });

                                    if (data.Anh != '') {
                                        $(Anh).attr('src', '../up/sanpham/' + data.Anh + '?ref=' + Math.random());
                                    }
                                    $(TenSp).append(data.Ten);
                                    $(DanhMucSP).append(data._DM_Ten);
                                    $(DonVi).append(data.GH_Ten);
                                    $(NguoiDaiDien).append(data.LH_Ten);
                                    $(DienThoai).append(data.LH_Mobile + " " + data.LH_Phone);
                                    $(Email).append(data.LH_Email);
                                    ////console.log(data.NgayCapNhat);
                                    var __NgayCapNhat = new Date(data.NgayCapNhat);
                                    var _NgayCapNhat = __NgayCapNhat.getDate() + '/' + (__NgayCapNhat.getMonth() + 1) + '/' + __NgayCapNhat.getFullYear();
                                    $(NgayDangKy).append(_NgayCapNhat);
                                    if (eval(data.Hot1) == true) {
                                        cbkDKDT.attr('checked', 'checked');
                                        var __NgayDKSP = new Date(data.NgayBD_DK_SPDT);
                                        var _NgayDKSP = __NgayDKSP.getDate() + '/' + (__NgayDKSP.getMonth() + 1) + '/' + __NgayDKSP.getFullYear();
                                        NgayDKSPDacTrung.val(_NgayDKSP);
                                        var __NgayHHDKSP = new Date(data.NgayKT_DK_SPDT);
                                        var _NgayHHDKSP = __NgayHHDKSP.getDate() + '/' + (__NgayHHDKSP.getMonth() + 1) + '/' + __NgayHHDKSP.getFullYear();
                                        NgayKTDKSPDacTrung.val(_NgayHHDKSP);

                                    }
                                    else {
                                        cbkDKDT.removeAttr('checked');
                                    }
                                    if (eval(data.Hot2) == true) {
                                        cbkDKMenu.attr('checked', 'checked');
                                        var __NgayDKSPMenu = new Date(data.NgayBD_DK_SPMenu);
                                        var _NgayDKSPMenu = __NgayDKSPMenu.getDate() + '/' + (__NgayDKSPMenu.getMonth() + 1) + '/' + __NgayDKSPMenu.getFullYear();
                                        NgayDKSPMenu.val(_NgayDKSPMenu);
                                        var __NgayHHDKSPMenu = new Date(data.NgayKT_DK_SPMenu);
                                        var _NgayHHDKSPMenu = __NgayHHDKSPMenu.getDate() + '/' + (__NgayHHDKSPMenu.getMonth() + 1) + '/' + __NgayHHDKSPMenu.getFullYear();
                                        NgayKTDKSPMenu.val(_NgayHHDKSPMenu);
                                    }
                                    else {
                                        cbkDKMenu.removeAttr('checked');
                                    }
                                    ID.val(data.ID);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    PopFormDuyetDKSPFn: function (_obj) {
        var newDlg = $(_obj);
        var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
        var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);
        var NgayDKSPMenu = $('.NgayDKSPMenu', newDlg);
        var NgayKTDKSPMenu = $('.NgayKTDKSPMenu', newDlg);
        NgayDKSPDacTrung.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayKTDKSPDacTrung.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayDKSPMenu.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayKTDKSPMenu.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    QickSaveDKDVGrid: function (_grid, _hot1, _hot2, _hot3, _hot4) {
        var grid = $(_grid);
        var s = '';
        if (jQuery(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn')) {
                    PublishFn.SaveDKDVSource(grid, s, '', '', '', '', _hot1, _hot2, _hot3, _hot4);
                }
            }
        }
    },
    DetailsSaveDKDVGrid: function (_obj, _grid, validate, fn) {
        var grid = $(_grid);
        var newDlg = $(_obj);

        var _hot1 = '';
        var _hot2 = '';
        var _hot3 = '';
        var _hot4 = '';
        var sptt = '';

        var ID = $('.ID', newDlg);
        var NgayDKSPDacTrung = $('.NgayDKSPDacTrung', newDlg);
        var NgayKTDKSPDacTrung = $('.NgayKTDKSPDacTrung', newDlg);
        var NgayDKSPMenu = $('.NgayDKSPMenu', newDlg);
        var NgayKTDKSPMenu = $('.NgayKTDKSPMenu', newDlg);
        var cbkDKDT = $('.cbkDKDT', newDlg);
        var cbkDKMenu = $('.cbkDKMenu', newDlg);
        var cbkTT = $('.cbkTT', newDlg);
        var err = '';
        var _checkedDt = cbkDKDT.is(':checked');
        var _checkedMenu = cbkDKMenu.is(':checked');
        var _checkedTT = cbkTT.is(':checked');
        var _ID = ID.val();
        if (eval(_checkedDt) == true) {
            var _NgayKTDKSPDacTrung = NgayKTDKSPDacTrung.val();
            var _NgayDKSPDacTrung = NgayDKSPDacTrung.val();
            var convertDateNgayKTDKSPDacTrung = PublishFn.convertDate(NgayKTDKSPDacTrung.val(), '/');
            var convertDateNgayDKSPDacTrung = PublishFn.convertDate(NgayDKSPDacTrung.val(), '/');
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
                _hot1 = 'False';
                _hot3 = 'True';
            }
        }
        else {
            NgayKTDKSPDacTrung.val('');
            NgayDKSPDacTrung.val('');
        }
        if (eval(_checkedMenu) == true) {
            var _NgayKTDKSPMenu = NgayKTDKSPMenu.val();
            var _NgayDKSPMenu = NgayDKSPMenu.val();
            var convertDateNgayKTDKSPMenu = PublishFn.convertDate(NgayKTDKSPMenu.val(), '/');
            var convertDateNgayDKSPMenu = PublishFn.convertDate(NgayDKSPMenu.val(), '/');
            if (Date.parse(convertDateNgayKTDKSPMenu) < Date.parse(convertDateNgayDKSPMenu)) {
                err += 'ngày kết thúc phải lớn hơn ngày đăng ký';
            }
            if (_NgayDKSPMenu == '') {
                err += 'Bạn phải điền ngày bắt đầu';
            }
            if (_NgayKTDKSPMenu == '') {
                err += 'Bạn phải điền ngày hết hạn';
            }
            if (_NgayDKSPMenu != '' && _NgayKTDKSPMenu != '' && (Date.parse(convertDateNgayKTDKSPMenu) > Date.parse(convertDateNgayDKSPMenu))) {
                _hot2 = 'False';
                _hot4 = 'True';
            }
        }
        else {
            NgayKTDKSPMenu.val('');
            NgayDKSPMenu.val('');
        }
        if (eval(_checkedTT) == true) {
            _hot1 = 'False';
            _hot2 = 'False';
        }
        if (err != '') { alert(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        var DateStartMN = NgayDKSPMenu.val();
        var DateEndMN = NgayKTDKSPMenu.val();
        var DateStartDT = NgayDKSPDacTrung.val();
        var DateEndDT = NgayKTDKSPDacTrung.val();
        //console.log('DateStartMN:' + DateStartMN);
        //console.log('DateEndMN:' + DateEndMN);
        //console.log('DateStartDT:' + DateStartDT);
        //console.log('DateEndDT:' + DateEndDT);
        //console.log('hot1:'+ _hot1);
        //console.log('hot2:' + _hot2);
        //console.log('hot3:' + _hot3);
        //console.log('hot4:' + _hot4);
        PublishFn.SaveDKDVSource(grid, _ID, DateStartDT, DateEndDT, DateStartMN, DateEndMN, _hot1, _hot1, _hot3, _hot4);
    },
    SaveDKDVSource: function (_grid, _id, _dateBDDT, _dateKTDT, _dateBDMN, _dateKTMN, _hot1, _hot2, _hot3, _hot4) {
        var grid = $(_grid);
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: PublishFn.urlDefault().toString() + '&subAct=SaveDKDV',
            dataType: 'script',
            data: {
                'ID': _id,
                'Hot1': _hot1,
                'Hot2': _hot2,
                'Hot3': _hot3,
                'Hot4': _hot4,
                'NgayDKSPDT': _dateBDDT,
                'NgayKTDKSPDT': _dateKTDT,
                'NgayDKSPMN': _dateBDMN,
                'NgayKTDKSPMN': _dateKTMN
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery(grid).trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa lưu được dữ liệu');
                }
            }
        });
    },
    keyUpFn: function (_FilterDMSP, _txtSearch, _FilterGH, _grid, _case) {
        var FilterDMSP = $(_FilterDMSP);
        var txtSearch = $(_txtSearch);
        var FilterGH = $(_FilterGH);
        var grid = $(_grid);
        $(FilterDMSP).keyup(function () {
            if ($(FilterDMSP).val() == '') {
                $(FilterDMSP).attr('_value', '');
                if ($(txtSearch).val() == 'Tìm kiếm tin') {
                    $(txtSearch).val('');
                }
                PublishFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
                if ($(txtSearch).val() == '') {
                    $(txtSearch).val('Tìm kiếm tin');
                }
            }
        });

        $(FilterGH).keyup(function () {
            if ($(FilterGH).val() == '') {
                $(FilterGH).attr('_value', '');
                if ($(txtSearch).val() == 'Tìm kiếm tin') {
                    $(txtSearch).val('');
                }
                PublishFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
                if ($(txtSearch).val() == '') {
                    $(txtSearch).val('Tìm kiếm tin');
                }
            }
        });



        $(txtSearch).keyup(function () {
            PublishFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
        });

        adm.watermark(txtSearch, 'Tìm kiếm tin', function () {
            $(txtSearch).val('');
            PublishFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
            $(txtSearch).val('Tìm kiếm tin');
        });
        adm.watermark(FilterDMSP, 'Gõ tên mục tin để lọc', function () {
            if ($(txtSearch).val() == 'Tìm kiếm tin') {
                $(txtSearch).val('');
            }
            PublishFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
            if ($(txtSearch).val() == '') {
                $(txtSearch).val('Tìm kiếm tin');
            }
        });

        adm.watermark(FilterGH, 'Gõ tên gian hàng để lọc', function () {
            if ($(txtSearch).val() == 'Tìm kiếm tin') {
                $(txtSearch).val('');
            }
            PublishFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
            if ($(txtSearch).val() == '') {
                $(txtSearch).val('Tìm kiếm tin');
            }
        });
    },
    search: function (_FilterDMSP, _txtSearch, _FilterGH, _grid, _case) {
        var grid = $(_grid);
        var timerSearch;
        var FilterDMSP = $(_FilterDMSP);
        var txtSearch = $(_txtSearch);
        var FilterGH = $(_FilterGH);
        var q = txtSearch.val();
        if (q == 'Tìm kiếm tin') {
            q = '';
        }
        var dm = $(FilterDMSP).attr('_value');
        var ghid = $(FilterGH).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: PublishFn.urlDefault().toString() + '&subAct=' + _case + '&dm=' + dm + '&q=' + q + '&GH_ID=' + ghid }).trigger('reloadGrid');
        }, 500);
    },
    LoadAutocompletefn: function (_FilterDMSP, _txtSearch, _FilterGH, _grid, _case) {
        var FilterDMSP = $(_FilterDMSP);
        var txtSearch = $(_txtSearch);
        var FilterGH = $(_FilterGH);
        var grid = $(_grid);

        PublishFn.autoCompleteGianHangByUsername(FilterGH, function (event, ui) {
            //console.log('label :' + ui.item.label);
            //console.log('value :' + ui.item.value);
            //console.log('id :' + ui.item.id);
            //console.log('username :' + ui.item.username);
            $(FilterGH).val(ui.item.label);
            $(FilterGH).attr('_value', ui.item.id);
            PublishFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
        });
        $(FilterGH).unbind('click').click(function () {
            $(FilterGH).autocomplete('search', '');
        });
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased("", "SP_NHOM", FilterDMSP, function (event, ui) {
                $(FilterDMSP).attr('_value', ui.item.id);
                PublishFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
            });
            $(FilterDMSP).unbind('click').click(function () {
                $(FilterDMSP).autocomplete('search', '');
            });
        });
    },
    autoCompleteGianHangByUsername: function (el, fn) {
        var term = 'thanhvien-Gianhang';
        $(el).autocomplete({
            source: function (request, response) {
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.GH_Ten,
                                value: item.GH_Ten,
                                id: item.GH_ID,
                                username: item.Username
                            }
                        }
                    }))
                    return;
                }
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: PublishFn.urlDefault().toString() + '&subAct=UserGianHangAutoComplete',
                    dataType: 'script',
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.GH_Ten,
                                        value: item.GH_Ten,
                                        id: item.GH_ID,
                                        username: item.Username
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
            }, change: function (event, ui) {
            },
            delay: 0,
            selectFirst: true
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
                				    .data("item.autocomplete", item)
                				    .append("<a><b>" + item.username + "</b>: " + item.label + "</a>")
                				    .appendTo(ul);
        };
        $(el).unbind('click').click(function () {
            $(el).autocomplete('search', '');
        });
    },
    ChuyenTinBanGiong: function (_grid) {
        var grid = $(_grid);
        var s = '';
        s = jQuery(grid).jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin');
        }
        else {
            if (confirm('Bạn có chắc chắn muốn chuyển sáng tin bán giống?')) {
                $.ajax({
                    url: PublishFn.urlDefault().toString() + '&subAct=ChuyenThanhTinBanGiong',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        if (dt == '1') {
                            alert('chuyển thành công');
                            jQuery(grid).trigger('reloadGrid');
                        }
                    }
                });

            }
        }
    }
}