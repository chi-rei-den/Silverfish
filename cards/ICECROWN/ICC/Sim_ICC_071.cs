using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_071",
  "name": [
    "光之悲恸",
    "Light's Sorrow"
  ],
  "text": [
    "在一个友方随从失去<b>圣盾</b>后，获得+1攻击力。",
    "After a friendly minion loses <b>Divine Shield</b>, gain +1 Attack."
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 4,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42735
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_071: SimTemplate //* Light's Sorrow
    {
        // After a friendly minion loses Divine Shield, gain +1 Attack.
        // Handled in triggerAMinionLosesDivineShield()

        SimCard weapon = CardIds.Collectible.Paladin.LightsSorrow;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}