var DuyetTin_tinFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.rss.tin.DuyetTin.Class1, plugin.rss.tin',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#tinMdlds-List').jqGrid({
            url: DuyetTin_tinFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Ảnh', 'Nội dung', 'Phân loại', 'Ngày', 'Hot', 'Hot1', 'Hot2', 'Hot3', 'Dm', 'Home', 'Đọc nhiều', 'Views', 'Bình luận', 'Điểm'],
            colModel: [
            { name: 'T_ID', key: true, sortable: true, hidden: true },
            { name: 'T_Anh', width: 5, sortable: false, editable: true },
            { name: 'T_Ten', width: 50, resizable: true, sortable: false, editable: true },
            { name: 'T_CM_ID', width: 10, resizable: true, sortable: false, editable: true },
            { name: 'T_Ngay', width: 5, resizable: true, sortable: false, editable: true },
            { name: 'T_Hot', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Hot1', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Hot2', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Hot3', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Dm', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Home', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_DocNhieu', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Views', width: 5, resizable: true, sortable: false },
            { name: 'T_BinhChon', width: 5, resizable: true, sortable: false },
            { name: 'T_Diem', width: 5, resizable: true, sortable: false }
            ],
            caption: 'Danh sách',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'T_ID',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#tinMdlds-Pager'),
            editurl: DuyetTin_tinFn.urlDefault + '&subAct=save',
            onSelectRow: function (rowid) {
               // var treedata = $("#tinMdlds-List").jqGrid('getRowData', rowid);
               // DuyetTin_tinFn.loadsubfunction(treedata.T_ID);
            },
            loadComplete: function () {

                adm.loading(null);

                //var searchTxt = $('.mdl-head-search-tinMdlds'); adm.regQS(searchTxt, 'tinMdlds-List');
                // DuyetTin_tinFn.headFn();
               //   DuyetTin_tinFn.loadTinList('0');

                $.getScript('../js/ajaxupload.js', function () { });
            }
        });
    }
//    ,
//        search: function () {
//                var timerSearch;
//                var filterByBao = $('.mdl-head-tinFilterByBao');
//                var filterByDanhMuc = $('.mdl-head-tinFilterByDanhMuc');
//                var filterByNhom = $('.mdl-head-tinFilterByNhom');
//                var filterByTopic = $('.mdl-head-tinFilterByTopic');
//                var filterByNgay = $('.mdl-head-tinFilterByNgay');
//                var searchTxt = $('.mdl-head-search-tinMdlds');

//                var _B_ID = $(filterByBao).attr('_value');
//                var _DM_ID = $(filterByDanhMuc).attr('_value');
//                var _N_ID = $(filterByNhom).attr('_value');
//                var _T_ID = $(filterByTopic).attr('_value');
//                var _Ngay = $(filterByNgay).val();

//                var __B_ID = $(filterByBao).val();
//                var __DM_ID = $(filterByDanhMuc).val();
//                var __N_ID = $(filterByNhom).val();
//                var __T_ID = $(filterByTopic).val();
//                var __q = $(searchTxt).val();
//                if (__DM_ID == '') {
//                    $(filterByDanhMuc).attr('_value', ''); _DM_ID = '';
//                }
//                if (__B_ID == '') {
//                    $(filterByBao).attr('_value', ''); _B_ID = '';
//                }
//                if (__N_ID == '') {
//                    $(filterByNhom).attr('_value', ''); _N_ID = '';
//                }
//                if (__T_ID == '') {
//                    $(filterByTopic).attr('_value', ''); _T_ID = '';
//                }
//                if (timerSearch) clearTimeout(timerSearch);

//                                timerSearch = setTimeout(function () {
//                                    $('#tinMdlds-List').jqGrid('setGridParam', { url: DuyetTin_tinFn.urlDefault
//                                    + '&subAct=get'
//                                    + '&Bao=' + _B_ID
//                                    + '&DM_ID=' + _DM_ID
//                                    + '&TpId=' + _T_ID
//                                     + '&Nid=' + _N_ID
//                                     + '&Ngay=' + _Ngay
//                                     + '&q=' + __q
//                                    }).trigger("reloadGrid");
//                                }, 1000);
//                            }

//        }

    

}
