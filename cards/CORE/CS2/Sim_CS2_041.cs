

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_041",
  "name": [
    "先祖治疗",
    "Ancestral Healing"
  ],
  "text": [
    "为一个随从恢复所有生命值并使其获得<b>嘲讽</b>。",
    "Restore a minion\nto full Health and\ngive it <b>Taunt</b>."
  ],
  "CardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 0,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 149
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_041 : SimTemplate //* ancestralhealing
    {
//    Restore a minion to full Health and give it Taunt.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(target, -1000);
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own)
                {
                    p.anzOwnTaunt++;
                }
                else
                {
                    p.anzEnemyTaunt++;
                }
            }
        }
    }
}