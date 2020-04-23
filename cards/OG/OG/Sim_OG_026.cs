

/* _BEGIN_TEMPLATE_
{
  "id": "OG_026",
  "name": [
    "永恒哨卫",
    "Eternal Sentinel"
  ],
  "text": [
    "<b>战吼：</b>将你所有<b>过载</b>的法力水晶解锁。",
    "<b>Battlecry:</b> Unlock your <b>Overloaded</b> Mana Crystals."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38265
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_026 : SimTemplate //* Eternal Sentinel
    {
        //Battlecry: Unlock your Overloaded Mana Crystals.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.unlockMana();
            }
        }
    }
}