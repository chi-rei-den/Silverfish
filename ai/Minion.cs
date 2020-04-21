using Chireiden.Silverfish;
using Triton.Game.Mapping;

namespace HREngine.Bots
{
    using HearthDb;
    using HearthDb.Enums;
    using System;
    using System.Collections.Generic;

    public class miniEnch
    {
        public SimCard CARDID = SimCard.None;
        public int creator = 0; // the minion
        public int controllerOfCreator = 0; // own or enemys buff?
        public int copyDeathrattle = 0;

        public miniEnch(SimCard id, int crtr, int controler, int copydr)
        {
            this.CARDID = id;
            this.creator = crtr;
            this.controllerOfCreator = controler;
            this.copyDeathrattle = copydr;
        }
    }

    public class Minion
    {
        //dont silence----------------------------
        public int anzGotDmg = 0;
        public int GotDmgValue = 0;
        public int anzGotHealed = 0;
        public int GotHealedValue = 0;
        public bool gotInspire = false;
        public bool isHero = false;
        public bool own;
        public int pID = 0;

        public SimCard name = SimCard.None;
        public CardClass CardClass = CardClass.INVALID;
        public int synergy = 0;
        public Handcard handcard;
        public int entitiyID = -1;
        //public int id = -1;//delete this
        public int zonepos = 0;
        public SimCard deathrattle2;

        public bool playedThisTurn = false;
        public bool playedPrevTurn = false;
        public int numAttacksThisTurn = 0;
        public bool immuneWhileAttacking = false;

        public bool allreadyAttacked = false;


        public bool shadowmadnessed = false;//´can be silenced :D

        public bool destroyOnOwnTurnStart = false; // depends on own!
        public bool destroyOnEnemyTurnStart = false; // depends on own!
        public bool destroyOnOwnTurnEnd = false; // depends on own!
        public bool destroyOnEnemyTurnEnd = false; // depends on own!
        public bool changeOwnerOnTurnStart = false;

        public bool conceal = false;
        public int ancestralspirit = 0;
        public int desperatestand = 0;
        public int souloftheforest = 0;
        public int stegodon = 0;
        public int livingspores = 0;
        public int explorershat = 0;
        public int returnToHand = 0;
        public int infest = 0;

        public int ownBlessingOfWisdom = 0;
        public int enemyBlessingOfWisdom = 0;
        public int ownPowerWordGlory = 0;
        public int enemyPowerWordGlory = 0;
        public int spellpower = 0;

        public bool cantBeTargetedBySpellsOrHeroPowers = false;
        public bool cantAttackHeroes = false;
        public bool cantAttack = false;

        public int Hp = 0;
        public int maxHp = 0;
        public int armor = 0;

        public int Angr = 0;
        public int AdjacentAngr = 0;
        public int tempAttack = 0;
        public int justBuffed = 0;

        public bool Ready = false;

        public bool taunt = false;
        public bool wounded = false;//hp red?

        public bool divineshild = false;
        public bool windfury = false;
        public bool frozen = false;
        public bool stealth = false;
        public bool immune = false;
        public bool untouchable = false;
        public bool exhausted = false;
        public bool lifesteal = false;

        public int charge = 0;
        public int rush = 0;
        public int hChoice = 0;
        public bool poisonous = false;
        public bool cantLowerHPbelowONE = false;

        public bool silenced = false;
        public bool playedFromHand = false;
        public bool extraParam = false;
        public int extraParam2 = 0;

        public Minion()
        {
            this.handcard = new Handcard();
        }

