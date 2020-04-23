using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_816",
  "name": [
    "卡利莫斯的仆从",
    "Servant of Kalimos"
  ],
  "text": [
    "<b>战吼：</b>如果你在上个回合使用过元素牌，则<b>发现</b>一张元素牌。",
    "[x]<b>Battlecry:</b> If you played\nan Elemental last turn,\n <b>Discover</b> an Elemental."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41410
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_816 : SimTemplate //* Servant of Kalimos
    {
        //Battlecry: If you played an Elemental last turn Discover an Elemental.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.anzOwnElementalsLastTurn > 0 && own.own)
            {
                p.drawACard(CardIds.Collectible.Shaman.HotSpringGuardian, own.own, true);
            }
        }
    }
}