var tinNhanObj = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.tinNhan.Class1, cnn.plugin.tinNhan',
    setup: function () {
        //alert('ok');
        adm.styleButton();
        var newDlg = $('#Tinnhanmdl-dlgNew');
        var txtNoiDung = $('.Noidung', newDlg);
        adm.createFck_TN(txtNoiDung);



        var Nguoinhan = $('.Nguoinhan', newDlg);
        tinNhanObj.initkeypress(Nguoinhan);

        var Cc = $('.Cc', newDlg);
        tinNhanObj.initkeypress(Cc);

        var Bc = $('.Bc', newDlg);
        tinNhanObj.initkeypress(Bc);


        tinNhanObj.insertDraff();
        tinNhanObj.addpopfn();
        tinNhanObj.initMail();


    },
    initMail: function (fn) {

        var newDlg = $('#Tinnhanmdl-dlgNew');
        //cai dat nguoi nhan
        var EmailTo = $('.Nguoinhan', newDlg);
        $(EmailTo).focus();
        var EmailToDiv = $(EmailTo).parent();
        $(EmailToDiv).find('span').remove();
        //alert($(EmailTo));
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete2(EmailTo, function (e, ui) {
                var CurrentItem = $(EmailToDiv).find('span[_value=' + ui.item.value + ']');
                setTimeout(function () {
                    var s = $(EmailTo).val();
                    if (s == '')
                        return;
                    else
                        $(EmailTo).val('');
                    if ($(CurrentItem).length < 1) {
                        var l = '';
                        l += '<span class=\"adm-token-item-radi\" _value=\"' + ui.item.value + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                        $(l).insertBefore(EmailTo);
                        CurrentItem = $(EmailToDiv).find('span[_value=' + ui.item.value + ']');
                        var removeBtn = $(CurrentItem).find('a');
                        $(removeBtn).click(function () {
                            $(CurrentItem).remove();
                        });

                        $(CurrentItem).click(function () {
                            $(CurrentItem).remove();
                        });
                    }
                    else {
                        $(CurrentItem).animate({ backgroundColor: 'orange' }, 500, function () {
                            $(CurrentItem).animate({ backgroundColor: 'white' }, 500);
                        });
                    }
                }, 100);

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
                    l += '<span class=\"adm-token-item-radi\" _value=\"' + s.substring(0, s.length - 1) + '\">' + s.substring(0, s.length - 1) + '<a href=\"javascript:;\">x</a></span>';
                    $(l).insertBefore(input);
                    var CurrentItem = $(inputTo).find('span[_value=' + s.substring(0, s.length - 1) + ']');
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
    insertDraff: function (fn) {
        var newDlg = $('#Tinnhanmdl-dlgNew');

        $.ajax({
            url: tinNhanObj.urlDefault + '&subAct=insertTin',
            success: function (_dt) {
                adm.loading(null);
                var dt = eval(_dt);
                var txtID = $('.ID', newDlg);
                $(txtID).val(dt.TinID);
                // alert(dt.TinID);
                $(txtID).attr('_value', dt.RowID);
                //alert(dt.RowID);
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    themmoi: function () {
        tinNhanObj.clearform();
        tinNhanObj.setup();

        var newDlg = $('#Tinnhanmdl-dlgNew');
        var sendBtn = $('#Tinnhanmdl-sendBtn', newDlg);
        $(sendBtn).show();

        var saveBtn = $('#Tinnhanmdl-saveBtn', newDlg);
        $(saveBtn).show();

        var delBtn = $('#Tinnhanmdl-delBtn', newDlg);
        $(delBtn).show();

        var newBtn = $('#Tinnhanmdl-newBtn', newDlg);
        $(newBtn).hide();
    },
    del: function (fn) {

        var newDlg = $('#Tinnhanmdl-dlgNew');
        var spbMsg = $('.admMsg', newDlg);

        var txtID = $('.ID', newDlg);
        adm.loading('Đang xóa tin nhắn');
        $.ajax({
            url: tinNhanObj.urlDefault + '&subAct=del',
            dataType: 'script',
            data: {
                'ID': txtID.val()
            },
            success: function (dt) {
                tinNhanObj.clearform();
//                spbMsg.html('Xóa dữ liệu thành công');
//                adm.loading(null);

//                var sendBtn = $('#Tinnhanmdl-sendBtn', newDlg);
//                $(sendBtn).attr('disabled', 'disabled');
//                //$('#Tinnhanmdl-saveBtn').attr('disabled', 'disabled');
//                $(sendBtn).hide();

//                var saveBtn = $('#Tinnhanmdl-saveBtn', newDlg);
//                $(saveBtn).hide();

//                var delBtn = $('#Tinnhanmdl-delBtn', newDlg);
//                $(delBtn).hide();

//                var newBtn = $('#Tinnhanmdl-newBtn', newDlg);
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
    send: function (fn) {

        var newDlg = $('#Tinnhanmdl-dlgNew');
        var spbMsg = $('.admMsg', newDlg);

        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();

        var txtTieuDe = $('.Tieude', newDlg);
        var TieuDe = $(txtTieuDe).val();

        var checkQuantrong = $('.Quantrong', newDlg);
        var Quantrong = $(checkQuantrong).is(':checked');

        var txtNoidung = $('.Noidung', newDlg);
        var Noidung = $(txtNoidung).val();

        var EmailTo = $('.Nguoinhan', newDlg);
        var EmailToDiv = $(EmailTo).parent();
        var l = '';
        $.each($(EmailToDiv).find('span'), function (i, item) {
            l += $(item).attr('_value') + ',';
        });
        var Nguoinhan = l;
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
        if ((id == '') || (id == null)) {
            err += 'Lỗi lưu dữ liệu<br/>';

        }
        if (Nguoinhan == '') {
            err += 'Nhập người nhận<br/>';
        }
        if ((TieuDe == '') || (TieuDe == null)) {
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
            url: tinNhanObj.urlDefault + '&subAct=send',
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
                tinNhanObj.clearform();
//                spbMsg.html('Thư của bạn đã được gửi');

//                var sendBtn = $('#Tinnhanmdl-sendBtn', newDlg);
//                $(sendBtn).attr('disabled', 'disabled');
//                $(sendBtn).hide();

//                var saveBtn = $('#Tinnhanmdl-saveBtn', newDlg);
//                $(saveBtn).hide();

//                var delBtn = $('#Tinnhanmdl-delBtn', newDlg);
//                $(delBtn).hide();

//                var newBtn = $('#Tinnhanmdl-newBtn', newDlg);
//                $(newBtn).show();

                adm.loading(null);


                adm.regType(typeof (danhbaObj), 'cnn.plugin.tinNhan.danhBa.Class1, cnn.plugin.tinNhan', function () {
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
                                    spbMsg.html('Lưu dữ liệu thành công');

                                    listUser = l + l1 + l2;
                                    listUser = listUser.replace(/,/g, ", ");
                                    $('.inline-items', dlg).html(listUser);
                                }
                                else {
                                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được vào danh bạ');
                                }
                            }
                        })

                    });

                });

            }

        });

    },
    save: function (validate, fn) {

        var newDlg = $('#Tinnhanmdl-dlgNew');
        var spbMsg = $('.admMsg', newDlg);

        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();

        var txtNguoinhan = $('.Nguoinhan', newDlg);
        var Nguoinhan = $(txtNguoinhan).val();


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

        //alert(Quantrong);

        var EmailTo = $('.Nguoinhan', newDlg);
        var EmailToDiv = $(EmailTo).parent();
        var l = '';
        $.each($(EmailToDiv).find('span'), function (i, item) {
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
            url: tinNhanObj.urlDefault + '&subAct=save',
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

    clearform: function () {
        var newDlg = $('#Tinnhanmdl-dlgNew');

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

        var txtTieuDe = $('.Tieude', newDlg);
        $(txtTieuDe).val('');

        var txtNoidung = $('.Noidung', newDlg);
        $(txtNoidung).val('');


    },
    thembc: function () {
        var newDlg = $('#Tinnhanmdl-dlgNew');
        $('#rowbc', newDlg).show();

    },
    addpopfn: function () {
        var newDlg = $('#Tinnhanmdl-dlgNew');
        var txtID = $('.ID', newDlg);


        var fileList = $('.adm-upload-fileList', newDlg);
        var fileBtn = $('.File', newDlg);
        var _params = { 'act': 'uploadfileDkLuong' }
        adm.upload(fileBtn, 'data', _params, function (rs) {
        }, function (_rs) {

        }, function (_r, _f) {
            var l = '';
            l += '<span class=\"adm-token-item-radi\"><span onclick=\"javascript:document.location.href=\'Default.aspx?act=download&ID=' + _r.replace('.', '') + '\'\">' + _f + '</span><a _value=\"' + _r.replace('.', '') + '\"  href=\"javascript:;\">x</a></span>';
            $.ajax({
                url: tinNhanObj.urlDefault,
                data: {
                    'subAct': 'saveDoc',
                    'F_ID': _r,
                    'RowID': $(txtID).attr('_value')
                },
                success: function (dt) {

                }
            });
            //alert(txtID.val());
            $(l).appendTo(fileList).find('a').click(function () {
                var _item = $(this);
                $(_item).hide();
                $.ajax({
                    url: tinNhanObj.urlDefault,
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
    addnguoinhan: function () {
        var newDlg = $('#Tinnhanmdl-dlgNew');
        var Nguoinhan = $('.Nguoinhan', newDlg);
        var NguoinhanToDiv = $(Nguoinhan).parent();
        tinNhanObj.adduser(Nguoinhan, NguoinhanToDiv);
    },
    addcc: function () {
        var newDlg = $('#Tinnhanmdl-dlgNew');
        var tinnhanCC = $('.Cc', newDlg);
        var tinnhanCCToDiv = $(tinnhanCC).parent();
        tinNhanObj.adduser(tinnhanCC, tinnhanCCToDiv);
    },
    addbc: function () {
        var newDlg = $('#Tinnhanmdl-dlgNew');
        var tinnhanBC = $('.Bc', newDlg);
        var tinnhanBCToDiv = $(tinnhanBC).parent();
        tinNhanObj.adduser(tinnhanBC, tinnhanBCToDiv);
    }
}

