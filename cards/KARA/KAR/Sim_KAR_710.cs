using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_710",
  "name": [
    "奥能铁匠",
    "Arcanosmith"
  ],
  "text": [
    "<b>战吼：</b>召唤一个0/5并具有<b>嘲讽</b>的随从。",
    "<b>Battlecry:</b> Summon a 0/5 minion with <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39491
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_710 : SimTemplate //* Arcanosmith
    {
        //Battlecry: Summon a 0/5 minion with Taunt.

        SimCard kid = CardIds.NonCollectible.Neutral.Arcanosmith_AnimatedShield; //Animated Shield

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(this.kid, own.zonepos, own.own);
        }
    }
}