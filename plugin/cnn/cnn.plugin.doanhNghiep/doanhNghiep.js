doanhNghiepFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.doanhNghiep.doanhNghiep, cnn.plugin.doanhNghiep'; },
    setup: function () { },
    loadForm: function (_get_gh, _NewDlg, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh) {
        doanhNghiepFn.MainFunction(_get_gh, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _NewDlg, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh);
    },
    MainFunction: function (_get_gh, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _NewDlg, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh) {

        doanhNghiepFn.loadgrid(_get_gh, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _NewDlg, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh);
    },
    Activeform: function (_subThongtinDoanhNghiep) {
        adm.styleButton();
        var tbBox = $('.thongTinChungDoanhNghiep-box', _subThongtinDoanhNghiep);
        //        $('.thongTinChungDoanhNghiep-menu-item', tbBox).eq(0).addClass('thongTinChungDoanhNghiep-menu-item-active');
        //        $('.thongTinChungDoanhNghiep-content-box', tbBox).eq(0).addClass('thongTinChungDoanhNghiep-content-box-active');
        $('.thongTinChungDoanhNghiep-menu-item', tbBox).click(function () {
            var item = $(this);
            var _ref = item.attr('_ref');
            $('.thongTinChungDoanhNghiep-menu-item-active', tbBox).removeClass('thongTinChungDoanhNghiep-menu-item-active');
            item.addClass('thongTinChungDoanhNghiep-menu-item-active');
            $('.thongTinChungDoanhNghiep-content-box-active', tbBox).removeClass('thongTinChungDoanhNghiep-content-box-active');
            $('.thongTinChungDoanhNghiep-content-box[_ref=""' + _ref + '""]', tbBox).addClass('thongTinChungDoanhNghiep-content-box-active');
        });

    },
    loadgridChungChi: function (_grid, s, _pager) {

        $(_grid).jqGrid({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=getChungChi&CC_GH_ID=' + s,
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['Id', 'TT', 'Ảnh', 'Tên chứng chỉ', 'Số', 'Giới hạn', 'Đơn vị cấp', 'Ngày cấp', 'Active'],
            colModel: [
                    { name: 'CC_ID', key: true, sortable: true, hidden: true },
                    { name: 'CC_TT', width: 20, resizable: true, sortable: true },
                    { name: 'CC_Anh', width: 110, resizable: true, sortable: true },
                    { name: 'CC_Ten', width: 300, resizable: true, sortable: true },
                    { name: 'CC_So', width: 150, resizable: true, sortable: true },
                    { name: 'CC_GioiHan', width: 300, resizable: true, sortable: true, align: 'center' },
                    { name: 'CC_DonViCap', width: 200, resizable: true, sortable: true, align: 'center' },
                    { name: 'CC_NgayCap', width: 200, resizable: true, sortable: true, align: 'center' },
                    { name: 'CC_Active', width: 50, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                    ],
            caption: 'Chứng chỉ',
            autowidth: true,
            sortname: 'CC_ID',
            sortorder: 'desc',
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) {
            },
            rowNum: 5,
            rowList: [5, 10, 15, 20, 25, 30],
            pager: jQuery(_pager),
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    loadgridVideo: function (_grid, s, _pager) {

        $(_grid).jqGrid({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=getVideo&TV_GH_ID=' + s,
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ["ID", "Thứ tự", "Hình ảnh", "Tiêu đề", "Mô tả", "Ngày tạo", "Người tạo", "Trạng thái"],
            colModel: [
                    { name: "TV_ID", width: 20, key: true, hidden: true },
                    { name: "TV_Thutu", width: 30, resizable: false, align: 'center' },
                    { name: "TV_Anh", width: 110, resizable: false, align: 'center' },
                    { name: "TV_Ten", width: 150, resizable: false, align: 'left' },
                    { name: "TV_Mota", width: 200, resizable: false, align: 'left' },
                    { name: "TV_NgayTao", width: 60, resizable: false, align: 'center' },
                    { name: "TV_NguoiTao", width: 60, resizable: false, align: 'center' },
                    { name: "TV_Active", width: 20, align: 'center', resizable: false, formatter: 'checkbox' }
                    ],
            caption: 'Video Clip',
            autowidth: true,
            autowidth: true,
            multiselect: true,
            ExpandColClick: true,
            sortname: 'TV_Thutu',
            sortorder: 'asc',
            multiboxonly: true,

            onSelectRow: function (rowid) {
            },
            rowNum: 5,
            rowList: [5, 10, 15, 20, 25, 30],
            pager: jQuery(_pager),
            onSelectRow: function (rowid) {
            },
            beforeRequest: function () {
                adm.loading('Đang nạp');
            },
            loadError: function () {
                adm.loading('Máy chủ đang quá tải');
            },
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },

    loadgridFlash: function (_grid, s, _pager) {
        $(_grid).jqGrid({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=getFlash&Flh_GH_ID=' + s,
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ["ID", "Thứ tự", "Hình ảnh", "Tên Flash", "Ngày tạo", "Người tạo", "Trạng thái"],
            colModel: [
                    { name: "Flh_ID", width: 20, key: true, hidden: true },
                    { name: "Flh_Thutu", width: 30, resizable: false, align: 'center' },
                    { name: "Flh_Anh", width: 200, resizable: false, align: 'center' },
                    { name: "Flh_Ten", width: 150, resizable: false, align: 'left' },
                    { name: "Flh_NgayTao", width: 60, resizable: false, align: 'center' },
                    { name: "Flh_NguoiTao", width: 60, resizable: false, align: 'center' },
                    { name: "Flh_Active", width: 20, align: 'center', resizable: false, formatter: 'checkbox' },
                    ],
            caption: 'Danh sách Flash',
            autowidth: true,
            autowidth: true,
            ExpandColClick: true,
            sortname: 'Flh_Thutu',
            sortorder: 'asc',
            multiboxonly: true,

            onSelectRow: function (rowid) {
                var treedata = $('#doanhNghiepMdl-subFlashMdl-List').jqGrid('getRowData', rowid);
            },
            rowNum: 5,
            rowList: [5, 10, 15, 20, 25, 30],
            pager: jQuery(_pager),
            onSelectRow: function (rowid) {
            },
            beforeRequest: function () {
                adm.loading('Đang nạp');
            },
            loadError: function () {
                adm.loading('Máy chủ đang quá tải');
            },
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    loadgridHinhAnh: function (_grid, s, _pager) {

        $(_grid).jqGrid({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=getHinhAnh&HA_GH_ID=' + s,
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ["ID", "Hình ảnh", "Tên hình ảnh", "Link", "Ngày tạo", "Người tạo", "Trạng thái"],
            colModel: [
                    { name: "HA_ID", width: 20, key: true, hidden: true },
                    { name: "HA_Anh", width: 110, resizable: false, align: 'center' },
                    { name: "HA_Ten", width: 150, resizable: false, align: 'left' },
                    { name: "HA_Link", width: 110, resizable: false, align: 'center' },
                    { name: "HA_NgayTao", width: 60, resizable: false, align: 'center' },
                    { name: "HA_NguoiTao", width: 60, resizable: false, align: 'center' },
                    { name: "HA_Active", width: 20, align: 'center', resizable: false, formatter: 'checkbox' },
                    ],
            caption: 'Danh sách hình ảnh',
            autowidth: true,
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            ExpandColClick: true,
            sortname: 'HA_ID',
            sortorder: 'asc',
            multiboxonly: true,
            onSelectRow: function (rowid) {
                var treedata = $(_grid).jqGrid('getRowData', rowid);
            },
            rowNum: 5,
            rowList: [5, 10, 15, 20, 25, 30],
            pager: jQuery(_pager),
            beforeRequest: function () {
                adm.loading('Đang nạp');
            },
            loadError: function () {
                adm.loading('Máy chủ đang quá tải');
            },
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },

    loadgridMain: function (_get_gh, _gridMain, _pagerMain, _subMdl, _filterSP, _filterKV, _searchText, _gridChungChi, _gridHinhAnh, _gridFlash, _gridVideo, newDlgLienHe, newDlgTaiKhoan, _NewDlg, _newDlgThongTin) {

        $(_gridMain).jqGrid({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=' + _get_gh,
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'TT', 'Tên DN', 'Địa chỉ', 'Khu vực', 'Ngày ĐK', 'UserName', 'Web', 'Người liên hệ', 'Điện thoại', 'Người đại diện', 'Email', 'Điện thoại công ty'],
            colModel: [
            { name: 'ID', key: true, sortable: true, hidden: true },
            { name: 'ThuTu', width: 30, resizable: true, sortable: true, align: "center" },
            { name: 'TenDN', width: 250, resizable: true, sortable: true, align: "left" },
            { name: 'DiaChi', width: 200, resizable: true, sortable: true, align: "left" },
            { name: 'KhuVuc', width: 80, resizable: true, sortable: true, align: "center" },
            { name: 'NgayDK', width: 100, resizable: true, sortable: true, align: "center" },
            { name: 'TaiKhoan', width: 200, resizable: true, sortable: true, align: "center" },
            { name: 'Web', width: 250, resizable: true, sortable: true, align: "center" },
            //{ name: 'ThanhVien', width: 90, resizable: true, sortable: true, align: "center" },
            {name: 'NguoiLienHe', width: 130, resizable: true, sortable: true, align: "left" },
            { name: 'MobileNguoiLH', width: 130, resizable: true, sortable: true, align: "left" },
            { name: 'NguoiDaiDien', hidden: true },
            { name: 'EmailMember', hidden: true },
            { name: 'DienThoai', hidden: true },

            ],
            caption: 'DANH SÁCH THÀNH VIÊN',
            //            autowidth: true,

            multiselect: true,
            multiboxonly: true,
            sortname: 'ID',
            sortorder: 'desc',
            onSelectRow: function (rowid) {
                $(_subMdl).show('fast');
                var treedata = $(_gridMain).jqGrid('getRowData', rowid);
                doanhNghiepFn.changeSubGrid(_gridChungChi, _gridVideo, _gridFlash, _gridHinhAnh, treedata.ID);
                doanhNghiepFn.lienHeDN(treedata.EmailMember, treedata.ID, treedata.TenDN, treedata.ThanhVien, treedata.NgayDK, treedata.DiaChi, treedata.DienThoai, treedata.Web, treedata.NguoiDaiDien, newDlgLienHe);
                doanhNghiepFn.Taikhoan(treedata.TaiKhoan, treedata.ID, treedata.TenDN, treedata.ThanhVien, treedata.NgayDK, treedata.DiaChi, treedata.DienThoai, treedata.Web, treedata.NguoiDaiDien, treedata.TaiKhoan, newDlgTaiKhoan);
                doanhNghiepFn.ThongTinDoanhNghiep(_NewDlg, _gridMain, _newDlgThongTin, treedata.ID);
            },
            rowNum: 5,
            rowList: [5, 10, 15, 20, 25, 30],
            pager: jQuery(_pagerMain),
            loadComplete: function () {
                adm.loading(null);
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autocompleteSelectPidByMa("", "SP_NHOM", _filterSP, function (event, ui) {
                        $(_filterSP).attr('_value', ui.item.id);
                        doanhNghiepFn.search(_get_gh,_searchText, _filterSP, _filterKV, _gridMain);
                    });
                    $(_filterSP).unbind('click').click(function () {
                        $(_filterSP).autocomplete('search', '');
                    });

                    danhmuc.autocompleteSelectPidByMa("", "KV_TINH", _filterKV, function (event, ui) {
                        $(_filterKV).attr('_value', ui.item.id);
                        doanhNghiepFn.search(_get_gh, _searchText, _filterSP, _filterKV, _gridMain);
                    });
                    $(_filterKV).unbind('click').click(function () {
                        $(_filterKV).autocomplete('search', '');
                    });

                });
            }
        });

    },
    keyupDoanhNghiep: function (get_gh,filterSP, filterKV, searchTxt, _gridMain) {
        $(filterSP).keyup(function () {
            if ($(filterSP).val() == '') {
                $(filterSP).attr('_value', '');
                if ($(searchTxt).val() == 'Tìm kiếm doanh nghiệp') {
                    $(searchTxt).val('');
                }
                doanhNghiepFn.search(get_gh, searchText, filterSP, filterKV, _gridMain);
                if ($(searchTxt).val() == '') {
                    $(searchTxt).val('Tìm kiếm doanh nghiệp');
                }
            }
        });
        $(filterKV).keyup(function () {
            if ($(filterKV).val() == '') {
                $(filterKV).attr('_value', '');
                if ($(searchTxt).val() == 'Tìm kiếm doanh nghiệp') {
                    $(searchTxt).val('');
                }
                doanhNghiepFn.search(get_gh, searchText, filterSP, filterKV, _gridMain);
                if ($(searchTxt).val() == '') {
                    $(searchTxt).val('Tìm kiếm doanh nghiệp');
                }
            }
        });
        $(searchTxt).keyup(function () {
            doanhNghiepFn.search(get_gh, searchTxt, filterSP, filterKV, _gridMain);
        });
        adm.watermark(searchTxt, 'Tìm kiếm doanh nghiệp', function () {
            $(searchTxt).val('');
            doanhNghiepFn.search(get_gh, searchTxt, filterSP, filterKV, _gridMain);
            $(searchTxt).val('Tìm kiếm doanh nghiệp');
        });
        adm.watermark(filterSP, 'Nhóm sản phẩm', function () {
            if ($(searchTxt).val() == 'Tìm kiếm doanh nghiệp') {
                $(searchTxt).val('');
            }
            doanhNghiepFn.search(get_gh, searchText, filterSP, filterKV, _gridMain);
            if ($(searchTxt).val() == '') {
                $(searchTxt).val('Tìm kiếm doanh nghiệp');
            }
        });
        adm.watermark(filterKV, 'Khu vực', function () {
            if ($(searchTxt).val() == 'Tìm kiếm doanh nghiệp') {
                $(searchTxt).val('');
            }
            doanhNghiepFn.search(get_gh, searchText, filterSP, filterKV, _gridMain);
            if ($(searchTxt).val() == '') {
                $(searchTxt).val('Tìm kiếm doanh nghiệp');
            }
        });

    },
    loadgrid: function (_get_gh, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _NewDlg, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh) {

        $(_subMdl).hide('fast');
        adm.styleButton();
        adm.loading('Đang tải danh sách doanh nghiệp');
        var initialized = [false, false];
        console.log(_subMdl);
        $(_subMdl).tabs({ show: function (event, ui) {
            if (ui.index == 0 && !initialized[0]) {
            }
            else if (ui.index == 1 && !initialized[1]) {
            }
            else if (ui.index == 2 && !initialized[2]) {
                s = jQuery(_gridMain).jqGrid('getGridParam', 'selarrrow').toString();
                //grid Chung chi
                doanhNghiepFn.loadgridChungChi(_gridChungChi, s, _pagerChungChi);

            }
            else if (ui.index == 3 && !initialized[3]) {
                s = jQuery(_gridMain).jqGrid('getGridParam', 'selarrrow').toString();
                doanhNghiepFn.loadgridVideo(_gridVideo, s, _pagerVideo);

            }
            else if (ui.index == 4 && !initialized[4]) {
                s = jQuery(_gridMain).jqGrid('getGridParam', 'selarrrow').toString();
                //Flash
                doanhNghiepFn.loadgridFlash(_gridFlash, s, _pagerFlash);

            }
            else if (ui.index == 5 && !initialized[5]) { }
            else if (ui.index == 6 && !initialized[6]) {
                s = jQuery(_gridMain).jqGrid('getGridParam', 'selarrrow').toString();
                doanhNghiepFn.loadgridHinhAnh(_gridHinhAnh, s, _pagerHinhAnh);

            }
            initialized[ui.index] = true;
        }
        });

        doanhNghiepFn.loadgridMain(_get_gh, _gridMain, _pagerMain, _subMdl, _filterSP, _filterKV, _searchTxt, _gridChungChi, _gridHinhAnh, _gridFlash, _gridVideo, _newDlgLienHe, _newDlgTaiKhoan, _NewDlg, _newDlgThongTin);

        doanhNghiepFn.keyupDoanhNghiep(_get_gh,_filterSP, _filterKV, _searchTxt, _gridMain);
        if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }


        var addChungChi = $('#doanhNghiepMdl-subChungChiMdl-addBtn', _NewDlg);
        var editChungChi = $('#doanhNghiepMdl-subChungChiMdl-editBtn', _NewDlg);
        var delChungChi = $('#doanhNghiepMdl-subChungChiMdl-delBtn', _NewDlg);
        var activeChungChi = $('#doanhNghiepMdl-subChungChiMdl-activeBtn', _NewDlg);
        var addVideo = $('#doanhNghiepMdl-subVideoMdl-addBtn', _NewDlg);
        var editVideo = $('#doanhNghiepMdl-subVideoMdl-editBtn', _NewDlg);
        var delVideo = $('#doanhNghiepMdl-subVideoMdl-delBtn', _NewDlg);
        var activeVideo = $('#doanhNghiepMdl-subVideoMdl-activeBtn', _NewDlg);
        var stopVideo = $('#doanhNghiepMdl-subVideoMdl-StopBtn', _NewDlg);
        var addHinhAnh = $('#doanhNghiepMdl-subHinhAnhMdl-addBtn', _NewDlg);
        var editHinhAnh = $('#doanhNghiepMdl-subHinhAnhMdl-editBtn', _NewDlg);
        var delHinhAnh = $('#doanhNghiepMdl-subHinhAnhMdl-delBtn', _NewDlg);
        var activeHinhAnh = $('#doanhNghiepMdl-subHinhAnhMdl-activeBtn', _NewDlg);
        var stopHinhAnh = $('#doanhNghiepMdl-subHinhAnhMdl-StopBtn', _NewDlg);
        var addFlash = $('#doanhNghiepMdl-subFlashMdl-addBtn', _NewDlg);
        var editFlash = $('#doanhNghiepMdl-subFlashMdl-editBtn', _NewDlg);
        var delFlash = $('#doanhNghiepMdl-subFlashMdl-delBtn', _NewDlg);
        var activeFlash = $('#doanhNghiepMdl-subFlashMdl-activeBtn', _NewDlg);
        var stopFlash = $('#doanhNghiepMdl-subFlashMdl-StopBtn', _NewDlg);
        var sendLienHeBtn = $('#doanhNghiepMdl-SenLienHeBtn', _NewDlg);
        var huyLienHe = $('#doanhNghiepMdl-HuyLienHeBtn', _NewDlg);
        var InfoBusinessSave = $('.mdl-head-infoBusinessSave', _NewDlg);
        var newDlgError = $('#doanhNghiepMdl-Dialog-dlgNew', _NewDlg);
        var nhaplaithongtin = $('.mdl-head-nhapLaiThongTin', _NewDlg);

        $(addChungChi).unbind('click').click(function () { doanhNghiepFn.addChungChi(_gridMain, _gridChungChi, _NewDlg, _DlgChungChi); });
        $(editChungChi).unbind('click').click(function () { doanhNghiepFn.editChungChi(_gridMain, _gridChungChi, _NewDlg, _DlgChungChi); });
        $(delChungChi).unbind('click').click(function () { doanhNghiepFn.delChungChi(_gridChungChi); });
        $(activeChungChi).unbind('click').click(function () { doanhNghiepFn.activeChungChi(_gridChungChi); });

        $(addVideo).unbind('click').click(function () { doanhNghiepFn.addVideo(_gridMain, _gridVideo, _NewDlg, _DlgVideo); });
        $(editVideo).unbind('click').click(function () { doanhNghiepFn.editVideo(_gridMain, _gridVideo, _NewDlg, _DlgVideo); });
        $(delVideo).unbind('click').click(function () { doanhNghiepFn.delVideo(_gridVideo); });
        $(activeVideo).unbind('click').click(function () { doanhNghiepFn.duyetVideo(_gridVideo); });
        $(stopVideo).unbind('click').click(function () { doanhNghiepFn.dungVideo(_gridVideo); });


        $(addHinhAnh).unbind('click').click(function () { doanhNghiepFn.addHinhAnh(_gridMain, _gridHinhAnh, _NewDlg, _DlgHinhAnh); });
        $(editHinhAnh).unbind('click').click(function () { doanhNghiepFn.editHinhAnh(_gridMain, _gridHinhAnh, _NewDlg, _DlgHinhAnh); });
        $(delHinhAnh).unbind('click').click(function () { doanhNghiepFn.delHinhAnh(_gridHinhAnh); });
        $(activeHinhAnh).unbind('click').click(function () { doanhNghiepFn.duyetHinhAnh(_gridHinhAnh); });
        $(stopHinhAnh).unbind('click').click(function () { doanhNghiepFn.dungHinhAnh(_gridHinhAnh); });

        $(addFlash).unbind('click').click(function () { doanhNghiepFn.addFlash(_gridMain, _gridFlash, _NewDlg, _DlgFlash); });
        $(editFlash).unbind('click').click(function () { doanhNghiepFn.editFlash(_gridMain, _gridFlash, _NewDlg, _DlgFlash); });
        $(delFlash).unbind('click').click(function () { doanhNghiepFn.delFlash(_gridFlash); });
        $(activeFlash).unbind('click').click(function () { doanhNghiepFn.duyetFlash(_gridFlash); });
        $(stopFlash).unbind('click').click(function () { doanhNghiepFn.dungFlash(_gridFlash); });


        $(sendLienHeBtn).unbind('click').click(function () { doanhNghiepFn.sendLienHeDN(_NewDlg); });
        $(huyLienHe).unbind('click').click(function () { doanhNghiepFn.clearform(null, null, null, null, _NewDlg); });


        $(InfoBusinessSave).unbind('click').click(function () { doanhNghiepFn.infoBusinessSave(_newDlgThongTin, newDlgError, _gridMain); });

        $(nhaplaithongtin).unbind('click').click(function () { doanhNghiepFn.editThongTinDN(_gridMain, _newDlgThongTin); });

    },

    //bat dau thong tin doanh nghiep
    ThongTinDoanhNghiep: function (_NewDlg, _gridMain, _newDlgThongTin, gh_id) {
        doanhNghiepFn.editThongTinDN(_gridMain, _newDlgThongTin);
        doanhNghiepFn.loadcontrols(_newDlgThongTin);
        doanhNghiepFn.Activeform(_newDlgThongTin);
    },
    loadcontrols: function (newDlgThongTin) {
        var tinh = $('.TenTinh', newDlgThongTin);
        var solaodong = $('.SoLaoDong', newDlgThongTin);
        var vonphapdinh = $('.VonPhapDinh', newDlgThongTin);
        var doanhthu = $('.DoanhThuHangNam', newDlgThongTin);
        var xuatkhau = $('.TyLeXuatKhau', newDlgThongTin);
        var quymonhamay = $('.QuyMoNhaMay', newDlgThongTin);
        var socanbo = $('.SoCanBo', newDlgThongTin);
        var chitietDN = $('.ChiTietCongTy', newDlgThongTin);
        var thitruong = $('#ListThiTruongChinh', newDlgThongTin);
        var chatluong = $('#ListChungNhanChatLuong', newDlgThongTin);
        var loaiDN = $('#ListLoaiDN', newDlgThongTin)
        var spdv = $('#SPDV', newDlgThongTin);

        adm.createFck(chitietDN);
        var ulpFn = function () {
            var uploadBtn = $('#btnLogo', newDlgThongTin);
            var uploadView = $('#logo-img', newDlgThongTin);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.upload(uploadBtn, 'anh', _params, function (rs) {
                $(uploadBtn).attr('ref', rs)
                $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();
        var ulpFn1 = function () {
            var uploadBtn1 = $('#btnImgLienHe', newDlgThongTin);
            var uploadView1 = $('#ImgLienHe', newDlgThongTin);
            var _params1 = { 'oldFile': $(uploadBtn1).attr('ref') };
            adm.upload(uploadBtn1, 'anh', _params1, function (rs) {
                $(uploadBtn1).attr('ref', rs)
                $(uploadView1).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                ulpFn1();
            }, function (f) {
            });
        }
        ulpFn1();

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'KV_TINH', tinh, function (event, ui) {
                $(tinh).attr('_value', ui.item.id);
            });
            $(tinh).unbind('click').click(function () { $(tinh).autocomplete('search', ''); });

        });
        adm.watermark(tinh, 'Chọn khu vực', function () {
        });
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_LD', solaodong, function (event, ui) {
                $(solaodong).attr('_value', ui.item.id);
            });
            $(solaodong).unbind('click').click(function () { $(solaodong).autocomplete('search', ''); });

        });
        adm.watermark(solaodong, 'Chọn số lao động', function () {
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_VON', vonphapdinh, function (event, ui) {
                $(vonphapdinh).attr('_value', ui.item.id);
            });
            $(vonphapdinh).unbind('click').click(function () { $(vonphapdinh).autocomplete('search', ''); });

        });
        adm.watermark(vonphapdinh, 'Chọn vốn pháp định', function () {
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_DTHU', doanhthu, function (event, ui) {
                $(doanhthu).attr('_value', ui.item.id);
            });
            $(doanhthu).unbind('click').click(function () { $(doanhthu).autocomplete('search', ''); });

        });
        adm.watermark(doanhthu, 'Chọn doanh thu', function () {
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_XK', xuatkhau, function (event, ui) {
                $(xuatkhau).attr('_value', ui.item.id);
            });
            $(xuatkhau).unbind('click').click(function () { $(xuatkhau).autocomplete('search', ''); });

        });
        adm.watermark(xuatkhau, 'Chọn tỷ lệ xuất khẩu', function () {
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_QUYMONM', quymonhamay, function (event, ui) {
                $(quymonhamay).attr('_value', ui.item.id);
            });
            $(quymonhamay).unbind('click').click(function () { $(quymonhamay).autocomplete('search', ''); });

        });
        adm.watermark(quymonhamay, 'Chọn quy mô nhà máy', function () {
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_R&D', socanbo, function (event, ui) {
                $(socanbo).attr('_value', ui.item.id);
            });
            $(socanbo).unbind('click').click(function () { $(socanbo).autocomplete('search', ''); });

        });
        adm.watermark(socanbo, 'Chọn số cán bộ', function () {
        });
        var nam = $('.NamThanhLap', newDlgThongTin);
        var year = [];
        for (var i = 2012; i >= 1900; i--) {
            year[2012 - i] = "" + i + "";
        }
        adm.watermark(nam, 'Chọn năm', function () {
        });
        $(nam).autocomplete({ source: year, minLength: 0, delay: 0, selectFirst: true });
        $(nam).unbind('click').click(function () {
            $(nam).autocomplete({
                source: year,
                minLength: 0,
                delay: 0,
                selectFirst: true
            });
        });
        doanhNghiepFn.EmailMember(newDlgThongTin);
    },
    editThongTinDN: function (_gridMain, newDlgThongTin) {

        if ($(_gridMain).jqGrid('getGridParam', 'selrow') != null) {
            _gh_id = $(_gridMain).jqGrid('getGridParam', 'selrow').toString();
        }
        if (_gh_id == '') {
            alert('Chọn Doanh nghiệp');
            return false;
        }
        var imgLogo = $('#logo-img', newDlgThongTin);
        var lblAnhDN = $('#btnLogo', newDlgThongTin);
        var txtchitietDN = $('.ChiTietCongTy', newDlgThongTin);
        var txtwebDN = $('.Web', newDlgThongTin);
        var txttenDN = $('.TenDN', newDlgThongTin);
        var txtDiaChiDN = $('.DiaChiDN', newDlgThongTin);
        var txtDienThoaiDN = $('.DienThoaiDN', newDlgThongTin);
        var txtNguoiDaiDien = $('.NguoiDaiDien', newDlgThongTin);
        var txtChiNhanh = $('.ChiNhanhDN', newDlgThongTin);
        var txtDiaChiNhaMay = $('.DiaChiNhaMay', newDlgThongTin);
        var txtNamThanhLap = $('.NamThanhLap', newDlgThongTin);
        //combobox get to danh muc        
        var txtthitruong = $('#ListThiTruongChinh', newDlgThongTin);
        var txtchatluong = $('#ListChungNhanChatLuong', newDlgThongTin);
        var txtloaiDN = $('#ListLoaiDN', newDlgThongTin);
        var txttinh = $('.TenTinh', newDlgThongTin);
        var txtsolaodong = $('.SoLaoDong', newDlgThongTin);
        var txtvonphapdinh = $('.VonPhapDinh', newDlgThongTin);
        var txtdoanhthu = $('.DoanhThuHangNam', newDlgThongTin);
        var txtxuatkhau = $('.TyLeXuatKhau', newDlgThongTin);
        var txtquymonhamay = $('.QuyMoNhaMay', newDlgThongTin);
        var txtsocanbo = $('.SoCanBo', newDlgThongTin);
        var txtspdv = $('#SPDV', newDlgThongTin);
        var txtnam = $('.NamThanhLap', newDlgThongTin);
        //lien he
        var txtTenLienHe = $('.TenNguoiLienHe', newDlgThongTin);
        var rdoNam = $('.Nam', newDlgThongTin);
        var rdoNu = $('.Nu', newDlgThongTin);
        var txtEmailLienHe = $('.EmailLienHe', newDlgThongTin);
        var txtDienThoaiLienHe = $('.DienThoai', newDlgThongTin);
        var txtDiDongLienHe = $('.DiDong', newDlgThongTin);
        var txtChucDanhLienHe = $('.ChucDanh', newDlgThongTin);
        var txtYahooLienHe = $('.Yahoo', newDlgThongTin);
        var txtDiaChiNguoiLienHe = $('.DiaChiNguoiLienHe', newDlgThongTin);
        var imgLienHe = $('#ImgLienHe', newDlgThongTin);
        var lblImgLienHe = $('#btnImgLienHe', newDlgThongTin);

        $.ajax({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=LoadThongTinDN&ID=' + _gh_id + '',
            dataType: 'script',
            data: {},
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);
                $.each(data, function (i, item_gh) {
                    $(lblAnhDN).attr('ref', item_gh.Anh);
                    if (item_gh.Anh != '') {
                        $(imgLogo).attr('src', '../up/i/' + item_gh.Anh + '?ref=' + Math.random());
                    }
                    $(txtchitietDN).val(item_gh.MoTa);
                    $(txtwebDN).val(item_gh.Website);
                    $(txttenDN).val(item_gh.Ten);
                    $(txtDiaChiDN).val(item_gh.DiaChi);
                    $(txtDienThoaiDN).val(item_gh.DienThoai);
                    $(txtNguoiDaiDien).val(item_gh.NguoiDaiDien);
                    $(txtChiNhanh).val(item_gh.TomTat);
                    $(txtDiaChiNhaMay).val(item_gh.GioiThieu);
                    $(txtNamThanhLap).val(item_gh.NamThanhLap);
                    $(txtTenLienHe).val(item_gh.LH_Ten);
                    $(txtEmailLienHe).val(item_gh.LH_Email);
                    $(txtDienThoaiLienHe).val(item_gh.LH_Phone);
                    $(txtDiDongLienHe).val(item_gh.LH_Mobile);
                    $(txtChucDanhLienHe).val(item_gh.LH_ChucDanh);
                    $(txtYahooLienHe).val(item_gh.LH_Ym);
                    if (item_gh.LH_GioiTinh == true) {
                        $(rdoNam).attr('checked', 'checked');
                    }
                    else { $(rdoNu).attr('checked', 'checked'); }
                    $(txtDiaChiNguoiLienHe).val(item_gh.LH_DiaChi);
                    $(lblImgLienHe).attr('ref', item_gh.LH_Anh);
                    if (item_gh.LH_Anh != '') {
                        $(imgLienHe).attr('src', '../up/i/' + item_gh.LH_Anh + '?ref=' + Math.random());
                    }


                });
                $.each(data, function (i, item_Dm) {
                    if (item_Dm.ldm_Ma == 'KV_TINH') {
                        txttinh.val(item_Dm.dm_Ten);
                        txttinh.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_LD') {
                        txtsolaodong.val(item_Dm.dm_Ten);
                        txtsolaodong.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_VON') {
                        txtvonphapdinh.val(item_Dm.dm_Ten);
                        txtvonphapdinh.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_DTHU') {
                        txtdoanhthu.val(item_Dm.dm_Ten);
                        txtdoanhthu.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_XK') {
                        txtxuatkhau.val(item_Dm.dm_Ten);
                        txtxuatkhau.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_QUYMONM') {
                        txtquymonhamay.val(item_Dm.dm_Ten);
                        txtquymonhamay.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_R&D') {
                        txtsocanbo.val(item_Dm.dm_Ten);
                        txtsocanbo.attr('_value', item_Dm.dm_Id);
                    }
                })
                txtspdv.html('');
                doanhNghiepFn.ListCheckbox("SP_NHOM", txtspdv, function () {
                    $.each(data, function (i, item) {
                        if (item.ldm_Ma == 'SP_NHOM') {
                            var arrcheck = eval($(txtspdv).find('.item-checkbox')); //$('.item-checkbox', newDlg);                           
                            $.each(arrcheck, function (i, item1) {
                                if (eval($(item1).attr('value')) == item.dm_Id) {
                                    $(item1).attr('checked', 'checked');
                                }
                            });
                        }

                    });
                });
                txtthitruong.html('');
                doanhNghiepFn.ListCheckbox("TV_TTRUONG", txtthitruong, function () {
                    $.each(data, function (i, item) {
                        if (item.ldm_Ma == 'TV_TTRUONG') {
                            var arrcheck = eval($(txtthitruong).find('.item-checkbox')); //$('.item-checkbox', newDlg);                           
                            $.each(arrcheck, function (i, item1) {
                                if (eval($(item1).attr('value')) == item.dm_Id) {
                                    //$(item1).is(':checked') = true;
                                    $(item1).attr('checked', 'checked');
                                }
                            });
                        }

                    });
                });
                txtchatluong.html('');
                doanhNghiepFn.ListCheckbox("TV_ISO", txtchatluong, function () {
                    $.each(data, function (i, item) {
                        if (item.ldm_Ma == 'TV_ISO') {
                            var arrcheck = eval($(txtchatluong).find('.item-checkbox')); //$('.item-checkbox', newDlg);                      -                            
                            $.each(arrcheck, function (i, item1) {
                                if (eval($(item1).attr('value')) == item.dm_Id) {
                                    $(item1).attr('checked', 'checked');
                                }
                            });
                        }

                    });
                });
                txtloaiDN.html('');
                doanhNghiepFn.ListCheckbox("DN_LOAI", txtloaiDN, function () {
                    $.each(data, function (i, item) {
                        if (item.ldm_Ma == 'DN_LOAI') {
                            var arrcheck = eval($(txtloaiDN).find('.item-checkbox')); //$('.item-checkbox', newDlg);                      
                            $.each(arrcheck, function (i, item1) {
                                if (eval($(item1).attr('value')) == item.dm_Id) {
                                    $(item1).attr('checked', 'checked');
                                }
                            });
                        }

                    });
                });

            }
        });
    },
    infoBusinessSave: function (newDlgThongTin, newDlgError, _gridMain) {
        var dialog = $('#dialog', newDlgError);
        //gioi thieu chung, thong tin co ban
        var lblLogo = $('.AnhLogo', newDlgThongTin);
        var logo = $(lblLogo).attr('ref');
        var txtchitietDN = $('.ChiTietCongTy', newDlgThongTin);
        var mota = $(txtchitietDN).val();
        var txtwebDN = $('.Web', newDlgThongTin);
        var web = $(txtwebDN).val();
        var txttenDN = $('.TenDN', newDlgThongTin);
        var tenDN = $(txttenDN).val();
        var txtDiaChiDN = $('.DiaChiDN', newDlgThongTin);
        var diachiDN = $(txtDiaChiDN).val();
        var txtDienThoaiDN = $('.DienThoaiDN', newDlgThongTin);
        var dienthoaiDN = $(txtDienThoaiDN).val();
        var txtNguoiDaiDien = $('.NguoiDaiDien', newDlgThongTin);
        var nguoiDaiDien = $(txtNguoiDaiDien).val();
        var txtChiNhanh = $('.ChiNhanhDN', newDlgThongTin);
        var chinhanh = $(txtChiNhanh).val();
        var txtDiaChiNhaMay = $('.DiaChiNhaMay', newDlgThongTin);
        var diaChiNhaMay = $(txtDiaChiNhaMay).val();
        //Nguoi lien he
        var txtTenLienHe = $('.TenNguoiLienHe', newDlgThongTin);
        var tenLienHe = $(txtTenLienHe).val();
        var rdoNam = $('.Nam', newDlgThongTin);
        var rdoNu = $('.Nu', newDlgThongTin);
        var Nam = $(rdoNam).is(':checked');
        var Nu = $(rdoNu).is(':checked');
        var gioiTinh = '';
        if (Nam == true) { gioiTinh = 'Nam'; }
        else { gioiTinh = 'Nữ'; }
        var txtEmailLienHe = $('.EmailLienHe', newDlgThongTin);
        var emailLienHe = $(txtEmailLienHe).val();
        var txtDienThoai = $('.DienThoai', newDlgThongTin);
        var dienThoai = $(txtDienThoai).val();
        var txtDiDong = $('.DiDong', newDlgThongTin);
        var diDong = $(txtDiDong).val();
        var txtChucDanh = $('.ChucDanh', newDlgThongTin);
        var chucDanh = $(txtChucDanh).val();
        var txtYahoo = $('.Yahoo', newDlgThongTin);
        var yahoo = $(txtYahoo).val();
        var txtDiaChiNguoiLienHe = $('.DiaChiNguoiLienHe', newDlgThongTin);
        var diaChiLH = $(txtDiaChiNguoiLienHe).val();
        var lblImg = $('#btnImgLienHe', newDlgThongTin);
        var imgLH = $(lblImg).attr('ref');
        //combobox, checkbox.(DanhMuc)
        var txtNamThanhLap = $('.NamThanhLap', newDlgThongTin);
        var namThanhLap = $(txtNamThanhLap).val();
        var txttinh = $('.TenTinh', newDlgThongTin);
        var tinh = $(txttinh).attr('_value');
        if ($(txttinh).val() == 'Chọn khu vực') {
            tinh = 'Chọn khu vực';
        }
        var txtvonphapdinh = $('.VonPhapDinh', newDlgThongTin);
        var vonphapdinh = $(txtvonphapdinh).attr('_value');
        if ($(txtvonphapdinh).val() == 'Chọn vốn pháp định') {
            vonphapdinh = 0;
        }
        var txtsolaodong = $('.SoLaoDong', newDlgThongTin);
        var solaodong = $(txtsolaodong).attr('_value');
        if ($(txtsolaodong).val() == 'Chọn số lao động') {
            solaodong = 0;
        }
        var txtdoanhthu = $('.DoanhThuHangNam', newDlgThongTin);
        var doanhthu = $(txtdoanhthu).attr('_value');
        if ($(txtdoanhthu).val() == 'Chọn doanh thu') {
            doanhthu = 0;
        }
        var txtxuatkhau = $('.TyLeXuatKhau', newDlgThongTin);
        var xuatkhau = $(txtxuatkhau).attr('_value');
        if ($(txtxuatkhau).val() == 'Chọn tỷ lệ xuất khẩu') {
            xuatkhau = 0;
        }
        var txtquymonhamay = $('.QuyMoNhaMay', newDlgThongTin);
        var quymonhamay = $(txtquymonhamay).attr('_value');
        if ($(txtquymonhamay).val() == 'Chọn quy mô nhà máy') {
            quymonhamay = 0;
        }
        var txtsocanbo = $('.SoCanBo', newDlgThongTin);
        var socanbo = $(txtsocanbo).attr('_value');
        if ($(txtsocanbo).val() == 'Chọn số cán bộ') {
            socanbo = 0;
        }
        var txtthitruong = $('#ListThiTruongChinh', newDlgThongTin);
        var txtchatluong = $('#ListChungNhanChatLuong', newDlgThongTin);
        var txtloaiDN = $('#ListLoaiDN', newDlgThongTin);
        var txtsanpham = $('#SPDV', newDlgThongTin);
        var resanpham = doanhNghiepFn.Duyetcheckbox(txtsanpham);
        var rethitruong = doanhNghiepFn.Duyetcheckbox(txtthitruong);
        var rechatluong = doanhNghiepFn.Duyetcheckbox(txtchatluong);
        var reloaiDN = doanhNghiepFn.Duyetcheckbox(txtloaiDN);
        var thitruong = rethitruong.substring(0, rethitruong.length - 1);
        var chatluong = rechatluong.substring(0, rechatluong.length - 1);
        var loaiDN = reloaiDN.substring(0, reloaiDN.length - 1);
        var spdv = resanpham.substring(0, resanpham.length - 1);
        var _gh_id = '';
        if ($(_gridMain).jqGrid('getGridParam', 'selrow') != null) {
            _gh_id = $(_gridMain).jqGrid('getGridParam', 'selrow').toString();
        }
        if (_gh_id == '') {
            alert('Chọn Doanh nghiệp');
            return false;
        }
        var err = '';
        if (tenDN == '') {
            err += '* Nhập tên công ty. <br/>';
        }
        if (diachiDN == '') {
            err += '* Nhập địa chỉ công ty. <br/>';
        }
        if (dienthoaiDN == '') {
            err += '* Nhập điện thoại công ty.<br/> ';
        }
        if (doanhNghiepFn.valiNumberPhone(dienthoaiDN) == false || doanhNghiepFn.valiNumberPhone(dienThoai) == false || doanhNghiepFn.valiNumberPhone(diDong) == false) {
            err += '* Điện thoại chỉ nhập sô.<br/>';
        }
        if (doanhNghiepFn.valiEmail(emailLienHe) == false & emailLienHe != '') {
            err += '* Nhập sai định dạng email.<br/>';
        }
        if (tinh == 'Chọn khu vực') {
            err += '* Chọn Tỉnh/Thành phố.<br/> ';
        }
        if (loaiDN == '') {
            err += '* Chọn loại hình công ty.<br/> '
        }
        if (spdv == '') {
            err += '* Chọn sản phẩm/Dịch vụ.<br/>';
        }
        if (tenLienHe == '') {
            err += '* Nhập tên người liên hệ.<br/>';
        }
        if (dienThoai == '') {
            err += '* Nhập điện thoại của người liên hệ.<br/>';
        }

        if (err != '') {
            $(dialog).html(err);
            $(newDlgError).dialog({
                title: 'Lỗi nhập dữ liệu',
                width: 230,
                buttons: {
                    'OK': function () {
                        $(newDlgError).dialog('close');
                    }
                }
            });
            return false;
        }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=infoBusinessSave',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _gh_id,
                'SoCanBo': socanbo,
                'QuyMoNhaMay': quymonhamay,
                'TyLeXuatKhau': xuatkhau,
                'DoanhThuHangNam': doanhthu,
                'SoLaoDong': solaodong,
                'VonPhapDinh': vonphapdinh,
                'TINH_ID': tinh,
                'NamThanhLap': namThanhLap,
                'ImageLienHe': imgLH,
                'DiaChiNguoiLienHe': diaChiLH,
                'Yahoo': yahoo,
                'ChucDanh': chucDanh,
                'DiDong': diDong,
                'DienThoai': dienThoai,
                'EmailLienHe': emailLienHe,
                'GioiTinh': gioiTinh,
                'TenNguoiLienHe': tenLienHe,
                'GioiThieu': diaChiNhaMay,
                'TomTat': chinhanh,
                'NguoiDaiDien': nguoiDaiDien,
                'DiaChi': diachiDN,
                'Ten': tenDN,
                'DienthoaiDN': dienthoaiDN,
                'Website': web,
                'MoTa': mota,
                'Anh': logo,
                'SPDV': spdv,
                'ThiTruong': thitruong,
                'ChatLuong': chatluong,
                'LoaiDN': loaiDN
            },
            success: function (dt) {
                adm.loading(null);
                $(_gridMain).jqGrid('setGridParam', { url: doanhNghiepFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
                alert('Thông tin doanh nghiệp đã được lưu');
            }
        });
    },
    EmailMember: function (newDlgThongTin) {
        $.ajax({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=EmailMember',
            dataType: 'script',
            success: function (dt) {
                adm.loading(null);
                var data = eval('(' + dt + ')');
                //var newDlg = $('#doanhNghiepMdl-subThongTinDoanhNghiepMdl');
                var txtEmail = $('.Email', newDlgThongTin);
                $(txtEmail).html(data.Email);
            }
        });
    },
    //List Checkbox
    ListCheckbox: function (ldm_ma, el, fn) {
        $.ajax({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=loadDM',
            dataType: 'script',
            data: {
                'LDM_Ma': ldm_ma
            },
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);
                $.each(data, function (i, item) {
                    el.append('<li><input class="item-checkbox" type="checkbox" name="' + item.ID + '" value="' + item.ID + '"/><label  style="width:25%" for="mainMarketsItem1">' + item.Ten + '</label></li>');
                });

                if (typeof (fn) == 'function') { fn(); }
            }

        });
    },
    Duyetcheckbox: function (_newDlg) {
        var newDlg = $(_newDlg);
        var arrcheck = eval($(newDlg).find('.item-checkbox')); //$('.item-checkbox', newDlg);                          
        var arrdm_id = '';
        $.each(arrcheck, function (i, item) {
            if (eval($(item).is(':checked')) == true) {
                arrdm_id = arrdm_id + $(item).attr('value') + ',';
            }
        });
        return arrdm_id;
    },
    ///Ket thuc thong tin doanh nghiep
    sendLienHeDN: function (_NewDlg) {
        newDlgLienHe = ('#doanhNghiepMdl-subLienHeDoanhNghiepMdl', _NewDlg)
        var txtEmail = $('.txtEmail', newDlgLienHe)
        var email = $(txtEmail).val();
        var txtNoiDung = $('.txtNoiDung', newDlgLienHe)
        var noidung = $(txtNoiDung).val();
        var txtID = $('.txtID', newDlgLienHe);
        var id = $(txtID).val();
        adm.loading('Đang gửi liên hệ');
        $.ajax({
            url: doanhnghiepChuaDuyetfn.urlDefault().toString() + '&subAct=lienHeDN',
            dataType: 'script',
            data: {
                'ID': id,
                'Email': email,
                'NoiDungLienHeDN': noidung
            },
            success: function (dt) {
                adm.loading(null);
            }

        })
        doanhnghiepChuaDuyetfn.clearform(newDlgLienHe);
    },
    RePass: function () {
        var txtEmail = $('.txtEmail', '#doanhNghiepMdl-subThongTinTKMdl')
        var email = $(txtEmail).val();
        var txtNoiDung = $('.txtNoiDung', '#doanhNghiepMdl-subThongTinTKMdl')
        var noidung = $(txtNoiDung).val();
        var txtPass = $('.txtMatKhau', '#doanhNghiepMdl-subThongTinTKMdl')
        var pass = $(txtPass).val()
        var txtID = $('.txtID', '#doanhNghiepMdl-subThongTinTKMdl')
        var id = $(txtID).val();
        adm.loading('Đang cấp lại mật khẩu');
        $.ajax({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=Repass',
            dataType: 'script',
            data: {
                'ID': id,
                'Email': email,
                'RePass': pass
            },
            success: function (dt) {
                adm.loading(null);
            }

        })
        doanhNghiepFn.clearform();
    },
    lienHeDN: function (email, id, ten, ltv, ngaydk, diachi, dienthoai, web, nguoidaidien, newDlg) {
        var txtTen = $('.Ten', newDlg);
        $(txtTen).html(ten);
        var txtLTV = $('.LTV', newDlg);
        $(txtLTV).html(ltv);
        var txtDiaChi = $('.DiaChi', newDlg);
        $(txtDiaChi).html(diachi);
        var txtNgayDK = $('.NgayDK', newDlg);
        $(txtNgayDK).html(ngaydk);
        var txtDienThoai = $('.DienThoai', newDlg);
        $(txtDienThoai).html(dienthoai);
        var txtWeb = $('.Website', newDlg);
        $(txtWeb).html(web);
        var txtNguoiDaiDien = $('.NguoiDaiDien', newDlg);
        $(txtNguoiDaiDien).html(nguoidaidien);
        var txtEmail = $('.txtEmail', newDlg);
        $(txtEmail).val(email);
        var txtID = $('.txtID', newDlg);
        $(txtID).val(id);

    },
    Taikhoan: function (email, id, ten, ltv, ngaydk, diachi, dienthoai, web, nguoidaidien, username, newDlg) {
        var txtTen = $('.Ten', newDlg);
        $(txtTen).html(ten);
        var txtLTV = $('.LTV', newDlg);
        $(txtLTV).html(ltv);
        var txtDiaChi = $('.DiaChi', newDlg);
        $(txtDiaChi).html(diachi);
        var txtNgayDK = $('.NgayDK', newDlg);
        $(txtNgayDK).html(ngaydk);
        var txtDienThoai = $('.DienThoai', newDlg);
        $(txtDienThoai).html(dienthoai);
        var txtWeb = $('.Website', newDlg);
        $(txtWeb).html(web);
        var txtNguoiDaiDien = $('.NguoiDaiDien', newDlg);
        $(txtNguoiDaiDien).html(nguoidaidien);
        var txtEmail = $('.txtEmail', newDlg);
        $(txtEmail).html(email);
        var txtTenDangNhap = $('.txtTenDangNhap', newDlg);
        $(txtTenDangNhap).html(username);
        var txtID = $('.txtID', newDlg);
        $(txtID).val(id);
    },
