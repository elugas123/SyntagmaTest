using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ninja.model.Entity;
using ninja.model.Mock;

namespace ninja.model.Manager {

    public class InvoiceManager {

        private InvoiceMock _mock;

        public InvoiceManager() {

            this._mock = InvoiceMock.GetInstance();

        }

        public IList<Invoice> GetAll() {

            return this._mock.GetAll();

        }

        public Invoice GetById(long id) {

            return this._mock.GetById(id);

        }

        public void Insert(Invoice item) {

            this._mock.Insert(item);

        }

        public void Delete(long id)
        {
            Invoice invoice = this.GetById(id);
            this._mock.Delete(invoice);
        }

        public Boolean Exists(long id)
        {
            return this._mock.Exists(id);
        }

        public void AddDetail(long id, IList<InvoiceDetail> detail)
        {
            this._mock.AddDetail(id, detail);
        }

        public void UpdateDetail(InvoiceDetail item)
        { 
            this._mock.UpdateDetail(item);
        }

        public void Update(Invoice item)
        {
            this._mock.Update(item);
        }

        public void UpdateDetail(long id, IList<InvoiceDetail> detail)
        {
            this._mock.DeleteDetails(id);
            this._mock.AddDetail(id, detail);
        }

        public void DeleteDetail(InvoiceDetail item)
        {
            this._mock.DeleteDetail(item);
        }

        public void AddInvoiceDetail(InvoiceDetail item)
        {
            this._mock.AddInvoiceDetail(item);
        }
    }
}