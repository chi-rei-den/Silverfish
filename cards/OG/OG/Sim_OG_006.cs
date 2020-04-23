using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_006",
  "name": [
    "邪鳍审判者",
    "Vilefin Inquisitor"
  ],
  "text": [
    "<b>战吼：</b>\n你的英雄技能变为“召唤一个1/1的鱼人”。",
    "<b>Battlecry:</b> Your Hero Power becomes 'Summon a   1/1 Murloc.'"
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 1,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38227
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_006 : SimTemplate //* Vilefin Inquisitor
    {
        //Battlecry: Your Hero Power becomes 'Summon a 1/1 Murloc.'

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.setNewHeroPower(CardIds.NonCollectible.Paladin.VilefinInquisitor_TheTidalHand, own.own); // The Tidal Hand
        }
    }
}