        public Minion(Minion m)
        {
            //dont silence----------------------------
            //this.anzGotDmg = m.anzGotDmg;
            //this.GotDmgValue = m.GotDmgValue;
            //this.anzGotHealed = m.anzGotHealed;
            this.gotInspire = m.gotInspire;
            this.isHero = m.isHero;
            this.own = m.own;

            this.name = m.name;
            this.CardClass = m.CardClass;
            this.synergy = m.synergy;
            this.handcard = m.handcard;
            this.deathrattle2 = m.deathrattle2;
            this.entitiyID = m.entitiyID;
            this.zonepos = m.zonepos;

            this.allreadyAttacked = m.allreadyAttacked;


            this.playedThisTurn = m.playedThisTurn;
            this.playedPrevTurn = m.playedPrevTurn;
            this.numAttacksThisTurn = m.numAttacksThisTurn;
            this.immuneWhileAttacking = m.immuneWhileAttacking;


            this.shadowmadnessed = m.shadowmadnessed;

            this.ancestralspirit = m.ancestralspirit;
            this.desperatestand = m.desperatestand;
            this.destroyOnOwnTurnStart = m.destroyOnOwnTurnStart; // depends on own!
            this.destroyOnEnemyTurnStart = m.destroyOnEnemyTurnStart; // depends on own!
            this.destroyOnOwnTurnEnd = m.destroyOnOwnTurnEnd; // depends on own!
            this.destroyOnEnemyTurnEnd = m.destroyOnEnemyTurnEnd; // depends on own!
            this.changeOwnerOnTurnStart = m.changeOwnerOnTurnStart;

            this.conceal = m.conceal;
            this.souloftheforest = m.souloftheforest;
            this.stegodon = m.stegodon;
            this.livingspores = m.livingspores;
            this.explorershat = m.explorershat;
            this.returnToHand = m.returnToHand;
            this.infest = m.infest;

            this.ownBlessingOfWisdom = m.ownBlessingOfWisdom;
            this.enemyBlessingOfWisdom = m.enemyBlessingOfWisdom;
            this.ownPowerWordGlory = m.ownPowerWordGlory;
            this.enemyPowerWordGlory = m.enemyPowerWordGlory;
            this.spellpower = m.spellpower;

            this.Hp = m.Hp;
            this.maxHp = m.maxHp;
            this.armor = m.armor;

            this.Angr = m.Angr;
            this.AdjacentAngr = m.AdjacentAngr;
            this.tempAttack = m.tempAttack;
            this.justBuffed = m.justBuffed;

            this.Ready = m.Ready;

            this.taunt = m.taunt;
            this.wounded = m.wounded;

            this.divineshild = m.divineshild;
            this.windfury = m.windfury;
            this.frozen = m.frozen;
            this.stealth = m.stealth;
            this.immune = m.immune;
            this.untouchable = m.untouchable;
            this.exhausted = m.exhausted;

            this.charge = m.charge;
            this.rush = m.rush;
            this.hChoice = m.hChoice;
            this.poisonous = m.poisonous;
            this.lifesteal = m.lifesteal;
            this.cantLowerHPbelowONE = m.cantLowerHPbelowONE;

            this.silenced = m.silenced;
            this.cantBeTargetedBySpellsOrHeroPowers = m.cantBeTargetedBySpellsOrHeroPowers;
            this.cantAttackHeroes = m.cantAttackHeroes;
            this.cantAttack = m.cantAttack;
        }

