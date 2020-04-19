namespace HREngine.Bots
{
    public class BehaviorRush : Behavior
    {
        public override string BehaviorName() { return "怼脸模式"; }


        PenalityManager penman = PenalityManager.Instance;

        public override float getPlayfieldValue(Playfield p)
        {
            if (p.value >= -2000000) return p.value;
            int retval = 0;
            retval -= p.evaluatePenality;
            retval += p.owncards.Count * 3;
            retval += p.ownQuest.questProgress * 10;

            retval += p.ownHero.Hp + p.ownHero.armor;
            retval += -(p.enemyHero.Hp + p.enemyHero.armor);

            retval += p.ownMaxMana * 15 - p.enemyMaxMana * 15;

            if (p.ownHeroPowerAllowedQuantity != p.enemyHeroPowerAllowedQuantity)
            {
                if (p.ownHeroPowerAllowedQuantity > p.enemyHeroPowerAllowedQuantity) retval += 1;
                else retval -= 4;
            }

            if (p.ownWeapon.Angr >= 1)
            {
                retval += p.ownWeapon.Angr * p.ownWeapon.Durability;
            }

            if (!p.enemyHero.frozen)
            {
                retval -= p.enemyWeapon.Durability * p.enemyWeapon.Angr;
            }
            else
            {
                if (p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.priest)
                {
                    retval += 11;
                }
            }

            //RR card draw value depending on the turn and distance to lethal
            //RR if lethal is close, carddraw value is increased
            if (p.lethalMissing() <= 5) //RR
            {
                retval += p.owncarddraw * 100;
            }
            if (p.ownMaxMana < 4)
            {
                retval += p.owncarddraw * 2;
            }
            else
            {
                retval += p.owncarddraw * 5;
            }
            retval += p.owncarddraw * 5;
            if (p.owncarddraw + 1 >= p.enemycarddraw) retval -= p.enemycarddraw * 7;
            else retval -= (p.owncarddraw + 1) * 7 + (p.enemycarddraw - p.owncarddraw - 1) * 12;

            bool useAbili = false;
            int usecoin = 0;
            foreach (Action a in p.playactions)
            {
                if (a.actionType == actionEnum.attackWithHero && p.enemyHero.Hp <= p.attackFaceHP) retval++;
                if (a.actionType == actionEnum.useHeroPower) useAbili = true;
                if (p.ownHeroName == HeroEnum.warrior && a.actionType == actionEnum.attackWithHero && useAbili) retval -= 1;
                //if (a.actionType == actionEnum.useHeroPower && a.card.card.name == CardIds.NonCollectible.Priest.LesserHeal && (!a.target.own)) retval -= 5;
                if (a.actionType != actionEnum.playcard) continue;
                if (a.card.card.CardId == CardIds.NonCollectible.Neutral.TheCoin || a.card.card.CardId == CardIds.Collectible.Druid.Innervate) usecoin++;

                if(a.card.card.Type == CardType.SPELL && a.card.card.CardId == CardIds.Collectible.Mage.Fireball && (a.target.isHero && !a.target.own)) retval += 2;
                if (a.card.card.Type == CardType.SPELL && a.card.card.CardId == Chireiden.Silverfish.SimCard.roaringtorch && (a.target.isHero && !a.target.own)) retval += 2;
                if(a.card.card.Secret) retval += 5;
            }
            if (usecoin > 0)
            {
                if (useAbili && p.ownMaxMana <= 2) retval -= 40;
                retval -= 5 * p.manaTurnEnd;
                if (p.manaTurnEnd + usecoin > 10) retval -= 5 * usecoin;
            }
            if (p.manaTurnEnd >= 2 && !useAbili && p.ownAbilityReady)
            {
                switch (p.ownHeroAblility.card.CardId)
                {
                    case Chireiden.Silverfish.SimCard.heal: goto case CardIds.NonCollectible.Priest.LesserHeal;
                    case CardIds.NonCollectible.Priest.LesserHeal:
                        bool wereTarget = false;
                        if (p.ownHero.Hp < p.ownHero.maxHp) wereTarget = true;
                        if (!wereTarget)
                        {
                            foreach (Minion m in p.ownMinions)
                            {
                                if (m.wounded) { wereTarget = true; break; }
                            }
                        }
                        if (wereTarget && !(p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0)) retval -= 10;
                        break;
                    case Chireiden.Silverfish.SimCard.poisoneddaggers: goto case CardIds.NonCollectible.Rogue.DaggerMastery;
                    case CardIds.NonCollectible.Rogue.DaggerMastery:
                        if (!(p.ownWeapon.Durability > 1 || p.ownWeapon.Angr > 1)) retval -= 10;
                        break;
                    case Chireiden.Silverfish.SimCard.totemicslam: goto case CardIds.NonCollectible.Shaman.TotemicCall;
                    case CardIds.NonCollectible.Shaman.TotemicCall:
                        if (p.ownMinions.Count < 7) retval -= 10;
                        else retval -= 3;
                        break;
                    case Chireiden.Silverfish.SimCard.thetidalhand: goto case Chireiden.Silverfish.SimCard.reinforce;
                    case CardIds.NonCollectible.Paladin.TheSilverHand: goto case Chireiden.Silverfish.SimCard.reinforce;
                    case Chireiden.Silverfish.SimCard.reinforce:
                        if (p.ownMinions.Count < 7) retval -= 10;
                        else retval -= 3;
                        break;
                    case Chireiden.Silverfish.SimCard.soultap: 
                        if (p.owncards.Count < 10 && p.ownDeckSize > 0) retval -= 10;
                        break;
                    case CardIds.NonCollectible.Warlock.LifeTap: 
                        if (p.owncards.Count < 10 && p.ownDeckSize > 0)
                        {
                            retval -= 10;
                            if (p.ownHero.immune) retval -= 5;
                        }
                        break;
                    default:
                        retval -= 10;
                        break;
                }
            }
            //if (usecoin && p.mana >= 1) retval -= 20;

            foreach (Minion m in p.ownMinions)
            {
                retval += m.Hp * 1;
                retval += m.Angr * 2;
                retval += m.handcard.card.rarity;
                if (m.windfury) retval += m.Angr;
                if (m.taunt) retval += 1;
                if (!m.taunt && m.stealth && m.handcard.card.isSpecialMinion && !m.silenced) retval += 20;
                if (m.handcard.card.CardId == Chireiden.Silverfish.SimCard.silverhandrecruit && m.Angr == 1 && m.Hp == 1) retval -= 5;
                if (p.ownMinions.Count > 1 && (m.handcard.card.CardId == CardIds.Collectible.Neutral.DireWolfAlpha || m.handcard.card.CardId == CardIds.Collectible.Shaman.FlametongueTotem || m.handcard.card.CardId == CardIds.Collectible.Neutral.StormwindChampion || m.handcard.card.CardId == CardIds.Collectible.Neutral.RaidLeader || m.handcard.card.CardId == CardIds.Collectible.Mage.FallenHero)) retval += 10;
                if (m.handcard.card.CardId == CardIds.Collectible.Neutral.NerubianEgg)
                {
                    if (m.Angr >= 1) retval += 2;
                    if ((!m.taunt && m.Angr == 0) && (m.divineshild || m.maxHp > 2)) retval -= 10;
                }
                retval += m.synergy;
            }

            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.Type == CardType.MOB)
                {
                    retval += hc.addattack + hc.addHp + hc.elemPoweredUp;
                }
            }

            int tmp = 0;
            foreach (Minion m in p.enemyMinions)
            {
                tmp = this.getEnemyMinionValue(m, p);
            }
            if (p.enemyMinions.Count == 1) tmp /= 2;
            retval -= tmp;

            retval -= p.enemySecretCount;
            retval -= p.lostDamage;//damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2
            retval -= p.lostWeaponDamage;
            if (p.ownMinions.Count == 0) retval -= 20;
            if (p.enemyMinions.Count >= 4) retval -= 20;
            if (p.enemyHero.Hp <= 0) retval = 10000;
            
            retval += p.anzOwnExtraAngrHp - p.anzEnemyExtraAngrHp / 2;
            //soulfire etc
            int deletecardsAtLast = 0;
            foreach (Action a in p.playactions)
            {
                if (a.actionType != actionEnum.playcard) continue;
                if (a.card.card.CardId == CardIds.Collectible.Warlock.Soulfire || a.card.card.CardId == CardIds.Collectible.Warlock.Doomguard || a.card.card.CardId == Chireiden.Silverfish.SimCard.succubus) deletecardsAtLast = 1;
                if (deletecardsAtLast == 1 && !(a.card.card.CardId == CardIds.Collectible.Warlock.Soulfire || a.card.card.CardId == CardIds.Collectible.Warlock.Doomguard || a.card.card.CardId == Chireiden.Silverfish.SimCard.succubus)) retval -= 20;
            }
            if (p.enemyHero.Hp >= 1 && p.guessingHeroHP <= 0)
            {
                if (p.turnCounter < 2) retval += p.owncarddraw * 500;
                retval -= 1000;
            }
            if (p.ownHero.Hp <= 0) retval -= 10000;

            p.value = retval;
            return retval;
        }

        public override int getEnemyMinionValue(Minion m, Playfield p)
        {
            int retval = 0;
            if (p.enemyMinions.Count >= 4 || m.taunt || (m.handcard.card.targetPriority >= 1 && !m.silenced) || m.Angr >= 5)
            {
                retval += m.Hp;
                if (!m.frozen && !(m.cantAttack && m.name != CardIds.Collectible.Neutral.ArgentWatchman))
                {
                    retval += m.Angr * 2;
                    if (m.windfury) retval += 2 * m.Angr;
                }
                if (m.taunt) retval += 5;
                if (m.divineshild) retval += m.Angr;
                if (m.frozen) retval -= 1; // because its bad for enemy :D
                if (m.poisonous)
                {
                    retval += 4;
                    if (p.ownMinions.Count < p.enemyMinions.Count) retval += 10;
                }
                if (m.lifesteal) retval += m.Angr;
                if (m.handcard.card.isSpecialMinion) retval += m.handcard.card.rarity;
            }

            retval += m.synergy;
            if (m.handcard.card.targetPriority >= 1 && !m.silenced) retval += m.handcard.card.targetPriority;
            if (m.Angr >= 4) retval += 20;
            if (m.Angr >= 7) retval += 50;
            if (m.name == CardIds.Collectible.Neutral.NerubianEgg && m.Angr <= 3 && !m.taunt) retval = 0;
            return retval;
        }


    }

}
