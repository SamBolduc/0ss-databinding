using System.ComponentModel;
using System.Runtime.CompilerServices;
using Formatif_1.Annotations;

namespace Formatif_1
{
    public class Game
    {
        public string Title { get; set; }
        public string Editor { get; set; }
        public string Description { get; set; }
        public int ReleaseDate { get; set; }
        public string Console { get; set; }
        public string CoverPath { get; set; }
        public double Cote { get; set; }
    }
}