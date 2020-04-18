namespace HREngine.Bots
{
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

        Dictionary<TAG_RACE, int> ClassRacePriorityWarloc = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityHunter = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityMage = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityShaman = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityDruid = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityPaladin = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityPriest = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityRouge = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityWarrior = new Dictionary<TAG_RACE, int>();
        
        ComboBreaker cb;
        Hrtprozis prozis;
        Settings settings;
        CardDB cdb;
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
            cdb = CardDB.Instance;
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
            if (!p.isLethalCheck && m.name == Chireiden.Silverfish.SimCard.bloodimp) retval += 50;
            switch (m.name)
            {
                case Chireiden.Silverfish.SimCard.leeroyjenkins:
                    if (!target.own && target.name == Chireiden.Silverfish.SimCard.whelp) return 500;
                    break;
                case Chireiden.Silverfish.SimCard.bloodmagethalnos:
                    if (!target.isHero && Ai.Instance.lethalMissing <= 5)
                    {
                        if (!target.taunt)
                        {
                            if (m.Hp <= target.Angr && m.own && !m.divineshild && !m.immune) return 65;
                        }
                    }
                    goto case Chireiden.Silverfish.SimCard.aiextra1;
                
                
                case Chireiden.Silverfish.SimCard.acolyteofpain: goto case Chireiden.Silverfish.SimCard.aiextra1;
                case Chireiden.Silverfish.SimCard.clockworkgnome: goto case Chireiden.Silverfish.SimCard.aiextra1;
                case Chireiden.Silverfish.SimCard.loothoarder: goto case Chireiden.Silverfish.SimCard.aiextra1;
                case Chireiden.Silverfish.SimCard.mechanicalyeti: goto case Chireiden.Silverfish.SimCard.aiextra1;
                case Chireiden.Silverfish.SimCard.mechbearcat: goto case Chireiden.Silverfish.SimCard.aiextra1;
                case Chireiden.Silverfish.SimCard.tombpillager: goto case Chireiden.Silverfish.SimCard.aiextra1;
                case Chireiden.Silverfish.SimCard.toshley: goto case Chireiden.Silverfish.SimCard.aiextra1;
                case Chireiden.Silverfish.SimCard.webspinner: goto case Chireiden.Silverfish.SimCard.aiextra1;
                case Chireiden.Silverfish.SimCard.aiextra1:
                    
                    if (m.Hp <= target.Angr && m.own && !m.divineshild && !m.immune)
                    {
                        int carddraw = 1; 
                        if (p.owncards.Count + carddraw > 10) retval += 15 * (p.owncards.Count + carddraw - 10);
                        else retval += 3 * p.optionsPlayedThisTurn;
                    }
                    return retval;
                    break;
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

            if (!isLethalCheck && p.enemyWeapon.name == Chireiden.Silverfish.SimCard.swordofjustice)
            {
                return 28;
            }

            switch (p.ownWeapon.name)
            {
                case Chireiden.Silverfish.SimCard.atiesh:
                    if (!isLethalCheck)
                    {
                        if (target.isHero) return 500;
                        else return 15;
                    }
                    break;
                case Chireiden.Silverfish.SimCard.doomhammer:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == Chireiden.Silverfish.SimCard.rockbiterweapon && hc.canplayCard(p, true)) return 10;
                    }
                    break;
                case Chireiden.Silverfish.SimCard.eaglehornbow:
                    if (p.ownWeapon.Durability == 1)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == Chireiden.Silverfish.SimCard.arcaneshot || hc.card.name == Chireiden.Silverfish.SimCard.killcommand) return -p.ownWeapon.Angr - 1;
                        }
                        if (p.ownSecretsIDList.Count >= 1) return 20;

                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Secret) return 20;
                        }
                    }
                    break;
                case Chireiden.Silverfish.SimCard.spiritclaws:
                    if (!isLethalCheck && p.ownWeapon.Angr == 1)
                    {
                        if (target.isHero) return 500;
                        else if (target.Hp == 1 && this.specialMinions.ContainsKey(target.name)) return 0;
                        else return 7;
                    }
                    break;
                case Chireiden.Silverfish.SimCard.gorehowl:
                    if (target.isHero && p.ownWeapon.Angr >= 3) return 10;
                    break;
                case Chireiden.Silverfish.SimCard.brassknuckles:
                    if (target.own)
                    {
                        if (p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob) != null)
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
                if (p.ownWeapon.Angr == 1 && wAttack == 0 && (p.ownHeroAblility.card.name == Chireiden.Silverfish.SimCard.poisoneddaggers || p.ownHeroAblility.card.name == Chireiden.Silverfish.SimCard.daggermastery)) wAttack = 1;
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
                if (c.card.type == Chireiden.Silverfish.SimCardtype.WEAPON && c.card.getManaCost(p, c.manacost) <= p.ownMaxMana + 1)
                {
                    return c.card.Attack;
                }
                if (this.equipWeaponPlayDatabase.ContainsKey(c.card.name) && c.card.name != Chireiden.Silverfish.SimCard.upgrade && c.card.getManaCost(p, c.manacost) <= p.ownMaxMana + 1)
                {
                    return this.equipWeaponPlayDatabase[c.card.name];
                }
            }
            return 0;
        }

        public int getPlayCardPenality(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            int retval = ai.botBase.getPlayCardPenality(card, target, p);
            if (retval < 0 || retval > 499) return retval;

            Chireiden.Silverfish.SimCard name = card.name;
            //there is no reason to buff HP of minon (because it is not healed)

            int abuff = getAttackBuffPenality(card, target, p);
            int tbuff = getTauntBuffPenality(card, target, p);
            if (name == Chireiden.Silverfish.SimCard.markofthewild && ((abuff >= 500 && tbuff == 0) || (abuff == 0 && tbuff >= 500)))
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
                retval += cb.getPlayValue(card.cardIDenum);
            }

            retval += playSecretPenality(card, p);
            retval += getPlayCardSecretPenality(card, p);

            return retval;
        }


        private int getAttackBuffPenality(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            Chireiden.Silverfish.SimCard name = card.name;
            if (name == Chireiden.Silverfish.SimCard.darkwispers && card.cardIDenum != Chireiden.Silverfish.SimCard.GVG_041a) return 0;
            int pen = 0;
            //buff enemy?

            if (!p.isLethalCheck && (card.name == Chireiden.Silverfish.SimCard.savageroar || card.name == Chireiden.Silverfish.SimCard.bloodlust))
            {
                int targets = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Ready) targets++;
                }
                if ((p.ownHero.Ready || p.ownHero.numAttacksThisTurn == 0) && card.name == Chireiden.Silverfish.SimCard.savageroar) targets++;

                if (targets <= 2)
                {
                    return 20;
                }
            }

            if (!this.attackBuffDatabase.ContainsKey(name)) return 0;
            if (target == null) return 60;
            if (!target.isHero && !target.own)
            {
                if (card.type == Chireiden.Silverfish.SimCardtype.MOB && p.ownMinions.Count == 0) return 2;
                
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    switch (hc.card.name)
                    {
                        case Chireiden.Silverfish.SimCard.biggamehunter:
                            if (target.Angr + this.attackBuffDatabase[name] > 6) return 5;
                            break;
                        case Chireiden.Silverfish.SimCard.shadowworddeath:
                            if (target.Angr + this.attackBuffDatabase[name] > 4) return 5;
                            break;
                        default:
                            break;
                    }
                }
                if (card.name == Chireiden.Silverfish.SimCard.crueltaskmaster || card.name == Chireiden.Silverfish.SimCard.innerrage)
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
                            if (hc.card.name == Chireiden.Silverfish.SimCard.execute) return 0;
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
                    switch (card.name)
                    {
                        case Chireiden.Silverfish.SimCard.markofyshaarj:
                            if (target.stealth)
                            {
                                if ((TAG_RACE)target.handcard.card.Race == TAG_RACE.PET) return 3;
                                else return 7;
                            }
                            if ((TAG_RACE)target.handcard.card.Race == TAG_RACE.PET && p.owncards.Count < 2) return 3;
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
            Chireiden.Silverfish.SimCard name = card.name;
            int pen = 0;

            if (!this.healthBuffDatabase.ContainsKey(name)) return 0;
            if (name == Chireiden.Silverfish.SimCard.darkwispers && card.cardIDenum != Chireiden.Silverfish.SimCard.GVG_041a) return 0;

            if (target != null && !target.own && !this.tauntBuffDatabase.ContainsKey(name))
            {
                pen = 500 + p.ownMinions.Count;
            }

            return pen;
        }


        private int getTauntBuffPenality(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            Chireiden.Silverfish.SimCard name = card.name;
            int pen = 0;
            //buff enemy?
            if (!this.tauntBuffDatabase.ContainsKey(name)) return 0;
            if (name == Chireiden.Silverfish.SimCard.markofnature && card.cardIDenum != Chireiden.Silverfish.SimCard.EX1_155b) return 0;
            if (name == Chireiden.Silverfish.SimCard.darkwispers && card.cardIDenum != Chireiden.Silverfish.SimCard.GVG_041a) return 0;
            
            if (target == null) return 3;
            if (!target.isHero && !target.own)
            {
                //allow it if you have black knight
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == Chireiden.Silverfish.SimCard.theblackknight) return 0;
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
                if (name == Chireiden.Silverfish.SimCard.ironbeakowl || name == Chireiden.Silverfish.SimCard.spellbreaker || name == Chireiden.Silverfish.SimCard.keeperofthegrove)
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
                        if (target.taunt || (name == Chireiden.Silverfish.SimCard.ironbeakowl && (p.ownMinions.Find(x => x.name == Chireiden.Silverfish.SimCard.tundrarhino) != null || p.owncards.Find(x => x.card.name == Chireiden.Silverfish.SimCard.charge) != null)) || (name == Chireiden.Silverfish.SimCard.spellbreaker && p.owncards.Find(x => x.card.name == Chireiden.Silverfish.SimCard.charge) != null)) return 0;

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
                        if (name == Chireiden.Silverfish.SimCard.keeperofthegrove) return 500;
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
            Chireiden.Silverfish.SimCard name = card.name;
            int pen = 0;

            if (name == Chireiden.Silverfish.SimCard.shieldslam && p.ownHero.armor == 0) return 500;
            if (name == Chireiden.Silverfish.SimCard.savagery && p.ownHero.Angr == 0) return 500;
            
            //aoe damage *************************************************************************************
            int aoeDamageType = 0;
            if (this.DamageAllEnemysDatabase.ContainsKey(name)) aoeDamageType = 1;
            else if (p.anzOwnAuchenaiSoulpriest >= 1 && HealAllDatabase.ContainsKey(name)) aoeDamageType = 2;
            else if (this.DamageAllDatabase.ContainsKey(name)) aoeDamageType = 3;
            if (aoeDamageType > 0)
            {
                if (p.enemyMinions.Count == 0)
                {
                    if (name == Chireiden.Silverfish.SimCard.cthun) return 0;
                    return 300;
                }

                int aoeDamage = 0;
                if (aoeDamageType == 1) aoeDamage = (card.type == Chireiden.Silverfish.SimCardtype.SPELL) ? p.getSpellDamageDamage(this.DamageAllEnemysDatabase[name]) : this.DamageAllEnemysDatabase[name];
                else if (aoeDamageType == 2) aoeDamage = (card.type == Chireiden.Silverfish.SimCardtype.SPELL) ? p.getSpellDamageDamage(this.HealAllDatabase[name]) : this.HealAllDatabase[name];
                else if (aoeDamageType == 3)
                {
                    if (name == Chireiden.Silverfish.SimCard.revenge && p.ownHero.Hp <= 12) aoeDamage = p.getSpellDamageDamage(3);
                    else aoeDamage = (card.type == Chireiden.Silverfish.SimCardtype.SPELL) ? p.getSpellDamageDamage(this.DamageAllDatabase[name]) : this.DamageAllDatabase[name];
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
                            case Chireiden.Silverfish.SimCard.sleepwiththefishes: 
                                if (!m.wounded) continue;
                                break;
                            case Chireiden.Silverfish.SimCard.dragonfirepotion: 
                                if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.DRAGON) continue;
                                break;
                            case Chireiden.Silverfish.SimCard.corruptedseer: 
                                if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.MURLOC) continue;
                                break;
                            case Chireiden.Silverfish.SimCard.shadowvolley: 
                                if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.DEMON) continue;
                                break;
                            case Chireiden.Silverfish.SimCard.demonwrath: 
                                if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.DEMON) continue;
                                break;
                            case Chireiden.Silverfish.SimCard.scarletpurifier: 
                                if (!(m.handcard.card.deathrattle && !m.silenced)) continue;
                                break;
                            case Chireiden.Silverfish.SimCard.yseraawakens: 
                                if (m.name == Chireiden.Silverfish.SimCard.ysera) continue;
                                break;
                            case Chireiden.Silverfish.SimCard.lightbomb: 
                                if (m.Hp > m.Angr) continue;
                                break;
                        }
                        
                        if (this.specialMinions.ContainsKey(m.name)) numSpecialMinionsEnemy++;
                        switch (m.name)
                        {
                            case Chireiden.Silverfish.SimCard.direwolfalpha: 
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
                            case Chireiden.Silverfish.SimCard.flametonguetotem: 
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
                            case Chireiden.Silverfish.SimCard.leokk: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.Hp > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case Chireiden.Silverfish.SimCard.raidleader: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.Hp > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case Chireiden.Silverfish.SimCard.stormwindchampion: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.Hp > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case Chireiden.Silverfish.SimCard.grimscaleoracle: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                                 
                            case Chireiden.Silverfish.SimCard.murlocwarleader: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 2;
                                }
                                break;
                            case Chireiden.Silverfish.SimCard.malganis: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.DEMON && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 2;
                                }
                                break;
                            case Chireiden.Silverfish.SimCard.southseacaptain: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.PIRATE && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case Chireiden.Silverfish.SimCard.timberwolf: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.PET && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case Chireiden.Silverfish.SimCard.warhorsetrainer: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if (mm.name == Chireiden.Silverfish.SimCard.silverhandrecruit && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case Chireiden.Silverfish.SimCard.warsongcommander: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if (mm.charge > 0 && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case Chireiden.Silverfish.SimCard.tunneltrogg:
                                preventDamage++;
                                break;
                            case Chireiden.Silverfish.SimCard.secretkeeper:
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
                        else if (m.name == Chireiden.Silverfish.SimCard.gurubashiberserker) preventDamage -= 3;
                        else if (m.name == Chireiden.Silverfish.SimCard.frothingberserker) frothingberserkerEnemy = true;
                        else if (m.name == Chireiden.Silverfish.SimCard.grimpatron) { preventDamage -= 3; grimpatronEnemy = true; }
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
                            switch (name)
                            {
                                case Chireiden.Silverfish.SimCard.sleepwiththefishes: 
                                    if (!m.wounded) continue;
                                    break;
                                case Chireiden.Silverfish.SimCard.dragonfirepotion: 
                                    if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.DRAGON) continue;
                                    break;
                                case Chireiden.Silverfish.SimCard.corruptedseer: 
                                    if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.MURLOC) continue;
                                    break;
                                case Chireiden.Silverfish.SimCard.shadowvolley: 
                                    if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.DEMON) continue;
                                    break;
                                case Chireiden.Silverfish.SimCard.demonwrath: 
                                    if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.DEMON) continue;
                                    break;
                                case Chireiden.Silverfish.SimCard.scarletpurifier: 
                                    if (!(m.handcard.card.deathrattle && !m.silenced)) continue;
                                    break;
                                case Chireiden.Silverfish.SimCard.yseraawakens: 
                                    if (m.name == Chireiden.Silverfish.SimCard.ysera) continue;
                                    break;
                                case Chireiden.Silverfish.SimCard.lightbomb: 
                                    if (m.Hp > m.Angr) continue;
                                    break;
                            }

                            switch (m.name)
                            {
                                case Chireiden.Silverfish.SimCard.direwolfalpha: 
                                    if (m.silenced) break;
                                    if (i > 0 && (p.ownMinions[i - 1].Hp > aoeDamage || p.ownMinions[i - 1].divineshild)) lostOwnDamage += 1;
                                    if (i < anz - 1 && (p.ownMinions[i + 1].Hp > aoeDamage || p.ownMinions[i + 1].divineshild)) lostOwnDamage += 1;
                                    break;
                                case Chireiden.Silverfish.SimCard.flametonguetotem: 
                                    if (m.silenced) break;
                                    if (i > 0 && (p.ownMinions[i - 1].Hp > aoeDamage || p.ownMinions[i - 1].divineshild)) lostOwnDamage += 2;
                                    if (i < anz - 1 && (p.ownMinions[i + 1].Hp > aoeDamage || p.ownMinions[i + 1].divineshild)) lostOwnDamage += 2;
                                    break;
                                case Chireiden.Silverfish.SimCard.leokk: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.Hp > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case Chireiden.Silverfish.SimCard.raidleader: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.Hp > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case Chireiden.Silverfish.SimCard.stormwindchampion: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.Hp > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case Chireiden.Silverfish.SimCard.grimscaleoracle: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                
                                case Chireiden.Silverfish.SimCard.murlocwarleader: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 2;
                                    }
                                    break;
                                case Chireiden.Silverfish.SimCard.malganis: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.DEMON && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 2;
                                    }
                                    break;
                                case Chireiden.Silverfish.SimCard.southseacaptain: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.PIRATE && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case Chireiden.Silverfish.SimCard.timberwolf: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.PET && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case Chireiden.Silverfish.SimCard.warhorsetrainer: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if (mm.name == Chireiden.Silverfish.SimCard.silverhandrecruit && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case Chireiden.Silverfish.SimCard.warsongcommander: 
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
                            else if (m.name == Chireiden.Silverfish.SimCard.gurubashiberserker && m.Hp > 1) lostOwnDamage += 3;
                            else if (m.name == Chireiden.Silverfish.SimCard.frothingberserker) frothingberserkerOwn = true;
                            else if (m.name == Chireiden.Silverfish.SimCard.grimpatron) { lostOwnDamage += 3; grimpatronOwn = true; }
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
                            foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.name == Chireiden.Silverfish.SimCard.execute) return 0;
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
                    else if (name == Chireiden.Silverfish.SimCard.holynova && preventDamage >= 0)
                    {
                        int ownWoundedMinions = 0;
                        foreach (Minion m in p.ownMinions) if (m.wounded) ownWoundedMinions++;
                        if (ownWoundedMinions > 2) return 20;
                    }

                    if (survivedEnemyMinions > 0)
                    {
                        int hasExecute = 0;
                        foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.name == Chireiden.Silverfish.SimCard.execute) hasExecute++;
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
                if (name == Chireiden.Silverfish.SimCard.baneofdoom)
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
                    
                    if (m.name == Chireiden.Silverfish.SimCard.madscientist && p.ownHeroStartClass == TAG_CLASS.HUNTER) return 500;

                    // no pen if we have battlerage for example
                    int dmg = this.DamageTargetDatabase.ContainsKey(name) ? this.DamageTargetDatabase[name] : this.HealTargetDatabase[name];
                    switch (card.cardIDenum)
                    {
                        case Chireiden.Silverfish.SimCard.EX1_166a: dmg = 2 - p.spellpower; break; 
                        case Chireiden.Silverfish.SimCard.CS2_031: if (!target.frozen) return 0; break; 
                        case Chireiden.Silverfish.SimCard.EX1_408: if (p.ownHero.Hp <= 12) dmg = 6; break; 
                        case Chireiden.Silverfish.SimCard.EX1_539: 
                            foreach (Minion mn in p.ownMinions)
                            {
                                if ((TAG_RACE)mn.handcard.card.Race == TAG_RACE.PET) { dmg = 5; break; }
                            }
                            break;
                    }
                    if (card.type == Chireiden.Silverfish.SimCardtype.SPELL) dmg = p.getSpellDamageDamage(dmg);
                
                    if (m.Hp > dmg)
                    {
                        switch (m.name)
                        {
                            case Chireiden.Silverfish.SimCard.gurubashiberserker: return 0; break;
                            case Chireiden.Silverfish.SimCard.axeflinger: return 0; break;
                            case Chireiden.Silverfish.SimCard.gahzrilla: return 0; break;
                            case Chireiden.Silverfish.SimCard.garr: if (p.ownMinions.Count <= 6) return 0; break;
                            case Chireiden.Silverfish.SimCard.hoggerdoomofelwynn: if (p.ownMinions.Count <= 6) return 0; break;
                            case Chireiden.Silverfish.SimCard.acolyteofpain: if (p.owncards.Count <= 3) return 0; break;
                            case Chireiden.Silverfish.SimCard.dragonegg: if (p.ownMinions.Count <= 6) return 5; break;
                            case Chireiden.Silverfish.SimCard.impgangboss: if (p.ownMinions.Count <= 6) return 0; break;
                            case Chireiden.Silverfish.SimCard.grimpatron: if (p.ownMinions.Count <= 6) return 0; break;
                        }
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == Chireiden.Silverfish.SimCard.battlerage) return pen;
                            if (hc.card.name == Chireiden.Silverfish.SimCard.rampage) return pen;
                        }
                    }
                    else
                    {
                        if (p.isLethalCheck && dmg == 1 && p.enemyHero.Hp < 3)
                        {
                            switch (m.name)
                            {
                                case Chireiden.Silverfish.SimCard.lepergnome: return 0; break;
                                case Chireiden.Silverfish.SimCard.axeflinger: return 0; break;
                            }
                        }
                        if (cardDrawDeathrattleDatabase.ContainsKey(m.name))
                        {
                            if (ai.lethalMissing <= 5 && p.lethalMissing() <= 5) pen += 115 + (dmg - m.Hp) * 10; //behav compensation
                            if (p.enemyAnzCards == 9) pen += 60; //drawACard compensation
                            return 10;
                        }
                    }
                    if (m.handcard.card.deathrattle) return 10;

                    pen = 500;
                }

                //special cards
                if (DamageTargetSpecialDatabase.ContainsKey(name))
                {
                    int dmg = DamageTargetSpecialDatabase[name];
                    Minion m = target; 
                    switch (name)
                    {
                        case Chireiden.Silverfish.SimCard.crueltaskmaster: if (m.Hp >= 2) return 0; break;
                        case Chireiden.Silverfish.SimCard.innerrage: if (m.Hp >= 2) return 0; break;
                        case Chireiden.Silverfish.SimCard.demonfire: if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.DEMON) return 0; break;
                        case Chireiden.Silverfish.SimCard.demonheart: if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.DEMON) return 0; break;
                        case Chireiden.Silverfish.SimCard.earthshock:
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
                            switch (hc.card.name)
                            {
                                case Chireiden.Silverfish.SimCard.battlerage: return pen; break;
                                case Chireiden.Silverfish.SimCard.rampage: return pen; break;
                                case Chireiden.Silverfish.SimCard.bloodwarriors: return pen; break;
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
                    realDamage = (card.type == Chireiden.Silverfish.SimCardtype.SPELL) ? p.getSpellDamageDamage(this.DamageTargetSpecialDatabase[name]) : this.DamageTargetSpecialDatabase[name];
                    switch (name)
                    {
                        case Chireiden.Silverfish.SimCard.soulfire: if (target.Hp <= realDamage - 2) pen = 10; break; 
                        case Chireiden.Silverfish.SimCard.baneofdoom: if (target.Hp > realDamage) pen = 10; break; 
                        case Chireiden.Silverfish.SimCard.shieldslam: if (target.Hp <= 4 || target.Angr <= 4) pen = 20; break; 
                        case Chireiden.Silverfish.SimCard.bloodtoichor: if (target.Hp <= realDamage) pen = 2; break; 
                    }
                }
                else
                {
                    if (DamageTargetDatabase.ContainsKey(name))
                    {
                        realDamage = this.DamageTargetDatabase[name];
                        switch (card.cardIDenum)
                        {
                            case Chireiden.Silverfish.SimCard.EX1_166a: realDamage = 2 - p.spellpower; break; 
                            case Chireiden.Silverfish.SimCard.CS2_031: if (!target.frozen) return 0; break; 
                            case Chireiden.Silverfish.SimCard.EX1_408: if (p.ownHero.Hp <= 12) realDamage = 6; break; 
                            case Chireiden.Silverfish.SimCard.EX1_539: 
                                foreach (Minion mn in p.ownMinions)
                                {
                                    if ((TAG_RACE)mn.handcard.card.Race == TAG_RACE.PET) { realDamage = 5; break; }
                                }
                                break;
                        }
                        if (card.type == Chireiden.Silverfish.SimCardtype.SPELL) realDamage = p.getSpellDamageDamage(realDamage);
                    }
                }
                if (realDamage == 0) realDamage = card.Attack;
                if (target.name == Chireiden.Silverfish.SimCard.grimpatron && realDamage < target.Hp) return 500;
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


            switch (name)
            {
                case Chireiden.Silverfish.SimCard.treeoflife:
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

                case Chireiden.Silverfish.SimCard.renojackson:
                    if (p.ownHero.Hp < 16)
                    {
                        int retval = p.ownHero.Hp - 16;
                        if (p.ownHeroHasDirectLethal()) return retval * 10;
                        else return retval * 2;
                    }
                    else
                    {
                        pen = (p.ownHero.Hp - 15) / 2;
                        if (p.ownAbilityReady && cardDrawBattleCryDatabase.ContainsKey(p.ownHeroAblility.card.name)) pen += 20;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (!cardDrawBattleCryDatabase.ContainsKey(hc.card.name)) continue;
                            pen += 20;
                            break;
                        }
                        return pen;
                    }
                    break;

                case Chireiden.Silverfish.SimCard.circleofhealing:
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
                        if (mnn.name == Chireiden.Silverfish.SimCard.northshirecleric) i++;
                        if (mnn.name == Chireiden.Silverfish.SimCard.lightwarden) i++;
                    }
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.name == Chireiden.Silverfish.SimCard.northshirecleric) i--;
                        if (mnn.name == Chireiden.Silverfish.SimCard.lightwarden) i--;
                    }
                    if (i >= 1) return pen;

                    // no pen if we have slam

                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == Chireiden.Silverfish.SimCard.slam && m.Hp < 2) return pen;
                        if (hc.card.name == Chireiden.Silverfish.SimCard.backstab) return pen;
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
            Chireiden.Silverfish.SimCard name = card.name;
            if (!cardDrawBattleCryDatabase.ContainsKey(name)) return 0;
            if (name == Chireiden.Silverfish.SimCard.wrath && card.cardIDenum != Chireiden.Silverfish.SimCard.EX1_154b) return 0;
            if (name == Chireiden.Silverfish.SimCard.nourish && card.cardIDenum != Chireiden.Silverfish.SimCard.EX1_164b) return 0;
            if (name == Chireiden.Silverfish.SimCard.tracking) return -1;            

            int carddraw = cardDrawBattleCryDatabase[name];
            if (carddraw == 0)
            {
                switch(name)
                {
                    case Chireiden.Silverfish.SimCard.harrisonjones:
                        carddraw = p.enemyWeapon.Durability;
                        if (carddraw == 0 && (p.enemyHeroStartClass != TAG_CLASS.DRUID && p.enemyHeroStartClass != TAG_CLASS.MAGE && p.enemyHeroStartClass != TAG_CLASS.WARLOCK && p.enemyHeroStartClass != TAG_CLASS.PRIEST)) return 5;
                        break;

                    case Chireiden.Silverfish.SimCard.divinefavor:
                        carddraw = p.enemyAnzCards - (p.owncards.Count);
                        if (carddraw <= 0) return 500;
                        break;

                    case Chireiden.Silverfish.SimCard.battlerage:
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
                                    if (hc.card.type == Chireiden.Silverfish.SimCardtype.MOB) return 500;
                                }
                                if (p.owncards.Count < 2) return -10;
                                else if (p.owncards.Count < 4) return -2;
                                else if (p.owncards.Count < 6) return 0;
                                else if (p.owncards.Count < 9) return 3;
                            }
                            return 500;
                        }
                        break;

                    case Chireiden.Silverfish.SimCard.slam:
                        if (target != null && target.Hp >= 3) carddraw = 1;
                        if (carddraw == 0) return 4;
                        break;

                    case Chireiden.Silverfish.SimCard.mortalcoil:
                        if (target != null && target.Hp == 1) carddraw = 1;
                        if (carddraw == 0) return 15;
                        break;

                    case Chireiden.Silverfish.SimCard.quickshot:
                        carddraw = (p.owncards.Count > 0) ? 0 : 1;
                        if (carddraw == 0) return 4;
                        break;

                    case Chireiden.Silverfish.SimCard.thoughtsteal:
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
                    
                    case Chireiden.Silverfish.SimCard.mindvision:
                        carddraw = Math.Min(1, p.enemyAnzCards);
                        if (carddraw != 1)
                        {
                            int scales = 0;
                            foreach (Minion mnn in p.ownMinions)
                            {
                                if (this.spellDependentDatabase.ContainsKey(mnn.name))
                                    if(mnn.name == Chireiden.Silverfish.SimCard.lorewalkercho) pen += 20; //if(spellDependentDatabase[mnn.name] == 0);
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
                        
                    case Chireiden.Silverfish.SimCard.echoofmedivh:
                        if (p.ownMinions.Count == 0) return 500;
                        return 0;
                        break;
                        
                    case Chireiden.Silverfish.SimCard.tinkertowntechnician:
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if ((TAG_RACE)mnn.handcard.card.Race != TAG_RACE.MECHANICAL) pen += 4;
                        }
                        break;

                    case Chireiden.Silverfish.SimCard.markofyshaarj:
                        if ((TAG_RACE)target.handcard.card.Race == TAG_RACE.PET) carddraw = 1;
                        break;

                    case Chireiden.Silverfish.SimCard.servantofkalimos:
                        if (p.anzOwnElementalsLastTurn > 0) carddraw = 1;
                        break;                        

                    default:
                        break;
                }
            }
            
            if (name == Chireiden.Silverfish.SimCard.farsight || name == Chireiden.Silverfish.SimCard.callpet) pen -= 10;
            
            if (name == Chireiden.Silverfish.SimCard.lifetap)
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
                        if (m.name == Chireiden.Silverfish.SimCard.doomsayer) return 2;
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
                        c = cdb.getCardDataFromID(ge.cardid);
                        if (cardDrawDeathrattleDatabase.ContainsKey(c.name)) prevCardDraw++;
                        else if (c.type == Chireiden.Silverfish.SimCardtype.SPELL && cardDrawBattleCryDatabase.ContainsKey(c.name)) prevCardDraw++;
                    }
                }
                return Math.Max(-carddraw + 2 * (p.optionsPlayedThisTurn - prevCardDraw) + p.ownMaxMana - p.mana, 0);
            }

            if (p.owncards.Count + carddraw > 10) return 15 * (p.owncards.Count + carddraw - 10);
            if (p.ownMaxMana > 3 && p.owncards.Count + p.cardsPlayedThisTurn > 7) return (5 * carddraw) + 1;

            int tmp = 2 * p.optionsPlayedThisTurn + p.ownMaxMana - p.mana;
            int diff = 0;
            switch (card.name)
            {
                case Chireiden.Silverfish.SimCard.solemnvigil:
                    tmp -= 2 * p.diedMinions.Count;
                    foreach (Action a in p.playactions)
                    {
                        if (a.actionType == actionEnum.playcard && this.cardDrawBattleCryDatabase.ContainsKey(a.card.card.name)) tmp -= 2;
                    }
                    break;
                case Chireiden.Silverfish.SimCard.echoofmedivh:
                    diff = p.ownMinions.Count - prozis.ownMinions.Count;
                    if (diff > 0) tmp -= 2 * diff;
                    break;
                case Chireiden.Silverfish.SimCard.bloodwarriors:
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
            if (card.type == Chireiden.Silverfish.SimCardtype.SPELL)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == Chireiden.Silverfish.SimCard.gadgetzanauctioneer) carddraw++;
                }
            }

            if (card.type == Chireiden.Silverfish.SimCardtype.MOB && (TAG_RACE)card.Race == TAG_RACE.PET)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == Chireiden.Silverfish.SimCard.starvingbuzzard) carddraw++;
                }
            }

            if (carddraw == 0) return 0;
            if (p.owncards.Count >= 5) return 0;

            
            if (card.cost > 0) pen = -carddraw + p.ownMaxMana - p.mana + p.optionsPlayedThisTurn;

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

            if (!this.randomEffects.ContainsKey(card.name) && !(this.cardDrawBattleCryDatabase.ContainsKey(card.name) && card.type != Chireiden.Silverfish.SimCardtype.SPELL))
            {
                return 0;
            }

            if (card.name == Chireiden.Silverfish.SimCard.brawl)
            {
                return 0;
            }

            if ((card.name == Chireiden.Silverfish.SimCard.cleave || card.name == Chireiden.Silverfish.SimCard.multishot) && p.enemyMinions.Count == 2)
            {
                return 0;
            }

            if ((card.name == Chireiden.Silverfish.SimCard.deadlyshot) && p.enemyMinions.Count == 1)
            {
                return 0;
            }

            if ((card.name == Chireiden.Silverfish.SimCard.arcanemissiles || card.name == Chireiden.Silverfish.SimCard.avengingwrath)
                && p.enemyMinions.Count == 0)
            {
                return 0;
            }

            int cards = 0;
            cards = this.randomEffects.ContainsKey(card.name) ? this.randomEffects[card.name] : this.cardDrawBattleCryDatabase[card.name];

            bool first = true;
            bool hasgadget = false;
            bool hasstarving = false;
            bool hasknife = false;
            bool hasFlamewaker = false;
            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.name == Chireiden.Silverfish.SimCard.gadgetzanauctioneer)
                {
                    hasgadget = true;
                }

                if (mnn.name == Chireiden.Silverfish.SimCard.starvingbuzzard)
                {
                    hasstarving = true;
                }

                if (mnn.name == Chireiden.Silverfish.SimCard.knifejuggler)
                {
                    hasknife = true;
                }

                if (mnn.name == Chireiden.Silverfish.SimCard.flamewaker)
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
                    && (p.ownHeroAblility.card.name == Chireiden.Silverfish.SimCard.totemiccall || p.ownHeroAblility.card.name == Chireiden.Silverfish.SimCard.lifetap || p.ownHeroAblility.card.name == Chireiden.Silverfish.SimCard.soultap))
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
                    if (card.name == Chireiden.Silverfish.SimCard.knifejuggler && card.type == Chireiden.Silverfish.SimCardtype.MOB)
                    {
                        continue;
                    }

                    if (this.cardDrawBattleCryDatabase.ContainsKey(a.card.card.name))
                    {
                        continue;
                    }

                    if (this.lethalHelpers.ContainsKey(a.card.card.name))
                    {
                        continue;
                    }

                    if (hasgadget && card.type == Chireiden.Silverfish.SimCardtype.SPELL)
                    {
                        continue;
                    }

                    if (hasFlamewaker && card.type == Chireiden.Silverfish.SimCardtype.SPELL)
                    {
                        continue;
                    }

                    if (hasstarving && (TAG_RACE)card.Race == TAG_RACE.PET)
                    {
                        continue;
                    }

                    if (hasknife && card.type == Chireiden.Silverfish.SimCardtype.MOB)
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
            switch (name)
            {
                case Chireiden.Silverfish.SimCard.troggbeastrager: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.PET);
                    if (hc != null) return -5;
                    break;
                case Chireiden.Silverfish.SimCard.grimestreetsmuggler: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                    if (hc != null) return -5;
                    break;
                case Chireiden.Silverfish.SimCard.donhancho: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                    if (hc != null) return -20;
                    break;
                case Chireiden.Silverfish.SimCard.deathaxepunisher: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.LIFESTEAL);
                    if (hc != null) return -10;
                    break;
                case Chireiden.Silverfish.SimCard.grimscalechum: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.MURLOC);
                    if (hc == null) return -5;
                    break;
                case Chireiden.Silverfish.SimCard.grimestreetpawnbroker: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Weapon);
                    if (hc == null) return -5;
                    break;
                case Chireiden.Silverfish.SimCard.grimestreetoutfitter: 
                    foreach (Handmanager.Handcard hc1 in p.owncards)
                    {
                        if (hc1.card.type == Chireiden.Silverfish.SimCardtype.MOB) anz++;
                    }
                    anz--; 
                    if (anz > 0) return -1 * anz * 4;
                    else return 5;
                    break;
                case Chireiden.Silverfish.SimCard.themistcaller: 
                    foreach (Handmanager.Handcard hc1 in p.owncards)
                    {
                        if (hc1.card.type == Chireiden.Silverfish.SimCardtype.MOB) anz++;
                    }
                    anz--; 
                    anz += p.ownDeckSize / 4;
                    return -1 * anz * 4;
                    break;
                case Chireiden.Silverfish.SimCard.hobartgrapplehammer: 
                    foreach (Handmanager.Handcard hc2 in p.owncards)
                    {
                        if (hc2.card.type == Chireiden.Silverfish.SimCardtype.WEAPON) anz++;
                    }
                    if (anz == 0) return 2;
                    else return -1 * anz * 2;
                    break;
                case Chireiden.Silverfish.SimCard.smugglerscrate: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.PET);
                    if (hc != null) return -10;
                    else return 10;
                    break;
                case Chireiden.Silverfish.SimCard.stolengoods: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.TAUNT);
                    if (hc != null) return -15;
                    else return 10;
                    break;
                case Chireiden.Silverfish.SimCard.smugglersrun: 
                    foreach (Handmanager.Handcard hc3 in p.owncards)
                    {
                        if (hc3.card.type == Chireiden.Silverfish.SimCardtype.MOB) anz++;
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
                    if (this.cardDiscardDatabase.ContainsKey(hc.card.name)) continue;
                    switch (hc.card.name)
                    {
                        case Chireiden.Silverfish.SimCard.silverwaregolem: pen -= 12; continue;
                        case Chireiden.Silverfish.SimCard.fistofjaraxxus: pen -= 6; continue;
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
                case Chireiden.Silverfish.SimCard.sanguinereveler: goto case Chireiden.Silverfish.SimCard.shadowflame;
                case Chireiden.Silverfish.SimCard.ravenouspterrordax: goto case Chireiden.Silverfish.SimCard.shadowflame;
                case Chireiden.Silverfish.SimCard.shadowflame:
                    if (target == null || !target.Ready) return 0;
                    else return 1;
                case Chireiden.Silverfish.SimCard.deathwing:
                    if (p.mobsplayedThisTurn >= 1) return 500;
                    break;
                case Chireiden.Silverfish.SimCard.twistingnether: goto case Chireiden.Silverfish.SimCard.brawl;
                case Chireiden.Silverfish.SimCard.doompact: goto case Chireiden.Silverfish.SimCard.brawl;
                case Chireiden.Silverfish.SimCard.brawl:
                    if (p.mobsplayedThisTurn >= 1) return 500;
                    
                    if (name == Chireiden.Silverfish.SimCard.brawl && p.ownMinions.Count + p.enemyMinions.Count <= 1) return 500;
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
                    switch (target.handcard.card.name)
                    {
                        case Chireiden.Silverfish.SimCard.lepergnome: return -2;
                        case Chireiden.Silverfish.SimCard.backstreetleper: return -2;
                        case Chireiden.Silverfish.SimCard.firesworn: return -2;
                        case Chireiden.Silverfish.SimCard.zombiechow:
                            if (p.anzOwnAuchenaiSoulpriest > 0) return -5;
                            else return 500;
                        case Chireiden.Silverfish.SimCard.corruptedhealbot:
                            if (p.anzOwnAuchenaiSoulpriest > 0) return -8;
                            else return 500;
                        default:
                            int up = 0;
                            foreach (Minion m in p.ownMinions)
                            {
                                switch (m.handcard.card.name)
                                {
                                    case Chireiden.Silverfish.SimCard.manawyrm: goto case Chireiden.Silverfish.SimCard.lightwarden;
                                    case Chireiden.Silverfish.SimCard.flamewaker: goto case Chireiden.Silverfish.SimCard.lightwarden;
                                    case Chireiden.Silverfish.SimCard.archmageantonidas: goto case Chireiden.Silverfish.SimCard.lightwarden;
                                    case Chireiden.Silverfish.SimCard.gadgetzanauctioneer: goto case Chireiden.Silverfish.SimCard.lightwarden;
                                    case Chireiden.Silverfish.SimCard.manaaddict: goto case Chireiden.Silverfish.SimCard.lightwarden;
                                    case Chireiden.Silverfish.SimCard.redmanawyrm: goto case Chireiden.Silverfish.SimCard.lightwarden;
                                    case Chireiden.Silverfish.SimCard.summoningstone: goto case Chireiden.Silverfish.SimCard.lightwarden;
                                    case Chireiden.Silverfish.SimCard.wickedwitchdoctor: goto case Chireiden.Silverfish.SimCard.lightwarden;
                                    case Chireiden.Silverfish.SimCard.holychampion: goto case Chireiden.Silverfish.SimCard.lightwarden;
                                    case Chireiden.Silverfish.SimCard.lightwarden:
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
                        case Chireiden.Silverfish.SimCard.unwillingsacrifice:
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

                if (m.allreadyAttacked && name != Chireiden.Silverfish.SimCard.execute)
                {
                    return 50;
                }

                if (name == Chireiden.Silverfish.SimCard.shadowwordpain)
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

                if (name == Chireiden.Silverfish.SimCard.mindcontrol && (m.name == Chireiden.Silverfish.SimCard.direwolfalpha || m.name == Chireiden.Silverfish.SimCard.raidleader || m.name == Chireiden.Silverfish.SimCard.flametonguetotem) && p.enemyMinions.Count == 1)
                {
                    pen = 50;
                }

                if (m.name == Chireiden.Silverfish.SimCard.doomsayer)
                {
                    pen = 5;
                }

            }

            return pen;
        }

        private int getSpecialCardComboPenalitys(Chireiden.Silverfish.SimCard card, Minion target, Playfield p)
        {
            bool lethal = p.isLethalCheck;
            Chireiden.Silverfish.SimCard name = card.name;

            if (lethal && card.type == Chireiden.Silverfish.SimCardtype.MOB)
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
                                if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.PET && mm.Ready) return 0;
                            }
                            break;
                        case 2:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.MECHANICAL && mm.Ready) return 0;
                            }
                            break;
                        case 3:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.MURLOC && mm.Ready) return 0;
                            }
                            break;
                        case 4:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.PIRATE && mm.Ready) return 0;
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
                                if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.DEMON && mm.Ready) return 0;
                            }
                            break;
                        case 9:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((TAG_RACE)mm.handcard.card.Race == TAG_RACE.TOTEM && mm.Ready) return 0;
                            }
                            break;
                        case 10:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.name == Chireiden.Silverfish.SimCard.cthun && mm.Ready) return 0;
                            }
                            break;
                    }
                    return 500;
                }
                else
                {
                    if ((name == Chireiden.Silverfish.SimCard.rendblackhand && target != null) && !target.own)
                    {
                        if ((target.taunt && target.handcard.card.rarity == 5) || target.handcard.card.name == Chireiden.Silverfish.SimCard.malganis)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards)
                            {
                                if ((TAG_RACE)hc.card.Race == TAG_RACE.DRAGON) return 0;
                            }
                        }
                        return 500;
                    }

                    if (name == Chireiden.Silverfish.SimCard.theblackknight)
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
                                if (mm.Ready && (mm.handcard.card.name == Chireiden.Silverfish.SimCard.lightwarden || mm.handcard.card.name == Chireiden.Silverfish.SimCard.holychampion)) beasts++;
                            }
                            if (beasts == 0) return 500;
                        }
                        else
                        {
                            if (!(name == Chireiden.Silverfish.SimCard.nightblade || card.Charge || this.silenceDatabase.ContainsKey(name) || this.DamageTargetDatabase.ContainsKey(name) || ((TAG_RACE)card.Race == TAG_RACE.PET && p.ownMinions.Find(x => x.name == Chireiden.Silverfish.SimCard.tundrarhino) != null) || p.owncards.Find(x => x.card.name == Chireiden.Silverfish.SimCard.charge) != null))
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
                case Chireiden.Silverfish.SimCard.hobartgrapplehammer: return -5; 
                case Chireiden.Silverfish.SimCard.bloodsailraider: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case Chireiden.Silverfish.SimCard.captaingreenskin: if (p.ownWeapon.Durability == 0) return 10; return 0; 
                case Chireiden.Silverfish.SimCard.luckydobuccaneer: if (!(p.ownWeapon.Durability > 0 && p.ownWeapon.Angr > 2)) return 10; return 0; 
                case Chireiden.Silverfish.SimCard.nagacorsair: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case Chireiden.Silverfish.SimCard.goblinautobarber: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case Chireiden.Silverfish.SimCard.dreadcorsair: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case Chireiden.Silverfish.SimCard.grimestreetpawnbroker: 
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == Chireiden.Silverfish.SimCardtype.WEAPON) return 0;
                    return 5;
                case Chireiden.Silverfish.SimCard.bloodsailcultist: ; 
                    if (p.ownWeapon.Durability > 0) foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.PIRATE) return 0;
                    return 8;
                case Chireiden.Silverfish.SimCard.ravasaurrunt: 
                    if (p.ownMinions.Count < 2) return 5;
                    break;
                case Chireiden.Silverfish.SimCard.nestingroc: 
                    if (p.ownMinions.Count < 2) return 5;
                    break;
                case Chireiden.Silverfish.SimCard.gentlemegasaur: 
                    targets = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.MURLOC) targets++;
                    }
                    return 20 - targets * 5;
                case Chireiden.Silverfish.SimCard.primalfinlookout: 
                    targets = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.MURLOC) targets++;
                    }
                    return 20 - targets * 5;
                case Chireiden.Silverfish.SimCard.spiritecho: 
                    if (p.ownQuest.Id == Chireiden.Silverfish.SimCard.UNG_942)
                    {
                        targets = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.MURLOC) targets++;
                        }
                        if (targets > 1) return -7;
                        return 10;
                    }
                    else if (p.ownMinions.Count < 2) return 7;
                    return 0;
                case Chireiden.Silverfish.SimCard.evolvingspores: 
                    if (p.ownMinions.Count < 3) return 15 - p.ownMinions.Count * 5;
                    return 0;
                case Chireiden.Silverfish.SimCard.livingmana: 
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
                case Chireiden.Silverfish.SimCard.elisethetrailblazer: return -7; 
                case Chireiden.Silverfish.SimCard.cracklingrazormaw:   
                    if (target != null) return 0;
                    return 5;
                case Chireiden.Silverfish.SimCard.dinomancy: return -7; 
                case Chireiden.Silverfish.SimCard.moltenblade: return -10; 
                case Chireiden.Silverfish.SimCard.gluttonousooze: goto case Chireiden.Silverfish.SimCard.acidicswampooze;
                case Chireiden.Silverfish.SimCard.acidicswampooze:
                    if (p.enemyWeapon.Angr > 0) return 0;
                    if (p.enemyHeroName == HeroEnum.shaman || p.enemyHeroName == HeroEnum.warrior || p.enemyHeroName == HeroEnum.thief || p.enemyHeroName == HeroEnum.pala) return 10;
                    if (p.enemyHeroName == HeroEnum.hunter) return 6;
                    return 0;
                case Chireiden.Silverfish.SimCard.darkshirecouncilman:
                    if (p.enemyMinions.Count == 0)
                    {
                        List<Handmanager.Handcard> temp = new List<Handmanager.Handcard>(p.owncards);
                        temp.Sort((a, b) => a.card.cost.CompareTo(b.card.cost)); 
                        int cnum = 0;
                        int pcards = 0;
                        int nextTurnMana = p.ownMaxMana + 1;
                        foreach (Handmanager.Handcard hc in temp)
                        {
                            if (hc.card.name == name && cnum == 0)
                            {
                                cnum++;
                                continue;
                            }
                            nextTurnMana -= hc.card.cost;
                            if (nextTurnMana < 0) break;
                            else pcards++;
                        }
                        return -3 * pcards;
                    }
                    break;
                case Chireiden.Silverfish.SimCard.deadmanshand: 
                    if (p.owncards.Count > 2) return -5 * p.owncards.Count;
                    break;
                case Chireiden.Silverfish.SimCard.bringiton: 
                    return 3 * p.enemyAnzCards * (11 - p.enemyMaxMana);
                case Chireiden.Silverfish.SimCard.strongshellscavenger:
                    int tmp = 0;
                    foreach (Minion m in p.ownMinions) if (m.taunt) tmp++;
                    return 12 - tmp * 2;

            }

            if (name == Chireiden.Silverfish.SimCard.unstableportal && p.owncards.Count <= 9) return -15;
            if (name == Chireiden.Silverfish.SimCard.lunarvisions && p.owncards.Count <= 8) return -5;

            if (name == Chireiden.Silverfish.SimCard.azuredrake)
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
                if (p.ownHeroStartClass == TAG_CLASS.DRUID)
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
                        if (hc.card.name == Chireiden.Silverfish.SimCard.menageriewarden) { menageriewarden = true; continue; }
                        if ((TAG_RACE)hc.card.Race == TAG_RACE.PET && hc.card.cost <= p.ownMaxMana) pet = true;
                    }
                    if (menageriewarden && pet) pen += 23;
                }
                return pen;
            }

            if (name == Chireiden.Silverfish.SimCard.manatidetotem)
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

            if (name == Chireiden.Silverfish.SimCard.menageriewarden)
            {
                if (target != null && (TAG_RACE)target.handcard.card.Race == TAG_RACE.PET) return 0;
                else return 10;
            }

            if (name == Chireiden.Silverfish.SimCard.duplicate)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == Chireiden.Silverfish.SimCard.mirrorentity)
                    {
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.handcard.card.Attack >= 3 && this.UsefulNeedKeepDatabase.ContainsKey(mnn.name)) return 0;
                        }
                        return 16;
                    }
                }
            }

            if ((name == Chireiden.Silverfish.SimCard.lifetap || name == Chireiden.Silverfish.SimCard.soultap) && p.owncards.Count <= 9)
            {
                 foreach (Minion mnn in p.ownMinions)
                 {
                     if (mnn.name == Chireiden.Silverfish.SimCard.wilfredfizzlebang && !mnn.silenced) return -20;
                 }
            }

            if (name == Chireiden.Silverfish.SimCard.forbiddenritual)
            {
                if (p.ownMinions.Count == 7 || p.mana == 0) return 500;
                return 7;
            }
            
            if (name == Chireiden.Silverfish.SimCard.competitivespirit)
            {
                if (p.ownMinions.Count < 1) return 500;
                if (p.ownMinions.Count > 2) return 0;
                return (15 - 5 * p.ownMinions.Count);
            }

            if (name == Chireiden.Silverfish.SimCard.shifterzerus) return 500;

            if (card.name == Chireiden.Silverfish.SimCard.daggermastery)
            {
                if (p.ownWeapon.Angr >= 2 || p.ownWeapon.Durability >= 2) return 5;
            }

            if (card.name == Chireiden.Silverfish.SimCard.upgrade)
            {
                if (p.ownWeapon.Durability == 0)
                {
                    if (weaponInHandAttackNextTurn(p) > 0) return 10;
                    return 0;
                }
            }

            if (card.name == Chireiden.Silverfish.SimCard.malchezaarsimp && p.owncards.Count > 2) return 5;

            if (card.name == Chireiden.Silverfish.SimCard.baronrivendare)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == Chireiden.Silverfish.SimCard.deathlord || mnn.name == Chireiden.Silverfish.SimCard.zombiechow || mnn.name == Chireiden.Silverfish.SimCard.dancingswords) return 30;
                }
            }

            //rule for coin on early game
            if (p.ownMaxMana < 3 && card.name == Chireiden.Silverfish.SimCard.thecoin)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.manacost <= p.ownMaxMana && hc.card.type == Chireiden.Silverfish.SimCardtype.MOB) return 5;
                }

            }
            
            //destroySecretPenality
            pen = 0;
            switch (card.name)
            {
                case Chireiden.Silverfish.SimCard.flare: 
                    foreach (Minion mn in p.ownMinions) if (mn.stealth) pen++;
                    foreach (Minion mn in p.enemyMinions) if (mn.stealth) pen--;
                    if (p.enemySecretCount > 0)
                    {
                        bool canPlayMinion = false;
                        bool canPlaySpell = false;
                        foreach(Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == Chireiden.Silverfish.SimCard.flare) continue;
                            if (hc.card.cost <= p.mana - 2) 
                            {
                                if (!canPlayMinion && hc.card.type == Chireiden.Silverfish.SimCardtype.MOB)
                                {
                                    
                                    int tmp = p.getSecretTriggersByType(0, true, false, target);
                                    if (tmp > 0) pen -= tmp * 50;
                                    canPlayMinion = true;
                                    continue;
                                }
                                if (!canPlaySpell && hc.card.type == Chireiden.Silverfish.SimCardtype.SPELL)
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
                            case TAG_CLASS.MAGE: pen += 5; break;
                            case TAG_CLASS.PALADIN: pen += 5; break;
                            case TAG_CLASS.HUNTER: pen += 5; break;
                        }
                    }
                    break;
                case Chireiden.Silverfish.SimCard.eaterofsecrets: 
                    if (p.enemySecretCount > 0)
                    {
                        pen -= p.enemySecretCount * 50;
                        if (p.playactions.Count == 0) pen -= 5;
                    }
                    else
                    {
                        switch (p.enemyHeroStartClass)
                        {
                            case TAG_CLASS.MAGE: pen += 5; break;
                            case TAG_CLASS.PALADIN: pen += 5; break;
                            case TAG_CLASS.HUNTER: pen += 5; break;
                        }
                    }
                    break;
                case Chireiden.Silverfish.SimCard.kezanmystic: 
                    if (p.enemySecretCount == 1 && p.playactions.Count == 0) pen -= 50;
                    break;
                case Chireiden.Silverfish.SimCard.水晶学:
                    if (p.owncards.Count <= 8) return -50;
                    else return 50;
                    break;
                //风驰电掣
                //判断手牌中随从数量，
                //此处大于或等于2个时使用
                case Chireiden.Silverfish.SimCard.smugglersrun:
                    {
                        int iii = 0;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.type == Chireiden.Silverfish.SimCardtype.MOB)
                            {
                                iii++;
                            }
                        }
                        if (iii >= 3) return -30;//此处为30考虑到可能会先开车后水晶学
                        else return 30;
                    }
                    break;
                //神恩术 divinefavor
                case Chireiden.Silverfish.SimCard.divinefavor:
                    if (p.enemycarddraw - p.owncards.Count >= 2) return -50;
                    else return 50;
                    break;
                //污手街供货商 grimestreetoutfitter
                //和开车一样的道理
                case Chireiden.Silverfish.SimCard.grimestreetoutfitter:
                    {
                        int iii = 0;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.type == Chireiden.Silverfish.SimCardtype.MOB)
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
                            if (hc.card.type == Chireiden.Silverfish.SimCardtype.MOB)
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
                case Chireiden.Silverfish.SimCard.mechwarper:
                    return -25;
                    break;

               

                //分裂战斧
                case Chireiden.Silverfish.SimCard.分裂战斧: 
                  int ownTotemsCount= 0;
                  foreach (Minion m in p.ownMinions)
                        {
                        if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.TOTEM) ownTotemsCount++;
                        }
                    return 5 - ownTotemsCount * 5;
                //风怒小陀螺
                case Chireiden.Silverfish.SimCard.whirlingzapomatic:
                    if (p.enemyHeroName == HeroEnum.warlock) return -10;

                    return 0;

                //风暴聚合器
                case Chireiden.Silverfish.SimCard.风暴聚合器:
                    if (p.ownMinions.Count < 7) return 95 - p.ownMinions.Count * 25;
                    return 0;

                //图腾之力和图腾潮涌惩罚
                case Chireiden.Silverfish.SimCard.totemicmight:
                    ownTotemsCount = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.TOTEM) ownTotemsCount++;
                    }
                    return 13 - ownTotemsCount * 2;
                case Chireiden.Silverfish.SimCard.图腾潮涌:
                    ownTotemsCount = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.TOTEM) ownTotemsCount++;
                    }
                    return 13 - ownTotemsCount * 2;
                //怪盗图腾
                case Chireiden.Silverfish.SimCard.怪盗图腾:
                    return -2;
                //暗金教侍从添加

                case Chireiden.Silverfish.SimCard.kaballackey:
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
                            if (hc.card.Secret && p.mana >= (hc.card.cost + card.cost))
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
                case Chireiden.Silverfish.SimCard.madscientist: return -6;
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
                case Chireiden.Silverfish.SimCard.medivhsvalet:
                    if (p.ownSecretsIDList.Count < 1) return 80;
                    if (target.isHero) return -5;
                    break;
                //爆炸符文
                case Chireiden.Silverfish.SimCard.explosiverunes: return -8;
                //复制
                case Chireiden.Silverfish.SimCard.duplicate:
                    bool found1 = false;
                    foreach (Minion mnn1 in p.ownMinions)
                    {
                        if (mnn1.name == Chireiden.Silverfish.SimCard.kabalcrystalrunner || mnn1.name == Chireiden.Silverfish.SimCard.云雾王子) found1 = true;
                    
                    }
                    if (found1) return -10;
                    
                    else return -5;
                    break;
                
                 //寒冰屏障
                case Chireiden.Silverfish.SimCard.iceblock: 
                    if (p.ownHero.Hp < 20) return -8;
                    else return -3;
                    break;
                //法术反制
                case Chireiden.Silverfish.SimCard.counterspell: return -6;
                //火焰结界
                case Chireiden.Silverfish.SimCard.火焰结界:
                    if (p.enemyMinions.Count == 2) return -8;
                    if (p.enemyMinions.Count == 3) return -12;
                    if (p.enemyMinions.Count >= 4) return -15;
                    else return -3;
                    break;
                
                //云雾王子
                case Chireiden.Silverfish.SimCard.cloudprince:
                    if (p.ownSecretsIDList.Count < 1) return 80;
                    if (target.isHero) return -5;
                    break;
                //艾露尼斯
                case Chireiden.Silverfish.SimCard.艾露尼斯:
                    if (p.owncards.Count >= 6) return 500;
                    else return -90;
                    break;
                //火冲
                case Chireiden.Silverfish.SimCard.fireblast:
                    if (target.isHero) return -2;
                    else return -1;
                    break;
                case Chireiden.Silverfish.SimCard.totemiccall:
                    if (lethal) return 20;
                    break;

                case Chireiden.Silverfish.SimCard.frostwolfwarlord:
                    if (p.ownMinions.Count == 0) pen += 5;
                    break;

                case Chireiden.Silverfish.SimCard.flametonguetotem:
                    if (p.ownMinions.Count == 0) return 100;
                    break;
                
                case Chireiden.Silverfish.SimCard.stampedingkodo:
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

                case Chireiden.Silverfish.SimCard.desperatestand: goto case Chireiden.Silverfish.SimCard.ancestralspirit;
                case Chireiden.Silverfish.SimCard.ancestralspirit:
                    if (!target.isHero)
                    {
                        if (!target.own)
                        {
                            if (target.name == Chireiden.Silverfish.SimCard.deathlord || target.name == Chireiden.Silverfish.SimCard.zombiechow || target.name == Chireiden.Silverfish.SimCard.dancingswords) return 0;
                            return 500;
                        }
                        else
                        {
                            if (this.specialMinions.ContainsKey(target.name)) return -5;
                            return 0;
                        }
                    }
                    break;

                case Chireiden.Silverfish.SimCard.houndmaster:
                    if (target == null) return 50;
                    break;

                case Chireiden.Silverfish.SimCard.beneaththegrounds: return -10;

                case Chireiden.Silverfish.SimCard.curseofrafaam: return -7;

                case Chireiden.Silverfish.SimCard.flameimp:
                    if (p.ownHero.Hp + p.ownHero.armor > 20) pen -= 3;
                    break;
             

                case Chireiden.Silverfish.SimCard.quartermaster:
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.name == Chireiden.Silverfish.SimCard.silverhandrecruit) return 0;
                    }
                    return 5;

                case Chireiden.Silverfish.SimCard.mysteriouschallenger: return -14;
                  

                case Chireiden.Silverfish.SimCard.biggamehunter:
                    if (target == null || target.own) return 40;
                    break;
                    
                case Chireiden.Silverfish.SimCard.emergencycoolant:
                    if (target != null && target.own) pen = 500;
                    break;

                case Chireiden.Silverfish.SimCard.shatteredsuncleric:
                    if (target == null) return 10;
                    break;

                case Chireiden.Silverfish.SimCard.argentprotector:
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

                case Chireiden.Silverfish.SimCard.facelessmanipulator:
                    if (target == null) return 50;
                    if (target.Angr >= 5 || target.handcard.card.cost >= 5 || (target.handcard.card.rarity == 5 || target.handcard.card.cost >= 3))
                    {
                        return 0;
                    }
                    return 49;

                case Chireiden.Silverfish.SimCard.rendblackhand:
                    if (target == null) return 15;
                    if (target.own) return 100;
                    if ((target.taunt && target.handcard.card.rarity == 5) || target.handcard.card.name == Chireiden.Silverfish.SimCard.malganis)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if ((TAG_RACE)hc.card.Race == TAG_RACE.DRAGON) return 0;
                        }
                    }
                    return 500;

                case Chireiden.Silverfish.SimCard.theblackknight:
                    if (target == null) return 50;
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.taunt && (target.Angr >= 3 || target.Hp >= 3)) return 0;
                    }
                    return 20;

                case Chireiden.Silverfish.SimCard.madderbomber: goto case Chireiden.Silverfish.SimCard.madbomber;
                case Chireiden.Silverfish.SimCard.madbomber:
                    pen = 0;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.Ready & mnn.Hp < 3) pen += 5;
                    }
                    return pen;

                case Chireiden.Silverfish.SimCard.sylvanaswindrunner:
                    if (p.enemyMinions.Count == 0) return 10;
                    break;

                case Chireiden.Silverfish.SimCard.betrayal:
                    if (!target.own && !target.isHero)
                    {
                        if (target.Angr == 0) return 30;
                        if (p.enemyMinions.Count == 1) return 30;
                    }
                    break;

                case Chireiden.Silverfish.SimCard.nerubianegg:
                    if (p.owncards.Find(x => this.attackBuffDatabase.ContainsKey(x.card.name)) != null || p.owncards.Find(x => this.tauntBuffDatabase.ContainsKey(x.card.name)) != null)
                    {
                        return -6;
                    }
                    break;

                case Chireiden.Silverfish.SimCard.bite:
                    if ((p.ownHero.numAttacksThisTurn == 0 || (p.ownHero.windfury && p.ownHero.numAttacksThisTurn == 1)) && !p.ownHero.frozen)
                    {

                    }
                    else return 20;
                    break;

                case Chireiden.Silverfish.SimCard.deadlypoison:
                    return -(p.ownWeapon.Durability - 1) * 2;

                case Chireiden.Silverfish.SimCard.coldblood:
                    if (lethal) return 0;
                    return 25;

                case Chireiden.Silverfish.SimCard.bloodmagethalnos: return 10;

                case Chireiden.Silverfish.SimCard.frostbolt:
                    if (!target.own && !target.isHero)
                    {
                        if (target.handcard.card.cost < 3 && !this.priorityDatabase.ContainsKey(target.handcard.card.name)) return 15;
                    }
                    return 0;

                case Chireiden.Silverfish.SimCard.poweroverwhelming:
                    if (target.own && !target.isHero && !target.Ready) return 500;
                    break;

                case Chireiden.Silverfish.SimCard.frothingberserker:
                    if (p.cardsPlayedThisTurn >= 1) pen = 5;
                    break;

                case Chireiden.Silverfish.SimCard.handofprotection:
                    if (!target.own)
                    {
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (!mm.divineshild) return 500;
                        }
                    }
                    if (target.Hp == 1) pen = 15;
                    break;

                case Chireiden.Silverfish.SimCard.wildgrowth: goto case Chireiden.Silverfish.SimCard.nourish;
                case Chireiden.Silverfish.SimCard.nourish:
                    if (p.ownMaxMana == 9 && !(p.ownHeroName == HeroEnum.thief && p.cardsPlayedThisTurn == 0)) return 500;
                    break;

                case Chireiden.Silverfish.SimCard.resurrect:
                    if (p.ownMaxMana < 6) return 50;
                    if (p.ownMinions.Count == 7) return 500;
                    if (p.ownMaxMana > 8) return 0;
                    if (p.OwnLastDiedMinion == Chireiden.Silverfish.SimCard.None) return 6;
                    return 0;

                case Chireiden.Silverfish.SimCard.lavashock:
                    if (p.ueberladung + p.lockedMana < 1) return 15;
                    return (3 - 3 * (p.ueberladung + p.lockedMana));

                case Chireiden.Silverfish.SimCard.edwinvancleef:
                    if (p.cardsPlayedThisTurn < 1) return 30;
                    else if (p.cardsPlayedThisTurn < 2) return 10;
                    else return 0;

                case Chireiden.Silverfish.SimCard.enhanceomechano:
                    if (p.ownMinions.Count == 0 && p.ownMaxMana < 5) return 500;
                    pen = 2 * (p.mana - 4 - p.mobsplayedThisTurn);
                    if (p.mobsplayedThisTurn < 1) pen += 30;
                    return pen;

                case Chireiden.Silverfish.SimCard.knifejuggler:
                    if (p.mobsplayedThisTurn >= 1) return 20;
                    break;

                case Chireiden.Silverfish.SimCard.flamewaker:
                    foreach (Action a in p.playactions)
                    {
                        if (a.actionType == actionEnum.playcard && a.card.card.type == Chireiden.Silverfish.SimCardtype.SPELL) return 30;
                    }
                    break;

                case Chireiden.Silverfish.SimCard.polymorph: goto case Chireiden.Silverfish.SimCard.hex;
                case Chireiden.Silverfish.SimCard.hex:
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

                case Chireiden.Silverfish.SimCard.ravagingghoul:
                    if (p.enemyMinions.Count == 0) return 7;
                    break;

                case Chireiden.Silverfish.SimCard.bookwyrm:
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

                case Chireiden.Silverfish.SimCard.grimestreetprotector:
                    if (p.ownMinions.Count == 1) return 10;
                    else if (p.ownMinions.Count == 0) return 20;
                    break;

                case Chireiden.Silverfish.SimCard.sunfuryprotector:
                    if (p.ownMinions.Count == 1) return 15;
                    else if (p.ownMinions.Count == 0) return 30;
                    break;

                case Chireiden.Silverfish.SimCard.defenderofargus:
                    if (p.ownMinions.Count == 1) return 30;
                    else if (p.ownMinions.Count == 0) return 50;
                    break;

                case Chireiden.Silverfish.SimCard.unearthedraptor:
                    if (target == null) return 10;
                    break;

                case Chireiden.Silverfish.SimCard.unleashthehounds:
                    if (p.enemyMinions.Count <= 1) return 20;
                    break;

                case Chireiden.Silverfish.SimCard.equality:
                    if (p.enemyMinions.Count <= 2 || (p.ownMinions.Count - p.enemyMinions.Count >= 1)) return 20;
                    break;

                case Chireiden.Silverfish.SimCard.bloodsailraider:
                    if (p.ownWeapon.Durability == 0)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.type == Chireiden.Silverfish.SimCardtype.WEAPON) return 10;
                        }
                    }
                    break;

                case Chireiden.Silverfish.SimCard.innerfire:
                    if (target.name == Chireiden.Silverfish.SimCard.lightspawn) return 500;
                    if (!target.Ready) return 20;
                    break;

                case Chireiden.Silverfish.SimCard.huntersmark:
                    if (!target.isHero)
                    {
                        if (target.own) return 500;
                        else if (target.Hp <= 4 && target.Angr <= 4 && !(target.poisonous && !target.silenced))
                        {
                            pen = 20;
                        }
                    }
                    break;

                case Chireiden.Silverfish.SimCard.crazedalchemist:
                    if (target != null) pen -= 1;
                    break;

                case Chireiden.Silverfish.SimCard.deathwing:
                    int prevDmg = 0;
                    foreach (Minion m1 in p.enemyMinions)
                    {
                        prevDmg += m1.Angr;
                    }
                    if (p.ownHero.Hp + p.ownHero.armor > prevDmg * 2) pen += p.ownMinions.Count * 10 + p.owncards.Count * 25;
                    break;

                case Chireiden.Silverfish.SimCard.deathwingdragonlord:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if ((TAG_RACE)hc.card.Race == TAG_RACE.DRAGON) pen -= 3;
                    }
                    pen += 3;
                    break;

                case Chireiden.Silverfish.SimCard.humility: goto case Chireiden.Silverfish.SimCard.aldorpeacekeeper;
                case Chireiden.Silverfish.SimCard.aldorpeacekeeper:
                    if (target != null)
                    {
                        if (target.own) pen = 500;
                        else if (target.Angr <= 3) pen = 30;
                        if (target.name == Chireiden.Silverfish.SimCard.lightspawn) pen = 500;
                    }
                    else pen = 40;
                    break;
            
                case Chireiden.Silverfish.SimCard.direwolfalpha: goto case Chireiden.Silverfish.SimCard.abusivesergeant;
                case Chireiden.Silverfish.SimCard.abusivesergeant:
                    int ready = 0;
                    foreach (Minion min in p.ownMinions)
                    {
                        if (min.Ready) ready++;
                    }
                    if (ready == 0) pen = 5;
                    break;
                    
                case Chireiden.Silverfish.SimCard.gangup:
                    if (this.GangUpDatabase.ContainsKey(target.handcard.card.name))
                    {
                        return (-5 - 1 * GangUpDatabase[target.handcard.card.name]);
                    }
                    else return 40;
                    
                case Chireiden.Silverfish.SimCard.defiasringleader:
                    if (p.cardsPlayedThisTurn == 0) pen = 10;
                    break;

                case Chireiden.Silverfish.SimCard.bloodknight:
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

                case Chireiden.Silverfish.SimCard.reincarnate:
                    if (target.own)
                    {
                        if (target.handcard.card.deathrattle || target.ancestralspirit >= 1 || target.desperatestand >= 1 || target.souloftheforest >= 1 || target.stegodon >= 1 || target.livingspores >= 1 || target.infest >= 1 || target.explorershat >= 1 || target.returnToHand >= 1 || target.deathrattle2 != null || target.enemyBlessingOfWisdom >= 1 || target.enemyPowerWordGlory >= 1) return 0;
                        if (target.handcard.card.Charge && ((target.numAttacksThisTurn == 1 && !target.windfury) || (target.numAttacksThisTurn == 2 && target.windfury))) return 0;
                        if (target.wounded || target.Angr < target.handcard.card.Attack || (target.silenced && this.specialMinions.ContainsKey(target.name))) return 0;
                        
                        bool hasOnMinionDiesMinion = false;
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.name == Chireiden.Silverfish.SimCard.scavenginghyena && target.handcard.card.Race == 20) hasOnMinionDiesMinion = true;
                            if (mnn.name == Chireiden.Silverfish.SimCard.flesheatingghoul || mnn.name == Chireiden.Silverfish.SimCard.cultmaster) hasOnMinionDiesMinion = true;
                        }
                        if (hasOnMinionDiesMinion) return 0;
                        return 500;
                    }
                    else
                    {
                        if (target.name == Chireiden.Silverfish.SimCard.nerubianegg && target.Angr <= 4 && !target.taunt) return 500;
                        if (target.taunt && !target.handcard.card.Taunt) return 0;
                        if (target.enemyBlessingOfWisdom >= 1 || target.enemyPowerWordGlory >= 1) return 0;
                        if (target.Angr > target.handcard.card.Attack || target.Hp > target.handcard.card.Health) return 0;
                        if (target.name == Chireiden.Silverfish.SimCard.abomination || target.name == Chireiden.Silverfish.SimCard.zombiechow || target.name == Chireiden.Silverfish.SimCard.unstableghoul || target.name == Chireiden.Silverfish.SimCard.dancingswords) return 0;
                        return 500;
                    }
                    break;

                case Chireiden.Silverfish.SimCard.divinespirit:
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
                                if (p.owncards.Find(x => x.card.name == Chireiden.Silverfish.SimCard.biggamehunter) != null && p.owncards.Find(x => x.card.name == Chireiden.Silverfish.SimCard.innerfire) != null && (target.Hp >= 4 || (p.owncards.Find(x => x.card.name == Chireiden.Silverfish.SimCard.divinespirit) != null && target.Hp >= 2)))
                                {
                                    return 0;
                                }
                                return 500;
                            }
                        }
                        else
                        {
                            // combo for killing with innerfire and biggamehunter
                            if (p.owncards.Find(x => x.card.name == Chireiden.Silverfish.SimCard.biggamehunter) != null && p.owncards.Find(x => x.card.name == Chireiden.Silverfish.SimCard.innerfire) != null && target.Hp >= 4)
                            {
                                return 0;
                            }
                            return 500;
                        }
                    }
                    break;
            }


            //------------------------------------------------------------------------------------------------------


            if ((p.ownHeroAblility.card.name == Chireiden.Silverfish.SimCard.totemiccall || p.ownHeroAblility.card.name == Chireiden.Silverfish.SimCard.totemicslam) && p.ownAbilityReady == false)
            {
                foreach (Action a in p.playactions)
                {
                    if (a.actionType == actionEnum.playcard && a.card.card.name == Chireiden.Silverfish.SimCard.draeneitotemcarver) return -1;
                    if (a.actionType == actionEnum.playcard && a.card.card.name == Chireiden.Silverfish.SimCard.图腾潮涌) return -1;
                    if (a.actionType == actionEnum.playcard && a.card.card.name == Chireiden.Silverfish.SimCard.totemicmight) return -1;
                    if (a.actionType == actionEnum.playcard && a.card.card.name == Chireiden.Silverfish.SimCard.分裂战斧) return -1;
                }
                if (p.owncards.Count > 1)
                {
                    if (card.type == Chireiden.Silverfish.SimCardtype.SPELL)
                    {
                        if (!(DamageTargetDatabase.ContainsKey(card.name) || DamageAllEnemysDatabase.ContainsKey(card.name)
                        || DamageAllDatabase.ContainsKey(card.name) || DamageRandomDatabase.ContainsKey(card.name)
                        || DamageTargetSpecialDatabase.ContainsKey(card.name) || DamageHeroDatabase.ContainsKey(card.name))) pen += 10;
                    }
                    else if (card.name == Chireiden.Silverfish.SimCard.frostwolfwarlord || card.name == Chireiden.Silverfish.SimCard.thingfrombelow || card.name == Chireiden.Silverfish.SimCard.draeneitotemcarver) return -1;
                    else pen += 10;
                }
            }



            if (target != null && (name == Chireiden.Silverfish.SimCard.sap || name == Chireiden.Silverfish.SimCard.dream || name == Chireiden.Silverfish.SimCard.kidnapper))
            {
                if (!target.own && (target.name == Chireiden.Silverfish.SimCard.theblackknight || name == Chireiden.Silverfish.SimCard.rendblackhand))
                {
                    return 50;
                }
            }

            if (!lethal && card.cardIDenum == Chireiden.Silverfish.SimCard.EX1_165t1) //druidoftheclaw	Charge
            {
                return 20;
            }


            if (lethal)
            {
                if (name == Chireiden.Silverfish.SimCard.corruption)
                {
                    int beasts = 0;
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.Ready && (mm.handcard.card.name == Chireiden.Silverfish.SimCard.questingadventurer || mm.handcard.card.name == Chireiden.Silverfish.SimCard.archmageantonidas || mm.handcard.card.name == Chireiden.Silverfish.SimCard.manaaddict || mm.handcard.card.name == Chireiden.Silverfish.SimCard.manawyrm || mm.handcard.card.name == Chireiden.Silverfish.SimCard.wildpyromancer)) beasts++;
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

                if (card.type == Chireiden.Silverfish.SimCardtype.SPELL)
                {
                    if (name == Chireiden.Silverfish.SimCard.vanish)
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

                        if (p.enemySecretCount > 0 && p.enemyHeroStartClass == TAG_CLASS.MAGE) return 0;

                        bool BeastReq = false;
                        bool MechReq = false;
                        bool PirateReq = false;
                        bool DragonReq = false;
                        if (target.handcard.card.battlecry)
                        {
                            if (this.dragonDependentDatabase.ContainsKey(target.name)) DragonReq = true;
                            switch (target.name)
                            {
                                //case Chireiden.Silverfish.SimCard.masterofceremonies:
                                case Chireiden.Silverfish.SimCard.ramwrangler: BeastReq = true; break;
                                case Chireiden.Silverfish.SimCard.druidofthefang: BeastReq = true; break;
                                case Chireiden.Silverfish.SimCard.goblinblastmage: MechReq = true; break;
                                case Chireiden.Silverfish.SimCard.tinkertowntechnician: MechReq = true; break;
                                case Chireiden.Silverfish.SimCard.shadydealer: if (!target.Ready && target.maxHp == 3) PirateReq = true; break;
                                case Chireiden.Silverfish.SimCard.gormoktheimpaler: if (p.ownMinions.Count > 4) return 0; break;
                                case Chireiden.Silverfish.SimCard.corerager: if (p.owncards.Count < 1) return 0; break;
                                case Chireiden.Silverfish.SimCard.drakonidcrusher: if (p.enemyHero.Hp < 16) return 0; break;
                                case Chireiden.Silverfish.SimCard.mindcontroltech: if (p.enemyMinions.Count > 3) return 0; break;
                                case Chireiden.Silverfish.SimCard.alexstraszaschampion: if (target.Ready) DragonReq = false; break;
                                case Chireiden.Silverfish.SimCard.twilightguardian: if (target.taunt) DragonReq = false; break;
                                case Chireiden.Silverfish.SimCard.wyrmrestagent: if (target.taunt) DragonReq = false; break;
                                case Chireiden.Silverfish.SimCard.blackwingtechnician: if (target.maxHp > 4) DragonReq = false; break;
                                case Chireiden.Silverfish.SimCard.twilightwhelp: if (target.maxHp > 1) DragonReq = false; break;
                                case Chireiden.Silverfish.SimCard.kingselekk: return 0; break;
                                case Chireiden.Silverfish.SimCard.gadgetzanjouster: if (target.maxHp == 2) return 0; break;
                                case Chireiden.Silverfish.SimCard.armoredwarhorse: if (!target.Ready) return 0; break;
                                case Chireiden.Silverfish.SimCard.masterjouster: if (!target.taunt) return 0; break;
                                case Chireiden.Silverfish.SimCard.tuskarrjouster: if (!target.Ready && p.ownHero.Hp < 26) return 0; break;
                            }
                        }

                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (this.spellDependentDatabase.ContainsKey(mnn.name) && mnn.entitiyID != target.entitiyID) return 0;
                            if (mnn.name == Chireiden.Silverfish.SimCard.starvingbuzzard && mnn.entitiyID != target.entitiyID && target.handcard.card.Race == 20) return 0;

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
                    if (hc.card.name == Chireiden.Silverfish.SimCard.kirintormage && p.mana >= hc.getManaCost(p))
 
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

            switch (c.name)
            {
                case Chireiden.Silverfish.SimCard.flare: return 0; break; 
                case Chireiden.Silverfish.SimCard.eaterofsecrets: return 0; break; 
                case Chireiden.Silverfish.SimCard.kezanmystic: 
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

            if ((c.name == Chireiden.Silverfish.SimCard.acidicswampooze || c.name == Chireiden.Silverfish.SimCard.gluttonousooze)
                && (p.enemyHeroStartClass == TAG_CLASS.WARRIOR || p.enemyHeroStartClass == TAG_CLASS.ROGUE || p.enemyHeroStartClass == TAG_CLASS.PALADIN))
            {
                if (p.enemyHeroStartClass == TAG_CLASS.ROGUE && p.enemyWeapon.Angr <= 2)
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

            if (p.enemyHeroStartClass == TAG_CLASS.HUNTER)
            {
                if (c.type == Chireiden.Silverfish.SimCardtype.MOB
                    && (attackedbefore == 0 || c.Health <= 4
                        || (p.enemyHero.Hp >= p.enemyHeroHpStarted && attackedbefore >= 1)))
                {
                    pen += 10;
                }
            }

            if (p.enemyHeroStartClass == TAG_CLASS.MAGE)
            {
                if (c.type == Chireiden.Silverfish.SimCardtype.MOB)
                {
                    Minion m = new Minion
                    {
                        Hp = c.Health,
                        maxHp = c.Health,
                        Angr = c.Attack,
                        taunt = c.Taunt,
                        name = c.name
                    };

                    // play first the small minion:
                    if ((!this.isOwnLowestInHand(m, p) && p.mobsplayedThisTurn == 0)
                        || (p.mobsplayedThisTurn == 0 && attackedbefore >= 1))
                    {
                        pen += 10;
                    }
                }

                if (c.type == Chireiden.Silverfish.SimCardtype.SPELL && p.cardsPlayedThisTurn == p.mobsplayedThisTurn)
                {
                    pen += 10;
                }
            }

            if (p.enemyHeroStartClass == TAG_CLASS.PALADIN)
            {
                if (c.type == Chireiden.Silverfish.SimCardtype.MOB)
                {
                    Minion m = new Minion
                    {
                        Hp = c.Health,
                        maxHp = c.Health,
                        Angr = c.Attack,
                        taunt = c.Taunt,
                        name = c.name
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

            if (p.enemyHeroStartClass == TAG_CLASS.HUNTER)
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
                                    if (a.card.card.type == Chireiden.Silverfish.SimCardtype.MOB || a.card.card.playrequires.Contains(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS))
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


            if (p.enemyHeroStartClass == TAG_CLASS.MAGE)
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
                                if (hc.card.type == Chireiden.Silverfish.SimCardtype.MOB && hc.canplayCard(p, true)) { pen += 10; break; }
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
                            pen += target.handcard.card.cost;
                            if (target.handcard.card.battlecry && target.name != Chireiden.Silverfish.SimCard.kingmukla) pen += 1;
                            return pen;
                        }
                    }
                    else return 0;
                }
            }

            if (p.enemyHeroStartClass == TAG_CLASS.PALADIN)
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
            if (choice == 1 && this.choose1database.ContainsKey(c.name))
            {
                c = cdb.getCardDataFromID(this.choose1database[c.name]);
            }
            else if (choice == 2 && this.choose2database.ContainsKey(c.name))
            {
                c = cdb.getCardDataFromID(this.choose2database[c.name]);
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
                if (card.card.type != Chireiden.Silverfish.SimCardtype.MOB) continue;
                Chireiden.Silverfish.SimCard c = card.card;
                m.Hp = c.Health;
                m.maxHp = c.Health;
                m.Angr = c.Attack;
                m.taunt = c.Taunt;
                m.name = c.name;
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
            enrageDatabase.Add(Chireiden.Silverfish.SimCard.aberrantberserker, 2);
            enrageDatabase.Add(Chireiden.Silverfish.SimCard.amaniberserker, 3);
            enrageDatabase.Add(Chireiden.Silverfish.SimCard.angrychicken, 5);
            enrageDatabase.Add(Chireiden.Silverfish.SimCard.bloodhoofbrave, 3);
            enrageDatabase.Add(Chireiden.Silverfish.SimCard.grommashhellscream, 6);
            enrageDatabase.Add(Chireiden.Silverfish.SimCard.ragingworgen, 2);
            enrageDatabase.Add(Chireiden.Silverfish.SimCard.spitefulsmith, 2);
            enrageDatabase.Add(Chireiden.Silverfish.SimCard.taurenwarrior, 3);
            enrageDatabase.Add(Chireiden.Silverfish.SimCard.warbot, 1);
        }

        private void setupHealDatabase()
        {
            HealAllDatabase.Add(Chireiden.Silverfish.SimCard.circleofhealing, 4);//allminions
            HealAllDatabase.Add(Chireiden.Silverfish.SimCard.darkscalehealer, 2);//all friends
            HealAllDatabase.Add(Chireiden.Silverfish.SimCard.holynova, 2);//to all own minions
            HealAllDatabase.Add(Chireiden.Silverfish.SimCard.treeoflife, 1000);//all friends

            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.amarawardenofhope, 40);
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.antiquehealbot, 8); //tohero
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.bindingheal, 5);
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.cultapothecary, 2);
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.drainlife, 2);//tohero
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.guardianofkings, 6);//tohero
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.holyfire, 5);//tohero
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.invocationofwater, 12);
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.jinyuwaterspeaker, 6);
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.priestessofelune, 4);//tohero
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.refreshmentvendor, 4);
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.renojackson, 25); //tohero
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.sacrificialpact, 5);//tohero
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.sealoflight, 4); //tohero
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.siphonsoul, 3); //tohero
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.tidalsurge, 4);
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.tournamentmedic, 2);
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.tuskarrjouster, 7);
            HealHeroDatabase.Add(Chireiden.Silverfish.SimCard.twilightdarkmender, 10);

            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.ancestralhealing, 1000);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.ancientoflore, 5);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.ancientsecrets, 5);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.bindingheal, 5);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.darkshirealchemist, 5);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.earthenringfarseer, 3);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.flashheal, 5);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.forbiddenhealing, 2);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.gadgetzansocialite, 2);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.heal, 4);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.healingtouch, 8);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.healingwave, 14);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.holylight, 6);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.hotspringguardian, 3);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.hozenhealer, 30);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.layonhands, 8);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.lesserheal, 2);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.lightofthenaaru, 3);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.moongladeportal, 6);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.voodoodoctor, 2);
            HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.willofmukla, 8);
            //HealTargetDatabase.Add(Chireiden.Silverfish.SimCard.divinespirit, 2);
        }

        private void setupDamageDatabase()
        {
            //DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.flameleviathan, 2);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.abomination, 2);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.abyssalenforcer, 3);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.anomalus, 8);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.barongeddon, 2);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.corruptedseer, 2);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.demonwrath, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.dragonfirepotion, 5);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.dreadinfernal, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.dreadscale, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.elementaldestruction, 4);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.excavatedevil, 3);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.explosivesheep, 2);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.felbloom, 4);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.felfirepotion, 5);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.hellfire, 3);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.lava, 2);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.lightbomb, 5);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.magmapulse, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.primordialdrake, 2);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.ravagingghoul, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.revenge, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.scarletpurifier, 2);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.sleepwiththefishes, 3);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.tentacleofnzoth, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.unstableghoul, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.volcanicpotion, 2);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.whirlwind, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.yseraawakens, 5);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.spiritlash, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.defile, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.bloodrazor, 1);
            DamageAllDatabase.Add(Chireiden.Silverfish.SimCard.bladestorm, 1);

            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.arcaneexplosion, 1);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.bladeflurry, 1);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.blizzard, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.consecration, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.cthun, 1);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.darkironskulker, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.fanofknives, 1);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.flamestrike, 4);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.holynova, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.invocationofair, 3);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.lightningstorm, 3);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.livingbomb, 5);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.locustswarm, 3);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.maelstromportal, 1);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.poisoncloud, 1);//todo 1 or 2
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.sergeantsally, 1);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.shadowflame, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.sporeburst, 1);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.starfall, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.stomp, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.swipe, 1);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.twilightflamecaller, 1);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.explodingbloatbat, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.deathstalkerrexxar, 2);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.deathanddecay, 3);
            DamageAllEnemysDatabase.Add(Chireiden.Silverfish.SimCard.bonestorm, 1);

            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.backstreetleper, 2);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.burningadrenaline, 2);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.curseofrafaam, 2);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.emeraldreaver, 1);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.frostblast, 3);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.headcrack, 2);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.invocationoffire, 6);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.lepergnome, 2);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.mindblast, 5);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.necroticaura, 3);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.nightblade, 3);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.purecold, 8);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.shadowbomber, 3);
            DamageHeroDatabase.Add(Chireiden.Silverfish.SimCard.sinisterstrike, 3);

            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.arcanemissiles, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.avengingwrath, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.bomblobber, 4);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.boombot, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.boombotjr, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.bouncingblade, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.cleave, 2);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.demolisher, 2);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.dieinsect, 8);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.dieinsects, 8);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.fierybat, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.flamecannon, 4);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.flamejuggler, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.flamewaker, 2);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.forkedlightning, 2);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.goblinblastmage, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.greaterarcanemissiles, 3);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.hugetoad, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.knifejuggler, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.madbomber, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.madderbomber, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.multishot, 3);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.ragnarosthefirelord, 8);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.rumblingelemental, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.shadowboxer, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.shipscannon, 2);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.spreadingmadness, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.throwrocks, 3);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.timepieceofhorror, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.volatileelemental, 3);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.volcano, 1);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.breathofsindragosa, 2);
            DamageRandomDatabase.Add(Chireiden.Silverfish.SimCard.blackguard, 3);

            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.arcaneblast, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.arcaneshot, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.backstab, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.ballistashot, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.barreltoss, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.betrayal, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.blackwingcorruptor, 3);//if dragon in hand
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.blazecaller, 5);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.blowgillsniper, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.bombsquad, 5);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.cobrashot, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.coneofcold, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.crackle, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.darkbomb, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.discipleofcthun, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.dispatchkodo, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.dragonsbreath, 4);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.drainlife, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.elvenarcher, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.eviscerate, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.explosiveshot, 5);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.felcannon, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.fireball, 6);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.fireblast, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.fireblastrank2, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.firebloomtoxin, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.fireelemental, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.firelandsportal, 5);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.fireplumephoenix, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.flamelance, 8);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.forbiddenflame, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.forgottentorch, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.frostbolt, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.frostshock, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.gormoktheimpaler, 4);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.greaterhealingpotion, 12);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.grievousbite, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.heartoffire, 5);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.hoggersmash, 4);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.holyfire, 5);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.holysmite, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.icelance, 4);//only if iced
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.implosion, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.ironforgerifleman, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.jadelightning, 4);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.jadeshuriken, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.keeperofthegrove, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.killcommand, 3);//or 5
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.lavaburst, 5);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.lavashock, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.lightningbolt, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.lightningjolt, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.livingroots, 2);//choice 1
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.medivhsvalet, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.meteor, 15);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.mindshatter, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.mindspike, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.moonfire, 1); 
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.mortalcoil, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.mortalstrike, 4);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.northseakraken, 4);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.onthehunt, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.perditionsblade, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.powershot, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.pyroblast, 10);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.razorpetal, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.roaringtorch, 6);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.shadowbolt, 4);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.shadowform, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.shadowstrike, 5);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.shotgunblast, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.si7agent, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.sonicbreath, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.sonoftheflame, 6);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.starfall, 5);//2 to all enemy
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.starfire, 5);//draw a card
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.steadyshot, 2);//or 1 + card
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.stormcrack, 4);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.stormpikecommando, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.swipe, 4);//1 to others
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.tidalsurge, 4);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.unbalancingstrike, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.undercityvaliant, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.wrath, 1);//todo 3 or 1+card
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.voidform, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.vampiricleech, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.ultimateinfestation, 5);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.toxicarrow, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.siphonlife, 3);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.icytouch, 1);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.iceclaw, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.drainsoul, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.doomerang, 2);
            DamageTargetDatabase.Add(Chireiden.Silverfish.SimCard.avalanche, 0);

            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.baneofdoom, 2); 
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.bash, 3); //+3 armor
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.bloodtoichor, 1); 
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.crueltaskmaster, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.deathbloom, 5);
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.demonfire, 2); // friendly demon get +2/+2
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.demonheart, 5);
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.earthshock, 1); //SILENCE /good for raggy etc or iced
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.feedingtime, 3); 
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.flamegeyser, 2); 
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.hammerofwrath, 3); //draw a card
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.holywrath, 2);//draw a card
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.innerrage, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.quickshot, 3); //draw a card
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.roguesdoit, 4);//draw a card
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.savagery, 1);//dmg=herodamage
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.shieldslam, 1);//dmg=armor
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.shiv, 1);//draw a card
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.slam, 2);//draw card if it survives
            DamageTargetSpecialDatabase.Add(Chireiden.Silverfish.SimCard.soulfire, 4);//delete a card

            HeroPowerEquipWeapon.Add(Chireiden.Silverfish.SimCard.daggermastery, 1);
            HeroPowerEquipWeapon.Add(Chireiden.Silverfish.SimCard.direshapeshift, 2);
            HeroPowerEquipWeapon.Add(Chireiden.Silverfish.SimCard.echolocate, 0);
            HeroPowerEquipWeapon.Add(Chireiden.Silverfish.SimCard.enraged, 2);
            HeroPowerEquipWeapon.Add(Chireiden.Silverfish.SimCard.poisoneddaggers, 2);
            HeroPowerEquipWeapon.Add(Chireiden.Silverfish.SimCard.shapeshift, 1);
            HeroPowerEquipWeapon.Add(Chireiden.Silverfish.SimCard.plaguelord, 3);

            
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.arcaneblast, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.arcaneshot, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.backstab, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.baneofdoom, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.barreltoss, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.bash, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.blastcrystalpotion, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.bloodthistletoxin, 3);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.bloodtoichor, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.chromaticmutation, 5);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.cobrashot, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.coneofcold, 6);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.crackle, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.crush, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.darkbomb, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.deathbloom, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.demonfire, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.demonheart, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.dispel, 4);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.dragonsbreath, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.drainlife, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.drakkisathscommand, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.dream, 3);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.dynamite, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.earthshock, 4);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.emergencycoolant, 6);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.eviscerate, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.explosiveshot, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.feedingtime, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.fireball, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.firebloomtoxin, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.firelandsportal, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.flamegeyser, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.flamelance, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.forbiddenflame, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.forgottentorch, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.frostbolt, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.grievousbite, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.hakkaribloodgoblet, 5);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.hammerofwrath, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.hex, 5);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.hoggersmash, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.holyfire, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.holysmite, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.holywrath, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.humility, 7);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.huntersmark, 7);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.icelance, 6);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.implosion, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.innerrage, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.jadelightning, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.jadeshuriken, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.keeperofthegrove, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.killcommand, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.lavaburst, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.lavashock, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.lightningbolt, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.livingroots, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.madbomber, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.madderbomber, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.meteor, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.moonfire, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.mortalcoil, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.mortalstrike, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.mulch, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.naturalize, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.necroticpoison, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.onthehunt, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.polymorph, 5);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.powershot, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.pyroblast, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.quickshot, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.razorpetal, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.roaringtorch, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.roguesdoit, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.rottenbanana, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.savagery, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.shadowbolt, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.shadowstep, 3);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.shadowstrike, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.shadowworddeath, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.shadowwordpain, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.shatter, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.shieldslam, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.shiv, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.silence, 4);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.siphonsoul, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.slam, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.sonicbreath, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.soulfire, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.spreadingmadness, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.starfall, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.starfire, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.stormcrack, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.swipe, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.tailswipe, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.thetruewarchief, 2);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.tidalsurge, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.timerewinder, 3);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.volcano, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.wrath, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.drainsoul, 1);
            this.maycauseharmDatabase.Add(Chireiden.Silverfish.SimCard.obliterate, 2);
        }

        private void setupsilenceDatabase()
        {
            
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.defiascleaner, 1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.dispel, 1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.earthshock, 1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.ironbeakowl, 1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.kabalsongstealer, 1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.lightschampion, 1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.massdispel, 1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.purify, -1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.silence, 1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.spellbreaker, 1);
            this.silenceDatabase.Add(Chireiden.Silverfish.SimCard.wailingsoul, -2);

            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.ancientwatcher, 2);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.animagolem, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.bittertidehydra, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.blackknight, 2);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.bombsquad, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.corruptedhealbot, 2);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.dancingswords, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.deathcharger, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.eeriestatue, 0);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.emeraldhivequeen, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.felorcsoulfiend, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.felreaver, 3);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.frozencrusher, 2);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.humongousrazorleaf, 2);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.icehowl, 2);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.mogortheogre, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.natthedarkfisher, 0);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.spectralrider, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.spectraltrainee, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.spectralwarrior, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.spore, 3);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.thebeast, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.unlicensedapothecary, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.unrelentingrider, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.unrelentingtrainee, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.unrelentingwarrior, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.venturecomercenary, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.whiteknight, 2);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.wrathguard, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.zombiechow, 2);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.tickingabomination, 0);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.rattlingrascal, 1);
            OwnNeedSilenceDatabase.Add(Chireiden.Silverfish.SimCard.masterchest, 1);
        }


        private void setupPriorityList()
        {
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.acidmaw, 3);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.animatedarmor, 2);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.archmageantonidas, 6);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.aviana, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.brannbronzebeard, 4);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.cloakedhuntress, 2);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.confessorpaletress, 7);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.crowdfavorite, 6);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.darkshirecouncilman, 2);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.direwolfalpha, 6);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.emperorthaurissan, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.fandralstaghelm, 6);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.flametonguetotem, 6);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.flamewaker, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.frothingberserker, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.gadgetzanauctioneer, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.grimestreetenforcer, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.grimpatron, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.grimscaleoracle, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.grimygadgeteer, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.holychampion, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.knifejuggler, 2);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.kodorider, 6);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.kvaldirraider, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.leokk, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.lyrathesunshard, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.malchezaarsimp, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.malganis, 10);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.manatidetotem, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.mechwarper, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.muklaschampion, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.murlocknight, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.murlocwarleader, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.nexuschampionsaraad, 6);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.northshirecleric, 4);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.pintsizedsummoner, 3);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.primalfintotem, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.prophetvelen, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.questingadventurer, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.radiantelemental, 3);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.ragnaroslightlord, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.raidleader, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.recruiter, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.scavenginghyena, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.secretkeeper, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.sorcerersapprentice, 3);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.southseacaptain, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.spiritsingerumbra, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.stormwindchampion, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.summoningportal, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.summoningstone, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.thevoraxx, 2);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.thunderbluffvaliant, 2);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.timberwolf, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.tunneltrogg, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.viciousfledgling, 4);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.violetillusionist, 10);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.violetteacher, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.warhorsetrainer, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.warsongcommander, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.wickedwitchdoctor, 5);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.wilfredfizzlebang, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.rotface, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.professorputricide, 1);
            priorityDatabase.Add(Chireiden.Silverfish.SimCard.moorabi, 1);
        }

        private void setupAttackBuff()
        {
            this.heroAttackBuffDatabase.Add(Chireiden.Silverfish.SimCard.bite, 4);
            this.heroAttackBuffDatabase.Add(Chireiden.Silverfish.SimCard.claw, 2);
            this.heroAttackBuffDatabase.Add(Chireiden.Silverfish.SimCard.evolvespines, 4);
            this.heroAttackBuffDatabase.Add(Chireiden.Silverfish.SimCard.feralrage, 4);
            this.heroAttackBuffDatabase.Add(Chireiden.Silverfish.SimCard.heroicstrike, 4);
            this.heroAttackBuffDatabase.Add(Chireiden.Silverfish.SimCard.gnash, 3);

            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.abusivesergeant, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.adaptation, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.bananas, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.bestialwrath, 2); // NEVER ON enemy MINION
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.blessingofkings, 4);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.blessingofmight, 3);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.bloodfurypotion, 3);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.briarthorntoxin, 3);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.clockworkknight, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.coldblood, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.crueltaskmaster, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.darkirondwarf, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.darkwispers, 5);//choice 2
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.demonfuse, 3);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.dinomancy, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.dinosize, 10);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.divinestrength, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.earthenscales, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.explorershat, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.innerrage, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.lancecarrier, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.lanternofpower, 10);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.lightfusedstegodon, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.markofnature, 4);//choice1 
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.markofthewild, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.markofyshaarj, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.mutatinginjection, 4);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.nightmare, 5); //destroy minion on next turn
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.powerwordtentacles, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.primalfusion, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.rampage, 3);//only damaged minion 
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.rockbiterweapon, 3);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.rockpoolhunter, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.screwjankclunker, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.sealofchampions, 3);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.silvermoonportal, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.spikeridgedsteed, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.velenschosen, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.whirlingblades, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.antimagicshell, 2);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.fallensuncleric, 1);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.cryostasis, 3);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.bonemare, 4);
            this.attackBuffDatabase.Add(Chireiden.Silverfish.SimCard.acherusveteran, 1);
        }

        private void setupHealthBuff()
        {
            //healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.ancientofwar, 5);//choice2 is only buffing himself!
            //healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.rooted, 5);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.adaptation, 1);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.armorplating, 1);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.bananas, 1);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.blessingofkings, 4);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.clockworkknight, 1);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.darkwispers, 5);//choice2
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.demonfuse, 3);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.dinomancy, 2);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.dinosize, 10);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.divinestrength, 2);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.earthenscales, 1);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.explorershat, 1);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.lanternofpower, 10);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.lightfusedstegodon, 1);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.markofnature, 4);//choice2
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.markofthewild, 2);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.markofyshaarj, 2);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.mutatinginjection, 4);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.nightmare, 5);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.powerwordshield, 2);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.powerwordtentacles, 6);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.primalfusion, 1);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.rampage, 3);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.rockpoolhunter, 1);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.screwjankclunker, 2);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.silvermoonportal, 2);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.spikeridgedsteed, 6);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.upgradedrepairbot, 4);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.velenschosen, 4);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.wildwalker, 3);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.antimagicshell, 2);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.sunbornevalkyr, 2);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.fallensuncleric, 1);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.cryostasis, 3);
            healthBuffDatabase.Add(Chireiden.Silverfish.SimCard.bonemare, 4);

            tauntBuffDatabase.Add(Chireiden.Silverfish.SimCard.ancestralhealing, 1);
            tauntBuffDatabase.Add(Chireiden.Silverfish.SimCard.darkwispers, 1);
            tauntBuffDatabase.Add(Chireiden.Silverfish.SimCard.markofnature, 1);
            tauntBuffDatabase.Add(Chireiden.Silverfish.SimCard.markofthewild, 1);
            tauntBuffDatabase.Add(Chireiden.Silverfish.SimCard.mutatinginjection, 1);
            tauntBuffDatabase.Add(Chireiden.Silverfish.SimCard.rustyhorn, 1);
            tauntBuffDatabase.Add(Chireiden.Silverfish.SimCard.sparringpartner, 1);
            tauntBuffDatabase.Add(Chireiden.Silverfish.SimCard.spikeridgedsteed, 1);
        }

        private void setupCardDrawBattlecry()
        {
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.alightinthedarkness, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.ancestralknowledge, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.ancientoflore, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.ancientteachings, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.arcaneintellect, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.archthiefrafaam, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.azuredrake, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.babblingbook, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.battlerage, 0);//only if wounded own minions or hero
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.bloodwarriors, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.burgle, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.cabaliststome, 3);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.callpet, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.carnassasbrood, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.chitteringtunneler, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.chooseyourpath, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.coldlightoracle, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.commandingshout, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.convert, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.darkpeddler, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.darkshirelibrarian, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.desertcamel, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.divinefavor, 0);//only if enemy has more cards than you
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.drakonidoperative, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.echoofmedivh, 0);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.elisestarseeker, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.elitetaurenchieftain, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.etherealconjurer, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.excessmana, 0);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.fanofknives, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.farsight, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.fightpromoter, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.finderskeepers, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.firefly, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.flamegeyser, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.flameheart, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.flare, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.freefromamber, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.giftofcards, 1); //choice = 2
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.gnomishexperimenter, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.gnomishinventor, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.goldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.gorillabota3, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.grandcrusader, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.grimestreetinformant, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.hallucination, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.hammerofwrath, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.harrisonjones, 0);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.harvest, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.holywrath, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.hydrologist, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.iknowaguy, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.ivoryknight, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.jeweledmacaw, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.jeweledscarab, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.journeybelow, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.kabalchemist, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.kabalcourier, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.kazakus, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.kingmukla, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.kingsblood, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.kingsbloodtoxin, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.kingselekk, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.layonhands, 3);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.lifetap, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.lockandload, 0);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.lotusagents, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.lunarvisions, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.maptothegoldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.markofyshaarj, 0);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.massdispel, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.megafin, 9);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.mimicpod, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.mindpocalypse, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.mindvision, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.mortalcoil, 0);//only if kills
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.muklatyrantofthevale, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.museumcurator, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.nefarian, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.neptulon, 4);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.netherspitehistorian, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.nourish, 3); //choice = 2
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.noviceengineer, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.powerwordshield, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.primalfinlookout, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.primordialglyph, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.purify, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.quickshot, 0);//only if your hand is empty
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.ravenidol, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.razorpetallasher, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.razorpetalvolley, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.roguesdoit, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.servantofkalimos, 0);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.shadowcaster, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.shadowoil, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.shadowvisions, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.shieldblock, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.shiv, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.slam, 0); //if survives
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.smalltimerecruits, 3);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.solemnvigil, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.soultap, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.spellslinger, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.sprint, 4);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.stampede, 0);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.starfire, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.stonehilldefender, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.swashburglar, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.thecurator, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.thistletea, 3);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.thoughtsteal, 0);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.tinkertowntechnician, 0); // If you have a Mech
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.tolvirwarden, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.tombspider, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.tortollanforager, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.tortollanprimalist, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.toshley, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.tracking, 1); //NOT SUPPORTED YET
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.ungoropack, 5);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.unholyshadow, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.unstableportal, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.varianwrynn, 3);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.wildmagic, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.wrath, 1); //choice=2
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.wrathion, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.xarilpoisonedmind, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.ultimateinfestation, 5);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.tomblurker, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.ghastlyconjurer, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.deathgrip, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.stitchedtracker, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.rollthebones, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.icefishing, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.howlingcommander, 0);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.frozenclone, 1);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.forgeofsouls, 2);
            cardDrawBattleCryDatabase.Add(Chireiden.Silverfish.SimCard.devourmind, 3);

            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.acolyteofpain, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.anubarak, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.bloodmagethalnos, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.clockworkgnome, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.crystallineoracle, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.dancingswords, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.deadlyfork, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.hook, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.igneouselemental, 2);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.loothoarder, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.meanstreetmarshal, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.mechanicalyeti, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.mechbearcat, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.pollutedhoarder, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.pyros, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.rhonin, 3);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.runicegg, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.shiftingshade, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.shimmeringtempest, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.tentaclesforarms, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.tombpillager, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.toshley, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.undercityhuckster, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.webspinner, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.xarilpoisonedmind, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.shallowgravedigger, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.frozenchampion, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.bonedrake, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.bonebaron, 2);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.arfus, 1);
            cardDrawDeathrattleDatabase.Add(Chireiden.Silverfish.SimCard.glacialmysteries, 1);
        }


        private void setupUsefulNeedKeepDatabase()
        {
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.acidmaw, 4);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.addledgrizzly, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.airelemental, 6);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.alarmobot, 4);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.ancientharbinger, 2);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.animatedarmor, 12);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.archmageantonidas, 7);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.armorsmith, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.aviana, 7);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.backroombouncer, 1);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.bloodimp, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.brannbronzebeard, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.burlyrockjawtrogg, 5);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.cloakedhuntress, 12);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.cobaltguardian, 8);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.coldarradrake, 15);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.confessorpaletress, 32);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.cultmaster, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.cultsorcerer, 13);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.darkshirecouncilman, 0);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.dementedfrostcaller, 15);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.demolisher, 11);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.direwolfalpha, 30);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.dragonkinsorcerer, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.emboldener3000, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.emperorthaurissan, 11);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.faeriedragon, 7);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.fallenhero, 15);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.masterchest, 48);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.fandralstaghelm, 15);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.felcannon, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.flametonguetotem, 30);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.flamewaker, 12);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.flesheatingghoul, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.floatingwatcher, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.frothingberserker, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.gadgetzanauctioneer, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.garrisoncommander, 7);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.gazlowe, 6);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.grimestreetenforcer, 12);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.grimscaleoracle, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.grimygadgeteer, 11);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.gruul, 4);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.hallazealtheascended, 16);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.healingtotem, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.hobgoblin, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.hogger, 13);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.homingchicken, 12);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.illidanstormrage, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.illuminator, 2);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.impmaster, 5);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.ironsensei, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.jeeves, 0);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.junkbot, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.kabaltrafficker, 1);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.kelthuzad, 18);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.knifejuggler, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.kodorider, 20);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.kvaldirraider, 12);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.leokk, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.lightwarden, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.lightwell, 13);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.lyrathesunshard, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.maidenofthelake, 18);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.malchezaarsimp, 0);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.malganis, 13);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.manatidetotem, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.manawyrm, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.masterswordsmith, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.mechwarper, 11);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.mekgineerthermaplugg, 5);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.micromachine, 12);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.moroes, 13);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.muklaschampion, 14);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.murlocknight, 16);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.murloctidecaller, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.murlocwarleader, 11);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.natpagle, 2);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.nexuschampionsaraad, 30);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.northshirecleric, 11);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.obsidiandestroyer, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.pintsizedsummoner, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.priestofthefeast, 3);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.primalfintotem, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.prophetvelen, 5);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.questingadventurer, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.radiantelemental, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.ragnaroslightlord, 19);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.ragnarosthefirelord, 5);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.raidleader, 11);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.recruiter, 15);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.redmanawyrm, 8);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.repairbot, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.rumblingelemental, 7);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.scavenginghyena, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.secretkeeper, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.shadeofnaxxramas, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.shadowboxer, 11);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.shakuthecollector, 25);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.shipscannon, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.siegeengine, 8);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.siltfinspiritwalker, 5);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.silverhandregent, 14);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.sorcerersapprentice, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.southseacaptain, 11);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.spiritsingerumbra, 13);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.starvingbuzzard, 8);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.stonesplintertrogg, 8);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.stormwindchampion, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.summoningportal, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.summoningstone, 13);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.thunderbluffvaliant, 16);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.timberwolf, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.tradeprincegallywix, 5);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.troggzortheearthinator, 4);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.twilightelder, 9);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.undertaker, 8);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.usherofsouls, 2);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.viciousfledgling, 13);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.violetillusionist, 14);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.violetteacher, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.vitalitytotem, 8);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.warhorsetrainer, 13);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.warsongcommander, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.weespellstopper, 11);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.wickedwitchdoctor, 13);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.wilfredfizzlebang, 16);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.windupburglebot, 5);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.youngpriestess, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.shadowascendant, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.festergut, 25);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.drakkarienchanter, 17);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.despicabledreadlord, 14);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.cobaltscalebane, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.valkyrsoulclaimer, 10);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.runeforgehaunter, 1);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.rotface, 26);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.necroticgeist, 12);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.moorabi, 16);
            UsefulNeedKeepDatabase.Add(Chireiden.Silverfish.SimCard.icewalker, 15);
        }

        private void setupDiscardCards()
        {
            cardDiscardDatabase.Add(Chireiden.Silverfish.SimCard.darkbargain, 6);
            cardDiscardDatabase.Add(Chireiden.Silverfish.SimCard.darkshirelibrarian, 2);
            cardDiscardDatabase.Add(Chireiden.Silverfish.SimCard.doomguard, 5);
            cardDiscardDatabase.Add(Chireiden.Silverfish.SimCard.lakkarifelhound, 4);
            cardDiscardDatabase.Add(Chireiden.Silverfish.SimCard.soulfire, 1);
            cardDiscardDatabase.Add(Chireiden.Silverfish.SimCard.succubus, 2);
        }

        private void setupDestroyOwnCards()
        {
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.brawl, 0);
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.deathwing, 0);
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.golakkacrawler, 0);
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.hungrycrab, 0);//not own mins
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.kingmosh, 0);
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.naturalize, 0);//not own mins
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.ravenouspterrordax, 0);
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.sacrificialpact, 0);//not own mins
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.siphonsoul, 0);//not own mins
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.shadowflame, 0);
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.twistingnether, 0);
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.unwillingsacrifice, 0);
            this.destroyOwnDatabase.Add(Chireiden.Silverfish.SimCard.sanguinereveler, 0);

            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.assassinate, 0);//not own mins
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.biggamehunter, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.bladeofcthun, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.blastcrystalpotion, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.bookwyrm, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.corruption, 0);//not own mins
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.crush, 0);//not own mins
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.darkbargain, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.deadlyshot, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.doom, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.drakkisathscommand, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.enterthecoliseum, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.execute, 0);//not own mins
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.hemetnesingwary, 0);//not own mins
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.mindcontrol, 0);//not own mins
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.moatlurker, 1);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.mulch, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.necroticpoison, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.rendblackhand, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.sabotage, 0);//not own mins
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.shadowworddeath, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.shadowwordhorror, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.shadowwordpain, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.shatter, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.theblackknight, 0);//not own mins
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.thetruewarchief, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.vilespineslayer, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.voidcrusher, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.obsidianstatue, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.obliterate, 0);
            this.destroyDatabase.Add(Chireiden.Silverfish.SimCard.doompact, 0);
        }

        private void setupReturnBackToHandCards()
        {
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.ancientbrewmaster, 0);
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.bloodthistletoxin, 0);
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.dream, 0);
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.gadgetzanferryman, 0);
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.kidnapper, 0);//if combo
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.recycle, 0);
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.shadowstep, 0);
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.timerewinder, 0);
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.vanish, 0);
            returnHandDatabase.Add(Chireiden.Silverfish.SimCard.youthfulbrewmaster, 0);
        }

        private void setupHeroDamagingAOE()
        {
            this.heroDamagingAoeDatabase.Add(Chireiden.Silverfish.SimCard.unknown, 0);
        }

        private void setupSpecialMins()
        {
            specialMinions.Add(Chireiden.Silverfish.SimCard.aberrantberserker, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.abomination, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.acidmaw, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.acolyteofpain, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.addledgrizzly, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.alarmobot, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.amaniberserker, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.ancientharbinger, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.angrychicken, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.animatedarmor, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.anubarak, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.anubarambusher, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.anubisathsentinel, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.arcaneanomaly, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.archmage, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.archmageantonidas, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.armorsmith, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.auchenaisoulpriest, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.aviana, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.axeflinger, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.ayablackpaw, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.azuredrake, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.backroombouncer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.backstreetleper, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.barongeddon, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.baronrivendare, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.blackwaterpirate, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.bloodhoofbrave, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.bloodimp, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.bloodmagethalnos, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.bolframshield, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.boneguardlieutenant, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.brannbronzebeard, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.bravearcher, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.buccaneer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.burglybully, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.burlyrockjawtrogg, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.cairnebloodhoof, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.chromaggus, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.chromaticdragonkin, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.cloakedhuntress, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.clockworkgnome, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.cobaltguardian, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.cogmaster, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.coldarradrake, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.coliseummanager, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.confessorpaletress, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.crazedworshipper, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.crowdfavorite, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.crueldinomancer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.crystallineoracle, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.cthun, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.cultmaster, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.cultsorcerer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.cutpurse, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.dalaranaspirant, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.dalaranmage, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.dancingswords, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.darkcultist, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.darkshirecouncilman, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.deadlyfork, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.deathlord, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.dementedfrostcaller, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.demolisher, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.direhornhatchling, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.direwolfalpha, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.djinniofzephyrs, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.doomsayer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.dragonegg, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.dragonhawkrider, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.dragonkinsorcerer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.dreadscale, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.dreadsteed, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.eggnapper, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.emperorcobra, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.emperorthaurissan, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.etherealarcanist, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.evolvedkobold, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.explosivesheep, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.eydisdarkbane, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.fallenhero, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.fandralstaghelm, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.felcannon, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.feugen, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.finjatheflyingstar, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.fjolalightbane, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.flametonguetotem, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.flamewaker, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.flesheatingghoul, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.floatingwatcher, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.foereaper4000, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.gadgetzanauctioneer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.gahzrilla, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.garr, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.garrisoncommander, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.gazlowe, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.genzotheshark, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.giantanaconda, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.giantsandworm, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.giantwasp, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.goblinsapper, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.grimestreetenforcer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.grimpatron, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.grimscaleoracle, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.grimygadgeteer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.grommashhellscream, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.gruul, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.gurubashiberserker, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.hallazealtheascended, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.harvestgolem, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.hauntedcreeper, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.hobgoblin, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.hogger, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.hoggerdoomofelwynn, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.holychampion, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.hoodedacolyte, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.hugetoad, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.igneouselemental, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.illidanstormrage, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.impgangboss, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.impmaster, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.infestedtauren, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.infestedwolf, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.ironsensei, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.jadeswarmer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.jeeves, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.junglemoonkin, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.junkbot, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.kabaltrafficker, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.kelthuzad, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.kindlygrandmother, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.knifejuggler, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.knuckles, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.koboldgeomancer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.kodorider, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.kvaldirraider, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.lepergnome, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.lightspawn, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.lightwarden, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.lightwell, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.loothoarder, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.lorewalkercho, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.lotusassassin, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.lowlysquire, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.lyrathesunshard, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.madscientist, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.maexxna, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.magnatauralpha, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.maidenofthelake, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.majordomoexecutus, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.malchezaarsimp, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.malganis, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.malorne, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.malygos, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.manaaddict, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.manageode, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.manatidetotem, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.manatreant, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.manawraith, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.manawyrm, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.masterswordsmith, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.mechanicalyeti, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.mechbearcat, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.mechwarper, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.mekgineerthermaplugg, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.micromachine, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.mimironshead, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.mistressofpain, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.moroes, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.muklaschampion, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.murlocknight, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.murloctidecaller, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.murlocwarleader, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.natpagle, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.nerubarweblord, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.nexuschampionsaraad, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.northshirecleric, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.obsidiandestroyer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.ogremagi, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.oldmurkeye, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.orgrimmaraspirant, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.patientassassin, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.pilotedshredder, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.pilotedskygolem, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.pintsizedsummoner, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.pitsnake, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.possessedvillager, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.priestofthefeast, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.primalfinchampion, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.primalfintotem, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.prophetvelen, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.pyros, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.questingadventurer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.radiantelemental, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.ragingworgen, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.ragnaroslightlord, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.raidleader, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.raptorhatchling, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.ratpack, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.recruiter, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.redmanawyrm, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.rumblingelemental, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.satedthreshadon, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.savagecombatant, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.savannahhighmane, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.scalednightmare, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.scavenginghyena, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.secretkeeper, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.selflesshero, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.sergeantsally, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.shadeofnaxxramas, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.shadowboxer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.shadowfiend, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.shakuthecollector, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.sherazincorpseflower, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.shiftingshade, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.shimmeringtempest, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.shipscannon, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.siltfinspiritwalker, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.silverhandregent, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.smalltimebuccaneer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.sneedsoldshredder, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.snowchugger, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.sorcerersapprentice, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.southseacaptain, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.southseasquidface, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.spawnofnzoth, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.spawnofshadows, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.spiritsingerumbra, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.spitefulsmith, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.stalagg, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.starvingbuzzard, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.steamwheedlesniper, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.stewardofdarkshire, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.stonesplintertrogg, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.stormwindchampion, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.summoningportal, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.summoningstone, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.sylvanaswindrunner, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tarcreeper, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tarlord, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tarlurker, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.taurenwarrior, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tentacleofnzoth, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.thebeast, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.theboogeymonster, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.thevoraxx, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.thunderbluffvaliant, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.timberwolf, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tinyknightofevil, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tirionfordring, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tortollanshellraiser, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.toshley, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tournamentmedic, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tradeprincegallywix, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.troggzortheearthinator, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tundrarhino, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.tunneltrogg, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.twilightelder, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.twilightsummoner, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.unboundelemental, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.undercityhuckster, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.undertaker, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.unstableghoul, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.usherofsouls, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.viciousfledgling, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.violetillusionist, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.violetteacher, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.vitalitytotem, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.voidcaller, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.voidcrusher, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.volatileelemental, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.warbot, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.warhorsetrainer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.warsongcommander, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.waterelemental, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.voodoohexxer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.webspinner, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.whiteeyes, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.wickedwitchdoctor, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.wickerflameburnbristle, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.wilfredfizzlebang, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.windupburglebot, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.wobblingrunts, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.xarilpoisonedmind, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.ysera, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.yshaarjrageunbound, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.zealousinitiate, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.vryghoul, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.thelichking, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.skelemancer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.shallowgravedigger, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.shadowascendant, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.obsidianstatue, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.mountainfirearmor, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.meatwagon, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.hadronox, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.festergut, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.fatespinner, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.explodingbloatbat, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.drakkarienchanter, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.despicabledreadlord, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.deadscaleknight, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.cobaltscalebane, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.chillbladechampion, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.bonedrake, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.bonebaron, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.bloodworm, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.bloodqueenlanathel, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.blackguard, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.arrogantcrusader, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.arfus, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.acolyteofagony, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.abominablebowman, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.venomancer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.valkyrsoulclaimer, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.stubborngastropod, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.runeforgehaunter, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.rotface, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.professorputricide, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.nighthowler, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.nerubianunraveler, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.necroticgeist, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.moorabi, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.mindbreaker, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.icewalker, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.graveshambler, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.doomedapprentice, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.cryptlord, 0);
            specialMinions.Add(Chireiden.Silverfish.SimCard.corpsewidow, 0);
        }

        private void setupOwnSummonFromDeathrattle()
        {
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.anubarak, -10);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.ayablackpaw, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.cairnebloodhoof, 5);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.crueldinomancer, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.devilsauregg, -20);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.dreadsteed, -1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.eggnapper, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.giantanaconda, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.harvestgolem, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.hauntedcreeper, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.infestedtauren, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.infestedwolf, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.jadeswarmer, -1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.kindlygrandmother, -10);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.moirabronzebeard, 3);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.mountedraptor, 3);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.nerubianegg, -16);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.pilotedshredder, 4);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.pilotedskygolem, 4);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.possessedvillager, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.ratpack, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.satedthreshadon, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.savannahhighmane, 8);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.sludgebelcher, 10);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.sneedsoldshredder, 5);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.twilightsummoner, -14);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.whiteeyes, -10);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.wobblingrunts, 1);
            ownSummonFromDeathrattle.Add(Chireiden.Silverfish.SimCard.frozenchampion, -12);
        }

        private void setupBuffingMinions()
        {
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.abusivesergeant, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.beckonerofevil, 10);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.bladeofcthun, 10);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.bloodsailcultist, 5);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.captaingreenskin, 5);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.cenarius, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.clockworkknight, 2);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.coldlightseer, 3);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.crueltaskmaster, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.cthunschosen, 10);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.cultsorcerer, 10);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.darkarakkoa, 10);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.darkirondwarf, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.defenderofargus, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.direwolfalpha, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.discipleofcthun, 10);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.doomcaller, 10);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.flametonguetotem, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.goblinautobarber, 5);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.grimscaleoracle, 3);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.hoodedacolyte, 10);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.houndmaster, 1);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.lancecarrier, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.leokk, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.malganis, 8);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.metaltoothleaper, 2);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.murlocwarleader, 3);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.quartermaster, 6);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.raidleader, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.screwjankclunker, 2);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.shatteredsuncleric, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.skeramcultist, 10);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.southseacaptain, 4);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.spitefulsmith, 5);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.stormwindchampion, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.templeenforcer, 0);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.thunderbluffvaliant, 9);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.timberwolf, 1);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.upgradedrepairbot, 2);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.usherofsouls, 10);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.warhorsetrainer, 6);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.warsongcommander, 7);
            buffingMinionsDatabase.Add(Chireiden.Silverfish.SimCard.worshipper, 0);

            buffing1TurnDatabase.Add(Chireiden.Silverfish.SimCard.abusivesergeant, 0);
            buffing1TurnDatabase.Add(Chireiden.Silverfish.SimCard.bloodlust, 3);
            buffing1TurnDatabase.Add(Chireiden.Silverfish.SimCard.darkirondwarf, 0);
            buffing1TurnDatabase.Add(Chireiden.Silverfish.SimCard.rockbiterweapon, 0);
            buffing1TurnDatabase.Add(Chireiden.Silverfish.SimCard.worshipper, 0);
        }

        private void setupEnemyTargetPriority()
        {
            priorityTargets.Add(Chireiden.Silverfish.SimCard.acidmaw, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.acolyteofpain, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.addledgrizzly, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.alarmobot, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.angrychicken, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.animatedarmor, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.anubarak, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.anubisathsentinel, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.archmageantonidas, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.auchenaisoulpriest, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.auctionmasterbeardo, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.aviana, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.ayablackpaw, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.backroombouncer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.barongeddon, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.baronrivendare, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.bloodmagethalnos, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.boneguardlieutenant, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.brannbronzebeard, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.burglybully, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.chromaggus, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.cloakedhuntress, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.coldarradrake, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.confessorpaletress, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.crowdfavorite, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.crueldinomancer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.crystallineoracle, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.cthun, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.cultmaster, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.cultsorcerer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.dalaranaspirant, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.daringreporter, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.darkshirecouncilman, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.dementedfrostcaller, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.demolisher, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.devilsauregg, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.nerubianegg, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.direhornhatchling, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.direwolfalpha, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.djinniofzephyrs, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.doomsayer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.dragonegg, 0);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.dragonhawkrider, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.dragonkinsorcerer, 4);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.dreadscale, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.dustdevil, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.eggnapper, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.emperorthaurissan, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.etherealarcanist, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.eydisdarkbane, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.fallenhero, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.masterchest, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.fandralstaghelm, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.finjatheflyingstar, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.flametonguetotem, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.flamewaker, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.flesheatingghoul, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.floatingwatcher, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.foereaper4000, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.friendlybartender, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.frothingberserker, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.gadgetzanauctioneer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.gahzrilla, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.garr, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.garrisoncommander, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.genzotheshark, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.giantanaconda, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.giantsandworm, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.grimestreetenforcer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.grimpatron, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.grimygadgeteer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.gurubashiberserker, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.hobgoblin, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.hogger, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.hoggerdoomofelwynn, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.holychampion, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.hoodedacolyte, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.igneouselemental, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.illidanstormrage, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.impgangboss, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.impmaster, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.ironsensei, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.junglemoonkin, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.kabaltrafficker, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.kelthuzad, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.knifejuggler, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.knuckles, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.koboldgeomancer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.kodorider, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.kvaldirraider, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.leeroyjenkins, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.leokk, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.lightwarden, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.lightwell, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.lowlysquire, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.lyrathesunshard, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.maexxna, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.maidenofthelake, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.malchezaarsimp, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.malganis, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.malygos, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.manaaddict, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.manatidetotem, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.manatreant, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.manawyrm, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.masterswordsmith, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.mechwarper, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.micromachine, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.mogortheogre, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.moroes, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.muklaschampion, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.murlocknight, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.natpagle, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.nerubarweblord, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.nexuschampionsaraad, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.northshirecleric, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.obsidiandestroyer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.orgrimmaraspirant, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.pintsizedsummoner, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.priestofthefeast, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.primalfintotem, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.prophetvelen, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.pyros, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.questingadventurer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.radiantelemental, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.ragnaroslightlord, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.raidleader, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.raptorhatchling, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.recruiter, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.redmanawyrm, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.rhonin, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.rumblingelemental, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.satedthreshadon, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.savagecombatant, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.scalednightmare, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.scavenginghyena, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.secretkeeper, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.shadeofnaxxramas, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.shakuthecollector, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.sherazincorpseflower, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.shimmeringtempest, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.silverhandregent, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.sorcerersapprentice, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.spiritsingerumbra, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.starvingbuzzard, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.steamwheedlesniper, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.stormwindchampion, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.summoningportal, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.summoningstone, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.theboogeymonster, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.thevoraxx, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.thrallmarfarseer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.thunderbluffvaliant, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.timberwolf, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.troggzortheearthinator, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.tundrarhino, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.tunneltrogg, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.twilightsummoner, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.unboundelemental, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.undertaker, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.viciousfledgling, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.violetillusionist, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.violetteacher, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.vitalitytotem, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.warhorsetrainer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.warsongcommander, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.whiteeyes, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.wickedwitchdoctor, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.wildpyromancer, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.wilfredfizzlebang, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.windupburglebot, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.youngdragonhawk, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.yshaarjrageunbound, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.thelichking, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.obsidianstatue, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.moirabronzebeard, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.highjusticegrimstone, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.hadronox, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.festergut, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.despicabledreadlord, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.rotface, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.professorputricide, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.nighthowler, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.necroticgeist, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.moorabi, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.icewalker, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.cryptlord, 10);
            priorityTargets.Add(Chireiden.Silverfish.SimCard.corpsewidow, 10);
        }

        private void setupLethalHelpMinions()
        {
            //spellpower minions
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.ancientmage, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.arcanotron, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.archmage, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.auchenaisoulpriest, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.azuredrake, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.bloodmagethalnos, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.cultsorcerer, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.dalaranaspirant, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.dalaranmage, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.evolvedkobold, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.frigidsnobold, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.junglemoonkin, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.koboldgeomancer, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.malygos, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.minimage, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.ogremagi, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.prophetvelen, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.sootspewer, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.streettrickster, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.wrathofairtotem, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.tuskarrfisherman, 0);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.taintedzealot, 1);
            lethalHelpers.Add(Chireiden.Silverfish.SimCard.spellweaver, 2);
        }

        private void setupRelations()
        {
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.arcaneanomaly, 1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.archmageantonidas, 2);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.burglybully, -1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.burlyrockjawtrogg, -1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.chromaticdragonkin, -1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.cultsorcerer, 1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.dementedfrostcaller, 1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.djinniofzephyrs, 1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.flamewaker, 1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.gadgetzanauctioneer, 2);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.gazlowe, 2);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.hallazealtheascended, 1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.lorewalkercho, 0);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.lyrathesunshard, 2);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.manaaddict, 1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.manawyrm, 1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.priestofthefeast, 1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.redmanawyrm, 1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.stonesplintertrogg, -1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.summoningstone, 3);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.tradeprincegallywix, -1);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.troggzortheearthinator, -2);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.violetteacher, 3);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.wickedwitchdoctor, 3);
            spellDependentDatabase.Add(Chireiden.Silverfish.SimCard.wildpyromancer, 1);

            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.alexstraszaschampion, 1);
            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.blackwingcorruptor, 1);
            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.blackwingtechnician, 1);
            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.bookwyrm, 1);
            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.drakonidoperative, 1);
            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.netherspitehistorian, 1);
            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.nightbanetemplar, 1);
            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.rendblackhand, 1);
            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.twilightguardian, 1);
            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.twilightwhelp, 1);
            dragonDependentDatabase.Add(Chireiden.Silverfish.SimCard.wyrmrestagent, 1);

            elementalLTDependentDatabase.Add(Chireiden.Silverfish.SimCard.blazecaller, 1);
            elementalLTDependentDatabase.Add(Chireiden.Silverfish.SimCard.kalimosprimallord, 1);
            elementalLTDependentDatabase.Add(Chireiden.Silverfish.SimCard.ozruk, 1);
            elementalLTDependentDatabase.Add(Chireiden.Silverfish.SimCard.servantofkalimos, 1);
            elementalLTDependentDatabase.Add(Chireiden.Silverfish.SimCard.steamsurger, 1);
            elementalLTDependentDatabase.Add(Chireiden.Silverfish.SimCard.stonesentinel, 1);
            elementalLTDependentDatabase.Add(Chireiden.Silverfish.SimCard.thunderlizard, 1);
            elementalLTDependentDatabase.Add(Chireiden.Silverfish.SimCard.tolvirstoneshaper, 1);
        }

        private void setupSilenceTargets()
        {
            silenceTargets.Add(Chireiden.Silverfish.SimCard.abomination, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.acidmaw, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.acolyteofpain, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.addledgrizzly, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.ancientharbinger, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.animatedarmor, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.anomalus, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.anubarak, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.anubisathsentinel, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.archmageantonidas, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.armorsmith, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.auchenaisoulpriest, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.aviana, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.axeflinger, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.ayablackpaw, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.backroombouncer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.barongeddon, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.baronrivendare, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.blackwaterpirate, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.bloodimp, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.blubberbaron, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.bolvarfordragon, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.boneguardlieutenant, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.brannbronzebeard, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.bravearcher, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.burlyrockjawtrogg, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.cairnebloodhoof, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.chillmaw, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.chromaggus, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.cobaltguardian, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.coldarradrake, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.coliseummanager, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.confessorpaletress, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.crazedworshipper, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.crowdfavorite, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.crueldinomancer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.crystallineoracle, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.cthun, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.cultmaster, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.cultsorcerer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.dalaranaspirant, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.darkcultist, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.darkshirecouncilman, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.dementedfrostcaller, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.devilsauregg, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.nerubianegg, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.direhornhatchling, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.direwolfalpha, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.djinniofzephyrs, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.doomsayer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.dragonegg, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.dragonhawkrider, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.dragonkinsorcerer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.dreadscale, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.eggnapper, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.emboldener3000, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.emperorcobra, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.emperorthaurissan, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.etherealarcanist, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.evolvedkobold, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.explosivesheep, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.eydisdarkbane, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.fallenhero, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.masterchest, 0);            
            silenceTargets.Add(Chireiden.Silverfish.SimCard.fandralstaghelm, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.feugen, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.finjatheflyingstar, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.fjolalightbane, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.flametonguetotem, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.flamewaker, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.flesheatingghoul, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.floatingwatcher, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.foereaper4000, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.frothingberserker, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.gadgetzanauctioneer, 10);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.gahzrilla, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.garr, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.garrisoncommander, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.giantanaconda, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.giantsandworm, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.giantwasp, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.grimestreetenforcer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.grimpatron, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.grimscaleoracle, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.grimygadgeteer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.grommashhellscream, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.gruul, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.gurubashiberserker, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.hallazealtheascended, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.hauntedcreeper, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.hobgoblin, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.hogger, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.hoggerdoomofelwynn, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.holychampion, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.homingchicken, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.hoodedacolyte, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.igneouselemental, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.illidanstormrage, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.impgangboss, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.impmaster, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.ironsensei, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.jadeswarmer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.jeeves, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.junkbot, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.kabaltrafficker, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.kelthuzad, 10);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.kindlygrandmother, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.knifejuggler, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.knuckles, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.kodorider, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.kvaldirraider, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.leokk, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.lightspawn, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.lightwarden, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.lightwell, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.lorewalkercho, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.lowlysquire, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.lyrathesunshard, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.madscientist, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.maexxna, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.magnatauralpha, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.maidenofthelake, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.majordomoexecutus, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.malganis, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.malorne, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.malygos, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.manaaddict, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.manageode, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.manatidetotem, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.manatreant, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.manawraith, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.manawyrm, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.masterswordsmith, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.mekgineerthermaplugg, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.micromachine, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.mogortheogre, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.muklaschampion, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.murlocknight, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.murloctidecaller, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.murlocwarleader, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.natpagle, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.nerubarweblord, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.nexuschampionsaraad, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.northshirecleric, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.obsidiandestroyer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.oldmurkeye, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.oneeyedcheat, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.orgrimmaraspirant, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.pilotedskygolem, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.pitsnake, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.primalfinchampion, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.primalfintotem, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.prophetvelen, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.pyros, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.questingadventurer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.radiantelemental, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.ragingworgen, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.raidleader, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.raptorhatchling, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.ratpack, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.recruiter, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.redmanawyrm, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.rhonin, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.rumblingelemental, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.satedthreshadon, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.savagecombatant, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.savannahhighmane, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.scalednightmare, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.scavenginghyena, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.secretkeeper, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.selflesshero, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.sergeantsally, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.shadeofnaxxramas, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.shadowboxer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.shakuthecollector, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.sherazincorpseflower, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.shiftingshade, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.shimmeringtempest, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.shipscannon, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.siegeengine, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.siltfinspiritwalker, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.silverhandregent, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.sneedsoldshredder, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.sorcerersapprentice, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.southseacaptain, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.southseasquidface, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.spawnofnzoth, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.spawnofshadows, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.spiritsingerumbra, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.spitefulsmith, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.stalagg, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.starvingbuzzard, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.steamwheedlesniper, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.stewardofdarkshire, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.stonesplintertrogg, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.stormwindchampion, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.summoningportal, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.summoningstone, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.sylvanaswindrunner, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.tarcreeper, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.tarlord, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.tarlurker, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.theboogeymonster, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.theskeletonknight, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.thevoraxx, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.thunderbluffvaliant, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.timberwolf, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.tirionfordring, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.tortollanshellraiser, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.tournamentmedic, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.tradeprincegallywix, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.troggzortheearthinator, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.tundrarhino, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.twilightelder, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.twilightsummoner, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.unboundelemental, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.undercityhuckster, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.undertaker, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.usherofsouls, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.v07tr0n, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.viciousfledgling, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.violetillusionist, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.violetteacher, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.vitalitytotem, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.voidcrusher, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.volatileelemental, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.warhorsetrainer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.warsongcommander, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.webspinner, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.whiteeyes, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.wickedwitchdoctor, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.wilfredfizzlebang, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.windupburglebot, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.wobblingrunts, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.youngpriestess, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.ysera, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.yshaarjrageunbound, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.zealousinitiate, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.vryghoul, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.thelichking, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.skelemancer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.shallowgravedigger, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.shadowascendant, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.moirabronzebeard, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.meatwagon, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.highjusticegrimstone, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.hadronox, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.frozenchampion, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.festergut, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.fatespinner, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.explodingbloatbat, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.drakkarienchanter, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.despicabledreadlord, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.cobaltscalebane, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.bonedrake, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.bonebaron, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.blackguard, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.arrogantcrusader, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.arfus, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.abominablebowman, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.voodoohexxer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.venomancer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.valkyrsoulclaimer, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.stubborngastropod, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.runeforgehaunter, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.rotface, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.professorputricide, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.nighthowler, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.nerubianunraveler, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.necroticgeist, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.moorabi, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.icewalker, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.doomedapprentice, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.cryptlord, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.corpsewidow, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.bolvarfireblood, 0);
            silenceTargets.Add(Chireiden.Silverfish.SimCard.bloodqueenlanathel, 0);
        }

        private void setupRandomCards()
        {
            randomEffects.Add(Chireiden.Silverfish.SimCard.alightinthedarkness, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.ancestorscall, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.animalcompanion, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.arcanemissiles, 3);
            randomEffects.Add(Chireiden.Silverfish.SimCard.archthiefrafaam, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.armoredwarhorse, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.avengingwrath, 8);
            randomEffects.Add(Chireiden.Silverfish.SimCard.babblingbook, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.barnes, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.bomblobber, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.bouncingblade, 3);
            randomEffects.Add(Chireiden.Silverfish.SimCard.brawl, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.captainsparrot, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.chitteringtunneler, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.chooseyourpath, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.cleave, 2);
            randomEffects.Add(Chireiden.Silverfish.SimCard.coghammer, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.crackle, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.cthun, 10);
            randomEffects.Add(Chireiden.Silverfish.SimCard.darkbargain, 2);
            randomEffects.Add(Chireiden.Silverfish.SimCard.darkpeddler, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.deadlyshot, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.desertcamel, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.elementaldestruction, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.elitetaurenchieftain, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.enhanceomechano, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.etherealconjurer, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.fierybat, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.finderskeepers, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.firelandsportal, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.flamecannon, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.flamejuggler, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.flamewaker, 2);
            randomEffects.Add(Chireiden.Silverfish.SimCard.forkedlightning, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.freefromamber, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.zarogscrown, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.gelbinmekkatorque, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.glaivezooka, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.grandcrusader, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.greaterarcanemissiles, 3);
            randomEffects.Add(Chireiden.Silverfish.SimCard.grimestreetinformant, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.hallucination, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.harvest, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.hungrydragon, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.hydrologist, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.iammurloc, 3);
            randomEffects.Add(Chireiden.Silverfish.SimCard.iknowaguy, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.ironforgeportal, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.ivoryknight, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.jeweledscarab, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.journeybelow, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.kabalchemist, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.kabalcourier, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.kazakus, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.kingsblood, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.lifetap, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.lightningstorm, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.lockandload, 10);
            randomEffects.Add(Chireiden.Silverfish.SimCard.lotusagents, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.madbomber, 3);
            randomEffects.Add(Chireiden.Silverfish.SimCard.madderbomber, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.maelstromportal, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.masterjouster, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.menageriemagician, 0);
            randomEffects.Add(Chireiden.Silverfish.SimCard.mindcontroltech, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.mindgames, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.mindvision, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.mogorschampion, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.mogortheogre, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.moongladeportal, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.multishot, 2);
            randomEffects.Add(Chireiden.Silverfish.SimCard.museumcurator, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.mysteriouschallenger, 2);
            randomEffects.Add(Chireiden.Silverfish.SimCard.pileon, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.powerofthehorde, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.primordialglyph, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.ramwrangler, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.ravenidol, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.resurrect, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.sabotage, 0);
            randomEffects.Add(Chireiden.Silverfish.SimCard.sensedemons, 2);
            randomEffects.Add(Chireiden.Silverfish.SimCard.servantofkalimos, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.shadowoil, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.shadowvisions, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.silvermoonportal, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.sirfinleymrrgglton, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.soultap, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.spellslinger, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.spreadingmadness, 9);
            randomEffects.Add(Chireiden.Silverfish.SimCard.stampede, 10);
            randomEffects.Add(Chireiden.Silverfish.SimCard.stonehilldefender, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.swashburglar, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.timepieceofhorror, 10);
            randomEffects.Add(Chireiden.Silverfish.SimCard.tinkmasteroverspark, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.tombspider, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.tortollanprimalist, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.totemiccall, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.tuskarrtotemic, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.unholyshadow, 2);
            randomEffects.Add(Chireiden.Silverfish.SimCard.unstableportal, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.varianwrynn, 2);
            randomEffects.Add(Chireiden.Silverfish.SimCard.volcano, 15);
            randomEffects.Add(Chireiden.Silverfish.SimCard.xarilpoisonedmind, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.zoobot, 0);
            randomEffects.Add(Chireiden.Silverfish.SimCard.tomblurker, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.ghastlyconjurer, 1);
            randomEffects.Add(Chireiden.Silverfish.SimCard.shadowessence, 1);

        }


        private void setupChooseDatabase()
        {
            this.choose1database.Add(Chireiden.Silverfish.SimCard.ancientoflore, Chireiden.Silverfish.SimCard.NEW1_008a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.ancientofwar, Chireiden.Silverfish.SimCard.EX1_178b);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.anodizedrobocub, Chireiden.Silverfish.SimCard.GVG_030a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.cenarius, Chireiden.Silverfish.SimCard.EX1_573a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.darkwispers, Chireiden.Silverfish.SimCard.GVG_041b);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.druidoftheclaw, Chireiden.Silverfish.SimCard.EX1_165t1);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.druidoftheflame, Chireiden.Silverfish.SimCard.BRM_010t);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.druidofthesaber, Chireiden.Silverfish.SimCard.AT_042t);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.feralrage, Chireiden.Silverfish.SimCard.OG_047a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.grovetender, Chireiden.Silverfish.SimCard.GVG_032a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.jadeidol, Chireiden.Silverfish.SimCard.CFM_602a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.keeperofthegrove, Chireiden.Silverfish.SimCard.EX1_166a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.kuntheforgottenking, Chireiden.Silverfish.SimCard.CFM_308a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.livingroots, Chireiden.Silverfish.SimCard.AT_037a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.markofnature, Chireiden.Silverfish.SimCard.EX1_155a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.mirekeeper, Chireiden.Silverfish.SimCard.OG_202a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.nourish, Chireiden.Silverfish.SimCard.EX1_164a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.powerofthewild, Chireiden.Silverfish.SimCard.EX1_160b);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.ravenidol, Chireiden.Silverfish.SimCard.LOE_115a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.shellshifter, Chireiden.Silverfish.SimCard.UNG_101t);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.starfall, Chireiden.Silverfish.SimCard.NEW1_007b);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.wispsoftheoldgods, Chireiden.Silverfish.SimCard.OG_195a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.wrath, Chireiden.Silverfish.SimCard.EX1_154a);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.malfurionthepestilent, Chireiden.Silverfish.SimCard.ICC_832b);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.plaguelord, Chireiden.Silverfish.SimCard.ICC_832pb);
            this.choose1database.Add(Chireiden.Silverfish.SimCard.druidoftheswarm, Chireiden.Silverfish.SimCard.ICC_051t);

            this.choose2database.Add(Chireiden.Silverfish.SimCard.ancientoflore, Chireiden.Silverfish.SimCard.NEW1_008b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.ancientofwar, Chireiden.Silverfish.SimCard.EX1_178a);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.anodizedrobocub, Chireiden.Silverfish.SimCard.GVG_030b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.cenarius, Chireiden.Silverfish.SimCard.EX1_573b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.darkwispers, Chireiden.Silverfish.SimCard.GVG_041a);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.druidoftheclaw, Chireiden.Silverfish.SimCard.EX1_165t2);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.druidoftheflame, Chireiden.Silverfish.SimCard.BRM_010t2);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.druidofthesaber, Chireiden.Silverfish.SimCard.AT_042t2);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.feralrage, Chireiden.Silverfish.SimCard.OG_047b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.grovetender, Chireiden.Silverfish.SimCard.GVG_032b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.jadeidol, Chireiden.Silverfish.SimCard.CFM_602b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.keeperofthegrove, Chireiden.Silverfish.SimCard.EX1_166b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.kuntheforgottenking, Chireiden.Silverfish.SimCard.CFM_308b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.livingroots, Chireiden.Silverfish.SimCard.AT_037b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.markofnature, Chireiden.Silverfish.SimCard.EX1_155b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.mirekeeper, Chireiden.Silverfish.SimCard.OG_202ae);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.nourish, Chireiden.Silverfish.SimCard.EX1_164b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.powerofthewild, Chireiden.Silverfish.SimCard.EX1_160t);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.ravenidol, Chireiden.Silverfish.SimCard.LOE_115b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.shellshifter, Chireiden.Silverfish.SimCard.UNG_101t2);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.starfall, Chireiden.Silverfish.SimCard.NEW1_007a);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.wispsoftheoldgods, Chireiden.Silverfish.SimCard.OG_195b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.wrath, Chireiden.Silverfish.SimCard.EX1_154b);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.malfurionthepestilent, Chireiden.Silverfish.SimCard.ICC_832a);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.plaguelord, Chireiden.Silverfish.SimCard.ICC_832pa);
            this.choose2database.Add(Chireiden.Silverfish.SimCard.druidoftheswarm, Chireiden.Silverfish.SimCard.ICC_051t2);
        }


        public int getClassRacePriorityPenality(TAG_CLASS opponentHeroClass, TAG_RACE minionRace)
        {
            int retval = 0;
            switch (opponentHeroClass)
            {
                case TAG_CLASS.WARLOCK:
                    if (this.ClassRacePriorityWarloc.ContainsKey(minionRace)) retval += this.ClassRacePriorityWarloc[minionRace];
                    break;
                case TAG_CLASS.WARRIOR:
                    if (this.ClassRacePriorityWarrior.ContainsKey(minionRace)) retval += this.ClassRacePriorityWarrior[minionRace];
					break;
                case TAG_CLASS.ROGUE:
                    if (this.ClassRacePriorityRouge.ContainsKey(minionRace)) retval += this.ClassRacePriorityRouge[minionRace];
					break;
                case TAG_CLASS.SHAMAN:
                    if (this.ClassRacePriorityShaman.ContainsKey(minionRace)) retval += this.ClassRacePriorityShaman[minionRace];
					break;
                case TAG_CLASS.PRIEST:
                    if (this.ClassRacePriorityPriest.ContainsKey(minionRace)) retval += this.ClassRacePriorityPriest[minionRace];
					break;
                case TAG_CLASS.PALADIN:
                    if (this.ClassRacePriorityPaladin.ContainsKey(minionRace)) retval += this.ClassRacePriorityPaladin[minionRace];
					break;
                case TAG_CLASS.MAGE:
                    if (this.ClassRacePriorityMage.ContainsKey(minionRace)) retval += this.ClassRacePriorityMage[minionRace];
					break;
                case TAG_CLASS.HUNTER:
                    if (this.ClassRacePriorityHunter.ContainsKey(minionRace)) retval += this.ClassRacePriorityHunter[minionRace];
					break;
                case TAG_CLASS.DRUID:
                    if (this.ClassRacePriorityDruid.ContainsKey(minionRace)) retval += this.ClassRacePriorityDruid[minionRace];
                    break;
                default:
                    break;
			}
            return retval;
        }

        private void setupClassRacePriorityDatabase()
        {
            this.ClassRacePriorityWarloc.Add(TAG_RACE.MURLOC, 2);
            this.ClassRacePriorityWarloc.Add(TAG_RACE.DEMON, 2);
            this.ClassRacePriorityWarloc.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityWarloc.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityWarloc.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityHunter.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityHunter.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityHunter.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityHunter.Add(TAG_RACE.PET, 2);
            this.ClassRacePriorityHunter.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityMage.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityMage.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityMage.Add(TAG_RACE.MECHANICAL, 2);
            this.ClassRacePriorityMage.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityMage.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityShaman.Add(TAG_RACE.MURLOC, 2);
            this.ClassRacePriorityShaman.Add(TAG_RACE.PIRATE, 1);
            this.ClassRacePriorityShaman.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityShaman.Add(TAG_RACE.MECHANICAL, 2);
            this.ClassRacePriorityShaman.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityShaman.Add(TAG_RACE.TOTEM, 2);

            this.ClassRacePriorityDruid.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityDruid.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityDruid.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityDruid.Add(TAG_RACE.PET, 1);
            this.ClassRacePriorityDruid.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityPaladin.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityPaladin.Add(TAG_RACE.PIRATE, 1);
            this.ClassRacePriorityPaladin.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityPaladin.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityPaladin.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityPaladin.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityPriest.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityPriest.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityPriest.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityPriest.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityPriest.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityRouge.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityRouge.Add(TAG_RACE.PIRATE, 2);
            this.ClassRacePriorityRouge.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityRouge.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityRouge.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityRouge.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityWarrior.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityWarrior.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityWarrior.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityWarrior.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityWarrior.Add(TAG_RACE.TOTEM, 0);
            this.ClassRacePriorityWarrior.Add(TAG_RACE.PIRATE, 2);
        }

        private void setupGangUpDatabase()
        {
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.addledgrizzly, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.alakirthewindlord, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.aldorpeacekeeper, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.ancientoflore, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.ancientofwar, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.antiquehealbot, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.anubarak, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.archmageantonidas, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.armorsmith, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.ayablackpaw, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.azuredrake, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.baronrivendare, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.biggamehunter, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.biteweed, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.bladeofcthun, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.bloodimp, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.bomblobber, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.boneguardlieutenant, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.burglybully, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.burlyrockjawtrogg, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.cabalshadowpriest, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.cairnebloodhoof, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.cenarius, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.chromaggus, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.cobaltguardian, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.coldarradrake, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.coldlightoracle, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.confessorpaletress, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.corendirebrew, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.cthun, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.cultapothecary, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.cultmaster, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.cultsorcerer, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.dementedfrostcaller, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.demolisher, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.direwolfalpha, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.doppelgangster, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.dragonkinsorcerer, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.drboom, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.earthenringfarseer, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.edwinvancleef, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.emboldener3000, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.emperorthaurissan, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.etherealpeddler, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.felcannon, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.fireelemental, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.fireguarddestroyer, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.flametonguetotem, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.flamewaker, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.flesheatingghoul, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.floatingwatcher, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.foereaper4000, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.friendlybartender, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.frothingberserker, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.gadgetzanauctioneer, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.gahzrilla, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.garr, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.gazlowe, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.gelbinmekkatorque, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.genzotheshark, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.grimestreetenforcer, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.grimscaleoracle, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.grimygadgeteer, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.gruul, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.harrisonjones, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.hemetnesingwary, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.highjusticegrimstone, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.hobgoblin, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.hogger, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.hoggerdoomofelwynn, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.igneouselemental, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.illidanstormrage, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.impmaster, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.infestedtauren, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.ironbeakowl, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.ironjuggernaut, 2);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.ironsensei, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.jadeswarmer, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.jeeves, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.junkbot, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.kelthuzad, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.kingkrush, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.knifejuggler, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.kodorider, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.leeroyjenkins, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.leokk, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.lightwarden, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.lightwell, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.loatheb, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.lucifron, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.lyrathesunshard, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.maexxna, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.malganis, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.malkorok, 2);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.malorne, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.malygos, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.manatidetotem, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.manawyrm, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.masterswordsmith, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.mechwarper, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.medivhtheguardian, 2);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.mekgineerthermaplugg, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.micromachine, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.misha, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.moatlurker, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.moirabronzebeard, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.murlocknight, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.murloctidecaller, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.murlocwarleader, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.nefarian, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.nexuschampionsaraad, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.northshirecleric, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.obsidiandestroyer, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.oldmurkeye, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.onyxia, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.pilotedshredder, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.pintsizedsummoner, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.prophetvelen, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.pyros, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.questingadventurer, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.radiantelemental, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.ragnaroslightlord, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.ragnarosthefirelord, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.raidleader, 2);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.ratpack, 2);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.razorgore, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.recruiter, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.repairbot, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.satedthreshadon, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.savagecombatant, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.savannahhighmane, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.scalednightmare, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.scavenginghyena, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.shadeofnaxxramas, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.shadopanrider, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.shadowboxer, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.shadowfiend, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.shakuthecollector, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.shipscannon, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.siltfinspiritwalker, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.sludgebelcher, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.sneedsoldshredder, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.sorcerersapprentice, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.southseacaptain, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.starvingbuzzard, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.stonesplintertrogg, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.stormwindchampion, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.summoningportal, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.summoningstone, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.swashburglar, 2);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.sylvanaswindrunner, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.theblackknight, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.theboogeymonster, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.timberwolf, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.tirionfordring, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.toshley, 4);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.tradeprincegallywix, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.troggzortheearthinator, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.undercityhuckster, 2);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.undertaker, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.unearthedraptor, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.usherofsouls, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.v07tr0n, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.vaelastrasz, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.viciousfledgling, 2);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.violetillusionist, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.violetteacher, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.vitalitytotem, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.voljin, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.warsongcommander, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.weespellstopper, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.wickedwitchdoctor, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.wobblingrunts, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.xarilpoisonedmind, 3);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.youngpriestess, 1);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.ysera, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.yshaarjrageunbound, 5);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.valkyrsoulclaimer, 0);
            GangUpDatabase.Add(Chireiden.Silverfish.SimCard.cryptlord, 4);
        }

        private void setupbuffHandDatabase()
        {
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.brassknuckles, 1);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.donhancho, 5);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.grimestreetenforcer, 1);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.grimestreetoutfitter, 1);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.grimestreetpawnbroker, 1);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.grimestreetsmuggler, 1);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.grimscalechum, 1);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.grimygadgeteer, 2);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.hiddencache, 2);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.hobartgrapplehammer, 1);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.shakyzipgunner, 2);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.smugglerscrate, 2);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.smugglersrun, 1);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.stolengoods, 3);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.themistcaller, 1);
            buffHandDatabase.Add(Chireiden.Silverfish.SimCard.troggbeastrager, 1);
        }

        private void setupequipWeaponPlayDatabase()
        {
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.arathiweaponsmith, 2);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.blingtron3000, 3);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.daggermastery, 1);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.echolocate, 2);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.instructorrazuvious, 5);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.malkorok, 3);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.medivhtheguardian, 1);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.musterforbattle, 1);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.nzothsfirstmate, 1);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.poisoneddaggers, 2);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.upgrade, 1);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.visionsoftheassassin, 1);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.utheroftheebonblade, 5);
            equipWeaponPlayDatabase.Add(Chireiden.Silverfish.SimCard.scourgelordgarrosh, 4);
        }


    }

}