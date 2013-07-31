dkdvtrvFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.Raovatcontrol.DKDVTRV.Class1, cnn.plugin.Raovatcontrol.DKDVTRV',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();

        //        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
        //            languageFn.setup(function()
        //            {});

        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $('#RaovatFnMdl-subDKDVMdl-List').jqGrid({
                    url: dkdvtrvFn.urlDefault + '&subAct=get',
                    datatype: 'json',
                    height: 'auto',
                    loadui: 'disable',
                    colNames: ['ID', 'Ảnh', 'Tiêu đề', 'Mục tin', 'Super', 'Hết hạn', 'Vip', 'Hết hạn', 'Nổi bật', 'Hết hạn', 'Ngày cập nhật', ''],
                    colModel: [
                { name: 'RV_ID', key: true, sortable: true, hidden: true },
                { name: 'RV_Anh1', width: 100, sortable: true, align: "center" },
                { name: 'RV_Ten', width: 100, resizable: true, sortable: true },
                { name: 'RV_DM_Ten', width: 50, sortable: true },
                { name: 'RV_DangKy_SUPER', width: 10, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                { name: 'RV_NgayCapNhat', width: 50, resizable: true, sortable: true },
                { name: 'RV_DangKy_VIP', width: 10, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                { name: 'RV_NgayCapNhat', width: 50, resizable: true, sortable: true },
                { name: 'RV_DangKy_NoiBat', width: 10, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                { name: 'RV_NgayCapNhat', width: 50, resizable: true, sortable: true },
                { name: 'RV_NgayCapNhat', width: 50, resizable: true, sortable: true },
                { name: 'Task', width: 20, resizable: true, sortable: false, align: "center" }
            ],
                    caption: 'Danh sách tin chờ duyệt',
                    sortname: 'RV_NgayCapNhat',
                    autowidth: true,
                    sortorder: 'asc',
                    multiselect: true,
                    rowNum: 10000,
                    onSelectRow: function (rowid) { },
                    loadComplete: function () {
                        adm.loading(null);
                        var txtfilter = $('.mdl-head-filterDMraovat','#RaoVatSubmdl-head');
                        var txtfilterNC = $('.mdl-head-filterNCraovat','#RaoVatSubmdl-head');
                        var txtfilterTINH = $('.mdl-head-filterTINHraovat','#RaoVatSubmdl-head');
                        adm.watermarks(function () {
                        });
                        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                            danhmuc.autoCompleteLangBased("", "RV-DM", txtfilter, function (event, ui) {
                                $(txtfilter).attr('_value', ui.item.id);
                                dkdvtrvFn.search();
                            });
                            $(txtfilter).unbind('click').click(function () {
                                $(txtfilter).autocomplete('search', '');
                            });


                            danhmuc.autoCompleteLangBased("", "KV-TINH", txtfilterTINH, function (event, ui) {
                                $(txtfilterTINH).attr('_value', ui.item.id);
                                dkdvtrvFn.search();
                            });
                            $(txtfilterTINH).unbind('click').click(function () {
                                $(txtfilterTINH).autocomplete('search', '');
                            });

                            danhmuc.autoCompleteLangBased("", "NC-MB", txtfilterNC, function (event, ui) {
                                $(txtfilterNC).attr('_value', ui.item.id);
                                dkdvtrvFn.search();
                            });
                            $(txtfilterNC).unbind('click').click(function () {
                                $(txtfilterNC).autocomplete('search', '');
                            });
                        });
                    }
                });
            });
        });

        var filterLoaiDanhMucID = $('.mdl-head-filterDMraovat');
        var filterNCID = $('.mdl-head-filterNCraovat');
        var filterTINHID = $('.mdl-head-filterTINHraovat');
        var searchTxt = $('.mdl-head-search-RaovatMdl-subDKFVMdl');


        $(filterLoaiDanhMucID).keyup(function () {
            if ($(filterLoaiDanhMucID).val() == '') {
                $(filterLoaiDanhMucID).attr('_value', '');
                if ($(searchTxt).val() == 'Tìm kiếm tin rao vặt') {
                    $(searchTxt).val('');
                }
                dkdvtrvFn.search();
                if ($(searchTxt).val() == '') {
                    $(searchTxt).val('Tìm kiếm tin rao vặt');
                }
            }
        });
        $(filterNCID).keyup(function () {
            if ($(filterNCID).val() == '') {
                $(filterNCID).attr('_value', '');
                if ($(searchTxt).val() == 'Tìm kiếm tin rao vặt') {
                    $(searchTxt).val('');
                }
                dkdvtrvFn.search();
                if ($(searchTxt).val() == '') {
                    $(searchTxt).val('Tìm kiếm tin rao vặt');
                }
            }
        });

        $(filterTINHID).keyup(function () {
            if ($(filterTINHID).val() == '') {
                $(filterTINHID).attr('_value', '');
                if ($(searchTxt).val() == 'Tìm kiếm tin rao vặt') {
                    $(searchTxt).val('');
                }
                dkdvtrvFn.search();
                if ($(searchTxt).val() == '') {
                    $(searchTxt).val('Tìm kiếm tin rao vặt');
                }
            }
        });

        $(searchTxt).keyup(function () {
            dkdvtrvFn.search();
        });
        adm.watermark(searchTxt, 'Tìm kiếm tin rao vặt', function () {
            $(searchTxt).val('');
            dkdvtrvFn.search();
            $(searchTxt).val('Tìm kiếm tin rao vặt');
        });

        adm.watermark(filterLoaiDanhMucID, 'Gõ tên mục tin để lọc', function () {
            if ($(searchTxt).val() == 'Tìm kiếm tin rao vặt') {
                $(searchTxt).val('');
            }
            dkdvtrvFn.search();
            if ($(searchTxt).val() == '') {
                $(searchTxt).val('Tìm kiếm tin rao vặt');
            }
        });

        adm.watermark(filterNCID, 'Gõ tên nhu cầu để lọc', function () {
            if ($(searchTxt).val() == 'Tìm kiếm tin rao vặt') {
                $(searchTxt).val('');
            }
            dkdvtrvFn.search();
            if ($(searchTxt).val() == '') {
                $(searchTxt).val('Tìm kiếm tin rao vặt');
            }
        });

        adm.watermark(filterTINHID, 'Gõ tên Khu vực để lọc', function () {
            if ($(searchTxt).val() == 'Tìm kiếm tin rao vặt') {
                $(searchTxt).val('');
            }
            dkdvtrvFn.search();
            if ($(searchTxt).val() == '') {
                $(searchTxt).val('Tìm kiếm tin rao vặt');
            }
        });
    },
    duyet: function () {
        var s = '';
        s = jQuery('#RaovatFnMdl-subDKDVMdl-List').jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để duyệt');
        }
        else {
            if (confirm('Bạn có chắc chắn duyệt các mẩu tin này?')) {
                $.ajax({
                    url: dkdvtrvFn.urlDefault + '&subAct=duyet',
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery('#RaovatFnMdl-subDKDVMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    },
    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-RaovatMdl-subDKFVMdl');
        var searchDM = $('.mdl-head-filterDMraovat');
        var searchNC = $('.mdl-head-filterNCraovat');
        var searchTINH = $('.mdl-head-filterTINHraovat');
        //var searchTxt = $('.mdl-head-search-Raovat');
        var q = filterDM.val();
        if (q == 'Tìm kiếm tin rao vặt') {
            q = '';
        }
        //var _Lang = $('#Raovatdl-changeLangSlt').val();
        var dm = $(searchDM).attr('_value');
        var nc = $(searchNC).attr('_value');
        var tinh = $(searchTINH).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#RaovatFnMdl-subDKDVMdl-List').jqGrid('setGridParam', { url: dkdvtrvFn.urlDefault + "&subAct=get&q=" + q + "&DM_ID=" + dm + '&TINH_ID=' + tinh + '&NC_ID=' + nc }).trigger("reloadGrid");
        }, 500);
    },
    loadHtml: function (fn) {
        var dlg = $('#RaovatFnMdl-subDKDVMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.Raovatcontrol.DKDVTRV.htm.htm")%>',
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
    clearform: function () {
        var newDlg = $('#RaovatFnMdl-subDKDVMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);

        var KV_ID = $('.KV_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var LangSlt = $('.Lang', newDlg);
        var NhuCau_ID = $('.NhuCau_ID', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Active = $('.Active', newDlg);
        var Publish = $('.Publish', newDlg);
        var Hot = $('.Hot', newDlg);
        var Super = $('.Super', newDlg);
        var Vip = $('.Vip', newDlg);
        var NgayHetHanhot = $('.NgayHetHanhot', newDlg);
        var NgayHetHanSuper = $('.NgayHetHanSuper', newDlg);
        var NgayHetHanVip = $('.NgayHetHanVip', newDlg);
        var NgayHetHan = $('.NgayHetHan', newDlg);

        var NgayHetHanDKhot = $('.NgayHetHanDKhot', newDlg);
        var NgayHetHanDKSuper = $('.NgayHetHanDKSuper', newDlg);
        var NgayHetHanDKVip = $('.NgayHetHanDKVip', newDlg);

        var DKhot = $('.DKHot', newDlg);
        var DKSuper = $('.DKSuper', newDlg);
        var DKVip = $('.DKVip', newDlg);


        var spbMsg = $('.admMsg', newDlg);
        ID.val('');
        NgayHetHan.val();
        Ten.val('');
        MoTa.val('');
        NhuCau_ID.val('');
        DM_ID.val('');
        KV_ID.val('');
        imgAnh.attr('src', '');
        lblAnh.attr('ref', '');
        NoiDung.val('');
        Active.removeAttr('checked');
        Publish.removeAttr('checked');
        DKhot.removeAttr('checked');
        DKSuper.removeAttr('checked');
        DKVip.removeAttr('checked');
        Hot.removeAttr('checked');
        Super.removeAttr('checked');
        Vip.removeAttr('checked');
        spbMsg.html('');
        NgayHetHanhot.val('');
        NgayHetHanSuper.val('');
        NgayHetHanVip.val('');
        NgayHetHan.val('');

        NgayHetHanDKhot.val('');
        NgayHetHanDKSuper.val('');
        NgayHetHanDKVip.val('');
    },
    View: function (_obj) {
        var item = $(_obj);
        if ($(item).length == 0) return false;
        var _id = $(item).attr('_id');
        dkdvtrvFn.loadHtml(function () {
            dkdvtrvFn.popfn();
            var newDlg = $('#RaovatFnMdl-subDKDVMdl-dlgNew');

            $('.adm-col-header-admin', newDlg).show();

            $(newDlg).dialog({
                title: 'Sửa',
                width: 900,
                height: 560,
                position: [200, 0],
                buttons: {
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    dkdvtrvFn.clearform();
                },
                open: function () {
                    //$('.adm-col-header-admin').addClass('adm-col-header-admin-hide');
                    adm.loading('Đang nạp dữ liệu');
                    adm.styleButton();
                    $.ajax({
                        url: dkdvtrvFn.urlDefault + '&subAct=edit',
                        dataType: 'script',
                        data: {
                            'ID': _id
                        },
                        success: function (_dt) {
                            $('.admdisabled').attr('disabled', 'disabled');
                            adm.loading(null);
                            var dt = eval(_dt);
                            var ID = $('.ID', newDlg);
                            var DM_ID = $('.DM_ID', newDlg);
                            var KV_ID = $('.KV_ID', newDlg);
                            var Ten = $('.Ten', newDlg);
                            var LangSlt = $('.Lang', newDlg);
                            var NhuCau_ID = $('.NhuCau_ID', newDlg);
                            var MoTa = $('.MoTa', newDlg);
                            var imgAnh = $('.adm-upload-preview-img', newDlg);
                            var lblAnh = $('.Anh', newDlg);
                            var NoiDung = $('.NoiDung', newDlg);
                            var Publish = $('.Publish', newDlg);
                            var DKhot = $('.DKHot', newDlg);
                            var DKSuper = $('.DKSuper', newDlg);
                            var DKVip = $('.DKVip', newDlg);

                            var NgayHetHanDKhot = $('.NgayHetHanDKhot', newDlg);
                            var __NgayHetHanDKhot = new Date(dt.VIP_NoiBat_NgayHetHan);
                            var _NgayHetHanDKhot = __NgayHetHanDKhot.getDate() + '/' + (__NgayHetHanDKhot.getMonth() + 1) + '/' + __NgayHetHanDKhot.getFullYear();
                            if (_NgayHetHanhot == '1/1/1970') {
                                NgayHetHanDKhot.val('');
                            }
                            else {
                                NgayHetHanDKhot.val(_NgayHetHanDKhot);
                            }

                            var NgayHetHanDKSuper = $('.NgayHetHanDKSuper', newDlg);
                            var __NgayHetHanDKSuper = new Date(dt.VIP_SUPER_NgayHetHan);
                            var _NgayHetHanDKSuper = __NgayHetHanDKSuper.getDate() + '/' + (__NgayHetHanDKSuper.getMonth() + 1) + '/' + __NgayHetHanDKSuper.getFullYear();
                            if (_NgayHetHanDKSuper == '1/1/1970') {
                                NgayHetHanDKSuper.val('');
                            }
                            else {
                                NgayHetHanDKSuper.val(_NgayHetHanDKSuper);
                            }
                            var NgayHetHanDKVip = $('.NgayHetHanDKVip', newDlg);
                            var __NgayHetHanDKVip = new Date(dt.VIP_VIP_NgayHetHan);
                            var _NgayHetHanDKVip = __NgayHetHanDKVip.getDate() + '/' + (__NgayHetHanDKVip.getMonth() + 1) + '/' + __NgayHetHanDKVip.getFullYear();
                            if (_NgayHetHanDKVip == '1/1/1970') {
                                NgayHetHanDKVip.val('');
                            }
                            else {
                                NgayHetHanDKVip.val(_NgayHetHanDKVip);
                            }

                            var NgayHetHanhot = $('.NgayHetHanhot', newDlg);
                            var __NgayHetHanhot = new Date(dt.VIP_NoiBat_NgayHetHan);
                            var _NgayHetHanhot = __NgayHetHanhot.getDate() + '/' + (__NgayHetHanhot.getMonth() + 1) + '/' + __NgayHetHanhot.getFullYear();
                            if (_NgayHetHanhot == '1/1/1970') {
                                NgayHetHanhot.val('');
                            }
                            else {
                                NgayHetHanhot.val(_NgayHetHanhot);
                            }

//                            var __NgayHetHanDKhot = new Date(dt.VIP_NoiBat_NgayHetHan);
//                            var _NgayHetHanDKhot = __NgayHetHanDKhot.getDate() + '/' + (__NgayHetHanDKhot.getMonth() + 1) + '/' + __NgayHetHanDKhot.getFullYear();
//                            if (_NgayHetHanDKhot == '1/1/1970') {
//                                NgayHetHanDKhot.val('');
//                            }
//                            else {
//                                NgayHetHanDKhot.val(_NgayHetHanDKhot);
//                            }


                            var NgayHetHanSuper = $('.NgayHetHanSuper', newDlg);
                            var __NgayHetHanSuper = new Date(dt.VIP_SUPER_NgayHetHan);
                            var _NgayHetHanSuper = __NgayHetHanSuper.getDate() + '/' + (__NgayHetHanSuper.getMonth() + 1) + '/' + __NgayHetHanSuper.getFullYear();
                            if (_NgayHetHanSuper == '1/1/1970') {
                                NgayHetHanSuper.val('');
                            }
                            else {
                                NgayHetHanSuper.val(_NgayHetHanSuper);
                            }
                            var NgayHetHanVip = $('.NgayHetHanVip', newDlg);
                            var __NgayHetHanVip = new Date(dt.VIP_VIP_NgayHetHan);
                            var _NgayHetHanVip = __NgayHetHanVip.getDate() + '/' + (__NgayHetHanVip.getMonth() + 1) + '/' + __NgayHetHanVip.getFullYear();
                            if (_NgayHetHanVip == '1/1/1970') {
                                NgayHetHanVip.val('');
                            }
                            else {
                                NgayHetHanVip.val(_NgayHetHanVip);
                            }

                            var NgayHetHan = $('.NgayHetHan', newDlg);
                            var __NgayHetHan = new Date(dt.NgayHetHan);
                            var _NgayHetHan = __NgayHetHan.getDate() + '/' + (__NgayHetHan.getMonth() + 1) + '/' + __NgayHetHan.getFullYear();
                            if (_NgayHetHan == '1/1/1970') {
                                NgayHetHan.val('');
                            }
                            else {
                                NgayHetHan.val(_NgayHetHan);
                            }
                            var spbMsg = $('.admMsg', newDlg);

                            ID.val(dt.ID);
                            DM_ID.val(dt._DM_Ten);
                            DM_ID.attr('_value', dt.DM_ID);
                            KV_ID.val(dt._Tinh_Ten)
                            KV_ID.attr('_value', dt.TINH_ID);
                            NhuCau_ID.val(dt._Nhucau_Ten)
                            NhuCau_ID.attr('_value', dt.NC_ID);
                            Ten.val(dt.Ten);
                            MoTa.val(dt.MoTa);
                            $(lblAnh).attr('ref', dt.Anh1);
                            if (dt.Anh1 != '') {
                                $(imgAnh).attr('src', '../up/i/' + dt.Anh1 + '?ref=' + Math.random());
                            }

                            NoiDung.val(dt.NoiDung);
                            if (dt.Publish) { Publish.attr('checked', 'checked'); } else { Publish.removeAttr('checked'); }
                            if (dt.DangKy_SUPER) { DKSuper.attr('checked', 'checked'); } else { DKSuper.removeAttr('checked'); }
                            if (dt.DangKy_VIP) { DKVip.attr('checked', 'checked'); } else { DKVip.removeAttr('checked'); }
                            if (dt.DangKy_NoiBat) { DKhot.attr('checked', 'checked'); } else { DKhot.removeAttr('checked'); }

                            adm.createFck(NoiDung);
                            $('.NgayHetHan', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });

                            LangSlt.val(dt.Lang);
                            if ($(LangSlt).children().length > 0) { return false; }
                            $(LangSlt).find('option').remove();
                            $.each(LangArr, function (i, item) {
                                if (item.Active) {
                                    Lang = item.Ma;
                                }
                                $(LangSlt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                            });
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
                        }
                    });
                }
            });
        });
    },
    duyetbyadm: function (validate, fn) {
        dkdvtrvFn.popfn();
        var newDlg = $('#RaovatFnMdl-subDKDVMdl-dlgNew');

        var ID = $('.ID', newDlg);
        var DKhot = $('.DKHot', newDlg);
        var NgayHetHanhot = $('.NgayHetHanDKhot', newDlg);
        var DKSuper = $('.DKSuper', newDlg);
        var NgayHetHanSuper = $('.NgayHetHanDKSuper', newDlg);
        var DKVip = $('.DKVip', newDlg);
        var NgayHetHanVip = $('.NgayHetHanDKVip', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _DKhot = DKhot.is(':checked');
        var _DKSuper = DKSuper.is(':checked');
        var _DKVip = DKVip.is(':checked');
        var _NgayHetHanhot = NgayHetHanhot.val();
        var _NgayHetHanSuper = NgayHetHanSuper.val();
        var _NgayHetHanVip = NgayHetHanVip.val();

        var err = '';
        if (_DKhot == true) {
            if (_NgayHetHanhot == '') {
                err += 'bạn chưa chọn ngày hết hạn hot';
            }
        }
        if (_NgayHetHanhot != '') {
            if (_DKhot == false) {
                err += 'bạn chưa chọn chọn đăng ký hot';
            }
        }
        if (_DKSuper == true) {
            if (_NgayHetHanSuper == '') {
                err += 'bạn chưa chọn ngày hết hạn super';
            }
        }
        if (_NgayHetHanSuper != '') {
            if (_DKSuper == false) {
                err += 'bạn chưa chọn chọn đăng ký super';
            }
        }
        if (_DKVip == true) {
            if (_NgayHetHanVip == '') {
                err += 'bạn chưa chọn ngày hết hạn vip';
            }
        }
        if (_NgayHetHanVip != '') {
            if (_DKVip == false) {
                err += 'bạn chưa chọn chọn đăng ký vip';
            }
        }

        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');

        $.ajax({
            url: dkdvtrvFn.urlDefault + '&subAct=SaveDuyet',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'DKhot': _DKhot,
                'DKsuper': _DKSuper,
                'DKvip': _DKVip,
                'VIP_NoiBat_NgayHetHan': _NgayHetHanhot,
                'VIP_VIP_NgayHetHan': _NgayHetHanVip,
                'VIP_SUPER_NgayHetHan': _NgayHetHanSuper
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#RaovatFnMdl-subDKDVMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    admDuyet: function (_obj) {
        var item = $(_obj);
        if ($(item).length == 0) return false;
        var _id = $(item).attr('_id');
        dkdvtrvFn.loadHtml(function () {
            dkdvtrvFn.popfn();
            var newDlg = $('#RaovatFnMdl-subDKDVMdl-dlgNew');

            $('.adm-col-header-admin', newDlg).show();

            $(newDlg).dialog({
                title: 'Sửa',
                width: 900,
                height: 560,
                position: [200, 0],
                buttons: {
                    'Duyệt và đóng': function () {
                        dkdvtrvFn.duyetbyadm(false, function () {
                            dkdvtrvFn.clearform();
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    dkdvtrvFn.clearform();
                },
                open: function () {
                    //$('.adm-col-header-admin').addClass('adm-col-header-admin-hide');
                    adm.loading('Đang nạp dữ liệu');
                    adm.styleButton();
                    $.ajax({
                        url: dkdvtrvFn.urlDefault + '&subAct=edit',
                        dataType: 'script',
                        data: {
                            'ID': _id
                        },
                        success: function (_dt) {
                            $('.admdisabled').attr('disabled', 'disabled');
                            adm.loading(null);
                            var dt = eval(_dt);
                            var ID = $('.ID', newDlg);
                            var DM_ID = $('.DM_ID', newDlg);
                            var KV_ID = $('.KV_ID', newDlg);
                            var Ten = $('.Ten', newDlg);
                            var LangSlt = $('.Lang', newDlg);
                            var NhuCau_ID = $('.NhuCau_ID', newDlg);
                            var MoTa = $('.MoTa', newDlg);
                            var imgAnh = $('.adm-upload-preview-img', newDlg);
                            var lblAnh = $('.Anh', newDlg);
                            var NoiDung = $('.NoiDung', newDlg);
                            var Publish = $('.Publish', newDlg);
                            var DKhot = $('.DKHot', newDlg);
                            var DKSuper = $('.DKSuper', newDlg);
                            var DKVip = $('.DKVip', newDlg);

                            var NgayHetHanDKhot = $('.NgayHetHanDKhot', newDlg);
                            var __NgayHetHanDKhot = new Date(dt.VIP_NoiBat_NgayHetHan);
                            var _NgayHetHanDKhot = __NgayHetHanDKhot.getDate() + '/' + (__NgayHetHanDKhot.getMonth() + 1) + '/' + __NgayHetHanDKhot.getFullYear();
                            if (_NgayHetHanhot == '1/1/1970') {
                                NgayHetHanDKhot.val('');
                            }
                            else {
                                NgayHetHanDKhot.val(_NgayHetHanDKhot);
                            }

                            var NgayHetHanDKSuper = $('.NgayHetHanDKSuper', newDlg);
                            var __NgayHetHanDKSuper = new Date(dt.VIP_SUPER_NgayHetHan);
                            var _NgayHetHanDKSuper = __NgayHetHanDKSuper.getDate() + '/' + (__NgayHetHanDKSuper.getMonth() + 1) + '/' + __NgayHetHanDKSuper.getFullYear();
                            if (_NgayHetHanDKSuper == '1/1/1970') {
                                NgayHetHanDKSuper.val('');
                            }
                            else {
                                NgayHetHanDKSuper.val(_NgayHetHanDKSuper);
                            }
                            var NgayHetHanDKVip = $('.NgayHetHanDKVip', newDlg);
                            var __NgayHetHanDKVip = new Date(dt.VIP_VIP_NgayHetHan);
                            var _NgayHetHanDKVip = __NgayHetHanDKVip.getDate() + '/' + (__NgayHetHanDKVip.getMonth() + 1) + '/' + __NgayHetHanDKVip.getFullYear();
                            if (_NgayHetHanDKVip == '1/1/1970') {
                                NgayHetHanDKVip.val('');
                            }
                            else {
                                NgayHetHanDKVip.val(_NgayHetHanDKVip);
                            }

                            var NgayHetHanhot = $('.NgayHetHanhot', newDlg);
                            var __NgayHetHanhot = new Date(dt.VIP_NoiBat_NgayHetHan);
                            var _NgayHetHanhot = __NgayHetHanhot.getDate() + '/' + (__NgayHetHanhot.getMonth() + 1) + '/' + __NgayHetHanhot.getFullYear();
                            if (_NgayHetHanhot == '1/1/1970') {
                                NgayHetHanhot.val('');
                            }
                            else {
                                NgayHetHanhot.val(_NgayHetHanhot);
                            }

//                            var __NgayHetHanDKhot = new Date(dt.VIP_NoiBat_NgayHetHan);
//                            var _NgayHetHanDKhot = __NgayHetHanDKhot.getDate() + '/' + (__NgayHetHanDKhot.getMonth() + 1) + '/' + __NgayHetHanDKhot.getFullYear();
//                            if (_NgayHetHanDKhot == '1/1/1970') {
//                                NgayHetHanDKhot.val('');
//                            }
//                            else {
//                                NgayHetHanDKhot.val(_NgayHetHanDKhot);
//                            }


                            var NgayHetHanSuper = $('.NgayHetHanSuper', newDlg);
                            var __NgayHetHanSuper = new Date(dt.VIP_SUPER_NgayHetHan);
                            var _NgayHetHanSuper = __NgayHetHanSuper.getDate() + '/' + (__NgayHetHanSuper.getMonth() + 1) + '/' + __NgayHetHanSuper.getFullYear();
                            if (_NgayHetHanSuper == '1/1/1970') {
                                NgayHetHanSuper.val('');
                            }
                            else {
                                NgayHetHanSuper.val(_NgayHetHanSuper);
                            }
                            var NgayHetHanVip = $('.NgayHetHanVip', newDlg);
                            var __NgayHetHanVip = new Date(dt.VIP_VIP_NgayHetHan);
                            var _NgayHetHanVip = __NgayHetHanVip.getDate() + '/' + (__NgayHetHanVip.getMonth() + 1) + '/' + __NgayHetHanVip.getFullYear();
                            if (_NgayHetHanVip == '1/1/1970') {
                                NgayHetHanVip.val('');
                            }
                            else {
                                NgayHetHanVip.val(_NgayHetHanVip);
                            }

                            var NgayHetHan = $('.NgayHetHan', newDlg);
                            var __NgayHetHan = new Date(dt.NgayHetHan);
                            var _NgayHetHan = __NgayHetHan.getDate() + '/' + (__NgayHetHan.getMonth() + 1) + '/' + __NgayHetHan.getFullYear();
                            if (_NgayHetHan == '1/1/1970') {
                                NgayHetHan.val('');
                            }
                            else {
                                NgayHetHan.val(_NgayHetHan);
                            }
                            var spbMsg = $('.admMsg', newDlg);

                            ID.val(dt.ID);
                            DM_ID.val(dt._DM_Ten);
                            DM_ID.attr('_value', dt.DM_ID);
                            KV_ID.val(dt._Tinh_Ten)
                            KV_ID.attr('_value', dt.TINH_ID);
                            NhuCau_ID.val(dt._Nhucau_Ten)
                            NhuCau_ID.attr('_value', dt.NC_ID);
                            Ten.val(dt.Ten);
                            MoTa.val(dt.MoTa);
                            $(lblAnh).attr('ref', dt.Anh1);
                            if (dt.Anh1 != '') {
                                $(imgAnh).attr('src', '../up/i/' + dt.Anh1 + '?ref=' + Math.random());
                            }

                            NoiDung.val(dt.NoiDung);
                            if (dt.Publish) { Publish.attr('checked', 'checked'); } else { Publish.removeAttr('checked'); }
                            if (dt.DangKy_SUPER) { DKSuper.attr('checked', 'checked'); } else { DKSuper.removeAttr('checked'); }
                            if (dt.DangKy_VIP) { DKVip.attr('checked', 'checked'); } else { DKVip.removeAttr('checked'); }
                            if (dt.DangKy_NoiBat) { DKhot.attr('checked', 'checked'); } else { DKhot.removeAttr('checked'); }

                            adm.createFck(NoiDung);
                            $('.NgayHetHan', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });

                            LangSlt.val(dt.Lang);
                            if ($(LangSlt).children().length > 0) { return false; }
                            $(LangSlt).find('option').remove();
                            $.each(LangArr, function (i, item) {
                                if (item.Active) {
                                    Lang = item.Ma;
                                }
                                $(LangSlt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                            });
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
                        }
                    });
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#RaovatFnMdl-subDKDVMdl-dlgNew');
        var DM_ID = $('.DM_ID', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var KV_ID = $('.KV_ID', newDlg);
        var NhuCau_ID = $('.NhuCau_ID', newDlg);

        danhmuc.autoCompleteLangBased('', 'RV-DM', DM_ID, function (event, ui) {
            $(DM_ID).attr('_value', ui.item.id);
        });
        $(DM_ID).unbind('click').click(function () { $(DM_ID).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'RV-DM', DM_ID, function (event, ui) {
            $(DM_ID).attr('_value', ui.item.id);
        });

        danhmuc.autoCompleteLangBased('', 'KV-TINH', KV_ID, function (event, ui) {
            $(KV_ID).attr('_value', ui.item.id);
        });
        $(KV_ID).unbind('click').click(function () { $(KV_ID).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'KV-TINH', KV_ID, function (event, ui) {
            $(KV_ID).attr('_value', ui.item.id);
        });

        danhmuc.autoCompleteLangBased('', 'NC-MB', NhuCau_ID, function (event, ui) {
            $(NhuCau_ID).attr('_value', ui.item.id);
        });
        $(NhuCau_ID).unbind('click').click(function () { $(NhuCau_ID).autocomplete('search', ''); });

        danhmuc.autoCompleteLangBased('', 'NC-MB', NhuCau_ID, function (event, ui) {
            $(NhuCau_ID).attr('_value', ui.item.id);
        });

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
        $('.NgayHetHan', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanVip', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanSuper', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanhot', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanDKVip', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanDKSuper', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayHetHanDKhot', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });

    }

}