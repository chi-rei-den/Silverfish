using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_034",
  "name": [
    "机械野兽",
    "Mech-Bear-Cat"
  ],
  "text": [
    "每当该随从受到伤害，将一张<b>零件</b>牌置入你的手牌。",
    "Whenever this minion takes damage, add a <b>Spare Part</b> card to your hand."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2002
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_034 : SimTemplate //* Mech-Bear-Cat
    {
        // Whenever this minion takes damage, add a Spare Part card to your hand.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                var tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (var i = 0; i < tmp; i++)
                {
                    p.drawACard(CardIds.NonCollectible.Neutral.ArmorPlating, m.own, true);
                }
            }
        }
    }
}