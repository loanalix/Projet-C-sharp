using System;
using System.Security.Cryptography.X509Certificates;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static int Age(string nom)  
        {
            int age_num = 0;

            while (age_num <= 0)
            {
                Console.Write(nom +", quel est ton age? ");
                string age_str = Console.ReadLine();

                try
                {
                    age_num = int.Parse(age_str);

                    if (age_num < 0)
                    {
                        Console.WriteLine("Erreur , vous devez entré un age valide");
                    }

                    else if (age_num == 0)
                    {
                        Console.WriteLine("L'age ne peut pas être égale à 0");
                    }

                }
                catch
                {
                    Console.WriteLine("Erreur , vous devez rentré un message valide. ");
                }
            }
            return age_num;
        }

        static string Name(int numeroPersonne ) {

            string nom = "";
            while (nom == "")
            {
                Console.Write("Quel et votre nom de la personne numéro " +numeroPersonne + " ? ");
                nom = Console.ReadLine();

                if (nom == "")
                {
                    Console.WriteLine("Le nom ne dois pas être vide ");
                }

            }
            return nom;
        }







        static void Main(string[] args)
        {
             Console.OutputEncoding = System.Text.Encoding.UTF8;

            string nom1 = Name(1);
            string nom2 = Name(2);

            int age1 = Age(nom1);
            int age2 = Age(nom2);

            Console.WriteLine();
            Console.WriteLine("Bonjour " + nom1 + " et vous avais " + age1 + " ans");
            int age_prochain = age1 + 1; 
            Console.WriteLine("Vous aurez " + age_prochain + " ans");
            
            Console.WriteLine();
            Console.WriteLine("Bonjour " + nom2 + " et vous avais " + age2 + " ans");
            age_prochain = age2 + 1;
            Console.WriteLine("Vous aurez " + age_prochain + " ans");


            /*
            int i = 1; 

            while (i < 10) 
            {
                Console.WriteLine("Valeur de i : " + i );
                i ++; 

            }

            Console.WriteLine("Fin de la boucle");
            */
        }
    }
}