using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.StarboundObjects
{
    public class StarboundAsset
    {
        [JsonIgnore]
        public Image Image { get; set; }

        [JsonIgnore]
        public string AssetName { get; set; }

        public StarboundAsset GetShallowCopy()
        {
            return (StarboundAsset)MemberwiseClone();
        }
    }
}
