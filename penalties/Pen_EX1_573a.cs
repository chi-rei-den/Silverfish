namespace HREngine.Bots
{
    class Pen_EX1_573a : PenTemplate //demigodsfavor
    {
//    verleiht euren anderen dienern +2/+2.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }
    }
}