        public void setMinionToMinion(Minion m)
        {
            //dont silence----------------------------
            this.anzGotDmg = m.anzGotDmg;
            this.GotDmgValue = m.GotDmgValue;
			this.anzGotHealed = m.anzGotHealed;
            this.gotInspire = m.gotInspire;
            this.isHero = m.isHero;
            this.own = m.own;

            this.name = m.name;
            this.CardClass = m.CardClass;
            this.synergy = m.synergy;
            this.handcard = m.handcard;
            this.deathrattle2 = m.deathrattle2;

            this.zonepos = m.zonepos;


            this.allreadyAttacked = m.allreadyAttacked;


            this.numAttacksThisTurn = m.numAttacksThisTurn;
            this.immuneWhileAttacking = m.immuneWhileAttacking;


            this.shadowmadnessed = m.shadowmadnessed;

            this.ancestralspirit = m.ancestralspirit;
            this.desperatestand = m.desperatestand;
            this.destroyOnOwnTurnStart = m.destroyOnOwnTurnStart; // depends on own!
            this.destroyOnEnemyTurnStart = m.destroyOnEnemyTurnStart; // depends on own!
            this.destroyOnOwnTurnEnd = m.destroyOnOwnTurnEnd; // depends on own!
            this.destroyOnEnemyTurnEnd = m.destroyOnEnemyTurnEnd; // depends on own!
            this.changeOwnerOnTurnStart = m.changeOwnerOnTurnStart;

            this.conceal = m.conceal;
            this.souloftheforest = m.souloftheforest;
            this.stegodon = m.stegodon;
            this.livingspores = m.livingspores;
            this.explorershat = m.explorershat;
            this.returnToHand = m.returnToHand;
            this.infest = m.infest;

            this.ownBlessingOfWisdom = m.ownBlessingOfWisdom;
            this.enemyBlessingOfWisdom = m.enemyBlessingOfWisdom;
            this.ownPowerWordGlory = m.ownPowerWordGlory;
            this.enemyPowerWordGlory = m.enemyPowerWordGlory;
            this.spellpower = m.spellpower;

            this.Hp = m.Hp;
            this.maxHp = m.maxHp;
            this.armor = m.armor;

            this.Angr = m.Angr;
            this.AdjacentAngr = m.AdjacentAngr;
            this.tempAttack = m.tempAttack;


            this.taunt = m.taunt;
            this.wounded = m.wounded;

            this.divineshild = m.divineshild;
            this.windfury = m.windfury;
            this.frozen = m.frozen;
            this.stealth = m.stealth;
            this.immune = m.immune;
            this.untouchable = m.untouchable;
            this.exhausted = m.exhausted;

            this.charge = m.charge;
            this.rush = m.rush;
            this.hChoice = m.hChoice;
            if ((m.charge > 0 && !m.frozen && !m.silenced) || (m.rush > 0 && !m.frozen && !m.silenced)) this.Ready = true;
            else this.Ready = false;
            if (m.rush > 0 && m.playedThisTurn) this.cantAttackHeroes = true;
            this.poisonous = m.poisonous;
            this.lifesteal = m.lifesteal;
            this.cantLowerHPbelowONE = m.cantLowerHPbelowONE;

            this.silenced = m.silenced;

            this.cantBeTargetedBySpellsOrHeroPowers = m.cantBeTargetedBySpellsOrHeroPowers;
            this.cantAttackHeroes = m.cantAttackHeroes;
            this.cantAttack = m.cantAttack;
        }

        public int getRealAttack()
        {
            return this.Angr;
        }