changeSubGrid: function (_gridChungChi, _gridVideo, _gridFlash, _gridHinhAnh, id) {
    $(_gridChungChi).jqGrid('setGridParam', { url: doanhNghiepFn.urlDefault().toString() + '&subAct=getChungChi&CC_GH_ID=' + id }).trigger('reloadGrid');
    $(_gridVideo).jqGrid('setGridParam', { url: doanhNghiepFn.urlDefault().toString() + '&subAct=getVideo&TV_GH_ID=' + id }).trigger('reloadGrid');
    $(_gridFlash).jqGrid('setGridParam', { url: doanhNghiepFn.urlDefault().toString() + '&subAct=getFlash&Flh_GH_ID=' + id }).trigger('reloadGrid');
    $(_gridHinhAnh).jqGrid('setGridParam', { url: doanhNghiepFn.urlDefault().toString() + '&subAct=getHinhAnh&HA_GH_ID=' + id }).trigger('reloadGrid');
},

    clearform: function (_popUpChungChi, _popUpVideo, _popFlash, _popHinhAnh, _NewDlg) {

        var newDlgLienHe = $('#doanhNghiepMdl-subLienHeDoanhNghiepMdl', _NewDlg);
        var txtNoiDung = $('.txtNoiDung', newDlgLienHe)
        $(txtNoiDung).val('');
        var txtTT = $('.TTChungChi', _popUpChungChi);
        $(txtTT).val('');
        var imgAnh = $('.adm-upload-preview-img-size', _popUpChungChi);
        var lblAnh = $('.AnhChungChi', _popUpChungChi);
        imgAnh.attr('src', '');
        lblAnh.attr('ref', '');
        var txtTen = $('.TenChungChi', _popUpChungChi);
        $(txtTen).val('');
        var txtSo = $('.SoChungChi', _popUpChungChi);
        $(txtSo).val('');
        var txtGioiHan = $('.GioiHanChungChi', _popUpChungChi);
        $(txtGioiHan).val('');
        var txtDonViCap = $('.DonViCapChungChi', _popUpChungChi);
        $(txtDonViCap).val('');
        var txtNgayCap = $('.NgayCapChungChi', _popUpChungChi);
        $(txtNgayCap).val('');
        var ckbActive = $('.ActiveChungChi', _popUpChungChi);
        $(ckbActive).removeAttr('checked');


        var txtID = $('.IDVideo', _popUpVideo);
        //  var txtPID = $('.PID', newDlg);
        var txtTen = $('.TenVideo', _popUpVideo);
        var txtThutu = $('.TTVideo', _popUpVideo);
        var txtMoTa = $('.MotaVideo', _popUpVideo);
        var chkDuyet = $('.ActiveVideo', _popUpVideo);
        var spInfo = $('.admInfoVideo', _popUpVideo);
        var spbMsg = $('.admMsgVideo', _popUpVideo);
        var imgAnh = $('.adm-upload-preview-img-size', _popUpVideo);
        var lblAnh = $('.AnhVideo', _popUpVideo);
        var hdClip = $('#clip', _popUpVideo);
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



        var txtID = $('.IDFlash', _popFlash);

        var txtTen = $('.TenFlash', _popFlash);
        var txtThutu = $('.ThutuFlash', _popFlash);
        var txtMoTa = $('.MotaFlash', _popFlash);
        var chkDuyet = $('.DuyetFlash', _popFlash);
        var spInfo = $('.admInfoFlash', _popFlash);
        var spbMsg = $('.admMsgFlash', _popFlash);
        var uploadImg = $('.adm-upload-preview-img-flash', _popFlash);
        var uploadBanner = $('.adm-upload-preview-img-banner', _popFlash);
        var lblAnh = $('.AnhFlash', _popFlash);
        $(uploadImg).remove();
        $(uploadBanner).remove();

        $(txtID).val('');
        $(txtThutu).val('');
        $(txtTen).val('');
        $(txtMoTa).val('');
        $(chkDuyet).removeAttr('checked');
        $(spbMsg).html('');
        $(spInfo).html('');

        var txtID = $('.IDHinhAnh', _popHinhAnh);
        //  var txtPID = $('.PID', newDlg);
        var txtTen = $('.TenHinhAnh', _popHinhAnh);
        var txtLink = $('.LinkHinhAnh', _popHinhAnh);
        var txtMoTa = $('.MotaHinhAnh', _popHinhAnh);
        var chkDuyet = $('.DuyetHinhAnh', _popHinhAnh);
        var spInfo = $('.admInfoHinhAnh', _popHinhAnh);
        var spbMsg = $('.admMsgHinhAnh', _popHinhAnh);
        var imgAnh = $('.adm-upload-preview-img-size', _popHinhAnh);
        var lblAnh = $('.AnhHinhAnh', _popHinhAnh);
        $(imgAnh).attr('src', '');
        $(lblAnh).attr('ref', '');
        $(txtID).val('');
        $(txtLink).val('');
        $(txtTen).val('');
        $(txtMoTa).val('');
        $(chkDuyet).removeAttr('checked');
        $(spbMsg).html('');
        $(spInfo).html('');


    },
    // doanhNghiepFn.search(_searchText, _filterSP, _filterKV, _gridMain);
    search: function (get_gh,searchText, searchDM, searchTINH, _gridMain) {
        var timerSearch;
        //        var searchText = $('.mdl-head-search-doanhNghiepMdl');       
        //        var searchDM = $('.mdl-head-filterNhomSP');
        //        var searchTINH = $('.mdl-head-filterKhuVuc');
        var q = searchText.val();
        if (q == 'Tìm kiếm doanh nghiệp') {
            q = '';
        }

        var dm = $(searchDM).attr('_value');
        var tinh = $(searchTINH).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(_gridMain).jqGrid('setGridParam', { url: doanhNghiepFn.urlDefault().toString() + '&subAct=' + get_gh + '&NhomDN_ID=' + dm + '&TINH_ID=' + tinh + '&q=' + q }).trigger('reloadGrid');
        }, 500);
    },
    xacnhan: function (_gridMain) {
        var s = '';
        s = jQuery(_gridMain).jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để xác nhận');
        }
        else {
            if (confirm('Bạn có muốn xác nhận doanh nghiệp đã chọn không?')) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=xacnhan',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(_gridMain).trigger('reloadGrid');
                    }
                });

            }
        }
    },
    boxacnhan: function (_gridMain) {
        var s = '';
        s = jQuery(_gridMain).jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để duyệt lại');
        }
        else {
            if (confirm('Bạn có muốn duyệt lại doanh nghiệp đã chọn không?')) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=boxacnhan',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(_gridMain).trigger('reloadGrid');
                    }
                });

            }
        }
    },


    ActiveTVBK: function (_gridMain) {
        var s = '';
        s = jQuery(_gridMain).jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để dừng');
        }
        else {
            if (confirm('Bạn có muốn Active doanh nghiệp đã chọn không?')) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=ActiveTVBK',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(_gridMain).trigger('reloadGrid');
                    }
                });

            }
        }
    },

    Active: function (_gridMain) {
        var s = '';
        s = jQuery(_gridMain).jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để dừng');
        }
        else {
            if (confirm('Bạn có muốn Khóa doanh nghiệp đã chọn không?')) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=Active',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(_gridMain).trigger('reloadGrid');
                    }
                });

            }
        }
    },

    del: function (_gridMain) {
        var s = '';
        s = jQuery(_gridMain).jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa?')) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=del',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(_gridMain).trigger('reloadGrid');
                    }
                });

            }
        }
    },


    addChungChi: function (_gridMain, _gridChungChi, _NewDlg, _DlgChungChi) {
        var _popUpChungChi = $('#doanhNghiep-ChungChiMdl-dlgNew');
        doanhNghiepFn.loadHtml(_DlgChungChi, _popUpChungChi, '<%=WebResource("cnn.plugin.doanhNghiep.ChungChi.htm")%>', function () {
            var _popUpChungChi = $('#doanhNghiep-ChungChiMdl-dlgNew');
            $(_popUpChungChi).dialog({
                title: 'Thêm mới',
                width: 500,
                height: 'auto',
                modal: true,
                buttons: {
                    'Lưu': function () {
                        doanhNghiepFn.saveChungChi(_NewDlg, _popUpChungChi, _gridMain, _gridChungChi, false, function () {
                            doanhNghiepFn.clearform(_popUpChungChi, null, null, null, _NewDlg);
                            jQuery(_gridChungChi).trigger('reloadGrid');
                        });
                    },
                    'Lưu và đóng': function () {
                        doanhNghiepFn.saveChungChi(_NewDlg, _popUpChungChi, _gridMain, _gridChungChi, false, function () {
                            $(_popUpChungChi).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(_popUpChungChi).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    doanhNghiepFn.popfn(_popUpChungChi, null);
                    doanhNghiepFn.clearform(_DlgChungChi, null, null, null, _NewDlg);

                }
            });
        });
    },
    editChungChi: function (_gridMain, _gridChungChi, _NewDlg, _NewDlgChungChi) {
        var s = '';
        if (jQuery(_gridChungChi).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(_gridChungChi).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Hãy chọn chứng chỉ để sửa.')
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Hãy chọn chứng chỉ để sửa.');
            }
            else {
                var _popUpChungChi = $('#doanhNghiep-ChungChiMdl-dlgNew');
                doanhNghiepFn.loadHtml(_NewDlgChungChi, _popUpChungChi, '<%=WebResource("cnn.plugin.doanhNghiep.ChungChi.htm")%>', function () {
                    var _popUpChungChi = $('#doanhNghiep-ChungChiMdl-dlgNew');
                    $(_popUpChungChi).dialog({
                        title: 'Sửa',
                        width: 500,
                        height: 'auto',
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                doanhNghiepFn.saveChungChi(_NewDlg, _popUpChungChi, _gridMain, _gridChungChi, false, function () {
                                    jQuery(_gridChungChi).trigger('reloadGrid');
                                });
                            },
                            'Lưu và đóng': function () {
                                doanhNghiepFn.saveChungChi(_NewDlg, _popUpChungChi, _gridMain, _gridChungChi, false, function () {
                                    $(_popUpChungChi).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(_popUpChungChi).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            doanhNghiepFn.popfn(_popUpChungChi, null);
                            $.ajax({
                                url: doanhNghiepFn.urlDefault().toString() + '&subAct=editChungChi',
                                dataType: 'script',
                                data: {
                                    'CC_ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var txtID = $('.IDChungChi', _popUpChungChi);
                                    $(txtID).val(dt.ID);

                                    var txtTen = $('.TenChungChi', _popUpChungChi);
                                    $(txtTen).val(dt.Ten);
                                    var txtTT = $('.TTChungChi', _popUpChungChi);
                                    $(txtTT).val(dt.TT);
                                    var txtGioiHan = $('.GioiHanChungChi', _popUpChungChi);
                                    $(txtGioiHan).val(dt.GioiHan);
                                    var txtSo = $('.SoChungChi', _popUpChungChi);
                                    $(txtSo).val(dt.So);
                                    var txtDonViCap = $('.DonViCapChungChi', _popUpChungChi);
                                    $(txtDonViCap).val(dt.DonViCap);
                                    var txtNgayCap = $('.NgayCapChungChi', _popUpChungChi);
                                    var ngaycap = new Date(dt.NgayCap);
                                    var _ngaycap = ngaycap.getDate() + '/' + (ngaycap.getMonth() + 1) + '/' + ngaycap.getFullYear();
                                    $(txtNgayCap).val(_ngaycap);
                                    var imgAnh = $('.adm-upload-preview-img-size', _popUpChungChi);
                                    var lblAnh = $('.AnhChungChi', _popUpChungChi);
                                    $(lblAnh).attr('ref', dt.Anh);
                                    if (dt.Anh != '') {
                                        $(imgAnh).attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());
                                    }
                                    var ckbActive = $('.ActiveChungChi', _popUpChungChi);
                                    if (dt.Active) {

                                        $(ckbActive).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbActive).removeAttr('checked');
                                    }

                                    var spInfo = $('.admInfoChungChi', _popUpChungChi);
                                    var spbMsg = $('.admMsgChungChi', _popUpChungChi);
                                    $(spbMsg).html('');

                                }
                            });
                        }
                    });
                });
            }

        }
    },
    delChungChi: function (_gridChungChi) {
        var s = '';
        s = jQuery(_gridChungChi).jqGrid('getGridParam', 'selarrrow').toString();

        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa?')) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=delChungChi',
                    dataType: 'script',
                    data: { 'CC_ID': s },
                    success: function (dt) {
                        jQuery(_gridChungChi).trigger('reloadGrid');
                    }
                });

            }
        }
    },
    activeChungChi: function (_gridChungChi) {
        var s = '';
        s = jQuery(_gridChungChi).jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn chứng chỉ để active ');
        }
        else {
            if (confirm('Bạn có muốn active chứng chỉ đã chọn không?')) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=ActiveChungChi',
                    dataType: 'script',
                    data: { 'CC_ID': s },
                    success: function (dt) {
                        jQuery(_gridChungChi).trigger('reloadGrid');
                    }
                });

            }
        }
    },
    saveChungChi: function (_NewDlg, _popUpChungChi, _gridMain, _gridChungChi, validate, fn) {

        var txtID = $('.IDChungChi', _popUpChungChi);
        var _id = $(txtID).val();
        var txtTT = $('.TTChungChi', _popUpChungChi);
        var _thutu = $(txtTT).val();
        var imgAnh = $('.adm-upload-preview-img-size', _popUpChungChi);
        var txtAnh = $('.AnhChungChi', _popUpChungChi);
        var _anh = txtAnh.attr('ref');
        var txtTen = $('.TenChungChi', _popUpChungChi);
        var _ten = $(txtTen).val();
        var _cc_gh_id = '';
        if ($(_gridMain).jqGrid('getGridParam', 'selrow') != null) {
            _cc_gh_id = $(_gridMain).jqGrid('getGridParam', 'selrow').toString();
        }
        if (_cc_gh_id == '') {
            alert('Chọn Doanh nghiệp');
            return false;
        }

        var txtSo = $('.SoChungChi', _popUpChungChi);
        var _so = $(txtSo).val();
        var txtGioiHan = $('.GioiHanChungChi', _popUpChungChi);
        var _gioihan = $(txtGioiHan).val();
        var txtDonViCap = $('.DonViCapChungChi', _popUpChungChi);
        var _donvicap = $(txtDonViCap).val();

        var txtNgayCap = $('.NgayCapChungChi', _popUpChungChi);
        var _ngaycap = $(txtNgayCap).val();
        var ckbActive = $('.ActiveChungChi', _popUpChungChi);
        var _active = $(ckbActive).is(':checked');
        var spbMsg = $('.admMsgChungChi', _popUpChungChi);
        var err = '';
        if (_ten == '')
            err += 'Nhập Tên <br/>';
        if (err != '') {
            spbMsg.html(err);
            return false;
        }
        if (validate) {
            if (typeof (fn) == 'function') {
                fn();
            }
            return false;
        }

        adm.loading('Đang lưu dữ liệu')
        doanhNghiepFn.clearform(_NewDlg);
        $.ajax({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=saveChungChi',
            dataType: 'script',
            data: {
                'CC_ID': _id,
                'CC_GH_ID': _cc_gh_id,
                'CC_TT': _thutu,
                'CC_Anh': _anh,
                'CC_Ten': _ten,
                'CC_So': _so,
                'CC_GioiHan': _gioihan,
                'CC_DonViCap': _donvicap,
                'CC_NgayCap': _ngaycap,
                'CC_DonViCap': _donvicap,
                'CC_Active': _active
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    jQuery(_gridChungChi).trigger('reloadGrid');
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
                else {

                    adm.loading('Lỗi nhập dữ liệu')
                }
            }
        })
    },
    addVideo: function (_gridMain, _gridVideo, _NewDlg, _DlgVideo) {
        var _popUpVideo = $('#doanhNghiep-VideoMdl-dlgNew');
        doanhNghiepFn.loadHtml(_DlgVideo, _popUpVideo, '<%=WebResource("cnn.plugin.doanhNghiep.Video.htm")%>', function () {
            var _popUpVideo = $('#doanhNghiep-VideoMdl-dlgNew');
            $(_popUpVideo).dialog({
                title: 'Thêm mới',
                modal: true,
                width: 500,
                height: 350,
                buttons: {
                    'Lưu': function () {
                        doanhNghiepFn.saveVideo(_NewDlg, _popUpVideo, _gridMain, _gridVideo);
                        doanhNghiepFn.clearform(null, _popUpVideo, null, null, _NewDlg);
                        jQuery(_gridVideo).trigger('reloadGrid');
                    },
                    'Lưu và đóng': function () {
                        doanhNghiepFn.saveVideo(_NewDlg, _popUpVideo, _gridMain, _gridVideo);
                        jQuery(_gridVideo).trigger('reloadGrid');
                        $(_popUpVideo).dialog('close');
                    },
                    'Đóng': function () {
                        $(_popUpVideo).dialog('close');
                    }
                },
                open: function () {
                    doanhNghiepFn.popfn(null, _popUpVideo);
                    doanhNghiepFn.clearform(null, _popUpVideo, null, null, _NewDlg);
                    adm.styleButton();
                    var ulpFn = function () {
                        var uploadBtn = $('.adm-upload-btn', _popUpVideo);
                        var fclip = $('#clip', _popUpVideo);
                        var uploadView = $('.adm-upload-preview-img-size', _popUpVideo);
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
        });
    },
    editVideo: function (_gridMain, _gridVideo, _NewDlg, _DlgVideo) {
        var s = '';
        if (jQuery(_gridVideo).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(_gridVideo).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn Video để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một Video');
            }
            else {

                var _popUpVideo = $('#doanhNghiep-VideoMdl-dlgNew');
                doanhNghiepFn.loadHtml(_DlgVideo, _popUpVideo, '<%=WebResource("cnn.plugin.doanhNghiep.Video.htm")%>', function () {
                    var _popUpVideo = $('#doanhNghiep-VideoMdl-dlgNew');

                    $(_popUpVideo).dialog({
                        title: 'Sửa',
                        modal: true,
                        width: 500,
                        height: 350,
                        buttons: {
                            'Lưu': function () {
                                doanhNghiepFn.saveVideo(_NewDlg, _popUpVideo, _gridMain, _gridVideo);
                                jQuery(_gridVideo).trigger('reloadGrid');
                            },
                            'Lưu và đóng': function () {
                                doanhNghiepFn.saveVideo(_NewDlg, _popUpVideo, _gridMain, _gridVideo);
                                $(_popUpVideo).dialog('close');
                            },
                            'Đóng': function () {
                                $(_popUpVideo).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');

                            adm.styleButton();
                            var ulpFn = function () {
                                var uploadBtn = $('.adm-upload-btn', _popUpVideo);
                                var fclip = $('#clip', _popUpVideo);
                                var uploadView = $('.adm-upload-preview-img-size', _popUpVideo);
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
                            //                            var txtPID = $('.PID', newDlg);
                            //                            $(txtPID).unbind('click').click(function () {
                            //                                $(txtPID).autocomplete('search', '');
                            //                            });
                            //                            video.setAutocomplete($(txtPID), function (event, ui) {
                            //                                $(txtPID).val(ui.item.label);
                            //                                $(txtPID).attr('_value', ui.item.id);
                            //                            });  
                            alert('2');
                            $.ajax({
                                url: doanhNghiepFn.urlDefault().toString() + '&subAct=editVideo',
                                dataType: 'script',
                                data: {
                                    'TV_ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    doanhNghiepFn.clearform(null, _popUpVideo, null, null, _NewDlg);
                                    var data = eval('(' + dt + ')');
                                    //var newDlg = $('#doanhNghiepChuaDuyet-VideoMdl-dlgNew');
                                    var txtID = $('.IDVideo', _popUpVideo);
                                    //    var txtPID = $('.PID', newDlg);
                                    var txtTen = $('.TenVideo', _popUpVideo);
                                    var txtThutu = $('.TTVideo', _popUpVideo);
                                    var txtMota = $('.MotaVideo', _popUpVideo);
                                    var spInfo = $('.admInfoVideo', _popUpVideo);
                                    var spbMsg = $('.admMsgVideo', _popUpVideo);
                                    var chkDuyet = $('.DuyetVideo', _popUpVideo);

                                    var hdClip = $('#clip', _popUpVideo);
                                    var lblAnh = $('.AnhVideo', _popUpVideo);

                                    var lblAnhPrv = $('.adm-upload-preview-size', _popUpVideo);
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
    delVideo: function (_gridVideo) {
        var s = '';
        if (jQuery(_gridVideo).jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery(_gridVideo).jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn Video để xóa');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn xóa?")) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=delVideo',
                    dataType: 'script',
                    data: {
                        'TV_ID': s
                    },
                    success: function (dt) {
                        jQuery(_gridVideo).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    duyetVideo: function (_gridVideo) {
        var s = '';
        if (jQuery(_gridVideo).jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery(_gridVideo).jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn Video để duyệt');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn duyệt?")) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=duyetVideo',
                    dataType: 'script',
                    data: {
                        'TV_ID': s
                    },
                    success: function (dt) {
                        jQuery(_gridVideo).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    dungVideo: function (_gridVideo) {
        var s = '';
        if (jQuery(_gridVideo).jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery(_gridVideo).jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn Video để dừng');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn dừng?")) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=dungVideo',
                    dataType: 'script',
                    data: {
                        'TV_ID': s
                    },
                    success: function (dt) {
                        jQuery(_gridVideo).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    saveVideo: function (_NewDlg, _popUpVideo, _gridMain, _gridVideo) {
        var newDlg = $(_popUpVideo);
        var txtID = $('.IDVideo', newDlg);
        //  var txtPID = $('.PID', newDlg);
        var txtTen = $('.TenVideo', newDlg);
        var txtThutu = $('.TTVideo', newDlg);
        var txtMota = $('.MotaVideo', newDlg);
        var chkDuyet = $('.DuyetVideo', newDlg);

        var spInfo = $('.admInfoVideo', newDlg);
        var spbMsg = $('.admMsgVideo', newDlg);
        var lblAnh = $('.AnhVideo', newDlg);
        var hdClip = $('#clip', newDlg);
        var clip = $(hdClip).attr('value');
        var anh = $(lblAnh).attr('ref');
        var id = $(txtID).val();
        //  var pid = $(txtPID).attr('_value');
        var duyet = $(chkDuyet).is(':checked');
        var ten = $(txtTen).val();
        var thutu = $(txtThutu).val();
        var mota = $(txtMota).val();
        var _tv_gh_id = '';
        if ($(_gridMain).jqGrid('getGridParam', 'selrow') != null) {
            _tv_gh_id = $(_gridMain).jqGrid('getGridParam', 'selrow').toString();
        }
        if (_tv_gh_id == '') {
            alert('Chọn Doanh nghiệp');
            return false;
        }


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
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=saveVideo',
            dataType: 'script',
            type: 'POST',
            data: {
                'TV_ID': id,
                'TV_GH_ID': _tv_gh_id,
                'TV_Ten': ten,
                'TV_Thutu': thutu,
                'TV_Mota': mota,
                'TV_Url': clip,
                'TV_Active': duyet,
                'TV_UrlImage': anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    spbMsg.html('');
                    doanhNghiepFn.clearform(null, _popUpVideo, null, null, _NewDlg);
                    jQuery(_gridVideo).trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })


    },

    addFlash: function (_gridMain, _gridFlash, _NewDlg, _DlgFlash) {
        var _popUpFlash = $('#doanhNghiep-FlashMdl-dlgNew');

        doanhNghiepFn.loadHtml(_DlgFlash, _popUpFlash, '<%=WebResource("cnn.plugin.doanhNghiep.Flash.htm")%>', function () {
            var _popUpFlash = $('#doanhNghiep-FlashMdl-dlgNew');
            $(_popUpFlash).dialog({
                title: 'Thêm mới',
                modal: true,
                width: 580,
                height: 370,
                buttons: {
                    'Lưu': function () {
                        doanhNghiepFn.saveFlash(_NewDlg, _popUpFlash, _gridMain, _gridFlash);
                        jQuery(_gridFlash).trigger('reloadGrid');
                    },
                    'Lưu và đóng': function () {
                        doanhNghiepFn.saveFlash(_NewDlg, _popUpFlash, _gridMain, _gridFlash);
                        $(_popUpFlash).dialog('close');
                    },
                    'Đóng': function () {
                        $(_popUpFlash).dialog('close');
                    }
                },
                open: function () {
                    doanhNghiepFn.clearform(null, null, _popUpFlash, null, _NewDlg);
                    adm.styleButton();
                    var ulpFn = function () {
                        var uploadBtn = $('.adm-upload-btn', _popUpFlash);
                        var uploadDiv = $('.adm-upload-preview-flash', _popUpFlash);
                        var uploadView = $('.adm-upload-preview-img-flash', _popUpFlash);
                        var uploadBanner = $('.adm-upload-preview-img-banner', _popUpFlash);
                        var OldRS = $('.DelFlash'); var Oldflash = OldRS.val();
                        var OldRSImg = $('.DelImg'); var OldImg = OldRSImg.val();
                        var _params = { 'oldFile': $(uploadBtn).attr('ref') };
                        adm.uploadFlash(uploadBtn, 'flash', _params, function (rs) {
                            arrRs = rs.split(".");
                            if (arrRs[1] == 'swf') {
                                $(uploadView).remove();
                                $(uploadBanner).remove();
                                $(uploadDiv).append('<embed class="adm-upload-preview-img-banner" src="../up/v/' + rs + '?ref=' + Math.random() + '"/>');
                                //$(uploadDiv).append('<input class ="DelFlash" type="hidden" value="' + rs + '"/>');
                                $(uploadBtn).attr('ref', rs);

                                //                                                                if (Oldflash != 'undefined') {
                                //                                                                    adm.delOldUpFlash(uploadBtn,Oldflash);                                    
                                //                                                                }
                                //                                                                if (OldImg != 'undefined') {
                                //                                                                    adm.delOldUpFlash(uploadBtn,OldImg);
                                //                                                                }
                            }
                            else {
                                $(uploadBanner).remove();
                                $(uploadView).remove();

                                $(uploadDiv).append('<img class="adm-upload-preview-img-flash" src="../up/i/' + rs + '?ref=' + Math.random() + '"/>');
                                // $(uploadDiv).append('<input class ="DelImg" type="hidden" value="' + rs + '"/>');
                                $(uploadBtn).attr('ref', rs);
                                //                                if (Oldflash != 'undefined') {
                                //                                    adm.delOldUpFlash(uploadBtn,Oldflash);
                                //                                   
                                //                                }
                                //                                if (OldImg != 'undefined') {
                                //                                    adm.delOldUpFlash(uploadBtn,OldImg);
                                //                                }
                            }

                            ulpFn();
                        }, function (f) {
                        });
                    }
                    ulpFn();
                }
            });
        });
    },
    editFlash: function (_gridMain, _gridFlash, _NewDlg, _DlgFlash) {
        var s = '';
        if (jQuery(_gridFlash).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(_gridFlash).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn Flash để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một Flash');
            }
            else {
                var _popUpFlash = $('#doanhNghiep-FlashMdl-dlgNew');
                doanhNghiepFn.loadHtml(_DlgFlash, _popUpFlash, '<%=WebResource("cnn.plugin.doanhNghiep.Flash.htm")%>', function () {
                    var _popUpFlash = $('#doanhNghiep-FlashMdl-dlgNew');

                    $(_popUpFlash).dialog({
                        title: 'Sửa',
                        modal: true,
                        width: 580,
                        height: 350,
                        buttons: {
                            'Lưu': function () {
                                doanhNghiepFn.saveFlash(_NewDlg, _popUpFlash, _gridMain, _gridFlash);
                                jQuery(_gridFlash).trigger('reloadGrid');
                            },
                            'Lưu và đóng': function () {
                                doanhNghiepFn.saveFlash(_NewDlg, _popUpFlash, _gridMain, _gridFlash);
                                jQuery(_gridFlash).trigger('reloadGrid');
                                $(_popUpFlash).dialog('close');
                            },
                            'Đóng': function () {
                                $(_popUpFlash).dialog('close');
                            }
                        },
                        open: function () {
                            doanhNghiepFn.clearform(null, null, _popUpFlash, null, _NewDlg);
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            var ulpFn = function () {
                                var uploadBtn = $('.adm-upload-btn', _popUpFlash);
                                var uploadDiv = $('.adm-upload-preview-flash', _popUpFlash);
                                var uploadView = $('.adm-upload-preview-img-flash', _popUpFlash);
                                var uploadBanner = $('.adm-upload-preview-img-banner', _popUpFlash);
                                var _params = { 'oldFile': $(uploadBtn).attr('ref') };
                                adm.uploadFlash(uploadBtn, 'flash', _params, function (rs) {
                                    arrRs = rs.split(".");
                                    if (arrRs[1] == 'swf') {
                                        $(uploadView).remove();
                                        $(uploadBanner).remove();

                                        $(uploadDiv).append('<embed class="adm-upload-preview-img-banner" src="../up/v/' + rs + '?ref=' + Math.random() + '"/>');
                                        $(uploadDiv).append('<input class ="DelFlash" type="hidden" value="' + rs + '"/>');
                                        $(uploadBtn).attr('ref', rs);

                                        //                                                                if (Oldflash != 'undefined') {
                                        //                                                                    adm.delOldUpFlash(uploadBtn,Oldflash);                                    
                                        //                                                                }
                                        //                                                                if (OldImg != 'undefined') {
                                        //                                                                    adm.delOldUpFlash(uploadBtn,OldImg);
                                        //                                                                }
                                    }
                                    else {
                                        $(uploadBanner).remove();
                                        $(uploadView).remove();

                                        $(uploadDiv).append('<img class="adm-upload-preview-img-flash" src="../up/i/' + rs + '?ref=' + Math.random() + '"/>');
                                        $(uploadDiv).append('<input class ="DelImg" type="hidden" value="' + rs + '"/>');
                                        $(uploadBtn).attr('ref', rs);
                                        //                                if (Oldflash != 'undefined') {
                                        //                                    adm.delOldUpFlash(uploadBtn,Oldflash);
                                        //                                   
                                        //                                }
                                        //                                if (OldImg != 'undefined') {
                                        //                                    adm.delOldUpFlash(uploadBtn,OldImg);
                                        //                                }
                                    }
                                    ulpFn();
                                }, function (f) {
                                });
                            }
                            ulpFn();

                            $.ajax({
                                url: doanhNghiepFn.urlDefault().toString() + '&subAct=editFlash',
                                dataType: 'script',
                                data: {
                                    'Flh_ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    doanhNghiepFn.clearform(null, null, _popUpFlash, null, _NewDlg);
                                    var data = eval('(' + dt + ')');
                                    var newDlg = $(_popUpFlash);
                                    var uploadDiv = $('.adm-upload-preview-flash', newDlg);
                                    var txtID = $('.IDFlash', newDlg);
                                    //    var txtPID = $('.PID', newDlg);
                                    var txtTen = $('.TenFlash', newDlg);
                                    var txtThutu = $('.ThutuFlash', newDlg);
                                    var txtMota = $('.MotaFlash', newDlg);
                                    var spInfo = $('.admInfoFlash', newDlg);
                                    var spbMsg = $('.admMsgFlash', newDlg);
                                    var chkDuyet = $('.DuyetFlash', newDlg);
                                    var imgAnh = $('.adm-upload-preview-img-flash', newDlg);
                                    var flash = $('.adm-upload-preview-img-banner', newDlg);
                                    var lblAnh = $('.AnhFlash', newDlg);
                                    $(lblAnh).attr('ref', data.PathImage);
                                    if (data.PathImage != '') {
                                        $(uploadDiv).append('<img class="adm-upload-preview-img-flash" src="../up/i/' + data.PathImage + '?ref=' + Math.random() + '"/>');
                                    }
                                    else {
                                        $(uploadDiv).append('<embed class="adm-upload-preview-img-banner" style="z-index:1;" src="../up/v/' + data.PathFlash + '?ref=' + Math.random() + '"/>');
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
    delFlash: function (_gridFlash) {
        var s = '';
        if (jQuery(_gridFlash).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(_gridFlash).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn Flash để xóa');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn xóa?")) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=delFlash',
                    dataType: 'script',
                    data: {
                        'Flh_ID': s
                    },
                    success: function (dt) {
                        jQuery(_gridFlash).trigger('reloadGrid');
                    }
                });
            }
        }
    },

    duyetFlash: function (_gridFlash) {
        var s = '';
        if (jQuery(_gridFlash).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(_gridFlash).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn Flash để duyệt');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn duyệt?")) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=duyetFlash',
                    dataType: 'script',
                    data: {
                        'Flh_ID': s
                    },
                    success: function (dt) {
                        jQuery(_gridFlash).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    dungFlash: function (_gridFlash) {
        var s = '';
        if (jQuery(_gridFlash).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(_gridFlash).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn Flash để dừng');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn dừng?")) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=dungFlash',
                    dataType: 'script',
                    data: {
                        'Flh_ID': s
                    },
                    success: function (dt) {
                        jQuery(_gridFlash).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    saveFlash: function (_NewDlg, _popUpFlash, _gridMain, _gridFlash) {
        var newDlg = $(_popUpFlash);
        var txtID = $('.IDFlash', newDlg);
        //  var txtPID = $('.PID', newDlg);
        var txtTen = $('.TenFlash', newDlg);
        var txtThutu = $('.ThutuFlash', newDlg);
        var txtMota = $('.MotaFlash', newDlg);
        var chkDuyet = $('.DuyetFlash', newDlg);

        var spInfo = $('.admInfoFlash', newDlg);
        var spbMsg = $('.admMsgFlash', newDlg);
        var lblAnh = $('.AnhFlash', newDlg);
        var hdClip = $('#clip', newDlg);
        var clip = $(hdClip).attr('value');
        var f_a = $(lblAnh).attr('ref');
        var arr = f_a.split(".");
        if (arr[1] == 'swf') {
            var flash = $(lblAnh).attr('ref');
        }
        else {
            var anh = $(lblAnh).attr('ref');
        }

        alert('flash' + flash);
        alert('anh' + anh);
        var id = $(txtID).val();
        var duyet = $(chkDuyet).is(':checked');
        var ten = $(txtTen).val();
        var thutu = $(txtThutu).val();
        var mota = $(txtMota).val();
        var _flh_gh_id = '';
        if ($(_gridMain).jqGrid('getGridParam', 'selrow') != null) {
            _flh_gh_id = $(_gridMain).jqGrid('getGridParam', 'selrow').toString();
        }
        if (_flh_gh_id == '') {
            alert('Chọn doanh nghiệp');
            return false;
        }


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
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=saveFlash',
            dataType: 'script',
            type: 'POST',
            data: {
                'Flh_ID': id,
                'Flh_GH_ID': _flh_gh_id,
                'Flh_Ten': ten,
                'Flh_Thutu': thutu,
                'Flh_Mota': mota,
                'Flh_Url': clip,
                'Flh_Active': duyet,
                'Flh_UrlImage': anh,
                'Flh_Url': flash
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    spbMsg.html('');
                    doanhNghiepFn.clearform(null, null, _popUpFlash, null, _NewDlg);
                    jQuery(_gridFlash).trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })


    },


    addHinhAnh: function (_gridMain, _gridHinhAnh, _NewDlg, _DlgHinhAnh) {
        var _popUpHinhAnh = $('#doanhNghiep-HinhAnhMdl-dlgNew');
        doanhNghiepFn.loadHtml(_DlgHinhAnh, _popUpHinhAnh, '<%=WebResource("cnn.plugin.doanhNghiep.HinhAnh.htm")%>', function () {
            var _popUpHinhAnh = $('#doanhNghiep-HinhAnhMdl-dlgNew');
            var newDlg = $(_popUpHinhAnh);
            $(newDlg).dialog({
                title: 'Thêm mới',
                modal: true,
                width: 400,
                height: 350,
                buttons: {
                    'Lưu': function () {
                        doanhNghiepFn.saveHinhAnh(_NewDlg, _popUpHinhAnh, _gridMain, _gridHinhAnh);
                    },
                    'Lưu và đóng': function () {
                        doanhNghiepFn.saveHinhAnh(_NewDlg, _popUpHinhAnh, _gridMain, _gridHinhAnh);
                        $(newDlg).dialog('close');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    doanhNghiepFn.clearform(null, null, null, _popUpHinhAnh, _NewDlg);
                    adm.styleButton();
                    var ulpFn = function () {
                        var uploadBtn = $('.adm-upload-btn', newDlg);
                        var uploadView = $('.adm-upload-preview-img-size', newDlg);
                        var _params = { 'oldFile': $(uploadBtn).attr('ref') };
                        adm.upload(uploadBtn, 'anh', _params, function (rs) {
                            $(uploadBtn).attr('ref', rs)
                            $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                            ulpFn();
                        }, function (f) {
                        });
                    }
                    ulpFn();
                }
            });
        });
    },
    editHinhAnh: function (_gridMain, _gridHinhAnh, _NewDlg, _DlgHinhAnh) {
        var s = '';
        if (jQuery("#doanhNghiepMdl-subHinhAnhMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#doanhNghiepMdl-subHinhAnhMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn hình ảnh để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một hình ảnh');
            }
            else {
                var _popUpHinhAnh = $('#doanhNghiep-HinhAnhMdl-dlgNew');
                doanhNghiepFn.loadHtml(_DlgHinhAnh, _popUpHinhAnh, '<%=WebResource("cnn.plugin.doanhNghiep.HinhAnh.htm")%>', function () {
                    var _popUpHinhAnh = $('#doanhNghiep-HinhAnhMdl-dlgNew');
                    var newDlg = $(_popUpHinhAnh);
                    $(newDlg).dialog({
                        title: 'Sửa',
                        modal: true,
                        width: 400,
                        height: 350,
                        buttons: {
                            'Lưu': function () {
                                doanhNghiepFn.saveHinhAnh(_NewDlg, _popUpHinhAnh, _gridMain, _gridHinhAnh);
                            },
                            'Lưu và đóng': function () {
                                doanhNghiepFn.saveHinhAnh(_NewDlg, _popUpHinhAnh, _gridMain, _gridHinhAnh);
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
                                var uploadBtn = $('.adm-upload-btn', newDlg);
                                var uploadView = $('.adm-upload-preview-img-size', newDlg);
                                var _params = { 'oldFile': $(uploadBtn).attr('ref') };
                                adm.upload(uploadBtn, 'anh', _params, function (rs) {
                                    $(uploadBtn).attr('ref', rs)
                                    $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                                    ulpFn();
                                }, function (f) {
                                });
                            }
                            ulpFn();

                            $.ajax({
                                url: doanhNghiepFn.urlDefault().toString() + '&subAct=editHinhAnh',
                                dataType: 'script',
                                data: {
                                    'HA_ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    doanhNghiepFn.clearform(null, null, null, _popUpHinhAnh, _NewDlg);
                                    var data = eval('(' + dt + ')');
                                    var newDlg = $(_popUpHinhAnh);
                                    var txtID = $('.IDHinhAnh', newDlg);
                                    var txtTen = $('.TenHinhAnh', newDlg);
                                    var txtLink = $('.LinkHinhAnh', newDlg);
                                    var txtMota = $('.MotaHinhAnh', newDlg);
                                    var spInfo = $('.admInfoHinhAnh', newDlg);
                                    var spbMsg = $('.admMsgHinhAnh', newDlg);
                                    var chkDuyet = $('.DuyetHinhAnh', newDlg);
                                    var imgAnh = $('.adm-upload-preview-img-size', newDlg);
                                    var lblAnh = $('.AnhHinhAnh', newDlg);
                                    $(lblAnh).attr('ref', data.PathImage);
                                    if (data.PathImage != '') {
                                        $(imgAnh).attr('src', '../up/i/' + data.PathImage + '?ref=' + Math.random());
                                    }
                                    $(txtID).val(data.ID);
                                    $(txtTen).val(data.Ten);
                                    $(txtLink).val(data.Link);
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
    delHinhAnh: function (_gridHinhAnh) {
        var s = '';
        if (jQuery(_gridHinhAnh).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(_gridHinhAnh).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn hình ảnh để xóa');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn xóa?")) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=delHinhAnh',
                    dataType: 'script',
                    data: {
                        'HA_ID': s
                    },
                    success: function (dt) {
                        jQuery(_gridHinhAnh).trigger('reloadGrid');
                    }
                });
            }
        }
    },

    duyetHinhAnh: function (_gridHinhAnh) {
        var s = '';
        if (jQuery(_gridHinhAnh).jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery(_gridHinhAnh).jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn hình ảnh để duyệt');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn duyệt?")) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=duyetHinhAnh',
                    dataType: 'script',
                    data: {
                        'HA_ID': s
                    },
                    success: function (dt) {
                        jQuery(_gridHinhAnh).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    dungHinhAnh: function (_gridHinhAnh) {
        var s = '';
        if (jQuery(_gridHinhAnh).jqGrid('getGridParam', 'selarrrow') != null) {
            s = jQuery(_gridHinhAnh).jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn hình ảnh để dừng');
        }
        else {
            if (confirm("Bạn có chắc chắn muốn dừng?")) {
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=dungHinhAnh',
                    dataType: 'script',
                    data: {
                        'HA_ID': s
                    },
                    success: function (dt) {
                        jQuery(_gridHinhAnh).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    saveHinhAnh: function (_NewDlg, _popUpHinhAnh, _gridMain, _gridHinhAnh) {
        var newDlg = $(_popUpHinhAnh);
        var txtID = $('.IDHinhAnh', newDlg);
        //  var txtPID = $('.PID', newDlg);
        var txtTen = $('.TenHinhAnh', newDlg);
        var txtLink = $('.LinkHinhAnh', newDlg);
        var txtMota = $('.MotaHinhAnh', newDlg);
        var chkDuyet = $('.DuyetHinhAnh', newDlg);
        var spInfo = $('.admInfoHinhAnh', newDlg);
        var spbMsg = $('.admMsgHinhAnh', newDlg);
        var lblAnh = $('.AnhHinhAnh', newDlg);
        var anh = $(lblAnh).attr('ref');
        var id = $(txtID).val();
        //  var pid = $(txtPID).attr('_value');
        var duyet = $(chkDuyet).is(':checked');
        var ten = $(txtTen).val();
        var link = $(txtLink).val();
        var mota = $(txtMota).val();
        var _ha_gh_id = '';
        if ($(_gridMain).jqGrid('getGridParam', 'selrow') != null) {
            _ha_gh_id = $(_gridMain).jqGrid('getGridParam', 'selrow').toString();
        }
        if (_ha_gh_id == '') {
            alert('Chọn doanh nghiệp');
            return false;
        }


        var err = '';
        if (ten == '') {
            err += 'Nhập tên<br/>';
        }
        if (err != '') {
            spbMsg.html(err);
            return false;
        }

        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=saveHinhAnh',
            dataType: 'script',
            type: 'POST',
            data: {
                'HA_ID': id,
                'HA_GH_ID': _ha_gh_id,
                'HA_Ten': ten,
                'HA_Mota': mota,
                'HA_Link': link,
                'HA_Active': duyet,
                'HA_UrlImage': anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    spbMsg.html('');
                    doanhNghiepFn.clearform(null, null, null, _popUpHinhAnh, _NewDlg);
                    jQuery(_gridHinhAnh).trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })


    },


    popfn: function (_newDlgChungChi, _newDlgVideo) {

        var ngaycap = $('.NgayCapChungChi', _newDlgChungChi);
        var gianhang = $('.GHID', _newDlgChungChi);
        ngaycap.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        var ulpChungChiFn = function () {
            var uploadBtn = $('.adm-upload-btn', _newDlgChungChi);
            var uploadView = $('.adm-upload-preview-img-size', _newDlgChungChi);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.upload(uploadBtn, 'anh', _params, function (rs) {
                $(uploadBtn).attr('ref', rs)
                $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                ulpChungChiFn();
            }, function (f) {
            });
        }
        ulpChungChiFn();


        var ngaytao = $('.NgayTaoVideo', _newDlgVideo);
        var mota = $('.MotaVideo', _newDlgVideo);
        ngaytao.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        var ulpVideoFn = function () {
            var uploadBtn = $('.adm-upload-btn', _newDlgVideo);
            var fclip = $('#clip', _newDlgVideo);
            var uploadView = $('.adm-upload-preview-img', _newDlgVideo);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.uploadvideo(uploadBtn, 'video', _params, function (rs) {
                arrRs = rs.split(";");

                $(fclip).attr('value', arrRs[1]);
                $(uploadBtn).attr('ref', arrRs[0])
                $(uploadView).attr('src', '../up/i/' + arrRs[0] + '?ref=' + Math.random());
                ulpVideoFn();
            }, function (f) {
            });
        }
        ulpVideoFn();
    },
    valiNumberPhone: function (number) {
        var status = false;
        var numberPRegEx = /(^[\d]*[-]*$)|(^[-]*[0-9]*$)|(^[0-9]*[-]*[0-9]*$)/;
        if (number.search(numberPRegEx) == -1) {
            status = false;
        }
        else {
            status = true;
        }
        return status;
    },
    valiEmail: function (email) {
        var status = false;
        var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
        if (emailRegEx.test(email))
            status = true;
        return status;
    },
    //end Validate
    setAutocomplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp danh sách');
                $.ajax({
                    url: doanhNghiepFn.urlDefault().toString() + '&subAct=getPid',
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
    nangCapThanhVien: function (_get_gh, _gridMain, _DlgNangCapTV) {
        var s = '';
        if (jQuery(_gridMain).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(_gridMain).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Hãy chọn doanh nghiệp để nâng cấp thành viên.')
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một doanh nghiệp');
            }
            else {
                var _popUpNangCapTV = $('#nangCapLoaiThanhVien-dlgNew');
                console.log(_DlgNangCapTV);
                doanhNghiepFn.loadHtml(_DlgNangCapTV, _popUpNangCapTV, '<%=WebResource("cnn.plugin.doanhNghiep.nangCapTV.htm")%>', function () {
                    adm.styleButton();
                    var _popUpNangCapTV = $('#nangCapLoaiThanhVien-dlgNew');
                    var loaithanhvien = $('.DM_ID', _popUpNangCapTV);
                    adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                        danhmuc.autoCompleteLangBased("", "TV_LOAI", loaithanhvien, function (event, ui) {
                            $(loaithanhvien).attr('_value', ui.item.id);
                            $(loaithanhvien).attr('_ten', ui.item.Ten);
                        });
                    });
                    var txtStartDate = $('.startdate', _popUpNangCapTV);
                    var txtEndDate = $('.enddate', _popUpNangCapTV);
                    txtStartDate.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
                    txtEndDate.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
                    $(_popUpNangCapTV).dialog({
                        title: 'NÂNG CẤP THÀNH VIÊN',
                        width: 'auto',
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                doanhNghiepFn.saveNangCapLTV(_get_gh, _gridMain)                            
                               
                            },
                            'Lưu và đóng': function () {
                                doanhNghiepFn.saveNangCapLTV(_get_gh, _gridMain)
                                    $(_popUpNangCapTV).dialog('close');
                               
                            },
                            'Đóng': function () {
                                $(_popUpNangCapTV).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            $.ajax({
                                url: doanhNghiepFn.urlDefault().toString() + '&subAct=NangCapThanhVien',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);

                                    var item_gh = data[0];
                                    var _popUpNangCapTV = $('#nangCapLoaiThanhVien-dlgNew');
                                    var txtID = $('.ID', _popUpNangCapTV);
                                    $(txtID).val(item_gh.ID);
                                    var txtTen = $('.Ten', _popUpNangCapTV);
                                    $(txtTen).html(item_gh.Ten);
                                    var txtDiaChi = $('.DiaChi', _popUpNangCapTV);
                                    $(txtDiaChi).html(item_gh.DiaChi);
                                    var txtNgayDK = $('.NgayDK', _popUpNangCapTV);
                                    var ngayDK = new Date(item_gh.NgayTao);
                                    var _ngaydk = ngayDK.getDate() + '/' + (ngayDK.getMonth() + 1) + '/' + ngayDK.getFullYear();
                                    $(txtNgayDK).html(_ngaydk);
                                    var txtNguoiDaiDien = $('.NguoiDaiDien', _popUpNangCapTV);
                                    $(txtNguoiDaiDien).html(item_gh.NguoiDaiDien);
                                    var txtDienThoai = $('.DienThoai', _popUpNangCapTV);
                                    $(txtDienThoai).html(item_gh.DienThoai);
                                    var txtWebsite = $('.Website', _popUpNangCapTV);
                                    $(txtWebsite).html(item_gh.Website);
                                    var txtStartDate = $('.startdate', _popUpNangCapTV);
                                    var txtEndDate = $('.enddate', _popUpNangCapTV);
                                    var txtDM_ID = $('.DM_ID', _popUpNangCapTV);
                                    if (item_gh.dm_Ma == 'TV_VANG') {

                                        var ngayDKTVV = new Date(item_gh.NgayDKTV_Vang);
                                        var _ngaydktvv = ngayDKTVV.getDate() + '/' + (ngayDKTVV.getMonth() + 1) + '/' + ngayDKTVV.getFullYear();

                                        if (_ngaydktvv != '1/1/100') {
                                            $(txtStartDate).val(_ngaydktvv);
                                        }
                                        var ngayKTTVV = new Date(item_gh.NgayKTTV_Vang);
                                        var _ngaykttvv = ngayKTTVV.getDate() + '/' + (ngayKTTVV.getMonth() + 1) + '/' + ngayKTTVV.getFullYear();
                                        if (_ngaydktvv != '1/1/100') {
                                            $(txtEndDate).val(_ngaykttvv);
                                        }


                                    }
                                    if (item_gh.dm_Ma == 'TV_BAC') {
                                        var ngayDKTVB = new Date(item_gh.NgayDKTV_Bac);
                                        var _ngaydktvb = ngayDKTVB.getDate() + '/' + (ngayDKTVB.getMonth() + 1) + '/' + ngayDKTVB.getFullYear();
                                        if (_ngaydktvv != '1/1/100') {
                                            $(txtStartDate).val(_ngaydktvb);
                                        }


                                        var ngayKTTVB = new Date(item_gh.NgayKTTV_Bac);
                                        var _ngaykttvb = ngayKTTVB.getDate() + '/' + (ngayKTTVB.getMonth() + 1) + '/' + ngayKTTVB.getFullYear();
                                        if (_ngaydktvv != '1/1/100') {
                                            $(txtEndDate).val(_ngaykttvb);
                                        }

                                    }
                                    if (item_gh.dm_Ma == 'TV_DONG') {
                                        var ngayDKTVD = new Date(item_gh.NgayDKTV_Dong);
                                        var _ngaydktvd = ngayDKTVD.getDate() + '/' + (ngayDKTVD.getMonth() + 1) + '/' + ngayDKTVD.getFullYear();
                                        if (_ngaydktvv != '1/1/100') {
                                            $(txtStartDate).val(_ngaydktvd);
                                        }
                                        var ngayKTTVD = new Date(item_gh.NgayKTTV_Dong);
                                        var _ngaykttvd = ngayKTTVD.getDate() + '/' + (ngayKTTVD.getMonth() + 1) + '/' + ngayKTTVD.getFullYear();

                                        if (_ngaydktvv != '1/1/100') {
                                            $(txtEndDate).val(_ngaykttvd);
                                        }

                                    }
                                    if (item_gh.dm_Ma == 'TV_FREE') {
                                        $(txtStartDate).val('');
                                        $(txtEndDate).val('');

                                    }
                                    txtDM_ID.val(item_gh.dm_Ten);
                                    txtDM_ID.attr('_value', item_gh.dm_Id);

                                }
                            });
                        }
                    });
                });
            }

        }
    },
    saveNangCapLTV: function (_get_gh, _gridMain) {
        var newDlg = $('#nangCapLoaiThanhVien-dlgNew');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        var txtDM_ID = $('.DM_ID', newDlg);
        var ltv_id = $(txtDM_ID).attr('_value');
        var txtNgaybatdau = $('.startdate', newDlg);
        var ngaybatdau = $(txtNgaybatdau).val();
        var txtNgayketthuc = $('.enddate', newDlg);
        var ngayketthuc = $(txtNgayketthuc).val();
        adm.loading(null);
        $.ajax({
            url: doanhNghiepFn.urlDefault().toString() + '&subAct=saveNangCapLTV',
            dataType: 'script',
            data: {

                'ID': id,
                'LTV_ID': ltv_id,
                'GH_NgayBatDau': ngaybatdau,
                'GH_NgayKetThuc': ngayketthuc
            },
            success: function (dt) {
                $(_gridMain).jqGrid('setGridParam', { url: doanhNghiepFn.urlDefault().toString() + '&subAct=' + _get_gh }).trigger('reloadGrid');
                adm.loading('Cập nhật thông tin thành công!');
            }
        })
    },


    loadMainHtml: function (_NewDlgParen, _NewDlgChl, _webResource, fn) {
        var newDlg = $(_NewDlgChl);
        if ($(newDlg).length < 1) {
            adm.loading('Load form');
            $(_NewDlgParen).load(_webResource, function () {
                adm.loading(null);
                if (typeof (fn) == 'function') { fn(); }
            });
        }
    },


    loadHtml: function (_newDlg, _popUpHtml, _WebResource, fn) {
        var dlg = $(_popUpHtml);
        var del = $(_newDlg);
        del.html('');
        if ($(dlg).length < 1) {
            adm.loading('Dựng form');
            $.ajax({
                url: _WebResource,
                success: function (dt) {
                    adm.loading(null);
                    $(del).append(dt);
                    if (typeof (fn) == 'function') { fn(); }
                }
            });
        }
        else { if (typeof (fn) == 'function') { fn(); } }

    }

}