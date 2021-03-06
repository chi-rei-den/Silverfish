using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_315",
  "name": [
    "雄斑虎",
    "Alleycat"
  ],
  "text": [
    "<b>战吼：</b>召唤一个1/1的雌斑虎。",
    "<b>Battlecry:</b> Summon a 1/1 Cat."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40426
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_315 : SimTemplate //* Alleycat
    {
        // Battlecry: Summon a 1/1 Cat.

        SimCard kid = CardIds.NonCollectible.Hunter.Alleycat_TabbycatToken; //1/1 Cat

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(this.kid, m.zonepos, m.own);
        }
    }
}