var UserDSSPMenuDaDuyetFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.User.UserDanhSachSPMenuDaDuyet.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#UserDSSPMenuDaDuyetFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#UserDSSPMenuDaDuyetFnMdl-Pager');
            var _grid = $('#UserDSSPMenuDaDuyetFnMdl-List');
            PublishFn.loadgridSPTraPhiUserCase(_obj, _grid, _pagergrid, 'getMenuUserDaDuyet', 'Danh sách sản phẩm Menu');
        });
    },
    edit: function () {
        var _objMain = $('#UserDSSPMenuDaDuyetFnMdl-Main');
        var _obj = $('#UserDSSPMenuDaDuyetFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#UserDSSPMenuDaDuyetFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#UserDSSPMenuDaDuyetFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#UserDSSPMenuDaDuyetFnMdl-Main');
        var _obj = $('#UserDSSPMenuDaDuyetFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#UserDSSPMenuDaDuyetFnMdl-List');
        PublishFn.DangKySanPhamDacTrung(_objMain, _obj, _Subobj, _grid);
    },
    DangKySanPhamMenu: function () {
        var _objMain = $('#UserDSSPMenuDaDuyetFnMdl-Main');
        var _obj = $('#UserDSSPMenuDaDuyetFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew');
        var _Subobj = $('.DangKySanPhamMenu-DKDV-dlgNew');
        var _grid = $('#UserDSSPMenuDaDuyetFnMdl-List');
        PublishFn.DangKySanPhamMenu(_objMain, _obj, _Subobj, _grid);
    },
    LamMoi: function () {
        var _grid = $('#UserDSSPMenuDaDuyetFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    }
}
