namespace HREngine.Bots
{
    class Pen_CS2_046 : PenTemplate //bloodlust
    {
//    verleiht euren dienern +3 angriff in diesem zug.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            if (!isLethal)
            {
                var targets = 0;
                foreach (var mnn in p.ownMinions)
                {
                    if (mnn.Ready)
                    {
                        targets++;
                    }
                }

                if (targets <= 1)
                {
                    return 40;
                }

                if (targets <= 2)
                {
                    return 20;
                }
            }

            return 0;
        }
    }
}