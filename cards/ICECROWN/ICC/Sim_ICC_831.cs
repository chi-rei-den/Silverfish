using HearthDb;
using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_831",
  "name": [
    "鲜血掠夺者古尔丹",
    "Bloodreaver Gul'dan"
  ],
  "text": [
    "<b>战吼：</b>召唤所有在本局对战中死亡的友方恶魔。",
    "<b>Battlecry:</b> Summon all friendly Demons that died this game."
  ],
  "cardClass": "WARLOCK",
  "type": "HERO",
  "cost": 10,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43415
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_831: SimTemplate
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIds.NonCollectible.Neutral.BloodreaverGuldan_SiphonLife, ownplay); // Siphon Life
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;


            int pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            int kids = 7 - pos;
            if (kids > 0)
            {
                p.callKid(CardIds.Collectible.Warlock.Felguard, pos, ownplay); //Felguard Taunt
                kids--;

                if (kids > 0)
                {
                    foreach (var e in Probabilitymaker.Instance.ownCardsOut)
                    {
                        var kid = e.Key;
                        if (kid.Race == Race.DEMON)
                        {
                            for (int i = 0; i < e.Value; i++)
                            {
                                p.callKid(kid, pos, ownplay);
                                kids--;
                                if (kids < 1) break;
                            }
                            if (kids < 1) break;
                        }
                    }
                }
            }
        }
    }
}