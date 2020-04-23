using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_019",
  "name": [
    "飞刀杂耍者",
    "Knife Juggler"
  ],
  "text": [
    "在你召唤一个随从后，随机对一个敌方角色造成1点伤害。",
    "[x]After you summon a\nminion, deal 1 damage\nto a random enemy."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1073
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_019 : SimTemplate //knifejuggler
    {
        //    fügt einem zufälligen feind 1 schaden zu, nachdem ihr einen diener herbeigerufen habt.
        public override void onMinionWasSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.entitiyID != summonedMinion.entitiyID && triggerEffectMinion.own == summonedMinion.own)
            {
                var temp = triggerEffectMinion.own ? p.enemyMinions : p.ownMinions;

                if (temp.Count >= 1)
                {
                    //search Minion with lowest hp
                    var enemy = temp[0];
                    var minhp = 10000;
                    var found = false;
                    foreach (var m in temp)
                    {
                        if (m.name == CardIds.Collectible.Neutral.NerubianEgg && m.Hp >= 2)
                        {
                            continue; //dont attack nerubianegg!
                        }

                        if (m.handcard.card.IsToken && m.Hp == 1)
                        {
                            continue;
                        }

                        if (m.name == CardIds.NonCollectible.Paladin.NobleSacrifice_Defender)
                        {
                            continue;
                        }

                        if (m.name == CardIds.Collectible.Mage.Spellbender)
                        {
                            continue;
                        }

                        if (m.Hp >= 2 && minhp > m.Hp)
                        {
                            enemy = m;
                            minhp = m.Hp;
                            found = true;
                        }
                    }

                    if (found)
                    {
                        p.minionGetDamageOrHeal(enemy, 1);
                    }
                    else
                    {
                        p.minionGetDamageOrHeal(triggerEffectMinion.own ? p.enemyHero : p.ownHero, 1);
                    }
                }
                else
                {
                    p.minionGetDamageOrHeal(triggerEffectMinion.own ? p.enemyHero : p.ownHero, 1);
                }

                triggerEffectMinion.stealth = false;
            }
        }
    }
}