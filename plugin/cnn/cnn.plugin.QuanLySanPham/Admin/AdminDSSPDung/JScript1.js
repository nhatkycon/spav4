var AdminDSSPDungFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.Admin.AdminDSSPDung.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#AdminDSSPDungFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#AdminDSSPDungFnMdl-Pager');
            var _grid = $('#AdminDSSPDungFnMdl-List');
            var _FilterDMSP = $('.FilterDMSP', '#AdminDSSPDungFnMdl-Main');
            var _txtSearch = $('.txtSearch', '#AdminDSSPDungFnMdl-Main');
            var _FilterGHID = $('.FilterGHID', '#AdminDSSPDungFnMdl-Main');
            PublishFn.loadgridAdmCase(_obj, _grid, _pagergrid, 'getDSSPDungAdm', 'Danh sách sản phẩm bị Dừng',_FilterDMSP, _txtSearch, _FilterGHID);
            //getDSSPAdm
        });
    },
    add: function () {
        var _objMain = $('#AdminDSSPDungFnMdl-Main');
        var _obj = $('#AdminDSSPDungFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#AdminDSSPDungFnMdl-List');
        PublishFn.add(_objMain, _obj, _Subobj, _grid);
    },
    edit: function () {
        var _objMain = $('#AdminDSSPDungFnMdl-Main');
        var _obj = $('#AdminDSSPDungFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#AdminDSSPDungFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#AdminDSSPDungFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#AdminDSSPDungFnMdl-Main');
        var _obj = $('#AdminDSSPDungFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#AdminDSSPDungFnMdl-List');
        PublishFn.DangKySanPhamDacTrung(_objMain, _obj, _Subobj, _grid);
    },
    DangKySanPhamMenu: function () {
        var _objMain = $('#AdminDSSPDungFnMdl-Main');
        var _obj = $('#AdminDSSPDungFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew');
        var _Subobj = $('.DangKySanPhamMenu-DKDV-dlgNew');
        var _grid = $('#AdminDSSPDungFnMdl-List');
        PublishFn.DangKySanPhamMenu(_objMain, _obj, _Subobj, _grid);
    },
    LamMoi: function () {
        var _grid = $('#AdminDSSPDungFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    },
    DangTin: function () {
        var _grid = $('#AdminDSSPDungFnMdl-List');
        PublishFn.DangTinDungTinCase(_grid, 'DangTinAdm');
    }

}
