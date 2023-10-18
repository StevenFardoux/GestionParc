using Class;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Crmf;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Web;

namespace DataBase
{
    public class Bd
    {
        static void Main(string[] args)
        {

            //init();
            /* test getImprimante
            foreach (Imprimante printer in getImprimante())
            {
                Console.Write($"{printer.getNom()} : ");
                foreach (Couleur color in printer.getListCouleurs())
                {
                    Console.Write($"{color.getNom()} : {color.getQuantite()}, ");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
            }*/


            //test getSalle
            /*foreach (Classe salle in getSalle())
            {
                Console.WriteLine($"{salle.getNom()} : ");
                Console.WriteLine($"    {salle.getImprimante().getNom()} : ");
                foreach (Couleur color in salle.getImprimante().getListCouleurs())
                {
                    Console.WriteLine($"        {color.getNom()} : {color.getQuantite()}");
                    foreach (DateTime date in color.getListHisto())
                    {
                        Console.WriteLine($"            {date.ToString("dd-MM-yyyy")}");
                    }
                }
                Console.WriteLine("----------------------------------------");
            }*/

            //test
            //UpdateQteCartById(1, 25);

            //Console.Write(getMaxHsitoByIdPrint(1));

            //insertNewCartouche("test", "Noir", 4);

            //backup_Db();

            string t = setup_Db();
        }

        static public MySqlConnection init()
        {
            string json = File.ReadAllText("..\\..\\..\\..\\DataBase\\bin\\Debug\\net6.0\\data.json");
            dynamic data = JsonConvert.DeserializeObject(json);

            string server = data.connection.Server;
            string database = data.connection.DataBase;
            string user = data.connection.user;
            string password = data.connection.password;

            string connexionString;
            MySqlConnection cnn;
            connexionString = $"Server={server};database={database};uid={user};pwd={password}";
            //connexionString = "Server=localhost;port=3307;uid=root;database=test";
            cnn = new MySqlConnection(connexionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connexion établie !");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return cnn;
        }

        static public List<Imprimante> getImprimanteDist()
        {
            using (MySqlConnection cnn = init())
            {
                string query = "SELECT DISTINCT idPrint, nomPrint, idCart, nomCart, couleur, quantite " +
                           "FROM contient CO " +
                           "INNER JOIN imprimante I " +
                           "ON I.idPrint = CO.idImprimante " +
                           "INNER JOIN cartouche CA " +
                           "ON CA.idCart = CO.idCartouche " +
                           "ORDER BY idPrint";
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Imprimante> listReq = new List<Imprimante>();
                        int idPrint = 0;
                        while (reader.Read())
                        {
                            if (int.Parse(reader["idPrint"].ToString()) == idPrint)
                            {
                                listReq[listReq.Count - 1].addToList(new Couleur(int.Parse(reader["idCart"].ToString()), reader["nomCart"].ToString(), reader["couleur"].ToString(), int.Parse(reader["quantite"].ToString())));
                            }
                            else
                            {
                                List<Couleur> list = new List<Couleur>
                                {
                                    new Couleur(int.Parse(reader["idCart"].ToString()), reader["nomCart"].ToString(), reader["couleur"].ToString(), int.Parse(reader["quantite"].ToString()))
                                };
                                Imprimante printer = new Imprimante(int.Parse(reader["idPrint"].ToString()), reader["nomPrint"].ToString(), list);
                                idPrint = int.Parse(reader["idPrint"].ToString());
                                listReq.Add(printer);
                            }
                        }
                        return listReq;
                    }
                }
            }
        }

