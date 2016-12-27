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

        public Seed(IRepository<News> newsRepo)
        {
            _newsRepo = newsRepo;
        }

        public void PopulateDb()
        {
            var random = new Random();
            var titles =
                "esthetically kohima titrating psalterium hyperdeify krumhorn pilgrimage vituperated cageling nonnihilistic laterality moldavite. Mabel painfully preprovoked helyne dowmetal tenn smackeroo bruegel magnetograph unguiculate conversus bin obstructionistic manchoukuo. Achondroplasia vocabularies papillar swinishly pyrochemical amoraim photoproton errand sudetes infantlike andes instate superfantastic dupr. Undeserted wis geometrise peachiness scapularies concubinage nonexaggerating via imbue tropophilous irreconcilability redisburse snickersnee projectional. Osculum jugginses hyoidal dou guadiana inerrant congeries rudderpost unpatriotically incise multirole glamorization necrotomy blazer.\r\n\r\nPrediscourse axletree unmarring conceivability kinchin prothallus celestial proserpine theorize moo sejant canaliculus read epigastrium. Fecundate methadone elliptic shredless lawbook serviceably erbil sander regirded abdicative proimmigration torc diesis incorporated. Antirevolution epiphysis drer outdrawing pursy manucode risotto triazole trumpless sinecurism enlightenment chandui dakhla subumbonate. Chesstree achan macrostomatous hoariest phenomena dilettantism micropyle pseudosemantically degressively prechoice pusillanimous underwatcher versifying conjunctionally. Allergen monteith ballocks clowneries blowsily tenches atonic echt squabby broadax unmended britannia sequestral heartland. Challahs concoction leucorrheal hemichordate zacatecas patella barotropic ghastlily rom lacerable bartonville cardiography lover kiwanian. Subtriangulate thirdly overinflate calles enlarge saltishly irremeably professor irreplevisable maternalized ciboria dyspepsy nonpracticableness unmew. Charro mesmerizer propylaeum snaky stellular earwitness pregrading irremissibleness wyo nonfluid privatdozent pussier proconsulship brosy. Semiparasitism fleshliest stimulater briza pele i\'\'d outtear zonked translator dora robustly roweled nonconstraining unconcernedly. Unparked belton recodifying nonprolific eurasia aegicores chiromantical pollyfish premiated siderostat acaricidal lee perkier zabaglione.";
            var titlesSeparated = titles.Split(' ');

            var max = titlesSeparated.Length;
            for (var i = 0; i < 100; i++)
            {
                string randomBody = string.Empty;
                for (var j = 0; j < 50; j++)
                    randomBody += titlesSeparated[random.Next(max)] + " ";
                var news = new News
                {
                    Title =
                        titlesSeparated[random.Next(max)] + " " +  titlesSeparated[random.Next(max)] + " " +
                        titlesSeparated[random.Next(max)],
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    Body = randomBody,
                    Preview = randomBody.Substring(0, 100)
                };
                _newsRepo.Add(news);
            }
            _newsRepo.Save();
        }
    }
}
