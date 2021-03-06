using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t38",
  "name": [
    "亡灵腐液",
    "Ichor of Undeath"
  ],
  "text": [
    "召唤两个在本局对战中死亡的友方随从。",
    "Summon 2 friendly minions that died this game."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 42069
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t38 : SimTemplate //* Ichor of Undeath
    {
        // Summon 2 friendly minions that died this game.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            if (p.OwnLastDiedMinion != SimCard.None)
            {
                p.callKid(p.OwnLastDiedMinion, pos, ownplay, false); //presurmise - OwnLastDiedMinion also for enemy
                p.callKid(p.OwnLastDiedMinion, pos, ownplay);
            }
        }
    }
}