tinnhanTestObj = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.tinNhan.Test.Class1, cnn.plugin.tinNhan',
        setup: function () {
            //tinnhanTestObj.popfn();
            alert('ok');
            tinnhanTestObj.realtime(); 
        },

    realtime: function () {
        if (_gloTimer) clearInterval(_gloTimer);

        var CurrentD = new Date();
        //document.title = 'iTask© | ' + CurrentD.getHours() + ':' + CurrentD.getMinutes() + ':' + CurrentD.getSeconds() + ' ' + CurrentD.getDate() + '/' + CurrentD.getMonth();
        alert('send1');
        $.ajax({
            url: tinnhanTestObj.urlDefault + '&subAct=test',
            dataType: 'script',
            success: function (_dt) {
                alert('revice1');
                _gloTimer = setInterval(function () { tinnhanTestObj.realtime(); }, 5000);
            }
        });
        
    }
   
}