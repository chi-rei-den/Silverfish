using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_041",
  "name": [
    "黑暗私语",
    "Dark Wispers"
  ],
  "text": [
    "<b>抉择：</b>\n召唤5个小精灵；或者使一个随从获得+5/+5和<b>嘲讽</b>。",
    "<b>Choose One -</b> Summon 5 Wisps; or Give a minion +5/+5 and <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2009
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_041 : SimTemplate //* Dark Wispers
    {
        //   Choose One - Summon 5 Wisps; or Give a minion +5/+5 and Taunt.

        SimCard kid = CardIds.Collectible.Neutral.Wisp;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || p.ownFandralStaghelm > 0 && ownplay)
            {
                for (var i = 0; i < 5; i++)
                {
                    var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
                    p.callKid(this.kid, pos, ownplay);
                }
            }

            if (choice == 2 || p.ownFandralStaghelm > 0 && ownplay)
            {
                if (target != null)
                {
                    p.minionGetBuffed(target, 5, 5);
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
    }
}