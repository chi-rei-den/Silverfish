using HearthDb;

namespace HREngine.Bots
{
    class Pen_EX1_607 : PenTemplate //innerrage
    {
//    fügt einem diener $1 schaden zu. der diener erhält +2 angriff.
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            if (target.own)
            {
                if (m.Hp == 1)
                {
                    return 500;
                }

                if (!m.Ready)
                {
                    return 50;
                }
            }
            else
            {
                //if (m.handcard.card.type == CardType.MINION && p.ownMinions.Count == 0) return 0;
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