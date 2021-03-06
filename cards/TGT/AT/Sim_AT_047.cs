using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_047",
  "name": [
    "德莱尼图腾师",
    "Draenei Totemcarver"
  ],
  "text": [
    "<b>战吼：</b>每有一个友方图腾，便获得+1/+1。",
    "<b>Battlecry:</b> Gain +1/+1 for each friendly Totem."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2613
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_047 : SimTemplate //* Draenei Totemcarver
    {
        //Battlecry: Gain +1/+1 for each friendly Totem.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var gain = 0;
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.handcard.card.Race == Race.TOTEM)
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