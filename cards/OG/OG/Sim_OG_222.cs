using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_222",
  "name": [
    "集结之刃",
    "Rallying Blade"
  ],
  "text": [
    "<b>战吼：</b>使你具有<b>圣盾</b>的随从获得+1/+1。",
    "<b>Battlecry:</b> Give +1/+1 to your minions with <b>Divine Shield</b>."
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38745
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_222 : SimTemplate //* Rallying Blade
    {
        //Battlecry: Give +1/+1 to your minions with Divine Shield.

        Chireiden.Silverfish.SimCard w = CardIds.Collectible.Paladin.RallyingBlade;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.divineshild) p.minionGetBuffed(m, 1, 1);
            }
        }
    }
}