

/* _BEGIN_TEMPLATE_
{
  "id": "PART_002",
  "name": [
    "时间回溯装置",
    "Time Rewinder"
  ],
  "text": [
    "将一个友方随从移回你的手牌。",
    "Return a friendly minion to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2152
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_PART_002 : SimTemplate //Time Rewinder
    {
        //   Return a friendly minion to your hand.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionReturnToHand(target, target.own, 0);
        }
    }
}