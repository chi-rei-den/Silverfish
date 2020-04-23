using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_080",
  "name": [
    "要塞指挥官",
    "Garrison Commander"
  ],
  "text": [
    "每个回合你可以使用两次英雄技能。",
    "You can use your Hero Power twice a turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2517
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_080 : SimTemplate //* Garrison Commander
    {
        //You can use your Hero Power twice on your turn.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                var another = false;
                foreach (var m in p.ownMinions)
                {
                    if (m.name == CardIds.Collectible.Neutral.GarrisonCommander && own.entitiyID != m.entitiyID)
                    {
                        another = true;
                    }
                }

                if (!another)
                {
                    p.ownHeroPowerAllowedQuantity++;
                }
            }
            else
            {
                var another = false;
                foreach (var m in p.enemyMinions)
                {
                    if (m.name == CardIds.Collectible.Neutral.GarrisonCommander && own.entitiyID != m.entitiyID)
                    {
                        another = true;
                    }
                }

                if (!another)
                {
                    p.enemyHeroPowerAllowedQuantity++;
                }
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                var another = false;
                foreach (var m in p.ownMinions)
                {
                    if (m.name == CardIds.Collectible.Neutral.GarrisonCommander && own.entitiyID != m.entitiyID)
                    {
                        another = true;
                    }
                }

                if (!another)
                {
                    p.ownHeroPowerAllowedQuantity--;
                }

                if (p.anzUsedOwnHeroPower >= p.ownHeroPowerAllowedQuantity)
                {
                    p.ownAbilityReady = false;
                }
            }
            else
            {
                var another = false;
                foreach (var m in p.enemyMinions)
                {
                    if (m.name == CardIds.Collectible.Neutral.GarrisonCommander && own.entitiyID != m.entitiyID)
                    {
                        another = true;
                    }
                }

                if (!another)
                {
                    p.enemyHeroPowerAllowedQuantity--;
                }

                if (p.anzUsedEnemyHeroPower >= p.enemyHeroPowerAllowedQuantity)
                {
                    p.enemyAbilityReady = false;
                }
            }
        }
    }
}