        static public List<Classe> getSalle()
        {
            using (MySqlConnection cnn = init())
            {
                string query = "SELECT idSalle, nomSalle, idPrint, nomPrint, idCart, nomCart, couleur, quantite, dateChangement " +
                               "FROM appartient A " +
                               "INNER JOIN salle S " +
                               "ON A.idClasse = s.idSalle " +
                               "INNER JOIN imprimante I " +
                               "ON A.idImprimante = I.idPrint " +
                               "INNER JOIN contient CO " +
                               "ON I.idPrint = CO.idImprimante " +
                               "INNER JOIN cartouche CA " +
                               "ON CO.idCartouche = CA.idCart " +
                               "ORDER BY nomSalle;";
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Classe> listReq = new List<Classe>();
                        int idSalle = 0, idPrint = 0, idCart = 0, indexCart = 0;
                        while (reader.Read())
                        {
                            if (int.Parse(reader["idSalle"].ToString()) == idSalle && int.Parse(reader["idPrint"].ToString()) == idPrint && int.Parse(reader["idCart"].ToString()) == idCart)
                            {
                                //meme cartouche sur même imprimante, dateChangement change
                                indexCart = listReq[listReq.Count - 1].getImprimante().getListCouleurs().Count;
                                listReq[listReq.Count - 1].getImprimante().getListCouleurs()[indexCart - 1].addHisto((DateTime)reader["dateChangement"]);
                            }
                            else if (int.Parse(reader["idSalle"].ToString()) == idSalle && int.Parse(reader["idPrint"].ToString()) == idPrint && int.Parse(reader["idCart"].ToString()) != idCart)
                            {
                                //autre cartouche
                                List<DateTime> list = new List<DateTime>
                                {
                                    (DateTime)reader["dateChangement"]
                                };
                                listReq[listReq.Count - 1].getImprimante().addToList(new Couleur(int.Parse(reader["idCart"].ToString()), reader["nomCart"].ToString(), reader["couleur"].ToString(), int.Parse(reader["quantite"].ToString()), list));
                                idCart = int.Parse(reader["idCart"].ToString());
                            }
                            else
                            {
                                List<DateTime> list = new List<DateTime>
                                {
                                    (DateTime)reader["dateChangement"]
                                };
                                List<Couleur> colors = new List<Couleur>
                                {
                                    new Couleur(int.Parse(reader["idCart"].ToString()), reader["nomCart"].ToString(), reader["couleur"].ToString(), int.Parse(reader["quantite"].ToString()), list)
                                };
                                Classe salle = new Classe(int.Parse(reader["idSalle"].ToString()), reader["nomSalle"].ToString(), new Imprimante(int.Parse(reader["idPrint"].ToString()), reader["nomPrint"].ToString(), colors));
                                idSalle = int.Parse(reader["idSalle"].ToString());
                                idPrint = int.Parse(reader["idPrint"].ToString());
                                idCart = int.Parse(reader["idCart"].ToString());
                                listReq.Add(salle);
                            }
                        }
                        return listReq;
                    }
                }
            }
                
        }

        public static int getMaxHsitoByIdPrint(int idPrint)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "SELECT idCartouche, COUNT(dateChangement) AS maxDate " +
                               "FROM contient " +
                               "WHERE idImprimante = @id " +
                               "GROUP BY idCartouche " +
                               "ORDER BY maxDate DESC";
                parameters.Add("@id", idPrint);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int req = 0;
                        while (reader.Read())
                        {
                            if (req < int.Parse(reader["maxDate"].ToString()))
                            {
                                req = int.Parse(reader["maxDate"].ToString());
                            }
                        }
                        return req;
                    }
                }
            }
        }

        static public List<Couleur> getLivraison()
        {
            using (MySqlConnection cnn = init())
            {
                string query = "SELECT idCart, couleur, quantite, idLivr, nomCart, quantiteCommande, dateCommande, dateLivraison " +
                               "FROM reference R " +
                               "INNER JOIN cartouche C " +
                               "ON R.idCartouche = c.idCart " +
                               "INNER JOIN livraisoncartouche L " +
                               "ON r.idLivraison = L.idLivr";
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Couleur> listReq = new List<Couleur>();
                        int idCart = 0;
                        while (reader.Read())
                        {
                            if (idCart == int.Parse(reader["idCart"].ToString()))
                            {
                                listReq[idCart].addLivraison(new Livraison(int.Parse(reader["idLivr"].ToString()), reader["nomCart"].ToString(), int.Parse(reader["quantiteCommande"].ToString()), (DateTime)reader["dateCommande"], (DateTime)reader["dateLivraison"]));
                            }
                            else
                            {
                                List<Livraison> list = new List<Livraison>
                                {
                                    new Livraison(int.Parse(reader["idLivr"].ToString()), reader["nomCart"].ToString(), int.Parse(reader["quantiteCommande"].ToString()), (DateTime)reader["dateCommande"], (DateTime)reader["dateLivraison"])
                                };
                                listReq.Add(new Couleur(int.Parse(reader["idCart"].ToString()), reader["nomCart"].ToString(), reader["couleur"].ToString(), int.Parse(reader["quantite"].ToString()), list));
                            }
                        }
                        return listReq;
                    }
                }
            }
        }

        static public List<Couleur> getCartouche()
        {
            using (MySqlConnection cnn = init())
            {
                string query = "SELECT idCart, nomCart, couleur, quantite " +
                               "FROM cartouche";
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Couleur> listReq = new List<Couleur>();
                        while (reader.Read())
                        {
                            listReq.Add(new Couleur(int.Parse(reader["idCart"].ToString()), reader["nomCart"].ToString(), reader["couleur"].ToString(), int.Parse(reader["quantite"].ToString())));
                        }
                        return listReq;
                    }
                }
            }
        }

        static public int getMaxHistoLivraisonById(int idCart)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "SELECT idCartouche, COUNT(idLivraison) AS nbLivr " +
                               "FROM reference " +
                               "WHERE idCartouche = @id " +
                               "GROUP BY idCartouche " +
                               "ORDER BY nbLivr  DESC";
                parameters.Add("@id", idCart);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int req = 0;
                        while (reader.Read())
                        {
                            if (req < int.Parse(reader["nbLivr"].ToString()))
                            {
                                req = int.Parse(reader["nbLivr"].ToString());
                            }
                        }
                        return req;
                    }
                }
            }
        }

        static public List<String> getNomCart()
        {
            using (MySqlConnection cnn = init())
            {
                string query = "SELECT nomCart " +
                               "FROM cartouche";
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> listReq = new List<string>();
                        while (reader.Read())
                        {
                            listReq.Add(reader["nomCart"].ToString());
                        }
                        return listReq;
                    }
                }
            }
        }
        
        static public Couleur getCartoucheByNom(string nom)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "SELECT idCart, nomCart, couleur, quantite " +
                    "FROM cartouche " +
                    "WHERE nomCart = @nom;";
                parameters.Add("@nom", nom);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Couleur colorReq = null;
                        while (reader.Read())
                        {
                            colorReq = new Couleur(int.Parse(reader["idCart"].ToString()), reader["nomCart"].ToString(), reader["couleur"].ToString(), int.Parse(reader["quantite"].ToString()));
                        }
                        return colorReq;
                    }
                }
            }
        }

        static public int getstatCartoucheById(int idPrint, int idCart)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "SELECT statEnMois " +
                                "FROM durabilite " +
                                "WHERE idImprimante = @idPrint AND idCartouche = @idCart";
                parameters.Add("@idPrint", idPrint);
                parameters.Add("@idCart", idCart);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<int> list = new List<int>();
                        int moyenne = 0;

                        while (reader.Read())
                        {
                            if (int.Parse(reader["statEnMois"].ToString()) != 0)
                            {
                                list.Add(int.Parse(reader["statEnMois"].ToString()));
                                moyenne += list[list.Count - 1];
                            }
                        }
                        if (moyenne != 0)
                        {
                            moyenne /= list.Count;
                        }
                        return moyenne;
                    }
                }
            }
        }

        static public List<Couleur> getCartoucheWithEmpl()
        {
            using (MySqlConnection cnn = init())
            {
                string query = "SELECT idCart, nomCart, couleur, quantite, idEmplacement, etagere, numero " +
                               "FROM cartouche C " +
                               "INNER JOIN emplacement E " +
                               "ON C.idEmplace = E.idEmplacement";
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Couleur> listReq = new List<Couleur>();
                        while (reader.Read())
                        {
                            listReq.Add(new Couleur(int.Parse(reader["idCart"].ToString()), reader["nomCart"].ToString(), reader["couleur"].ToString(), int.Parse(reader["quantite"].ToString()), new Emplacement(int.Parse(reader["idEmplacement"].ToString()), reader["etagere"].ToString(), int.Parse(reader["numero"].ToString()))));
                        }

                        return listReq;
                    }
                }
            }
        }

        static public List<Empreint> getEmpreint()
        {
            using (MySqlConnection cnn = init())
            {
                string query = "SELECT id, nomObject, quantite, dateEmpreint, dateRetour " +
                               "FROM empreint";
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Empreint> listReq = new List<Empreint>();
                        while (reader.Read())
                        {
                            listReq.Add(new Empreint(int.Parse(reader["id"].ToString()), reader["nomObject"].ToString(), int.Parse(reader["quantite"].ToString()), (DateTime)reader["dateEmpreint"], (DateTime)reader["dateRetour"]));
                        }

                        return listReq;
                    }
                }
            }
        }


        static public void UpdateQteCartById(int idCart, int qte)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "UPDATE cartouche SET quantite = @qte WHERE idCart = @id;";
                parameters.Add("@qte", qte);
                parameters.Add("@id", idCart);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        static public void updateSalle(int idSalle, string nom, int idPrint)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "UPDATE Salle SET nomSalle = @nom WHERE idSalle = @id";
                parameters.Add("@nom", nom);
                parameters.Add("@id", idSalle);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }

                Dictionary<string, object> parameters2 = new Dictionary<string, object>();
                query = "DELETE FROM appartient WHERE idClasse = @id";
                parameters2.Add("@id", idSalle);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param2 in parameters2)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param2.Key, param2.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                } 

                    Dictionary<string, object> parameters3 = new Dictionary<string, object>();
                query = "INSERT INTO appartient VALUES(@idSalle, @idPrint)";
                parameters3.Add("@idSalle", idSalle);
                parameters3.Add("@idPrint", idPrint);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param3 in parameters3)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param3.Key, param3.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        static public void updatePrinter(int id, string nom, List<int> listidCart)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "UPDATE imprimante SET nomPrint = @nom WHERE idPrint = @id";
                parameters.Add("@nom", nom);
                parameters.Add("@id", id);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }

                Dictionary<string, object> paramenters2 = new Dictionary<string, object>();
                query = "DELETE FROM contient " +
                        "WHERE idImprimante = @id";
                paramenters2.Add("@id", id);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param2 in paramenters2)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param2.Key, param2.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }

                foreach (int idCart in listidCart)
                {
                    insertNewdateChangement(id, idCart, DateTime.Now);
                }
            }
        }

        static public void updateCartouche(int id,  string nom, string couleur, int qte)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "UPDATE cartouche SET nomCart = @nom, couleur = @couleur, quantite = @qte WHERE idCart = @id";
                parameters.Add("@nom", nom);
                parameters.Add("@couleur", couleur);
                parameters.Add("@qte", qte);
                parameters.Add("@id", id);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        static public void insertNewdateChangement(int idPrint, int idCart, DateTime date)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string querry = "INSERT INTO contient " +
                                "VALUES(@idPrint, @idCart, @date)";
                parameters.Add("@idPrint", idPrint);
                parameters.Add("@idCart", idCart);
                parameters.Add("@date", date.ToString("yyyy-MM-dd"));
                using (MySqlCommand cmd = new MySqlCommand(querry, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        static public void insertNewLivraison(string nomCart, int quantite, DateTime dateCommande, DateTime dateLivraison)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "INSERT INTO livraisoncartouche VALUES(null, @qte, @dateCommande, @dateLivraison);";
                parameters.Add("@qte", quantite);
                parameters.Add("@dateCommande", dateCommande);
                parameters.Add("@dateLivraison", dateLivraison);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    Dictionary<string, object> parameters2 = new Dictionary<string, object>();
                    query = "INSERT INTO reference VALUES((SELECT idCart FROM cartouche WHERE nomCart = 'Magenta'), (SELECT MAX(idLivr) FROM livraisoncartouche));";
                    parameters2.Add("@nomCart", nomCart);
                    using (MySqlCommand cmd2 = new MySqlCommand(query, cnn))
                    {
                        foreach (KeyValuePair<string, object> param2 in parameters2)
                        {
                            cmd2.Parameters.Add(new MySqlParameter(param2.Key, param2.Value));
                        }
                        cmd2.Prepare();
                        cmd2.ExecuteNonQuery();
                    }
                }
            }
        }

        static public void insertNewCartouche(string nomCart, string couleur, int qte)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "INSERT INTO cartouche " +
                               "VALUES(null, @nomCart, @couleur, @qte)";
                parameters.Add("@nomCart", nomCart);
                parameters.Add("@couleur", couleur);
                parameters.Add("@qte", qte);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        static public void insertNewPrinter(Classe salle)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "INSERT INTO imprimante VALUES(null, @nom)";
                parameters.Add("@nom", salle.getImprimante().getNom());
                using (MySqlCommand cmd = new MySqlCommand(query, cnn)) 
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                    
                foreach (Couleur color in salle.getImprimante().getListCouleurs())
                {
                    Dictionary<string, object> parameters2 = new Dictionary<string, object>();
                    query = "INSERT INTO contient " +
                            "VALUES((SELECT MAX(idPrint) FROM imprimante), " +
                            "(SELECT idCart FROM cartouche WHERE nomCart = @nomCart), " +
                            "now())";
                    parameters2.Add("@nomCart", color.getNom());
                    using (MySqlCommand cmd2 = new MySqlCommand(query, cnn))
                    {
                        foreach (KeyValuePair<string, object> param2 in parameters2)
                        {
                            cmd2.Parameters.Add(new MySqlParameter(param2.Key, param2.Value));
                        }
                        cmd2.Prepare();
                        cmd2.ExecuteNonQuery();
                    }
                }

                Dictionary<string, object> parameters3 = new Dictionary<string, object>();
                query = "INSERT INTO salle " +
                        "VALUES(null, @nomsalle)";
                parameters3.Add("@nomSalle", salle.getNom());
                using (MySqlCommand cmd3 = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param3 in parameters3)
                    {
                        cmd3.Parameters.Add(new MySqlParameter(param3.Key, param3.Value));
                    }
                    cmd3.Prepare();
                    cmd3.ExecuteNonQuery();
                    cmd3.Clone();
                }
                    

                query = "INSERT INTO appartient " +
                        "VALUES((SELECT MAX(idSalle) FROM salle), (SELECT MAX(idPrint) FROM imprimante));";
                using (MySqlCommand cmd4 = new MySqlCommand(query, cnn))
                {
                    cmd4.Prepare();
                    cmd4.ExecuteNonQuery();
                    cmd4.Clone();
                }
            }
        }

        static public void insertNewEmpreint(Empreint empreint)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "INSERT INTO empreint VALUES(null, @nom, @qte, @dateEmpreint, @dateRetour);";
                parameters.Add("@nom", empreint.getNomObject());
                parameters.Add("@qte",empreint.getQuantite());
                parameters.Add("@dateEmpreint", empreint.getDateEmpreint().ToString("yyyy-dd-MM"));
                parameters.Add("@dateRetour", empreint.getDateRetour().ToString("yyyy-dd-MM"));
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param  in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        static public void delSalle(int id)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "DELETE FROM salle WHERE idSalle = @id";
                parameters.Add("@id", id);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        static public void delPrinter(int id)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "DELETE FROM imprimante WHERE idSalle = @id";
                parameters.Add("@id", id);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        static public void delCartouche(int id) 
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "DELETE FROM cartouche WHERE idSalle = @id";
                parameters.Add("@id", id);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        static public void delEmpreint(int id)
        {
            using (MySqlConnection cnn = init())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "DELETE FROM empreint WHERE id = @id";
                parameters.Add("@id", id);
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter(param.Key, param.Value));
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        static public string setup_Db()
        {
            string json = File.ReadAllText("..\\..\\..\\..\\DataBase\\bin\\Debug\\net6.0\\data.json");
            dynamic data = JsonConvert.DeserializeObject(json);

            string server = data.connection.Server;
            string database = data.connection.Database; 
            string user = data.connection.user;
            string password = data.connection.password;

            string connexionString = $"Server={server};uid={user};pwd={password}";
            using (MySqlConnection cnn = new MySqlConnection(connexionString))
            {
                try
                {
                    cnn.Open();
                    Console.WriteLine("Connexion établie !");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                string query = "DROP DATABASE IF EXISTS gestionImprimante;";
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }


                query = "CREATE DATABASE gestionImprimante;";
                using (MySqlCommand cmd2 = new MySqlCommand(query, cnn))
                {
                    cmd2.Prepare();
                    cmd2.ExecuteNonQuery();
                } 


                query = "USE gestionImprimante;";
                using (MySqlCommand cmd3 = new MySqlCommand(query, cnn))
                {
                    cmd3.ExecuteNonQuery();
                }


                query = File.ReadAllText("..\\..\\..\\..\\DataBase\\bin\\Debug\\net6.0\\gestionImprimante.sql");
                //Console.WriteLine(query);
                using (MySqlCommand cmd4 = new MySqlCommand(query, cnn))
                {
                    Console.WriteLine(query);
                    cmd4.ExecuteNonQuery();
                }
            }
            return "Base de donnée importé avec succès !";
        }

        static public void backup_Db()
        {
            using (MySqlConnection cnn = init())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = cnn;
                    using (MySqlBackup bp = new MySqlBackup(cmd))
                    {
                        bp.ExportToFile("..\\..\\..\\..\\DataBase\\bin\\Debug\\net6.0\\gestionImprimante.sql");

                        Console.WriteLine("Backup effectué avec succcès !");
                    }
                }
            }
        }
    }
}