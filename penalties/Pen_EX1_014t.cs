using HearthDb;

namespace HREngine.Bots
{
    class Pen_EX1_014t : PenTemplate //bananas
    {
//    verleiht einem diener +1/+1.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            if (target.own)
            {
                if (!m.Ready)
                {
                    return 50;
                }

                if (m.Hp == 1 && !m.divineshild)
                {
                    return 10;
                }
            }
            else
            {
                foreach (var hc in p.owncards)
                {
                    if (hc.card.CardId == CardIds.Collectible.Neutral.BigGameHunter || hc.card.CardId == CardIds.Collectible.Priest.ShadowWordDeath)
                    {
                        return 0;
                    }
                }

                return 500;
            }

            return 0;
        }
    }
}