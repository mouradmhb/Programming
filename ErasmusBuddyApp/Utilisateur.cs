using System;
using System.Security.Cryptography;
using System.Text;

public class Utilisateur
{
    public string Nom { get; set; }
    public string Email { get; set; }
    private string MotDePasseHash { get; set; } = string.Empty; // Initialisation par défaut
    public string Role { get; set; }

    // Constructeur
    public Utilisateur(string nom, string email, string role)
    {
        Nom = nom;
        Email = email;
        Role = role;
    }

    public void EnregistrerMotDePasse(string motDePasse)
    {
        MotDePasseHash = HacherMotDePasse(motDePasse);
    }

    public bool VerifierMotDePasse(string motDePasse)
    {
        return MotDePasseHash == HacherMotDePasse(motDePasse);
    }

    private string HacherMotDePasse(string motDePasse)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(motDePasse));
            StringBuilder builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
