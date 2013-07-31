var DKSanPhamDacTrungFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.DangKyDichVu.DKSPDacTrungNew.Class1, cnn.plugin.DangKyDichVu'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#DKSanPhamDacTrungFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#DKSanPhamDacTrungFnMdl-Pager');
            var _grid = $('#DKSanPhamDacTrungFnMdl-List');
            PublishFn.loadgridCase(_obj, _grid, _pagergrid,'get','Danh sách sản phẩm');
        });
    },
    add: function () {
        var _objMain = $('#DKSanPhamDacTrungFnMdl-Main');
        var _obj = $('#DKSanPhamDacTrungFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#DKSanPhamDacTrungFnMdl-List');
        PublishFn.add(_objMain, _obj, _Subobj, _grid);
    },
    edit: function () {
        var _objMain = $('#DKSanPhamDacTrungFnMdl-Main');
        var _obj = $('#DKSanPhamDacTrungFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#DKSanPhamDacTrungFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#DKSanPhamDacTrungFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#DKSanPhamDacTrungFnMdl-Main');
        var _obj = $('#DKSanPhamDacTrungFnMdl-HangHoatempMdl-DKSanPhamDacTrung-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#DKSanPhamDacTrungFnMdl-List');
        PublishFn.DangKySanPhamDacTrung(_objMain, _obj, _Subobj, _grid);
    }
}
