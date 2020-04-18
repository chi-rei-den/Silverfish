using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_086",
  "name": [
    "冰封秘典",
    "Glacial Mysteries"
  ],
  "text": [
    "将每种不同的<b>奥秘</b>从你的牌库中置入战场。",
    "Put one of each <b>Secret</b> from your deck into\nthe battlefield."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 8,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42760
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_086: SimTemplate //* Glacial Mysteries
    {
        // Put one of each Secret from your deck into the battlefield.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                List<Chireiden.Silverfish.SimCard> secrets = new List<Chireiden.Silverfish.SimCard>();
                Chireiden.Silverfish.SimCard c;
                foreach (KeyValuePair<Chireiden.Silverfish.SimCard, int> cid in p.prozis.turnDeck)
                {
                    c = CardDB.Instance.getCardDataFromID(cid.Key);
                    if (c.Secret) secrets.Add(cid.Key);
                }

                foreach (Chireiden.Silverfish.SimCard cId in secrets)
                {
                    if (p.ownSecretsIDList.Count < 5 && !p.ownSecretsIDList.Contains(cId)) p.ownSecretsIDList.Add(cId);
                }
            }
            else
            {
                for (int i = p.enemySecretCount; i < 5; i++)
                {
                    p.enemySecretCount++;
                    p.enemySecretList.Add(Probabilitymaker.Instance.getNewSecretGuessedItem(p.getNextEntity(), p.enemyHeroStartClass));
                }
            }
        }
	}
}