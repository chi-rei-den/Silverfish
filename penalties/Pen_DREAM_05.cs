using HearthDb;

namespace HREngine.Bots
{
    class Pen_DREAM_05 : PenTemplate //nightmare
    {
//    verleiht einem diener +5/+5. zu beginn eures nächsten zuges wird er vernichtet.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            if (target.own)
            {
                if (!m.Ready)
                {
                    return 500;
                }

                return 0;
            }

            if (target.frozen)
            {
                return 0;
            }

            foreach (var hc in p.owncards)
            {
                if (hc.card.CardId == CardIds.Collectible.Neutral.BigGameHunter || hc.card.CardId == CardIds.Collectible.Priest.ShadowWordDeath)
                {
                    return 0;
                }
            }

            return 20;
            return 0;
        }
    }
}