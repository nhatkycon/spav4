var AdminDanhSachSanPhamFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.Admin.AdminSPMoi.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#AdminDanhSachSanPhamFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#AdminDanhSachSanPhamFnMdl-Pager');
            var _grid = $('#AdminDanhSachSanPhamFnMdl-List');
            var _FilterDMSP = $('.FilterDMSP', '#AdminDanhSachSanPhamFnMdl-Main'); //FilterGHID
            var _FilterGHID = $('.FilterGHID', '#AdminDanhSachSanPhamFnMdl-Main');
            var _txtSearch = $('.txtSearch', '#AdminDanhSachSanPhamFnMdl-Main');
            PublishFn.loadgridAdmCase(_obj, _grid, _pagergrid, 'getDSSPAdm', 'Danh sách sản phẩm', _FilterDMSP, _txtSearch, _FilterGHID);
            //getDSSPAdm
        });
    },
    add: function () {
        var _objMain = $('#AdminDanhSachSanPhamFnMdl-Main');
        var _obj = $('#AdminDanhSachSanPhamFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#AdminDanhSachSanPhamFnMdl-List');
        PublishFn.add(_objMain, _obj, _Subobj, _grid);
    },
    edit: function () {
        var _objMain = $('#AdminDanhSachSanPhamFnMdl-Main');
        var _obj = $('#AdminDanhSachSanPhamFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#AdminDanhSachSanPhamFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#AdminDanhSachSanPhamFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#AdminDanhSachSanPhamFnMdl-Main');
        var _obj = $('#AdminDanhSachSanPhamFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#AdminDanhSachSanPhamFnMdl-List');
        PublishFn.DangKySanPhamDacTrung(_objMain, _obj, _Subobj, _grid);
    },
    DangKySanPhamMenu: function () {
        var _objMain = $('#AdminDanhSachSanPhamFnMdl-Main');
        var _obj = $('#AdminDanhSachSanPhamFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew');
        var _Subobj = $('.DangKySanPhamMenu-DKDV-dlgNew');
        var _grid = $('#AdminDanhSachSanPhamFnMdl-List');
        PublishFn.DangKySanPhamMenu(_objMain, _obj, _Subobj, _grid);
    },
    LamMoi: function () {
        var _grid = $('#AdminDanhSachSanPhamFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    },
    DungTin: function () {
        var _grid = $('#AdminDanhSachSanPhamFnMdl-List');
        PublishFn.DangTinDungTinCase(_grid, 'DungTinAdm');
    },
    ChuyenThanhTinBanGiong: function () {
        var _grid = $('#AdminDanhSachSanPhamFnMdl-List');
        PublishFn.ChuyenTinBanGiong(_grid);
    }
}
