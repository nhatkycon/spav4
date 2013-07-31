var datDichVuFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.spa.datDichVuMgr.Class1, plugin.spa.datDichVuMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#datDichVuMdl-List').jqGrid({
            url: datDichVuFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Ảnh', 'Quận', 'Tên', 'Địa chỉ', 'Phone', 'Ngày tạo', 'Mới', 'K/Trương', 'K/Mãi', 'Active','Sao'],
            colModel: [
            { name: 'DDV_ID', key: true, sortable: true, hidden: true },
            { name: 'DDV_Anh', width: 10, sortable: false, editable: true },
            { name: 'DDV_KV_ID', width: 10, resizable: true, sortable: false, editable: true },
            { name: 'DDV_Ten', width: 40, resizable: true, sortable: false, editable: true },
            { name: 'DDV_DiaChi', width: 20, resizable: true, sortable: false, editable: true },
            { name: 'DDV_Phone', width: 20, resizable: true, sortable: false},
            { name: 'DDV_NgayTao', width: 10, resizable: true, sortable: false},
            { name: 'DDV_Moi', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'DDV_KhaiTruong', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'DDV_KhuyenMai', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'DDV_Publish', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'DDV_Sao', width: 5, resizable: true, sortable: false }
            ],
            caption: 'Spa',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'DDV_ID',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#datDichVuMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#datDichVuMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
                datDichVuFn.headFn();
            }
        });
        $.getScript('../js/ajaxupload.js', function () { });
    },
    headFn: function () {
        var searchTxt = $('.mdl-head-search-datDichVuMdl');
        $(searchTxt).unbind('keyup').keyup(function () {
            datDichVuFn.search();
        });
        
    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-search-datDichVuMdl');
        var __q = $(searchTxt).val();
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#datDichVuMdl-List').jqGrid('setGridParam', { url: datDichVuFn.urlDefault
             + '&q=' + __q
             + '&subAct=get'
            }).trigger("reloadGrid");
        }, 1000);
    },
    edit: function () {
        var s = '';
        if (jQuery('#datDichVuMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#datDichVuMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                datDichVuFn.loadHtml(function () {
                    var newDlg = $('#datDichVuMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 800,
                        buttons: {
                            'Lưu': function () {
                                datDichVuFn.save(false, function () { datDichVuFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                datDichVuFn.save(false, function () { datDichVuFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            datDichVuFn.clearform();
                            datDichVuFn.popfn();
                            $.ajax({
                                url: datDichVuFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                type:'POST',
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

                                    $(ID).val(dt.ID);
                                    $(DM_ID).val(dt.DM_Ten); $(DM_ID).attr('_value', dt.DM_ID);
                                    $(Ten).val(dt.Ten);
                                    $(Phone).val(dt.Phone);
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
        if (jQuery('#datDichVuMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#datDichVuMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: datDichVuFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery('#datDichVuMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#datDichVuMdl-dlgNew');
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

        var _ID = $(ID).val();
        var _Ten = $(Ten).val();
        var _Phone = $(Phone).val();
        var _KV_ID = $(KV_ID).attr('_value');
        var _Sao = $(Sao).val();
        var _Alias = $(Alias).val();
        var _Diem = $(Diem).val();
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
            url: datDichVuFn.urlDefault + '&subAct=save',
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
                'Anh': _anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#datDichVuMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        datDichVuFn.loadHtml(function () {
            var newDlg = $('#datDichVuMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 800,
                buttons: {
                    'Lưu': function () {
                        datDichVuFn.save(false, function () {
                            datDichVuFn.clearform();
                        }, '#datDichVuMdl-List');
                    },
                    'Lưu và đóng': function () {
                        datDichVuFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#datDichVuMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    datDichVuFn.clearform();
                    datDichVuFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#datDichVuMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var P_ID = $('.P_ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var NgayHen_Ngay = $('.NgayHen_Ngay', newDlg);
        var NgayHen_Gio = $('.NgayHen_Gio', newDlg);
        var NgayThanhToan = $('.NgayThanhToan', newDlg);
        var Active = $('.Active', newDlg);
        var Confirmed = $('.Confirmed', newDlg);
        var ThanhToan = $('.ThanhToan', newDlg);
        var SpaReaded = $('.SpaReaded', newDlg);
        var SpaConfirmed = $('.SpaConfirmed', newDlg);
        var Publish = $('.Publish', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteByLoai('QUAN', KV_ID, function (event, ui) {
                $(KV_ID).attr('_value', ui.item.id);
            });
            danhmuc.autoCompleteByLoai('LOAI-SPA', DM_ID, function (event, ui) {
                $(DM_ID).attr('_value', ui.item.id);
            });
        });
        

    },
    addDangKy: function (_DV_ID, _Loai, fn) {
        datDichVuFn.loadHtml(function () {
            var newDlg = $('#bookDichVuMdl-dlgNew');
            common.fbJquery('Đăng ký dịch vụ', newDlg, 800, 'dk-dv-user', function (bd) {
                var NgayHen_Ngay = $('.NgayHen_Ngay', bd);
                var NgayHen_Gio = $('.NgayHen_Gio', bd);
                var MEM_Ten = $('.KH_Ten', bd);
                var MEM_DiaChi = $('.KH_DiaChi', bd);
                var MEM_Mobile = $('.KH_Mobile', bd);
                var GhiChu = $('.GhiChu', bd);
                adm.styleButton();
                var date = new Date();
                var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
                datDichVuFn.getGio(NgayHen_Gio, function (e, ui) {
                });
                NgayHen_Ngay.val(dateStr);
                NgayHen_Ngay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
                var footer = bd.find('.facebox-footer');
                footer.hide();
                bd.find('.dangKyBtn').click(function () {
                    var _NgayHen_Ngay = NgayHen_Ngay.val();
                    var _NgayHen_Gio = NgayHen_Gio.val();
                    var _MEM_Ten = MEM_Ten.val();
                    var _MEM_DiaChi = MEM_DiaChi.val();
                    var _MEM_Mobile = MEM_Mobile.val();
                    var _GhiChu = GhiChu.val();
                    var err = '';
                    if (_MEM_Ten == '') {
                        err += 'Nhập tên <br/>';
                    }
                    if (_MEM_DiaChi == '') {
                        err += 'Nhập Email <br/>';
                    }
                    if (_MEM_Mobile == '') {
                        err += 'Nhập mobile <br/>';
                    }
                    if (_NgayHen_Ngay == '') {
                        err += 'Chọn ngày <br/>';
                    }
                    if (_NgayHen_Gio == '') {
                        err += 'Chọn giờ <br/>';
                    }
                    if (err != '') {
                        common.fbMsg('Lỗi này bạn ơi', '<h1>Bạn cần chỉnh ngay nhé:</h1>' + err, 400, 'msg-portal-pop', function () {
                            setTimeout(function () {
                                $(document).trigger('close.facebox', 'msg-portal-pop');
                            }, 5000);
                        });
                        return false;
                    }
                    common.fbMsg('Đang xử lý', 'Vui lòng đợi 1 chút bạn nhé...' + err, 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 20000);
                    });
                    $.ajax({
                        url: datDichVuFn.urlDefault,
                        data: {
                            subAct: 'saveDangky'
                            , NgayHen_Ngay: _NgayHen_Ngay
                            , NgayHen_Gio: _NgayHen_Gio
                            , MEM_Ten: _MEM_Ten
                            , MEM_DiaChi: _MEM_DiaChi
                            , MEM_Mobile: _MEM_Mobile
                            , GhiChu: _GhiChu
                            , DV_ID: _DV_ID
                            , Loai: _Loai
                        },
                        success: function (_dt) {
                            $(document).trigger('close.facebox', 'msg-portal-pop-processing');
                            
                            if (_dt == '1') {
                                $(document).trigger('close.facebox', 'dk-user');
                                common.fbMsg('Xong rồi này', '<h1>Bạn đã đăng ký thành công</h1>Chúng tôi sẽ liên lạc lại với bạn ngay nhé', 400, 'msg-portal-pop', function () {
                                    setTimeout(function () {
                                        $(document).trigger('close.facebox', 'msg-portal-pop');
                                        if (typeof (fn) == "function") {
                                            fn();
                                        }
                                        else {
                                            document.location.reload();
                                        }
                                    }, 2000);
                                    $(document).trigger('close.facebox', 'dk-dv-user');
                                });
                            }
                            else {
                                common.fbMsg('Dính lỗi rồi :(( ặc ặc', '<h1>Có lỗi, chán quá vì mình sửa mãi mà nó vẫn bị</h1>' + _dt + '<br/>Copy lỗi trên rùi gửi cho mình nhé: linh_net', 200, 'msg-portal-pop', function () {
                                    setTimeout(function () {
                                        $(document).trigger('close.facebox', 'msg-portal-pop');
                                    }, 5000);
                                });
                            }
                        }
                    });
                });
            });
        });
    },
    popDichVuFn: function (newDlg) {
        var NgayHen_Ngay = $('.NgayHen_Ngay', newDlg);
        var NgayHen_Gio = $('.NgayHen_Gio', newDlg);
        var MEM_Ten = $('.MEM_Ten', newDlg);
        var MEM_DiaChi = $('.MEM_DiaChi', newDlg);
        var MEM_Mobile = $('.MEM_Mobile', newDlg);
        var GhiChu = $('.GhiChu', newDlg);

        

    },
    getGio: function (el, fn) {
        $.ajax({
            url: datDichVuFn.urlDefault,
            dataType: 'script',
            data: { 'subAct': 'getGio' },
            success: function (dt, status, xhr) {
                adm.loading(null);
                var data = eval(dt);
                $(el).autocomplete({
                    source: data,
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
				            .append('<a>' + item.label + '</a>')
				            .appendTo(ul);
                };
            }
        });

    },
    autoComplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'spa' + request.term;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: datDichVuFn.urlDefault,
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
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    clearform: function () {
        var newDlg = $('#datDichVuMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var P_ID = $('.P_ID', newDlg);
        var SPA_ID = $('.SPA_ID', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var NgayHen_Ngay = $('.NgayHen_Ngay', newDlg);
        var NgayHen_Gio = $('.NgayHen_Gio', newDlg);
        var NgayThanhToan = $('.NgayThanhToan', newDlg);
        var Active = $('.Active', newDlg);
        var Confirmed = $('.Confirmed', newDlg);
        var ThanhToan = $('.ThanhToan', newDlg);
        var SpaReaded = $('.SpaReaded', newDlg);
        var SpaConfirmed = $('.SpaConfirmed', newDlg);
        var Publish = $('.Publish', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        newDlg.find('input').val('');
        newDlg.find('input').attr('_value','');

        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#datDichVuMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.spa.datDichVuMgr.htm.htm")%>',
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
