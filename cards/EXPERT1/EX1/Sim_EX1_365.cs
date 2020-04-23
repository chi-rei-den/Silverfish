using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_365",
  "name": [
    "神圣愤怒",
    "Holy Wrath"
  ],
  "text": [
    "抽一张牌，并造成等同于其法力值消耗的伤害。",
    "Draw a card and deal damage equal to its Cost."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 5,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 435
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_365 : SimTemplate //holywrath
    {
        // todo ask the posibility manager!
//    zieht eine karte und verursacht schaden, der ihren kosten entspricht.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay);

            var dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}