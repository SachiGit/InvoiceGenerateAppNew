using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoiceGenerateAppNew.Data;
using InvoiceGenerateAppNew.Models;
using Microsoft.VisualBasic;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace InvoiceGenerateAppNew.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public string CusName { get; private set; }
        public DateOnly TransactionDate { get; private set; }

        public InvoiceDetailsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: InvoiceDetails
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.InvoiceDetails.Include(i => i.Product);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: InvoiceDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.InvoiceDetails
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.InvoiceID == id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", "ProductPrice");
            return View();
        }

        // POST: InvoiceDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceID,CustomerName,TransDate,Discounts,Qty,TotalAmount,BalanceAmount,ProductId")] InvoiceDetail invoiceDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", invoiceDetail.ProductId);

            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", invoiceDetail.ProductId);
            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceID,CustomerName,TransDate,Discounts,Qty,TotalAmount,BalanceAmount,ProductId")] InvoiceDetail invoiceDetail)
        {
            if (id != invoiceDetail.InvoiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceDetailExists(invoiceDetail.InvoiceID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", invoiceDetail.ProductId);
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.InvoiceDetails
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.InvoiceID == id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceDetail = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetail != null)
            {
                _context.InvoiceDetails.Remove(invoiceDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceDetailExists(int id)
        {
            return _context.InvoiceDetails.Any(e => e.InvoiceID == id);
        }

        // Action method for displaying the invoice
        public ActionResult PrintInvoice(int id)
        {
            // Retrieve invoice data from your data source (e.g., database)
            InvoiceDetail invoice = GetInvoiceById(id, CusName, TransactionDate);
            
            // Pass the invoice data to the view
            return View(invoice);
        }

        // Method to retrieve invoice data (replace this with your data retrieval logic)
        private InvoiceDetail GetInvoiceById(int id, string CusName, DateOnly TransactionDate)
        {
            // Simulated data retrieval, replace with actual implementation
            return new InvoiceDetail
            {
                //ToDo Some Changers...
                InvoiceID = id,
                CustomerName = CusName,
                TransDate = TransactionDate
                 //Populate other properties as needed
            };
        }       
    }
}
