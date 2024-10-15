
using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SalesController : Controller
{
    public IActionResult Index()
    {
        var sales = new List<Sale>();

        string filePath = "Data/SalesData.csv"; 

        if (System.IO.File.Exists(filePath))
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                sales = csv.GetRecords<Sale>().ToList();
            }
        }

        return View(sales);
    }
}
