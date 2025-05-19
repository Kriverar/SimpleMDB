using System.Reflection.Metadata;

namespace SimpleMDB;

public class MockMovieRepository : IMovieRepository
{
    private List<Movie> movies;
    private int idCount;

    public MockMovieRepository()
    {
        movies = new List<Movie>();
        idCount = 0;

        string[] titles = new[]
        {
            "Inception", "The Godfather", "Pulp Fiction", "The Dark Knight", "Forrest Gump", "Interstellar", "Gladiator", "Titanic", "The Matrix", "The Shawshank Redemption",
            "Fight Club", "The Lord of the Rings", "The Social Network", "Parasite", "Whiplash", "La La Land", "Avengers: Endgame", "Joker", "Black Panther", "The Revenant",
            "The Silence of the Lambs", "Goodfellas", "The Departed", "No Country for Old Men", "Django Unchained", "The Prestige", "12 Years a Slave", "The Green Mile", "Schindler’s List", "Mad Max: Fury Road",
            "Blade Runner 2049", "Once Upon a Time in Hollywood", "Her", "1917", "Birdman", "Bohemian Rhapsody", "A Beautiful Mind", "Arrival", "Gravity", "The Irishman",
            "The Wolf of Wall Street", "The Grand Budapest Hotel", "The Imitation Game", "Prisoners", "Logan", "Spotlight", "The King’s Speech", "Minari", "Moonlight", "Sound of Metal",
            "Oppenheimer", "Everything Everywhere All At Once", "Knives Out", "The Batman", "Tenet", "Dune", "The Banshees of Inisherin", "CODA", "Drive", "Ex Machina",
            "The Whale", "Marriage Story", "The Farewell", "Jojo Rabbit", "The Shape of Water", "Lady Bird", "The Big Short", "Inside Out", "Soul", "Turning Red",
            "Encanto", "Luca", "Frozen II", "Coco", "Zootopia", "Moana", "Big Hero 6", "The Lego Movie", "Wreck-It Ralph", "Frozen",
            "Up", "Toy Story 3", "Toy Story 4", "Finding Dory", "Finding Nemo", "Wall-E", "Ratatouille", "The Incredibles", "Cars", "Brave",
            "Shrek", "Shrek 2", "Kung Fu Panda", "How to Train Your Dragon", "Megamind", "Despicable Me", "Minions", "The Croods", "Sing", "Trolls"
        };

        int[] years = new[]
        {
            2010, 1972, 1994, 2008, 1994, 2014, 2000, 1997, 1999, 1994,
            1999, 2001, 2010, 2019, 2014, 2016, 2019, 2019, 2018, 2015,
            1991, 1990, 2006, 2007, 2012, 2006, 2013, 1999, 1993, 2015,
            2017, 2019, 2013, 2019, 2014, 2018, 2001, 2016, 2013, 2019,
            2013, 2014, 2014, 2013, 2017, 2015, 2010, 2020, 2016, 2019,
            2023, 2022, 2019, 2022, 2020, 2021, 2022, 2021, 2011, 2015,
            2022, 2019, 2019, 2017, 2018, 2017, 2015, 2015, 2020, 2022,
            2021, 2019, 2017, 2017, 2016, 2014, 2015, 2006, 2011, 2012,
            2010, 2010, 2008, 2016, 2003, 2010, 2013, 2004, 2006, 2012,
            2001, 2004, 2008, 2010, 2017, 2013, 2015, 2020, 2016, 2019
        };

                string[] descriptions = new[]
        {
            "A mind-bending thriller set within the architecture of dreams.",
            "The rise and fall of a powerful family in organized crime.",
            "An intertwining tale of crime, redemption, and fate.",
            "A dark knight battles chaos in a city on the edge.",
            "The heartwarming journey of a man who lived an extraordinary life.",
            "A sci-fi epic exploring love across time and space.",
            "A betrayed general returns as a gladiator for justice.",
            "A tragic love story aboard a doomed ocean liner.",
            "A hacker uncovers a disturbing digital reality.",
            "Hope and friendship blossom in a hopeless prison.",
            "Two identities clash in an underground fight club.",
            "A fellowship’s quest to destroy a ring of power.",
            "The social impact of a tech giant’s origin.",
            "A poor family schemes its way into high society.",
            "A jazz drummer pushes the limits of perfection.",
            "Love and dreams collide on the LA stage.",
            "Earth's mightiest heroes face a universal threat.",
            "A fractured mind spirals into dangerous delusion.",
            "A superhero’s legacy explored through heritage.",
            "A wounded survivor seeks vengeance in the wild.",
            "An FBI trainee faces a brilliant but twisted mind.",
            "The gritty life of New York gangsters exposed.",
            "An undercover cop’s identity game turns deadly.",
            "Two hitmen cross paths in desolate Texas.",
            "A slave becomes a legendary bounty hunter.",
            "Magicians’ rivalry turns deadly in pursuit of fame.",
            "A man’s unbreakable spirit tested under slavery.",
            "An inmate with mystical powers changes lives.",
            "One man’s quiet resistance during the Holocaust.",
            "A fiery desert car chase for survival and hope.",
            "A replicant's search for purpose in a bleak future.",
            "Hollywood's golden past reimagined with style.",
            "A man finds love in artificial intelligence.",
            "A single-shot race to stop a tragedy.",
            "An actor’s internal battle for artistic truth.",
            "The rise of a rock legend and his band.",
            "A genius cracks codes while battling inner demons.",
            "First contact sparks a race to understand.",
            "Survival after a space accident tests the human will.",
            "A mobster reflects on decades of loyalty and crime.",
            "A stockbroker’s reckless pursuit of excess.",
            "A hotel concierge uncovers a deadly conspiracy.",
            "A scientist faces a war-era ethical dilemma.",
            "A father’s rage when his daughters go missing.",
            "A mutant’s final chapter in a brutal world.",
            "Reporters expose institutional corruption in religion.",
            "A king finds strength through overcoming his stammer.",
            "A family chases the American dream in the countryside.",
            "A coming-of-age journey of self-discovery.",
            "A drummer copes with the loss of his hearing.",
            "Time-traveling soldiers must fix history’s mistakes.",
            "A man trapped in a time loop fights aliens.",
            "An AI gains consciousness and questions existence.",
            "An isolated woman finds herself in a spy ring.",
            "A robot and dog team up for survival.",
            "A man’s clone questions his identity and purpose.",
            "A small town's secrets come to light in tragedy.",
            "A detective follows clues in a futuristic city.",
            "An astronaut's mission reveals universal truths.",
            "A failed invention changes the course of war.",
            "An unlikely friendship spans generations.",
            "A cursed painting haunts those who see it.",
            "A high schooler uncovers a supernatural conspiracy.",
            "A family cursed by a generational secret.",
            "A love story set in virtual reality.",
            "A young coder faces off with his creation.",
            "A retired agent comes back for one last job.",
            "A painter's obsession leads to madness.",
            "A scientist travels through time to fix a mistake.",
            "A warrior protects his tribe from invaders.",
            "An explorer finds a city lost to myth.",
            "A child prodigy battles expectations and self-doubt.",
            "An inventor unleashes a creature into the world.",
            "A ghost relives her past in modern times.",
            "A heist crew executes a plan during a blackout.",
            "A detective tracks a killer with a twisted logic.",
            "A group of teens unlock an ancient curse.",
            "An android questions the ethics of humanity.",
            "A writer battles isolation and inspiration.",
            "A submarine crew faces sabotage and betrayal.",
            "An astronaut sacrifices everything to save Earth.",
            "A VR gamer blurs fiction and reality.",
            "A chef builds an empire one dish at a time.",
            "A courtroom trial unravels a national scandal.",
            "A virus transforms the world into chaos.",
            "A woman uncovers a mystery in her dreams.",
            "A team of rogues hunts ancient relics.",
            "A hacker discovers a global mind-control plot.",
            "A prisoner plans the ultimate escape.",
            "A pandemic threatens the fabric of society.",
            "A musical genius reclaims his legacy.",
            "A pilot navigates a sky filled with secrets.",
            "A revolutionary AI learns to feel emotion.",
            "A mountaineer's past catches up on the cliffside.",
            "A secret society manipulates world history.",
            "A legendary sword awakens new heroes.",
            "A dystopian future ruled by memory control.",
            "A haunted forest draws in the curious.",
            "An ancient evil returns through technology.",
            "A race against time to stop the end of days.",
            "An elite team rescues artifacts from war zones.",
            "A love letter to cinema through a magical projector."
        };

        var random = new Random();

        for (int i = 0; i < titles.Length; i++)
        {
            string title = titles[i];
            int year = years[i];
            string description = descriptions[i % descriptions.Length];
            float rating = (float)Math.Round(random.NextDouble() * 10, 1);

            movies.Add(new Movie(idCount++, title, year, description, rating));
        }
    }

