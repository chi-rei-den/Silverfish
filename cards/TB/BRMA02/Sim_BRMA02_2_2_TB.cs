using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA02_2_2_TB",
  "name": [
    "强势围观",
    "Jeering Crowd"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个1/1并具有<b>嘲讽</b>的观众。",
    "<b>Hero Power</b>\nSummon a 1/1 Spectator with <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 31457
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA02_2_2_TB : SimTemplate //* Jeering Crowd
    {
        // Hero Power: Summon a 1/1 Spectator with Taunt.

        SimCard kid = CardIds.NonCollectible.Neutral.JeeringCrowd_DarkIronSpectatorToken; //Dark Iron Spectator

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var place = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, place, ownplay, false);
        }
    }
}