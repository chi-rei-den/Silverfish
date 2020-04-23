using System;
using System.Collections.Generic;
using System.IO;
using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
    public class BoardTester
    {
        public string botBehavior = "None";
        int maxwide = 3000;
        int twoturnsim = 256;
        int pprob1 = 50;
        int pprob2 = 80;
        bool playaround;

        int ownPlayer = 1;
        int enemmaxman;

        Minion ownHero;
        Minion enemyHero;

        Weapon ownWeapon;
        Weapon enemyWeapon;

        int ownHEntity;
        int enemyHEntity = 1;
        bool enemyHeroStealth;


        int gTurn;
        int gTurnStep;
        int mana;
        int maxmana;
        int ownherohp;
        int ownheromaxhp = 30;
        int enemyheromaxhp = 30;
        int ownherodefence;
        bool ownheroready;
        bool ownHeroimmunewhileattacking;
        int ownheroattacksThisRound;
        int ownHeroAttack;
        int ownHeroTempAttack;
        bool ownHeroStealth;
        int numOptionPlayedThisTurn;
        int numMinionsPlayedThisTurn;
        int cardsPlayedThisTurn;
        int overload;
        int lockedMana;

        int anzOgOwnCThunHpBonus;
        int anzOgOwnCThunAngrBonus;
        int anzOgOwnCThunTaunt;
        int anzOwnJadeGolem;
        int anzEnemyJadeGolem;
        int anzOwnElementalsThisTurn;
        int anzOwnElementalsLastTurn;
        int ownElementalsHaveLifesteal;
        int ownCrystalCore;
        bool ownMinionsInDeckCost0;

        int ownDecksize = 30;
        int enemyDecksize = 30;
        int ownFatigue;
        int enemyFatigue;

        bool heroImmune;
        bool enemyHeroImmune;

        int ownHeroPowerCost = 2;
        int enemyHeroPowerCost = 2;

        int enemySecretAmount;
        List<SecretItem> enemySecrets = new List<SecretItem>();

        bool ownHeroFrozen;

        List<string> ownsecretlist = new List<string>();
        int enemyherohp;
        int enemyherodefence;
        bool enemyFrozen;
        bool fistRun = true;
        int enemyNumberHand = 5;

        List<Minion> ownminions = new List<Minion>();
        List<Minion> enemyminions = new List<Minion>();
        List<Handcard> handcards = new List<Handcard>();
        List<SimCard> enemycards = new List<SimCard>();
        List<GraveYardItem> turnGraveYard = new List<GraveYardItem>();
        List<GraveYardItem> turnGraveYardAll = new List<GraveYardItem>();
        List<string> discover = new List<string>();
        Dictionary<int, IDEnumOwner> LurkersDB = new Dictionary<int, IDEnumOwner>();
        Dictionary<SimCard, int> og = new Dictionary<SimCard, int>();
        Dictionary<SimCard, int> eg = new Dictionary<SimCard, int>();

        bool feugendead;
        bool stalaggdead;
        public bool datareaded;

        public BoardTester(string data = "")
        {
            this.og.Clear();
            this.eg.Clear();

            var omd = "";
            var emd = "";

            var weaponOnlyAttackMobsUntilEnfacehp = 0;
            var berserkIfCanFinishNextTour = 0;
            var facehp = 15;
            var placement = 0;

            var ets = 20;
            var ets2 = 200;

            var ntssw = 10;
            var ntssd = 6;
            var ntssm = 50;

            var iC = 0;
            var speedup = 0;
            var adjustActions = 0;
            var concedeMode = 0;

            var alpha = 50;

            var dosecrets = false;

            Settings.Instance.placement = 0;
            Hrtprozis.Instance.clearAllNewGame();
            Handmanager.Instance.clearAllRecalc();
            var lines = new string[0] { };
            if (data == "")
            {
                this.datareaded = false;
                try
                {
                    var path = Settings.Instance.path;
                    lines = File.ReadAllLines($"{path}test.txt");
                    this.datareaded = true;
                }
                catch
                {
                    this.datareaded = false;
                    Helpfunctions.Instance.logg("cant find test.txt");
                    Helpfunctions.Instance.ErrorLog("cant find test.txt");
                    return;
                }
            }
            else
            {
                this.datareaded = true;
                lines = data.Split(new[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
            }

            SimCard heroability = CardIds.NonCollectible.Mage.Fireblast;
            SimCard enemyability = CardIds.NonCollectible.Mage.Fireblast;
            var abilityReady = false;

            var readstate = 0;
            var counter = 0;

            var tempminion = new Minion();
            var j = 0;
            foreach (var sss in lines)
            {
                var s = $"{sss} ";
                Helpfunctions.Instance.logg(s);

                if (s.StartsWith("ailoop") || s.StartsWith("deep ") || s.StartsWith("cut to len"))
                {
                    continue;
                }

                if (s.StartsWith("####"))
                {
                    continue;
                }

                if (s.StartsWith("mana changed"))
                {
                    continue;
                }

                if (s.StartsWith("start calculations, current time: "))
                {
                    if (!this.fistRun)
                    {
                        break;
                    }

                    this.fistRun = false;

                    Ai.Instance.currentCalculatedBoard = s.Split(' ')[4].Split(' ')[0];

                    this.botBehavior = s.Split(' ')[6].Split(' ')[0];

                    this.maxwide = Convert.ToInt32(s.Split(' ')[7].Split(' ')[0]);

                    //following params are optional
                    this.twoturnsim = 0;
                    if (s.Contains("twoturnsim "))
                    {
                        this.twoturnsim = Convert.ToInt32(s.Split(new[] {"twoturnsim "}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                    }

                    if (s.Contains(" face "))
                    {
                        var tmp = s.Split(new[] {"face "}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        facehp = Convert.ToInt32(tmp);
                    }

                    if (s.Contains(" womob:"))
                    {
                        var tmp = s.Split(new[] {" womob:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        weaponOnlyAttackMobsUntilEnfacehp = Convert.ToInt32(tmp);
                    }

                    if (s.Contains(" berserk:"))
                    {
                        var tmp = s.Split(new[] {" berserk:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        berserkIfCanFinishNextTour = Convert.ToInt32(tmp);
                    }

                    if (s.Contains(" cede:"))
                    {
                        var tmp = s.Split(new[] {" cede:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        concedeMode = Convert.ToInt32(tmp);
                    }

                    this.playaround = false;
                    if (s.Contains("playaround "))
                    {
                        var probs = s.Split(new[] {"playaround "}, StringSplitOptions.RemoveEmptyEntries)[1];
                        this.playaround = true;
                        this.pprob1 = Convert.ToInt32(probs.Split(' ')[0]);
                        this.pprob2 = Convert.ToInt32(probs.Split(' ')[1]);
                    }

                    if (s.Contains(" ets "))
                    {
                        var eturnsim = s.Split(new[] {" ets "}, StringSplitOptions.RemoveEmptyEntries)[1];
                        ets = Convert.ToInt32(eturnsim.Split(' ')[0]);
                    }

                    if (s.Contains(" ets2 "))
                    {
                        var eturnsim2 = s.Split(new[] {" ets2 "}, StringSplitOptions.RemoveEmptyEntries)[1];
                        ets2 = Convert.ToInt32(eturnsim2.Split(' ')[0]);
                    }

                    if (s.Contains(" ntss "))
                    {
                        var ss = s.Split(new[] {" ntss "}, StringSplitOptions.RemoveEmptyEntries)[1];
                        ntssd = Convert.ToInt32(ss.Split(' ')[0]);
                        ntssw = Convert.ToInt32(ss.Split(' ')[1]);
                        ntssm = Convert.ToInt32(ss.Split(' ')[2]);
                    }

                    if (s.Contains(" iC "))
                    {
                        var ss = s.Split(new[] {" iC "}, StringSplitOptions.RemoveEmptyEntries)[1];
                        iC = Convert.ToInt32(ss.Split(' ')[0]);
                    }

                    if (s.Contains(" speedup "))
                    {
                        var ss = s.Split(new[] {" speedup "}, StringSplitOptions.RemoveEmptyEntries)[1];
                        speedup = Convert.ToInt32(ss.Split(' ')[0]);
                    }

                    if (s.Contains(" aA "))
                    {
                        var ss = s.Split(new[] {" aA "}, StringSplitOptions.RemoveEmptyEntries)[1];
                        adjustActions = Convert.ToInt32(ss.Split(' ')[0]);
                    }

                    if (s.Contains(" secret"))
                    {
                        dosecrets = true;
                    }

                    if (s.Contains(" weight "))
                    {
                        var alphaval = s.Split(new[] {" weight "}, StringSplitOptions.RemoveEmptyEntries)[1];
                        alpha = Convert.ToInt32(alphaval.Split(' ')[0]);
                    }

                    if (s.Contains(" plcmnt:"))
                    {
                        var tmp = s.Split(new[] {" plcmnt:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        placement = Convert.ToInt32(tmp);
                    }

                    continue;
                }

                if (s.StartsWith("enemy secretsCount:"))
                {
                    this.enemySecretAmount = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemySecrets.Clear();
                    if (this.enemySecretAmount >= 1 && s.Contains(";"))
                    {
                        var secretstuff = s.Split(';')[1];
                        foreach (var sec in secretstuff.Split(','))
                        {
                            if (sec == "" || sec == string.Empty || sec == " ")
                            {
                                continue;
                            }

                            this.enemySecrets.Add(new SecretItem(sec));
                        }
                    }

                    continue;
                }

                if (s.StartsWith("turn "))
                {
                    var ss = s.Replace("turn ", "");
                    this.gTurn = Convert.ToInt32(ss.Split('/')[0]);
                    this.gTurnStep = Convert.ToInt32(ss.Split('/')[1]);
                }

                if (s.StartsWith("mana "))
                {
                    var ss = s.Replace("mana ", "");
                    this.mana = Convert.ToInt32(ss.Split('/')[0]);
                    this.maxmana = Convert.ToInt32(ss.Split('/')[1]);
                }

                if (s.StartsWith("emana "))
                {
                    var ss = s.Replace("emana ", "");
                    this.enemmaxman = Convert.ToInt32(ss);
                }

                if (s.StartsWith("Enemy cards: "))
                {
                    this.enemyNumberHand = Convert.ToInt32(s.Split(' ')[2]);
                    readstate = 0;
                    continue;
                }

                if (s.StartsWith("GraveYard:"))
                {
                    if (s.Contains("fgn"))
                    {
                        this.feugendead = true;
                    }

                    if (s.Contains("stlgg"))
                    {
                        this.stalaggdead = true;
                    }

                    continue;
                }

                if (s.StartsWith("osecrets: "))
                {
                    var secs = s.Replace("osecrets: ", "");
                    foreach (var sec in secs.Split(' '))
                    {
                        if (sec == "" || sec == string.Empty)
                        {
                            continue;
                        }

                        this.ownsecretlist.Add(sec);
                    }

                    continue;
                }

                if (s.StartsWith("cthunbonus: "))
                {
                    var ss = s.Split(' ');
                    this.anzOgOwnCThunAngrBonus = Convert.ToInt32(ss[1]);
                    this.anzOgOwnCThunHpBonus = Convert.ToInt32(ss[2]);
                    this.anzOgOwnCThunTaunt = Convert.ToInt32(ss[3]);
                }

                if (s.StartsWith("jadegolems: "))
                {
                    var ss = s.Split(' ');
                    this.anzOwnJadeGolem = Convert.ToInt32(ss[1]);
                    this.anzEnemyJadeGolem = Convert.ToInt32(ss[2]);
                }

                if (s.StartsWith("elementals: "))
                {
                    var ss = s.Split(' ');
                    this.anzOwnElementalsThisTurn = Convert.ToInt32(ss[1]);
                    this.anzOwnElementalsLastTurn = Convert.ToInt32(ss[2]);
                    if (ss.Length > 3)
                    {
                        this.ownElementalsHaveLifesteal = ss[3] == "1" ? 1 : 0;
                    }
                }

                if (s.StartsWith("quests: "))
                {
                    var ss = s.Split(' ');
                    Questmanager.Instance.updateQuestStuff(ss[1], Convert.ToInt32(ss[2]), Convert.ToInt32(ss[3]), true);
                    Questmanager.Instance.updateQuestStuff(ss[4], Convert.ToInt32(ss[5]), Convert.ToInt32(ss[6]), false);
                }

                if (s.StartsWith("advanced: "))
                {
                    var ss = s.Split(' ');
                    this.ownCrystalCore = Convert.ToInt32(ss[1]);
                    this.ownMinionsInDeckCost0 = Convert.ToInt32(ss[2]) == 1 ? true : false;
                }

                if (s.StartsWith("ownDiedMinions: "))
                {
                    var temp = "";
                    temp = s.Replace("ownDiedMinions: ", "");

                    foreach (var str in temp.Split(';'))
                    {
                        if (str == "" || str == " ")
                        {
                            continue;
                        }

                        var id = str.Split(',')[0];
                        var ent = str.Split(',')[1];
                        var gyi = new GraveYardItem(id, Convert.ToInt32(ent), true);
                        this.turnGraveYard.Add(gyi);
                    }

                    continue;
                }

                if (s.StartsWith("enemyDiedMinions: "))
                {
                    var temp = "";
                    temp = s.Replace("enemyDiedMinions: ", "");

                    foreach (var str in temp.Split(';'))
                    {
                        if (str == "" || str == " ")
                        {
                            continue;
                        }

                        var id = str.Split(',')[0];
                        var ent = str.Split(',')[1];
                        var gyi = new GraveYardItem(id, Convert.ToInt32(ent), false);
                        this.turnGraveYard.Add(gyi);
                    }

                    continue;
                }

                if (s.StartsWith("otg: "))
                {
                    var temp = "";
                    temp = s.Replace("otg: ", "");

                    foreach (var str in temp.Split(';'))
                    {
                        if (str == "" || str == " ")
                        {
                            continue;
                        }

                        var id = str.Split(',')[0];
                        var ent = str.Split(',')[1];
                        var gyi = new GraveYardItem(id, Convert.ToInt32(ent), true);
                        this.turnGraveYardAll.Add(gyi);
                    }

                    continue;
                }

                if (s.StartsWith("etg: "))
                {
                    var temp = "";
                    temp = s.Replace("etg: ", "");

                    foreach (var str in temp.Split(';'))
                    {
                        if (str == "" || str == " ")
                        {
                            continue;
                        }

                        var id = str.Split(',')[0];
                        var ent = str.Split(',')[1];
                        var gyi = new GraveYardItem(id, Convert.ToInt32(ent), false);
                        this.turnGraveYardAll.Add(gyi);
                    }

                    continue;
                }

                if (s.StartsWith("og:"))
                {
                    var temp = s.Replace("og: ", "");
                    foreach (var tmp in temp.Split(';'))
                    {
                        if (tmp == "" || tmp == " ")
                        {
                            continue;
                        }

                        var id = tmp.Split(',')[0];
                        var anz = Convert.ToInt32(tmp.Split(',')[1]);
                        SimCard cide = id;
                        this.og.Add(cide, anz);
                    }

                    continue;
                }

                if (s.StartsWith("eg:"))
                {
                    var temp = s.Replace("eg: ", "");
                    foreach (var tmp in temp.Split(';'))
                    {
                        if (tmp == "" || tmp == " ")
                        {
                            continue;
                        }

                        var id = tmp.Split(',')[0];
                        var anz = Convert.ToInt32(tmp.Split(',')[1]);
                        SimCard cide = id;
                        this.eg.Add(cide, anz);
                    }

                    continue;
                }

                if (s.StartsWith("discover card:"))
                {
                    this.discover.Add(s.Split(' ')[2]);
                    this.discover.Add(s.Split(' ')[3]);
                    this.discover.Add(s.Split(' ')[4]);
                    this.discover.Add(s.Split(' ')[5]);
                    continue;
                }

                if (readstate == 42 && counter == 1) // player
                {
                    var ss = s.Split(' ');
                    this.numMinionsPlayedThisTurn = Convert.ToInt32(ss[0]);
                    this.cardsPlayedThisTurn = Convert.ToInt32(ss[1]);
                    this.overload = Convert.ToInt32(ss[2]);
                    if (ss.Length == 5)
                    {
                        this.ownPlayer = Convert.ToInt32(ss[3]);
                    }
                    else
                    {
                        this.lockedMana = Convert.ToInt32(ss[3]);
                        this.ownPlayer = Convert.ToInt32(ss[4]);
                    }
                }

                if (readstate == 1 && counter == 1) // class + hp + defence + immunewhile attacking + immune
                {
                    var h = s.Split(' ');
                    this.ownHero.CardClass = h[0].ParseEnum<CardClass>();
                    this.ownherohp = Convert.ToInt32(h[1]);
                    this.ownheromaxhp = Convert.ToInt32(h[2]);
                    this.ownherodefence = Convert.ToInt32(h[3]);
                    this.ownHeroimmunewhileattacking = h[4] == "True" ? true : false;
                    this.heroImmune = h[5] == "True" ? true : false;
                    this.ownHEntity = Convert.ToInt32(h[6]);
                    this.ownheroready = h[7] == "True" ? true : false;
                    this.ownheroattacksThisRound = Convert.ToInt32(h[8]);
                    this.ownHeroFrozen = h[9] == "True" ? true : false;
                    this.ownHeroAttack = Convert.ToInt32(h[10]);
                    this.ownHeroTempAttack = Convert.ToInt32(h[11]);
                    if (h.Length > 12)
                    {
                        this.ownHeroStealth = h[12] == "True" ? true : false;
                    }
                }

                if (readstate == 1 && counter == 2) // own hero weapon
                {
                    var w = s.Split(' ');

                    this.ownWeapon = new Weapon();
                    var d = Convert.ToInt32(w[2]);
                    if (d > 0)
                    {
                        if (w.Length > 5)
                        {
                            this.ownWeapon.equip(w[4]);
                            if (w.Length > 6)
                            {
                                this.ownWeapon.poisonous = w[5] == "1" ? true : false;
                            }

                            if (w.Length > 7)
                            {
                                this.ownWeapon.lifesteal = w[6] == "1" ? true : false;
                            }
                        }
                        else
                        {
                            this.ownWeapon.equip(w[3]);
                        }
                    }

                    this.ownWeapon.Angr = Convert.ToInt32(w[1]);
                    this.ownWeapon.Durability = Convert.ToInt32(w[2]);
                }

                if (readstate == 1 && counter == 3) // ability + abilityready
                {
                    abilityReady = s.Split(' ')[1] == "True";
                    heroability = s.Split(' ')[2];
                }

                if (readstate == 1 && counter >= 5) // secrets
                {
                    if (!(s.StartsWith("enemyhero:") || s.StartsWith("cthunbonus:") || s.StartsWith("jadegolems:") || s.StartsWith("elementals:") || s.StartsWith("quests:") || s.StartsWith("advanced:")))
                    {
                        this.ownsecretlist.Add(s.Replace(" ", ""));
                    }
                }

                if (readstate == 2 && counter == 1) // class + hp + defence + frozen + immune
                {
                    var h = s.Split(' ');
                    this.enemyHero.CardClass = h[0].ParseEnum<CardClass>();
                    this.enemyherohp = Convert.ToInt32(h[1]);
                    this.enemyheromaxhp = Convert.ToInt32(h[2]);
                    this.enemyherodefence = Convert.ToInt32(h[3]);
                    this.enemyFrozen = h[4] == "True" ? true : false;
                    this.enemyHeroImmune = h[5] == "True" ? true : false;
                    this.enemyHEntity = Convert.ToInt32(h[6]);
                    if (h.Length > 7)
                    {
                        this.enemyHeroStealth = h[7] == "True" ? true : false;
                    }
                }

                if (readstate == 2 && counter == 2) // weapon + stuff
                {
                    var w = s.Split(' ');

                    this.enemyWeapon = new Weapon();
                    var d = Convert.ToInt32(w[2]);
                    if (d > 0)
                    {
                        if (w.Length > 5)
                        {
                            this.enemyWeapon.equip(w[4]);
                            if (w.Length > 6)
                            {
                                this.enemyWeapon.poisonous = w[5] == "1" ? true : false;
                            }

                            if (w.Length > 7)
                            {
                                this.enemyWeapon.lifesteal = w[6] == "1" ? true : false;
                            }
                        }
                        else
                        {
                            this.enemyWeapon.equip(w[3]);
                        }
                    }

                    this.enemyWeapon.Angr = Convert.ToInt32(w[1]);
                    this.enemyWeapon.Durability = Convert.ToInt32(w[2]);
                }

                if (readstate == 2 && counter == 3) // ability
                {
                    enemyability = s.Split(' ')[2];
                }

                if (readstate == 2 && counter == 4) // fatigue
                {
                    this.ownDecksize = Convert.ToInt32(s.Split(' ')[1]);
                    this.enemyDecksize = Convert.ToInt32(s.Split(' ')[3]);
                    this.ownFatigue = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemyFatigue = Convert.ToInt32(s.Split(' ')[4]);
                }

                if (readstate == 3) // minion + enchantment
                {
                    if (s.Contains(" zp:"))
                    {
                        var minionname = s.Split(' ')[0];
                        var minionid = s.Split(' ')[1];
                        var zp = Convert.ToInt32(s.Split(new[] {" zp:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        var ent = 1000 + j;
                        if (s.Contains(" e:"))
                        {
                            ent = Convert.ToInt32(s.Split(new[] {" e:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        }

                        var attack = Convert.ToInt32(s.Split(new[] {" A:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        var hp = Convert.ToInt32(s.Split(new[] {" H:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        var maxhp = Convert.ToInt32(s.Split(new[] {" mH:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        var ready = s.Split(new[] {" rdy:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True";
                        if (s.Contains(" respawn:"))
                        {
                            var tmp = s.Split(new[] {" respawn:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0].Split(':');
                            this.LurkersDB.Add(ent, new IDEnumOwner {IDEnum = tmp[0], own = tmp[1] == "True" ? true : false});
                        }

                        var natt = 0;
                        if (s.Contains(" natt:"))
                        {
                            natt = Convert.ToInt32(s.Split(new[] {" natt:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        }

                        var hChoice = 0; //hidden choice
                        if (s.Contains(" hChoice:"))
                        {
                            hChoice = Convert.ToInt32(s.Split(new[] {" hChoice:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        }

                        // optional params (bools)
                        var ex = s.Contains(" ex");
                        var taunt = s.Contains(" tnt");
                        var frzn = s.Contains(" frz");
                        var silenced = s.Contains(" silenced");
                        var divshield = s.Contains(" divshield");
                        var ptt = s.Contains(" ptt");
                        var wndfry = s.Contains(" wndfr");
                        var stl = s.Contains(" stlth");
                        var pois = s.Contains(" poi");
                        var lfst = s.Contains(" lfst");
                        var immn = s.Contains(" imm");
                        var untch = s.Contains(" untch");
                        var cncdl = s.Contains(" cncdl");
                        var destroyOnOwnTurnStart = s.Contains(" dstrOwnTrnStrt");
                        var destroyOnOwnTurnEnd = s.Contains(" dstrOwnTrnnd");
                        var destroyOnEnemyTurnStart = s.Contains(" dstrEnmTrnStrt");
                        var destroyOnEnemyTurnEnd = s.Contains(" dstrEnmTrnnd");
                        var shadowmadnessed = s.Contains(" shdwmdnssd");
                        var cntlower = s.Contains(" cantLowerHpBelowOne");
                        var cbtBySpells = s.Contains(" cbtBySpells");
                        //optional params (ints)


                        var chrg = 0; //charge
                        if (s.Contains(" chrg("))
                        {
                            chrg = Convert.ToInt32(s.Split(new[] {" chrg("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var adjadmg = 0; //adjadmg
                        if (s.Contains(" adjaattk("))
                        {
                            adjadmg = Convert.ToInt32(s.Split(new[] {" adjaattk("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var tmpdmg = 0; //adjadmg
                        if (s.Contains(" tmpattck("))
                        {
                            tmpdmg = Convert.ToInt32(s.Split(new[] {" tmpattck("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var spllpwr = 0; //adjadmg
                        if (s.Contains(" spllpwr("))
                        {
                            spllpwr = Convert.ToInt32(s.Split(new[] {" spllpwr("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var ancestralspirit = 0; //adjadmg
                        if (s.Contains(" ancstrl("))
                        {
                            ancestralspirit = Convert.ToInt32(s.Split(new[] {" ancstrl("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var desperatestand = 0; //adjadmg
                        if (s.Contains(" despStand("))
                        {
                            desperatestand = Convert.ToInt32(s.Split(new[] {" despStand("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var ownBlessingOfWisdom = 0; //adjadmg
                        if (s.Contains(" ownBlssng("))
                        {
                            ownBlessingOfWisdom = Convert.ToInt32(s.Split(new[] {" ownBlssng("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var enemyBlessingOfWisdom = 0; //adjadmg
                        if (s.Contains(" enemyBlssng("))
                        {
                            enemyBlessingOfWisdom = Convert.ToInt32(s.Split(new[] {" enemyBlssng("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var ownPowerWordGlory = 0; //adjadmg
                        if (s.Contains(" ownGlory("))
                        {
                            ownPowerWordGlory = Convert.ToInt32(s.Split(new[] {" ownGlory("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var enemyPowerWordGlory = 0; //adjadmg
                        if (s.Contains(" enemyGlory("))
                        {
                            enemyPowerWordGlory = Convert.ToInt32(s.Split(new[] {" enemyGlory("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var souloftheforest = 0; //adjadmg
                        if (s.Contains(" souloffrst("))
                        {
                            souloftheforest = Convert.ToInt32(s.Split(new[] {" souloffrst("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var stegodon = 0; //adjadmg
                        if (s.Contains(" stegodon("))
                        {
                            stegodon = Convert.ToInt32(s.Split(new[] {" stegodon("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var livingspores = 0; //adjadmg
                        if (s.Contains(" lspores("))
                        {
                            livingspores = Convert.ToInt32(s.Split(new[] {" lspores("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var explorershat = 0; //adjadmg
                        if (s.Contains(" explHat("))
                        {
                            explorershat = Convert.ToInt32(s.Split(new[] {" explHat("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var returnToHand = 0; //adjadmg
                        if (s.Contains(" retHand("))
                        {
                            returnToHand = Convert.ToInt32(s.Split(new[] {" retHand("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var infest = 0; //adjadmg
                        if (s.Contains(" infest("))
                        {
                            infest = Convert.ToInt32(s.Split(new[] {" infest("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        SimCard deathrattle2 = null;
                        if (s.Contains(" dethrl("))
                        {
                            deathrattle2 = s.Split(new[] {" dethrl("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0];
                        }


                        tempminion = this.createNewMinion(new Handcard(minionid), zp, true);
                        tempminion.own = true;
                        tempminion.entitiyID = ent;
                        tempminion.handcard.entity = ent;
                        tempminion.Angr = attack;
                        tempminion.Hp = hp;
                        tempminion.maxHp = maxhp;
                        tempminion.Ready = ready;
                        tempminion.numAttacksThisTurn = natt;
                        tempminion.exhausted = ex;
                        tempminion.taunt = taunt;
                        tempminion.frozen = frzn;
                        tempminion.silenced = silenced;
                        tempminion.divineshild = divshield;
                        tempminion.playedThisTurn = ptt;
                        tempminion.windfury = wndfry;
                        tempminion.stealth = stl;
                        tempminion.poisonous = pois;
                        tempminion.lifesteal = lfst;
                        tempminion.immune = immn;
                        tempminion.untouchable = untch;
                        tempminion.conceal = cncdl;
                        tempminion.destroyOnOwnTurnStart = destroyOnOwnTurnStart;
                        tempminion.destroyOnOwnTurnEnd = destroyOnOwnTurnEnd;
                        tempminion.destroyOnEnemyTurnStart = destroyOnEnemyTurnStart;
                        tempminion.destroyOnEnemyTurnEnd = destroyOnEnemyTurnEnd;
                        tempminion.shadowmadnessed = shadowmadnessed;
                        tempminion.cantLowerHPbelowONE = cntlower;
                        tempminion.cantBeTargetedBySpellsOrHeroPowers = cbtBySpells;

                        tempminion.charge = chrg;
                        tempminion.hChoice = hChoice;
                        tempminion.AdjacentAngr = adjadmg;
                        tempminion.tempAttack = tmpdmg;
                        tempminion.spellpower = spllpwr;

                        tempminion.ancestralspirit = ancestralspirit;
                        tempminion.desperatestand = desperatestand;
                        tempminion.ownBlessingOfWisdom = ownBlessingOfWisdom;
                        tempminion.enemyBlessingOfWisdom = enemyBlessingOfWisdom;
                        tempminion.ownPowerWordGlory = ownPowerWordGlory;
                        tempminion.enemyPowerWordGlory = enemyPowerWordGlory;
                        tempminion.souloftheforest = souloftheforest;
                        tempminion.stegodon = stegodon;
                        tempminion.livingspores = livingspores;
                        tempminion.explorershat = explorershat;
                        tempminion.returnToHand = returnToHand;
                        tempminion.infest = infest;
                        tempminion.deathrattle2 = deathrattle2;

                        if (maxhp > hp)
                        {
                            tempminion.wounded = true;
                        }

                        tempminion.updateReadyness();
                        this.ownminions.Add(tempminion);
                    }
                }

                if (readstate == 4) // minion or enchantment
                {
                    if (s.Contains(" zp:"))
                    {
                        var minionname = s.Split(' ')[0];
                        var minionid = s.Split(' ')[1];
                        var zp = Convert.ToInt32(s.Split(new[] {" zp:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        var ent = 1000 + j;
                        if (s.Contains(" e:"))
                        {
                            ent = Convert.ToInt32(s.Split(new[] {" e:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        }

                        var attack = Convert.ToInt32(s.Split(new[] {" A:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        var hp = Convert.ToInt32(s.Split(new[] {" H:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        var maxhp = Convert.ToInt32(s.Split(new[] {" mH:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        var ready = s.Split(new[] {" rdy:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        var natt = 0;
                        //if (s.Contains(" natt:")) natt = Convert.ToInt32(s.Split(new string[] { " natt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        var hChoice = 0; //hidden choice
                        if (s.Contains(" hChoice:"))
                        {
                            hChoice = Convert.ToInt32(s.Split(new[] {" hChoice:"}, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        }

                        // optional params (bools)
                        var ex = s.Contains(" ex");
                        var taunt = s.Contains(" tnt");
                        var frzn = s.Contains(" frz");
                        var silenced = s.Contains(" silenced");
                        var divshield = s.Contains(" divshield");
                        var ptt = s.Contains(" ptt");
                        var wndfry = s.Contains(" wndfr");
                        var stl = s.Contains(" stlth");
                        var pois = s.Contains(" poi");
                        var lfst = s.Contains(" lfst");
                        var immn = s.Contains(" imm");
                        var untch = s.Contains(" untch");
                        var cncdl = s.Contains(" cncdl");
                        var destroyOnOwnTurnStart = s.Contains(" dstrOwnTrnStrt");
                        var destroyOnOwnTurnEnd = s.Contains(" dstrOwnTrnnd");
                        var destroyOnEnemyTurnStart = s.Contains(" dstrEnmTrnStrt");
                        var destroyOnEnemyTurnEnd = s.Contains(" dstrEnmTrnnd");
                        var shadowmadnessed = s.Contains(" shdwmdnssd");
                        var cntlower = s.Contains(" cantLowerHpBelowOne");
                        var cbtBySpells = s.Contains(" cbtBySpells");
                        //optional params (ints)


                        var chrg = 0; //charge
                        if (s.Contains(" chrg("))
                        {
                            chrg = Convert.ToInt32(s.Split(new[] {" chrg("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var adjadmg = 0; //adjadmg
                        if (s.Contains(" adjaattk("))
                        {
                            adjadmg = Convert.ToInt32(s.Split(new[] {" adjaattk("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var tmpdmg = 0; //adjadmg
                        if (s.Contains(" tmpattck("))
                        {
                            tmpdmg = Convert.ToInt32(s.Split(new[] {" tmpattck("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var spllpwr = 0; //adjadmg
                        if (s.Contains(" spllpwr("))
                        {
                            spllpwr = Convert.ToInt32(s.Split(new[] {" spllpwr("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var ancestralspirit = 0; //adjadmg
                        if (s.Contains(" ancstrl("))
                        {
                            ancestralspirit = Convert.ToInt32(s.Split(new[] {" ancstrl("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var desperatestand = 0; //adjadmg
                        if (s.Contains(" despStand("))
                        {
                            desperatestand = Convert.ToInt32(s.Split(new[] {" despStand("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var ownBlessingOfWisdom = 0; //adjadmg
                        if (s.Contains(" ownBlssng("))
                        {
                            ownBlessingOfWisdom = Convert.ToInt32(s.Split(new[] {" ownBlssng("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var enemyBlessingOfWisdom = 0; //adjadmg
                        if (s.Contains(" enemyBlssng("))
                        {
                            enemyBlessingOfWisdom = Convert.ToInt32(s.Split(new[] {" enemyBlssng("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var ownPowerWordGlory = 0; //adjadmg
                        if (s.Contains(" ownGlory("))
                        {
                            ownPowerWordGlory = Convert.ToInt32(s.Split(new[] {" ownGlory("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var enemyPowerWordGlory = 0; //adjadmg
                        if (s.Contains(" enemyGlory("))
                        {
                            enemyPowerWordGlory = Convert.ToInt32(s.Split(new[] {" enemyGlory("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var souloftheforest = 0; //adjadmg
                        if (s.Contains(" souloffrst("))
                        {
                            souloftheforest = Convert.ToInt32(s.Split(new[] {" souloffrst("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var stegodon = 0; //adjadmg
                        if (s.Contains(" stegodon("))
                        {
                            stegodon = Convert.ToInt32(s.Split(new[] {" stegodon("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var livingspores = 0; //adjadmg
                        if (s.Contains(" lspores("))
                        {
                            livingspores = Convert.ToInt32(s.Split(new[] {" lspores("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var explorershat = 0; //adjadmg
                        if (s.Contains(" explHat("))
                        {
                            explorershat = Convert.ToInt32(s.Split(new[] {" explHat("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var returnToHand = 0; //adjadmg
                        if (s.Contains(" retHand("))
                        {
                            returnToHand = Convert.ToInt32(s.Split(new[] {" retHand("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        var infest = 0; //adjadmg
                        if (s.Contains(" infest("))
                        {
                            infest = Convert.ToInt32(s.Split(new[] {" infest("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        }

                        SimCard deathrattle2 = null;
                        if (s.Contains(" dethrl("))
                        {
                            deathrattle2 = s.Split(new[] {" dethrl("}, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0];
                        }


                        tempminion = this.createNewMinion(new Handcard(minionid), zp, false);
                        tempminion.own = false;
                        tempminion.entitiyID = ent;
                        tempminion.handcard.entity = ent;
                        tempminion.Angr = attack;
                        tempminion.Hp = hp;
                        tempminion.maxHp = maxhp;
                        tempminion.Ready = ready;
                        tempminion.numAttacksThisTurn = natt;
                        tempminion.exhausted = ex;
                        tempminion.taunt = taunt;
                        tempminion.frozen = frzn;
                        tempminion.silenced = silenced;
                        tempminion.divineshild = divshield;
                        tempminion.playedThisTurn = ptt;
                        tempminion.windfury = wndfry;
                        tempminion.stealth = stl;
                        tempminion.poisonous = pois;
                        tempminion.lifesteal = lfst;
                        tempminion.immune = immn;
                        tempminion.untouchable = untch;
                        tempminion.conceal = cncdl;
                        tempminion.destroyOnOwnTurnStart = destroyOnOwnTurnStart;
                        tempminion.destroyOnOwnTurnEnd = destroyOnOwnTurnEnd;
                        tempminion.destroyOnEnemyTurnStart = destroyOnEnemyTurnStart;
                        tempminion.destroyOnEnemyTurnEnd = destroyOnEnemyTurnEnd;
                        tempminion.shadowmadnessed = shadowmadnessed;
                        tempminion.cantLowerHPbelowONE = cntlower;
                        tempminion.cantBeTargetedBySpellsOrHeroPowers = cbtBySpells;

                        tempminion.charge = chrg;
                        tempminion.hChoice = hChoice;
                        tempminion.AdjacentAngr = adjadmg;
                        tempminion.tempAttack = tmpdmg;
                        tempminion.spellpower = spllpwr;

                        tempminion.ancestralspirit = ancestralspirit;
                        tempminion.desperatestand = desperatestand;
                        tempminion.ownBlessingOfWisdom = ownBlessingOfWisdom;
                        tempminion.enemyBlessingOfWisdom = enemyBlessingOfWisdom;
                        tempminion.ownPowerWordGlory = ownPowerWordGlory;
                        tempminion.enemyPowerWordGlory = enemyPowerWordGlory;
                        tempminion.souloftheforest = souloftheforest;
                        tempminion.stegodon = stegodon;
                        tempminion.livingspores = livingspores;
                        tempminion.explorershat = explorershat;
                        tempminion.returnToHand = returnToHand;
                        tempminion.infest = infest;
                        tempminion.deathrattle2 = deathrattle2;

                        if (maxhp > hp)
                        {
                            tempminion.wounded = true;
                        }

                        tempminion.updateReadyness();
                        this.enemyminions.Add(tempminion);
                    }
                }

                if (readstate == 5) // minion or enchantment
                {
                    var card = new Handcard();

                    var hc = s.Split(' ');
                    card.position = Convert.ToInt32(hc[1]);
                    var minionname = hc[2];
                    card.manacost = Convert.ToInt32(hc[3]);
                    card.entity = Convert.ToInt32(hc[5]);
                    card.card = hc[6];
                    if (hc.Length > 8)
                    {
                        card.addattack = Convert.ToInt32(hc[7]);
                    }

                    if (hc.Length > 9)
                    {
                        card.addHp = Convert.ToInt32(hc[8]);
                    }

                    if (hc.Length > 10)
                    {
                        card.elemPoweredUp = Convert.ToInt32(hc[9]);
                    }

                    this.handcards.Add(card);
                }


                if (s.StartsWith("ownhero:"))
                {
                    readstate = 1;
                    counter = 0;
                }

                if (s.StartsWith("enemyhero:"))
                {
                    readstate = 2;
                    counter = 0;
                }

                if (s.StartsWith("OwnMinions:"))
                {
                    readstate = 3;
                    counter = 0;
                }

                if (s.StartsWith("EnemyMinions:"))
                {
                    readstate = 4;
                    counter = 0;
                }

                if (s.StartsWith("Own Handcards:"))
                {
                    readstate = 5;
                    counter = 0;
                }

                if (s.StartsWith("player:"))
                {
                    readstate = 42;
                    counter = 0;
                }


                counter++;
                j++;
            }

            Helpfunctions.Instance.logg("rdy");

            //Set default settings for behaviour
            Settings.Instance.setSettings(this.botBehavior);
            Settings.Instance.test = true;

            //Apply settings from this UILogg
            Hrtprozis.Instance.setAttackFaceHP(facehp);
            ComboBreaker.Instance.attackFaceHP = facehp;
            Settings.Instance.enfacehp = facehp;
            Settings.Instance.weaponOnlyAttackMobsUntilEnfacehp = weaponOnlyAttackMobsUntilEnfacehp;
            Settings.Instance.berserkIfCanFinishNextTour = berserkIfCanFinishNextTour;
            Settings.Instance.concedeMode = concedeMode;
            Settings.Instance.enemyTurnMaxWide = ets;
            Settings.Instance.enemyTurnMaxWideSecondStep = ets2;
            Settings.Instance.placement = placement;
            Settings.Instance.nextTurnDeep = ntssd;
            Settings.Instance.nextTurnMaxWide = ntssw;
            Settings.Instance.nextTurnTotalBoards = ntssm;
            Settings.Instance.ImprovedCalculations = iC;
            Settings.Instance.speedupLevel = speedup;
            Settings.Instance.adjustActions = adjustActions;
            Settings.Instance.useSecretsPlayAround = dosecrets;
            Settings.Instance.setWeights(alpha);
            Settings.Instance.playaround = this.playaround;
            Settings.Instance.playaroundprob = this.pprob1;
            Settings.Instance.playaroundprob2 = this.pprob2;


            //set Simulation stuff
            Ai.Instance.botBase = Silverfish.Instance.getBehaviorByName(this.botBehavior);
            RulesEngine.Instance.setCardIdRulesGame(this.ownHero.CardClass, this.enemyHero.CardClass);
            RulesEngine.Instance.setRulesTurn((this.gTurn + 1) / 2);
            Ai.Instance.setMaxWide(this.maxwide);
            Ai.Instance.setTwoTurnSimulation(false, this.twoturnsim);
            Ai.Instance.setPlayAround();


            Hrtprozis.Instance.setOwnPlayer(this.ownPlayer);
            Handmanager.Instance.setOwnPlayer(this.ownPlayer);

            this.numOptionPlayedThisTurn = 0;
            this.numOptionPlayedThisTurn += this.cardsPlayedThisTurn + this.ownheroattacksThisRound;
            foreach (var m in this.ownminions)
            {
                this.numOptionPlayedThisTurn += m.numAttacksThisTurn;
            }

            Hrtprozis.Instance.updateTurnInfo(this.gTurn, this.gTurnStep);
            Hrtprozis.Instance.updatePlayer(this.maxmana, this.mana, this.cardsPlayedThisTurn, this.numMinionsPlayedThisTurn, this.numOptionPlayedThisTurn, this.overload, this.lockedMana, this.ownHEntity, this.enemyHEntity);
            Hrtprozis.Instance.updateSecretStuff(this.ownsecretlist, this.enemySecretAmount);
            Hrtprozis.Instance.updateCThunInfo(this.anzOgOwnCThunAngrBonus, this.anzOgOwnCThunHpBonus, this.anzOgOwnCThunTaunt);
            Hrtprozis.Instance.updateJadeGolemsInfo(this.anzOwnJadeGolem, this.anzEnemyJadeGolem);
            Hrtprozis.Instance.updateElementals(this.anzOwnElementalsThisTurn, this.anzOwnElementalsLastTurn, this.ownElementalsHaveLifesteal);
            Hrtprozis.Instance.updateCrystalCore(this.ownCrystalCore);
            Hrtprozis.Instance.updateOwnMinionsInDeckCost0(this.ownMinionsInDeckCost0);
            Hrtprozis.Instance.updateDiscoverCards(this.discover);

            var herowindfury = false;
            if (this.ownWeapon.windfury)
            {
                herowindfury = true;
            }

            //create heros:

            this.ownHero = new Minion();
            this.enemyHero = new Minion();
            this.ownHero.isHero = true;
            this.enemyHero.isHero = true;
            this.ownHero.own = true;
            this.enemyHero.own = false;
            this.ownHero.maxHp = this.ownheromaxhp;
            this.enemyHero.maxHp = this.enemyheromaxhp;
            this.ownHero.entitiyID = this.ownHEntity;
            this.enemyHero.entitiyID = this.enemyHEntity;
            this.ownHero.CardClass = this.ownHero.CardClass;
            this.enemyHero.CardClass = this.enemyHero.CardClass;

            this.ownHero.Angr = this.ownHeroAttack;
            this.ownHero.Hp = this.ownherohp;
            this.ownHero.armor = this.ownherodefence;
            this.ownHero.frozen = this.ownHeroFrozen;
            this.ownHero.immuneWhileAttacking = this.ownHeroimmunewhileattacking;
            this.ownHero.immune = this.heroImmune;
            this.ownHero.numAttacksThisTurn = this.ownheroattacksThisRound;
            this.ownHero.windfury = herowindfury;
            this.ownHero.stealth = this.ownHeroStealth;

            this.enemyHero.Angr = this.enemyWeapon.Angr;
            this.enemyHero.Hp = this.enemyherohp;
            this.enemyHero.frozen = this.enemyFrozen;
            this.enemyHero.armor = this.enemyherodefence;
            this.enemyHero.immune = this.enemyHeroImmune;
            this.enemyHero.stealth = this.enemyHeroStealth;
            this.enemyHero.Ready = false;

            this.ownHero.updateReadyness();


            //save data
            Hrtprozis.Instance.updateHero(this.ownWeapon, this.ownHero.CardClass, heroability, abilityReady, this.ownHeroPowerCost, this.ownHero);
            Hrtprozis.Instance.updateHero(this.enemyWeapon, this.enemyHero.CardClass, enemyability, false, this.enemyHeroPowerCost, this.enemyHero, this.enemmaxman);
            Hrtprozis.Instance.updateHeroStartClass(this.ownHero.CardClass, this.enemyHero.CardClass);

            Hrtprozis.Instance.updateMinions(this.ownminions, this.enemyminions);
            Hrtprozis.Instance.updateLurkersDB(this.LurkersDB);

            Hrtprozis.Instance.updateFatigueStats(this.ownDecksize, this.ownFatigue, this.enemyDecksize, this.enemyFatigue);

            Handmanager.Instance.setHandcards(this.handcards, this.handcards.Count, this.enemyNumberHand);

            Probabilitymaker.Instance.setEnemySecretData(this.enemySecrets);

            Probabilitymaker.Instance.setTurnGraveYard(this.turnGraveYard, this.turnGraveYardAll);
            Probabilitymaker.Instance.stalaggDead = this.stalaggdead;
            Probabilitymaker.Instance.feugenDead = this.feugendead;

            Probabilitymaker.Instance.setOwnCardsOut(this.og);
            Probabilitymaker.Instance.setEnemyCardsOut(this.eg);
        }


        public Minion createNewMinion(Handcard hc, int zonepos, bool own)
        {
            var m = new Minion
            {
                handcard = new Handcard(hc),
                zonepos = zonepos,
                entitiyID = hc.entity,
                Angr = hc.card.Attack,
                Hp = hc.card.Health,
                maxHp = hc.card.Health,
                name = hc.card,
                playedThisTurn = true,
                numAttacksThisTurn = 0
            };

            m.own = own;
            m.isHero = false;
            m.entitiyID = hc.entity;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.windfury = hc.card.Windfury;
            m.taunt = hc.card.Taunt;
            m.charge = hc.card.Charge ? 1 : 0;
            m.divineshild = hc.card.DivineShield;
            m.poisonous = hc.card.Poisonous;
            m.lifesteal = hc.card.Lifesteal;
            m.stealth = hc.card.Stealth;

            if (own)
            {
                m.synergy = PenalityManager.Instance.getClassRacePriorityPenality(this.ownHero.CardClass, hc.card.Race);
            }
            else
            {
                m.synergy = PenalityManager.Instance.getClassRacePriorityPenality(this.enemyHero.CardClass, hc.card.Race);
            }

            if (m.synergy > 0 && hc.card.Stealth)
            {
                m.synergy++;
            }

            m.updateReadyness();

            if (m.name == CardIds.Collectible.Priest.Lightspawn)
            {
                m.Angr = m.Hp;
            }

            return m;
        }

        public void printSettings()
        {
            Helpfunctions.Instance.logg("#################### Settings #########################################");
            Helpfunctions.Instance.logg($"path = {Settings.Instance.path}");
            Helpfunctions.Instance.logg($"logpath = {Settings.Instance.logpath}");
            Helpfunctions.Instance.logg($"logfile = {Settings.Instance.logfile}");
            Helpfunctions.Instance.logg($"twotsamount = {Settings.Instance.twotsamount}");
            Helpfunctions.Instance.logg($"secondTurnAmount = {Settings.Instance.secondTurnAmount}");
            Helpfunctions.Instance.logg($"playaroundprob2 = {Settings.Instance.playaroundprob2}");
            Helpfunctions.Instance.logg($"playaroundprob = {Settings.Instance.playaroundprob}");
            Helpfunctions.Instance.logg($"nextTurnTotalBoards = {Settings.Instance.nextTurnTotalBoards}");
            Helpfunctions.Instance.logg($"nextTurnMaxWide = {Settings.Instance.nextTurnMaxWide}");
            Helpfunctions.Instance.logg($"nextTurnDeep = {Settings.Instance.nextTurnDeep}");
            Helpfunctions.Instance.logg($"maxwide = {Settings.Instance.maxwide}");
            Helpfunctions.Instance.logg($"enfacehp = {Settings.Instance.enfacehp}");
            Helpfunctions.Instance.logg(
                $"weaponOnlyAttackMobsUntilEnfacehp = {Settings.Instance.weaponOnlyAttackMobsUntilEnfacehp}");
            Helpfunctions.Instance.logg($"enemyTurnMaxWideSecondStep = {Settings.Instance.enemyTurnMaxWideSecondStep}");
            Helpfunctions.Instance.logg($"enemyTurnMaxWide = {Settings.Instance.enemyTurnMaxWide}");
            Helpfunctions.Instance.logg($"alpha = {Settings.Instance.alpha}");
            Helpfunctions.Instance.logg($"secondweight = {Settings.Instance.secondweight}");
            Helpfunctions.Instance.logg($"firstweight = {Settings.Instance.firstweight}");
            Helpfunctions.Instance.logg($"writeToSingleFile = {Settings.Instance.writeToSingleFile}");
            Helpfunctions.Instance.logg($"useSecretsPlayAround = {Settings.Instance.useSecretsPlayAround}");
            Helpfunctions.Instance.logg($"useExternalProcess = {Settings.Instance.useExternalProcess}");
            Helpfunctions.Instance.logg($"placement = {Settings.Instance.placement}");
            Helpfunctions.Instance.logg($"simulateEnemysTurn = {Settings.Instance.simulateEnemysTurn}");
            Helpfunctions.Instance.logg($"printlearnmode = {Settings.Instance.printlearnmode}");
            Helpfunctions.Instance.logg($"playaround = {Settings.Instance.playaround}");
            Helpfunctions.Instance.logg($"passiveWaiting = {Settings.Instance.passiveWaiting}");
            Helpfunctions.Instance.logg($"learnmode = {Settings.Instance.learnmode}");
            Helpfunctions.Instance.logg($"enemyConcede = {Settings.Instance.enemyConcede}");
            Helpfunctions.Instance.logg($"concede = {Settings.Instance.concede}");
            Helpfunctions.Instance.logg($"ImprovedCalculations = {Settings.Instance.ImprovedCalculations}");
            Helpfunctions.Instance.logg($"speedupLevel = {Settings.Instance.speedupLevel}");
            Helpfunctions.Instance.logg($"adjustActions = {Settings.Instance.adjustActions}");
            Helpfunctions.Instance.logg("#################### Settings End #####################################");
        }
    }
}