using System;
using System.Collections.Generic;

class Program
{
    static List<Utilisateur> utilisateurs = new List<Utilisateur>();
    static List<Evenement> evenements = new List<Evenement>(); // Liste des événements

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Erasmus Buddy App ===");
            Console.WriteLine("1. S'inscrire");
            Console.WriteLine("2. Se connecter");
            Console.WriteLine("3. Afficher les événements");
            Console.WriteLine("4. Ajouter un événement (Mentor seulement)");
            Console.WriteLine("5. Quitter");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    InscrireUtilisateur();
                    break;
                case "2":
                    ConnecterUtilisateur();
                    break;
                case "3":
                    AfficherEvenements();
                    break;
                case "4":
                    AjouterEvenement();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Appuyez sur Entrée pour réessayer.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void InscrireUtilisateur()
    {
        Console.Clear();
        Console.WriteLine("=== Inscription ===");
        Console.Write("Nom : ");
        string nom = Console.ReadLine();
        Console.Write("Email : ");
        string email = Console.ReadLine();
        Console.Write("Mot de passe : ");
        string motDePasse = Console.ReadLine();
        Console.Write("Rôle (Etudiant/Mentor) : ");
        string role = Console.ReadLine();

        Utilisateur nouvelUtilisateur = new Utilisateur(nom, email, role);
        nouvelUtilisateur.EnregistrerMotDePasse(motDePasse);
        utilisateurs.Add(nouvelUtilisateur);

        Console.WriteLine("Inscription réussie ! Appuyez sur Entrée pour continuer.");
        Console.ReadLine();
    }

    static void ConnecterUtilisateur()
    {
        Console.Clear();
        Console.WriteLine("=== Connexion ===");
        Console.Write("Email : ");
        string email = Console.ReadLine();
        Console.Write("Mot de passe : ");
        string motDePasse = Console.ReadLine();

        Utilisateur utilisateur = utilisateurs.Find(u => u.Email == email);

        if (utilisateur != null && utilisateur.VerifierMotDePasse(motDePasse))
        {
            Console.WriteLine($"Bienvenue, {utilisateur.Nom} ({utilisateur.Role}) !");
        }
        else
        {
            Console.WriteLine("Email ou mot de passe incorrect.");
        }

        Console.WriteLine("Appuyez sur Entrée pour continuer.");
        Console.ReadLine();
    }

    static void AfficherEvenements()
    {
        Console.Clear();
        Console.WriteLine("=== Liste des événements ===");

        if (evenements.Count == 0)
        {
            Console.WriteLine("Aucun événement n'est disponible pour le moment.");
        }
        else
        {
            foreach (var evt in evenements)
            {
                Console.WriteLine(evt.ToString());
            }
        }

        Console.WriteLine("\nAppuyez sur Entrée pour continuer.");
        Console.ReadLine();
    }

    static void AjouterEvenement()
    {
        Console.Clear();
        Console.WriteLine("=== Ajouter un événement ===");
        Console.Write("Titre : ");
        string titre = Console.ReadLine();
        Console.Write("Date (jj/mm/aaaa) : ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Description : ");
        string description = Console.ReadLine();

        Evenement nouvelEvenement = new Evenement(titre, date, description);
        evenements.Add(nouvelEvenement);

        Console.WriteLine("Événement ajouté avec succès ! Appuyez sur Entrée pour continuer.");
        Console.ReadLine();
    }
}