        public void getDamageOrHeal(int dmg, Playfield p, bool isMinionAttack, bool dontCalcLostDmg)
        {
            if (this.Hp <= 0) return;

            if (this.immune && dmg > 0 || this.untouchable) return;

            int damage = dmg;
            int heal = 0;
            if (dmg < 0) heal = -dmg;

            if (this.isHero)
            {
                if (this.own)
                {
                    if (p.ownWeapon.name == CardIds.Collectible.Warrior.CursedBlade) dmg += dmg;
                    if (p.anzOwnAnimatedArmor > 0 && dmg > 0) dmg = 1;
                    if (p.anzOwnBolfRamshield > 0 && dmg > 0)


                    {
                        int rest = this.armor - dmg;
                        this.armor = Math.Max(0, rest);
                        if (rest < 0)
                        {
                            foreach (Minion m in p.ownMinions)
                            {
                                if (m.name == CardIds.Collectible.Neutral.BolfRamshield)
                                {
                                    m.getDamageOrHeal(-rest, p, true, false);
                                    break;
                                }
                            }
                        }
                        return;
                    }
                }
                else
                {
                    if (p.anzEnemyAnimatedArmor > 0 && dmg > 0) dmg = 1;
                    if (p.enemyWeapon.name == CardIds.Collectible.Warrior.CursedBlade) dmg += dmg;
                    if (p.anzEnemyBolfRamshield > 0 && dmg > 0)
                    {
                        int rest = this.armor - dmg;
                        this.armor = Math.Max(0, rest);
                        if (rest < 0)
                        {
                            foreach (Minion m in p.enemyMinions)
                            {
                                if (m.name == CardIds.Collectible.Neutral.BolfRamshield)
                                {
                                    m.getDamageOrHeal(-rest, p, true, false);
                                    break;
                                }
                            }
                        }
                        return;
                    }
                }

                int copy = this.Hp;
                if (heal > 0)
                {
                    this.Hp = Math.Min(this.maxHp, this.Hp + heal);
                    if (copy < this.Hp)
                    {
                        p.tempTrigger.charsGotHealed++;
                        this.anzGotHealed++;
                        this.GotHealedValue += heal;
                    }
                }
                else if (dmg > 0)
                {
                    int rest = this.armor - dmg;
                    if (rest < 0) this.Hp += rest;
                    this.armor = Math.Max(0, this.armor - dmg);


                    if (this.cantLowerHPbelowONE && this.Hp <= 0) this.Hp = 1;
                    if (copy > this.Hp)
                    {
                        this.anzGotDmg++;
                        this.GotDmgValue += dmg;
                        if (this.own)
                        {
                            p.tempTrigger.ownMinionsGotDmg++;
                            p.tempTrigger.ownHeroGotDmg++;
                        }
                        else
                        {
                            p.tempTrigger.enemyMinionsGotDmg++;
                            p.tempTrigger.enemyHeroGotDmg++;
                        }
                        p.secretTrigger_HeroGotDmg(this.own, copy - this.Hp);
                    }
                }
                return;
            }

            //its a Minion--------------------------------------------------------------

            bool woundedbefore = this.wounded;
            if (damage > 0) this.allreadyAttacked = true;

            if (damage > 0 && this.divineshild)
            {
                p.minionLosesDivineShield(this);
                if (!own && !dontCalcLostDmg && p.turnCounter == 0)
                {
                    if (isMinionAttack)
                    {
                        p.lostDamage += damage - 1;
                    }
                    else
                    {
                        p.lostDamage += (damage - 1) * (damage - 1);
                    }
                }
                return;
            }

            if (this.cantLowerHPbelowONE && damage >= 1 && damage >= this.Hp) damage = this.Hp - 1;

            if (!own && !dontCalcLostDmg && this.Hp < damage && p.turnCounter == 0)
            {
                if (isMinionAttack)
                {
                    p.lostDamage += (damage - this.Hp);
                }
                else
                {
                    p.lostDamage += (damage - this.Hp) * (damage - this.Hp);
                }
            }

            int hpcopy = this.Hp;

            if (damage >= 1)
            {
                this.Hp = this.Hp - damage;
            }

            if (heal >= 1)
            {
                if (own && !dontCalcLostDmg && heal <= 999 && this.Hp + heal > this.maxHp) p.lostHeal += this.Hp + heal - this.maxHp;

                this.Hp = this.Hp + Math.Min(heal, this.maxHp - this.Hp);
            }



            if (this.Hp > hpcopy)
            {
                //minionWasHealed
                p.tempTrigger.minionsGotHealed++;
                p.tempTrigger.charsGotHealed++;
                this.anzGotHealed++;
                this.GotHealedValue += heal;
            }
            else if (this.Hp < hpcopy)
            {
                if (this.own) p.tempTrigger.ownMinionsGotDmg++;
                else p.tempTrigger.enemyMinionsGotDmg++;

                if (p.anzAcidmaw > 0)
                {
                    if (p.anzAcidmaw == 1)
                    {
                        if (this.name != CardIds.Collectible.Hunter.Acidmaw) this.Hp = 0;
                    }
                    else this.Hp = 0;
                }

                this.anzGotDmg++;
                this.GotDmgValue += dmg;
            }

            if (this.maxHp == this.Hp)
            {
                this.wounded = false;
            }
            else
            {
                this.wounded = true;
            }



            if (this.name == CardIds.Collectible.Priest.Lightspawn && !this.silenced)
            {
                this.Angr = this.Hp;
            }

            if (woundedbefore && !this.wounded)
            {
                this.handcard.card.Simulator.onEnrageStop(p, this);
            }

            if (!woundedbefore && this.wounded)
            {
                this.handcard.card.Simulator.onEnrageStart(p, this);
            }

            if (this.Hp <= 0)
            {
                this.minionDied(p);
            }
        }

