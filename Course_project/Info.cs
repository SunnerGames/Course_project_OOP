namespace Course_project
{
    abstract class Info
    {
        public int FilmID { get; set; }
    }

    class InfoFilms : Info
    {
        public string Title { get; set; }
        public string FilmGenre { get; set; }
        public int RatesNumber { get; set; }
        public double AvgRate { get; set; }
        public int ProductionYear { get; set; }
        public string Nomination { get; set; }

        public InfoFilms(string title, string filmGenre, int ratesNumber, double avgRate, int productionYear, string nomination, int filmID)
        {
            Title = title;
            FilmGenre = filmGenre;
            RatesNumber = ratesNumber;
            AvgRate = avgRate;
            ProductionYear = productionYear;
            Nomination = nomination;
            FilmID = filmID;
        }
    }

    class InfoPartcps : Info
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Date { get; set; }
        public string Phone { get; set; }

        public InfoPartcps(string firstName, string lastName, string date, string phone, int filmID)
        {
            FirstName = firstName;
            LastName = lastName;
            Date = date;
            Phone = phone;
            FilmID = filmID;
        }
    }

    class InfoOthers : Info
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Date { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        public InfoOthers(string firstName, string lastName, string date, string phone, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Date = date;
            Phone = phone;
            Role = role;
        }
    }

}
