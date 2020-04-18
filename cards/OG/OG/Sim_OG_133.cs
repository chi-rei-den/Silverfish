using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_133",
  "name": [
    "恩佐斯",
    "N'Zoth, the Corruptor"
  ],
  "text": [
    "<b>战吼：</b>召唤所有你在本局对战中死亡的，并具有<b>亡语</b>的随从。",
    "<b>Battlecry:</b> Summon your <b>Deathrattle</b> minions that died this game."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 10,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38496
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_133 : SimTemplate //* N'Zoth, the Corruptor
    {
        //Battlecry: Summon your Deathrattle minions that died this game.

        Chireiden.Silverfish.SimCard kid = null;

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int kids = 7 - p.ownMinions.Count;

            if (kids > 0)
            {
                foreach (var e in Probabilitymaker.Instance.ownCardsOut)
                {
                    kid = e.Key;
                    if (kid.Deathrattle)
                    {
                        for (int i = 0; i < e.Value; i++)
                        {
                            p.callKid(kid, own.zonepos, own.own);
                            kids--;
                            if (kids < 1) break;
                        }
                        if (kids < 1) break;
                    }
                }
            }
        }
    }
}