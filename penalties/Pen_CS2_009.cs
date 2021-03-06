using HearthDb;

namespace HREngine.Bots
{
    class Pen_CS2_009 : PenTemplate //markofthewild
    {
//    verleiht einem diener spott/ und +2/+2.i&gt; (+2 angriff/+2 leben)/i&gt;
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

                var enemyHasTaunts = false;
                foreach (var e in p.enemyMinions)
                {
                    if (e.taunt)
                    {
                        enemyHasTaunts = true;
                    }
                }

                if (!target.taunt && !target.silenced && target.handcard.card.targetPriority >= 1 && enemyHasTaunts)
                {
                    return 0;
                }

                return 500;
            }

            return 0;
        }
    }
}