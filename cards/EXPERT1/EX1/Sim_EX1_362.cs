

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_362",
  "name": [
    "银色保卫者",
    "Argent Protector"
  ],
  "text": [
    "<b>战吼：</b>使一个其他友方随从获得<b>圣盾</b>。",
    "<b>Battlecry:</b> Give a friendly minion <b>Divine Shield</b>."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1022
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_362 : SimTemplate //argentprotector
    {
//    kampfschrei:/ verleiht einem befreundeten diener gottesschild/.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                target.divineshild = true;
            }
        }
    }
}