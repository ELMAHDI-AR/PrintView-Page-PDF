using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrintViewPDF.Controllers
{
    public class CustomerController : Controller
    {
        //DbPrintPDFEntities
        // GET: Customer
        public ActionResult Index()
        {
            using (DbPrintPDFEntities db = new DbPrintPDFEntities())
            {
                var customerList = db.Customers.ToList();

                return View(customerList);
            }
        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }


        public ActionResult DetailCustomer(int idCustomer)
        {
            using (DbPrintPDFEntities db = new DbPrintPDFEntities())
            {
                Customer customer = db.Customers.FirstOrDefault(c => c.CustomerId == idCustomer);
                return PartialView("~/Views/Shared/DetailCustomer.cshtml", customer);
            }
        }

        public ActionResult PrintPartialViewToPdf(int id)
        {
            using (DbPrintPDFEntities db = new DbPrintPDFEntities())
            {
                Customer customer = db.Customers.FirstOrDefault(c => c.CustomerId == id);

                var report = new PartialViewAsPdf("~/Views/Shared/DetailCustomer.cshtml", customer);
                return report;
            }
           
        }
    }
}