using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    internal static class Utente
    {
        private static string _username;
        private static string _password;
        private static string _confermaPassword;
        public static string Username { get { return _username; } set { _username = value; } }
        public static string Password { get { return _password; } set { _password = value; } }
        public static string ConfermaPassword { get { return _confermaPassword; } set { _confermaPassword = value; } }

        static Dictionary<string, List<DateTime>> utentiLoggati = new Dictionary<string, List<DateTime>>();


        public static void Login()
        {
            Console.WriteLine("Inserisci qui l'username");
            _username = Console.ReadLine();
            Console.WriteLine("Inserisci qui la password");
            _password = Console.ReadLine();
            Console.WriteLine("Conferma la password");
            _confermaPassword = Console.ReadLine();

            if (_username != null || _password == _confermaPassword)
            {
                Console.WriteLine("Login effettuato con successo");
                utentiLoggati[_username] = new List<DateTime>();
                utentiLoggati[_username].Add(DateTime.Now);
                MenuPrincipale();
            }
            else
            {
                Console.WriteLine("Login fallito");
            }
        }

        public static void Logout()
        {
            if (_username != null && _password != null)
            {
                _username = null; _password = null; _confermaPassword = null;
                Console.WriteLine("Logout eseguito con successo, statti bene");
                MenuPrincipale();
            }
            else
            {
                Console.WriteLine("Vuoi fare il logout senza avere un account? Sei un genio");
                MenuPrincipale();

            }
        }

        public static void MenuPrincipale()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("BENVENUTO");
            Console.WriteLine("===========================");
            Console.WriteLine("Scegli l'operazione da effettuare: ");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Logout");
            Console.WriteLine("3.Verifica ora e data di login");
            Console.WriteLine("4.Lista degli accesi");
            Console.WriteLine("5.Termina la tua vita");

            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Logout();
                    break;
                case 3:
                    VerificaOraData();
                    break;
                case 4:
                    ListaUtenti();
                    break;
                case 5:
                    Console.WriteLine("Sei proprio sicuro?    (y/n)");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opzione non valida");
                    MenuPrincipale();
                    break;
            }

        }
        public static void ListaUtenti()
        {
            Console.WriteLine("Lista degli accessi");
            foreach (var coppia in utentiLoggati)
            {
                string _username = coppia.Key;
                List<DateTime> accessi = coppia.Value;

                foreach (var access in accessi)
                {
                    Console.WriteLine($"{_username} " + access.ToString());
                    Console.ReadLine();
                    MenuPrincipale();
                }

            }
        }

        public static void VerificaOraData()
        {
            Console.WriteLine("Inserisci il nome utente");
            string nomeUtente = Console.ReadLine();
            if (nomeUtente == "")
            {
                Console.WriteLine("Devi scivere qualcosa");
                MenuPrincipale();
            }
            else if (utentiLoggati.ContainsKey(nomeUtente))
            {
                DateTime oraLog = utentiLoggati[nomeUtente].LastOrDefault();
                Console.WriteLine($"{nomeUtente} si e' loggato l'ultima volta alle {oraLog}");
                MenuPrincipale();

            }
            else
            {
                Console.WriteLine($"{nomeUtente} non e' loggato");
                MenuPrincipale();
            }
        }
    }

}
