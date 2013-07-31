var DanhSachSanPhamDungFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.User.UserDanhSachSPDung.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#DanhSachSanPhamDungFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#DanhSachSanPhamDungFnMdl-Pager');
            var _grid = $('#DanhSachSanPhamDungFnMdl-List');
            PublishFn.loadgridCase(_obj, _grid, _pagergrid, 'getSPDung','Danh sách sản phẩm tạm dừng');
        });
    },
    edit: function () {
        var _objMain = $('#DanhSachSanPhamDungFnMdl-Main');
        var _obj = $('#DanhSachSanPhamDungFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#DanhSachSanPhamDungFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#DanhSachSanPhamDungFnMdl-List');
        PublishFn.del(_grid);
    },
    LamMoi: function () {
        var _grid = $('#DanhSachSanPhamDungFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    },
    DangTin: function () {
        var _grid = $('#DanhSachSanPhamDungFnMdl-List');
        PublishFn.DangTinDungTinCase(_grid, 'DangTin');
    }
}
