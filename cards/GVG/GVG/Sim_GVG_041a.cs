

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_041a",
  "name": [
    "守护者的呼唤",
    "Call the Guardians"
  ],
  "text": [
    "+5/+5并具有<b>嘲讽</b>。",
    "+5/+5 and <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2176
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_041a : SimTemplate //* Dark Wispers
    {
        //   Give a minion +5/+5 and Taunt.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
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