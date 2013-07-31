var danhbaObj = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.tinNhan.danhBa.Class1, cnn.plugin.tinNhan',
    //chung	
    setup: function () {

        danhbaObj.loadgrid2('', '');
        danhbaObj.loadgridGroup2();

        //cau hinh tim kiem
        var newDlg = $('#danhbamdl-ListConten');
        var searchTxt = $('.mdl-head-search-listdanhba', newDlg);
        $(searchTxt).keyup(function () {
            danhbaObj.danhbasearch();
        });
        adm.watermark(searchTxt, 'Tìm kiếm', function () {
            //if ($(listgroup).attr('_value'))
            $(searchTxt).val('');
            danhbaObj.danhbasearch();
            $(searchTxt).val('Tìm kiếm');
        });
        adm.styleButton();

    },

    //chung//
    //Group//
    loadgridGroup2: function () {
        $.ajax({
            url: danhbaObj.urlDefault + '&subAct=getgroup2',
            dataType: 'script',

            success: function (dt) {
                adm.loading(null);
                //var Listdanhba = $("#danhbagroup-List");
                var items = $("#danhbagroup-List");
                ////console.log(dt);
                var listdata = eval(dt);


                var data = '<ul style="margin-left: -16px;width: 100%;">';
                data += '<li class=\"checkbox checkboxed\" id="checkAll">Tất cả địa chỉ</li>';
                data += '<hr>';
                $.each(listdata, function (i, item) {
                    var CurrentItem = '';

                    CurrentItem += '<li class=\"checkbox\" >';
                    CurrentItem += '<span class=\"Ten\" _value=\"' + item.ID + '\">' + item.Ten + '</span>';
                    CurrentItem += '</li >';
                    data += CurrentItem;
                });
                data += '</ul>';
                items = $(items).html(data);

                var lis = $(items).find('li');
                //////console.log(lis);
                $.each(lis, function (i, Currentli) {
                    $(Currentli).click(function () {
                        var id = $(Currentli).find('span');
                        id = $(id).attr('_value');
                        //alert(id);
                        danhbaObj.loadgrid2(id, '');
                        danhbaObj.Check();
                        $(lis).removeClass('checkboxed');
                        $(Currentli).addClass('checkboxed');
                    });


                });
            }
        });

    },
    loadHtmlGroup: function (fn) {

        var dlg = $('#danhbamdl-groupgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');

            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.danhBa.htm1.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('#danhbamdl-ListConten').append(dt);
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
        danhbaObj.loadHtmlGroup(function () {
            var newDlg = $('#danhbamdl-groupgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        danhbaObj.groupsave(false, function () {
                            danhbaObj.groupclearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        danhbaObj.groupsave(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    danhbaObj.groupclearform();
                }
            });
        });
    },
    groupsave: function (validate, fn) {
        var newDlg = $('#danhbamdl-groupgNew');

        var txtID = $('.ID', newDlg);
        var GID = $(txtID).val();

        var txtgroupName = $('.groupName', newDlg);
        var groupName = $(txtgroupName).val();
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: danhbaObj.urlDefault + '&subAct=savegroup',
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
                    //jQuery('#danhbagroupdl-List').trigger('reloadGrid');
                    danhbaObj.loadgridGroup2();
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    groupclearform: function () {
        var newDlg = $('#danhbamdl-groupgNew');

        var txtgroupName = $('.groupName', newDlg);
        $(txtgroupName).val('');

        var txtID = $('.ID', newDlg);
        $(txtID).val('');
        //alert('da clear xong');
    },
    groupedit: function () {
        var s = '';
        var items = $("#danhbagroup-List");
        var lis = $(items).find('li');
        $.each(lis, function (i, Currentli) {
            if ($(Currentli).hasClass('checkboxed')) {
                var id = $(Currentli).find('span');
                s = $(id).attr('_value');
            }

        });
        if ((s == '') || (s == null)) {
            alert('Chọn mẫu một bản ghi để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẫu bản ghi');
            }
            else {
                danhbaObj.loadHtmlGroup(function () {
                    var newDlg = $('#danhbamdl-groupgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu và đóng': function () {
                                danhbaObj.groupsave(false, function () {
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
                            danhbaObj.groupclearform();
                            $.ajax({
                                url: danhbaObj.urlDefault + '&subAct=editgroup',
                                dataType: 'script',
                                data: {
                                    'GID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#danhbamdl-groupgNew');

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
        var items = $("#danhbagroup-List");
        var lis = $(items).find('li');
        $.each(lis, function (i, Currentli) {
            if ($(Currentli).hasClass('checkboxed')) {
                var id = $(Currentli).find('span');
                s = $(id).attr('_value');
            }

        });
        if ((s == '') || (s == null)) {
            alert('Chọn mẫu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa ban ghi này không?')) {
                var ll = s;
                //alert(ll);
                $.ajax({
                    url: danhbaObj.urlDefault + '&subAct=delgroup',
                    dataType: 'script',
                    data: {
                        'GID': ll
                    },
                    success: function (dt) {
                        //alert('xoa ok');
                        danhbaObj.loadgridGroup2();
                        danhbaObj.loadgrid2('', '');
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
                    url: danhbaObj.urlDefault + '&subAct=listgroup',
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

    loadgrid2: function (GID, s) {
        $.ajax({
            url: danhbaObj.urlDefault + '&subAct=get2',
            dataType: 'script',
            data: {
                'GID': GID,
                's': s
            },
            success: function (dt) {
                adm.loading(null);
                //alert('ok');
                var items = $("#danhba-List");
                //////console.log(dt);
                var listdata = eval(dt);

                var data = '<div class=\"checkall\" >';
                data += '        <div title=\"Chọn hết\" class=\"cbox col-hd\" style=\"float:left; padding-left: 24px;\">';
                data += '             <input type=\"checkbox\" title=\"Chọn hết\"  class=\"checkboxall\" >';
                data += '        </div>';
                data += '    <div  class=\"tripane-col-hd\">      Chọn hết      </div>   ';
                data += '</div>';
                //var data = '';
                ////console.log(data);
                data += '<ul style="margin-left: -25px;">';
                $.each(listdata, function (i, item) {
                    var CurrentItem = '';
                    CurrentItem += '<li class=\"checkbox \" >';
                    CurrentItem += '<span  style=\"float:left;\"> ';
                    CurrentItem += '<input type=\"checkbox\"  name=\"' + i + '\" class=\"choose-me\"> ';
                    CurrentItem += '</span>';
                    CurrentItem += '<span class=\"detail\" style=\"float:left;\"> ';

                    CurrentItem += '<span class=\"Ten\">' + item.Ten + '</span>';
                    CurrentItem += '<span class=\"User\" _value=\"' + item.ID + '\">' + '(' + item.Username + ')' + '</span>';
                    CurrentItem += '</span>';

                    CurrentItem += '</li >';
                    data += CurrentItem;
                });
                data += '</ul>';
                items = $(items).html(data);

                var lis = $(items).find('li');
                var lis1 = $(items).find('li');
                //////console.log(lis);
                //click lua chon
                $.each(lis, function (i, Currentli) {
                    var chekBtn = $(Currentli).find('input');

                    $(chekBtn).change(function () {
                        //alert('btn');
                        if ($(chekBtn).is(':checked')) {
                            $(Currentli).removeClass('checkbox');
                            $(Currentli).addClass('checkboxed');
                            danhbaObj.Check();
                        }
                        else {
                            $(Currentli).removeClass('checkboxed');
                            $(Currentli).addClass('checkbox');

                            danhbaObj.Check();
                        }

                    });

                    var detail = $('.detail', Currentli);
                    //click de xem chi tiet
                    $(detail).click(function () {
                        //clear check
                        //$(lis1).removeClass('checkboxed');
                        $.each(lis1, function (j, Currentli1) {
                            if ($(Currentli1).hasClass('checkboxed')) {
                                $(Currentli1).removeClass('checkboxed');
                                $(Currentli1).addClass('checkbox');

                                var chekBtn1 = $(Currentli1).find('input');
                                $(chekBtn1).attr('checked', '');
                            }
                        });
                        //clear count
                        var newDlg = $('#danhbamdl-ListConten');
                        var danhbadetail = $('.danhbadetail', newDlg);
                        $(danhbadetail).show();

                        $(Currentli).removeClass('checkbox');
                        $(Currentli).addClass('checkboxed');

                        var danhbagroup = $("#danhbagroup-List");
                        checkAll = $("#checkAll", danhbagroup);
                        if ($(checkAll).hasClass('checkboxed')) {
                            $("#danhbamdl-xoakhoigroupBtn").hide();
                            //alert('checkall');
                        }
                        else {
                            $("#danhbamdl-xoakhoigroupBtn").show();
                            //alert('checkgroup');
                        }
                        adm.styleButton();
                        var User = $('.User', Currentli).html();


                        $.ajax({
                            url: danhbaObj.urlDefault + '&subAct=getdetail',
                            data: {
                                'listUser': User
                            },
                            success: function (dt) {
                                adm.loading(null);
                                //console.log(User);
                                //console.log(dt);
                                $('.listdanhbadetail', danhbadetail).html(dt);
                            }
                        });

                    });
                });

                var checkall = $(".checkboxall", items);
                $(checkall).click(function () {
                    $.each(lis, function (i, Currentli) {
                        var chekBtn = $(Currentli).find('input');
                        if ($(checkall).is(':checked')) {
                            $(chekBtn).attr('checked', 'checked');
                            $(Currentli).removeClass('checkbox');
                            $(Currentli).addClass('checkboxed');
                            danhbaObj.Check();
                        }
                        else {
                            $(chekBtn).attr('checked', '');
                            $(Currentli).removeClass('checkboxed');
                            $(Currentli).addClass('checkbox');
                            danhbaObj.Check();
                        }

                    });

                });
            }
        });

    },
    Check: function () {

        var items = $("#danhba-List");

        var lis = $(items).find('li');
        var counts = 0;
        $.each(lis, function (i, Currentli) {
            var chekBtn = $(Currentli).find('input');
            if ($(chekBtn).is(':checked'))
                counts += 1;
        });
        var newDlg = $('#danhbamdl-ListConten');
        var danhbadetail = $('.danhbadetail', newDlg);

        if (counts > 0) {
            //hien thi chi tiet nhom
            $(danhbadetail).show();

            //lay ve group
            var GID = '';
            var items = $("#danhbagroup-List");
            var lis = $(items).find('li');
            $.each(lis, function (i, Currentli) {
                if ($(Currentli).hasClass('checkboxed')) {
                    var id = $(Currentli).find('span');
                    GID = $(id).attr('_value');
                }

            });
            GID = parseInt(GID);
            //kiem tra xem la xoa khoi danh ba hay xoa khoi danhbagroup
            //alert(GID);
            if (GID > 0) {
                $('#danhbamdl-xoakhoigroupBtn', danhbadetail).show();
                //$('#danhbamdl-xoakhoigroupBtn', danhbadetail).attr('disabled', false);
            }
            else {
                $('#danhbamdl-xoakhoigroupBtn', danhbadetail).hide();
                //$('#danhbamdl-xoakhoigroupBtn', danhbadetail).attr('disabled', true);
                //$('input[type=submit]', this).attr('disabled', 'disabled');
            }
            var l = 'Bạn đã chọn:' + counts;
            //alert(l);
            $('.listdanhbadetail', danhbadetail).html(l);
        }
        else {
            $(danhbadetail).hide();
        }

    },

    loadHtmlDanhba: function (fn) {

        var dlg = $('#danhbamdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');

            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.danhBa.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('#danhbamdl-ListConten').append(dt);
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
        danhbaObj.loadHtmlDanhba(function () {
            var newDlg = $('#danhbamdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 350,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        danhbaObj.danhbasave(false, function () {
                            danhbaObj.danhbaclearform();

                        });
                    },
                    'Lưu và đóng': function () {
                        danhbaObj.danhbasave(false, function () {
                            $(newDlg).dialog('close');
                            danhbaObj.danhbaclearform();
                            danhbaObj.loadgrid2('', '');
                        });

                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        danhbaObj.danhbaclearform();
                        danhbaObj.loadgrid2('', '');
                    }
                },
                open: function () {
                    adm.styleButton();
                    danhbaObj.danhbaclearform();
                }
            });
        });
    },
    danhbaclearform: function () {
        var newDlg = $('#danhbamdl-dlgNew');

        var listUser = $('.listUser', newDlg);
        listUser = $(listUser).parent();
        $(listUser).find('span').remove();
    },

    danhbasave: function (validate, fn) {
        var newDlg = $('#danhbamdl-dlgNew');

        var txtID = $('.ID', newDlg);
        var GID = $(txtID).val();

        var listUser = $('.listUser', newDlg);

        listUser = $(listUser).val() + ',';
        //alert(listUser);
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: danhbaObj.urlDefault + '&subAct=savedanhba',
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
                    //jQuery('#danhbamdl-List').trigger('reloadGrid');
                    danhbaObj.loadgrid2('', '');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    danhbadel: function (fn) {
        var s = '';
        var items = $("#danhba-List");
        var lis = $(items).find('li');
        $.each(lis, function (i, Currentli) {
            var chekBtn = $(Currentli).find('input');
            if ($(chekBtn).is(':checked')) {
                var id = $('.User', Currentli);
                s += $(id).attr('_value') + ',';
            }

        });
        //alert(s);
        if ((s == '') || (s == null)) {
            alert('Chọn mẫu danh bạ để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa địa chỉ liên lạc này không?')) {
                var ll = s;
                //alert(ll);
                $.ajax({
                    url: danhbaObj.urlDefault + '&subAct=deldanhba',
                    dataType: 'script',
                    data: {
                        'DB_ID': ll
                    },
                    success: function (dt) {
                        danhbaObj.loadgrid2('', '');
                        //jQuery("#danhbamdl-List").trigger('reloadGrid');
                    }
                });
            }
        }

    },

    danhbadelG: function (fn) {
        var s = '';
        var items = $("#danhba-List");
        var lis = $(items).find('li');
        $.each(lis, function (i, Currentli) {
            var chekBtn = $(Currentli).find('input');
            if ($(chekBtn).is(':checked')) {
                var id = $('.User', Currentli);
                s += $(id).attr('_value') + ',';
            }

        });
        if ((s == '') || (s == null)) {
            alert('Chọn mẫu danh bạ để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa địa chỉ liên lạc này không?')) {
                var ll = s;
                //alert(ll);
                $.ajax({
                    url: danhbaObj.urlDefault + '&subAct=deldanhbaG',
                    dataType: 'script',
                    data: {
                        'DB_ID': ll
                    },
                    success: function (dt) {
                        danhbaObj.loadgrid2('', '');
                        //jQuery("#danhbamdl-List").trigger('reloadGrid');
                    }
                });
            }
        }

    },
    chuyentoi: function () {
        var s = '';
        var items = $("#danhba-List");
        var lis = $(items).find('li');
        $.each(lis, function (i, Currentli) {

            var chekBtn = $(Currentli).find('input');
            if ($(chekBtn).is(':checked')) {
                var id = $('.User', Currentli);
                s += $(id).attr('_value') + ',';
            }


        });
        alert(s);
        if ((s == '') || (s == null)) {
            alert('Chọn danh bạ');
        }
        else {
            $.ajax({
                url: danhbaObj.urlDefault + '&subAct=getgroup2',
                dataType: 'script',

                success: function (dt) {
                    adm.loading(null);
                    var items = $("#chonnhom");
                    ////console.log(dt);
                    var listdata = eval(dt);


                    var data = '<ul style="margin-left: -25px;">';
                    $.each(listdata, function (i, item) {
                        var CurrentItem = '';

                        CurrentItem += '<li class=\"checkbox\" >';
                        CurrentItem += '<input type=\"checkbox\"  name=\"' + i + '\" class=\"choose-me\"> ';
                        CurrentItem += '<span class=\"Ten\" _value=\"' + item.ID + '\">' + item.Ten + '</span>';
                        CurrentItem += '</li >';
                        data += CurrentItem;
                    });
                    data += '</ul>';
                    items = $(items).html(data);

                    var lis = $(items).find('li');
                    //////console.log(lis);
                    var GID = '';
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

                    var newDlg = $('#chonnhom');
                    $(newDlg).dialog({
                        title: 'Chọn nhóm',
                        width: 350,
                        modal: true,
                        buttons: {
                            'Xong': function () {

                                $.each(lis, function (i, Currentli) {
                                    var chekBtn = $(Currentli).find('input');

                                    if ($(chekBtn).is(':checked')) {
                                        var id = $(Currentli).find('span');
                                        GID += $(id).attr('_value') + ',';
                                    }

                                });

                                $.ajax({
                                    url: danhbaObj.urlDefault + '&subAct=chuyentoi',
                                    dataType: 'script',
                                    data: {
                                        'DB_ID': s,
                                        'G_ID': GID
                                    },
                                    success: function (dt) {
                                        adm.loading(null);
                                        $(newDlg).dialog('close');
                                    }
                                })


                            },
                            'Hủy': function () {
                                //                            danhbaObj.danhbasearch('');
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {


                        }
                    });
                }
            });
        }

    },
    danhbasearch: function () {

        timerSearch = setTimeout(function () {
            danhbaObj.loadgrid3();
        }, 500);
        adm.loading(null);
    },
    loadgrid3: function () {
        var GID = '';
        var items = $("#danhbagroup-List");
        var lis = $(items).find('li');
        $.each(lis, function (i, Currentli) {
            if ($(Currentli).hasClass('checkboxed')) {
                var id = $(Currentli).find('span');
                GID = $(id).attr('_value');
            }

        });
        //alert(GID);
        var newDlg = $('#danhbamdl-ListConten');
        var filterDB = $('.mdl-head-search-listdanhba', newDlg);
        var s = filterDB.val();
        if (s == 'Tìm kiếm') {
            s = '';
        }
        //alert(s);

        danhbaObj.loadgrid2(GID, s);

    },
    //Danhba//


    //chon danh ba2//
    loadHtmldanhba2: function (fn) {
        var dlg = $('#danhbamdl-dlgChondanhba');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');

            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.danhBa.htm3.htm")%>',
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
    chondanhba2: function (fn) {
        danhbaObj.loadHtmldanhba2(function () {
            var newDlg = $('#danhbamdl-dlgChondanhba');
            $(newDlg).dialog({
                title: 'Danh bạ',
                width: 450,
                height: 380,
                modal: true,
                buttons: {
                    'Chọn': function () {

                        var Listdanhba = $("#danhbamdl-Listdanhba", newDlg);
                        //var lables = $(Listdanhba).find('ul');
                        var lables = $(Listdanhba).find('li');
                        ////console.log(lables);
                        var data = '';
                        $.each(lables, function (i, Currentli) {
                            var check = $('input', Currentli);

                            if ($(check).is(':checked')) {
                                var lbTen = $('.Ten', Currentli);
                                var lbUser = $('.User', Currentli);
                                var user = $(lbUser).html();
                                user = user.substring(1, user.length - 1)

                                var CurrentItem = '';

                                CurrentItem = '<span class=\"adm-token-item-radi\" _value=\"' + user + '\">' + $(lbTen).html() + '<a href=\"javascript:;\">x</a></span>';
                                data += CurrentItem;
                            }

                        });
                        ////console.log(data);
                        if (typeof (fn) == 'function') {
                            fn(data);
                        }
                        //danhbaObj.danhbasearch('');
                        $(newDlg).dialog('close');



                    },
                    'Đóng': function () {
                        //danhbaObj.danhbasearch2('');
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    danhbaObj.loadchondanhba2();
                    //cau hinh droplist
                    var listgroup = $('#listgroup', newDlg);
                    adm.watermarks(listgroup, 'Lọc theo nhóm', function () {
                        adm.clearCombo([listgroup]);
                    });
                    danhbaObj.autoCompleteByGroup(true, listgroup, function (event, ui) {
                        $(listgroup).val(ui.item.Ten);
                        $(listgroup).attr('_value', ui.item.id);
                        danhbaObj.danhbasearch2();
                    });

                    //cau hinh tim kiem
                    var searchTxt = $('.mdl-head-search-danhba', newDlg);
                    $(searchTxt).keyup(function () {
                        danhbaObj.danhbasearch2();
                    });
                    adm.watermark(searchTxt, 'Tìm kiếm', function () {
                        //if ($(listgroup).attr('_value'))
                        $(searchTxt).val('');
                        danhbaObj.danhbasearch2();
                        $(searchTxt).val('Tìm kiếm');
                    });
                    adm.styleButton();

                }
            });
        });
    },
    loadchondanhba2: function (fn) {
        var newDlg = $('#danhbamdl-dlgChondanhba');
        var filterDB = $('.mdl-head-search-danhba', newDlg);
        var s = filterDB.val();
        if (s == 'Tìm kiếm') {
            s = '';
        }

        var listgroup = $('#listgroup', newDlg);
        var GID = listgroup.attr('_value');

        $.ajax({
            url: danhbaObj.urlDefault + '&subAct=get2',
            dataType: 'script',
            data: {
                'GID': GID,
                's': s
            },
            success: function (dt) {
                adm.loading(null);
                var Listdanhba = $("#danhbamdl-Listdanhba", newDlg);
                var items = $(".items", Listdanhba);
                //////console.log(dt);
                var listdata = eval(dt);

                var data = '';

                data += '<ul style="margin-left: -25px;">';
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
                    $(Currentli).click(function () {
                        if ($(Currentli).hasClass('checkboxed')) {
                            $(Currentli).removeClass('checkboxed');
                            $(Currentli).addClass('checkbox');
                            $(chekBtn).attr('checked', '');
                            danhbaObj.CheckCount();
                        }
                        else {
                            $(Currentli).removeClass('checkbox');
                            $(Currentli).addClass('checkboxed');
                            $(chekBtn).attr('checked', 'checked');
                            danhbaObj.CheckCount();
                        }

                    });

                });


                data = '';
                data += '<div class=\"checkall\" style=\"float:left; padding-left: 21px;\" > ';
                data += '        <div title=\"Chọn hết\" class=\"cbox col-hd\" style=\"float:left;\"> ';
                data += '             <input type=\"checkbox\" title=\"Chọn tất cả\"  class=\"checkboxall\" >';
                data += '        </div>';
                data += '    <div  class=\"tripane-col-hd\" style=\"float:left;\">Chọn tất cả</div>   ';
                data += '</div>';
                var checkallList = $(".checkallList", newDlg);
                checkallList = $(checkallList).html(data);
                var checkall = $('.checkboxall', checkallList);
                //                //console.log(checkallList);
                //                //console.log(checkall);

                $(checkall).click(function () {
                    $.each(lis, function (i, Currentli) {
                        var chekBtn = $(Currentli).find('input');
                        if ($(checkall).is(':checked')) {
                            $(chekBtn).attr('checked', 'checked');
                            $(Currentli).removeClass('checkbox');
                            $(Currentli).addClass('checkboxed');
                            danhbaObj.CheckCount();
                        }
                        else {
                            $(chekBtn).attr('checked', '');
                            $(Currentli).removeClass('checkboxed');
                            $(Currentli).addClass('checkbox');
                            danhbaObj.CheckCount();
                        }
                    });

                });

                $('#danhba-Count', newDlg).html('');
            }
        });

    },
    danhbasearch2: function () {

        timerSearch = setTimeout(function () {
            danhbaObj.loadchondanhba2();
        }, 500);
        adm.loading(null);
    },
    CheckCount: function () {

        var dlg = $("#danhbamdl-dlgChondanhba");
        var items = $(".items-choose", dlg);
        var lis = $(items).find('li');
        var counts = 0;
        $.each(lis, function (i, Currentli) {
            var chekBtn = $(Currentli).find('input');
            if ($(chekBtn).is(':checked'))
                counts += 1;
        });
        if (counts > 0) {
            var l = 'Bạn đã chọn:' + counts;
            $('#danhba-Count', dlg).html(l);
        }
        else {
            $('#danhba-Count', dlg).html('');
        }

    },

    //add danh ba
    loadHtmladddanhba: function (newDlg1, fn) {
        var dlg = $('#danhbamdl-dlgadddanhba', newDlg1);
        //alert('1');

        if ($(dlg).length < 1) {
            adm.loading('Dựng from');

            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.danhBa.htm4.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $(newDlg1).html(dt);
                    adm.styleButton();
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