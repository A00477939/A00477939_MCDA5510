using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Assignment1;
using System.Diagnostics;

namespace ProgAssign1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            List<MyCsvStructure> data = new List<MyCsvStructure>();
            List<MyCsvStructure> corruptdata = new List<MyCsvStructure>();
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
            csvConfig.MissingFieldFound = null; 
            csvConfig.HeaderValidated = null;
            int curr = 0;
            int incurr = 0;


            DirWalker dirWalker = new DirWalker();
            List<string> files = dirWalker.Walk("/Users/hrithikarora/Documents/SMU/Assignment/net assignment/Sample Data/");
            string outputfile = @"/Users/hrithikarora/Documents/SMU/Assignment/net assignment/ProgAssign1/Output/out.csv";
            string logfile = @"/Users/hrithikarora/Documents/SMU/Assignment/net assignment/ProgAssign1/Log/log.txt";

            foreach (string csvFilePath in files)
            {
                if (Path.GetExtension(csvFilePath).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(csvFilePath);
                    using var reader = new StreamReader(csvFilePath);
                    using var csv = new CsvReader(reader, csvConfig); 
                    var records = csv.GetRecords<MyCsvStructure>();

                    string[] folderParts = csvFilePath.Split(Path.DirectorySeparatorChar);
                    string datePart = folderParts[^4] + "/" + folderParts[^3] + "/" + folderParts[^2] ; 
                    foreach (var record in records)
                    {
                        record.Date = datePart;

                        if (DataValidator.ValidateData(record))
                        {
                            data.Add(record);
                            curr++;
                        }
                        else
                        {
                            corruptdata.Add(record);
                            incurr++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter(outputfile))
            using (var csvOut = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csvOut.WriteRecords(data);
            }

            using (var errorWriter = new StreamWriter(logfile))
            {
                foreach (var record in corruptdata)
                {
                    errorWriter.WriteLine($"Invalid data: {record.FirstName}, {record.LastName}, {record.StreetNumber}, {record.Street} , {record.City}, {record.Province},{record.PostalCode}, {record.Country},{record.PhoneNumber}, {record.EmailAddress},{record.Date}");
                

                }
                errorWriter.WriteLine($"Correct data: {curr}");
                errorWriter.WriteLine($"InCorrect data: {incurr}");
                stopwatch.Stop();
                TimeSpan elapsed = stopwatch.Elapsed;
                errorWriter.WriteLine($"Time: {elapsed}");
            }


        }
     


    }
}
