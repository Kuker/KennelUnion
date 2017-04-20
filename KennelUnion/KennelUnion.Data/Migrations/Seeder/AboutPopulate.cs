using KennelUnion.Data.Entities;
using KennelUnion.Data.Repositories;
using System;

namespace KennelUnion.Data.Migrations
{
    class AboutPopulate : IDBSeedHelper
    {
        private IRepository<About> _aboutRepo;

        public AboutPopulate(IRepository<About> aboutRepo)
        {
            _aboutRepo = aboutRepo;
        }

        public void Seed()
        {
            var news = new About
            {
                Content = "This is default page.",
                CreatedOn = DateTime.Now
            };
            _aboutRepo.Add(news);
            _aboutRepo.Save();
        }
    }
}