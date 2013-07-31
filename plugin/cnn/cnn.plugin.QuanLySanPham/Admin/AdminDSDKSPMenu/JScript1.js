var AdmDanhSachSanPhamMenuFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.Admin.AdminDSDKSPMenu.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#AdmDanhSachSanPhamMenuFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#AdmDanhSachSanPhamMenuFnMdl-Pager');
            var _grid = $('#AdmDanhSachSanPhamMenuFnMdl-List');
            var _FilterDMSP = $('.FilterDMSP', '#AdmDanhSachSanPhamMenuFnMdl-Main');
            var _txtSearch = $('.txtSearch', '#AdmDanhSachSanPhamMenuFnMdl-Main');
            var _FilterGHID = $('.FilterGHID', '#AdmDanhSachSanPhamMenuFnMdl-Main');
            PublishFn.loadgridSPTraPhiAdmCase(_obj, _grid, _pagergrid, 'getSPMenuAdm', 'Danh sách đăng ký sản phẩm Menu',_FilterDMSP, _txtSearch, _FilterGHID);
        });
    },
    edit: function () {
        var _objMain = $('#AdmDanhSachSanPhamMenuFnMdl-Main');
        var _obj = $('#AdmDanhSachSanPhamMenuFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#AdmDanhSachSanPhamMenuFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#AdmDanhSachSanPhamMenuFnMdl-List');
        PublishFn.del(_grid);
    },
    LamMoi: function () {
        var _grid = $('#AdmDanhSachSanPhamMenuFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    },
    DuyetChiTietDT: function () {
        var _objMain = $('#AdmDanhSachSanPhamMenuFnMdl-Main');
        var _obj = $('#AdmDanhSachSanPhamMenuFnMdl-FormDuyetDKDVtempMdl-dlgNew');
        var _Subobj = $('.DuyetSPDT-Dlg');
        var _grid = $('#AdmDanhSachSanPhamMenuFnMdl-List');
        PublishFn.FormDuyetDKSP(_objMain, _obj, _Subobj, _grid, 'Duyệt dịch vụ đăng ký sản phẩm đặc trưng');
    },
    DuyetNhanhDT: function () {
        var _grid = $('#AdmDanhSachSanPhamMenuFnMdl-List');
        PublishFn.QickSaveDKDVGrid(_grid, '', 'False', '', 'True');
    },
    HuyDKSPDT: function () {
        var _grid = $('#AdmDanhSachSanPhamMenuFnMdl-List');
        PublishFn.QickSaveDKDVGrid(_grid, '', 'False', '', '');
    }
}
