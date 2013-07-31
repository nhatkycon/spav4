doanhNghiepDuyetFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.doanhNghiep.daDuyet.Class1, cnn.plugin.doanhNghiep'; },
    setup: function () { },
    NapdoanhNghiepFn: function () {
        var _NewDlg = $('#doanhNghiepDaDuyetMdl-Main-NewDlg');
        var _DlgChungChi = $('#doanhNghiepDaDuyetMdl-ChungChi-NewDlg');
        var _DlgVideo = $('#doanhNghiepDaDuyetMdl-Video-NewDlg');
        var _DlgFlash = $('#doanhNghiepDaDuyetMdl-Flash-NewDlg');
        var _DlgHinhAnh = $('#doanhNghiepDaDuyetMdl-HinhAnh-NewDlg');
        var _NewDlgBody = $('#doanhNghiepDaDuyetMdl-Body-NewDlg', _NewDlg);

        var _filterSP = $('.mdl-head-filterNhomSP', '#doanhnghiepDaDuyet-head');
        var _filterKV = $('.mdl-head-filterKhuVuc', '#doanhnghiepDaDuyet-head');
        var _searchTxt = $('.mdl-head-search-doanhNghiepDaDuyet', '#doanhnghiepDaDuyet-head');
        var _get_gh = 'getDuyet';

        adm.regType(typeof (doanhNghiepFn), 'cnn.plugin.doanhNghiep.doanhNghiep, cnn.plugin.doanhNghiep', function () {
            var _newDlgForm = $('#doanhNghiepDaDuyetMdl-subMdl', _NewDlg);
            doanhNghiepFn.loadMainHtml(_NewDlgBody, _newDlgForm, '<%=WebResource("cnn.plugin.doanhNghiep.daDuyet.doanhNghiepDaDuyet.htm")%>', function () {
                var _subMdl = $('#doanhNghiepDaDuyetMdl-subMdl', _NewDlgBody);
                var _gridMain = $('#doanhNghiepDaDuyetMdl-List', _NewDlg);
                var _pagerMain = $('#doanhNghiepDaDuyetMdl-Pager', _NewDlg);
                var _gridChungChi = $('#doanhNghiepDaDuyetMdl-subChungChiMdl-List', _NewDlgBody);
                var _pagerChungChi = $('#doanhNghiepDaDuyetMdl-ChungChiPager', _NewDlgBody);
                var _gridVideo = $('#doanhNghiepDaDuyetMdl-subVideoMdl-List', _NewDlgBody);
                var _pagerVideo = $('#doanhNghiepDaDuyetMdl-VideoPager', _NewDlgBody);
                var _gridFlash = $('#doanhNghiepDaDuyetMdl-subFlashMdl-List', _NewDlgBody);
                var _pagerFlash = $('#doanhNghiepDaDuyetMdl-FlashPager', _NewDlgBody);
                var _gridHinhAnh = $('#doanhNghiepDaDuyetMdl-subHinhAnhMdl-List', _NewDlgBody);
                var _pagerHinhAnh = $('#doanhNghiepDaDuyetMdl-HinhAnhPager', _NewDlgBody);
                var _newDlgLienHe = $('#doanhNghiepDaDuyetMdl-subLienHeMdl', _NewDlgBody);
                var _newDlgTaiKhoan = $('#doanhNghiepDaDuyetMdl-subThongTinTKMdl', _NewDlgBody);
                var _newDlgThongTin = $('#doanhNghiepDaDuyetMdl-subThongTinMdl', _NewDlgBody);

                doanhNghiepFn.loadForm(_get_gh, _NewDlg, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh);
            });
        });

    },

    del: function () {
        var _NewDlg = $('#doanhNghiepDaDuyetMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepDaDuyetMdl-List', _NewDlg);
        doanhNghiepFn.del(_girdMain);

    },
    active: function () {
        var _NewDlg = $('#doanhNghiepDaDuyetMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepDaDuyetMdl-List', _NewDlg);
        doanhNghiepFn.Active(_girdMain);
    },
 
    boxacnhan: function () {
        var _NewDlg = $('#doanhNghiepDaDuyetMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepDaDuyetMdl-List', _NewDlg);
        doanhNghiepFn.boxacnhan(_girdMain);
    },
    nangCapTV: function () {
        var _get_gh = 'getDuyet';
        var _NewDlg = $('#doanhNghiepDaDuyetMdl-Main-NewDlg');
        var _gridMain = $('#doanhNghiepDaDuyetMdl-List', _NewDlg);
        var _DlgNangCapTV = ('#doanhNghiepDaDuyetMdl-NangCapTV-NewDlg');
        doanhNghiepFn.nangCapThanhVien(_get_gh,_gridMain, _DlgNangCapTV);
    }

}






 