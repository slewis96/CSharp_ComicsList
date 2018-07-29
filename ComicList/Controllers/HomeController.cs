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
            List<ComicBook> allComics = new List<ComicBook>();
            allComics.Add( new ComicBook(1, "Hellblazer #24", "DC Comics", "25th", "July", "https://www.dccomics.com/comics/the-hellblazer-2016/the-hellblazer-24", "https://www.dccomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/hellblazer_24_5b58aa2e1b8fa8.91931370.jpg?itok=TLBTqfc5"));
            allComics.Add( new ComicBook(2, "The Walking Dead #182", "Image Comics", "1st", "August", "https://imagecomics.com/comics/releases/the-walking-dead-182", "https://imagecomics.com/uploads/releases/_main/TheWalkingDead_182-1.png"));
            allComics.Add( new ComicBook(3, "The Walking Dead #183", "Image Comics", "5th", "September", "https://imagecomics.com/comics/releases/the-walking-dead-183", "https://imagecomics.com/uploads/releases/_main/TWD183_Cover.jpg"));
            allComics.Add( new ComicBook(4, "The Walking Dead #184", "Image Comics", "3rd", "October", "https://imagecomics.com/comics/releases/the-walking-dead-184","https://imagecomics.com/uploads/releases/_main/TWD184_Cover.jpg"));
            allComics.Add( new ComicBook(5, "The Sandman Universe #1", "Vertigo Comics", "8th", "August", "https://www.vertigocomics.com/comics/the-sandman-universe-2018/the-sandman-universe-1", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/SNDUNI_Cv1_300_R1_5b3ba127a24c56.52724561.jpg?itok=oCvC32GU"));
            allComics.Add( new ComicBook(6, "House of Whispers #1", "Vertigo Comics", "12th", "September", "https://www.vertigocomics.com/comics/house-of-whispers-2018/house-of-whispers-1", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/06/HOWSP_Cv1_5b1eb9b1b677b6.14801600.jpg?itok=Qvo63jWa"));
            allComics.Add( new ComicBook(7, "The Dreaming #1", "Vertigo Comics", "5th", "September", "https://www.vertigocomics.com/comics/the-dreaming-2018/the-dreaming-1", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/06/DREAMNG_Cv1_ds_5b1eb798b4f412.83971528.jpg?itok=czRnqCxn"));
            allComics.Add(new ComicBook(8, "The Dreaming #2", "Vertigo Comics", "3rd", "October", "https://www.vertigocomics.com/comics/the-dreaming-2018/the-dreaming-2", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/DREAMNG_Cv2_5b4f73fa78bed2.58523224.jpg?itok=z6CKDtJK"));
            allComics.Add( new ComicBook(9, "House of Whispers #2", "Vertigo Comics", "10th", "October", "https://www.vertigocomics.com/comics/house-of-whispers-2018/house-of-whispers-2", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/HOWSP_Cv2_SOLICITS_5b4f74d6df7319.63412843.jpg?itok=-HgEXQuO"));
            allComics.Add( new ComicBook(10, "Lucifer #1", "Vertigo Comics", "17th", "October", "https://www.vertigocomics.com/comics/lucifer-2018/lucifer-1", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/LUCI_Cv1_ds_600_5b4f7140f1d617.68191623.jpg?itok=7lFwMfDu"));
            allComics.Add( new ComicBook(11, "The Books of Magic #1", "Vertigo Comics", "24th", "October", "https://www.vertigocomics.com/comics/the-books-of-magic-2018/the-books-of-magic-1", "https://www.vertigocomics.com/sites/default/files/styles/covers192x291/public/comic-covers/2018/07/BOMG_Cv1_ds_5b4f700db1d665.75994792.jpg?itok=l24foNTV"));
            string[] months = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

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
