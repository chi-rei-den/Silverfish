namespace HREngine.Bots
{
    class Pen_EX1_582 : PenTemplate //dalaranmage
    {
//    zauberschaden +1/
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }
    }
}