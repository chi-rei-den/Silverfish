

/* _BEGIN_TEMPLATE_
{
  "id": "PART_003",
  "name": [
    "生锈的号角",
    "Rusty Horn"
  ],
  "text": [
    "使一个随从获得<b>嘲讽</b>。",
    "Give a minion <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2153
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_PART_003 : SimTemplate //* Rusty Horn
    {
        // Give a minion Taunt.  

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
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