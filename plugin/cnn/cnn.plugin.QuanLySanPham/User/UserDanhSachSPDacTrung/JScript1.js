var DanhSachSanPhamDacTrungFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.User.UserDanhSachSPDacTrung.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#DanhSachSanPhamDacTrungFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#DanhSachSanPhamDacTrungFnMdl-Pager');
            var _grid = $('#DanhSachSanPhamDacTrungFnMdl-List');
            PublishFn.loadgridSPTraPhiUserCase(_obj, _grid, _pagergrid, 'getSPDT','Danh sách sản phẩm đăng ký đặc trưng');
        });
    },
    edit: function () {
        var _objMain = $('#DanhSachSanPhamDacTrungFnMdl-Main');
        var _obj = $('#DanhSachSanPhamDacTrungFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#DanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#DanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#DanhSachSanPhamDacTrungFnMdl-Main');
        var _obj = $('#DanhSachSanPhamDacTrungFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#DanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.DangKySanPhamDacTrung(_objMain, _obj, _Subobj, _grid);
    },
    DangKySanPhamMenu: function () {
        var _objMain = $('#DanhSachSanPhamDacTrungFnMdl-Main');
        var _obj = $('#DanhSachSanPhamDacTrungFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew');
        var _Subobj = $('.DangKySanPhamMenu-DKDV-dlgNew');
        var _grid = $('#DanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.DangKySanPhamMenu(_objMain, _obj, _Subobj, _grid);
    },
    LamMoi: function () {
        var _grid = $('#DanhSachSanPhamDacTrungFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    }
}
