///
// This file contains a few methods required for the bot to run.
// They will be removed in later updates
///
using HearthDb.Enums;
using HREngine.Bots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthDb;

namespace Chireiden.Silverfish
{
    partial class SimCard
    {
        public bool IsToken => CardId.EndsWith("t");
        public List<Minion> getTargetsForCard(Playfield p, bool isLethalCheck, bool own)
        {
            //if wereTargets=true and 0 targets at end -> then can not play this card
            List<Minion> retval = new List<Minion>();
            if (this.Type == CardType.MINION && ((own && p.ownMinions.Count >= 7) || (!own && p.enemyMinions.Count >= 7))) return retval; // cant play mob, if we have allready 7 mininos
            if (this.Secret && ((own && (p.ownSecretsIDList.Contains(this) || p.ownSecretsIDList.Count >= 5)) || (!own && p.enemySecretCount >= 5))) return retval;
            //if (p.mana < this.getManaCost(p, 1)) return retval;

            // https://github.com/HearthSim/HearthDb/issues/18
            // The PlayRequirement section lost since version 16.0.0.37060
            // So it will ALWAYS be true
            if (true) /*this.playrequires.Count == 0*/
            {
                retval.Add(null); return retval;
            }
            /*
            List<Minion> targets = new List<Minion>();
            bool targetAll = false;
            bool targetAllEnemy = false;
            bool targetAllFriendly = false;
            bool targetEnemyHero = false;
            bool targetOwnHero = false;
            bool targetOnlyMinion = false;
            bool extraParam = false;
            bool wereTargets = false;
            bool REQ_UNDAMAGED_TARGET = false;
            bool REQ_TARGET_WITH_DEATHRATTLE = false;
            bool REQ_TARGET_WITH_RACE = false;
            bool REQ_TARGET_MIN_ATTACK = false;
            bool REQ_TARGET_MAX_ATTACK = false;
            bool REQ_MUST_TARGET_TAUNTER = false;
            bool REQ_STEADY_SHOT = false;
            bool REQ_FROZEN_TARGET = false;
            bool REQ_HERO_TARGET = false;
            bool REQ_DAMAGED_TARGET = false;
            bool REQ_LEGENDARY_TARGET = false;
            bool REQ_TARGET_IF_AVAILABLE = false;
            bool REQ_STEALTHED_TARGET = false;
            bool REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = false;

            foreach (CardDB.ErrorType2 PlayReq in this.playrequires)
            {
                switch (PlayReq)
                {
                    case ErrorType2.REQ_TARGET_TO_PLAY:
                    case ErrorType2.REQ_TARGET_TO_PLAY2:
                        targetAll = true;
                        continue;
                    case ErrorType2.REQ_MINION_TARGET:
                        targetOnlyMinion = true;
                        continue;
                    case ErrorType2.REQ_TARGET_IF_AVAILABLE:
                        REQ_TARGET_IF_AVAILABLE = true;
                        targetAll = true;
                        continue;
                    case ErrorType2.REQ_FRIENDLY_TARGET:
                        if (own) targetAllFriendly = true;
                        else targetAllEnemy = true;
                        continue;
                    case ErrorType2.REQ_NUM_MINION_SLOTS:
                        if ((own ? p.ownMinions.Count : p.enemyMinions.Count) > 7 - this.needEmptyPlacesForPlaying) return retval;
                        continue;
                    case ErrorType2.REQ_MINION_SLOT_OR_MANA_CRYSTAL_SLOT:
                        if (own) { if (p.ownMinions.Count > 6 & p.ownMaxMana > 9) return retval; }
                        else if (p.enemyMinions.Count > 6 & p.enemyMaxMana > 9) return retval;
                        continue;
                    case ErrorType2.REQ_ENEMY_TARGET:
                        if (own) targetAllEnemy = true;
                        else targetAllFriendly = true;
                        continue;
                    case ErrorType2.REQ_HERO_TARGET:
                        REQ_HERO_TARGET = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_MINIMUM_ENEMY_MINIONS:
                        if ((own ? p.enemyMinions.Count : p.ownMinions.Count) < this.needMinNumberOfEnemy) return retval;
                        continue;
                    case ErrorType2.REQ_NONSELF_TARGET:
                        targetAll = true;
                        continue;
                    case ErrorType2.REQ_TARGET_WITH_RACE:
                        REQ_TARGET_WITH_RACE = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_DAMAGED_TARGET:
                        REQ_DAMAGED_TARGET = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_TARGET_MAX_ATTACK:
                        REQ_TARGET_MAX_ATTACK = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_WEAPON_EQUIPPED:
                        if ((own ? p.ownWeapon.Durability : p.enemyWeapon.Durability) == 0) return retval;
                        continue;
                    case ErrorType2.REQ_TARGET_FOR_COMBO:
                        if (p.cardsPlayedThisTurn >= 1) targetAll = true;
                        continue;
                    case ErrorType2.REQ_TARGET_MIN_ATTACK:
                        REQ_TARGET_MIN_ATTACK = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_MINIMUM_TOTAL_MINIONS:
                        if (this.needMinTotalMinions > p.ownMinions.Count + p.enemyMinions.Count) return retval;
                        continue;
                    case ErrorType2.REQ_MINION_CAP_IF_TARGET_AVAILABLE:
                        if ((own ? p.ownMinions.Count : p.enemyMinions.Count) > 7 - this.needMinionsCapIfAvailable) return retval;
                        continue;
                    case ErrorType2.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY:
                        int difftotem = 0;
                        foreach (Minion m in (own ? p.ownMinions : p.enemyMinions))
                        {
                            if (m.name == cardName.healingtotem || m.name == cardName.wrathofairtotem || m.name == cardName.searingtotem || m.name == cardName.stoneclawtotem) difftotem++;
                        }
                        if (difftotem == 4) return retval;
                        continue;
                    case ErrorType2.REQ_MUST_TARGET_TAUNTER:
                        REQ_MUST_TARGET_TAUNTER = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND:
                        if (own)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards)
                            {
                                if ((Race)hc.card.Race == Race.DRAGON) { targetAll = true; break; }
                            }
                        }
                        else targetAll = true; // apriori the enemy have a dragon
                        continue;
                    case ErrorType2.REQ_LEGENDARY_TARGET:
                        REQ_LEGENDARY_TARGET = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_UNDAMAGED_TARGET:
                        REQ_UNDAMAGED_TARGET = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_TARGET_WITH_DEATHRATTLE:
                        REQ_TARGET_WITH_DEATHRATTLE = true;
                        targetOnlyMinion = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN:
                        REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_STEADY_SHOT:
                        REQ_STEADY_SHOT = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_FROZEN_TARGET:
                        REQ_FROZEN_TARGET = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_MINION_OR_ENEMY_HERO:
                        REQ_STEADY_SHOT = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_STEALTHED_TARGET:
                        REQ_STEALTHED_TARGET = true;
                        extraParam = true;
                        continue;
                    case ErrorType2.REQ_ENEMY_WEAPON_EQUIPPED:
                        if (own)
                        {
                            if (p.enemyWeapon.Durability > 0) targetEnemyHero = true;
                            else return retval;
                        }
                        else
                        {
                            if (p.ownWeapon.Durability > 0) targetOwnHero = true;
                            else return retval;
                        }
                        continue;
                    case ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS:
                        int tmp = (own) ? p.ownMinions.Count : p.enemyMinions.Count;
                        if (tmp >= needMinOwnMinions) targetAll = true;
                        continue;
                    case ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_SECRETS:
                        if (p.ownSecretsIDList.Count >= needControlaSecret) targetAll = true;
                        continue;
                    case ErrorType2.REQ_MUST_PLAY_OTHER_CARD_FIRST:
                        if (p.cardsPlayedThisTurn == 0) return retval;
                        continue;
                    case ErrorType2.REQ_HAND_NOT_FULL:
                        if (p.owncards.Count == 10) return retval;
                        continue;

                        //default:
                }
            }

            if (targetAll)
            {
                wereTargets = true;
                if (targetAllFriendly != targetAllEnemy)
                {
                    if (targetAllFriendly)
                    {
                        foreach (Minion m in p.ownMinions) if (!m.untouchable) targets.Add(m);
                    }
                    else
                    {
                        foreach (Minion m in p.enemyMinions) if (!m.untouchable) targets.Add(m);
                    }
                }
                else
                {
                    foreach (Minion m in p.ownMinions) if (!m.untouchable) targets.Add(m);
                    foreach (Minion m in p.enemyMinions) if (!m.untouchable) targets.Add(m);
                }
                if (targetOnlyMinion)
                {
                    targetEnemyHero = false;
                    targetOwnHero = false;
                }
                else
                {
                    if (!p.enemyHero.immune) targetEnemyHero = true;
                    if (!p.ownHero.immune) targetOwnHero = true;
                    if (targetAllEnemy) targetOwnHero = false;
                    if (targetAllFriendly) targetEnemyHero = false;
                }
            }

            if (extraParam)
            {
                wereTargets = true;
                if (REQ_TARGET_WITH_RACE)
                {
                    foreach (Minion m in targets)
                    {
                        if (m.handcard.card.Race != this.needRaceForPlaying) m.extraParam = true;
                    }
                    targetOwnHero = (p.ownHeroName == HeroEnum.lordjaraxxus && (Race)this.needRaceForPlaying == Race.DEMON);
                    targetEnemyHero = (p.enemyHeroName == HeroEnum.lordjaraxxus && (Race)this.needRaceForPlaying == Race.DEMON);
                }
                if (REQ_HERO_TARGET)
                {
                    foreach (Minion m in targets)
                    {
                        m.extraParam = true;
                    }
                    targetOwnHero = true;
                    targetEnemyHero = true;
                }
                if (REQ_DAMAGED_TARGET)
                {
                    foreach (Minion m in targets)
                    {
                        if (!m.wounded)
                        {
                            m.extraParam = true;
                        }
                    }
                    targetOwnHero = false;
                    targetEnemyHero = false;
                }
                if (REQ_TARGET_MAX_ATTACK)
                {
                    foreach (Minion m in targets)
                    {
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            m.extraParam = true;
                        }
                    }
                    targetOwnHero = false;
                    targetEnemyHero = false;
                }
                if (REQ_TARGET_MIN_ATTACK)
                {
                    foreach (Minion m in targets)
                    {
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            m.extraParam = true;
                        }
                    }
                    targetOwnHero = false;
                    targetEnemyHero = false;
                }
                if (REQ_MUST_TARGET_TAUNTER)
                {
                    foreach (Minion m in targets)
                    {
                        if (!m.taunt)
                        {
                            m.extraParam = true;
                        }
                    }
                    targetOwnHero = false;
                    targetEnemyHero = false;
                }
                if (REQ_UNDAMAGED_TARGET)
                {
                    foreach (Minion m in targets)
                    {
                        if (m.wounded)
                        {
                            m.extraParam = true;
                        }
                    }
                    targetOwnHero = false;
                    targetEnemyHero = false;
                }
                if (REQ_STEALTHED_TARGET)
                {
                    foreach (Minion m in targets)
                    {
                        if (!m.stealth)
                        {
                            m.extraParam = true;
                        }
                    }
                    targetOwnHero = false;
                    targetEnemyHero = false;
                }
                if (REQ_TARGET_WITH_DEATHRATTLE)
                {
                    foreach (Minion m in targets)
                    {
                        if (!m.silenced && (m.handcard.card.Deathrattle || m.deathrattle2 != null ||
                        m.ancestralspirit + m.desperatestand + m.souloftheforest + m.stegodon + m.livingspores + m.explorershat + m.returnToHand + m.infest > 0)) continue;
                        else m.extraParam = true;
                    }
                    targetOwnHero = false;
                    targetEnemyHero = false;
                }
                if (REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN)
                {
                    if (p.anzOwnElementalsLastTurn < 1)
                    {
                        foreach (Minion m in targets) m.extraParam = true;
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                }
                if (REQ_LEGENDARY_TARGET)
                {
                    wereTargets = false;
                    foreach (Minion m in targets)
                    {
                        if (m.handcard.card.Rarity != Rarity.LEGENDARY) m.extraParam = true;
                    }
                    targetOwnHero = false;
                    targetEnemyHero = false;
                }
                if (REQ_STEADY_SHOT)
                {
                    if ((p.weHaveSteamwheedleSniper && own) || (p.enemyHaveSteamwheedleSniper && !own))
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.cantBeTargetedBySpellsOrHeroPowers && (this.Type == CardType.HERO_POWER || this.Type == CardType.SPELL))
                            {
                                m.extraParam = true;
                                if (m.stealth && !m.own) m.extraParam = true;
                            }
                        }
                        if (own) targetEnemyHero = true;
                        else targetOwnHero = true;
                    }
                    else wereTargets = false;
                }
                if (REQ_FROZEN_TARGET)
                {

                    foreach (Minion m in targets)
                    {
                        if (!m.frozen) m.extraParam = true;
                    }
                }
            }

            if (targetEnemyHero && own && p.enemyHero.stealth) targetEnemyHero = false;
            if (targetOwnHero && !own && p.ownHero.stealth) targetOwnHero = false;

            if (isLethalCheck)
            {
                if (targetEnemyHero && own) retval.Add(p.enemyHero);
                else if (targetOwnHero && !own) retval.Add(p.ownHero);

                switch (this.Type)
                {
                    case CardType.SPELL:
                        if (p.prozis.penman.attackBuffDatabase.ContainsKey(this.name))
                        {
                            if (targetOwnHero && own) retval.Add(p.ownHero);
                            foreach (Minion m in targets)
                            {
                                if (m.extraParam != true && !m.cantBeTargetedBySpellsOrHeroPowers)
                                {
                                    if (m.own)
                                    {
                                        if (m.Ready) retval.Add(m);
                                    }
                                    else if (m.taunt) retval.Add(m);
                                }
                                m.extraParam = false;
                            }
                        }
                        else
                        {
                            switch (this.name)
                            {
                                case CardIds.Collectible.Mage.PolymorphBoar:
                                    foreach (Minion m in targets)
                                    {
                                        m.extraParam = false;
                                        if (m.cantBeTargetedBySpellsOrHeroPowers) continue;
                                        if (m.own) retval.Add(m);
                                        else if (m.taunt) retval.Add(m);
                                    }
                                    break;
                                case CardIds.Collectible.Shaman.Hex: goto case CardIds.Collectible.Mage.Polymorph;
                                case CardIds.Collectible.Mage.Polymorph:
                                    foreach (Minion m in targets)
                                    {
                                        m.extraParam = false;
                                        if (!m.own && m.taunt && !m.cantBeTargetedBySpellsOrHeroPowers) retval.Add(m);
                                    }
                                    break;
                            }
                        }
                        break;
                    case CardType.MINION:
                        foreach (Minion m in targets)
                        {
                            if (m.extraParam != true)
                            {
                                if (m.stealth && !m.own) continue;
                                retval.Add(m);
                            }
                            m.extraParam = false;
                        }
                        break;
                    case CardType.HERO_POWER:
                        if (p.prozis.penman.attackBuffDatabase.ContainsKey(this.name))
                        {
                            foreach (Minion m in targets)
                            {
                                if (m.extraParam != true && !m.cantBeTargetedBySpellsOrHeroPowers)
                                {
                                    if (m.own)
                                    {
                                        if (m.Ready) retval.Add(m);
                                    }
                                    else if (m.taunt) retval.Add(m);
                                }
                                m.extraParam = false;
                            }
                        }
                        break;
                }
            }
            else
            {
                if (targetEnemyHero) retval.Add(p.enemyHero);
                if (targetOwnHero) retval.Add(p.ownHero);

                foreach (Minion m in targets)
                {
                    if (m.extraParam != true)
                    {
                        if (m.stealth && !m.own) continue;
                        if (m.cantBeTargetedBySpellsOrHeroPowers && (this.Type == CardType.SPELL || this.Type == CardType.HERO_POWER)) continue;
                        retval.Add(m);
                    }
                    m.extraParam = false;
                }
            }

            if (retval.Count == 0 && (!wereTargets || REQ_TARGET_IF_AVAILABLE)) retval.Add(null);

            return retval;
            */
        }


