using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
    //!!!	Under test
    //v0.1.2
    /*
     SUMMARY
     1) Comparison operators (=, !=, >, <) !ONLY NUMERIC VALUE!
     (= - equal, != - not equal, > - greater than, < - less than)

     tm - turn mana (default mana at this turn);
     am - available mana (at this turn);
     t - turn;
     overload - overload, which can cause a card in the current round;
     owncarddraw - extra carddraw this turn
     ohhp - own hero health points;
     ehhp - enemy hero health points;
     owa - own weapon attack;
     ewa - enemy weapon attack;
     owd - own weapon durability;
     ewd - enemy weapon durability;
     ohc - own hand cards count (the number of cards in own hand);
     ehc - enemy hand cards count (the number of cards in enemy's hand);
     omc - own minions count (the number of own minions on the board);
     emc - enemy minions count (the number of enemy minions on the board);
     For "ohc", "omc" and "emc" you can use these extensions:
        :Murlocs (the number of own/enemy Murlocs on the board/in own hand)
        :Demons (the number of own/enemy Demons on the board/in own hand)
        :Mechs (the number of own/enemy Mechs on the board/in own hand)
        :Beasts (the number of own/enemy Beasts on the board/in own hand)
        :Totems (the number of own/enemy Totems on the board/in own hand)
        :Pirates (the number of own/enemy Pirates on the board/in own hand)
        :Dragons (the number of own/enemy Dragons on the board/in own hand)
        :Elems (the number of own/enemy Elementals on the board/in own hand)
        :shields (the number of own/enemy shields on the board/in own hand)
        :taunts (the number of own/enemy taunts on the board/in own hand)
     For "ohc" only:
        :Minions (the number of Minions in own hand)
        :Spells (the number of Spells in own hand)
        :Secrets (the number of Secrets in own hand)
        :Weapons (the number of Weapons in own hand)
     For "omc" and "emc" only:
        :SHR (the number of own/enemy Silver Hand Recruits on the board)
        :undamaged (the number of undamaged own/enemy minions on the board)
        :damaged (the number of damaged own/enemy minions on the board)
    Also you can compare "ohc" with "ehc" and "omc" with "emc"
     Example:   omc>3 - means that you must have more than 3 minions on the board
                omc:Murlocs>3 - means that you must have more than 3 murlocs on the board
                omc>emc - means that you must have more minions than your opponent

     2) Boolean operators (=, !=)
     (= - equal/contain; != - not equal/does't contain)

     ob - own board (own board must/must not contain this minion (CardID));
     eb - enemy board (enemy board must/must not contain this minion (CardID));
     oh - own hand (own hand must/must not contain this card (CardID));
     ow - own weapon (CardID);
     ew - enemy weapon (CardID);
     ohero - own hero class (ALL, DRUID, HUNTER, MAGE, PALADIN, PRIEST, ROGUE, SHAMAN, WARLOCK, WARRIOR);
     ehero - enemy hero class;

     3) Unique:
     coin - must be a coin in hand at turn start;
     !coin - must not be a coin in hand at turn start;
     noduplicates - if your deck contain no duplicates
     p= - play - card in hand that must be played (CardID);
     p2= - play 2 identical cards - 2 identical card in hand that must be played (CardID);
     a= - attacker - minion on board (CardID);
     For "p=" and "p2=" and "a=" you can use these extensions:
        :pen= (after CardID) - penalty for playing/attacking this card outside of this rule;
        :tgt= - target - target for spell or for minion/weapon (CardID/hero/!hero);
        You can use comparison operators ( =, !=, >, < !ONLY NUMERIC VALUE!) for these parameters:
        :aAt - attacker's attack (mob/hero)
        :aHp - attacker's health points
        :tAt - target's attack
        :tHp - target's health points

     4) Condition binding:
     & - And (condition1&condition2 - true only if the condition 1 AND condition 2 are true);
     || - Or (condition1||condition2 - true if the condition 1 is true OR condition 2 is true);
     Example: cond_1 & cond_2||cond_3||cond_4 & cond_5 - true if condition_1 = true And (condition 2 or 3 or 4) = true And condition_5 = true;

     5) Extra info (written with a comma)
     bonus=X - if all conditions are TRUE then this Playfield gets this bonus;

     */

    public class RulesEngine
    {
        Dictionary<int, Rule> heapOfRules = new Dictionary<int, Rule>();
        Dictionary<int, List<SimCard>> RuleCardIdsPlay = new Dictionary<int, List<SimCard>>();
        Dictionary<int, List<SimCard>> RuleCardIdsAttack = new Dictionary<int, List<SimCard>>();
        Dictionary<int, List<SimCard>> RuleCardIdsHand = new Dictionary<int, List<SimCard>>();
        Dictionary<int, List<SimCard>> RuleCardIdsOwnBoard = new Dictionary<int, List<SimCard>>();
        Dictionary<int, List<SimCard>> RuleCardIdsEnemyBoard = new Dictionary<int, List<SimCard>>();
        Dictionary<int, int> BoardStateRules = new Dictionary<int, int>();
        Dictionary<int, int> BoardStateRulesGame = new Dictionary<int, int>();
        Dictionary<int, int> BoardStateRulesTurn = new Dictionary<int, int>();
        Dictionary<SimCard, List<int>> CardIdRules = new Dictionary<SimCard, List<int>>();
        Dictionary<SimCard, Dictionary<int, int>> CardIdRulesGame = new Dictionary<SimCard, Dictionary<int, int>>();
        Dictionary<SimCard, Dictionary<int, int>> CardIdRulesPlayGame = new Dictionary<SimCard, Dictionary<int, int>>();
        Dictionary<SimCard, Dictionary<int, int>> CardIdRulesHandGame = new Dictionary<SimCard, Dictionary<int, int>>();
        Dictionary<SimCard, Dictionary<int, int>> CardIdRulesOwnBoardGame = new Dictionary<SimCard, Dictionary<int, int>>();
        Dictionary<SimCard, Dictionary<int, int>> CardIdRulesEnemyBoardGame = new Dictionary<SimCard, Dictionary<int, int>>();
        Dictionary<SimCard, Dictionary<int, int>> AttackerIdRulesGame = new Dictionary<SimCard, Dictionary<int, int>>();
        Dictionary<SimCard, List<int>> CardIdRulesTurnPlay = new Dictionary<SimCard, List<int>>();
        Dictionary<SimCard, List<int>> CardIdRulesTurnHand = new Dictionary<SimCard, List<int>>();
        Dictionary<Race, List<int>> hcRaceRulesGame = new Dictionary<Race, List<int>>();
        Dictionary<Race, List<int>> hcRaceRulesTurn = new Dictionary<Race, List<int>>();
        List<int> pfStateRulesGame = new List<int>();
        Dictionary<CardClass, Dictionary<int, int>> RuleOwnClass = new Dictionary<CardClass, Dictionary<int, int>>();
        Dictionary<CardClass, Dictionary<int, int>> RuleEnemyClass = new Dictionary<CardClass, Dictionary<int, int>>();
        Dictionary<int, int> replacedRules = new Dictionary<int, int>();
        string pathToRules = "";

        public bool mulliganRulesLoaded;
        Dictionary<string, string> MulliganRules = new Dictionary<string, string>();
        Dictionary<string, Dictionary<string, string>> MulliganRulesDB = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<SimCard, string> MulliganRulesManual = new Dictionary<SimCard, string>();
        Condition condTmp;
        string condErr;
        Minion target;
        int tmp_counter;
        int printRules = Settings.Instance.printRules;

        Hrtprozis prozis = Hrtprozis.Instance;


        public enum param
        {
            None,
            orcond,
            tm_equal,
            tm_notequal,
            tm_greater,
            tm_less,
            am_equal,
            am_notequal,
            am_greater,
            am_less,
            owa_equal,
            owa_notequal,
            owa_greater,
            owa_less,
            ewa_equal,
            ewa_notequal,
            ewa_greater,
            ewa_less,
            owd_equal,
            owd_notequal,
            owd_greater,
            owd_less,
            ewd_equal,
            ewd_notequal,
            ewd_greater,
            ewd_less,
            omc_equal,
            omc_notequal,
            omc_greater,
            omc_less,
            emc_equal,
            emc_notequal,
            emc_greater,
            emc_less,
            omc_equal_emc,
            omc_notequal_emc,
            omc_greater_emc,
            omc_less_emc,
            omc_murlocs_equal,
            omc_murlocs_notequal,
            omc_murlocs_greater,
            omc_murlocs_less,
            emc_murlocs_equal,
            emc_murlocs_notequal,
            emc_murlocs_greater,
            emc_murlocs_less,
            omc_demons_equal,
            omc_demons_notequal,
            omc_demons_greater,
            omc_demons_less,
            emc_demons_equal,
            emc_demons_notequal,
            emc_demons_greater,
            emc_demons_less,
            omc_mechs_equal,
            omc_mechs_notequal,
            omc_mechs_greater,
            omc_mechs_less,
            emc_mechs_equal,
            emc_mechs_notequal,
            emc_mechs_greater,
            emc_mechs_less,
            omc_beasts_equal,
            omc_beasts_notequal,
            omc_beasts_greater,
            omc_beasts_less,
            emc_beasts_equal,
            emc_beasts_notequal,
            emc_beasts_greater,
            emc_beasts_less,
            omc_totems_equal,
            omc_totems_notequal,
            omc_totems_greater,
            omc_totems_less,
            emc_totems_equal,
            emc_totems_notequal,
            emc_totems_greater,
            emc_totems_less,
            omc_pirates_equal,
            omc_pirates_notequal,
            omc_pirates_greater,
            omc_pirates_less,
            emc_pirates_equal,
            emc_pirates_notequal,
            emc_pirates_greater,
            emc_pirates_less,
            omc_Dragons_equal,
            omc_Dragons_notequal,
            omc_Dragons_greater,
            omc_Dragons_less,
            emc_Dragons_equal,
            emc_Dragons_notequal,
            emc_Dragons_greater,
            emc_Dragons_less,
            omc_elems_equal,
            omc_elems_notequal,
            omc_elems_greater,
            omc_elems_less,
            emc_elems_equal,
            emc_elems_notequal,
            emc_elems_greater,
            emc_elems_less,
            omc_shr_equal,
            omc_shr_notequal,
            omc_shr_greater,
            omc_shr_less,
            emc_shr_equal,
            emc_shr_notequal,
            emc_shr_greater,
            emc_shr_less,
            omc_undamaged_equal,
            omc_undamaged_notequal,
            omc_undamaged_greater,
            omc_undamaged_less,
            emc_undamaged_equal,
            emc_undamaged_notequal,
            emc_undamaged_greater,
            emc_undamaged_less,
            omc_damaged_equal,
            omc_damaged_notequal,
            omc_damaged_greater,
            omc_damaged_less,
            emc_damaged_equal,
            emc_damaged_notequal,
            emc_damaged_greater,
            emc_damaged_less,
            omc_shields_equal,
            omc_shields_notequal,
            omc_shields_greater,
            omc_shields_less,
            emc_shields_equal,
            emc_shields_notequal,
            emc_shields_greater,
            emc_shields_less,
            omc_taunts_equal,
            omc_taunts_notequal,
            omc_taunts_greater,
            omc_taunts_less,
            emc_taunts_equal,
            emc_taunts_notequal,
            emc_taunts_greater,
            emc_taunts_less,
            aAt_equal,
            aAt_notequal,
            aAt_greater,
            aAt_less,
            aHp_equal,
            aHp_notequal,
            aHp_greater,
            aHp_less,
            tAt_equal,
            tAt_notequal,
            tAt_greater,
            tAt_less,
            tHp_equal,
            tHp_notequal,
            tHp_greater,
            tHp_less,
            ohc_equal,
            ohc_notequal,
            ohc_greater,
            ohc_less,
            ehc_equal,
            ehc_notequal,
            ehc_greater,
            ehc_less,
            ohc_equal_ehc,
            ohc_notequal_ehc,
            ohc_greater_ehc,
            ohc_less_ehc,
            ohc_minions_equal,
            ohc_minions_notequal,
            ohc_minions_greater,
            ohc_minions_less,
            ohc_spells_equal,
            ohc_spells_notequal,
            ohc_spells_greater,
            ohc_spells_less,
            ohc_secrets_equal,
            ohc_secrets_notequal,
            ohc_secrets_greater,
            ohc_secrets_less,
            ohc_weapons_equal,
            ohc_weapons_notequal,
            ohc_weapons_greater,
            ohc_weapons_less,
            ohc_murlocs_equal,
            ohc_murlocs_notequal,
            ohc_murlocs_greater,
            ohc_murlocs_less,
            ohc_demons_equal,
            ohc_demons_notequal,
            ohc_demons_greater,
            ohc_demons_less,
            ohc_mechs_equal,
            ohc_mechs_notequal,
            ohc_mechs_greater,
            ohc_mechs_less,
            ohc_beasts_equal,
            ohc_beasts_notequal,
            ohc_beasts_greater,
            ohc_beasts_less,
            ohc_totems_equal,
            ohc_totems_notequal,
            ohc_totems_greater,
            ohc_totems_less,
            ohc_pirates_equal,
            ohc_pirates_notequal,
            ohc_pirates_greater,
            ohc_pirates_less,
            ohc_Dragons_equal,
            ohc_Dragons_notequal,
            ohc_Dragons_greater,
            ohc_Dragons_less,
            ohc_elems_equal,
            ohc_elems_notequal,
            ohc_elems_greater,
            ohc_elems_less,
            ohc_shields_equal,
            ohc_shields_notequal,
            ohc_shields_greater,
            ohc_shields_less,
            ohc_taunts_equal,
            ohc_taunts_notequal,
            ohc_taunts_greater,
            ohc_taunts_less,
            turn_equal,
            turn_notequal,
            turn_greater,
            turn_less,
            overload_equal,
            overload_notequal,
            overload_greater,
            overload_less,
            owncarddraw_equal,
            owncarddraw_notequal,
            owncarddraw_greater,
            owncarddraw_less,
            ohhp_equal,
            ohhp_notequal,
            ohhp_greater,
            ohhp_less,
            ehhp_equal,
            ehhp_notequal,
            ehhp_greater,
            ehhp_less,
            ownboard_contain,
            ownboard_notcontain,
            enboard_contain,
            enboard_notcontain,
            ownhand_contain,
            ownhand_notcontain,
            ownweapon_equal,
            ownweapon_notequal,
            enweapon_equal,
            enweapon_notequal,
            ownhero_equal,
            ownhero_notequal,
            enhero_equal,
            enhero_notequal,
            tgt_equal,
            tgt_notequal,
            noduplicates,
            play,
            play2,
            attacker,
            ur,
            rn,
            rr,
            bonus
        }

        public class Condition
        {
            public param parameter = param.None;
            public int num = int.MinValue;
            public CardClass hClass = CardClass.INVALID;
            public SimCard cardID = SimCard.None;
            public int numCards = 0;
            public int bonus;
            public int orCondNum = -1;
            public List<Condition> orConditions = new List<Condition>();
            public List<Condition> extraConditions = new List<Condition>();
            public string parentRule = "";

            public Condition(param paramtr, int pnum, string pRule)
            {
                this.parameter = paramtr;
                this.num = pnum;
                this.parentRule = pRule;
            }

            public Condition(param paramtr, SimCard cID, string pRule)
            {
                this.parameter = paramtr;
                this.cardID = cID;
                this.parentRule = pRule;
            }

            public Condition(param paramtr, CardClass hClas, string pRule)
            {
                this.parameter = paramtr;
                this.hClass = hClas;
                this.parentRule = pRule;
            }
        }

        public class Rule
        {
            public bool ultimateRule;
            public int ruleNumber;
            public int replacedRule;
            public int bonus;
            public List<Condition> conditions = new List<Condition>();
        }

        public class actUnit
        {
            public SimCard cardID = SimCard.None;
            public Action action;
            public int entity = -1;

            public actUnit(SimCard cid, Action a, int ent)
            {
                this.cardID = cid;
                this.action = a;
                this.entity = ent;
            }
        }

        private static RulesEngine instance;

        public static RulesEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RulesEngine();
                }

                return instance;
            }
        }

        private RulesEngine()
        {
        }


        public int getRuleWeight(Playfield p)
        {
            var weight = 0;
            var possibleRules = new List<int>();
            possibleRules.AddRange(this.BoardStateRulesTurn.Keys);
            var handCardsWRule = new Dictionary<SimCard, int>();
            var playedCardsWRule = new Dictionary<SimCard, List<actUnit>>();
            var playedCardsWRulePen = new Dictionary<SimCard, int>();
            var attackersWRule = new Dictionary<SimCard, List<actUnit>>();
            var attackersWRulePen = new Dictionary<SimCard, int>();
            foreach (var a in p.playactions)
            {
                SimCard cardID = SimCard.None;
                switch (a.actionType)
                {
                    case actionEnum.playcard:
                        cardID = a.card.card.CardId;
                        if (this.CardIdRulesGame.ContainsKey(cardID))
                        {
                            possibleRules.AddRange(this.CardIdRulesGame[cardID].Keys);
                            if (playedCardsWRule.ContainsKey(cardID))
                            {
                                playedCardsWRule[cardID].Add(new actUnit(cardID, a, a.card.entity));
                            }
                            else
                            {
                                playedCardsWRule.Add(cardID, new List<actUnit> {new actUnit(cardID, a, a.card.entity)});
                                playedCardsWRulePen.Add(cardID, 0);
                            }
                        }

                        break;
                    case actionEnum.attackWithMinion:
                        cardID = a.own.handcard.card.CardId;
                        if (this.AttackerIdRulesGame.ContainsKey(cardID))
                        {
                            possibleRules.AddRange(this.AttackerIdRulesGame[cardID].Keys);
                            if (attackersWRule.ContainsKey(cardID))
                            {
                                attackersWRule[cardID].Add(new actUnit(cardID, a, a.own.entitiyID));
                            }
                            else
                            {
                                attackersWRule.Add(cardID, new List<actUnit> {new actUnit(cardID, a, a.own.entitiyID)});
                                attackersWRulePen.Add(cardID, 0);
                            }
                        }

                        break;
                    case actionEnum.attackWithHero: break;
                    case actionEnum.useHeroPower: break;
                }
            }

            if (possibleRules.Count > 0)
            {
                p.rulesUsed = "";
                possibleRules = possibleRules.Distinct().ToList();
                var count = possibleRules.Count;
                for (var i = 0; i < count; i++)
                {
                    var ruleNum = possibleRules[i];
                    var ruleBroken = false;
                    var tmpPen = new List<Tuple<Condition, List<actUnit>>>();
                    foreach (var cond in this.heapOfRules[ruleNum].conditions)
                    {
                        if (cond.orCondNum < 0)
                        {
                            switch (cond.parameter)
                            {
                                case param.play:
                                    if (playedCardsWRule.ContainsKey(cond.cardID))
                                    {
                                        tmpPen.Add(new Tuple<Condition, List<actUnit>>(cond, playedCardsWRule[cond.cardID]));
                                        continue;
                                    }

                                    ruleBroken = true;
                                    continue;
                                case param.play2:
                                    if (playedCardsWRule.ContainsKey(cond.cardID))
                                    {
                                        tmpPen.Add(new Tuple<Condition, List<actUnit>>(cond, playedCardsWRule[cond.cardID]));
                                        if (playedCardsWRule[cond.cardID].Count >= 2)
                                        {
                                            continue;
                                        }
                                    }

                                    ruleBroken = true;
                                    continue;
                                case param.attacker:
                                    if (attackersWRule.ContainsKey(cond.cardID))
                                    {
                                        tmpPen.Add(new Tuple<Condition, List<actUnit>>(cond, attackersWRule[cond.cardID]));
                                        continue;
                                    }

                                    ruleBroken = true;
                                    continue;
                                default:
                                    if (!ruleBroken && this.checkCondition(cond, p))
                                    {
                                        continue;
                                    }

                                    ruleBroken = true;
                                    continue;
                            }
                        }

                        var orCondBroken = true;
                        foreach (var orCond in cond.orConditions)
                        {
                            switch (orCond.parameter)
                            {
                                case param.play:
                                    if (playedCardsWRule.ContainsKey(orCond.cardID))
                                    {
                                        tmpPen.Add(new Tuple<Condition, List<actUnit>>(orCond, playedCardsWRule[orCond.cardID]));
                                        orCondBroken = false;
                                    }

                                    break;
                                case param.play2:
                                    if (playedCardsWRule.ContainsKey(orCond.cardID))
                                    {
                                        tmpPen.Add(new Tuple<Condition, List<actUnit>>(orCond, playedCardsWRule[orCond.cardID]));
                                        if (playedCardsWRule[orCond.cardID].Count >= 2)
                                        {
                                            orCondBroken = false;
                                        }
                                    }

                                    break;
                                case param.attacker:
                                    if (attackersWRule.ContainsKey(cond.cardID))
                                    {
                                        tmpPen.Add(new Tuple<Condition, List<actUnit>>(cond, attackersWRule[cond.cardID]));
                                        continue;
                                    }

                                    ruleBroken = true;
                                    continue;
                                default:
                                    if (this.checkCondition(orCond, p))
                                    {
                                        orCondBroken = false;
                                    }

                                    break;
                            }

                            if (!orCondBroken)
                            {
                                break;
                            }
                        }

                        if (orCondBroken)
                        {
                            ruleBroken = true;
                        }
                    }

                    if (ruleBroken)
                    {
                        foreach (var condPen in tmpPen)
                        {
                            weight += condPen.Item1.bonus;
                            if (this.printRules > 0)
                            {
                                p.rulesUsed +=
                                    $"{-condPen.Item1.bonus} broken rule:{condPen.Item1.parentRule}@";
                            }
                        }
                    }
                    else
                    {
                        var tmpPenBonus = 0;
                        foreach (var condPen in tmpPen)
                        {
                            foreach (var au in condPen.Item2)
                            {
                                var actRuleBroken = false;
                                if (condPen.Item1.extraConditions.Count > 0)
                                {
                                    foreach (var extraCond in condPen.Item1.extraConditions)
                                    {
                                        if (this.checkCondition(extraCond, p, au.action))
                                        {
                                            continue;
                                        }

                                        actRuleBroken = true;
                                        tmpPenBonus -= condPen.Item1.bonus;
                                        if (this.printRules > 0)
                                        {
                                            p.rulesUsed +=
                                                $"{-condPen.Item1.bonus} broken extra condition:{condPen.Item1.parentRule}@";
                                        }

                                        break;
                                    }
                                }

                                if (!actRuleBroken)
                                {
                                    tmpPenBonus += this.heapOfRules[ruleNum].bonus;
                                    if (this.printRules > 0)
                                    {
                                        p.rulesUsed +=
                                            $"{this.heapOfRules[ruleNum].bonus} {condPen.Item1.parentRule}@";
                                    }
                                }
                            }
                        }

                        if (tmpPen.Count > 0)
                        {
                            weight -= tmpPenBonus;
                        }
                        else
                        {
                            weight -= this.heapOfRules[ruleNum].bonus;
                            if (this.printRules > 0)
                            {
                                var ruleStr = "no conditions";
                                if (this.heapOfRules[ruleNum].conditions.Count > 0)
                                {
                                    ruleStr = this.heapOfRules[ruleNum].conditions[0].parentRule;
                                }

                                p.rulesUsed += $"{this.heapOfRules[ruleNum].bonus}{ruleStr}@";
                            }
                        }
                    }
                }
            }

            p.ruleWeight = weight;
            return weight;
        }

        public void setCardIdRulesGame(CardClass ohc, CardClass ehc)
        {
            this.CardIdRulesGame.Clear();
            this.CardIdRulesPlayGame.Clear();
            this.CardIdRulesHandGame.Clear();
            this.CardIdRulesOwnBoardGame.Clear();
            this.CardIdRulesEnemyBoardGame.Clear();
            this.AttackerIdRulesGame.Clear();
            var sdf = this.heapOfRules;
            if (this.RuleOwnClass.ContainsKey(ohc) && this.RuleEnemyClass.ContainsKey(ehc))
            {
                foreach (var ruleNum in this.RuleOwnClass[ohc].Keys)
                {
                    if (this.RuleEnemyClass[ehc].ContainsKey(ruleNum))
                    {
                        if (this.RuleCardIdsPlay.ContainsKey(ruleNum))
                        {
                            this.addCardIdRulesGame(this.RuleCardIdsPlay, this.CardIdRulesPlayGame, ruleNum);
                        }

                        if (this.RuleCardIdsAttack.ContainsKey(ruleNum))
                        {
                            this.addAttackerIdRulesGame(ruleNum);
                        }

                        if (this.BoardStateRules.ContainsKey(ruleNum) && !this.BoardStateRulesGame.ContainsKey(ruleNum))
                        {
                            this.BoardStateRulesGame.Add(ruleNum, 0);
                        }
                    }
                }
            }

            if (this.RuleOwnClass.ContainsKey(ohc) && this.RuleEnemyClass.ContainsKey(CardClass.INVALID))
            {
                foreach (var ruleNum in this.RuleOwnClass[ohc].Keys)
                {
                    if (this.RuleEnemyClass[CardClass.INVALID].ContainsKey(ruleNum))
                    {
                        if (this.RuleCardIdsPlay.ContainsKey(ruleNum))
                        {
                            this.addCardIdRulesGame(this.RuleCardIdsPlay, this.CardIdRulesPlayGame, ruleNum);
                        }

                        if (this.RuleCardIdsAttack.ContainsKey(ruleNum))
                        {
                            this.addAttackerIdRulesGame(ruleNum);
                        }

                        if (this.BoardStateRules.ContainsKey(ruleNum) && !this.BoardStateRulesGame.ContainsKey(ruleNum))
                        {
                            this.BoardStateRulesGame.Add(ruleNum, 0);
                        }
                    }
                }
            }

            if (this.RuleOwnClass.ContainsKey(CardClass.INVALID) && this.RuleEnemyClass.ContainsKey(ehc))
            {
                foreach (var ruleNum in this.RuleEnemyClass[ehc].Keys)
                {
                    if (this.RuleOwnClass[CardClass.INVALID].ContainsKey(ruleNum))
                    {
                        if (this.RuleCardIdsPlay.ContainsKey(ruleNum))
                        {
                            this.addCardIdRulesGame(this.RuleCardIdsPlay, this.CardIdRulesPlayGame, ruleNum);
                        }

                        if (this.RuleCardIdsAttack.ContainsKey(ruleNum))
                        {
                            this.addAttackerIdRulesGame(ruleNum);
                        }

                        if (this.BoardStateRules.ContainsKey(ruleNum) && !this.BoardStateRulesGame.ContainsKey(ruleNum))
                        {
                            this.BoardStateRulesGame.Add(ruleNum, 0);
                        }
                    }
                }
            }

            if (this.RuleOwnClass.ContainsKey(CardClass.INVALID) && this.RuleEnemyClass.ContainsKey(CardClass.INVALID))
            {
                foreach (var ruleNum in this.RuleOwnClass[CardClass.INVALID].Keys)
                {
                    if (this.RuleEnemyClass[CardClass.INVALID].ContainsKey(ruleNum))
                    {
                        if (this.RuleCardIdsPlay.ContainsKey(ruleNum))
                        {
                            this.addCardIdRulesGame(this.RuleCardIdsPlay, this.CardIdRulesPlayGame, ruleNum);
                        }

                        if (this.RuleCardIdsAttack.ContainsKey(ruleNum))
                        {
                            this.addAttackerIdRulesGame(ruleNum);
                        }

                        if (this.BoardStateRules.ContainsKey(ruleNum) && !this.BoardStateRulesGame.ContainsKey(ruleNum))
                        {
                            this.BoardStateRulesGame.Add(ruleNum, 0);
                        }
                    }
                }
            }
        }

        private void addCardIdRulesGame(Dictionary<int, List<SimCard>> baseDct, Dictionary<SimCard, Dictionary<int, int>> targetDct, int ruleNum)
        {
            foreach (var cid in baseDct[ruleNum])
            {
                if (targetDct.ContainsKey(cid))
                {
                    if (this.replacedRules.ContainsKey(ruleNum))
                    {
                        var oldRules = targetDct[cid];
                        if (oldRules.ContainsKey(this.replacedRules[ruleNum]))
                        {
                            oldRules.Remove(this.replacedRules[ruleNum]);
                        }
                    }

                    if (!targetDct[cid].ContainsKey(ruleNum))
                    {
                        targetDct[cid].Add(ruleNum, 0);
                    }
                }
                else
                {
                    targetDct.Add(cid, new Dictionary<int, int> {{ruleNum, 0}});
                }
            }

            foreach (var cid in baseDct[ruleNum])
            {
                if (this.CardIdRulesGame.ContainsKey(cid))
                {
                    if (this.replacedRules.ContainsKey(ruleNum))
                    {
                        var oldRules = this.CardIdRulesGame[cid];
                        if (oldRules.ContainsKey(this.replacedRules[ruleNum]))
                        {
                            oldRules.Remove(this.replacedRules[ruleNum]);
                        }
                    }

                    if (!this.CardIdRulesGame[cid].ContainsKey(ruleNum))
                    {
                        this.CardIdRulesGame[cid].Add(ruleNum, 0);
                    }
                }
                else
                {
                    this.CardIdRulesGame.Add(cid, new Dictionary<int, int> {{ruleNum, 0}});
                }
            }
        }

        private void addAttackerIdRulesGame(int ruleNum)
        {
            foreach (var cid in this.RuleCardIdsAttack[ruleNum])
            {
                if (this.AttackerIdRulesGame.ContainsKey(cid))
                {
                    if (this.replacedRules.ContainsKey(ruleNum))
                    {
                        var oldRules = this.AttackerIdRulesGame[cid];
                        if (oldRules.ContainsKey(this.replacedRules[ruleNum]))
                        {
                            oldRules.Remove(this.replacedRules[ruleNum]);
                        }
                    }

                    if (!this.AttackerIdRulesGame[cid].ContainsKey(ruleNum))
                    {
                        this.AttackerIdRulesGame[cid].Add(ruleNum, 0);
                    }
                }
                else
                {
                    this.AttackerIdRulesGame.Add(cid, new Dictionary<int, int> {{ruleNum, 0}});
                }
            }
        }

        public void setRulesTurn(int gTurn)
        {
            this.BoardStateRulesTurn.Clear();
            foreach (var rNum in this.BoardStateRulesGame.Keys)
            {
                var gonext = false;
                var noturnrule = true;
                foreach (var cond in this.heapOfRules[rNum].conditions)
                {
                    if (gonext)
                    {
                        break;
                    }

                    if (cond.orCondNum < 0)
                    {
                        switch (cond.parameter)
                        {
                            case param.turn_equal:
                                noturnrule = false;
                                if (gTurn == cond.num)
                                {
                                    this.BoardStateRulesTurn.Add(rNum, 0);
                                    gonext = true;
                                }

                                continue;
                            case param.turn_notequal:
                                noturnrule = false;
                                if (gTurn == cond.num)
                                {
                                    if (this.BoardStateRulesTurn.ContainsKey(gTurn))
                                    {
                                        this.BoardStateRulesTurn.Remove(gTurn);
                                    }

                                    gonext = true;
                                }

                                continue;
                            case param.turn_greater:
                                noturnrule = false;
                                if (gTurn > cond.num)
                                {
                                    this.BoardStateRulesTurn.Add(rNum, 0);
                                }

                                continue;
                            case param.turn_less:
                                noturnrule = false;
                                if (gTurn < cond.num)
                                {
                                    this.BoardStateRulesTurn.Add(rNum, 0);
                                }

                                continue;
                        }
                    }
                    else
                    {
                        foreach (var orCond in cond.orConditions)
                        {
                            switch (cond.parameter)
                            {
                                case param.turn_equal:
                                    noturnrule = false;
                                    if (gTurn == cond.num)
                                    {
                                        this.BoardStateRulesTurn.Add(rNum, 0);
                                        gonext = true;
                                    }

                                    continue;
                                case param.turn_notequal:
                                    noturnrule = false;
                                    if (gTurn == cond.num)
                                    {
                                        if (this.BoardStateRulesTurn.ContainsKey(gTurn))
                                        {
                                            this.BoardStateRulesTurn.Remove(gTurn);
                                        }

                                        gonext = true;
                                    }

                                    continue;
                                case param.turn_greater:
                                    noturnrule = false;
                                    if (gTurn > cond.num)
                                    {
                                        this.BoardStateRulesTurn.Add(rNum, 0);
                                    }

                                    continue;
                                case param.turn_less:
                                    noturnrule = false;
                                    if (gTurn < cond.num)
                                    {
                                        this.BoardStateRulesTurn.Add(rNum, 0);
                                    }

                                    continue;
                            }
                        }
                    }
                }

                if (noturnrule)
                {
                    this.BoardStateRulesTurn.Add(rNum, 0);
                }
            }
        }

        public void readRules(string behavName, bool nameIsPath = false)
        {
            this.pathToRules = behavName;
            if (!nameIsPath)
            {
                if (this.MulliganRulesDB.ContainsKey(behavName))
                {
                    this.MulliganRules = this.MulliganRulesDB[behavName];
                    this.mulliganRulesLoaded = true;
                    return;
                }

                if (!Silverfish.Instance.BehaviorPath.ContainsKey(behavName))
                {
                    Helpfunctions.Instance.ErrorLog($"{behavName}: no special rules.");
                    return;
                }

                this.pathToRules = Path.Combine(Silverfish.Instance.BehaviorPath[behavName], "_rules.txt");
            }

            if (!File.Exists(this.pathToRules))
            {
                Helpfunctions.Instance.ErrorLog($"{behavName}: no special rules.");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(this.pathToRules);
                string tmps;
                bool getNextRule;
                this.MulliganRules.Clear();
                var rulesList = new List<Rule>();
                foreach (var s in lines)
                {
                    getNextRule = false;
                    if (s == "" || s == null)
                    {
                        continue;
                    }

                    if (s.StartsWith("//"))
                    {
                        continue;
                    }

                    var preRule = s.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                    var oneRule = new Rule();
                    var conditions = new List<Condition>();
                    var orCondNum = 1;
                    foreach (var ss in preRule)
                    {
                        if (getNextRule)
                        {
                            break;
                        }

                        var tmp = ss.Split('=');
                        var condition = tmp[0];
                        switch (condition)
                        {
                            case "ur":
                                oneRule.ultimateRule = true;
                                continue;
                            case "rn":
                                try { oneRule.ruleNumber = Convert.ToInt32(tmp[1]); }
                                catch
                                {
                                    Helpfunctions.Instance.ErrorLog(
                                        $"[RulesEngine] Wrong rule number (must be a number): {ss}");
                                    getNextRule = true;
                                }

                                continue;
                            case "rr":
                                try { oneRule.replacedRule = Convert.ToInt32(tmp[1]); }
                                catch
                                {
                                    Helpfunctions.Instance.ErrorLog(
                                        $"[RulesEngine] Wrong replaced rule number (must be a number): {ss}");
                                    getNextRule = true;
                                }

                                continue;
                            case "bonus":
                                try { oneRule.bonus = Convert.ToInt32(tmp[1]); }
                                catch
                                {
                                    Helpfunctions.Instance.ErrorLog(
                                        $"[RulesEngine] Wrong bonus (must be a number): {ss}");
                                    getNextRule = true;
                                }

                                continue;
                            default:
                                var condAnd = ss.Split('&');
                                foreach (var singlecondAnd in condAnd)
                                {
                                    if (getNextRule)
                                    {
                                        break;
                                    }

                                    if (singlecondAnd.Contains("|"))
                                    {
                                        tmps = singlecondAnd.Replace("||", "|");
                                        var condOr = tmps.Split('|');
                                        var orCondidion = new Condition(param.orcond, condOr.Count(), this.printRules == 0 ? "" : s);
                                        orCondidion.orCondNum = orCondNum;
                                        foreach (var singlecondOr in condOr)
                                        {
                                            if (!this.validateCondition(singlecondOr, s))
                                            {
                                                Helpfunctions.Instance.ErrorLog(
                                                    $"[RulesEngine] {this.condErr}{singlecondOr}");
                                                getNextRule = true;
                                            }

                                            if (getNextRule)
                                            {
                                                break;
                                            }

                                            this.condTmp.orCondNum = orCondNum;
                                            orCondidion.orConditions.Add(this.condTmp);
                                        }

                                        conditions.Add(orCondidion);
                                        orCondNum++;
                                        continue;
                                    }

                                    if (this.validateCondition(singlecondAnd, s))
                                    {
                                        conditions.Add(this.condTmp);
                                    }
                                    else
                                    {
                                        Helpfunctions.Instance.ErrorLog($"[RulesEngine] {this.condErr}{singlecondAnd}");
                                        getNextRule = true;
                                    }
                                }

                                continue;
                        }
                    }

                    if (getNextRule)
                    {
                        continue;
                    }

                    oneRule.conditions = conditions;
                    rulesList.Add(oneRule);
                }

                this.heapOfRules.Clear();
                this.replacedRules.Clear();
                foreach (var r in rulesList)
                {
                    if (r.ruleNumber == 0)
                    {
                        continue;
                    }

                    if (this.heapOfRules.ContainsKey(r.ruleNumber))
                    {
                        Helpfunctions.Instance.ErrorLog(
                            $"[RulesEngine] Rule rejected. Duplicate numbers: rn={r.ruleNumber}");
                    }
                    else
                    {
                        this.heapOfRules.Add(r.ruleNumber, r);
                    }
                }

                var tmpRules = new Dictionary<int, Rule>();
                var i = 1;
                foreach (var r in rulesList)
                {
                    if (r.ruleNumber != 0)
                    {
                        continue;
                    }

                    while (this.heapOfRules.ContainsKey(i))
                    {
                        i++;
                    }

                    r.ruleNumber = i;
                    tmpRules.Add(i, r);
                    i++;
                }

                foreach (var r in rulesList)
                {
                    if (r.replacedRule == 0)
                    {
                        continue;
                    }

                    if (this.heapOfRules.ContainsKey(r.replacedRule))
                    {
                        this.replacedRules.Add(r.ruleNumber, r.replacedRule);
                    }
                    else
                    {
                        Helpfunctions.Instance.ErrorLog($"[RulesEngine] No rule to replace: rr={r.replacedRule}");
                        r.replacedRule = 0;
                    }
                }

                foreach (var r in tmpRules)
                {
                    if (this.heapOfRules.ContainsKey(r.Key))
                    {
                        Helpfunctions.Instance.ErrorLog(
                            $"[RulesEngine] Replaced rule rejected. Duplicate numbers: rr={r.Key}");
                    }
                    else
                    {
                        this.heapOfRules.Add(r.Key, r.Value);
                    }
                }

                var equalOwnHeroes = new Dictionary<CardClass, int>();
                var notequalOwnHeroes = new Dictionary<CardClass, int>();
                var equalEnHeroes = new Dictionary<CardClass, int>();
                var notequalEnHeroes = new Dictionary<CardClass, int>();

                foreach (var r in this.heapOfRules)
                {
                    equalOwnHeroes.Clear();
                    notequalOwnHeroes.Clear();
                    equalEnHeroes.Clear();
                    notequalEnHeroes.Clear();
                    foreach (var cond in this.getAllCondList(r.Value.conditions))
                    {
                        switch (cond.parameter)
                        {
                            case param.ownhero_equal:
                                if (equalOwnHeroes.ContainsKey(cond.hClass))
                                {
                                    equalOwnHeroes[cond.hClass]++;
                                }
                                else
                                {
                                    equalOwnHeroes.Add(cond.hClass, 1);
                                }

                                continue;
                            case param.ownhero_notequal:
                                if (notequalOwnHeroes.ContainsKey(cond.hClass))
                                {
                                    notequalOwnHeroes[cond.hClass]++;
                                }
                                else
                                {
                                    notequalOwnHeroes.Add(cond.hClass, 1);
                                }

                                continue;
                            case param.enhero_equal:
                                if (equalEnHeroes.ContainsKey(cond.hClass))
                                {
                                    equalEnHeroes[cond.hClass]++;
                                }
                                else
                                {
                                    equalEnHeroes.Add(cond.hClass, 1);
                                }

                                continue;
                            case param.enhero_notequal:
                                if (notequalEnHeroes.ContainsKey(cond.hClass))
                                {
                                    notequalEnHeroes[cond.hClass]++;
                                }
                                else
                                {
                                    notequalEnHeroes.Add(cond.hClass, 1);
                                }

                                continue;
                        }
                    }

                    if (equalOwnHeroes.Count > 0 || notequalOwnHeroes.Count > 0)
                    {
                        foreach (CardClass hClass in Enum.GetValues(typeof(CardClass)))
                        {
                            if (hClass == CardClass.INVALID)
                            {
                                continue;
                            }

                            if (equalOwnHeroes.ContainsKey(hClass))
                            {
                                if (equalOwnHeroes[hClass] > 1)
                                {
                                    Helpfunctions.Instance.ErrorLog(
                                        $"[RulesEngine] Double own Hero class (equal): {hClass}");
                                }

                                if (notequalOwnHeroes.ContainsKey(hClass))
                                {
                                    Helpfunctions.Instance.ErrorLog(
                                        $"[RulesEngine] The same equal/notequal own Hero class: {hClass}");
                                }

                                if (this.RuleOwnClass.ContainsKey(hClass))
                                {
                                    this.RuleOwnClass[hClass].Add(r.Key, 0);
                                }
                                else
                                {
                                    this.RuleOwnClass.Add(hClass, new Dictionary<int, int> {{r.Key, 0}});
                                }
                            }
                            else if (equalOwnHeroes.Count < 1)
                            {
                                if (!notequalOwnHeroes.ContainsKey(hClass))
                                {
                                    if (notequalOwnHeroes[hClass] > 1)
                                    {
                                        Helpfunctions.Instance.ErrorLog(
                                            $"[RulesEngine] Double own Hero class (notequal): {hClass}");
                                    }

                                    if (this.RuleOwnClass.ContainsKey(hClass))
                                    {
                                        this.RuleOwnClass[hClass].Add(r.Key, 0);
                                    }
                                    else
                                    {
                                        this.RuleOwnClass.Add(hClass, new Dictionary<int, int> {{r.Key, 0}});
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.RuleOwnClass.ContainsKey(CardClass.INVALID))
                        {
                            this.RuleOwnClass[CardClass.INVALID].Add(r.Key, 0);
                        }
                        else
                        {
                            this.RuleOwnClass.Add(CardClass.INVALID, new Dictionary<int, int> {{r.Key, 0}});
                        }
                    }

                    if (equalEnHeroes.Count > 0 || notequalEnHeroes.Count > 0)
                    {
                        foreach (CardClass hClass in Enum.GetValues(typeof(CardClass)))
                        {
                            if (hClass == CardClass.INVALID || hClass == CardClass.INVALID)
                            {
                                continue;
                            }

                            if (equalEnHeroes.ContainsKey(hClass))
                            {
                                if (equalEnHeroes[hClass] > 1)
                                {
                                    Helpfunctions.Instance.ErrorLog(
                                        $"[RulesEngine] Double enemy Hero class (equal): {hClass}");
                                }

                                if (notequalEnHeroes.ContainsKey(hClass))
                                {
                                    Helpfunctions.Instance.ErrorLog(
                                        $"[RulesEngine] The same equal/notequal enemy Hero class: {hClass}");
                                }

                                if (this.RuleEnemyClass.ContainsKey(hClass))
                                {
                                    this.RuleEnemyClass[hClass].Add(r.Key, 0);
                                }
                                else
                                {
                                    this.RuleEnemyClass.Add(hClass, new Dictionary<int, int> {{r.Key, 0}});
                                }
                            }
                            else if (equalEnHeroes.Count < 1)
                            {
                                if (!notequalEnHeroes.ContainsKey(hClass))
                                {
                                    if (notequalEnHeroes[hClass] > 1)
                                    {
                                        Helpfunctions.Instance.ErrorLog(
                                            $"[RulesEngine] Double enemy Hero class (notequal): {hClass}");
                                    }

                                    if (this.RuleEnemyClass.ContainsKey(hClass))
                                    {
                                        this.RuleEnemyClass[hClass].Add(r.Key, 0);
                                    }
                                    else
                                    {
                                        this.RuleEnemyClass.Add(hClass, new Dictionary<int, int> {{r.Key, 0}});
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.RuleEnemyClass.ContainsKey(CardClass.INVALID))
                        {
                            this.RuleEnemyClass[CardClass.INVALID].Add(r.Key, 0);
                        }
                        else
                        {
                            this.RuleEnemyClass.Add(CardClass.INVALID, new Dictionary<int, int> {{r.Key, 0}});
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                Helpfunctions.Instance.ErrorLog("[规则编辑器] _rules.txt - 文本读取错误. 我们将使用默认规则，放弃自定义规则.");
                return;
            }

            Helpfunctions.Instance.ErrorLog($"[规则编辑器] {this.heapOfRules.Count} 规则名 {behavName} 读取成功");
            this.setRuleCardIds();
        }

        private List<Condition> getAllCondList(List<Condition> tmp)
        {
            var allCondList = new List<Condition>();
            foreach (var cond in tmp)
            {
                if (cond.parameter == param.orcond)
                {
                    allCondList.AddRange(cond.orConditions);
                }
                else
                {
                    allCondList.Add(cond);
                }
            }

            return allCondList;
        }

        public void setRuleCardIds()
        {
            this.RuleCardIdsPlay.Clear();
            this.RuleCardIdsHand.Clear();
            this.RuleCardIdsOwnBoard.Clear();
            this.RuleCardIdsEnemyBoard.Clear();
            this.RuleCardIdsAttack.Clear();
            foreach (var oneRule in this.heapOfRules)
            {
                var stateRule = false;
                var playRule = false;
                var IDsListPlay = new List<SimCard>();
                var IDsListHand = new List<SimCard>();
                var IDsListOB = new List<SimCard>();
                var IDsListEB = new List<SimCard>();
                var IDsListAttack = new List<SimCard>();
                foreach (var cond in this.getAllCondList(oneRule.Value.conditions))
                {
                    switch (cond.parameter)
                    {
                        case param.play:
                            IDsListPlay.Add(cond.cardID);
                            playRule = true;
                            continue;
                        case param.play2:
                            IDsListPlay.Add(cond.cardID);
                            playRule = true;
                            continue;
                        case param.attacker:
                            IDsListAttack.Add(cond.cardID);
                            playRule = true;
                            continue;
                        case param.ownhero_equal:
                            continue;
                        case param.ownhero_notequal:
                            continue;
                        case param.enhero_equal:
                            continue;
                        case param.enhero_notequal:
                            continue;
                        case param.ownhand_contain:
                            IDsListHand.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        case param.ownhand_notcontain:
                            IDsListHand.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        case param.ownboard_contain:
                            IDsListOB.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        case param.ownboard_notcontain:
                            IDsListOB.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        case param.enboard_contain:
                            IDsListEB.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        case param.enboard_notcontain:
                            IDsListEB.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        default:
                            continue;
                    }
                }

                if (IDsListPlay.Count > 0)
                {
                    this.RuleCardIdsPlay.Add(oneRule.Key, IDsListPlay.Distinct().ToList());
                }

                if (IDsListHand.Count > 0)
                {
                    this.RuleCardIdsHand.Add(oneRule.Key, IDsListHand);
                }

                if (IDsListOB.Count > 0)
                {
                    this.RuleCardIdsOwnBoard.Add(oneRule.Key, IDsListOB);
                }

                if (IDsListEB.Count > 0)
                {
                    this.RuleCardIdsEnemyBoard.Add(oneRule.Key, IDsListEB);
                }

                if (IDsListAttack.Count > 0)
                {
                    this.RuleCardIdsAttack.Add(oneRule.Key, IDsListAttack);
                }

                if (playRule && stateRule || !playRule)
                {
                    this.BoardStateRules.Add(oneRule.Key, 0);
                }
            }
        }


        private bool validateCondition(string singlecond, string ruleString)
        {
            switch (singlecond)
            {
                case "omc=emc":
                    this.condTmp = new Condition(param.omc_equal_emc, 0, this.printRules == 0 ? "" : ruleString);
                    return true;
                case "omc!=emc":
                    this.condTmp = new Condition(param.omc_notequal_emc, 0, this.printRules == 0 ? "" : ruleString);
                    return true;
                case "omc>emc":
                    this.condTmp = new Condition(param.omc_greater_emc, 0, this.printRules == 0 ? "" : ruleString);
                    return true;
                case "omc<emc":
                    this.condTmp = new Condition(param.omc_less_emc, 0, this.printRules == 0 ? "" : ruleString);
                    return true;
                case "ohc=ehc":
                    this.condTmp = new Condition(param.ohc_equal_ehc, 0, this.printRules == 0 ? "" : ruleString);
                    return true;
                case "ohc!=ehc":
                    this.condTmp = new Condition(param.ohc_notequal_ehc, 0, this.printRules == 0 ? "" : ruleString);
                    return true;
                case "ohc>ehc":
                    this.condTmp = new Condition(param.ohc_greater_ehc, 0, this.printRules == 0 ? "" : ruleString);
                    return true;
                case "ohc<ehc":
                    this.condTmp = new Condition(param.ohc_less_ehc, 0, this.printRules == 0 ? "" : ruleString);
                    return true;
            }

            this.condErr = "";
            string[] tmp;
            var extraParam = new string[0];
            var parameter = "";
            var condParam = param.None;
            var pval = "";
            var pvaltype = 0;


            if (singlecond.StartsWith("p="))
            {
                extraParam = singlecond.Split(':');
                singlecond = extraParam[0];
            }
            else if (singlecond.StartsWith("a="))
            {
                extraParam = singlecond.Split(':');
                singlecond = extraParam[0];
            }

            this.getSinglecond(singlecond, out tmp, out parameter);

            if (tmp.Length == 2)
            {
                switch (tmp[1])
                {
                    case "coin":
                        pval = "GAME_005";
                        break;
                    case "!coin":
                        pval = "GAME_005";
                        break;
                    default:
                        pval = tmp[1];
                        break;
                }
            }
            else if (tmp.Length == 1)
            {
                switch (tmp[0])
                {
                    case "noduplicates":
                        this.condTmp = new Condition(param.noduplicates, 0, this.printRules == 0 ? "" : ruleString);
                        return true;
                    default:
                        this.condErr = "Wrong condition: ";
                        return false;
                }
            }
            else
            {
                this.condErr = "Wrong condition: ";
                return false;
            }

            parameter = (tmp[0] + parameter).ToLower();
            switch (parameter)
            {
                case "tm=":
                    condParam = param.tm_equal;
                    break;
                case "tm!=":
                    condParam = param.tm_notequal;
                    break;
                case "tm>":
                    condParam = param.tm_greater;
                    break;
                case "tm<":
                    condParam = param.tm_less;
                    break;
                case "am=":
                    condParam = param.am_equal;
                    break;
                case "am!=":
                    condParam = param.am_notequal;
                    break;
                case "am>":
                    condParam = param.am_greater;
                    break;
                case "am<":
                    condParam = param.am_less;
                    break;
                case "owa=":
                    condParam = param.owa_equal;
                    break;
                case "owa!=":
                    condParam = param.owa_notequal;
                    break;
                case "owa>":
                    condParam = param.owa_greater;
                    break;
                case "owa<":
                    condParam = param.owa_less;
                    break;
                case "ewa=":
                    condParam = param.ewa_equal;
                    break;
                case "ewa!=":
                    condParam = param.ewa_notequal;
                    break;
                case "ewa>":
                    condParam = param.ewa_greater;
                    break;
                case "ewa<":
                    condParam = param.ewa_less;
                    break;
                case "owd=":
                    condParam = param.owd_equal;
                    break;
                case "owd!=":
                    condParam = param.owd_notequal;
                    break;
                case "owd>":
                    condParam = param.owd_greater;
                    break;
                case "owd<":
                    condParam = param.owd_less;
                    break;
                case "ewd=":
                    condParam = param.ewd_equal;
                    break;
                case "ewd!=":
                    condParam = param.ewd_notequal;
                    break;
                case "ewd>":
                    condParam = param.ewd_greater;
                    break;
                case "ewd<":
                    condParam = param.ewd_less;
                    break;
                case "omc=":
                    condParam = param.omc_equal;
                    break;
                case "omc!=":
                    condParam = param.omc_notequal;
                    break;
                case "omc>":
                    condParam = param.omc_greater;
                    break;
                case "omc<":
                    condParam = param.omc_less;
                    break;
                case "emc=":
                    condParam = param.emc_equal;
                    break;
                case "emc!=":
                    condParam = param.emc_notequal;
                    break;
                case "emc>":
                    condParam = param.emc_greater;
                    break;
                case "emc<":
                    condParam = param.emc_less;
                    break;

                case "omc:murlocs=":
                    condParam = param.omc_murlocs_equal;
                    break;
                case "omc:murlocs!=":
                    condParam = param.omc_murlocs_notequal;
                    break;
                case "omc:murlocs>":
                    condParam = param.omc_murlocs_greater;
                    break;
                case "omc:murlocs<":
                    condParam = param.omc_murlocs_less;
                    break;
                case "emc:murlocs=":
                    condParam = param.emc_murlocs_equal;
                    break;
                case "emc:murlocs!=":
                    condParam = param.emc_murlocs_notequal;
                    break;
                case "emc:murlocs>":
                    condParam = param.emc_murlocs_greater;
                    break;
                case "emc:murlocs<":
                    condParam = param.emc_murlocs_less;
                    break;
                case "omc:demons=":
                    condParam = param.omc_demons_equal;
                    break;
                case "omc:demons!=":
                    condParam = param.omc_demons_notequal;
                    break;
                case "omc:demons>":
                    condParam = param.omc_demons_greater;
                    break;
                case "omc:demons<":
                    condParam = param.omc_demons_less;
                    break;
                case "emc:demons=":
                    condParam = param.emc_demons_equal;
                    break;
                case "emc:demons!=":
                    condParam = param.emc_demons_notequal;
                    break;
                case "emc:demons>":
                    condParam = param.emc_demons_greater;
                    break;
                case "emc:demons<":
                    condParam = param.emc_demons_less;
                    break;
                case "omc:mechs=":
                    condParam = param.omc_mechs_equal;
                    break;
                case "omc:mechs!=":
                    condParam = param.omc_mechs_notequal;
                    break;
                case "omc:mechs>":
                    condParam = param.omc_mechs_greater;
                    break;
                case "omc:mechs<":
                    condParam = param.omc_mechs_less;
                    break;
                case "emc:mechs=":
                    condParam = param.emc_mechs_equal;
                    break;
                case "emc:mechs!=":
                    condParam = param.emc_mechs_notequal;
                    break;
                case "emc:mechs>":
                    condParam = param.emc_mechs_greater;
                    break;
                case "emc:mechs<":
                    condParam = param.emc_mechs_less;
                    break;
                case "omc:beasts=":
                    condParam = param.omc_beasts_equal;
                    break;
                case "omc:beasts!=":
                    condParam = param.omc_beasts_notequal;
                    break;
                case "omc:beasts>":
                    condParam = param.omc_beasts_greater;
                    break;
                case "omc:beasts<":
                    condParam = param.omc_beasts_less;
                    break;
                case "emc:beasts=":
                    condParam = param.emc_beasts_equal;
                    break;
                case "emc:beasts!=":
                    condParam = param.emc_beasts_notequal;
                    break;
                case "emc:beasts>":
                    condParam = param.emc_beasts_greater;
                    break;
                case "emc:beasts<":
                    condParam = param.emc_beasts_less;
                    break;
                case "omc:totems=":
                    condParam = param.omc_totems_equal;
                    break;
                case "omc:totems!=":
                    condParam = param.omc_totems_notequal;
                    break;
                case "omc:totems>":
                    condParam = param.omc_totems_greater;
                    break;
                case "omc:totems<":
                    condParam = param.omc_totems_less;
                    break;
                case "emc:totems=":
                    condParam = param.emc_totems_equal;
                    break;
                case "emc:totems!=":
                    condParam = param.emc_totems_notequal;
                    break;
                case "emc:totems>":
                    condParam = param.emc_totems_greater;
                    break;
                case "emc:totems<":
                    condParam = param.emc_totems_less;
                    break;
                case "omc:pirates=":
                    condParam = param.omc_pirates_equal;
                    break;
                case "omc:pirates!=":
                    condParam = param.omc_pirates_notequal;
                    break;
                case "omc:pirates>":
                    condParam = param.omc_pirates_greater;
                    break;
                case "omc:pirates<":
                    condParam = param.omc_pirates_less;
                    break;
                case "emc:pirates=":
                    condParam = param.emc_pirates_equal;
                    break;
                case "emc:pirates!=":
                    condParam = param.emc_pirates_notequal;
                    break;
                case "emc:pirates>":
                    condParam = param.emc_pirates_greater;
                    break;
                case "emc:pirates<":
                    condParam = param.emc_pirates_less;
                    break;
                case "omc:Dragons=":
                    condParam = param.omc_Dragons_equal;
                    break;
                case "omc:Dragons!=":
                    condParam = param.omc_Dragons_notequal;
                    break;
                case "omc:Dragons>":
                    condParam = param.omc_Dragons_greater;
                    break;
                case "omc:Dragons<":
                    condParam = param.omc_Dragons_less;
                    break;
                case "emc:Dragons=":
                    condParam = param.emc_Dragons_equal;
                    break;
                case "emc:Dragons!=":
                    condParam = param.emc_Dragons_notequal;
                    break;
                case "emc:Dragons>":
                    condParam = param.emc_Dragons_greater;
                    break;
                case "emc:Dragons<":
                    condParam = param.emc_Dragons_less;
                    break;
                case "omc:elems=":
                    condParam = param.omc_elems_equal;
                    break;
                case "omc:elems!=":
                    condParam = param.omc_elems_notequal;
                    break;
                case "omc:elems>":
                    condParam = param.omc_elems_greater;
                    break;
                case "omc:elems<":
                    condParam = param.omc_elems_less;
                    break;
                case "emc:elems=":
                    condParam = param.emc_elems_equal;
                    break;
                case "emc:elems!=":
                    condParam = param.emc_elems_notequal;
                    break;
                case "emc:elems>":
                    condParam = param.emc_elems_greater;
                    break;
                case "emc:elems<":
                    condParam = param.emc_elems_less;
                    break;
                case "omc:shr=":
                    condParam = param.omc_shr_equal;
                    break;
                case "omc:shr!=":
                    condParam = param.omc_shr_notequal;
                    break;
                case "omc:shr>":
                    condParam = param.omc_shr_greater;
                    break;
                case "omc:shr<":
                    condParam = param.omc_shr_less;
                    break;
                case "emc:shr=":
                    condParam = param.emc_shr_equal;
                    break;
                case "emc:shr!=":
                    condParam = param.emc_shr_notequal;
                    break;
                case "emc:shr>":
                    condParam = param.emc_shr_greater;
                    break;
                case "emc:shr<":
                    condParam = param.emc_shr_less;
                    break;
                case "omc:undamaged=":
                    condParam = param.omc_undamaged_equal;
                    break;
                case "omc:undamaged!=":
                    condParam = param.omc_undamaged_notequal;
                    break;
                case "omc:undamaged>":
                    condParam = param.omc_undamaged_greater;
                    break;
                case "omc:undamaged<":
                    condParam = param.omc_undamaged_less;
                    break;
                case "emc:undamaged=":
                    condParam = param.emc_undamaged_equal;
                    break;
                case "emc:undamaged!=":
                    condParam = param.emc_undamaged_notequal;
                    break;
                case "emc:undamaged>":
                    condParam = param.emc_undamaged_greater;
                    break;
                case "emc:undamaged<":
                    condParam = param.emc_undamaged_less;
                    break;
                case "omc:damaged=":
                    condParam = param.omc_damaged_equal;
                    break;
                case "omc:damaged!=":
                    condParam = param.omc_damaged_notequal;
                    break;
                case "omc:damaged>":
                    condParam = param.omc_damaged_greater;
                    break;
                case "omc:damaged<":
                    condParam = param.omc_damaged_less;
                    break;
                case "emc:damaged=":
                    condParam = param.emc_damaged_equal;
                    break;
                case "emc:damaged!=":
                    condParam = param.emc_damaged_notequal;
                    break;
                case "emc:damaged>":
                    condParam = param.emc_damaged_greater;
                    break;
                case "emc:damaged<":
                    condParam = param.emc_damaged_less;
                    break;
                case "omc:shields=":
                    condParam = param.omc_shields_equal;
                    break;
                case "omc:shields!=":
                    condParam = param.omc_shields_notequal;
                    break;
                case "omc:shields>":
                    condParam = param.omc_shields_greater;
                    break;
                case "omc:shields<":
                    condParam = param.omc_shields_less;
                    break;
                case "emc:shields=":
                    condParam = param.emc_shields_equal;
                    break;
                case "emc:shields!=":
                    condParam = param.emc_shields_notequal;
                    break;
                case "emc:shields>":
                    condParam = param.emc_shields_greater;
                    break;
                case "emc:shields<":
                    condParam = param.emc_shields_less;
                    break;
                case "omc:taunts=":
                    condParam = param.omc_taunts_equal;
                    break;
                case "omc:taunts!=":
                    condParam = param.omc_taunts_notequal;
                    break;
                case "omc:taunts>":
                    condParam = param.omc_taunts_greater;
                    break;
                case "omc:taunts<":
                    condParam = param.omc_taunts_less;
                    break;
                case "emc:taunts=":
                    condParam = param.emc_taunts_equal;
                    break;
                case "emc:taunts!=":
                    condParam = param.emc_taunts_notequal;
                    break;
                case "emc:taunts>":
                    condParam = param.emc_taunts_greater;
                    break;
                case "emc:taunts<":
                    condParam = param.emc_taunts_less;
                    break;
                case "ohc=":
                    condParam = param.ohc_equal;
                    break;
                case "ohc!=":
                    condParam = param.ohc_notequal;
                    break;
                case "ohc>":
                    condParam = param.ohc_greater;
                    break;
                case "ohc<":
                    condParam = param.ohc_less;
                    break;
                case "ehc=":
                    condParam = param.ehc_equal;
                    break;
                case "ehc!=":
                    condParam = param.ehc_notequal;
                    break;
                case "ehc>":
                    condParam = param.ehc_greater;
                    break;
                case "ehc<":
                    condParam = param.ehc_less;
                    break;
                //+extensions:
                case "ohc:minions=":
                    condParam = param.ohc_minions_equal;
                    break;
                case "ohc:minions!=":
                    condParam = param.ohc_minions_notequal;
                    break;
                case "ohc:minions>":
                    condParam = param.ohc_minions_greater;
                    break;
                case "ohc:minions<":
                    condParam = param.ohc_minions_less;
                    break;
                case "ohc:spells=":
                    condParam = param.ohc_spells_equal;
                    break;
                case "ohc:spells!=":
                    condParam = param.ohc_spells_notequal;
                    break;
                case "ohc:spells>":
                    condParam = param.ohc_spells_greater;
                    break;
                case "ohc:spells<":
                    condParam = param.ohc_spells_less;
                    break;
                case "ohc:secrets=":
                    condParam = param.ohc_secrets_equal;
                    break;
                case "ohc:secrets!=":
                    condParam = param.ohc_secrets_notequal;
                    break;
                case "ohc:secrets>":
                    condParam = param.ohc_secrets_greater;
                    break;
                case "ohc:secrets<":
                    condParam = param.ohc_secrets_less;
                    break;
                case "ohc:weapons=":
                    condParam = param.ohc_weapons_equal;
                    break;
                case "ohc:weapons!=":
                    condParam = param.ohc_weapons_notequal;
                    break;
                case "ohc:weapons>":
                    condParam = param.ohc_weapons_greater;
                    break;
                case "ohc:weapons<":
                    condParam = param.ohc_weapons_less;
                    break;
                case "ohc:murlocs=":
                    condParam = param.ohc_murlocs_equal;
                    break;
                case "ohc:murlocs!=":
                    condParam = param.ohc_murlocs_notequal;
                    break;
                case "ohc:murlocs>":
                    condParam = param.ohc_murlocs_greater;
                    break;
                case "ohc:murlocs<":
                    condParam = param.ohc_murlocs_less;
                    break;
                case "ohc:demons=":
                    condParam = param.ohc_demons_equal;
                    break;
                case "ohc:demons!=":
                    condParam = param.ohc_demons_notequal;
                    break;
                case "ohc:demons>":
                    condParam = param.ohc_demons_greater;
                    break;
                case "ohc:demons<":
                    condParam = param.ohc_demons_less;
                    break;
                case "ohc:mechs=":
                    condParam = param.ohc_mechs_equal;
                    break;
                case "ohc:mechs!=":
                    condParam = param.ohc_mechs_notequal;
                    break;
                case "ohc:mechs>":
                    condParam = param.ohc_mechs_greater;
                    break;
                case "ohc:mechs<":
                    condParam = param.ohc_mechs_less;
                    break;
                case "ohc:beasts=":
                    condParam = param.ohc_beasts_equal;
                    break;
                case "ohc:beasts!=":
                    condParam = param.ohc_beasts_notequal;
                    break;
                case "ohc:beasts>":
                    condParam = param.ohc_beasts_greater;
                    break;
                case "ohc:beasts<":
                    condParam = param.ohc_beasts_less;
                    break;
                case "ohc:totems=":
                    condParam = param.ohc_totems_equal;
                    break;
                case "ohc:totems!=":
                    condParam = param.ohc_totems_notequal;
                    break;
                case "ohc:totems>":
                    condParam = param.ohc_totems_greater;
                    break;
                case "ohc:totems<":
                    condParam = param.ohc_totems_less;
                    break;
                case "ohc:pirates=":
                    condParam = param.ohc_pirates_equal;
                    break;
                case "ohc:pirates!=":
                    condParam = param.ohc_pirates_notequal;
                    break;
                case "ohc:pirates>":
                    condParam = param.ohc_pirates_greater;
                    break;
                case "ohc:pirates<":
                    condParam = param.ohc_pirates_less;
                    break;
                case "ohc:Dragons=":
                    condParam = param.ohc_Dragons_equal;
                    break;
                case "ohc:Dragons!=":
                    condParam = param.ohc_Dragons_notequal;
                    break;
                case "ohc:Dragons>":
                    condParam = param.ohc_Dragons_greater;
                    break;
                case "ohc:Dragons<":
                    condParam = param.ohc_Dragons_less;
                    break;
                case "ohc:elems=":
                    condParam = param.ohc_elems_equal;
                    break;
                case "ohc:elems!=":
                    condParam = param.ohc_elems_notequal;
                    break;
                case "ohc:elems>":
                    condParam = param.ohc_elems_greater;
                    break;
                case "ohc:elems<":
                    condParam = param.ohc_elems_less;
                    break;
                case "ohc:shields=":
                    condParam = param.ohc_shields_equal;
                    break;
                case "ohc:shields!=":
                    condParam = param.ohc_shields_notequal;
                    break;
                case "ohc:shields>":
                    condParam = param.ohc_shields_greater;
                    break;
                case "ohc:shields<":
                    condParam = param.ohc_shields_less;
                    break;
                case "ohc:taunts=":
                    condParam = param.ohc_taunts_equal;
                    break;
                case "ohc:taunts!=":
                    condParam = param.ohc_taunts_notequal;
                    break;
                case "ohc:taunts>":
                    condParam = param.ohc_taunts_greater;
                    break;
                case "ohc:taunts<":
                    condParam = param.ohc_taunts_less;
                    break;
                case "t=":
                    condParam = param.turn_equal;
                    break;
                case "t!=":
                    condParam = param.turn_notequal;
                    break;
                case "t>":
                    condParam = param.turn_greater;
                    break;
                case "t<":
                    condParam = param.turn_less;
                    break;
                case "overload=":
                    condParam = param.overload_equal;
                    break;
                case "overload!=":
                    condParam = param.overload_notequal;
                    break;
                case "overload>":
                    condParam = param.overload_greater;
                    break;
                case "overload<":
                    condParam = param.overload_less;
                    break;
                case "owncarddraw=":
                    condParam = param.owncarddraw_equal;
                    break;
                case "owncarddraw!=":
                    condParam = param.owncarddraw_notequal;
                    break;
                case "owncarddraw>":
                    condParam = param.owncarddraw_greater;
                    break;
                case "owncarddraw<":
                    condParam = param.owncarddraw_less;
                    break;
                case "ohhp=":
                    condParam = param.ohhp_equal;
                    break;
                case "ohhp!=":
                    condParam = param.ohhp_notequal;
                    break;
                case "ohhp>":
                    condParam = param.ohhp_greater;
                    break;
                case "ohhp<":
                    condParam = param.ohhp_less;
                    break;
                case "ehhp=":
                    condParam = param.ehhp_equal;
                    break;
                case "ehhp!=":
                    condParam = param.ehhp_notequal;
                    break;
                case "ehhp>":
                    condParam = param.ehhp_greater;
                    break;
                case "ehhp<":
                    condParam = param.ehhp_less;
                    break;

                case "ob=":
                    condParam = param.ownboard_contain;
                    pvaltype = 1;
                    break;
                case "ob!=":
                    condParam = param.ownboard_notcontain;
                    pvaltype = 1;
                    break;
                case "eb=":
                    condParam = param.enboard_contain;
                    pvaltype = 1;
                    break;
                case "eb!=":
                    condParam = param.enboard_notcontain;
                    pvaltype = 1;
                    break;
                case "oh=":
                    condParam = param.ownhand_contain;
                    pvaltype = 1;
                    break;
                case "oh!=":
                    condParam = param.ownhand_notcontain;
                    pvaltype = 1;
                    break;
                case "ow=":
                    condParam = param.ownweapon_equal;
                    pvaltype = 1;
                    break;
                case "ow!=":
                    condParam = param.ownweapon_notequal;
                    pvaltype = 1;
                    break;
                case "ew=":
                    condParam = param.enweapon_equal;
                    pvaltype = 1;
                    break;
                case "ew!=":
                    condParam = param.enweapon_notequal;
                    pvaltype = 1;
                    break;
                case "ohero=":
                    condParam = param.ownhero_equal;
                    pvaltype = 2;
                    break;
                case "ohero!=":
                    condParam = param.ownhero_notequal;
                    pvaltype = 2;
                    break;
                case "ehero=":
                    condParam = param.enhero_equal;
                    pvaltype = 2;
                    break;
                case "ehero!=":
                    condParam = param.enhero_notequal;
                    pvaltype = 2;
                    break;

                case "p=":
                    condParam = param.play;
                    pvaltype = 1;
                    break;
                case "p2=":
                    condParam = param.play2;
                    pvaltype = 1;
                    break;
                case "a=":
                    condParam = param.attacker;
                    pvaltype = 1;
                    break;
                default:
                    this.condErr = "Wrong parameter: ";
                    return false;
            }

            var returnRes = false;
            switch (pvaltype)
            {
                case 0:
                    try
                    {
                        this.condTmp = new Condition(condParam, Convert.ToInt32(pval), this.printRules == 0 ? "" : ruleString);
                        returnRes = true;
                    }
                    catch
                    {
                        this.condErr = "Wrong parameter value (must be a number): ";
                        returnRes = false;
                    }

                    break;
                case 1:
                    SimCard cardId = pval;
                    if (cardId == SimCard.None)
                    {
                        this.condErr = "Wrong CardID: ";
                        returnRes = false;
                    }
                    else
                    {
                        this.condTmp = new Condition(condParam, cardId, this.printRules == 0 ? "" : ruleString);
                        returnRes = true;
                    }

                    break;
                case 2:
                    var hClass = pval.ParseEnum<CardClass>();
                    if (hClass == CardClass.INVALID)
                    {
                        this.condErr = "Wrong Hero Class: ";
                        returnRes = false;
                    }
                    else
                    {
                        this.condTmp = new Condition(condParam, hClass, this.printRules == 0 ? "" : ruleString);
                        returnRes = true;
                    }

                    break;
            }

            if (extraParam.Count() > 1 && returnRes)
            {
                var extraConds = new List<Condition>();
                var extraParamCount = extraParam.Count();
                for (var i = 1; i < extraParamCount; i++)
                {
                    this.getSinglecond(extraParam[i], out tmp, out parameter);

                    var pvalInt = 0;
                    SimCard pvalCardId = SimCard.None;
                    try
                    {
                        switch (tmp[0])
                        {
                            case "tgt":
                                pvalCardId = tmp[1];
                                if (pvalCardId == SimCard.None)
                                {
                                    this.condErr = "Wrong CardID: ";
                                    returnRes = false;
                                }

                                break;
                            default:
                                pvalInt = Convert.ToInt32(tmp[1]);
                                break;
                        }
                    }
                    catch
                    {
                        this.condErr = "Wrong extra parameter: ";
                        return false;
                    }

                    switch (tmp[0] + parameter)
                    {
                        case "pen=":
                            this.condTmp.bonus = pvalInt;
                            continue;
                        case "aAt=":
                            condParam = param.aAt_equal;
                            break;
                        case "aAt!=":
                            condParam = param.aAt_notequal;
                            break;
                        case "aAt>":
                            condParam = param.aAt_greater;
                            break;
                        case "aAt<":
                            condParam = param.aAt_less;
                            break;
                        case "aHp=":
                            condParam = param.aHp_equal;
                            break;
                        case "aHp!=":
                            condParam = param.aHp_notequal;
                            break;
                        case "aHp>":
                            condParam = param.aHp_greater;
                            break;
                        case "aHp<":
                            condParam = param.aHp_less;
                            break;
                        case "tAt=":
                            condParam = param.tAt_equal;
                            break;
                        case "tAt!=":
                            condParam = param.tAt_notequal;
                            break;
                        case "tAt>":
                            condParam = param.tAt_greater;
                            break;
                        case "tAt<":
                            condParam = param.tAt_less;
                            break;
                        case "tHp=":
                            condParam = param.tHp_equal;
                            break;
                        case "tHp!=":
                            condParam = param.tHp_notequal;
                            break;
                        case "tHp>":
                            condParam = param.tHp_greater;
                            break;
                        case "tHp<":
                            condParam = param.tHp_less;
                            break;
                        case "tgt=":
                            condParam = param.tgt_equal;
                            break;
                        case "tgt!=":
                            condParam = param.tgt_notequal;
                            break;
                        default:
                            this.condErr = "Wrong extra parameter: ";
                            return false;
                    }

                    if (tmp[0] == "tgt")
                    {
                        extraConds.Add(new Condition(condParam, pvalCardId, this.printRules == 0 ? "" : ruleString));
                    }
                    else
                    {
                        extraConds.Add(new Condition(condParam, pvalInt, this.printRules == 0 ? "" : ruleString));
                    }
                }

                this.condTmp.extraConditions.AddRange(extraConds);
            }

            return returnRes;
        }

        private void getSinglecond(string singlecond, out string[] tmp, out string parameter)
        {
            parameter = "";
            if (singlecond.Contains("!="))
            {
                tmp = singlecond.Split(new[] {"!="}, StringSplitOptions.RemoveEmptyEntries);
                parameter = "!=";
            }
            else if (singlecond.Contains("="))
            {
                tmp = singlecond.Split('=');
                parameter = "=";
            }
            else if (singlecond.Contains(">"))
            {
                tmp = singlecond.Split('>');
                parameter = ">";
            }
            else if (singlecond.Contains("<"))
            {
                tmp = singlecond.Split('<');
                parameter = "<";
            }
            else
            {
                tmp = singlecond.Split('=');
            }
        }

        private bool checkCondition(Condition cond, Playfield p, Action a = null)
        {
            this.condErr = "";
            switch (cond.parameter)
            {
                case param.tm_equal:
                    if (p.ownMaxMana == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tm_notequal:
                    if (p.ownMaxMana != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tm_greater:
                    if (p.ownMaxMana > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tm_less:
                    if (p.ownMaxMana < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.am_equal:
                    if (p.mana == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.am_notequal:
                    if (p.mana != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.am_greater:
                    if (p.mana > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.am_less:
                    if (p.mana < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owa_equal:
                    if (p.ownWeapon.Angr == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owa_notequal:
                    if (p.ownWeapon.Angr != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owa_greater:
                    if (p.ownWeapon.Angr > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owa_less:
                    if (p.ownWeapon.Angr < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ewa_equal:
                    if (p.enemyWeapon.Angr == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ewa_notequal:
                    if (p.enemyWeapon.Angr != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ewa_greater:
                    if (p.enemyWeapon.Angr > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ewa_less:
                    if (p.enemyWeapon.Angr < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owd_equal:
                    if (p.ownWeapon.Durability == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owd_notequal:
                    if (p.ownWeapon.Durability != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owd_greater:
                    if (p.ownWeapon.Durability > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owd_less:
                    if (p.ownWeapon.Durability < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ewd_equal:
                    if (p.enemyWeapon.Durability == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ewd_notequal:
                    if (p.enemyWeapon.Durability != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ewd_greater:
                    if (p.enemyWeapon.Durability > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ewd_less:
                    if (p.enemyWeapon.Durability < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_equal:
                    if (p.ownMinions.Count == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_notequal:
                    if (p.ownMinions.Count != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_greater:
                    if (p.ownMinions.Count > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_less:
                    if (p.ownMinions.Count < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_equal:
                    if (p.enemyMinions.Count == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_notequal:
                    if (p.enemyMinions.Count != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_greater:
                    if (p.enemyMinions.Count > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_less:
                    if (p.enemyMinions.Count < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_equal_emc:
                    if (p.ownMinions.Count == p.enemyMinions.Count)
                    {
                        return true;
                    }

                    return false;
                case param.omc_notequal_emc:
                    if (p.ownMinions.Count != p.enemyMinions.Count)
                    {
                        return true;
                    }

                    return false;
                case param.omc_greater_emc:
                    if (p.ownMinions.Count > p.enemyMinions.Count)
                    {
                        return true;
                    }

                    return false;
                case param.omc_less_emc:
                    if (p.ownMinions.Count < p.enemyMinions.Count)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_equal:
                    if (p.owncards.Count == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_notequal:
                    if (p.owncards.Count != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_greater:
                    if (p.owncards.Count > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_less:
                    if (p.owncards.Count < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ehc_equal:
                    if (p.enemyAnzCards == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ehc_notequal:
                    if (p.enemyAnzCards != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ehc_greater:
                    if (p.enemyAnzCards > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ehc_less:
                    if (p.enemyAnzCards < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_equal_ehc:
                    if (p.owncards.Count == p.enemyAnzCards)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_notequal_ehc:
                    if (p.owncards.Count != p.enemyAnzCards)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_greater_ehc:
                    if (p.owncards.Count > p.enemyAnzCards)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_less_ehc:
                    if (p.owncards.Count < p.enemyAnzCards)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_minions_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.MINION)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_minions_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.MINION)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_minions_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.MINION)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_minions_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.MINION)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_spells_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.SPELL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_spells_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.SPELL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_spells_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.SPELL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_spells_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.SPELL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_secrets_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Secret)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_secrets_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Secret)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_secrets_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Secret)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_secrets_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Secret)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_weapons_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.WEAPON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_weapons_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.WEAPON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_weapons_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.WEAPON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_weapons_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.WEAPON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_murlocs_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_murlocs_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_murlocs_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_murlocs_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_demons_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_demons_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_demons_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_demons_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_mechs_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_mechs_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_mechs_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_mechs_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_beasts_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_beasts_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_beasts_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_beasts_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_totems_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_totems_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_totems_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_pirates_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_pirates_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_pirates_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_pirates_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_Dragons_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_Dragons_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_Dragons_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_Dragons_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_elems_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_elems_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_elems_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_elems_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_shields_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.DivineShield)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_shields_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.DivineShield)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_shields_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.DivineShield)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_shields_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.DivineShield)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_taunts_equal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_taunts_notequal:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_taunts_greater:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohc_taunts_less:
                    this.tmp_counter = 0;
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.aAt_equal:
                    if (a.own != null && a.own.Angr == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.aAt_notequal:
                    if (a.own != null && a.own.Angr != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.aAt_greater:
                    if (a.own != null && a.own.Angr > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.aAt_less:
                    if (a.own != null && a.own.Angr < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.aHp_equal:
                    if (a.own != null && a.prevHpOwn == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.aHp_notequal:
                    if (a.own != null && a.prevHpOwn != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.aHp_greater:
                    if (a.own != null && a.prevHpOwn > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.aHp_less:
                    if (a.own != null && a.prevHpOwn < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tAt_equal:
                    if (a.target != null && a.target.Angr == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tAt_notequal:
                    if (a.target != null && a.target.Angr != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tAt_greater:
                    if (a.target != null && a.target.Angr > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tAt_less:
                    if (a.target != null && a.target.Angr < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tHp_equal:
                    if (a.target != null && a.prevHpTarget == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tHp_notequal:
                    if (a.target != null && a.prevHpTarget != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tHp_greater:
                    if (a.target != null && a.prevHpTarget > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.tHp_less:
                    if (a.target != null && a.prevHpTarget < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_murlocs_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_murlocs_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_murlocs_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_murlocs_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_murlocs_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_murlocs_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_murlocs_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_murlocs_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.MURLOC)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_demons_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_demons_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_demons_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_demons_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_demons_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_demons_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_demons_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_demons_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.DEMON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_mechs_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_mechs_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_mechs_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_mechs_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_mechs_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_mechs_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_mechs_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_mechs_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.MECHANICAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_beasts_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_beasts_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_beasts_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_beasts_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_beasts_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_beasts_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_beasts_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_beasts_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.PET)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_totems_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_totems_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_totems_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_totems_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_totems_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_totems_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_totems_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_totems_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.TOTEM)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_pirates_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_pirates_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_pirates_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_pirates_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_pirates_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_pirates_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_pirates_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_pirates_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.PIRATE)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_Dragons_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_Dragons_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_Dragons_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_Dragons_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_Dragons_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_Dragons_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_Dragons_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_Dragons_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.DRAGON)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_elems_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_elems_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_elems_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_elems_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_elems_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_elems_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_elems_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_elems_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.Race == Race.ELEMENTAL)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_shr_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_shr_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_shr_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_shr_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_shr_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_shr_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_shr_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_shr_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_undamaged_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (!m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_undamaged_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (!m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_undamaged_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (!m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_undamaged_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (!m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_undamaged_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (!m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_undamaged_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (!m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_undamaged_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (!m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_undamaged_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (!m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_damaged_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_damaged_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_damaged_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_damaged_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_damaged_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_damaged_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_damaged_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_damaged_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.wounded)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_shields_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.divineshild)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_shields_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.divineshild)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_shields_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.divineshild)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_shields_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.divineshild)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_shields_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.divineshild)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_shields_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.divineshild)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_shields_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.divineshild)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_shields_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.divineshild)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_taunts_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_taunts_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_taunts_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.omc_taunts_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.ownMinions)
                    {
                        if (m.taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_taunts_equal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_taunts_notequal:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_taunts_greater:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.emc_taunts_less:
                    this.tmp_counter = 0;
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.taunt)
                        {
                            this.tmp_counter++;
                        }
                    }

                    if (this.tmp_counter < cond.num)
                    {
                        return true;
                    }

                    return false;

                case param.turn_equal:
                    if (p.gTurn == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.turn_notequal:
                    if (p.gTurn != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.turn_greater:
                    if (p.gTurn > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.turn_less:
                    if (p.gTurn < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.overload_equal:
                    if (p.ueberladung == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.overload_notequal:
                    if (p.ueberladung != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.overload_greater:
                    if (p.ueberladung > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.overload_less:
                    if (p.ueberladung < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owncarddraw_equal:
                    if (p.owncarddraw == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owncarddraw_notequal:
                    if (p.owncarddraw != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owncarddraw_greater:
                    if (p.owncarddraw > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.owncarddraw_less:
                    if (p.owncarddraw < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohhp_equal:
                    if (p.ownHero.Hp == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohhp_notequal:
                    if (p.ownHero.Hp != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohhp_greater:
                    if (p.ownHero.Hp > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ohhp_less:
                    if (p.ownHero.Hp < cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ehhp_equal:
                    if (p.enemyHero.Hp == cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ehhp_notequal:
                    if (p.enemyHero.Hp != cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ehhp_greater:
                    if (p.enemyHero.Hp > cond.num)
                    {
                        return true;
                    }

                    return false;
                case param.ehhp_less:
                    if (p.enemyHero.Hp < cond.num)
                    {
                        return true;
                    }

                    return false;

                case param.ownboard_contain:
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.CardId == cond.cardID)
                        {
                            return true;
                        }
                    }

                    return false;
                case param.ownboard_notcontain:
                    foreach (var m in p.ownMinions)
                    {
                        if (m.handcard.card.CardId == cond.cardID)
                        {
                            return false;
                        }
                    }

                    return true;
                case param.enboard_contain:
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.CardId == cond.cardID)
                        {
                            return true;
                        }
                    }

                    return false;
                case param.enboard_notcontain:
                    foreach (var m in p.enemyMinions)
                    {
                        if (m.handcard.card.CardId == cond.cardID)
                        {
                            return false;
                        }
                    }

                    return true;
                case param.ownhand_contain:
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.CardId == cond.cardID)
                        {
                            return true;
                        }
                    }

                    return false;
                case param.ownhand_notcontain:
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.CardId == cond.cardID)
                        {
                            return false;
                        }
                    }

                    return true;
                case param.ownweapon_equal:
                    if (p.ownWeapon.card.CardId == cond.cardID)
                    {
                        return true;
                    }

                    return false;
                case param.ownweapon_notequal:
                    if (p.ownWeapon.card.CardId != cond.cardID)
                    {
                        return true;
                    }

                    return false;
                case param.enweapon_equal:
                    if (p.enemyWeapon.card.CardId == cond.cardID)
                    {
                        return true;
                    }

                    return false;
                case param.enweapon_notequal:
                    if (p.enemyWeapon.card.CardId != cond.cardID)
                    {
                        return true;
                    }

                    return false;
                case param.ownhero_equal:
                    if (cond.hClass == CardClass.INVALID)
                    {
                        return true;
                    }

                    if (p.ownHeroStartClass == cond.hClass)
                    {
                        return true;
                    }

                    return false;
                case param.ownhero_notequal:
                    if (p.ownHeroStartClass != cond.hClass)
                    {
                        return true;
                    }

                    return false;
                case param.enhero_equal:
                    if (cond.hClass == CardClass.INVALID)
                    {
                        return true;
                    }

                    if (p.enemyHeroStartClass == cond.hClass)
                    {
                        return true;
                    }

                    return false;
                case param.enhero_notequal:
                    if (p.enemyHeroStartClass != cond.hClass)
                    {
                        return true;
                    }

                    return false;
                // TODO: What's this?
                //case param.tgt_equal:
                //    if (a.target!= null && (a.target.handcard.card.CardId == cond.cardID || (a.target.isHero && cond.cardID == SimCard.hero))) return true;
                //    return false;
                //case param.tgt_notequal:
                //    if (a.target != null)
                //    {
                //        if (a.target.isHero)
                //        {
                //            if (cond.cardID != SimCard.hero) return true;
                //            else return false;
                //        }
                //        else if (a.target.handcard.card.CardId != cond.cardID) return true;
                //    }
                //    return false;
                case param.noduplicates:
                    return p.prozis.noDuplicates;
                default:
                    this.condErr = "Wrong parameter: ";
                    return false;
            }
        }
    }
}