

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_751",
  "name": [
    "渊狱惩击者",
    "Abyssal Enforcer"
  ],
  "text": [
    "<b>战吼：</b>对所有其他角色造成3点伤害。",
    "<b>Battlecry:</b> Deal 3 damage to all other characters."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 7,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40541
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_751 : SimTemplate //* Abyssal Enforcer
    {
        // Battlecry: Deal 3 damage to all other characters.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allCharsGetDamage(3, own.entitiyID);
        }
    }
}