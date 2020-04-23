namespace HREngine.Bots
{
    class Pen_CS2_013 : PenTemplate //wildgrowth
    {
//    erhaltet einen leeren manakristall.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }
    }
}