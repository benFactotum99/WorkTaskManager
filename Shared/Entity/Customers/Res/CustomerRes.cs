using Infrastructure.Persistence.Entity;
using Newtonsoft.Json.Linq;
using Shared.Entity.Customers.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Customers.Res
{
    public class CustomerRes
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? MobilePhone { get; set; }

        public string? Alias { get; set; }
    }

    public static class CustomerResMap
    {
        public static Customer MapDto(this CustomerRes value) => MapDto(value, new());
        public static Customer MapDto(this CustomerRes value, Customer element)
        {
            element.Id = value.Id;
            element.Name = value.Name;
            element.Email = value.Email;
            element.Phone = value.Phone;
            element.MobilePhone = value.MobilePhone;
            element.Alias = value.Alias;
            return element;
        }

        public static CustomerReq MapToReqDto(this CustomerRes value) => MapToReqDto(value, new CustomerReq());
        public static CustomerReq MapToReqDto(this CustomerRes value, CustomerReq element)
        {
            element.Name = value.Name;
            element.Email = value.Email;
            element.Phone = value.Phone;
            element.MobilePhone = value.MobilePhone;
            element.Alias = value.Alias;
            return element;
        }

        public static CustomerRes MapDto(this Customer element)
        {
            return new CustomerRes
            {
                Id = element.Id,
                Name = element.Name,
                Email = element.Email,
                Phone = element.Phone,
                MobilePhone = element.MobilePhone,
                Alias = element.Alias
            };
        }

        public static List<CustomerRes> MapDto(this List<Customer> values)
        {
            List<CustomerRes> res = new();
            for (int i = 0; i < values.Count(); i++) { res.Add(values[i].MapDto()); };
            return res;
        }
    }
}
