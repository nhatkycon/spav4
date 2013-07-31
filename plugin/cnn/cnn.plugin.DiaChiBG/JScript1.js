DiaChiBanGiongFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.DiaChiBG.Class1, cnn.plugin.DiaChiBG'; },
    setup: function () { },
    //    loadHtml: function (_objmain, _objId, _subObjClass, _WebResource, fn) {
    //        var ObjMain = $(_objmain);
    //        var Obj = $(_objId);
    //        var SubObj = $(_subObjClass);
    //        //$(Obj).html('');
    //        if ($(dlg).length < 1) {
    //            adm.loading('Dựng from');
    //            $.ajax({
    //                url: _WebResource,
    //                success: function (dt) {
    //                    adm.loading(null);
    //                    $('body').append(dt);
    //                    if (typeof (fn) == 'function') {
    //                        fn();
    //                    }
    //                }
    //            });
    //        }
    //        else {
    //            if (typeof (fn) == 'function') {
    //                fn();
    //            }
    //        }
    //    },
    loadHtml: function (_objmain, _objId, _subObjClass, fn) {
        var ObjMain = $(_objmain);
        var Obj = $(_objId);
        var SubObj = $(_subObjClass);
        $(Obj).html('');
        adm.loading('Dựng from');
        $.ajax({
            url: '<%=WebResource("cnn.plugin.DiaChiBG.htm.htm")%>',
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
            danhmuc.getSelectTionTest('BANGIONG', danhMucSelectionList, DanhMucBox_show, obj);
            $('.DanhMucBox_show').show();
        });
        $('.danhMucSelection-List').click(function () {
            danhmuc.getSelectTionTest('BANGIONG', danhMucSelectionList, DanhMucBox_show, obj);
            $('.DanhMucBox_show').show();
        });

        var XuatXu_ID = $('.XuatXu_ID', obj);
        var DonVi_ID = $('.DonVi_ID', obj);
        var NoiDung = $('.NoiDung', obj);
        var GNY = $('.GNY', obj);

        danhmuc.autoCompleteLangBased('', 'KV_TINH', XuatXu_ID, function (event, ui) {
            $(XuatXu_ID).attr('_value', ui.item.id);
        });
        $(XuatXu_ID).unbind('click').click(function () { $(XuatXu_ID).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'HH_DV', DonVi_ID, function (event, ui) {
            $(DonVi_ID).attr('_value', ui.item.id);
        });
        $(DonVi_ID).unbind('click').click(function () { $(DonVi_ID).autocomplete('search', ''); });
        adm.createFck(NoiDung);

        $(GNY).unbind('keyup').keyup(function () {
            var strValue = $(this).val();
            $(this).val(adm.numberFormatfn(adm.stripNonNumericfn(strValue)));
        });

        var ulpFn = function () {
            var uploadBtn = $('.adm-upload-btn', obj);
            var uploadView = $('.previewImg', obj);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.upload(uploadBtn, 'anh', _params, function (rs) {
                $(uploadBtn).attr('ref', rs)
                $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();
    },
    clearform: function (_obj) {
        var newDlg = $(_obj);
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var imgAnh = $('.previewImg', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var GNY = $('.GNY', newDlg);
        var XuatXu_ID = $('.XuatXu_ID', newDlg);
        var DienThoai = $('.DienThoai', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        ID.val('');
        Ten.val('');
        DM_ID.html('');
        imgAnh.attr('src', '');
        lblAnh.attr('ref', '');
        MoTa.val('');
        NoiDung.val('');
        DonVi_ID.val('');
        GNY.val('');
        XuatXu_ID.val('');
        DienThoai.val('');
        DiaChi.val('');
        spbMsg.html('');
    },
    add: function (_objmain, _obj, _Subobj, _grid) {
        var ObjMain = $(_objmain);
        var obj = $(_obj);
        var Subobj = $(_Subobj);
        var grid = $(_grid);
        DiaChiBanGiongFn.loadHtml(ObjMain, obj, Subobj, function () {
            var newDlg = $(obj);
            $(newDlg).dialog({
                title: 'Thêm địa chỉ bán giống',
                width: 'auto',
                height: 'auto',
                modal: true,
                buttons: {
                    'Lưu': function () {
                        DiaChiBanGiongFn.save(newDlg, grid, false, function () {
                            DiaChiBanGiongFn.clearform(obj);
                        });
                    },
                    'Lưu và đóng': function () {
                        DiaChiBanGiongFn.save(newDlg, grid, false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Ðóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    DiaChiBanGiongFn.clearform(obj);
                },
                open: function () {
                    adm.styleButton();
                    DiaChiBanGiongFn.popfn(obj);
                    DiaChiBanGiongFn.clearform(obj);
                }
            });
        });
    },
    save: function (_obj, _grid, validate, fn) {
        var grid = $(_grid);
        var newDlg = $(_obj);
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var imgAnh = $('.previewImg', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var GNY = $('.GNY', newDlg);
        var XuatXu_ID = $('.XuatXu_ID', newDlg);
        var DienThoai = $('.DienThoai', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var _ID = ID.val();
        var _Ten = Ten.val();
        var _DM_ID = DM_ID.attr('value');
        var _Anh = lblAnh.attr('ref');
        var _NoiDung = NoiDung.val();
        var _MoTa = MoTa.val();
        var _DonVi_ID = DonVi_ID.attr('_value');
        var _GNY = GNY.val();
        var _XuatXu_ID = XuatXu_ID.val();
        var _DienThoai = DienThoai.val();
        var _DiaChi = DiaChi.val();

        var err = '';
        if (_DM_ID == '' || typeof (_DM_ID) == 'undefined') { err += 'Bạn Chọn danh mục<br/>'; };
        if (_Ten == '') { err += 'Nhập tên <br/>'; };
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: DiaChiBanGiongFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                'ID': _ID, //
                'Ten': _Ten, //
                'DM_ID': _DM_ID, //
                'Anh': _Anh, //
                'MoTa': _MoTa, //
                'NoiDung': _NoiDung, //
                'DonVi_ID': _DonVi_ID, //
                'XuatXu_ID': _XuatXu_ID, //
                'GNY': _GNY, //
                'DiaChi': _DiaChi, //
                'DienThoai': _DienThoai//
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
                    url: DiaChiBanGiongFn.urlDefault().toString() + '&subAct=' + _case,
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', 'TT', 'Ảnh', 'Tên', 'Danh mục', 'Thông tin tóm tắt', 'Ngày cập nhật'],
                    colModel: [
                            { name: 'ID', key: true, sortable: true, hidden: true },
                            { name: 'TT', width: 10, key: true, sortable: true, align: "center" },
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
                        DiaChiBanGiongFn.LoadAutocompletefn(FilterDMSP, txtSearch, FilterGHID, grid, _case);
                    },
                    pager: $(pagergrid)
                });

                DiaChiBanGiongFn.keyUpFn(FilterDMSP, txtSearch, FilterGHID, grid, _case);
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                });
                if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }
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
                DiaChiBanGiongFn.loadHtml(ObjMain, obj, Subobj, function () {
                    var newDlg = $(obj);
                    $(newDlg).dialog({
                        title: 'Edit',
                        width: 785,
                        height: 660,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                DiaChiBanGiongFn.save(newDlg, grid, false, function () {
                                    DiaChiBanGiongFn.clearform(obj);
                                });
                            },
                            'Lưu và đóng': function () {
                                DiaChiBanGiongFn.save(newDlg, grid, false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Ðóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            DiaChiBanGiongFn.clearform(obj);
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            DiaChiBanGiongFn.popfn(obj);
                            adm.styleButton();
                            $.ajax({
                                url: DiaChiBanGiongFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var imgAnh = $('.previewImg', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var DonVi_ID = $('.DonVi_ID', newDlg);
                                    var GNY = $('.GNY', newDlg);
                                    var XuatXu_ID = $('.XuatXu_ID', newDlg);
                                    var DienThoai = $('.DienThoai', newDlg);
                                    var DiaChi = $('.DiaChi', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    DiaChi.val(dt.DiaChi);
                                    DienThoai.val(dt.DienThoai);
                                    ID.val(dt.ID);
                                    Ten.val(dt.Ten);
                                    $(lblAnh).attr('ref', dt.Anh);
                                    if (dt.Anh != '') {
                                        $(imgAnh).attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());
                                    }
                                    NoiDung.val(dt.NoiDung);
                                    MoTa.val(dt.Mota);
                                    $(DM_ID).attr('value', dt.DM_ID);
                                    DonVi_ID.val(dt._DM_DonVi);
                                    DonVi_ID.attr('_value', dt.DonViTinh);
                                    XuatXu_ID.val(dt.NoiDang);
                                    //XuatXu_ID.attr('_value', dt.XuatXu_ID);
                                    GNY.val(dt.Gia);
                                    $.ajax({
                                        url: DiaChiBanGiongFn.urlDefault().toString() + '&subAct=SelectTreeParentByDmId',
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
                    //                    var treedata = $("#DiaChiBanGiongFnMdl-List").jqGrid('getRowData', s); // L?y row hi?n t?i dang select
                    //                    var __DM_ID = treedata._DM_ID; // L?y DM_ID th?t c?a danh m?c
                    $.ajax({
                        url: DiaChiBanGiongFn.urlDefault().toString() + '&subAct=del',
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
                DiaChiBanGiongFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
                if ($(txtSearch).val() == '') {
                    $(txtSearch).val('Tìm kiếm tin');
                }
            }
        });

//        $(FilterGH).keyup(function () {
//            if ($(FilterGH).val() == '') {
//                $(FilterGH).attr('_value', '');
//                if ($(txtSearch).val() == 'Tìm kiếm tin') {
//                    $(txtSearch).val('');
//                }
//                DiaChiBanGiongFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
//                if ($(txtSearch).val() == '') {
//                    $(txtSearch).val('Tìm kiếm tin');
//                }
//            }
//        });



        $(txtSearch).keyup(function () {
            DiaChiBanGiongFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
        });

        adm.watermark(txtSearch, 'Tìm kiếm tin', function () {
            $(txtSearch).val('');
            DiaChiBanGiongFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
            $(txtSearch).val('Tìm kiếm tin');
        });
        adm.watermark(FilterDMSP, 'Gõ tên mục tin để lọc', function () {
            if ($(txtSearch).val() == 'Tìm kiếm tin') {
                $(txtSearch).val('');
            }
            DiaChiBanGiongFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
            if ($(txtSearch).val() == '') {
                $(txtSearch).val('Tìm kiếm tin');
            }
        });

//        adm.watermark(FilterGH, 'Gõ tên gian hàng để lọc', function () {
//            if ($(txtSearch).val() == 'Tìm kiếm tin') {
//                $(txtSearch).val('');
//            }
//            DiaChiBanGiongFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
//            if ($(txtSearch).val() == '') {
//                $(txtSearch).val('Tìm kiếm tin');
//            }
//        });
    },
    search: function (_FilterDMSP, _txtSearch, _FilterGH, _grid, _case) {
        var grid = $(_grid);
        var timerSearch;
        var FilterDMSP = $(_FilterDMSP);
        var txtSearch = $(_txtSearch);
//        var FilterGH = $(_FilterGH);
        var q = txtSearch.val();
        if (q == 'Tìm kiếm tin') {
            q = '';
        }
        var dm = $(FilterDMSP).attr('_value');
//        var ghid = $(FilterGH).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: DiaChiBanGiongFn.urlDefault().toString() + '&subAct=' + _case + '&dm=' + dm + '&q=' + q}).trigger('reloadGrid');
        }, 500);
    },
    LoadAutocompletefn: function (_FilterDMSP, _txtSearch, _FilterGH, _grid, _case) {
        var FilterDMSP = $(_FilterDMSP);
        var txtSearch = $(_txtSearch);
        var FilterGH = $(_FilterGH);
        var grid = $(_grid);
//        DiaChiBanGiongFn.autoCompleteGianHangByUsername(FilterGH, function (event, ui) {
//            $(FilterGH).val(ui.item.label);
//            $(FilterGH).attr('_value', ui.item.id);
//            DiaChiBanGiongFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
//        });
//        $(FilterGH).unbind('click').click(function () {
//            $(FilterGH).autocomplete('search', '');
//        });
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased("", "BANGIONG", FilterDMSP, function (event, ui) {
                $(FilterDMSP).attr('_value', ui.item.id);
                DiaChiBanGiongFn.search(FilterDMSP, txtSearch, FilterGH, grid, _case);
            });
            $(FilterDMSP).unbind('click').click(function () {
                $(FilterDMSP).autocomplete('search', '');
            });
        });
    },
    LoadGridfn: function () {
        var _obj = $('#DiaChiBanGiongFnMdl-HangHoatempMdl-dlgNew');
        var _pagergrid = $('#DiaChiBanGiongFnMdl-Pager');
        var _grid = $('#DiaChiBanGiongFnMdl-List');
        var _FilterDMSP = $('.FilterDMSP', '#DiaChiBanGiongFnMdl-Main');
        var _txtSearch = $('.txtSearch', '#DiaChiBanGiongFnMdl-Main');
        DiaChiBanGiongFn.loadgridAdmCase(_obj, _grid, _pagergrid, 'get', 'Danh sách sản phẩm mới', _FilterDMSP, _txtSearch);
    },
    addfn: function () {
        var _objMain = $('#DiaChiBanGiongFnMdl-Main');
        var _obj = $('#DiaChiBanGiongFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.DiaChiBanGiongtempMdl-dlgNew');
        var _grid = $('#DiaChiBanGiongFnMdl-List');
        DiaChiBanGiongFn.add(_objMain, _obj, _Subobj, _grid);
    },
    delfn: function () {
        var _grid = $('#DiaChiBanGiongFnMdl-List');
        DiaChiBanGiongFn.del(_grid);
    },
    editfn: function () {
        var _objMain = $('#DiaChiBanGiongFnMdl-Main');
        var _obj = $('#DiaChiBanGiongFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.DiaChiBanGiongtempMdl-dlgNew');
        var _grid = $('#DiaChiBanGiongFnMdl-List');
        DiaChiBanGiongFn.edit(_objMain, _obj, _Subobj, _grid);
    }
}