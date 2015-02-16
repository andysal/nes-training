﻿using System;
using Bookings.Domain.BookingContenxt;
using Bookings.Domain.BookingContenxt.Events;
using Machine.Specifications;

namespace Bookings.Tests.DomainTests
{
    [Subject("Resource")]
    public class quando_la_prendo
    {
        static readonly Guid _id = new Guid("4534C386-5284-4203-9AA3-87B60A172764");
        static Resource resource;

        Establish context = () =>
            {
                resource = new Resource(_id, "MacBook Pro 13\"");
            };

        Because of = () =>
            {
                resource.Lend();
            };

        // transizioni di stato
        It questa_diventa_presa = () => 
            resource.Lent.ShouldBeTrue();

        // eventi
        It l_evento_di_presa_e_stato_scatenato = () => 
            resource.ShouldHadRaised<ResourceLent>();
    }
}