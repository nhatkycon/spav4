var AdmDanhSachSanPhamDacTrungFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.Admin.AdminDSDKSPDacTrung.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#AdmDanhSachSanPhamDacTrungFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#AdmDanhSachSanPhamDacTrungFnMdl-Pager');
            var _grid = $('#AdmDanhSachSanPhamDacTrungFnMdl-List');
            var _FilterDMSP = $('.FilterDMSP', '#AdmDanhSachSanPhamDacTrungFnMdl-Main');
            var _txtSearch = $('.txtSearch', '#AdmDanhSachSanPhamDacTrungFnMdl-Main');
            var _FilterGHID = $('.FilterGHID', '#AdmDanhSachSanPhamDacTrungFnMdl-Main');
            PublishFn.loadgridSPTraPhiAdmCase(_obj, _grid, _pagergrid, 'getSPDTAdm','Danh sách đăng ký sản phẩm đặc trưng', _FilterDMSP, _txtSearch, _FilterGHID);
        });
    },
    edit: function () {
        var _objMain = $('#AdmDanhSachSanPhamDacTrungFnMdl-Main');
        var _obj = $('#AdmDanhSachSanPhamDacTrungFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#AdmDanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#AdmDanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.del(_grid);
    },
    LamMoi: function () {
        var _grid = $('#AdmDanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    },
    DuyetChiTietDT: function () {
        var _objMain = $('#AdmDanhSachSanPhamDacTrungFnMdl-Main');
        var _obj = $('#AdmDanhSachSanPhamDacTrungFnMdl-FormDuyetDKDVtempMdl-dlgNew');
        var _Subobj = $('.DuyetSPDT-Dlg');
        var _grid = $('#AdmDanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.FormDuyetDKSP(_objMain, _obj, _Subobj, _grid, 'Duyệt dịch vụ đăng ký sản phẩm đặc trưng');
    },
    DuyetNhanhDT: function () {
        var _grid = $('#AdmDanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.QickSaveDKDVGrid(_grid,'False','','True','');
    },
    HuyDKSPDT: function () {
        var _grid = $('#AdmDanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.QickSaveDKDVGrid(_grid,'False','','','');
    }
}
