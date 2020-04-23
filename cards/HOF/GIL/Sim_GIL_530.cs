

/* _BEGIN_TEMPLATE_
{
  "id": "GIL_530",
  "name": [
    "阴燃电鳗",
    "Murkspark Eel"
  ],
  "text": [
    "<b>战吼：</b>\n如果你的牌库中只有法力值消耗为偶数的牌，造成2点伤害。",
    "<b>Battlecry:</b> If your deck has only even-Cost cards, deal 2 damage."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "HOF",
  "collectible": true,
  "dbfId": 46996
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    public class Sim_GIL_530 : SimTemplate //��ȼ����
    {
        /// <summary>
        /// Battlecry: If your deck has only even-Cost cards, deal 2 damage.
        /// 战吼： 如果你的牌库中只有法力值消耗为偶数的牌，造成2点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                var damage = 2;
                p.minionGetDamageOrHeal(target, damage);
                if (p.enemyMinions.Count == 0 && !p.isLethalCheck)
                {
                    p.evaluatePenality += 20;
                }
            }
        }
    }
}