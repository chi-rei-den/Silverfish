using Chireiden.Silverfish;
namespace HREngine.Bots
{
    using HearthDb;
    using HearthDb.Enums;
    using System;
    using System.Collections.Generic;

    public class EnemyTurnSimulator
    {

        public int thread = 0;

        private List<Playfield> posmoves = new List<Playfield>(7000);
        //public int maxwide = 20;
        Movegenerator movegen = Movegenerator.Instance;
        public int maxwide = 20;
        private int twotsamount = 0;
        private int berserkIfCanFinishNextTour = 0;


        public void setMaxwide(bool firstStep)
        {
            twotsamount = Settings.Instance.secondTurnAmount;
            if (firstStep) maxwide = Settings.Instance.enemyTurnMaxWide;
            else maxwide = Settings.Instance.enemyTurnMaxWideSecondStep;
            berserkIfCanFinishNextTour = Settings.Instance.berserkIfCanFinishNextTour;
        }

        public void simulateEnemysTurn(Playfield rootfield, bool simulateTwoTurns, bool playaround, bool print, int pprob, int pprob2)
        {

            if (rootfield.bestEnemyPlay == null)
            {
                bool havedonesomething = true;
                posmoves.Clear();

                posmoves.Add(new Playfield(rootfield));
                posmoves[0].isLethalCheck = false;
                posmoves[0].startTurn();
                rootfield.guessingHeroHP = posmoves[0].guessingHeroHP;
                List<Playfield> temp = new List<Playfield>();
                int deep = 0;
                int enemMana = Math.Min(rootfield.enemyMaxMana + 1, 10);

                if (playaround && !rootfield.loatheb)
                {
                    float oldval = Ai.Instance.botBase.getPlayfieldValue(posmoves[0]);
                    posmoves[0].value = int.MinValue;
                    enemMana = posmoves[0].EnemyCardPlaying(rootfield.enemyHeroStartClass, enemMana, rootfield.enemyAnzCards, pprob, pprob2);
                    if (posmoves[0].wehaveCounterspell > 1)
                    {
                        posmoves[0].ownSecretsIDList.Remove(CardIds.Collectible.Mage.Counterspell);
                        posmoves[0].evaluatePenality -= 7;
                    }
                    float newval = Ai.Instance.botBase.getPlayfieldValue(posmoves[0]);
                    posmoves[0].value = int.MinValue;
                    posmoves[0].enemyAnzCards--;
                    posmoves[0].triggerCardsChanged(false);
                    if (oldval < newval)
                    {
                        posmoves.Clear();
                        posmoves.Add(new Playfield(rootfield));
                        posmoves[0].startTurn();
                    }
                }

                if (posmoves[0].ownHeroHasDirectLethal())
                {
                    if (posmoves[0].value >= -2000000) rootfield.value -= 10000;
                    else rootfield.value = -10000;

                    return;
                }

                doSomeBasicEnemyAi(posmoves[0]);

                //play ability!
                if (rootfield.enemyHeroPowerCostLessOnce <= 0 && posmoves[0].enemyAbilityReady && enemMana >= rootfield.enemyHeroAblility.manacost && posmoves[0].enemyHeroAblility.card.canplayCard(posmoves[0], 0, false) && !rootfield.loatheb)
                {
                    int abilityPenality = 0;
                    List<Minion> trgts = posmoves[0].enemyHeroAblility.card.getTargetsForHeroPower(posmoves[0], false);
                    foreach (Minion trgt in trgts)
                    {
                        Action a = new Action(actionEnum.useHeroPower, posmoves[0].enemyHeroAblility, null, 0, trgt, abilityPenality, 0);
                        Playfield pf = new Playfield(posmoves[0]);
                        pf.doAction(a);
                        posmoves.Add(pf);
                    }
                }

                int boardcount = 0;
                //movegen...

                int i = 0;
                int count = 0;
                Playfield p = null;

                Playfield bestold = null;
                havedonesomething = true;
                float bestoldval = int.MaxValue;
                while (havedonesomething)
                {

                    temp.Clear();
                    temp.AddRange(posmoves);
                    havedonesomething = false;
                    count = temp.Count;
                    for (i = 0; i < count; i++)
                    {
                        p = temp[i];
                        if (p.complete)
                        {
                            continue;
                        }
                        List<Action> actions = movegen.getMoveList(p, false, true, false);

                        foreach (Action a in actions)
                        {
                            havedonesomething = true;
                            Playfield pf = new Playfield(p);
                            pf.doAction(a);
                            posmoves.Add(pf);
                            boardcount++;
                        }

                        p.endTurn();
                        p.complete = true;
                        p.guessingHeroHP = rootfield.guessingHeroHP;
                        if (Ai.Instance.botBase.getPlayfieldValue(p) < bestoldval) // want the best enemy-play-> worst for us
                        {
                            bestoldval = Ai.Instance.botBase.getPlayfieldValue(p);
                            bestold = p;
                        }
                        posmoves.Remove(p);
                        if (boardcount >= maxwide) break;
                    }


                    cuttingposibilitiesET();

                    deep++;
                    if (boardcount >= maxwide) break;
                }

                posmoves.Add(bestold);
                float bestval = int.MaxValue;
                Playfield bestplay = bestold;
                count = posmoves.Count;
                for (i = 0; i < count; i++)
                {
                    p = posmoves[i];
                    if (!p.complete)
                    {
                        p.endTurn();
                        p.complete = true;
                    }
                    p.guessingHeroHP = rootfield.guessingHeroHP;
                    float val = Ai.Instance.botBase.getPlayfieldValue(p);
                    if (p.enemyMinions.Count > 6) val += 12;
                    if (bestval > val)// we search the worst value
                    {
                        bestplay = p;
                        bestval = val;
                    }
                }
                if (bestplay.enemyMinions.Count < 7)
                {
                    if (bestplay.enemyAnzCards > 0)
                    {
                        if (bestplay.enemyMaxMana > 5) bestplay.callKid(CardIds.Collectible.Neutral.Spellbreaker, bestplay.enemyMinions.Count, false, false);
                        else bestplay.callKid(CardIds.NonCollectible.Neutral.Xavius_XavianSatyrToken, bestplay.enemyMinions.Count, false, false);
                        int tmp = bestplay.enemyMinions.Count;
                        bestplay.simulateTrapsEndEnemyTurn();

                        if (tmp == bestplay.enemyMinions.Count)
                        {
                            int bval = 1;
                            if (bestplay.enemyMaxMana > 4) bval = 2;
                            if (bestplay.enemyMaxMana > 7) bval = 3;
                            if (bestplay.enemyMinions.Count >= 1) bestplay.minionGetBuffed(bestplay.enemyMinions[bestplay.enemyMinions.Count - 1], bval - 1, bval);
                        }
                    }
                }
                bestplay.startTurn();
                bestplay.ownAbilityReady = false;
                bestplay.owncarddraw = rootfield.owncarddraw;
                bestplay.complete = true;
                bestplay.isLethalCheck = rootfield.isLethalCheck;
                Ai.Instance.botBase.getPlayfieldValue(bestplay);
                bestval = bestplay.value;
                rootfield.value = bestplay.value;

                if (twotsamount > 0 || (rootfield.isLethalCheck && berserkIfCanFinishNextTour > 0))
                {
                    rootfield.bestEnemyPlay = new Playfield(bestplay);
                    rootfield.bestEnemyPlay.value = bestval;
                }
            }




            if ((simulateTwoTurns || (rootfield.isLethalCheck && berserkIfCanFinishNextTour > 0)) && rootfield.bestEnemyPlay != null && rootfield.bestEnemyPlay.value > -1000)
            {


                float bestval = rootfield.bestEnemyPlay.value;
                rootfield.bestEnemyPlay.complete = false;
                rootfield.bestEnemyPlay.value = int.MinValue;
                rootfield.value = Settings.Instance.firstweight * bestval + Settings.Instance.secondweight * Ai.Instance.nextTurnSimulator[this.thread].doallmoves(rootfield.bestEnemyPlay, print);




            }
        }

