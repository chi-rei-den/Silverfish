

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_611",
  "name": [
    "冰冻陷阱",
    "Freezing Trap"
  ],
  "text": [
    "<b>奥秘：</b>当一个敌方随从攻击时，将其移回拥有者的手牌，并且法力值消耗增加（2）点。",
    "<b>Secret:</b> When an enemy minion attacks, return it to its owner's hand. It costs (2) more."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 519
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_611 : SimTemplate //freezingtrap
    {
        //todo secret
        //    geheimnis:/ wenn ein feindlicher diener angreift, lasst ihn auf die hand seines besitzers zurückkehren. zusätzlich kostet er (2) mehr.

        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            p.minionReturnToHand(target, !ownplay, 2);
            target.Hp = -100;
        }
    }
}