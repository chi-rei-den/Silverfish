namespace HREngine.Bots
{
    class Pen_CS2_mirror : PenTemplate //mirrorimage
    {
//    spott/
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }
    }
}