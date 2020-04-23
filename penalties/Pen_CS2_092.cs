using HearthDb;

namespace HREngine.Bots
{
    class Pen_CS2_092 : PenTemplate //blessingofkings
    {
//    verleiht einem diener +4/+4. i&gt;(+4 angriff/+4 leben)/i&gt;
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            if (target.own)
            {
                if (!m.Ready)
                {
                    return 50;
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