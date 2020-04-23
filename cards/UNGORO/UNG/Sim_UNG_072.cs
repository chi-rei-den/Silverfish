using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_072",
  "name": [
    "石丘防御者",
    "Stonehill Defender"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>\n<b>发现</b>一张具有<b>嘲讽</b>的随从牌。",
    "<b>Taunt</b>\n<b>Battlecry:</b> <b>Discover</b> a <b>Taunt</b> minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41243
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_072 : SimTemplate //* Stonehill Defender
    {
        //Taunt. Battlecry: Discover a Taunt minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardIds.Collectible.Neutral.PompousThespian, own.own, true);
        }
    }
}