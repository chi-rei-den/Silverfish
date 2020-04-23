

/* _BEGIN_TEMPLATE_
{
  "id": "CS1_129",
  "name": [
    "心灵之火",
    "Inner Fire"
  ],
  "text": [
    "使一个随从的攻击力等同于其生命值。",
    "Change a minion's Attack to be equal to its Health."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 376
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS1_129 : SimTemplate //innerfire
    {
//    setzt den angriff eines dieners auf einen wert, der seinem leben entspricht.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionSetAngrToHP(target);
        }
    }
}