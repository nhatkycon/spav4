var video = {
    urlDefault: adm.urlDefault1 + '&act=loadPlug&rqPlug=cnn.plugin.Video.Class1, cnn.plugin.Video',
    setup: function () {
    },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        //        $('.sub-mdl').tabs();
        $('#videomdl-List').jqGrid({
            url: video.urlDefault + "&subAct=get",
            datatype: "json",
            height: "auto",
            loadui: 'disable',
            colNames: ["ID", "Thứ tự", "Hình ảnh", "Tiêu đề", "Mô tả","Chủ đề", "Ngày tạo", "Người tạo", "Trạng thái"],
            colModel: [
                    { name: "ID", width: 20, key: true, hidden: true },
                    { name: "Thutu", width: 30, resizable: false, align: 'center' },
                    { name: "Anh", width: 110, resizable: false, align: 'center' },
                    { name: "Ten", width: 150, resizable: false, align: 'left' },
                    { name: "Mota", width: 200, resizable: false, align: 'left' },
                    { name: "ChuDe", width: 100, resizable: false, align: 'center' },
                    { name: "NgayTao", width: 60, resizable: false, align: 'center' },
                    { name: "NguoiTao", width: 60, resizable: false, align: 'center' },
                    { name: "Active", width: 20, align: 'center', resizable: false, formatter: 'checkbox' }
                    ],
            caption: "Danh sách",
            autowidth: true,
            multiselect: true,
            ExpandColClick: true,
            sortname: 'Thutu',
            sortorder: 'asc',
            rowNum: 50,
            rowList: [50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#videomdl-Pager'),
            onSelectRow: function (rowid) {
            },                    
            loadComplete: function () {
                adm.loading(null);
            }
        });

        var newDlg = $('#videomdl-dlgNew');
        if ($(newDlg).length < 1) {
            $('body').append('<div class=\"adm-dialogS\" id=\"videomdl-dlgNew\"></div>');
            newDlg = $('#videomdl-dlgNew');
            adm.loading('Load dữ liệu');
            $(newDlg).load('<%=WebResource("cnn.plugin.Video.add.htm")%>', function () {
                adm.loading(null);
            });
        }
        var tsk = $('#videomdl-headTask');
        var txtSearch = $('.SearchTxt', tsk);
        var btnSearch = $('.admSearch-btn', tsk);

        //        adm.watermarks(txtSearch, 'Tìm kiếm', function () {
        //        });
        //        $(btnSearch).unbind('click').click(function () {
        //            var _searchTxt = $(txtSearch).val();
        //            if (_searchTxt != '') {
        //                video.filterQuickFn('&q=' + _searchTxt, 'Kết quả tìm kiếm');
        //            }
        //        });
        //        $(txtSearch).focus(function () {
        //            $(txtSearch).unbind('keypress').bind('keypress', function (evt) {
        //                if (evt.keyCode == 13) {
        //                    var _searchTxt = $(txtSearch).val();
        //                    if (_searchTxt != '') {
        //                        video.filterQuickFn('&q=' + _searchTxt, 'Kết quả tìm kiếm');
        //                    }
        //                }
        //            });
        //        });
        var filterCQID = $('.mdl-head-filtervideoByCQID');
        adm.watermark(filterCQID, 'Gõ tên đơn vị để lọc', function () {
            $(searchTxt).val('');
            video.search();
            $(searchTxt).val('Tìm kiếm');
        });
        adm.watermark(txtSearch, 'Tìm kiếm', function () {
            $(txtSearch).val('');
            video.search();
            $(txtSearch).val('Tìm kiếm');
        });
        adm.regType(typeof (coquan), 'docsoft.plugin.hethong.coquan.Class1,docsoft.plugin.hethong.coquan', function () {
            coquan.setAutocomplete(filterCQID, function (event, ui) {
                $(filterCQID).val(ui.item.label);
                $(filterCQID).attr('_value', ui.item.id);
                if ($(searchTxt).val() == 'Tìm kiếm') {
                    $(searchTxt).val('');
                }
                video.search();
                $(searchTxt).val('Tìm kiếm');
            });
            $(filterCQID).unbind('click').click(function () {
                if ($(filterCQID).val() == 'Gõ tên đơn vị để lọc') $(filterCQID).val('');
                $(filterCQID).autocomplete('search', '');
            });
        });

    },
    filterQuickFn: function (v, c) {
        if (v == null) {
            $('#videomdl-List').jqGrid('setGridParam', { url: video.urlDefault + '&subAct=get' }).trigger('reloadGrid');
            $('#videomdl-List').jqGrid('setCaption', c);
        }
        else {
            $('#videomdl-List').jqGrid('setCaption', c);
            $('#videomdl-List').jqGrid('setGridParam', { url: video.urlDefault + '&subAct=get' + v }).trigger('reloadGrid');
        }
    },

    add: function () {
        var newDlg = $('#videomdl-dlgNew');
        $(newDlg).dialog({
            title: 'Thêm mới',
            modal: true,
            width: 500,
            height: 320,
            buttons: {
                'Lưu': function () {
                    video.save();
                },
                'Lưu và đóng': function () {
                    video.save();
                    $(newDlg).dialog('close');
                },
                'Đóng': function () {
                    $(newDlg).dialog('close');
                }
            },
            open: function () {
                video.clearform();
                adm.styleButton();
            
                var ulpFn = function () {
                    var uploadBtn = $('.adm-upload-btn', newDlg);
                    var fclip = $('#clip', newDlg);
                    var uploadView = $('.adm-upload-preview-img', newDlg);
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
            }
        });
    },
    edit: function () {
        var s = '';
        if (jQuery("#videomdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#videomdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                video.loadHtml(function () {
                    var newDlg = $('#videomdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        modal: true,
                        width: 500,
                        height: 320,
                        buttons: {
                            'Lưu': function () {
                                video.save();
                            },
                            'Lưu và đóng': function () {
                                video.save();
                                $(newDlg).dialog('close');
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            var ulpFn = function () {
                                var fclip = $('#clip', newDlg);
                                var uploadBtn = $('.adm-upload-btn', newDlg);
                                var uploadView = $('.adm-upload-preview-img', newDlg);
                                var _params = { 'oldFile': $(uploadBtn).attr('ref') };
                                adm.upload(uploadBtn, 'video', _params, function (rs) {
                                    arrRs = rs.split(";");
                                    $(fclip).attr('value', arrRs[1]);
                                    $(uploadBtn).attr('ref', arrRs[0])
                                    $(uploadView).attr('src', '../up/v/' + arrRs[0] + '?ref=' + Math.random());
                                    ulpFn();
                                }, function (f) {
                                });
                            }
                            ulpFn();
                            //                            var txtPID = $('.PID', newDlg);
                            //                            $(txtPID).unbind('click').click(function () {
                            //                                $(txtPID).autocomplete('search', '');
                            //                            });
                            //                            video.setAutocomplete($(txtPID), function (event, ui) {
                            //                                $(txtPID).val(ui.item.label);
                            //                                $(txtPID).attr('_value', ui.item.id);
                            //                            });                            
                            $.ajax({
                                url: video.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    video.clearform();
                                    var data = eval('(' + dt + ')');
                                    var newDlg = $('#videomdl-dlgNew');
                                    var txtID = $('.ID', newDlg);
                                    //    var txtPID = $('.PID', newDlg);
                                    var txtTen = $('.Ten', newDlg);
                                    var txtThutu = $('.Thutu', newDlg);
                                    var txtMota = $('.Mota', newDlg);
                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    var chkDuyet = $('.Duyet', newDlg);

                                    var hdClip = $('#clip', newDlg);
                                    var lblAnh = $('.Anh', newDlg);

                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    $(hdClip).attr('value', data.Url);
                                    $(lblAnh).attr('ref', data.UrlImage);
                                    if (data.Anh != '') {
                                        $(lblAnhPrvImg).attr('src', '../up/v/' + data.UrlImage + '?ref=' + Math.random());
                                    }

                                    $(txtID).val(data.ID);

                                    //$(txtPID).val(data.PID);
                                    // $(txtPID).val(data._Parent.Ten);
                                    // $(txtPID).attr('_value', data.PID);
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
    del: function () {
        var s = '';
        if (jQuery("#videomdl-List").jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery("#videomdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn xóa?")) {
                $.ajax({
                    url: video.urlDefault + '&subAct=del',
                    dataType: 'script',
                    data: {
                        'arrID': s
                    },
                    success: function (dt) {
                        jQuery("#videomdl-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    duyet: function () {
        var s = '';
        if (jQuery("#videomdl-List").jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery("#videomdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để duyệt');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn duyệt?")) {
                $.ajax({
                    url: video.urlDefault + '&subAct=duyet',
                    dataType: 'script',
                    data: {
                        'arrID': s
                    },
                    success: function (dt) {
                        jQuery("#videomdl-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    dung: function () {
        var s = '';
        if (jQuery("#videomdl-List").jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery("#videomdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để dừng');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn dừng?")) {
                $.ajax({
                    url: video.urlDefault + '&subAct=dung',
                    dataType: 'script',
                    data: {
                        'arrID': s
                    },
                    success: function (dt) {
                        jQuery("#videomdl-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    save: function () {
        var newDlg = $('#videomdl-dlgNew');
        var txtID = $('.ID', newDlg);
        //  var txtPID = $('.PID', newDlg);
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
        //  var pid = $(txtPID).attr('_value');
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
            url: video.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'Ten': ten,
                'Thutu': thutu,
                'Mota': mota,
                'clip': clip,
                'Duyet': duyet,
                'Anh': anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    spbMsg.html('');
                    video.clearform();
                    jQuery("#videomdl-List").trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })


    },
    setAutocomplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp list');
                $.ajax({
                    url: video.urlDefault + '&subAct=getpid',
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
                                value: item.Username,
                                level: item.Loai,
                                id: item.ID
                            }
                        }));
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
				            .append("<a style=\"margin-left:" + parseInt(item.level) * 10 + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    search: function () {
        var timerSearch;
        var filterCQID = $('.mdl-head-filtervideoByCQID');
        var searchTxt = $('.mdl-head-search-video');
        var q = $(searchTxt).val();
        var cq = $(filterCQID).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        alert('sdfds');
        timerSearch = setTimeout(function () {
            $('#videomdl-List').jqGrid('setGridParam', { url: video.urlDefault + "&subAct=get&q=" + q + "&CQ_ID=" + cq }).trigger("reloadGrid");
        }, 500);
    },
    clearform: function () {
        var newDlg = $('#videomdl-dlgNew');
        var txtID = $('.ID', newDlg);
        //  var txtPID = $('.PID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtThutu = $('.Thutu', newDlg);
        var txtMoTa = $('.Mota', newDlg);
        var chkDuyet = $('.Duyet', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var hdClip = $('#clip', newDlg);
        $(imgAnh).attr('src', '');
        $(lblAnh).attr('ref', '');
        $(hdClip).attr('value', '');
        //   $(txtPID).attr('_value', '0');
        //  $(txtPID).val('');
        $(txtID).val('');
        $(txtThutu).val('');
        $(txtTen).val('');
        $(txtMoTa).val('');

        $(chkDuyet).removeAttr('checked');
        $(spbMsg).html('');
        $(spInfo).html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#videomdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.Video.add.htm")%>',
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