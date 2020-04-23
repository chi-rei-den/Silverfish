using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_208",
  "name": [
    "岩石哨兵",
    "Stone Sentinel"
  ],
  "text": [
    "<b>战吼：</b>如果你在上个回合使用过元素牌，则召唤两个2/3并具有<b>嘲讽</b>的元素。",
    "<b>Battlecry:</b> If you played an Elemental last turn, summon two 2/3 Elementals with <b>Taunt</b>."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 7,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41116
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_208 : SimTemplate //* Stone Sentinel
    {
        //Battlecry: If you played an Elemental last turn, summon two 2/3 Elementals with Taunt.

        SimCard kid = CardIds.NonCollectible.Shaman.StoneSentinel_RockElementalToken; //Rock Elemental

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.anzOwnElementalsLastTurn > 0 && own.own)
            {
                p.callKid(this.kid, own.zonepos - 1, own.own); //1st left
                p.callKid(this.kid, own.zonepos, own.own);
            }
        }
    }
}