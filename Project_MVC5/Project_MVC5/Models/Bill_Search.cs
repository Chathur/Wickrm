using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace Project_MVC5.Models
{
    public class Bill_Search
    {
        public int? Page { get; set; }
        public string Name_Product { get; set; }
        public Nullable<double> Price { get; set; }
        public string Quantity { get; set; }
        public Nullable<double> Total { get; set; }
        public System.DateTime Date { get; set; }
        public string Employee { get; set; }
        public int ? Bill_No { get; set; }
        public string Customer { get; set; }
        public IPagedList<tb_SalesOrder> SearchResults { get; set; }
        public string SearchButton { get; set; }
    }
}