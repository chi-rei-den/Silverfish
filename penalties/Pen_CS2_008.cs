namespace HREngine.Bots
{
    class Pen_CS2_008 : PenTemplate //moonfire
    {
//    verursacht $1 schaden.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }
    }
}