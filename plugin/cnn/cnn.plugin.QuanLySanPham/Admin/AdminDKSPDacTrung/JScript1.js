var AdminDSSanPhamDTFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLySanPham.Admin.AdminDKSPDacTrung.Class1, cnn.plugin.QuanLySanPham'; },
    setup: function () { },
    NapPublishFn: function () {
        adm.regTypeNew(typeof (PublishFn), 'cnn.plugin.QuanLySanPham.Class1, cnn.plugin.QuanLySanPham', function () {
            var _obj = $('#AdminDSSanPhamDTFnMdl-HangHoatempMdl-dlgNew');
            var _pagergrid = $('#AdminDSSanPhamDTFnMdl-Pager');
            var _grid = $('#AdminDSSanPhamDTFnMdl-List');
            var _FilterDMSP = $('.FilterDMSP', '#AdminDSSanPhamDTFnMdl-Main');
            var _txtSearch = $('.txtSearch', '#AdminDSSanPhamDTFnMdl-Main');
            var _FilterGHID = $('.FilterGHID', '#AdminDSSanPhamDTFnMdl-Main');
            PublishFn.loadgridSPTraPhiAdmCase(_obj, _grid, _pagergrid, 'getSPDTAdmDuyet','Danh sách sản phẩm đặc trưng', _FilterDMSP, _txtSearch, _FilterGHID);
        });
    },
    add: function () {
        var _objMain = $('#AdminDSSanPhamDTFnMdl-Main');
        var _obj = $('#AdminDSSanPhamDTFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#AdminDSSanPhamDTFnMdl-List');
        PublishFn.add(_objMain, _obj, _Subobj, _grid);
    },
    edit: function () {
        var _objMain = $('#AdminDSSanPhamDTFnMdl-Main');
        var _obj = $('#AdminDSSanPhamDTFnMdl-HangHoatempMdl-dlgNew');
        var _Subobj = $('.HangHoatempMdl-dlgNew');
        var _grid = $('#AdminDSSanPhamDTFnMdl-List');
        PublishFn.edit(_objMain, _obj, _Subobj, _grid);
    },
    del: function () {
        var _grid = $('#AdminDSSanPhamDTFnMdl-List');
        PublishFn.del(_grid);
    },
    DangKySanPhamDacTrung: function () {
        var _objMain = $('#AdminDSSanPhamDTFnMdl-Main');
        var _obj = $('#AdminDSSanPhamDTFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew');
        var _Subobj = $('.DangKySanPhamDacTrung-DKDV-dlgNew');
        var _grid = $('#AdminDSSanPhamDTFnMdl-List');
        PublishFn.DangKySanPhamDacTrung(_objMain, _obj, _Subobj, _grid);
    },
    DangKySanPhamMenu: function () {
        var _objMain = $('#AdminDSSanPhamDTFnMdl-Main');
        var _obj = $('#AdminDSSanPhamDTFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew');
        var _Subobj = $('.DangKySanPhamMenu-DKDV-dlgNew');
        var _grid = $('#AdminDSSanPhamDTFnMdl-List');
        PublishFn.DangKySanPhamMenu(_objMain, _obj, _Subobj, _grid);
    },
    LamMoi: function () {
        var _grid = $('#AdminDSSanPhamDTFnMdl-List');
        PublishFn.LamMoiGrid(_grid);
    },
    DungTin: function () {
        var _grid = $('#AdminDSSanPhamDTFnMdl-List');
        PublishFn.DangTinDungTinCase(_grid,'DungTin');
    },
    ChuyenSPThuong: function () {
        var _grid = $('#AdminDSSanPhamDTFnMdl-List');
        PublishFn.QickSaveDKDVGrid(_grid, '', '', 'False', '');
    },
    GiaHan: function () {
        var _objMain = $('#AdminDSSanPhamDTFnMdl-Main');
        var _obj = $('#AdminDSSanPhamDTFnMdl-FormDuyetDKDVtempMdl-dlgNew');
        var _Subobj = $('.DuyetSPDT-Dlg');
        var _grid = $('#AdminDSSanPhamDTFnMdl-List');
        PublishFn.FormDuyetDKSP(_objMain, _obj, _Subobj, _grid, 'Gia hạn trả phí cho sản phẩm');
    }

}
