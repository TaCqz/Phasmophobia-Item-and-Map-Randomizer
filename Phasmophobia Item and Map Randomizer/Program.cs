namespace Phasmophobia_Item_and_Map_Randomizer
{
    internal static class Program
    {
        public static List<Item> itemList = new List<Item>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void InitializeItems()
        {
            Program.Log("Starting initialization of available Items...\n");

            // Basic Items
            Program.Log("Registrating Basic Items...\n");

            Item spiritBox = new Item("Spirit Box", true, false, 2);
            itemList.Add(spiritBox);
            Item book = new Item("Ghost Writing Book", true, false, 2);
            itemList.Add(book);
            Item emf = new Item("EMF Reader", true, false, 2);
            itemList.Add(emf);
            Item uv = new Item("UV Flashlight", true, true, 2);
            itemList.Add(uv);
            Item flashlight = new Item("Flashlight", false, true, 4);
            itemList.Add(flashlight);
            Item vidcam = new Item("Video Camera", true, false, 6);
            itemList.Add(vidcam);
            Item foto = new Item("Photo Camera", false, false, 3);
            itemList.Add(foto);
            Item dots = new Item("D.O.T.S. Projector", true, false, 2);
            itemList.Add(dots);

            // Optional Items
            Program.Log("Registrating Optional Items...\n");

            Item candle = new Item("Candle", false, false, 4);
            itemList.Add(candle);
            Item cruzifix = new Item("Cruzifix", false, false, 2);
            itemList.Add(cruzifix);
            Item glowstick = new Item("Glowstick", true, false, 2);
            itemList.Add(glowstick);
            Item headcam = new Item("Head Mounted Camera", false, false, 4);
            itemList.Add(headcam);
            Item lighter = new Item("Lighter", false, false, 4);
            itemList.Add(lighter);
            Item motion = new Item("Motion Sensor", false, false, 4);
            itemList.Add(motion);
            Item parabolic = new Item("Parabolic Microphone", false, false, 2);
            itemList.Add(parabolic);
            Item salt = new Item("Salt Shaker", false, false, 3);
            itemList.Add(salt);
            Item drugs = new Item("Sanity Pills", false, false, 4);
            itemList.Add(drugs);
            Item smudge = new Item("Smudge Sticks", false, false, 4);
            itemList.Add(smudge);
            Item sound = new Item("Sound Sensor", false, false, 4);
            itemList.Add(sound);
            Item strongFlashlight = new Item("Strong Flashlight", false, true, 4);
            itemList.Add(strongFlashlight);
            Item thermometer = new Item("Thermometer", true, false, 3);
            itemList.Add(thermometer);
            Item tripod = new Item("Tripod", false, false, 5);
            itemList.Add(tripod);

            foreach (Item i in itemList) i.ToString();

            Program.Log("Initialization of Items done!\n");
        }

        public static void RunRandomizer(int mode, int difficulty, bool lightAllowed, int numberEvidenceAllowed, int itemsPerPlayer, int playerNumber, bool guaranteeLight)
        {
            // Initialization
            itemList.Clear();
            InitializeItems();

            int players = playerNumber;
            Randomizer randomizer = new Randomizer();
            Form1.ingameDifficulty = randomizer.getIngameDifficulty(mode, difficulty);
            Settings settings = new Settings(mode, difficulty, lightAllowed, numberEvidenceAllowed, itemsPerPlayer, randomizer, guaranteeLight);
            

            while (players > 0)
            {
                List<Item>[] finalItems = new List<Item>[4];
                finalItems[players-1] = randomizer.getRandomizedItemList(settings);
                Program.Log("Items for Player " + players);
                foreach (Item i in finalItems[players-1])
                {
                    Program.Log(i.Name);
                    Form1.SetPlayerItems(players, i);
                }
                players--;
            }
            
        }

        public static void Log(string s)
        {
            DateTime now = DateTime.Now;

            Console.WriteLine(now + ": " + s);
        }
    }
}