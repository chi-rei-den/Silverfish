namespace HREngine.Bots
{
    class Pen_CS2_088 : PenTemplate //guardianofkings
    {
//    kampfschrei:/ stellt bei eurem helden 6 leben wieder her.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }
    }
}