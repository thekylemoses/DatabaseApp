using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp
{
    internal class PlayerWriter
    {
        public static void WritePlayersToScreen(List<Player> players)
        {
            Console.WriteLine("|  #    Name                        | H  2B  3B  HR  BB |   AVG     OBP     SLG   |");
            Console.WriteLine("------------------------------------------------------------------------------------");
            foreach (Player player in players)
            {
                Console.WriteLine(player);
            }
        }
    }
}
