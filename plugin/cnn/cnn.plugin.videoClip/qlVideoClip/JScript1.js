qlvideoClipfn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.videoClip.qlVideoClip.Class1, cnn.plugin.videoClip'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang tải danh sách Video Clip');
        $('#videoClipMdl-qlVideoClip-List').jqGrid({
            url: qlvideoClipfn.urlDefault().toString() + '&subAct=getVideo',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ["ID", "Thứ tự", "Hình ảnh", "Tên Video", "Mô tả", "Lượt xem", "Chủ đề", "Ngày tạo", "Người tạo", "Trạng thái"],
            colModel: [
                    { name: "VC_ID", width: 20, key: true, hidden: true },
                    { name: "VC_ThuTu", width: 30, resizable: false, align: 'center' },
                    { name: "VC_Anh", width: 120, resizable: false, align: 'center' },
                    { name: "VC_Ten", width: 130, resizable: false, align: 'left' },
                    { name: "VC_MoTa", width: 130, resizable: false, align: 'left' },
                    { name: "VC_LuotXem", width: 60, resizable: false, align: 'center' },
                    { name: "VC_ChuDe", width: 60, resizable: false, align: 'center' },
                    { name: "VC_NgayTao", width: 50, resizable: false, align: 'center' },
                    { name: "VC_NguoiTao", width: 60, resizable: false, align: 'center' },
                    { name: "VC_Active", width: 20, align: 'center', resizable: false, formatter: 'checkbox' }
                    ],
            caption: 'Video Clip',
            autowidth: true,
            autowidth: true,
            multiselect: true,
            ExpandColClick: true,
            sortname: 'VC_ThuTu',
            sortorder: 'asc',
            multiboxonly: true,
            onSelectRow: function (rowid) {
            },
            rowNum: 5,
            rowList: [5, 10, 15, 20, 25, 30],
            pager: jQuery('#videoClipmdl-qlVideoClip-Pager'),

            loadComplete: function () {
                adm.loading(null);
                var chude = $('.mdl-head-qlVC-filterChuDe', '#VideoClip-qlVC-head');
                var txtfilterGianHang = $('.mdl-head-filterGianHang', '#VideoClip-qlVC-head');
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteLangBased("", "CLIPS", chude, function (event, ui) {
                        $(chude).attr('_value', ui.item.id);
                        qlvideoClipfn.search();
                    });
                    $(chude).unbind('click').click(function () {
                        $(chude).autocomplete('search', '');
                    });


                });
            }
        });
        var filterLoaiDanhMucID = $('.mdl-head-qlVC-filterChuDe', '#VideoClip-qlVC-head');
        var filterGianHangID = $('.mdl-head-filterGianHang', '#VideoClip-qlVC-head');
        var searchTxt = $('.mdl-head-search-qlVC-VideoClipmdl', '#VideoClip-qlVC-head');

        $(filterLoaiDanhMucID).keyup(function () {
            if ($(filterLoaiDanhMucID).val() == '') {
                $(filterLoaiDanhMucID).attr('_value', '');
                if ($(searchTxt).val() == 'Tìm kiếm Video clip') {
                    $(searchTxt).val('');
                }
                qlvideoClipfn.search();
                if ($(searchTxt).val() == '') {
                    $(searchTxt).val('Tìm kiếm Video clip');
                }
            }
        });
        $(filterGianHangID).keyup(function () {
            if ($(filterGianHangID).val() == '') {
                $(filterGianHangID).attr('_value', '');
                if ($(searchTxt).val() == 'Tìm kiếm Video clip') {
                    $(searchTxt).val('');
                }
                qlvideoClipfn.search();
                if ($(searchTxt).val() == '') {
                    $(searchTxt).val('Tìm kiếm Video clip');
                }
            }
        });
        $(searchTxt).keyup(function () {
            qlvideoClipfn.search();
        });
        adm.watermark(searchTxt, 'Tìm kiếm Video clip', function () {
            $(searchTxt).val('');
            qlvideoClipfn.search();
            $(searchTxt).val('Tìm kiếm Video clip');
        });
        adm.watermark(filterLoaiDanhMucID, 'Chọn chủ đề', function () {
            if ($(searchTxt).val() == 'Tìm kiếm Video clip') {
                $(searchTxt).val('');
            }
            qlvideoClipfn.search();
            if ($(searchTxt).val() == '') {
                $(searchTxt).val('Tìm kiếm Video clip');
            }
        });
        adm.watermark(filterGianHangID, 'Chọn doanh nghiệp', function () {
            if ($(searchTxt).val() == 'Tìm kiếm Video clip') {
                $(searchTxt).val('');
            }
            qlvideoClipfn.search();
            if ($(searchTxt).val() == '') {
                $(searchTxt).val('Tìm kiếm Video clip');
            }
        });

        if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }
    },


    clearform: function () {
        var newDlg = $('#videoClipMdl-qlVideoClip-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtChuDe = $('.DM_ID', newDlg)
        //  var txtPID = $('.PID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtThutu = $('.Thutu', newDlg);
        var txtMoTa = $('.Mota', newDlg);
        var chkDuyet = $('.Active', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.adm-upload-preview-img-size', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var hdClip = $('#clip', newDlg);
        $(imgAnh).attr('src', '');
        $(lblAnh).attr('ref', '');
        $(hdClip).attr('value', '');

        $(txtChuDe).val('');
        $(txtID).val('');
        $(txtThutu).val('');
        $(txtTen).val('');
        $(txtMoTa).val('');

        $(chkDuyet).removeAttr('checked');
        $(spbMsg).html('');
        $(spInfo).html('');
    },
    search: function () {
        var timerSearch;
        var filterVideo = $('.mdl-head-search-qlVC-VideoClipmdl');
        var searchDM = $('.mdl-head-qlVC-filterChuDe');
        var searchGianHang = $('.mdl-head-filterGianHang');
        var q = filterVideo.val();
        if (q == 'Tìm kiếm Video clip') {
            q = '';
        }
        var dm = $(searchDM).attr('_value');
        var gianhang = $(searchGianHang).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#videoClipMdl-qlVideoClip-List').jqGrid('setGridParam', { url: qlvideoClipfn.urlDefault().toString() + '&subAct=getVideo&ChuDe_ID=' + dm + '&q=' + q }).trigger('reloadGrid');
        }, 500);
    },


    addVideo: function () {
        qlvideoClipfn.loadHtml(function () {
            var newDlg = $('#videoClipMdl-qlVideoClip-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                modal: true,
                width: 500,
                height: 370,
                buttons: {
                    'Lưu': function () {
                        qlvideoClipfn.saveVideo();
                    },
                    'Lưu và đóng': function () {
                        qlvideoClipfn.saveVideo();
                        $(newDlg).dialog('close');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    qlvideoClipfn.popfn();
                    qlvideoClipfn.clearform();
                }
            });
        });
    },
    editVideo: function () {
        var s = '';
        if (jQuery("#videoClipMdl-qlVideoClip-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#videoClipMdl-qlVideoClip-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn Video để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một Video');
            }
            else {
                qlvideoClipfn.loadHtml(function () {
                    var newDlg = $('#videoClipMdl-qlVideoClip-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        modal: true,
                        width: 500,
                        height: 370,
                        buttons: {
                            'Lưu': function () {
                                qlvideoClipfn.saveVideo();
                            },
                            'Lưu và đóng': function () {
                                qlvideoClipfn.saveVideo();
                                $(newDlg).dialog('close');
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            qlvideoClipfn.clearform();
                            adm.styleButton();
                            qlvideoClipfn.popfn();

                            $.ajax({
                                url: qlvideoClipfn.urlDefault().toString() + '&subAct=editVideo',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    qlvideoClipfn.clearform();
                                    var data = eval(dt);
                                    var newDlg = $('#videoClipMdl-qlVideoClip-dlgNew');
                                    var txtID = $('.ID', newDlg);
                                    var txtDM_ID = $('.DM_ID');
                                    var txtTen = $('.Ten', newDlg);
                                    var txtThutu = $('.Thutu', newDlg);
                                    var txtMota = $('.Mota', newDlg);
                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    var chkDuyet = $('.Duyet', newDlg);

                                    var hdClip = $('#clip', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview-size', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    $(hdClip).attr('value', data.Url);
                                    txtDM_ID.val(data.TenChuDe);
                                    txtDM_ID.attr('_value', data.ChuDe_ID);
                                    $(lblAnh).attr('ref', data.UrlImage);
                                    if (data.Anh != '') {
                                        $(lblAnhPrvImg).attr('src', '../up/v/' + data.UrlImage + '?ref=' + Math.random());
                                    }
                                    $(txtID).val(data.ID);
                                    $(txtTen).val(data.Ten);
                                    $(txtThutu).val(data.Thutu);
                                    $(txtMota).val(data.Mota);
                                    if (data.Active) {

                                        $(chkDuyet).attr('checked', 'checked');
                                    }
                                    else {
                                        $(chkDuyet).removeAttr('checked');
                                    }

                                    $(spInfo).html(data.Ngaytao);
                                }
                            });
                        },
                        close: function () {

                        }
                    });
                });
            }
        }
    },
    delVideo: function () {
        var s = '';
        if (jQuery("#videoClipMdl-qlVideoClip-List").jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery("#videoClipMdl-qlVideoClip-List").jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn Video để xóa');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn xóa?")) {
                $.ajax({
                    url: qlvideoClipfn.urlDefault().toString() + '&subAct=delVideo',
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery("#videoClipMdl-qlVideoClip-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    duyetVideo: function () {
        var s = '';
        if (jQuery("#videoClipMdl-qlVideoClip-List").jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery("#videoClipMdl-qlVideoClip-List").jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn Video để duyệt');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn duyệt?")) {
                $.ajax({
                    url: qlvideoClipfn.urlDefault().toString() + '&subAct=duyetVideo',
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery("#videoClipMdl-qlVideoClip-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    dungVideo: function () {
        var s = '';
        if (jQuery("#videoClipMdl-qlVideoClip-List").jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery("#videoClipMdl-qlVideoClip-List").jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn Video để dừng');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn dừng?")) {
                $.ajax({
                    url: qlvideoClipfn.urlDefault().toString() + '&subAct=dungVideo',
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery("#videoClipMdl-qlVideoClip-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    saveVideo: function () {
        var newDlg = $('#videoClipMdl-qlVideoClip-dlgNew');
        var txtID = $('.ID', newDlg);
        //  var txtPID = $('.PID', newDlg);
        var txtChuDe = $('.DM_ID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtThutu = $('.Thutu', newDlg);
        var txtMota = $('.Mota', newDlg);
        var chkDuyet = $('.Duyet', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var hdClip = $('#clip', newDlg);
        var clip = $(hdClip).attr('value');
        var anh = $(lblAnh).attr('ref');
        var id = $(txtID).val();
        var chude = $(txtChuDe).attr('_value');
        var duyet = $(chkDuyet).is(':checked');
        var ten = $(txtTen).val();
        var thutu = $(txtThutu).val();
        var mota = $(txtMota).val();

        var err = '';
        if (ten == '') {
            err += 'Nhập tên<br/>';
        }
        if (thutu == '0') {
            err += 'Chọn số thư tự<br/>';
        }
        if (!adm.isInt(thutu)) {
            err += 'Chọn số thư tự sai<br/>';
        }
        if (err != '') {
            spbMsg.html(err);
            return false;
        }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: qlvideoClipfn.urlDefault().toString() + '&subAct=saveVideo',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'Ten': ten,
                'Thutu': thutu,
                'ChuDe_ID': chude,
                'Mota': mota,
                'Url': clip,
                'Active': duyet,
                'UrlImage': anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    spbMsg.html('');
                    qlvideoClipfn.clearform();
                    jQuery("#videoClipMdl-qlVideoClip-List").trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })


    },


    popfn: function () {
        var newDlg = $('#videoClipMdl-qlVideoClip-dlgNew');
        var DM_ID = $('.DM_ID', newDlg);
        danhmuc.autoCompleteLangBased('', 'CLIPS', DM_ID, function (event, ui) {
            $(DM_ID).attr('_value', ui.item.id);
        });
        $(DM_ID).unbind('click').click(function () { $(DM_ID).autocomplete('search', ''); });
        var ulpFn = function () {
            var uploadBtn = $('.adm-upload-btn', newDlg);
            var fclip = $('#clip', newDlg);
            var uploadView = $('.adm-upload-preview-img-size', newDlg);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.uploadvideo(uploadBtn, 'video', _params, function (rs) {
                arrRs = rs.split(";");
                $(fclip).attr('value', arrRs[1]);
                $(uploadBtn).attr('ref', arrRs[0])
                $(uploadView).attr('src', '../up/v/' + arrRs[0] + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();

    },
    setAutocomplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp danh sách');
                $.ajax({
                    url: qlvideoClipfn.urlDefault().toString() + '&subAct=getPid',
                    dataType: 'script',
                    data: {
                        'q': request.term
                    },
                    success: function (dt) {
                        adm.loading(null);
                        var data = eval(dt);
                        response($.map(data, function (item) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                ma: item.Ma
                            }
                        }))
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            }
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    loadHtml: function (fn) {
        var dlg = $('#videoClipMdl-qlVideoClip-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng form');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.videoClip.qlVideoClip.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('body').append(dt);
                    if (typeof (fn) == 'function') { fn(); }
                }
            });
        }
        else { if (typeof (fn) == 'function') { fn(); } }
    }
}

