

/* _BEGIN_TEMPLATE_
{
  "id": "AT_052",
  "name": [
    "图腾魔像",
    "Totem Golem"
  ],
  "text": [
    "<b>过载：</b>（1）",
    "<b>Overload:</b> (1)"
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2610
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_052 : SimTemplate //* Totem Golem
    {
        //Overload: (1)

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.ueberladung++;
            }
        }
    }
}