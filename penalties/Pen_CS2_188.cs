using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
    class Pen_CS2_188 : PenTemplate //abusivesergeant
    {
//    kampfschrei:/ verleiht einem diener +2 angriff in diesem zug.
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
                if (m.handcard.card.Type == CardType.MINION && p.ownMinions.Count == 0)
                {
                    return 0;
                }

                //allow it if you have biggamehunter
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