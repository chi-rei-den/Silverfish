

/* _BEGIN_TEMPLATE_
{
  "id": "AT_069",
  "name": [
    "格斗陪练师",
    "Sparring Partner"
  ],
  "text": [
    "<b>嘲讽</b>\n<b>战吼：</b>使一个随从获得<b>嘲讽</b>。",
    "<b>Taunt</b>\n<b>Battlecry:</b> Give a\nminion <b>Taunt</b>."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2733
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_069 : SimTemplate //* Sparring Partner
    {
        //Taunt Battlecry: Give a minion Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null && !target.taunt)
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