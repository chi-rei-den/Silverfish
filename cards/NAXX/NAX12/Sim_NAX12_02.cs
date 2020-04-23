

/* _BEGIN_TEMPLATE_
{
  "id": "NAX12_02",
  "name": [
    "残杀",
    "Decimate"
  ],
  "text": [
    "<b>英雄技能</b>\n将所有随从的生命值变为1。",
    "<b>Hero Power</b>\nChange the Health of all minions to 1."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1891
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX12_02 : SimTemplate //* Decimate
    {
        // Hero Power: Change the Health of all minions to 1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (var m in p.ownMinions)
            {
                p.minionSetLifetoX(m, 1);
            }

            foreach (var m in p.enemyMinions)
            {
                p.minionSetLifetoX(m, 1);
            }
        }
    }
}