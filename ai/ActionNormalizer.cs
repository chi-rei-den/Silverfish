using System.Collections.Generic;
using System.Linq;
using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
    public class ActionNormalizer
    {
        PenalityManager penman = PenalityManager.Instance;
        Helpfunctions help = Helpfunctions.Instance;
        Settings settings = Settings.Instance;

        public struct targetNdamage
        {
            public int targetEntity;
            public int receivedDamage;

            public targetNdamage(int ent, int dmg)
            {
                this.targetEntity = ent;
                this.receivedDamage = dmg;
            }
        }


        public void adjustActions(Playfield p, bool isLethalCheck)
        {
            if (p.enemySecretCount > 0)
            {
                return;
            }

            if (p.playactions.Count < 2)
            {
                return;
            }

            var reorderedActions = new List<Action>();
            var rndActIdsDmg = new Dictionary<int, Dictionary<int, int>>();
            var tmpPlOld = new Playfield();

            if (isLethalCheck)
            {
                if (Ai.Instance.botBase.getPlayfieldValue(p) < 10000)
                {
                    return;
                }

                var tmpPf = new Playfield();
                if (tmpPf.anzEnemyTaunt > 0)
                {
                    return;
                }

                var actDmgDict = new Dictionary<Action, int>();
                tmpPf.enemyHero.Hp = 30;
                try
                {
                    var useability = 0;
                    foreach (var a in p.playactions)
                    {
                        if (a.actionType == actionEnum.useHeroPower)
                        {
                            useability = 1;
                        }

                        if (a.actionType == actionEnum.attackWithHero)
                        {
                            useability++;
                        }

                        var actDmd = tmpPf.enemyHero.Hp + tmpPf.enemyHero.armor;
                        tmpPf.doAction(a);
                        actDmd -= tmpPf.enemyHero.Hp + tmpPf.enemyHero.armor;
                        actDmgDict.Add(a, actDmd);
                    }

                    if (useability > 1)
                    {
                        return;
                    }
                }
                catch { return; }

                foreach (var pair in actDmgDict.OrderByDescending(pair => pair.Value))
                {
                    reorderedActions.Add(pair.Key);
                }

                tmpPf = new Playfield();
                foreach (var a in reorderedActions)
                {
                    if (!this.isActionPossible(tmpPf, a))
                    {
                        return;
                    }

                    try
                    {
                        tmpPf.doAction(a);
                    }
                    catch
                    {
                        this.printError(p.playactions, reorderedActions, a);
                        return;
                    }
                }

                if (Ai.Instance.botBase.getPlayfieldValue(tmpPf) < 10000)
                {
                    return;
                }
            }
            else
            {
                var damageRandom = false;
                var rndBeforeDamageAll = false;
                Action aa;
                for (var i = 0; i < p.playactions.Count; i++)
                {
                    aa = p.playactions[i];
                    switch (aa.actionType)
                    {
                        case actionEnum.playcard:
                            if (damageRandom && this.penman.DamageAllEnemysDatabase.ContainsKey(aa.card.card))
                            {
                                rndBeforeDamageAll = true;
                            }
                            else if (this.penman.DamageRandomDatabase.ContainsKey(aa.card.card))
                            {
                                damageRandom = true;
                            }

                            break;
                    }
                }

                var aoeEnNum = 0;
                var outOfPlace = 0;
                var totemiccall = false;
                var rndAct = new List<Action>();
                var rndActTmp = new List<Action>();
                for (var i = 0; i < p.playactions.Count; i++)
                {
                    damageRandom = false;
                    aa = p.playactions[i];
                    reorderedActions.Add(aa);
                    switch (aa.actionType)
                    {
                        case actionEnum.useHeroPower:
                            if (aa.card.card == CardIds.NonCollectible.Shaman.TotemicCall)
                            {
                                totemiccall = true;
                            }

                            break;
                        case actionEnum.playcard:
                            if (this.penman.DamageAllEnemysDatabase.ContainsKey(aa.card.card))
                            {
                                if (i != aoeEnNum)
                                {
                                    if (totemiccall && aa.card.card.Type == CardType.SPELL)
                                    {
                                        return;
                                    }

                                    reorderedActions.RemoveAt(i);
                                    reorderedActions.Insert(aoeEnNum, aa);
                                    outOfPlace++;
                                }

                                aoeEnNum++;
                            }
                            else if (rndBeforeDamageAll && aa.card.card.Type == CardType.SPELL && this.penman.DamageRandomDatabase.ContainsKey(aa.card.card))
                            {
                                damageRandom = true;
                                var tmp = new Playfield(tmpPlOld);
                                tmpPlOld.doAction(aa);

                                var actIdDmg = new Dictionary<int, int>();
                                if (tmp.enemyHero.Hp != tmpPlOld.enemyHero.Hp)
                                {
                                    actIdDmg.Add(tmpPlOld.enemyHero.entitiyID, tmp.enemyHero.Hp - tmpPlOld.enemyHero.Hp);
                                }

                                if (tmp.ownHero.Hp != tmpPlOld.ownHero.Hp)
                                {
                                    actIdDmg.Add(tmpPlOld.ownHero.entitiyID, tmp.ownHero.Hp - tmpPlOld.ownHero.Hp);
                                }

                                var found = false;
                                foreach (var m in tmp.enemyMinions)
                                {
                                    found = false;
                                    foreach (var nm in tmpPlOld.enemyMinions)
                                    {
                                        if (m.entitiyID == nm.entitiyID)
                                        {
                                            found = true;
                                            if (m.Hp != nm.Hp)
                                            {
                                                actIdDmg.Add(m.entitiyID, m.Hp - nm.Hp);
                                            }

                                            break;
                                        }
                                    }

                                    if (!found)
                                    {
                                        actIdDmg.Add(m.entitiyID, m.Hp);
                                    }
                                }

                                foreach (var m in tmp.ownMinions)
                                {
                                    found = false;
                                    foreach (var nm in tmpPlOld.ownMinions)
                                    {
                                        if (m.entitiyID == nm.entitiyID)
                                        {
                                            found = true;
                                            if (m.Hp != nm.Hp)
                                            {
                                                actIdDmg.Add(m.entitiyID, m.Hp - nm.Hp);
                                            }

                                            break;
                                        }
                                    }

                                    if (!found)
                                    {
                                        actIdDmg.Add(m.entitiyID, m.Hp);
                                    }
                                }

                                rndActIdsDmg.Add(aa.card.entity, actIdDmg);
                            }

                            break;
                    }

                    if (!damageRandom)
                    {
                        tmpPlOld.doAction(aa);
                    }
                }

                if (outOfPlace == 0)
                {
                    return;
                }

                var tmpPf = new Playfield();
                foreach (var a in reorderedActions)
                {
                    if (!this.isActionPossible(tmpPf, a))
                    {
                        return;
                    }

                    try
                    {
                        if (!(a.actionType == actionEnum.playcard && rndActIdsDmg.ContainsKey(a.card.entity)))
                        {
                            tmpPf.doAction(a);
                        }
                        else
                        {
                            tmpPf.playactions.Add(a);
                            var actIdDmg = rndActIdsDmg[a.card.entity];
                            if (actIdDmg.ContainsKey(tmpPf.enemyHero.entitiyID))
                            {
                                tmpPf.minionGetDamageOrHeal(tmpPf.enemyHero, actIdDmg[tmpPf.enemyHero.entitiyID]);
                            }

                            if (actIdDmg.ContainsKey(tmpPf.ownHero.entitiyID))
                            {
                                tmpPf.minionGetDamageOrHeal(tmpPf.ownHero, actIdDmg[tmpPf.ownHero.entitiyID]);
                            }

                            foreach (var m in tmpPf.enemyMinions)
                            {
                                if (actIdDmg.ContainsKey(m.entitiyID))
                                {
                                    tmpPf.minionGetDamageOrHeal(m, actIdDmg[m.entitiyID]);
                                }
                            }

                            foreach (var m in tmpPf.ownMinions)
                            {
                                if (actIdDmg.ContainsKey(m.entitiyID))
                                {
                                    tmpPf.minionGetDamageOrHeal(m, actIdDmg[m.entitiyID]);
                                }
                            }

                            tmpPf.doDmgTriggers();
                        }
                    }
                    catch
                    {
                        this.printError(p.playactions, reorderedActions, a);
                        return;
                    }
                }

                tmpPf.lostDamage = tmpPlOld.lostDamage;
                var newval = Ai.Instance.botBase.getPlayfieldValue(tmpPf);
                var oldval = Ai.Instance.botBase.getPlayfieldValue(tmpPlOld);

                if (oldval > newval)
                {
                    return;
                }
            }

            this.help.logg("Old order of actions:");
            foreach (var a in p.playactions)
            {
                a.print();
            }

            p.playactions.Clear();
            p.playactions.AddRange(reorderedActions);

            this.help.logg("New order of actions:");
        }

        private bool isActionPossible(Playfield p, Action a)
        {
            var actionFound = false;
            switch (a.actionType)
            {
                case actionEnum.playcard:
                    foreach (var hc in p.owncards)
                    {
                        if (hc.entity == a.card.entity)
                        {
                            if (p.mana >= hc.card.getManaCost(p, hc.manacost))
                            {
                                if (p.ownMinions.Count > 6)
                                {
                                    if (hc.card.Type == CardType.MINION)
                                    {
                                        return false;
                                    }
                                }

                                actionFound = true;
                            }

                            break;
                        }
                    }

                    break;
                case actionEnum.attackWithMinion:
                    foreach (var m in p.ownMinions)
                    {
                        if (m.entitiyID == a.own.entitiyID)
                        {
                            if (!m.Ready)
                            {
                                return false;
                            }

                            actionFound = true;
                            break;
                        }
                    }

                    break;
                case actionEnum.attackWithHero:
                    if (p.ownHero.Ready)
                    {
                        actionFound = true;
                    }

                    break;
                case actionEnum.useHeroPower:
                    if (p.ownAbilityReady && p.mana >= p.ownHeroAblility.card.getManaCost(p, p.ownHeroAblility.manacost))
                    {
                        actionFound = true;
                    }

                    break;
            }

            if (!actionFound)
            {
                return false;
            }

            if (a.target != null)
            {
                actionFound = false;
                if (p.enemyHero.entitiyID == a.target.entitiyID)
                {
                    actionFound = true;
                }
                else if (p.ownHero.entitiyID == a.target.entitiyID)
                {
                    actionFound = true;
                }
                else
                {
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.entitiyID == a.target.entitiyID)
                        {
                            actionFound = true;
                            break;
                        }
                    }

                    if (!actionFound)
                    {
                        foreach (var m in p.ownMinions)
                        {
                            if (m.entitiyID == a.target.entitiyID)
                            {
                                actionFound = true;
                                break;
                            }
                        }
                    }
                }
            }

            return actionFound;
        }

        private void printError(List<Action> mainActList, List<Action> newActList, Action aError)
        {
            this.help.ErrorLog("Reordering actions error!");
            this.help.logg("Reordering actions error!\r\nError in action:");
            aError.print();
            this.help.logg("Main order of actions:");
            foreach (var a in mainActList)
            {
                a.print();
            }

            this.help.logg("New order of actions:");
            foreach (var a in newActList)
            {
                a.print();
            }
        }

        public void checkLostActions(Playfield p)
        {
            var tmpPf = new Playfield();
            foreach (var a in p.playactions)
            {
                if (a.target != null && a.own != null)
                {
                    a.own.own = !a.target.own;
                }

                tmpPf.doAction(a);
            }

            var mainTurnSimulator = new MiniSimulator(6, 3000, 0);
            mainTurnSimulator.setSecondTurnSimu(this.settings.simulateEnemysTurn, this.settings.secondTurnAmount);
            mainTurnSimulator.setPlayAround(this.settings.playaround, this.settings.playaroundprob, this.settings.playaroundprob2);

            tmpPf.checkLostAct = true;
            tmpPf.isLethalCheck = p.isLethalCheck;

            var bestval = mainTurnSimulator.doallmoves(tmpPf);
            if (bestval > p.value)
            {
                p.playactions.Clear();
                p.playactions.AddRange(mainTurnSimulator.bestboard.playactions);
                p.value = bestval;
            }
        }
    }
}