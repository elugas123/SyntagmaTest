﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ninja.model.Entity;
using ninja.model.Manager;

namespace ninja.test {

    [TestClass]
    public class TestInvoice {

        [TestMethod]
        public void InsertNewInvoice() {

            InvoiceManager manager = new InvoiceManager();
            long id = 1006;
            Invoice invoice = new Invoice() {
                Id = id,
                Type = Invoice.Types.A.ToString()
            };

            manager.Insert(invoice);
            Invoice result = manager.GetById(id);

            Assert.AreEqual(invoice, result);

        }

        [TestMethod]
        public void InsertNewDetailInvoice()
        {
            InvoiceManager manager = new InvoiceManager();
            long id = 1007;
            Invoice invoice = new Invoice() {
                Id = id,
                Type = Invoice.Types.A.ToString()
            };

            invoice.AddDetail(new InvoiceDetail() {
                Id = id,
                InvoiceId = id,
                Description = "Venta insumos varios",
                Amount = 14,
                UnitPrice = 4.33
            });

            invoice.AddDetail(new InvoiceDetail() {
                Id = id,
                InvoiceId = 6,
                Description = "Venta insumos tóner",
                Amount = 5,
                UnitPrice = 87
            });

            manager.Insert(invoice);
            Invoice result = manager.GetById(id);

            Assert.AreEqual(invoice, result);
        }

        [TestMethod]
        public void DeleteInvoice()
        {
            long id = 1003;
            InvoiceManager manager = new InvoiceManager();
            if (manager.Exists(1003))
            {
                manager.Delete(1003);
                Assert.AreEqual(false, manager.Exists(1003));
            }
        }

        [TestMethod]
        public void UpdateInvoiceDetail() {

            long id = 1002;
            InvoiceManager manager = new InvoiceManager();
            IList<InvoiceDetail> detail = new List<InvoiceDetail>();

            detail.Add(new InvoiceDetail() {
                Id = 1,
                InvoiceId = id,
                Description = "Venta insumos varios",
                Amount = 14,
                UnitPrice = 4.33
            });

            detail.Add(new InvoiceDetail() {
                Id = 2,
                InvoiceId = id,
                Description = "Venta insumos tóner",
                Amount = 5,
                UnitPrice = 87
            });

            manager.UpdateDetail(id, detail);
            Invoice result = manager.GetById(id);

            Assert.AreEqual(2, result.GetDetail().Count());

        }

        [TestMethod]
        public void CalculateInvoiceTotalPriceWithTaxes() {

            long id = 1003;
            InvoiceManager manager = new InvoiceManager();
            Invoice invoice = manager.GetById(id);

            double sum = 0;
            if (invoice != null)
            {
                foreach (InvoiceDetail item in invoice.GetDetail())
                    sum += item.TotalPrice * item.Taxes;

                Assert.AreEqual(sum, invoice.CalculateInvoiceTotalPriceWithTaxes());
            }
        }

    }

}