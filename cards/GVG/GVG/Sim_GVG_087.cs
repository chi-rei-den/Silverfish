using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_087",
  "name": [
    "热砂港狙击手",
    "Steamwheedle Sniper"
  ],
  "text": [
    "你的英雄技能能够以随从为目标。",
    "Your Hero Power can target minions."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2055
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_087 : SimTemplate //* Steamwheedle Sniper
    {
        //  Your Hero Power can target minions. 

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.weHaveSteamwheedleSniper = true;
            }
            else
            {
                p.enemyHaveSteamwheedleSniper = true;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                var hasss = false;
                foreach (var mnn in p.ownMinions)
                {
                    if (m.name == CardIds.Collectible.Hunter.SteamwheedleSniper && !mnn.silenced)
                    {
                        hasss = true;
                    }
                }

                p.weHaveSteamwheedleSniper = hasss;
            }
            else
            {
                var hasss = false;
                foreach (var mnn in p.enemyMinions)
                {
                    if (m.name == CardIds.Collectible.Hunter.SteamwheedleSniper && !mnn.silenced)
                    {
                        hasss = true;
                    }
                }

                p.enemyHaveSteamwheedleSniper = hasss;
            }
        }
    }
}