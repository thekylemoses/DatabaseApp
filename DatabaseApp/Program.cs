using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;

namespace DatabaseApp
{
    internal class Program
    {
        public static List<Player> GetPlayerFromDatabase(DbCommand cmd)
        {
            List<Player> results = new List<Player>();
            cmd.CommandText = "select * from PlayerInfo";
            Player player;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    player = new Player(Convert.ToInt32(reader["playerNum"]), Convert.ToString(reader["playerName"]), Convert.ToString(reader["playerPos"]), Convert.ToInt32(reader["hitABs"]), Convert.ToInt32(reader["hitSingle"]), Convert.ToInt32(reader["hitDouble"]), Convert.ToInt32(reader["hitTriple"]), Convert.ToInt32(reader["hitHR"]), Convert.ToInt32(reader["hitWalk"]), Convert.ToInt32(reader["pitchOuts"]), Convert.ToInt32(reader["pitchRuns"]));
                    results.Add(player);
                }
            }
            return results;
        }

        public static int GetNextPlayerNum(List<Player> players)
        {
            int maxNum = 0;
            foreach (Player player in players)
            {
                if (player.Number > maxNum)
                { 
                    maxNum = player.Number;
                }
            }
            return maxNum + 1;
        }

        static void Main(string[] args)
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            List<Player> players;

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            using (DbConnection conn = factory.CreateConnection())
            {
                if (conn == null)
                {
                    Console.WriteLine("Unable to connect to database.");
                    Console.ReadLine();
                    return;
                }

                conn.ConnectionString = connectionString;
                conn.Open();

                DbCommand cmd = conn.CreateCommand();

                players = GetPlayerFromDatabase(cmd);

                int hitABs = 0;
                int hitSingle = 0;
                int hitDouble = 0;
                int hitTriple = 0;
                int hitHR = 0;
                int hitWalk = 0;
                float hitAVG = 0;
                float hitOBP = 0;
                float hitSLG = 0;
                int pitchOuts = 0;
                int pitchRuns = 0;
                float pitchERA = 0;

                
                


                int run = 0;
                Console.WriteLine("**********************************************");
                Console.WriteLine("*************** MLB TEAM STATS ***************");
                Console.WriteLine("**********************************************");
                while (run != 5)
                {
                    if (run == 0)
                    {

                        Console.WriteLine("");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Main Menu");
                        Console.WriteLine("---------------");
                        Console.WriteLine("1. View Roster");
                        Console.WriteLine("2. Add Player");
                        Console.WriteLine("3. Delete Player");
                        Console.WriteLine("4. Quit Program");
                        Console.WriteLine("");
                        Console.Write("Select: ");
                        run = Convert.ToInt32(Console.ReadLine());
                    }
                    //View Roster
                    if (run == 1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("---------------");
                        Console.WriteLine("View Roster");
                        Console.WriteLine("---------------");
                        PlayerWriter.WritePlayersToScreen(players);
                        Console.WriteLine("Press any key to return to the Main Menu");
                        Console.ReadLine();
                        run = 0;
                    }

                    //Add Player
                    else if (run == 2)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Add Player");
                        Console.WriteLine("---------------");
                        Console.Write("Number: ");
                        int playerNum = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Full Name: ");
                        string playerName = Console.ReadLine();
                        Console.Write("Position (Ex: 1B, SP, CL, etc): ");
                        string playerPos = (Console.ReadLine()).Trim();
                        if (playerPos.Contains("SP"))
                        {
                            Console.Write("Outs Recorded: ");
                            pitchOuts = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Runs Allowed: ");
                            pitchRuns = Convert.ToInt32(Console.ReadLine());
                            if (pitchOuts > 3)
                            {
                                pitchERA = (float)(9 * pitchRuns) / (pitchOuts / 3);
                            }
                            else if (pitchOuts == 0)
                            {
                                pitchERA = (float)(9 * pitchRuns) * 3;

                            }
                            else
                            {
                                pitchERA = (9 * pitchRuns) * 3 / pitchOuts;
                            }
                        }
                        else if (playerPos.Contains("RP"))
                        {
                            Console.Write("Outs Recorded: ");
                            pitchOuts = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Runs Allowed: ");
                            pitchRuns = Convert.ToInt32(Console.ReadLine());
                            if (pitchOuts > 3)
                            {
                                pitchERA = (float)(9 * pitchRuns) / (pitchOuts / 3);
                            }
                            else if (pitchOuts == 0)
                            {
                                pitchERA = (float)(9 * pitchRuns) * 3;

                            }
                            else
                            {
                                pitchERA = (9 * pitchRuns) * 3 / pitchOuts;
                            }
                        }
                        else if (playerPos.Contains("CL"))
                        {
                            Console.Write("Outs Recorded: ");
                            pitchOuts = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Runs Allowed: ");
                            pitchRuns = Convert.ToInt32(Console.ReadLine());
                            if (pitchOuts > 3)
                            {
                                pitchERA = (float)(9 * pitchRuns) / (pitchOuts / 3);
                            }
                            else if (pitchOuts == 0)
                            {
                                pitchERA = (float)(9 * pitchRuns) * 3;

                            }
                            else
                            {
                                pitchERA = (9 * pitchRuns) * 3 / pitchOuts;
                            }
                        }
                        else
                        {
                            Console.Write("At Bats: ");
                            hitABs = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Singles: ");
                            hitSingle = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Doubles: ");
                            hitDouble = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Triples: ");
                            hitTriple = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Home Runs: ");
                            hitHR = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Walks: ");
                            hitWalk = Convert.ToInt32(Console.ReadLine());
                            if (hitABs > 0)
                            {

                                hitAVG = (float)(hitSingle + hitDouble + hitTriple + hitHR) / hitABs;
                                hitOBP = (float)(hitSingle + hitDouble + hitTriple + hitHR + hitWalk) / (hitABs + hitWalk);
                                hitSLG = (float)(hitSingle + (hitDouble * 2) + (hitTriple * 3) + (hitHR * 4)) / hitABs;
                            }
                            else
                            {
                                hitAVG = (float)(hitSingle + hitDouble + hitTriple + hitHR) / 1;
                                hitOBP = (float)(hitSingle + hitDouble + hitTriple + hitHR + hitWalk) / 1;
                                hitSLG = (float)(hitSingle + (hitDouble * 2) + (hitTriple * 3) + (hitHR * 4)) / 1;
                            }


                        }

                        string query = String.Format("insert into PlayerInfo values ({0},'{1}','{2}',{3},{4},{5},{6},{7},{8},{9:F3},{10:F3},{11:F3},{12},{13},{14:F2})", playerNum, playerName, playerPos, hitABs, hitSingle, hitDouble, hitTriple, hitHR, hitWalk, hitAVG, hitOBP, hitSLG, pitchOuts, pitchRuns, pitchERA);
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Here are the results after adding the new player:");
                        players = GetPlayerFromDatabase(cmd);
                        PlayerWriter.WritePlayersToScreen(players);
                        Console.WriteLine("Press any key to return to the Main Menu");
                        Console.ReadLine();
                        run = 0;
                    }

                    //Delete Player
                    else if (run == 3)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Delete Player");
                        Console.WriteLine("---------------");
                        Console.Write("Enter the jersey number of the player you would like to delete from the database: ");
                        string deleteThis = Console.ReadLine().ToUpper();
                        Console.WriteLine("After deleting that player...");
                        cmd.CommandText = String.Format("delete from PlayerInfo where playerNum = '{0}'", deleteThis);
                        cmd.ExecuteNonQuery();
                        players = GetPlayerFromDatabase(cmd);
                        PlayerWriter.WritePlayersToScreen(players);
                        Console.ReadLine();
                        Console.WriteLine("Press any key to return to the Main Menu");
                        run = 0;
                    }
                    else if (run == 4)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("* * * * * * * * * *");
                        Console.WriteLine("*                 *");
                        Console.WriteLine("* Farewell,Friend *");
                        Console.WriteLine("*                 *");
                        Console.WriteLine("* * * * * * * * * *");
                        Console.ReadLine();
                        run = 5;
                    }

                }
            }
        }
    }
}
