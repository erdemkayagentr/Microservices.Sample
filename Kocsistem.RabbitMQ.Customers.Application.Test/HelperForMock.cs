using Kocsistem.RabbitMQ.Customers.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Kocsistem.RabbitMQ.Customers.Application.Test
{
    public static class HelperForMock
    {
        public static IEnumerable<CustomersTable> GetMockDatas()
        {
            return new List<CustomersTable>
            {
               new CustomersTable
               {
                   Id = Guid.Parse("6449145e-d9a4-4309-8775-984933824bbc"),
                   Email ="mail@erdemkaya.gen.tr",
                   FullName ="Erdem Kaya"
               },
               new CustomersTable
               {
                   Id = Guid.Parse("64e194fb-247b-4423-87f1-ffa5f56e782a"),
                   Email ="sendeo@erdemkaya.gen.tr",
                   FullName ="Sendeo"
               }
            };
        }
    }
}
