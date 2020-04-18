namespace HREngine.Bots
{
    using System.Collections.Generic;

    public class Movegenerator
    {
        PenalityManager pen = PenalityManager.Instance;

        private static Movegenerator instance;

        public static Movegenerator Instance
        {
            get
            {
                return instance ?? (instance = new Movegenerator());
            }
        }

        private Movegenerator()
        {
        }
        
        public List<Action> getMoveList(Playfield p, bool usePenalityManager, bool useCutingTargets, bool own)
        {
            //generates only own moves
            List<Action> ret = new List<Action>();
            List<Minion> trgts = new List<Minion>();

            if (p.complete || p.ownHero.Hp <= 0)
            {
                return ret;
            }

          //play cards:
            if (own)
            {
                List<string> playedcards = new List<string>();
                System.Text.StringBuilder cardNcost = new System.Text.StringBuilder();

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    int cardCost = hc.card.getManaCost(p, hc.manacost);
                    if ((p.nextSpellThisTurnCostHealth && hc.card.Type == Chireiden.Silverfish.SimCardtype.SPELL) || (p.nextMurlocThisTurnCostHealth && (TAG_RACE)hc.card.Race == TAG_RACE.MURLOC))
                    {
                        if (p.ownHero.Hp > cardCost || p.ownHero.immune) { }
                        else continue; // if not enough Hp
                    }
                    else if (p.mana < cardCost) continue; // if not enough manna

                    Chireiden.Silverfish.SimCard c = hc.card;
                    cardNcost.Clear();
                    cardNcost.Append(c.name).Append(hc.manacost);
                    if (playedcards.Contains(cardNcost.ToString())) continue; // dont play the same card in one loop
                    playedcards.Add(cardNcost.ToString());

                    int isChoice = (c.choice) ? 1 : 0;
                    bool choiceDamageFound = false;
                    for (int choice = 0 + 1 * isChoice; choice < 1 + 2 * isChoice; choice++)
                    {
                        if (isChoice == 1)
                        {
                            c = pen.getChooseCard(hc.card, choice); // do all choice
                            if (p.ownFandralStaghelm > 0)
                            {
                                if (choiceDamageFound) break;
                                for (int i = 1; i < 3; i++)
                                {
                                    Chireiden.Silverfish.SimCard cTmp = pen.getChooseCard(hc.card, i); // do all choice
                                    if (pen.DamageTargetDatabase.ContainsKey(cTmp.name) || (p.anzOwnAuchenaiSoulpriest > 0 && pen.HealTargetDatabase.ContainsKey(cTmp.name)))
                                    {
                                        choice = i;
                                        choiceDamageFound = true;
                                        c = cTmp;
                                        break;
                                    }
                                    //- Draw a card must be at end in the Sim_xxx - then it will selected!
                                }
                            }
                        }
                        if (p.ownMinions.Count > 6 && (c.Type == Chireiden.Silverfish.SimCardtype.MOB || hc.card.Type == Chireiden.Silverfish.SimCardtype.MOB)) continue;
                        trgts = c.getTargetsForCard(p, p.isLethalCheck, true);
                        if (trgts.Count == 0) continue;

                        int cardplayPenality = 0;
                        int bestplace = p.getBestPlace(c.Type == Chireiden.Silverfish.SimCardtype.MOB ? c : hc.card, p.isLethalCheck);
                        foreach (Minion trgt in trgts)
                        {
                            if (usePenalityManager) cardplayPenality = pen.getPlayCardPenality(c, trgt, p);
                            if (cardplayPenality <= 499)
                            {
                                Action a = new Action(actionEnum.playcard, hc, null, bestplace, trgt, cardplayPenality, choice);
                                ret.Add(a);
                            }
                        }
                    }
                }
            }

          //get targets for Hero weapon and Minions  ###################################################################################

            trgts = p.getAttackTargets(own, p.isLethalCheck);
            if (!p.isLethalCheck) trgts = this.cutAttackList(trgts);

          // attack with minions
            List<Minion> attackingMinions = new List<Minion>(8);
            foreach (Minion m in (own ? p.ownMinions : p.enemyMinions))
            {
                if (m.Ready && m.Angr >= 1 && !m.frozen) attackingMinions.Add(m); //* add non-attacing minions
            }
            attackingMinions = this.cutAttackList(attackingMinions);

            foreach (Minion m in attackingMinions)
            {
                int attackPenality = 0;
                foreach (Minion trgt in trgts)
                {
                    if (m.cantAttackHeroes && trgt.isHero) continue;
                    if (usePenalityManager) attackPenality = pen.getAttackWithMininonPenality(m, p, trgt);
                    if (attackPenality <= 499)
                    {
                        Action a = new Action(actionEnum.attackWithMinion, null, m, 0, trgt, attackPenality, 0);
                        ret.Add(a);
                    }
                }
            }

          // attack with hero (weapon)
            if ((own && p.ownHero.Ready && p.ownHero.Angr >= 1) || (!own && p.enemyHero.Ready && p.enemyHero.Angr >= 1))
            {
                int heroAttackPen = 0;
                foreach (Minion trgt in trgts)
                {
                    if ((own ? p.ownWeapon.cantAttackHeroes : p.enemyWeapon.cantAttackHeroes) && trgt.isHero) continue;
                    if (usePenalityManager) heroAttackPen = pen.getAttackWithHeroPenality(trgt, p);
                    if (heroAttackPen <= 499)
                    {
                        Action a = new Action(actionEnum.attackWithHero, null, (own ? p.ownHero : p.enemyHero), 0, trgt, heroAttackPen, 0);
                        ret.Add(a);
                    }
                }
            }

            //#############################################################################################################

            // use own ability
            if (own)
            {
                if (p.ownAbilityReady && p.mana >= p.ownHeroAblility.card.getManaCost(p, p.ownHeroAblility.manacost)) // if ready and enough manna
                {
                    Chireiden.Silverfish.SimCard c = p.ownHeroAblility.card;
                    int isChoice = (c.choice) ? 1 : 0;
                    for (int choice = 0 + 1 * isChoice; choice < 1 + 2 * isChoice; choice++)
                    {
                        if (isChoice == 1)
                        {
                            c = pen.getChooseCard(p.ownHeroAblility.card, choice); // do all choice
                        }
                        int cardplayPenality = 0;
                        int bestplace = p.ownMinions.Count + 1; //we can not manage it
                        trgts = p.ownHeroAblility.card.getTargetsForHeroPower(p, true);
                        foreach (Minion trgt in trgts)
                        {
                            if (usePenalityManager) cardplayPenality = pen.getPlayCardPenality(p.ownHeroAblility.card, trgt, p);
                            if (cardplayPenality <= 499)
                            {
                                Action a = new Action(actionEnum.useHeroPower, p.ownHeroAblility, null, bestplace, trgt, cardplayPenality, choice);
                                ret.Add(a);
                            }
                        }
                    }
                }
            }

            return ret;
        }

        public List<Minion> cutAttackList(List<Minion> oldlist)
        {
            List<Minion> retvalues = new List<Minion>(oldlist.Count);
            List<Minion> addedmins = new List<Minion>(oldlist.Count);

            foreach (Minion m in oldlist)
            {
                if (m.isHero)
                {
                    retvalues.Add(m);
                    continue;
                }

                bool goingtoadd = true;
                bool isSpecial = m.handcard.card.isSpecialMinion;
                foreach (Minion mnn in addedmins)
                {
                    //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                    bool otherisSpecial = mnn.handcard.card.isSpecialMinion;
			        bool onlySpecial = isSpecial && otherisSpecial && !m.silenced && !mnn.silenced;
			        bool onlyNotSpecial =(!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced));
			
			        if(onlySpecial && (m.name != mnn.name)) continue; // different name -> take it
                    if ((onlySpecial || onlyNotSpecial) && (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous && mnn.lifesteal == m.lifesteal && m.handcard.card.isToken == mnn.handcard.card.isToken && mnn.handcard.card.Race == m.handcard.card.Race))
                    {
				        goingtoadd = false;
				        break;
                    }
                }

                if (goingtoadd)
                {
                    addedmins.Add(m);
                    retvalues.Add(m);
                    //help.logg(m.name + " " + m.id +" is added to targetlist");
                }
                else
                {
                    //help.logg(m.name + " is not needed to attack");
                    continue;
                }
            }
            //help.logg("end targetcutting");

            return retvalues;
        }


        public bool didAttackOrderMatters(Playfield p)
        {
            //return true;
            if (p.isOwnTurn)
            {
                if (p.enemySecretCount >= 1) return true;
                if (p.enemyHero.immune) return true;

            }
            else
            {
                if (p.ownHero.immune) return true;
            }
            List<Minion> enemym = (p.isOwnTurn) ? p.enemyMinions : p.ownMinions;
            List<Minion> ownm = (p.isOwnTurn) ? p.ownMinions : p.enemyMinions;

            int strongestAttack = 0;
            foreach (Minion m in enemym)
            {
                if (m.Angr > strongestAttack) strongestAttack = m.Angr;
                if (m.taunt) return true;
                if (m.name == CardIds.Collectible.Neutral.DancingSwords || m.name == CardIds.Collectible.Neutral.Deathlord) return true;
            }

            int haspets = 0;
            bool hashyena = false;
            bool hasJuggler = false;
            bool spawnminions = false;
            foreach (Minion m in ownm)
            {
                if (m.name == CardIds.Collectible.Neutral.CultMaster) return true;
                if (m.name == CardIds.Collectible.Neutral.KnifeJuggler) hasJuggler = true;
                if (m.Ready && m.Angr >= 1)
                {
                    if (m.AdjacentAngr >= 1) return true;//wolphalfa or flametongue is in play
                    if (m.name == CardIds.Collectible.Priest.NorthshireCleric) return true;
                    if (m.name == CardIds.Collectible.Warrior.Armorsmith) return true;
                    if (m.name == CardIds.Collectible.Neutral.LootHoarder) return true;
                    //if (m.name == CardIds.Collectible.Neutral.MadScientist) return true; // dont change the tactic
                    if (m.name == CardIds.Collectible.Neutral.SylvanasWindrunner) return true;
                    if (m.name == CardIds.Collectible.Priest.DarkCultist) return true;
                    if (m.ownBlessingOfWisdom >= 1) return true;
                    if (m.ownPowerWordGlory >= 1) return true;
                    if (m.name == CardIds.Collectible.Neutral.AcolyteOfPain) return true;
                    if (m.name == CardIds.Collectible.Warrior.FrothingBerserker) return true;
                    if (m.name == CardIds.Collectible.Neutral.FlesheatingGhoul) return true;
                    if (m.name == CardIds.Collectible.Neutral.BloodmageThalnos) return true;
                    if (m.name == CardIds.Collectible.Hunter.Webspinner) return true;
                    if (m.name == CardIds.Collectible.Paladin.TirionFordring) return true;
                    if (m.name == CardIds.Collectible.Neutral.BaronRivendare) return true;


                    //if (m.name == CardIds.Collectible.Neutral.ManaWraith) return true;
                    //buffing minions (attack with them last)
                    if (m.name == CardIds.Collectible.Neutral.RaidLeader || m.name == CardIds.Collectible.Neutral.StormwindChampion || m.name == CardIds.Collectible.Hunter.TimberWolf || m.name == CardIds.Collectible.Neutral.SouthseaCaptain || m.name == CardIds.Collectible.Neutral.MurlocWarleader || m.name == CardIds.Collectible.Neutral.GrimscaleOracle || m.name == CardIds.NonCollectible.Hunter.Leokk || m.name == CardIds.Collectible.Mage.FallenHero || m.name == CardIds.Collectible.Paladin.WarhorseTrainer) return true;


                    if (m.name == CardIds.Collectible.Hunter.ScavengingHyena) hashyena = true;
                    if (m.handcard.card.Race == 20) haspets++;
                    if (m.name == CardIds.Collectible.Neutral.HarvestGolem || m.name == CardIds.Collectible.Neutral.HauntedCreeper || m.souloftheforest >= 1 || m.stegodon >= 1 || m.livingspores >= 1 || m.infest >= 1 || m.ancestralspirit >= 1 || m.desperatestand  >= 1 || m.explorershat >= 1 || m.returnToHand >= 1 || m.name == CardIds.Collectible.Neutral.NerubianEgg || m.name == CardIds.Collectible.Hunter.SavannahHighmane || m.name == CardIds.Collectible.Neutral.SludgeBelcher || m.name == CardIds.Collectible.Neutral.CairneBloodhoof || m.name == CardIds.Collectible.Neutral.Feugen || m.name == CardIds.Collectible.Neutral.Stalagg || m.name == CardIds.Collectible.Neutral.TheBeast) spawnminions = true;
                    
                }
            }

            if (haspets >= 1 && hashyena) return true;
            if (hasJuggler && spawnminions) return true;




            return false;
        }
    }

}