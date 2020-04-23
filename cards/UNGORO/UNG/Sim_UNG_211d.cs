

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_211d",
  "name": [
    "气之祈咒",
    "Invocation of Air"
  ],
  "text": [
    "对所有敌方随从造成3点伤害。",
    "Deal 3 damage to all enemy minions."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41336
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_211d : SimTemplate //* Invocation of Air
    {
        //Deal 3 damage to all enemy minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
        }
    }
}