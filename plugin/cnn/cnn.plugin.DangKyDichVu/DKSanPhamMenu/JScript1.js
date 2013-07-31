var DKSanPhamMenuFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.DangKyDichVu.DKSanPhamMenu.Class1, cnn.plugin.DangKyDichVu'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#DKSanPhamMenuFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#DKSanPhamMenuFnMdl-Pager');
            var _grid = $('#DKSanPhamMenuFnMdl-List');
            PublishFn.loadgridCase(_obj, _grid, _pagergrid,'get','Danh sách sản phẩm');
        });
    },
    add: function () {
        var _objMain = $('#DKSanPhamMenuFnMdl-Main');
        var _obj = $('#DKSanPhamMenuFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#DKSanPhamMenuFnMdl-List');
        PublishFn.add(_objMain, _obj, _Subobj, _grid);
    },
    edit: function () {
        var _objMain = $('#DKSanPhamMenuFnMdl-Main');
        var _obj = $('#DKSanPhamMenuFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#DKSanPhamMenuFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#DKSanPhamMenuFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#DKSanPhamMenuFnMdl-Main');
        var _obj = $('#DKSanPhamMenuFnMdl-HangHoatempMdl-DKSanPhamMenu-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#DKSanPhamMenuFnMdl-List');
        PublishFn.DangKySanPhamMenu(_objMain, _obj, _Subobj, _grid);
    }
}
