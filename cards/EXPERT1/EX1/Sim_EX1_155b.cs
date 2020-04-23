

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_155b",
  "name": [
    "皮糙肉厚",
    "Thick Hide"
  ],
  "text": [
    "+4生命值并具有<b>嘲讽</b>。",
    "+4 Health and <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 690
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_155b : SimTemplate //* markofnature
    {
        //+4 Health and Taunt.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 0, 4);
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