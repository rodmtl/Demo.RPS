using System.Collections.Generic;

namespace Demo.RPS.Models
{
    /// <summary>
    /// Basic Model for RPS weapons
    /// </summary>
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Beats { get; set; }
    }
}
