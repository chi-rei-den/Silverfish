using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
    class Pen_EX1_603 : PenTemplate //crueltaskmaster
    {
//    kampfschrei:/ fügt einem diener 1 schaden zu und verleiht ihm +2 angriff.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            if (target.own)
            {
                if (m.Hp == 1)
                {
                    return 50;
                }

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

                if (m.Hp == 1)
                {
                    return 0;
                }

                if (!m.wounded && (m.Angr >= 4 || m.Hp >= 5))
                {
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.CardId == CardIds.Collectible.Warrior.Execute)
                        {
                            return 0;
                        }
                    }
                }

                return this.getValueOfMinion(4, 5);
            }

            return 0;
        }
    }
}