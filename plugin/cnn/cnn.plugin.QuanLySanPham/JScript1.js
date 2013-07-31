var QuanLySanPhamFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#QuanLySanPhamFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#QuanLySanPhamFnMdl-Pager');
            var _grid = $('#QuanLySanPhamFnMdl-List');
            PublishFn.loadgridCase(_obj, _grid, _pagergrid, 'get','Danh sách sản phẩm mới');
        });
    },
    add: function () {
        var _objMain = $('#QuanLySanPhamFnMdl-Main');
        var _obj = $('#QuanLySanPhamFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#QuanLySanPhamFnMdl-List');
        PublishFn.add(_objMain, _obj, _Subobj, _grid);
    },
    edit: function () {
        var _objMain = $('#QuanLySanPhamFnMdl-Main');
        var _obj = $('#QuanLySanPhamFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#QuanLySanPhamFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#QuanLySanPhamFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#QuanLySanPhamFnMdl-Main');
        var _obj = $('#QuanLySanPhamFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#QuanLySanPhamFnMdl-List');
        PublishFn.DangKySanPhamDacTrung(_objMain, _obj, _Subobj, _grid);
    },
    DangKySanPhamMenu: function () {
        var _objMain = $('#QuanLySanPhamFnMdl-Main');
        var _obj = $('#QuanLySanPhamFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew');
        var _Subobj = $('.DangKySanPhamMenu-DKDV-dlgNew');
        var _grid = $('#QuanLySanPhamFnMdl-List');
        PublishFn.DangKySanPhamMenu(_objMain, _obj, _Subobj, _grid);
    },
    LamMoi: function () {
        var _grid = $('#QuanLySanPhamFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    },
    DungTin: function () {
        var _grid = $('#QuanLySanPhamFnMdl-List');
        PublishFn.DangTinDungTinCase(_grid, 'DungTin');
    }
}
