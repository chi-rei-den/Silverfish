using System.Collections.Generic;
using Chireiden.Silverfish;

namespace HREngine.Bots
{
    public class Handmanager
    {
        public List<Handcard> handCards = new List<Handcard>();

        public int anzcards;

        public int enemyAnzCards;

        private int ownPlayerController;

        Helpfunctions help;

        private static Handmanager instance;

        public static Handmanager Instance
        {
            get
            {
                return instance ?? (instance = new Handmanager());
            }
        }


        private Handmanager()
        {
            this.help = Helpfunctions.Instance;
        }

        public void clearAllRecalc()
        {
            this.handCards.Clear();
            this.anzcards = 0;
            this.enemyAnzCards = 0;
            this.ownPlayerController = 0;
        }

        public void setOwnPlayer(int player)
        {
            this.ownPlayerController = player;
        }


        public void setHandcards(List<Handcard> hc, int anzown, int anzenemy)
        {
            this.handCards.Clear();
            foreach (var h in hc)
            {
                this.handCards.Add(new Handcard(h));
            }

            //this.handCards.AddRange(hc);
            this.handCards.Sort((a, b) => a.position.CompareTo(b.position));
            this.anzcards = anzown;
            this.enemyAnzCards = anzenemy;
        }

        public void printcards()
        {
            this.help.logg("Own Handcards: ");
            foreach (var hc in this.handCards)
            {
                this.help.logg(
                    $"pos {hc.position} {hc.card.CardId} {hc.manacost} entity {hc.entity} {hc.card.CardId} {hc.addattack} {hc.addHp} {hc.elemPoweredUp}");
            }

            this.help.logg($"Enemy cards: {this.enemyAnzCards}");
        }
    }

    public class Handcard
    {
        public int position;
        public int entity = -1;
        public int manacost = 1000;
        public int addattack;
        public int addHp;
        public SimCard card;
        public Minion target;
        public int elemPoweredUp;
        public int extraParam2 = 0;
        public bool filterPass = false;

        public Handcard()
        {
            this.card = SimCard.None;
        }

        public Handcard(Handcard hc)
        {
            this.position = hc.position;
            this.entity = hc.entity;
            this.manacost = hc.manacost;
            this.card = hc.card;
            this.addattack = hc.addattack;
            this.addHp = hc.addHp;
            this.elemPoweredUp = hc.elemPoweredUp;
        }

        public Handcard(SimCard c)
        {
            this.position = 0;
            this.entity = -1;
            this.card = c;
            this.addattack = 0;
            this.addHp = 0;
        }

        public void setHCtoHC(Handcard hc)
        {
            this.manacost = hc.manacost;
            this.addattack = hc.addattack;
            this.addHp = hc.addHp;
            this.card = hc.card;
            this.elemPoweredUp = hc.elemPoweredUp;
        }

        public int getManaCost(Playfield p)
        {
            return this.card.getManaCost(p, this.manacost);
        }

        public bool canplayCard(Playfield p, bool own)
        {
            return this.card.canplayCard(p, this.manacost, own);
        }
    }
}