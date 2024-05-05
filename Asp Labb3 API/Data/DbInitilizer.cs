using Asp_Labb3_API.Models;

namespace Asp_Labb3_API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.People.Any())
            {
                return;   
            }

            var people = new Person[]
            {
            new Person{Name="Alice", PhoneNumber="123-456-7890"},
            new Person{Name="Bob", PhoneNumber="987-654-3210"},
            new Person{Name="Charlie", PhoneNumber="234-567-8901"},
            new Person{Name="David", PhoneNumber="345-678-9012"},
            new Person{Name="Eva", PhoneNumber="456-789-0123"},
            new Person{Name="Fiona", PhoneNumber="567-890-1234"},
            new Person{Name="George", PhoneNumber="678-901-2345"},
            new Person{Name="Hannah", PhoneNumber="789-012-3456"}
            };

            foreach (Person p in people)
            {
                context.People.Add(p);
            }
            context.SaveChanges();

            var interests = new Interest[]
            {
            new Interest{Title="Reading", Description="Books and literature"},
            new Interest{Title="Hiking", Description="Exploring trails"},
            new Interest{Title="Gaming", Description="Video and board games"},
            new Interest{Title="Cooking", Description="Discovering recipes and techniques"},
            new Interest{Title="Traveling", Description="Visiting new countries and cultures"},
            new Interest{Title="Photography", Description="Taking and editing photos"},
            new Interest{Title="Music", Description="Playing instruments and listening to music"},
            new Interest{Title="Gardening", Description="Cultivating plants and vegetables"}
            };

            foreach (Interest i in interests)
            {
                context.Interests.Add(i);
            }
            context.SaveChanges();

            var personInterests = new PersonInterest[]
            {
            new PersonInterest{PersonId=1, InterestId=1},
            new PersonInterest{PersonId=1, InterestId=2},
            new PersonInterest{PersonId=2, InterestId=3},
            new PersonInterest{PersonId=2, InterestId=4},
            new PersonInterest{PersonId=3, InterestId=5},
            new PersonInterest{PersonId=4, InterestId=6},
            new PersonInterest{PersonId=5, InterestId=7},
            new PersonInterest{PersonId=6, InterestId=8},
            new PersonInterest{PersonId=7, InterestId=1},
            new PersonInterest{PersonId=8, InterestId=2}
            };

            foreach (PersonInterest pi in personInterests)
            {
                context.PersonInterests.Add(pi);
            }
            context.SaveChanges();

            var interestLinks = new InterestLink[]
            {
            new InterestLink{InterestId=1, PersonId=1, URL="https://www.wikihow.com/Teach-Yourself-to-Read"},
            new InterestLink{InterestId=2, PersonId=2, URL="https://www.wikihow.com/Hike"},
            new InterestLink{InterestId=3, PersonId=3, URL="https://www.wikihow.com/Play-Video-Games"},
            new InterestLink{InterestId=4, PersonId=4, URL="https://www.wikihow.com/Cook"},
            new InterestLink{InterestId=5, PersonId=5, URL="https://www.wikihow.com/Travel"},
            new InterestLink{InterestId=6, PersonId=6, URL="https://www.wikihow.com/Start-Doing-Photography"},
            new InterestLink{InterestId=7, PersonId=7, URL="https://www.wikihow.com/Write-a-Musical"},
            new InterestLink{InterestId=8, PersonId=8, URL="https://www.wikihow.com/Garden"}
            };

            foreach (InterestLink il in interestLinks)
            {
                context.InterestLinks.Add(il);
            }
            context.SaveChanges();
        }
    }

}
