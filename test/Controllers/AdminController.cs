using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.Data;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region // Slider

        public ActionResult Slider()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var slider = context.Slider.ToList();
                return View(slider);
            }
        }
        public ActionResult SlideEkle()
        {
            return View();
        }
        public ActionResult SlideDuzenle(int SlideID)
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var _slideDuzenle = context.Slider.Where(x => x.ID == SlideID).FirstOrDefault();
                return View(_slideDuzenle);
            }
        }
        public ActionResult SlideSil(int SlideID)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    context.Slider.Remove(context.Slider.First(d => d.ID == SlideID));
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult SlideEkle(Slider s, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    Slider _slide = new Slider();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _slide.SliderFoto = memoryStream.ToArray();
                    }
                    _slide.SliderText = s.SliderText;
                    _slide.BaslangicTarih = s.BaslangicTarih;
                    _slide.BitisTarih = s.BitisTarih;
                    context.Slider.Add(_slide);
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult SlideDuzenle(Slider slide, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    var _slideDuzenle = context.Slider.Where(x => x.ID == slide.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _slideDuzenle.SliderFoto = memoryStream.ToArray();
                    }
                    _slideDuzenle.SliderText = slide.SliderText;
                    _slideDuzenle.BaslangicTarih = slide.BaslangicTarih;
                    _slideDuzenle.BitisTarih = slide.BitisTarih;
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        #region // Iletisim

        public ActionResult Iletisim()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var Oneri = context.Oneri.ToList();
                return View(Oneri);
            }
        }
        public ActionResult OneriDetay(int OneriID)
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var _OneriDuzenle = context.Oneri.FirstOrDefault(x => x.ID == OneriID);
                return View(_OneriDuzenle);
            }
        }
        public ActionResult OneriSil(int OneriID)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    context.Oneri.Remove(context.Oneri.First(d => d.ID == OneriID));
                    context.SaveChanges();
                    return RedirectToAction("Iletisim", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult OneriDetay(Oneri oneri, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    var _IletisimDetay = context.Oneri.Where(x => x.ID == oneri.ID).FirstOrDefault();
                    _IletisimDetay.Telefon = oneri.Telefon;
                    context.SaveChanges();
                    return RedirectToAction("Iletisim", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        #region // Istek

        public ActionResult Istek()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var Istek = context.Blog.ToList();
                return View(Istek);
            }
        }
        public ActionResult IstekEkle()
        {
            return View();
        }
        public ActionResult IstekDuzenle(int BlogID)
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var _IstekDuzenle = context.Blog.Where(x => x.ID == BlogID).FirstOrDefault();
                return View(_IstekDuzenle);
            }
        }
        public ActionResult IstekSil(int BlogID)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    context.Blog.Remove(context.Blog.First(d => d.ID == BlogID));
                    context.SaveChanges();
                    return RedirectToAction("Istek", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult IstekEkle(Blog b, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    Blog Istek = new Blog();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        Istek.BlogFoto = memoryStream.ToArray();
                    }
                    Istek.BlogBaslik = b.BlogBaslik;
                    Istek.BlogIcerik = b.BlogIcerik;
                    Istek.Tarih = DateTime.Now;
                    context.Blog.Add(Istek);
                    context.SaveChanges();
                    return RedirectToAction("Istek", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult IstekDuzenle(Blog b, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    var _IstekDuzenle = context.Blog.Where(x => x.ID == b.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _IstekDuzenle.BlogFoto = memoryStream.ToArray();
                    }
                    _IstekDuzenle.BlogBaslik = b.BlogBaslik;
                    _IstekDuzenle.BlogIcerik = b.BlogIcerik;
                    _IstekDuzenle.Tarih = DateTime.Now;
                    context.SaveChanges();
                    return RedirectToAction("Istek", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion

        #region // Oyun

        public ActionResult Oyun()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var Oyun = context.Takim.ToList();
                return View(Oyun);
            }
        }
        public ActionResult OyunEkle()
        {
            return View();
        }
        public ActionResult OyunDuzenle(int OyunID)
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var _OyunDuzenle = context.Takim.Where(x => x.ID == OyunID).FirstOrDefault();
                return View(_OyunDuzenle);
            }
        }
        public ActionResult OyunSil(int OyunID)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    context.Takim.Remove(context.Takim.First(d => d.ID == OyunID));
                    context.SaveChanges();
                    return RedirectToAction("Oyun", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult OyunEkle(Takim t, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    Takim _Oyun = new Takim();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _Oyun.Foto = memoryStream.ToArray();
                    }
                    _Oyun.AdSoyad = t.AdSoyad;
                    _Oyun.Icerik = t.Icerik;
                    _Oyun.Tip = t.Tip;
                    context.Takim.Add(_Oyun);
                    context.SaveChanges();
                    return RedirectToAction("Oyun", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult OyunDuzenle(Takim t, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    var _OyunDuzenle = context.Takim.Where(x => x.ID == t.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _OyunDuzenle.Foto = memoryStream.ToArray();
                    }
                    _OyunDuzenle.AdSoyad = t.AdSoyad;
                    _OyunDuzenle.Icerik = t.Icerik;
                    _OyunDuzenle.Tip = t.Tip;
                    context.SaveChanges();
                    return RedirectToAction("Oyun", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        #region // Haberler

        public ActionResult Haberler()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var Haberler = context.Modul.ToList();
                return View(Haberler);
            }
        }
        public ActionResult HaberEkle()
        {
            return View();
        }
        public ActionResult HaberDuzenle(int ModulID)
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var _HaberDuzenle = context.Modul.Where(x => x.ID == ModulID).FirstOrDefault();
                return View(_HaberDuzenle);
            }
        }
        public ActionResult HaberSil(int ModulID)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    context.Modul.Remove(context.Modul.First(d => d.ID == ModulID));
                    context.SaveChanges();
                    return RedirectToAction("Haberler", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult HaberEkle(Modul m, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    Modul _Haber = new Modul();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _Haber.ModulFoto = memoryStream.ToArray();
                    }
                    _Haber.ModulBaslik = m.ModulBaslik;
                    _Haber.ModulIcerik = m.ModulIcerik;
                    _Haber.Tarih = DateTime.Now;
                    context.Modul.Add(_Haber);
                    context.SaveChanges();
                    return RedirectToAction("Haberler", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult HaberDuzenle(Modul m, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    var _HaberDuzenle = context.Modul.Where(x => x.ID == m.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _HaberDuzenle.ModulFoto = memoryStream.ToArray();
                    }
                    _HaberDuzenle.ModulBaslik = m.ModulBaslik;
                    _HaberDuzenle.ModulIcerik = m.ModulIcerik;
                    _HaberDuzenle.Tarih = DateTime.Now;
                    context.SaveChanges();
                    return RedirectToAction("Haberler", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        #region // Etkinlikler

        public ActionResult Etkinlikler()
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var Etkinlikler = context.Duyuru.ToList();
                return View(Etkinlikler);
            }
        }
        public ActionResult EtkinlikEkle()
        {
            return View();
        }
        public ActionResult EtkinlikDuzenle(int DuyuruID)
        {
            using (MetaGameContext context = new MetaGameContext())
            {
                var _EtkinlikDuzenle = context.Duyuru.Where(x => x.ID == DuyuruID).FirstOrDefault();
                return View(_EtkinlikDuzenle);
            }
        }
        public ActionResult EtkinlikSil(int DuyuruID)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    context.Duyuru.Remove(context.Duyuru.First(d => d.ID == DuyuruID));
                    context.SaveChanges();
                    return RedirectToAction("Etkinlikler", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult EtkinlikEkle(Duyuru d, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    Duyuru _duyuru = new Duyuru();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _duyuru.DuyuruFoto = memoryStream.ToArray();
                    }
                    _duyuru.DuyuruBaslik = d.DuyuruBaslik;
                    _duyuru.DuyuruIcerik = d.DuyuruIcerik;
                    _duyuru.Tarih = DateTime.Now;
                    context.Duyuru.Add(_duyuru);
                    context.SaveChanges();
                    return RedirectToAction("Etkinlikler", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult EtkinlikDuzenle(Duyuru d, HttpPostedFileBase file)
        {
            try
            {
                using (MetaGameContext context = new MetaGameContext())
                {
                    var _etkinlikDuzenle = context.Duyuru.Where(x => x.ID == d.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _etkinlikDuzenle.DuyuruFoto = memoryStream.ToArray();
                    }
                    _etkinlikDuzenle.DuyuruBaslik = d.DuyuruBaslik;
                    _etkinlikDuzenle.DuyuruIcerik = d.DuyuruIcerik;
                    _etkinlikDuzenle.Tarih = DateTime.Now;
                    context.SaveChanges();
                    return RedirectToAction("Etkinlikler", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        
    }
}