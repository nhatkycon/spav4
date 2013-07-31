UserMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.raoVatMgr.UserMgr.Class1, cnn.plugin.raoVatMgr',
    setup: function () {
    },
    loadgrid: function () {
        //adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        var DMID = $('.mdl-head-search-Raovat');
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                $('#RaoVatUserMgrmdl-List').jqGrid({
                    url: UserMgrFn.urlDefault + '&subAct=get',
                    datatype: 'json',
                    height: 'auto',
                    loadui: 'disable',
                    colNames: ['ID', 'Ảnh', 'Tiêu đề', 'Mô tả', 'Mục tin', 'Ngày đăng', 'Publish', 'Kích hoạt'],
                    colModel: [
                { name: 'RV_ID', key: true, sortable: true, hidden: true },
                { name: 'RV_Anh', width: 100, resizable: true, sortable: true, align: "center" },
                { name: 'RV_Ten', width: 120, resizable: true, sortable: true },
                { name: 'RV_MoTa', width: 100, resizable: true, sortable: true },
                { name: 'RV_DM_Ten', width: 50, sortable: true },
                { name: 'RV_NgayDang', width: 50, resizable: true, sortable: true, align: "center" },
                { name: 'RV_Publish', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                { name: 'RV_Active', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
            ],
                    caption: 'Danh sách tin',
                    autowidth: true,
                    sortname: 'RV_NgayDang',
                    sortorder: 'desc',
                    rowNum: 50,
                    rowList: [50, 100, 200, 300],
                    multiselect: true,
                    pager: jQuery('#Raovatmdl-Page'),
                    onSelectRow: function (rowid) {
                    },
                    loadComplete: function () {
                        adm.loading(null);

                    }
                });
                //
                var _today = new Date();
                var _todayDate = _today.getDate() + '/' + (_today.getMonth() + 1) + '/' + _today.getFullYear();
                var _todayDates = _today.getDate() + '/' + (_today.getMonth() + 1) + '/' + (_today.getFullYear() - 1);

                $('.mdl-head-tungay').datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true, onSelect: function (d, s) { thongketin.search(); } });
                $('.mdl-head-denngay').datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true, onSelect: function (d, s) { thongketin.search(); } });
                $('.mdl-head-tungay').val(_todayDates);
                $('.mdl-head-denngay').val(_todayDate);

                var txtthanhvien = $('.mdl-head-filterthanhvien');
                adm.watermarks(txtthanhvien, 'Lọc theo thành viên', function () {
                });
                adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
                    thanhvien.setAutocompleteCungDonVi(txtthanhvien, function (event, ui) {
                        $(txtthanhvien).val(ui.item.label);
                        $(txtthanhvien).attr('_value', ui.item.username);
                    });
                    $(txtthanhvien).unbind('click').click(function () {
                        $(txtthanhvien).autocomplete('search', '');
                    });
                });

                $(txtthanhvien).keyup(function () {
                    if ($(txtthanhvien).val() == '') {
                        $(txtthanhvien).attr('_value', '');
                        UserMgrFn.search();
                        if ($(txtthanhvien).val() == '') {
                            $(txtthanhvien).val('Lọc theo thành viên');
                        }
                    }
                });

                adm.watermark(txtthanhvien, 'Lọc theo thành viên', function () {
                    $(txtthanhvien).val('');
                    giaothuongfn.search();
                    $(txtthanhvien).val('Lọc theo thành viên');
                });

            });
        });
    },
    Countadvice: function () {
        var txtthanhvien = $('.mdl-head-filterthanhvien');
        var txttungay = $('.mdl-head-tungay');
        var txtdenngay = $('.mdl-head-denngay');
        var user = txtthanhvien.attr('_value');
        var tungay = txttungay.val();
        var denngay = txtdenngay.val();
        adm.loading('Đang lấy dữ liệu');
        $.ajax({
            url: raovatfn.urlDefault + '&subAct=get',
            dataType: 'script',
            type: 'POST',
            data: {
                'user': user,
                'tungay': tungay,
                'denngay': denngay
            },
            success: function (dt) {
                adm.loading(null);
                
            }
        });

    }
}