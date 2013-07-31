GiaoThuongTestDanhMucFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.giaoThuong.TestDanhMuc.Class1, cnn.plugin.giaoThuong'; },
    setup: function () {

    },
    loadgrid: function () {
        adm.styleButton();
    },
    loadHtml: function (fn) {
        var dlg = $('#GiaoThuongTestDanhMucFnMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.giaoThuong.TestDanhMuc.htm.htm")%>',
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
    add: function () {
        GiaoThuongTestDanhMucFn.loadHtml(function () {
            adm.styleButton();
            var newDlg = $('#GiaoThuongTestDanhMucFnMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 750,
                height: 550,
                modal: true,
                open: function () {
                    GiaoThuongTestDanhMucFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            var _obj = $('#GiaoThuongTestDanhMucFnMdl-dlgNew');
            var danhMucSelectionList = $('.danhMucSelection-List', '#GiaoThuongTestDanhMucFnMdl-dlgNew');
            var DanhMucBox_show = $('.DanhMucBox_show', '#GiaoThuongTestDanhMucFnMdl-dlgNew');
            $('.danhMucSelection-Btn').click(function () {
                danhmuc.getSelectTionTest('SP_NHOM', danhMucSelectionList, DanhMucBox_show, _obj);
                $('.DanhMucBox_show').show();
            });
            $('.danhMucSelection-List').click(function () {
                danhmuc.getSelectTionTest('SP_NHOM', danhMucSelectionList, DanhMucBox_show, _obj);
                $('.DanhMucBox_show').show();
            });
        });
        //        danhmuc.autoCompleteLangBased('', 'RAOVAT', DM_ID, function (event, ui) {
        //            $(DM_ID).attr('_value', ui.item.id);
        //        });
        //        var _objarr = [
        //            { _value: '110', _name: 'a' },
        //            { _value: '111', _name: 'b' },
        //            { _value: '112', _name: 'c' },
        //        ]
        //        $.each(_objarr, function (i, item) {
        //            //console.log(item._name);
        //        });
    }
}

//,
//    getSelectTion: function (_obj) {
//        $.ajax({
//            url: GiaoThuongTestDanhMucFn.urlDefault().toString() + '&subAct=autoCompleteLangBased',
//            dataType: 'script',
//            data: {
//        },
//        success: function (_dt) {
//            var danhMucData = eval(_dt);
//            var obj = $(_obj);
//            var newMdl = $('#productCategoryListContainer');
//            //if ($(obj).find('span') < 1) {
//            $(newMdl).dialog({
//                title: 'Chon danh muc',
//                width: 570,
//                height: 350,
//                open: function () {
//                    var div1 = $('.danhMuc-geSelectTion-Mdl-1', newMdl);
//                    var div2 = $('.danhMuc-geSelectTion-Mdl-2', newMdl);
//                    var div3 = $('.danhMuc-geSelectTion-Mdl-3', newMdl);
//                    $(div1).show();
//                    $(div2).hide();
//                    $(div3).hide();
//                    var divbtn = $('.selectedLastInfo', newMdl);
//                    divbtn.hide();
//                    var output = $('.danhMucSelection-List', '#GiaoThuongTestDanhMucFnMdl-dlgNew');
//                    $(div1).html('');
//                    $(div2).html('');
//                    $(div3).html('');
//                    $.each(danhMucData, function (i, item) {
//                        if (item.Level == 1) {
//                            var _item = $('<div class="SubdanhMuc-geSelectTion-Mdl" _text="' + item.Ten + '" _id="' + item.ID + '">' + item.Ten + '</div>').appendTo(div1);
//                            if ($(output).find('.spanlv1').length == 1) {
//                                var slv1 = $(output).find('.spanlv1').attr('_id');
//                                $('[_id="' + slv1 + '"]', div1).addClass('SubDanhmuc-item-selected');
//                                $(divbtn).show();
//                            }
//                            _item.click(function () {
//                                divbtn.hide();
//                                $(div1).find('.SubDanhmuc-item-selected').removeClass('SubDanhmuc-item-selected');
//                                $(div2).find('.SubDanhmuc-item-selected').removeClass('SubDanhmuc-item-selected');
//                                $(div3).find('.SubDanhmuc-item-selected').removeClass('SubDanhmuc-item-selected');
//                                $(_item).addClass('SubDanhmuc-item-selected');
//                                var _pid = $(_item).attr('_id');
//                                $(div2).show();
//                                $('.SubdanhMuc-geSelectTion-Mdl', div2).hide();
//                                div3.hide();
//                                $('[_pid="' + _pid + '"]', div2).show();
//                                if ($('[_pid="' + _pid + '"]', div2).length == 0) {
//                                    div2.hide();
//                                    divbtn.show();
//                                    _item.dblclick(function () {
//                                        $(newMdl).dialog('close');
//                                        $(output).html('');
//                                        var spanidlv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_id');
//                                        var spannamelv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_text');
//                                        $('<span class="spanlv1" level="1" _id="' + spanidlv1 + '">' + spannamelv1 + '</span>').appendTo(output);
//                                    });
//                                    divbtn.click(function () {
//                                        $(newMdl).dialog('close');
//                                        $(output).html('');
//                                        var spanidlv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_id');
//                                        var spannamelv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_text');
//                                        $('<span class="spanlv1" level="1" _id="' + spanidlv1 + '">' + spannamelv1 + '</span>').appendTo(output);
//                                    });

//                                }
//                                else {
//                                    divbtn.hide();
//                                }
//                            });
//                        }
//                    });
//                    $.each(danhMucData, function (i, item) {
//                        if (item.Level == 2) {
//                            var _item = $('<div class="SubdanhMuc-geSelectTion-Mdl" style="display:none;" _text="' + item.Ten + '" _pid="' + item.PID + '" _id="' + item.ID + '">' + item.Ten + '</div>').appendTo(div2);
//                            if ($(output).find('.spanlv2').length == 1) {
//                                var slv1 = $(output).find('.spanlv1').attr('_id');
//                                $('[_id="' + slv1 + '"]', div1).addClass('SubDanhmuc-item-selected');
//                                $(div2).show();
//                                $('[_pid="' + slv1 + '"]', div2).show();
//                                var slv2 = $(output).find('.spanlv2').attr('_id');
//                                $('[_id="' + slv2 + '"]', div2).addClass('SubDanhmuc-item-selected');
//                                $(divbtn).show();
//                            }
//                            _item.click(function () {
//                                divbtn.hide();
//                                $(div2).find('.SubDanhmuc-item-selected').removeClass('SubDanhmuc-item-selected');
//                                $(div3).find('.SubDanhmuc-item-selected').removeClass('SubDanhmuc-item-selected');
//                                $(_item).addClass('SubDanhmuc-item-selected');
//                                var _pid = $(_item).attr('_id');
//                                div3.show();
//                                $('.SubdanhMuc-geSelectTion-Mdl', div3).hide();
//                                $('[_pid="' + _pid + '"]', div3).show();
//                                if ($('[_pid="' + _pid + '"]', div3).length == 0) {
//                                    div3.hide();
//                                    divbtn.show();
//                                    _item.dblclick(function () {
//                                        $(newMdl).dialog('close');
//                                        $(output).html('');
//                                        var spanidlv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_id');
//                                        var spannamelv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_text');
//                                        $('<span class="spanlv1" level="1" _id="' + spanidlv1 + '">' + spannamelv1 + '</span>').appendTo(output);
//                                        $('<span> >> </span>').appendTo(output);
//                                        var spanidlv2 = $(div2).find('.SubDanhmuc-item-selected').attr('_id');
//                                        var spannamelv2 = $(div2).find('.SubDanhmuc-item-selected').attr('_text');
//                                        $('<span class="spanlv2" level="2" _id="' + spanidlv2 + '">' + spannamelv2 + '</span>').appendTo(output);
//                                    });
//                                    divbtn.click(function () {
//                                        $(newMdl).dialog('close');
//                                        $(output).html('');
//                                        var spanidlv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_id');
//                                        var spannamelv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_text');
//                                        $('<span class="spanlv1" level="1" _id="' + spanidlv1 + '">' + spannamelv1 + '</span>').appendTo(output);
//                                        $('<span> >> </span>').appendTo(output);
//                                        var spanidlv2 = $(div2).find('.SubDanhmuc-item-selected').attr('_id');
//                                        var spannamelv2 = $(div2).find('.SubDanhmuc-item-selected').attr('_text');
//                                        $('<span class="spanlv2" level="2" _id="' + spanidlv2 + '">' + spannamelv2 + '</span>').appendTo(output);
//                                    });
//                                }
//                                else {
//                                    divbtn.hide();
//                                }
//                            });
//                        }
//                    });
//                    $.each(danhMucData, function (i, item) {
//                        if (item.Level == 3) {
//                            var _item = $('<div class="SubdanhMuc-geSelectTion-Mdl" style="display:none;" _text="' + item.Ten + '" _pid="' + item.PID + '" _id="' + item.ID + '">' + item.Ten + '</div>').appendTo(div3);
//                            if ($(output).find('.spanlv2').length == 3) {
//                                var slv1 = $(output).find('.spanlv1').attr('_id');
//                                $('[_id="' + slv1 + '"]', div1).addClass('SubDanhmuc-item-selected');
//                                $(div2).show();
//                                $('[_pid="' + slv1 + '"]', div2).show();
//                                var slv2 = $(output).find('.spanlv2').attr('_id');
//                                $('[_id="' + slv2 + '"]', div2).addClass('SubDanhmuc-item-selected');
//                                $(div3).show();
//                                $('[_pid="' + slv2 + '"]', div2).show();
//                                var slv3 = $(output).find('.spanlv3').attr('_id');
//                                $('[_id="' + slv3 + '"]', div3).addClass('SubDanhmuc-item-selected');
//                                $(divbtn).show();
//                            }
//                            _item.click(function () {
//                                divbtn.hide();
//                                $(div3).find('.SubDanhmuc-item-selected').removeClass('SubDanhmuc-item-selected');
//                                $(_item).addClass('SubDanhmuc-item-selected');
//                                divbtn.show();
//                                _item.dblclick(function () {
//                                    $(newMdl).dialog('close');
//                                    $(output).html('');
//                                    var spanidlv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_id');
//                                    var spannamelv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_text');
//                                    $('<span class="spanlv1" level="1" _id="' + spanidlv1 + '">' + spannamelv1 + '</span>').appendTo(output);
//                                    $('<span> >> </span>').appendTo(output);
//                                    var spanidlv2 = $(div2).find('.SubDanhmuc-item-selected').attr('_id');
//                                    var spannamelv2 = $(div2).find('.SubDanhmuc-item-selected').attr('_text');
//                                    $('<span class="spanlv2" level="2" _id="' + spanidlv2 + '">' + spannamelv2 + '</span>').appendTo(output);
//                                    $('<span> >> </span>').appendTo(output);
//                                    var spanidlv3 = $(div3).find('.SubDanhmuc-item-selected').attr('_id');
//                                    var spannamelv3 = $(div3).find('.SubDanhmuc-item-selected').attr('_text');
//                                    $('<span class="spanlv3" level="3" _id="' + spanidlv3 + '">' + spannamelv3 + '</span>').appendTo(output);
//                                });
//                                divbtn.click(function () {
//                                    $(newMdl).dialog('close');
//                                    $(output).html('');
//                                    var spanidlv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_id');
//                                    var spannamelv1 = $(div1).find('.SubDanhmuc-item-selected').attr('_text');
//                                    $('<span class="spanlv1" level="1" _id="' + spanidlv1 + '">' + spannamelv1 + '</span>').appendTo(output);
//                                    $('<span> >> </span>').appendTo(output);
//                                    var spanidlv2 = $(div2).find('.SubDanhmuc-item-selected').attr('_id');
//                                    var spannamelv2 = $(div2).find('.SubDanhmuc-item-selected').attr('_text');
//                                    $('<span class="spanlv2" level="2" _id="' + spanidlv2 + '">' + spannamelv2 + '</span>').appendTo(output);
//                                    $('<span> >> </span>').appendTo(output);
//                                    var spanidlv3 = $(div3).find('.SubDanhmuc-item-selected').attr('_id');
//                                    var spannamelv3 = $(div3).find('.SubDanhmuc-item-selected').attr('_text');
//                                    $('<span class="spanlv3" level="3" _id="' + spanidlv3 + '">' + spannamelv3 + '</span>').appendTo(output);
//                                });
//                            });
//                        }
//                    });
//                }
//            });
//        }
//    });
//}