        public void minionDied(Playfield p)
        {
            if (this.name == CardIds.Collectible.Neutral.Stalagg)
            {
                p.stalaggDead = true;
            }
            else
            {
                if (this.name == CardIds.Collectible.Neutral.Feugen) p.feugenDead = true;
            }



            if (own)
            {
                p.tempTrigger.ownMinionsDied++;
                if (this.taunt) p.anzOwnTaunt--;
                if (this.handcard.card.Race == Race.BEAST)
                {
                    p.tempTrigger.ownBeastDied++;
                }
                else if (this.handcard.card.Race == Race.MECHANICAL)
                {
                    p.tempTrigger.ownMechanicDied++;
                }
                else if (this.handcard.card.Race == Race.MURLOC)
                {
                    p.tempTrigger.ownMurlocDied++;
                }
            }
            else
            {
                p.tempTrigger.enemyMinionsDied++;
                if (this.taunt) p.anzEnemyTaunt--;
                if (this.handcard.card.Race == Race.BEAST)
                {
                    p.tempTrigger.enemyBeastDied++;
                }
                else if (this.handcard.card.Race == Race.MECHANICAL)
                {
                    p.tempTrigger.enemyMechanicDied++;
                }
                else if (this.handcard.card.Race == Race.MURLOC)
                {
                    p.tempTrigger.enemyMurlocDied++;
                }
            }

            if (p.diedMinions != null)
            {
                GraveYardItem gyi = new GraveYardItem(this.handcard.card.CardId, this.entitiyID, this.own);
                p.diedMinions.Add(gyi);
            }
        }

        public void updateReadyness()
        {
            Ready = false;
            if (cantAttack) return;

            if (isHero)
            {
                if (!frozen && ((charge >= 1 && playedThisTurn) || !playedThisTurn) && (numAttacksThisTurn == 0 || (numAttacksThisTurn == 1 && windfury))) Ready = true;
                return;
            }

            if (!frozen && ((charge >= 1 && playedThisTurn) || !playedThisTurn || shadowmadnessed) && (numAttacksThisTurn == 0 || (numAttacksThisTurn == 1 && windfury) || ( !silenced && this.name == CardIds.NonCollectible.Neutral.MimironsHead_V07Tr0NToken && numAttacksThisTurn <=3 )) ) Ready = true;
            if (!frozen && (((charge == 0 && rush >= 1 && playedThisTurn)) || !playedThisTurn || shadowmadnessed) && (numAttacksThisTurn == 0 || (numAttacksThisTurn == 1 && windfury) || (!silenced && this.name == CardIds.NonCollectible.Neutral.MimironsHead_V07Tr0NToken && numAttacksThisTurn <= 3))) { Ready = true; cantAttackHeroes = true; }
            if (!frozen && (((charge > 0 && rush >= 1 && playedThisTurn)) || !playedThisTurn || shadowmadnessed) && (numAttacksThisTurn == 0 || (numAttacksThisTurn == 1 && windfury) || (!silenced && this.name == CardIds.NonCollectible.Neutral.MimironsHead_V07Tr0NToken && numAttacksThisTurn <= 3)))
            {
                Ready = true;
                cantAttackHeroes = false;
            }
        }

