

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_178b",
  "name": [
    "拔根",
    "Uproot"
  ],
  "text": [
    "+5攻击力。",
    "+5 Attack."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 7,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 182
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_178b : SimTemplate //* Uproot
    {
        //+5 Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 5, 0);
        }
    }
}