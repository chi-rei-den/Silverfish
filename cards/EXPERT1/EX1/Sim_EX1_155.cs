

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_155",
  "name": [
    "自然印记",
    "Mark of Nature"
  ],
  "text": [
    "<b>抉择：</b>\n使一个随从获得+4攻击力；或者+4生命值和<b>嘲讽</b>。",
    "<b>Choose One -</b> Give a minion +4 Attack; or +4 Health and <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 151
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_155 : SimTemplate //* markofnature
    {
        //Choose One - Give a minion +4 Attack; or +4 Health and Taunt.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || p.ownFandralStaghelm > 0 && ownplay)
            {
                p.minionGetBuffed(target, 4, 0);
            }

            if (choice == 2 || p.ownFandralStaghelm > 0 && ownplay)
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
}