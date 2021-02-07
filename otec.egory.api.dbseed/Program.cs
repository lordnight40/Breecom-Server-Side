using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using otec.egory.api.dto;

namespace otec.egory.api.dbseed
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new DataContext(options => options.);
        }
    }
}