using System.Collections.Generic;
using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
    public class BehaviorControl : Behavior
    {
        public override string BehaviorName() { return "控场模式"; }


        PenalityManager penman = PenalityManager.Instance;

        public override float getPlayfieldValue(Playfield p)
        {
            if (p.value >= -2000000)
            {
                return p.value;
            }

            var retval = 0;
            var hpboarder = 10;
            if (p.ownHero.CardClass == CardClass.WARLOCK && p.enemyHero.CardClass != CardClass.MAGE)
            {
                hpboarder = 6;
            }

            var aggroboarder = 11;

            retval -= p.evaluatePenality;
            retval += p.owncards.Count * 5;
            retval += p.ownQuest.questProgress * 10;

            retval += p.ownMaxMana;
            retval -= p.enemyMaxMana;

            retval += p.ownMaxMana * 20 - p.enemyMaxMana * 20;
            retval += (p.enemyHeroAblility.manacost - p.ownHeroAblility.manacost) * 4;
            if (p.ownHeroPowerAllowedQuantity != p.enemyHeroPowerAllowedQuantity)
            {
                if (p.ownHeroPowerAllowedQuantity > p.enemyHeroPowerAllowedQuantity)
                {
                    retval += 3;
                }
                else
                {
                    retval -= 3;
                }
            }

            if (p.enemyHero.CardClass == CardClass.MAGE || p.enemyHero.CardClass == CardClass.DRUID)
            {
                retval -= 2 * p.enemyspellpower;
            }

            if (p.ownHero.Hp + p.ownHero.armor > hpboarder)
            {
                retval += p.ownHero.Hp + p.ownHero.armor;
            }
            else
            {
                if (p.nextTurnWin())
                {
                    retval -= hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor;
                }
                else
                {
                    retval -= 2 * (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor) * (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor);
                }
            }

            if (p.enemyHero.Hp + p.enemyHero.armor > aggroboarder)
            {
                retval += -p.enemyHero.Hp - p.enemyHero.armor;
            }
            else
            {
                retval += 4 * (aggroboarder + 1 - p.enemyHero.Hp - p.enemyHero.armor);
            }

            if (p.ownWeapon.Angr > 0)
            {
                if (p.ownWeapon.Angr > 1)
                {
                    retval += p.ownWeapon.Angr * p.ownWeapon.Durability;
                }
                else
                {
                    retval += p.ownWeapon.Angr * p.ownWeapon.Durability + 1;
                }
            }

            if (!p.enemyHero.frozen)
            {
                retval -= p.enemyWeapon.Durability * p.enemyWeapon.Angr;
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    retval += 12;
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

            if (p.owncarddraw + 1 >= p.enemycarddraw)
            {
                retval -= p.enemycarddraw * 7;
            }
            else
            {
                retval -= (p.owncarddraw + 1) * 7 + (p.enemycarddraw - p.owncarddraw - 1) * 12;
            }

            //int owntaunt = 0;
            var readycount = 0;
            var ownMinionsCount = 0;
            foreach (var m in p.ownMinions)
            {
                retval += 5;
                retval += m.Hp * 2;
                retval += m.Angr * 2;
                retval += (int)m.handcard.card.Rarity;
                if (!m.playedThisTurn && m.windfury)
                {
                    retval += m.Angr;
                }

                if (m.divineshild)
                {
                    retval += 1;
                }

                if (m.stealth)
                {
                    retval += 1;
                }

                if (m.handcard.card.isSpecialMinion && !m.silenced)
                {
                    retval += 1;
                    if (!m.taunt && m.stealth)
                    {
                        retval += 20;
                    }
                }
                else
                {
                    if (m.Angr <= 2 && m.Hp <= 2 && !m.divineshild)
                    {
                        retval -= 5;
                    }
                }

                //if (!m.taunt && m.stealth && penman.specialMinions.ContainsKey(m.name)) retval += 20;
                //if (m.poisonous) retval += 1;
                if (m.lifesteal)
                {
                    retval += m.Angr / 2;
                }

                if (m.divineshild && m.taunt)
                {
                    retval += 4;
                }

                //if (m.taunt && m.handcard.card.name == CardIds.NonCollectible.Neutral.Frog) owntaunt++;
                //if (m.handcard.card.isToken && m.Angr <= 2 && m.Hp <= 2) retval -= 5;
                //if (!penman.specialMinions.ContainsKey(m.name) && m.Angr <= 2 && m.Hp <= 2) retval -= 5;
                if (p.ownMinions.Count > 2 && (m.handcard.card.CardId == CardIds.Collectible.Neutral.DireWolfAlpha || m.handcard.card.CardId == CardIds.Collectible.Shaman.FlametongueTotem || m.handcard.card.CardId == CardIds.Collectible.Neutral.StormwindChampion || m.handcard.card.CardId == CardIds.Collectible.Neutral.RaidLeader))
                {
                    retval += 10;
                }

                if (m.handcard.card.CardId == CardIds.Collectible.Neutral.BloodmageThalnos)
                {
                    retval += 10;
                }

                if (m.handcard.card.CardId == CardIds.Collectible.Neutral.NerubianEgg)
                {
                    if (m.Angr >= 1)
                    {
                        retval += 2;
                    }

                    if (!m.taunt && m.Angr == 0 && (m.divineshild || m.maxHp > 2))
                    {
                        retval -= 10;
                    }
                }

                if (m.Ready)
                {
                    readycount++;
                }

                if (m.Hp <= 4 && (m.Angr > 2 || m.Hp > 3))
                {
                    ownMinionsCount++;
                }

                retval += m.synergy;
            }

            retval += p.anzOgOwnCThunAngrBonus;
            retval += p.anzOwnExtraAngrHp - p.anzEnemyExtraAngrHp;

            /*if (p.enemyMinions.Count >= 0)
            {
                int anz = p.enemyMinions.Count;
                if (owntaunt == 0) retval -= 10 * anz;
                retval += owntaunt * 10 - 11 * anz;
            }*/


            var useAbili = false;
            var usecoin = 0;
            //soulfire etc
            var deletecardsAtLast = 0;
            var wasCombo = 0;
            var firstSpellToEnHero = false;
            var count = p.playactions.Count;
            var ownActCount = 0;
            for (var i = 0; i < count; i++)
            {
                var a = p.playactions[i];
                ownActCount++;
                switch (a.actionType)
                {
                    case actionEnum.attackWithHero:
                        if (p.enemyHero.Hp <= p.attackFaceHP)
                        {
                            retval++;
                        }

                        if (p.ownHero.CardClass == CardClass.WARRIOR && useAbili)
                        {
                            retval -= 1;
                        }

                        continue;
                    case actionEnum.useHeroPower:
                        useAbili = true;
                        continue;
                    case actionEnum.playcard:
                        break;
                    default:
                        continue;
                }

                switch (a.card.card.CardId)
                {
                    case CardIds.Collectible.Druid.Innervate:
                    case CardIds.NonCollectible.Neutral.TheCoin:
                        usecoin++;
                        if (i == count - 1)
                        {
                            retval -= 10;
                        }

                        goto default;
                    case CardIds.Collectible.Warlock.DarkshireLibrarian: goto case CardIds.Collectible.Warlock.Soulfire;
                    case CardIds.Collectible.Warlock.DarkBargain: goto case CardIds.Collectible.Warlock.Soulfire;
                    case CardIds.Collectible.Warlock.Doomguard: goto case CardIds.Collectible.Warlock.Soulfire;
                    case CardIds.Collectible.Warlock.Felstalker: goto case CardIds.Collectible.Warlock.Soulfire;
                    case CardIds.Collectible.Warlock.Soulfire:
                        deletecardsAtLast = 1;
                        break;
                    default:
                        if (deletecardsAtLast == 1)
                        {
                            retval -= 20;
                        }

                        break;
                }

                if (a.card.card.Combo && i > 0)
                {
                    wasCombo++;
                }

                if (a.target == null)
                {
                    continue;
                }

                //save spell for all classes
                if (a.card.card.Type == CardType.SPELL && a.target.isHero && !a.target.own)
                {
                    if (i == 0)
                    {
                        firstSpellToEnHero = true;
                    }

                    retval -= 11;
                }
            }

            if (wasCombo > 0 && firstSpellToEnHero)
            {
                if (wasCombo + 1 == ownActCount)
                {
                    retval += 10;
                }
            }

            if (usecoin > 0)
            {
                if (useAbili && p.ownMaxMana <= 2)
                {
                    retval -= 40;
                }

                retval -= 5 * p.manaTurnEnd;
                if (p.manaTurnEnd + usecoin > 10)
                {
                    retval -= 5 * usecoin;
                }
            }

            if (p.manaTurnEnd >= 2 && !useAbili && p.ownAbilityReady)
            {
                switch (p.ownHeroAblility.card.CardId)
                {
                    case CardIds.NonCollectible.Priest.JusticarTrueheart_Heal:
                    case CardIds.NonCollectible.Priest.LesserHeal:
                        var wereTarget = false;
                        if (p.ownHero.Hp < p.ownHero.maxHp)
                        {
                            wereTarget = true;
                        }

                        if (!wereTarget)
                        {
                            foreach (var m in p.ownMinions)
                            {
                                if (m.wounded)
                                {
                                    wereTarget = true;
                                    break;
                                }
                            }
                        }

                        if (wereTarget && !(p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0))
                        {
                            retval -= 10;
                        }

                        break;
                    case CardIds.NonCollectible.Rogue.JusticarTrueheart_PoisonedDaggers:
                    case CardIds.NonCollectible.Rogue.DaggerMastery:
                        if (!(p.ownWeapon.Durability > 1 || p.ownWeapon.Angr > 1))
                        {
                            retval -= 10;
                        }

                        break;
                    case CardIds.NonCollectible.Shaman.JusticarTrueheart_TotemicSlam:
                    case CardIds.NonCollectible.Shaman.TotemicCall:
                        if (p.ownMinions.Count < 7)
                        {
                            retval -= 10;
                        }
                        else
                        {
                            retval -= 3;
                        }

                        break;
                    case CardIds.NonCollectible.Paladin.VilefinInquisitor_TheTidalHand:
                    case CardIds.NonCollectible.Paladin.JusticarTrueheart_TheSilverHand:
                    case CardIds.NonCollectible.Paladin.ReinforceBasic:
                        if (p.ownMinions.Count < 7)
                        {
                            retval -= 10;
                        }
                        else
                        {
                            retval -= 3;
                        }

                        break;
                    case CardIds.NonCollectible.Warlock.JusticarTrueheart_SoulTap:
                        if (p.owncards.Count < 10 && p.ownDeckSize > 0)
                        {
                            retval -= 10;
                        }

                        break;
                    case CardIds.NonCollectible.Warlock.LifeTap:
                        if (p.owncards.Count < 10 && p.ownDeckSize > 0)
                        {
                            retval -= 10;
                            if (p.ownHero.immune)
                            {
                                retval -= 5;
                            }
                        }

                        break;
                    default:
                        retval -= 10;
                        break;
                }
            }
            //if (usecoin && p.mana >= 1) retval -= 20;

            var mobsInHand = 0;
            var bigMobsInHand = 0;
            foreach (var hc in p.owncards)
            {
                if (hc.card.Type == CardType.MINION)
                {
                    mobsInHand++;
                    if (hc.card.Attack + hc.addattack >= 3)
                    {
                        bigMobsInHand++;
                    }

                    retval += hc.addattack + hc.addHp + hc.elemPoweredUp;
                }
            }

            if (ownMinionsCount - p.enemyMinions.Count >= 4 && bigMobsInHand >= 1)
            {
                retval += bigMobsInHand * 25;
            }


            //bool hasTank = false;
            foreach (var m in p.enemyMinions)
            {
                retval -= this.getEnemyMinionValue(m, p);
                //hasTank = hasTank || m.taunt;
            }

            retval -= p.enemyMinions.Count * 2;
            /*foreach (SecretItem si in p.enemySecretList)
            {
                if (readycount >= 1 && !hasTank && si.canbeTriggeredWithAttackingHero)
                {
                    retval -= 100;
                }
                if (readycount >= 1 && p.enemyMinions.Count >= 1 && si.canbeTriggeredWithAttackingMinion)
                {
                    retval -= 100;
                }
                if (si.canbeTriggeredWithPlayingMinion && mobsInHand >= 1)
                {
                    retval -= 25;
                }
            }*/

            retval -= p.enemySecretCount;
            retval -= p.lostDamage; //damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2
            retval -= p.lostWeaponDamage;

            //if (p.ownMinions.Count == 0) retval -= 20;
            //if (p.enemyMinions.Count == 0) retval += 20;

            if (p.enemyHero.Hp <= 0)
            {
                retval += 10000;
                if (retval < 10000)
                {
                    retval = 10000;
                }
            }

            if (p.enemyHero.Hp >= 1 && p.guessingHeroHP <= 0)
            {
                if (p.turnCounter < 2)
                {
                    retval += p.owncarddraw * 100;
                }

                retval -= 1000;
            }

            if (p.ownHero.Hp <= 0)
            {
                retval -= 10000;
            }

            p.value = retval;
            return retval;
        }


        public override int getEnemyMinionValue(Minion m, Playfield p)
        {
            var retval = 5;
            retval += m.Hp * 2;
            if (!m.frozen && !(m.cantAttack && m.name != CardIds.Collectible.Neutral.ArgentWatchman))
            {
                retval += m.Angr * 2;
                if (m.windfury)
                {
                    retval += m.Angr * 2;
                }

                if (m.Angr >= 4)
                {
                    retval += 10;
                }

                if (m.Angr >= 7)
                {
                    retval += 50;
                }
            }

            if (!m.handcard.card.isSpecialMinion)
            {
                if (m.Angr == 0)
                {
                    retval -= 7;
                }
                else if (m.Angr <= 2 && m.Hp <= 2 && !m.divineshild)
                {
                    retval -= 5;
                }
            }
            else
            {
                retval += (int)m.handcard.card.Rarity;
            }

            if (m.taunt)
            {
                retval += 5;
            }

            if (m.divineshild)
            {
                retval += m.Angr;
            }

            if (m.divineshild && m.taunt)
            {
                retval += 5;
            }

            if (m.stealth)
            {
                retval += 1;
            }

            if (m.poisonous)
            {
                retval += 4;
                if (p.ownMinions.Count < p.enemyMinions.Count)
                {
                    retval += 10;
                }
            }

            if (m.lifesteal)
            {
                retval += m.Angr;
            }

            if (m.handcard.card.targetPriority >= 1 && !m.silenced)
            {
                retval += m.handcard.card.targetPriority;
            }

            if (m.name == CardIds.Collectible.Neutral.NerubianEgg && m.Angr <= 3 && !m.taunt)
            {
                retval = 0;
            }

            retval += m.synergy;
            return retval;
        }


        public override int getSirFinleyPriority(List<Handcard> discoverCards)
        {
            return -1; //comment out or remove this to set manual priority
            var sirFinleyChoice = -1;
            var tmp = int.MinValue;
            for (var i = 0; i < discoverCards.Count; i++)
            {
                SimCard name = discoverCards[i].card.CardId;
                if (this.SirFinleyPriorityList.ContainsKey(name) && this.SirFinleyPriorityList[name] > tmp)
                {
                    tmp = this.SirFinleyPriorityList[name];
                    sirFinleyChoice = i;
                }
            }

            return sirFinleyChoice;
        }

        private Dictionary<SimCard, int> SirFinleyPriorityList = new Dictionary<SimCard, int>
        {
            //{HeroPowerName, Priority}, where 0-9 = manual priority
            {CardIds.NonCollectible.Warlock.LifeTap, 9},
            {CardIds.NonCollectible.Hunter.SteadyShot, 8},
            {CardIds.NonCollectible.Mage.Fireblast, 7},
            {CardIds.NonCollectible.Druid.Shapeshift, 6},
            {CardIds.NonCollectible.Rogue.DaggerMastery, 5},
            {CardIds.NonCollectible.Paladin.ReinforceBasic, 4},
            {CardIds.NonCollectible.Warrior.ArmorUpBasic, 2},
            {CardIds.NonCollectible.Shaman.TotemicCall, 1},
            {CardIds.NonCollectible.Priest.LesserHeal, 0}
        };
    }
}