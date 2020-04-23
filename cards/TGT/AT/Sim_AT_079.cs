using System.Collections.Generic;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_079",
  "name": [
    "神秘挑战者",
    "Mysterious Challenger"
  ],
  "text": [
    "<b>战吼：</b>将每种不同的<b>奥秘</b>从你的牌库中置入战场。",
    "<b>Battlecry:</b> Put one of each <b>Secret</b> from your deck into the battlefield."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2726
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_079 : SimTemplate //* Mysterious Challenger
    {
        //Battlecry: Put one of each Secret from your deck into the battlefield.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                var secrets = new List<SimCard>();
                SimCard c;
                foreach (var cid in p.prozis.turnDeck)
                {
                    c = cid.Key;
                    if (c.Secret)
                    {
                        secrets.Add(cid.Key);
                    }
                }

                foreach (var cId in secrets)
                {
                    if (p.ownSecretsIDList.Count < 5 && !p.ownSecretsIDList.Contains(cId))
                    {
                        p.ownSecretsIDList.Add(cId);
                    }
                }
            }
            else
            {
                for (var i = p.enemySecretCount; i < 5; i++)
                {
                    p.enemySecretCount++;
                    p.enemySecretList.Add(Probabilitymaker.Instance.getNewSecretGuessedItem(p.getNextEntity(), p.enemyHeroStartClass));
                }
            }
        }
    }
}