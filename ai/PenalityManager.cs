namespace HREngine.Bots
{
    using HearthDb;
    using HearthDb.Enums;
    using System;
    using System.Collections.Generic;

    public class PenalityManager
    {
        //todo acolyteofpain
        //todo better aoe-penality

        public Dictionary<Chireiden.Silverfish.SimCard, int> HealTargetDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> HealHeroDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> HealAllDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();


        Dictionary<Chireiden.Silverfish.SimCard, int> DamageAllDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> DamageHeroDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> DamageRandomDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> DamageAllEnemysDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> HeroPowerEquipWeapon = new Dictionary<Chireiden.Silverfish.SimCard, int>();

        Dictionary<Chireiden.Silverfish.SimCard, int> enrageDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> silenceDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> OwnNeedSilenceDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();

        Dictionary<Chireiden.Silverfish.SimCard, int> heroAttackBuffDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> attackBuffDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> healthBuffDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> tauntBuffDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();

        Dictionary<Chireiden.Silverfish.SimCard, int> lethalHelpers = new Dictionary<Chireiden.Silverfish.SimCard, int>();

        Dictionary<Chireiden.Silverfish.SimCard, int> spellDependentDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> dragonDependentDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> elementalLTDependentDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();

        public Dictionary<Chireiden.Silverfish.SimCard, int> cardDiscardDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> destroyOwnDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> destroyDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> buffingMinionsDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> buffing1TurnDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> heroDamagingAoeDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> randomEffects = new Dictionary<Chireiden.Silverfish.SimCard, int>();

        Dictionary<Chireiden.Silverfish.SimCard, int> silenceTargets = new Dictionary<Chireiden.Silverfish.SimCard, int>();

        Dictionary<Chireiden.Silverfish.SimCard, int> returnHandDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> GangUpDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> buffHandDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> equipWeaponPlayDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();

        Dictionary<Chireiden.Silverfish.SimCard, int> priorityDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, int> UsefulNeedKeepDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        Dictionary<Chireiden.Silverfish.SimCard, Chireiden.Silverfish.SimCard> choose1database = new Dictionary<Chireiden.Silverfish.SimCard, Chireiden.Silverfish.SimCard>();
        Dictionary<Chireiden.Silverfish.SimCard, Chireiden.Silverfish.SimCard> choose2database = new Dictionary<Chireiden.Silverfish.SimCard, Chireiden.Silverfish.SimCard>();

        public Dictionary<Chireiden.Silverfish.SimCard, int> DamageTargetDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> DamageTargetSpecialDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> maycauseharmDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> cardDrawBattleCryDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> cardDrawDeathrattleDatabase = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> priorityTargets = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        public Dictionary<Chireiden.Silverfish.SimCard, int> specialMinions = new Dictionary<Chireiden.Silverfish.SimCard, int>(); //minions with cardtext, but no battlecry
        public Dictionary<Chireiden.Silverfish.SimCard, int> ownSummonFromDeathrattle = new Dictionary<Chireiden.Silverfish.SimCard, int>();

        Dictionary<Race, int> ClassRacePriorityWarloc = new Dictionary<Race, int>();
        Dictionary<Race, int> ClassRacePriorityHunter = new Dictionary<Race, int>();
        Dictionary<Race, int> ClassRacePriorityMage = new Dictionary<Race, int>();
        Dictionary<Race, int> ClassRacePriorityShaman = new Dictionary<Race, int>();
        Dictionary<Race, int> ClassRacePriorityDruid = new Dictionary<Race, int>();
        Dictionary<Race, int> ClassRacePriorityPaladin = new Dictionary<Race, int>();
        Dictionary<Race, int> ClassRacePriorityPriest = new Dictionary<Race, int>();
        Dictionary<Race, int> ClassRacePriorityRouge = new Dictionary<Race, int>();
        Dictionary<Race, int> ClassRacePriorityWarrior = new Dictionary<Race, int>();

        ComboBreaker cb;
        Hrtprozis prozis;
        Settings settings;
        Ai ai;

        private static PenalityManager instance;

        public static PenalityManager Instance
        {
            get
            {
                return instance ?? (instance = new PenalityManager());
            }
        }

        public void setInstances()
        {
            ai = Ai.Instance;
            cb = ComboBreaker.Instance;
            prozis = Hrtprozis.Instance;
            settings = Settings.Instance;
        }

        private PenalityManager()
        {
            setupHealDatabase();
            setupEnrageDatabase();
            setupDamageDatabase();
            setupPriorityList();
            setupsilenceDatabase();
            setupAttackBuff();
            setupHealthBuff();
            setupCardDrawBattlecry();
            setupDiscardCards();
            setupDestroyOwnCards();
            setupSpecialMins();
            setupEnemyTargetPriority();
            setupHeroDamagingAOE();
            setupBuffingMinions();
            setupRandomCards();
            setupLethalHelpMinions();
            setupSilenceTargets();
            setupUsefulNeedKeepDatabase();
            setupRelations();
            setupChooseDatabase();
            setupClassRacePriorityDatabase();
            setupGangUpDatabase();
            setupOwnSummonFromDeathrattle();
			setupbuffHandDatabase();
            setupequipWeaponPlayDatabase();
            setupReturnBackToHandCards();
        }


        public int getAttackWithMininonPenality(Minion m, Playfield p, Minion target)
        {
            int retval = ai.botBase.getAttackWithMininonPenality(m, p, target);
            if (retval < 0 || retval > 499) return retval;

            retval += getAttackSecretPenality(m, p, target);
            if (!p.isLethalCheck && m.name == CardIds.Collectible.Warlock.BloodImp) retval += 50;
            switch (m.name.CardId)
            {
                case CardIds.Collectible.Neutral.LeeroyJenkins:
                    if (!target.own && target.name == CardIds.NonCollectible.Neutral.Whelp) return 500;
                    break;
                case CardIds.Collectible.Neutral.BloodmageThalnos:
                    if (!target.isHero && Ai.Instance.lethalMissing <= 5)
                    {
                        if (!target.taunt)
                        {
                            if (m.Hp <= target.Angr && m.own && !m.divineshild && !m.immune) return 65;
                        }
                    }
                    goto case Chireiden.Silverfish.SimCard.None;


                case CardIds.Collectible.Neutral.AcolyteOfPain:
                case CardIds.Collectible.Neutral.ClockworkGnome:
                case CardIds.Collectible.Neutral.LootHoarder:
                case CardIds.Collectible.Neutral.MechanicalYeti:
                case CardIds.Collectible.Druid.MechBearCat:
                case CardIds.Collectible.Rogue.TombPillager:
                case CardIds.Collectible.Neutral.Toshley:
                case CardIds.Collectible.Hunter.Webspinner:
                case Chireiden.Silverfish.SimCard.None:

                    if (m.Hp <= target.Angr && m.own && !m.divineshild && !m.immune)
                    {
                        int carddraw = 1;
                        if (p.owncards.Count + carddraw > 10) retval += 15 * (p.owncards.Count + carddraw - 10);
                        else retval += 3 * p.optionsPlayedThisTurn;
                    }
                    return retval;
            }
            if (this.specialMinions.ContainsKey(m.name) && target.Hp > m.Angr && !target.isHero) retval++;
            if (this.UsefulNeedKeepDatabase.ContainsKey(m.name) && !target.isHero && !(m.divineshild || target.Angr == 0)) retval++;
            if (m.justBuffed > 0)
            {
                if (m.divineshild || m.immune) {}
                else if (target.poisonous || target.Angr >= m.Hp) retval += m.justBuffed;
            }
            return retval;
        }

        public int getAttackWithHeroPenality(Minion target, Playfield p)
        {
            bool isLethalCheck = p.isLethalCheck;
            int retval = ai.botBase.getAttackWithHeroPenality(target, p);
            if (retval < 0 || retval > 499) return retval;

            if (!isLethalCheck && target.isHero && target.Hp > settings.enfacehp)
            {
                switch (settings.weaponOnlyAttackMobsUntilEnfacehp)
                {
                    case 1:
                        if (p.ownWeapon.Durability == 1 && p.ownWeapon.Angr > 1) return 500;
                        break;
                    case 2:
                        return 500;
                    case 3:
                        if (p.ownWeapon.Durability == 1) return 500;
                        break;
                    case 4:
                        if (weaponInHandAttackNextTurn(p) == 0) return 500;
                        break;
                    case 5:
                        int wAttack = weaponInHandAttackNextTurn(p);
                        if (wAttack > 1 || (wAttack == 1 && p.ownWeapon.Angr == 1)) { }
                        else return 500;
                        break;
                    default:
                        if (p.ownWeapon.Angr > 1) return 500;
                        break;
                }
            }

            if (!isLethalCheck && p.enemyWeapon.name == CardIds.Collectible.Paladin.SwordOfJustice)
            {
                return 28;
            }

            switch (p.ownWeapon.name.CardId)
            {
                case CardIds.NonCollectible.Neutral.Atiesh:
                    if (!isLethalCheck)
                    {
                        if (target.isHero) return 500;
                        else return 15;
                    }
                    break;
                case CardIds.Collectible.Shaman.Doomhammer:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card == CardIds.Collectible.Shaman.RockbiterWeapon && hc.canplayCard(p, true)) return 10;
                    }
                    break;
                case CardIds.Collectible.Hunter.EaglehornBow:
                    if (p.ownWeapon.Durability == 1)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card == CardIds.Collectible.Hunter.ArcaneShot || hc.card == CardIds.Collectible.Hunter.KillCommand) return -p.ownWeapon.Angr - 1;
                        }
                        if (p.ownSecretsIDList.Count >= 1) return 20;

                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Secret) return 20;
                        }
                    }
                    break;
                case CardIds.Collectible.Shaman.SpiritClaws:
                    if (!isLethalCheck && p.ownWeapon.Angr == 1)
                    {
                        if (target.isHero) return 500;
                        else if (target.Hp == 1 && this.specialMinions.ContainsKey(target.name)) return 0;
                        else return 7;
                    }
                    break;
                case CardIds.Collectible.Warrior.Gorehowl:
                    if (target.isHero && p.ownWeapon.Angr >= 3) return 10;
                    break;
                case CardIds.Collectible.Warrior.BrassKnuckles:
                    if (target.own)
                    {
                        if (p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.Mob) != null)
                        {
                            return -5;
                        }
                    }
                    else
                    {
                        if (p.enemyAnzCards > 3) return -5;
                    }
                    break;
            }

            if (p.ownWeapon.Durability >= 1)
            {
                int wAttack = weaponInHandAttackNextTurn(p);
                if (p.ownWeapon.Angr == 1 && wAttack == 0 && (p.ownHeroAblility.card == Chireiden.Silverfish.SimCard.poisoneddaggers || p.ownHeroAblility.card.CardId == CardIds.NonCollectible.Rogue.DaggerMastery)) wAttack = 1;
                if (wAttack > 0) retval = -p.ownWeapon.Angr - 1; // so he doesnt "lose" the weapon in evaluation :D
            }
            if (p.ownWeapon.Angr == 1 && p.ownHeroName == HeroEnum.thief)
            {
                if (target.Hp < 11) retval += 1;
                else retval += -1;
            }
            return retval;
        }

        public int weaponInHandAttackNextTurn(Playfield p)
        {
            foreach (Handmanager.Handcard c in p.owncards)
            {
                if (c.card.Type == CardType.WEAPON && c.card.getManaCost(p, c.manacost) <= p.ownMaxMana + 1)
                {
                    return c.card.Attack;
                }
                if (this.equipWeaponPlayDatabase.ContainsKey(c.card) && c.card != CardIds.Collectible.Warrior.Upgrade && c.card.getManaCost(p, c.manacost) <= p.ownMaxMana + 1)
                {
                    return this.equipWeaponPlayDatabase[c.card];
                }
            }
            return 0;
        }

        public int getPlayCardPenality(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            int retval = ai.botBase.getPlayCardPenality(card, target, p);
            if (retval < 0 || retval > 499) return retval;

            Chireiden.Silverfish.SimCard name = card.CardId;
            //there is no reason to buff HP of minon (because it is not healed)

            int abuff = getAttackBuffPenality(card, target, p);
            int tbuff = getTauntBuffPenality(card, target, p);
            if (name == CardIds.Collectible.Druid.MarkOfTheWild && ((abuff >= 500 && tbuff == 0) || (abuff == 0 && tbuff >= 500)))
            {
                retval = 0;
            }
            else
            {
                retval += abuff + tbuff;
            }
            retval += getHPBuffPenality(card, target, p);
            retval += getSilencePenality(name, target, p);
            retval += getDamagePenality(card, target, p);
            retval += getHealPenality(name, target, p);
            retval += getCardDrawPenality(card, target, p);
            retval += getCardDrawofEffectMinions(card, p);
            retval += getCardDiscardPenality(name, p);
            retval += getDestroyOwnPenality(name, target, p);

            retval += getDestroyPenality(name, target, p);
            retval += getSpecialCardComboPenalitys(card, target, p);
            retval += getRandomPenaltiy(card, p, target);
            retval += getBuffHandPenalityPlay(name, p);
            if (!p.isLethalCheck)
            {
                retval += cb.getPenalityForDestroyingCombo(card, p);
                retval += cb.getPlayValue(card.CardId);
            }

            retval += playSecretPenality(card, p);
            retval += getPlayCardSecretPenality(card, p);

            return retval;
        }


        private int getAttackBuffPenality(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            Chireiden.Silverfish.SimCard name = card.CardId;
            if (name == CardIds.Collectible.Druid.DarkWispers && card.CardId != CardIds.NonCollectible.Druid.DarkWispers_CallTheGuardians) return 0;
            int pen = 0;
            //buff enemy?

            if (!p.isLethalCheck && (card.CardId == CardIds.Collectible.Druid.SavageRoar || card.CardId == CardIds.Collectible.Shaman.Bloodlust))
            {
                int targets = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Ready) targets++;
                }
                if ((p.ownHero.Ready || p.ownHero.numAttacksThisTurn == 0) && card.CardId == CardIds.Collectible.Druid.SavageRoar) targets++;

                if (targets <= 2)
                {
                    return 20;
                }
            }

            if (!this.attackBuffDatabase.ContainsKey(name)) return 0;
            if (target == null) return 60;
            if (!target.isHero && !target.own)
            {
                if (card.Type == CardType.MOB && p.ownMinions.Count == 0) return 2;

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    switch (hc.card.CardId)
                    {
                        case CardIds.Collectible.Neutral.BigGameHunter:
                            if (target.Angr + this.attackBuffDatabase[name] > 6) return 5;
                            break;
                        case CardIds.Collectible.Priest.ShadowWordDeath:
                            if (target.Angr + this.attackBuffDatabase[name] > 4) return 5;
                            break;
                        default:
                            break;
                    }
                }
                if (card.CardId == CardIds.Collectible.Warrior.CruelTaskmaster || card.CardId == CardIds.Collectible.Warrior.InnerRage)
                {
                    Minion m = target;

                    if (m.Hp == 1)
                    {
                        return 0;
                    }

                    if (!m.wounded && (m.Angr >= 4 || m.Hp >= 5))
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.CardId == CardIds.Collectible.Warrior.Execute) return 0;
                        }
                    }
                    pen = 30;
                }
                else
                {
                    pen = 500;
                }
            }
            if (!target.isHero && target.own)
            {
                Minion m = target;
                if (!m.Ready)
                {
                    switch (card.CardId)
                    {
                        case CardIds.Collectible.Druid.MarkOfYshaarj:
                            if (target.stealth)
                            {
                                if ((Race)target.handcard.card.Race == Race.PET) return 3;
                                else return 7;
                            }
                            if ((Race)target.handcard.card.Race == Race.PET && p.owncards.Count < 2) return 3;
                            return 50;

                        default:
                            break;
                    }
                    return 50;
                }
                if (m.Hp == 1 && !m.divineshild && !this.buffing1TurnDatabase.ContainsKey(name))
                {
                    return 10;
                }
                if (m.Angr == 0)
                {
                    if (!m.silenced && m.handcard.card.deathrattle) return -8;
                    return -5;
                }
            }

            return pen;
        }

        private int getHPBuffPenality(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            Chireiden.Silverfish.SimCard name = card.CardId;
            int pen = 0;

            if (!this.healthBuffDatabase.ContainsKey(name)) return 0;
            if (name == CardIds.Collectible.Druid.DarkWispers && card.CardId != CardIds.NonCollectible.Druid.DarkWispers_CallTheGuardians) return 0;

            if (target != null && !target.own && !this.tauntBuffDatabase.ContainsKey(name))
            {
                pen = 500 + p.ownMinions.Count;
            }

            return pen;
        }


        private int getTauntBuffPenality(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            Chireiden.Silverfish.SimCard name = card.CardId;
            int pen = 0;
            //buff enemy?
            if (!this.tauntBuffDatabase.ContainsKey(name)) return 0;
            if (name == CardIds.Collectible.Druid.MarkOfNature && card.CardId != CardIds.NonCollectible.Druid.MarkofNature_ThickHide) return 0;
            if (name == CardIds.Collectible.Druid.DarkWispers && card.CardId != CardIds.NonCollectible.Druid.DarkWispers_CallTheGuardians) return 0;

            if (target == null) return 3;
            if (!target.isHero && !target.own)
            {
                //allow it if you have black knight
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.CardId == CardIds.Collectible.Neutral.TheBlackKnight) return 0;
                }

                // allow taunting if target is priority and others have taunt
                bool enemyhasTaunts = false;
                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.taunt)
                    {
                        enemyhasTaunts = true;
                        break;
                    }
                }
                if (enemyhasTaunts && this.priorityDatabase.ContainsKey(target.name) && !target.silenced && !target.taunt)
                {
                    return 0;
                }

                pen = 500;
            }

            return pen;
        }

        private int getSilencePenality(Chireiden.Silverfish.SimCard name, Minion target, Playfield p)
        {
            int pen = 0;

            if (target == null)
            {
                if (name == CardIds.Collectible.Neutral.IronbeakOwl || name == CardIds.Collectible.Neutral.Spellbreaker || name == CardIds.Collectible.Druid.KeeperOfTheGrove)
                {
                    return 20;
                }
                return 0;
            }

            if (target.own)
            {
                if (this.silenceDatabase.ContainsKey(name))
                {
                    if (!target.silenced && this.OwnNeedSilenceDatabase.ContainsKey(target.name)) return -5;
                    if (target.Angr < target.handcard.card.Attack || target.maxHp < target.handcard.card.Health
                        || target.enemyPowerWordGlory > 0 || target.enemyBlessingOfWisdom > 0
                        || (target.frozen && !target.playedThisTurn && target.numAttacksThisTurn == 0))
                    {
                        return 0;
                    }
                    pen += 500;
                }
            }
            else
            {
                switch (target.name)
                {
                    case Chireiden.Silverfish.SimCard.masterchest: return 500;
                }
                if (this.silenceDatabase.ContainsKey(name))
                {
                    pen = 5;
                    if (p.isLethalCheck)
                    {
                        //during lethal we only silence taunt, or if its a mob (owl/spellbreaker) + we can give him charge
                        if (target.taunt || (name == CardIds.Collectible.Neutral.IronbeakOwl && (p.ownMinions.Find(x => x.name == CardIds.Collectible.Hunter.TundraRhino) != null || p.owncards.Find(x => x.card.CardId == CardIds.Collectible.Warrior.Charge) != null)) || (name == CardIds.Collectible.Neutral.Spellbreaker && p.owncards.Find(x => x.card.CardId == CardIds.Collectible.Warrior.Charge) != null)) return 0;

                        return 500;
                    }

                    if (!target.silenced && this.OwnNeedSilenceDatabase.ContainsKey(target.name))
                    {
                        if (target.taunt) pen += 15;
                        return 500;
                    }

                    if (!target.silenced)
                    {
                        if (this.priorityDatabase.ContainsKey(target.name)) return 0;
                        if (this.silenceTargets.ContainsKey(target.name)) return 0;
                        if (target.handcard.card.deathrattle) return 0;
                    }

                    if (target.Angr <= target.handcard.card.Attack && target.maxHp <= target.handcard.card.Health && !target.taunt && !target.windfury && !target.divineshild && !target.poisonous && !target.lifesteal && !this.specialMinions.ContainsKey(name))
                    {
                        if (name == CardIds.Collectible.Druid.KeeperOfTheGrove) return 500;
                        return 30;
                    }

                    if (target.Angr > target.handcard.card.Attack || target.maxHp > target.handcard.card.Health)
                    {
                        return 0;
                    }

                    return pen;
                }
            }

            return pen;

        }

        private int getDamagePenality(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            Chireiden.Silverfish.SimCard name = card;
            int pen = 0;

            if (name == CardIds.Collectible.Warrior.ShieldSlam && p.ownHero.armor == 0) return 500;
            if (name == CardIds.Collectible.Druid.Savagery && p.ownHero.Angr == 0) return 500;

            //aoe damage *************************************************************************************
            int aoeDamageType = 0;
            if (this.DamageAllEnemysDatabase.ContainsKey(name)) aoeDamageType = 1;
            else if (p.anzOwnAuchenaiSoulpriest >= 1 && HealAllDatabase.ContainsKey(name)) aoeDamageType = 2;
            else if (this.DamageAllDatabase.ContainsKey(name)) aoeDamageType = 3;
            if (aoeDamageType > 0)
            {
                if (p.enemyMinions.Count == 0)
                {
                    if (name == CardIds.Collectible.Neutral.Cthun) return 0;
                    return 300;
                }

                int aoeDamage = 0;
                if (aoeDamageType == 1) aoeDamage = (card.Type == CardType.SPELL) ? p.getSpellDamageDamage(this.DamageAllEnemysDatabase[name]) : this.DamageAllEnemysDatabase[name];
                else if (aoeDamageType == 2) aoeDamage = (card.Type == CardType.SPELL) ? p.getSpellDamageDamage(this.HealAllDatabase[name]) : this.HealAllDatabase[name];
                else if (aoeDamageType == 3)
                {
                    if (name == CardIds.Collectible.Warrior.Revenge && p.ownHero.Hp <= 12) aoeDamage = p.getSpellDamageDamage(3);
                    else aoeDamage = (card.Type == CardType.SPELL) ? p.getSpellDamageDamage(this.DamageAllDatabase[name]) : this.DamageAllDatabase[name];
                }

                int preventDamage = 0;
                int lostOwnDamage = 0;
                int lostOwnHp = 0;
                int lostOwnMinions = 0;
                int survivedEnemyMinions = 0;
                int survivedEnemyMinionsAngr = 0;
                bool frothingberserkerEnemy = false;
                bool frothingberserkerOwn = false;
                bool grimpatronEnemy = false;
                bool grimpatronOwn = false;
                int numSpecialMinionsEnemy = 0;


                int preventDamageAdd = 0;
                int anz = p.enemyMinions.Count;
                for (int i = 0; i < anz; i++)
                {
                    Minion m = p.enemyMinions[i];
                    if (aoeDamage >= m.Hp && !m.divineshild)
                    {
                        switch (name)
                        {
                            case CardIds.Collectible.Warrior.SleepWithTheFishes:
                                if (!m.wounded) continue;
                                break;
                            case CardIds.Collectible.Priest.DragonfirePotion:
                                if ((Race)m.handcard.card.Race == Race.DRAGON) continue;
                                break;
                            case CardIds.Collectible.Neutral.CorruptedSeer:
                                if ((Race)m.handcard.card.Race == Race.MURLOC) continue;
                                break;
                            case CardIds.NonCollectible.Neutral.ShadowVolley:
                                if ((Race)m.handcard.card.Race == Race.DEMON) continue;
                                break;
                            case CardIds.Collectible.Warlock.Demonwrath:
                                if ((Race)m.handcard.card.Race == Race.DEMON) continue;
                                break;
                            case CardIds.Collectible.Paladin.ScarletPurifier:
                                if (!(m.handcard.card.deathrattle && !m.silenced)) continue;
                                break;
                            case CardIds.NonCollectible.DreamCards.YseraAwakens:
                                if (m.name == CardIds.Collectible.Neutral.Ysera) continue;
                                break;
                            case CardIds.Collectible.Priest.Lightbomb:
                                if (m.Hp > m.Angr) continue;
                                break;
                        }

                        if (this.specialMinions.ContainsKey(m.name)) numSpecialMinionsEnemy++;
                        switch (m.name)
                        {
                            case CardIds.Collectible.Neutral.DireWolfAlpha:
                                if (m.silenced) break;

                                if (i > 0)
                                {
                                    if (p.enemyMinions[i - 1].divineshild)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].Hp <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i - 1].Hp > aoeDamage)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].Hp - aoeDamage <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                }
                                if (i < anz - 1)
                                {
                                    if (p.enemyMinions[i + 1].divineshild)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].Hp <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i + 1].Hp > aoeDamage)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].Hp - aoeDamage <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                }
                                break;
                            case CardIds.Collectible.Shaman.FlametongueTotem:
                                if (m.silenced) break;
                                if (i > 0)
                                {
                                    if (p.enemyMinions[i - 1].divineshild)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].Hp <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i - 1].Hp > aoeDamage)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].Hp - aoeDamage <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                }
                                if (i < anz - 1)
                                {
                                    if (p.enemyMinions[i + 1].divineshild)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].Hp <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i + 1].Hp > aoeDamage)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].Hp - aoeDamage <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                }
                                break;
                            case CardIds.NonCollectible.Hunter.Leokk:
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.Hp > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardIds.Collectible.Neutral.RaidLeader:
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.Hp > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardIds.Collectible.Neutral.StormwindChampion:
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.Hp > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardIds.Collectible.Neutral.GrimscaleOracle:
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((Race)mm.handcard.card.Race == Race.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;

                            case CardIds.Collectible.Neutral.MurlocWarleader:
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((Race)mm.handcard.card.Race == Race.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 2;
                                }
                                break;
                            case CardIds.Collectible.Warlock.Malganis:
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((Race)mm.handcard.card.Race == Race.DEMON && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 2;
                                }
                                break;
                            case CardIds.Collectible.Neutral.SouthseaCaptain:
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((Race)mm.handcard.card.Race == Race.PIRATE && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardIds.Collectible.Hunter.TimberWolf:
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((Race)mm.handcard.card.Race == Race.PET && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardIds.Collectible.Paladin.WarhorseTrainer:
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if (mm.name == Chireiden.Silverfish.SimCard.silverhandrecruit && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardIds.Collectible.Warrior.WarsongCommander:
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if (mm.charge > 0 && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardIds.Collectible.Shaman.TunnelTrogg:
                                preventDamage++;
                                break;
                            case CardIds.Collectible.Neutral.Secretkeeper:
                                preventDamage++;
                                break;
                        }
                        preventDamage += m.Angr;
                    }
                    else
                    {
                        survivedEnemyMinions++;
                        if (survivedEnemyMinionsAngr < m.Angr) survivedEnemyMinionsAngr = m.Angr;
                        if (!m.wounded && this.enrageDatabase.ContainsKey(name)) preventDamage -= this.enrageDatabase[name];
                        else if (m.name == CardIds.Collectible.Neutral.GurubashiBerserker) preventDamage -= 3;
                        else if (m.name == CardIds.Collectible.Warrior.FrothingBerserker) frothingberserkerEnemy = true;
                        else if (m.name == CardIds.Collectible.Neutral.GrimPatron) { preventDamage -= 3; grimpatronEnemy = true; }
                    }
                }
                preventDamage += preventDamageAdd;

                if (aoeDamageType > 1)
                {
                    anz = p.ownMinions.Count;
                    for (int i = 0; i < anz; i++)
                    {
                        Minion m = p.ownMinions[i];
                        if (aoeDamage >= m.Hp && !m.divineshild)
                        {
                            switch (name.CardId)
                            {
                                case CardIds.Collectible.Warrior.SleepWithTheFishes:
                                    if (!m.wounded) continue;
                                    break;
                                case CardIds.Collectible.Priest.DragonfirePotion:
                                    if ((Race)m.handcard.card.Race == Race.DRAGON) continue;
                                    break;
                                case CardIds.Collectible.Neutral.CorruptedSeer:
                                    if ((Race)m.handcard.card.Race == Race.MURLOC) continue;
                                    break;
                                case CardIds.NonCollectible.Neutral.ShadowVolley:
                                    if ((Race)m.handcard.card.Race == Race.DEMON) continue;
                                    break;
                                case CardIds.Collectible.Warlock.Demonwrath:
                                    if ((Race)m.handcard.card.Race == Race.DEMON) continue;
                                    break;
                                case CardIds.Collectible.Paladin.ScarletPurifier:
                                    if (!(m.handcard.card.deathrattle && !m.silenced)) continue;
                                    break;
                                case CardIds.NonCollectible.DreamCards.YseraAwakens:
                                    if (m.name == CardIds.Collectible.Neutral.Ysera) continue;
                                    break;
                                case CardIds.Collectible.Priest.Lightbomb:
                                    if (m.Hp > m.Angr) continue;
                                    break;
                            }

                            switch (m.name.CardId)
                            {
                                case CardIds.Collectible.Neutral.DireWolfAlpha:
                                    if (m.silenced) break;
                                    if (i > 0 && (p.ownMinions[i - 1].Hp > aoeDamage || p.ownMinions[i - 1].divineshild)) lostOwnDamage += 1;
                                    if (i < anz - 1 && (p.ownMinions[i + 1].Hp > aoeDamage || p.ownMinions[i + 1].divineshild)) lostOwnDamage += 1;
                                    break;
                                case CardIds.Collectible.Shaman.FlametongueTotem:
                                    if (m.silenced) break;
                                    if (i > 0 && (p.ownMinions[i - 1].Hp > aoeDamage || p.ownMinions[i - 1].divineshild)) lostOwnDamage += 2;
                                    if (i < anz - 1 && (p.ownMinions[i + 1].Hp > aoeDamage || p.ownMinions[i + 1].divineshild)) lostOwnDamage += 2;
                                    break;
                                case CardIds.NonCollectible.Hunter.Leokk:
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.Hp > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardIds.Collectible.Neutral.RaidLeader:
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.Hp > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardIds.Collectible.Neutral.StormwindChampion:
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.Hp > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardIds.Collectible.Neutral.GrimscaleOracle:
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((Race)mm.handcard.card.Race == Race.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;

                                case CardIds.Collectible.Neutral.MurlocWarleader:
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((Race)mm.handcard.card.Race == Race.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 2;
                                    }
                                    break;
                                case CardIds.Collectible.Warlock.Malganis:
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((Race)mm.handcard.card.Race == Race.DEMON && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 2;
                                    }
                                    break;
                                case CardIds.Collectible.Neutral.SouthseaCaptain:
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((Race)mm.handcard.card.Race == Race.PIRATE && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardIds.Collectible.Hunter.TimberWolf:
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((Race)mm.handcard.card.Race == Race.PET && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardIds.Collectible.Paladin.WarhorseTrainer:
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if (mm.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardIds.Collectible.Warrior.WarsongCommander:
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if (mm.charge > 0 && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                            }
                            lostOwnHp += m.Hp;
                            lostOwnDamage += m.Angr;

                            lostOwnMinions++;
                            if (!m.wounded && this.enrageDatabase.ContainsKey(name)) lostOwnDamage += this.enrageDatabase[name];
                            else if (m.name == CardIds.Collectible.Neutral.GurubashiBerserker && m.Hp > 1) lostOwnDamage += 3;
                            else if (m.name == CardIds.Collectible.Warrior.FrothingBerserker) frothingberserkerOwn = true;
                            else if (m.name == CardIds.Collectible.Neutral.GrimPatron) { lostOwnDamage += 3; grimpatronOwn = true; }
                        }
                    }

                    if (p.ownMinions.Count - lostOwnMinions - survivedEnemyMinions > 0)
                    {
                        if (preventDamage >= lostOwnDamage) return 0;
                        return (lostOwnDamage - preventDamage) * 2;
                    }
                    else
                    {
                        if (preventDamage >= lostOwnDamage * 2 + 1) return 0;
                        int MinionBalance = lostOwnMinions - (p.enemyMinions.Count - survivedEnemyMinions);
                        if (MinionBalance > 0 && preventDamage <= lostOwnDamage) return 80;
                        if (survivedEnemyMinions > 0)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards) if (hc.card == CardIds.Collectible.Warrior.Execute) return 0;
                        }
                        if (lostOwnHp <= preventDamage)
                        {
                            if (MinionBalance <= 0) return 1;
                            return 10;
                        }
                        else return 30;
                    }
                }
                else
                {

                    if (preventDamage > 5 || (p.enemyMinions.Count - survivedEnemyMinions) >= 4) return 0;
                    else if (name == CardIds.Collectible.Priest.HolyNova && preventDamage >= 0)
                    {
                        int ownWoundedMinions = 0;
                        foreach (Minion m in p.ownMinions) if (m.wounded) ownWoundedMinions++;
                        if (ownWoundedMinions > 2) return 20;
                    }

                    if (survivedEnemyMinions > 0)
                    {
                        int hasExecute = 0;
                        foreach (Handmanager.Handcard hc in p.owncards) if (hc.card == CardIds.Collectible.Warrior.Execute) hasExecute++;
                        if (hasExecute > 0)
                        {
                            if (survivedEnemyMinions <= hasExecute) return 0;
                            preventDamage += survivedEnemyMinionsAngr;
                            if (preventDamage > 6) preventDamage = 6;
                        }
                    }

                    int tmp = 0;
                    Minion bogMob = null;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.Angr > tmp)
                        {
                            tmp = m.Angr;
                            bogMob = m;
                        }
                    }
                    if (bogMob != null && bogMob.Angr >= 4 && bogMob.Hp > preventDamage)
                    {
                        preventDamage = 6;
                    }

                    return (6 - preventDamage) * 20 - numSpecialMinionsEnemy * 8 - p.spellpower;
                }
            }
            //END aoe damage **********************************************************************************

            if (target == null) return 0;

            if (target.own && target.isHero)
            {
                if (DamageTargetDatabase.ContainsKey(name) || DamageTargetSpecialDatabase.ContainsKey(name) || (p.anzOwnAuchenaiSoulpriest >= 1 && HealTargetDatabase.ContainsKey(name)))
                {
                    pen = 500;
                }
            }

            if (!p.isLethalCheck && !target.own && target.isHero)
            {
                if (name == CardIds.Collectible.Warlock.BaneOfDoom)
                {
                    pen = 500;
                }
            }

            if (target.own && !target.isHero)
            {
                if (DamageTargetDatabase.ContainsKey(name) || (p.anzOwnAuchenaiSoulpriest >= 1 && HealTargetDatabase.ContainsKey(name)))
                {
                    // no pen if own is enrage
                    Minion m = target;

                    //standard ones :D (mostly carddraw
                    if (enrageDatabase.ContainsKey(m.name) && !m.wounded && m.Ready)
                    {
                        return pen;
                    }

                    if (m.name == CardIds.Collectible.Neutral.MadScientist && p.ownHeroStartClass == CardClass.HUNTER) return 500;

                    // no pen if we have battlerage for example
                    int dmg = this.DamageTargetDatabase.ContainsKey(name) ? this.DamageTargetDatabase[name] : this.HealTargetDatabase[name];
                    switch (card.CardId)
                    {
                        case CardIds.NonCollectible.Druid.KeeperoftheGrove_Moonfire: dmg = 2 - p.spellpower; break;
                        case CardIds.Collectible.Mage.IceLance: if (!target.frozen) return 0; break;
                        case CardIds.Collectible.Warrior.MortalStrike: if (p.ownHero.Hp <= 12) dmg = 6; break;
                        case CardIds.Collectible.Hunter.KillCommand:
                            foreach (Minion mn in p.ownMinions)
                            {
                                if ((Race)mn.handcard.card.Race == Race.PET) { dmg = 5; break; }
                            }
                            break;
                    }
                    if (card.Type == CardType.SPELL) dmg = p.getSpellDamageDamage(dmg);

                    if (m.Hp > dmg)
                    {
                        switch (m.name.CardId)
                        {
                            case CardIds.Collectible.Neutral.GurubashiBerserker: return 0;
                            case CardIds.Collectible.Warrior.AxeFlinger: return 0;
                            case CardIds.Collectible.Hunter.Gahzrilla: return 0;
                            case Chireiden.Silverfish.SimCard.garr: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardIds.Collectible.Neutral.HoggerDoomOfElwynn: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardIds.Collectible.Neutral.AcolyteOfPain: if (p.owncards.Count <= 3) return 0; break;
                            case CardIds.Collectible.Neutral.DragonEgg: if (p.ownMinions.Count <= 6) return 5; break;
                            case CardIds.Collectible.Warlock.ImpGangBoss: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardIds.Collectible.Neutral.GrimPatron: if (p.ownMinions.Count <= 6) return 0; break;
                        }
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card == CardIds.Collectible.Warrior.BattleRage) return pen;
                            if (hc.card == CardIds.Collectible.Warrior.Rampage) return pen;
                        }
                    }
                    else
                    {
                        if (p.isLethalCheck && dmg == 1 && p.enemyHero.Hp < 3)
                        {
                            switch (m.name.CardId)
                            {
                                case CardIds.Collectible.Neutral.LeperGnome: return 0; break;
                                case CardIds.Collectible.Warrior.AxeFlinger: return 0; break;
                            }
                        }
                        if (cardDrawDeathrattleDatabase.ContainsKey(m.name))
                        {
                            if (ai.lethalMissing <= 5 && p.lethalMissing() <= 5) pen += 115 + (dmg - m.Hp) * 10; //behav compensation
                            if (p.enemyAnzCards == 9) pen += 60; //drawACard compensation
                            return 10;
                        }
                    }
                    if (m.handcard.card.Deathrattle) return 10;

                    pen = 500;
                }

                //special cards
                if (DamageTargetSpecialDatabase.ContainsKey(name))
                {
                    int dmg = DamageTargetSpecialDatabase[name];
                    Minion m = target;
                    switch (name.CardId)
                    {
                        case CardIds.Collectible.Warrior.CruelTaskmaster: if (m.Hp >= 2) return 0; break;
                        case CardIds.Collectible.Warrior.InnerRage: if (m.Hp >= 2) return 0; break;
                        case CardIds.Collectible.Warlock.Demonfire: if ((Race)m.handcard.card.Race == Race.DEMON) return 0; break;
                        case CardIds.Collectible.Warlock.Demonheart: if ((Race)m.handcard.card.Race == Race.DEMON) return 0; break;
                        case CardIds.Collectible.Shaman.EarthShock:
                            if (m.Hp >= 2)
                            {
                                if ((!m.silenced && this.OwnNeedSilenceDatabase.ContainsKey(m.name))
                                    || m.Angr < m.handcard.card.Attack || m.maxHp < m.handcard.card.Health
                                    || m.enemyPowerWordGlory > 0 || m.enemyBlessingOfWisdom > 0
                                    || (m.frozen && !m.playedThisTurn && m.numAttacksThisTurn == 0))
                                    return 0;
                                if ((enrageDatabase.ContainsKey(m.name) || priorityDatabase.ContainsKey(m.name)) && !m.silenced) return 500;
                            }
                            else return 500; //dont silence other own minions
                            break;
                    }
                    if (m.Hp > dmg)
                    {
                        if (enrageDatabase.ContainsKey(m.name) && !m.wounded && m.Ready) // no pen if own is enrage
                        {
                            return pen;
                        }

                        foreach (Handmanager.Handcard hc in p.owncards) // no pen if we have battlerage for example
                        {
                            switch (hc.card.CardId)
                            {
                                case CardIds.Collectible.Warrior.BattleRage: return pen; break;
                                case CardIds.Collectible.Warrior.Rampage: return pen; break;
                                case CardIds.Collectible.Warrior.BloodWarriors: return pen; break;
                            }
                        }
                    }
                    pen = 500;
                }
            }
            if (!target.own && !target.isHero)
            {
                int realDamage = 0;
                if (DamageTargetSpecialDatabase.ContainsKey(name))
                {
                    realDamage = (card.Type == CardType.SPELL) ? p.getSpellDamageDamage(this.DamageTargetSpecialDatabase[name]) : this.DamageTargetSpecialDatabase[name];
                    switch (name.CardId)
                    {
                        case CardIds.Collectible.Warlock.Soulfire: if (target.Hp <= realDamage - 2) pen = 10; break;
                        case CardIds.Collectible.Warlock.BaneOfDoom: if (target.Hp > realDamage) pen = 10; break;
                        case CardIds.Collectible.Warrior.ShieldSlam: if (target.Hp <= 4 || target.Angr <= 4) pen = 20; break;
                        case CardIds.Collectible.Warrior.BloodToIchor: if (target.Hp <= realDamage) pen = 2; break;
                    }
                }
                else
                {
                    if (DamageTargetDatabase.ContainsKey(name))
                    {
                        realDamage = this.DamageTargetDatabase[name];
                        switch (card.CardId)
                        {
                            case CardIds.NonCollectible.Druid.KeeperoftheGrove_Moonfire: realDamage = 2 - p.spellpower; break;
                            case CardIds.Collectible.Mage.IceLance: if (!target.frozen) return 0; break;
                            case CardIds.Collectible.Warrior.MortalStrike: if (p.ownHero.Hp <= 12) realDamage = 6; break;
                            case CardIds.Collectible.Hunter.KillCommand:
                                foreach (Minion mn in p.ownMinions)
                                {
                                    if ((Race)mn.handcard.card.Race == Race.PET) { realDamage = 5; break; }
                                }
                                break;
                        }
                        if (card.Type == CardType.SPELL) realDamage = p.getSpellDamageDamage(realDamage);
                    }
                }
                if (realDamage == 0) realDamage = card.Attack;
                if (target.name == CardIds.Collectible.Neutral.GrimPatron && realDamage < target.Hp) return 500;
            }

            return pen;
        }

        private int getHealPenality(Chireiden.Silverfish.SimCard name, Minion target, Playfield p)
        {
            ///Todo healpenality for aoe heal
            ///todo auchenai soulpriest
            if (p.anzOwnAuchenaiSoulpriest >= 1) return 0;
            int pen = 0;
            int heal = 0;


            switch (name.CardId)
            {
                case CardIds.Collectible.Druid.TreeOfLife:
                    {
                        int mheal = 0;
                        int wounded = 0;
                        if (p.ownHero.wounded) wounded++;
                        foreach (Minion mi in p.ownMinions)
                        {
                            mheal += Math.Min((mi.maxHp - mi.Hp), 4);
                            if (mi.wounded) wounded++;
                        }
                        if (mheal == 0) return 500;
                        if (mheal <= 7 && wounded <= 2) return 20;
                    }
                    break;

                case CardIds.Collectible.Neutral.RenoJackson:
                    if (p.ownHero.Hp < 16)
                    {
                        int retval = p.ownHero.Hp - 16;
                        if (p.ownHeroHasDirectLethal()) return retval * 10;
                        else return retval * 2;
                    }
                    else
                    {
                        pen = (p.ownHero.Hp - 15) / 2;
                        if (p.ownAbilityReady && cardDrawBattleCryDatabase.ContainsKey(p.ownHeroAblility.card.CardId)) pen += 20;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (!cardDrawBattleCryDatabase.ContainsKey(hc.card.CardId)) continue;
                            pen += 20;
                            break;
                        }
                        return pen;
                    }
                    break;

                case CardIds.Collectible.Priest.CircleOfHealing:
                    {
                        int mheal = 0;
                        int wounded = 0;
                        //int eheal = 0;
                        foreach (Minion mi in p.ownMinions)
                        {
                            mheal += Math.Min((mi.maxHp - mi.Hp), 4);
                            if (mi.wounded) wounded++;
                        }
                        //Console.WriteLine(mheal + " circle");
                        if (mheal == 0) return 500;
                        if (mheal <= 7 && wounded <= 2) return 20;
                    }
                    break;
            }

            if (HealTargetDatabase.ContainsKey(name))
            {
                if (target == null) return 10;
                heal = HealTargetDatabase[name];
                if (target.isHero && !target.own) return 510; // dont heal enemy
                if ((target.isHero && target.own) && p.ownHero.Hp == 30) return 150;
                if ((target.isHero && target.own) && p.ownHero.Hp + heal - 1 > 30) pen = p.ownHero.Hp + heal - 30;
                Minion m = new Minion();

                if (!target.isHero && target.own)
                {
                    m = target;
                    int wasted = 0;
                    if (m.Hp == m.maxHp) return 500;
                    if (m.Hp + heal - 1 > m.maxHp) wasted = m.Hp + heal - m.maxHp;
                    pen = wasted;

                    if ((m.taunt || this.UsefulNeedKeepDatabase.ContainsKey(m.name)) && wasted <= 2 && m.Hp < m.maxHp) pen -= 5; // bonus for healing a taunt/useful minion

                    if (m.Hp + heal <= m.maxHp) pen = -1;
                }

                if (!target.isHero && !target.own)
                {
                    m = target;
                    if (m.Hp == m.maxHp) return 500;
                    // no penality if we heal enrage enemy
                    if (enrageDatabase.ContainsKey(m.name))
                    {
                        return pen;
                    }
                    // no penality if we have heal-trigger :D
                    int i = 0;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.name == CardIds.Collectible.Priest.NorthshireCleric) i++;
                        if (mnn.name == CardIds.Collectible.Neutral.Lightwarden) i++;
                    }
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.name == CardIds.Collectible.Priest.NorthshireCleric) i--;
                        if (mnn.name == CardIds.Collectible.Neutral.Lightwarden) i--;
                    }
                    if (i >= 1) return pen;

                    // no pen if we have slam

                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card == CardIds.Collectible.Warrior.Slam && m.Hp < 2) return pen;
                        if (hc.card == CardIds.Collectible.Rogue.Backstab) return pen;
                    }

                    pen = 500;
                }


            }

            return pen;
        }

        private int getCardDrawPenality(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            // penality if carddraw is late or you have enough cards
            int pen = 0;
            Chireiden.Silverfish.SimCard name = card;
            if (!cardDrawBattleCryDatabase.ContainsKey(name)) return 0;
            if (name == CardIds.Collectible.Druid.Wrath && card.CardId != CardIds.NonCollectible.Druid.Wrath_NaturesWrath) return 0;
            if (name == CardIds.Collectible.Druid.Nourish && card.CardId != CardIds.NonCollectible.Druid.Nourish_Enrich) return 0;
            if (name == CardIds.Collectible.Hunter.Tracking) return -1;

            int carddraw = cardDrawBattleCryDatabase[name];
            if (carddraw == 0)
            {
                switch(name.CardId)
                {
                    case CardIds.Collectible.Neutral.HarrisonJones:
                        carddraw = p.enemyWeapon.Durability;
                        if (carddraw == 0 && (p.enemyHeroStartClass != CardClass.DRUID && p.enemyHeroStartClass != CardClass.MAGE && p.enemyHeroStartClass != CardClass.WARLOCK && p.enemyHeroStartClass != CardClass.PRIEST)) return 5;
                        break;

                    case CardIds.Collectible.Paladin.DivineFavor:
                        carddraw = p.enemyAnzCards - (p.owncards.Count);
                        if (carddraw <= 0) return 500;
                        break;

                    case CardIds.Collectible.Warrior.BattleRage:
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.wounded) carddraw++;
                        }
                        if (carddraw == 0)
                        {
                            if(p.ownMinions.Count == 0 && p.mana > 6)
                            {
                                foreach (Handmanager.Handcard hc in p.owncards)
                                {
                                    if (hc.card.Type == CardType.MOB) return 500;
                                }
                                if (p.owncards.Count < 2) return -10;
                                else if (p.owncards.Count < 4) return -2;
                                else if (p.owncards.Count < 6) return 0;
                                else if (p.owncards.Count < 9) return 3;
                            }
                            return 500;
                        }
                        break;

                    case CardIds.Collectible.Warrior.Slam:
                        if (target != null && target.Hp >= 3) carddraw = 1;
                        if (carddraw == 0) return 4;
                        break;

                    case CardIds.Collectible.Warlock.MortalCoil:
                        if (target != null && target.Hp == 1) carddraw = 1;
                        if (carddraw == 0) return 15;
                        break;

                    case CardIds.Collectible.Hunter.QuickShot:
                        carddraw = (p.owncards.Count > 0) ? 0 : 1;
                        if (carddraw == 0) return 4;
                        break;

                    case CardIds.Collectible.Priest.Thoughtsteal:
                        carddraw = Math.Min(2, p.enemyDeckSize);
                        if (carddraw == 2) break;
                        if (carddraw == 1) pen +=4;
                        else
                        {
                            foreach (Minion mnn in p.ownMinions)
                            {
                                if (spellDependentDatabase.ContainsKey(mnn.name)) return 0;
                            }
                            return 500;
                        }
                        break;

                    case CardIds.Collectible.Priest.MindVision:
                        carddraw = Math.Min(1, p.enemyAnzCards);
                        if (carddraw != 1)
                        {
                            int scales = 0;
                            foreach (Minion mnn in p.ownMinions)
                            {
                                if (this.spellDependentDatabase.ContainsKey(mnn.name))
                                    if(mnn.name == CardIds.Collectible.Neutral.LorewalkerCho) pen += 20; //if(spellDependentDatabase[mnn.name] == 0);
                                    else scales--;
                            }
                            if (scales == 0) return 500;
                            foreach (Minion mnn in p.enemyMinions)
                            {
                                if (this.spellDependentDatabase.ContainsKey(mnn.name) && this.spellDependentDatabase[name] <= 0) scales++;
                            }
                            return (12 + scales * 4 + pen);
                        }
                        break;

                    case CardIds.Collectible.Mage.EchoOfMedivh:
                        if (p.ownMinions.Count == 0) return 500;
                        return 0;
                        break;

                    case CardIds.Collectible.Neutral.TinkertownTechnician:
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if ((Race)mnn.handcard.card.Race != Race.MECHANICAL) pen += 4;
                        }
                        break;

                    case CardIds.Collectible.Druid.MarkOfYshaarj:
                        if ((Race)target.handcard.card.Race == Race.PET) carddraw = 1;
                        break;

                    case CardIds.Collectible.Neutral.ServantOfKalimos:
                        if (p.anzOwnElementalsLastTurn > 0) carddraw = 1;
                        break;

                    default:
                        break;
                }
            }

            if (name == CardIds.Collectible.Shaman.FarSight || name == CardIds.Collectible.Hunter.CallPet) pen -= 10;

            if (name == CardIds.NonCollectible.Warlock.LifeTap)
            {
                if (p.isLethalCheck) return 500; //RR no benefit for lethal check
                int minmana = 10;
                bool cardOnLimit = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.manacost <= minmana)
                    {
                        minmana = hc.manacost;
                    }
                    //if (hc.getManaCost(p) == p.ownMaxMana)
                    int manac = hc.getManaCost(p);
                    if (manac > p.ownMaxMana - 2 && manac <= p.ownMaxMana)
                    {
                        cardOnLimit = true;
                    }

                }

                if (ai.botBase is BehaviorRush && p.ownMaxMana <= 3 && cardOnLimit) return 6; //RR penalization for drawing the 3 first turns if we have a card in hand that we won't be able to play in Rush

                if (p.owncards.Count + p.cardsPlayedThisTurn <= 5 && minmana > p.ownMaxMana) return 0;
                if (p.owncards.Count + p.cardsPlayedThisTurn > 5)
                {
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.name == CardIds.Collectible.Neutral.Doomsayer) return 2;
                    }
                    return 25;
                }

                int prevCardDraw = 0;
                if (p.optionsPlayedThisTurn > 0)
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.playedThisTurn && cardDrawBattleCryDatabase.ContainsKey(m.name)) prevCardDraw++;
                    }
                    Chireiden.Silverfish.SimCard c;
                    foreach (GraveYardItem ge in Probabilitymaker.Instance.turngraveyardAll)
                    {
                        c = ge.cardid;
                        if (cardDrawDeathrattleDatabase.ContainsKey(c)) prevCardDraw++;
                        else if (c.Type == CardType.SPELL && cardDrawBattleCryDatabase.ContainsKey(c)) prevCardDraw++;
                    }
                }
                return Math.Max(-carddraw + 2 * (p.optionsPlayedThisTurn - prevCardDraw) + p.ownMaxMana - p.mana, 0);
            }

            if (p.owncards.Count + carddraw > 10) return 15 * (p.owncards.Count + carddraw - 10);
            if (p.ownMaxMana > 3 && p.owncards.Count + p.cardsPlayedThisTurn > 7) return (5 * carddraw) + 1;

            int tmp = 2 * p.optionsPlayedThisTurn + p.ownMaxMana - p.mana;
            int diff = 0;
            switch (card.CardId)
            {
                case CardIds.Collectible.Paladin.SolemnVigil:
                    tmp -= 2 * p.diedMinions.Count;
                    foreach (Action a in p.playactions)
                    {
                        if (a.actionType == actionEnum.playcard && this.cardDrawBattleCryDatabase.ContainsKey(a.card.card.CardId)) tmp -= 2;
                    }
                    break;
                case CardIds.Collectible.Mage.EchoOfMedivh:
                    diff = p.ownMinions.Count - prozis.ownMinions.Count;
                    if (diff > 0) tmp -= 2 * diff;
                    break;
                case CardIds.Collectible.Warrior.BloodWarriors:
                    foreach (Minion m in p.ownMinions) if (m.wounded) diff++;
                    foreach (Minion m in prozis.ownMinions) if (m.wounded) diff--;
                    if (diff > 0) tmp -= 2 * diff;
                    break;
            }
            if (tmp < 0) tmp = 0;
            pen += -carddraw + tmp;
            if (p.ownMinions.Count < 3) pen += carddraw;
            if (p.playactions.Count > 0) pen += p.playactions.Count; // draw first!
            else if (p.owncards.Count < 4) pen -= (4 - p.owncards.Count) * 4;
            if (p.ownMinionsInDeckCost0) pen -= carddraw * 5;
            return pen;
        }

        private int getCardDrawofEffectMinions(Chireiden.Silverfish.SimCard card, Playfield p)
        {
            int pen = 0;
            int carddraw = 0;
            if (card.Type == CardType.SPELL)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardIds.Collectible.Neutral.GadgetzanAuctioneer) carddraw++;
                }
            }

            if (card.Type == CardType.MOB && (Race)card.Race == Race.PET)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardIds.Collectible.Hunter.StarvingBuzzard) carddraw++;
                }
            }

            if (carddraw == 0) return 0;
            if (p.owncards.Count >= 5) return 0;


            if (card.Cost > 0) pen = -carddraw + p.ownMaxMana - p.mana + p.optionsPlayedThisTurn;

            return pen;
        }

        public int getCardDrawDeathrattlePenality(Chireiden.Silverfish.SimCard name, Playfield p)
        {
            // penality if carddraw is late or you have enough cards
            if (!cardDrawDeathrattleDatabase.ContainsKey(name)) return 0;

            int carddraw = cardDrawDeathrattleDatabase[name];
            if (p.owncards.Count + carddraw > 10) return 15 * (p.owncards.Count + carddraw - 10);
            return 3 * p.optionsPlayedThisTurn;
        }

        private int getRandomPenaltiy(Chireiden.Silverfish.SimCard card, Playfield p, Minion target)
        {
            if (p.turnCounter >= 1)
            {
                return 0;
            }

            if (!this.randomEffects.ContainsKey(card.CardId) && !(this.cardDrawBattleCryDatabase.ContainsKey(card.CardId) && card.Type != CardType.SPELL))
            {
                return 0;
            }

            if (card.CardId == CardIds.Collectible.Warrior.Brawl)
            {
                return 0;
            }

            if ((card.CardId == CardIds.Collectible.Warrior.Cleave || card.CardId == CardIds.Collectible.Hunter.MultiShot) && p.enemyMinions.Count == 2)
            {
                return 0;
            }

            if ((card.CardId == CardIds.Collectible.Hunter.DeadlyShot) && p.enemyMinions.Count == 1)
            {
                return 0;
            }

            if ((card.CardId == CardIds.Collectible.Mage.ArcaneMissiles || card.CardId == CardIds.Collectible.Paladin.AvengingWrath)
                && p.enemyMinions.Count == 0)
            {
                return 0;
            }

            int cards = 0;
            cards = this.randomEffects.ContainsKey(card.CardId) ? this.randomEffects[card.CardId] : this.cardDrawBattleCryDatabase[card.CardId];

            bool first = true;
            bool hasgadget = false;
            bool hasstarving = false;
            bool hasknife = false;
            bool hasFlamewaker = false;
            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.name == CardIds.Collectible.Neutral.GadgetzanAuctioneer)
                {
                    hasgadget = true;
                }

                if (mnn.name == CardIds.Collectible.Hunter.StarvingBuzzard)
                {
                    hasstarving = true;
                }

                if (mnn.name == CardIds.Collectible.Neutral.KnifeJuggler)
                {
                    hasknife = true;
                }

                if (mnn.name == CardIds.Collectible.Mage.Flamewaker)
                {
                    hasFlamewaker = true;
                }
            }

            foreach (Action a in p.playactions)
            {
                if (a.actionType == actionEnum.attackWithHero)
                {
                    first = false;
                    continue;
                }

                if (a.actionType == actionEnum.useHeroPower
                    && (p.ownHeroAblility.card.CardId == CardIds.NonCollectible.Shaman.TotemicCall || p.ownHeroAblility.card.CardId == CardIds.NonCollectible.Warlock.LifeTap || p.ownHeroAblility.card.CardId == Chireiden.Silverfish.SimCard.soultap))
                {
                    first = false;
                    continue;
                }

                if (a.actionType == actionEnum.attackWithMinion)
                {
                    first = false;
                    continue;
                }

                if (a.actionType == actionEnum.playcard)
                {
                    if (card.CardId == CardIds.Collectible.Neutral.KnifeJuggler && card.Type == CardType.MOB)
                    {
                        continue;
                    }

                    if (this.cardDrawBattleCryDatabase.ContainsKey(a.card.card.CardId))
                    {
                        continue;
                    }

                    if (this.lethalHelpers.ContainsKey(a.card.card.CardId))
                    {
                        continue;
                    }

                    if (hasgadget && card.Type == CardType.SPELL)
                    {
                        continue;
                    }

                    if (hasFlamewaker && card.Type == CardType.SPELL)
                    {
                        continue;
                    }

                    if (hasstarving && (Race)card.Race == Race.PET)
                    {
                        continue;
                    }

                    if (hasknife && card.Type == CardType.MOB)
                    {
                        continue;
                    }

                    first = false;
                }
            }

            if (first == false)
            {
                return cards + p.playactions.Count + 1;
            }

            return 0;
        }


        private int getBuffHandPenalityPlay(Chireiden.Silverfish.SimCard name, Playfield p)
        {
            if (!buffHandDatabase.ContainsKey(name)) return 0;

            Handmanager.Handcard hc;
            int anz = 0;
            switch (name.CardId)
            {
                case CardIds.Collectible.Hunter.TroggBeastrager:
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.CARDRACE, Race.PET);
                    if (hc != null) return -5;
                    break;
                case CardIds.Collectible.Neutral.GrimestreetSmuggler:
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.Mob);
                    if (hc != null) return -5;
                    break;
                case CardIds.Collectible.Neutral.DonHancho:
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.Mob);
                    if (hc != null) return -20;
                    break;
                case CardIds.Collectible.Neutral.DeathaxePunisher:
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.LIFESTEAL);
                    if (hc != null) return -10;
                    break;
                case CardIds.Collectible.Paladin.GrimscaleChum:
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.CARDRACE, Race.MURLOC);
                    if (hc == null) return -5;
                    break;
                case CardIds.Collectible.Warrior.GrimestreetPawnbroker:
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.Weapon);
                    if (hc == null) return -5;
                    break;
                case CardIds.Collectible.Paladin.GrimestreetOutfitter:
                    foreach (Handmanager.Handcard hc1 in p.owncards)
                    {
                        if (hc1.card.Type == CardType.MOB) anz++;
                    }
                    anz--;
                    if (anz > 0) return -1 * anz * 4;
                    else return 5;
                    break;
                case CardIds.Collectible.Shaman.TheMistcaller:
                    foreach (Handmanager.Handcard hc1 in p.owncards)
                    {
                        if (hc1.card.Type == CardType.MOB) anz++;
                    }
                    anz--;
                    anz += p.ownDeckSize / 4;
                    return -1 * anz * 4;
                    break;
                case CardIds.Collectible.Warrior.HobartGrapplehammer:
                    foreach (Handmanager.Handcard hc2 in p.owncards)
                    {
                        if (hc2.card.Type == CardType.WEAPON) anz++;
                    }
                    if (anz == 0) return 2;
                    else return -1 * anz * 2;
                    break;
                case CardIds.Collectible.Hunter.SmugglersCrate:
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.CARDRACE, Race.PET);
                    if (hc != null) return -10;
                    else return 10;
                    break;
                case CardIds.Collectible.Warrior.StolenGoods:
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GameTag.TAUNT);
                    if (hc != null) return -15;
                    else return 10;
                    break;
                case CardIds.Collectible.Paladin.SmugglersRun:
                    foreach (Handmanager.Handcard hc3 in p.owncards)
                    {
                        if (hc3.card.Type == CardType.MOB) anz++;
                    }
                    anz--;
                    if (anz > 0) return -1 * anz * 4;
                    else return 5;
                    break;
            }
            return 0;
        }

        private int getCardDiscardPenality(Chireiden.Silverfish.SimCard name, Playfield p)
        {
            if (p.owncards.Count <= 1) return 0;
            if (p.ownMaxMana <= 3) return 0;
            int pen = 0;
            if (this.cardDiscardDatabase.ContainsKey(name))
            {
                int newmana = p.mana - cardDiscardDatabase[name];
                bool canplaythisturn = false;
                bool haveChargeInHand = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (this.cardDiscardDatabase.ContainsKey(hc.card.CardId)) continue;
                    switch (hc.card.CardId)
                    {
                        case CardIds.Collectible.Warlock.SilverwareGolem: pen -= 12; continue;
                        case CardIds.Collectible.Warlock.FistOfJaraxxus: pen -= 6; continue;
                    }
                    if (hc.card.getManaCost(p, hc.manacost) <= newmana)
                    {
                        canplaythisturn = true;
                    }
                    if (hc.card.Charge && hc.card.getManaCost(p, hc.manacost) < p.ownMaxMana + 1) haveChargeInHand = true;
                }
                if (canplaythisturn) pen += 18;
                if (haveChargeInHand) pen += 10;
            }

            return pen;
        }

        private int getDestroyOwnPenality(Chireiden.Silverfish.SimCard name, Minion target, Playfield p)
        {
            if (!this.destroyOwnDatabase.ContainsKey(name)) return 0;

            switch (name)
            {
                case CardIds.Collectible.Warlock.SanguineReveler: goto case CardIds.Collectible.Warlock.Shadowflame;
                case CardIds.Collectible.Warlock.RavenousPterrordax: goto case CardIds.Collectible.Warlock.Shadowflame;
                case CardIds.Collectible.Warlock.Shadowflame:
                    if (target == null || !target.Ready) return 0;
                    else return 1;
                case CardIds.Collectible.Neutral.Deathwing:
                    if (p.mobsplayedThisTurn >= 1) return 500;
                    break;
                case CardIds.Collectible.Warlock.TwistingNether: goto case CardIds.Collectible.Warrior.Brawl;
                case CardIds.Collectible.Warlock.Doompact: goto case CardIds.Collectible.Warrior.Brawl;
                case CardIds.Collectible.Warrior.Brawl:
                    if (p.mobsplayedThisTurn >= 1) return 500;

                    if (name == CardIds.Collectible.Warrior.Brawl && p.ownMinions.Count + p.enemyMinions.Count <= 1) return 500;
                    int highminion = 0;
                    int veryhighminion = 0;
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.Angr >= 5 || m.Hp >= 5) highminion++;
                        if (m.Angr >= 8 || m.Hp >= 8) veryhighminion++;
                    }

                    if (highminion >= 2 || veryhighminion >= 1)
                    {
                        return 0;
                    }

                    if (p.enemyMinions.Count <= 2 || p.enemyMinions.Count + 2 <= p.ownMinions.Count || p.ownMinions.Count >= 3)
                    {
                        return 30;
                    }
                    break;
            }

            if (target == null) return 0;
            if (target.own && !target.isHero)
            {
                // dont destroy owns (except mins with deathrattle effects or + effects)
                if (p.isLethalCheck)
                {
                    if (target.Ready) return 500;
                    switch (target.handcard.card.CardId)
                    {
                        case CardIds.Collectible.Neutral.LeperGnome: return -2;
                        case CardIds.Collectible.Neutral.BackstreetLeper: return -2;
                        case CardIds.NonCollectible.Neutral.Firesworn: return -2;
                        case CardIds.Collectible.Neutral.ZombieChow:
                            if (p.anzOwnAuchenaiSoulpriest > 0) return -5;
                            else return 500;
                        case CardIds.Collectible.Neutral.CorruptedHealbot:
                            if (p.anzOwnAuchenaiSoulpriest > 0) return -8;
                            else return 500;
                        default:
                            int up = 0;
                            foreach (Minion m in p.ownMinions)
                            {
                                switch (m.handcard.card.CardId)
                                {
                                    case CardIds.Collectible.Mage.ManaWyrm: goto case CardIds.Collectible.Neutral.Lightwarden;
                                    case CardIds.Collectible.Mage.Flamewaker: goto case CardIds.Collectible.Neutral.Lightwarden;
                                    case CardIds.Collectible.Mage.ArchmageAntonidas: goto case CardIds.Collectible.Neutral.Lightwarden;
                                    case CardIds.Collectible.Neutral.GadgetzanAuctioneer: goto case CardIds.Collectible.Neutral.Lightwarden;
                                    case CardIds.Collectible.Neutral.ManaAddict: goto case CardIds.Collectible.Neutral.Lightwarden;
                                    case CardIds.Collectible.Neutral.RedManaWyrm: goto case CardIds.Collectible.Neutral.Lightwarden;
                                    case CardIds.Collectible.Neutral.SummoningStone: goto case CardIds.Collectible.Neutral.Lightwarden;
                                    case CardIds.Collectible.Shaman.WickedWitchdoctor: goto case CardIds.Collectible.Neutral.Lightwarden;
                                    case CardIds.Collectible.Priest.HolyChampion: goto case CardIds.Collectible.Neutral.Lightwarden;
                                    case CardIds.Collectible.Neutral.Lightwarden:
                                        if (m.Ready)
                                        {
                                            up++;
                                            if (target.entitiyID == m.entitiyID) up--;
                                        }
                                        continue;
                                }
                            }
                            if (up > 0) return 0;
                            if (target.handcard.card.deathrattle) return 10;
                            else return 500;
                    }
                }
                else
                {
                    switch (name)
                    {
                        case CardIds.Collectible.Warlock.UnwillingSacrifice:
                            if (p.enemyMinions.Count > 0)
                            {
                                if (target.handcard.card.deathrattle) return 1;
                                else return 3;
                            }
                            break;
                    }


                }
                return 500;
            }

            return 0;
        }

        private int getDestroyPenality(Chireiden.Silverfish.SimCard name, Minion target, Playfield p)
        {
            if (!this.destroyDatabase.ContainsKey(name) || p.isLethalCheck) return 0;
            int pen = 0;
            if (target == null) return 0;
            if (target.own && !target.isHero)
            {
                Minion m = target;
                if (!m.handcard.card.deathrattle)
                {
                    pen = 500;
                }
            }
            if (!target.own && !target.isHero)
            {
                // dont destroy owns ;_; (except mins with deathrattle effects)

                Minion m = target;

                if (m.allreadyAttacked && name != CardIds.Collectible.Warrior.Execute)
                {
                    return 50;
                }

                if (name == CardIds.Collectible.Priest.ShadowWordPain)
                {
                    if (this.specialMinions.ContainsKey(m.name) || m.Angr == 3 || m.Hp >= 4)
                    {
                        return 0;
                    }

                    if (m.Angr == 2) return 5;

                    return 10;
                }

                if (m.Angr >= 4 || m.Hp >= 5)
                {
                    pen = 0; // so we dont destroy cheap ones :D
                }
                else
                {
                    pen = 30;
                }

                if (name == CardIds.Collectible.Priest.MindControl && (m.name == CardIds.Collectible.Neutral.DireWolfAlpha || m.name == CardIds.Collectible.Neutral.RaidLeader || m.name == CardIds.Collectible.Shaman.FlametongueTotem) && p.enemyMinions.Count == 1)
                {
                    pen = 50;
                }

                if (m.name == CardIds.Collectible.Neutral.Doomsayer)
                {
                    pen = 5;
                }

            }

            return pen;
        }

        private int getSpecialCardComboPenalitys(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            bool lethal = p.isLethalCheck;
            Chireiden.Silverfish.SimCard name = card.CardId;

            if (lethal && card.Type == CardType.MOB)
            {
                if (this.lethalHelpers.ContainsKey(name))
                {
                    return 0;
                }

                if (this.buffingMinionsDatabase.ContainsKey(name))
                {
                    switch (this.buffingMinionsDatabase[name])
                    {
                        case 0:
                            if (p.ownMinions.Count > 0) return 0;
                                break;
                        case 1:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((Race)mm.handcard.card.Race == Race.PET && mm.Ready) return 0;
                            }
                            break;
                        case 2:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((Race)mm.handcard.card.Race == Race.MECHANICAL && mm.Ready) return 0;
                            }
                            break;
                        case 3:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((Race)mm.handcard.card.Race == Race.MURLOC && mm.Ready) return 0;
                            }
                            break;
                        case 4:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((Race)mm.handcard.card.Race == Race.PIRATE && mm.Ready) return 0;
                            }
                            break;
                        case 5:
                            if (p.ownHero.Ready && p.ownHero.Angr >= 1) return 0;
                            break;
                        case 6:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.name == Chireiden.Silverfish.SimCard.silverhandrecruit && mm.Ready) return 0;
                            }
                            break;
                        case 7:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.charge > 0) return 0;
                            }
                            break;
                        case 8:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((Race)mm.handcard.card.Race == Race.DEMON && mm.Ready) return 0;
                            }
                            break;
                        case 9:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((Race)mm.handcard.card.Race == Race.TOTEM && mm.Ready) return 0;
                            }
                            break;
                        case 10:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.name == CardIds.Collectible.Neutral.Cthun && mm.Ready) return 0;
                            }
                            break;
                    }
                    return 500;
                }
                else
                {
                    if ((name == CardIds.Collectible.Neutral.RendBlackhand && target != null) && !target.own)
                    {
                        if ((target.taunt && target.handcard.card.rarity == 5) || target.handcard.card.CardId == CardIds.Collectible.Warlock.Malganis)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards)
                            {
                                if ((Race)hc.card.Race == Race.DRAGON) return 0;
                            }
                        }
                        return 500;
                    }

                    if (name == CardIds.Collectible.Neutral.TheBlackKnight)
                    {
                        foreach (Minion mm in p.enemyMinions)
                        {
                            if (mm.taunt) return 0;
                        }
                        return 500;
                    }
                    else
                    {
                        if ((this.HealTargetDatabase.ContainsKey(name) || this.HealHeroDatabase.ContainsKey(name) || this.HealAllDatabase.ContainsKey(name)))
                        {
                            int beasts = 0;
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.Ready && (mm.handcard.card.CardId == CardIds.Collectible.Neutral.Lightwarden || mm.handcard.card.CardId == CardIds.Collectible.Priest.HolyChampion)) beasts++;
                            }
                            if (beasts == 0) return 500;
                        }
                        else
                        {
                            if (!(name == CardIds.Collectible.Neutral.Nightblade || card.Charge || this.silenceDatabase.ContainsKey(name) || this.DamageTargetDatabase.ContainsKey(name) || ((Race)card.Race == Race.PET && p.ownMinions.Find(x => x.name == CardIds.Collectible.Hunter.TundraRhino) != null) || p.owncards.Find(x => x.card.CardId == CardIds.Collectible.Warrior.Charge) != null))
                            {
                                return 500;
                            }
                        }
                        return 0;
                    }
                }
            }

            //lethal end########################################################

            int pen = 0;
            if (dragonDependentDatabase.ContainsKey(name))
            {
                pen += 10;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.Race == 24)
                    {
                        pen -= 10;
                        break;
                    }
                }
            }

            if (elementalLTDependentDatabase.ContainsKey(name) && p.anzOwnElementalsLastTurn == 0) pen += 10;

            int targets = 0;
            switch(name)
            {
                case CardIds.Collectible.Warrior.HobartGrapplehammer: return -5;
                case CardIds.Collectible.Neutral.BloodsailRaider: if (p.ownWeapon.Durability == 0) return 5; return 0;
                case CardIds.Collectible.Neutral.CaptainGreenskin: if (p.ownWeapon.Durability == 0) return 10; return 0;
                case CardIds.Collectible.Rogue.LuckydoBuccaneer: if (!(p.ownWeapon.Durability > 0 && p.ownWeapon.Angr > 2)) return 10; return 0;
                case CardIds.Collectible.Neutral.NagaCorsair: if (p.ownWeapon.Durability == 0) return 5; return 0;
                case CardIds.Collectible.Rogue.GoblinAutoBarber: if (p.ownWeapon.Durability == 0) return 5; return 0;
                case CardIds.Collectible.Neutral.DreadCorsair: if (p.ownWeapon.Durability == 0) return 5; return 0;
                case CardIds.Collectible.Warrior.GrimestreetPawnbroker:
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.Type == CardType.WEAPON) return 0;
                    return 5;
                case CardIds.Collectible.Warrior.BloodsailCultist: ;
                    if (p.ownWeapon.Durability > 0) foreach (Minion m in p.ownMinions) if ((Race)m.handcard.card.Race == Race.PIRATE) return 0;
                    return 8;
                case CardIds.Collectible.Neutral.RavasaurRunt:
                    if (p.ownMinions.Count < 2) return 5;
                    break;
                case CardIds.Collectible.Neutral.NestingRoc:
                    if (p.ownMinions.Count < 2) return 5;
                    break;
                case CardIds.Collectible.Neutral.GentleMegasaur:
                    targets = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((Race)m.handcard.card.Race == Race.MURLOC) targets++;
                    }
                    return 20 - targets * 5;
                case CardIds.Collectible.Neutral.PrimalfinLookout:
                    targets = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((Race)m.handcard.card.Race == Race.MURLOC) targets++;
                    }
                    return 20 - targets * 5;
                case CardIds.Collectible.Shaman.SpiritEcho:
                    if (p.ownQuest.Id == CardIds.Collectible.Shaman.UniteTheMurlocs)
                    {
                        targets = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((Race)m.handcard.card.Race == Race.MURLOC) targets++;
                        }
                        if (targets > 1) return -7;
                        return 10;
                    }
                    else if (p.ownMinions.Count < 2) return 7;
                    return 0;
                case CardIds.Collectible.Druid.EvolvingSpores:
                    if (p.ownMinions.Count < 3) return 15 - p.ownMinions.Count * 5;
                    return 0;
                case CardIds.Collectible.Druid.LivingMana:
                    int free = 7 - p.ownMinions.Count;
                    switch (free)
                    {
                        case 7: return -22 * free;
                        case 6: return -21 * free;
                        case 5: return -20 * free;
                        case 4: if (p.ownMinions.Count < p.enemyMinions.Count) return -20 * free; else return -19 * free;
                        case 3: if (p.ownMinions.Count + 2 < p.enemyMinions.Count) return -20 * free; else return 0;
                        case 2: return 0;
                        case 1: return 5;
                        default:
                            return 500;
                    }
                    break;
                case CardIds.Collectible.Neutral.EliseTheTrailblazer: return -7;
                case CardIds.Collectible.Hunter.CracklingRazormaw:
                    if (target != null) return 0;
                    return 5;
                case CardIds.Collectible.Hunter.Dinomancy: return -7;
                case CardIds.Collectible.Warrior.MoltenBlade: return -10;
                case CardIds.Collectible.Neutral.GluttonousOoze: goto case CardIds.Collectible.Neutral.AcidicSwampOoze;
                case CardIds.Collectible.Neutral.AcidicSwampOoze:
                    if (p.enemyWeapon.Angr > 0) return 0;
                    if (p.enemyHeroName == HeroEnum.shaman || p.enemyHeroName == HeroEnum.warrior || p.enemyHeroName == HeroEnum.thief || p.enemyHeroName == HeroEnum.pala) return 10;
                    if (p.enemyHeroName == HeroEnum.hunter) return 6;
                    return 0;
                case CardIds.Collectible.Warlock.DarkshireCouncilman:
                    if (p.enemyMinions.Count == 0)
                    {
                        List<Handmanager.Handcard> temp = new List<Handmanager.Handcard>(p.owncards);
                        temp.Sort((a, b) => a.card.Cost.CompareTo(b.card.Cost));
                        int cnum = 0;
                        int pcards = 0;
                        int nextTurnMana = p.ownMaxMana + 1;
                        foreach (Handmanager.Handcard hc in temp)
                        {
                            if (hc.card.CardId == name && cnum == 0)
                            {
                                cnum++;
                                continue;
                            }
                            nextTurnMana -= hc.card.Cost;
                            if (nextTurnMana < 0) break;
                            else pcards++;
                        }
                        return -3 * pcards;
                    }
                    break;
                case CardIds.Collectible.Warrior.DeadMansHand:
                    if (p.owncards.Count > 2) return -5 * p.owncards.Count;
                    break;
                case CardIds.Collectible.Warrior.BringItOn:
                    return 3 * p.enemyAnzCards * (11 - p.enemyMaxMana);
                case CardIds.Collectible.Druid.StrongshellScavenger:
                    int tmp = 0;
                    foreach (Minion m in p.ownMinions) if (m.taunt) tmp++;
                    return 12 - tmp * 2;

            }

            if (name == CardIds.Collectible.Mage.UnstablePortal && p.owncards.Count <= 9) return -15;
            if (name == CardIds.Collectible.Druid.LunarVisions && p.owncards.Count <= 8) return -5;

            if (name == CardIds.Collectible.Neutral.AzureDrake)
            {
                pen = 0;
                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.Angr > 3 && p.anzOwnTaunt == 0)
                    {
                        pen = 5;
                        break;
                    }
                }
                if (p.ownHeroStartClass == CardClass.DRUID)
                {
                    if (p.owncards.Count > 3)
                    {
                        p.owncarddraw--;
                        pen += 5;
                    }
                    bool menageriewarden = false;
                    bool pet = false;
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.CardId == CardIds.Collectible.Druid.MenagerieWarden) { menageriewarden = true; continue; }
                        if ((Race)hc.card.Race == Race.PET && hc.card.Cost <= p.ownMaxMana) pet = true;
                    }
                    if (menageriewarden && pet) pen += 23;
                }
                return pen;
            }

            if (name == CardIds.Collectible.Shaman.ManaTideTotem)
            {
                if (p.owncards.Count > 2)
                {
                    int eAngr = p.enemyWeapon.Angr;
                    foreach (Minion em in p.enemyMinions)
                    {
                        if (!em.frozen) eAngr += em.Angr;
                    }
                    if (p.anzOwnTaunt > 0)
                    {
                        foreach (Minion om in p.ownMinions)
                        {
                            if (om.taunt) eAngr -= om.Hp;
                        }
                    }
                    if (eAngr >= 3) return 5;
                }
                return 0;
            }

            if (name == CardIds.Collectible.Druid.MenagerieWarden)
            {
                if (target != null && (Race)target.handcard.card.Race == Race.PET) return 0;
                else return 10;
            }

            if (name == CardIds.Collectible.Mage.Duplicate)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.CardId == CardIds.Collectible.Mage.MirrorEntity)
                    {
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.handcard.card.Attack >= 3 && this.UsefulNeedKeepDatabase.ContainsKey(mnn.name)) return 0;
                        }
                        return 16;
                    }
                }
            }

            if ((name == CardIds.NonCollectible.Warlock.LifeTap || name == Chireiden.Silverfish.SimCard.soultap) && p.owncards.Count <= 9)
            {
                 foreach (Minion mnn in p.ownMinions)
                 {
                     if (mnn.name == CardIds.Collectible.Warlock.WilfredFizzlebang && !mnn.silenced) return -20;
                 }
            }

            if (name == CardIds.Collectible.Warlock.ForbiddenRitual)
            {
                if (p.ownMinions.Count == 7 || p.mana == 0) return 500;
                return 7;
            }

            if (name == CardIds.Collectible.Paladin.CompetitiveSpirit)
            {
                if (p.ownMinions.Count < 1) return 500;
                if (p.ownMinions.Count > 2) return 0;
                return (15 - 5 * p.ownMinions.Count);
            }

            if (name == CardIds.Collectible.Neutral.ShifterZerus) return 500;

            if (card.CardId == CardIds.NonCollectible.Rogue.DaggerMastery)
            {
                if (p.ownWeapon.Angr >= 2 || p.ownWeapon.Durability >= 2) return 5;
            }

            if (card.CardId == CardIds.Collectible.Warrior.Upgrade)
            {
                if (p.ownWeapon.Durability == 0)
                {
                    if (weaponInHandAttackNextTurn(p) > 0) return 10;
                    return 0;
                }
            }

            if (card.CardId == CardIds.Collectible.Warlock.MalchezaarsImp && p.owncards.Count > 2) return 5;

            if (card.CardId == CardIds.Collectible.Neutral.BaronRivendare)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardIds.Collectible.Neutral.Deathlord || mnn.name == CardIds.Collectible.Neutral.ZombieChow || mnn.name == CardIds.Collectible.Neutral.DancingSwords) return 30;
                }
            }

            //rule for coin on early game
            if (p.ownMaxMana < 3 && card.CardId == CardIds.NonCollectible.Neutral.TheCoin)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.manacost <= p.ownMaxMana && hc.card.Type == CardType.MOB) return 5;
                }

            }

            //destroySecretPenality
            pen = 0;
            switch (card.CardId)
            {
                case CardIds.Collectible.Hunter.Flare:
                    foreach (Minion mn in p.ownMinions) if (mn.stealth) pen++;
                    foreach (Minion mn in p.enemyMinions) if (mn.stealth) pen--;
                    if (p.enemySecretCount > 0)
                    {
                        bool canPlayMinion = false;
                        bool canPlaySpell = false;
                        foreach(Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.CardId == CardIds.Collectible.Hunter.Flare) continue;
                            if (hc.card.Cost <= p.mana - 2)
                            {
                                if (!canPlayMinion && hc.card.Type == CardType.MOB)
                                {

                                    int tmp = p.getSecretTriggersByType(0, true, false, target);
                                    if (tmp > 0) pen -= tmp * 50;
                                    canPlayMinion = true;
                                    continue;
                                }
                                if (!canPlaySpell && hc.card.Type == CardType.SPELL)
                                {
                                    int tmp = p.getSecretTriggersByType(1, true, false, target);
                                    if (tmp > 0) pen -= tmp * 50;
                                    canPlaySpell = true;
                                    continue;
                                }
                            }
                        }
                        pen -= p.enemySecretCount * 5;
                        if (p.playactions.Count == 0) pen -= 5;
                    }
                    else
                    {
                        switch (p.enemyHeroStartClass)
                        {
                            case CardClass.MAGE: pen += 5; break;
                            case CardClass.PALADIN: pen += 5; break;
                            case CardClass.HUNTER: pen += 5; break;
                        }
                    }
                    break;
                case CardIds.Collectible.Neutral.EaterOfSecrets:
                    if (p.enemySecretCount > 0)
                    {
                        pen -= p.enemySecretCount * 50;
                        if (p.playactions.Count == 0) pen -= 5;
                    }
                    else
                    {
                        switch (p.enemyHeroStartClass)
                        {
                            case CardClass.MAGE: pen += 5; break;
                            case CardClass.PALADIN: pen += 5; break;
                            case CardClass.HUNTER: pen += 5; break;
                        }
                    }
                    break;
                case CardIds.Collectible.Neutral.KezanMystic:
                    if (p.enemySecretCount == 1 && p.playactions.Count == 0) pen -= 50;
                    break;
                case Chireiden.Silverfish.SimCard.水晶学:
                    if (p.owncards.Count <= 8) return -50;
                    else return 50;
                    break;
                //风驰电掣
                //判断手牌中随从数量，
                //此处大于或等于2个时使用
                case CardIds.Collectible.Paladin.SmugglersRun:
                    {
                        int iii = 0;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Type == CardType.MOB)
                            {
                                iii++;
                            }
                        }
                        if (iii >= 3) return -30;//此处为30考虑到可能会先开车后水晶学
                        else return 30;
                    }
                    break;
                //神恩术 divinefavor
                case CardIds.Collectible.Paladin.DivineFavor:
                    if (p.enemycarddraw - p.owncards.Count >= 2) return -50;
                    else return 50;
                    break;
                //污手街供货商 grimestreetoutfitter
                //和开车一样的道理
                case CardIds.Collectible.Paladin.GrimestreetOutfitter:
                    {
                        int iii = 0;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Type == CardType.MOB)
                            {
                                iii++;
                            }
                        }
                        if (iii >= 3) return -29;
                        else return 30;
                    }
                    break;
                //亮石技师
                //原则同上
                case Chireiden.Silverfish.SimCard.亮石技师:
                    {
                        int iii = 0;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Type == CardType.MOB)
                            {
                                iii++;
                            }
                        }
                        if (iii >= 3) return -29;
                        else return 30;
                    }
                    break;
                //通电机器人
                case Chireiden.Silverfish.SimCard.通电机器人:
                    {
                        int iii = 0;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Race == 17)
                            {
                                iii++;
                            }
                        }
                        if (iii >= 3) return -40;
                        else if (iii >= 2) return -20;
                        else
                            return 20;
                    }
                    break;
                //机械跃迁者 mechwarper
                //此处惩罚值有待考究
                /*矛盾点在于是否要判断法力水晶可用个数，然后下机械跃迁者后减费铺场
                * 此处要经大量测试去确定
                * 此处暂时确定为白板直接下
                * */
                case CardIds.Collectible.Neutral.Mechwarper:
                    return -25;
                    break;



                //分裂战斧
                case Chireiden.Silverfish.SimCard.分裂战斧:
                  int ownTotemsCount= 0;
                  foreach (Minion m in p.ownMinions)
                        {
                        if ((Race)m.handcard.card.Race == Race.TOTEM) ownTotemsCount++;
                        }
                    return 5 - ownTotemsCount * 5;
                //风怒小陀螺
                case CardIds.Collectible.Shaman.WhirlingZapOMatic:
                    if (p.enemyHeroName == HeroEnum.warlock) return -10;

                    return 0;

                //风暴聚合器
                case Chireiden.Silverfish.SimCard.风暴聚合器:
                    if (p.ownMinions.Count < 7) return 95 - p.ownMinions.Count * 25;
                    return 0;

                //图腾之力和图腾潮涌惩罚
                case CardIds.Collectible.Shaman.TotemicMight:
                    ownTotemsCount = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((Race)m.handcard.card.Race == Race.TOTEM) ownTotemsCount++;
                    }
                    return 13 - ownTotemsCount * 2;
                case Chireiden.Silverfish.SimCard.图腾潮涌:
                    ownTotemsCount = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((Race)m.handcard.card.Race == Race.TOTEM) ownTotemsCount++;
                    }
                    return 13 - ownTotemsCount * 2;
                //怪盗图腾
                case Chireiden.Silverfish.SimCard.怪盗图腾:
                    return -2;
                //暗金教侍从添加

                case CardIds.Collectible.Mage.KabalLackey:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (p.ownMaxMana == 1 && hc.card.Secret) return -50;
                    }
                    break;

                case Chireiden.Silverfish.SimCard.对空奥术法师:
                    {
                        int KillCount = 0;
                        foreach (Minion mi in p.enemyMinions)
                        {
                            //对方随从生命值小于 2
                            if (mi.Hp <= 2)
                                KillCount++;
                        }
                        //如果对面随从等于0
                        if (p.enemyMinions.Count == 0)
                        {
                            return 50;//不推荐使用
                        }
                        //如果对面随从大于1
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Secret && p.mana >= (hc.card.Cost + card.Cost))
                            {
                                //如果对面随从等于1
                                if (p.enemyMinions.Count == 1)
                                {
                                    //是否能击杀
                                    if (KillCount < 1)
                                        return 5;//不推荐使用
                                    else
                                        return -10;//比较推荐使用
                                }
                                else
                                {
                                    //如果对面随从大于1
                                    return -50 * KillCount;//推荐使用
                                }
                            }
                        }
                        break;
                    }









                //疯狂的科学家
                case CardIds.Collectible.Neutral.MadScientist: return -6;
                //厄运信天翁
                   case Chireiden.Silverfish.SimCard.厄运信天翁:
                  int ownMinionsSumHp = 0;
                  if (p.enemyHero.Hp < 20) return -20;
                        foreach (Minion mm in p.ownMinions)
                   ownMinionsSumHp += mm.Hp;
                  if (ownMinionsSumHp < 4) return -3;
                    else return -ownMinionsSumHp;
                    break;
                //麦迪文的男仆
                case CardIds.Collectible.Mage.MedivhsValet:
                    if (p.ownSecretsIDList.Count < 1) return 80;
                    if (target.isHero) return -5;
                    break;
                //爆炸符文
                case CardIds.Collectible.Mage.ExplosiveRunes: return -8;
                //复制
                case CardIds.Collectible.Mage.Duplicate:
                    bool found1 = false;
                    foreach (Minion mnn1 in p.ownMinions)
                    {
                        if (mnn1.name == CardIds.Collectible.Mage.KabalCrystalRunner || mnn1.name == Chireiden.Silverfish.SimCard.云雾王子) found1 = true;

                    }
                    if (found1) return -10;

                    else return -5;
                    break;

                 //寒冰屏障
                case CardIds.Collectible.Mage.IceBlock:
                    if (p.ownHero.Hp < 20) return -8;
                    else return -3;
                    break;
                //法术反制
                case CardIds.Collectible.Mage.Counterspell: return -6;
                //火焰结界
                case Chireiden.Silverfish.SimCard.火焰结界:
                    if (p.enemyMinions.Count == 2) return -8;
                    if (p.enemyMinions.Count == 3) return -12;
                    if (p.enemyMinions.Count >= 4) return -15;
                    else return -3;
                    break;

                //云雾王子
                case CardIds.Collectible.Mage.CloudPrince:
                    if (p.ownSecretsIDList.Count < 1) return 80;
                    if (target.isHero) return -5;
                    break;
                //艾露尼斯
                case Chireiden.Silverfish.SimCard.艾露尼斯:
                    if (p.owncards.Count >= 6) return 500;
                    else return -90;
                    break;
                //火冲
                case CardIds.NonCollectible.Mage.Fireblast:
                    if (target.isHero) return -2;
                    else return -1;
                    break;
                case CardIds.NonCollectible.Shaman.TotemicCall:
                    if (lethal) return 20;
                    break;

                case CardIds.Collectible.Neutral.FrostwolfWarlord:
                    if (p.ownMinions.Count == 0) pen += 5;
                    break;

                case CardIds.Collectible.Shaman.FlametongueTotem:
                    if (p.ownMinions.Count == 0) return 100;
                    break;

                case CardIds.Collectible.Neutral.StampedingKodo:
                    bool found = false;
                    foreach (Minion mi in p.enemyMinions)
                    {
                        if (mi.Angr <= 2) found = true;
                    }
                    if (!found) return 20;
                    break;

                case Chireiden.Silverfish.SimCard.Windfury:
                    if (!target.own) return 500;
                    else if (!target.Ready) return 500;
                    break;

                case CardIds.Collectible.Paladin.DesperateStand: goto case CardIds.Collectible.Shaman.AncestralSpirit;
                case CardIds.Collectible.Shaman.AncestralSpirit:
                    if (!target.isHero)
                    {
                        if (!target.own)
                        {
                            if (target.name == CardIds.Collectible.Neutral.Deathlord || target.name == CardIds.Collectible.Neutral.ZombieChow || target.name == CardIds.Collectible.Neutral.DancingSwords) return 0;
                            return 500;
                        }
                        else
                        {
                            if (this.specialMinions.ContainsKey(target.name)) return -5;
                            return 0;
                        }
                    }
                    break;

                case CardIds.Collectible.Hunter.Houndmaster:
                    if (target == null) return 50;
                    break;

                case CardIds.Collectible.Rogue.BeneathTheGrounds: return -10;

                case CardIds.Collectible.Warlock.CurseOfRafaam: return -7;

                case CardIds.Collectible.Warlock.FlameImp:
                    if (p.ownHero.Hp + p.ownHero.armor > 20) pen -= 3;
                    break;


                case CardIds.Collectible.Paladin.Quartermaster:
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.name == Chireiden.Silverfish.SimCard.silverhandrecruit) return 0;
                    }
                    return 5;

                case CardIds.Collectible.Paladin.MysteriousChallenger: return -14;


                case CardIds.Collectible.Neutral.BigGameHunter:
                    if (target == null || target.own) return 40;
                    break;

                case CardIds.NonCollectible.Neutral.EmergencyCoolant:
                    if (target != null && target.own) pen = 500;
                    break;

                case CardIds.Collectible.Neutral.ShatteredSunCleric:
                    if (target == null) return 10;
                    break;

                case CardIds.Collectible.Paladin.ArgentProtector:
                    if (target == null) pen = 20;
                    else
                    {
                        if (!target.own) return 500;
                        if (!target.Ready && !target.handcard.card.isSpecialMinion)
                        {
                            if (target.Angr <= 2 && target.Hp <= 2) pen = 15;
                            else pen = 10;
                        }
                    }
                    break;

                case CardIds.Collectible.Neutral.FacelessManipulator:
                    if (target == null) return 50;
                    if (target.Angr >= 5 || target.handcard.card.Cost >= 5 || (target.handcard.card.rarity == 5 || target.handcard.card.Cost >= 3))
                    {
                        return 0;
                    }
                    return 49;

                case CardIds.Collectible.Neutral.RendBlackhand:
                    if (target == null) return 15;
                    if (target.own) return 100;
                    if ((target.taunt && target.handcard.card.rarity == 5) || target.handcard.card.CardId == CardIds.Collectible.Warlock.Malganis)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if ((Race)hc.card.Race == Race.DRAGON) return 0;
                        }
                    }
                    return 500;

                case CardIds.Collectible.Neutral.TheBlackKnight:
                    if (target == null) return 50;
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.taunt && (target.Angr >= 3 || target.Hp >= 3)) return 0;
                    }
                    return 20;

                case CardIds.Collectible.Neutral.MadderBomber: goto case CardIds.Collectible.Neutral.MadBomber;
                case CardIds.Collectible.Neutral.MadBomber:
                    pen = 0;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.Ready & mnn.Hp < 3) pen += 5;
                    }
                    return pen;

                case CardIds.Collectible.Neutral.SylvanasWindrunner:
                    if (p.enemyMinions.Count == 0) return 10;
                    break;

                case CardIds.Collectible.Rogue.Betrayal:
                    if (!target.own && !target.isHero)
                    {
                        if (target.Angr == 0) return 30;
                        if (p.enemyMinions.Count == 1) return 30;
                    }
                    break;

                case CardIds.Collectible.Neutral.NerubianEgg:
                    if (p.owncards.Find(x => this.attackBuffDatabase.ContainsKey(x.card.CardId)) != null || p.owncards.Find(x => this.tauntBuffDatabase.ContainsKey(x.card.CardId)) != null)
                    {
                        return -6;
                    }
                    break;

                case CardIds.Collectible.Druid.Bite:
                    if ((p.ownHero.numAttacksThisTurn == 0 || (p.ownHero.windfury && p.ownHero.numAttacksThisTurn == 1)) && !p.ownHero.frozen)
                    {

                    }
                    else return 20;
                    break;

                case CardIds.Collectible.Rogue.DeadlyPoison:
                    return -(p.ownWeapon.Durability - 1) * 2;

                case CardIds.Collectible.Rogue.ColdBlood:
                    if (lethal) return 0;
                    return 25;

                case CardIds.Collectible.Neutral.BloodmageThalnos: return 10;

                case CardIds.Collectible.Mage.Frostbolt:
                    if (!target.own && !target.isHero)
                    {
                        if (target.handcard.card.Cost < 3 && !this.priorityDatabase.ContainsKey(target.handcard.card.CardId)) return 15;
                    }
                    return 0;

                case CardIds.Collectible.Warlock.PowerOverwhelming:
                    if (target.own && !target.isHero && !target.Ready) return 500;
                    break;

                case CardIds.Collectible.Warrior.FrothingBerserker:
                    if (p.cardsPlayedThisTurn >= 1) pen = 5;
                    break;

                case CardIds.Collectible.Paladin.HandOfProtection:
                    if (!target.own)
                    {
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (!mm.divineshild) return 500;
                        }
                    }
                    if (target.Hp == 1) pen = 15;
                    break;

                case CardIds.Collectible.Druid.WildGrowth: goto case CardIds.Collectible.Druid.Nourish;
                case CardIds.Collectible.Druid.Nourish:
                    if (p.ownMaxMana == 9 && !(p.ownHeroName == HeroEnum.thief && p.cardsPlayedThisTurn == 0)) return 500;
                    break;

                case CardIds.Collectible.Priest.Resurrect:
                    if (p.ownMaxMana < 6) return 50;
                    if (p.ownMinions.Count == 7) return 500;
                    if (p.ownMaxMana > 8) return 0;
                    if (p.OwnLastDiedMinion == Chireiden.Silverfish.SimCard.None) return 6;
                    return 0;

                case CardIds.Collectible.Shaman.LavaShock:
                    if (p.ueberladung + p.lockedMana < 1) return 15;
                    return (3 - 3 * (p.ueberladung + p.lockedMana));

                case CardIds.Collectible.Rogue.EdwinVancleef:
                    if (p.cardsPlayedThisTurn < 1) return 30;
                    else if (p.cardsPlayedThisTurn < 2) return 10;
                    else return 0;

                case CardIds.Collectible.Neutral.EnhanceOMechano:
                    if (p.ownMinions.Count == 0 && p.ownMaxMana < 5) return 500;
                    pen = 2 * (p.mana - 4 - p.mobsplayedThisTurn);
                    if (p.mobsplayedThisTurn < 1) pen += 30;
                    return pen;

                case CardIds.Collectible.Neutral.KnifeJuggler:
                    if (p.mobsplayedThisTurn >= 1) return 20;
                    break;

                case CardIds.Collectible.Mage.Flamewaker:
                    foreach (Action a in p.playactions)
                    {
                        if (a.actionType == actionEnum.playcard && a.card.card.Type == CardType.SPELL) return 30;
                    }
                    break;

                case CardIds.Collectible.Mage.Polymorph: goto case CardIds.Collectible.Shaman.Hex;
                case CardIds.Collectible.Shaman.Hex:
                    if (!target.isHero)
                    {
                        if (target.own)
                        {
                            if (target.name == Chireiden.Silverfish.SimCard.masterchest) return -5;
                            else return 500;
                        }
                        else
                        {
                            if (target.allreadyAttacked) return 30;
                            Minion frog = target;
                            if (this.priorityTargets.ContainsKey(frog.name)) return 0;
                            if (frog.Angr >= 4 && frog.Hp >= 4) return 0;
                            if (frog.Angr >= 2 && frog.Hp >= 6) return 5;
                            return 30;
                        }
                    }
                    break;

                case CardIds.Collectible.Warrior.RavagingGhoul:
                    if (p.enemyMinions.Count == 0) return 7;
                    break;

                case CardIds.Collectible.Neutral.BookWyrm:
                    if (target == null) return 20;
                    else
                    {
                        if (this.priorityTargets.ContainsKey(target.name) || this.priorityDatabase.ContainsKey(target.name))
                        {
                            if (target.Hp > 3) return -6;
                            return -3;
                        }
                        else if (target.maxHp > 3) return 0;
                        else return 5;
                    }
                    break;

                case CardIds.Collectible.Paladin.GrimestreetProtector:
                    if (p.ownMinions.Count == 1) return 10;
                    else if (p.ownMinions.Count == 0) return 20;
                    break;

                case CardIds.Collectible.Neutral.SunfuryProtector:
                    if (p.ownMinions.Count == 1) return 15;
                    else if (p.ownMinions.Count == 0) return 30;
                    break;

                case CardIds.Collectible.Neutral.DefenderOfArgus:
                    if (p.ownMinions.Count == 1) return 30;
                    else if (p.ownMinions.Count == 0) return 50;
                    break;

                case CardIds.Collectible.Rogue.UnearthedRaptor:
                    if (target == null) return 10;
                    break;

                case CardIds.Collectible.Hunter.UnleashTheHounds:
                    if (p.enemyMinions.Count <= 1) return 20;
                    break;

                case CardIds.Collectible.Paladin.Equality:
                    if (p.enemyMinions.Count <= 2 || (p.ownMinions.Count - p.enemyMinions.Count >= 1)) return 20;
                    break;

                case CardIds.Collectible.Neutral.BloodsailRaider:
                    if (p.ownWeapon.Durability == 0)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Type == CardType.WEAPON) return 10;
                        }
                    }
                    break;

                case CardIds.Collectible.Priest.InnerFire:
                    if (target.name == CardIds.Collectible.Priest.Lightspawn) return 500;
                    if (!target.Ready) return 20;
                    break;

                case CardIds.Collectible.Hunter.HuntersMark:
                    if (!target.isHero)
                    {
                        if (target.own) return 500;
                        else if (target.Hp <= 4 && target.Angr <= 4 && !(target.poisonous && !target.silenced))
                        {
                            pen = 20;
                        }
                    }
                    break;

                case CardIds.Collectible.Neutral.CrazedAlchemist:
                    if (target != null) pen -= 1;
                    break;

                case CardIds.Collectible.Neutral.Deathwing:
                    int prevDmg = 0;
                    foreach (Minion m1 in p.enemyMinions)
                    {
                        prevDmg += m1.Angr;
                    }
                    if (p.ownHero.Hp + p.ownHero.armor > prevDmg * 2) pen += p.ownMinions.Count * 10 + p.owncards.Count * 25;
                    break;

                case CardIds.Collectible.Neutral.Deathwingdragonlord:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if ((Race)hc.card.Race == Race.DRAGON) pen -= 3;
                    }
                    pen += 3;
                    break;

                case CardIds.Collectible.Paladin.Humility: goto case CardIds.Collectible.Paladin.AldorPeacekeeper;
                case CardIds.Collectible.Paladin.AldorPeacekeeper:
                    if (target != null)
                    {
                        if (target.own) pen = 500;
                        else if (target.Angr <= 3) pen = 30;
                        if (target.name == CardIds.Collectible.Priest.Lightspawn) pen = 500;
                    }
                    else pen = 40;
                    break;

                case CardIds.Collectible.Neutral.DireWolfAlpha: goto case CardIds.Collectible.Neutral.AbusiveSergeant;
                case CardIds.Collectible.Neutral.AbusiveSergeant:
                    int ready = 0;
                    foreach (Minion min in p.ownMinions)
                    {
                        if (min.Ready) ready++;
                    }
                    if (ready == 0) pen = 5;
                    break;

                case CardIds.Collectible.Rogue.GangUp:
                    if (this.GangUpDatabase.ContainsKey(target.handcard.card.CardId))
                    {
                        return (-5 - 1 * GangUpDatabase[target.handcard.card.CardId]);
                    }
                    else return 40;

                case CardIds.Collectible.Rogue.DefiasRingleader:
                    if (p.cardsPlayedThisTurn == 0) pen = 10;
                    break;

                case CardIds.Collectible.Neutral.BloodKnight:
                    int shilds = 0;
                    foreach (Minion min in p.ownMinions)
                    {
                        if (min.divineshild) shilds++;
                    }
                    foreach (Minion min in p.enemyMinions)
                    {
                        if (min.divineshild) shilds++;
                    }
                    if (shilds == 0) pen = 10;
                    break;

                case CardIds.Collectible.Shaman.Reincarnate:
                    if (target.own)
                    {
                        if (target.handcard.card.deathrattle || target.ancestralspirit >= 1 || target.desperatestand >= 1 || target.souloftheforest >= 1 || target.stegodon >= 1 || target.livingspores >= 1 || target.infest >= 1 || target.explorershat >= 1 || target.returnToHand >= 1 || target.deathrattle2 != null || target.enemyBlessingOfWisdom >= 1 || target.enemyPowerWordGlory >= 1) return 0;
                        if (target.handcard.card.Charge && ((target.numAttacksThisTurn == 1 && !target.windfury) || (target.numAttacksThisTurn == 2 && target.windfury))) return 0;
                        if (target.wounded || target.Angr < target.handcard.card.Attack || (target.silenced && this.specialMinions.ContainsKey(target.name))) return 0;

                        bool hasOnMinionDiesMinion = false;
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.name == CardIds.Collectible.Hunter.ScavengingHyena && target.handcard.card.Race == 20) hasOnMinionDiesMinion = true;
                            if (mnn.name == CardIds.Collectible.Neutral.FlesheatingGhoul || mnn.name == CardIds.Collectible.Neutral.CultMaster) hasOnMinionDiesMinion = true;
                        }
                        if (hasOnMinionDiesMinion) return 0;
                        return 500;
                    }
                    else
                    {
                        if (target.name == CardIds.Collectible.Neutral.NerubianEgg && target.Angr <= 4 && !target.taunt) return 500;
                        if (target.taunt && !target.handcard.card.Taunt) return 0;
                        if (target.enemyBlessingOfWisdom >= 1 || target.enemyPowerWordGlory >= 1) return 0;
                        if (target.Angr > target.handcard.card.Attack || target.Hp > target.handcard.card.Health) return 0;
                        if (target.name == CardIds.Collectible.Neutral.Abomination || target.name == CardIds.Collectible.Neutral.ZombieChow || target.name == CardIds.Collectible.Neutral.UnstableGhoul || target.name == CardIds.Collectible.Neutral.DancingSwords) return 0;
                        return 500;
                    }
                    break;

                case CardIds.Collectible.Priest.DivineSpirit:
                    if (!target.isHero)
                    {
                        if (target.own)
                        {
                            if (target.Hp >= 4) return 0;
                            return 15;
                        }
                        else if (lethal)
                        {
                            if (!target.taunt) return 500;
                            else
                            {
                                // combo for killing with innerfire and biggamehunter
                                if (p.owncards.Find(x => x.card.CardId == CardIds.Collectible.Neutral.BigGameHunter) != null && p.owncards.Find(x => x.card.CardId == CardIds.Collectible.Priest.InnerFire) != null && (target.Hp >= 4 || (p.owncards.Find(x => x.card.CardId == CardIds.Collectible.Priest.DivineSpirit) != null && target.Hp >= 2)))
                                {
                                    return 0;
                                }
                                return 500;
                            }
                        }
                        else
                        {
                            // combo for killing with innerfire and biggamehunter
                            if (p.owncards.Find(x => x.card.CardId == CardIds.Collectible.Neutral.BigGameHunter) != null && p.owncards.Find(x => x.card.CardId == CardIds.Collectible.Priest.InnerFire) != null && target.Hp >= 4)
                            {
                                return 0;
                            }
                            return 500;
                        }
                    }
                    break;
            }


            //------------------------------------------------------------------------------------------------------


            if ((p.ownHeroAblility.card.CardId == CardIds.NonCollectible.Shaman.TotemicCall || p.ownHeroAblility.card.CardId == Chireiden.Silverfish.SimCard.totemicslam) && p.ownAbilityReady == false)
            {
                foreach (Action a in p.playactions)
                {
                    if (a.actionType == actionEnum.playcard && a.card.card.CardId == CardIds.Collectible.Shaman.DraeneiTotemcarver) return -1;
                    if (a.actionType == actionEnum.playcard && a.card.card.CardId == Chireiden.Silverfish.SimCard.图腾潮涌) return -1;
                    if (a.actionType == actionEnum.playcard && a.card.card.CardId == CardIds.Collectible.Shaman.TotemicMight) return -1;
                    if (a.actionType == actionEnum.playcard && a.card.card.CardId == Chireiden.Silverfish.SimCard.分裂战斧) return -1;
                }
                if (p.owncards.Count > 1)
                {
                    if (card.Type == CardType.SPELL)
                    {
                        if (!(DamageTargetDatabase.ContainsKey(card.CardId) || DamageAllEnemysDatabase.ContainsKey(card.CardId)
                        || DamageAllDatabase.ContainsKey(card.CardId) || DamageRandomDatabase.ContainsKey(card.CardId)
                        || DamageTargetSpecialDatabase.ContainsKey(card.CardId) || DamageHeroDatabase.ContainsKey(card.CardId))) pen += 10;
                    }
                    else if (card.CardId == CardIds.Collectible.Neutral.FrostwolfWarlord || card.CardId == CardIds.Collectible.Shaman.ThingFromBelow || card.CardId == CardIds.Collectible.Shaman.DraeneiTotemcarver) return -1;
                    else pen += 10;
                }
            }



            if (target != null && (name == CardIds.Collectible.Rogue.Sap || name == CardIds.NonCollectible.DreamCards.Dream || name == CardIds.Collectible.Rogue.Kidnapper))
            {
                if (!target.own && (target.name == CardIds.Collectible.Neutral.TheBlackKnight || name == CardIds.Collectible.Neutral.RendBlackhand))
                {
                    return 50;
                }
            }

            if (!lethal && card.CardId == CardIds.NonCollectible.Druid.DruidoftheClaw_DruidOfTheClawTokenClassic1) //druidoftheclaw	Charge
            {
                return 20;
            }


            if (lethal)
            {
                if (name == CardIds.Collectible.Warlock.Corruption)
                {
                    int beasts = 0;
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.Ready && (mm.handcard.card.CardId == CardIds.Collectible.Neutral.QuestingAdventurer || mm.handcard.card.CardId == CardIds.Collectible.Mage.ArchmageAntonidas || mm.handcard.card.CardId == CardIds.Collectible.Neutral.ManaAddict || mm.handcard.card.CardId == CardIds.Collectible.Mage.ManaWyrm || mm.handcard.card.CardId == CardIds.Collectible.Neutral.WildPyromancer)) beasts++;
                    }
                    if (beasts == 0) return 500;
                }
            }


            if (returnHandDatabase.ContainsKey(name))
            {
                if (target != null && target.own && !target.isHero && target.Ready) pen += 10;

                switch (target.name)
                {
                    case Chireiden.Silverfish.SimCard.masterchest: return target.own ? -21 : 5;
                }

                if (card.Type == CardType.SPELL)
                {
                    if (name == CardIds.Collectible.Rogue.Vanish)
                    {
                        //dont vanish if we have minons on board wich are ready
                        bool haveready = false;
                        foreach (Minion mins in p.ownMinions)
                        {
                            if (mins.Ready) haveready = true;
                        }
                        if (haveready) pen += 10;
                    }
                    else
                    {
                        if (target.wounded) return 0;
                        if (target.silenced)
                        {
                            if (this.UsefulNeedKeepDatabase.ContainsKey(target.name)) return -1;
                        }
                        if (target.charge > 0 && !target.Ready) return 0;

                        if (p.enemySecretCount > 0 && p.enemyHeroStartClass == CardClass.MAGE) return 0;

                        bool BeastReq = false;
                        bool MechReq = false;
                        bool PirateReq = false;
                        bool DragonReq = false;
                        if (target.handcard.card.battlecry)
                        {
                            if (this.dragonDependentDatabase.ContainsKey(target.name)) DragonReq = true;
                            switch (target.name)
                            {
                                //case CardIds.Collectible.Neutral.MasterOfCeremonies:
                                case CardIds.Collectible.Hunter.RamWrangler: BeastReq = true; break;
                                case CardIds.Collectible.Druid.DruidOfTheFang: BeastReq = true; break;
                                case CardIds.Collectible.Mage.GoblinBlastmage: MechReq = true; break;
                                case CardIds.Collectible.Neutral.TinkertownTechnician: MechReq = true; break;
                                case CardIds.Collectible.Rogue.ShadyDealer: if (!target.Ready && target.maxHp == 3) PirateReq = true; break;
                                case CardIds.Collectible.Neutral.GormokTheImpaler: if (p.ownMinions.Count > 4) return 0; break;
                                case CardIds.Collectible.Hunter.CoreRager: if (p.owncards.Count < 1) return 0; break;
                                case CardIds.Collectible.Neutral.DrakonidCrusher: if (p.enemyHero.Hp < 16) return 0; break;
                                case CardIds.Collectible.Priest.MindControltech: if (p.enemyMinions.Count > 3) return 0; break;
                                case CardIds.Collectible.Warrior.AlexstraszasChampion: if (target.Ready) DragonReq = false; break;
                                case CardIds.Collectible.Neutral.TwilightGuardian: if (target.taunt) DragonReq = false; break;
                                case CardIds.Collectible.Priest.WyrmrestAgent: if (target.taunt) DragonReq = false; break;
                                case CardIds.Collectible.Neutral.BlackwingTechnician: if (target.maxHp > 4) DragonReq = false; break;
                                case CardIds.Collectible.Priest.TwilightWhelp: if (target.maxHp > 1) DragonReq = false; break;
                                case CardIds.Collectible.Hunter.KingsElekk: return 0; break;
                                case CardIds.Collectible.Neutral.GadgetzanJouster: if (target.maxHp == 2) return 0; break;
                                case CardIds.Collectible.Neutral.ArmoredWarhorse: if (!target.Ready) return 0; break;
                                case CardIds.Collectible.Neutral.MasterJouster: if (!target.taunt) return 0; break;
                                case CardIds.Collectible.Paladin.TuskarrJouster: if (!target.Ready && p.ownHero.Hp < 26) return 0; break;
                            }
                        }

                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (this.spellDependentDatabase.ContainsKey(mnn.name) && mnn.entitiyID != target.entitiyID) return 0;
                            if (mnn.name == CardIds.Collectible.Hunter.StarvingBuzzard && mnn.entitiyID != target.entitiyID && target.handcard.card.Race == 20) return 0;

                            if (BeastReq && mnn.handcard.card.Race == 20) return 0;
                            if (MechReq && mnn.handcard.card.Race == 17) return 0;
                            if (PirateReq && mnn.handcard.card.Race == 23) return 0;
                        }

                        if (DragonReq)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards)
                            {
                                if (hc.card.Race == 24) return 0;
                            }
                        }
                        return 500;
                    }
                }
            }

            return pen;
        }

        private int playSecretPenality(Chireiden.Silverfish.SimCard card, Playfield p)
        {
            //penality if we play secret and have playable kirintormage
            int pen = 0;
            if (card.Secret)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
            {
                    //肯瑞托法师
                    if (hc.card.CardId == CardIds.Collectible.Mage.KirinTorMage && p.mana >= hc.getManaCost(p))

                    {
                       pen = 500;
                   }
                }
            }

            return pen;
        }


        ///secret strategys pala
        /// -Attack lowest enemy. If you can’t, use noncombat means to kill it.
        /// -attack with something able to withstand 2 damage.
        /// -Then play something that had low health to begin with to dodge Repentance.
        ///
        ///secret strategys hunter
        /// - kill enemys with your minions with 2 or less heal.
        ///  - Use the smallest minion available for the first attack
        ///  - Then smack them in the face with whatever’s left.
        ///  - If nothing triggered until then, it’s a Snipe, so throw something in front of it that won’t die or is expendable.
        ///
        ///secret strategys mage
        /// - Play a small minion to trigger Mirror Entity.
        /// Then attack the mage directly with the smallest minion on your side.
        /// If nothing triggered by that point, it’s either Spellbender or Counterspell, so hold your spells until you can (and have to!) deal with either.

        private int getPlayCardSecretPenality(Chireiden.Silverfish.SimCard c, Playfield p)
        {
            int pen = 0;
            if (p.enemySecretCount == 0)
            {
                return 0;
            }

            switch (c.CardId)
            {
                case CardIds.Collectible.Hunter.Flare: return 0; break;
                case CardIds.Collectible.Neutral.EaterOfSecrets: return 0; break;
                case CardIds.Collectible.Neutral.KezanMystic:
                    if (p.enemySecretCount == 1)  return 0;
                    break;
            }

            int attackedbefore = 0;

            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.numAttacksThisTurn >= 1)
                {
                    attackedbefore++;
                }
            }

            if ((c.CardId == CardIds.Collectible.Neutral.AcidicSwampOoze || c.CardId == CardIds.Collectible.Neutral.GluttonousOoze)
                && (p.enemyHeroStartClass == CardClass.WARRIOR || p.enemyHeroStartClass == CardClass.ROGUE || p.enemyHeroStartClass == CardClass.PALADIN))
            {
                if (p.enemyHeroStartClass == CardClass.ROGUE && p.enemyWeapon.Angr <= 2)
                {
                    pen += 100;
                }
                else
                {
                    if (p.enemyWeapon.Angr <= 1)
                    {
                        pen += 100;
                    }
                }
            }

            if (p.enemyHeroStartClass == CardClass.HUNTER)
            {
                if (c.Type == CardType.MOB
                    && (attackedbefore == 0 || c.Health <= 4
                        || (p.enemyHero.Hp >= p.enemyHeroHpStarted && attackedbefore >= 1)))
                {
                    pen += 10;
                }
            }

            if (p.enemyHeroStartClass == CardClass.MAGE)
            {
                if (c.Type == CardType.MOB)
                {
                    Minion m = new Minion
                    {
                        Hp = c.Health,
                        maxHp = c.Health,
                        Angr = c.Attack,
                        taunt = c.Taunt,
                        name = c.CardId
                    };

                    // play first the small minion:
                    if ((!this.isOwnLowestInHand(m, p) && p.mobsplayedThisTurn == 0)
                        || (p.mobsplayedThisTurn == 0 && attackedbefore >= 1))
                    {
                        pen += 10;
                    }
                }

                if (c.Type == CardType.SPELL && p.cardsPlayedThisTurn == p.mobsplayedThisTurn)
                {
                    pen += 10;
                }
            }

            if (p.enemyHeroStartClass == CardClass.PALADIN)
            {
                if (c.Type == CardType.MOB)
                {
                    Minion m = new Minion
                    {
                        Hp = c.Health,
                        maxHp = c.Health,
                        Angr = c.Attack,
                        taunt = c.Taunt,
                        name = c.CardId
                    };
                    if ((!this.isOwnLowestInHand(m, p) && p.mobsplayedThisTurn == 0) || attackedbefore == 0)
                    {
                        pen += 10;
                    }
                }
            }

            return pen;
        }

        private int getAttackSecretPenality(Minion m, Playfield p, Minion target)
        {
            if (p.enemySecretCount == 0)
            {
                return 0;
            }

            int pen = 0;

            int attackedbefore = 0;

            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.numAttacksThisTurn >= 1) attackedbefore++;
            }

            if (p.enemyHeroStartClass == CardClass.HUNTER)
            {
                if (target.isHero)
                {
                    bool canBe_explosive = false;
                    foreach (SecretItem si in p.enemySecretList)
                    {
                        if (si.canBe_explosive) { canBe_explosive = true; break; }
                    }
                    if (canBe_explosive)
                    {
                        foreach(Action a in p.playactions)
                        {
                            switch (a.actionType)
                            {
                                case actionEnum.useHeroPower:
                                    if (a.card.card.playrequires.Contains(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS)) pen += 22;
                                    break;
                                case actionEnum.playcard:
                                    if (a.card.card.Type == CardType.MOB || a.card.card.playrequires.Contains(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS))
                                    {
                                        pen += 20;
                                    }
                                    break;
                            }
                        }
                    }
                }

                bool islow = isOwnLowest(m, p);
                if (attackedbefore == 0 && islow) pen -= 20;
                if (attackedbefore == 0 && !islow) pen += 10;

                if (target.isHero && !target.own && p.enemyMinions.Count >= 1)
                {
                    if (hasMinionsWithLowHeal(p)) pen += 10; //penality if we doesn't attacked minions before
                }
            }


            if (p.enemyHeroStartClass == CardClass.MAGE)
            {
                if (target.isHero)
                {
                    bool canBe_vaporize = false;
                    foreach (SecretItem si in p.enemySecretList)
                    {
                        if (si.canBe_vaporize) { canBe_vaporize = true; break; }
                    }
                    if (canBe_vaporize)
                    {
                        if (!target.own)
                        {
                            bool islow = isOwnLowest(m, p);
                            if (!islow) pen += 10;
                            else
                            {
                                if (getValueOfMinion(m) > 14) pen += 5;
                            }
                            if (p.enemyMinions.Count > 0) pen += 12;
                        }
                        return pen;
                    }
                    else
                    {
                        //TODO other secrets

                        if (p.mobsplayedThisTurn == 0)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards)
                            {
                                if (hc.card.Type == CardType.MOB && hc.canplayCard(p, true)) { pen += 10; break; }
                            }
                        }
                    }

                }
                else
                {
                    bool canBe_duplicate = false;
                    foreach (SecretItem si in p.enemySecretList)
                    {
                        if (si.canBe_duplicate) { canBe_duplicate = true; break; }
                    }
                    if (canBe_duplicate)
                    {
                        pen = 1;
                        if (target.Hp > m.Angr || target.divineshild) return 0;
                        else
                        {
                            pen += target.handcard.card.Cost;
                            if (target.handcard.card.battlecry && target.name != CardIds.Collectible.Neutral.KingMukla) pen += 1;
                            return pen;
                        }
                    }
                    else return 0;
                }
            }

            if (p.enemyHeroStartClass == CardClass.PALADIN)
            {

                bool islow = isOwnLowest(m, p);

                if (!target.own && !target.isHero && attackedbefore == 0)
                {
                    if (!isEnemyLowest(target, p) || m.Hp <= 2) pen += 5;
                }

                if (target.isHero && !target.own && !islow)
                {
                    pen += 5;
                }

                if (target.isHero && !target.own && p.enemyMinions.Count >= 1 && attackedbefore == 0)
                {
                    pen += 5;
                }

            }


            return pen;
        }


        public Chireiden.Silverfish.SimCard getChooseCard(Chireiden.Silverfish.SimCard c, int choice)
        {
            if (choice == 1 && this.choose1database.ContainsKey(c.CardId))
            {
                c = cdb.getCardDataFromID(this.choose1database[c.CardId]);
            }
            else if (choice == 2 && this.choose2database.ContainsKey(c.CardId))
            {
                c = cdb.getCardDataFromID(this.choose2database[c.CardId]);
            }
            return c;
        }

        public int getValueOfUsefulNeedKeepPriority(Chireiden.Silverfish.SimCard name)
        {
            return UsefulNeedKeepDatabase.ContainsKey(name) ? UsefulNeedKeepDatabase[name] : 0;
        }


        private int getValueOfMinion(Minion m)
        {
            int ret = 0;
            ret += 2 * m.Angr + m.Hp;
            if (m.taunt) ret += 2;
            if (this.priorityDatabase.ContainsKey(m.name)) ret += 20 + priorityDatabase[m.name];
            return ret;
        }

        private bool isOwnLowest(Minion mnn, Playfield p)
        {
            bool ret = true;
            int val = getValueOfMinion(mnn);
            foreach (Minion m in p.ownMinions)
            {
                if (!m.Ready) continue;
                if (getValueOfMinion(m) < val) ret = false;
            }
            return ret;
        }

        private bool isOwnLowestInHand(Minion mnn, Playfield p)
        {
            bool ret = true;
            Minion m = new Minion();
            int val = getValueOfMinion(mnn);
            foreach (Handmanager.Handcard card in p.owncards)
            {
                if (card.card.Type != CardType.MOB) continue;
                Chireiden.Silverfish.SimCard c = card.card;
                m.Hp = c.Health;
                m.maxHp = c.Health;
                m.Angr = c.Attack;
                m.taunt = c.Taunt;
                m.name = c.CardId;
                if (getValueOfMinion(m) < val) ret = false;
            }
            return ret;
        }

        private int getValueOfEnemyMinion(Minion m)
        {
            int ret = 0;
            ret += m.Hp;
            if (m.taunt) ret -= 2;
            return ret;
        }

        private bool isEnemyLowest(Minion mnn, Playfield p)
        {
            bool ret = true;
            List<Minion> litt = p.getAttackTargets(true, false);
            int val = getValueOfEnemyMinion(mnn);
            foreach (Minion m in p.enemyMinions)
            {
                if (litt.Find(x => x.entitiyID == m.entitiyID) == null) continue;
                if (getValueOfEnemyMinion(m) < val) ret = false;
            }
            return ret;
        }

        private bool hasMinionsWithLowHeal(Playfield p)
        {
            bool ret = false;
            foreach (Minion m in p.ownMinions)
            {
                if (m.Hp <= 2 && (m.Ready || this.priorityDatabase.ContainsKey(m.name))) ret = true;
            }
            return ret;
        }

        public int guessTotalSpellDamage(Playfield p, Chireiden.Silverfish.SimCard name, bool ownplay)
        {
            int dmg = 0;
            if (this.DamageTargetDatabase.ContainsKey(name)) dmg = this.DamageTargetDatabase[name];
            else if (this.DamageTargetSpecialDatabase.ContainsKey(name)) dmg = this.DamageTargetSpecialDatabase[name];
            else if (this.DamageRandomDatabase.ContainsKey(name)) dmg = this.DamageRandomDatabase[name];
            else if (this.DamageHeroDatabase.ContainsKey(name)) dmg = this.DamageHeroDatabase[name];
            else if (this.DamageAllDatabase.ContainsKey(name)) dmg = (p.ownMinions.Count * this.DamageAllDatabase[name] + p.enemyMinions.Count * this.DamageAllDatabase[name]) * 7 / 10;
            else if (this.DamageAllEnemysDatabase.ContainsKey(name)) dmg = p.enemyMinions.Count * this.DamageAllEnemysDatabase[name] * 7 / 10;
            else if (p.anzOwnAuchenaiSoulpriest >= 1)
            {
                if (this.HealAllDatabase.ContainsKey(name)) dmg = (p.ownMinions.Count * this.HealAllDatabase[name] + p.enemyMinions.Count * this.HealAllDatabase[name]) * 7 / 10;
                else if (this.HealTargetDatabase.ContainsKey(name)) dmg = Math.Min(this.HealTargetDatabase[name], 29);
            }

            if (dmg != 0) dmg = (ownplay) ? p.getSpellDamageDamage(dmg) : p.getEnemySpellDamageDamage(dmg);
            return dmg;
        }


        private void setupEnrageDatabase()
        {
            enrageDatabase.Add(CardIds.Collectible.Neutral.AberrantBerserker, 2);
            enrageDatabase.Add(CardIds.Collectible.Neutral.AmaniBerserker, 3);
            enrageDatabase.Add(CardIds.Collectible.Neutral.AngryChicken, 5);
            enrageDatabase.Add(CardIds.Collectible.Warrior.BloodhoofBrave, 3);
            enrageDatabase.Add(CardIds.Collectible.Warrior.GrommashHellscream, 6);
            enrageDatabase.Add(CardIds.Collectible.Neutral.RagingWorgen, 2);
            enrageDatabase.Add(CardIds.Collectible.Neutral.SpitefulSmith, 2);
            enrageDatabase.Add(CardIds.Collectible.Neutral.TaurenWarrior, 3);
            enrageDatabase.Add(CardIds.Collectible.Warrior.Warbot, 1);
        }

        private void setupHealDatabase()
        {
            HealAllDatabase.Add(CardIds.Collectible.Priest.CircleOfHealing, 4);//allminions
            HealAllDatabase.Add(CardIds.Collectible.Neutral.DarkscaleHealer, 2);//all friends
            HealAllDatabase.Add(CardIds.Collectible.Priest.HolyNova, 2);//to all own minions
            HealAllDatabase.Add(CardIds.Collectible.Druid.TreeOfLife, 1000);//all friends

            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.amarawardenofhope, 40);
            HealHeroDatabase.Add(CardIds.Collectible.Neutral.AntiqueHealbot, 8); //tohero
            HealHeroDatabase.Add(CardIds.Collectible.Priest.BindingHeal, 5);
            HealHeroDatabase.Add(CardIds.Collectible.Neutral.CultApothecary, 2);
            HealHeroDatabase.Add(CardIds.Collectible.Warlock.DrainLife, 2);//tohero
            HealHeroDatabase.Add(CardIds.Collectible.Paladin.GuardianOfKings, 6);//tohero
            HealHeroDatabase.Add(CardIds.Collectible.Priest.HolyFire, 5);//tohero
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.invocationofwater, 12);
            HealHeroDatabase.Add(CardIds.Collectible.Shaman.JinyuWaterspeaker, 6);
            HealHeroDatabase.Add(CardIds.Collectible.Neutral.PriestessOfElune, 4);//tohero
            HealHeroDatabase.Add(CardIds.Collectible.Neutral.RefreshmentVendor, 4);
            HealHeroDatabase.Add(CardIds.Collectible.Neutral.RenoJackson, 25); //tohero
            HealHeroDatabase.Add(CardIds.Collectible.Warlock.SacrificialPact, 5);//tohero
            HealHeroDatabase.Add(CardIds.Collectible.Paladin.SealOfLight, 4); //tohero
            HealHeroDatabase.Add(CardIds.Collectible.Warlock.SiphonSoul, 3); //tohero
            HealHeroDatabase.Add(CardIds.Collectible.Shaman.TidalSurge, 4);
            HealHeroDatabase.Add(CardIds.Collectible.Neutral.TournamentMedic, 2);
            HealHeroDatabase.Add(CardIds.Collectible.Paladin.TuskarrJouster, 7);
            HealHeroDatabase.Add(CardIds.Collectible.Priest.TwilightDarkmender, 10);

            HealTargetDatabase.Add(CardIds.Collectible.Shaman.AncestralHealing, 1000);
            HealTargetDatabase.Add(CardIds.Collectible.Druid.AncientOfLore, 5);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.ancientsecrets, 5);
            HealTargetDatabase.Add(CardIds.Collectible.Priest.BindingHeal, 5);
            HealTargetDatabase.Add(CardIds.Collectible.Priest.DarkshireAlchemist, 5);
            HealTargetDatabase.Add(CardIds.Collectible.Neutral.EarthenRingFarseer, 3);
            HealTargetDatabase.Add(CardIds.Collectible.Priest.FlashHeal, 5);
            HealTargetDatabase.Add(CardIds.Collectible.Paladin.ForbiddenHealing, 2);
            HealTargetDatabase.Add(CardIds.Collectible.Neutral.GadgetzanSocialite, 2);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.heal, 4);
            HealTargetDatabase.Add(CardIds.Collectible.Druid.HealingTouch, 8);
            HealTargetDatabase.Add(CardIds.Collectible.Shaman.HealingWave, 14);
            HealTargetDatabase.Add(CardIds.Collectible.Paladin.HolyLight, 6);
            HealTargetDatabase.Add(CardIds.Collectible.Shaman.HotSpringGuardian, 3);
            HealTargetDatabase.Add(CardIds.Collectible.Neutral.HozenHealer, 30);
            HealTargetDatabase.Add(CardIds.Collectible.Paladin.LayOnHands, 8);
            HealTargetDatabase.Add(CardIds.NonCollectible.Priest.LesserHeal, 2);
            HealTargetDatabase.Add(CardIds.Collectible.Priest.LightOfTheNaaru, 3);
            HealTargetDatabase.Add(CardIds.Collectible.Druid.MoongladePortal, 6);
            HealTargetDatabase.Add(CardIds.Collectible.Neutral.VoodooDoctor, 2);
            HealTargetDatabase.Add(CardIds.NonCollectible.Neutral.WillOfMukla, 8);
            //HealTargetDatabase.Add(CardIds.Collectible.Priest.DivineSpirit, 2);
        }

        private void setupDamageDatabase()
        {
            //DamageAllDatabase.Add(CardIds.Collectible.Mage.FlameLeviathan, 2);
            DamageAllDatabase.Add(CardIds.Collectible.Neutral.Abomination, 2);
            DamageAllDatabase.Add(CardIds.Collectible.Warlock.AbyssalEnforcer, 3);
            DamageAllDatabase.Add(CardIds.Collectible.Mage.Anomalus, 8);
            DamageAllDatabase.Add(CardIds.Collectible.Neutral.BaronGeddon, 2);
            DamageAllDatabase.Add(CardIds.Collectible.Neutral.CorruptedSeer, 2);
            DamageAllDatabase.Add(CardIds.Collectible.Warlock.Demonwrath, 1);
            DamageAllDatabase.Add(CardIds.Collectible.Priest.DragonfirePotion, 5);
            DamageAllDatabase.Add(CardIds.Collectible.Warlock.DreadInfernal, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.dreadscale, 1);
            DamageAllDatabase.Add(CardIds.Collectible.Shaman.ElementalDestruction, 4);
            DamageAllDatabase.Add(CardIds.Collectible.Priest.ExcavatedEvil, 3);
            DamageAllDatabase.Add(CardIds.Collectible.Neutral.ExplosiveSheep, 2);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.felbloom, 4);
            DamageAllDatabase.Add(CardIds.Collectible.Warlock.FelfirePotion, 5);
            DamageAllDatabase.Add(CardIds.Collectible.Warlock.Hellfire, 3);
            DamageAllDatabase.Add(CardIds.NonCollectible.Neutral.Lava, 2);
            DamageAllDatabase.Add(CardIds.Collectible.Priest.Lightbomb, 5);
            DamageAllDatabase.Add(CardIds.NonCollectible.Neutral.MagmaPulse, 1);
            DamageAllDatabase.Add(CardIds.Collectible.Neutral.PrimordialDrake, 2);
            DamageAllDatabase.Add(CardIds.Collectible.Warrior.RavagingGhoul, 1);
            DamageAllDatabase.Add(CardIds.Collectible.Warrior.Revenge, 1);
            DamageAllDatabase.Add(CardIds.Collectible.Paladin.ScarletPurifier, 2);
            DamageAllDatabase.Add(CardIds.Collectible.Warrior.SleepWithTheFishes, 3);
            DamageAllDatabase.Add(CardIds.Collectible.Neutral.TentacleOfNzoth, 1);
            DamageAllDatabase.Add(CardIds.Collectible.Neutral.UnstableGhoul, 1);
            DamageAllDatabase.Add(CardIds.Collectible.Mage.VolcanicPotion, 2);
            DamageAllDatabase.Add(CardIds.Collectible.Warrior.Whirlwind, 1);
            DamageAllDatabase.Add(CardIds.NonCollectible.DreamCards.YseraAwakens, 5);
            DamageAllDatabase.Add(CardIds.Collectible.Priest.SpiritLash, 1);
            DamageAllDatabase.Add(CardIds.Collectible.Warlock.Defile, 1);
            DamageAllDatabase.Add(CardIds.Collectible.Warrior.BloodRazor, 1);
            DamageAllDatabase.Add(CardIds.Collectible.Warrior.Bladestorm, 1);

            DamageAllEnemysDatabase.Add(CardIds.Collectible.Mage.ArcaneExplosion, 1);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Rogue.BladeFlurry, 1);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Mage.Blizzard, 2);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Paladin.Consecration, 2);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Neutral.Cthun, 1);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Rogue.DarkIronSkulker, 2);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Rogue.FanOfKnives, 1);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Mage.Flamestrike, 4);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Priest.HolyNova, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.invocationofair, 3);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Shaman.LightningStorm, 3);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.livingbomb, 5);
            DamageAllEnemysDatabase.Add(CardIds.NonCollectible.Neutral.LocustSwarm, 3);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Shaman.MaelstromPortal, 1);
            DamageAllEnemysDatabase.Add(CardIds.NonCollectible.Neutral.PoisonCloud, 1);//todo 1 or 2
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Neutral.SergeantSally, 1);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Warlock.Shadowflame, 2);
            DamageAllEnemysDatabase.Add(CardIds.NonCollectible.Neutral.Sporeburst, 1);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Druid.Starfall, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.stomp, 2);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Druid.Swipe, 1);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Mage.TwilightFlamecaller, 1);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Hunter.ExplodingBloatbat, 2);
            DamageAllEnemysDatabase.Add(CardIds.Collectible.Hunter.DeathstalkerRexxar, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.deathanddecay, 3);
            DamageAllEnemysDatabase.Add(CardIds.NonCollectible.Neutral.BoneStorm, 1);

            DamageHeroDatabase.Add(CardIds.Collectible.Neutral.BackstreetLeper, 2);
            DamageHeroDatabase.Add(CardIds.NonCollectible.Neutral.BurningAdrenaline, 2);
            DamageHeroDatabase.Add(CardIds.Collectible.Warlock.CurseOfRafaam, 2);
            DamageHeroDatabase.Add(CardIds.Collectible.Neutral.EmeraldReaver, 1);
            DamageHeroDatabase.Add(CardIds.NonCollectible.Neutral.FrostBlast, 3);
            DamageHeroDatabase.Add(CardIds.Collectible.Rogue.Headcrack, 2);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.invocationoffire, 6);
            DamageHeroDatabase.Add(CardIds.Collectible.Neutral.LeperGnome, 2);
            DamageHeroDatabase.Add(CardIds.Collectible.Priest.MindBlast, 5);
            DamageHeroDatabase.Add(CardIds.NonCollectible.Neutral.NecroticAura, 3);
            DamageHeroDatabase.Add(CardIds.Collectible.Neutral.Nightblade, 3);
            DamageHeroDatabase.Add(CardIds.NonCollectible.Neutral.PureCold, 8);
            DamageHeroDatabase.Add(CardIds.Collectible.Priest.Shadowbomber, 3);
            DamageHeroDatabase.Add(CardIds.Collectible.Rogue.SinisterStrike, 3);

            DamageRandomDatabase.Add(CardIds.Collectible.Mage.ArcaneMissiles, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Paladin.AvengingWrath, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Neutral.BombLobber, 4);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.boombot, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.boombotjr, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Warrior.BouncingBlade, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Warrior.Cleave, 2);
            DamageRandomDatabase.Add(CardIds.Collectible.Neutral.Demolisher, 2);
            DamageRandomDatabase.Add(CardIds.NonCollectible.Neutral.DieInsect, 8);
            DamageRandomDatabase.Add(CardIds.NonCollectible.Neutral.DieInsects, 8);
            DamageRandomDatabase.Add(CardIds.Collectible.Hunter.FieryBat, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Mage.Flamecannon, 4);
            DamageRandomDatabase.Add(CardIds.Collectible.Neutral.FlameJuggler, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Mage.Flamewaker, 2);
            DamageRandomDatabase.Add(CardIds.Collectible.Shaman.ForkedLightning, 2);
            DamageRandomDatabase.Add(CardIds.Collectible.Mage.GoblinBlastmage, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Mage.GreaterArcaneMissiles, 3);
            DamageRandomDatabase.Add(CardIds.Collectible.Neutral.HugeToad, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Neutral.KnifeJuggler, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Neutral.MadBomber, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Neutral.MadderBomber, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Hunter.MultiShot, 3);
            DamageRandomDatabase.Add(CardIds.Collectible.Neutral.RagnarosTheFirelord, 8);
            DamageRandomDatabase.Add(CardIds.Collectible.Shaman.RumblingElemental, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Priest.Shadowboxer, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Neutral.ShipsCannon, 2);
            DamageRandomDatabase.Add(CardIds.Collectible.Warlock.SpreadingMadness, 1);
            DamageRandomDatabase.Add(CardIds.NonCollectible.Neutral.ThrowRocks, 3);
            DamageRandomDatabase.Add(CardIds.NonCollectible.Neutral.TimepieceOfHorror, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Neutral.VolatileElemental, 3);
            DamageRandomDatabase.Add(CardIds.Collectible.Shaman.Volcano, 1);
            DamageRandomDatabase.Add(CardIds.Collectible.Mage.BreathOfSindragosa, 2);
            DamageRandomDatabase.Add(CardIds.Collectible.Paladin.Blackguard, 3);

            DamageTargetDatabase.Add(CardIds.Collectible.Mage.ArcaneBlast, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Hunter.ArcaneShot, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Rogue.Backstab, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.ballistashot, 3);
            DamageTargetDatabase.Add(CardIds.NonCollectible.Neutral.BarrelToss, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Rogue.Betrayal, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.BlackwingCorruptor, 3);//if dragon in hand
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.Blazecaller, 5);
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.BlowgillSniper, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.BombSquad, 5);
            DamageTargetDatabase.Add(CardIds.Collectible.Hunter.CobraShot, 3);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.ConeOfCold, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Shaman.Crackle, 3);
            DamageTargetDatabase.Add(CardIds.Collectible.Warlock.Darkbomb, 3);
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.DiscipleOfCthun, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Hunter.DispatchKodo, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.DragonsBreath, 4);
            DamageTargetDatabase.Add(CardIds.Collectible.Warlock.DrainLife, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.ElvenArcher, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Rogue.Eviscerate, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Hunter.ExplosiveShot, 5);
            DamageTargetDatabase.Add(CardIds.Collectible.Warlock.FelCannon, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.Fireball, 6);
            DamageTargetDatabase.Add(CardIds.NonCollectible.Mage.Fireblast, 1);
            DamageTargetDatabase.Add(CardIds.NonCollectible.Mage.Fireblastrank2, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.firebloomtoxin, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Shaman.FireElemental, 3);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.FirelandsPortal, 5);
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.FirePlumePhoenix, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.FlameLance, 8);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.ForbiddenFlame, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.ForgottenTorch, 3);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.Frostbolt, 3);
            DamageTargetDatabase.Add(CardIds.Collectible.Shaman.FrostShock, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.GormokTheImpaler, 4);
            DamageTargetDatabase.Add(CardIds.Collectible.Priest.GreaterHealingPotion, 12);
            DamageTargetDatabase.Add(CardIds.Collectible.Hunter.GrievousBite, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.heartoffire, 5);
            DamageTargetDatabase.Add(CardIds.NonCollectible.Neutral.HoggerSmash, 4);
            DamageTargetDatabase.Add(CardIds.Collectible.Priest.HolyFire, 5);
            DamageTargetDatabase.Add(CardIds.Collectible.Priest.HolySmite, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.IceLance, 4);//only if iced
            DamageTargetDatabase.Add(CardIds.Collectible.Warlock.ImpLosion, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.IronforgeRifleman, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Shaman.JadeLightning, 4);
            DamageTargetDatabase.Add(CardIds.Collectible.Rogue.JadeShuriken, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Druid.KeeperOfTheGrove, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Hunter.KillCommand, 3);//or 5
            DamageTargetDatabase.Add(CardIds.NonCollectible.Neutral.Lavaburst, 5);
            DamageTargetDatabase.Add(CardIds.Collectible.Shaman.LavaShock, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Shaman.LightningBolt, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.lightningjolt, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Druid.LivingRoots, 2);//choice 1
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.MedivhsValet, 3);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.Meteor, 15);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.mindshatter, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.mindspike, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Druid.Moonfire, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Warlock.MortalCoil, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Warrior.MortalStrike, 4);
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.NorthSeaKraken, 4);
            DamageTargetDatabase.Add(CardIds.Collectible.Hunter.OnTheHunt, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Rogue.PerditionsBlade, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Hunter.Powershot, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Mage.Pyroblast, 10);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.razorpetal, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.roaringtorch, 6);
            DamageTargetDatabase.Add(CardIds.Collectible.Warlock.ShadowBolt, 4);
            DamageTargetDatabase.Add(CardIds.Collectible.Priest.Shadowform, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Rogue.ShadowStrike, 5);
            DamageTargetDatabase.Add(CardIds.NonCollectible.Hunter.ShotgunBlast, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Rogue.Si7Agent, 2);
            DamageTargetDatabase.Add(CardIds.NonCollectible.Neutral.SonicBreath, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.sonoftheflame, 6);
            DamageTargetDatabase.Add(CardIds.Collectible.Druid.Starfall, 5);//2 to all enemy
            DamageTargetDatabase.Add(CardIds.Collectible.Druid.Starfire, 5);//draw a card
            DamageTargetDatabase.Add(CardIds.NonCollectible.Hunter.SteadyShot, 2);//or 1 + card
            DamageTargetDatabase.Add(CardIds.Collectible.Shaman.Stormcrack, 4);
            DamageTargetDatabase.Add(CardIds.Collectible.Neutral.StormpikeCommando, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Druid.Swipe, 4);//1 to others
            DamageTargetDatabase.Add(CardIds.Collectible.Shaman.TidalSurge, 4);
            DamageTargetDatabase.Add(CardIds.NonCollectible.Neutral.UnbalancingStrike, 3);
            DamageTargetDatabase.Add(CardIds.Collectible.Rogue.UndercityValiant, 1);
            DamageTargetDatabase.Add(CardIds.Collectible.Druid.Wrath, 1);//todo 3 or 1+card
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.voidform, 2);
            DamageTargetDatabase.Add(CardIds.NonCollectible.Neutral.VampiricLeech, 3);
            DamageTargetDatabase.Add(CardIds.Collectible.Druid.UltimateInfestation, 5);
            DamageTargetDatabase.Add(CardIds.Collectible.Hunter.ToxicArrow, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.siphonlife, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.icytouch, 1);
            DamageTargetDatabase.Add(CardIds.NonCollectible.Neutral.IceClaw, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Warlock.DrainSoul, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Rogue.Doomerang, 2);
            DamageTargetDatabase.Add(CardIds.Collectible.Shaman.Avalanche, 0);

            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warlock.BaneOfDoom, 2);
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warrior.Bash, 3); //+3 armor
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warrior.BloodToIchor, 1);
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warrior.CruelTaskmaster, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardIds.NonCollectible.Neutral.Deathbloom, 5);
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warlock.Demonfire, 2); // friendly demon get +2/+2
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warlock.Demonheart, 5);
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Shaman.EarthShock, 1); //SILENCE /good for raggy etc or iced
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warlock.FeedingTime, 3);
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Mage.FlameGeyser, 2);
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Paladin.HammerOfWrath, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Paladin.HolyWrath, 2);//draw a card
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warrior.InnerRage, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Hunter.QuickShot, 3); //draw a card
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.roguesdoit, 4);//draw a card
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Druid.Savagery, 1);//dmg=herodamage
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warrior.ShieldSlam, 1);//dmg=armor
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Rogue.Shiv, 1);//draw a card
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warrior.Slam, 2);//draw card if it survives
            DamageTargetSpecialDatabase.Add(CardIds.Collectible.Warlock.Soulfire, 4);//delete a card

            HeroPowerEquipWeapon.Add(CardIds.NonCollectible.Rogue.DaggerMastery, 1);
            HeroPowerEquipWeapon.Add(Chireiden.Silverfish.SimCard.direshapeshift, 2);
            HeroPowerEquipWeapon.Add(CardIds.NonCollectible.Neutral.Echolocate, 0);
            HeroPowerEquipWeapon.Add(CardIds.NonCollectible.Neutral.Enraged, 2);
            HeroPowerEquipWeapon.Add(Chireiden.Silverfish.SimCard.poisoneddaggers, 2);
            HeroPowerEquipWeapon.Add(CardIds.NonCollectible.Druid.Shapeshift, 1);
            HeroPowerEquipWeapon.Add(Chireiden.Silverfish.SimCard.plaguelord, 3);


            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.ArcaneBlast, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Hunter.ArcaneShot, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Rogue.Backstab, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.BaneOfDoom, 1);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.BarrelToss, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warrior.Bash, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.BlastcrystalPotion, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.bloodthistletoxin, 3);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warrior.BloodToIchor, 1);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.ChromaticMutation, 5);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Hunter.CobraShot, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.ConeOfCold, 6);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Shaman.Crackle, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warrior.Crush, 2);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.Darkbomb, 1);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.Deathbloom, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.Demonfire, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.Demonheart, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.dispel, 4);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.DragonsBreath, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.DrainLife, 1);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.DrakkisathsCommand, 2);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.DreamCards.Dream, 3);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.Dynamite, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Shaman.EarthShock, 4);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.EmergencyCoolant, 6);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Rogue.Eviscerate, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Hunter.ExplosiveShot, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.FeedingTime, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.Fireball, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.firebloomtoxin, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.FirelandsPortal, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.FlameGeyser, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.FlameLance, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.ForbiddenFlame, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.ForgottenTorch, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.Frostbolt, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Hunter.GrievousBite, 1);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.HakkariBloodGoblet, 5);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Paladin.HammerOfWrath, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Shaman.Hex, 5);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.HoggerSmash, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Priest.HolyFire, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Priest.HolySmite, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Paladin.HolyWrath, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Paladin.Humility, 7);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Hunter.HuntersMark, 7);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.IceLance, 6);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.ImpLosion, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warrior.InnerRage, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Shaman.JadeLightning, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Rogue.JadeShuriken, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Druid.KeeperOfTheGrove, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Hunter.KillCommand, 1);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.Lavaburst, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Shaman.LavaShock, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Shaman.LightningBolt, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Druid.LivingRoots, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Neutral.MadBomber, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Neutral.MadderBomber, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.Meteor, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Druid.Moonfire, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.MortalCoil, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warrior.MortalStrike, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Druid.Mulch, 2);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Druid.Naturalize, 2);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.NecroticPoison, 2);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Hunter.OnTheHunt, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.Polymorph, 5);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Hunter.Powershot, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.Pyroblast, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Hunter.QuickShot, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.razorpetal, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.roaringtorch, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.roguesdoit, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.rottenbanana, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Druid.Savagery, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.ShadowBolt, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Rogue.Shadowstep, 3);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Rogue.ShadowStrike, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Priest.ShadowWordDeath, 2);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Priest.ShadowWordPain, 2);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Mage.Shatter, 2);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warrior.ShieldSlam, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Rogue.Shiv, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Priest.Silence, 4);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.SiphonSoul, 2);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warrior.Slam, 1);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.SonicBreath, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.Soulfire, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.SpreadingMadness, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Druid.Starfall, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Druid.Starfire, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Shaman.Stormcrack, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Druid.Swipe, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.tailswipe, 1);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.TheTrueWarchief, 2);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Shaman.TidalSurge, 1);
            this.maycauseharmDatabase.Add(CardIds.NonCollectible.Neutral.TimeRewinder, 3);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Shaman.Volcano, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Druid.Wrath, 1);
            this.maycauseharmDatabase.Add(CardIds.Collectible.Warlock.DrainSoul, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.obliterate, 2);
        }

        private void setupsilenceDatabase()
        {

            this.silenceDatabase.Add(CardIds.Collectible.Neutral.DefiasCleaner, 1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.dispel, 1);
            this.silenceDatabase.Add(CardIds.Collectible.Shaman.EarthShock, 1);
            this.silenceDatabase.Add(CardIds.Collectible.Neutral.IronbeakOwl, 1);
            this.silenceDatabase.Add(CardIds.Collectible.Priest.KabalSongstealer, 1);
            this.silenceDatabase.Add(CardIds.Collectible.Neutral.LightsChampion, 1);
            this.silenceDatabase.Add(CardIds.Collectible.Priest.MassDispel, 1);
            this.silenceDatabase.Add(CardIds.Collectible.Priest.Purify, -1);
            this.silenceDatabase.Add(CardIds.Collectible.Priest.Silence, 1);
            this.silenceDatabase.Add(CardIds.Collectible.Neutral.Spellbreaker, 1);
            this.silenceDatabase.Add(CardIds.Collectible.Neutral.WailingSoul, -2);

            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.AncientWatcher, 2);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Warlock.AnimaGolem, 1);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.BittertideHydra, 1);
            OwnNeedSilenceDatabase.Add(CardIds.NonCollectible.Neutral.BlackKnight, 2);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.BombSquad, 1);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.CorruptedHealbot, 2);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.DancingSwords, 1);
            OwnNeedSilenceDatabase.Add(CardIds.NonCollectible.Neutral.Deathcharger, 1);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.EerieStatue, 0);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.EmeraldHiveQueen, 1);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.FelOrcSoulfiend, 1);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.FelReaver, 3);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.FrozenCrusher, 2);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.HumongousRazorleaf, 2);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.Icehowl, 2);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.MogorTheOgre, 1);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.NatTheDarkfisher, 0);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.spectralrider, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.spectraltrainee, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.spectralwarrior, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.spore, 3);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.TheBeast, 1);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Warlock.UnlicensedApothecary, 1);
            OwnNeedSilenceDatabase.Add(CardIds.NonCollectible.Neutral.UnrelentingRider, 1);
            OwnNeedSilenceDatabase.Add(CardIds.NonCollectible.Neutral.UnrelentingTrainee, 1);
            OwnNeedSilenceDatabase.Add(CardIds.NonCollectible.Neutral.UnrelentingWarrior, 1);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.VentureCoMercenary, 1);
            OwnNeedSilenceDatabase.Add(CardIds.NonCollectible.Neutral.WhiteKnight, 2);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Druid.Wrathguard, 1);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.ZombieChow, 2);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.TickingAbomination, 0);
            OwnNeedSilenceDatabase.Add(CardIds.Collectible.Neutral.RattlingRascal, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.masterchest, 1);
        }


        private void setupPriorityList()
        {
            priorityDatabase.Add(CardIds.Collectible.Hunter.Acidmaw, 3);
            priorityDatabase.Add(CardIds.Collectible.Mage.AnimatedArmor, 2);
            priorityDatabase.Add(CardIds.Collectible.Mage.ArchmageAntonidas, 6);
            priorityDatabase.Add(CardIds.Collectible.Druid.Aviana, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.BrannBronzebeard, 4);
            priorityDatabase.Add(CardIds.Collectible.Hunter.CloakedHuntress, 2);
            priorityDatabase.Add(CardIds.Collectible.Priest.ConfessorPaletress, 7);
            priorityDatabase.Add(CardIds.Collectible.Neutral.CrowdFavorite, 6);
            priorityDatabase.Add(CardIds.Collectible.Warlock.DarkshireCouncilman, 2);
            priorityDatabase.Add(CardIds.Collectible.Neutral.DireWolfAlpha, 6);
            priorityDatabase.Add(CardIds.Collectible.Neutral.EmperorThaurissan, 5);
            priorityDatabase.Add(CardIds.Collectible.Druid.FandralStaghelm, 6);
            priorityDatabase.Add(CardIds.Collectible.Shaman.FlametongueTotem, 6);
            priorityDatabase.Add(CardIds.Collectible.Mage.Flamewaker, 5);
            priorityDatabase.Add(CardIds.Collectible.Warrior.FrothingBerserker, 1);
            priorityDatabase.Add(CardIds.Collectible.Neutral.GadgetzanAuctioneer, 1);
            priorityDatabase.Add(CardIds.Collectible.Paladin.GrimestreetEnforcer, 1);
            priorityDatabase.Add(CardIds.Collectible.Neutral.GrimPatron, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.GrimscaleOracle, 5);
            priorityDatabase.Add(CardIds.Collectible.Warrior.GrimyGadgeteer, 1);
            priorityDatabase.Add(CardIds.Collectible.Priest.HolyChampion, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.KnifeJuggler, 2);
            priorityDatabase.Add(CardIds.Collectible.Neutral.Kodorider, 6);
            priorityDatabase.Add(CardIds.Collectible.Neutral.KvaldirRaider, 1);
            priorityDatabase.Add(CardIds.NonCollectible.Hunter.Leokk, 5);
            priorityDatabase.Add(CardIds.Collectible.Priest.LyraTheSunshard, 1);
            priorityDatabase.Add(CardIds.Collectible.Warlock.MalchezaarsImp, 1);
            priorityDatabase.Add(CardIds.Collectible.Warlock.Malganis, 10);
            priorityDatabase.Add(CardIds.Collectible.Shaman.ManaTideTotem, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.Mechwarper, 1);
            priorityDatabase.Add(CardIds.Collectible.Neutral.MuklasChampion, 5);
            priorityDatabase.Add(CardIds.Collectible.Paladin.MurlocKnight, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.MurlocWarleader, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.NexusChampionSaraad, 6);
            priorityDatabase.Add(CardIds.Collectible.Priest.NorthshireCleric, 4);
            priorityDatabase.Add(CardIds.Collectible.Neutral.PintSizedSummoner, 3);
            priorityDatabase.Add(CardIds.Collectible.Shaman.PrimalfinTotem, 5);
            priorityDatabase.Add(CardIds.Collectible.Priest.ProphetVelen, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.QuestingAdventurer, 1);
            priorityDatabase.Add(CardIds.Collectible.Priest.RadiantElemental, 3);
            priorityDatabase.Add(CardIds.Collectible.Paladin.RagnarosLightlord, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.RaidLeader, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.Recruiter, 1);
            priorityDatabase.Add(CardIds.Collectible.Hunter.ScavengingHyena, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.Secretkeeper, 5);
            priorityDatabase.Add(CardIds.Collectible.Mage.SorcerersApprentice, 3);
            priorityDatabase.Add(CardIds.Collectible.Neutral.SouthseaCaptain, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.SpiritsingerUmbra, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.StormwindChampion, 5);
            priorityDatabase.Add(CardIds.Collectible.Warlock.SummoningPortal, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.SummoningStone, 5);
            priorityDatabase.Add(CardIds.Collectible.Neutral.TheVoraxx, 2);
            priorityDatabase.Add(CardIds.Collectible.Shaman.ThunderBluffValiant, 2);
            priorityDatabase.Add(CardIds.Collectible.Hunter.TimberWolf, 5);
            priorityDatabase.Add(CardIds.Collectible.Shaman.TunnelTrogg, 1);
            priorityDatabase.Add(CardIds.Collectible.Neutral.ViciousFledgling, 4);
            priorityDatabase.Add(CardIds.Collectible.Neutral.VioletIllusionist, 10);
            priorityDatabase.Add(CardIds.Collectible.Neutral.VioletTeacher, 1);
            priorityDatabase.Add(CardIds.Collectible.Paladin.WarhorseTrainer, 5);
            priorityDatabase.Add(CardIds.Collectible.Warrior.WarsongCommander, 5);
            priorityDatabase.Add(CardIds.Collectible.Shaman.WickedWitchdoctor, 5);
            priorityDatabase.Add(CardIds.Collectible.Warlock.WilfredFizzlebang, 1);
            priorityDatabase.Add(CardIds.Collectible.Warrior.Rotface, 1);
            priorityDatabase.Add(CardIds.Collectible.Hunter.ProfessorPutricide, 1);
            priorityDatabase.Add(CardIds.Collectible.Shaman.Moorabi, 1);
        }

        private void setupAttackBuff()
        {
            this.heroAttackBuffDatabase.Add(CardIds.Collectible.Druid.Bite, 4);
            this.heroAttackBuffDatabase.Add(CardIds.Collectible.Druid.Claw, 2);
            this.heroAttackBuffDatabase.Add(Chireiden.Silverfish.SimCard.evolvespines, 4);
            this.heroAttackBuffDatabase.Add(CardIds.Collectible.Druid.FeralRage, 4);
            this.heroAttackBuffDatabase.Add(CardIds.Collectible.Warrior.HeroicStrike, 4);
            this.heroAttackBuffDatabase.Add(CardIds.Collectible.Druid.Gnash, 3);

            this.attackBuffDatabase.Add(CardIds.Collectible.Neutral.AbusiveSergeant, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Paladin.Adaptation, 1);
            this.attackBuffDatabase.Add(CardIds.NonCollectible.Neutral.Bananas, 1);
            this.attackBuffDatabase.Add(CardIds.Collectible.Hunter.BestialWrath, 2); // NEVER ON enemy MINION
            this.attackBuffDatabase.Add(CardIds.Collectible.Paladin.BlessingOfKings, 4);
            this.attackBuffDatabase.Add(CardIds.Collectible.Paladin.BlessingOfMight, 3);
            this.attackBuffDatabase.Add(CardIds.Collectible.Warlock.BloodfuryPotion, 3);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.briarthorntoxin, 3);
            this.attackBuffDatabase.Add(CardIds.Collectible.Neutral.ClockworkKnight, 1);
            this.attackBuffDatabase.Add(CardIds.Collectible.Rogue.ColdBlood, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Warrior.CruelTaskmaster, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Neutral.DarkIronDwarf, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Druid.DarkWispers, 5);//choice 2
            this.attackBuffDatabase.Add(CardIds.Collectible.Warlock.Demonfuse, 3);
            this.attackBuffDatabase.Add(CardIds.Collectible.Hunter.Dinomancy, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Paladin.Dinosize, 10);
            this.attackBuffDatabase.Add(CardIds.Collectible.Paladin.DivineStrength, 1);
            this.attackBuffDatabase.Add(CardIds.Collectible.Druid.EarthenScales, 1);
            this.attackBuffDatabase.Add(CardIds.Collectible.Hunter.ExplorersHat, 1);
            this.attackBuffDatabase.Add(CardIds.Collectible.Warrior.InnerRage, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Neutral.LanceCarrier, 2);
            this.attackBuffDatabase.Add(CardIds.NonCollectible.Neutral.LanternOfPower, 10);
            this.attackBuffDatabase.Add(CardIds.Collectible.Paladin.LightfusedStegodon, 1);
            this.attackBuffDatabase.Add(CardIds.Collectible.Druid.MarkOfNature, 4);//choice1
            this.attackBuffDatabase.Add(CardIds.Collectible.Druid.MarkOfTheWild, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Druid.MarkOfYshaarj, 2);
            this.attackBuffDatabase.Add(CardIds.NonCollectible.Neutral.MutatingInjection, 4);
            this.attackBuffDatabase.Add(CardIds.NonCollectible.DreamCards.Nightmare, 5); //destroy minion on next turn
            this.attackBuffDatabase.Add(CardIds.Collectible.Priest.PowerWordTentacles, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Shaman.PrimalFusion, 1);
            this.attackBuffDatabase.Add(CardIds.Collectible.Warrior.Rampage, 3);//only damaged minion
            this.attackBuffDatabase.Add(CardIds.Collectible.Shaman.RockbiterWeapon, 3);
            this.attackBuffDatabase.Add(CardIds.Collectible.Neutral.RockpoolHunter, 1);
            this.attackBuffDatabase.Add(CardIds.Collectible.Warrior.ScrewjankClunker, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Paladin.SealOfChampions, 3);
            this.attackBuffDatabase.Add(CardIds.Collectible.Paladin.SilvermoonPortal, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Paladin.SpikeridgedSteed, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Priest.VelensChosen, 2);
            this.attackBuffDatabase.Add(CardIds.NonCollectible.Neutral.WhirlingBlades, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.antimagicshell, 2);
            this.attackBuffDatabase.Add(CardIds.Collectible.Neutral.FallenSunCleric, 1);
            this.attackBuffDatabase.Add(CardIds.Collectible.Shaman.Cryostasis, 3);
            this.attackBuffDatabase.Add(CardIds.Collectible.Neutral.Bonemare, 4);
            this.attackBuffDatabase.Add(CardIds.Collectible.Neutral.AcherusVeteran, 1);
        }

        private void setupHealthBuff()
        {
            //healthBuffDatabase.Add(CardIds.Collectible.Druid.AncientOfWar, 5);//choice2 is only buffing himself!
            //healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.rooted, 5);
            healthBuffDatabase.Add(CardIds.Collectible.Paladin.Adaptation, 1);
            healthBuffDatabase.Add(CardIds.NonCollectible.Neutral.ArmorPlating, 1);
            healthBuffDatabase.Add(CardIds.NonCollectible.Neutral.Bananas, 1);
            healthBuffDatabase.Add(CardIds.Collectible.Paladin.BlessingOfKings, 4);
            healthBuffDatabase.Add(CardIds.Collectible.Neutral.ClockworkKnight, 1);
            healthBuffDatabase.Add(CardIds.Collectible.Druid.DarkWispers, 5);//choice2
            healthBuffDatabase.Add(CardIds.Collectible.Warlock.Demonfuse, 3);
            healthBuffDatabase.Add(CardIds.Collectible.Hunter.Dinomancy, 2);
            healthBuffDatabase.Add(CardIds.Collectible.Paladin.Dinosize, 10);
            healthBuffDatabase.Add(CardIds.Collectible.Paladin.DivineStrength, 2);
            healthBuffDatabase.Add(CardIds.Collectible.Druid.EarthenScales, 1);
            healthBuffDatabase.Add(CardIds.Collectible.Hunter.ExplorersHat, 1);
            healthBuffDatabase.Add(CardIds.NonCollectible.Neutral.LanternOfPower, 10);
            healthBuffDatabase.Add(CardIds.Collectible.Paladin.LightfusedStegodon, 1);
            healthBuffDatabase.Add(CardIds.Collectible.Druid.MarkOfNature, 4);//choice2
            healthBuffDatabase.Add(CardIds.Collectible.Druid.MarkOfTheWild, 2);
            healthBuffDatabase.Add(CardIds.Collectible.Druid.MarkOfYshaarj, 2);
            healthBuffDatabase.Add(CardIds.NonCollectible.Neutral.MutatingInjection, 4);
            healthBuffDatabase.Add(CardIds.NonCollectible.DreamCards.Nightmare, 5);
            healthBuffDatabase.Add(CardIds.Collectible.Priest.PowerWordShield, 2);
            healthBuffDatabase.Add(CardIds.Collectible.Priest.PowerWordTentacles, 6);
            healthBuffDatabase.Add(CardIds.Collectible.Shaman.PrimalFusion, 1);
            healthBuffDatabase.Add(CardIds.Collectible.Warrior.Rampage, 3);
            healthBuffDatabase.Add(CardIds.Collectible.Neutral.RockpoolHunter, 1);
            healthBuffDatabase.Add(CardIds.Collectible.Warrior.ScrewjankClunker, 2);
            healthBuffDatabase.Add(CardIds.Collectible.Paladin.SilvermoonPortal, 2);
            healthBuffDatabase.Add(CardIds.Collectible.Paladin.SpikeridgedSteed, 6);
            healthBuffDatabase.Add(CardIds.Collectible.Warrior.Upgradedrepairbot, 4);
            healthBuffDatabase.Add(CardIds.Collectible.Priest.VelensChosen, 4);
            healthBuffDatabase.Add(CardIds.Collectible.Druid.Wildwalker, 3);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.antimagicshell, 2);
            healthBuffDatabase.Add(CardIds.Collectible.Neutral.SunborneValkyr, 2);
            healthBuffDatabase.Add(CardIds.Collectible.Neutral.FallenSunCleric, 1);
            healthBuffDatabase.Add(CardIds.Collectible.Shaman.Cryostasis, 3);
            healthBuffDatabase.Add(CardIds.Collectible.Neutral.Bonemare, 4);

            tauntBuffDatabase.Add(CardIds.Collectible.Shaman.AncestralHealing, 1);
            tauntBuffDatabase.Add(CardIds.Collectible.Druid.DarkWispers, 1);
            tauntBuffDatabase.Add(CardIds.Collectible.Druid.MarkOfNature, 1);
            tauntBuffDatabase.Add(CardIds.Collectible.Druid.MarkOfTheWild, 1);
            tauntBuffDatabase.Add(CardIds.NonCollectible.Neutral.MutatingInjection, 1);
            tauntBuffDatabase.Add(CardIds.NonCollectible.Neutral.RustyHorn, 1);
            tauntBuffDatabase.Add(CardIds.Collectible.Warrior.SparringPartner, 1);
            tauntBuffDatabase.Add(CardIds.Collectible.Paladin.SpikeridgedSteed, 1);
        }

        private void setupCardDrawBattlecry()
        {
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Paladin.ALightInTheDarkness, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Shaman.AncestralKnowledge, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Druid.AncientOfLore, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.ancientteachings, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.ArcaneIntellect, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.ArchThiefRafaam, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.AzureDrake, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.BabblingBook, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warrior.BattleRage, 0);//only if wounded own minions or hero
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warrior.BloodWarriors, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.Burgle, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.CabalistsTome, 3);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.CallPet, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.carnassasbrood, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warlock.ChitteringTunneler, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.chooseyourpath, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.ColdlightOracle, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warrior.CommandingShout, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.Convert, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warlock.DarkPeddler, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warlock.DarkshireLibrarian, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.DesertCamel, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Paladin.DivineFavor, 0);//only if enemy has more cards than you
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.DrakonidOperative, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.EchoOfMedivh, 0);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.EliseStarseeker, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.EliteTaurenChieftain, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.EtherealConjurer, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.excessmana, 0);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.FanOfKnives, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Shaman.FarSight, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.FightPromoter, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Shaman.FindersKeepers, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.FireFly, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.FlameGeyser, 1);
            cardDrawBattleCryDatabase.Add(CardIds.NonCollectible.Neutral.Flameheart, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.Flare, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.FreeFromAmber, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.giftofcards, 1); //choice = 2
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.GnomishExperimenter, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.GnomishInventor, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.goldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.GorillabotA3, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.GrandCrusader, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.GrimestreetInformant, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.Hallucination, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Paladin.HammerOfWrath, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.HarrisonJones, 0);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.harvest, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Paladin.HolyWrath, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Paladin.Hydrologist, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warrior.IKnowAGuy, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Paladin.IvoryKnight, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.JeweledMacaw, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.JeweledScarab, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.JourneyBelow, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.KabalChemist, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.KabalCourier, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.Kazakus, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.KingMukla, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.kingsblood, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.kingsbloodtoxin, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.KingsElekk, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Paladin.LayOnHands, 3);
            cardDrawBattleCryDatabase.Add(CardIds.NonCollectible.Warlock.LifeTap, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.LockAndLoad, 0);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.LotusAgents, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Druid.LunarVisions, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.maptothegoldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Druid.MarkOfYshaarj, 0);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.MassDispel, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.megafin, 9);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.MimicPod, 2);
            cardDrawBattleCryDatabase.Add(CardIds.NonCollectible.Neutral.Mindpocalypse, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.MindVision, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warlock.MortalCoil, 0);//only if kills
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.MuklaTyrantOfTheVale, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.MuseumCurator, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.Nefarian, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Shaman.Neptulon, 4);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.NetherspiteHistorian, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Druid.Nourish, 3); //choice = 2
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.NoviceEngineer, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.PowerWordShield, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.PrimalfinLookout, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.PrimordialGlyph, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.Purify, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.QuickShot, 0);//only if your hand is empty
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Druid.RavenIdol, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.RazorpetalLasher, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.RazorpetalVolley, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.roguesdoit, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.ServantOfKalimos, 0);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.Shadowcaster, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.shadowoil, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.ShadowVisions, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warrior.ShieldBlock, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.Shiv, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warrior.Slam, 0); //if survives
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Paladin.SmallTimeRecruits, 3);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Paladin.SolemnVigil, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.soultap, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.Spellslinger, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.Sprint, 4);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.Stampede, 0);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Druid.Starfire, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.StonehillDefender, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.Swashburglar, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.TheCurator, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.ThistleTea, 3);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.Thoughtsteal, 0);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.TinkertownTechnician, 0); // If you have a Mech
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.TolvirWarden, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.TombSpider, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Druid.TortollanForager, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.TortollanPrimalist, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.Toshley, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.Tracking, 1); //NOT SUPPORTED YET
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.ungoropack, 5);
            cardDrawBattleCryDatabase.Add(CardIds.NonCollectible.Neutral.UnholyShadow, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.UnstablePortal, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warrior.VarianWrynn, 3);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.wildmagic, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Druid.Wrath, 1); //choice=2
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Druid.Wrathion, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.XarilPoisonedMind, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Druid.UltimateInfestation, 5);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Neutral.TombLurker, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.GhastlyConjurer, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.deathgrip, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Hunter.StitchedTracker, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Rogue.RollTheBones, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Shaman.IceFishing, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Paladin.HowlingCommander, 0);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Mage.FrozenClone, 1);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Warrior.ForgeOfSouls, 2);
            cardDrawBattleCryDatabase.Add(CardIds.Collectible.Priest.DevourMind, 3);

            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.AcolyteOfPain, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Rogue.Anubarak, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.BloodmageThalnos, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.ClockworkGnome, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Priest.CrystallineOracle, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.DancingSwords, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Rogue.DeadlyFork, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.NonCollectible.Neutral.Hook, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.IgneousElemental, 2);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.LootHoarder, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Paladin.MeanstreetMarshal, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.MechanicalYeti, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Druid.MechBearCat, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.PollutedHoarder, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Mage.Pyros, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Mage.Rhonin, 3);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.RunicEgg, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Priest.ShiftingShade, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Mage.ShimmeringTempest, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Warrior.TentaclesForArms, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Rogue.TombPillager, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.Toshley, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Rogue.UndercityHuckster, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Hunter.Webspinner, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Rogue.XarilPoisonedMind, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.ShallowGravedigger, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.NonCollectible.Neutral.FrozenChampion, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.BoneDrake, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Rogue.BoneBaron, 2);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Neutral.Arfus, 1);
            cardDrawDeathrattleDatabase.Add(CardIds.Collectible.Mage.GlacialMysteries, 1);
        }


        private void setupUsefulNeedKeepDatabase()
        {
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Hunter.Acidmaw, 4);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Druid.AddledGrizzly, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.AirElemental, 6);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.AlarmOBot, 4);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.AncientHarbinger, 2);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.AnimatedArmor, 12);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.ArchmageAntonidas, 7);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warrior.Armorsmith, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Druid.Aviana, 7);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.BackroomBouncer, 1);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.BloodImp, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.BrannBronzebeard, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.BurlyRockjawTrogg, 5);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Hunter.CloakedHuntress, 12);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Paladin.CobaltGuardian, 8);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.ColdarraDrake, 15);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Priest.ConfessorPaletress, 32);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.CultMaster, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.CultSorcerer, 13);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.DarkshireCouncilman, 0);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.DementedFrostcaller, 15);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Demolisher, 11);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.DireWolfAlpha, 30);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.DragonkinSorcerer, 9);
            UsefulNeedKeepDatabase.Add(CardIds.NonCollectible.Neutral.Emboldener3000, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.EmperorThaurissan, 11);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.FaerieDragon, 7);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.FallenHero, 15);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.masterchest, 48);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Druid.FandralStaghelm, 15);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.FelCannon, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.FlametongueTotem, 30);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.Flamewaker, 12);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.FlesheatingGhoul, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.FloatingWatcher, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warrior.FrothingBerserker, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.GadgetzanAuctioneer, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.GarrisonCommander, 7);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Gazlowe, 6);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Paladin.GrimestreetEnforcer, 12);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.GrimscaleOracle, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warrior.GrimyGadgeteer, 11);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Gruul, 4);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.HallazealTheAscended, 16);
            UsefulNeedKeepDatabase.Add(CardIds.NonCollectible.Shaman.HealingTotem, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Hobgoblin, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Hogger, 13);
            UsefulNeedKeepDatabase.Add(CardIds.NonCollectible.Neutral.HomingChicken, 12);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.illidanstormrage, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Illuminator, 2);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.ImpMaster, 5);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Rogue.IronSensei, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Jeeves, 0);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Junkbot, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.KabalTrafficker, 1);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Kelthuzad, 18);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.KnifeJuggler, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Kodorider, 20);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.KvaldirRaider, 12);
            UsefulNeedKeepDatabase.Add(CardIds.NonCollectible.Hunter.Leokk, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Lightwarden, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Priest.Lightwell, 13);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Priest.LyraTheSunshard, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.MaidenOfTheLake, 18);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.MalchezaarsImp, 0);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.Malganis, 13);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.ManaTideTotem, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.ManaWyrm, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.MasterSwordsmith, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Mechwarper, 11);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.MekgineerThermaplugg, 5);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.MicroMachine, 12);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Moroes, 13);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.MuklasChampion, 14);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Paladin.MurlocKnight, 16);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.MurlocTidecaller, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.MurlocWarleader, 11);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.NatPagle, 2);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.NexusChampionSaraad, 30);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Priest.NorthshireCleric, 11);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warrior.ObsidianDestroyer, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.PintSizedSummoner, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Priest.PriestOfTheFeast, 3);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.PrimalfinTotem, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Priest.ProphetVelen, 5);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.QuestingAdventurer, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Priest.RadiantElemental, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Paladin.RagnarosLightlord, 19);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.RagnarosTheFirelord, 5);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.RaidLeader, 11);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Recruiter, 15);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.RedManaWyrm, 8);
            UsefulNeedKeepDatabase.Add(CardIds.NonCollectible.Neutral.RepairBot, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.RumblingElemental, 7);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Hunter.ScavengingHyena, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Secretkeeper, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.ShadeOfNaxxramas, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Priest.Shadowboxer, 11);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Rogue.ShakuTheCollector, 25);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.ShipsCannon, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warrior.SiegeEngine, 8);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.SiltfinSpiritwalker, 5);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.SilverHandRegent, 14);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.SorcerersApprentice, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.SouthseaCaptain, 11);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.SpiritsingerUmbra, 13);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Hunter.StarvingBuzzard, 8);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.StonesplinterTrogg, 8);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.StormwindChampion, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.SummoningPortal, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.SummoningStone, 13);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.ThunderBluffValiant, 16);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Hunter.TimberWolf, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Rogue.TradePrinceGallywix, 5);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.TroggzorTheEarthinator, 4);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.TwilightElder, 9);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.Undertaker, 8);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.UsherOfSouls, 2);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.ViciousFledgling, 13);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.VioletIllusionist, 14);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.VioletTeacher, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.VitalityTotem, 8);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Paladin.WarhorseTrainer, 13);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warrior.WarsongCommander, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.WeeSpellstopper, 11);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.WickedWitchdoctor, 13);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.WilfredFizzlebang, 16);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.WindUpBurglebot, 5);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.YoungPriestess, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Priest.ShadowAscendant, 10);
            UsefulNeedKeepDatabase.Add(CardIds.NonCollectible.Neutral.Festergut, 25);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.DrakkariEnchanter, 17);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warlock.DespicableDreadlord, 14);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.CobaltScalebane, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warrior.ValkyrSoulclaimer, 10);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Rogue.RuneforgeHaunter, 1);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Warrior.Rotface, 26);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Neutral.NecroticGeist, 12);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Shaman.Moorabi, 16);
            UsefulNeedKeepDatabase.Add(CardIds.Collectible.Mage.IceWalker, 15);
        }

        private void setupDiscardCards()
        {
            cardDiscardDatabase.Add(CardIds.Collectible.Warlock.DarkBargain, 6);
            cardDiscardDatabase.Add(CardIds.Collectible.Warlock.DarkshireLibrarian, 2);
            cardDiscardDatabase.Add(CardIds.Collectible.Warlock.Doomguard, 5);
            cardDiscardDatabase.Add(CardIds.Collectible.Warlock.LakkariFelhound, 4);
            cardDiscardDatabase.Add(CardIds.Collectible.Warlock.Soulfire, 1);
            cardDiscardDatabase.Add(Chireiden.Silverfish.SimCard.succubus, 2);
        }

        private void setupDestroyOwnCards()
        {
            this.destroyOwnDatabase.Add(CardIds.Collectible.Warrior.Brawl, 0);
            this.destroyOwnDatabase.Add(CardIds.Collectible.Neutral.Deathwing, 0);
            this.destroyOwnDatabase.Add(CardIds.Collectible.Neutral.GolakkaCrawler, 0);
            this.destroyOwnDatabase.Add(CardIds.Collectible.Neutral.HungryCrab, 0);//not own mins
            this.destroyOwnDatabase.Add(CardIds.Collectible.Warrior.KingMosh, 0);
            this.destroyOwnDatabase.Add(CardIds.Collectible.Druid.Naturalize, 0);//not own mins
            this.destroyOwnDatabase.Add(CardIds.Collectible.Warlock.RavenousPterrordax, 0);
            this.destroyOwnDatabase.Add(CardIds.Collectible.Warlock.SacrificialPact, 0);//not own mins
            this.destroyOwnDatabase.Add(CardIds.Collectible.Warlock.SiphonSoul, 0);//not own mins
            this.destroyOwnDatabase.Add(CardIds.Collectible.Warlock.Shadowflame, 0);
            this.destroyOwnDatabase.Add(CardIds.Collectible.Warlock.TwistingNether, 0);
            this.destroyOwnDatabase.Add(CardIds.Collectible.Warlock.UnwillingSacrifice, 0);
            this.destroyOwnDatabase.Add(CardIds.Collectible.Warlock.SanguineReveler, 0);

            this.destroyDatabase.Add(CardIds.Collectible.Rogue.Assassinate, 0);//not own mins
            this.destroyDatabase.Add(CardIds.Collectible.Neutral.BigGameHunter, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Rogue.BladeOfCthun, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Warlock.BlastcrystalPotion, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Neutral.BookWyrm, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Warlock.Corruption, 0);//not own mins
            this.destroyDatabase.Add(CardIds.Collectible.Warrior.Crush, 0);//not own mins
            this.destroyDatabase.Add(CardIds.Collectible.Warlock.DarkBargain, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Hunter.DeadlyShot, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Warlock.Doom, 0);
            this.destroyDatabase.Add(CardIds.NonCollectible.Neutral.DrakkisathsCommand, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Paladin.EnterTheColiseum, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Warrior.Execute, 0);//not own mins
            this.destroyDatabase.Add(CardIds.Collectible.Neutral.HemetNesingwary, 0);//not own mins
            this.destroyDatabase.Add(CardIds.Collectible.Priest.MindControl, 0);//not own mins
            this.destroyDatabase.Add(CardIds.Collectible.Neutral.MoatLurker, 1);
            this.destroyDatabase.Add(CardIds.Collectible.Druid.Mulch, 0);
            this.destroyDatabase.Add(CardIds.NonCollectible.Neutral.NecroticPoison, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Neutral.RendBlackhand, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Rogue.Sabotage, 0);//not own mins
            this.destroyDatabase.Add(CardIds.Collectible.Priest.ShadowWordDeath, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Priest.ShadowWordHorror, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Priest.ShadowWordPain, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Mage.Shatter, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Neutral.TheBlackKnight, 0);//not own mins
            this.destroyDatabase.Add(CardIds.NonCollectible.Neutral.TheTrueWarchief, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Rogue.VilespineSlayer, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Warlock.VoidCrusher, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Priest.ObsidianStatue, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.obliterate, 0);
            this.destroyDatabase.Add(CardIds.Collectible.Warlock.Doompact, 0);
        }

        private void setupReturnBackToHandCards()
        {
            returnHandDatabase.Add(CardIds.Collectible.Neutral.AncientBrewmaster, 0);
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.bloodthistletoxin, 0);
            returnHandDatabase.Add(CardIds.NonCollectible.DreamCards.Dream, 0);
            returnHandDatabase.Add(CardIds.Collectible.Rogue.GadgetzanFerryman, 0);
            returnHandDatabase.Add(CardIds.Collectible.Rogue.Kidnapper, 0);//if combo
            returnHandDatabase.Add(CardIds.Collectible.Druid.Recycle, 0);
            returnHandDatabase.Add(CardIds.Collectible.Rogue.Shadowstep, 0);
            returnHandDatabase.Add(CardIds.NonCollectible.Neutral.TimeRewinder, 0);
            returnHandDatabase.Add(CardIds.Collectible.Rogue.Vanish, 0);
            returnHandDatabase.Add(CardIds.Collectible.Neutral.YouthfulBrewmaster, 0);
        }

        private void setupHeroDamagingAOE()
        {
            this.heroDamagingAoeDatabase.Add(Chireiden.Silverfish.SimCard.None, 0);
        }

        private void setupSpecialMins()
        {
            specialMinions.Add(CardIds.Collectible.Neutral.AberrantBerserker, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Abomination, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.Acidmaw, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.AcolyteOfPain, 0);
            specialMinions.Add(CardIds.Collectible.Druid.AddledGrizzly, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.AlarmOBot, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.AmaniBerserker, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.AncientHarbinger, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.AngryChicken, 0);
            specialMinions.Add(CardIds.Collectible.Mage.AnimatedArmor, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.Anubarak, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.AnubarAmbusher, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.AnubisathSentinel, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ArcaneAnomaly, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Archmage, 0);
            specialMinions.Add(CardIds.Collectible.Mage.ArchmageAntonidas, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.Armorsmith, 0);
            specialMinions.Add(CardIds.Collectible.Priest.AuchenaiSoulpriest, 0);
            specialMinions.Add(CardIds.Collectible.Druid.Aviana, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.AxeFlinger, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.AyaBlackpaw, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.AzureDrake, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BackroomBouncer, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BackstreetLeper, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BaronGeddon, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BaronRivendare, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BlackwaterPirate, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.BloodhoofBrave, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.BloodImp, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BloodmageThalnos, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BolfRamshield, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BoneguardLieutenant, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BrannBronzebeard, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.BraveArcher, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.Buccaneer, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BurglyBully, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BurlyRockjawTrogg, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.CairneBloodhoof, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Chromaggus, 0);
            specialMinions.Add(CardIds.NonCollectible.Neutral.ChromaticDragonkin, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.CloakedHuntress, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ClockworkGnome, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.CobaltGuardian, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Cogmaster, 0);
            specialMinions.Add(CardIds.Collectible.Mage.ColdarraDrake, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ColiseumManager, 0);
            specialMinions.Add(CardIds.Collectible.Priest.ConfessorPaletress, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.CrazedWorshipper, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.CrowdFavorite, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.CruelDinomancer, 0);
            specialMinions.Add(CardIds.Collectible.Priest.CrystallineOracle, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Cthun, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.CultMaster, 0);
            specialMinions.Add(CardIds.Collectible.Mage.CultSorcerer, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.Cutpurse, 0);
            specialMinions.Add(CardIds.Collectible.Mage.DalaranAspirant, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.DalaranMage, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.DancingSwords, 0);
            specialMinions.Add(CardIds.Collectible.Priest.DarkCultist, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.DarkshireCouncilman, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.DeadlyFork, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Deathlord, 0);
            specialMinions.Add(CardIds.Collectible.Mage.DementedFrostcaller, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Demolisher, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.DirehornHatchling, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.DireWolfAlpha, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.DjinniOfZephyrs, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Doomsayer, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.DragonEgg, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.DragonhawkRider, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.DragonkinSorcerer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.dreadscale, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.Dreadsteed, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Eggnapper, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.EmperorCobra, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.EmperorThaurissan, 0);
            specialMinions.Add(CardIds.Collectible.Mage.EtherealArcanist, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.EvolvedKobold, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ExplosiveSheep, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.EydisDarkbane, 0);
            specialMinions.Add(CardIds.Collectible.Mage.FallenHero, 0);
            specialMinions.Add(CardIds.Collectible.Druid.FandralStaghelm, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.FelCannon, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Feugen, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.FinjaTheFlyingStar, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.FjolaLightbane, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.FlametongueTotem, 0);
            specialMinions.Add(CardIds.Collectible.Mage.Flamewaker, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.FlesheatingGhoul, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.FloatingWatcher, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.FoeReaper4000, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.GadgetzanAuctioneer, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.Gahzrilla, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.garr, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.GarrisonCommander, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Gazlowe, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.GenzoTheShark, 0);
            specialMinions.Add(CardIds.Collectible.Druid.GiantAnaconda, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.GiantSandWorm, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.GiantWasp, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.GoblinSapper, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.GrimestreetEnforcer, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.GrimPatron, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.GrimscaleOracle, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.GrimyGadgeteer, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.GrommashHellscream, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Gruul, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.GurubashiBerserker, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.HallazealTheAscended, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.HarvestGolem, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.HauntedCreeper, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Hobgoblin, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Hogger, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.HoggerDoomOfElwynn, 0);
            specialMinions.Add(CardIds.Collectible.Priest.HolyChampion, 0);
            specialMinions.Add(CardIds.Collectible.Priest.HoodedAcolyte, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.HugeToad, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.IgneousElemental, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.illidanstormrage, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.ImpGangBoss, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ImpMaster, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.InfestedTauren, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.InfestedWolf, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.IronSensei, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.JadeSwarmer, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Jeeves, 0);
            specialMinions.Add(CardIds.Collectible.Druid.JungleMoonkin, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Junkbot, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.KabalTrafficker, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Kelthuzad, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.KindlyGrandmother, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.KnifeJuggler, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.Knuckles, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.KoboldGeomancer, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Kodorider, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.KvaldirRaider, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.LeperGnome, 0);
            specialMinions.Add(CardIds.Collectible.Priest.Lightspawn, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Lightwarden, 0);
            specialMinions.Add(CardIds.Collectible.Priest.Lightwell, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.LootHoarder, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.LorewalkerCho, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.LotusAssassin, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.LowlySquire, 0);
            specialMinions.Add(CardIds.Collectible.Priest.LyraTheSunshard, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MadScientist, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Maexxna, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.MagnataurAlpha, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MaidenOfTheLake, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MajordomoExecutus, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.MalchezaarsImp, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.Malganis, 0);
            specialMinions.Add(CardIds.Collectible.Druid.Malorne, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Malygos, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ManaAddict, 0);
            specialMinions.Add(CardIds.Collectible.Priest.ManaGeode, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.ManaTideTotem, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.manatreant, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ManaWraith, 0);
            specialMinions.Add(CardIds.Collectible.Mage.ManaWyrm, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MasterSwordsmith, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MechanicalYeti, 0);
            specialMinions.Add(CardIds.Collectible.Druid.MechBearCat, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Mechwarper, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MekgineerThermaplugg, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MicroMachine, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MimironsHead, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.mistressofpain, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Moroes, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MuklasChampion, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.MurlocKnight, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MurlocTidecaller, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MurlocWarleader, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.NatPagle, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.NerubarWeblord, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.NexusChampionSaraad, 0);
            specialMinions.Add(CardIds.Collectible.Priest.NorthshireCleric, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.ObsidianDestroyer, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.OgreMagi, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.OldMurkEye, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.OrgrimmarAspirant, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.PatientAssassin, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.PilotedShredder, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.PilotedSkyGolem, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.PintSizedSummoner, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.PitSnake, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.PossessedVillager, 0);
            specialMinions.Add(CardIds.Collectible.Priest.PriestOfTheFeast, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.PrimalfinChampion, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.PrimalfinTotem, 0);
            specialMinions.Add(CardIds.Collectible.Priest.ProphetVelen, 0);
            specialMinions.Add(CardIds.Collectible.Mage.Pyros, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.QuestingAdventurer, 0);
            specialMinions.Add(CardIds.Collectible.Priest.RadiantElemental, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.RagingWorgen, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.RagnarosLightlord, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.RaidLeader, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.RaptorHatchling, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.RatPack, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Recruiter, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.RedManaWyrm, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.RumblingElemental, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SatedThreshadon, 0);
            specialMinions.Add(CardIds.Collectible.Druid.SavageCombatant, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.SavannahHighmane, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ScaledNightmare, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.ScavengingHyena, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Secretkeeper, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.SelflessHero, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SergeantSally, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ShadeOfNaxxramas, 0);
            specialMinions.Add(CardIds.Collectible.Priest.Shadowboxer, 0);
            specialMinions.Add(CardIds.Collectible.Priest.Shadowfiend, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.ShakuTheCollector, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.SherazinCorpseFlower, 0);
            specialMinions.Add(CardIds.Collectible.Priest.ShiftingShade, 0);
            specialMinions.Add(CardIds.Collectible.Mage.ShimmeringTempest, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ShipsCannon, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.SiltfinSpiritwalker, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SilverHandRegent, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SmallTimeBuccaneer, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SneedsOldShredder, 0);
            specialMinions.Add(CardIds.Collectible.Mage.Snowchugger, 0);
            specialMinions.Add(CardIds.Collectible.Mage.SorcerersApprentice, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SouthseaCaptain, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.SouthseaSquidface, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SpawnOfNzoth, 0);
            specialMinions.Add(CardIds.Collectible.Priest.SpawnOfShadows, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SpiritsingerUmbra, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SpitefulSmith, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Stalagg, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.StarvingBuzzard, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.SteamwheedleSniper, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.StewardOfDarkshire, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.StonesplinterTrogg, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.StormwindChampion, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.SummoningPortal, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SummoningStone, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.SylvanasWindrunner, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TarCreeper, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.TarLord, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.TarLurker, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TaurenWarrior, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TentacleOfNzoth, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TheBeast, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TheBoogeymonster, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TheVoraxx, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.ThunderBluffValiant, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.TimberWolf, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.TinyKnightOfEvil, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.TirionFordring, 0);
            specialMinions.Add(CardIds.Collectible.Priest.TortollanShellraiser, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Toshley, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TournamentMedic, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.TradePrinceGallywix, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TroggzorTheEarthinator, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.TundraRhino, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.TunnelTrogg, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TwilightElder, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TwilightSummoner, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.UnboundElemental, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.UndercityHuckster, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Undertaker, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.UnstableGhoul, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.UsherOfSouls, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ViciousFledgling, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.VioletIllusionist, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.VioletTeacher, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.VitalityTotem, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.Voidcaller, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.VoidCrusher, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.VolatileElemental, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.Warbot, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.WarhorseTrainer, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.WarsongCommander, 0);
            specialMinions.Add(CardIds.Collectible.Mage.WaterElemental, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.VoodooHexxer, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.Webspinner, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.WhiteEyes, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.WickedWitchdoctor, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.WickerflameBurnbristle, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.WilfredFizzlebang, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.WindUpBurglebot, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.WobblingRunts, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.XarilPoisonedMind, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Ysera, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.YshaarjRageUnbound, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ZealousInitiate, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Vryghoul, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.TheLichKing, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Skelemancer, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.ShallowGravedigger, 0);
            specialMinions.Add(CardIds.Collectible.Priest.ShadowAscendant, 0);
            specialMinions.Add(CardIds.Collectible.Priest.ObsidianStatue, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.MountainfireArmor, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.MeatWagon, 0);
            specialMinions.Add(CardIds.Collectible.Druid.Hadronox, 0);
            specialMinions.Add(CardIds.NonCollectible.Neutral.Festergut, 0);
            specialMinions.Add(CardIds.Collectible.Druid.Fatespinner, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.ExplodingBloatbat, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.DrakkariEnchanter, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.DespicableDreadlord, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.DeadscaleKnight, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.CobaltScalebane, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.ChillbladeChampion, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.BoneDrake, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.BoneBaron, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Bloodworm, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.BloodQueenLanathel, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.Blackguard, 0);
            specialMinions.Add(CardIds.Collectible.Paladin.ArrogantCrusader, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Arfus, 0);
            specialMinions.Add(CardIds.Collectible.Priest.AcolyteOfAgony, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.AbominableBowman, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Venomancer, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.ValkyrSoulclaimer, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.StubbornGastropod, 0);
            specialMinions.Add(CardIds.Collectible.Rogue.RuneforgeHaunter, 0);
            specialMinions.Add(CardIds.Collectible.Warrior.Rotface, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.ProfessorPutricide, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.NightHowler, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.NerubianUnraveler, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.NecroticGeist, 0);
            specialMinions.Add(CardIds.Collectible.Shaman.Moorabi, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.Mindbreaker, 0);
            specialMinions.Add(CardIds.Collectible.Mage.IceWalker, 0);
            specialMinions.Add(CardIds.Collectible.Neutral.GraveShambler, 0);
            specialMinions.Add(CardIds.Collectible.Warlock.Doomedapprentice, 0);
            specialMinions.Add(CardIds.Collectible.Druid.CryptLord, 0);
            specialMinions.Add(CardIds.Collectible.Hunter.CorpseWidow, 0);
        }

        private void setupOwnSummonFromDeathrattle()
        {
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Rogue.Anubarak, -10);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.AyaBlackpaw, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.CairneBloodhoof, 5);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Warlock.CruelDinomancer, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.DevilsaurEgg, -20);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Warlock.Dreadsteed, -1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.Eggnapper, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Druid.GiantAnaconda, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.HarvestGolem, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.HauntedCreeper, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.InfestedTauren, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Hunter.InfestedWolf, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Rogue.JadeSwarmer, -1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Hunter.KindlyGrandmother, -10);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.moirabronzebeard, 3);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Druid.MountedRaptor, 3);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.NerubianEgg, -16);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.PilotedShredder, 4);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.PilotedSkyGolem, 4);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Warlock.PossessedVillager, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Hunter.RatPack, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.SatedThreshadon, 1);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Hunter.SavannahHighmane, 8);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.SludgeBelcher, 10);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.SneedsOldShredder, 5);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.TwilightSummoner, -14);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Shaman.WhiteEyes, -10);
            ownSummonFromDeathrattle.Add(CardIds.Collectible.Neutral.WobblingRunts, 1);
            ownSummonFromDeathrattle.Add(CardIds.NonCollectible.Neutral.FrozenChampion, -12);
        }

        private void setupBuffingMinions()
        {
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.AbusiveSergeant, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.BeckonerOfEvil, 10);
            buffingMinionsDatabase.Add(CardIds.Collectible.Rogue.BladeOfCthun, 10);
            buffingMinionsDatabase.Add(CardIds.Collectible.Warrior.BloodsailCultist, 5);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.CaptainGreenskin, 5);
            buffingMinionsDatabase.Add(CardIds.Collectible.Druid.Cenarius, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.ClockworkKnight, 2);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.ColdlightSeer, 3);
            buffingMinionsDatabase.Add(CardIds.Collectible.Warrior.CruelTaskmaster, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.Cthunschosen, 10);
            buffingMinionsDatabase.Add(CardIds.Collectible.Mage.CultSorcerer, 10);
            buffingMinionsDatabase.Add(CardIds.Collectible.Druid.DarkArakkoa, 10);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.DarkIronDwarf, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.DefenderOfArgus, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.DireWolfAlpha, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.DiscipleOfCthun, 10);
            buffingMinionsDatabase.Add(CardIds.Collectible.Warlock.Doomcaller, 10);
            buffingMinionsDatabase.Add(CardIds.Collectible.Shaman.FlametongueTotem, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Rogue.GoblinAutoBarber, 5);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.GrimscaleOracle, 3);
            buffingMinionsDatabase.Add(CardIds.Collectible.Priest.HoodedAcolyte, 10);
            buffingMinionsDatabase.Add(CardIds.Collectible.Hunter.Houndmaster, 1);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.LanceCarrier, 0);
            buffingMinionsDatabase.Add(CardIds.NonCollectible.Hunter.Leokk, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Warlock.Malganis, 8);
            buffingMinionsDatabase.Add(CardIds.Collectible.Hunter.MetaltoothLeaper, 2);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.MurlocWarleader, 3);
            buffingMinionsDatabase.Add(CardIds.Collectible.Paladin.Quartermaster, 6);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.RaidLeader, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Warrior.ScrewjankClunker, 2);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.ShatteredSunCleric, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.SkeramCultist, 10);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.SouthseaCaptain, 4);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.SpitefulSmith, 5);
            buffingMinionsDatabase.Add(CardIds.Collectible.Neutral.StormwindChampion, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Priest.TempleEnforcer, 0);
            buffingMinionsDatabase.Add(CardIds.Collectible.Shaman.ThunderBluffValiant, 9);
            buffingMinionsDatabase.Add(CardIds.Collectible.Hunter.TimberWolf, 1);
            buffingMinionsDatabase.Add(CardIds.Collectible.Warrior.Upgradedrepairbot, 2);
            buffingMinionsDatabase.Add(CardIds.Collectible.Warlock.UsherOfSouls, 10);
            buffingMinionsDatabase.Add(CardIds.Collectible.Paladin.WarhorseTrainer, 6);
            buffingMinionsDatabase.Add(CardIds.Collectible.Warrior.WarsongCommander, 7);
            buffingMinionsDatabase.Add(CardIds.NonCollectible.Neutral.Worshipper, 0);

            buffing1TurnDatabase.Add(CardIds.Collectible.Neutral.AbusiveSergeant, 0);
            buffing1TurnDatabase.Add(CardIds.Collectible.Shaman.Bloodlust, 3);
            buffing1TurnDatabase.Add(CardIds.Collectible.Neutral.DarkIronDwarf, 0);
            buffing1TurnDatabase.Add(CardIds.Collectible.Shaman.RockbiterWeapon, 0);
            buffing1TurnDatabase.Add(CardIds.NonCollectible.Neutral.Worshipper, 0);
        }

        private void setupEnemyTargetPriority()
        {
            priorityTargets.Add(CardIds.Collectible.Hunter.Acidmaw, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.AcolyteOfPain, 10);
            priorityTargets.Add(CardIds.Collectible.Druid.AddledGrizzly, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.AlarmOBot, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.AngryChicken, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.AnimatedArmor, 10);
            priorityTargets.Add(CardIds.Collectible.Rogue.Anubarak, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.AnubisathSentinel, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.ArchmageAntonidas, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.AuchenaiSoulpriest, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.AuctionmasterBeardo, 10);
            priorityTargets.Add(CardIds.Collectible.Druid.Aviana, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.AyaBlackpaw, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.BackroomBouncer, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.BaronGeddon, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.BaronRivendare, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.BloodmageThalnos, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.BoneguardLieutenant, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.BrannBronzebeard, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.BurglyBully, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Chromaggus, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.CloakedHuntress, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.ColdarraDrake, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.ConfessorPaletress, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.CrowdFavorite, 10);
            priorityTargets.Add(CardIds.Collectible.Warlock.CruelDinomancer, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.CrystallineOracle, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Cthun, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.CultMaster, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.CultSorcerer, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.DalaranAspirant, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.DaringReporter, 10);
            priorityTargets.Add(CardIds.Collectible.Warlock.DarkshireCouncilman, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.DementedFrostcaller, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Demolisher, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.DevilsaurEgg, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.NerubianEgg, 10);
            priorityTargets.Add(CardIds.Collectible.Warrior.DirehornHatchling, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.DireWolfAlpha, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.DjinniOfZephyrs, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Doomsayer, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.DragonEgg, 0);
            priorityTargets.Add(CardIds.Collectible.Neutral.DragonhawkRider, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.DragonkinSorcerer, 4);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.dreadscale, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.DustDevil, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Eggnapper, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.EmperorThaurissan, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.EtherealArcanist, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.EydisDarkbane, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.FallenHero, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.masterchest, 10);
            priorityTargets.Add(CardIds.Collectible.Druid.FandralStaghelm, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.FinjaTheFlyingStar, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.FlametongueTotem, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.Flamewaker, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.FlesheatingGhoul, 10);
            priorityTargets.Add(CardIds.Collectible.Warlock.FloatingWatcher, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.FoeReaper4000, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.FriendlyBartender, 10);
            priorityTargets.Add(CardIds.Collectible.Warrior.FrothingBerserker, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.GadgetzanAuctioneer, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.Gahzrilla, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.garr, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.GarrisonCommander, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.GenzoTheShark, 10);
            priorityTargets.Add(CardIds.Collectible.Druid.GiantAnaconda, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.GiantSandWorm, 10);
            priorityTargets.Add(CardIds.Collectible.Paladin.GrimestreetEnforcer, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.GrimPatron, 10);
            priorityTargets.Add(CardIds.Collectible.Warrior.GrimyGadgeteer, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.GurubashiBerserker, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Hobgoblin, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Hogger, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.HoggerDoomOfElwynn, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.HolyChampion, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.HoodedAcolyte, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.IgneousElemental, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.illidanstormrage, 10);
            priorityTargets.Add(CardIds.Collectible.Warlock.ImpGangBoss, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.ImpMaster, 10);
            priorityTargets.Add(CardIds.Collectible.Rogue.IronSensei, 10);
            priorityTargets.Add(CardIds.Collectible.Druid.JungleMoonkin, 10);
            priorityTargets.Add(CardIds.Collectible.Warlock.KabalTrafficker, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Kelthuzad, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.KnifeJuggler, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.Knuckles, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.KoboldGeomancer, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Kodorider, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.KvaldirRaider, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.LeeroyJenkins, 10);
            priorityTargets.Add(CardIds.NonCollectible.Hunter.Leokk, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Lightwarden, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.Lightwell, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.LowlySquire, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.LyraTheSunshard, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Maexxna, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.MaidenOfTheLake, 10);
            priorityTargets.Add(CardIds.Collectible.Warlock.MalchezaarsImp, 10);
            priorityTargets.Add(CardIds.Collectible.Warlock.Malganis, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Malygos, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.ManaAddict, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.ManaTideTotem, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.manatreant, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.ManaWyrm, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.MasterSwordsmith, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Mechwarper, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.MicroMachine, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.MogorTheOgre, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Moroes, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.MuklasChampion, 10);
            priorityTargets.Add(CardIds.Collectible.Paladin.MurlocKnight, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.NatPagle, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.NerubarWeblord, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.NexusChampionSaraad, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.NorthshireCleric, 10);
            priorityTargets.Add(CardIds.Collectible.Warrior.ObsidianDestroyer, 10);
            priorityTargets.Add(CardIds.Collectible.Warrior.OrgrimmarAspirant, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.PintSizedSummoner, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.PriestOfTheFeast, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.PrimalfinTotem, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.ProphetVelen, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.Pyros, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.QuestingAdventurer, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.RadiantElemental, 10);
            priorityTargets.Add(CardIds.Collectible.Paladin.RagnarosLightlord, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.RaidLeader, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.RaptorHatchling, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Recruiter, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.RedManaWyrm, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.Rhonin, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.RumblingElemental, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.SatedThreshadon, 10);
            priorityTargets.Add(CardIds.Collectible.Druid.SavageCombatant, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.ScaledNightmare, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.ScavengingHyena, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Secretkeeper, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.ShadeOfNaxxramas, 10);
            priorityTargets.Add(CardIds.Collectible.Rogue.ShakuTheCollector, 10);
            priorityTargets.Add(CardIds.Collectible.Rogue.SherazinCorpseFlower, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.ShimmeringTempest, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.SilverHandRegent, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.SorcerersApprentice, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.SpiritsingerUmbra, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.StarvingBuzzard, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.SteamwheedleSniper, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.StormwindChampion, 10);
            priorityTargets.Add(CardIds.Collectible.Warlock.SummoningPortal, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.SummoningStone, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.TheBoogeymonster, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.TheVoraxx, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.ThrallmarFarseer, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.ThunderBluffValiant, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.TimberWolf, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.TroggzorTheEarthinator, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.TundraRhino, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.TunnelTrogg, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.TwilightSummoner, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.UnboundElemental, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.Undertaker, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.ViciousFledgling, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.VioletIllusionist, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.VioletTeacher, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.VitalityTotem, 10);
            priorityTargets.Add(CardIds.Collectible.Paladin.WarhorseTrainer, 10);
            priorityTargets.Add(CardIds.Collectible.Warrior.WarsongCommander, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.WhiteEyes, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.WickedWitchdoctor, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.WildPyromancer, 10);
            priorityTargets.Add(CardIds.Collectible.Warlock.WilfredFizzlebang, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.WindUpBurglebot, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.YoungDragonhawk, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.YshaarjRageUnbound, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.TheLichKing, 10);
            priorityTargets.Add(CardIds.Collectible.Priest.ObsidianStatue, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.moirabronzebeard, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.highjusticegrimstone, 10);
            priorityTargets.Add(CardIds.Collectible.Druid.Hadronox, 10);
            priorityTargets.Add(CardIds.NonCollectible.Neutral.Festergut, 10);
            priorityTargets.Add(CardIds.Collectible.Warlock.DespicableDreadlord, 10);
            priorityTargets.Add(CardIds.Collectible.Warrior.Rotface, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.ProfessorPutricide, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.NightHowler, 10);
            priorityTargets.Add(CardIds.Collectible.Neutral.NecroticGeist, 10);
            priorityTargets.Add(CardIds.Collectible.Shaman.Moorabi, 10);
            priorityTargets.Add(CardIds.Collectible.Mage.IceWalker, 10);
            priorityTargets.Add(CardIds.Collectible.Druid.CryptLord, 10);
            priorityTargets.Add(CardIds.Collectible.Hunter.CorpseWidow, 10);
        }

        private void setupLethalHelpMinions()
        {
            //spellpower minions
            lethalHelpers.Add(CardIds.Collectible.Neutral.AncientMage, 0);
            lethalHelpers.Add(CardIds.NonCollectible.Neutral.Arcanotron, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.Archmage, 0);
            lethalHelpers.Add(CardIds.Collectible.Priest.AuchenaiSoulpriest, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.AzureDrake, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.BloodmageThalnos, 0);
            lethalHelpers.Add(CardIds.Collectible.Mage.CultSorcerer, 0);
            lethalHelpers.Add(CardIds.Collectible.Mage.DalaranAspirant, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.DalaranMage, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.EvolvedKobold, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.FrigidSnobold, 0);
            lethalHelpers.Add(CardIds.Collectible.Druid.JungleMoonkin, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.KoboldGeomancer, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.Malygos, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.MiniMage, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.OgreMagi, 0);
            lethalHelpers.Add(CardIds.Collectible.Priest.ProphetVelen, 0);
            lethalHelpers.Add(CardIds.Collectible.Mage.SootSpewer, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.StreetTrickster, 0);
            lethalHelpers.Add(CardIds.Collectible.Druid.Wrathofairtotem, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.TuskarrFisherman, 0);
            lethalHelpers.Add(CardIds.Collectible.Neutral.TaintedZealot, 1);
            lethalHelpers.Add(CardIds.Collectible.Neutral.Spellweaver, 2);
        }

        private void setupRelations()
        {
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.ArcaneAnomaly, 1);
            spellDependentDatabase.Add(CardIds.Collectible.Mage.ArchmageAntonidas, 2);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.BurglyBully, -1);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.BurlyRockjawTrogg, -1);
            spellDependentDatabase.Add(CardIds.NonCollectible.Neutral.ChromaticDragonkin, -1);
            spellDependentDatabase.Add(CardIds.Collectible.Mage.CultSorcerer, 1);
            spellDependentDatabase.Add(CardIds.Collectible.Mage.DementedFrostcaller, 1);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.DjinniOfZephyrs, 1);
            spellDependentDatabase.Add(CardIds.Collectible.Mage.Flamewaker, 1);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.GadgetzanAuctioneer, 2);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.Gazlowe, 2);
            spellDependentDatabase.Add(CardIds.Collectible.Shaman.HallazealTheAscended, 1);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.LorewalkerCho, 0);
            spellDependentDatabase.Add(CardIds.Collectible.Priest.LyraTheSunshard, 2);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.ManaAddict, 1);
            spellDependentDatabase.Add(CardIds.Collectible.Mage.ManaWyrm, 1);
            spellDependentDatabase.Add(CardIds.Collectible.Priest.PriestOfTheFeast, 1);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.RedManaWyrm, 1);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.StonesplinterTrogg, -1);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.SummoningStone, 3);
            spellDependentDatabase.Add(CardIds.Collectible.Rogue.TradePrinceGallywix, -1);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.TroggzorTheEarthinator, -2);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.VioletTeacher, 3);
            spellDependentDatabase.Add(CardIds.Collectible.Shaman.WickedWitchdoctor, 3);
            spellDependentDatabase.Add(CardIds.Collectible.Neutral.WildPyromancer, 1);

            dragonDependentDatabase.Add(CardIds.Collectible.Warrior.AlexstraszasChampion, 1);
            dragonDependentDatabase.Add(CardIds.Collectible.Neutral.BlackwingCorruptor, 1);
            dragonDependentDatabase.Add(CardIds.Collectible.Neutral.BlackwingTechnician, 1);
            dragonDependentDatabase.Add(CardIds.Collectible.Neutral.BookWyrm, 1);
            dragonDependentDatabase.Add(CardIds.Collectible.Priest.DrakonidOperative, 1);
            dragonDependentDatabase.Add(CardIds.Collectible.Neutral.NetherspiteHistorian, 1);
            dragonDependentDatabase.Add(CardIds.Collectible.Paladin.NightbaneTemplar, 1);
            dragonDependentDatabase.Add(CardIds.Collectible.Neutral.RendBlackhand, 1);
            dragonDependentDatabase.Add(CardIds.Collectible.Neutral.TwilightGuardian, 1);
            dragonDependentDatabase.Add(CardIds.Collectible.Priest.TwilightWhelp, 1);
            dragonDependentDatabase.Add(CardIds.Collectible.Priest.WyrmrestAgent, 1);

            elementalLTDependentDatabase.Add(CardIds.Collectible.Neutral.Blazecaller, 1);
            elementalLTDependentDatabase.Add(CardIds.Collectible.Shaman.KalimosPrimalLord, 1);
            elementalLTDependentDatabase.Add(CardIds.Collectible.Neutral.Ozruk, 1);
            elementalLTDependentDatabase.Add(CardIds.Collectible.Neutral.ServantOfKalimos, 1);
            elementalLTDependentDatabase.Add(CardIds.Collectible.Mage.SteamSurger, 1);
            elementalLTDependentDatabase.Add(CardIds.Collectible.Shaman.StoneSentinel, 1);
            elementalLTDependentDatabase.Add(CardIds.Collectible.Neutral.ThunderLizard, 1);
            elementalLTDependentDatabase.Add(CardIds.Collectible.Neutral.TolvirStoneshaper, 1);
        }

        private void setupSilenceTargets()
        {
            silenceTargets.Add(CardIds.Collectible.Neutral.Abomination, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.Acidmaw, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.AcolyteOfPain, 0);
            silenceTargets.Add(CardIds.Collectible.Druid.AddledGrizzly, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.AncientHarbinger, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.AnimatedArmor, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.Anomalus, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.Anubarak, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.AnubisathSentinel, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.ArchmageAntonidas, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.Armorsmith, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.AuchenaiSoulpriest, 0);
            silenceTargets.Add(CardIds.Collectible.Druid.Aviana, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.AxeFlinger, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.AyaBlackpaw, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.BackroomBouncer, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.BaronGeddon, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.BaronRivendare, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.BlackwaterPirate, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.BloodImp, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.BlubberBaron, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.BolvarFordragon, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.BoneguardLieutenant, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.BrannBronzebeard, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.BraveArcher, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.BurlyRockjawTrogg, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.CairneBloodhoof, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Chillmaw, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Chromaggus, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.CobaltGuardian, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.ColdarraDrake, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ColiseumManager, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.ConfessorPaletress, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.CrazedWorshipper, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.CrowdFavorite, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.CruelDinomancer, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.CrystallineOracle, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Cthun, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.CultMaster, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.CultSorcerer, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.DalaranAspirant, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.DarkCultist, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.DarkshireCouncilman, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.DementedFrostcaller, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.DevilsaurEgg, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.NerubianEgg, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.DirehornHatchling, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.DireWolfAlpha, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.DjinniOfZephyrs, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Doomsayer, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.DragonEgg, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.DragonhawkRider, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.DragonkinSorcerer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.dreadscale, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Eggnapper, 0);
            silenceTargets.Add(CardIds.NonCollectible.Neutral.Emboldener3000, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.EmperorCobra, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.EmperorThaurissan, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.EtherealArcanist, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.EvolvedKobold, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ExplosiveSheep, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.EydisDarkbane, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.FallenHero, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.masterchest, 0);
            silenceTargets.Add(CardIds.Collectible.Druid.FandralStaghelm, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Feugen, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.FinjaTheFlyingStar, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.FjolaLightbane, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.FlametongueTotem, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.Flamewaker, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.FlesheatingGhoul, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.FloatingWatcher, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.FoeReaper4000, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.FrothingBerserker, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.GadgetzanAuctioneer, 10);
            silenceTargets.Add(CardIds.Collectible.Hunter.Gahzrilla, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.garr, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.GarrisonCommander, 0);
            silenceTargets.Add(CardIds.Collectible.Druid.GiantAnaconda, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.GiantSandWorm, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.GiantWasp, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.GrimestreetEnforcer, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.GrimPatron, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.GrimscaleOracle, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.GrimyGadgeteer, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.GrommashHellscream, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Gruul, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.GurubashiBerserker, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.HallazealTheAscended, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.HauntedCreeper, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Hobgoblin, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Hogger, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.HoggerDoomOfElwynn, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.HolyChampion, 0);
            silenceTargets.Add(CardIds.NonCollectible.Neutral.HomingChicken, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.HoodedAcolyte, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.IgneousElemental, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.illidanstormrage, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.ImpGangBoss, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ImpMaster, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.IronSensei, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.JadeSwarmer, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Jeeves, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Junkbot, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.KabalTrafficker, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Kelthuzad, 10);
            silenceTargets.Add(CardIds.Collectible.Hunter.KindlyGrandmother, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.KnifeJuggler, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.Knuckles, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Kodorider, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.KvaldirRaider, 0);
            silenceTargets.Add(CardIds.NonCollectible.Hunter.Leokk, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.Lightspawn, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Lightwarden, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.Lightwell, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.LorewalkerCho, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.LowlySquire, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.LyraTheSunshard, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MadScientist, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Maexxna, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.MagnataurAlpha, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MaidenOfTheLake, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MajordomoExecutus, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.Malganis, 0);
            silenceTargets.Add(CardIds.Collectible.Druid.Malorne, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Malygos, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ManaAddict, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.ManaGeode, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.ManaTideTotem, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.manatreant, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ManaWraith, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.ManaWyrm, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MasterSwordsmith, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MekgineerThermaplugg, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MicroMachine, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MogorTheOgre, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MuklasChampion, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.MurlocKnight, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MurlocTidecaller, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MurlocWarleader, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.NatPagle, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.NerubarWeblord, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.NexusChampionSaraad, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.NorthshireCleric, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.ObsidianDestroyer, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.OldMurkEye, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.OneEyedCheat, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.OrgrimmarAspirant, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.PilotedSkyGolem, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.PitSnake, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.PrimalfinChampion, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.PrimalfinTotem, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.ProphetVelen, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.Pyros, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.QuestingAdventurer, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.RadiantElemental, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.RagingWorgen, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.RaidLeader, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.RaptorHatchling, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.RatPack, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Recruiter, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.RedManaWyrm, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.Rhonin, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.RumblingElemental, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.SatedThreshadon, 0);
            silenceTargets.Add(CardIds.Collectible.Druid.SavageCombatant, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.SavannahHighmane, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ScaledNightmare, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.ScavengingHyena, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Secretkeeper, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.SelflessHero, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.SergeantSally, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ShadeOfNaxxramas, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.Shadowboxer, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.ShakuTheCollector, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.SherazinCorpseFlower, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.ShiftingShade, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.ShimmeringTempest, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ShipsCannon, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.SiegeEngine, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.SiltfinSpiritwalker, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.SilverHandRegent, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.SneedsOldShredder, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.SorcerersApprentice, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.SouthseaCaptain, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.SouthseaSquidface, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.SpawnOfNzoth, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.SpawnOfShadows, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.SpiritsingerUmbra, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.SpitefulSmith, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Stalagg, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.StarvingBuzzard, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.SteamwheedleSniper, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.StewardOfDarkshire, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.StonesplinterTrogg, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.StormwindChampion, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.SummoningPortal, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.SummoningStone, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.SylvanasWindrunner, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.TarCreeper, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.TarLord, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.TarLurker, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.TheBoogeymonster, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.TheSkeletonKnight, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.TheVoraxx, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.ThunderBluffValiant, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.TimberWolf, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.TirionFordring, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.TortollanShellraiser, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.TournamentMedic, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.TradePrinceGallywix, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.TroggzorTheEarthinator, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.TundraRhino, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.TwilightElder, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.TwilightSummoner, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.UnboundElemental, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.UndercityHuckster, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Undertaker, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.UsherOfSouls, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.v07tr0n, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ViciousFledgling, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.VioletIllusionist, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.VioletTeacher, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.VitalityTotem, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.VoidCrusher, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.VolatileElemental, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.WarhorseTrainer, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.WarsongCommander, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.Webspinner, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.WhiteEyes, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.WickedWitchdoctor, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.WilfredFizzlebang, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.WindUpBurglebot, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.WobblingRunts, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.YoungPriestess, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Ysera, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.YshaarjRageUnbound, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ZealousInitiate, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Vryghoul, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.TheLichKing, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Skelemancer, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.ShallowGravedigger, 0);
            silenceTargets.Add(CardIds.Collectible.Priest.ShadowAscendant, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.moirabronzebeard, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.MeatWagon, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.highjusticegrimstone, 0);
            silenceTargets.Add(CardIds.Collectible.Druid.Hadronox, 0);
            silenceTargets.Add(CardIds.NonCollectible.Neutral.FrozenChampion, 0);
            silenceTargets.Add(CardIds.NonCollectible.Neutral.Festergut, 0);
            silenceTargets.Add(CardIds.Collectible.Druid.Fatespinner, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.ExplodingBloatbat, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.DrakkariEnchanter, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.DespicableDreadlord, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.CobaltScalebane, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.BoneDrake, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.BoneBaron, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.Blackguard, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.ArrogantCrusader, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Arfus, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.AbominableBowman, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.VoodooHexxer, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.Venomancer, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.ValkyrSoulclaimer, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.StubbornGastropod, 0);
            silenceTargets.Add(CardIds.Collectible.Rogue.RuneforgeHaunter, 0);
            silenceTargets.Add(CardIds.Collectible.Warrior.Rotface, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.ProfessorPutricide, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.NightHowler, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.NerubianUnraveler, 0);
            silenceTargets.Add(CardIds.Collectible.Neutral.NecroticGeist, 0);
            silenceTargets.Add(CardIds.Collectible.Shaman.Moorabi, 0);
            silenceTargets.Add(CardIds.Collectible.Mage.IceWalker, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.Doomedapprentice, 0);
            silenceTargets.Add(CardIds.Collectible.Druid.CryptLord, 0);
            silenceTargets.Add(CardIds.Collectible.Hunter.CorpseWidow, 0);
            silenceTargets.Add(CardIds.Collectible.Paladin.BolvarFireblood, 0);
            silenceTargets.Add(CardIds.Collectible.Warlock.BloodQueenLanathel, 0);
        }

        private void setupRandomCards()
        {
            randomEffects.Add(CardIds.Collectible.Paladin.ALightInTheDarkness, 1);
            randomEffects.Add(CardIds.Collectible.Shaman.AncestorsCall, 1);
            randomEffects.Add(CardIds.Collectible.Hunter.AnimalCompanion, 1);
            randomEffects.Add(CardIds.Collectible.Mage.ArcaneMissiles, 3);
            randomEffects.Add(CardIds.Collectible.Neutral.ArchThiefRafaam, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.ArmoredWarhorse, 1);
            randomEffects.Add(CardIds.Collectible.Paladin.AvengingWrath, 8);
            randomEffects.Add(CardIds.Collectible.Mage.BabblingBook, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.Barnes, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.BombLobber, 1);
            randomEffects.Add(CardIds.Collectible.Warrior.BouncingBlade, 3);
            randomEffects.Add(CardIds.Collectible.Warrior.Brawl, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.CaptainsParrot, 1);
            randomEffects.Add(CardIds.Collectible.Warlock.ChitteringTunneler, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.chooseyourpath, 1);
            randomEffects.Add(CardIds.Collectible.Warrior.Cleave, 2);
            randomEffects.Add(CardIds.Collectible.Paladin.Coghammer, 1);
            randomEffects.Add(CardIds.Collectible.Shaman.Crackle, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.Cthun, 10);
            randomEffects.Add(CardIds.Collectible.Warlock.DarkBargain, 2);
            randomEffects.Add(CardIds.Collectible.Warlock.DarkPeddler, 1);
            randomEffects.Add(CardIds.Collectible.Hunter.DeadlyShot, 1);
            randomEffects.Add(CardIds.Collectible.Hunter.DesertCamel, 1);
            randomEffects.Add(CardIds.Collectible.Shaman.ElementalDestruction, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.EliteTaurenChieftain, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.EnhanceOMechano, 1);
            randomEffects.Add(CardIds.Collectible.Mage.EtherealConjurer, 1);
            randomEffects.Add(CardIds.Collectible.Hunter.FieryBat, 1);
            randomEffects.Add(CardIds.Collectible.Shaman.FindersKeepers, 1);
            randomEffects.Add(CardIds.Collectible.Mage.FirelandsPortal, 1);
            randomEffects.Add(CardIds.Collectible.Mage.Flamecannon, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.FlameJuggler, 1);
            randomEffects.Add(CardIds.Collectible.Mage.Flamewaker, 2);
            randomEffects.Add(CardIds.Collectible.Shaman.ForkedLightning, 1);
            randomEffects.Add(CardIds.Collectible.Priest.FreeFromAmber, 1);
            randomEffects.Add(CardIds.NonCollectible.Neutral.ZarogsCrown, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.GelbinMekkatorque, 1);
            randomEffects.Add(CardIds.Collectible.Hunter.Glaivezooka, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.GrandCrusader, 1);
            randomEffects.Add(CardIds.Collectible.Mage.GreaterArcaneMissiles, 3);
            randomEffects.Add(CardIds.Collectible.Neutral.GrimestreetInformant, 1);
            randomEffects.Add(CardIds.Collectible.Rogue.Hallucination, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.harvest, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.HungryDragon, 1);
            randomEffects.Add(CardIds.Collectible.Paladin.Hydrologist, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.iammurloc, 3);
            randomEffects.Add(CardIds.Collectible.Warrior.IKnowAGuy, 1);
            randomEffects.Add(CardIds.Collectible.Warrior.IronforgePortal, 1);
            randomEffects.Add(CardIds.Collectible.Paladin.IvoryKnight, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.JeweledScarab, 1);
            randomEffects.Add(CardIds.Collectible.Rogue.JourneyBelow, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.KabalChemist, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.KabalCourier, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.Kazakus, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.kingsblood, 1);
            randomEffects.Add(CardIds.NonCollectible.Warlock.LifeTap, 1);
            randomEffects.Add(CardIds.Collectible.Shaman.LightningStorm, 1);
            randomEffects.Add(CardIds.Collectible.Hunter.LockAndLoad, 10);
            randomEffects.Add(CardIds.Collectible.Neutral.LotusAgents, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.MadBomber, 3);
            randomEffects.Add(CardIds.Collectible.Neutral.MadderBomber, 1);
            randomEffects.Add(CardIds.Collectible.Shaman.MaelstromPortal, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.MasterJouster, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.MenagerieMagician, 0);
            randomEffects.Add(CardIds.Collectible.Priest.MindControltech, 1);
            randomEffects.Add(CardIds.Collectible.Priest.Mindgames, 1);
            randomEffects.Add(CardIds.Collectible.Priest.MindVision, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.MogorsChampion, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.MogorTheOgre, 1);
            randomEffects.Add(CardIds.Collectible.Druid.MoongladePortal, 1);
            randomEffects.Add(CardIds.Collectible.Hunter.MultiShot, 2);
            randomEffects.Add(CardIds.Collectible.Priest.MuseumCurator, 1);
            randomEffects.Add(CardIds.Collectible.Paladin.MysteriousChallenger, 2);
            randomEffects.Add(CardIds.NonCollectible.Neutral.PileOn, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.powerofthehorde, 1);
            randomEffects.Add(CardIds.Collectible.Mage.PrimordialGlyph, 1);
            randomEffects.Add(CardIds.Collectible.Hunter.RamWrangler, 1);
            randomEffects.Add(CardIds.Collectible.Druid.RavenIdol, 1);
            randomEffects.Add(CardIds.Collectible.Priest.Resurrect, 1);
            randomEffects.Add(CardIds.Collectible.Rogue.Sabotage, 0);
            randomEffects.Add(CardIds.Collectible.Warlock.SenseDemons, 2);
            randomEffects.Add(CardIds.Collectible.Neutral.ServantOfKalimos, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.shadowoil, 1);
            randomEffects.Add(CardIds.Collectible.Priest.ShadowVisions, 1);
            randomEffects.Add(CardIds.Collectible.Paladin.SilvermoonPortal, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.SirFinleyMrrgglton, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.soultap, 1);
            randomEffects.Add(CardIds.Collectible.Mage.Spellslinger, 1);
            randomEffects.Add(CardIds.Collectible.Warlock.SpreadingMadness, 9);
            randomEffects.Add(CardIds.Collectible.Hunter.Stampede, 10);
            randomEffects.Add(CardIds.Collectible.Neutral.StonehillDefender, 1);
            randomEffects.Add(CardIds.Collectible.Rogue.Swashburglar, 1);
            randomEffects.Add(CardIds.NonCollectible.Neutral.TimepieceOfHorror, 10);
            randomEffects.Add(CardIds.Collectible.Neutral.TinkmasterOverspark, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.TombSpider, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.TortollanPrimalist, 1);
            randomEffects.Add(CardIds.NonCollectible.Shaman.TotemicCall, 1);
            randomEffects.Add(CardIds.Collectible.Shaman.TuskarrTotemic, 1);
            randomEffects.Add(CardIds.NonCollectible.Neutral.UnholyShadow, 2);
            randomEffects.Add(CardIds.Collectible.Mage.UnstablePortal, 1);
            randomEffects.Add(CardIds.Collectible.Warrior.VarianWrynn, 2);
            randomEffects.Add(CardIds.Collectible.Shaman.Volcano, 15);
            randomEffects.Add(CardIds.Collectible.Rogue.XarilPoisonedMind, 1);
            randomEffects.Add(CardIds.Collectible.Neutral.Zoobot, 0);
            randomEffects.Add(CardIds.Collectible.Neutral.TombLurker, 1);
            randomEffects.Add(CardIds.Collectible.Mage.GhastlyConjurer, 1);
            randomEffects.Add(CardIds.Collectible.Priest.ShadowEssence, 1);

        }


        private void setupChooseDatabase()
        {
            this.choose1database.Add(CardIds.Collectible.Druid.AncientOfLore, CardIds.NonCollectible.Druid.AncientofLore_AncientTeachingsClassic);
            this.choose1database.Add(CardIds.Collectible.Druid.AncientOfWar, CardIds.NonCollectible.Druid.AncientofWar_Uproot);
            this.choose1database.Add(CardIds.Collectible.Druid.AnodizedRoboCub, CardIds.NonCollectible.Druid.AnodizedRoboCub_AttackMode);
            this.choose1database.Add(CardIds.Collectible.Druid.Cenarius, CardIds.NonCollectible.Druid.Cenarius_DemigodsFavor);
            this.choose1database.Add(CardIds.Collectible.Druid.DarkWispers, CardIds.NonCollectible.Druid.DarkWispers_NaturesDefense);
            this.choose1database.Add(CardIds.Collectible.Druid.DruidOfTheClaw, CardIds.NonCollectible.Druid.DruidoftheClaw_DruidOfTheClawTokenClassic1);
            this.choose1database.Add(CardIds.Collectible.Druid.DruidOfTheFlame, CardIds.NonCollectible.Druid.DruidoftheFlame_DruidOfTheFlameToken1);
            this.choose1database.Add(CardIds.Collectible.Druid.DruidOfTheSaber, CardIds.NonCollectible.Druid.DruidoftheSaber_DruidOfTheSaberToken1);
            this.choose1database.Add(CardIds.Collectible.Druid.FeralRage, CardIds.NonCollectible.Druid.FeralRage_EvolveSpines);
            this.choose1database.Add(CardIds.Collectible.Druid.GroveTender, CardIds.NonCollectible.Druid.GroveTender_GiftOfMana);
            this.choose1database.Add(CardIds.Collectible.Druid.JadeIdol, CardIds.NonCollectible.Druid.JadeIdol_CutFromJade);
            this.choose1database.Add(CardIds.Collectible.Druid.KeeperOfTheGrove, CardIds.NonCollectible.Druid.KeeperoftheGrove_Moonfire);
            this.choose1database.Add(CardIds.Collectible.Druid.KunTheForgottenKing, CardIds.NonCollectible.Druid.KuntheForgottenKing_ForgottenArmor);
            this.choose1database.Add(CardIds.Collectible.Druid.LivingRoots, CardIds.NonCollectible.Druid.LivingRoots_GraspingRoots);
            this.choose1database.Add(CardIds.Collectible.Druid.MarkOfNature, CardIds.NonCollectible.Druid.MarkofNature_TigersFury);
            this.choose1database.Add(CardIds.Collectible.Druid.MireKeeper, CardIds.NonCollectible.Druid.MireKeeper_YshaarjsStrength);
            this.choose1database.Add(CardIds.Collectible.Druid.Nourish, CardIds.NonCollectible.Druid.Nourish_RampantGrowth);
            this.choose1database.Add(CardIds.Collectible.Druid.PowerOfTheWild, CardIds.NonCollectible.Druid.PoweroftheWild_LeaderOfThePack);
            this.choose1database.Add(CardIds.Collectible.Druid.RavenIdol, CardIds.NonCollectible.Druid.RavenIdol_BreakFree);
            this.choose1database.Add(CardIds.Collectible.Druid.Shellshifter, CardIds.NonCollectible.Druid.Shellshifter_ShellshifterToken1);
            this.choose1database.Add(CardIds.Collectible.Druid.Starfall, CardIds.NonCollectible.Druid.Starfall_Starlord);
            this.choose1database.Add(CardIds.Collectible.Druid.WispsOfTheOldGods, CardIds.NonCollectible.Druid.WispsoftheOldGods_ManyWisps);
            this.choose1database.Add(CardIds.Collectible.Druid.Wrath, CardIds.NonCollectible.Druid.Wrath_SolarWrath);
            this.choose1database.Add(CardIds.Collectible.Druid.MalfurionThePestilent, CardIds.NonCollectible.Druid.MalfurionthePestilent_SpiderPlague);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.plaguelord, CardIds.NonCollectible.Druid.MalfurionthePestilent_SpiderFangs);
            this.choose1database.Add(CardIds.Collectible.Druid.DruidOfTheSwarm, CardIds.NonCollectible.Druid.DruidoftheSwarm_DruidOfTheSwarmToken1);

            this.choose2database.Add(CardIds.Collectible.Druid.AncientOfLore, CardIds.NonCollectible.Druid.AncientofLore_AncientSecretsClassic);
            this.choose2database.Add(CardIds.Collectible.Druid.AncientOfWar, CardIds.NonCollectible.Druid.AncientofWar_Rooted);
            this.choose2database.Add(CardIds.Collectible.Druid.AnodizedRoboCub, CardIds.NonCollectible.Druid.AnodizedRoboCub_TankMode);
            this.choose2database.Add(CardIds.Collectible.Druid.Cenarius, CardIds.NonCollectible.Druid.Cenarius_ShandosLesson);
            this.choose2database.Add(CardIds.Collectible.Druid.DarkWispers, CardIds.NonCollectible.Druid.DarkWispers_CallTheGuardians);
            this.choose2database.Add(CardIds.Collectible.Druid.DruidOfTheClaw, CardIds.NonCollectible.Druid.DruidoftheClaw_DruidOfTheClawTokenClassic2);
            this.choose2database.Add(CardIds.Collectible.Druid.DruidOfTheFlame, CardIds.NonCollectible.Druid.DruidoftheFlame_DruidOfTheFlameToken12);
            this.choose2database.Add(CardIds.Collectible.Druid.DruidOfTheSaber, CardIds.NonCollectible.Druid.DruidoftheSaber_DruidOfTheSaberToken12);
            this.choose2database.Add(CardIds.Collectible.Druid.FeralRage, CardIds.NonCollectible.Druid.FeralRage_EvolveScales);
            this.choose2database.Add(CardIds.Collectible.Druid.GroveTender, CardIds.NonCollectible.Druid.GroveTender_GiftOfCards);
            this.choose2database.Add(CardIds.Collectible.Druid.JadeIdol, CardIds.NonCollectible.Druid.JadeIdol_JadeStash);
            this.choose2database.Add(CardIds.Collectible.Druid.KeeperOfTheGrove, CardIds.NonCollectible.Druid.KeeperoftheGrove_Dispel);
            this.choose2database.Add(CardIds.Collectible.Druid.KunTheForgottenKing, CardIds.NonCollectible.Druid.KuntheForgottenKing_ForgottenMana);
            this.choose2database.Add(CardIds.Collectible.Druid.LivingRoots, CardIds.NonCollectible.Druid.LivingRoots_OneTwoTrees);
            this.choose2database.Add(CardIds.Collectible.Druid.MarkOfNature, CardIds.NonCollectible.Druid.MarkofNature_ThickHide);
            this.choose2database.Add(CardIds.Collectible.Druid.MireKeeper, CardIds.NonCollectible.Druid.MireKeeper_YshaarjsStrengthe);
            this.choose2database.Add(CardIds.Collectible.Druid.Nourish, CardIds.NonCollectible.Druid.Nourish_Enrich);
            this.choose2database.Add(CardIds.Collectible.Druid.PowerOfTheWild, CardIds.NonCollectible.Druid.PoweroftheWild_PantherToken);
            this.choose2database.Add(CardIds.Collectible.Druid.RavenIdol, CardIds.NonCollectible.Druid.RavenIdol_Awakened);
            this.choose2database.Add(CardIds.Collectible.Druid.Shellshifter, CardIds.NonCollectible.Druid.Shellshifter_ShellshifterToken12);
            this.choose2database.Add(CardIds.Collectible.Druid.Starfall, CardIds.NonCollectible.Druid.Starfall_StellarDrift);
            this.choose2database.Add(CardIds.Collectible.Druid.WispsOfTheOldGods, CardIds.NonCollectible.Druid.WispsoftheOldGods_BigWisps);
            this.choose2database.Add(CardIds.Collectible.Druid.Wrath, CardIds.NonCollectible.Druid.Wrath_NaturesWrath);
            this.choose2database.Add(CardIds.Collectible.Druid.MalfurionThePestilent, CardIds.NonCollectible.Druid.MalfurionthePestilent_ScarabPlague);
            this.choose2database.Add(CardIds.NonCollectible.Druid.malfu, CardIds.NonCollectible.Druid.MalfurionthePestilent_ScarabShell);
            this.choose2database.Add(CardIds.Collectible.Druid.DruidOfTheSwarm, CardIds.NonCollectible.Druid.DruidoftheSwarm_DruidOfTheSwarmToken12);
        }


        public int getClassRacePriorityPenality(CardClass opponentHeroClass, Race minionRace)
        {
            int retval = 0;
            switch (opponentHeroClass)
            {
                case CardClass.WARLOCK:
                    if (this.ClassRacePriorityWarloc.ContainsKey(minionRace)) retval += this.ClassRacePriorityWarloc[minionRace];
                    break;
                case CardClass.WARRIOR:
                    if (this.ClassRacePriorityWarrior.ContainsKey(minionRace)) retval += this.ClassRacePriorityWarrior[minionRace];
					break;
                case CardClass.ROGUE:
                    if (this.ClassRacePriorityRouge.ContainsKey(minionRace)) retval += this.ClassRacePriorityRouge[minionRace];
					break;
                case CardClass.SHAMAN:
                    if (this.ClassRacePriorityShaman.ContainsKey(minionRace)) retval += this.ClassRacePriorityShaman[minionRace];
					break;
                case CardClass.PRIEST:
                    if (this.ClassRacePriorityPriest.ContainsKey(minionRace)) retval += this.ClassRacePriorityPriest[minionRace];
					break;
                case CardClass.PALADIN:
                    if (this.ClassRacePriorityPaladin.ContainsKey(minionRace)) retval += this.ClassRacePriorityPaladin[minionRace];
					break;
                case CardClass.MAGE:
                    if (this.ClassRacePriorityMage.ContainsKey(minionRace)) retval += this.ClassRacePriorityMage[minionRace];
					break;
                case CardClass.HUNTER:
                    if (this.ClassRacePriorityHunter.ContainsKey(minionRace)) retval += this.ClassRacePriorityHunter[minionRace];
					break;
                case CardClass.DRUID:
                    if (this.ClassRacePriorityDruid.ContainsKey(minionRace)) retval += this.ClassRacePriorityDruid[minionRace];
                    break;
                default:
                    break;
			}
            return retval;
        }

        private void setupClassRacePriorityDatabase()
        {
            this.ClassRacePriorityWarloc.Add(Race.MURLOC, 2);
            this.ClassRacePriorityWarloc.Add(Race.DEMON, 2);
            this.ClassRacePriorityWarloc.Add(Race.MECHANICAL, 1);
            this.ClassRacePriorityWarloc.Add(Race.PET, 0);
            this.ClassRacePriorityWarloc.Add(Race.TOTEM, 0);

            this.ClassRacePriorityHunter.Add(Race.MURLOC, 1);
            this.ClassRacePriorityHunter.Add(Race.DEMON, 0);
            this.ClassRacePriorityHunter.Add(Race.MECHANICAL, 1);
            this.ClassRacePriorityHunter.Add(Race.PET, 2);
            this.ClassRacePriorityHunter.Add(Race.TOTEM, 0);

            this.ClassRacePriorityMage.Add(Race.MURLOC, 1);
            this.ClassRacePriorityMage.Add(Race.DEMON, 0);
            this.ClassRacePriorityMage.Add(Race.MECHANICAL, 2);
            this.ClassRacePriorityMage.Add(Race.PET, 0);
            this.ClassRacePriorityMage.Add(Race.TOTEM, 0);

            this.ClassRacePriorityShaman.Add(Race.MURLOC, 2);
            this.ClassRacePriorityShaman.Add(Race.PIRATE, 1);
            this.ClassRacePriorityShaman.Add(Race.DEMON, 0);
            this.ClassRacePriorityShaman.Add(Race.MECHANICAL, 2);
            this.ClassRacePriorityShaman.Add(Race.PET, 0);
            this.ClassRacePriorityShaman.Add(Race.TOTEM, 2);

            this.ClassRacePriorityDruid.Add(Race.MURLOC, 1);
            this.ClassRacePriorityDruid.Add(Race.DEMON, 0);
            this.ClassRacePriorityDruid.Add(Race.MECHANICAL, 1);
            this.ClassRacePriorityDruid.Add(Race.PET, 1);
            this.ClassRacePriorityDruid.Add(Race.TOTEM, 0);

            this.ClassRacePriorityPaladin.Add(Race.MURLOC, 1);
            this.ClassRacePriorityPaladin.Add(Race.PIRATE, 1);
            this.ClassRacePriorityPaladin.Add(Race.DEMON, 0);
            this.ClassRacePriorityPaladin.Add(Race.MECHANICAL, 1);
            this.ClassRacePriorityPaladin.Add(Race.PET, 0);
            this.ClassRacePriorityPaladin.Add(Race.TOTEM, 0);

            this.ClassRacePriorityPriest.Add(Race.MURLOC, 1);
            this.ClassRacePriorityPriest.Add(Race.DEMON, 0);
            this.ClassRacePriorityPriest.Add(Race.MECHANICAL, 1);
            this.ClassRacePriorityPriest.Add(Race.PET, 0);
            this.ClassRacePriorityPriest.Add(Race.TOTEM, 0);

            this.ClassRacePriorityRouge.Add(Race.MURLOC, 1);
            this.ClassRacePriorityRouge.Add(Race.PIRATE, 2);
            this.ClassRacePriorityRouge.Add(Race.DEMON, 0);
            this.ClassRacePriorityRouge.Add(Race.MECHANICAL, 1);
            this.ClassRacePriorityRouge.Add(Race.PET, 0);
            this.ClassRacePriorityRouge.Add(Race.TOTEM, 0);

            this.ClassRacePriorityWarrior.Add(Race.MURLOC, 1);
            this.ClassRacePriorityWarrior.Add(Race.DEMON, 0);
            this.ClassRacePriorityWarrior.Add(Race.MECHANICAL, 1);
            this.ClassRacePriorityWarrior.Add(Race.PET, 0);
            this.ClassRacePriorityWarrior.Add(Race.TOTEM, 0);
            this.ClassRacePriorityWarrior.Add(Race.PIRATE, 2);
        }

        private void setupGangUpDatabase()
        {
            GangUpDatabase.Add(CardIds.Collectible.Druid.AddledGrizzly, 1);
            GangUpDatabase.Add(CardIds.Collectible.Shaman.AlakirTheWindlord, 5);
            GangUpDatabase.Add(CardIds.Collectible.Paladin.AldorPeacekeeper, 5);
            GangUpDatabase.Add(CardIds.Collectible.Druid.AncientOfLore, 5);
            GangUpDatabase.Add(CardIds.Collectible.Druid.AncientOfWar, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.AntiqueHealbot, 5);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.Anubarak, 5);
            GangUpDatabase.Add(CardIds.Collectible.Mage.ArchmageAntonidas, 3);
            GangUpDatabase.Add(CardIds.Collectible.Warrior.Armorsmith, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.AyaBlackpaw, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.AzureDrake, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.BaronRivendare, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.BigGameHunter, 5);
            GangUpDatabase.Add(CardIds.Collectible.Druid.Biteweed, 5);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.BladeOfCthun, 5);
            GangUpDatabase.Add(CardIds.Collectible.Warlock.BloodImp, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.BombLobber, 4);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.BoneguardLieutenant, 3);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.BurglyBully, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.BurlyRockjawTrogg, 1);
            GangUpDatabase.Add(CardIds.Collectible.Priest.CabalShadowPriest, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.CairneBloodhoof, 5);
            GangUpDatabase.Add(CardIds.Collectible.Druid.Cenarius, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Chromaggus, 4);
            GangUpDatabase.Add(CardIds.Collectible.Paladin.CobaltGuardian, 1);
            GangUpDatabase.Add(CardIds.Collectible.Mage.ColdarraDrake, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.ColdlightOracle, 5);
            GangUpDatabase.Add(CardIds.Collectible.Priest.ConfessorPaletress, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.corendirebrew, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Cthun, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.CultApothecary, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.CultMaster, 1);
            GangUpDatabase.Add(CardIds.Collectible.Mage.CultSorcerer, 5);
            GangUpDatabase.Add(CardIds.Collectible.Mage.DementedFrostcaller, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Demolisher, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.DireWolfAlpha, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Doppelgangster, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.DragonkinSorcerer, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.DrBoom, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.EarthenRingFarseer, 3);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.EdwinVancleef, 5);
            GangUpDatabase.Add(CardIds.NonCollectible.Neutral.Emboldener3000, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.EmperorThaurissan, 5);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.EtherealPeddler, 3);
            GangUpDatabase.Add(CardIds.Collectible.Warlock.FelCannon, 0);
            GangUpDatabase.Add(CardIds.Collectible.Shaman.FireElemental, 5);
            GangUpDatabase.Add(CardIds.Collectible.Shaman.FireguardDestroyer, 4);
            GangUpDatabase.Add(CardIds.Collectible.Shaman.FlametongueTotem, 4);
            GangUpDatabase.Add(CardIds.Collectible.Mage.Flamewaker, 4);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.FlesheatingGhoul, 0);
            GangUpDatabase.Add(CardIds.Collectible.Warlock.FloatingWatcher, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.FoeReaper4000, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.FriendlyBartender, 3);
            GangUpDatabase.Add(CardIds.Collectible.Warrior.FrothingBerserker, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.GadgetzanAuctioneer, 1);
            GangUpDatabase.Add(CardIds.Collectible.Hunter.Gahzrilla, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.garr, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Gazlowe, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.GelbinMekkatorque, 3);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.GenzoTheShark, 5);
            GangUpDatabase.Add(CardIds.Collectible.Paladin.GrimestreetEnforcer, 3);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.GrimscaleOracle, 1);
            GangUpDatabase.Add(CardIds.Collectible.Warrior.GrimyGadgeteer, 3);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Gruul, 4);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.HarrisonJones, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.HemetNesingwary, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.highjusticegrimstone, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Hobgoblin, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Hogger, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.HoggerDoomOfElwynn, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.IgneousElemental, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.illidanstormrage, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.ImpMaster, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.InfestedTauren, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.IronbeakOwl, 4);
            GangUpDatabase.Add(CardIds.Collectible.Warrior.IronJuggernaut, 2);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.IronSensei, 1);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.JadeSwarmer, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Jeeves, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Junkbot, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Kelthuzad, 5);
            GangUpDatabase.Add(CardIds.Collectible.Hunter.KingKrush, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.KnifeJuggler, 3);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Kodorider, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.LeeroyJenkins, 3);
            GangUpDatabase.Add(CardIds.NonCollectible.Hunter.Leokk, 3);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Lightwarden, 0);
            GangUpDatabase.Add(CardIds.Collectible.Priest.Lightwell, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Loatheb, 5);
            GangUpDatabase.Add(CardIds.NonCollectible.Neutral.Lucifron, 5);
            GangUpDatabase.Add(CardIds.Collectible.Priest.LyraTheSunshard, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Maexxna, 3);
            GangUpDatabase.Add(CardIds.Collectible.Warlock.Malganis, 4);
            GangUpDatabase.Add(CardIds.Collectible.Warrior.Malkorok, 2);
            GangUpDatabase.Add(CardIds.Collectible.Druid.Malorne, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Malygos, 1);
            GangUpDatabase.Add(CardIds.Collectible.Shaman.ManaTideTotem, 0);
            GangUpDatabase.Add(CardIds.Collectible.Mage.ManaWyrm, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.MasterSwordsmith, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Mechwarper, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.MedivhTheGuardian, 2);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.MekgineerThermaplugg, 4);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.MicroMachine, 1);
            GangUpDatabase.Add(CardIds.NonCollectible.Hunter.Misha, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.MoatLurker, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.moirabronzebeard, 5);
            GangUpDatabase.Add(CardIds.Collectible.Paladin.MurlocKnight, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.MurlocTidecaller, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.MurlocWarleader, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Nefarian, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.NexusChampionSaraad, 5);
            GangUpDatabase.Add(CardIds.Collectible.Priest.NorthshireCleric, 0);
            GangUpDatabase.Add(CardIds.Collectible.Warrior.ObsidianDestroyer, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.OldMurkEye, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Onyxia, 4);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.PilotedShredder, 3);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.PintSizedSummoner, 1);
            GangUpDatabase.Add(CardIds.Collectible.Priest.ProphetVelen, 1);
            GangUpDatabase.Add(CardIds.Collectible.Mage.Pyros, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.QuestingAdventurer, 1);
            GangUpDatabase.Add(CardIds.Collectible.Priest.RadiantElemental, 1);
            GangUpDatabase.Add(CardIds.Collectible.Paladin.RagnarosLightlord, 3);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.RagnarosTheFirelord, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.RaidLeader, 2);
            GangUpDatabase.Add(CardIds.Collectible.Hunter.RatPack, 2);
            GangUpDatabase.Add(CardIds.NonCollectible.Neutral.Razorgore, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Recruiter, 5);
            GangUpDatabase.Add(CardIds.NonCollectible.Neutral.RepairBot, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.SatedThreshadon, 1);
            GangUpDatabase.Add(CardIds.Collectible.Druid.SavageCombatant, 5);
            GangUpDatabase.Add(CardIds.Collectible.Hunter.SavannahHighmane, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.ScaledNightmare, 3);
            GangUpDatabase.Add(CardIds.Collectible.Hunter.ScavengingHyena, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.ShadeOfNaxxramas, 3);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.ShadoPanRider, 5);
            GangUpDatabase.Add(CardIds.Collectible.Priest.Shadowboxer, 0);
            GangUpDatabase.Add(CardIds.Collectible.Priest.Shadowfiend, 1);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.ShakuTheCollector, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.ShipsCannon, 0);
            GangUpDatabase.Add(CardIds.Collectible.Shaman.SiltfinSpiritwalker, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.SludgeBelcher, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.SneedsOldShredder, 5);
            GangUpDatabase.Add(CardIds.Collectible.Mage.SorcerersApprentice, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.SouthseaCaptain, 0);
            GangUpDatabase.Add(CardIds.Collectible.Hunter.StarvingBuzzard, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.StonesplinterTrogg, 0);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.StormwindChampion, 4);
            GangUpDatabase.Add(CardIds.Collectible.Warlock.SummoningPortal, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.SummoningStone, 5);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.Swashburglar, 2);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.SylvanasWindrunner, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.TheBlackKnight, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.TheBoogeymonster, 3);
            GangUpDatabase.Add(CardIds.Collectible.Hunter.TimberWolf, 0);
            GangUpDatabase.Add(CardIds.Collectible.Paladin.TirionFordring, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Toshley, 4);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.TradePrinceGallywix, 3);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.TroggzorTheEarthinator, 1);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.UndercityHuckster, 2);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Undertaker, 0);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.UnearthedRaptor, 5);
            GangUpDatabase.Add(CardIds.Collectible.Warlock.UsherOfSouls, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.v07tr0n, 5);
            GangUpDatabase.Add(CardIds.NonCollectible.Neutral.Vaelastrasz, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.ViciousFledgling, 2);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.VioletIllusionist, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.VioletTeacher, 0);
            GangUpDatabase.Add(CardIds.Collectible.Shaman.VitalityTotem, 1);
            GangUpDatabase.Add(CardIds.Collectible.Priest.Voljin, 5);
            GangUpDatabase.Add(CardIds.Collectible.Warrior.WarsongCommander, 3);
            GangUpDatabase.Add(CardIds.Collectible.Mage.WeeSpellstopper, 0);
            GangUpDatabase.Add(CardIds.Collectible.Shaman.WickedWitchdoctor, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.WobblingRunts, 3);
            GangUpDatabase.Add(CardIds.Collectible.Rogue.XarilPoisonedMind, 3);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.YoungPriestess, 1);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.Ysera, 5);
            GangUpDatabase.Add(CardIds.Collectible.Neutral.YshaarjRageUnbound, 5);
            GangUpDatabase.Add(CardIds.Collectible.Warrior.ValkyrSoulclaimer, 0);
            GangUpDatabase.Add(CardIds.Collectible.Druid.CryptLord, 4);
        }

        private void setupbuffHandDatabase()
        {
            buffHandDatabase.Add(CardIds.Collectible.Warrior.BrassKnuckles, 1);
            buffHandDatabase.Add(CardIds.Collectible.Neutral.DonHancho, 5);
            buffHandDatabase.Add(CardIds.Collectible.Paladin.GrimestreetEnforcer, 1);
            buffHandDatabase.Add(CardIds.Collectible.Paladin.GrimestreetOutfitter, 1);
            buffHandDatabase.Add(CardIds.Collectible.Warrior.GrimestreetPawnbroker, 1);
            buffHandDatabase.Add(CardIds.Collectible.Neutral.GrimestreetSmuggler, 1);
            buffHandDatabase.Add(CardIds.Collectible.Paladin.GrimscaleChum, 1);
            buffHandDatabase.Add(CardIds.Collectible.Warrior.GrimyGadgeteer, 2);
            buffHandDatabase.Add(CardIds.Collectible.Hunter.HiddenCache, 2);
            buffHandDatabase.Add(CardIds.Collectible.Warrior.HobartGrapplehammer, 1);
            buffHandDatabase.Add(CardIds.Collectible.Hunter.ShakyZipgunner, 2);
            buffHandDatabase.Add(CardIds.Collectible.Hunter.SmugglersCrate, 2);
            buffHandDatabase.Add(CardIds.Collectible.Paladin.SmugglersRun, 1);
            buffHandDatabase.Add(CardIds.Collectible.Warrior.StolenGoods, 3);
            buffHandDatabase.Add(CardIds.Collectible.Shaman.TheMistcaller, 1);
            buffHandDatabase.Add(CardIds.Collectible.Hunter.TroggBeastrager, 1);
        }

        private void setupequipWeaponPlayDatabase()
        {
            equipWeaponPlayDatabase.Add(CardIds.Collectible.Warrior.ArathiWeaponsmith, 2);
            equipWeaponPlayDatabase.Add(CardIds.Collectible.Neutral.Blingtron3000, 3);
            equipWeaponPlayDatabase.Add(CardIds.NonCollectible.Rogue.DaggerMastery, 1);
            equipWeaponPlayDatabase.Add(CardIds.NonCollectible.Neutral.Echolocate, 2);
            equipWeaponPlayDatabase.Add(CardIds.NonCollectible.Neutral.InstructorRazuvious, 5);
            equipWeaponPlayDatabase.Add(CardIds.Collectible.Warrior.Malkorok, 3);
            equipWeaponPlayDatabase.Add(CardIds.Collectible.Neutral.MedivhTheGuardian, 1);
            equipWeaponPlayDatabase.Add(CardIds.Collectible.Paladin.MusterForBattle, 1);
            equipWeaponPlayDatabase.Add(CardIds.Collectible.Warrior.NzothsFirstMate, 1);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.poisoneddaggers, 2);
            equipWeaponPlayDatabase.Add(CardIds.Collectible.Warrior.Upgrade, 1);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.visionsoftheassassin, 1);
            equipWeaponPlayDatabase.Add(CardIds.Collectible.Paladin.UtherOfTheEbonBlade, 5);
            equipWeaponPlayDatabase.Add(CardIds.Collectible.Warrior.ScourgelordGarrosh, 4);
        }


    }

}