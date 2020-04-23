

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_018",
  "name": [
    "血帆袭击者",
    "Bloodsail Raider"
  ],
  "text": [
    "<b>战吼：</b>\n获得等同于你的武器攻击力的攻击力。",
    "<b>Battlecry:</b> Gain Attack equal to the Attack\nof your weapon."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 999
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_018 : SimTemplate //bloodsail raider
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.Angr += p.ownWeapon.Angr;
        }
    }
}