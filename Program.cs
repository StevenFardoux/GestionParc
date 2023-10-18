using Class;
using Org.BouncyCastle.Crypto.Engines;

namespace Gestion_des_cartouches_d_ancres
{
    internal static  class Program
    {
        // intialisation et déclaration des variables et listes.
        /*public static bool openFr = false;
        public static bool openRecap = false;
        public static bool openGcc = false;
        public static bool openGl = false;
        public static bool openAdd = false;
        public static bool openGs = false;
        public static bool openGe = false;*/

        public static List<bool> listOpen = new List<bool>
        {
            false, //openFR -> 0
            false, //openRecap -> 1
            false, //openGcc -> 2
            false, //openGl -> 3
            false, //openAdd -> 4
            false, //openModif -> 5
            false, //openEmplacement -> 6
            false  //openGe -> 7
        };

        public static List<Classe> listResultatSalle = new List<Classe>();
        public static List<Imprimante> listImprimante = new List<Imprimante>();
        public static List<Couleur> listLivraison = new List<Couleur>();
        // Fin initialisation et déclaration.

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new container());
        }
    }
}                          