        public List<Minion> getTargetsForHeroPower(Playfield p, bool own)
        {
            List<Minion> trgts = this.getTargetsForCard(p, p.isLethalCheck, own);
            var abName = own ? p.ownHeroAblility.card.CardId : p.enemyHeroAblility.card.CardId;
            int abType = 0; //0 none, 1 damage, 2 heal, 3 baff
            switch (abName)
            {
                case CardIds.NonCollectible.Priest.JusticarTrueheart_Heal:
                case CardIds.NonCollectible.Priest.LesserHeal:
                    if (p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0) abType = 1;
                    else abType = 2;
                    break;
                case CardIds.NonCollectible.Hunter.JusticarTrueheart_BallistaShot: abType = 1; break;
                case CardIds.NonCollectible.Hunter.SteadyShot: abType = 1; break;
                case CardIds.NonCollectible.Mage.Fireblast: abType = 1; break;
                case CardIds.NonCollectible.Mage.JusticarTrueheart_FireblastRank2: abType = 1; break;
                case CardIds.NonCollectible.Shaman.ChargedHammer_LightningJoltToken: abType = 1; break;
                case CardIds.NonCollectible.Priest.Shadowform_MindSpikeToken: abType = 1; break;
                case CardIds.NonCollectible.Priest.Shadowform_MindShatterToken: abType = 1; break;
                case CardIds.NonCollectible.Neutral.PowerOfTheFirelord: abType = 1; break;
                case CardIds.NonCollectible.Hunter.ShotgunBlast: abType = 1; break;
                case CardIds.NonCollectible.Neutral.UnbalancingStrike: abType = 1; break;
                case CardIds.Collectible.Hunter.Dinomancy: abType = 3; break;
            }

            switch (abType)
            {
                case 2:
                    List<Minion> minions = own ? p.ownMinions : p.enemyMinions;
                    int tCount = minions.Count;
                    bool needCut = true;
                    for (int i = 0; i < tCount; i++)
                    {
                        switch (minions[i].name.CardId)
                        {
                            case CardIds.Collectible.Priest.Shadowboxer:
                                if (own && p.enemyHero.Hp == 1 && p.enemyMinions.Count > 0) needCut = false;
                                break;
                            case CardIds.Collectible.Priest.HolyChampion: needCut = false; break;
                            case CardIds.Collectible.Neutral.Lightwarden: needCut = false; break;
                            case CardIds.Collectible.Priest.NorthshireCleric: needCut = false; break;


                        }
                    }

                    tCount = trgts.Count;
                    if (tCount > 0)
                    {
                        if (trgts[0] != null)
                        {
                            List<Minion> tmp = new List<Minion>();
                            for (int i = 0; i < tCount; i++)
                            {
                                Minion m = trgts[i];
                                if (m.Hp < m.maxHp)
                                {
                                    if (needCut)
                                    {
                                        if (m.own == own) tmp.Add(m);
                                    }
                                    else tmp.Add(m);
                                }
                            }
                            return tmp;
                        }
                    }
                    break;
            }
            return trgts;
        }

