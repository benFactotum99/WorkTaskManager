using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Entity;

namespace Shared.Entity.Customers.Req
{
    public class CustomerReq
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? MobilePhone { get; set; }

        public string? Alias { get; set; }
    }

    public static class CustomerReqMap
    {
        public static Customer MapDto(this CustomerReq value) => MapDto(value, new());
        public static Customer MapDto(this CustomerReq value, Customer element)
        {
            element.Name = value.Name;
            element.Email = value.Email;
            element.Phone = value.Phone;
            element.MobilePhone = value.MobilePhone;
            element.Alias = value.Alias;
            return element;
        }
    }    
}
