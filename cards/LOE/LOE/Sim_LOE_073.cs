using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_073",
  "name": [
    "石化魔暴龙",
    "Fossilized Devilsaur"
  ],
  "text": [
    "<b>战吼：</b>\n如果你控制一个野兽，便获得<b>嘲讽</b>。",
    "<b>Battlecry:</b> If you control a Beast, gain <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2945
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_073 : SimTemplate //* Fossilized Devilsaur
    {
        //Battlecry: If you control a Beast, gain Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.handcard.card.Race == Race.PET)
                {
                    own.taunt = true;
                    if (own.own)
                    {
                        p.anzOwnTaunt++;
                    }
                    else
                    {
                        p.anzEnemyTaunt++;
                    }

                    break;
                }
            }
        }
    }
}