        public void becomeSilence(Playfield p)
        {
            if (this.untouchable) return;
            if (own)
            {
                p.spellpower -= spellpower;
                if (this.taunt) p.anzOwnTaunt--;
            }
            else
            {
                p.enemyspellpower -= spellpower;
                if (this.taunt) p.anzEnemyTaunt--;
            }
            spellpower = 0;

            deathrattle2 = null;
            p.minionGetOrEraseAllAreaBuffs(this, false);
            //buffs
            ancestralspirit = 0;
            desperatestand = 0;
            destroyOnOwnTurnStart = false;
            destroyOnEnemyTurnStart = false;
            destroyOnOwnTurnEnd = false;
            destroyOnEnemyTurnEnd = false;
            changeOwnerOnTurnStart = false;
            conceal = false;
            souloftheforest = 0;
            stegodon = 0;
            livingspores = 0;
            explorershat = 0;
            returnToHand = 0;
            infest = 0;
            deathrattle2 = null;
            if (this.name == CardIds.Collectible.Neutral.MoatLurker && p.LurkersDB.ContainsKey(this.entitiyID)) p.LurkersDB.Remove(this.entitiyID);

            ownBlessingOfWisdom = 0;
            enemyBlessingOfWisdom = 0;
            ownPowerWordGlory = 0;
            enemyPowerWordGlory = 0;

            cantBeTargetedBySpellsOrHeroPowers = false;
            cantAttackHeroes = false;
            cantAttack = false;

            charge = 0;
            rush = 0;
            hChoice = 0;
            taunt = false;
            divineshild = false;
            windfury = false;
            frozen = false;
            stealth = false;
            immune = false;
            poisonous = false;
            cantLowerHPbelowONE = false;
            lifesteal = false;


            //delete enrage (if minion is silenced the first time)
            if (wounded && handcard.card.Enrage && !silenced)
            {
                handcard.card.Simulator.onEnrageStop(p, this);
            }

            //reset attack
            Angr = handcard.card.Attack;
            tempAttack = 0;//we dont toutch the adjacent buffs!


            //reset hp and heal it
            if (maxHp < handcard.card.Health)//minion has lower maxHp as his card -> heal his hp
            {
                Hp += handcard.card.Health - maxHp; //heal minion
            }
            maxHp = handcard.card.Health;
            if (Hp > maxHp) Hp = maxHp;

            if (!silenced)//minion WAS not silenced, deactivate his aura
            {
                handcard.card.Simulator.onAuraEnds(p, this);
            }

            silenced = true;
            this.updateReadyness();
            p.minionGetOrEraseAllAreaBuffs(this, true);
            if (own)
            {
                p.tempTrigger.ownMinionsChanged = true;
            }
            else
            {
                p.tempTrigger.enemyMininsChanged = true;
            }
            if (this.shadowmadnessed)
            {
                this.shadowmadnessed = false;
                p.shadowmadnessed--;
                p.minionGetControlled(this, !own, false);
            }
        }

        public Minion GetTargetForMinionWithSurvival(Playfield p, bool own)
        {
            if (this.Angr == 0) return null;
            if ((own ? p.enemyMinions.Count : p.ownMinions.Count) < 1) return (own ? p.enemyHero : p.ownHero);
            Minion target = new Minion();
            Minion targetTaumt = new Minion();
            foreach (Minion m in own ? p.enemyMinions : p.ownMinions)
            {
                if (m.taunt && !m.silenced)
                {
                    if (this.Hp > m.Hp && (m.Hp + m.Angr + m.Angr * (m.windfury ? 1 : 0)) > (targetTaumt.Hp + targetTaumt.Angr + targetTaumt.Angr * (targetTaumt.windfury ? 1 : 0))) targetTaumt = m;
                }
                else
                {
                    if (this.Hp > m.Hp && (m.Hp + m.Angr + m.Angr * (m.windfury ? 1 : 0)) > (target.Hp + target.Angr + target.Angr * (target.windfury ? 1 : 0))) target = m;
                }
            }
            if (targetTaumt.Hp > 0) return targetTaumt;
            if (target.Hp > 0) return target;
            return null;
        }

        public void loadEnchantments(List<miniEnch> enchants, int ownPlayerControler)
        {
            foreach (miniEnch me in enchants)
            {
                // reborns and destoyings----------------------------------------------


                if (me.CARDID == CardIds.NonCollectible.Paladin.BlessingofWisdom_BlessingOfWisdomEnchantment1 || me.CARDID == CardIds.NonCollectible.Paladin.BlessingofWisdom_BlessingOfWisdomEnchantment2) //BlessingOfWisdom
                {
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.ownBlessingOfWisdom++;
                    }
                    else
                    {
                        this.enemyBlessingOfWisdom++;
                    }
                }

                if (me.CARDID == CardIds.NonCollectible.Neutral.PowerWordGlory_PowerWordGloryEnchantment) //PowerWordGlory
                {
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.ownPowerWordGlory++;
                    }
                    else
                    {
                        this.enemyPowerWordGlory++;
                    }
                }


                if (me.CARDID == CardIds.NonCollectible.Warlock.PowerOverwhelming_PowerOverwhelmingEnchantment) //overwhelmingpower
                {
                    if (me.controllerOfCreator == ownPlayerControler)
                    {
                        this.destroyOnOwnTurnEnd = true;
                    }
                    else
                    {
                        this.destroyOnEnemyTurnEnd = true;
                    }
                }

