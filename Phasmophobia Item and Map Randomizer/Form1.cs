namespace Phasmophobia_Item_and_Map_Randomizer
{
    public partial class Form1 : Form
    {
        private int mode = 0;
        private int difficulty = 1;
        private bool lightAllowed = true;
        private int maxEvidence = 4;
        private int itemsPerPlayer = 4;
        private int players = 4;
        private bool guaranteeLight = false;

        private static List<Item> player1_list = new List<Item>();
        private static List<Item> player2_list = new List<Item>();
        private static List<Item> player3_list = new List<Item>();
        private static List<Item> player4_list = new List<Item>();
        public static int ingameDifficulty = 0;

        string[] maps = { "Tanglewood Street House", "Ridgeview Road House", "Bleasdale Farmhouse", "Edgefield Street House", "Grafton Farmhouse", 
                          "Willow Street House", "Brownstone High School", "Maple Lodge Campsite", "Prison", "Asylum" };

        public static void SetPlayerItems(int player, Item i)
        {
            if (player == 1) player1_list.Add(i);
            else if (player == 2) player2_list.Add(i);
            else if (player == 3) player3_list.Add(i);
            else if (player == 4) player4_list.Add(i);
        }

        public Form1()
        {
            InitializeComponent();
            ToolTip modeTip = new ToolTip();
            modeTip.ToolTipIcon = ToolTipIcon.Info;
            modeTip.IsBalloon = true;
            modeTip.ShowAlways = true;
            modeTip.SetToolTip(label7, "Default Mode: No Restrictions by default\n" +
                                       "No Lights: No Lightsources except for Lighters and Glowsticks\n" +
                                       "No Evidence: No Items that gather active evidence towards the ghost\n" +
                                       "Nightmare: Combination of No Lights and No Evidence. WARNING: HARD!!");

            selectMode.Items.Add("Default");
            selectMode.Items.Add("No Lights");
            selectMode.Items.Add("No Evidence");
            selectMode.Items.Add("Nightmare");

            ToolTip diffTip = new ToolTip();
            diffTip.ToolTipIcon = ToolTipIcon.Info;
            diffTip.IsBalloon = true;
            diffTip.ShowAlways = true;
            diffTip.SetToolTip(label8, "Modifier for the Ingame Difficulty Level. Try it out ;)");

            selectDiff.Items.Add("Easy");
            selectDiff.Items.Add("Medium");
            selectDiff.Items.Add("Hard");

            selectLight.Items.Add("Yes");
            selectLight.Items.Add("No");

            selectMaxEvidence.Items.Add("1");
            selectMaxEvidence.Items.Add("2");
            selectMaxEvidence.Items.Add("3");
            selectMaxEvidence.Items.Add("4");

            selectItems.Items.Add("1");
            selectItems.Items.Add("2");
            selectItems.Items.Add("3");
            selectItems.Items.Add("4");

            selectPlayers.Items.Add("1");
            selectPlayers.Items.Add("2");
            selectPlayers.Items.Add("3");
            selectPlayers.Items.Add("4");



        }

        public void RunRando()
        {
            player1_list.Clear();
            player2_list.Clear();
            player3_list.Clear();
            player4_list.Clear();

            Program.RunRandomizer(mode, difficulty, lightAllowed, maxEvidence, itemsPerPlayer, players, guaranteeLight);

            player1_textbox.Clear();
            player2_textbox.Clear();
            player3_textbox.Clear();
            player4_textbox.Clear();


            #region Player1
            player1_textbox.AppendText("Item 1: " + Environment.NewLine + player1_list[0].Name + Environment.NewLine);
            if (itemsPerPlayer > 1) player1_textbox.AppendText("Item 2: " + Environment.NewLine + player1_list[1].Name + Environment.NewLine);
            if (itemsPerPlayer > 2) player1_textbox.AppendText("Item 3: " + Environment.NewLine + player1_list[2].Name + Environment.NewLine);
            if (itemsPerPlayer > 3) player1_textbox.AppendText("Item 4: " + Environment.NewLine + player1_list[3].Name + Environment.NewLine);
            #endregion

            #region Player2
            if (players > 1)
            {
                player2_textbox.AppendText("Item 1: " + Environment.NewLine + player2_list[0].Name + Environment.NewLine);
                if (itemsPerPlayer > 1) player2_textbox.AppendText("Item 2: " + Environment.NewLine + player2_list[1].Name + Environment.NewLine);
                if (itemsPerPlayer > 2) player2_textbox.AppendText("Item 3: " + Environment.NewLine + player2_list[2].Name + Environment.NewLine);
                if (itemsPerPlayer > 3) player2_textbox.AppendText("Item 4: " + Environment.NewLine + player2_list[3].Name + Environment.NewLine);
            }
            #endregion

            #region Player3
            if (players > 2)
            {
                player3_textbox.AppendText("Item 1: " + Environment.NewLine + player3_list[0].Name + Environment.NewLine);
                if (itemsPerPlayer > 1) player3_textbox.AppendText("Item 2: " + Environment.NewLine + player3_list[1].Name + Environment.NewLine);
                if (itemsPerPlayer > 2) player3_textbox.AppendText("Item 3: " + Environment.NewLine + player3_list[2].Name + Environment.NewLine);
                if (itemsPerPlayer > 3) player3_textbox.AppendText("Item 4: " + Environment.NewLine + player3_list[3].Name + Environment.NewLine);
            }
            #endregion

            #region Player4
            if (players > 3)
            {
                player4_textbox.AppendText("Item 1: " + Environment.NewLine + player4_list[0].Name + Environment.NewLine);
                if (itemsPerPlayer > 1) player4_textbox.AppendText("Item 2: " + Environment.NewLine + player4_list[1].Name + Environment.NewLine);
                if (itemsPerPlayer > 2) player4_textbox.AppendText("Item 3: " + Environment.NewLine + player4_list[2].Name + Environment.NewLine);
                if (itemsPerPlayer > 3) player4_textbox.AppendText("Item 4: " + Environment.NewLine + player4_list[3].Name + Environment.NewLine);
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectMode.Text == "Default") mode = 0;
            else if (selectMode.Text == "No Lights") mode = 1;
            else if (selectMode.Text == "No Evidence") mode = 2;
            else if (selectMode.Text == "Nightmare") mode = 3;
            else if (selectMode.Text == "Select Mode") mode = 0;

            if (selectDiff.Text == "Easy") difficulty = 0;
            else if (selectDiff.Text == "Medium") difficulty = 1;
            else if (selectDiff.Text == "Hard") difficulty = 2;
            else difficulty = 0;

            if (selectLight.Text == "Yes") lightAllowed = true;
            else lightAllowed = false;

            guaranteeLight = checkLight.Checked;

            if (selectMaxEvidence.Text == "1") maxEvidence = 1;
            else if (selectMaxEvidence.Text == "2") maxEvidence = 2;
            else if (selectMaxEvidence.Text == "3") maxEvidence = 3;
            else if (selectMaxEvidence.Text == "4") maxEvidence = 4;
            else maxEvidence = 4;

            if (selectItems.Text == "1") itemsPerPlayer = 1;
            else if (selectItems.Text == "2") itemsPerPlayer = 2;
            else if (selectItems.Text == "3") itemsPerPlayer= 3;
            else if (selectItems.Text == "4") itemsPerPlayer = 4;
            else itemsPerPlayer = 4;

            if (selectPlayers.Text == "1") players = 1;
            else if (selectPlayers.Text == "2") players = 2;
            else if (selectPlayers.Text == "3") players = 3;
            else if (selectPlayers.Text == "4") players = 4;
            else players = 4;

            if (ingameDifficulty == 0) difficulty_textbox.Text = "Amateur";
            if (ingameDifficulty == 1) difficulty_textbox.Text = "Intermediate";
            if (ingameDifficulty == 2) difficulty_textbox.Text = "Professional";
            if (ingameDifficulty == 3) difficulty_textbox.Text = "Nightmare";

            map_textbox.Text = maps[Randomizer.getMap()];

            RunRando();
        }
    }  
}