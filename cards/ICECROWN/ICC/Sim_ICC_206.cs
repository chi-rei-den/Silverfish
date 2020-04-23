

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_206",
  "name": [
    "变节",
    "Treachery"
  ],
  "text": [
    "选择一个友方随从，交给你的\n对手。",
    "Choose a friendly minion and give it to your opponent."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42565
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_206 : SimTemplate //* Treachery
    {
        // Choose a friendly minion. Your opponent gains control of it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetControlled(target, !ownplay, false);
        }
    }
}