using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_833",
  "name": [
    "冰霜女巫吉安娜",
    "Frost Lich Jaina"
  ],
  "text": [
    "<b>战吼：</b>召唤一个3/6的水元素。本局对战中，你的所有元素具有<b>吸血</b>。",
    "[x]<b>Battlecry:</b> Summon a\n3/6 Water Elemental.\nYour Elementals have\n<b>Lifesteal</b> this game."
  ],
  "cardClass": "MAGE",
  "type": "HERO",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43419
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_833 : SimTemplate //* Frost Lich Jaina
    {
        // Battlecry: Summon a 3/6 Water Elemental. Your Elementals have Lifesteal for the rest of the game.

        SimCard kid = CardIds.NonCollectible.Mage.FrostLichJaina_WaterElementalToken; //Water Elemental

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIds.NonCollectible.Neutral.IcyTouchHeroic, ownplay); // Icy Touch
            if (ownplay)
            {
                p.ownHero.armor += 5;
            }
            else
            {
                p.enemyHero.armor += 5;
            }

            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay);
        }
    }
}