<%@ WebService Language="C#" Class="Tin" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using docbao.entitites;
using System.Collections.Generic;
using linh.controls;
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Tin  : System.Web.Services.WebService {

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public List<docbao.entitites.Tin> Search(int top, string keyword)
    {
        return TinDal.SelectTopTimKiemWs(top, keyword);
    }
    
    [WebMethod]
    public List<Channel> GetChannels()
    {
        List<Channel> List = new List<Channel>();
        foreach (Channel item in ChannelDal.SelectAll())
        {
            List.Add(item);
        }
        return List;
    }
    [WebMethod]
    public List<Channel> GetChannel()
    {
        List<Channel> List = new List<Channel>();
        foreach (Channel item in ChannelDal.SelectAll())
        {
            
            List.Add(item);
            break;
        }
        return List;
    }
    [WebMethod]
    public List<myChannel> getRss()
    {
        List<myChannel> List = new List<myChannel>();
        foreach (Channel item in ChannelDal.SelectAll())
        {
            List.Add(new myChannel(item.RssUrl, item.ID, item.DM_ID));
        }
        return List;
    }
    [WebMethod]
    public docbao.entitites.Tin InsertLink(docbao.entitites.Tin item)
    {
        return docbao.entitites.TinDal.Insert(item);
    }
    [WebMethod]
    public bool CheckLink(string link)
    {
        return TinDal.ValidateLink(link);
    }
    [WebMethod]
    public bool CheckLink2(string link,string title)
    {
        return TinDal.ValidateLink(link, title);
    }
    [WebMethod]
    public void InsertTag(string key, int count, int ID)
    {
        TagDal.Insert(null, key, count, ID);
    }
    [WebMethod]
    public List<docbao.entitites.Tin> tin_getTop(string dm,string cm,string q)
    {
        Pager<docbao.entitites.Tin> pagerGet = TinDal.pagerAdm(q, "", dm, cm, null);
        return pagerGet.List;
    }
    [WebMethod]
    public docbao.entitites.Bao Get(int TinID)
    {
        return docbao.entitites.BaoDal.SelectById(TinID);
    }
}
public class myChannel
{
    public string url { get; set; }
    public int cm_id { get; set; }
    public int dm_id { get; set; }
    public myChannel() { }
    public myChannel(string _url, int _cm_id, int _dm_id)
    {
        url = _url;
        cm_id = _cm_id;
        dm_id = _dm_id;
    }
}