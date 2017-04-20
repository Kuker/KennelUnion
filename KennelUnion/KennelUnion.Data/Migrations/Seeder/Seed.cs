using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using KennelUnion.Data.Repositories;

namespace KennelUnion.Data.Migrations
{
    public class Seed
    {
        private IRepository<News> _newsRepo;
        private IRepository<About> _aboutRepo;

        public Seed(IRepository<News> newsRepo, IRepository<About> aboutRepo)
        {
            _newsRepo = newsRepo;
            _aboutRepo = aboutRepo;
        }

        public void PopulateDb()
        {
            List<IDBSeedHelper> entriesToPopulate = new List<IDBSeedHelper>()
            {
                new NewsPopulate(_newsRepo), new AboutPopulate(_aboutRepo)
            };
            entriesToPopulate.ForEach(h => h.Seed());
        }
    }
}
