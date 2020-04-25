using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Models.Data;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                AnaSayfaDTO anaSayfa = new AnaSayfaDTO();
                anaSayfa.slider = context.Slider.Where(x => (x.BaslangicTarih <= DateTime.Now && x.BitisTarih > DateTime.Now)).ToList();
                anaSayfa.Duyuru = context.Duyuru.OrderByDescending(x=> x.DuyuruTarih).Take(3).ToList();
                anaSayfa.modul = context.Modul.OrderByDescending(x => x.Tarih).Take(3).ToList();
                anaSayfa.takim = context.Takim.OrderByDescending(x => x.ID).Take(3).ToList();

                return View(anaSayfa);
            }
        }
        public ActionResult Haberler()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                List<Modul> Haberler = context.Modul.OrderByDescending(x=> x.Tarih).ToList();
                return View(Haberler);
            }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim";

            return View();
        }
        public ActionResult Events()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                List<Duyuru> Etkinlik = context.Duyuru.OrderBy(x => x.Tarih).ToList();
                return View(Etkinlik);
            }
        }
        public ActionResult EventDetails(int EtkinlikID)
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                Duyuru EventDetay = context.Duyuru.FirstOrDefault(x => x.ID == EtkinlikID);
                return View(EventDetay);
            }
        }
        public ActionResult Games()
        {
            ViewBag.Message = "Oyunlar";

            return View();
        }
        public ActionResult Lol()
        {
            ViewBag.Message = "League Of Legends";

            return View();
        }
        public ActionResult Dn()
        {
            ViewBag.Message = "Dragon Nest";

            return View();
        }
        public ActionResult LolVideo()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                List<Takim> LolVideo = context.Takim.OrderByDescending(x => x.ID).ToList();
                return View(LolVideo);
            }
        }
        public ActionResult LolRehber()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                List<Takim> LolRehber = context.Takim.OrderByDescending(x => x.ID).ToList();
                return View(LolRehber);
            }
        }
        public ActionResult DnVideo()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                List<Takim> DnVideo = context.Takim.OrderByDescending(x => x.ID).ToList();
                return View(DnVideo);
            }
        }
        public ActionResult DnRehber()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                List<Takim> DnRehber = context.Takim.OrderByDescending(x => x.ID).ToList();
                return View(DnRehber);
            }
        }
        public ActionResult Istekler()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                List<Blog> istekler = context.Blog.OrderByDescending(x => x.BlogTarih).ToList();
                return View(istekler);
            }
        }
        [HttpPost]
        public ActionResult Contact(Oneri iletisimform)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    Oneri _iletisimform = new Oneri();
                    _iletisimform.AdSoyad = iletisimform.AdSoyad;
                    _iletisimform.Telefon = iletisimform.Telefon;
                    _iletisimform.Eposta = iletisimform.Eposta;
                    _iletisimform.Mesaj = iletisimform.Mesaj;
                    _iletisimform.Tarih = DateTime.Now;
                    context.Oneri.Add(_iletisimform);
                    context.SaveChanges();
                    TempData["Mesaj"] = "Mesajınız Gönderilmiştir";
                    
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
    public class AnaSayfaDTO
    {
        public List<Slider> slider { get; set; }
        public List<Duyuru> Duyuru { get; set; }
        public List<Blog> blog { get; set; }
        public List<Takim> takim { get; set; }
        public List<Modul> modul { get; set; }
    }
}