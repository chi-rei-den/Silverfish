using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_004",
  "name": [
    "疯狂的科学家",
    "Mad Scientist"
  ],
  "text": [
    "<b>亡语：</b>\n将一个<b>奥秘</b>从你的牌库中置入战场。",
    "<b>Deathrattle:</b> Put a <b>Secret</b> from your deck into the battlefield."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1783
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_004 : SimTemplate//* Mad Scientist
    {
        // Deathrattle: Put a Secret: from your deck into the battlefield.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownHeroStartClass == TAG_CLASS.MAGE)
                {
                    p.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_289);
                }
                if (p.ownHeroStartClass == TAG_CLASS.HUNTER)
                {
                    p.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_554);
                }
                if (p.ownHeroStartClass == TAG_CLASS.PALADIN)
                {
                    p.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_130);
                }
            }
            else
            {
                if (p.enemyHeroStartClass == TAG_CLASS.MAGE || p.enemyHeroStartClass == TAG_CLASS.HUNTER || p.enemyHeroStartClass == TAG_CLASS.PALADIN)
                {
                    if (p.enemySecretCount <= 4)
                    {
                        p.enemySecretCount++;
                        SecretItem si = Probabilitymaker.Instance.getNewSecretGuessedItem(p.getNextEntity(), p.ownHeroStartClass);
                        if (p.enemyHeroStartClass == TAG_CLASS.PALADIN)
                        {
                            si.canBe_redemption = false;
                        }
                        if (Settings.Instance.useSecretsPlayAround)
                        {
                            p.enemySecretList.Add(si);
                        }
                    }
                }
            }
        }
    }

}
