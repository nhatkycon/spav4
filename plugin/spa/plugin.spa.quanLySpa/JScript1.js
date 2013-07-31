var quanLySpaFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.spa.quanLySpa.Class1, plugin.spa.quanLySpa',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#quanLySpaMdl-List').jqGrid({
            url: quanLySpaFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Ảnh', 'Quận', 'Tên', 'Địa chỉ', 'Phone', 'Ngày tạo', 'Mới', 'K/Trương', 'K/Mãi', 'Active', 'Sao'],
            colModel: [
            { name: 'SPA_ID', key: true, sortable: true, hidden: true },
            { name: 'SPA_Anh', width: 10, sortable: false, editable: true },
            { name: 'SPA_KV_ID', width: 10, resizable: true, sortable: false, editable: true },
            { name: 'SPA_Ten', width: 40, resizable: true, sortable: false, editable: true },
            { name: 'SPA_DiaChi', width: 20, resizable: true, sortable: false, editable: true },
            { name: 'SPA_Phone', width: 20, resizable: true, sortable: false },
            { name: 'SPA_NgayTao', width: 10, resizable: true, sortable: false },
            { name: 'SPA_Moi', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'SPA_KhaiTruong', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'SPA_KhuyenMai', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'SPA_Publish', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'SPA_Sao', width: 5, resizable: true, sortable: false }
            ],
            caption: 'Spa',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'SPA_ID',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#quanLySpaMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#quanLySpaMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
                quanLySpaFn.headFn();
            }
        });
        $.getScript('../js/ajaxupload.js', function () { });
    },
    headFn: function () {
        var searchTxt = $('.mdl-head-search-quanLySpaMdl');
        $(searchTxt).unbind('keyup').keyup(function () {
            quanLySpaFn.search();
        });

    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-search-quanLySpaMdl');
        var __q = $(searchTxt).val();
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#quanLySpaMdl-List').jqGrid('setGridParam', { url: quanLySpaFn.urlDefault
             + '&q=' + __q
             + '&subAct=get'
            }).trigger("reloadGrid");
        }, 1000);
    },
    edit: function () {
        var s = '';
        if (jQuery('#quanLySpaMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#quanLySpaMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                quanLySpaFn.loadHtml(function () {
                    var newDlg = $('#quanLySpaMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 800,
                        buttons: {
                            'Lưu': function () {
                                quanLySpaFn.save(false, function () { quanLySpaFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                quanLySpaFn.save(false, function () { quanLySpaFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            quanLySpaFn.clearform();
                            quanLySpaFn.popfn();
                            $.ajax({
                                url: quanLySpaFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                type: 'POST',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var Phone = $('.Phone', newDlg);
                                    var KV_ID = $('.KV_ID', newDlg);
                                    var Sao = $('.Sao', newDlg);
                                    var Alias = $('.Alias', newDlg);
                                    var Diem = $('.Diem', newDlg);
                                    var ToaDo = $('.ToaDo', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var DiaChi = $('.DiaChi', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var Publish = $('.Publish', newDlg);
                                    var Moi = $('.Moi', newDlg);
                                    var KhuyenMai = $('.KhuyenMai', newDlg);
                                    var KhaiTruong = $('.KhaiTruong', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    var spbMsg = $('.admMsg', newDlg);

                                    var LoaiThanhVien = $('.LoaiThanhVien', newDlg);
                                    var Website = $('.Website', newDlg);
                                    var Email = $('.Email', newDlg);
                                    var BaoDam = $('.BaoDam', newDlg);

                                    $(ID).val(dt.ID);
                                    $(DM_ID).val(dt.DM_Ten); $(DM_ID).attr('_value', dt.DM_ID);

                                    $(Ten).val(dt.Ten);
                                    $(Phone).val(dt.Phone);

                                    $(LoaiThanhVien).val(dt.LoaiThanhVien);
                                    $(Website).val(dt.Website);
                                    $(Email).val(dt.Email);
                                    if (dt.BaoDam) { $(BaoDam).attr('checked', 'checked'); } else { $(BaoDam).removeAttr('checked', 'checked'); }

                                    $(KV_ID).val(dt.KV_Ten);
                                    $(KV_ID).attr('_value', dt.KV_ID);
                                    $(Sao).val(dt.Sao);
                                    $(Alias).val(dt.Alias);
                                    $(Diem).val(dt.Diem);
                                    $(ToaDo).val(dt.ToaDo);
                                    $(MoTa).val(dt.MoTa);
                                    $(DiaChi).val(dt.DiaChi);
                                    $(NoiDung).val(dt.NoiDung);
                                    if (dt.Publish) { $(Publish).attr('checked', 'checked'); } else { $(Publish).removeAttr('checked', 'checked'); }
                                    if (dt.Moi) { $(Moi).attr('checked', 'checked'); } else { $(Moi).removeAttr('checked', 'checked'); }
                                    if (dt.KhuyenMai) { $(KhuyenMai).attr('checked', 'checked'); } else { $(KhuyenMai).removeAttr('checked', 'checked'); }
                                    if (dt.KhaiTruong) { $(KhaiTruong).attr('checked', 'checked'); } else { $(KhaiTruong).removeAttr('checked', 'checked'); }
                                    if (dt.Anh != '') {
                                        $(lblAnh).attr('ref', dt.Anh);
                                        $(lblAnhPrvImg).attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());
                                    }
                                    $(spbMsg).html('');
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
        if (jQuery('#quanLySpaMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#quanLySpaMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: quanLySpaFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery('#quanLySpaMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#quanLySpaMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Phone = $('.Phone', newDlg);
        var KV_ID = $('.KV_ID', newDlg);
        var Sao = $('.Sao', newDlg);
        var Alias = $('.Alias', newDlg);
        var Diem = $('.Diem', newDlg);
        var ToaDo = $('.ToaDo', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Publish = $('.Publish', newDlg);
        var Moi = $('.Moi', newDlg);
        var KhuyenMai = $('.KhuyenMai', newDlg);
        var KhaiTruong = $('.KhaiTruong', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var lblAnhPrv = $('.adm-upload-preview', newDlg);
        var lblAnhPrvImg = $(lblAnhPrv).find('img');

        var LoaiThanhVien = $('.LoaiThanhVien', newDlg);
        var Website = $('.Website', newDlg);
        var Email = $('.Email', newDlg);
        var BaoDam = $('.BaoDam', newDlg);

        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _Ten = $(Ten).val();
        var _Phone = $(Phone).val();
        var _KV_ID = $(KV_ID).attr('_value');
        var _Sao = $(Sao).val();
        var _Alias = $(Alias).val();
        var _Diem = $(Diem).val();
        var _DM_ID = DM_ID.attr('_value');
        
        var _LoaiThanhVien = $(LoaiThanhVien).val();
        var _Website = $(Website).val();
        var _Email = $(Email).val();
        var _BaoDam = $(BaoDam).is(':checked');

        var _ToaDo = $(ToaDo).val();
        var _MoTa = $(MoTa).val();
        var _DiaChi = $(DiaChi).val();
        var _NoiDung = $(NoiDung).val();
        var _Publish = $(Publish).is(':checked');
        var _Moi = $(Moi).is(':checked');
        var _KhuyenMai = $(KhuyenMai).is(':checked');
        var _KhaiTruong = $(KhaiTruong).is(':checked');
        var _anh = $(lblAnh).attr('ref');

        var err = '';
        if (_Ten == '') { err += 'Nhập Tên<br/>'; }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: quanLySpaFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'Ten': _Ten,
                'Phone': _Phone,
                'KV_ID': _KV_ID,
                'Sao': _Sao,
                'Alias': _Alias,
                'Diem': _Diem,
                'ToaDo': _ToaDo,
                'MoTa': _MoTa,
                'DiaChi': _DiaChi,
                'NoiDung': _NoiDung,
                'Publish': _Publish,
                'Moi': _Moi,
                'KhuyenMai': _KhuyenMai,
                'KhaiTruong': _KhaiTruong,
                'Anh': _anh,
                LoaiThanhVien: _LoaiThanhVien,
                Website: _Website,
                Email: _Email,
                BaoDam: _BaoDam,
                DM_ID : _DM_ID
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#quanLySpaMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        quanLySpaFn.loadHtml(function () {
            var newDlg = $('#quanLySpaMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 800,
                buttons: {
                    'Lưu': function () {
                        quanLySpaFn.save(false, function () {
                            quanLySpaFn.clearform();
                        }, '#quanLySpaMdl-List');
                    },
                    'Lưu và đóng': function () {
                        quanLySpaFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#quanLySpaMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    quanLySpaFn.clearform();
                    quanLySpaFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#quanLySpaMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var KV_ID = $('.KV_ID', newDlg);
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteByLoai('QUAN', KV_ID, function (event, ui) {
                $(KV_ID).attr('_value', ui.item.id);
            });
            danhmuc.autoCompleteByLoai('LOAI-SPA', DM_ID, function (event, ui) {
                $(DM_ID).attr('_value', ui.item.id);
            });
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

    },
    autoComplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'spa-danh-sach' + request.term;
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID
                            };
                        }
                    }));
                }
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: quanLySpaFn.urlDefault,
                    dataType: 'script',
                    data: { 'subAct': 'autoComplete', 'q': request.term },
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
                                        id: item.ID
                                    };
                                }
                            }));
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
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    clearform: function () {
        var newDlg = $('#quanLySpaMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Phone = $('.Phone', newDlg);
        var KV_ID = $('.KV_ID', newDlg);
        var Sao = $('.Sao', newDlg);
        var Alias = $('.Alias', newDlg);
        var Diem = $('.Diem', newDlg);
        var ToaDo = $('.ToaDo', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var LoaiThanhVien = $('.LoaiThanhVien', newDlg);
        var Website = $('.Website', newDlg);
        var Email = $('.Email', newDlg);
        var BaoDam = $('.BaoDam', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Publish = $('.Publish', newDlg);
        var Moi = $('.Moi', newDlg);
        var KhuyenMai = $('.KhuyenMai', newDlg);
        var KhaiTruong = $('.KhaiTruong', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var lblAnhPrv = $('.adm-upload-preview', newDlg);
        var lblAnhPrvImg = $(lblAnhPrv).find('img');
        var spbMsg = $('.admMsg', newDlg);

        $(ID).val('');
        $(Ten).val('');
        $(Phone).html('');
        $(Sao).html('1');
        $(ToaDo).html('');
        $(MoTa).html('');
        $(DiaChi).html('');
        $(NoiDung).val('');
        $(Alias).val('');
        $(Diem).val('0');
        Website.val('');
        Email.val('');
        LoaiThanhVien.val('');

        newDlg.find('input').val('');
        newDlg.find('input').attr('_value', '');

        $(lblAnh).attr('ref', '');
        $(lblAnh).prev().find('img').attr('src', '');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#quanLySpaMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.spa.quanLySpa.htm.htm")%>',
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
