using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_481",
  "name": [
    "死亡先知萨尔",
    "Thrall, Deathseer"
  ],
  "text": [
    "<b>战吼：</b>随机将你的所有随从变形成为法力值消耗增加（2）点的随从。",
    "<b>Battlecry:</b> Transform your minions into random ones that cost (2) more."
  ],
  "cardClass": "SHAMAN",
  "type": "HERO",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42987
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_481: SimTemplate //* Thrall, Deathseer
    {
        // Battlecry: Transform your minions into random ones that cost (2) more.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIds.NonCollectible.Neutral.ThrallDeathseer_TransmuteSpirit, ownplay); // Transmute Spirit
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                p.minionTransform(m, p.getRandomCardForManaMinion(m.handcard.card.cost + 2));
            }
        }
    }
}