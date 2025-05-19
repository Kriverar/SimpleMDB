using System.Reflection.Metadata;

namespace SimpleMDB;

public class MockActorRepository : IActorRepository
{
    private List<Actor> actors;
    private int idCount;

    public MockActorRepository()
    {
        actors = new List<Actor>();
        idCount = 0;

        string[] firstNames = new[]
        {
            "Leonardo", "Scarlett", "Denzel", "Meryl", "Tom", "Natalie", "Brad", "Angelina", "Johnny", "Jennifer",
            "Robert", "Emma", "Morgan", "Kate", "Chris", "Anne", "Samuel", "Julia", "Keanu", "Viola",
            "Ryan", "Charlize", "Will", "Nicole", "Christian", "Amy", "Matt", "Cate", "Hugh", "Rachel",
            "Benedict", "Sandra", "Mark", "Zendaya", "Jake", "Emily", "Daniel", "Gal", "Michael", "Reese",
            "Timothée", "Florence", "Jason", "Zoe", "Andrew", "Margot", "Tobey", "Jodie", "Idris", "Kristen",
            "Paul", "Natalia", "Javier", "Salma", "Cillian", "Anya", "Pedro", "Millie", "Chadwick", "Daisy",
            "Joseph", "Alicia", "Mahershala", "Gugu", "Ewan", "Saoirse", "Donald", "Helena", "Rami", "Tessa",
            "Dev", "Karen", "Forest", "Emily", "Jeremy", "Elizabeth", "Tom", "Daniel", "Rosamund", "Oscar",
            "David", "Emma", "Ben", "Jessica", "Logan", "Mads", "John", "Tilda", "Willem", "Dakota",
            "Lupita", "Bill", "Ethan", "Maisie", "Josh", "Robin", "Kerry", "Chris", "Anthony", "Angela"
        };

        string[] lastNames = new[]
        {
            "DiCaprio", "Johansson", "Washington", "Streep", "Hanks", "Portman", "Pitt", "Jolie", "Depp", "Lawrence",
            "Downey", "Watson", "Freeman", "Winslet", "Hemsworth", "Hathaway", "Jackson", "Roberts", "Reeves", "Davis",
            "Gosling", "Theron", "Smith", "Kidman", "Bale", "Adams", "Damon", "Blanchett", "Jackman", "McAdams",
            "Cumberbatch", "Bullock", "Ruffalo", "Coleman", "Gyllenhaal", "Blunt", "Radcliffe", "Gadot", "Fassbender", "Witherspoon",
            "Chalamet", "Pugh", "Momoa", "Kravitz", "Garfield", "Robbie", "Maguire", "Foster", "Elba", "Stewart",
            "Rudd", "Dyer", "Bardem", "Hayek", "Murphy", "Taylor-Joy", "Pascal", "Brown", "Boseman", "Ridley",
            "Gordon-Levitt", "Vikander", "Ali", "Mbatha-Raw", "McGregor", "Ronan", "Glover", "Bonham Carter", "Malek", "Thompson",
            "Patel", "Gillan", "Whitaker", "Deschanel", "Renner", "Olsen", "Hiddleston", "Kaluuya", "Pike", "Isaac",
            "Harbour", "Stone", "Affleck", "Chastain", "Lerman", "Mikkelsen", "Boyega", "Swinton", "Dafoe", "Johnson",
            "Nyong'o", "Skarsgård", "Hawke", "Williams", "Hutcherson", "Wright", "Washington", "Pratt", "Hopkins", "Bassett"
        };

        var highlights = new[]
        {
            "drama and action films",
            "comedies and musicals",
            "independent art-house features",
            "television drama series",
            "blockbuster sci-fi movies",
            "thriller and horror genres",
            "historical biopics",
            "romantic comedies",
            "animated feature films",
            "stage and screen productions"
        };

        var random = new Random();

        for (int i = 0; i < firstNames.Length; i++)
        {
            float rating = (float)Math.Round(random.NextDouble() * 10, 1);
            string career = highlights[i % highlights.Length];
            string bio = $"{firstNames[i]} {lastNames[i]} is an actor known for their work in {career}.";
            actors.Add(new Actor(idCount++, firstNames[i], lastNames[i], bio, rating));
        }
    }

    public async Task<PagedResult<Actor>> ReadAll(int page, int size)
    {
        int totalCount = actors.Count;
        int start = Math.Clamp((page - 1) * size, 0, totalCount);
        int length = Math.Clamp(size, 0, totalCount - start);
        List<Actor> values = actors.Skip(start).Take(length).ToList();
        return await Task.FromResult(new PagedResult<Actor>(values, totalCount));
    }

    public async Task<Actor?> Create(Actor newActor)
    {
        newActor.Id = idCount++;
        actors.Add(newActor);
        return await Task.FromResult(newActor);
    }

    public async Task<Actor?> Read(int id)
    {
        Actor? actor = actors.FirstOrDefault(u => u.Id == id);
        return await Task.FromResult(actor);
    }

    public async Task<Actor?> Update(int id, Actor newActor)
    {
        Actor? actor = actors.FirstOrDefault(u => u.Id == id);
        if (actor != null)
        {
            actor.FirstName = newActor.FirstName;
            actor.LastName = newActor.LastName;
            actor.Bio = newActor.Bio;
            actor.Rating = newActor.Rating;
        }
        return await Task.FromResult(actor);
    }

    public async Task<Actor?> Delete(int id)
    {
        Actor? actor = actors.FirstOrDefault(u => u.Id == id);
        if (actor != null)
        {
            actors.Remove(actor);
        }
        return await Task.FromResult(actor);
    }
}