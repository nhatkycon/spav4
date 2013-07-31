var UserDSSPDacTrungDaDuyetFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.User.UserDanhSachSPDTDaDuyet.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#UserDSSPDacTrungDaDuyetFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#UserDSSPDacTrungDaDuyetFnMdl-Pager');
            var _grid = $('#UserDSSPDacTrungDaDuyetFnMdl-List');
            PublishFn.loadgridSPTraPhiUserCase(_obj, _grid, _pagergrid, 'getSPDTDaDuyet', 'Danh sách sản phẩm đặc trưng');
        });
    },
    edit: function () {
        var _objMain = $('#UserDSSPDacTrungDaDuyetFnMdl-Main');
        var _obj = $('#UserDSSPDacTrungDaDuyetFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#UserDSSPDacTrungDaDuyetFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#UserDSSPDacTrungDaDuyetFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#UserDSSPDacTrungDaDuyetFnMdl-Main');
        var _obj = $('#UserDSSPDacTrungDaDuyetFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#UserDSSPDacTrungDaDuyetFnMdl-List');
        PublishFn.DangKySanPhamDacTrung(_objMain, _obj, _Subobj, _grid);
    },
    DangKySanPhamMenu: function () {
        var _objMain = $('#UserDSSPDacTrungDaDuyetFnMdl-Main');
        var _obj = $('#UserDSSPDacTrungDaDuyetFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew');
        var _Subobj = $('.DangKySanPhamMenu-DKDV-dlgNew');
        var _grid = $('#UserDSSPDacTrungDaDuyetFnMdl-List');
        PublishFn.DangKySanPhamMenu(_objMain, _obj, _Subobj, _grid);
    },
    LamMoi: function () {
        var _grid = $('#UserDSSPDacTrungDaDuyetFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    }
}
