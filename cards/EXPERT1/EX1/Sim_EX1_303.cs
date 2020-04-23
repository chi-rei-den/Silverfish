

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_303",
  "name": [
    "暗影烈焰",
    "Shadowflame"
  ],
  "text": [
    "消灭一个友方随从，对所有敌方随从造成等同于其攻击力的伤害。",
    "Destroy a friendly minion and deal its Attack damage to all enemy minions."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 147
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_303 : SimTemplate //shadowflame
    {
//    vernichtet einen befreundeten diener und fügt allen feindlichen dienern schaden zu, der seinem angriff entspricht.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var damage1 = ownplay ? p.getSpellDamageDamage(target.Angr) : p.getEnemySpellDamageDamage(target.Angr);

            p.minionGetDestroyed(target);

            p.allMinionOfASideGetDamage(!ownplay, damage1);
        }
    }
}