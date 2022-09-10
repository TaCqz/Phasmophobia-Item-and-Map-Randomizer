using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phasmophobia_Item_and_Map_Randomizer
{
    public class Item
    {
        #region fields
        private readonly bool _isEvidence;
        private readonly bool _isLight;
        private readonly string _name;
        private readonly int _max;

        #region properties
        public bool IsEvidence
        {
            get { return _isEvidence; }
        }
        public bool IsLight
        {
            get { return _isLight; }
        }
        public string Name
        {
           get { return _name; }
        }
        public int Max
        {
            get { return _max; }
        }
        #endregion

        #endregion

        public Item(string name, bool evidence, bool light, int max)
        {
            _isEvidence = evidence;
            _isLight = light;
            _name = name;
            _max = max;
        }

        public new void ToString()
        {
            Program.Log($"Item Name: {this._name, -20} Is a Lightsource: {_isLight, -10} Is an Evidence item: {_isEvidence, -10} Max number in game: {_max, -2}");
        }
    }
}
