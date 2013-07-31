tinnhanpopupObj = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.popUp.Class1, cnn.plugin.popUp',
    setup: function () {
        //tinnhanpopupObj.popfn();
        alert('setup');
        tinnhanpopupObj.add();
    },
    loadHtml: function (fn) {
        var dlg = $('#tinnhanpopupmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            alert('loadHtml');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.popUp.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    alert('loadhtml ok');
                    $('body').append(dt);
                    
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
            });
        }
        else {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
    },
    add: function () {
        alert('add');
        tinnhanpopupObj.loadHtml(function () {
            var newDlg = $('#tinnhanpopupmdl-dlgNew');
            alert($(newDlg).html());
            $(newDlg).dialog({
                title: 'Tin mới',
                width: 400,
                modal: true,
                buttons: {
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    alert('open ok');
                    adm.styleButton();
                }
            });
        });

    }
}