using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputWhite = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputGrey = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> whiteTilesAreas = new Stack<int>(inputWhite);
            Queue<int> greyTilesAreas = new Queue<int>(inputGrey);
            Dictionary<string, int> tilesLocationAreas = new Dictionary<string, int>();
            tilesLocationAreas["Sink"] = 40;
            tilesLocationAreas["Oven"] = 50;
            tilesLocationAreas["Countertop"] = 60;
            tilesLocationAreas["Wall"] = 70;

            Dictionary<string, int> tilesLocationCount = new Dictionary<string, int>();
            tilesLocationCount["Sink"] = 0;
            tilesLocationCount["Oven"] = 0;
            tilesLocationCount["Countertop"] = 0;
            tilesLocationCount["Wall"] = 0;
            tilesLocationCount["Floor"] = 0;

            while (whiteTilesAreas.Count != 0 && greyTilesAreas.Count != 0)
            {
                var currentWhiteTail = whiteTilesAreas.Pop();
                var currentGreyTail = greyTilesAreas.Dequeue();
                if (currentWhiteTail == currentGreyTail)
                {
                    var newTile = currentGreyTail + currentWhiteTail;
                    if (tilesLocationAreas.Values.Contains(newTile))
                    {
                        string newTileLocation = tilesLocationAreas.First(t => t.Value == newTile).Key;
                        tilesLocationCount[newTileLocation]++;
                    }
                    else
                    {
                        tilesLocationCount["Floor"]++;
                    }

                }
                else
                {
                    whiteTilesAreas.Push(currentWhiteTail / 2);
                    greyTilesAreas.Enqueue(currentGreyTail);
                }
            }

            if (whiteTilesAreas.Count>0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whiteTilesAreas)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (greyTilesAreas.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTilesAreas)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }
            foreach(var tile in tilesLocationCount.Where(t => t.Value > 0).OrderByDescending(t=>t.Value).ThenBy(t=>t.Key))
            {
                Console.WriteLine($"{tile.Key}: {tile.Value}");
            }
        }
    }
}
