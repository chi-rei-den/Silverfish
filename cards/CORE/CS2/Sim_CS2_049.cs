using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_049",
  "name": [
    "图腾召唤",
    "Totemic Call"
  ],
  "text": [
    "<b>英雄技能</b>\n随机召唤一个\n图腾。",
    "<b>Hero Power</b>\nSummon a random Totem."
  ],
  "CardClass": "SHAMAN",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 687
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_049 : SimTemplate // totemiccall
    {
        //Hero Power: Summon a random Totem.

        SimCard searing = CardIds.NonCollectible.Shaman.SearingTotem;
        SimCard healing = CardIds.NonCollectible.Shaman.HealingTotem;
        SimCard wrathofair = CardIds.NonCollectible.Shaman.WrathOfAirTotem;
        SimCard stoneclaw = CardIds.NonCollectible.Shaman.StoneclawTotem;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            SimCard kid;
            var otherTotems = 0;
            var wrath = false;
            foreach (var m in ownplay ? p.ownMinions : p.enemyMinions)
            {
                switch (m.name.CardId)
                {
                    case CardIds.NonCollectible.Shaman.SearingTotem:
                        otherTotems++;
                        continue;
                    case CardIds.NonCollectible.Shaman.StoneclawTotem:
                        otherTotems++;
                        continue;
                    case CardIds.NonCollectible.Shaman.HealingTotem:
                        otherTotems++;
                        continue;
                    case CardIds.NonCollectible.Shaman.WrathOfAirTotem:
                        wrath = true;
                        continue;
                }
            }

            if (p.isLethalCheck)
            {
                if (otherTotems == 3 && !wrath)
                {
                    kid = this.wrathofair;
                }
                else
                {
                    kid = this.healing;
                }
            }
            else
            {
                if (!wrath)
                {
                    kid = this.wrathofair;
                }
                else
                {
                    kid = this.searing;
                }

                if (p.ownHeroHasDirectLethal())
                {
                    kid = this.stoneclaw;
                }
            }

            p.callKid(kid, pos, ownplay, false);
        }
    }
}