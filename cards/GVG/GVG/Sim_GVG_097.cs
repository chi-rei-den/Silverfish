

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_097",
  "name": [
    "小个子驱魔者",
    "Lil' Exorcist"
  ],
  "text": [
    "<b>嘲讽</b>，<b>战吼：</b>每有一个具有<b>亡语</b>的敌方随从，便获得+1/+1。",
    "<b>Taunt</b>\n<b>Battlecry:</b> Gain +1/+1 for each enemy <b>Deathrattle</b> minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2065
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_097 : SimTemplate //Lil' Exorcist
    {
        //   Taunt Battlecry: Gain +1/+1 for each enemy Deathrattle minion.
        //todo does silenced count?
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.enemyMinions : p.ownMinions;

            var gain = 0;
            foreach (var m in temp)
            {
                if (m.handcard.card.Deathrattle)
                {
                    gain++;
                }
            }

            if (gain >= 1)
            {
                p.minionGetBuffed(own, gain, gain);
            }
        }
    }
}