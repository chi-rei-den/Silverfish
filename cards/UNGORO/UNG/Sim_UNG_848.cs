

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_848",
  "name": [
    "始生幼龙",
    "Primordial Drake"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>\n对所有其他随从造成2点伤害。",
    "[x]<b>Taunt</b>\n<b>Battlecry:</b> Deal 2 damage\nto all other minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41929
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_848 : SimTemplate //* Primordial Drake
    {
        //Taunt Battlecry: Deal 2 damage to all other minions.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allMinionsGetDamage(2, own.entitiyID);
        }
    }
}