                if (me.CARDID == CardIds.NonCollectible.Priest.ShadowMadness_ShadowMadnessEnchantment) //Dark Command
                {
                    this.shadowmadnessed = true;
                }

                if (me.CARDID == CardIds.NonCollectible.Neutral.Loatheb_NecroticAuraEnchantment) //Necrotic Aura
                {
                    //todo Eure Zauber kosten in diesem Zug (5) mehr.
                }
                if (me.CARDID == CardIds.NonCollectible.Neutral.MillhouseManastorm_KillMillhouseToken) //death to millhouse!
                {
                    // todo spells cost (0) this turn!
                }
                if (me.CARDID == CardIds.NonCollectible.Mage.KirinTorMage_PowerOfTheKirinTorEnchantment) //Power of the Kirin Tor
                {
                    // todo Your next Secret costs (0).
                }
               // if (me.CARDID == CardIds.NonCollectible.Warrior.WarsongCommander_ChargeEnchantment) //warsongcommander
               // {
              //      this.charge++;
              //  }

                switch(me.CARDID.CardId)
                {
                    //ToDo: TBUD_1	Each turn, if you have less health then a your opponent, summon a free minion


                    // destroy-------------------------------------------------
                    case CardIds.NonCollectible.Warlock.Corruption_CorruptionEnchantment:
                        if (me.controllerOfCreator == ownPlayerControler) this.destroyOnOwnTurnStart = true;
                        else this.destroyOnEnemyTurnStart = true;   //corruption
                        continue;
                    case CardIds.NonCollectible.Neutral.Nightmare_NightmareEnchantment:
                        if (me.controllerOfCreator == ownPlayerControler) this.destroyOnOwnTurnStart = true;
                        else this.destroyOnEnemyTurnStart = true;   //nightmare
                        continue;

                    // deathrattles-------------------------------------------------
                    case CardIds.NonCollectible.Hunter.ExplorersHat_ExplorersHatEnchantment: this.explorershat++; continue;
                    case CardIds.NonCollectible.Shaman.SpiritEcho_EchoedSpiritEnchantment: this.returnToHand++; continue;

                    case CardIds.NonCollectible.Shaman.AncestralSpirit_AncestralSpiritEnchantment: this.ancestralspirit++; continue;
                    case CardIds.NonCollectible.Paladin.DesperateStand_RedeemedEnchantment: this.desperatestand++; continue;
                    case CardIds.NonCollectible.Druid.SouloftheForest_SoulOfTheForestEnchantment: this.souloftheforest++; continue;
                    case CardIds.NonCollectible.Paladin.SpikeridgedSteed_OnAStegodonEnchantment: this.stegodon++; continue;
                    case CardIds.NonCollectible.Neutral.LivingSporesToken2: this.livingspores++; continue;

                    case CardIds.NonCollectible.Druid.Infest_NerubianSpores: this.infest++; continue;
                    case CardIds.NonCollectible.Rogue.UnearthedRaptor_UnearthedRaptorEnchantment: this.extraParam2 = me.copyDeathrattle; continue; //unearthedraptor
                   // case SimCard.LOE_012e: this.deathrattle2 = ; continue; //zzdeletetombexplorer


                    //conceal-------------------------------------------------
                    case CardIds.NonCollectible.Rogue.Conceal_ConcealedEnchantment: this.conceal = true; continue;
                    case CardIds.NonCollectible.Rogue.MasterofDisguise_DisguisedEnchantment: this.conceal = true; continue;
                    case CardIds.NonCollectible.Neutral.FinickyCloakfield_CloakedEnchantment: this.conceal = true; continue;
                    case CardIds.NonCollectible.Neutral.XarilPoisonedMind_Fadeleaf: this.conceal = true; continue;

                    //cantLowerHPbelowONE-------------------------------------------------
                    case CardIds.NonCollectible.Warrior.CommandingShout_CommandingShoutEnchantment1: this.cantLowerHPbelowONE = true; continue; //commandingshout
                    case CardIds.NonCollectible.Warrior.CommandingShout_CommandingShoutEnchantment2: this.cantLowerHPbelowONE = true; continue; //commandingshout

                    //spellpower-------------------------------------------------
                    case CardIds.NonCollectible.Neutral.VelensChosen_VelensChosen: this.spellpower++; continue; //velenschosen
                    case CardIds.NonCollectible.Mage.DalaranAspirant_PowerOfDalaranEnchantment: this.spellpower++; continue; //dalaran
                    case CardIds.NonCollectible.Neutral.AncientMage_TeachingsOfTheKirinTorEnchantment: this.spellpower++; continue; //ancient mage

                    //charge-------------------------------------------------
                    case CardIds.NonCollectible.Warrior.AlexstraszasChampion_AlexstraszasBoonEnchantment: this.charge++; continue;
                    case CardIds.NonCollectible.Warrior.Charge_ChargeEnchantment: this.charge++; continue;
                    case CardIds.NonCollectible.Neutral.GiveTauntAndChargeTavernBrawl: this.charge++; continue;
                    case CardIds.NonCollectible.Hunter.TundraRhino_ChargeEnchantment: this.charge++; continue;

                    //adjacentbuffs-------------------------------------------------
                    case CardIds.NonCollectible.Shaman.FlametongueTotem_FlametongueEnchantment: this.AdjacentAngr += 2; continue; //flametongue
                    case CardIds.NonCollectible.Neutral.DireWolfAlpha_StrengthOfThePackEnchantment: this.AdjacentAngr += 1; continue; //dire wolf alpha

                    //tempbuffs-------------------------------------------------
                    case CardIds.NonCollectible.Rogue.SharpenedEnchantment: this.tempAttack += 1; continue;
                    case CardIds.NonCollectible.Hunter.BestialWrath_BestialWrathEnchantment: this.tempAttack += 2; this.immune = true; continue;
                    case CardIds.NonCollectible.Hunter.Stablemaster_GroomedEnchantment: this.immune = true; continue;
                    case CardIds.NonCollectible.Druid.SavageCombatant_SavageEnchantment: this.tempAttack += 2; continue;
                    case CardIds.NonCollectible.Druid.JusticarTrueheart_DireClaws: this.tempAttack += 2; continue;
                    case CardIds.NonCollectible.Druid.Claw_ClawEnchantment: this.tempAttack += 2; continue;
                    case CardIds.NonCollectible.Druid.SavageRoar_SavageRoarEnchantment: this.tempAttack += 2; continue;
                    case CardIds.NonCollectible.Neutral.DarkIronDwarf_TemperedEnchantment: this.tempAttack += 2; continue;
                    case CardIds.NonCollectible.Neutral.SealofLight_SealOfLight: this.tempAttack += 2; continue;
                    case CardIds.NonCollectible.Shaman.Bloodlust_BloodlustEnchantment: this.tempAttack += 3; continue;
                    case CardIds.NonCollectible.Warrior.HeroicStrike_HeroicStrikeEnchantment: this.tempAttack += 4; continue;
                    case CardIds.NonCollectible.Neutral.Bite_BiteEnchantment: this.tempAttack += 4; continue;
                    case CardIds.NonCollectible.Druid.FeralRage_SpinesEnchantment: this.tempAttack += 4; continue;
                    case CardIds.NonCollectible.Neutral.Enrage_EnrageEnchantment: this.tempAttack += 6; continue;
                    case CardIds.NonCollectible.Neutral.Shrinkmeister_Shrunk: this.tempAttack += -2; continue;
                    case CardIds.NonCollectible.Priest.PintSizePotion_ShrunkEnchantment: this.tempAttack += -3; continue;
                    case CardIds.NonCollectible.Priest.SolemnVigil_MeltEnchantment: this.tempAttack += -1000; continue;
                    case CardIds.NonCollectible.Neutral.WillofMukla_MightOfMuklaEnchantment: this.tempAttack += 8; continue;
                    case CardIds.NonCollectible.Shaman.RockbiterWeapon_RockbiterWeaponEnchantment: this.tempAttack += 3; continue;
                    case CardIds.NonCollectible.Neutral.AbusiveSergeant_InspiredEnchantment: this.tempAttack += 2; continue;
                    case CardIds.NonCollectible.Druid.Shapeshift_ClawsEnchantment: this.tempAttack += 1; continue;









                }
            }
        }
    }

}