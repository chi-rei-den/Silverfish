

/* _BEGIN_TEMPLATE_
{
  "id": "OG_321",
  "name": [
    "疯狂的信徒",
    "Crazed Worshipper"
  ],
  "text": [
    "<b>嘲讽</b>。每当该随从受到伤害，使你的克苏恩获得+1/+1<i>（无论它在哪里）。</i>",
    "<b>Taunt.</b> Whenever this minion takes damage, give your C'Thun +1/+1 <i>(wherever it is).</i>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38958
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_321 : SimTemplate //* Crazed Worshipper
    {
        //Taunt. Whenever this minion takes damage, give your C'Thun +1/+1 (wherever it is).

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                var tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                p.cthunGetBuffed(tmp, tmp, 0);
            }
        }
    }
}