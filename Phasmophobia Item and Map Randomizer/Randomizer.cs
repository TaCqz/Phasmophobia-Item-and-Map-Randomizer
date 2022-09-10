using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phasmophobia_Item_and_Map_Randomizer
{
    internal class Randomizer
    {
        private List<Item> validItemList = new List<Item>();
        private const int FLASHLIGHT = 4;

        public Randomizer()
        {
            
        }

        public static int getMap()
        {
            Random r = new Random();

            int x = r.Next(0, 10);

            return x;
        }

        public int getIngameDifficulty(int mode, int difficulty)
        {
            int result = 0;

            if (mode == 3) result = 3;
            else
            {
                Random rand = new Random();
                if (difficulty == 0)
                {
                    int chance = rand.Next(1, 11);
                    if (chance < 8) return 0;
                    else return 1;
                }
                if (difficulty == 1)
                {
                    int chance = rand.Next(1, 11);
                    if (chance <= 5) return 1;
                    else return 2;
                }
                if (difficulty == 2)
                {
                    int chance = rand.Next(1, 11);
                    if (chance < 10) return 2;
                    else return 3;
                }
            }

            return result;
        }

        public List<Item> getRandomizedItemList(Settings settings)
        {
            assembleValidItems(settings.Mode, settings.LightAllowed, settings.NumberEvidenceAllowed, settings.ItemsPerPlayer);

            List<Item> playerItems = new List<Item>();
            int itemsNeeded = settings.ItemsPerPlayer;
            int allowedEvidenceItems = settings.NumberEvidenceAllowed;
            if (settings.GuaranteeLight)
            {
                playerItems.Add(Program.itemList[FLASHLIGHT]);
                itemsNeeded--;
                validItemList.Remove(playerItems[0]);
            }
            while(itemsNeeded > 0)
            {
                Random r = new Random();
                int x = r.Next(0, validItemList.Count);

                if (validItemList[x].IsEvidence == true)
                {
                    if (allowedEvidenceItems > 0) 
                    {
                        playerItems.Add(validItemList[x]);
                        validItemList.RemoveAt(x);
                        allowedEvidenceItems--;
                        itemsNeeded--;
                    }
                }
                else {
                    playerItems.Add(validItemList[x]);
                    validItemList.RemoveAt(x);
                    itemsNeeded--;
                }
            }
            Program.Log("\n\nItems for this Player: ");
            foreach(Item item in playerItems)
            {
                Program.Log(item.Name);
            }
            return playerItems;
            
        }

        private void assembleValidItems(int mode, bool lightAllowed, int numberEvidenceAllowed, int itemsPerPlayer)
        {
            validItemList.Clear();
            foreach (Item item in Program.itemList)
            {
                // If its a light AND Evidence is allowed, add to List
                if (lightAllowed == true && item.IsLight && numberEvidenceAllowed > 0 && item.IsEvidence) validItemList.Add(item);
                // If its a light BUT evidence is not allowed, add if its not evidence
                else if (lightAllowed == true && item.IsLight == true && item.IsEvidence == false) validItemList.Add(item);
                // If item is not light BUT its evidence and evidence is allowed, add to list
                if (item.IsLight == false && numberEvidenceAllowed > 0 && item.IsEvidence == true) validItemList.Add(item);
                else if (item.IsLight == false && item.IsEvidence == false) validItemList.Add(item);
                // There is no else needed! Everything else shouldnt be added!!


            }

            Program.Log("All available Items for randomizations: ");
            foreach (Item i in validItemList)
            { 
                Program.Log(i.Name);
            }
        }
    }
}
