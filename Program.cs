using System;
using System.Collections.Generic;
using System.Linq;
using TP01M03.BO;

namespace TP01M03
{
     class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        static void Main(string[] args) {
            InitialiserDatas();

            //foreach( Livre livre in ListeLivres){
            //    Console.WriteLine(livre.ToString());
            //}
            //Console.ReadKey();

            ListeAuteurs.Where(a => a.Nom.ToUpper().StartsWith("G")).Select(a => a.Prenom).ToList().ForEach(auteur => Console.WriteLine($"{auteur}"));

            Console.WriteLine("\n-------------------\n");

            Console.WriteLine(
                ListeLivres.GroupBy(livre => livre.Auteur).OrderByDescending(nbLivre => nbLivre.Count()).FirstOrDefault().Key.ToString());

            Console.WriteLine("\n-------------------\n");

            Console.WriteLine(
                ListeLivres.OrderByDescending(livre => livre.NbPages).First().ToString());

            Console.WriteLine("\n-------------------\n");

            ListeLivres.Select(livre => livre.Titre).OrderBy(titre => titre).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("\n-------------------\n");

            Console.WriteLine( ListeAuteurs.OrderBy(auteur => ListeLivres.Count(livre => livre.Auteur == auteur)).FirstOrDefault().ToString());
        }
    
        private static void InitialiserDatas(){
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
