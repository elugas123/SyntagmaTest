using System.Linq;
using System.Web.Mvc;
using ninja.model.Manager;
using ninja.model.Entity;

namespace ninja.Controllers
{
    public class InvoiceController : Controller
    {
        InvoiceManager manager = new InvoiceManager();
        
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        public ActionResult Detail(long Id)
        {
            ViewBag.IdInvoice = Id;
            return View(manager.GetById(Id).GetDetail());
        }

        public ActionResult CreateInvoice()
        {
            return View();
        }

        public ActionResult NewInvoice(Invoice item)
        {
            if (item != null)
                manager.Insert(item);
            return Redirect("Index");
        }

        public ActionResult Delete(long Id)
        {
            manager.Delete(Id);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult DeleteDetail(long Id, long InvoiceId)
        {
            manager.DeleteDetail(manager.GetById(InvoiceId).GetDetail().First(x => x.Id == Id));
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Update(long Id)
        {
            return View(manager.GetById(Id));
        }

        public ActionResult UpdateInvoice(Invoice item)
        {
            manager.Update(item);
            return Redirect("Index");
        }

        public ActionResult UpdateAddDetail(long Id, long InvoiceId)
        {
            return View(manager.GetById(InvoiceId).GetDetail().First(x => x.Id == Id));
        }

        public ActionResult UpdateDetail(InvoiceDetail item)
        {
            manager.UpdateDetail(item);
            return RedirectToAction("Detail", new { Id = item.InvoiceId});
        }

        public ActionResult AddDetail(long Id)
        {
            return View(new InvoiceDetail() { InvoiceId = Id });
        }

        public ActionResult AddInvoiceDetail(InvoiceDetail item)
        {
            manager.AddInvoiceDetail(item);
            return RedirectToAction("Detail", new { Id = item.InvoiceId });
        }
    }
}


