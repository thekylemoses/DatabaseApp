using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp
{
    internal class Player
    {
        //FOR HITTERS//
        public int Number { get; set; }
        public string Name { get; set; }
        public string Pos { get; set; }
        public int AtBats { get; set; }
        public int Singles { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HomeRuns { get; set; }
        public int Walks { get; set; }
        public float Average;
        public float OnBase;
        public float Slugging;

        //FOR PITCHERS//
        public int Outs { get; set; }
        public int Runs { get; set; }
        public float ERA;



        public Player()
        {
            Number = 0;
            Name = "";
            Pos = "";
            AtBats = 0;
            Singles = 0;
            Doubles = 0;
            Triples = 0;
            HomeRuns = 0;
            Walks = 0;
            Average = 0;
            OnBase = 0;
            Slugging = 0;
            Outs = 0;
            Runs = 0;
            ERA = 0;
        }

        public Player(int playerNum, string playerName, string playerPos, int hitABs, int hitSingle, int hitDouble, int hitTriple, int hitHR, int hitWalk, int pitchOuts, int pitchRuns)
        {
            Number = playerNum;
            Name = playerName;
            Pos = playerPos;
            AtBats = hitABs;
            Singles = hitSingle;
            Doubles = hitDouble;
            Triples = hitTriple;
            HomeRuns = hitHR;
            Walks = hitWalk;

            if (hitABs > 0)
            {

                Average = (float)(hitSingle + hitDouble + hitTriple + hitHR) / hitABs;
                OnBase = (float)(hitSingle + hitDouble + hitTriple + hitHR + hitWalk) / (hitABs + hitWalk);
                Slugging = (float)(hitSingle + (hitDouble * 2) + (hitTriple * 3) + (hitHR * 4)) / hitABs;
            }
            else
            {
                Average = (float)(hitSingle + hitDouble + hitTriple + hitHR) / 1;
                OnBase = (float)(hitSingle + hitDouble + hitTriple + hitHR + hitWalk) / 1;
                Slugging = (float)(hitSingle + (hitDouble * 2) + (hitTriple * 3) + (hitHR * 4)) / 1;
            }

            Outs = pitchOuts;
            Runs = pitchRuns;

            if (pitchOuts > 3)
            {
                ERA = (float)(9 * pitchRuns) / (pitchOuts / 3);
            }
            else if (pitchOuts == 0)
            {
                ERA = (float)(9 * pitchRuns) * 3;

            }
            else
            {
                ERA = (9 * pitchRuns) * 3 / pitchOuts;
            }
        }


        public override string ToString()
        {
            if (Pos.Trim() == "SP")
            {
                return String.Format("| #{0,-3}  {1}{2} |     ERA: {3,-5:F2}    |                         |", Number, Name, Pos, ERA);
            }
            else if (Pos.Trim() == "RP")
            {
                return String.Format("| #{0,-3}  {1}{2} |     ERA: {3,-5:F2}    |                         |", Number, Name, Pos, ERA);
            }
            else if (Pos.Trim() == "RP")
            {
                return String.Format("| #{0,-3}  {1}{2} |     ERA: {3,-5:F2}    |                         |", Number, Name, Pos, ERA);
            }
            else
            {
                return String.Format("| #{0,-3}  {1}{2} | {3}   {4}   {5}   {6}   {7} |  {8:F3}   {9:F3}   {10:F3}  |", Number, Name, Pos, (Singles + Doubles + Triples + HomeRuns), Doubles, Triples, HomeRuns, Walks, Average, OnBase, Slugging);

            }
        }
    
    }
}