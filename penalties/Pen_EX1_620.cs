namespace HREngine.Bots
{
    class Pen_EX1_620 : PenTemplate //moltengiant
    {
//    kostet (1) weniger für jeden schadenspunkt, den euer held erlitten hat.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            return 0;
        }
    }
}