using MelonFinanceHelper.Data;
using MelonFinanceHelper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace MelonFinanceHelper.Controllers
{
    public class TransactionController : Controller
    {
        private readonly AppDbContext _appDb;

        public TransactionController(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        [HttpGet]
        public IActionResult CreateTransaction()
        {
            ViewBag.AllTransactions = _appDb.transactions.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateTransaction(string comment, string category, string type, string date, int money)
        {
            Transaction transaction = new Transaction()
            {
                comment = comment,
                category = category,
                type = type,
                date = date,
                money = money
            };

            Info.total += money;

            _appDb.transactions.Add(transaction);
            _appDb.SaveChanges();


            return RedirectToAction("AllTransactions", "Transaction");
        }

        [HttpPost]
        public IActionResult DeleteTransaction(int id)
        {
            var transaction = _appDb.transactions.Find(id);

            _appDb.transactions.Remove(transaction);

            _appDb.SaveChanges();

            return RedirectToAction("AllTransactions", "Transaction");
        }

        [HttpGet]
        public IActionResult AllTransactions()
        {

            var transactions = _appDb.transactions.ToList();
            ViewBag.AllTransactions = transactions;
            return View(transactions);
        }


        [HttpGet]
        public async Task<FileResult> DownloadCsv()
        {
            var records = await _appDb.transactions.ToListAsync();

            var stringBuilder = new StringBuilder();


            stringBuilder.AppendLine("Id,category,type,data,comment,money");

            foreach (var record in records)
            {
                var category = record.category.Replace(",", ";");
                var type = record.type.Replace(",", ";");
                var data = record.date.Replace(",", ";");
                var description = record.comment.Replace(",", ";");
                var money = record.money.ToString().Replace(",", ";");


                stringBuilder.AppendLine($"{record.Id},{category},{description},{data},{type},{money}");
            }



            var fileBytes = Encoding.UTF8.GetPreamble()
                .Concat(Encoding.UTF8.GetBytes(stringBuilder.ToString()))
                .ToArray();
            string fileName = "data_export.csv";

            return File(fileBytes, "text/csv", fileName);
        }

    }
}
