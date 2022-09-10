using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phasmophobia_Item_and_Map_Randomizer
{
    internal class Settings
    {
        #region fields
        // MODE SETTINGS
        private readonly int _mode; // 0 = Default, 1 = No Lights, 2 = No Evidence, 3 = Insanity (No Light, No Evidence, No Fusebox)
        private readonly int _difficulty; // 0 = Easy, 1 = Medium, 2 = Hard
        // 0 = Amateur, 1 = Intermediate, 2 = Professional, 3 = Nightmare =>
        // Easy allows Amateur (80%) and Intermediate (20%)
        // Medium allows intermediate (50%) and Professional (50%)
        // Hard allows Professional (90%) and Nightmare (10%) (Higher Professional Chance)
        // If mode is Insanity, only Nightmare is allowed!!
        private readonly int _ingameDifficulty;

        // ITEM SETTINGS
        private readonly bool _lightAllowed; // Maximum of allowed light sources PER PLAYER
        private readonly int _numberEvidenceAllowed; // Maximum of allowed evidence items PER PLAYER
        private readonly int _itemsPerPlayer;
        private Randomizer? _randomizer;
        private readonly bool _guaranteeLight;
        #endregion

        #region properties
        public int Mode
        {
            get { return _mode; }
        }
        public int Difficulty
        {
            get { return _difficulty; }
        }
        public int IngameDifficulty
        {
            get { return _ingameDifficulty; }
        }
        public bool LightAllowed
        {
            get { return _lightAllowed; }
        }
        public int NumberEvidenceAllowed
        {
            get { return _numberEvidenceAllowed; }
        }
        public int ItemsPerPlayer
        {
            get { return _itemsPerPlayer; }
        }
        public bool GuaranteeLight
        {
            get { return _guaranteeLight; }
        }
        #endregion

        #region ctor
        public Settings(int mode, int difficulty, bool lightAllowed, int numberEvidenceAllowed, int itemsPerPlayer, Randomizer rand, bool guaranteeLight)
        {
            // Defined Fields
            _difficulty = difficulty;
            _mode = mode;
            if (mode == 1 || mode == 3) _lightAllowed = false;
            else _lightAllowed = lightAllowed;
            if (mode == 2 || mode == 3) _numberEvidenceAllowed = 0;
            else _numberEvidenceAllowed = numberEvidenceAllowed;
            _itemsPerPlayer = itemsPerPlayer;
            _randomizer = rand;
            _guaranteeLight = guaranteeLight;

            // Get ingame difficulty based on settings
            _ingameDifficulty = _randomizer.getIngameDifficulty(this._mode, this._difficulty);


            Program.Log("Difficulty Settings: 0 = Amateur, 1 = Intermediate, 2 = Professional, 3 = Nightmare");
            Program.Log("Ingame Difficulty: " + _ingameDifficulty.ToString());
            _guaranteeLight = guaranteeLight;
        }
        #endregion
    }
}
