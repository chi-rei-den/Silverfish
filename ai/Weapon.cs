using Chireiden.Silverfish;
using HearthDb;

namespace HREngine.Bots
{
    public class Weapon
    {
        public int pID = 0;
        public SimCard name = SimCard.None;
        public SimCard card;
        public int numAttacksThisTurn;

        public int Angr;
        public int Durability;

        public bool windfury;
        public bool immune;
        public bool lifesteal;
        public bool poisonous;
        public bool cantAttackHeroes;

        public Weapon()
        {
            this.card = SimCard.None;
        }

        public Weapon(Weapon w)
        {
            this.name = w.name;
            this.card = w.card;
            this.numAttacksThisTurn = w.numAttacksThisTurn;

            this.Angr = w.Angr;
            this.Durability = w.Durability;

            this.windfury = w.windfury;
            this.immune = w.immune;
            this.lifesteal = w.lifesteal;
            this.poisonous = w.poisonous;
            this.cantAttackHeroes = w.cantAttackHeroes;
        }

        public bool isEqual(Weapon w)
        {
            if (this.Angr != w.Angr)
            {
                return false;
            }

            if (this.Durability != w.Durability)
            {
                return false;
            }

            if (this.poisonous != w.poisonous)
            {
                return false;
            }

            if (this.lifesteal != w.lifesteal)
            {
                return false;
            }

            if (this.name != w.name)
            {
                return false;
            }

            return true;
        }

        public void equip(SimCard c)
        {
            this.name = c.CardId;
            this.card = c;
            this.numAttacksThisTurn = 0;

            this.Angr = c.Attack;
            this.Durability = c.Durability;

            this.windfury = c.Windfury;
            this.immune = false;
            this.lifesteal = c.Lifesteal;
            this.poisonous = c.Poisonous;
            this.cantAttackHeroes = c.CardId == CardIds.Collectible.Warrior.FoolsBane ? true : false;
        }

        public string weaponToString()
        {
            return
                $"{this.Angr} {this.Durability} {this.name} {this.card.CardId} {(this.poisonous ? 1 : 0)} {(this.lifesteal ? 1 : 0)}";
        }
    }
}