using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_010",
  "name": [
    "夜魇骑士",
    "Nightbane Templar"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有龙牌，便召唤两个1/1的雏龙。",
    "<b>Battlecry:</b> If you're holding a Dragon, summon two 1/1 Whelps."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39477
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_010 : SimTemplate //* Nightbane Templar
    {
        //Battlecry: If you're holding a Dragon, summon two 1/1 Whelps.

        SimCard kid = CardIds.NonCollectible.Paladin.NightbaneTemplar_Whelp; //Whelp

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                var dragonInHand = false;
                foreach (var hc in p.owncards)
                {
                    if (hc.card.Race == Race.DRAGON)
                    {
                        dragonInHand = true;
                        break;
                    }
                }

                if (dragonInHand)
                {
                    p.callKid(this.kid, own.zonepos, own.own);
                    p.callKid(this.kid, own.zonepos, own.own);
                }
            }
            else
            {
                if (p.enemyAnzCards > 1)
                {
                    p.callKid(this.kid, own.zonepos, own.own);
                    p.callKid(this.kid, own.zonepos, own.own);
                }
            }
        }
    }
}