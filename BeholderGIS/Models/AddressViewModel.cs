using AutoMapper;
using BeholderGIS.Infrastructure;
using Domain;
using System;
using System.Linq;
using System.Text;

namespace BeholderGIS.Models
{
    public class AddressViewModel : IMapFrom<Address>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public int? StateId { get; set; }
        public string StateCode { get; set; }
        public string Zip5 { get; set; }

        public string Zip4 { get; set; }
        public string Zipcode => $"{Zip5}-{Zip4}";
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public DateTime? DateModified { get; set; }
        public int? ModifiedUserId { get; set; }

        public override string ToString()
        {
            string[] arr = { Address1 + " " + Address2, City, StateCode, Zip5 };

            return string.Join(", ", arr.Where(s => !string.IsNullOrWhiteSpace(s)).Select(x => x.Trim()));

        }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Address, AddressViewModel>()
                .ForMember(d => d.StateCode, opt => opt.MapFrom(s => s.State.StateCode)).ReverseMap();
        }


        //public static String StripUnicodeCharactersFromString(string inputValue)
        //{
        //    return Encoding.ASCII.GetString(Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(Encoding.ASCII.EncodingName, new EncoderReplacementFallback(String.Empty), new DecoderExceptionFallback()), Encoding.UTF8.GetBytes(inputValue)));
        //}
    }
}