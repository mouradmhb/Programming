using System;

public class Evenement
{
    public string Titre { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public Evenement(string titre, DateTime date, string description)
    {
        Titre = titre;
        Date = date;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Titre} - {Date.ToString("dd/MM/yyyy")} : {Description}";
    }
}
