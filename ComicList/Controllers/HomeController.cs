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
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string[] lines = System.IO.File.ReadAllLines("https://comicpulllist.azurewebsites.net/data/comics.txt");
            int i = 1;
            foreach (string line in lines) {
                List<string> parameters = line.Split(',').ToList<string>();
                string title = parameters[0].Trim();
                string pub = parameters[1].Trim();
                string day = parameters[2].Trim();
                string month = parameters[3].Trim();
                string link = parameters[4].Trim();
                string img = parameters[5].Trim();
                Console.WriteLine("LINE ------>>> {0}{1}{2}", title, link, img);
                allComics.Add(new ComicBook(i, title, pub, day, month, link, img));
                i++;
            }
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
