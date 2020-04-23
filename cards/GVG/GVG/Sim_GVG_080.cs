using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_080",
  "name": [
    "尖牙德鲁伊",
    "Druid of the Fang"
  ],
  "text": [
    "<b>战吼：</b>如果你控制任何野兽，将该随从变形成为7/7。",
    "<b>Battlecry:</b> If you have a Beast, transform this minion into a 7/7."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2048
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_080 : SimTemplate //* Druid of the Fang
    {
        //   Battlecry:If you have a Beast, transform this minion into a 7/7.
        SimCard betterguy = CardIds.NonCollectible.Druid.DruidoftheFang_DruidOfTheFangToken;

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            var hasbeast = false;
            foreach (var m in temp)
            {
                if (m.handcard.card.Race == Race.PET)
                {
                    hasbeast = true;
                    break;
                }
            }

            if (hasbeast)
            {
                p.minionTransform(own, this.betterguy);
            }
        }
    }
}