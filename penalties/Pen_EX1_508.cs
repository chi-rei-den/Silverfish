namespace HREngine.Bots
{
    class Pen_EX1_508 : PenTemplate //grimscaleoracle
    {
//    alle anderen murlocs haben +1 angriff.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }
    }
}