        public void cuttingposibilitiesET()
        {
            Dictionary<Int64, Playfield> tempDict = new Dictionary<Int64, Playfield>();
            Playfield p = null;
            int max = posmoves.Count;
            for (int i = 0; i < max; i++)
            {
                p = posmoves[i];
                Int64 hash = p.GetPHash();
                if (!tempDict.ContainsKey(hash)) tempDict.Add(hash, p);
            }
            posmoves.Clear();
            foreach (KeyValuePair<Int64, Playfield> d in tempDict)
            {
                posmoves.Add(d.Value);
            }
            tempDict.Clear();
        }

        private void doSomeBasicEnemyAi(Playfield p)
        {
            if (p.enemyHero.CardClass == CardClass.MAGE)
            {
                if (Probabilitymaker.Instance.enemyCardsOut.ContainsKey(CardIds.Collectible.Neutral.Alexstrasza)) p.ownHero.Hp = Math.Max(5, p.ownHero.Hp - 7);
            }

            //play some cards (to not overdraw)
            if (p.enemyAnzCards >= 8)
            {
                p.enemyAnzCards--;
                p.triggerCardsChanged(false);
            }
            if (p.enemyAnzCards >= 4)
            {
                p.enemyAnzCards--;
                p.triggerCardsChanged(false);
            }
            if (p.enemyAnzCards >= 2)
            {
                p.enemyAnzCards--;
                p.triggerCardsChanged(false);
            }

            foreach (Minion m in p.enemyMinions.ToArray())
            {
                if (m.silenced) continue;
                if (p.enemyAnzCards >= 2 && (m.name == CardIds.Collectible.Neutral.GadgetzanAuctioneer || m.name == CardIds.Collectible.Hunter.StarvingBuzzard))
                {
                    if (p.enemyDeckSize >= 1)
                    {
                        p.drawACard(SimCard.None, false);
                    }
                }
                int anz = 0;
                switch (m.name.CardId)
                {
                    //****************************************heal
                    case CardIds.Collectible.Priest.NorthshireCleric:
                        anz = 0;
                        foreach (Minion mnn in p.enemyMinions)
                        {
                            if (mnn.wounded) anz++;
                        }
                        anz = Math.Min(anz, 3);
                        for (int i = 0; i < anz; i++)
                        {
                            if (p.enemyDeckSize >= 1) p.drawACard(SimCard.None, false);
                        }
                        continue;
                    case CardIds.Collectible.Priest.Shadowboxer:
                        anz = 0;
                        foreach (Minion mnn in p.enemyMinions)
                        {
                            if (mnn.wounded) anz++;
                        }
                        if (anz > 0)
                        {
                            anz = Math.Min(anz, 3);
                            Minion target = p.ownHero;
                            for (; anz > 0; anz--)
                            {
                                if (p.ownMinions.Count > 0) target = p.searchRandomMinion(p.ownMinions, SearchMode.LowHealth);
                                if (target == null) target = p.ownHero;
                                p.minionGetDamageOrHeal(target, 1);
                            }
                        }
                        continue;
                    case CardIds.Collectible.Neutral.Lightwarden:
                        anz = 0;
                        foreach (Minion mnn in p.enemyMinions)
                        {
                            if (mnn.wounded) anz++;
                        }
                        if (p.enemyHero.wounded) anz++;
                        if (anz >= 2) p.minionGetBuffed(m, 2, 0);
                        continue;
                    //****************************************
                    //****************************************spell
                    case CardIds.Collectible.Neutral.ManaAddict:
                        if (p.enemyAnzCards >= 1)
                        {
                            p.minionGetTempBuff(m, 2, 0);
                            if (p.enemyAnzCards >= 3 && p.enemyMaxMana >= 5) p.minionGetTempBuff(m, 2, 0);
                        }
                        continue;
                    case CardIds.Collectible.Mage.ManaWyrm:
                        if (p.enemyAnzCards >= 1)
                        {
                            p.minionGetBuffed(m, 1, 0);
                            if (p.enemyAnzCards >= 3 && p.enemyMaxMana >= 5) p.minionGetBuffed(m, 1, 0);
                        }
                        continue;
                    case CardIds.Collectible.Neutral.DragonkinSorcerer:
                        if (p.enemyAnzCards >= 1)
                        {
                            p.minionGetTempBuff(m, 1, 1);
                            if (p.enemyAnzCards >= 3 && p.enemyMaxMana >= 5) p.minionGetBuffed(m, 1, 1);
                        }
                        continue;
                    case CardIds.Collectible.Neutral.VioletTeacher:
                        if (p.enemyAnzCards >= 1)
                        {
                            p.callKid(CardIds.NonCollectible.Neutral.VioletTeacher_VioletApprenticeToken, p.enemyMinions.Count, false);
                            if (p.enemyAnzCards >= 3 && p.enemyMaxMana >= 5) p.callKid(CardIds.NonCollectible.Neutral.VioletTeacher_VioletApprenticeToken, p.enemyMinions.Count, false);
                        }
                        continue;
                    case CardIds.Collectible.Warrior.WarsongCommander:
                        // Druid of the Claw 利爪德鲁伊
                        // Why?
                        p.callKid("EX1_165t1", p.enemyMinions.Count, false, false);
                        continue;
                    case CardIds.Collectible.Neutral.GadgetzanAuctioneer:
                        if (p.enemyAnzCards >= 1)
                        {
                            p.drawACard(SimCard.None, false);
                            if (p.enemyAnzCards >= 3 && p.enemyMaxMana >= 5) p.drawACard(SimCard.None, false);
                        }
                        continue;
                    case CardIds.Collectible.Mage.ArchmageAntonidas:
                        if (p.ownMinions.Count < 1) p.minionGetDamageOrHeal(p.ownHero, 6);
                        else
                        {
                            Minion target = new Minion();
                            foreach (Minion mnn in p.ownMinions)
                            {
                                if (mnn.Hp <= 6 && (mnn.Hp + mnn.Angr) > (target.Hp + target.Angr)) target = mnn;
                            }
                            p.minionGetDamageOrHeal(target, 6);
                        }
                        continue;
                    case CardIds.Collectible.Neutral.Gazlowe:
                        if (p.enemyAnzCards >= 1)
                        {
                            p.drawACard(SimCard.None, false);
                            if (p.enemyAnzCards >= 3 && p.enemyMaxMana >= 5) p.drawACard(SimCard.None, false);
                        }
                        continue;
                    case CardIds.Collectible.Mage.Flamewaker:
                        anz = 0;
                        if (p.enemyAnzCards >= 1) anz++;
                        if (p.enemyAnzCards >= 3 && p.enemyMaxMana >= 5) anz++;
                        if (anz > 0)
                        {
                            Minion target = p.ownHero;
                            anz = anz * 2 - 1;
                            p.minionGetDamageOrHeal(target, 1);
                            for (; anz > 0; anz--)
                            {
                                if (p.ownMinions.Count > 0) target = p.searchRandomMinion(p.ownMinions, SearchMode.LowHealth);
                                if (target == null) target = p.ownHero;
                                p.minionGetDamageOrHeal(target, 1);
                            }
                        }
                        continue;
                    //****************************************
                    //****************************************secret
                    case CardIds.Collectible.Neutral.Secretkeeper:
                        if (p.enemyAnzCards >= 3) p.minionGetBuffed(m, 1, 1);
                        continue;
                    case CardIds.Collectible.Mage.EtherealArcanist:
                        if (p.enemyAnzCards >= 3 || p.enemySecretCount > 0) p.minionGetBuffed(m, 2, 2);
                        continue;
                    //****************************************
                    //****************************************play
                    case CardIds.Collectible.Neutral.Xavius:
                        // Illidan -> Xavius
                        // 可怜的一粒蛋
                        if (p.enemyAnzCards >= 1) p.callKid(CardIds.NonCollectible.Neutral.Xavius_XavianSatyrToken, p.enemyMinions.Count, false);
                        continue;
                    case CardIds.Collectible.Neutral.QuestingAdventurer:
                        if (p.enemyAnzCards >= 1)
                        {
                            p.minionGetBuffed(m, 1, 1);
                            if (p.enemyAnzCards >= 3 && p.enemyMaxMana >= 5) p.minionGetBuffed(m, 1, 1);
                        }
                        continue;
                    case CardIds.Collectible.Shaman.UnboundElemental:
                        if (p.enemyAnzCards >= 2) p.minionGetBuffed(m, 1, 1);
                        continue;
                    //****************************************
                    //****************************************turn
                    //****************************************armor
                    case CardIds.Collectible.Warrior.SiegeEngine:
                        anz = 0;
                        foreach (Minion mnn in p.enemyMinions)
                        {
                            if (mnn.name == CardIds.Collectible.Warrior.Armorsmith) anz++;
                        }
                        if (p.enemyAnzCards >= 3) anz++;
                        if (anz > 0) p.minionGetBuffed(m, anz, 0);
                        continue;
                    //****************************************summon
                    case CardIds.Collectible.Neutral.MurlocTidecaller:
                        if (p.enemyAnzCards >= 2) p.minionGetBuffed(m, 1, 0);
                        continue;
                    case CardIds.Collectible.Neutral.Undertaker:
                        if (p.enemyAnzCards >= 2) p.minionGetBuffed(m, 1, 0);
                        continue;
                    case CardIds.Collectible.Hunter.StarvingBuzzard:
                        if (p.enemyAnzCards >= 2) p.drawACard(SimCard.None, false);
                        continue;
                    case CardIds.Collectible.Paladin.CobaltGuardian:
                        if (p.enemyAnzCards >= 2) m.divineshild = true;
                        continue;
                    case CardIds.Collectible.Neutral.KnifeJuggler:
                        anz = Math.Min(p.enemyAnzCards, p.enemyMaxMana / 2);
                        if (anz > 0)
                        {
                            Minion target = p.ownHero;
                            for (; anz > 0; anz--)
                            {
                                if (p.ownMinions.Count > 0) target = p.searchRandomMinion(p.ownMinions, SearchMode.LowHealth);
                                if (target == null) target = p.ownHero;
                                p.minionGetDamageOrHeal(target, 1);
                            }
                        }
                        continue;
                    case CardIds.Collectible.Neutral.ShipsCannon:
                        if (p.enemyAnzCards >= 2)
                        {
                            Minion target = p.ownHero;
                            if (p.ownMinions.Count > 0) target = p.searchRandomMinion(p.ownMinions, SearchMode.LowHealth);
                            if (target == null) target = p.ownHero;
                            p.minionGetDamageOrHeal(target, 1);
                        }
                        continue;
                    case CardIds.Collectible.Hunter.TundraRhino:
                        p.callKid(CardIds.Collectible.Neutral.IronfurGrizzly, p.enemyMinions.Count, false, true, true);
                        continue;
                    //****************************************
                    //****************************************damage
                    case CardIds.Collectible.Warrior.FrothingBerserker:
                        if (m.Hp >= 3 && p.enemyAnzCards >= 3) p.minionGetBuffed(m, 1, 0);
                        continue;
                    case CardIds.Collectible.Neutral.GurubashiBerserker:
                        if (m.Hp >= 4 && p.enemyAnzCards >= 3) p.minionGetBuffed(m, 3, 0);
                        continue;
                    case CardIds.Collectible.Warlock.FloatingWatcher:
                        if (p.enemyMaxMana >= p.enemyAnzCards * 2) p.minionGetBuffed(m, 2, 2);
                        continue;
                    case CardIds.Collectible.Warrior.Armorsmith:
                        if (p.enemyMinions.Count >= 3) p.minionGetArmor(p.enemyHero, 1);
                        continue;
                    case CardIds.Collectible.Hunter.Gahzrilla:
                        if (m.Hp >= 4 && p.enemyAnzCards >= 3) p.minionGetBuffed(m, m.Angr * 2, 0);
                        continue;
                    case CardIds.Collectible.Neutral.AcolyteOfPain:
                        if (m.Hp >= 3 && p.enemyAnzCards >= 3) p.drawACard(SimCard.None, false);
                        continue;
                    case CardIds.Collectible.Druid.MechBearCat:
                        if (m.Hp >= 3 && p.enemyAnzCards >= 3) p.drawACard(SimCard.None, false);
                        continue;
                    case CardIds.Collectible.Neutral.GrimPatron:
                        if (m.Hp >= 3 && p.enemyAnzCards >= 3) p.callKid(CardIds.Collectible.Neutral.GrimPatron, p.enemyMinions.Count, false);
                        continue;
                    case CardIds.Collectible.Neutral.DragonEgg:
                        if (p.enemyAnzCards >= 3) p.callKid(CardIds.NonCollectible.Neutral.DragonEgg_BlackWhelpToken, p.enemyMinions.Count, false);
                        continue;
                    case CardIds.Collectible.Warlock.ImpGangBoss:
                        if (m.Hp >= 3 && p.enemyAnzCards >= 3) p.callKid(CardIds.NonCollectible.Warlock.ImpGangBoss_ImpToken, p.enemyMinions.Count, false);
                        continue;
                    case CardIds.Collectible.Warrior.AxeFlinger:
                        if (m.Hp >= 3 && p.enemyAnzCards >= 3) p.minionGetDamageOrHeal(p.ownHero, 2);
                        continue;
                    case CardIds.Collectible.Neutral.BrannBronzebeard:
                        p.minionGetBuffed(m, 0, 6);
                        continue;
                    case CardIds.Collectible.Warrior.ObsidianDestroyer:
                        if (p.enemyMinions.Count < 6) p.callKid(CardIds.NonCollectible.Warrior.ObsidianDestroyer_ScarabToken, p.enemyMinions.Count, false);
                        continue;
                    case CardIds.Collectible.Shaman.TunnelTrogg:
                        p.minionGetBuffed(m, 1, 0);
                        continue;
                    case CardIds.Collectible.Neutral.SummoningStone:
                        if (p.enemyMinions.Count < 6) p.callKid(CardIds.Collectible.Paladin.KeeperOfUldaman, p.enemyMinions.Count, false);
                        continue;
                        //****************************************
                        //****************************************dies (rough approximation)
                        //****************************************
                }
            }
            p.doDmgTriggers();
        }
    }
}