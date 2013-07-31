var AdminDSSanPhamMenuFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.Admin.AdminSPMenu.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#AdminDSSanPhamMenuFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#AdminDSSanPhamMenuFnMdl-Pager');
            var _grid = $('#AdminDSSanPhamMenuFnMdl-List');
            var _FilterDMSP = $('.FilterDMSP', '#AdminDSSanPhamMenuFnMdl-Main');
            var _txtSearch = $('.txtSearch', '#AdminDSSanPhamMenuFnMdl-Main');
            var _FilterGHID = $('.FilterGHID', '#AdminDSSanPhamMenuFnMdl-Main');
            PublishFn.loadgridSPTraPhiAdmCase(_obj, _grid, _pagergrid, 'getSPMenuAdmDuyet', 'Danh sách sản Phẩm Menu', _FilterDMSP, _txtSearch, _FilterGHID);
        });
    },
    add: function () {
        var _objMain = $('#AdminDSSanPhamMenuFnMdl-Main');
        var _obj = $('#AdminDSSanPhamMenuFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#AdminDSSanPhamMenuFnMdl-List');
        PublishFn.add(_objMain, _obj, _Subobj, _grid);
    },
    edit: function () {
        var _objMain = $('#AdminDSSanPhamMenuFnMdl-Main');
        var _obj = $('#AdminDSSanPhamMenuFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#AdminDSSanPhamMenuFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#AdminDSSanPhamMenuFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#AdminDSSanPhamMenuFnMdl-Main');
        var _obj = $('#AdminDSSanPhamMenuFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#AdminDSSanPhamMenuFnMdl-List');
        PublishFn.DangKySanPhamDacTrung(_objMain, _obj, _Subobj, _grid);
    },
    DangKySanPhamMenu: function () {
        var _objMain = $('#AdminDSSanPhamMenuFnMdl-Main');
        var _obj = $('#AdminDSSanPhamMenuFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew');
        var _Subobj = $('.DangKySanPhamMenu-DKDV-dlgNew');
        var _grid = $('#AdminDSSanPhamMenuFnMdl-List');
        PublishFn.DangKySanPhamMenu(_objMain, _obj, _Subobj, _grid);
    },
    LamMoi: function () {
        var _grid = $('#AdminDSSanPhamMenuFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    },
    DungTin: function () {
        var _grid = $('#AdminDSSanPhamMenuFnMdl-List');
        PublishFn.DangTinDungTinCase(_grid,'DungTin');
    },
    ChuyenSPThuong: function () {
        var _grid = $('#AdminDSSanPhamMenuFnMdl-List');
        PublishFn.QickSaveDKDVGrid(_grid, '', '', '', 'False');
    },
    GiaHan: function () {
        var _objMain = $('#AdminDSSanPhamMenuFnMdl-Main');
        var _obj = $('#AdminDSSanPhamMenuFnMdl-FormDuyetDKDVtempMdl-dlgNew');
        var _Subobj = $('.DuyetSPDT-Dlg');
        var _grid = $('#AdminDSSanPhamMenuFnMdl-List');
        PublishFn.FormDuyetDKSP(_objMain, _obj, _Subobj, _grid, 'Gia hạn trả phí cho sản phẩm');
    }

}
