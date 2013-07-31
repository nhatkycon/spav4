danhBaWebFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.danhBaWeb.quanLyDanhBaWeb.Class1, cnn.plugin.danhBaWeb'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        $('#danhBaWebMdl-List').jqGrid({
            url: danhBaWebFn.urlDefault().toString() + '&subAct=get',
            height: 'auto',
            width: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'TT', 'Tên DN', 'Địa chỉ', 'Khu vực', 'Web', 'Nổi Bật'],
            colModel: [
            { name: 'ID', key: true, sortable: true, hidden: true },
            { name: 'ThuTu', width: 30, resizable: true, sortable: true, align: "center" },
            { name: 'TenDN', width: 200, resizable: true, sortable: true, align: "left" },
            { name: 'DiaChi', width: 220, resizable: true, sortable: true, align: "left" },
            { name: 'KhuVuc', width: 80, resizable: true, sortable: true, align: "center" },
            { name: 'Web', width: 200, resizable: true, sortable: true, align: "center" },
            { name: 'WebNoiBat', width: 70, align: 'center', resizable: false, formatter: 'checkbox' },
            ],
            caption: 'DANH SÁCH WEBSITE DOANH NGHIỆP',
            multiselect: true,
            multiboxonly: true,
            sortname: 'ID',
            sortorder: 'desc',
            onSelectRow: function (rowid) {         
            },
            rowNum: 5,
            rowList: [5, 10, 15, 20, 25, 30],
            pager: jQuery('#danhBaWebMdl-Pager'),
            loadComplete: function () {
                //                adm.loading(null);
                //                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                //                    danhmuc.autocompleteSelectPidByMa("", "SP_NHOM", _filterSP, function (event, ui) {
                //                        $(_filterSP).attr('_value', ui.item.id);
                //                        danhBaWebFn.search(_get_gh,_searchText, _filterSP, _filterKV, _gridMain);
                //                    });
                //                    $(_filterSP).unbind('click').click(function () {
                //                        $(_filterSP).autocomplete('search', '');
                //                    });

                //                    danhmuc.autocompleteSelectPidByMa("", "KV_TINH", _filterKV, function (event, ui) {
                //                        $(_filterKV).attr('_value', ui.item.id);
                //                        danhBaWebFn.search();
                //                    });
                //                    $(_filterKV).unbind('click').click(function () {
                //                        $(_filterKV).autocomplete('search', '');
                //                    });
                //                });
            }
        });

    },
    ActiveNoiBat: function () {
        var s = '';
        s = jQuery('#danhBaWebMdl-List').jqGrid('getGridParam', 'selarrrow').toString();       
        if (s == '') {
            alert('Chọn mẩu tin để kích hoạt web nổi bật');
        }
        else {
            if (confirm('Bạn có muốn kích hoạt website nổi bật không?')) {
                $.ajax({
                    url: danhBaWebFn.urlDefault().toString() + '&subAct=Active',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery('#danhBaWebMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }

    },
    HuyNoiBat:function(){
        var s = '';
        s = jQuery('#danhBaWebMdl-List').jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để hủy bỏ web nổi bật');
        }
        else {
            if (confirm('Bạn có muốn hủy bỏ website nổi bật không?')) {
                $.ajax({
                    url: danhBaWebFn.urlDefault().toString() + '&subAct=HuyNoiBat',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery('#danhBaWebMdl-List').trigger('reloadGrid');
                    }
                });

            }
        }
    }
    
}