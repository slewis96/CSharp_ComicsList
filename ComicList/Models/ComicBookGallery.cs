using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ComicList.Models {
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ComicBook
    {
        public int ID { get; set; }
        public string SeriesTitle { get; set; }
        public string Publisher { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }

        public ComicBook(int iD, string seriesTitle, string publisher, string day, string month, string link, string image) {
            ID = iD;
            SeriesTitle = seriesTitle;
            Publisher = publisher;
            Day = day;
            Month = month;
            Link = link;
            Image = image;
        }
    } 
}
