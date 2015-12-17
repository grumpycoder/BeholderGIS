using AutoMapper;
using AutoMapper.QueryableExtensions;
using BeholderGIS.Helpers;
using BeholderGIS.Models;
using CsvHelper;
using Domain;
using EntityFramework.Utilities;
using GeocodeSharp.Google;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeholderGIS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            AutoMapperConfig.Execute();
            var db = new AppDbContext();
            //BEGIN FILTER

            var pred = PredicateBuilder.True<Address>();
            pred = pred.And(x => x.StateId != null && x.State.StateCode != "IE");
            pred = pred.And(x => x.City != null &&
                                 !x.City.ToLower().Contains("Statewide") &&
                                 !x.City.ToLower().Contains("unknown") &&
                                 !x.City.ToLower().Contains("incomplete") &&
                                 x.City.ToLower() != "unkn" &&
                                 x.City.ToLower() != "unk" &&
                                 x.City.ToLower() != "misc" &&
                                 !x.City.ToLower().Contains("unspecified") &&
                                 !x.City.ToLower().Contains("area")
                                 );
            pred = pred.And(x => x.Latitude == null);
            pred = pred.And(x => x.AddressChapterRels.Count > 0);

            //pred = pred.And(x => x.Id == 7998);
            //pred = pred.And(x => x.County != null);
            //pred = pred.And(x => x.Address1 != null);
            //pred = pred.And(x => x.Zip5 == null);

            //END FILTER

            var list =
                db.Addresses.Include("State")
                    .Where(pred)
                    .OrderBy(x => x.Id)
                    //.Take(250)
                    .ProjectTo<AddressViewModel>()
                    .ToList();

            var recordCount = db.Addresses.Include("State").Where(pred).OrderBy(x => x.Id).Count();
            TextWriter textwriter = File.CreateText(@"C:\temp\beholder-addresslist.csv");
            var currentDate = DateTime.Now;

            var counter = 0;
            var currentRecord = 0;
            foreach (var vm in list)
            {
                currentRecord += 1;
                counter += 1;
                Console.WriteLine($"{currentRecord} of {recordCount}");
                Console.WriteLine($"RecordId: {vm.Id} - Updating");

                //if (vm.City != null)
                //{
                //    //var s = vm.Address1.Humanize(LetterCasing.Title);
                //    var s = vm.City.Humanize(LetterCasing.Title);
                //    Console.WriteLine($"Before: {vm.City}");
                //    Console.WriteLine($"After: {s}");
                //    if (!vm.City.Equals(s))
                //    {
                //        //vm.City = s;
                //        vm.City = s;
                //        Debug.WriteLine(s);
                //    }
                //}

                try
                {
                    var result = GetLocation(vm);
                    if (result.Result != null)
                    {
                        vm.Latitude = (decimal)result.Result.Geometry.Location.Latitude;
                        vm.Longitude = (decimal)result.Result.Geometry.Location.Longitude;
                    }

                    vm.DateModified = currentDate;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (counter != 10) continue;
                //Sleep 2 seconds not to exceed limit of 10 per second. 
                Thread.Sleep(2000);
                counter = 0;
            }

            using (var csv = new CsvWriter(textwriter))
            {
                csv.WriteRecords(list);
            }

            var addresses = Mapper.Map<List<AddressViewModel>, List<Address>>(list);


            //EFBatchOperation.For(db, db.Addresses).UpdateAll(addresses, a => a.ColumnsToUpdate(x => x.City, x => x.County, x => x.Address1, x => x.Address2));
            EFBatchOperation.For(db, db.Addresses).UpdateAll(addresses, a => a.ColumnsToUpdate(x => x.Latitude, x => x.Longitude, x => x.DateModified));

            Console.WriteLine($"Records: {recordCount}");
            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        private static async Task<GeocodeResult> GetLocation(AddressViewModel vm)
        {
            var addr = vm.ToString();
            //if (vm.Address1.ToLower().Contains("box"))
            //{
            addr = $"{vm.City}, {vm.StateCode}, {vm.Zip5}";
            //}
            var client = new GeocodeClient("AIzaSyB0KEXycmRe-D901682pcwkE3GsKIVUxTg");
            var response = await client.GeocodeAddress(addr);
            if (response.Status != GeocodeStatus.Ok) return null;

            var firstResult = response.Results.First();
            return firstResult;
        }

        private static async Task<GeocodeResult> GetLocation(string address)
        {
            var client = new GeocodeClient();
            var response = await client.GeocodeAddress(address);
            if (response.Status != GeocodeStatus.Ok) return null;

            var firstResult = response.Results.First();
            return firstResult;
        }

    }
}
