

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_178a",
  "name": [
    "扎根",
    "Rooted"
  ],
  "text": [
    "+5生命值并具有<b>嘲讽</b>。",
    "+5 Health and <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 7,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 578
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_178a : SimTemplate //* Rooted
    {
        //+5 Health and Taunt.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 0, 5);
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