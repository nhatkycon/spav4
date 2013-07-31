var tinnhandaxoaObj = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.tinNhan.daXoa.Class1, cnn.plugin.tinNhan',
    //chung	
    setup: function () {
        //alert(1111111);

        tinnhandaxoaObj.loadHtml();
        tinnhandaxoaObj.loadHtml1();
        tinnhandaxoaObj.loadHtml2();

        tinnhandaxoaObj.loadgrid();

        $('#tinnhandaxoamdl-troveBtn').hide();

        //cau hinh tim kiem
        var searchTxt = $('.mdl-head-search-tinnhandaxoa');
        $(searchTxt).keyup(function () {
            tinnhandaxoaObj.search();
        });
        adm.watermark(searchTxt, 'Tìm kiếm tin', function () {
            $(searchTxt).val('');
            tinnhandaxoaObj.search();
            $(searchTxt).val('Tìm kiếm tin');
        });
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu tin nhắn');
        adm.styleButton();
        $('#tinnhandaxoamdl-List').jqGrid({
            url: tinnhandaxoaObj.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['STT', 'TinID', 'Đặt cờ', 'Người gửi', 'Tiêu đề', 'Ngày gửi', 'File'],
            colModel: [
            { name: 'TN_Thutu', width: 10, resizable: true, sortable: true, align: "center" },
            { name: 'TN_TinID', key: true, sortable: true, hidden: true },
            { name: 'TNM_Co', width: 15, resizable: true, align: "center" },
            { name: 'TN_Usergui', width: 50, resizable: true, sortable: true, align: "left" },
            { name: 'TN_Tieude', width: 160, resizable: true, sortable: true, align: "left" },
            { name: 'TN_Ngaygui', width: 80, resizable: true, sortable: true, align: "left" },
            { name: 'TN_File', width: 20, resizable: true, sortable: true, align: "center" },

        ],
            caption: 'Hòm thư đã xóa',
            autowidth: true,
            sortname: 'TN_TinID',
            sortorder: 'desc',
            rowNum: 50,
            rowList: [50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#tinnhandaxoamdl-Pager'),
            onSelectRow: function (rowid) {


            },
            loadComplete: function () {
                adm.loading(null);

            },
            grouping: false,
            groupingView: {
                groupField: ['TN_Tieude'],
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
    setupfocus: function (newDlg) {
        var Nguoinhan = $('.Nguoinhan', newDlg);
        tinnhandaxoaObj.initkeypress(Nguoinhan);

        var Cc = $('.Cc', newDlg);
        tinnhandaxoaObj.initkeypress(Cc);

        var Bc = $('.Bc', newDlg);
        tinnhandaxoaObj.initkeypress(Bc);
    },
    initkeypress: function (input) {
        var inputTo = $(input).parent();
        $(inputTo).click(function () {
            $(input).focus();
        });

        $(input).keyup(function (e) {
            //alert(e.which);
            if (e.which == 188) {
                var s = $(input).val();
                if ((s.length > 0) & (s != ',')) {
                    $(input).val('');
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + s + '\">' + s + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(input);
                    var CurrentItem = $(inputTo).find('span[_value=' + s + ']');
                    var removeBtn = $(CurrentItem).find('a');
                    $(removeBtn).click(function () {
                        $(CurrentItem).remove();
                    });
                }
            }
            if (e.which == 8) {
                var s = $(input).val();

                if (s.length > 0) {
                    $(input).val('');

                }
                else {
                    //alert('aaa');
                    var spanar = $(inputTo).find('span');
                    var spancur = spanar[spanar.length - 1];
                    if (spanar.length > 0)
                        $(spancur).remove();

                }
            }
        });

    },
    selectRow: function (rowid) {
        tinnhandaxoaObj.getinfo(rowid);

        $('#tinnhandaxoamdl-TinID').val(rowid);
        $('#tinnhandaxoa-List').hide();
        tinnhandaxoaObj.hideBtn();
        $('#tinnhandaxoamdl-dlgChitiet').show();
        $('#tinnhandaxoamdl-troveBtn').show();
        $('#tinnhandaxoamdl-traloiBtn').show();
        $('#tinnhandaxoamdl-chuyentiepBtn').show();
    },
    hideDiv: function () {
        $('#tinnhandaxoamdl-dlgChitiet').hide();
        $('#tinnhandaxoamdl-dlgTraloi').hide();
        $('#tinnhandaxoamdl-dlgChuyentiep').hide();

    },
    hideBtn: function () {
        $('#tinnhandaxoamdl-chuyentiepBtn').hide();
        $('#tinnhandaxoamdl-traloiBtn').hide();
        $('#tinnhandaxoamdl-chuyentoiBtn').hide();
        $('#tinnhandaxoamdl-delBtn').hide();
        $('#tinnhandaxoamdl-datcoBtn').hide();
        $('#tinnhandaxoamdl-bocoBtn').hide();
        $('#tinnhandaxoamdl-chuyentoiDop').hide();
    },
    showBtn: function () {
        $('#tinnhandaxoamdl-chuyentiepBtn').show();
        $('#tinnhandaxoamdl-traloiBtn').show();
        $('#tinnhandaxoamdl-chuyentoiBtn').show();
        $('#tinnhandaxoamdl-delBtn').show();
        $('#tinnhandaxoamdl-datcoBtn').show();
        $('#tinnhandaxoamdl-bocoBtn').show();
        $('#tinnhandaxoamdl-chuyentoiDop').show();
    },
    quaylai: function () {
        $('#tinnhandaxoa-List').show();
        $('#tinnhandaxoamdl-troveBtn').hide();
        tinnhandaxoaObj.hideDiv();
        tinnhandaxoaObj.showBtn();
        //tinnhandaxoaObj.loadgrid();
        //$('#tinnhandaxoamdl-List').jqGrid('setGridParam', { url: tinnhandaxoaObj.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        jQuery('#tinnhandaxoamdl-List').trigger('reloadGrid');
    },
    chuyentoi: function (droplist) {
        var s = '';
        s = jQuery("#tinnhandaxoamdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tin nhắn');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tinnhandaxoamdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            adm.loading('Đang chuyển dữ liệu');
            $.ajax({
                url: tinnhandaxoaObj.urlDefault + '&subAct=chuyentoi',
                dataType: 'script',
                data: {
                    'ID': ll,
                    'chuyentoi': droplist.value
                },
                success: function (dt) {
                    jQuery("#tinnhandaxoamdl-List").trigger('reloadGrid');
                    adm.loading(null);
                }
            });
        }
    },
    getinfo: function (tinID) {

        adm.loading('Đang nạp dữ liệu');
        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=getInfo',
            dataType: 'script',
            data: {
                'ID': tinID
            },
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);
                var newDlg = $('#tinnhandaxoamdl-dlgChitiet');

                var lbnguoigui = $('#lbnguoigui', newDlg);
                $(lbnguoigui).html(data.Nguoigui);

                var lbnguoinhan = $('#lbnguoinhan', newDlg);
                $(lbnguoinhan).html(data.Nguoinhan);

                var lbCc = $('#lbCc', newDlg);
                $(lbCc).html(data.Listcc);

                var lbBc = $('#lbBc', newDlg);
                $(lbBc).html(data.Listbc);

                var lbnguoigui = $('#lbnguoigui', newDlg);
                $(lbnguoigui).html(data.Nguoigui);

                var lbngaygui = $('#lbngaygui', newDlg);
                $(lbngaygui).html(data.sNgaygui);
                //alert(data.Ngaygui);

                var lbtieude = $('#lbtieude', newDlg);
                $(lbtieude).html(data.Tieude);


                var lbnoidung = $('#lbnoidung', newDlg);
                $(lbnoidung).html(data.Noidung);

                var lbfilelist = $('.pp_mediabars', newDlg);
                $(lbfilelist).html(data.FileListStr);
            }
        });


    },
    search: function () {
        var timerSearch;
        var filterTN = $('.mdl-head-search-tinnhandaxoa');
        var s = filterTN.val();
        if (s == 'Tìm kiếm tin') {
            s = '';
        }

        timerSearch = setTimeout(function () {
            $('#tinnhandaxoamdl-List').jqGrid('setGridParam', { url: tinnhandaxoaObj.urlDefault + '&subAct=get&s=' + s }).trigger('reloadGrid');
        }, 500);
    },
    loadHtml: function (fn) {

        var dlg = $('#tinnhandaxoamdl-dlgTraloi');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');

            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.daXoa.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    //                    alert('OOK');
                    $('#tinnhandaxoamdl-ListConten').append(dt);
                    var newDlg = $('#tinnhandaxoamdl-dlgTraloi');
                    tinnhandaxoaObj.setupfocus(newDlg);
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
    loadHtml1: function (fn) {
        var dlg = $('#tinnhandaxoamdl-dlgChitiet');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.daXoa.htm1.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('#tinnhandaxoamdl-ListConten').append(dt);
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
    loadHtml2: function (fn) {

        var dlg = $('#tinnhandaxoamdl-dlgChuyentiep');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');

            $.ajax({
                url: '<%=WebResource("cnn.plugin.tinNhan.daXoa.htm2.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('#tinnhandaxoamdl-ListConten').append(dt);
                    var newDlg = $('#tinnhandaxoamdl-dlgTraloi');
                    tinnhandaxoaObj.setupfocus(newDlg);
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

    del: function (fn) {
        var s = '';
        s = jQuery("#tinnhandaxoamdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tin nhắn để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa tin nhắn này không?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    var treedata = $("#tinnhandaxoamdl-List").jqGrid('getRowData', ss[j]);
                    ll += ss[j] + ',';
                }
                $.ajax({
                    url: tinnhandaxoaObj.urlDefault + '&subAct=del',
                    dataType: 'script',
                    data: {
                        'ID': ll
                    },
                    success: function (dt) {
                        jQuery("#tinnhandaxoamdl-List").trigger('reloadGrid');
                    }
                });
            }
        }

    },

    datco: function (fn) {
        var s = '';
        s = jQuery("#tinnhandaxoamdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tin nhắn');
        }
        else {

            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tinnhandaxoamdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            adm.loading('Đang sử lý tin nhắn');
            $.ajax({
                url: tinnhandaxoaObj.urlDefault + '&subAct=datco',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    adm.loading(null);
                    jQuery("#tinnhandaxoamdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },

    boco: function (fn) {
        var s = '';
        s = jQuery("#tinnhandaxoamdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẫu tin nhắn');
        }
        else {

            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tinnhandaxoamdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            adm.loading('Đang sử lý tin nhắn');
            $.ajax({
                url: tinnhandaxoaObj.urlDefault + '&subAct=boco',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    adm.loading(null);
                    jQuery("#tinnhandaxoamdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    adduser: function (item, parent) {
        adm.regType(typeof (danhbaObj), 'cnn.plugin.tinNhan.danhBa.Class1, cnn.plugin.tinNhan', function () {
            danhbaObj.chondanhba2(function (data) {

                $(data).insertBefore(item);
                var span = $(parent).find('span');

                $.each(span, function (i, Currentspan) {
                    var removeBtn = $(Currentspan).find('a');
                    $(removeBtn).click(function () {
                        $(Currentspan).remove();
                    });

                });

            });

        });
    },
    showchitiet: function () {
        var dlg = $('#tinnhandaxoamdl-dlgChitiet');
        var chitiet = $('.chitiet', dlg);

        var hf = $('#hfchitiet', dlg);

        if ($(hf).hasClass('andiv')) {
            $(hf).html('Ẩn chi tiết');
            $(hf).removeClass('andiv');
            $(hf).addClass('hiendiv');
            $(chitiet).show();
        }
        else {
            $(hf).html('Hiện chi tiết');
            $(hf).removeClass('hiendiv');
            $(hf).addClass('andiv');
            $(chitiet).hide();
        }

    },
    //chung//

    //traloi
    traloi: function () {
        var tinid = '';
        var id = $('#tinnhandaxoamdl-TinID').val();
        if ((typeof (id) == 'undefined') || (id == '')) {
            if (jQuery("#tinnhandaxoamdl-List").jqGrid('getGridParam', 'selrow') != null) {
                tinid = jQuery("#tinnhandaxoamdl-List").jqGrid('getGridParam', 'selrow').toString();
            }
        }
        else {
            tinid = id;
        }
        if (tinid == '') {
            alert('Chọn một bản ghi');
            return;
        }

        $('#tinnhandaxoa-List').hide();
        tinnhandaxoaObj.hideDiv();
        tinnhandaxoaObj.hideBtn();

        $('#tinnhandaxoamdl-dlgTraloi').show();
        $('#tinnhandaxoamdl-troveBtn').show();
        adm.styleButton();
        adm.loading('Ðang nạp dữ liệu');
        tinnhandaxoaObj.clearformtl();
        tinnhandaxoaObj.addpoptraloifn();


        //alert(tinid);
        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=getInfotl',
            dataType: 'script',
            data: {
                'ID': tinid
            },
            success: function (dt) {
                //alert(1);
                adm.loading(null);
                var data = eval(dt);
                var newDlg = $('#tinnhandaxoamdl-dlgTraloi');

                var txtID = $('.ID', newDlg);
                $(txtID).val(data.TinID);
                //alert(data.TinID);

                var txtNguoinhan = $('.Nguoinhan', newDlg);
                //$(txtNguoinhan).val(data.Nguoigui);
                var NguoinhanToDiv = $(txtNguoinhan).parent();
                $(NguoinhanToDiv).prepend(data.Nguoigui);
                $(NguoinhanToDiv).find('a').click(function () {
                    $(this).parent().remove();
                });


                var txtTieuDe = $('.Tieude', newDlg);
                $(txtTieuDe).val(data.Tieude);


                var txtNoidung = $('.Noidung', newDlg);
                var noidungmoi = '----------Nội dung cũ--------<br>' + data.Noidung;
                $(txtNoidung).val(noidungmoi);

                tinnhandaxoaObj.insertDraffTL();

                var sendBtn = $('#tinnhandaxoamdl-dlgTraloi-sendBtn', newDlg);
                $(sendBtn).show();
                var saveBtn = $('#tinnhandaxoamdl-dlgTraloi-saveBtn', newDlg);
                $(saveBtn).show();
                var delBtn = $('#tinnhandaxoamdl-dlgTraloi-delBtn', newDlg);
                $(delBtn).show();
            }
        });



    },
    insertDraffTL: function (fn) {
        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');

        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=insertTin',
            success: function (_dt) {
                adm.loading(null);
                var dt = eval(_dt);
                var txtID = $('.ID', newDlg);
                $(txtID).val(dt.TinID);
                //alert(dt.TinID);
                $(txtID).attr('_value', dt.RowID);
                //alert(dt.RowID);
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    delEmptytl: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        adm.loading('Đang xóa tin nhắn');
        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=delEmpty',
            dataType: 'script',
            data: {
                'ID': id
            },
            success: function (dt) {
                tinnhandaxoaObj.clearformtl();
//                adm.loading(null);

//                var sendBtn = $('#tinnhandaxoamdl-dlgTraloi-sendBtn', newDlg);
//                $(sendBtn).hide();

//                var saveBtn = $('#tinnhandaxoamdl-dlgTraloi-saveBtn', newDlg);
//                $(saveBtn).hide();

//                var delBtn = $('#tinnhandaxoamdl-dlgTraloi-delBtn', newDlg);
//                $(delBtn).hide();

//                var newBtn = $('#tinnhandaxoamdl-dlgTraloi-newBtn', newDlg);
//                $(newBtn).show();
                adm.regType(typeof (danhbaObj), 'cnn.plugin.tinNhan.danhBa.Class1, cnn.plugin.tinNhan', function () {
                    danhbaObj.loadHtmladddanhba(newDlg, function () {

                        var dlg = $('#danhbamdl-dlgadddanhba', newDlg);
                        dlg.show();

                        $('.success', dlg).html('Thư của bạn đã được hủy');
                        $('.label', dlg).find('b').html('');
                        $('.inline-items', dlg).html('');
                    });

                });

            }
        });


    },
    clearformtl: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');

        var txtTieude = $('.Tieude', newDlg);
        $(txtTieude).val('');


        var txtNoidung = $('.Noidung', newDlg);
        $(txtNoidung).val('');

        var Nguoinhan = $('.Nguoinhan', newDlg);
        Nguoinhan = $(Nguoinhan).parent();
        $(Nguoinhan).find('span').remove();
        //$(Nguoinhan).html('');


        var tinnhanCC = $('.Cc', newDlg);
        tinnhanCC = $(tinnhanCC).parent();
        $(tinnhanCC).find('span').remove();
        //$(tinnhanCC).html('');

        var tinnhanBC = $('.Bc', newDlg);
        tinnhanBC = $(tinnhanBC).parent();
        $(tinnhanBC).find('span').remove();
        //$(tinnhanBC).html('');

        var fileList = $('.adm-upload-fileList', newDlg);
        $(fileList).html('');

        //alert('ok');

    },
    sendtl: function (fn) {

        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');
        var spbMsg = $('.admMsg', newDlg);

        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        //alert(id);

        var txtTieuDe = $('.Tieude', newDlg);
        var TieuDe = $(txtTieuDe).val();


        var txtNoidung = $('.Noidung', newDlg);
        var Noidung = $(txtNoidung).val();

        var checkQuantrong = $('.Quantrong', newDlg);
        var Quantrong = $(checkQuantrong).is(':checked');

        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        var l = '';
        $.each($(NguoinhanToDiv).find('span'), function (i, item) {
            l += $(item).attr('_value') + ',';
        });
        Nguoinhan = l;
        //alert(l);

        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        var l1 = '';
        $.each($(tinnhanCCToDiv).find('span'), function (i, item) {
            l1 += $(item).attr('_value') + ',';
        });
        //alert(l1);

        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        var l2 = '';
        $.each($(tinnhanBCToDiv).find('span'), function (i, item) {
            l2 += $(item).attr('_value') + ',';
        });
        //alert(l2);

        var fileList = $('.adm-upload-fileList', newDlg);
        var fileListToDiv = $(fileList).parent();
        var l3 = '';
        $.each($(fileListToDiv).find('span'), function (i, item) {
            l3 += $(item).attr('_value') + ',';
        });
        //alert(l3);

        var err = '';
        if (id == '') {
            err += 'Lỗi lưu dữ liệu<br/>';

        }
        if (Nguoinhan == '') {
            err += 'Nhập người nhận<br/>';
        }
        if (TieuDe == '') {
            err += 'Chưa nhập tiêu đề<br/>';
        }

        if (Noidung == '') {
            err += 'Nhập nội dung<br/>';
        }

        if (err != '') {
            spbMsg.html(err);
            return;
        }

        adm.loading('Đang gửi tin nhắn');
        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=sendtl',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'Tieude': TieuDe,
                'Noidung': Noidung,
                'Nguoinhan': l,
                'UserCC': l1,
                'UserBC': l2,
                'File': l3,
                'Quantrong': Quantrong
            },
            success: function (dt) {

                adm.loading(null);
                if (dt == '1') {
                    tinnhandaxoaObj.clearformtl();
//                    spbMsg.html('Thư của bạn đã được gửi');

//                    var sendBtn = $('#tinnhandaxoamdl-dlgTraloi-sendBtn', newDlg);
//                    $(sendBtn).attr('disabled', 'disabled');
//                    //$('#Tinnhanmdl-saveBtn').attr('disabled', 'disabled');
//                    $(sendBtn).hide();

//                    var saveBtn = $('#tinnhandaxoamdl-dlgTraloi-saveBtn', newDlg);
//                    $(saveBtn).hide();

//                    var delBtn = $('#tinnhandaxoamdl-dlgTraloi-delBtn', newDlg);
//                    $(delBtn).hide();

//                    var newBtn = $('#tinnhandaxoamdl-dlgTraloi-newBtn', newDlg);
//                    $(newBtn).show();

                    danhbaObj.loadHtmladddanhba(newDlg, function () {

                        var dlg = $('#danhbamdl-dlgadddanhba', newDlg);
                        dlg.show();
                        var listUser = l + l1 + l2;

                        $.ajax({
                            url: danhbaObj.urlDefault + '&subAct=addexist',
                            dataType: 'script',
                            type: 'POST',
                            data: {
                                'listUser': listUser
                            },
                            success: function (dt) {
                                adm.loading(null);
                                if (dt == '1') {
                                    adm.loading('Lưu dữ liệu thành công');

                                    listUser = l + l1 + l2;
                                    listUser = listUser.replace(/,/g, ", ");
                                    $('.inline-items', dlg).html(listUser);
                                }
                                else {
                                    adm.loading('Lỗi máy chủ, chưa thể lưu được vào danh bạ');
                                }
                            }
                        });

                    });
                   
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }

            }

        });

    },
    savetl: function (validate, fn) {
        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');
        var spbMsg = $('.admMsg', newDlg);

        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();


        var txtCc = $('.Cc', newDlg);
        var Cc = $(txtCc).val();

        var txtBc = $('.Bc', newDlg);
        var Bc = $(txtBc).val();

        var txtTieuDe = $('.Tieude', newDlg);
        var TieuDe = $(txtTieuDe).val();

        var txtNoidung = $('.Noidung', newDlg);
        var Noidung = $(txtNoidung).val();


        var checkQuantrong = $('.Quantrong', newDlg);
        var Quantrong = $(checkQuantrong).is(':checked');
        //alert(2);

        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        var l = '';
        $.each($(NguoinhanToDiv).find('span'), function (i, item) {
            l += $(item).attr('_value') + ',';
        });
        //alert(l);

        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        var l1 = '';
        $.each($(tinnhanCCToDiv).find('span'), function (i, item) {
            l1 += $(item).attr('_value') + ',';
        });
        //alert(l1);

        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        var l2 = '';
        $.each($(tinnhanBCToDiv).find('span'), function (i, item) {
            l2 += $(item).attr('_value') + ',';
        });
        //alert(l2);


        var fileList = $('.adm-upload-fileList', newDlg);
        var fileListToDiv = $(fileList).parent();
        var l3 = '';
        $.each($(fileListToDiv).find('span'), function (i, item) {
            l3 += $(item).attr('_value') + ',';
        });
        //alert(l3);


        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=savetl',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'Tieude': TieuDe,
                'Noidung': Noidung,
                'Nguoinhan': l,
                'UserCC': l1,
                'UserBC': l2,
                'File': l3,
                'Quantrong': Quantrong

            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    spbMsg.html('Lưu dữ liệu thành công');

                    var sendBtn = $('#tinnhandaxoamdl-dlgTraloi-sendBtn', newDlg);
                    $(sendBtn).attr('disabled', 'disabled');
                    //$('#Tinnhanmdl-saveBtn').attr('disabled', 'disabled');
                    $(sendBtn).hide();

                    var saveBtn = $('#tinnhandaxoamdl-dlgTraloi-saveBtn', newDlg);
                    $(saveBtn).hide();

                    var delBtn = $('#tinnhandaxoamdl-dlgTraloi-delBtn', newDlg);
                    $(delBtn).hide();

                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    initMailTraloi: function (fn) {

        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');
        //cai dat nguoi nhan
        var Nguoinhan = $('.Nguoinhan', newDlg);
        $(Nguoinhan).focus();
        var NguoinhanToDiv = $(Nguoinhan).parent();
        $(NguoinhanToDiv).find('span').remove();
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(Nguoinhan, function (e, ui) {

                var CurrentItem = $(NguoinhanToDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    $(Nguoinhan).val('');
                }, 100);
                if ($(CurrentItem).length < 1) {
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(Nguoinhan);
                    CurrentItem = $(NguoinhanToDiv).find('span[_value=' + ui.item.value + ']');
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
        //cai dat CC
        var tinnhanCC = $('.Cc', newDlg);
        // $(tinnhanCC).focus();
        var tinnhanCCDiv = $(tinnhanCC).parent();
        $(tinnhanCCDiv).find('span').remove();
        //alert($(tinnhanCC));
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(tinnhanCC, function (e, ui) {

                var CurrentItem = $(tinnhanCCDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    $(tinnhanCC).val('');
                }, 100);
                if ($(CurrentItem).length < 1) {
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(tinnhanCC);
                    CurrentItem = $(tinnhanCCDiv).find('span[_value=' + ui.item.value + ']');
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
        //cai dat Bc
        var tinnhanBC = $('.Bc', newDlg);
        //$(tinnhanBC).focus();
        var tinnhanBCDiv = $(tinnhanBC).parent();
        $(tinnhanBCDiv).find('span').remove();
        //alert($(tinnhanBC));
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(tinnhanBC, function (e, ui) {

                var CurrentItem = $(tinnhanBCDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    $(tinnhanBC).val('');
                }, 100);
                if ($(CurrentItem).length < 1) {
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(tinnhanBC);
                    CurrentItem = $(tinnhanBCDiv).find('span[_value=' + ui.item.value + ']');
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
    addpoptraloifn: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');

        var txtNoiDung = $('.Noidung', newDlg);
        adm.createFck_TN(txtNoiDung);
        tinnhandaxoaObj.initMailTraloi();

        var txtID = $('.ID', newDlg);
        var fileList = $('.adm-upload-fileList', newDlg);
        var fileBtn = $('.File', newDlg);
        var _params = { 'act': 'uploadfileDkLuong' }
        adm.upload(fileBtn, 'data', _params, function (rs) {
        }, function (_rs) {

        }, function (_r, _f) {
            var l = '';
            // alert(_r.replace('.', ''));
            l += '<span class=\"adm-token-item-radi\"><span onclick=\"javascript:document.location.href=\'Default.aspx?act=download&ID=' + _r.replace('.', '') + '\'\">' + _f + '</span><a _value=\"' + _r.replace('.', '') + '\"  href=\"javascript:;\">x</a></span>';
            $.ajax({
                url: tinnhandaxoaObj.urlDefault,
                data: {
                    'subAct': 'saveDoc',
                    'F_ID': _r,
                    'ID': $(txtID).attr('_value')
                },
                success: function (dt) {

                }
            });
            //alert(txtID.val());
            $(l).appendTo(fileList).find('a').click(function () {
                var _item = $(this);
                $(_item).hide();
                $.ajax({
                    url: tinnhandaxoaObj.urlDefault,
                    data: {
                        'subAct': 'DeleteDoc',
                        'F_ID': $(_item).attr('_value')
                    },
                    success: function (dt) {
                        $(_item).remove();
                    }
                });
                $(this).parent().remove();
            });
        });
    },
    addnguoinhantl: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');
        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        tinnhandaxoaObj.adduser(Nguoinhan, NguoinhanToDiv);
    },
    addcctl: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');
        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        tinnhandaxoaObj.adduser(tinnhanCC, tinnhanCCToDiv);
    },
    addbctl: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');
        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        tinnhandaxoaObj.adduser(tinnhanBC, tinnhanBCToDiv);
    },
    thembctl: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgTraloi');
        $('#rowbc', newDlg).show();

    },
    //traloi//	

    //chuyentiep
    chuyentiep: function () {
        var tinid = '';
        var id = $('#tinnhandaxoamdl-TinID').val();
        if ((typeof (id) == 'undefined') || (id == '')) {
            if (jQuery("#tinnhandaxoamdl-List").jqGrid('getGridParam', 'selrow') != null) {
                tinid = jQuery("#tinnhandaxoamdl-List").jqGrid('getGridParam', 'selrow').toString();
            }
        }
        else {
            tinid = id;
        }
        if (tinid == '') {
            alert('Chọn một bản ghi');
            return;
        }


        //alert(s);
        adm.styleButton();
        $('#tinnhandaxoa-List').hide();
        tinnhandaxoaObj.hideDiv();
        tinnhandaxoaObj.hideBtn();


        $('#tinnhandaxoamdl-dlgChuyentiep').show();
        $('#tinnhandaxoamdl-troveBtn').show();


        adm.loading('Ðang nạp dữ liệu');
        //tinnhandaxoaObj.clearform();
        tinnhandaxoaObj.addpopchuyentieppfn();

        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=getInfoct',
            dataType: 'script',
            data: {
                'ID': tinid
            },
            success: function (dt) {
                //alert(1);
                adm.loading(null);
                var data = eval(dt);
                var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');

                var txtID = $('.ID', newDlg);
                $(txtID).val(data.TinID);
                //alert(data.TinID);

                var txtTieuDe = $('.Tieude', newDlg);
                $(txtTieuDe).val(data.Tieude);


                var txtNoidung = $('.Noidung', newDlg);
                $(txtNoidung).val(data.Noidung);

                var lbladm_upload_fileList = $('.adm-upload-fileList', newDlg);
                $(lbladm_upload_fileList).html(data.FileListStr);
                $(lbladm_upload_fileList).find('a').click(function () {
                    var _item = $(this).parent();
                    $(_item).hide();
                    $.ajax({
                        url: tinnhandaxoaObj.urlDefault,
                        data: {
                            'subAct': 'DeleteDoc',
                            'F_ID': $(_item).attr('_value')
                        },
                        success: function (dt) {
                            $(_item).remove();
                        }
                    });
                    $(this).parent().remove();
                });


                tinnhandaxoaObj.insertDraffCT(data.TinID);

                var sendBtn = $('#tinnhandaxoamdl-dlgChuyentiep-sendBtn', newDlg);
                $(sendBtn).attr('disabled', 'disabled');
                //$('#Tinnhanmdl-saveBtn').attr('disabled', 'disabled');
                $(sendBtn).show();

                var saveBtn = $('#tinnhandaxoamdl-dlgChuyentiep-saveBtn', newDlg);
                $(saveBtn).show();

                var delBtn = $('#tinnhandaxoamdl-dlgChuyentiep-delBtn', newDlg);
                $(delBtn).show();
            }
        });




    },
    insertDraffCT: function (tinid) {
        //        var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');
        //        var id = $('.ID', newDlg);
        //        id = $(id).val();
        //alert(tinid);
        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=insertTinct',
            dataType: 'script',
            data: {
                'ID': tinid
            },
            success: function (_dt) {
                adm.loading(null);
                var dt = eval(_dt);
                var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');
                var txtID = $('.ID', newDlg);
                $(txtID).val(dt.TinID);
                //alert(dt.TinID);
                $(txtID).attr('_value', dt.RowID);
                //alert(dt.RowID);
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    savect: function (validate, fn) {
        var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');
        var spbMsg = $('.admMsg', newDlg);

        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();


        var txtCc = $('.Cc', newDlg);
        var Cc = $(txtCc).val();

        var txtBc = $('.Bc', newDlg);
        var Bc = $(txtBc).val();

        var txtTieuDe = $('.Tieude', newDlg);
        var TieuDe = $(txtTieuDe).val();

        var txtNoidung = $('.Noidung', newDlg);
        var Noidung = $(txtNoidung).val();

        var checkQuantrong = $('.Quantrong', newDlg);
        var Quantrong = $(checkQuantrong).is(':checked');
        //alert(2);

        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        var l = '';
        $.each($(NguoinhanToDiv).find('span'), function (i, item) {
            l += $(item).attr('_value') + ',';
        });
        //alert(l);

        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        var l1 = '';
        $.each($(tinnhanCCToDiv).find('span'), function (i, item) {
            l1 += $(item).attr('_value') + ',';
        });
        //alert(l1);

        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        var l2 = '';
        $.each($(tinnhanBCToDiv).find('span'), function (i, item) {
            l2 += $(item).attr('_value') + ',';
        });
        //alert(l2);


        var fileList = $('.adm-upload-fileList', newDlg);
        var fileListToDiv = $(fileList).parent();
        var l3 = '';
        $.each($(fileListToDiv).find('span'), function (i, item) {
            l3 += $(item).attr('_value') + ',';
        });
        //alert(l3);


        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=savect',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'Tieude': TieuDe,
                'Noidung': Noidung,
                'Nguoinhan': l,
                'UserCC': l1,
                'UserBC': l2,
                'File': l3,
                'Quantrong': Quantrong

            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    spbMsg.html('Lưu dữ liệu thành công');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    sendct: function (fn) {

        var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');
        var spbMsg = $('.admMsg', newDlg);

        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        //alert(id);

        var txtTieuDe = $('.Tieude', newDlg);
        var TieuDe = $(txtTieuDe).val();


        var txtNoidung = $('.Noidung', newDlg);
        var Noidung = $(txtNoidung).val();

        var checkQuantrong = $('.Quantrong', newDlg);
        var Quantrong = $(checkQuantrong).is(':checked');

        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        var l = '';
        $.each($(NguoinhanToDiv).find('span'), function (i, item) {
            l += $(item).attr('_value') + ',';
        });
        Nguoinhan = l;
        //alert(l);

        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        var l1 = '';
        $.each($(tinnhanCCToDiv).find('span'), function (i, item) {
            l1 += $(item).attr('_value') + ',';
        });
        //alert(l1);

        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        var l2 = '';
        $.each($(tinnhanBCToDiv).find('span'), function (i, item) {
            l2 += $(item).attr('_value') + ',';
        });
        //alert(l2);

        var fileList = $('.adm-upload-fileList', newDlg);
        var fileListToDiv = $(fileList).parent();
        var l3 = '';
        $.each($(fileListToDiv).find('span'), function (i, item) {
            l3 += $(item).attr('_value') + ',';
        });
        //alert(l3);

        var err = '';
        if (id == '') {
            err += 'Lỗi lưu dữ liệu<br/>';

        }
        if (Nguoinhan == '') {
            err += 'Nhập người nhận<br/>';
        }
        if (TieuDe == '') {
            err += 'Chưa nhập tiêu đề<br/>';
        }

        if (Noidung == '') {
            err += 'Nhập nội dung<br/>';
        }

        if (err != '') {
            spbMsg.html(err);
            return;
        }
        adm.loading('Đang gửi tin nhắn');
        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=sendct',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'Tieude': TieuDe,
                'Noidung': Noidung,
                'Nguoinhan': l,
                'UserCC': l1,
                'UserBC': l2,
                'File': l3,
                'Quantrong': Quantrong
            },
            success: function (dt) {

                adm.loading(null);
                if (dt == '1') {
                    tinnhandaxoaObj.clearformct();
//                    spbMsg.html('Thư của bạn đã được gửi');

//                    var sendBtn = $('#tinnhandaxoamdl-dlgChuyentiep-sendBtn', newDlg);
//                    $(sendBtn).attr('disabled', 'disabled');
//                    //$('#Tinnhanmdl-saveBtn').attr('disabled', 'disabled');
//                    $(sendBtn).hide();

//                    var saveBtn = $('#tinnhandaxoamdl-dlgChuyentiep-saveBtn', newDlg);
//                    $(saveBtn).hide();

//                    var delBtn = $('#tinnhandaxoamdl-dlgChuyentiep-delBtn', newDlg);
//                    $(delBtn).hide();

//                    var newBtn = $('#tinnhandaxoamdl-dlgChuyentiep-newBtn', newDlg);
                    //                    $(newBtn).show();
                    danhbaObj.loadHtmladddanhba(newDlg, function () {

                        var dlg = $('#danhbamdl-dlgadddanhba', newDlg);
                        dlg.show();
                        var listUser = l + l1 + l2;

                        $.ajax({
                            url: danhbaObj.urlDefault + '&subAct=addexist',
                            dataType: 'script',
                            type: 'POST',
                            data: {
                                'listUser': listUser
                            },
                            success: function (dt) {
                                adm.loading(null);
                                if (dt == '1') {
                                    adm.loading('Lưu dữ liệu thành công');

                                    listUser = l + l1 + l2;
                                    listUser = listUser.replace(/,/g, ", ");
                                    $('.inline-items', dlg).html(listUser);
                                }
                                else {
                                    adm.loading('Lỗi máy chủ, chưa thể lưu được vào danh bạ');
                                }
                            }
                        });

                    });
                   
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }


            }

        });

    },
    clearformct: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');

        var txtTieuDe = $('.Tieude', newDlg);
        $(txtTieuDe).val('');

        var txtNoidung = $('.Noidung', newDlg);
        $(txtNoidung).val('');

        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        $(NguoinhanToDiv).find('span').remove();
        //$(Nguoinhan).val('');

        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        $(tinnhanCCToDiv).find('span').remove();
        //$(tinnhanCC).val('');

        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        $(tinnhanBCToDiv).find('span').remove();
        //$(tinnhanBC).val('');

        var fileList = $('.adm-upload-fileList', newDlg);
        var fileListToDiv = $(fileList).parent();
        $(fileListToDiv).find('span').remove();
        //$(fileListToDiv).val('');


        //alert('ok!');
    },
    initMailChuyentiep: function (fn) {

        var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');
        //cai dat nguoi nhan
        var Nguoinhan = $('.Nguoinhan', newDlg);
        $(Nguoinhan).focus();
        var NguoinhanToDiv = $(Nguoinhan).parent();
        $(NguoinhanToDiv).find('span').remove();
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(Nguoinhan, function (e, ui) {

                var CurrentItem = $(NguoinhanToDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    $(Nguoinhan).val('');
                }, 100);
                if ($(CurrentItem).length < 1) {
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(Nguoinhan);
                    CurrentItem = $(NguoinhanToDiv).find('span[_value=' + ui.item.value + ']');
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
        //cai dat CC
        var tinnhanCC = $('.Cc', newDlg);
        // $(tinnhanCC).focus();
        var tinnhanCCDiv = $(tinnhanCC).parent();
        $(tinnhanCCDiv).find('span').remove();
        //alert($(tinnhanCC));
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(tinnhanCC, function (e, ui) {

                var CurrentItem = $(tinnhanCCDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    $(tinnhanCC).val('');
                }, 100);
                if ($(CurrentItem).length < 1) {
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(tinnhanCC);
                    CurrentItem = $(tinnhanCCDiv).find('span[_value=' + ui.item.value + ']');
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
        //cai dat Bc
        var tinnhanBC = $('.Bc', newDlg);
        //$(tinnhanBC).focus();
        var tinnhanBCDiv = $(tinnhanBC).parent();
        $(tinnhanBCDiv).find('span').remove();
        //alert($(tinnhanBC));
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(tinnhanBC, function (e, ui) {

                var CurrentItem = $(tinnhanBCDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    $(tinnhanBC).val('');
                }, 100);
                if ($(CurrentItem).length < 1) {
                    var l = '';
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(tinnhanBC);
                    CurrentItem = $(tinnhanBCDiv).find('span[_value=' + ui.item.value + ']');
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
    delEmptyct: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();

        adm.loading('Đang xóa tin nhắn');
        $.ajax({
            url: tinnhandaxoaObj.urlDefault + '&subAct=delEmpty',
            dataType: 'script',
            data: {
                'ID': id
            },
            success: function (dt) {
                tinnhandaxoaObj.clearformct();
                adm.loading(null);

//                var sendBtn = $('#tinnhandaxoamdl-dlgChuyentiep-sendBtn', newDlg);
//                $(sendBtn).attr('disabled', 'disabled');
//                //$('#Tinnhanmdl-saveBtn').attr('disabled', 'disabled');
//                $(sendBtn).hide();

//                var saveBtn = $('#tinnhandaxoamdl-dlgChuyentiep-saveBtn', newDlg);
//                $(saveBtn).hide();

//                var delBtn = $('#tinnhandaxoamdl-dlgChuyentiep-delBtn', newDlg);
//                $(delBtn).hide();

//                var newBtn = $('#tinnhandaxoamdl-dlgChuyentiep-newBtn', newDlg);
                //                $(newBtn).show();

                adm.regType(typeof (danhbaObj), 'cnn.plugin.tinNhan.danhBa.Class1, cnn.plugin.tinNhan', function () {
                    danhbaObj.loadHtmladddanhba(newDlg, function () {

                        var dlg = $('#danhbamdl-dlgadddanhba', newDlg);
                        dlg.show();

                        $('.success', dlg).html('Thư của bạn đã được hủy');
                        $('.label', dlg).find('b').html('');
                        $('.inline-items', dlg).html('');
                    });

                });
            }
        });

    },
    addpopchuyentieppfn: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');

        var txtNoiDung = $('.Noidung', newDlg);
        adm.createFck_TN(txtNoiDung);
        tinnhandaxoaObj.initMailChuyentiep();

        var txtID = $('.ID', newDlg);
        var fileList = $('.adm-upload-fileList', newDlg);
        var fileBtn = $('.File', newDlg);
        var _params = { 'act': 'uploadfileDkLuong' }

        adm.upload(fileBtn, 'data', _params, function (rs) {
        }, function (_rs) {

        }, function (_r, _f) {
            var l = '';
            // alert(_r.replace('.', ''));
            l += '<span class=\"adm-token-item-radi\"><span onclick=\"javascript:document.location.href=\'Default.aspx?act=download&ID=' + _r.replace('.', '') + '\'\">' + _f + '</span><a _value=\"' + _r.replace('.', '') + '\"  href=\"javascript:;\">x</a></span>';
            $.ajax({
                url: tinnhandaxoaObj.urlDefault,
                data: {
                    'subAct': 'saveDoc',
                    'F_ID': _r,
                    'ID': $(txtID).attr('_value')
                },
                success: function (dt) {

                }
            });
            //alert(txtID.val());
            $(l).appendTo(fileList).find('a').click(function () {
                var _item = $(this);
                $(_item).hide();
                $.ajax({
                    url: tinnhandaxoaObj.urlDefault,
                    data: {
                        'subAct': 'DeleteDoc',
                        'F_ID': $(_item).attr('_value')
                    },
                    success: function (dt) {
                        $(_item).remove();
                    }
                });
                $(this).parent().remove();
            });
        });

    },
    addnguoinhanct: function () {
         var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');
        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        tinnhandaxoaObj.adduser(Nguoinhan, NguoinhanToDiv);
    },
    addccct: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');
        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        tinnhandaxoaObj.adduser(tinnhanCC, tinnhanCCToDiv);
    },
    addbcct: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');
        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        tinnhandaxoaObj.adduser(tinnhanBC, tinnhanBCToDiv);
    },
    thembcct: function () {
        var newDlg = $('#tinnhandaxoamdl-dlgChuyentiep');
        $('#rowbc', newDlg).show();

    }
    //chuyentiep//




}