using Game.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Main.Class.Save
{
    [Serializable]
    public struct HeroesData
    {
        [JsonInclude] public static List<Heroes> heroes = new List<Heroes>();
    }
}
