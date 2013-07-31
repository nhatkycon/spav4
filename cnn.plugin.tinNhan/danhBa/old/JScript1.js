var danhbaObjold = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.tinNhan.danhBa.old.Class1, cnn.plugin.tinNhan',
    //chung	
    setup: function () {

        danhbaObjold.loadgrid();
        danhbaObjold.loadgridGroup();
        danhbaObjold.loadgridgroupdetail();

        var listgroup = $('#listgroup');
        adm.watermarks(listgroup, 'Cho vào nhóm', function () {
            adm.clearCombo([listgroup]);
        });

        danhbaObjold.autoCompleteByGroup(true, listgroup, function (event, ui) {
            //$(listgroup).val(ui.item.Ten + ': ' + ui.item.Ten);
            $(listgroup).val(ui.item.Ten);
            $(listgroup).attr('_value', ui.item.id);
            danhbaObjold.chuyentoi(ui.item.id);
            //alert(ui.item.id);
        });

    },
    chuyentoi: function (groupID) {
        var s = '';
        s = jQuery("#danhbaoldmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tin nhắn');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#danhbaoldmdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            adm.loading('Đang chuyển dữ liệu');
            $.ajax({
                url: danhbaObjold.urlDefault + '&subAct=chuyentoi',
                dataType: 'script',
                data: {
                    'DB_ID': ll,
                    'G_ID': groupID
                },
                success: function (dt) {
                    jQuery("#danhbaoldmdl-List").trigger('reloadGrid');
                    adm.loading(null);
                }
            });
        }
    },



    //chung//
    //Group//
    loadgridGroup: function () {
        adm.loading('Đang lấy dữ liệu group');
        adm.styleButton();
        $('#danhbaoldgroupdl-List').jqGrid({
            url: danhbaObjold.urlDefault + '&subAct=getgroup',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['STT', 'ID', 'Tên'],
            colModel: [
            { name: 'G_Thutu', width: 10, resizable: true, sortable: true, align: "center" },
            { name: 'G_ID', key: true, sortable: true, hidden: true },
            { name: 'G_Ten', width: 30, resizable: true, sortable: true, align: "center" }
        ],
            caption: 'Group',
            autowidth: true,
            sortname: 'G_ID',
            sortorder: 'desc',
            rowNum: 8,
            rowList: [15, 50, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#danhbaoldgroupdl-Pager'),
            onSelectRow: function (rowid) {
                danhbaObjold.groupdetailsearch(rowid);

            },
            loadComplete: function () {
                adm.loading(null);
            },
            grouping: false,
            groupingView: {
                groupField: ['G_ID'],
                groupColumnShow: [true],
                groupText: ['<b>{0}</b>  - <span style=\"color:red;\">Tổng số: {1}</span>'],
                groupCollapse: false,
                groupOrder: ['asc'],
                groupSummary: [true],
                groupColumnShow: [false],
                groupDataSorted: true
            }
        });

    },
    loadHtmlGroup: function (fn) {

        var dlg = $('#danhbaoldmdl-groupgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');

            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.danhBa.old.htm1.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('#danhbaoldmdl-ListConten').append(dt);
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

    groupadd: function () {
        danhbaObjold.loadHtmlGroup(function () {
            var newDlg = $('#danhbaoldmdl-groupgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        danhbaObjold.groupsave(false, function () {
                            danhbaObjold.groupclearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        danhbaObjold.groupsave(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    danhbaObjold.groupclearform();
                }
            });
        });
    },
    groupsave: function (validate, fn) {
        var newDlg = $('#danhbaoldmdl-groupgNew');

        var txtID = $('.ID', newDlg);
        var GID = $(txtID).val();

        var txtgroupName = $('.groupName', newDlg);
        var groupName = $(txtgroupName).val();
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: danhbaObjold.urlDefault + '&subAct=savegroup',
            dataType: 'script',
            type: 'POST',
            data: {
                'GID': GID,
                'groupName': groupName
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#danhbaoldgroupdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    groupclearform: function () {
        var newDlg = $('#danhbaoldmdl-groupgNew');

        var txtgroupName = $('.groupName', newDlg);
        $(txtgroupName).val('');

        var txtID = $('.ID', newDlg);
        $(txtID).val('');
        //alert('da clear xong');
    },
    groupedit: function () {
        var s = '';
        if (jQuery('#danhbaoldgroupdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#danhbaoldgroupdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẫu một bản ghi để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẫu bản ghi');
            }
            else {
                danhbaObjold.loadHtmlGroup(function () {
                    var newDlg = $('#danhbaoldmdl-groupgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                danhbaObjold.groupsave(false, function () {
                                    alert('da save');
                                    danhbaObjold.groupclearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                danhbaObjold.groupsave(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            danhbaObjold.groupclearform();
                            $.ajax({
                                url: danhbaObjold.urlDefault + '&subAct=editgroup',
                                dataType: 'script',
                                data: {
                                    'GID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#danhbaoldmdl-groupgNew');

                                    var txtID = $('.ID', newDlg);
                                    $(txtID).val(data.ID);
                                    //alert(data.ID);
                                    var txtgroupName = $('.groupName', newDlg);
                                    $(txtgroupName).val(data.Ten);

                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    $(spbMsg).html('');
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    groupdel: function (fn) {
        var s = '';
        s = jQuery("#danhbaoldgroupdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa ban ghi này không?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    var treedata = $("#danhbaoldgroupdl-List").jqGrid('getRowData', ss[j]);
                    ll += ss[j] + ',';
                }
                $.ajax({
                    url: danhbaObjold.urlDefault + '&subAct=groupdel',
                    dataType: 'script',
                    data: {
                        'GID': ll
                    },
                    success: function (dt) {
                        jQuery("#danhbaoldgroupdl-List").trigger('reloadGrid');
                    }
                });
            }
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    autoCompleteByGroup: function (s, el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'autoCompleteByGroup-' + s;
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                id: item.ID,
                                Ten: item.Ten
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhbaObjold.urlDefault + '&subAct=listgroup',
                    dataType: 'script',
                    data: {
                        'q': ''
                    },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        id: item.ID,
                                        Ten: item.Ten
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
				            .append("<a>" + item.Ten + "</a>")
				            .appendTo(ul);
        };
    },

    //Group//
    //Danhba//
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu danh bạ');
        adm.styleButton();
        $('#danhbaoldmdl-List').jqGrid({
            url: danhbaObjold.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['STT', 'ID', 'User'],
            colModel: [
            { name: 'DB_Thutu', width: 10, resizable: true, sortable: true, align: "center" },
            { name: 'DB_ID', key: true, sortable: true, hidden: true },
            { name: 'DB_Username', width: 30, resizable: true, sortable: true, align: "center" }


        ],
            caption: 'Danh bạ',
            autowidth: true,
            sortname: 'DB_ID',
            sortorder: 'desc',
            rowNum: 50,
            rowList: [50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#danhbaoldmdl-Pager'),
            onSelectRow: function (rowid) {


            },
            loadComplete: function () {
                adm.loading(null);
            },
            grouping: false,
            groupingView: {
                groupField: ['DB_ID'],
                groupColumnShow: [true],
                groupText: ['<b>{0}</b>  - <span style=\"color:red;\">Tổng số: {1}</span>'],
                groupCollapse: false,
                groupOrder: ['asc'],
                groupSummary: [true],
                groupColumnShow: [false],
                groupDataSorted: true
            }
        });

    },

    initlistUser: function (fn) {

        var newDlg = $('#danhbaoldmdl-dlgNew');
        //cai dat nguoi nhan
        var listUser = $('.listUser', newDlg);
        $(listUser).focus();
        var listUserToDiv = $(listUser).parent();
        $(listUserToDiv).find('span').remove();
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(listUser, function (e, ui) {

                var CurrentItem = $(listUserToDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    $(listUser).val('');
                }, 100);
                if ($(CurrentItem).length < 1) {
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(listUser);
                    CurrentItem = $(listUserToDiv).find('span[_value=' + ui.item.value + ']');
                    var removeBtn = $(CurrentItem).find('a');
                    $(removeBtn).click(function () {
                        $(CurrentItem).remove();
                    });
                }
                else {
                    $(CurrentItem).animate({ backgroundColor: 'orange' }, 500, function () {
                        $(CurrentItem).animate({ backgroundColor: 'white' }, 500);
                    });
                }
            });
        });

    },
    loadHtmlDanhba: function (fn) {

        var dlg = $('#danhbaoldmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');

            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.danhBa.old.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('#danhbaoldmdl-ListConten').append(dt);
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
    danhbaadd: function () {
        danhbaObjold.loadHtmlDanhba(function () {
            var newDlg = $('#danhbaoldmdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        danhbaObjold.danhbasave(false, function () {
                            danhbaObjold.groupclearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        danhbaObjold.danhbasave(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    danhbaObjold.initlistUser();
                    danhbaObjold.danhbaclearform();
                }
            });
        });
    },
    danhbaclearform: function () {
        var newDlg = $('#danhbaoldmdl-dlgNew');

        var listUser = $('.listUser', newDlg);
        listUser = $(listUser).parent();
        $(listUser).find('span').remove();
    },

    danhbasave: function (validate, fn) {
        var newDlg = $('#danhbaoldmdl-dlgNew');

        var txtID = $('.ID', newDlg);
        var GID = $(txtID).val();

        var listUser = $('.listUser', newDlg);
        var listUserToDiv = $(listUser).parent();
        var l = '';
        $.each($(listUserToDiv).find('span'), function (i, item) {
            l += $(item).attr('_value') + ',';
        });
        listUser = l;
        //alert(l);
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: danhbaObjold.urlDefault + '&subAct=savedanhba',
            dataType: 'script',
            type: 'POST',
            data: {
                'listUser': listUser
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#danhbaoldmdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    danhbadel: function (fn) {
        var s = '';
        s = jQuery("#danhbaoldmdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu danh bạ để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa địa chỉ liên lạc này không?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    var treedata = $("#danhbaoldmdl-List").jqGrid('getRowData', ss[j]);
                    ll += ss[j] + ',';
                }
                $.ajax({
                    url: danhbaObjold.urlDefault + '&subAct=deldanhba',
                    dataType: 'script',
                    data: {
                        'DB_ID': ll
                    },
                    success: function (dt) {
                        jQuery("#danhbaoldmdl-List").trigger('reloadGrid');
                    }
                });
            }
        }

    },
    //Danhba//
    //chi tiet//
    loadgridgroupdetail: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#danhbaoldgroupdetaildl-List').jqGrid({
            url: danhbaObjold.urlDefault + '&subAct=getgroupdetail',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['STT', 'ID', 'User'],
            colModel: [
            { name: 'GD_Thutu', width: 10, resizable: true, sortable: true, align: "center" },
            { name: 'GD_ID', key: true, sortable: true, hidden: true },
            { name: 'GD_Username', width: 30, resizable: true, sortable: true, align: "center" }


        ],
            caption: 'Chi tiết',
            autowidth: true,
            sortname: 'GD_ID',
            sortorder: 'desc',
            rowNum: 8,
            rowList: [15, 50, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#danhbaoldgroupdetaildl-Pager'),
            onSelectRow: function (rowid) {


            },
            loadComplete: function () {
                adm.loading(null);
            },
            grouping: false,
            groupingView: {
                groupField: ['GD_ID'],
                groupColumnShow: [true],
                groupText: ['<b>{0}</b>  - <span style=\"color:red;\">Tổng số: {1}</span>'],
                groupCollapse: false,
                groupOrder: ['asc'],
                groupSummary: [true],
                groupColumnShow: [false],
                groupDataSorted: true
            }
        });

    },

    groupdetailsearch: function (GID) {

        timerSearch = setTimeout(function () {
            $('#danhbaoldgroupdetaildl-List').jqGrid('setGridParam', { url: danhbaObjold.urlDefault + '&subAct=getgroupdetail&GID=' + GID }).trigger('reloadGrid');
        }, 500);
    },
    groupdetaildel: function (fn) {
        var s = '';
        s = jQuery("#danhbaoldgroupdetaildl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu danh bạ để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa địa chỉ liên lạc này không?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    var treedata = $("#danhbaoldgroupdetaildl-List").jqGrid('getRowData', ss[j]);
                    ll += ss[j] + ',';
                }
                $.ajax({
                    url: danhbaObjold.urlDefault + '&subAct=delgroupdetail',
                    dataType: 'script',
                    data: {
                        'GD_ID': ll
                    },
                    success: function (dt) {
                        jQuery("#danhbaoldgroupdetaildl-List").trigger('reloadGrid');
                    }
                });
            }
        }

    },

    //chi tiet//

    //chon danh ba//
    loadHtmldanhba: function (fn) {
        var dlg = $('#danhbaoldmdl-dlgChondanhba');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');

            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.danhBa.old.htm3.htm")%>',
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
    chondanhba: function (fn) {
        danhbaObjold.loadHtmldanhba(function () {
            var newDlg = $('#danhbaoldmdl-dlgChondanhba');
            $(newDlg).dialog({
                title: 'Danh bạ',
                width: 450,
                modal: true,
                buttons: {
                    'Chọn': function () {

                        var s = '';
                        s = jQuery("#danhbaoldmdl-List", newDlg).jqGrid('getGridParam', 'selarrrow').toString();
                        if (s == '') {
                            alert('Chọn mẫu danh bạ ');
                        }
                        else {

                            var ss = s.split(',');
                            var data = '';
                            for (j = 0; j < ss.length; j++) {
                                treedata = $("#danhbaoldmdl-List", newDlg).jqGrid('getRowData', ss[j]);
                                if (typeof (treedata.DB_Username) != 'undefined') {
                                    var CurrentItem = '';
                                    CurrentItem = '<span class=\"adm-token-item-radi\" _value=\"' + treedata.DB_Username + '\">' + treedata.DB_Username + '<a href=\"javascript:;\">x</a></span>';
                                    data += CurrentItem;
                                }
                            }
                            //alert(ll);
                            if (typeof (fn) == 'function') {
                                fn(data);
                            }
                            danhbaObjold.danhbasearch('');
                            $(newDlg).dialog('close');

                        }

                    },
                    'Đóng': function () {
                        danhbaObjold.danhbasearch('');
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    danhbaObjold.loadchondanhba();


                    //cau hinh droplist
                    var listgroup = $('#listgroup', newDlg);
                    adm.watermarks(listgroup, 'Lọc theo nhóm', function () {
                        adm.clearCombo([listgroup]);
                    });
                    danhbaObjold.autoCompleteByGroup(true, listgroup, function (event, ui) {
                        $(listgroup).val(ui.item.Ten);
                        $(listgroup).attr('_value', ui.item.id);
                        danhbaObjold.danhbasearch();
                    });

                    //cau hinh tim kiem
                    var searchTxt = $('.mdl-head-search-danhba', newDlg);
                    $(searchTxt).keyup(function () {
                        danhbaObjold.danhbasearch();
                    });
                    adm.watermark(searchTxt, 'Tìm kiếm', function () {
                        //if ($(listgroup).attr('_value'))
                        $(searchTxt).val('');
                        danhbaObjold.danhbasearch();
                        $(searchTxt).val('Tìm kiếm');
                    });


                }
            });
        });
    },
    loadchondanhba: function () {
        //adm.loading('Đang lấy dữ liệu danh bạ');
        adm.styleButton();
        var newDlg = $('#danhbaoldmdl-dlgChondanhba');
        $('#danhbaoldmdl-List', newDlg).jqGrid({
            url: danhbaObjold.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['STT', 'ID', 'User'],
            colModel: [
            { name: 'DB_Thutu', width: 10, resizable: true, sortable: true, align: "center" },
            { name: 'DB_ID', key: true, sortable: true, hidden: true },
            { name: 'DB_Username', width: 30, resizable: true, sortable: true, align: "center" }


        ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'DB_ID',
            sortorder: 'desc',
            rowNum: 50,
            rowList: [50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#danhbaoldmdl-Pager', newDlg),
            onSelectRow: function (rowid) {


            },
            loadComplete: function () {
                adm.loading(null);
            },
            grouping: false,
            groupingView: {
                groupField: ['DB_ID'],
                groupColumnShow: [true],
                groupText: ['<b>{0}</b>  - <span style=\"color:red;\">Tổng số: {1}</span>'],
                groupCollapse: false,
                groupOrder: ['asc'],
                groupSummary: [true],
                groupColumnShow: [false],
                groupDataSorted: true
            }
        });

    },
    danhbasearch: function () {
        var newDlg = $('#danhbaoldmdl-dlgChondanhba');

        var filterDB = $('.mdl-head-search-danhba', newDlg);
        var s = filterDB.val();
        if (s == 'Tìm kiếm') {
            s = '';
        }

        var listgroup = $('#listgroup', newDlg);
        var GID = listgroup.attr('_value');
        //alert(GID);
        timerSearch = setTimeout(function () {
            $('#danhbaoldmdl-List', newDlg).jqGrid('setGridParam', { url: danhbaObjold.urlDefault + '&subAct=get&GID=' + GID + '&s=' + s }).trigger('reloadGrid');
        }, 500);
        adm.loading(null);
    },
    //chon danh ba2//
    chondanhba2: function (fn) {
        danhbaObjold.loadHtmldanhba(function () {
            var newDlg = $('#danhbaoldmdl-dlgChondanhba');
            $(newDlg).dialog({
                title: 'Danh bạ',
                width: 450,
                modal: true,
                buttons: {
                    'Chọn': function () {

                        var Listdanhba = $("#danhbaoldmdl-Listdanhba", newDlg);
                        //var lables = $(Listdanhba).find('ul');
                        var lables = $(Listdanhba).find('li');
//                        ////console.log(lables);
                        var data = '';
                        $.each(lables, function (i, Currentli) {
                            var check = $('input', Currentli);

                            if ($(check).is(':checked')) {
                                var lbTen = $('.Ten', Currentli);
                                var lbUser = $('.User', Currentli);

                                var CurrentItem = '';
                                CurrentItem = '<span class=\"adm-token-item-radi\" _value=\"' + $(lbUser).html() + '\">' + $(lbTen).html() + '<a href=\"javascript:;\">x</a></span>';
                                data += CurrentItem;
                            }

                        });
//                        ////console.log(data);
                        if (typeof (fn) == 'function') {
                            fn(data);
                        }
                        //danhbaObjold.danhbasearch('');
                        $(newDlg).dialog('close');



                    },
                    'Đóng': function () {
                        //danhbaObjold.danhbasearch2('');
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    danhbaObjold.loadchondanhba2();
                    //cau hinh droplist
                    var listgroup = $('#listgroup', newDlg);
                    adm.watermarks(listgroup, 'Lọc theo nhóm', function () {
                        adm.clearCombo([listgroup]);
                    });
                    danhbaObjold.autoCompleteByGroup(true, listgroup, function (event, ui) {
                        $(listgroup).val(ui.item.Ten);
                        $(listgroup).attr('_value', ui.item.id);
                        danhbaObjold.danhbasearch2();
                    });

                    //cau hinh tim kiem
                    var searchTxt = $('.mdl-head-search-danhba', newDlg);
                    $(searchTxt).keyup(function () {
                        danhbaObjold.danhbasearch2();
                    });
                    adm.watermark(searchTxt, 'Tìm kiếm', function () {
                        //if ($(listgroup).attr('_value'))
                        $(searchTxt).val('');
                        danhbaObjold.danhbasearch2();
                        $(searchTxt).val('Tìm kiếm');
                    });
                    adm.styleButton();

                }
            });
        });
    },
    loadchondanhba2: function (fn) {
        var newDlg = $('#danhbaoldmdl-dlgChondanhba');
        var filterDB = $('.mdl-head-search-danhba', newDlg);
        var s = filterDB.val();
        if (s == 'Tìm kiếm') {
            s = '';
        }

        var listgroup = $('#listgroup', newDlg);
        var GID = listgroup.attr('_value');

        $.ajax({
            url: danhbaObjold.urlDefault + '&subAct=get2',
            dataType: 'script',
            data: {
                'GID': GID,
                's': s
            },
            success: function (dt) {
                adm.loading(null);
                var Listdanhba = $("#danhbaoldmdl-Listdanhba", newDlg);
                var items = $(".items", Listdanhba);
                //////console.log(dt);
                var listdata = eval(dt);
                

                var data = '<ul>';
                $.each(listdata, function (i, item) {
                    var CurrentItem = '';
                    CurrentItem += '<li class=\"checkbox \" >';
                    CurrentItem += '<input type=\"checkbox\"  name=\"' + i + '\" class=\"choose-me\"> ';
                    CurrentItem += '<span class=\"Ten\">' + item.Ten + '</span>';
                    CurrentItem += '<span class=\"User\">' + '(' + item.Username + ')' + '</span>';
                    CurrentItem += '</li >';
                    data += CurrentItem;
                });
                data += '</ul>';
                items = $(items).html(data);

                var lis = $(items).find('li');
                //////console.log(lis);
                $.each(lis, function (i, Currentli) {
                    var chekBtn = $(Currentli).find('input');
                    $(chekBtn).click(function () {

                        if ($(chekBtn).is(':checked')) {
                                $(Currentli).removeClass('checkbox');
                                $(Currentli).addClass('checkboxed');   
                        }
                            else {
                                $(Currentli).removeClass('checkboxed');
                                $(Currentli).addClass('checkbox');     
                        }

                    });

                });
            }
        });

    },
    danhbasearch2: function () {

        timerSearch = setTimeout(function () {
            danhbaObjold.loadchondanhba2();
        }, 500);
        adm.loading(null);
    }

}