var UserSanPhamMenuFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.User.UserSanPhamMenu.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#UserSanPhamMenuFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#UserSanPhamMenuFnMdl-Pager');
            var _grid = $('#UserSanPhamMenuFnMdl-List');
            PublishFn.loadgridSPTraPhiUserCase(_obj, _grid, _pagergrid, 'getMenu','Danh sách sản phẩm đăng ký Menu');
        });
    },
    edit: function () {
        var _objMain = $('#UserSanPhamMenuFnMdl-Main');
        var _obj = $('#UserSanPhamMenuFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#UserSanPhamMenuFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#UserSanPhamMenuFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#UserSanPhamMenuFnMdl-Main');
        var _obj = $('#UserSanPhamMenuFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#UserSanPhamMenuFnMdl-List');
        PublishFn.DangKySanPhamDacTrung(_objMain, _obj, _Subobj, _grid);
    },
    DangKySanPhamMenu: function () {
        var _objMain = $('#UserSanPhamMenuFnMdl-Main');
        var _obj = $('#UserSanPhamMenuFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew');
        var _Subobj = $('.DangKySanPhamMenu-DKDV-dlgNew');
        var _grid = $('#UserSanPhamMenuFnMdl-List');
        PublishFn.DangKySanPhamMenu(_objMain, _obj, _Subobj, _grid);
    },
    LamMoi: function () {
        var _grid = $('#UserSanPhamMenuFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    }
}
