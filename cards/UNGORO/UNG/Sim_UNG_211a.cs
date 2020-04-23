using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_211a",
  "name": [
    "土之祈咒",
    "Invocation of Earth"
  ],
  "text": [
    "召唤数个1/1的元素，直到你的随从数量达到上限。",
    "Fill your board with 1/1 Elementals."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41330
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_211a : SimTemplate //* Invocation of Earth
    {
        //Fill your board with 1/1 Elementals.

        SimCard kid = CardIds.NonCollectible.Shaman.KalimosPrimalLord_StoneElemental; //Stone Elemental

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var MinionsCount = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(this.kid, MinionsCount, ownplay, false);
            var kids = 6 - MinionsCount;
            for (var i = 0; i < kids; i++)
            {
                p.callKid(this.kid, MinionsCount, ownplay);
            }
        }
    }
}