    public async Task<PagedResult<Movie>> ReadAll(int page, int size)
    {
        int totalCount = movies.Count;
        int start = Math.Clamp((page - 1) * size, 0, totalCount);
        int length = Math.Clamp(size, 0, totalCount - start);
        List<Movie> values = movies.Skip(start).Take(length).ToList();
        return await Task.FromResult(new PagedResult<Movie>(values, totalCount));
    }

    public async Task<Movie?> Create(Movie newMovie)
    {
        newMovie.Id = idCount++;
        movies.Add(newMovie);
        return await Task.FromResult(newMovie);
    }

    public async Task<Movie?> Read(int id)
    {
        Movie? movie = movies.FirstOrDefault(u => u.Id == id);
        return await Task.FromResult(movie);
    }

    public async Task<Movie?> Update(int id, Movie newMovie)
    {
        Movie? movie = movies.FirstOrDefault(u => u.Id == id);
        if (movie != null)
        {
            movie.Title = newMovie.Title;
            movie.Year = newMovie.Year;
            movie.Description = newMovie.Description;
            movie.Rating = newMovie.Rating;
        }
        return await Task.FromResult(movie);
    }

    public async Task<Movie?> Delete(int id)
    {
        Movie? movie = movies.FirstOrDefault(u => u.Id == id);
        if (movie != null)
        {
            movies.Remove(movie);
        }
        return await Task.FromResult(movie);
    }
}