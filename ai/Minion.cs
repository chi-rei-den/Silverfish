using System;
using System.Collections.Generic;
using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
    public class miniEnch
    {
        public SimCard CARDID = SimCard.None;
        public int creator; // the minion
        public int controllerOfCreator; // own or enemys buff?
        public int copyDeathrattle;

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
        public int anzGotDmg;
        public int GotDmgValue;
        public int anzGotHealed;
        public int GotHealedValue;
        public bool gotInspire;
        public bool isHero;
        public bool own;
        public int pID = 0;

        public SimCard name = SimCard.None;
        public CardClass CardClass = CardClass.INVALID;
        public int synergy;
        public Handcard handcard;

        public int entitiyID = -1;

        //public int id = -1;//delete this
        public int zonepos;
        public SimCard deathrattle2;

        public bool playedThisTurn;
        public bool playedPrevTurn;
        public int numAttacksThisTurn;
        public bool immuneWhileAttacking;

        public bool allreadyAttacked;


        public bool shadowmadnessed; //´can be silenced :D

        public bool destroyOnOwnTurnStart; // depends on own!
        public bool destroyOnEnemyTurnStart; // depends on own!
        public bool destroyOnOwnTurnEnd; // depends on own!
        public bool destroyOnEnemyTurnEnd; // depends on own!
        public bool changeOwnerOnTurnStart;

        public bool conceal;
        public int ancestralspirit;
        public int desperatestand;
        public int souloftheforest;
        public int stegodon;
        public int livingspores;
        public int explorershat;
        public int returnToHand;
        public int infest;

        public int ownBlessingOfWisdom;
        public int enemyBlessingOfWisdom;
        public int ownPowerWordGlory;
        public int enemyPowerWordGlory;
        public int spellpower;

        public bool cantBeTargetedBySpellsOrHeroPowers;
        public bool cantAttackHeroes;
        public bool cantAttack;

        public int Hp;
        public int maxHp;
        public int armor;

        public int Angr;
        public int AdjacentAngr;
        public int tempAttack;
        public int justBuffed;

        public bool Ready;

        public bool taunt;
        public bool wounded; //hp red?

        public bool divineshild;
        public bool windfury;
        public bool frozen;
        public bool stealth;
        public bool immune;
        public bool untouchable;
        public bool exhausted;
        public bool lifesteal;

        public int charge;
        public int rush;
        public int hChoice;
        public bool poisonous;
        public bool cantLowerHPbelowONE;

        public bool silenced;
        public bool playedFromHand = false;
        public bool extraParam = false;
        public int extraParam2;

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
            if (m.charge > 0 && !m.frozen && !m.silenced || m.rush > 0 && !m.frozen && !m.silenced)
            {
                this.Ready = true;
            }
            else
            {
                this.Ready = false;
            }

            if (m.rush > 0 && m.playedThisTurn)
            {
                this.cantAttackHeroes = true;
            }

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
            if (this.Hp <= 0)
            {
                return;
            }

            if (this.immune && dmg > 0 || this.untouchable)
            {
                return;
            }

            var damage = dmg;
            var heal = 0;
            if (dmg < 0)
            {
                heal = -dmg;
            }

            if (this.isHero)
            {
                if (this.own)
                {
                    if (p.ownWeapon.name == CardIds.Collectible.Warrior.CursedBlade)
                    {
                        dmg += dmg;
                    }

                    if (p.anzOwnAnimatedArmor > 0 && dmg > 0)
                    {
                        dmg = 1;
                    }

                    if (p.anzOwnBolfRamshield > 0 && dmg > 0)


                    {
                        var rest = this.armor - dmg;
                        this.armor = Math.Max(0, rest);
                        if (rest < 0)
                        {
                            foreach (var m in p.ownMinions)
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
                    if (p.anzEnemyAnimatedArmor > 0 && dmg > 0)
                    {
                        dmg = 1;
                    }

                    if (p.enemyWeapon.name == CardIds.Collectible.Warrior.CursedBlade)
                    {
                        dmg += dmg;
                    }

                    if (p.anzEnemyBolfRamshield > 0 && dmg > 0)
                    {
                        var rest = this.armor - dmg;
                        this.armor = Math.Max(0, rest);
                        if (rest < 0)
                        {
                            foreach (var m in p.enemyMinions)
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

                var copy = this.Hp;
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
                    var rest = this.armor - dmg;
                    if (rest < 0)
                    {
                        this.Hp += rest;
                    }

                    this.armor = Math.Max(0, this.armor - dmg);


                    if (this.cantLowerHPbelowONE && this.Hp <= 0)
                    {
                        this.Hp = 1;
                    }

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

            var woundedbefore = this.wounded;
            if (damage > 0)
            {
                this.allreadyAttacked = true;
            }

            if (damage > 0 && this.divineshild)
            {
                p.minionLosesDivineShield(this);
                if (!this.own && !dontCalcLostDmg && p.turnCounter == 0)
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

            if (this.cantLowerHPbelowONE && damage >= 1 && damage >= this.Hp)
            {
                damage = this.Hp - 1;
            }

            if (!this.own && !dontCalcLostDmg && this.Hp < damage && p.turnCounter == 0)
            {
                if (isMinionAttack)
                {
                    p.lostDamage += damage - this.Hp;
                }
                else
                {
                    p.lostDamage += (damage - this.Hp) * (damage - this.Hp);
                }
            }

            var hpcopy = this.Hp;

            if (damage >= 1)
            {
                this.Hp = this.Hp - damage;
            }

            if (heal >= 1)
            {
                if (this.own && !dontCalcLostDmg && heal <= 999 && this.Hp + heal > this.maxHp)
                {
                    p.lostHeal += this.Hp + heal - this.maxHp;
                }

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
                if (this.own)
                {
                    p.tempTrigger.ownMinionsGotDmg++;
                }
                else
                {
                    p.tempTrigger.enemyMinionsGotDmg++;
                }

                if (p.anzAcidmaw > 0)
                {
                    if (p.anzAcidmaw == 1)
                    {
                        if (this.name != CardIds.Collectible.Hunter.Acidmaw)
                        {
                            this.Hp = 0;
                        }
                    }
                    else
                    {
                        this.Hp = 0;
                    }
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
                if (this.name == CardIds.Collectible.Neutral.Feugen)
                {
                    p.feugenDead = true;
                }
            }


            if (this.own)
            {
                p.tempTrigger.ownMinionsDied++;
                if (this.taunt)
                {
                    p.anzOwnTaunt--;
                }

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
                if (this.taunt)
                {
                    p.anzEnemyTaunt--;
                }

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
                var gyi = new GraveYardItem(this.handcard.card.CardId, this.entitiyID, this.own);
                p.diedMinions.Add(gyi);
            }
        }

        public void updateReadyness()
        {
            this.Ready = false;
            if (this.cantAttack)
            {
                return;
            }

            if (this.isHero)
            {
                if (!this.frozen && (this.charge >= 1 && this.playedThisTurn || !this.playedThisTurn) && (this.numAttacksThisTurn == 0 || this.numAttacksThisTurn == 1 && this.windfury))
                {
                    this.Ready = true;
                }

                return;
            }

            if (!this.frozen && (this.charge >= 1 && this.playedThisTurn || !this.playedThisTurn || this.shadowmadnessed) && (this.numAttacksThisTurn == 0 || this.numAttacksThisTurn == 1 && this.windfury || !this.silenced && this.name == CardIds.NonCollectible.Neutral.MimironsHead_V07Tr0NToken && this.numAttacksThisTurn <= 3))
            {
                this.Ready = true;
            }

            if (!this.frozen && (this.charge == 0 && this.rush >= 1 && this.playedThisTurn || !this.playedThisTurn || this.shadowmadnessed) && (this.numAttacksThisTurn == 0 || this.numAttacksThisTurn == 1 && this.windfury || !this.silenced && this.name == CardIds.NonCollectible.Neutral.MimironsHead_V07Tr0NToken && this.numAttacksThisTurn <= 3))
            {
                this.Ready = true;
                this.cantAttackHeroes = true;
            }

            if (!this.frozen && (this.charge > 0 && this.rush >= 1 && this.playedThisTurn || !this.playedThisTurn || this.shadowmadnessed) && (this.numAttacksThisTurn == 0 || this.numAttacksThisTurn == 1 && this.windfury || !this.silenced && this.name == CardIds.NonCollectible.Neutral.MimironsHead_V07Tr0NToken && this.numAttacksThisTurn <= 3))
            {
                this.Ready = true;
                this.cantAttackHeroes = false;
            }
        }

        public void becomeSilence(Playfield p)
        {
            if (this.untouchable)
            {
                return;
            }

            if (this.own)
            {
                p.spellpower -= this.spellpower;
                if (this.taunt)
                {
                    p.anzOwnTaunt--;
                }
            }
            else
            {
                p.enemyspellpower -= this.spellpower;
                if (this.taunt)
                {
                    p.anzEnemyTaunt--;
                }
            }

            this.spellpower = 0;

            this.deathrattle2 = null;
            p.minionGetOrEraseAllAreaBuffs(this, false);
            //buffs
            this.ancestralspirit = 0;
            this.desperatestand = 0;
            this.destroyOnOwnTurnStart = false;
            this.destroyOnEnemyTurnStart = false;
            this.destroyOnOwnTurnEnd = false;
            this.destroyOnEnemyTurnEnd = false;
            this.changeOwnerOnTurnStart = false;
            this.conceal = false;
            this.souloftheforest = 0;
            this.stegodon = 0;
            this.livingspores = 0;
            this.explorershat = 0;
            this.returnToHand = 0;
            this.infest = 0;
            this.deathrattle2 = null;
            if (this.name == CardIds.Collectible.Neutral.MoatLurker && p.LurkersDB.ContainsKey(this.entitiyID))
            {
                p.LurkersDB.Remove(this.entitiyID);
            }

            this.ownBlessingOfWisdom = 0;
            this.enemyBlessingOfWisdom = 0;
            this.ownPowerWordGlory = 0;
            this.enemyPowerWordGlory = 0;

            this.cantBeTargetedBySpellsOrHeroPowers = false;
            this.cantAttackHeroes = false;
            this.cantAttack = false;

            this.charge = 0;
            this.rush = 0;
            this.hChoice = 0;
            this.taunt = false;
            this.divineshild = false;
            this.windfury = false;
            this.frozen = false;
            this.stealth = false;
            this.immune = false;
            this.poisonous = false;
            this.cantLowerHPbelowONE = false;
            this.lifesteal = false;


            //delete enrage (if minion is silenced the first time)
            if (this.wounded && this.handcard.card.Enrage && !this.silenced)
            {
                this.handcard.card.Simulator.onEnrageStop(p, this);
            }

            //reset attack
            this.Angr = this.handcard.card.Attack;
            this.tempAttack = 0; //we dont toutch the adjacent buffs!


            //reset hp and heal it
            if (this.maxHp < this.handcard.card.Health) //minion has lower maxHp as his card -> heal his hp
            {
                this.Hp += this.handcard.card.Health - this.maxHp; //heal minion
            }

            this.maxHp = this.handcard.card.Health;
            if (this.Hp > this.maxHp)
            {
                this.Hp = this.maxHp;
            }

            if (!this.silenced) //minion WAS not silenced, deactivate his aura
            {
                this.handcard.card.Simulator.onAuraEnds(p, this);
            }

            this.silenced = true;
            this.updateReadyness();
            p.minionGetOrEraseAllAreaBuffs(this, true);
            if (this.own)
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
                p.minionGetControlled(this, !this.own, false);
            }
        }

        public Minion GetTargetForMinionWithSurvival(Playfield p, bool own)
        {
            if (this.Angr == 0)
            {
                return null;
            }

            if ((own ? p.enemyMinions.Count : p.ownMinions.Count) < 1)
            {
                return own ? p.enemyHero : p.ownHero;
            }

            var target = new Minion();
            var targetTaumt = new Minion();
            foreach (var m in own ? p.enemyMinions : p.ownMinions)
            {
                if (m.taunt && !m.silenced)
                {
                    if (this.Hp > m.Hp && m.Hp + m.Angr + m.Angr * (m.windfury ? 1 : 0) > targetTaumt.Hp + targetTaumt.Angr + targetTaumt.Angr * (targetTaumt.windfury ? 1 : 0))
                    {
                        targetTaumt = m;
                    }
                }
                else
                {
                    if (this.Hp > m.Hp && m.Hp + m.Angr + m.Angr * (m.windfury ? 1 : 0) > target.Hp + target.Angr + target.Angr * (target.windfury ? 1 : 0))
                    {
                        target = m;
                    }
                }
            }

            if (targetTaumt.Hp > 0)
            {
                return targetTaumt;
            }

            if (target.Hp > 0)
            {
                return target;
            }

            return null;
        }

        public void loadEnchantments(List<miniEnch> enchants, int ownPlayerControler)
        {
            foreach (var me in enchants)
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

                switch (me.CARDID.CardId)
                {
                    //ToDo: TBUD_1	Each turn, if you have less health then a your opponent, summon a free minion


                    // destroy-------------------------------------------------
                    case CardIds.NonCollectible.Warlock.Corruption_CorruptionEnchantment:
                        if (me.controllerOfCreator == ownPlayerControler)
                        {
                            this.destroyOnOwnTurnStart = true;
                        }
                        else
                        {
                            this.destroyOnEnemyTurnStart = true; //corruption
                        }

                        continue;
                    case CardIds.NonCollectible.Neutral.Nightmare_NightmareEnchantment:
                        if (me.controllerOfCreator == ownPlayerControler)
                        {
                            this.destroyOnOwnTurnStart = true;
                        }
                        else
                        {
                            this.destroyOnEnemyTurnStart = true; //nightmare
                        }

                        continue;

                    // deathrattles-------------------------------------------------
                    case CardIds.NonCollectible.Hunter.ExplorersHat_ExplorersHatEnchantment:
                        this.explorershat++;
                        continue;
                    case CardIds.NonCollectible.Shaman.SpiritEcho_EchoedSpiritEnchantment:
                        this.returnToHand++;
                        continue;

                    case CardIds.NonCollectible.Shaman.AncestralSpirit_AncestralSpiritEnchantment:
                        this.ancestralspirit++;
                        continue;
                    case CardIds.NonCollectible.Paladin.DesperateStand_RedeemedEnchantment:
                        this.desperatestand++;
                        continue;
                    case CardIds.NonCollectible.Druid.SouloftheForest_SoulOfTheForestEnchantment:
                        this.souloftheforest++;
                        continue;
                    case CardIds.NonCollectible.Paladin.SpikeridgedSteed_OnAStegodonEnchantment:
                        this.stegodon++;
                        continue;
                    case CardIds.NonCollectible.Neutral.LivingSporesToken2:
                        this.livingspores++;
                        continue;

                    case CardIds.NonCollectible.Druid.Infest_NerubianSpores:
                        this.infest++;
                        continue;
                    case CardIds.NonCollectible.Rogue.UnearthedRaptor_UnearthedRaptorEnchantment:
                        this.extraParam2 = me.copyDeathrattle;
                        continue; //unearthedraptor
                    // case SimCard.LOE_012e: this.deathrattle2 = ; continue; //zzdeletetombexplorer


                    //conceal-------------------------------------------------
                    case CardIds.NonCollectible.Rogue.Conceal_ConcealedEnchantment:
                        this.conceal = true;
                        continue;
                    case CardIds.NonCollectible.Rogue.MasterofDisguise_DisguisedEnchantment:
                        this.conceal = true;
                        continue;
                    case CardIds.NonCollectible.Neutral.FinickyCloakfield_CloakedEnchantment:
                        this.conceal = true;
                        continue;
                    case CardIds.NonCollectible.Neutral.XarilPoisonedMind_Fadeleaf:
                        this.conceal = true;
                        continue;

                    //cantLowerHPbelowONE-------------------------------------------------
                    case CardIds.NonCollectible.Warrior.CommandingShout_CommandingShoutEnchantment1:
                        this.cantLowerHPbelowONE = true;
                        continue; //commandingshout
                    case CardIds.NonCollectible.Warrior.CommandingShout_CommandingShoutEnchantment2:
                        this.cantLowerHPbelowONE = true;
                        continue; //commandingshout

                    //spellpower-------------------------------------------------
                    case CardIds.NonCollectible.Neutral.VelensChosen_VelensChosen:
                        this.spellpower++;
                        continue; //velenschosen
                    case CardIds.NonCollectible.Mage.DalaranAspirant_PowerOfDalaranEnchantment:
                        this.spellpower++;
                        continue; //dalaran
                    case CardIds.NonCollectible.Neutral.AncientMage_TeachingsOfTheKirinTorEnchantment:
                        this.spellpower++;
                        continue; //ancient mage

                    //charge-------------------------------------------------
                    case CardIds.NonCollectible.Warrior.AlexstraszasChampion_AlexstraszasBoonEnchantment:
                        this.charge++;
                        continue;
                    case CardIds.NonCollectible.Warrior.Charge_ChargeEnchantment:
                        this.charge++;
                        continue;
                    case CardIds.NonCollectible.Neutral.GiveTauntAndChargeTavernBrawl:
                        this.charge++;
                        continue;
                    case CardIds.NonCollectible.Hunter.TundraRhino_ChargeEnchantment:
                        this.charge++;
                        continue;

                    //adjacentbuffs-------------------------------------------------
                    case CardIds.NonCollectible.Shaman.FlametongueTotem_FlametongueEnchantment:
                        this.AdjacentAngr += 2;
                        continue; //flametongue
                    case CardIds.NonCollectible.Neutral.DireWolfAlpha_StrengthOfThePackEnchantment:
                        this.AdjacentAngr += 1;
                        continue; //dire wolf alpha

                    //tempbuffs-------------------------------------------------
                    case CardIds.NonCollectible.Rogue.SharpenedEnchantment:
                        this.tempAttack += 1;
                        continue;
                    case CardIds.NonCollectible.Hunter.BestialWrath_BestialWrathEnchantment:
                        this.tempAttack += 2;
                        this.immune = true;
                        continue;
                    case CardIds.NonCollectible.Hunter.Stablemaster_GroomedEnchantment:
                        this.immune = true;
                        continue;
                    case CardIds.NonCollectible.Druid.SavageCombatant_SavageEnchantment:
                        this.tempAttack += 2;
                        continue;
                    case CardIds.NonCollectible.Druid.JusticarTrueheart_DireClaws:
                        this.tempAttack += 2;
                        continue;
                    case CardIds.NonCollectible.Druid.Claw_ClawEnchantment:
                        this.tempAttack += 2;
                        continue;
                    case CardIds.NonCollectible.Druid.SavageRoar_SavageRoarEnchantment:
                        this.tempAttack += 2;
                        continue;
                    case CardIds.NonCollectible.Neutral.DarkIronDwarf_TemperedEnchantment:
                        this.tempAttack += 2;
                        continue;
                    case CardIds.NonCollectible.Neutral.SealofLight_SealOfLight:
                        this.tempAttack += 2;
                        continue;
                    case CardIds.NonCollectible.Shaman.Bloodlust_BloodlustEnchantment:
                        this.tempAttack += 3;
                        continue;
                    case CardIds.NonCollectible.Warrior.HeroicStrike_HeroicStrikeEnchantment:
                        this.tempAttack += 4;
                        continue;
                    case CardIds.NonCollectible.Neutral.Bite_BiteEnchantment:
                        this.tempAttack += 4;
                        continue;
                    case CardIds.NonCollectible.Druid.FeralRage_SpinesEnchantment:
                        this.tempAttack += 4;
                        continue;
                    case CardIds.NonCollectible.Neutral.Enrage_EnrageEnchantment:
                        this.tempAttack += 6;
                        continue;
                    case CardIds.NonCollectible.Neutral.Shrinkmeister_Shrunk:
                        this.tempAttack += -2;
                        continue;
                    case CardIds.NonCollectible.Priest.PintSizePotion_ShrunkEnchantment:
                        this.tempAttack += -3;
                        continue;
                    case CardIds.NonCollectible.Priest.SolemnVigil_MeltEnchantment:
                        this.tempAttack += -1000;
                        continue;
                    case CardIds.NonCollectible.Neutral.WillofMukla_MightOfMuklaEnchantment:
                        this.tempAttack += 8;
                        continue;
                    case CardIds.NonCollectible.Shaman.RockbiterWeapon_RockbiterWeaponEnchantment:
                        this.tempAttack += 3;
                        continue;
                    case CardIds.NonCollectible.Neutral.AbusiveSergeant_InspiredEnchantment:
                        this.tempAttack += 2;
                        continue;
                    case CardIds.NonCollectible.Druid.Shapeshift_ClawsEnchantment:
                        this.tempAttack += 1;
                        continue;
                }
            }
        }
    }
}