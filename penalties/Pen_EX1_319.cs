namespace HREngine.Bots
{
    class Pen_EX1_319 : PenTemplate //flameimp
    {
//    kampfschrei:/ fügt eurem helden 3 schaden zu.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }
    }
}