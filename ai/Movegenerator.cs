using System.Collections.Generic;
using System.Text;
using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
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
            var ret = new List<Action>();
            var trgts = new List<Minion>();

            if (p.complete || p.ownHero.Hp <= 0)
            {
                return ret;
            }

            //play cards:
            if (own)
            {
                var playedcards = new List<string>();
                var cardNcost = new StringBuilder();

                foreach (var hc in p.owncards)
                {
                    var cardCost = hc.card.getManaCost(p, hc.manacost);
                    if (p.nextSpellThisTurnCostHealth && hc.card.Type == CardType.SPELL || p.nextMurlocThisTurnCostHealth && hc.card.Race == Race.MURLOC)
                    {
                        if (p.ownHero.Hp > cardCost || p.ownHero.immune) { }
                        else
                        {
                            continue; // if not enough Hp
                        }
                    }
                    else if (p.mana < cardCost)
                    {
                        continue; // if not enough manna
                    }

                    var c = hc.card;
                    cardNcost.Clear();
                    cardNcost.Append(c.CardId).Append(hc.manacost);
                    if (playedcards.Contains(cardNcost.ToString()))
                    {
                        continue; // dont play the same card in one loop
                    }

                    playedcards.Add(cardNcost.ToString());

                    var isChoice = c.ChooseOne ? 1 : 0;
                    var choiceDamageFound = false;
                    for (var choice = 0 + 1 * isChoice; choice < 1 + 2 * isChoice; choice++)
                    {
                        if (isChoice == 1)
                        {
                            c = this.pen.getChooseCard(hc.card, choice); // do all choice
                            if (p.ownFandralStaghelm > 0)
                            {
                                if (choiceDamageFound)
                                {
                                    break;
                                }

                                for (var i = 1; i < 3; i++)
                                {
                                    var cTmp = this.pen.getChooseCard(hc.card, i); // do all choice
                                    if (this.pen.DamageTargetDatabase.ContainsKey(cTmp) || p.anzOwnAuchenaiSoulpriest > 0 && this.pen.HealTargetDatabase.ContainsKey(cTmp.CardId))
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

                        if (p.ownMinions.Count > 6 && (c.Type == CardType.MINION || hc.card.Type == CardType.MINION))
                        {
                            continue;
                        }

                        trgts = c.getTargetsForCard(p, p.isLethalCheck, true);
                        if (trgts.Count == 0)
                        {
                            continue;
                        }

                        var cardplayPenality = 0;
                        var bestplace = p.getBestPlace(c.Type == CardType.MINION ? c : hc.card, p.isLethalCheck);
                        foreach (var trgt in trgts)
                        {
                            if (usePenalityManager)
                            {
                                cardplayPenality = this.pen.getPlayCardPenality(c, trgt, p);
                            }

                            if (cardplayPenality <= 499)
                            {
                                var a = new Action(actionEnum.playcard, hc, null, bestplace, trgt, cardplayPenality, choice);
                                ret.Add(a);
                            }
                        }
                    }
                }
            }

            //get targets for Hero weapon and Minions  ###################################################################################

            trgts = p.getAttackTargets(own, p.isLethalCheck);
            if (!p.isLethalCheck)
            {
                trgts = this.cutAttackList(trgts);
            }

            // attack with minions
            var attackingMinions = new List<Minion>(8);
            foreach (var m in own ? p.ownMinions : p.enemyMinions)
            {
                if (m.Ready && m.Angr >= 1 && !m.frozen)
                {
                    attackingMinions.Add(m); //* add non-attacing minions
                }
            }

            attackingMinions = this.cutAttackList(attackingMinions);

            foreach (var m in attackingMinions)
            {
                var attackPenality = 0;
                foreach (var trgt in trgts)
                {
                    if (m.cantAttackHeroes && trgt.isHero)
                    {
                        continue;
                    }

                    if (usePenalityManager)
                    {
                        attackPenality = this.pen.getAttackWithMininonPenality(m, p, trgt);
                    }

                    if (attackPenality <= 499)
                    {
                        var a = new Action(actionEnum.attackWithMinion, null, m, 0, trgt, attackPenality, 0);
                        ret.Add(a);
                    }
                }
            }

            // attack with hero (weapon)
            if (own && p.ownHero.Ready && p.ownHero.Angr >= 1 || !own && p.enemyHero.Ready && p.enemyHero.Angr >= 1)
            {
                var heroAttackPen = 0;
                foreach (var trgt in trgts)
                {
                    if ((own ? p.ownWeapon.cantAttackHeroes : p.enemyWeapon.cantAttackHeroes) && trgt.isHero)
                    {
                        continue;
                    }

                    if (usePenalityManager)
                    {
                        heroAttackPen = this.pen.getAttackWithHeroPenality(trgt, p);
                    }

                    if (heroAttackPen <= 499)
                    {
                        var a = new Action(actionEnum.attackWithHero, null, own ? p.ownHero : p.enemyHero, 0, trgt, heroAttackPen, 0);
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
                    var c = p.ownHeroAblility.card;
                    var isChoice = c.ChooseOne ? 1 : 0;
                    for (var choice = 0 + 1 * isChoice; choice < 1 + 2 * isChoice; choice++)
                    {
                        if (isChoice == 1)
                        {
                            c = this.pen.getChooseCard(p.ownHeroAblility.card, choice); // do all choice
                        }

                        var cardplayPenality = 0;
                        var bestplace = p.ownMinions.Count + 1; //we can not manage it
                        trgts = p.ownHeroAblility.card.getTargetsForHeroPower(p, true);
                        foreach (var trgt in trgts)
                        {
                            if (usePenalityManager)
                            {
                                cardplayPenality = this.pen.getPlayCardPenality(p.ownHeroAblility.card, trgt, p);
                            }

                            if (cardplayPenality <= 499)
                            {
                                var a = new Action(actionEnum.useHeroPower, p.ownHeroAblility, null, bestplace, trgt, cardplayPenality, choice);
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
            var retvalues = new List<Minion>(oldlist.Count);
            var addedmins = new List<Minion>(oldlist.Count);

            foreach (var m in oldlist)
            {
                if (m.isHero)
                {
                    retvalues.Add(m);
                    continue;
                }

                var goingtoadd = true;
                var isSpecial = m.handcard.card.isSpecialMinion;
                foreach (var mnn in addedmins)
                {
                    //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                    var otherisSpecial = mnn.handcard.card.isSpecialMinion;
                    var onlySpecial = isSpecial && otherisSpecial && !m.silenced && !mnn.silenced;
                    var onlyNotSpecial = (!isSpecial || isSpecial && m.silenced) && (!otherisSpecial || otherisSpecial && mnn.silenced);

                    if (onlySpecial && m.name != mnn.name)
                    {
                        continue; // different name -> take it
                    }

                    if ((onlySpecial || onlyNotSpecial) && mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous && mnn.lifesteal == m.lifesteal && m.handcard.card.IsToken == mnn.handcard.card.IsToken && mnn.handcard.card.Race == m.handcard.card.Race)
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
            }
            //help.logg("end targetcutting");

            return retvalues;
        }


        public bool didAttackOrderMatters(Playfield p)
        {
            //return true;
            if (p.isOwnTurn)
            {
                if (p.enemySecretCount >= 1)
                {
                    return true;
                }

                if (p.enemyHero.immune)
                {
                    return true;
                }
            }
            else
            {
                if (p.ownHero.immune)
                {
                    return true;
                }
            }

            var enemym = p.isOwnTurn ? p.enemyMinions : p.ownMinions;
            var ownm = p.isOwnTurn ? p.ownMinions : p.enemyMinions;

            var strongestAttack = 0;
            foreach (var m in enemym)
            {
                if (m.Angr > strongestAttack)
                {
                    strongestAttack = m.Angr;
                }

                if (m.taunt)
                {
                    return true;
                }

                if (m.name == CardIds.Collectible.Neutral.DancingSwords || m.name == CardIds.Collectible.Neutral.Deathlord)
                {
                    return true;
                }
            }

            var haspets = 0;
            var hashyena = false;
            var hasJuggler = false;
            var spawnminions = false;
            foreach (var m in ownm)
            {
                if (m.name == CardIds.Collectible.Neutral.CultMaster)
                {
                    return true;
                }

                if (m.name == CardIds.Collectible.Neutral.KnifeJuggler)
                {
                    hasJuggler = true;
                }

                if (m.Ready && m.Angr >= 1)
                {
                    if (m.AdjacentAngr >= 1)
                    {
                        return true; //wolphalfa or flametongue is in play
                    }

                    if (m.name == CardIds.Collectible.Priest.NorthshireCleric)
                    {
                        return true;
                    }

                    if (m.name == CardIds.Collectible.Warrior.Armorsmith)
                    {
                        return true;
                    }

                    if (m.name == CardIds.Collectible.Neutral.LootHoarder)
                    {
                        return true;
                    }

                    //if (m.name == CardIds.Collectible.Neutral.MadScientist) return true; // dont change the tactic
                    if (m.name == CardIds.Collectible.Neutral.SylvanasWindrunner)
                    {
                        return true;
                    }

                    if (m.name == CardIds.Collectible.Priest.DarkCultist)
                    {
                        return true;
                    }

                    if (m.ownBlessingOfWisdom >= 1)
                    {
                        return true;
                    }

                    if (m.ownPowerWordGlory >= 1)
                    {
                        return true;
                    }

                    if (m.name == CardIds.Collectible.Neutral.AcolyteOfPain)
                    {
                        return true;
                    }

                    if (m.name == CardIds.Collectible.Warrior.FrothingBerserker)
                    {
                        return true;
                    }

                    if (m.name == CardIds.Collectible.Neutral.FlesheatingGhoul)
                    {
                        return true;
                    }

                    if (m.name == CardIds.Collectible.Neutral.BloodmageThalnos)
                    {
                        return true;
                    }

                    if (m.name == CardIds.Collectible.Hunter.Webspinner)
                    {
                        return true;
                    }

                    if (m.name == CardIds.Collectible.Paladin.TirionFordring)
                    {
                        return true;
                    }

                    if (m.name == CardIds.Collectible.Neutral.BaronRivendare)
                    {
                        return true;
                    }


                    //if (m.name == CardIds.Collectible.Neutral.ManaWraith) return true;
                    //buffing minions (attack with them last)
                    if (m.name == CardIds.Collectible.Neutral.RaidLeader || m.name == CardIds.Collectible.Neutral.StormwindChampion || m.name == CardIds.Collectible.Hunter.TimberWolf || m.name == CardIds.Collectible.Neutral.SouthseaCaptain || m.name == CardIds.Collectible.Neutral.MurlocWarleader || m.name == CardIds.Collectible.Neutral.GrimscaleOracle || m.name == CardIds.NonCollectible.Hunter.Leokk || m.name == CardIds.Collectible.Mage.FallenHero || m.name == CardIds.Collectible.Paladin.WarhorseTrainer)
                    {
                        return true;
                    }


                    if (m.name == CardIds.Collectible.Hunter.ScavengingHyena)
                    {
                        hashyena = true;
                    }

                    if (m.handcard.card.Race == Race.BEAST)
                    {
                        haspets++;
                    }

                    if (m.name == CardIds.Collectible.Neutral.HarvestGolem || m.name == CardIds.Collectible.Neutral.HauntedCreeper || m.souloftheforest >= 1 || m.stegodon >= 1 || m.livingspores >= 1 || m.infest >= 1 || m.ancestralspirit >= 1 || m.desperatestand >= 1 || m.explorershat >= 1 || m.returnToHand >= 1 || m.name == CardIds.Collectible.Neutral.NerubianEgg || m.name == CardIds.Collectible.Hunter.SavannahHighmane || m.name == CardIds.Collectible.Neutral.SludgeBelcher || m.name == CardIds.Collectible.Neutral.CairneBloodhoof || m.name == CardIds.Collectible.Neutral.Feugen || m.name == CardIds.Collectible.Neutral.Stalagg || m.name == CardIds.Collectible.Neutral.TheBeast)
                    {
                        spawnminions = true;
                    }
                }
            }

            if (haspets >= 1 && hashyena)
            {
                return true;
            }

            if (hasJuggler && spawnminions)
            {
                return true;
            }


            return false;
        }
    }
}