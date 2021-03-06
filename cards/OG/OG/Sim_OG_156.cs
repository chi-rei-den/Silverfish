using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_156",
  "name": [
    "怒鳍猎潮者",
    "Bilefin Tidehunter"
  ],
  "text": [
    "<b>战吼：</b>召唤一个1/1并具有<b>嘲讽</b>的软泥怪。",
    "<b>Battlecry:</b> Summon a 1/1 Ooze with <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38538
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_156 : SimTemplate //* Bilefin Tidehunter
    {
        //Battlecry: Summon a 1/1 Ooze with Taunt.

        SimCard kid = CardIds.NonCollectible.Neutral.BilefinTidehunter_Ooze;

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(this.kid, own.zonepos, own.own);
        }
    }
}