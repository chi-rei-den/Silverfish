namespace HREngine.Bots
{
    class Pen_EX1_178a : PenTemplate //rooted
    {
//    +5 leben und spott/.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }
    }
}