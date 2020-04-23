

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_018",
  "name": [
    "坑道穴居人",
    "Tunnel Trogg"
  ],
  "text": [
    "每当你<b>过载</b>时，每一个被锁的法力水晶会使其获得+1攻击力。",
    "Whenever you <b>Overload</b>, gain +1 Attack per locked Mana Crystal."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2890
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_018 : SimTemplate //* Tunnel Trogg
    {
        //Whenether you Overloaded, gain +1 Attack per locked Mana Crystal.

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.Overload > 0)
            {
                p.minionGetBuffed(triggerEffectMinion, hc.card.Overload, 0);
            }
        }
    }
}