using System;
using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_114",
  "name": [
    "禁忌仪式",
    "Forbidden Ritual"
  ],
  "text": [
    "消耗你所有的法力值，每消耗一点法力值，便召唤一个1/1的触须。",
    "Spend all your Mana. Summon that many 1/1 Tentacles."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 0,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38454
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_114 : SimTemplate //* Forbidden Ritual
    {
        //Spend all your Mana. Summon that many 1/1 Tentacles.

        SimCard kid = CardIds.NonCollectible.Warlock.ForbiddenRitual_IckyTentacle; //Icky Tentacle

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                if (p.mana > 0)
                {
                    var pos = p.ownMinions.Count;
                    var anz = Math.Min(7 - pos, p.mana);
                    p.callKid(this.kid, pos, ownplay, false);
                    anz--;
                    for (var i = 0; i < anz; i++)
                    {
                        p.callKid(this.kid, pos, ownplay);
                    }

                    p.mana = 0;
                }
            }
        }
    }
}