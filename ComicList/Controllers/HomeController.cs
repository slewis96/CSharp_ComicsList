using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComicList.Models;

namespace ComicList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Comicbooks
            var comicBook = new ComicBook(1, "Hellblazer #24", "DC Comics", "25th", "July", "https://www.dccomics.com/comics/the-hellblazer-2016/the-hellblazer-24", "https://www.dccomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/hellblazer_24_5b58aa2e1b8fa8.91931370.jpg?itok=TLBTqfc5");
            var comicBook2 = new ComicBook(2, "The Walking Dead #182", "Image Comics", "1st", "August", "https://imagecomics.com/comics/releases/the-walking-dead-182", "https://imagecomics.com/uploads/releases/_main/TheWalkingDead_182-1.png");
            var comicBook3 = new ComicBook(3, "The Walking Dead #183", "Image Comics", "5th", "September", "https://imagecomics.com/comics/releases/the-walking-dead-183", "https://imagecomics.com/uploads/releases/_main/TWD183_Cover.jpg");
            var comicBook4 = new ComicBook(4, "The Walking Dead #184", "Image Comics", "3rd", "October", "https://imagecomics.com/comics/releases/the-walking-dead-184","https://imagecomics.com/uploads/releases/_main/TWD184_Cover.jpg");
            var comicBook5 = new ComicBook(5, "The Sandman Universe #1", "Vertigo Comics", "8th", "August", "https://www.vertigocomics.com/comics/the-sandman-universe-2018/the-sandman-universe-1", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/SNDUNI_Cv1_300_R1_5b3ba127a24c56.52724561.jpg?itok=oCvC32GU");
            var comicBook6 = new ComicBook(6, "House of Whispers #1", "Vertigo Comics", "12th", "September", "https://www.vertigocomics.com/comics/house-of-whispers-2018/house-of-whispers-1", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/06/HOWSP_Cv1_5b1eb9b1b677b6.14801600.jpg?itok=Qvo63jWa");
            var comicBook7 = new ComicBook(7, "The Dreaming #1", "Vertigo Comics", "5th", "September", "https://www.vertigocomics.com/comics/the-dreaming-2018/the-dreaming-1", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/06/DREAMNG_Cv1_ds_5b1eb798b4f412.83971528.jpg?itok=czRnqCxn");
            var comicBook8 = new ComicBook(8, "The Dreaming #2", "Vertigo Comics", "3rd", "October", "https://www.vertigocomics.com/comics/the-dreaming-2018/the-dreaming-2", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/DREAMNG_Cv2_5b4f73fa78bed2.58523224.jpg?itok=z6CKDtJK");
            var comicBook9 = new ComicBook(9, "Lucifer #1", "Vertigo Comics", "17th", "October", "https://www.vertigocomics.com/comics/lucifer-2018/lucifer-1", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/LUCI_Cv1_ds_600_5b4f7140f1d617.68191623.jpg?itok=7lFwMfDu");
            var comicBook10 = new ComicBook(10, "The Books of Magic #1", "Vertigo Comics", "24th", "October", "https://www.vertigocomics.com/comics/the-books-of-magic-2018/the-books-of-magic-1", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/BOMG_Cv1_ds_5b4f700db1d665.75994792.jpg?itok=l24foNTV");
            ComicBook[] allComics = new ComicBook[]{comicBook,comicBook2,comicBook3,comicBook4,comicBook5,comicBook6,comicBook7,comicBook8,comicBook9, comicBook10};
            string[] months = new string[] {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

            //Comics given to index
            ViewBag.Comics = new List<List<ComicBook>>();

            //For each month match comics and add list to Viewbag list
            foreach(string month in months) {
                List<ComicBook> comicMonth = new List<ComicBook>();
                foreach (ComicBook comic in allComics) {
                    if(comic.Month == month) {
                        comicMonth.Add(comic);
                    } 
                }
                if (comicMonth.Any()){
                    ViewBag.Comics.Add(comicMonth);
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