        public int calculateManaCost(Playfield p)//calculates the mana from orginal mana, needed for back-to hand effects and new draw
        {
            int retval = this.Cost;
            int offset = 0;

            if (p.anzOwnShadowfiend > 0) offset -= p.anzOwnShadowfiend;

            switch (this.Type)
            {
                case CardType.MINION:
                    if (p.anzOwnAviana > 0) retval = 1;

                    offset += p.ownMinionsCostMore;

                    if (this.Deathrattle) offset += p.ownDRcardsCostMore;

                    offset += p.managespenst;

                    int temp = -(p.startedWithbeschwoerungsportal) * 2;
                    if (retval + temp <= 0) temp = -retval + 1;
                    offset = offset + temp;

                    if (p.mobsplayedThisTurn == 0)
                    {
                        offset -= p.winzigebeschwoererin;
                    }

                    if (this.Battlecry)
                    {
                        offset += p.nerubarweblord * 2;
                    }

                    if ((Race)this.Race == Race.MECHANICAL)
                    { //if the number of zauberlehrlings change
                        offset -= p.anzOwnMechwarper;
                    }
                    break;
                case CardType.SPELL:
                    if (p.nextSpellThisTurnCost0) return 0;
                    offset += p.ownSpelsCostMore;
                    if (p.playedPreparation)
                    { //if the number of zauberlehrlings change
                        offset -= 2;
                    }
                    break;
                case CardType.WEAPON:
                    offset -= p.blackwaterpirate * 2;
                    if (this.Deathrattle) offset += p.ownDRcardsCostMore;
                    break;
            }

            offset -= p.myCardsCostLess;

            switch (this.CardId)
            {
                case CardIds.Collectible.Neutral.HappyGhoul:
                    if (p.ownHero.anzGotHealed > 0) retval = offset;
                    break;
                case CardIds.Collectible.Neutral.DreadCorsair:
                    retval = retval + offset - p.ownWeapon.Angr;
                    break;
                case CardIds.Collectible.Neutral.VolcanicDrake:
                    retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                    break;
                case CardIds.Collectible.Druid.KnightOfTheWild:
                    retval = retval + offset - p.tempTrigger.ownBeastSummoned;
                    break;
                case CardIds.Collectible.Neutral.SeaGiant:
                    retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count;
                    break;
                case CardIds.Collectible.Neutral.MountainGiant:
                    retval = retval + offset - p.owncards.Count;
                    break;
                case CardIds.Collectible.Neutral.ClockworkGiant:
                    retval = retval + offset - p.enemyAnzCards;
                    break;
                case CardIds.Collectible.Neutral.MoltenGiant:
                    retval = retval + offset - p.ownHero.maxHp + p.ownHero.Hp;
                    break;
                case CardIds.Collectible.Neutral.FrostGiant:
                    retval = retval + offset - p.anzUsedOwnHeroPower;
                    break;
                case CardIds.Collectible.Neutral.ArcaneGiant:
                    retval = retval + offset - p.spellsplayedSinceRecalc;
                    break;
                case CardIds.Collectible.Shaman.SnowfuryGiant:
                    retval = retval + offset - p.ueberladung;
                    break;
                case CardIds.Collectible.Mage.KabalCrystalRunner:
                    retval = retval + offset - 2 * p.secretsplayedSinceRecalc;
                    break;
                case CardIds.Collectible.Neutral.SecondRateBruiser:
                    retval = retval + offset - ((p.enemyMinions.Count < 3) ? 0 : 2);
                    break;
                case CardIds.NonCollectible.Neutral.Golemagg:
                    retval = retval + offset - p.ownHero.maxHp + p.ownHero.Hp;
                    break;
                case CardIds.Collectible.Druid.VolcanicLumberer:
                    retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                    break;
                case CardIds.Collectible.Neutral.SkycapnKragg:
                    int costBonus = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((Race)m.handcard.card.Race == Race.PIRATE) costBonus++;
                    }
                    retval = retval + offset - costBonus;
                    break;
                case CardIds.Collectible.Shaman.EveryfinIsAwesome:
                    int costBonusM = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((Race)m.handcard.card.Race == Race.MURLOC) costBonusM++;
                    }
                    retval = retval + offset - costBonusM;
                    break;
                case CardIds.Collectible.Warrior.Crush:
                    // cost 4 less if we have a dmged minion
                    bool dmgedminions = false;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.wounded) dmgedminions = true;
                    }
                    if (dmgedminions)
                    {
                        retval = retval + offset - 4;
                    }
                    break;
                default:
                    retval = retval + offset;
                    break;
            }

            if (this.Secret)
            {
                if (p.anzOwnCloakedHuntress > 0 || p.nextSecretThisTurnCost0) retval = 0;
            }

            retval = Math.Max(0, retval);

            return retval;
        }

        public int getManaCost(Playfield p, int currentcost)
        {
            int retval = currentcost;

            int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

            // CARDS that increase/decrease the manacosts of others ##############################
            switch (this.Type)
            {
                case CardType.HERO_POWER:
                    retval += p.ownHeroPowerCostLessOnce;
                    if (retval < 0) retval = 0;
                    return retval;
                case CardType.MINION:

                    if (p.ownMinionsCostMore != p.ownMinionsCostMoreAtStart)
                    {
                        offset += (p.ownMinionsCostMore - p.ownMinionsCostMoreAtStart);
                    }


                    if (this.Deathrattle && p.ownDRcardsCostMore != p.ownDRcardsCostMoreAtStart)
                    {
                        offset += (p.ownDRcardsCostMore - p.ownDRcardsCostMoreAtStart);
                    }


                    if (p.managespenst != p.startedWithManagespenst)
                    {
                        offset += (p.managespenst - p.startedWithManagespenst);
                    }


                    if (this.Battlecry && p.nerubarweblord != p.startedWithnerubarweblord)
                    {
                        offset += (p.nerubarweblord - p.startedWithnerubarweblord) * 2;
                    }


                    if (p.anzOwnAviana > 0)
                    {
                        retval = 1;
                    }


                    if (p.anzOwnMechwarper != p.anzOwnMechwarperStarted && (Race)this.Race == Race.MECHANICAL)
                    {
                        offset += (p.anzOwnMechwarperStarted - p.anzOwnMechwarper);
                    }


                    if (p.startedWithbeschwoerungsportal != p.beschwoerungsportal)
                    {
                        offset += (p.startedWithbeschwoerungsportal - p.beschwoerungsportal) * 2;
                    }


                    if (p.winzigebeschwoererin != p.startedWithWinzigebeschwoererin && ((p.turnCounter == 0 && p.startedWithMobsPlayedThisTurn == 0) || (p.turnCounter > 0 && p.mobsplayedThisTurn == 0)))
                    {
                        offset += (p.startedWithWinzigebeschwoererin - p.winzigebeschwoererin);
                    }


                    if (p.anzOwnDragonConsort != p.anzOwnDragonConsortStarted && (Race)this.Race == Race.DRAGON)
                    {
                        offset += (p.anzOwnDragonConsortStarted - p.anzOwnDragonConsort) * 2;
                    }
                    break;
                case CardType.SPELL:

                    if (p.nextSpellThisTurnCost0) return 0;


                    if (p.ownSpelsCostMoreAtStart != p.ownSpelsCostMore)
                    {
                        offset += p.ownSpelsCostMore - p.ownSpelsCostMoreAtStart;
                    }


                    if (p.playedPreparation)
                    {
                        offset -= 2;
                    }
                    break;
                case CardType.WEAPON:

                    if (p.blackwaterpirateStarted != p.blackwaterpirate)
                    {
                        offset += (p.blackwaterpirateStarted - p.blackwaterpirate) * 2;
                    }

                    if (this.Deathrattle && p.ownDRcardsCostMore != p.ownDRcardsCostMoreAtStart)
                    {
                        offset += (p.ownDRcardsCostMore - p.ownDRcardsCostMoreAtStart);
                    }
                    break;
            }


            if (p.startedWithmyCardsCostLess != p.myCardsCostLess)
            {
                offset += p.startedWithmyCardsCostLess - p.myCardsCostLess;
            }

            switch (this.CardId)
            {
                case CardIds.Collectible.Druid.VolcanicLumberer:
                case CardIds.Collectible.Paladin.SolemnVigil:
                case CardIds.Collectible.Neutral.VolcanicDrake:
                case CardIds.Collectible.Mage.DragonsBreath:
                    retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                    break;
                case CardIds.Collectible.Druid.KnightOfTheWild:
                    retval = retval + offset - p.tempTrigger.ownBeastSummoned;
                    break;
                case CardIds.Collectible.Neutral.DreadCorsair:
                    retval = retval + offset - p.ownWeapon.Angr + p.ownWeaponAttackStarted; // if weapon attack change we change manacost
                    break;
                case CardIds.Collectible.Neutral.SeaGiant:
                    retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count + p.ownMobsCountStarted + p.enemyMobsCountStarted;
                    break;
                case CardIds.Collectible.Neutral.MountainGiant:
                    retval = retval + offset - p.owncards.Count + p.ownCardsCountStarted;
                    break;
                case CardIds.Collectible.Neutral.ClockworkGiant:
                    retval = retval + offset - p.enemyAnzCards + p.enemyCardsCountStarted;
                    break;
                case CardIds.Collectible.Neutral.MoltenGiant:
                    retval = retval + offset - p.ownHeroHpStarted + p.ownHero.Hp;
                    break;
                case CardIds.Collectible.Neutral.FrostGiant:
                    retval = retval + offset - p.anzUsedOwnHeroPower;
                    break;
                case CardIds.Collectible.Neutral.ArcaneGiant:
                    retval = retval + offset - p.spellsplayedSinceRecalc;
                    break;
                case CardIds.Collectible.Shaman.SnowfuryGiant:
                    retval = retval + offset - p.ueberladung;
                    break;
                case CardIds.Collectible.Mage.KabalCrystalRunner:
                    retval = retval + offset - 2 * p.secretsplayedSinceRecalc;
                    break;
                case CardIds.Collectible.Neutral.SecondRateBruiser:
                    retval = retval + offset - ((p.enemyMinions.Count < 3) ? 0 : 2) + ((p.enemyMobsCountStarted < 3) ? 0 : 2);
                    break;
                case CardIds.NonCollectible.Neutral.Golemagg:
                    retval = retval + offset - p.ownHeroHpStarted + p.ownHero.Hp;
                    break;
                case CardIds.Collectible.Neutral.SkycapnKragg:
                    int costBonus = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((Race)m.handcard.card.Race == Race.PIRATE) costBonus++;
                    }
                    retval = retval + offset - costBonus + p.anzOwnPiratesStarted;
                    break;
                case CardIds.Collectible.Shaman.EveryfinIsAwesome:
                    int costBonusM = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((Race)m.handcard.card.Race == Race.MURLOC) costBonusM++;
                    }
                    retval = retval + offset - costBonusM + p.anzOwnMurlocStarted;
                    break;
                case CardIds.Collectible.Warrior.Crush:
                    // cost 4 less if we have a dmged minion
                    bool dmgedminions = false;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.wounded) dmgedminions = true;
                    }
                    if (dmgedminions != p.startedWithDamagedMinions)
                    {
                        if (dmgedminions)
                        {
                            retval = retval + offset - 4;
                        }
                        else
                        {
                            retval = retval + offset + 4;
                        }
                    }
                    break;
                case CardIds.Collectible.Neutral.HappyGhoul:
                    if (p.ownHero.anzGotHealed > 0) retval = 0;
                    break;
                case CardIds.Collectible.Shaman.ThingFromBelow:
                    if (p.playactions.Count > 0)
                    {
                        foreach (var a in p.playactions)
                        {
                            if (a.actionType == actionEnum.playcard)
                            {
                                switch (a.card.card.CardId)
                                {
                                    case CardIds.Collectible.Shaman.TuskarrTotemic: retval -= p.ownBrannBronzebeard + 1; break;
                                    default:
                                        if ((Race)a.card.card.Race == Race.TOTEM) retval--;
                                        break;
                                }
                            }
                            else if (a.actionType == actionEnum.useHeroPower)
                            {
                                switch (a.card.card.CardId)
                                {
                                    case CardIds.NonCollectible.Shaman.TotemicCall: retval--; break;
                                    case CardIds.NonCollectible.Shaman.JusticarTrueheart_TotemicSlam: retval--; break;
                                }
                            }
                        }
                    }
                    break;
                default:
                    retval = retval + offset;
                    break;
            }

            if (this.Secret && (p.anzOwnCloakedHuntress > 0 || p.nextSecretThisTurnCost0))
            {
                retval = 0;
            }

            retval = Math.Max(0, retval);

            return retval;
        }

        public bool canplayCard(Playfield p, int manacost, bool own)
        {
            if (p.mana < this.getManaCost(p, manacost)) return false;
            if (this.getTargetsForCard(p, false, own).Count == 0) return false;
            return true;
        }

    }
}
