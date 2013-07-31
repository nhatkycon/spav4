using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using linh.common;
using System.Web;
using docsoft.entities;
using cnn.entities;
namespace cnn.entities
{
    //class DiaChiBanGiongEx
    //{
    //    //public DiaChiBanGiong ItemDCBG
    //}
    public class DiaChiBanGiongEx
    {
        public DanhMuc itemDM { get; set; }
        public DiaChiBanGiong itemDCBG { get; set; }
        public List<DiaChiBanGiong> ListDCBG { get; set; }
    }
}
