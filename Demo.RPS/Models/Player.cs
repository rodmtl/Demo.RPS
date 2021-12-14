namespace Demo.RPS.Models
{
    /// <summary>
    /// Basic Player Model for RPS
    /// </summary>
    public class Player
    {
        public int Id { get; set; }
        public int Wins { get; set; }
        /// <summary>
        /// 0 - human
        /// 1 - computer
        /// </summary>
        public int PlayerType { get; set; }
    }
}
