raovatfn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.raoVatMgr.Class1, cnn.plugin.raoVatMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu tin tức');
        adm.styleButton();
        var DMID = $('.mdl-head-search-Raovat');
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $('#Raovatmdl-list').jqGrid({
                    url: raovatfn.urlDefault + '&subAct=get',
                    datatype: 'json',
                    height: 'auto',
                    loadui: 'disable',
                    colNames: ['ID', 'Ảnh', 'Tiêu đề','Mục tin','Ngày đăng', 'Tên người đăng', 'Publish', 'Active'],
                    colModel: [
                        { name: 'RV_ID', key: true, sortable: true, hidden: true },
                        { name: 'RV_Anh', width: 100, resizable: true, sortable: true, align: "center" },
                        { name: 'RV_Ten', width: 120, resizable: true, sortable: true },
                        { name: 'RV_DM_Ten', width: 50, sortable: true },
                        { name: 'RV_NgayDang', width: 50, resizable: true, sortable: true, align: "center" },
                        { name: 'RV_TenNguoiDang', width: 50, resizable: true, sortable: true, align: "center" },
                        { name: 'RV_Publish', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                        { name: 'RV_Active', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                    ],
                    caption: 'Danh sách tin',
                    autowidth: true,
                    sortname: 'RV_NgayDang',
                    sortorder: 'desc',
                    rowNum: 50,
                    rowList: [50, 100, 200, 300],
                    multiselect: true,
                    pager: jQuery('#Raovatmdl-Page'),
                    onSelectRow: function (rowid) {
                    },
                    loadComplete: function () {
                        adm.loading(null);

                        var txtfilter = $('.mdl-head-filterDMraovat','#RaoVatmdl-head');
                        var txtfilterNC = $('.mdl-head-filterNCraovat','#RaoVatmdl-head');
                        var txtfilterTINH = $('.mdl-head-filterTINHraovat','#RaoVatmdl-head');
                        adm.watermarks(function () {
                        });
                        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                            danhmuc.autoCompleteLangBased("", "RV-DM", txtfilter, function (event, ui) {
                                $(txtfilter).attr('_value', ui.item.id);
                                raovatfn.search();
                            });
                            $(txtfilter).unbind('click').click(function () {
                                $(txtfilter).autocomplete('search', '');
                            });
                            danhmuc.autoCompleteLangBased("", "KV-TINH", txtfilterTINH, function (event, ui) {
                                $(txtfilterTINH).attr('_value', ui.item.id);
                                raovatfn.search();
                            });
                            $(txtfilterTINH).unbind('click').click(function () {
                                $(txtfilterTINH).autocomplete('search', '');
                            });
                            danhmuc.autoCompleteLangBased("", "NC-MB", txtfilterNC, function (event, ui) {
                                $(txtfilterNC).attr('_value', ui.item.id);
                                raovatfn.search();
                            });
                            $(txtfilterNC).unbind('click').click(function () {
                                $(txtfilterNC).autocomplete('search', '');
                            });
                        });
                    }
                });
                var filterLoaiDanhMucID = $('.mdl-head-filterDMraovat');
                var filterNCID = $('.mdl-head-filterNCraovat');
                var filterTINHID = $('.mdl-head-filterTINHraovat');
                var searchTxt = $('.mdl-head-search-Raovat');
                $(filterLoaiDanhMucID).keyup(function () {
                    if ($(filterLoaiDanhMucID).val() == '') {
                        $(filterLoaiDanhMucID).attr('_value', '');
                        if ($(searchTxt).val() == 'Tìm kiếm tin rao vặt') {
                            $(searchTxt).val('');
                        }
                        raovatfn.search();
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
                        raovatfn.search();
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
                        raovatfn.search();
                        if ($(searchTxt).val() == '') {
                            $(searchTxt).val('Tìm kiếm tin rao vặt');
                        }
                    }
                });
                $(searchTxt).keyup(function () {
                    raovatfn.search();
                });
                adm.watermark(searchTxt, 'Tìm kiếm tin rao vặt', function () {
                    $(searchTxt).val('');
                    raovatfn.search();
                    $(searchTxt).val('Tìm kiếm tin rao vặt');
                });
                adm.watermark(filterLoaiDanhMucID, 'Gõ tên mục tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin rao vặt') {
                        $(searchTxt).val('');
                    }
                    raovatfn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin rao vặt');
                    }
                });
                adm.watermark(filterNCID, 'Gõ tên nhu cầu để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin rao vặt') {
                        $(searchTxt).val('');
                    }
                    raovatfn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin rao vặt');
                    }
                });
                adm.watermark(filterTINHID, 'Gõ tên Khu vực để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin rao vặt') {
                        $(searchTxt).val('');
                    }
                    raovatfn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin rao vặt');
                    }
                });
                var changeLangBtn = $('#Raovatdl-changeLangSlt');
                $(changeLangBtn).find('option').remove();
                $.each(LangArr, function (i, item) {
                    if (item.Active) {
                        Lang = item.Ma;
                    }
                    $(changeLangBtn).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                });
                $(changeLangBtn).val(Lang);

                if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }
            });
        });
    },
    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-Raovat');
        var searchDM = $('.mdl-head-filterDMraovat');
        var searchNC = $('.mdl-head-filterNCraovat');
        var searchTINH = $('.mdl-head-filterTINHraovat');
        var q = filterDM.val();
        if (q == 'Tìm kiếm tin rao vặt') {
            q = '';
        }
        var dm = $(searchDM).attr('_value');
        var nc = $(searchNC).attr('_value');
        var tinh = $(searchTINH).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#Raovatmdl-list').jqGrid('setGridParam', { url: raovatfn.urlDefault + "&subAct=get&q=" + q + "&DM_ID=" + dm + '&TINH_ID=' + tinh + '&NC_ID=' + nc }).trigger("reloadGrid");
        }, 500);
    },
    add: function () {
        raovatfn.loadHtml(function () {
            var newDlg = $('#RaoVatmdl-dlgNew');
            raovatfn.popfn();
            $('.adm-col-header-user', newDlg).hide();
            $('.adm-col-header-admin', newDlg).show();
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                height: 560,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        raovatfn.save(false, function () {
                            raovatfn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        raovatfn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    raovatfn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    raovatfn.clearform();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#RaoVatmdl-dlgNew');
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
    },
    clearform: function () {
        var newDlg = $('#RaoVatmdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var KV_ID = $('.KV_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var Alias = $('.Alias', newDlg);
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
    },
    loadHtml: function (fn) {
        var dlg = $('#RaoVatmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.raoVatMgr.htm.htm")%>',
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